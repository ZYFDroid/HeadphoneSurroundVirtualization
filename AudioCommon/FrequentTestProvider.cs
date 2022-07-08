using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace AudioCommon
{
    public class FrequentTestProvider : ISampleProvider
    {
        private WaveFormat _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(48000, 1);

        public WaveFormat WaveFormat => _waveFormat;

        public int freq0 = 500;
        public int freq1 = 500;

        public float freq1Strength = 1.0f;
        public float freq2Strength = 1.0f;

        private int n = 0;

        public int Read(float[] buffer, int offset, int count)
        {
            Array.Clear(buffer, offset, count); 
            return count;
        }
    }
}
