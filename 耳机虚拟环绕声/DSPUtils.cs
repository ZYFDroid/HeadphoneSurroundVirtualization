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
            int bufferLen = (int)(0.32 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.2f, -1);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.1f, -18);
            CrossIn = 0.6f;
        }

        public override float[] process(float sample)
        {
            channels[0] = crossInFilter1.Transform(sample) ;
            channels[1] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
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
            channels[1] = crossInFilter1.Transform(sample);
            channels[0] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
        }
    }

    public class FrontCenterDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        public FrontCenterDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(0.16 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.15f, -2);
        }

        public override float[] process(float sample)
        {
            float actual = _buffer.pop(sample);
            channels[1] = crossInFilter1.Transform(actual) * 0.8f;
            channels[0] = crossInFilter1.Transform(actual) * 0.8f;
            return channels;
        }
    }
    public class LowFrequentDsp : DSPProcessor
    {
        RingBuffer _buffer;
        BiQuadFilter crossInFilter1;
        public LowFrequentDsp(int sampleRate) : base(sampleRate)
        {
            int bufferLen = (int)(0.48 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 16000, 0.16f, -18);
        }

        public override float[] process(float sample)
        {
            float actual = _buffer.pop(sample);
            channels[1] =  crossInFilter1.Transform(actual);
            channels[0] =  crossInFilter1.Transform(actual);
            return channels;
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
            int bufferLen = (int)(0.3 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.16f, -5);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.1f, -18);
            CrossIn = 0.6f;
        }

        public override float[] process(float sample)
        {
            channels[0] = crossInFilter1.Transform(sample);
            channels[1] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
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
            int bufferLen = (int)(0.3 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.16f, -5);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.1f, -18);
            CrossIn = 0.6f;
        }

        public override float[] process(float sample)
        {
            channels[1] = crossInFilter1.Transform(sample);
            channels[0] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
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
            int bufferLen = (int)(0.5 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.16f, 2f);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.1f, -18);
            CrossIn = 0.8f;
        }

        public override float[] process(float sample)
        {
            channels[0] = crossInFilter1.Transform(sample);
            channels[1] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
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
            int bufferLen = (int)(0.5 / 1000 * sampleRate);
            _buffer = new RingBuffer(bufferLen);
            crossInFilter1 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.16f, 2f);
            crossInFilter2 = BiQuadFilter.PeakingEQ(sampleRate, 20000, 0.1f, -18);
            CrossIn = 0.8f;
        }

        public override float[] process(float sample)
        {
            channels[1] = crossInFilter1.Transform(sample);
            channels[0] = crossInFilter2.Transform(_buffer.pop(sample)) * (subWeight / mainWeight);
            return channels;
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

}
