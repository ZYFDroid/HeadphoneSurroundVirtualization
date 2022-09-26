using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using NAudio.CoreAudioApi;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi.Interfaces;
using System.Runtime.InteropServices;
using AudioCommon;

namespace 耳机虚拟环绕声
{
    public partial class FrmMain : Form,NAudio.CoreAudioApi.Interfaces.IMMNotificationClient
    {

        public int deviceLatency = 40;

       
        class StartParam
        {
            public DeviceDesc sourceDevice;
            public DeviceDesc targetDevice;
        }

        List<DeviceDesc> devices = new List<DeviceDesc>();

        public FrmMain()
        {
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            this.Size = Properties.Resources.bg_hesuvi2.Size;
        }
        #region window effect
        const int WM_PAINT = 0x000F;
        const int WM_SIZE = 0x0005;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                case WM_SIZE:
                    SetWindowRgn(m.HWnd, CreateRoundRectRgn(0, 0, this.Width, this.Height,24, 24), true);
                    break;
            }
            base.WndProc(ref m);
        }
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        void enableShadow()=> SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);

        #endregion



        private SurroundToStereoSampleProvider surroundToStereoSampleProvider;
        private AudioEnchancementSampleProvider audioEnchancementSampleProvider;
        private bool _notifyAudioDeviceChanged = false;
        


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _notifyAudioDeviceChanged = false;
                StartParam startParam = e.Argument as StartParam;
                EarTrumpet.Interop.MMDeviceAPI.AutoPolicyConfigClientWin7 policyConfigClient = new EarTrumpet.Interop.MMDeviceAPI.AutoPolicyConfigClientWin7();

                policyConfigClient.SetDefaultEndpoint(startParam.sourceDevice.id);

                surroundProc.ReportProgress(10);
                while (!surroundProc.CancellationPending)
                {
                   

                    MMDevice targetDevice = deviceEnumerator.GetDevice(startParam.sourceDevice.id); //要捕获的设备
                    MMDevice outDevice = deviceEnumerator.GetDevice(startParam.targetDevice.id); // 输出设备
                    targetDevice.AudioEndpointVolume.MasterVolumeLevel = outDevice.AudioEndpointVolume.MasterVolumeLevel;
                    AudioEndpointVolumeNotificationDelegate targetVolumeChanged = (data) =>
                     {
                         try
                         {
                             outDevice.AudioEndpointVolume.Mute = targetDevice.AudioEndpointVolume.Mute;
                             outDevice.AudioEndpointVolume.MasterVolumeLevel = targetDevice.AudioEndpointVolume.MasterVolumeLevel;

                         }
                         catch { }
                     };
                    targetDevice.AudioEndpointVolume.OnVolumeNotification += targetVolumeChanged;
                    var targetFormat = targetDevice.AudioClient.MixFormat;
                    WasapiCapture wasapiCapture = new LowLanceyLoopbackCapture(targetDevice, deviceLatency); //对虚拟声卡进行捕获
                    
                    BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(wasapiCapture.WaveFormat);

                    int prefillLen = deviceLatency/9; //玄学调参：只要除以9就可以避免卡顿？我也不知道为什么
                    prefillLen *= bufferedWaveProvider.WaveFormat.SampleRate;
                    prefillLen /= 1000;
                    prefillLen *= bufferedWaveProvider.WaveFormat.Channels;
                    prefillLen *= bufferedWaveProvider.WaveFormat.BitsPerSample;

                    byte[] prefillEmptyBuffer = new byte[prefillLen];

                    bufferedWaveProvider.BufferDuration = TimeSpan.FromMilliseconds(deviceLatency * 2);
                    bufferedWaveProvider.DiscardOnBufferOverflow = true;
                    wasapiCapture.DataAvailable += (_, waveArgs) =>
                    {
                        if(bufferedWaveProvider.BufferedDuration.Milliseconds == 0)//underflow detect
                        {
                            bufferedWaveProvider.AddSamples(prefillEmptyBuffer, 0, prefillEmptyBuffer.Length);
                            //underflowCount++;
                        }
                        if(bufferedWaveProvider.BufferedDuration.Milliseconds > deviceLatency * 2 * 95 / 100)//Overflow detect
                        {
                            bufferedWaveProvider.Read(prefillEmptyBuffer, 0, prefillEmptyBuffer.Length);
                            Array.Clear(prefillEmptyBuffer,0,prefillEmptyBuffer.Length);
                            //overflowCount++;
                        }
                        bufferedWaveProvider.AddSamples(waveArgs.Buffer, 0, waveArgs.BytesRecorded);
                    };
                    try
                    {
                        wasapiCapture.StartRecording();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            wasapiCapture?.Dispose();
                        }
                        catch { }
                        System.Threading.Thread.Sleep(514);
                        continue;
                    }
                    WaveToSampleProvider waveToSampleProvider = new WaveToSampleProvider(bufferedWaveProvider);
                    surroundToStereoSampleProvider = new SurroundToStereoSampleProvider(waveToSampleProvider,Program.SurroundSettings.customIrPath); //实现算法
                    surroundToStereoSampleProvider.applySettings(Program.SurroundSettings, true);
                    
                    audioEnchancementSampleProvider = new AudioEnchancementSampleProvider(surroundToStereoSampleProvider, Program.AudioEnchancementData.getDeviceParam(outDevice.ID));
                    WasapiOut wasapiOut = null;
                    try
                    {
                        wasapiOut = new WasapiOut(outDevice, AudioClientShareMode.Shared, true, deviceLatency + deviceLatency / 2); //从我们的立体声耳机创建一个声音输出
                        wasapiOut.Init(audioEnchancementSampleProvider);
                        wasapiOut.Play(); //开始环绕
                    }catch(Exception ex)
                    {
                        _notifyAudioDeviceChanged = true;
                    }
                    while (!surroundProc.CancellationPending)
                    {
                        System.Threading.Thread.Sleep(20);
                        surroundProc.ReportProgress(30);
                        if (_notifyAudioDeviceChanged)
                        {
                            System.Threading.Thread.Sleep(  114  );
                            _notifyAudioDeviceChanged = false;
                            DevicePriority newDevice = null;
                            while(!surroundProc.CancellationPending && newDevice == null)
                            {
                                newDevice = deviceDecider.OnDeviceChanged(outDevice.ID,devices.Where(d => d.id != targetDevice.ID).Select(d => d.id).ToArray());
                                if(newDevice == null)
                                {
                                    System.Threading.Thread.Sleep(  514  );
                                    /*
                                    问：修复这个不稳定的问题花了多久
                                    答：九时啊
                                    问：修完bug要去吃什么庆祝
                                    答：酒食啊
                                    问：最初是怎样想到做这个软件的
                                    答：旧事啊
                                    问：帮忙编译fft_convolver的是你的什么人
                                    答：旧识啊
                                    问：平时有了写代码的灵感会怎么办
                                    答：速打哟（指迅速将代码打出来）
                                    问：你就会这一句是吗（恼）
                                    答：就是啊
                                    你是一个一个一个开发者啊啊啊
                                     */
                                }
                            }
                            
                            if (newDevice.DeviceID != startParam.targetDevice.id) {
                                startParam.targetDevice.id = newDevice.DeviceID;
                                break;
                            }
                        }
                    }
                    targetDevice.AudioEndpointVolume.OnVolumeNotification -= targetVolumeChanged;
                    wasapiCapture.StopRecording();
                    wasapiOut?.Stop();
                    wasapiOut?.Dispose();
                    wasapiCapture.Dispose();
                    surroundToStereoSampleProvider = null;
                    audioEnchancementSampleProvider = null;
                    
                }
                policyConfigClient.SetDefaultEndpoint(startParam.targetDevice.id);
                surroundProc.ReportProgress(99);
            }
            catch (Exception ex)
            {
                surroundProc.ReportProgress(44, ex.ToString());
            }
        }

        MP3模拟器.CtlBarMeter[] bars;

        MMDeviceEnumerator deviceEnumerator;
        DeviceDecider deviceDecider;
        Toaster.Toast Toast;
        private void Form1_Load(object sender, EventArgs e)
        {
            Toast = new Toaster.Toast(this,label11.Font);
            deviceDecider = new DeviceDecider(Program.DevicePriorityList);
            deviceEnumerator = new MMDeviceEnumerator();
            loadData();
            
            chkShowAllDevice.CheckedChanged -= chkShowAllDevice_CheckedChanged;
            chkShowAllDevice.Checked = Program.SurroundSettings.ignoreOutputChannelCount;
            chkShowAllDevice.CheckedChanged += chkShowAllDevice_CheckedChanged;
            if (cmbSrc.Enabled == false)
            {
                var r = MessageBox.Show(this,"检测到未安装虚拟音频设备，是否打开安装向导？","",MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    new FrmConfig().ShowDialog(this);
                }
            }
            deviceEnumerator.RegisterEndpointNotificationCallback(this);
            bars = new MP3模拟器.CtlBarMeter[] {
                barFL,barFR,barFC,barLF,barRL,barRR,barSL,barSR
            };

            
            numCompressAttack.Value = (int)Program.SurroundSettings.cmpAttack;
            numCompressGate.Value = (int)(Program.SurroundSettings.cmpGate * 10);

            numCompressRatio.Value = (int)(Program.SurroundSettings.cmpRatio *10);
            if(Program.SurroundSettings.cmpRatio < 0.01)
            {
                numCompressRatio.Value = 800;
            }
            numCompressRelease.Value = (int)Program.SurroundSettings.cmpRelease;
            numMasterGain.Value =(int)Math.Round(Program.SurroundSettings.masterGain * 100f);
            numCompress_ValueChanged(null, null);
            numMasterGain_Scroll(null, null);
            chkLowLancey.Checked = Program.SurroundSettings.lowLancey;
            chkFc2F.Checked = Program.SurroundSettings.rerouteFrontCenter;
            saveCustomIrConfig(Program.SurroundSettings.customIrPath);
            Program.needSave = false;

            lblVersion.Text ="v"+ Application.ProductVersion;
            loaded = true;
        }
        private bool loaded = false;
        private void loadData()
        {
            var result = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active | DeviceState.Disabled);
            devices.Clear();
            foreach (var item in result)
            {
                try
                {
                    DeviceDesc deviceDesc = new DeviceDesc();
                    deviceDesc.name = item.FriendlyName;
                    deviceDesc.id = item.ID;
                    deviceDesc.channels = item.AudioClient.MixFormat.Channels;
                    devices.Add(deviceDesc);
                }
                catch
                {

                }
            }

            cmbSrc.setDict(devices.Where(c => c.channels == 8).ToDictionary(d => d.name));
            
            cmbDst.setDict(devices.Where(c => Program.SurroundSettings.ignoreOutputChannelCount || c.channels == 2).ToDictionary(d => d.name));
            if (cmbDst.Enabled)
            {
                var defaultDeviceId = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia).ID;
                var deviceIdArray = devices.Where(c => c.channels == 2).Select(d => d.id).ToArray();
                if (deviceIdArray.Contains(defaultDeviceId))
                {
                    cmbDst.SelectedValue = devices.FirstOrDefault(d => d.id == defaultDeviceId);
                }
                else
                {
                    DevicePriority devp = deviceDecider.GetSuggest(deviceIdArray);
                    if(devp != null)
                    {
                        cmbDst.SelectedValue = devices.FirstOrDefault(d => d.id == devp.DeviceID);
                    }
                }
            }
            foreach (var device in devices)
            {
                if (device.name.ToLower().Contains("cable"))
                {
                    cmbSrc.SelectedValue = device;
                }
            }
        }

        private bool surroundIsOn = false;

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!surroundIsOn)
            {
                DeviceDesc src = cmbSrc.SelectedValue as DeviceDesc;
                DeviceDesc dst = cmbDst.SelectedValue as DeviceDesc;
                if(src == null)
                {
                    Toast.ShowMessage("请选择虚拟环绕声设备");
                    return;
                }
                if (dst == null)
                {
                    Toast.ShowMessage("请选择输出设备");
                    return;
                }
                if (src.id == dst.id)
                {
                    Toast.ShowMessage("你不能选择相同的设备");
                    return;
                }
                btnBegin.Enabled = false;
                StartParam sp = new StartParam();
                sp.sourceDevice = src;
                sp.targetDevice = dst;
                deviceDecider.OnStart(dst.id,devices.Select(d => d.id).ToArray());
                chkBypass.Checked = false;
                this.deviceLatency = chkLowLancey.Checked ? 40 : 200;
                surroundProc.RunWorkerAsync(sp);

            }
            else
            {
                btnBegin.Enabled = false;
                surroundProc.CancelAsync();
            }
            
        }



        private void surroundProc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage == 30)
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    doTimer();
                }
                return;
            }
            if(e.ProgressPercentage == 44)
            {
                MessageBox.Show(e.UserState.ToString(),"出错了");
                btnBegin.Enabled = true;
                btnBegin.Image = Properties.Resources.btnSurroundOn;
                lblStatus.Text = "已关闭";
                surroundIsOn = false;
            }
            if(e.ProgressPercentage == 10)
            {
                btnBegin.Enabled = true;
                btnBegin.Image = Properties.Resources.btnSurroundOff;

                lblStatus.Text = "已开启";
                surroundIsOn = true;
            }
            if (e.ProgressPercentage == 99)
            {
                btnBegin.Enabled = true;
                btnBegin.Image = Properties.Resources.btnSurroundOn;

                lblStatus.Text = "已关闭";
                surroundIsOn = false;
                mtmOutL.Reset();
                mtmOutR.Reset();
                for (int i = 0; i < bars.Length; i++)
                {
                    bars[i].Reset();
                }
            }
        }

        const float displayDbRange = 60;

        private void doTimer()
        {
            mtmOutL.Value = (MathHelper.linear2db(surroundToStereoSampleProvider.outLeft) + displayDbRange) / displayDbRange;
            mtmOutR.Value = (MathHelper.linear2db(surroundToStereoSampleProvider.outRight) + displayDbRange) / displayDbRange;
            this.numCompressOverflow1.Value =  (MathHelper.linear2db(surroundToStereoSampleProvider._compressorGain)) / displayDbRange;
            for (int i = 0; i < surroundToStereoSampleProvider.rawPeaks.Length; i++)
            {
                bars[i].Value = (MathHelper.linear2db(surroundToStereoSampleProvider.rawPeaks[i]) + displayDbRange) / displayDbRange;
            }
        }

        private void surroundProc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.WindowsShutDown)
            {
                surroundProc.CancelAsync();
                return;
            }
            e.Cancel = surroundIsOn;
            if (e.Cancel) { return; }
        }

        private void numMasterGain_Scroll(object sender, EventArgs e)
        {
            Program.SurroundSettings.masterGain = numMasterGain.Value / 100f;
            surroundToStereoSampleProvider?.applySettings(Program.SurroundSettings); 
            numMasterGain.ThumbText = $"{Program.SurroundSettings.masterGain.ToString("00.00")}dB";
            Program.needSave = true;
        }

        private void numCompress_ValueChanged(object sender, EventArgs e)
        {
            var s = Program.SurroundSettings;
            if (loaded)
            {
                s.cmpGate = numCompressGate.Value / 10f;
                s.cmpRatio = (numCompressRatio.Value + 10f) / 10f;
                if (s.cmpRatio > 79.9)
                {
                    s.cmpRatio = 0;
                }
                s.cmpAttack = (float)Math.Round(numCompressAttack.Value / 1f);
                s.cmpRelease = (float)Math.Round(numCompressRelease.Value / 1f);
            }
            numCompressAttack.ThumbText = $"{s.cmpAttack}ms";
            numCompressGate.ThumbText = $"{s.cmpGate}dB";
            numCompressRatio.ThumbText = (s.cmpRatio == 0 ? "∞" : s.cmpRatio.ToString())+":1";
            numCompressRelease.ThumbText = $"{s.cmpRelease}ms";
            surroundToStereoSampleProvider?.applySettings(s);
            surroundToStereoSampleProvider?.applySettings(Program.SurroundSettings);
            Program.needSave = true;

        }

        void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            notifyDeviceChanged();
        }

        void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId)
        {
            notifyDeviceChanged();
        }

        void IMMNotificationClient.OnDeviceRemoved(string deviceId)
        {
            notifyDeviceChanged();
        }

        void notifyDeviceChanged()
        {
            Invoke(new Action(()=>
            {
                updateDeviceCountdown = 10;
                updateDeviceCountdownTimer.Enabled = true;
            }));
            
        }

        void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
            
        }

        void IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
            
        }

        private void chkBypass_CheckedChanged(object sender, EventArgs e)
        {
            if(surroundToStereoSampleProvider != null)
            {
                surroundToStereoSampleProvider.Bypass = chkBypass.Checked;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new FrmConfig().ShowDialog(this);
            loadData();
        }

        private void chkLowLancey_CheckedChanged(object sender, EventArgs e)
        {
            Program.SurroundSettings.lowLancey = chkLowLancey.Checked;
            Program.needSave = true;
        }

        private void chkFc2F_CheckedChanged(object sender, EventArgs e)
        {
            Program.SurroundSettings.rerouteFrontCenter = chkFc2F.Checked;
            Program.needSave = true;
            surroundToStereoSampleProvider?.applySettings(Program.SurroundSettings);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (surroundIsOn)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                Close();
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002; 
        private void dragger_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        private Control[] pages = null;
        private Button[] pageButtons = null;
        private void initPage()
        {
            pages = new Control[] {panelPage1,panelPage2,panelPage3,panelPage4 };
            pageButtons = new Button[] {btnPage1,btnPage2,btnPage3,btnPage4}; 
        }
        private int currentPage = 0;
        private void switchPage(int p)
        {
            if(pages == null)
            {
                initPage();
            }
            if(currentPage == p) { return; }
            pageButtons[currentPage].Image = null;
            pageButtons[currentPage].ForeColor = Color.LightGray;
            pageButtons[p].Image = Properties.Resources.rightIndicator;
            pageButtons[p].ForeColor = Color.White;

            pages[currentPage].Location = posHide.Location;
            pages[p].Location = posShow.Location;
            currentPage = p;
        }

        private void btnPage1_Click(object sender, EventArgs e)
        {
            switchPage(int.Parse(((Control)sender).Tag.ToString())-1);
        }

        private void aboutClick(object sender, EventArgs e)
        {
            Control which = sender as Control;
            if(which.Tag != null)
            {
                string text = which.Tag.ToString();
                System.Diagnostics.Process.Start(text);
            }
        }

        class TestSurroundSampleProvider : ISampleProvider, IDisposable
        {
            private NAudio.Vorbis.VorbisSampleProvider sampleProvider0;
            private NAudio.Vorbis.VorbisSampleProvider sampleProvider1;
            private NAudio.Vorbis.VorbisSampleProvider sampleProvider2;
            private NAudio.Vorbis.VorbisSampleProvider sampleProvider3;
            public TestSurroundSampleProvider()
            {
                sampleProvider0 = new NAudio.Vorbis.VorbisSampleProvider(new MemoryStream(Properties.Resources.testsurround_0), true);
                sampleProvider1 = new NAudio.Vorbis.VorbisSampleProvider(new MemoryStream(Properties.Resources.testsurround_1), true);
                sampleProvider2 = new NAudio.Vorbis.VorbisSampleProvider(new MemoryStream(Properties.Resources.testsurround_2), true);
                sampleProvider3 = new NAudio.Vorbis.VorbisSampleProvider(new MemoryStream(Properties.Resources.testsurround_3), true);
                _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleProvider0.WaveFormat.SampleRate, 8);
            }
            private WaveFormat _waveFormat;
            WaveFormat ISampleProvider.WaveFormat => _waveFormat;
            float[] frame = new float[2];
            int ISampleProvider.Read(float[] buffer, int offset, int count)
            {
                int read = 0;
                for (int i = offset; i < offset+count; i+=8)
                {
                    if(sampleProvider0.Read(frame,0,2) <= 0) { return read; }
                    buffer[i] = frame[0];
                    buffer[i+1] = frame[1];
                    if (sampleProvider1.Read(frame, 0, 2) <= 0) { return read; }
                    buffer[i+2] = frame[0];
                    buffer[i + 3] = frame[1];
                    if (sampleProvider2.Read(frame, 0, 2) <= 0) { return read; }
                    buffer[i+4] = frame[0];
                    buffer[i + 5] = frame[1];
                    if (sampleProvider3.Read(frame, 0, 2) <= 0) { return read; }
                    buffer[i+6] = frame[0];
                    buffer[i + 7] = frame[1];
                    read += 8;
                }
                return read;
            }

            public void Dispose()
            {
                safeDispose(sampleProvider0,sampleProvider1,sampleProvider2,sampleProvider3);   
            }
            private void safeDispose(params IDisposable[] d)
            {
                foreach (var item in d)
                {

                    try { item?.Dispose(); } catch { }
                }
            }
        }
        private WasapiOut waveOut = null;
        private TestSurroundSampleProvider waveFileReader = null;
        private void btnTest_Click(object sender, EventArgs e)
        {

            btnTest.Enabled = false;
            if (waveOut == null)
            {
                waveFileReader = new TestSurroundSampleProvider();
                waveOut = new WasapiOut();
                waveOut.Init(waveFileReader);
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
                waveOut.Play();
            }
            else
            {
                waveOut.Stop();
            }

            btnTest.Enabled = true;
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            safeDispose(waveOut, waveFileReader);
            waveOut = null;
            waveFileReader = null;
        }

        private void safeDispose(params IDisposable[] d)
        {
            foreach (var item in d)
            {

                try { item?.Dispose(); } catch { }
            }
        }

        private void btnSwitchConvolver_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try
                {
                    surroundToStereoSampleProvider?.switchIrFile(path);
                   
                    saveCustomIrConfig(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveCustomIrConfig(string path)
        {
            Program.SurroundSettings.customIrPath = path;
            lblConvolver.Text = Program.SurroundSettings.customIrPath ?? "默认";
            Program.needSave = true;
        }

        private void btnResetConvolver_Click(object sender, EventArgs e)
        {
            surroundToStereoSampleProvider?.switchIrFile(null);
            saveCustomIrConfig(null);
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void chkShowAllDevice_CheckedChanged(object sender, EventArgs e)
        {
            Program.SurroundSettings.ignoreOutputChannelCount = chkShowAllDevice.Checked;
            loadData();
            Program.needSave = true;
        }

        private void btnEnchanceAudio__Click(object sender, EventArgs e)
        {
            DeviceDesc dst = cmbDst.SelectedValue as DeviceDesc;
            if (dst == null)
            {
                Toast.ShowMessage("请选择输出设备");
                return;
            }
            string profileGuid = Program.AudioEnchancementData.getDeviceParam(dst.id) == null ? "" : Program.AudioEnchancementData.getDeviceParam(dst.id).guid;
            if (frmEqManage == null)
            {
                frmEqManage = new FrmEQManage(audioEnchancementSampleProvider, profileGuid, dst);
                frmEqManage.FormClosed += FrmEqManage_FormClosed;
                frmEqManage.Show(this);
            }
            else
            {
                frmEqManage.Activate();
                if(frmEqManage.WindowState == FormWindowState.Minimized)
                {
                    frmEqManage.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void FrmEqManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEqManage?.Dispose();
            frmEqManage = null;
        }

        private FrmEQManage frmEqManage = null;


        private int updateDeviceCountdown = 0;
        private void updateDeviceCountdownTimer_Tick(object sender, EventArgs e)
        {
            updateDeviceCountdown--;
            if(updateDeviceCountdown < 0)
            {
                if (surroundProc.IsBusy && !surroundProc.CancellationPending)
                {
                    _notifyAudioDeviceChanged = true;
                }
                loadData();
                updateDeviceCountdownTimer.Stop();
            }
        }

        private void btnResetDevicePriority_Click(object sender, EventArgs e)
        {
            Program.DevicePriorityList.Clear();
            Program.save();
            loadData();
            Toast.ShowMessage("已清除设备优先级配置");
        }

        private void btnExportIR__Click(object sender, EventArgs e)
        {
            if (surroundIsOn)
            {
                Toast.ShowMessage("关闭环绕声之后才可以进行导出。");
                return;
            }
            DeviceDesc targetDevice = (cmbDst.SelectedValue) as DeviceDesc;

            if(targetDevice == null)
            {
                Toast.ShowMessage("未选择要创建的目标设备。");
                return;
            }
            var deviceParam = Program.AudioEnchancementData.getDeviceParam(targetDevice.id);
            var shouldCreate = MessageBox.Show(this, $"是否创建脉冲样本？以下是创建配置：\r\n\r\n环绕样本：{lblConvolver.Text}\r\n目标设备：{targetDevice.name}\r\n配置文件：{(deviceParam == null ? "无" : deviceParam.DisplayName)}", "创建脉冲样本",MessageBoxButtons.YesNo);
            if(shouldCreate != DialogResult.Yes) { return; }

            if(saveFileDialog1.ShowDialog(this) != DialogResult.OK) { return; }

            string savePath = saveFileDialog1.FileName;

            var irgen = new IRGen();
            var stage1 = new SurroundToStereoSampleProvider(irgen, Program.SurroundSettings.customIrPath); //实现算法
            stage1.applySettings(Program.SurroundSettings, true);
            var stage2 = new AudioEnchancementSampleProvider(stage1, deviceParam);

            var channels = new float[48000 * 2 * 2];

            int required = channels.Length;
            int offset = 0;
            while(required > 0)
            {
                int len = stage2.Read(channels, offset, required);
                required -= len;
                offset += len;
            }
            var tempfile = Path.GetTempFileName();
            
            WaveFileWriter wfw = new WaveFileWriter(savePath, WaveFormat.CreateIeeeFloatWaveFormat(48000,4));
            float[] singleSample = new float[4];
            for (int i = 0; i < 48000; i++)
            {
                singleSample[0] = channels[i * 2];
                singleSample[1] = channels[i * 2+1];
                singleSample[2] = channels[96000 + i * 2];
                singleSample[3] = channels[96000 + i * 2+1];
                wfw.WriteSamples(singleSample, 0, 4);
            }
            wfw.Dispose();
            Toast.ShowMessage("创建成功！");
        }

        private class IRGen : ISampleProvider
        {
            private WaveFormat _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(48000, 8);
            public WaveFormat WaveFormat => _waveFormat;

            private int ptr = 0;
            private int max = 96000;
            public int Read(float[] buffer, int offset, int count)
            {
                int readed = 0;
                for (int i = offset; i < count + offset; i+=8)
                {
                    buffer[i + 0] = 0;
                    buffer[i + 1] = 0;
                    buffer[i + 2] = 0;
                    buffer[i + 3] = 0;
                    buffer[i + 4] = 0;
                    buffer[i + 5] = 0;
                    buffer[i + 6] = 0;
                    buffer[i + 7] = 0;


                    if (ptr == 1)
                    {
                        buffer[i] = 0.9f;
                    }
                    if(ptr == 48000 + 1)
                    {
                        buffer[i + 1] = 0.9f;
                    }

                    readed += 8;

                    ptr++;

                }
                return readed;
            }

        }
    }
}
