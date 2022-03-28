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
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
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

    class SurroundToStereoSampleProvider : ISampleProvider
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
                }
                left =clamp(left / (float)_channels);
                right =clamp(right / (float)_channels);
                buffer[outOffset] = left;
                buffer[outOffset+1] = right;
                outOffset += 2;
                sampleReaded += 2;
            }

            return sampleReaded;
        }

        private float clamp(float f)
        {
            if(f < -1) { return -1; }
            if(f > 1) { return 1; }
            return f;
        }
    }

    class LowLanceyLoopbackCapture : WasapiCapture
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
