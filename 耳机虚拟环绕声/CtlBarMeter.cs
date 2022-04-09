using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3模拟器
{
    public partial class CtlBarMeter : UserControl
    {
        public CtlBarMeter()
        {
            InitializeComponent();
        }

        public const int delayframe = 1;


        float smoothfactor = 0.19f;

        float linearDownValue = 0.0f;

        float animedValue = 0;


        float _value = 0;
        public float Value {
            get { return _value; }
            set {
                _value = value;
                if (_value > 1) { _value = 1; }
                if (_value < 0) { _value = 0; }

                valuehistory[ptr] = _value;
                
                ptr++;
                if (ptr >= valuehistory.Length) { ptr = 0; }
                linearDownValue -= 0.015f;
                if (linearDownValue < valuehistory[ptr])
                {
                    linearDownValue = valuehistory[ptr];
                }
                animedValue = animedValue + (linearDownValue - animedValue) * smoothfactor;

                mask.Height = (int)(this.Height * step(1- animedValue,steps)) + 1;
                //mask.Height = (int)(this.Height * (1- valuehistory[ptr])) + 1;
            }
        }

        public float[] valuehistory = new float[delayframe];
        public int ptr = 0;
        private void CtlBarMeter_Load(object sender, EventArgs e)
        {
            int removePadding = this.BorderStyle == BorderStyle.None ? 0 : 1;
            Image bgImg = new Bitmap(this.Width-2 * removePadding, this.Height-2 * removePadding);
            Graphics g = Graphics.FromImage(bgImg);
            int level1 = bgImg.Height * 10 / 100;
            int level2 = bgImg.Height * 20 / 100;
            Pen pRed = Pens.Red;
            Pen pYellow = Pens.Yellow;
            Pen pGreen = Pens.Lime;
            for (int i = 1; i < bgImg.Height; i+=4)
            {
                Pen p = pGreen;
                if(i < level2)
                {
                    p = pYellow;
                }
                if (i < level1)
                {
                    p = pRed;
                }
                g.DrawLine(p, 1, i, bgImg.Width-2, i);
                g.DrawLine(p, 1, i+1, bgImg.Width-2, i+1);
                steps++;
            }
            steps++;
            g.Dispose();
            Bitmap foreImg = new Bitmap(bgImg);
            g = Graphics.FromImage(foreImg);
            Brush blackmask = new SolidBrush(Color.FromArgb(192,0,0,0));
            g.FillRectangle(blackmask, 0, 0, foreImg.Width, foreImg.Height);
            g.Dispose();
            this.BackgroundImage = bgImg;
            this.mask.BackgroundImage = foreImg;
            mask.Height = this.Height;
        }

        float steps = 0;
        float step(float i,float steps)
        {
            return (float)Math.Round(i * steps) / steps;
        }
    }
}
