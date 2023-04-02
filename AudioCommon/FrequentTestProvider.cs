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
        private WaveFormat _waveFormat = null;
        private float sampleRate;

        public FrequentTestProvider(int sampleRate)
        {
            _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
            this.sampleRate = sampleRate; 
        }

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
                float n0 = (float)n / sampleRate;
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
                if(n >= sampleRate)
                {
                    n = 0;
                }
            }

            return count;
        }
    }

    public class SelectionSampleProvider : ISampleProvider
    {
        private ISampleProvider[] providers;
        private int _selectionIndex = 0;
        private WaveFormat _cacheWaveFormat = null;
        public int SelectionIndex
        {
            get { return _selectionIndex; }
            set {
                if(value < 0 || value >= providers.Length)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _selectionIndex = value; 
            }
        }

        public SelectionSampleProvider(ISampleProvider[] providers)
        {
            if(providers.Length == 0)
            {
                throw new ArgumentNullException("Empty array");
            }

            if(providers.Any(p => p == null))
            {
                throw new ArgumentNullException("One or more providers are null");
            }

            this.providers = providers;

            _cacheWaveFormat = providers[0].WaveFormat;

            for (int i = 1; i < providers.Length; i++)
            {
                if (providers[i].WaveFormat.Channels != _cacheWaveFormat.Channels)
                {
                    throw new ArgumentException("Different Waveformat is not allowed");
                }
                if (providers[i].WaveFormat.SampleRate != _cacheWaveFormat.SampleRate)
                {
                    throw new ArgumentException("Different Waveformat is not allowed");
                }
                if (providers[i].WaveFormat.Encoding != _cacheWaveFormat.Encoding)
                {
                    throw new ArgumentException("Different Waveformat is not allowed");
                }
                if (providers[i].WaveFormat.BitsPerSample != _cacheWaveFormat.BitsPerSample)
                {
                    throw new ArgumentException("Different Waveformat is not allowed");
                }
            }

        }

        WaveFormat ISampleProvider.WaveFormat => _cacheWaveFormat;

        int ISampleProvider.Read(float[] buffer, int offset, int count)
        {
            return providers[_selectionIndex].Read(buffer, offset, count);
        }
    }


    public class FrequentProvider : ISampleProvider
    {

        public FrequentProvider(int sampleRate)
        {
            _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
        }
        private WaveFormat _waveFormat;
        public WaveFormat WaveFormat => _waveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] = (float)Next() * _volume;
            }
            return count;
        }

        private double dT = 0;
        private double T = 0;

        private int _freq;

        public int Frequency
        {
            get { return _freq; }
            set
            {
                this._freq = value;
                double _sampleRate = this.WaveFormat.SampleRate;
                double __freq = _freq;
                double oneHzDT = 1 / _sampleRate * Math.PI * 2;
                this.dT = oneHzDT * __freq;
            }
        }
        float _volume;
        public float Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
            }
        }
        double Next()
        {
            T = T + dT;
            if (T > 100*2*Math.PI)
            {
                T -= 100 *2* Math.PI;
            }
            return Math.Sin(T);
        }
    }
}
