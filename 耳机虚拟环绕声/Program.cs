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
using 耳机虚拟环绕声.ThirdParties.EqualizerAPO;

namespace 耳机虚拟环绕声
{

    /*
    To-Does:
    TODO: 自动配置设备（需要管理员权限）
    TODO: 耳机调音向导
    TODO: 创建耳机调音基准数据
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
        static void Main()
        {
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
                File.WriteAllBytes(tempname, Properties.Resources.FFTConvolver_dll);
                File.Move(tempname, name);
            }
            FFTConvolver.FFTConvolver.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (needSave)
            {
                File.WriteAllText(TuneConfigFile, JsonConvert.Serialize(SurroundSettings));
                File.WriteAllText(DeviceConfigFile, JsonConvert.Serialize(DevicePriorityList));
                File.WriteAllText(AudioEnchancementConfigFile, JsonConvert.Serialize(AudioEnchancementData));
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
            get => System.IO.Path.Combine(UserDataDir, "audioeq_v0.json");
        }
        public static string FFTConvolverModule
        {
            get => System.IO.Path.Combine(UserDataDir, "FFTConvolver02.dll");
        }

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
    public class AudioEnchancementData
    {
        public List<DeviceParameterMapping> deviceParameterMappings = new List<DeviceParameterMapping>();
        public List<AudioEnchancementParameters> audioEnchancementParameters = new List<AudioEnchancementParameters>();
        /// <summary>
        /// Fail-safe的获取模块
        /// </summary>
        /// <param name="deviceGuid"></param>
        /// <returns></returns>
        public AudioEnchancementParameters getDeviceParam(string deviceGuid)
        {
            DeviceParameterMapping dpm = null;
            foreach (var item in deviceParameterMappings)
            {
                if(item.deviceGuid == deviceGuid)
                {
                    dpm = item;
                }
            }
            if(dpm != null)
            {
                foreach (var item in audioEnchancementParameters)
                {
                    if(item.guid == dpm.parameterGuid)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public void setDeviceParam(string deviceName,string deviceGuid,AudioEnchancementParameters param)
        {
          
            deviceParameterMappings.RemoveAll(d => d.deviceGuid == deviceGuid);
            if (param != null)
            {
                deviceParameterMappings.Add(new DeviceParameterMapping() { deviceGuid = deviceGuid, deviceName = deviceName, parameterGuid = param.guid });
            }
        }
    }

    public class DeviceParameterMapping
    {
        public string deviceGuid;
        public string deviceName;
        public string parameterGuid;
    }

    public class AudioEnchancementParameters
    {
        /// <summary>
        /// 显示的名称
        /// </summary>
        public string DisplayName = "Default";
        /// <summary>
        /// 唯一标志
        /// </summary>
        public string guid = Guid.Empty.ToString();
        /// <summary>
        /// 是否交换左右声道
        /// 这对于某些左右声道做反，但又必须区分左右耳的耳机来说有用
        /// </summary>
        public bool swapChannel = false; 
        /// <summary>
        /// 抗串扰
        /// 范围是 -1 ~ 1
        /// （但如果是1的时候
        /// 部分奇怪的电脑（例如惠普的暗影精灵）在使用有线耳机的时候，一边声道的声音会有一部分跑到另一边。影响立体声分离度和效果
        /// </summary>
        public float antiCrossfeedLevel = 0; 
        /// <summary>
        /// 音量平衡
        /// 范围是-1 ~ 1
        /// 如果你的耳机一边声音大一边声音小，建议用这个
        /// 但是更建议换个新的
        /// </summary>
        public float balanceLevel = 0;
        /// <summary>
        /// 界外立体声
        /// 部分奇怪的耳机（例如淘宝某店买的蓝牙头带耳机），有一边的单元正负极接反了，导致音乐听起来不太好听，可以使用这个开关修复
        /// </summary>
        public bool invertOneSide = false;

        /// <summary>
        /// 用于均衡器的参数列表
        /// </summary>
        public List<PeakEQParam> peakEQParams = new List<PeakEQParam>();
    }

    public class PeakEQParam
    {
        public float centerFrequent;
        public float gain;
        public float Q;
    }
    
    public class AudioEnchancementSampleProvider : ISampleProvider
    {
        private AudioEnchancementParameters param;
        private ISampleProvider baseProvider;

        public AudioEnchancementParameters AudioEnchancementParameters => param;

        BiQuad[,] biQuadFilters = null;
        public WaveFormat WaveFormat => baseProvider.WaveFormat;


        public AudioEnchancementSampleProvider(ISampleProvider baseProvider,AudioEnchancementParameters param)
        {
            if(baseProvider.WaveFormat.Channels != 2)
            {
                throw new ArgumentException("Channels must be stereo(two channel)");
            }
            this.baseProvider = baseProvider;
            Apply(param);
        }

        public bool Bypass = false;

        private object syncObj = new object();
        public void Apply(AudioEnchancementParameters param)
        {
            lock (syncObj)
            {
                if(param == null)
                {
                    this.param = null;
                    return;
                }
                float sampleRate = WaveFormat.SampleRate;
                this.param = param;
                biQuadFilters = new BiQuad[param.peakEQParams.Count, WaveFormat.Channels];
                peakEqCount = param.peakEQParams.Count;
                for (int i = 0; i < param.peakEQParams.Count; i++)
                {
                    for (int c = 0; c < WaveFormat.Channels; c++)
                    {
                        PeakEQParam eq = param.peakEQParams[i];
                        biQuadFilters[i, c] = BiQuad.PeakEQ(sampleRate, eq.centerFrequent, eq.Q, eq.gain);
                    }
                }
                lDown = 1;
                rDown = 1;
                if(param.balanceLevel < 0)
                {
                    rDown = - (-1 - param.balanceLevel) / (1 - param.balanceLevel);
                }
                else
                {
                    lDown = - (1 - param.balanceLevel) / (-1 - param.balanceLevel);  
                }
            }
        }
        private int peakEqCount = 0;
        float lDown = 1;
        float rDown = 1;
        public int Read(float[] buffer, int offset, int count)
        {
            int sampleReaded = baseProvider.Read(buffer, offset, count);
            if (!Bypass && param != null)
            {
                lock (syncObj)
                {
                    int channel = 2;
                    int end = offset + sampleReaded;
                    // 均衡器
                    for (int n = 0; n < peakEqCount; n++)
                    {
                        biQuadFilters[n, 0].processBatch(buffer, offset, count, 2, 0);
                        biQuadFilters[n, 1].processBatch(buffer, offset, count, 2, 1);
                    }
                    for (int i = offset; i < end; i += channel)
                    {

                        // 交换左右声道
                        if (param.swapChannel)
                        {
                            float t = buffer[i];
                            buffer[i] = buffer[i+1];
                            buffer[i+1] = t;
                        }
                        // 反转一边
                        if (param.invertOneSide)
                        {
                            buffer[i] = -buffer[i];
                        }
                        // 抗串扰
                        float l = buffer[i];
                        float r = buffer[i+1];
                        buffer[i + 1] += l * param.antiCrossfeedLevel;
                        buffer[i] += r * param.antiCrossfeedLevel;

                        // 声道平衡
                        buffer[i] *= lDown;
                        buffer[i + 1] *= rDown;
                    }
                }
            }
            return sampleReaded;
        }
    }

    public class SurroundToStereoSampleProvider : ISampleProvider
    {
        int _channels=8;

        const int bufferSize = 1024;

        public SurroundToStereoSampleProvider(ISampleProvider sampleIn,string customIrPath = null)
        {
            this.customIrPath = customIrPath;
            _sampleIn = sampleIn;
            _inWaveFormat = sampleIn.WaveFormat;
            _outWaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(_inWaveFormat.SampleRate, 2);
            _buffer = new float[_inWaveFormat.Channels * _inWaveFormat.SampleRate / 10];
            _channels = _inWaveFormat.Channels;

            initIR();
            List<float[]> __in = new List<float[]>();
            for (int i = 0; i < 8; i++)
            {
                __in.Add(new float[bufferSize]);
            }
            _sampleInBuffer = __in.ToArray();

            List<float[]> __out = new List<float[]>();
            for (int i = 0; i < 16; i++)
            {
                __out.Add(new float[bufferSize]);
            }
            _sampleOutBuffer = __out.ToArray();
            _buffer = new float[bufferSize * _channels];
            rawPeaks = new float[_channels];
            _rawMaxs = new float[_channels];
        }

        private string customIrPath = null;
        void initIR()
        {
            var IRs = genIR(_outWaveFormat.SampleRate);

            FFTConvolver.FFTConvolver.con01_reset();
            FFTConvolver.FFTConvolver.con02_reset();
            FFTConvolver.FFTConvolver.con03_reset();
            FFTConvolver.FFTConvolver.con04_reset();
            FFTConvolver.FFTConvolver.con05_reset();
            FFTConvolver.FFTConvolver.con06_reset();
            FFTConvolver.FFTConvolver.con07_reset();
            FFTConvolver.FFTConvolver.con08_reset();
            FFTConvolver.FFTConvolver.con09_reset();
            FFTConvolver.FFTConvolver.con10_reset();
            FFTConvolver.FFTConvolver.con11_reset();
            FFTConvolver.FFTConvolver.con12_reset();
            FFTConvolver.FFTConvolver.con13_reset();
            FFTConvolver.FFTConvolver.con14_reset();
            FFTConvolver.FFTConvolver.con15_reset();
            FFTConvolver.FFTConvolver.con16_reset();
            int irLen = IRs[0].Length;
            int fftSize = 1024;
            unsafe
            {
                fixed (float* ir0 = IRs[0]) { test(FFTConvolver.FFTConvolver.con01_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[1]) { test(FFTConvolver.FFTConvolver.con02_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[8]) { test(FFTConvolver.FFTConvolver.con03_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[9]) { test(FFTConvolver.FFTConvolver.con04_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[6]) { test(FFTConvolver.FFTConvolver.con05_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[7]) { test(FFTConvolver.FFTConvolver.con06_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[6]) { test(FFTConvolver.FFTConvolver.con07_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[7]) { test(FFTConvolver.FFTConvolver.con08_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[4]) { test(FFTConvolver.FFTConvolver.con09_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[5]) { test(FFTConvolver.FFTConvolver.con10_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[12]) { test(FFTConvolver.FFTConvolver.con11_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[13]) { test(FFTConvolver.FFTConvolver.con12_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[2]) { test(FFTConvolver.FFTConvolver.con13_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[3]) { test(FFTConvolver.FFTConvolver.con14_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[10]) { test(FFTConvolver.FFTConvolver.con15_init(fftSize, ir0, irLen)); }
                fixed (float* ir0 = IRs[11]) { test(FFTConvolver.FFTConvolver.con16_init(fftSize, ir0, irLen)); }
            }

        }

        void test(bool b)
        {
            if (!b) { throw new Exception("Operation failed!"); }
        }

        public void switchIrFile(string irPath)
        {
            customIrPath = irPath;
            bool _lastBypass = Bypass;
            Bypass = true;
            System.Threading.Thread.Sleep(500);
            try
            {
                initIR();
            }catch (Exception e)
            {
                customIrPath=null;
                initIR();
                Bypass = _lastBypass;
                throw e;
            }
            Bypass = _lastBypass;
        }

        const int OffsetFrontLeft = 0; // 左前
        const int OffsetFrontRight = 1; //右前
        const int OffsetFrontCenter = 2; //前
        const int OffsetBassBoost = 3; //低音炮
        const int OffsetRearLeft = 4; //左后
        const int OffsetRearRight = 5; //右后
        const int OffsetSideLeft = 6; //左侧
        const int OffsetSideRight = 7; //右侧
        private float[][] genIR(int sampleRate)
        {
            
            List<float>[] ret;

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
                ret = new List<float>[14];
                int irChannels = irIn.WaveFormat.Channels;
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = new List<float>();
                }

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
                float[] buffer = new float[irChannels * 100];
                int count = 0;
                while ((count = sampleProvider.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (irChannels == 14)
                    {
                        for (int i = 0; i < count; i += irChannels)
                        {
                            for (int c = 0; c < irChannels; c++)
                            {
                                ret[c].Add(buffer[i + c]);
                            }
                        }
                    } else if (irChannels == 7)
                    {
                        for (int i = 0; i < count; i += irChannels)
                        {
                            for (int c = 0; c < irChannels; c++)
                            {
                                ret[c].Add(buffer[i + c]);
                            }
                            ret[7].Add(ret[6].Last());

                            ret[8].Add(ret[1].Last());
                            ret[9].Add(ret[0].Last());

                            ret[10].Add(ret[3].Last());
                            ret[11].Add(ret[2].Last());

                            ret[12].Add(ret[5].Last());
                            ret[13].Add(ret[4].Last());
                        }
                    }
                    else
                    {
                        throw new Exception("不是有效的7.1环绕脉冲响应文件");
                    }

                }
            
            }
            internalIrStream?.Dispose();
            return ret.Select(r => r.ToArray()).ToArray();
        }


        private WaveFormat _outWaveFormat = null;
        private WaveFormat _inWaveFormat = null;
        private ISampleProvider _sampleIn;
        public WaveFormat WaveFormat => _outWaveFormat;
        float[] _buffer;



        float[][] _sampleInBuffer = null;
        float[][] _sampleOutBuffer = null;


        public bool Bypass = false;


       

        public void applySettings(SurroundSettings settings,bool fullApply = false)
        {
            
            
            this.fc2f = settings.rerouteFrontCenter;
        }


        private bool fc2f = false;

        public float[] rawPeaks;
        private float[] _rawMaxs;
        private float l, r;
        int ccd = 1000;
        int cd = 1000;

        public int Read(float[] buffer, int offset, int count)
        {
            
            int desiredSamples = count / 2;
            int neededSamples = desiredSamples * _inWaveFormat.Channels;
            int maxSamples = _buffer.Length;

            int readFrom = _sampleIn.Read(_buffer,0,Math.Min(maxSamples,neededSamples));

            int monoCount = (readFrom / _channels);


            for (int i = 0; i < readFrom; i+=_channels)
            {
                for (int c = 0; c < _channels; c++)
                {
                    float sample = _buffer[i+c];
                    _sampleInBuffer[c][i/_channels] = sample;
                    if(_rawMaxs[c] < sample)
                    {
                        _rawMaxs[c] = sample;
                    }

                }
                cd--;
                if(cd < 0)
                {
                    cd = ccd;
                    for (int c = 0; c < rawPeaks.Length; c++)
                    {
                        rawPeaks[c] -= visualizerDownRate;
                        if (rawPeaks[c] < _rawMaxs[c])
                        {
                            rawPeaks[c] = _rawMaxs[c];
                        }
                        _rawMaxs[c] = 0;
                    }
                }
                if (fc2f)
                {
                    _sampleInBuffer[OffsetFrontLeft][i / _channels] += _sampleInBuffer[OffsetFrontCenter][i / _channels] * 0.75f;
                    _sampleInBuffer[OffsetFrontRight][i / _channels] += _sampleInBuffer[OffsetFrontCenter][i / _channels] * 0.75f;
                    _sampleInBuffer[OffsetFrontCenter][i / _channels] = 0;
                }
            }
            if(!Bypass)
            unsafe
            {
                fixed(float* lpIn = _sampleInBuffer[0])
                    fixed(float* lpOut = _sampleOutBuffer[0])
                {

                    FFTConvolver.FFTConvolver.con01_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[0])
                fixed (float* lpOut = _sampleOutBuffer[1])
                {

                    FFTConvolver.FFTConvolver.con02_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[1])
                fixed (float* lpOut = _sampleOutBuffer[2])
                {

                    FFTConvolver.FFTConvolver.con03_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[1])
                fixed (float* lpOut = _sampleOutBuffer[3])
                {

                    FFTConvolver.FFTConvolver.con04_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[2])
                fixed (float* lpOut = _sampleOutBuffer[4])
                {

                    FFTConvolver.FFTConvolver.con05_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[2])
                fixed (float* lpOut = _sampleOutBuffer[5])
                {

                    FFTConvolver.FFTConvolver.con06_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[3])
                fixed (float* lpOut = _sampleOutBuffer[6])
                {

                    FFTConvolver.FFTConvolver.con07_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[3])
                fixed (float* lpOut = _sampleOutBuffer[7])
                {

                    FFTConvolver.FFTConvolver.con08_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[4])
                fixed (float* lpOut = _sampleOutBuffer[8])
                {

                    FFTConvolver.FFTConvolver.con09_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[4])
                fixed (float* lpOut = _sampleOutBuffer[9])
                {

                    FFTConvolver.FFTConvolver.con10_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[5])
                fixed (float* lpOut = _sampleOutBuffer[10])
                {

                    FFTConvolver.FFTConvolver.con11_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[5])
                fixed (float* lpOut = _sampleOutBuffer[11])
                {

                    FFTConvolver.FFTConvolver.con12_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[6])
                fixed (float* lpOut = _sampleOutBuffer[12])
                {

                    FFTConvolver.FFTConvolver.con13_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[6])
                fixed (float* lpOut = _sampleOutBuffer[13])
                {

                    FFTConvolver.FFTConvolver.con14_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[7])
                fixed (float* lpOut = _sampleOutBuffer[14])
                {

                    FFTConvolver.FFTConvolver.con15_process(lpIn, lpOut, monoCount);
                }
                fixed (float* lpIn = _sampleInBuffer[7])
                fixed (float* lpOut = _sampleOutBuffer[15])
                {

                    FFTConvolver.FFTConvolver.con16_process(lpIn, lpOut, monoCount);
                }
            }

            for (int i = 0; i < monoCount; i ++)
            {
                l = 0;r = 0;
                for (int c = 0; c < _channels; c++)
                {
                    if (Bypass)
                    {
                        l = _sampleInBuffer[0][i];
                        r = _sampleInBuffer[1][i];
                    }
                    else
                    {
                        l += _sampleOutBuffer[c * 2][i];
                        r += _sampleOutBuffer[c * 2 + 1][i];
                    }
                }
                buffer[offset+i * 2] = l;
                buffer[offset + i * 2 + 1] = r;
            }

            return monoCount * 2 ;
        }


        const float visualizerDownRate = 0.04f;
    }

    public class CompressorSampleProvider : ISampleProvider
    {
        const float visualizerDownRate = 0.04f;
        public ISampleProvider baseProvider;
        private float _currentGain = 0f;
        private float _MininumGain = 0f;
        private float _gainAttackRate = 0f;
        private float _gainDecayRate = 0f;
        private float _gate;

        private int _decayCd = 0;
        private int _decayCds = 100;
        public void applySettings(SurroundSettings settings)
        {
            _gate = MathHelper.db2linear(settings.cmpGate);
            _MininumGain = settings.cmpRatio == 0 ? -150 : MathHelper.linear2db(1 / settings.cmpRatio);
            float sampleRate = baseProvider.WaveFormat.SampleRate;
            _gainAttackRate = (-_MininumGain) / (sampleRate * (settings.cmpAttack / 1000f + 0.001f));
            _gainDecayRate = (-_MininumGain) / (sampleRate * (settings.cmpRelease / 1000f + 0.001f));
            _decayCds = baseProvider.WaveFormat.SampleRate / 1000 * 25;
            if (settings.cmpAttack <= 0.000001f)
            {
                _currentGain = 0f;//disable compressor
            }

            _gain = MathHelper.db2linear(settings.masterGain);

        }

        public WaveFormat WaveFormat => baseProvider.WaveFormat;

        public float _compressorGain = 1f;
        private float _gain = 1f;
        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = baseProvider.Read(buffer, offset, count);

            for (int i = offset; i < offset+samplesRead; i+=2)
            {
                float l = buffer[i];
                float r = buffer[i + 1];
                _compressorGain = -_currentGain;
                float gainFactor = MathHelper.db2linear(_currentGain);

                l = l * _gain * 0.9f * gainFactor;
                r = r * _gain * 0.9f * gainFactor;


                float dc = Math.Max(Math.Abs(l), Math.Abs(r));
                if (dc > _gate)
                {
                    _currentGain -= _gainAttackRate;
                    if (_currentGain < _MininumGain)
                    {
                        _currentGain = _MininumGain;
                    }
                    _decayCd = _decayCds;
                }
                else
                {
                    if (_decayCd > 0)
                    {
                        _decayCd--;
                    }
                    else
                    {
                        _currentGain += _gainDecayRate;
                        if (_currentGain > 0)
                        {
                            _currentGain = 0;
                        }
                    }
                }


                _maxLeft = _maxLeft > l ? _maxLeft : l;
                _maxRight = _maxRight > r ? _maxRight : r;


                buffer[i] = l;
                buffer[i+1] = r;
                cd--;
                if (cd < 0)
                {
                    cd = ccd;

                    outLeft -= visualizerDownRate;
                    outRight -= visualizerDownRate;

                    if (outLeft < _maxLeft)
                    {
                        outLeft = _maxLeft;
                    }
                    if (outRight < _maxRight)
                    {
                        outRight = _maxRight;
                    }
                    _maxLeft = 0;
                    _maxRight = 0;
                }
            }

            return samplesRead;
        }

        int ccd = 1000;

        public float outLeft = 0, outRight = 0;
        public float displayLeft = 0, displayRight = 0;
        private float _maxLeft = 0, _maxRight = 0;
        private int cd = 500;

        public CompressorSampleProvider(ISampleProvider baseProvider)
        {
            this.baseProvider = baseProvider;
        }
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
