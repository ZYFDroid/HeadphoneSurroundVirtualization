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
        public CtlEQView()
        {
            InitializeComponent();
        }

        private void CtlEQView_Load(object sender, EventArgs e)
        {
            if (DesignMode) { return; }
            this.DoubleBuffered = true;
            this.BorderStyle = BorderStyle.None;
            controlGraphics = Graphics.FromHwnd(Handle);
            initMemoryDC();
            if (!DesignMode)
            {
                renderTimer.Start();
            }
        }

        private void initMemoryDC()
        {
            renderTimer.Enabled = false;
            renderBuffer?.Dispose();
            memoryDC?.Dispose();
            backgroundBuffer?.Dispose();
            backgroundDC?.Dispose();
            backgroundDC = new Bitmap(this.Width, this.Height);
            backgroundBuffer = Graphics.FromImage(backgroundDC);
            memoryDC = new Bitmap(this.Width, this.Height);
            renderBuffer = Graphics.FromImage(memoryDC);
            renderBuffer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            renderBuffer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            backgroundBuffer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            backgroundBuffer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            renderBackground();
            renderTimer.Enabled = true;
        }

        private Bitmap memoryDC = null;
        private Bitmap backgroundDC = null;
        private Graphics backgroundBuffer = null;
        private Graphics renderBuffer = null;
        private Graphics controlGraphics = null;

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

            Action<float, string> drawAtDb = (dB, text) =>
            {
                float y = h / 2 - (dB / DisplayRange) * (h / 2);
                g.DrawLine(gridPen, 0, y, Width, y);
                RectangleF rect = new RectangleF(0, y - 30, 1000, 30);
                g.DrawString(text, Font, forePen.Brush, rect, bottomLeft);
            };
            drawAtFreq(20, "20Hz");
            drawAtFreq(100, "100Hz");
            drawAtFreq(1000, "1kHz");
            drawAtFreq(10000, "10kHz");

            float clippedRange = ((int)(DisplayRange / 3 - 1)) * 3f;

            for (float d = -clippedRange; d <= clippedRange; d += 3)
            {
                drawAtDb(d, d + "dB");
            }


            g.DrawRectangle(forePen, 0, 0, Width - 1, Height - 1);
        }

        private void Draw()
        {

            if (controlGraphics == null)
            {
                return;
            }
            if (renderBuffer == null)
            {
                return;
            }
            if (ParentForm.WindowState == FormWindowState.Minimized) { return; }
            DrawInternal(renderBuffer);
            controlGraphics.DrawImage(memoryDC, 0, 0);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            initMemoryDC();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            initMemoryDC();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (DesignMode)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                DrawInternal(e.Graphics);
            }
            
        }
        public void Redraw()
        {
            Draw();
        }



        private Pen forePen = new Pen(Color.White, 2);
        private Pen gridPen = new Pen(Color.Gray, 1);
        private Pen gridPenStroke = new Pen(Color.White, 1);


        public List<EqualizerAPO.FilterNode> PeakEQParams = new List<EqualizerAPO.FilterNode>();

        // 凑出来的
        private const float ndFactor = 3.5f;


        private void DrawInternal(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawImage(backgroundDC, 0, 0);

            float w = Width;
            float h = Height;

            if(PeakEQParams.Count == 0)
            {
                g.DrawLine(forePen, 0, h / 2, w, h / 2);
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

        }

        public float DisplayRange = 15f;//dB

        public float evalEqParam(int freq,float q,float gain,float xpos)
        {
            // 下面的数据是我凑出来的。凑了半天，只要画出来的图像和EqualizerAPO里的看着很像就行了（
            float centerX = Freq2Log(freq);
            float qMultiplier = ndFactor;
            return GuarssianDistribution(gain, q * qMultiplier, xpos - centerX);
        }

        public static float Freq2Log(int freq)
        {
            return (float)(Math.Log10(freq / 2) - 1f) / 3f;
        }

        public static int Log2Freq(float log)
        {
            return (int)Math.Round(Math.Pow(10, (log * 3) + 1) * 2d);
        }

        StringFormat bottomLeft = new StringFormat() { Alignment = StringAlignment.Near,LineAlignment = StringAlignment.Far };

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
                Draw();
            }
        }
    }

    
}
