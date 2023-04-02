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

namespace 耳机虚拟环绕声
{
    public partial class CtlEQView : UserControl
    {

        public event EventHandler<Graphics> PostRender;

        public CtlEQView()
        {
            InitializeComponent();
        }

        private void CtlEQView_Load(object sender, EventArgs e)
        {
            if (DesignMode) { return; }
            this.DoubleBuffered = true;
            this.BorderStyle = BorderStyle.None;
            initMemoryDC();
            if (!DesignMode)
            {
                renderTimer.Start();
            }
        }

        private void initMemoryDC()
        {
            renderTimer.Enabled = false;
            backgroundBuffer?.Dispose();
            backgroundDC?.Dispose();
            backgroundDC = new Bitmap(this.Width, this.Height);
            backgroundBuffer = Graphics.FromImage(backgroundDC);
            //backgroundBuffer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            backgroundBuffer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            renderBackground();
            renderTimer.Enabled = true;
        }

        private Bitmap backgroundDC = null;
        private Graphics backgroundBuffer = null;

        private void renderBackground()
        {
            Graphics g = backgroundBuffer;
            g.Clear(Color.Black);
            float w = Width;
            float h = Height;
            g.DrawLine(gridPen, 0, h / 2, w, h / 2);
            for (int i = 30; i < 100; i += 10)
            {
                float px = w * Freq2Log(i);
                g.DrawLine(gridPen, px, 1, px, Height);
            }
            for (int i = 100; i < 1000; i += 100)
            {
                float px = w * Freq2Log(i);
                g.DrawLine(gridPen, px, 0, px, Height);
            }
            for (int i = 1000; i < 10000; i += 1000)
            {
                float px = w * Freq2Log(i);
                g.DrawLine(gridPen, px, 0, px, Height);
            }
            for (int i = 10000; i < 20000; i += 5000)
            {
                float px = w * Freq2Log(i);
                g.DrawLine(gridPen, px, 0, px, Height);
            }

            Action<float, string> drawAtFreq = (freq, text) =>
            {
                float x = Freq2Log((int)freq) * w;
                g.DrawLine(gridPenStroke, x, 0, x, Height);
                RectangleF rect = new RectangleF(x, h - 30, 100, 30);
                g.DrawString(text, Font, forePen.Brush, rect, bottomLeft);
            };

            int step = 1;
            if (Height < 720)
            {
                step = 2;
            }

            if (Height < 400)
            {
                step = 3;
            }

            Action<float, string> drawAtDb = (dB, text) =>
            {
                float y = h / 2 - (dB / DisplayRange) * (h / 2);

                if (text != "")
                {
                    RectangleF rect = new RectangleF(0, y - 30, 1000, 30);
                    g.DrawString(text, Font, forePen.Brush, rect, bottomLeft);

                    g.DrawLine(gridPenStroke, 0, y, Width, y);
                }
                else
                {

                    g.DrawLine(gridPen, 0, y, Width, y);
                }
                
                
            };
            drawAtFreq(20, "20Hz");
            drawAtFreq(100, "100Hz");
            drawAtFreq(1000, "1kHz");
            drawAtFreq(10000, "10kHz");

            float clippedRange = ((int)(DisplayRange / 3 - 1)) * 3f;

            

            for (int d = 0; d <= clippedRange; d += step)
            {
                string msg = "";

                if(step == 1)
                {
                    msg = (d % 5 == 0) ? (d+" dB") : "";
                }

                if (step == 2)
                {
                    msg = (d % 4 == 0) ? (d + " dB") : "";
                }
                if (step == 3)
                {
                    msg = (d % 6 == 0) ? (d + " dB") : "";
                }
                drawAtDb(d, msg);
                if (d > 0.01f)
                {
                    drawAtDb(-d, msg == "" ? msg : "-"+msg);
                }
            }


            g.DrawRectangle(forePen, 0, 0, Width - 1, Height - 1);
        }

        

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            initMemoryDC();
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            initMemoryDC();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            DrawInternal(e.Graphics);
            
        }
        public void Redraw()
        {
            Invalidate();
        }



        private Pen forePen = new Pen(Color.White, 2);
        private Pen gridPen = new Pen(Color.FromArgb(255,48,48,48), 1);
        private Pen gridPenStroke = new Pen(Color.Gray, 1);


        public List<EqualizerAPO.FilterNode> PeakEQParams = new List<EqualizerAPO.FilterNode>();

        private void DrawInternal(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawImage(backgroundDC, 0, 0);

            float w = Width;
            float h = Height;

            if(PeakEQParams.Count == 0)
            {
                g.DrawLine(forePen, 0, h / 2, w, h / 2);
                PostRender?.Invoke(this, g);
                return;
            }

            var list = PeakEQParams.OrderBy(p => p.freq).ToArray();
            float lastX = 0;
            float lastY = h / 2 - h / 2 * (list[0].dbGain / DisplayRange);
            foreach (var item in list)
            {
                float lx = w * Freq2Log((int)item.freq);
                float ly = h / 2 - h / 2 * (item.dbGain / DisplayRange);
                g.DrawLine(forePen, lastX, lastY, lx, ly);
                lastX = lx;
                lastY = ly;
            }
            g.DrawLine(forePen,lastX,lastY,w,lastY);
            PostRender?.Invoke(this,g);
        }

        public float DisplayRange = 30f;//dB

        public static float Freq2Log(int freq)
        {
            return (float)(Math.Log10(freq / 2) - 1f) / 3f;
        }

        public static int Log2Freq(float log)
        {
            return (int)Math.Round(Math.Pow(10, (log * 3) + 1) * 2d);
        }

        StringFormat bottomLeft = new StringFormat() { Alignment = StringAlignment.Near,LineAlignment = StringAlignment.Far };

        public float GainAt(float freq)
        {
            if (PeakEQParams.Count == 0)
            {
                return 0;
            }
            if(PeakEQParams.Count == 1)
            {
                return PeakEQParams[0].dbGain;
            }
            
            var list = PeakEQParams.OrderBy(p => p.freq).ToArray();
            if(freq < list[0].freq)
            {
                return list[0].dbGain;
            }
            if(freq > list[list.Length- 1].freq)
            {
                return list[list.Length-1].dbGain;
            }
            for (int i = 0; i < list.Length-1; i++)
            {
                if (list[i+1].freq > freq && list[i].freq <= freq)
                {
                    float fromFreq = list[i].freq;
                    float toFreq = list[i+1].freq;
                    float fromLog = Freq2Log((int)fromFreq);
                    float toLog = Freq2Log((int)toFreq);
                    float midLog = Freq2Log((int)freq);

                    float logPercent =(midLog - fromLog) / (toLog - fromLog);

                    float fromDbGain = list[i].dbGain;
                    float toDbGain = list[i + 1].dbGain;

                    return fromDbGain + logPercent * (toDbGain - fromDbGain);

                }
            }
            // This should not happen.
            return list[list.Length - 1].dbGain;
        }

        public float GuarssianDistribution(float altitude,float Q,float x)
        {
            float q = Q * 100f; //Magic
            double step1 = (1d / Math.Sqrt(2d * Math.PI * q)) * Math.Pow(Math.E, -x * x * q / 2);
            double step2 = (1d / Math.Sqrt(2d * Math.PI * q)) * Math.E * 0.368d; //Magic
            return (float)((step1 / step2) * altitude);
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Invalidate();
            }
        }
    }

    
}
