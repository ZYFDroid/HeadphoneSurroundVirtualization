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
    public partial class CtlBarSlider : UserControl
    {
        public CtlBarSlider()
        {
            InitializeComponent();
        }

        private bool dragging = false;
        private int dragX = 0;
        private void btnDragger_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragX = e.X;
            }
        }

        private void btnDragger_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                int newWidth = panWidth.Width;
                newWidth += e.X - dragX;
                if(newWidth < ThumbWidth) { newWidth = ThumbWidth; }
                if(newWidth > Width) { newWidth = Width; }
                panWidth.Width = newWidth;
                recomputeValue();
            }
        }

        private void btnDragger_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        private void CtlBarSlider_Click(object sender, EventArgs e)
        {
            Value += BigStep;
        }

        private void panWidth_Click(object sender, EventArgs e)
        {
            Value -= BigStep;
        }
        Pen linePen = new Pen(Brushes.White, 2);
        private void CtlBarSlider_Paint(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            e.Graphics.DrawLine(linePen,0,c.Height / 2,c.Width,c.Height/2);
        }

        private void CtlBarSlider_Load(object sender, EventArgs e)
        {
            btnDragger.MouseWheel += BtnDragger_MouseWheel;
            repositionThumb();
        }

        private void BtnDragger_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                Value += SmallStep;
            }
            else
            {
                Value -= SmallStep;
            }
        }


        public int SmallStep { get; set; } = 3;
        public int BigStep { get; set; } = 5;

        public string ThumbText { get => btnDragger.Text;set => btnDragger.Text = value; }

        private int _value = 0;

        private int _min = 0;

        private int _max = 100;

        public int Value { 
            get { return _value; }
            set { 
                _value = value;
                if(_value < _min)
                {
                    _value = _min;
                }
                if(_value > _max)
                {
                    _value = _max;
                }
                CallValueChange();
                repositionThumb();
            }
        }

        public int Min
        {
            get => _min;
            set
            {
                _min = value;
                if(_min >= _max)
                {
                    _max = _min + 1;
                }
                if (_value < _min)
                {
                    _value = _min;
                    CallValueChange();
                }
                if (_value > _max)
                {
                    _value = _max;
                    CallValueChange();
                }
                repositionThumb();
            }
        }

        public int Max
        {
            get => _max;
            set
            {
                _max = value;
                if(_max <= _min)
                {
                    _min = _max - 1;
                }
                if (_value < _min)
                {
                    _value = _min;
                    CallValueChange();
                }
                if (_value > _max)
                {
                    _value = _max;
                    CallValueChange();
                }
                repositionThumb();
            }
        }

        private void CallValueChange()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> ValueChanged;

        public int ThumbWidth
        {
            get { return btnDragger.Width; }
            set
            {
                int minWidth = Width * 3 / 4;
                if(value > minWidth) { value = minWidth; }
                btnDragger.Width = value;
                repositionThumb();
            }
        }

        private void repositionThumb()
        {
            int total = _max - _min;
            int progress = _value - _min;
            int availableSpace = Width - ThumbWidth;
            int paddingSpace = ThumbWidth;
            panWidth.Width = paddingSpace + (availableSpace * progress / total);
        }

        private void recomputeValue()
        {
            int availableSpace = Width - ThumbWidth;
            int progressSpace = panWidth.Width - ThumbWidth;
            _value = _min + (_max - _min) * progressSpace / availableSpace;
            CallValueChange();
        }
    }
}
