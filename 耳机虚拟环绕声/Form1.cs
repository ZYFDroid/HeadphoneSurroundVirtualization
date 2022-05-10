using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.CoreAudioApi;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi.Interfaces;

namespace 耳机虚拟环绕声
{
    public partial class Form1 : Form,NAudio.CoreAudioApi.Interfaces.IMMNotificationClient
    {

        public int deviceLancey = 40;

        class DeviceDesc
        {
            public string name;
            public string id;
            public int channels = 0;

            public override bool Equals(object obj)
            {
                return obj is DeviceDesc desc &&
                       id == desc.id;
            }

            public override int GetHashCode()
            {
                return 1877310944 + EqualityComparer<string>.Default.GetHashCode(id);
            }
        }
        class StartParam
        {
            public DeviceDesc sourceDevice;
            public DeviceDesc targetDevice;
        }

        List<DeviceDesc> devices = new List<DeviceDesc>();

        public Form1()
        {
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
        }

        private SurroundToStereoSampleProvider surroundToStereoSampleProvider;

        private bool _notifyAudioDeviceChanged = false;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _notifyAudioDeviceChanged = false;
                StartParam startParam = e.Argument as StartParam;

                surroundProc.ReportProgress(10);
                while (!surroundProc.CancellationPending)
                {
                    EarTrumpet.Interop.MMDeviceAPI.AutoPolicyConfigClientWin7 policyConfigClient = new EarTrumpet.Interop.MMDeviceAPI.AutoPolicyConfigClientWin7();

                    policyConfigClient.SetDefaultEndpoint(startParam.sourceDevice.id);


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
                    //Console.ReadLine();
                    var targetFormat = targetDevice.AudioClient.MixFormat;
                    WasapiCapture wasapiCapture = new LowLanceyLoopbackCapture(targetDevice, deviceLancey); //对虚拟声卡进行捕获
                    WasapiOut wasapiOut = new WasapiOut(outDevice, AudioClientShareMode.Shared, true, deviceLancey + deviceLancey / 2 ); //从我们的立体声耳机创建一个声音输出
                    BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(wasapiCapture.WaveFormat);

                    int prefillLen = deviceLancey/9; //玄学调参：只要除以9就可以避免卡顿？我也不知道为什么
                    prefillLen *= bufferedWaveProvider.WaveFormat.SampleRate;
                    prefillLen /= 1000;
                    prefillLen *= bufferedWaveProvider.WaveFormat.Channels;
                    prefillLen *= bufferedWaveProvider.WaveFormat.BitsPerSample;

                    byte[] prefillEmptyBuffer = new byte[prefillLen];

                    bufferedWaveProvider.BufferDuration = TimeSpan.FromMilliseconds(deviceLancey * 2);
                    bufferedWaveProvider.DiscardOnBufferOverflow = true;
                    wasapiCapture.DataAvailable += (_, waveArgs) =>
                    {
                        if(bufferedWaveProvider.BufferedDuration.Milliseconds == 0)
                        {
                            bufferedWaveProvider.AddSamples(prefillEmptyBuffer, 0, prefillEmptyBuffer.Length);
                            
                        }
                        bufferedWaveProvider.AddSamples(waveArgs.Buffer, 0, waveArgs.BytesRecorded);
                    };
                    wasapiCapture.StartRecording();
                    WaveToSampleProvider waveToSampleProvider = new WaveToSampleProvider(bufferedWaveProvider);
                    surroundToStereoSampleProvider = new SurroundToStereoSampleProvider(waveToSampleProvider); //实现算法
                    surroundToStereoSampleProvider.applySettings(Program.SurroundSettings, true);

                    

                    wasapiOut.Init(surroundToStereoSampleProvider);
                    wasapiOut.Play(); //开始环绕
                    while (!surroundProc.CancellationPending)
                    {
                        System.Threading.Thread.Sleep(10);
                        surroundProc.ReportProgress(30);
                        if (_notifyAudioDeviceChanged)
                        {
                            _notifyAudioDeviceChanged = false;
                            DevicePriority newDevice = deviceDecider.OnDeviceChanged(startParam.targetDevice.id,devices.Select(d => d.id).ToArray());
                            if(newDevice == null)
                            {
                                surroundProc.CancelAsync();
                                break;
                            }
                            if(newDevice.DeviceID != startParam.targetDevice.id) {
                                startParam.targetDevice.id = newDevice.DeviceID;
                                break;
                            }
                        }
                    }
                    targetDevice.AudioEndpointVolume.OnVolumeNotification -= targetVolumeChanged;
                    wasapiCapture.StopRecording();
                    wasapiOut.Stop();
                    wasapiOut.Dispose();
                    wasapiCapture.Dispose();
                    policyConfigClient.SetDefaultEndpoint(startParam.targetDevice.id);
                }

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
        private void Form1_Load(object sender, EventArgs e)
        {
            deviceDecider = new DeviceDecider(Program.DevicePriorityList);
            deviceEnumerator = new MMDeviceEnumerator();
            loadData();

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

            numCompressAttack.Value = Program.SurroundSettings.cmpAttack;
            numCompressGate.Value = Program.SurroundSettings.cmpGate + 20;
            numCompressRatio.Value = Program.SurroundSettings.cmpRatio -1;
            numCompressRelease.Value = Program.SurroundSettings.cmpRelease;
            numMasterGain.Value =(int)Math.Round(Program.SurroundSettings.masterGain * 100f);
            numCompress_ValueChanged(null, null);
            numMasterGain_Scroll(null, null);
            chkLowLancey.Checked = Program.SurroundSettings.lowLancey;
            Program.neenSave = false;
        }

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
            
            cmbDst.setDict(devices.Where(c => c.channels == 2).ToDictionary(d => d.name));
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

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!lblIndicator.Visible)
            {
                DeviceDesc src = cmbSrc.SelectedValue as DeviceDesc;
                DeviceDesc dst = cmbDst.SelectedValue as DeviceDesc;
                if(src == null)
                {
                    MessageBox.Show("请选择虚拟环绕声设备");
                    return;
                }
                if (dst == null)
                {
                    MessageBox.Show("请选择输出设备");
                    return;
                }
                if (src.id == dst.id)
                {
                    MessageBox.Show("你不能选择相同的设备");
                    return;
                }
                btnBegin.Enabled = false;
                StartParam sp = new StartParam();
                sp.sourceDevice = src;
                sp.targetDevice = dst;
                deviceDecider.OnStart(dst.id,devices.Select(d => d.id).ToArray());
                chkBypass.Checked = false;
                this.deviceLancey = chkLowLancey.Checked ? 40 : 160;
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
                lblIndicator.Visible = false;
            }
            if(e.ProgressPercentage == 10)
            {
                btnBegin.Enabled = true;
                btnBegin.Image = Properties.Resources.btnSurroundOff;
                lblIndicator.Visible = true;
            }
            if (e.ProgressPercentage == 99)
            {
                btnBegin.Enabled = true;
                btnBegin.Image = Properties.Resources.btnSurroundOn;
                lblIndicator.Visible = false;
                mtmOutL.Reset();
                mtmOutR.Reset();
                numCompressOverflow.Reset();
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
            this.numCompressOverflow.Value = (-MathHelper.linear2db(surroundToStereoSampleProvider._compressorGain)) / displayDbRange;
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
            e.Cancel = lblIndicator.Visible;
            if (e.Cancel) { return; }
        }

        private void numMasterGain_Scroll(object sender, EventArgs e)
        {
            Program.SurroundSettings.masterGain = numMasterGain.Value / 100f;
            surroundToStereoSampleProvider?.applySettings(Program.SurroundSettings);
            lblMasterGain.Text = $"{Program.SurroundSettings.masterGain}dB\r\n增益";
            Program.neenSave = true;
        }

        private void numCompress_ValueChanged(object sender, EventArgs e)
        {
            var s = Program.SurroundSettings;
            s.cmpGate = (float) Math.Round(numCompressGate.Value - 20f,2);
            s.cmpRatio = (float)Math.Round(numCompressRatio.Value +1,1);
            if(s.cmpRatio > 79.9)
            {
                s.cmpRatio = 0;
            }
            s.cmpAttack = (float)Math.Round(numCompressAttack.Value);
            s.cmpRelease = (float)Math.Round(numCompressRelease.Value);
            lblCompressAttack.Text = $"{s.cmpAttack}ms\r\n启动时间";
            lblCompressGate.Text = $"{s.cmpGate}dB\r\n噪音门限";
            lblCompressRatio.Text = (s.cmpRatio == 0 ? "∞" : s.cmpRatio.ToString())+":1\r\n压缩比";
            lblCompressRelease.Text = $"{s.cmpRelease}ms\r\n释放时间";
            surroundToStereoSampleProvider?.applySettings(s);
            Program.neenSave = true;
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
            Invoke(new Action(loadData));
            if(surroundProc.IsBusy && !surroundProc.CancellationPending)
            {
                _notifyAudioDeviceChanged = true;
            }
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
        }

        private void chkLowLancey_CheckedChanged(object sender, EventArgs e)
        {
            Program.SurroundSettings.lowLancey = chkLowLancey.Checked;
            Program.neenSave = true;
        }
    }
}
