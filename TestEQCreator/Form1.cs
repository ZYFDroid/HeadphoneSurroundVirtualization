using AudioCommon;
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

        public static int[] tests = {80, 105, 140, 180, 240, 320, 420, 550};

        public static float testScale = 7f / 3f;

        public static float testQ = 3.5f;

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
                //eqs.Add(new PeakEQParam() { centerFrequent = tests[i], gain = 3, Q = 0.1f });
            }
            eqs.Add(new PeakEQParam() { centerFrequent = 1210, gain =-5, Q = 0.9054f });
            eqs.Add(new PeakEQParam() { centerFrequent = 2773, gain = -3.8f, Q = 1.2848f });
            eqs.Add(new PeakEQParam() { centerFrequent = 13372, gain = 5.3f, Q = 0.24000f });
            eqs.Add(new PeakEQParam() { centerFrequent = 48, gain = 2.4f, Q = 0.3333f });
            eqs.Add(new PeakEQParam() { centerFrequent = 3758, gain = 1, Q = 0.9333f });
            ctlEQView1.PeakEQParams = eqs;
        }

        private void ctlFQ_Load(object sender, EventArgs e)
        {
            
        }

        private void ctlFQ_ValueChanged(object sender, EventArgs e)
        {
            ctlFQ.ThumbText =""+ ctlFQ.Value / 1000f;
            foreach (var item in eqs)
            {
                //item.Q = ctlFQ.Value / 1000f;
            }
        }

        private void numVD(object sender, EventArgs e)
        {
            numDisplayFactor.ThumbText =""+ numDisplayFactor.Value / 1000f;
            ctlEQView1.ndFactor = numDisplayFactor.Value / 1000f;
        }
    }
}
