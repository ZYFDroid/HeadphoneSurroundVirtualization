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


    public class DoNothingDSP : DSPProcessor
    {
        float[] channels = new float[2];
        public DoNothingDSP(int sampleRate) : base(sampleRate)
        {
        }

        public override void applySettings(SurroundSettings settings)
        {
           
        }

        public override float[] process(float sample)
        {
           return channels;
        }
    }

    public class ImpulseResponseDSP : DSPProcessor
    {
        private ImpulseResponseConvolution leftConv = null;
        private ImpulseResponseConvolution rightConv = null;

        public ImpulseResponseDSP(int sampleRate,float[] leftIR,float[] rightIR) : base(sampleRate)
        {
            leftConv = new ImpulseResponseConvolution(leftIR);
            rightConv = new ImpulseResponseConvolution(rightIR);
        }

        public override void applySettings(SurroundSettings settings)
        {
             
        }

        float[] data = new float[2];

        public override float[] process(float sample)
        {
            data[0] = leftConv.transform(sample);
            data[1] = rightConv.transform(sample);
            return data;
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
    class ImpulseResponseConvolution
    {
        private float[] impulse;
        private float[] history;
        private int historyPtr = 0;
        public ImpulseResponseConvolution(float[] impulse)
        {
            this.impulse = impulse;
            this.history = new float[impulse.Length];
        }

        public float transform(float input)
        {
            history[historyPtr] = input;
            float sum = 0;
            int j = historyPtr;
            for (int i = 0; i < impulse.Length; i++)
            {
                sum += impulse[i] * history[j];
                j++;
                if (j > impulse.Length)
                {
                    j = 0;
                }
            }
            return sum;

        }

    }
}
