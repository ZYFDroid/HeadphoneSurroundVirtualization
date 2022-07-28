using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio;
using NAudio.Wave;
using System.IO;
using NAudio.Wave.SampleProviders;
using AudioCommon;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace 耳机虚拟环绕声
{

    /*
    To-Does:
    TODO: 耳机调音向导
    TODO: 创建耳机调音基准数据
    TODO: 把处理环绕数据的部分也做进C++好了
    TODO: C++部分新功能：输入环绕数据，直接输出立体声数据
    TODO: 干脆把平衡，翻转声道，抗串扰也做进脉冲响应里好了
    TODO: 反正都是一些简单的数学运算
     */
    internal static class Program
    {
        public static List<DevicePriority> DevicePriorityList = new List<DevicePriority>();
        
        internal static SurroundSettings SurroundSettings = new SurroundSettings();

        public static AudioEnchancementData AudioEnchancementData = new AudioEnchancementData();

        public static bool needSave = false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] param)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (param.Length > 0)
            {
                if (param[0] == FrmConfig.PARAM_SETUP_DEVICE)
                {
                    try
                    {
                        FrmConfig.ConfigDevice();
                        MessageBox.Show("配置成功。");
                        Environment.Exit(0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.GetType().FullName+": "+ ex.Message,"配置失败");
                        Environment.Exit(1);
                    }
                    return;
                }
            }
            if (File.Exists(TuneConfigFile))
            {
                SurroundSettings = JsonConvert.Deserialize<SurroundSettings>(File.ReadAllText(TuneConfigFile));
            }
            if (File.Exists(DeviceConfigFile))
            {
                DevicePriorityList = JsonConvert.Deserialize<List<DevicePriority>>(File.ReadAllText(DeviceConfigFile));
            }
            if (File.Exists(AudioEnchancementConfigFile))
            {
                AudioEnchancementData = JsonConvert.Deserialize<AudioEnchancementData>(File.ReadAllText(AudioEnchancementConfigFile));
            }


            if (!File.Exists(FFTConvolverModule))
            {
                string name = FFTConvolverModule;
                string tempname = FFTConvolverModule+".tmp";
                File.WriteAllBytes(tempname, AudioCommon.Properties.Resources.FFTConvolver_dll);
                if (File.Exists(name))
                {
                    File.Delete(name);
                }
                File.Move(tempname, name);
            }
            
            if(!SetDllDirectory(UserDataDir))
            {
                MessageBox.Show("加载音频处理模块失败。");
                throw new Exception();
            }
            FFTConvolver.FFTConvolver.Init();
            FFTConvolver.FFTConvolver.init_mem();
            Application.Run(new btnExportIR());
            if (needSave)
            {
                save();
            }
        }

        public static void save()
        {
            File.WriteAllText(TuneConfigFile, JsonConvert.Serialize(SurroundSettings));
            File.WriteAllText(DeviceConfigFile, JsonConvert.Serialize(DevicePriorityList));
            File.WriteAllText(AudioEnchancementConfigFile, JsonConvert.Serialize(AudioEnchancementData));
        }

        public static string UserDataDir
        {
            get
            {
                string appdata = Environment.GetEnvironmentVariable("LOCALAPPDATA");
                if (appdata == null || appdata.Trim() == "")
                {
                    appdata = System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "AppData");
                }
                string datadir = System.IO.Path.Combine(appdata, "com.zyfdroid.hesuvi");
                if (!System.IO.Directory.Exists(datadir))
                {
                    System.IO.Directory.CreateDirectory(datadir);
                }
                return datadir;
            }
        }
        public static string TuneConfigFile
        {
            get => System.IO.Path.Combine(UserDataDir, "config_fir_v2.json");
        }
        public static string DeviceConfigFile
        {
            get => System.IO.Path.Combine(UserDataDir, "device.json");
        }
        public static string AudioEnchancementConfigFile
        {
            get => System.IO.Path.Combine(UserDataDir, "audioeq_v1.json");
        }
        public static string FFTConvolverModule
        {
            get => System.IO.Path.Combine(UserDataDir, FFTConvolver.FFTConvolver.dllName);
        }


        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);
        public class JsonConvert
        {
            private static System.Web.Script.Serialization.JavaScriptSerializer serializer;
            public static string Serialize(object obj)
            {
                if (serializer == null) { serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); }
                return serializer.Serialize(obj);
            }

            public static T Deserialize<T>(string json)
            {
                if (serializer == null) { serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); }
                return serializer.Deserialize<T>(json);
            }
        }

        public static void setDict<T>(this ComboBox cmb, Dictionary<String, T> dict)
        {
            cmb.Enabled = false;
            cmb.DataSource = null;
            cmb.Items.Clear();
            cmb.Text = "";
            if (null != dict && dict.Count > 0)
            {
                cmb.Enabled = true;
                cmb.DataSource = new BindingSource() { DataSource = dict };
                cmb.DisplayMember = "Key";
                cmb.ValueMember = "Value";
            }
        }
    }

    public class SurroundSettings
    {
        /// <summary>
        /// 主音量（增益）
        /// </summary>
        public float masterGain = 0;
        /// <summary>
        /// 压缩器 - 压缩比
        /// </summary>
        public float cmpRatio = 30;
        /// <summary>
        /// 压缩器 - 启动时间
        /// </summary>
        public float cmpAttack = 144;
        /// <summary>
        /// 压缩器 - 释放时间
        /// </summary>
        public float cmpRelease = 3200;
        /// <summary>
        /// 压缩器 - 噪音门限
        /// </summary>
        public float cmpGate = 0;
        /// <summary>
        /// 低延迟模式（不开这个延迟半秒多）
        /// </summary>
        public bool lowLancey = false;
        /// <summary>
        /// 将前置声道通入左前和右前
        /// 如果觉得中置声道不太自然可以试试这个
        /// </summary>
        public bool rerouteFrontCenter = false;
        /// <summary>
        /// 强制扫描所有设备
        /// 部分奇怪的电脑会强制所有设备都变成7.1声道的（例如戴尔外星人），导致无法正常开启环绕声
        /// </summary>
        public bool ignoreOutputChannelCount = false; 

        /// <summary>
        /// 自定义HRIR文件。
        /// </summary>
        public string customIrPath = null;
    }
    public class DeviceDesc
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
    public class SurroundToStereoSampleProvider : ISampleProvider
    {
        int _channels=8;


        public SurroundToStereoSampleProvider(ISampleProvider sampleIn,string customIrPath = null)
        {
            this.customIrPath = customIrPath;
            _sampleIn = sampleIn;
            _inWaveFormat = sampleIn.WaveFormat;
            _outWaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(_inWaveFormat.SampleRate, 2);
            _channels = _inWaveFormat.Channels;

            _buffer = new float[_channels * 48000];

            FFTConvolver.FFTConvolver.set_bypass(false);

            initIR();
            rawPeaks = new float[_channels];
        }

        private string customIrPath = null;
        void initIR()
        {
            int chanCount = 0;
            float[] IRs = genIR(_outWaveFormat.SampleRate,out chanCount);
            if(chanCount != 7 && chanCount != 14)
            {
                throw new Exception("此音频文件不是一个有效的HRIR文件");
            }
            unsafe {
                fixed (float* irs = IRs)
                {
                    test(FFTConvolver.FFTConvolver.set_sr_ir(irs, IRs.Length, chanCount));
                }
            }
        }

        void test(bool b)
        {
            if (!b) { throw new Exception("Operation failed!"); }
        }

        public void switchIrFile(string irPath)
        {
            customIrPath = irPath;
            try
            {
                initIR();
            }catch (Exception e)
            {
                customIrPath=null;
                initIR();
                throw e;
            }
        }

        const int OffsetFrontLeft = 0; // 左前
        const int OffsetFrontRight = 1; //右前
        const int OffsetFrontCenter = 2; //前
        const int OffsetBassBoost = 3; //低音炮
        const int OffsetRearLeft = 4; //左后
        const int OffsetRearRight = 5; //右后
        const int OffsetSideLeft = 6; //左侧
        const int OffsetSideRight = 7; //右侧
        private float[] genIR(int sampleRate,out int chanCount)
        {

            List<float> buffer = new List<float>();

            WaveStream irSource = null;
            
            if (customIrPath != null) {
                if (File.Exists(customIrPath)) { 
                    irSource = new WaveFileReader(customIrPath);
                }
                
            }
            MemoryStream internalIrStream = null;
            if (irSource == null)
            {
                internalIrStream = new MemoryStream(Properties.Resources.fir); 
                irSource =new WaveFileReader(internalIrStream);
            }

            using (WaveStream irIn = irSource)
            {

                ISampleProvider sampleReader = null;
                if (irIn.WaveFormat.BitsPerSample == 8)
                {
                    sampleReader = new Pcm8BitToSampleProvider(irIn);
                }
                else if(irIn.WaveFormat.BitsPerSample == 16)
                {
                    sampleReader = new Pcm16BitToSampleProvider(irIn);
                }
                else if (irIn.WaveFormat.BitsPerSample == 24)
                {
                    sampleReader = new Pcm24BitToSampleProvider(irIn);
                }
                else if (irIn.WaveFormat.BitsPerSample == 32 && irIn.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
                {
                    sampleReader = new Pcm32BitToSampleProvider(irIn);
                }
                else
                {
                    sampleReader = new WaveToSampleProvider(irIn);
                }

                ISampleProvider sampleProvider = sampleReader;
                if (sampleRate != irIn.WaveFormat.SampleRate)
                {
                    sampleProvider = new WdlResamplingSampleProvider(sampleProvider, sampleRate);
                }

                int chan = sampleProvider.WaveFormat.Channels;

                float[] buf = new float[chan * 100];

                int readed = 0;

                while((readed = sampleProvider.Read(buf,0,buf.Length)) > 0)
                {
                    for (int i = 0; i < readed; i++)
                    {
                        buffer.Add(buf[i]);
                    }
                }

                chanCount = chan;
            }
            internalIrStream?.Dispose();
            return buffer.ToArray();
        }


        private WaveFormat _outWaveFormat = null;
        private WaveFormat _inWaveFormat = null;
        private ISampleProvider _sampleIn;
        public WaveFormat WaveFormat => _outWaveFormat;


        private bool _bypass = false;
        public bool Bypass
        {
            get
            {
                return _bypass;
            }
            set
            {
                FFTConvolver.FFTConvolver.set_bypass(value);
                _bypass = value;
            }
        }


       

        public void applySettings(SurroundSettings settings,bool fullApply = false)
        {
            FFTConvolver.FFTConvolver.set_master_gain(settings.masterGain);
            FFTConvolver.FFTConvolver.set_fc2f(settings.rerouteFrontCenter);
            FFTConvolver.FFTConvolver.set_cmp_param(_outWaveFormat.SampleRate,
                settings.cmpGate, settings.cmpRatio, settings.cmpAttack, settings.cmpRelease);
        }

        private float[] _buffer;

        public float[] rawPeaks;

        private float[] meters = new float[11];
        public int Read(float[] buffer, int offset, int count)
        {
            
            int desiredSamples = count / 2;
            int neededSamples = desiredSamples * _inWaveFormat.Channels;
            int maxSamples = 24000 * 8;

            int readFrom = _sampleIn.Read(_buffer,0,Math.Min(maxSamples,neededSamples));

            int monoCount = (readFrom / _channels);

            unsafe {
                fixed (float* fin = _buffer){
                    fixed (float* fout = buffer)
                    {
                        fixed(float* pMeters = meters) {
                            FFTConvolver.FFTConvolver.pro_call(fin, fout, pMeters, 0, offset, monoCount);
                        }
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                rawPeaks[i] = meters[i];
            }

            outLeft = meters[8];
            outRight = meters[9];
            _compressorGain = meters[10];
            return monoCount * 2 ;
        }

        public float _compressorGain = 1f;
        public float outLeft = 0, outRight = 0;
    }

    
    public class LowLanceyLoopbackCapture : WasapiCapture
    {

        public override WaveFormat WaveFormat
        {
            get
            {
                return base.WaveFormat;
            }
            set
            {
                throw new InvalidOperationException("WaveFormat cannot be set for WASAPI Loopback Capture");
            }
        }

        public LowLanceyLoopbackCapture(MMDevice captureDevice,int desiredLancey) : base(captureDevice, true, desiredLancey)
        {

        }

        protected override AudioClientStreamFlags GetAudioClientStreamFlags()
        {
            return AudioClientStreamFlags.Loopback;
        }
    }

    internal class DevicePriority
    {
        public int Priority;
        public string DeviceID;
    }
    
    internal class DeviceDecider
    {
        public List<DevicePriority> DevicePriorityList;
        public DeviceDecider(List<DevicePriority> devicePriorityList)
        {
            DevicePriorityList = devicePriorityList;
        }
        private DevicePriority getPriority(string device)
        {
            var query = DevicePriorityList.Where(d => d.DeviceID == device).FirstOrDefault();
            if (query == null)
            {
                var d = new DevicePriority() { DeviceID = device, Priority = 1 };
                DevicePriorityList.Add(d);
                return d;
            }
            return query;
        }
        private void setPriority(string device,int priority)
        {
            var query = DevicePriorityList.Where(d => d.DeviceID == device).FirstOrDefault();
            if (query == null)
            {
                var d = new DevicePriority() { DeviceID = device, Priority = priority };
                DevicePriorityList.Add(d);
               
            }
            query.Priority = priority;
            Program.needSave = true;
        }

        public DevicePriority GetSuggest(string[] availableDevices)
        {
           
            var availablePriority = 
                availableDevices.Select(d => getPriority(d)).OrderByDescending(d => d.Priority).ToList();
            if(availablePriority.Count > 0)
            {
                return availablePriority[0];
            }
            return null;
        }



        public DevicePriority OnDeviceChanged(string currentDevice,string[] devices)
        {
            DevicePriority currentDevicePriority = getPriority(currentDevice);
            if (devices.Contains(currentDevice))
            {
                DevicePriority maxDevicePrioriry = GetSuggest(devices);
                return currentDevicePriority.Priority >= maxDevicePrioriry.Priority ? currentDevicePriority : maxDevicePrioriry;
            }
            else
            {
                return GetSuggest(devices);
            }
        }

        public void OnStart(string selectedDevice,string[] devices)
        {
            int desiredPriority = devices.Length;
            DevicePriority selectedDevicePriority = getPriority(selectedDevice);
            if(selectedDevicePriority.Priority < desiredPriority)
            {
                setPriority(selectedDevice,desiredPriority);
                selectedDevicePriority.Priority = desiredPriority;
            }

            DevicePriority maxDevicePriority = GetSuggest(devices);
            if (selectedDevicePriority.Priority < maxDevicePriority.Priority)
            {
                int large = maxDevicePriority.Priority;
                int small = selectedDevicePriority.Priority;
                setPriority(maxDevicePriority.DeviceID, small);
                setPriority(selectedDevice,large);
            }
        }
    }

}
