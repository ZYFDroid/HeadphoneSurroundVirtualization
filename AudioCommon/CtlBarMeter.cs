﻿using System;
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



        public float smoothfactor = 0.24f;
        public float linearDownRate = 0.012f;

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
            backgroundBuffer?.Dispose();
            backgroundDC?.Dispose();
            backgroundDC = new Bitmap(this.Width, this.Height);
            backgroundBuffer = Graphics.FromImage(backgroundDC);
            memoryDC = new Bitmap(this.Width,this.Height);
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
            g.DrawLine(pBorder, 1, 0, Width - 2, 0);
            g.DrawLine(pBorder, 1, Height - 1, Width - 2, Height - 1);
            g.DrawLine(pBorder, 0, 1, 0, Height - 2);
            g.DrawLine(pBorder, Width - 1, 1, Width - 1, Height - 2);
            clientRect.Width = this.Width;
            clientRect.Height = this.Height;
            if (DisplayText != null)
            {
                g.DrawString(DisplayText, this.Font, txtBrush, clientRect, centerStr);
            }

            float rectSize = this.Width * 1.2f;
            float rectY = this.Height / 8f;
            float rectCenterX = this.Width / 2;
            float rectX = rectCenterX - rectSize / 2;
            float rectCenterY = rectSize / 2 + rectY;

            g.DrawArc(pCircle, rectX, rectY, rectSize, rectSize, 225, 90);

            //g.FillEllipse(pCircle.Brush, rectCenterX - 2, rectCenterY - 2, 4, 4);
            //g.DrawEllipse(pCircle, rectCenterX - 2, rectCenterY - 2, 4, 4);

        }

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
        Pen pHand = new Pen(Brushes.White, 1.6f);
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
            g.DrawImage(backgroundDC, 0, 0);
            
            float rectSize = this.Width * 1.2f;
            float rectY = this.Height / 8f;
            float rectCenterX = this.Width / 2;
            float rectCenterY = rectSize / 2 + rectY;

            float handLength = rectSize / 2f * 0.98f;

            
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
        public void Reset()
        {
            //linearDownValue = 0;
            //animedValue = 0;
            Value = 0;
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            if(ParentForm.WindowState == FormWindowState.Minimized)
            {
                return;
            }
            linearDownValue -= linearDownRate;
            if (linearDownValue < _value)
            {
                linearDownValue = _value;
            }
            animedValue = animedValue + (linearDownValue - animedValue) * smoothfactor;
            Draw();
        }
    }
}
