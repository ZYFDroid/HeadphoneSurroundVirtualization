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
            
        }

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
                SurroundToStereoSampleProvider surroundToStereoSampleProvider = new SurroundToStereoSampleProvider(waveToSampleProvider); //实现算法
                wasapiOut.Init(surroundToStereoSampleProvider);
                wasapiOut.Play(); //开始环绕
                surroundProc.ReportProgress(10);
                while (!surroundProc.CancellationPending)
                {
                    System.Threading.Thread.Sleep(500);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            var result = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active | DeviceState.Disabled);
            foreach (var item in result)
            {
                DeviceDesc deviceDesc = new DeviceDesc();
                deviceDesc.name = item.FriendlyName;
                deviceDesc.id = item.ID;
                deviceDesc.channels = item.AudioClient.MixFormat.Channels;
                devices.Add(deviceDesc);
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
            if(e.ProgressPercentage == 44)
            {
                MessageBox.Show(e.UserState.ToString(),"出错了");
                btnBegin.Enabled = true;
                btnBegin.Text = "开始环绕";
                lblIndicator.Visible = false;
            }
            if(e.ProgressPercentage == 10)
            {
                btnBegin.Enabled = true;
                btnBegin.Text = "停止环绕";
                lblIndicator.Visible = true;
            }
            if (e.ProgressPercentage == 99)
            {
                btnBegin.Enabled = true;
                btnBegin.Text = "开始环绕";
                lblIndicator.Visible = false;
            }
        }

        private void surroundProc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = lblIndicator.Visible;
        }
    }
}
