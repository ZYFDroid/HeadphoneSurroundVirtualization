using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 耳机虚拟环绕声
{
    public abstract class DSPProcessor
    {
        protected int _sampleRate;
        public DSPProcessor(int sampleRate)
        {
            _sampleRate = sampleRate;
        }

        protected float[] channels = new float[2];
        public abstract float[] process(float sample);


        public abstract void applySettings(SurroundSettings settings);
    }

    public class FrontLeftDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        BiQuadFilter crossInFilter2;
        public float CrossIn
        {
            get
            {
                return mainWeight;
            }
            set
            {
                mainWeight = value;
                subWeight = 1 - value;
            }
        }

        private float mainWeight = 0.7f;
        private float subWeight = 0.3f;

        public FrontLeftDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(fsOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.2f, -fsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.1f, -fsOpposideDecay);
            CrossIn = fsCrossin;
        }

        public override float[] process(float sample)
        {
            sample *= fsVolume;
            channels[0] = crossInFilter1.Transform(sample) ;
            channels[1] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }


        public float fsVolume = 1.0f; //前扬声器音量
        public float fsCrossin = 0.6f; //前混音交叉淡入
        public float fsSideDecay = 1.0f; //前侧高频衰减
        public float fsOpposideDecay = 18.0f; //前侧对侧高频衰减
        public float fsOpposideDelay = 0.32f; //对侧延迟混音毫秒

        public override void applySettings(SurroundSettings settings)
        {
            this.fsVolume = settings.fsVolume;
            this.fsCrossin = settings.fsCrossin;
            this.fsSideDecay = settings.fsSideDecay;
            this.fsOpposideDecay = settings.fsOpposideDecay;
            this.fsOpposideDelay = settings.fsOpposideDelay;

            int bufferLen = (int)(fsOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.2f, -fsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.1f, -fsOpposideDecay);
            CrossIn = fsCrossin;
        }
    }
    public class FrontRightDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        BiQuadFilter crossInFilter2;
        public float CrossIn
        {
            get
            {
                return mainWeight;
            }
            set
            {
                mainWeight = value;
                subWeight = 1 - value;
            }
        }

        private float mainWeight = 0.7f;
        private float subWeight = 0.3f;
        public FrontRightDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(0.32 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.2f, -1);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.1f, -18);
            CrossIn = 0.6f;
        }

        public override float[] process(float sample)
        {
            sample *= fsVolume;
            channels[1] = crossInFilter1.Transform(sample);
            channels[0] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }

        public float fsVolume = 1.0f; //前扬声器音量
        public float fsCrossin = 0.6f; //前混音交叉淡入
        public float fsSideDecay = 1.0f; //前侧高频衰减
        public float fsOpposideDecay = 18.0f; //前侧对侧高频衰减
        public float fsOpposideDelay = 0.32f; //对侧延迟混音毫秒

        public override void applySettings(SurroundSettings settings)
        {
            this.fsVolume = settings.fsVolume;
            this.fsCrossin = settings.fsCrossin;
            this.fsSideDecay = settings.fsSideDecay;
            this.fsOpposideDecay = settings.fsOpposideDecay;
            this.fsOpposideDelay = settings.fsOpposideDelay;

            int bufferLen = (int)(fsOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.2f, -fsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.1f, -fsOpposideDecay);
            CrossIn = fsCrossin;
        }
    }

    public class FrontCenterDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        public FrontCenterDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(fcDelay / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.15f, -fcDecay);
        }

        public override float[] process(float sample)
        {
            float actual = _buffer.pop(sample);
            channels[1] = crossInFilter1.Transform(actual) * fcVolume;
            channels[0] = crossInFilter1.Transform(actual) * fcVolume;
            return channels;
        }
        public float fcVolume = 0.8f; //中置扬声器音量
        public float fcDecay = -2f; //中置高频衰减
        public float fcDelay = 0.16f;//中置混音延迟
        public override void applySettings(SurroundSettings settings)
        {
            this.fcDecay = settings.fcDecay;
            this.fcDelay = settings.fcDelay;
            this.fcVolume = settings.fcVolume;
            int bufferLen = (int)(fcDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.15f, -fcDecay);
        }
    }
    public class LowFrequentDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        public LowFrequentDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(lfDelay / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 16000, 0.16f, -lfDecay);
        }

        public override float[] process(float sample)
        {
            float actual = _buffer.pop(sample) * lfVolume;
            channels[1] =  crossInFilter1.Transform(actual);
            channels[0] =  crossInFilter1.Transform(actual);
            return channels;
        }
        public float lfVolume = 1.0f; //低音扬声器音量
        public float lfDecay = -18f; //低音扬声器高频衰减
        public float lfDelay = 0.48f;//低音扬声器混音延迟
        public override void applySettings(SurroundSettings settings)
        {
            this.lfVolume = settings.lfVolume;
            this.lfDecay = settings.lfDecay;
            this.lfDelay = settings.lfDelay;
            int bufferLen = (int)(lfDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 16000, 0.16f, -lfDecay);
        }
    }

    public class RearLeftDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        BiQuadFilter crossInFilter2;
        public float CrossIn
        {
            get
            {
                return mainWeight;
            }
            set
            {
                mainWeight = value;
                subWeight = 1 - value;
            }
        }

        private float mainWeight = 0.7f;
        private float subWeight = 0.3f;
        public RearLeftDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(rsOpposideDelay / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 16000, 0.16f, -rsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 16000, 0.1f, -rsOpposideDecay);
            CrossIn = rsCrossin;
        }

        public override float[] process(float sample)
        {
            sample *= rsVolume;
            channels[0] = crossInFilter1.Transform(sample);
            channels[1] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }

        public float rsVolume = 1.0f; //后扬声器音量
        public float rsCrossin = 0.6f; //后置混音交叉淡入
        public float rsSideDecay = 5.0f; //后侧高频衰减
        public float rsOpposideDecay = 24.0f; //后侧对侧高频衰减
        public float rsOpposideDelay = 0.3f; //后侧延迟混音毫秒
        public override void applySettings(SurroundSettings settings)
        {
            rsVolume = settings.rsVolume;
            rsCrossin = settings.rsCrossin;
            rsSideDecay = settings.rsSideDecay;
            rsOpposideDecay = settings.rsOpposideDecay;
            rsOpposideDelay=settings.rsOpposideDelay;
            int bufferLen = (int)(rsOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 16000, 0.16f, -rsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 16000, 0.1f, -rsOpposideDecay);
            CrossIn = rsCrossin;
        }
    }
    public class RearRightDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        BiQuadFilter crossInFilter2;
        public float CrossIn
        {
            get
            {
                return mainWeight;
            }
            set
            {
                mainWeight = value;
                subWeight = 1 - value;
            }
        }

        private float mainWeight = 0.7f;
        private float subWeight = 0.3f;
        public RearRightDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(rsOpposideDelay / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 16000, 0.16f, -rsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 16000, 0.1f, -rsOpposideDecay);
            CrossIn = rsCrossin;
        }

        public override float[] process(float sample)
        {
            sample *= rsVolume;
            channels[1] = crossInFilter1.Transform(sample);
            channels[0] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }

        public float rsVolume = 1.0f; //后扬声器音量
        public float rsCrossin = 0.6f; //后置混音交叉淡入
        public float rsSideDecay = 5.0f; //后侧高频衰减
        public float rsOpposideDecay = 24.0f; //后侧对侧高频衰减
        public float rsOpposideDelay = 0.3f; //后侧延迟混音毫秒
        public override void applySettings(SurroundSettings settings)
        {
            rsVolume = settings.rsVolume;
            rsCrossin = settings.rsCrossin;
            rsSideDecay = settings.rsSideDecay;
            rsOpposideDecay = settings.rsOpposideDecay;
            rsOpposideDelay = settings.rsOpposideDelay;
            int bufferLen = (int)(rsOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 16000, 0.16f, -rsSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 16000, 0.1f, -rsOpposideDecay);
            CrossIn = rsCrossin;
        }
    }
    public class SideLeftDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        BiQuadFilter crossInFilter2;
        public float CrossIn
        {
            get
            {
                return mainWeight;
            }
            set
            {
                mainWeight = value;
                subWeight = 1 - value;
            }
        }

        private float mainWeight = 0.7f;
        private float subWeight = 0.3f;
        public SideLeftDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(ssOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.16f, -ssSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 14000, 0.1f, -ssOpposideDecay);
            CrossIn = ssCrossin;
        }

        public override float[] process(float sample)
        {
            sample *= ssVolume;
            channels[0] = crossInFilter1.Transform(sample);
            channels[1] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }
        public float ssVolume = 1.0f; //侧面扬声器音量
        public float ssCrossin = 0.6f; //侧面混音交叉淡入
        public float ssSideDecay = -2.0f; //侧面高频衰减
        public float ssOpposideDecay = 22.0f; //侧面对侧高频衰减
        public float ssOpposideDelay = 0.36f; //侧面延迟混音毫秒
        public override void applySettings(SurroundSettings settings)
        {
            this.ssVolume = settings.ssVolume;
            this.ssCrossin = settings.ssCrossin;
            this.ssSideDecay = settings.ssSideDecay;
            this.ssOpposideDecay = settings.ssOpposideDecay;
            this.ssOpposideDelay = settings.ssOpposideDelay;
            int bufferLen = (int)(ssOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.16f, -ssSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 14000, 0.1f, -ssOpposideDecay);
            CrossIn = ssCrossin;
        }
    }

    public class SideRightDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        BiQuadFilter crossInFilter2;
        public float CrossIn
        {
            get
            {
                return mainWeight;
            }
            set
            {
                mainWeight = value;
                subWeight = 1 - value;
            }
        }

        private float mainWeight = 0.7f;
        private float subWeight = 0.3f;
        public SideRightDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(ssOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.16f, -ssSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 14000, 0.1f, -ssOpposideDecay);
            CrossIn = ssCrossin;
        }

        public override float[] process(float sample)
        {
            sample *= ssVolume;
            channels[1] = crossInFilter1.Transform(sample);
            channels[0] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }

        public float ssVolume = 1.0f; //侧面扬声器音量
        public float ssCrossin = 0.6f; //侧面混音交叉淡入
        public float ssSideDecay = -2.0f; //侧面高频衰减
        public float ssOpposideDecay = 22.0f; //侧面对侧高频衰减
        public float ssOpposideDelay = 0.36f; //侧面延迟混音毫秒
        public override void applySettings(SurroundSettings settings)
        {
            this.ssVolume = settings.ssVolume;
            this.ssCrossin = settings.ssCrossin;
            this.ssSideDecay = settings.ssSideDecay;
            this.ssOpposideDecay = settings.ssOpposideDecay;
            this.ssOpposideDelay = settings.ssOpposideDelay;
            int bufferLen = (int)(ssOpposideDelay / 1000 * _sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(_sampleRate, 20000, 0.16f, -ssSideDecay);
            crossInFilter2 = BiQuadFilter.PeakingEQ(_sampleRate, 14000, 0.1f, -ssOpposideDecay);
            CrossIn = ssCrossin;
        }
    }
    public class RingBuffer
    {
        private float[] buffer;
        private int bufferPtr = 0;
        public RingBuffer(int len)
        {
            if(len <= 0)
            {
                len = 1;
            }
            buffer = new float[len];
        }

        public float pop(float queueIn)
        {
            float v = buffer[bufferPtr];
            buffer[bufferPtr] = queueIn;
            bufferPtr++;
            if (bufferPtr >= buffer.Length)
            {
                bufferPtr = 0;
            }
            return v;
        }
    }

    public static class MathHelper
    {
        public static float clamp(float x)
        {
            return x < -1 ? -1 : (x > 1 ? 1 : x);
        }

        public static float clamp(float x,float min,float max)
        {
            return x < min ? min : (x > max ? max : x);
        }
        public static float db2linear(float dB)
        {
            return (float) Math.Pow(10d, dB / 20.0);
        }

        public static float linear2db(float x)
        {
            return (float)(20.0 * Math.Log10(x / 1.0));
        }
    }

}
