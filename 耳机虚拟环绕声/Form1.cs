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

namespace 耳机虚拟环绕声
{
    public partial class Form1 : Form
    {

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                StartParam startParam = e.Argument as StartParam;

                MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
                var result = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active | DeviceState.Disabled);
                MMDevice targetDevice = null; //要捕获的设备
                MMDevice outDevice = null; // 输出设备
                foreach (var item in result)
                {
                    Console.WriteLine(item.DeviceFriendlyName);
                    if (item.ID == startParam.sourceDevice.id) //获取虚拟声卡
                    {
                        targetDevice = item;
                    }
                    if (item.ID == startParam.targetDevice.id) //获取当前的立体声耳机
                    {
                        outDevice = item;
                    }
                }
                //Console.ReadLine();
                var targetFormat = targetDevice.AudioClient.MixFormat;
                WasapiCapture wasapiCapture = new LowLanceyLoopbackCapture(targetDevice, 50); //对虚拟声卡进行捕获
                WasapiOut wasapiOut = new WasapiOut(outDevice, AudioClientShareMode.Shared, true, 50); //从我们的立体声耳机创建一个声音输出
                BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(wasapiCapture.WaveFormat);
                bufferedWaveProvider.BufferDuration = TimeSpan.FromMilliseconds(50);
                bufferedWaveProvider.DiscardOnBufferOverflow = true;
                wasapiCapture.DataAvailable += (_, waveArgs) =>
                {
                    bufferedWaveProvider.AddSamples(waveArgs.Buffer, 0, waveArgs.BytesRecorded);
                };
                wasapiCapture.StartRecording();
                WaveToSampleProvider waveToSampleProvider = new WaveToSampleProvider(bufferedWaveProvider);
                surroundToStereoSampleProvider = new SurroundToStereoSampleProvider(waveToSampleProvider); //实现算法
                surroundToStereoSampleProvider.applySettings(Program.SurroundSettings,true);
                wasapiOut.Init(surroundToStereoSampleProvider);
                wasapiOut.Play(); //开始环绕
                surroundProc.ReportProgress(10);
                while (!surroundProc.CancellationPending)
                {
                    System.Threading.Thread.Sleep(10);
                    surroundProc.ReportProgress(30);
                }
                wasapiCapture.StopRecording();
                surroundProc.ReportProgress(99);
                wasapiOut.Stop();
                wasapiOut.Dispose();
                wasapiCapture.Dispose();
            }catch (Exception ex)
            {
                surroundProc.ReportProgress(44, ex.ToString());
            }
        }

        MP3模拟器.CtlBarMeter[] bars;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            var result = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active | DeviceState.Disabled);
            foreach (var item in result)
            {
                try
                {
                    DeviceDesc deviceDesc = new DeviceDesc();
                    deviceDesc.name = item.FriendlyName;
                    deviceDesc.id = item.ID;
                    deviceDesc.channels = item.AudioClient.MixFormat.Channels;
                    devices.Add(deviceDesc);
                }catch 
                {

                }
            }
            
            cmbSrc.setDict(devices.Where(c => c.channels > 2).ToDictionary(d => d.name));
            cmbDst.setDict(devices.Where(c => c.channels == 2).ToDictionary(d => d.name));
            foreach(var device in devices)
            {
                if (device.name.ToLower().Contains("cable"))
                {
                    cmbSrc.SelectedValue = device;
                }
            }

            bars = new MP3模拟器.CtlBarMeter[] {
                barFL,barFR,barFC,barLF,barRL,barRR,barSL,barSR
            };
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
            }
        }

        const float displayDbRange = 60;

        private void doTimer()
        {
            mtmOutL.Value = (MathHelper.linear2db(surroundToStereoSampleProvider.displayLeft) + displayDbRange) / displayDbRange;
            mtmOutR.Value = (MathHelper.linear2db(surroundToStereoSampleProvider.displayRight) + displayDbRange) / displayDbRange;
            this.numCompressOverflow.Value = (-surroundToStereoSampleProvider._compressGain) / displayDbRange;
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
            e.Cancel = lblIndicator.Visible;
        }

        private void numMasterGain_Scroll(object sender, EventArgs e)
        {
            Program.SurroundSettings.masterGain = numMasterGain.Value / 100f;
            surroundToStereoSampleProvider?.applySettings(Program.SurroundSettings);
            lblMasterGain.Text = $"{Program.SurroundSettings.masterGain}dB\r\n增益";
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
        }
    }
}
