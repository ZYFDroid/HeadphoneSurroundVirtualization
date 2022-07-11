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
    public partial class FrmParamEQ : Form
    {
        private List<EqualizerAPO.FilterNode> peakEQParamList = null;
        public FrmParamEQ(List<EqualizerAPO.FilterNode> data)
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
            numFC.Value = (decimal)lastPointer.peakEQParam.freq;
            numDBGain.Value = (decimal)lastPointer.peakEQParam.dbGain;
            numIsFromUser = true;
        }

        private void numFC_ValueChanged(object sender, EventArgs e)
        {
            if (!numIsFromUser) {
                return;
            }
            if(lastPointer != null)
            {
                lastPointer.peakEQParam.freq =(float) numFC.Value;
                lastPointer.peakEQParam.dbGain = (float)numDBGain.Value;
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
            EqualizerAPO.FilterNode p = null;
            if (lastPointer == null)
            {
                p =  new EqualizerAPO.FilterNode() { freq = (float)numFC.Value, dbGain = (float)numDBGain.Value };
            }
            else
            {
                p = new EqualizerAPO.FilterNode() { freq = 1000, dbGain = 0 };
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
        public EqualizerAPO.FilterNode peakEQParam;
        private CtlEQView eqView;
        public PeakeqPointer(EqualizerAPO.FilterNode peakEQParam, CtlEQView eqView)
        {
            this.peakEQParam = peakEQParam;
            this.eqView = eqView;
            Size = new Size(8, 8);
            this.Cursor = Cursors.NoMove2D;
        }

        public void initPosition()
        {
            this.Left = (int)(CtlEQView.Freq2Log((int)peakEQParam.freq) * (float)eqView.Width)-4;
            this.Top = (int)((float)eqView.Height / 2f - (peakEQParam.dbGain / eqView.DisplayRange) * (float)eqView.Height / 2f)-4;
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

                peakEQParam.freq = CtlEQView.Log2Freq((this.Left + 4f) / (float)eqView.Width);
                peakEQParam.dbGain = eqView.DisplayRange * (((float)eqView.Height / 2f - ((float)this.Top + 4f)) / ((float)eqView.Height / 2f));

                if(peakEQParam.freq < 20) { peakEQParam.freq = 20;}
                if(peakEQParam.freq > 20000) { peakEQParam.freq = 20000; }
                if(peakEQParam.dbGain < -15) { peakEQParam.dbGain = -15;}
                if(peakEQParam.dbGain > 15) { peakEQParam.dbGain = 15; }


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
