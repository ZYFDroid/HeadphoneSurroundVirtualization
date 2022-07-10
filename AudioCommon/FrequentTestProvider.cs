using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using 耳机虚拟环绕声;

namespace AudioCommon
{
    public class FrequentTestProvider : ISampleProvider
    {
        private WaveFormat _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(48000, 1);

        public WaveFormat WaveFormat => _waveFormat;

        public float freq0 = 500;
        public float freq1 = 500;

        private float freq1Strength = 0.5f;
        private float freq2Strength = 0.5f;

        private int n = 0;

        public float Freq1Strength
        {
            get => MathHelper.linear2db(freq1Strength);
            set => freq1Strength = MathHelper.db2linear(value);
        }
        public float Freq2Strength
        {
            get => MathHelper.linear2db(freq2Strength);
            set => freq2Strength = MathHelper.db2linear(value);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            Array.Clear(buffer, offset, count);
            for (int i = offset; i < offset + count; i++)
            {
                float n0 = (float)n / 48000f;
                float sample = 0;
                if(n0 <= 0.333f)
                {
                    sample = (float)Math.Sin(n0 * Math.PI * freq0) * freq1Strength;
                    if(n0 >= 0.300f)
                    {
                        sample = sample * (0.333f - n0) / 0.033f;
                    }
                }

                if(n0 >= 0.5 && n0 <= 0.833)
                {
                    sample = (float)Math.Sin((n0 - 0.500f) * Math.PI * freq1) * freq2Strength;
                    if (n0 >= 0.800f)
                    {
                        sample = sample * (0.833f - n0) / 0.033f;
                    }
                }

                buffer[i] = sample;

                n++;
                if(n >= 48000)
                {
                    n = 0;
                }
            }

            return count;
        }
    }
}
