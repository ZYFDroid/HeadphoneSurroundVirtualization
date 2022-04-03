using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
namespace 耳机虚拟环绕声
{
    internal static class Program
    {

        internal static SurroundSettings SurroundSettings = new SurroundSettings();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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

        public float cmpRatio = 1; // 压缩器 - 压缩比
        public float cmpAttack = 40;// 压缩器 - 启动时间
        public float cmpRelease = 400; // 压缩器 - 释放时间
        public float cmpGate = 0;// 压缩器 - 噪音门限

        public float fsVolume = 1.0f; //前扬声器音量
        public float fsCrossin = 0.6f; //前混音交叉淡入
        public float fsSideDecay = 2.0f; //前侧高频衰减
        public float fsOpposideDecay = 16.0f; //前侧对侧高频衰减
        public float fsOpposideDelay = 0.32f; //对侧延迟混音毫秒

        public float fcVolume = 0.8f; //中置扬声器音量
        public float fcDecay = 3f; //中置高频衰减
        public float fcDelay = 0.16f;//中置混音延迟

        public float lfVolume = 1.0f; //低音扬声器音量
        public float lfDecay = 18f; //低音扬声器高频衰减
        public float lfDelay = 0.48f;//低音扬声器混音延迟

        public float rsVolume = 0.8f; //后扬声器音量
        public float rsCrossin = 0.6f; //后置混音交叉淡入
        public float rsSideDecay = 9.0f; //后侧高频衰减
        public float rsOpposideDecay = 24.0f; //后侧对侧高频衰减
        public float rsOpposideDelay = 0.32f; //后侧延迟混音毫秒

        public float ssVolume = 1.0f; //侧面扬声器音量
        public float ssCrossin = 0.8f; //侧面混音交叉淡入
        public float ssSideDecay = -2.0f; //侧面高频衰减
        public float ssOpposideDecay = 22.0f; //侧面对侧高频衰减
        public float ssOpposideDelay = 0.5f; //侧面延迟混音毫秒

    }

    public class SurroundToStereoSampleProvider : ISampleProvider
    {
        int _channels=8;
        public SurroundToStereoSampleProvider(ISampleProvider sampleIn)
        {
            _sampleIn = sampleIn;
            _inWaveFormat = sampleIn.WaveFormat;
            _outWaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(_inWaveFormat.SampleRate, 2);
            _buffer = new float[_inWaveFormat.Channels * _inWaveFormat.SampleRate / 10];
            _channels = _inWaveFormat.Channels;
            dspProcessor[OffsetFrontLeft] = new FrontLeftDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetFrontRight] = new FrontRightDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetFrontCenter] = new FrontCenterDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetBassBoost] = new LowFrequentDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetRearLeft] = new RearLeftDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetRearRight] = new RearRightDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetSideLeft] = new SideLeftDsp(_inWaveFormat.SampleRate);
            dspProcessor[OffsetSideRight] = new SideRightDsp(_inWaveFormat.SampleRate);
            rawPeaks = new float[_inWaveFormat.Channels];
            _rawMaxs = new float[_inWaveFormat.Channels];
        }
        private WaveFormat _outWaveFormat = null;
        private WaveFormat _inWaveFormat = null;
        private ISampleProvider _sampleIn;
        public WaveFormat WaveFormat => _outWaveFormat;
        float[] _buffer;

        const int OffsetFrontLeft = 0; // 左前
        const int OffsetFrontRight = 1; //右前
        const int OffsetFrontCenter = 2; //前
        const int OffsetBassBoost = 3; //低音炮
        const int OffsetRearLeft = 4; //左后
        const int OffsetRearRight = 5; //右后
        const int OffsetSideLeft = 6; //左侧
        const int OffsetSideRight = 7; //右侧

        DSPProcessor[] dspProcessor = new DSPProcessor[8];

        public float outLeft = 0,outRight = 0;
        public float displayLeft = 0,displayRight = 0;
        private float _maxLeft = 0, _maxRight = 0;
        private int cd = 500;
        private int updatePeakDelay = 500;

        private float _gain = 1f;
        public void applySettings(SurroundSettings settings,bool fullApply = false)
        {
            if (fullApply)
            {
                foreach (var item in dspProcessor)
                {
                    item.applySettings(settings);
                }
            }
            _gain = MathHelper.db2linear(settings.masterGain);

            _compressThreahold = settings.cmpGate;
            updatePeakDelay = _outWaveFormat.SampleRate / 1000;
            _minCompress = settings.cmpRatio < 0.5f ? 0 : 1f / settings.cmpRatio;
            if(_minCompress == 0)
            {
                _minCompress = 0.0000001f;
            }
            _compressUpRate = settings.cmpRelease == 0 ? 20 : (0 - MathHelper.linear2db(_minCompress)) / settings.cmpRelease;
            _compressDownRate = settings.cmpAttack == 0 ? 20 : (0 - MathHelper.linear2db(_minCompress)) / settings.cmpAttack;
            if(_minCompress >= 0.99999f)
            {
                _compressGain = 0;
            }
        }


        public float[] rawPeaks;
        private float[] _rawMaxs;

        public int Read(float[] buffer, int offset, int count)
        {

            
            int sampleReaded = 0;
            int desiredSamples = count / 2;
            int neededSamples = desiredSamples * _inWaveFormat.Channels;
            int maxSamples = _buffer.Length;

            int readFrom = _sampleIn.Read(_buffer,0,Math.Min(maxSamples,neededSamples));

            int outOffset = offset;
            for (int i = 0; i < readFrom; i+=_channels)
            {
                float left = 0;
                float right = 0;
                for(int c = 0;c < _channels; c++)
                {
                    float[] data = dspProcessor[c].process(_buffer[i + c]);
                    left += data[0];
                    right += data[1];
                    _rawMaxs[c] = _rawMaxs[c] > _buffer[i + c] ? _rawMaxs[c] : _buffer[i + c];
                }
                left = left / (float)_channels * _gain;
                right = right / (float)_channels * _gain;
                

                float aleft = left < 0 ? -left : left;
                float aright = right < 0 ? -right : right;

                _maxLeft = _maxLeft < aleft ? aleft : _maxLeft;
                _maxRight = _maxRight < aright ? aright : _maxRight;
                
                if(cd-- < 0)
                {
                    cd = updatePeakDelay;
                    outLeft = _maxLeft;
                    outRight = _maxRight;
                    _maxLeft = 0;
                    _maxRight = 0;

                    for (int c = 0; c < _channels; c++)
                    {
                        rawPeaks[c] = _rawMaxs[c];
                        _rawMaxs[c] = 0;
                    }
                    
                    processCompressor();
                }
                float linearCompressGain = MathHelper.db2linear(_compressGain);
                left = MathHelper.clamp(left * linearCompressGain);
                right = MathHelper.clamp(right * linearCompressGain);
                displayLeft = outLeft * linearCompressGain;
                displayRight = outRight * linearCompressGain;
                buffer[outOffset] = left;
                buffer[outOffset + 1] = right;

                outOffset += 2;
                sampleReaded += 2;
            }

            return sampleReaded;
        }

        public float _compressGain = 0f;

       

        private float _compressThreahold = 1;
        private float _minCompress = 1;

        private float _compressUpRate = 0.001f;
        private float _compressDownRate = 0.001f;

        private float[] _peakHistory = new float[10];
        private int _peakHistoryPtr = 0;

        private void processCompressor()
        {
            float peak =MathHelper.linear2db(displayLeft > displayRight ? displayLeft : displayRight);
            _peakHistory[_peakHistoryPtr] = peak;
            _peakHistoryPtr++;
            if(_peakHistoryPtr >= _peakHistory.Length)
            {
                _peakHistoryPtr = 0;
            }
            peak = _peakHistory.Max();
            if(peak > _compressThreahold)
            {
                _compressGain -= _compressDownRate;
                

                if(MathHelper.db2linear(_compressGain) < _minCompress)
                {
                    _compressGain = MathHelper.linear2db(_minCompress <= 0.0001f ? 0.0001f : _minCompress);
                }
            }
            else
            {
                _compressGain += _compressUpRate;
                if(_compressGain > 0)
                {
                    _compressGain = 0;
                }
            }
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
}
