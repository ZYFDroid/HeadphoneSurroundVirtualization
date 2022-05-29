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



        public float smoothfactor = 0.15f;

        float linearDownValue = 0.0f;

        float animedValue = 0;


        float _value = 0;
        public float Value {
            get { return _value; }
            set {
                _value = value;
                if (_value > 1) { _value = 1; }
                if (_value < 0) { _value = 0; }
                if(linearDownValue < _value)
                {
                    linearDownValue = _value;
                }
                
            }
        }
        private void CtlBarMeter_Load(object sender, EventArgs e)
        {
            if (DesignMode) { return; }
            this.DoubleBuffered = true;
            this.BorderStyle = BorderStyle.None;
            controlGraphics = Graphics.FromHwnd(Handle);
            initMemoryDC();
            
        }

        private void initMemoryDC()
        {
            renderTimer.Enabled = false;
            renderBuffer?.Dispose();
            memoryDC?.Dispose();
            memoryDC = new Bitmap(this.Width,this.Height);
            renderBuffer = Graphics.FromImage(memoryDC);
            renderBuffer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            renderBuffer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            renderTimer.Enabled = true;
        }

        private Bitmap memoryDC = null;
        private Graphics renderBuffer = null;
        private Graphics controlGraphics = null;

        private void Draw()
        {

            if(controlGraphics == null)
            {
                return;
            }
            if(renderBuffer == null)
            {
                return;
            }
            if(ParentForm.WindowState == FormWindowState.Minimized) { return; }
            DrawInternal(renderBuffer);
            controlGraphics.DrawImage(memoryDC, 0, 0);
        }

        

        Pen pCircle = new Pen(Brushes.White, 2.5f);
        Pen pHand = new Pen(Brushes.White, 1.8f);
        Pen pBorder = new Pen(Brushes.White, 1);
        Brush txtBrush = Brushes.LightGray;
        public string DisplayText { get; set; } = "";

        StringFormat centerStr = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        Rectangle clientRect = new Rectangle();
        void DrawInternal(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawLine(pBorder, 1, 0, Width - 2, 0);
            g.DrawLine(pBorder, 1, Height-1, Width - 2, Height-1);
            g.DrawLine(pBorder, 0, 1, 0, Height-2);
            g.DrawLine(pBorder, Width - 1, 1, Width - 1, Height-2);
            clientRect.Width = this.Width;
            clientRect.Height = this.Height;
            if (DisplayText != null)
            {
                g.DrawString(DisplayText, this.Font,txtBrush,clientRect, centerStr);
            }

            float rectSize = this.Width * 1.2f;
            float rectY = this.Height / 8f;
            float rectCenterX = this.Width / 2;
            float rectCenterY = rectSize / 2 + rectY;
            float rectX = rectCenterX - rectSize / 2;

            float handLength = rectSize / 2f * 0.98f;

            g.DrawArc(pCircle, rectX, rectY, rectSize, rectSize, 225, 90);

            float pointerAngle = -(float)Math.PI / 4f * 3f +  animedValue / 1 * (float)Math.PI /2 ;

            g.DrawLine(pHand, rectCenterX, rectCenterY, rectCenterX+(float)Math.Cos(pointerAngle) * handLength, rectCenterY+(float)Math.Sin(pointerAngle) * handLength);

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
                DrawInternal(e.Graphics);
            }
        }
        internal void Reset()
        {
            //linearDownValue = 0;
            //animedValue = 0;
            Value = 0;
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            linearDownValue -= 0.016f;
            if (linearDownValue < _value)
            {
                linearDownValue = _value;
            }
            animedValue = animedValue + (linearDownValue - animedValue) * smoothfactor;
            Draw();
        }
    }
}
