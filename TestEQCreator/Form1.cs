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

        /*
         ---------------------------

---------------------------
80,105,138,182,240,317,418,551,726,957,1262,1664,2193,2891,3811,5024,6623,8730,11509,15172,
---------------------------
确定   
---------------------------

         */
        public Form1()
        {
            InitializeComponent();
        }
        // 测试频响曲线时使用的基准频率
        public static int[] tests = { 80, 105, 138, 182, 240, 317, 418, 551, 726, 957, 1262, 1664, 2193, 2891, 3811, 5024, 6623, 8730, 11509, 15172 };
        // 生成频响曲线校准的时候使用的Q值
        public static float bandQ = 2f;
        // 生成频响曲线校准时使用的Q值的倍数
        public static float dbGainMultiplier = 3f / 7.6f;



        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 200;i <= 960;i+=40)
            {
                float f = i / 1000f;
                sb.Append(CtlEQView.Log2Freq(f)).Append(",");
            }
            MessageBox.Show(sb.ToString());
        }
        List<PeakEQParam> eqs = new List<PeakEQParam>();
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tests.Length; i++)
            {
                eqs.Add(new PeakEQParam() { centerFrequent = tests[i], gain = 3, Q = bandQ });
            }
            //ctlEQView1.PeakEQParams = eqs;
            testProvider.freq0 = 551;
            testProvider.freq1 = 551;
            testProvider.Freq1Strength = -15;
            testProvider.Freq2Strength = -15;
            waveOut = new WaveOut();
            waveOut.Init(testProvider);
            waveOut.Play();
        }
        private WaveOut waveOut;
        private FrequentTestProvider testProvider = new FrequentTestProvider();

        private void ctlFQ_Load(object sender, EventArgs e)
        {
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in ctlEQView1.PeakEQParams)
            {
                //Console.WriteLine($"Filter: ON PK Fc {item.centerFrequent} Hz Gain {item.gain} dB Q {item.Q}");
            }
        }

        private void ctlBarSlider1_Load(object sender, EventArgs e)
        {
            ctlBarSlider1.ThumbText = tests[ctlBarSlider1.Value] + " Hz";
            testProvider.freq1 = tests[ctlBarSlider1.Value];
            //ctlBarSlider2.Value = (int)Math.Round(ctlEQView1.PeakEQParams[ctlBarSlider1.Value].gain * 100f / dbGainMultiplier);
        }

        private void ctlBarSlider2_ValueChanged(object sender, EventArgs e)
        {
            float dB = (float)ctlBarSlider2.Value / 100f;
            float dBDiff = (float)ctlBarSlider3.Value / 100f;
            ctlBarSlider2.ThumbText = dB + " dB";
            testProvider.Freq1Strength = dB - 15f + dBDiff;
            testProvider.Freq2Strength = 0 - 15f + dBDiff;
            //ctlEQView1.PeakEQParams[ctlBarSlider1.Value].gain = dB * dbGainMultiplier;
        }

        private void ctlBarSlider3_ValueChanged(object sender, EventArgs e)
        {
            float dB = (float)ctlBarSlider2.Value / 100f;
            float dBDiff = (float)ctlBarSlider3.Value / 100f;
            ctlBarSlider3.ThumbText = dBDiff + " dB";
            testProvider.Freq1Strength = dB - 15f + dBDiff;
            testProvider.Freq2Strength = 0 - 15f + dBDiff;
        }
    }
}
