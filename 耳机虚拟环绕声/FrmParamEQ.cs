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
    public partial class FrmParamEQ : Form
    {
        private List<PeakEQParam> peakEQParamList = null;
        public FrmParamEQ(List<PeakEQParam> data)
        {
            this.peakEQParamList = data;
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void FrmParamEQ_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private PeakeqPointer lastPointer = null;
        private void loadData()
        {
            ctlEqView.PeakEQParams = peakEQParamList;
            ctlEqView.Dock = DockStyle.None;
            ctlEqView.Size = tblChartContainer.Size;
            ctlEqView.Location = Point.Empty;
            tblChartContainer.Controls.SetChildIndex(ctlEqView, 0);
            ctlEqView.SendToBack();
            peakEQParamList.ForEach(p =>
            {
                PeakeqPointer ptrCtl = new PeakeqPointer(p, ctlEqView);
                tblChartContainer.Controls.Add(ptrCtl);
                tblChartContainer.Controls.SetChildIndex(ptrCtl,1);
                ptrCtl.Dragged += PtrCtl_Dragged;
                ptrCtl.BringToFront();
                ptrCtl.initPosition();
            });
        }

        private bool numIsFromUser = true;
        private void PtrCtl_Dragged(object sender, EventArgs e)
        {
            lastPointer = sender as PeakeqPointer;
            numIsFromUser = false;
            numFC.Value = (decimal)lastPointer.peakEQParam.centerFrequent;
            numDBGain.Value = (decimal)lastPointer.peakEQParam.gain;
            numFQ.Value = (decimal)lastPointer.peakEQParam.Q;
            numIsFromUser = true;
        }

        private void numFC_ValueChanged(object sender, EventArgs e)
        {
            if (!numIsFromUser) {
                return;
            }
            if(lastPointer != null)
            {
                lastPointer.peakEQParam.centerFrequent =(float) numFC.Value;
                lastPointer.peakEQParam.Q = (float)numFQ.Value;
                lastPointer.peakEQParam.gain = (float)numDBGain.Value;
                lastPointer.initPosition();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lastPointer != null)
            {
                peakEQParamList.Remove(lastPointer.peakEQParam);
                tblChartContainer.Controls.Remove(lastPointer);
                lastPointer.Dispose();
                lastPointer = null;
            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(peakEQParamList.Count > 30)
            {
                MessageBox.Show(this,"数量超过上限（30个）");
                return;
            }
            ctlEqView.SendToBack();
            PeakEQParam p = null;
            if (lastPointer == null)
            {
                p =  new PeakEQParam() { centerFrequent = (float)numFC.Value, gain = (float)numDBGain.Value, Q = (float)numFQ.Value };
            }
            else
            {
                p = new PeakEQParam() { centerFrequent = 1000, gain = 0, Q = 1 };
            }
            peakEQParamList.Add(p);
            PeakeqPointer ptrCtl = new PeakeqPointer(p, ctlEqView);
            tblChartContainer.Controls.Add(ptrCtl);
            tblChartContainer.Controls.SetChildIndex(ptrCtl, 1);
            ptrCtl.Dragged += PtrCtl_Dragged;
            ptrCtl.initPosition();
            ptrCtl.BringToFront();
            lastPointer = ptrCtl;

        }
        public event EventHandler RequestUpdate;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RequestUpdate?.Invoke(this, EventArgs.Empty);
        }
    }


    internal class PeakeqPointer : UserControl
    {
        public PeakEQParam peakEQParam;
        private CtlEQView eqView;
        public PeakeqPointer(PeakEQParam peakEQParam, CtlEQView eqView)
        {
            this.peakEQParam = peakEQParam;
            this.eqView = eqView;
            Size = new Size(8, 8);
            this.Cursor = Cursors.NoMove2D;
        }

        public void initPosition()
        {
            this.Left = (int)(eqView.Freq2Log((int)peakEQParam.centerFrequent) * (float)eqView.Width)-4;
            this.Top = (int)((float)eqView.Height / 2f - (peakEQParam.gain / eqView.DisplayRange) * (float)eqView.Height / 2f)-4;
        }

        private bool isDragging = false;
        private int dragX = 0, dragY = 0;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragX = e.X;
                dragY = e.Y;
                Dragged?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                int newTop = this.Top + (e.Y - dragY);
                int newLeft = this.Left + (e.X - dragX);
                if (newTop < -3)
                {
                    newTop = -3;
                }
                if (newLeft < -3)
                {
                    newLeft = -3;
                }
                if (newTop > eqView.Height - 4)
                {
                    newTop = eqView.Height - 4;
                }
                if (newLeft > eqView.Width - 4)
                {
                    newLeft = eqView.Width - 4;
                }
                this.Top = newTop;
                this.Left = newLeft;

                peakEQParam.centerFrequent = eqView.Log2Freq((this.Left + 4f) / (float)eqView.Width);
                peakEQParam.gain = eqView.DisplayRange * (((float)eqView.Height / 2f - ((float)this.Top + 4f)) / ((float)eqView.Height / 2f));

                if(peakEQParam.centerFrequent < 20) { peakEQParam.centerFrequent = 20;}
                if(peakEQParam.centerFrequent > 20000) { peakEQParam.centerFrequent = 20000; }
                if(peakEQParam.gain < -15) { peakEQParam.gain = -15;}
                if(peakEQParam.gain > 15) { peakEQParam.gain = 15; }


                Dragged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler Dragged;
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
            Dragged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.Red);
        }

    }
}
