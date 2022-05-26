using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;
using NAudio.Dsp;
using NAudio2.Dsp;

namespace 耳机虚拟环绕声
{

    /*
    To-Does:
    TODO: 当无支持环绕的设备时则提示
    TODO: 配置引导提示
     */
    internal static class Program
    {
        public static List<DevicePriority> DevicePriorityList = new List<DevicePriority>();
        internal static SurroundSettings SurroundSettings = new SurroundSettings();
        public static bool neenSave = false;
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
            if (neenSave)
            {
                File.WriteAllText(TuneConfigFile, JsonConvert.Serialize(SurroundSettings));
                File.WriteAllText(DeviceConfigFile, JsonConvert.Serialize(DevicePriorityList));
            }
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
        public float masterGain = 0; // 主音量（增益）

        public float cmpRatio = 30; // 压缩器 - 压缩比
        public float cmpAttack = 144;// 压缩器 - 启动时间
        public float cmpRelease = 3200; // 压缩器 - 释放时间
        public float cmpGate = 0;// 压缩器 - 噪音门限

        public bool lowLancey = false;

    }


    public class SurroundToStereoSampleProvider : ISampleProvider
    {
        int _channels=8;

        const int bufferSize = 1024;

        public SurroundToStereoSampleProvider(ISampleProvider sampleIn)
        {
            _sampleIn = sampleIn;
            _inWaveFormat = sampleIn.WaveFormat;
            _outWaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(_inWaveFormat.SampleRate, 2);
            _buffer = new float[_inWaveFormat.Channels * _inWaveFormat.SampleRate / 10];
            _channels = _inWaveFormat.Channels;

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
                fixed(float* ir0 = IRs[0]) { test(FFTConvolver.FFTConvolver.con01_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[1]) { test(FFTConvolver.FFTConvolver.con02_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[8]) { test(FFTConvolver.FFTConvolver.con03_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[9]) { test(FFTConvolver.FFTConvolver.con04_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[6]) { test(FFTConvolver.FFTConvolver.con05_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[7]) { test(FFTConvolver.FFTConvolver.con06_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[6]) { test(FFTConvolver.FFTConvolver.con07_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[7]) { test(FFTConvolver.FFTConvolver.con08_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[4]) { test(FFTConvolver.FFTConvolver.con09_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[5]) { test(FFTConvolver.FFTConvolver.con10_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[12]) {test( FFTConvolver.FFTConvolver.con11_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[13]) {test( FFTConvolver.FFTConvolver.con12_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[2]) { test(FFTConvolver.FFTConvolver.con13_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[3]) { test(FFTConvolver.FFTConvolver.con14_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[10]) {test( FFTConvolver.FFTConvolver.con15_init(fftSize, ir0, irLen)); }
                fixed(float* ir0 = IRs[11]) {test( FFTConvolver.FFTConvolver.con16_init(fftSize, ir0, irLen)); }
            }
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


        void test(bool b)
        {
            if (!b) { throw new Exception("Operation failed!"); }
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
            using(MemoryStream ms = new MemoryStream(Properties.Resources.fir))
            using(WaveFileReader irIn = new WaveFileReader(ms))
            {
                ret = new List<float>[irIn.WaveFormat.Channels];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = new List<float>();
                }
                WaveToSampleProvider sampleReader = new WaveToSampleProvider(irIn);
                ISampleProvider sampleProvider = sampleReader;
                if(sampleRate != irIn.WaveFormat.SampleRate)
                {
                    sampleProvider = new WdlResamplingSampleProvider(sampleProvider,sampleRate);
                }
                float[] buffer = new float[ret.Length * 100];
                int count = 0;
                while((count = sampleProvider.Read(buffer,0,buffer.Length)) > 0)
                {
                    for (int i = 0; i < count; i+=ret.Length)
                    {
                        for (int c = 0; c < ret.Length; c++)
                        {
                            ret[c].Add(buffer[i + c]);
                        }
                    }
                }
            }
            return ret.Select(r => r.ToArray()).ToArray();
        }


        private WaveFormat _outWaveFormat = null;
        private WaveFormat _inWaveFormat = null;
        private ISampleProvider _sampleIn;
        public WaveFormat WaveFormat => _outWaveFormat;
        float[] _buffer;



        float[][] _sampleInBuffer = null;
        float[][] _sampleOutBuffer = null;

        public float outLeft = 0,outRight = 0;
        public float displayLeft = 0,displayRight = 0;
        private float _maxLeft = 0, _maxRight = 0;
        private int cd = 500;

        public bool Bypass = false;
        private float _gain = 1f;


        private float _currentGain = 0f;
        private float _MininumGain = 0f;
        private float _gainAttackRate = 0f;
        private float _gainDecayRate = 0f;
        private float _gate;

        private int _decayCd = 0;
        private int _decayCds = 100;

        public void applySettings(SurroundSettings settings,bool fullApply = false)
        {
            
            _gain = MathHelper.db2linear(settings.masterGain);
            
            _gate = MathHelper.db2linear(settings.cmpGate);
            _MininumGain = settings.cmpRatio == 0 ? -150 : MathHelper.linear2db(1 / settings.cmpRatio);
            float sampleRate = _outWaveFormat.SampleRate;
            _gainAttackRate = (-_MininumGain) / (sampleRate * (settings.cmpAttack/1000f + 0.001f));
            _gainDecayRate = (-_MininumGain) / (sampleRate * (settings.cmpRelease / 1000f + 0.001f));
            _decayCds = _inWaveFormat.SampleRate / 1000 * 25;
            if (settings.cmpAttack <= 0.000001f)
            {
                _currentGain = 0f;//disable compressor
            }
        }


        

        public float[] rawPeaks;
        private float[] _rawMaxs;
        private float l, r;
        int ccd = 1000;

        public float _compressorGain = 1f;

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
                        rawPeaks[c] = _rawMaxs[c];
                        _rawMaxs[c] = 0;
                    }
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
                _compressorGain = -_currentGain;
                float gainFactor = MathHelper.db2linear(_currentGain);

                l = l * _gain * 0.9f * gainFactor;
                r = r * _gain * 0.9f * gainFactor ;


                float dc = Math.Max(Math.Abs(l),Math.Abs(r));
                if(dc > _gate)
                {
                    _currentGain -= _gainAttackRate;
                    if(_currentGain < _MininumGain)
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


                buffer[offset + i * 2] = l;
                buffer[offset + i * 2 + 1] = r;
                cd--;
                if (cd < 0)
                {
                    cd = ccd;
                    outLeft = _maxLeft;
                    outRight = _maxRight;
                    _maxLeft = 0;
                    _maxRight = 0;
                }
            }

            return monoCount * 2 ;
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
            Program.neenSave = true;
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
