using NAudio.Wave;
using NVorbis;
using System;
using System.Collections.Generic;
using System.IO;

namespace NAudio.Vorbis
{
    public class VorbisSampleProvider : ISampleProvider,IDisposable
    {
        private WaveFormat _waveFormat = null;
        public VorbisSampleProvider(string fileName): this(File.OpenRead(fileName), true)
        {
            
        }
        private VorbisReader _vorbisReader = null;
        public VorbisSampleProvider(Stream s, bool autoDispose = false)
        {
            _vorbisReader = new VorbisReader(s,autoDispose);
            _waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(_vorbisReader.SampleRate,_vorbisReader.Channels);
        }

        public WaveFormat WaveFormat => _waveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            return _vorbisReader.ReadSamples(buffer, offset, count);
        }

        public void Dispose()
        {
            try { _vorbisReader.Dispose(); } catch { }  
        }
    }
}