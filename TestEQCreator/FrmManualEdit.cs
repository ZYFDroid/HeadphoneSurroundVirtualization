using AudioCommon;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toaster;

namespace 耳机虚拟环绕声
{
    public partial class FrmManualEdit : Form
    {
        private List<EqualizerAPO.FilterNode> peakEQParamList = null;
        private static string TempDataPath = null;
        public FrmManualEdit()
        {
            TempDataPath = Path.Combine(Environment.ExpandEnvironmentVariables("%TEMP%"), "com.zyfdroid.hesuvi", "tempconfig.json");
            
            do
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(TempDataPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(TempDataPath));
                    }
                    if (File.Exists(TempDataPath))
                    {
                        peakEQParamList = JsonConvert.Deserialize<List<EqualizerAPO.FilterNode>>(File.ReadAllText(TempDataPath));
                        break;
                    }
                }
                catch (Exception)
                {

                }

                this.peakEQParamList = new List<EqualizerAPO.FilterNode>();


            } while (false);
            
            InitializeComponent();
            
            this.FormClosing += FrmManualEdit_FormClosing;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void FrmManualEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(TempDataPath, JsonConvert.Serialize(peakEQParamList));
            wasapiOut?.Stop();
            wasapiOut?.Dispose();
        }

        Toast Toast;
        private void FrmParamEQ_Load(object sender, EventArgs e)
        {
            Toast = new Toaster.Toast(this, btnPlayPause.Font);
            loadData();
            frequentProvider = new FrequentProvider(48000);
            frequentProvider.Volume = MathHelper.db2linear(-30);
            frequentProvider.Frequency = 500;
            wasapiOut = new WasapiOut();
            wasapiOut.Init(frequentProvider);
            ctlBarSlider1.Value = (int)Math.Round(CtlEQView.Freq2Log(500) * 10000);
        }

        FrequentProvider frequentProvider;
        WasapiOut wasapiOut;



        private int selectedFrequent = 500;

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
            frequentProvider.Volume = MathHelper.db2linear(ctlEqView.GainAt(selectedFrequent) - 30f);
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
            if(peakEQParamList.Count > 114)
            {

                Toast.ShowMessage("数量超过上限 (100个)");
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

        private void ctlEqView_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panelOuterContainer_SizeChanged(object sender, EventArgs e)
        {
            ctlEqView.Size = tblChartContainer.Size;
            foreach (var item in tblChartContainer.Controls)
            {
                if(item is PeakeqPointer)
                {

                    (item as PeakeqPointer)?.initPosition();
                }
            }
        }

        private void panelOuterContainer_Resize(object sender, EventArgs e)
        {
            
        }

        private void ctlEqView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                lastPointer = null;
                double freq = CtlEQView.Log2Freq((float)e.X / (float)ctlEqView.Width);
                double gain = ctlEqView.DisplayRange * (((float)ctlEqView.Height / 2f - (float)e.Y) / ((float)ctlEqView.Height / 2f));
                numFC.Value = (decimal)freq;
                numDBGain.Value = (decimal)gain;
                btnNew.PerformClick();
            }
        }

        Pen currentFreqIndicator = Pens.Red;
        private void ctlEqView_PostRender(object sender, Graphics e)
        {
            float fLog = CtlEQView.Freq2Log(selectedFrequent);
            int pos = (int)Math.Round(fLog * (float)ctlEqView.Width);
            e.DrawLine(currentFreqIndicator, pos, 0, pos, ctlEqView.Height);


        }
        bool draggingChart = false;

        private int draggingChartBeginY = 0;
        private void ctlEqView_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingChart)
            {
                float deltaY = e.Y - draggingChartBeginY;
                draggingChartBeginY = e.Y;
                float deltaDB = -ctlEqView.DisplayRange * 2 * (deltaY / ctlEqView.Height);
                if(ctlEqView.PeakEQParams.Count == 0) { return; }
                if(deltaDB > 0)
                {
                    float maxDB = ctlEqView.PeakEQParams.Max(p => p.dbGain);
                    if(maxDB + deltaDB > ctlEqView.DisplayRange)
                    {
                        deltaDB = ctlEqView.DisplayRange - maxDB;
                    }
                }
                if (deltaDB < 0)
                {
                    float minDB = ctlEqView.PeakEQParams.Min(p => p.dbGain);
                    if (minDB + deltaDB < -ctlEqView.DisplayRange)
                    {
                        deltaDB = (-ctlEqView.DisplayRange) - minDB ;
                    }
                }
                ctlEqView.PeakEQParams.ForEach(p => p.dbGain += deltaDB);
                
            }
        }

        private void ctlEqView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                draggingChart = false;
                foreach (var item in tblChartContainer.Controls)
                {
                    if(item is PeakeqPointer)
                    {
                        var pointer = item as PeakeqPointer;
                        pointer.initPosition();
                    }
                }
            }
        }

        private void ctlEqView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                draggingChart = true;
                draggingChartBeginY = e.Y;
            }
        }

        private void mnuDist30_Click(object sender, EventArgs e)
        {
            if(ctlEqView.PeakEQParams.Count > 0)
            {
                Toast.ShowMessage("请清空后再操作");
                return;
            }
            for(float f = 0;f < 31; f++)
            {
                float x = f / 30;
                if(x <= 0) { x = 0.001f; }
                if(x >= 1) { x = 0.999f; }
                float freq = CtlEQView.Log2Freq(x);
                peakEQParamList.Add(new EqualizerAPO.FilterNode() { dbGain = 0,freq = freq });
            }
            loadData();
        }

        private void mnuInvert_Click(object sender, EventArgs e)
        {
            foreach (var item in peakEQParamList)
            {
                item.dbGain = -item.dbGain;
            }
            foreach (var item in tblChartContainer.Controls)
            {
                if (item is PeakeqPointer)
                {
                    var pointer = item as PeakeqPointer;
                    pointer.initPosition();
                }
            }
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否清空？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<Control> controlsToRemove = new List<Control>();
                foreach (var item in tblChartContainer.Controls)
                {
                    if (item is PeakeqPointer)
                    {
                        controlsToRemove.Add(item as Control);
                    }
                }
                controlsToRemove.ForEach(c => tblChartContainer.Controls.Remove(c));
                peakEQParamList.Clear();
            }
        }

        private void ctlBarSlider1_ValueChanged(object sender, EventArgs e)
        {
            int newFreq = CtlEQView.Log2Freq(((float)ctlBarSlider1.Value) / 10000f);
            if (newFreq < 32) { newFreq = 32; }
            if (newFreq > 16384) { newFreq = 16384; }
            ctlBarSlider1.ThumbText = newFreq + " Hz";
            this.selectedFrequent = newFreq;
            FreqChanged();
        }

        void FreqChanged()
        {
            frequentProvider.Volume = MathHelper.db2linear(ctlEqView.GainAt(selectedFrequent) - 30f);
            frequentProvider.Frequency = selectedFrequent;
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if(wasapiOut.PlaybackState != PlaybackState.Playing)
            {
                wasapiOut.Play();
            }
            else
            {
                wasapiOut.Pause();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                string title = System.IO.Path.GetFileNameWithoutExtension(fileName);
                AudioEnchancementParameters data = new AudioEnchancementParameters();
                data.DisplayName  = title;
                data.guid = Guid.NewGuid().ToString();
                data.peakEQParams = this.peakEQParamList;
                System.IO.File.WriteAllText(fileName,JsonConvert.Serialize(data));
                Toast.ShowMessage("保存成功");
            }
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
        [DllImport("user32.dll")]
        private static extern Int16 GetKeyState(Keys nVirtKey);

        private bool IsKeyPressed(Keys k)
        {
            short v = GetKeyState(k);
            return v != 0;
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

                if (IsKeyPressed(Keys.ShiftKey))
                {
                    newLeft = this.Left;
                }
                

                this.Top = newTop;
                this.Left = newLeft;

                peakEQParam.freq = CtlEQView.Log2Freq((this.Left + 4f) / (float)eqView.Width);
                peakEQParam.dbGain = eqView.DisplayRange * (((float)eqView.Height / 2f - ((float)this.Top + 4f)) / ((float)eqView.Height / 2f));

                if(peakEQParam.freq < 20) { peakEQParam.freq = 20;}
                if(peakEQParam.freq > 20000) { peakEQParam.freq = 20000; }
                if(peakEQParam.dbGain < -eqView.DisplayRange) { peakEQParam.dbGain = -eqView.DisplayRange; }
                if(peakEQParam.dbGain > eqView.DisplayRange) { peakEQParam.dbGain = eqView.DisplayRange; }


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
