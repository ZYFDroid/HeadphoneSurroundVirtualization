using AudioCommon;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 耳机虚拟环绕声;

namespace TestEQCreator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            frequentProvider = new FrequentProvider(48000);
            wasapiOut = new WasapiOut(NAudio.CoreAudioApi.AudioClientShareMode.Shared,50);
            wasapiOut.Init(frequentProvider);
        }
        WasapiOut wasapiOut;
        FrequentProvider frequentProvider;

        private void ctlBarSlider1_ValueChanged(object sender, EventArgs e)
        {
            int newFreq = CtlEQView.Log2Freq(((float)ctlBarSlider1.Value) / 10000f);
            if(newFreq < 32) { newFreq = 32; }
            if(newFreq > 16384) { newFreq = 16384; }
            frequentProvider.Frequency = newFreq;
            ctlBarSlider1.ThumbText = newFreq + " Hz";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wasapiOut.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wasapiOut.Pause();
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
            for (int i = offset; i < offset+count; i++)
            {
                buffer[i] = (float)Next();
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

        double Next()
        {
            T = T + dT;
            if(T > 999999999)
            {
                T = 0;
            }
            return Math.Sin(T) * 0.1d;
        }
    }
}
