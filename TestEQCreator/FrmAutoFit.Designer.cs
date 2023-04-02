namespace TestEQCreator
{
    partial class FrmAutoFit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tblMain = new Creek.UI.MultiPanel.MultiPaneControl();
            this.page1Prequest = new Creek.UI.MultiPanel.MultiPanePage();
            this.btnPage1Next = new System.Windows.Forms.Button();
            this.numInitialVolume = new 耳机虚拟环绕声.CtlBarSlider();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.page2Minium = new Creek.UI.MultiPanel.MultiPanePage();
            this.btnPage2Back = new System.Windows.Forms.Button();
            this.btnPage2Next = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numMininumSound = new 耳机虚拟环绕声.CtlBarSlider();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.page3ThinAdjust = new Creek.UI.MultiPanel.MultiPanePage();
            this.btnPage3Back = new System.Windows.Forms.Button();
            this.lblFreqOutOfRangeHint = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNextFreq = new System.Windows.Forms.Button();
            this.btnPrevFreq = new System.Windows.Forms.Button();
            this.btnPage3Next = new System.Windows.Forms.Button();
            this.numFreqAdjust = new 耳机虚拟环绕声.CtlBarSlider();
            this.ctlEqView = new 耳机虚拟环绕声.CtlEQView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentFreq = new System.Windows.Forms.Label();
            this.lblFreqIndex = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.page4ExportData = new Creek.UI.MultiPanel.MultiPanePage();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveAsTarget = new System.Windows.Forms.Button();
            this.btnApplyTarget = new System.Windows.Forms.Button();
            this.btnChangeTarget = new System.Windows.Forms.Button();
            this.btnPage4Back = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblTargetInfo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.page0Begin = new Creek.UI.MultiPanel.MultiPanePage();
            this.btnBegin = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dlgHsvtOpener = new System.Windows.Forms.OpenFileDialog();
            this.dlgHsvtSaver = new System.Windows.Forms.SaveFileDialog();
            this.dlgHsvxSaver = new System.Windows.Forms.SaveFileDialog();
            this.tblMain.SuspendLayout();
            this.page1Prequest.SuspendLayout();
            this.page2Minium.SuspendLayout();
            this.page3ThinAdjust.SuspendLayout();
            this.page4ExportData.SuspendLayout();
            this.page0Begin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.Color.Transparent;
            this.tblMain.Controls.Add(this.page1Prequest);
            this.tblMain.Controls.Add(this.page2Minium);
            this.tblMain.Controls.Add(this.page3ThinAdjust);
            this.tblMain.Controls.Add(this.page4ExportData);
            this.tblMain.Controls.Add(this.page0Begin);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(16, 16);
            this.tblMain.Name = "tblMain";
            this.tblMain.SelectedPage = this.page0Begin;
            this.tblMain.Size = new System.Drawing.Size(841, 549);
            this.tblMain.TabIndex = 0;
            this.tblMain.Text = "multiPaneControl1";
            // 
            // page1Prequest
            // 
            this.page1Prequest.Controls.Add(this.btnPage1Next);
            this.page1Prequest.Controls.Add(this.numInitialVolume);
            this.page1Prequest.Controls.Add(this.label9);
            this.page1Prequest.Controls.Add(this.label2);
            this.page1Prequest.Controls.Add(this.label1);
            this.page1Prequest.Name = "page1Prequest";
            this.page1Prequest.Size = new System.Drawing.Size(841, 549);
            this.page1Prequest.TabIndex = 0;
            // 
            // btnPage1Next
            // 
            this.btnPage1Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage1Next.FlatAppearance.BorderSize = 2;
            this.btnPage1Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage1Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPage1Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1Next.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPage1Next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPage1Next.Location = new System.Drawing.Point(724, 514);
            this.btnPage1Next.Name = "btnPage1Next";
            this.btnPage1Next.Size = new System.Drawing.Size(117, 32);
            this.btnPage1Next.TabIndex = 2;
            this.btnPage1Next.Text = "下一步";
            this.btnPage1Next.UseVisualStyleBackColor = true;
            // 
            // numInitialVolume
            // 
            this.numInitialVolume.BackColor = System.Drawing.Color.Black;
            this.numInitialVolume.BigStep = 5;
            this.numInitialVolume.Location = new System.Drawing.Point(36, 269);
            this.numInitialVolume.Max = 100;
            this.numInitialVolume.Min = 0;
            this.numInitialVolume.Name = "numInitialVolume";
            this.numInitialVolume.Size = new System.Drawing.Size(768, 30);
            this.numInitialVolume.SmallStep = 3;
            this.numInitialVolume.TabIndex = 16;
            this.numInitialVolume.ThumbText = "0.0 dB";
            this.numInitialVolume.ThumbWidth = 65;
            this.numInitialVolume.Value = 0;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(32, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(772, 87);
            this.label9.TabIndex = 15;
            this.label9.Text = "缓慢向右拖动上面的滑块，以及调整系统音量，直到感觉听到的声音大小正好";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(839, 1);
            this.label2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "第一步：调整到合适音量";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // page2Minium
            // 
            this.page2Minium.Controls.Add(this.btnPage2Back);
            this.page2Minium.Controls.Add(this.btnPage2Next);
            this.page2Minium.Controls.Add(this.label3);
            this.page2Minium.Controls.Add(this.numMininumSound);
            this.page2Minium.Controls.Add(this.label5);
            this.page2Minium.Controls.Add(this.label4);
            this.page2Minium.Name = "page2Minium";
            this.page2Minium.Size = new System.Drawing.Size(841, 549);
            this.page2Minium.TabIndex = 1;
            // 
            // btnPage2Back
            // 
            this.btnPage2Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage2Back.FlatAppearance.BorderSize = 2;
            this.btnPage2Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage2Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPage2Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2Back.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPage2Back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPage2Back.Location = new System.Drawing.Point(601, 514);
            this.btnPage2Back.Name = "btnPage2Back";
            this.btnPage2Back.Size = new System.Drawing.Size(117, 32);
            this.btnPage2Back.TabIndex = 17;
            this.btnPage2Back.Text = "回退";
            this.btnPage2Back.UseVisualStyleBackColor = true;
            // 
            // btnPage2Next
            // 
            this.btnPage2Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage2Next.FlatAppearance.BorderSize = 2;
            this.btnPage2Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage2Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPage2Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2Next.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPage2Next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPage2Next.Location = new System.Drawing.Point(724, 514);
            this.btnPage2Next.Name = "btnPage2Next";
            this.btnPage2Next.Size = new System.Drawing.Size(117, 32);
            this.btnPage2Next.TabIndex = 17;
            this.btnPage2Next.Text = "下一步";
            this.btnPage2Next.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(839, 1);
            this.label3.TabIndex = 9;
            // 
            // numMininumSound
            // 
            this.numMininumSound.BackColor = System.Drawing.Color.Black;
            this.numMininumSound.BigStep = 5;
            this.numMininumSound.Location = new System.Drawing.Point(36, 269);
            this.numMininumSound.Max = 100;
            this.numMininumSound.Min = 0;
            this.numMininumSound.Name = "numMininumSound";
            this.numMininumSound.Size = new System.Drawing.Size(768, 30);
            this.numMininumSound.SmallStep = 3;
            this.numMininumSound.TabIndex = 19;
            this.numMininumSound.ThumbText = "0.0 dB";
            this.numMininumSound.ThumbWidth = 65;
            this.numMininumSound.Value = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(32, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(772, 87);
            this.label5.TabIndex = 18;
            this.label5.Text = "接下来会播放一个嘟嘟声。缓慢向右拖动上面的滑块，直到刚好能听到嘟嘟声音";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(609, 55);
            this.label4.TabIndex = 8;
            this.label4.Text = "第二步：你能听到的最小声音";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // page3ThinAdjust
            // 
            this.page3ThinAdjust.Controls.Add(this.btnPage3Back);
            this.page3ThinAdjust.Controls.Add(this.lblFreqOutOfRangeHint);
            this.page3ThinAdjust.Controls.Add(this.label8);
            this.page3ThinAdjust.Controls.Add(this.btnNextFreq);
            this.page3ThinAdjust.Controls.Add(this.btnPrevFreq);
            this.page3ThinAdjust.Controls.Add(this.btnPage3Next);
            this.page3ThinAdjust.Controls.Add(this.numFreqAdjust);
            this.page3ThinAdjust.Controls.Add(this.ctlEqView);
            this.page3ThinAdjust.Controls.Add(this.label6);
            this.page3ThinAdjust.Controls.Add(this.lblCurrentFreq);
            this.page3ThinAdjust.Controls.Add(this.lblFreqIndex);
            this.page3ThinAdjust.Controls.Add(this.label10);
            this.page3ThinAdjust.Controls.Add(this.label7);
            this.page3ThinAdjust.Name = "page3ThinAdjust";
            this.page3ThinAdjust.Size = new System.Drawing.Size(841, 549);
            this.page3ThinAdjust.TabIndex = 2;
            // 
            // btnPage3Back
            // 
            this.btnPage3Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage3Back.FlatAppearance.BorderSize = 2;
            this.btnPage3Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage3Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPage3Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3Back.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPage3Back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPage3Back.Location = new System.Drawing.Point(601, 514);
            this.btnPage3Back.Name = "btnPage3Back";
            this.btnPage3Back.Size = new System.Drawing.Size(117, 32);
            this.btnPage3Back.TabIndex = 18;
            this.btnPage3Back.Text = "回退";
            this.btnPage3Back.UseVisualStyleBackColor = true;
            // 
            // lblFreqOutOfRangeHint
            // 
            this.lblFreqOutOfRangeHint.BackColor = System.Drawing.Color.Transparent;
            this.lblFreqOutOfRangeHint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFreqOutOfRangeHint.ForeColor = System.Drawing.Color.DarkGray;
            this.lblFreqOutOfRangeHint.Location = new System.Drawing.Point(640, 239);
            this.lblFreqOutOfRangeHint.Name = "lblFreqOutOfRangeHint";
            this.lblFreqOutOfRangeHint.Size = new System.Drawing.Size(203, 101);
            this.lblFreqOutOfRangeHint.TabIndex = 19;
            this.lblFreqOutOfRangeHint.Text = "部分人可能无法听到此频率。若滑块拉到尽头依然听不到声音，说明已经发生听力下降，或者耳机质量过差。";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(637, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 82);
            this.label8.TabIndex = 19;
            this.label8.Text = "微调滑块，直到在每个频率上都能刚好能同时听到两个不同的嘟嘟声";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnNextFreq
            // 
            this.btnNextFreq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextFreq.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNextFreq.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnNextFreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextFreq.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnNextFreq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNextFreq.Location = new System.Drawing.Point(739, 204);
            this.btnNextFreq.Name = "btnNextFreq";
            this.btnNextFreq.Size = new System.Drawing.Size(94, 32);
            this.btnNextFreq.TabIndex = 19;
            this.btnNextFreq.Text = "下一个";
            this.btnNextFreq.UseVisualStyleBackColor = true;
            // 
            // btnPrevFreq
            // 
            this.btnPrevFreq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevFreq.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrevFreq.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPrevFreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevFreq.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPrevFreq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrevFreq.Location = new System.Drawing.Point(639, 204);
            this.btnPrevFreq.Name = "btnPrevFreq";
            this.btnPrevFreq.Size = new System.Drawing.Size(94, 32);
            this.btnPrevFreq.TabIndex = 19;
            this.btnPrevFreq.Text = "上一个";
            this.btnPrevFreq.UseVisualStyleBackColor = true;
            // 
            // btnPage3Next
            // 
            this.btnPage3Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage3Next.FlatAppearance.BorderSize = 2;
            this.btnPage3Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage3Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPage3Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3Next.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPage3Next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPage3Next.Location = new System.Drawing.Point(724, 514);
            this.btnPage3Next.Name = "btnPage3Next";
            this.btnPage3Next.Size = new System.Drawing.Size(117, 32);
            this.btnPage3Next.TabIndex = 19;
            this.btnPage3Next.Text = "下一步";
            this.btnPage3Next.UseVisualStyleBackColor = true;
            // 
            // numFreqAdjust
            // 
            this.numFreqAdjust.BackColor = System.Drawing.Color.Black;
            this.numFreqAdjust.BigStep = 5;
            this.numFreqAdjust.Location = new System.Drawing.Point(5, 473);
            this.numFreqAdjust.Max = 100;
            this.numFreqAdjust.Min = 0;
            this.numFreqAdjust.Name = "numFreqAdjust";
            this.numFreqAdjust.Size = new System.Drawing.Size(833, 30);
            this.numFreqAdjust.SmallStep = 3;
            this.numFreqAdjust.TabIndex = 13;
            this.numFreqAdjust.ThumbText = "0.0 dB";
            this.numFreqAdjust.ThumbWidth = 65;
            this.numFreqAdjust.Value = 0;
            // 
            // ctlEqView
            // 
            this.ctlEqView.Location = new System.Drawing.Point(5, 69);
            this.ctlEqView.Name = "ctlEqView";
            this.ctlEqView.Size = new System.Drawing.Size(624, 398);
            this.ctlEqView.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(839, 1);
            this.label6.TabIndex = 11;
            // 
            // lblCurrentFreq
            // 
            this.lblCurrentFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentFreq.Font = new System.Drawing.Font("Courier New", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFreq.ForeColor = System.Drawing.Color.White;
            this.lblCurrentFreq.Location = new System.Drawing.Point(639, 107);
            this.lblCurrentFreq.Name = "lblCurrentFreq";
            this.lblCurrentFreq.Size = new System.Drawing.Size(194, 55);
            this.lblCurrentFreq.TabIndex = 10;
            this.lblCurrentFreq.Text = "500 Hz";
            this.lblCurrentFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqIndex
            // 
            this.lblFreqIndex.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFreqIndex.ForeColor = System.Drawing.Color.White;
            this.lblFreqIndex.Location = new System.Drawing.Point(639, 170);
            this.lblFreqIndex.Name = "lblFreqIndex";
            this.lblFreqIndex.Size = new System.Drawing.Size(169, 31);
            this.lblFreqIndex.TabIndex = 10;
            this.lblFreqIndex.Text = "第 1/40 个";
            this.lblFreqIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(639, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 31);
            this.label10.TabIndex = 10;
            this.label10.Text = "当前频率";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(609, 55);
            this.label7.TabIndex = 10;
            this.label7.Text = "第三步：频率响应调整";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // page4ExportData
            // 
            this.page4ExportData.Controls.Add(this.label12);
            this.page4ExportData.Controls.Add(this.btnSaveAsTarget);
            this.page4ExportData.Controls.Add(this.btnApplyTarget);
            this.page4ExportData.Controls.Add(this.btnChangeTarget);
            this.page4ExportData.Controls.Add(this.btnPage4Back);
            this.page4ExportData.Controls.Add(this.btnFinish);
            this.page4ExportData.Controls.Add(this.lblTargetInfo);
            this.page4ExportData.Controls.Add(this.label11);
            this.page4ExportData.Controls.Add(this.label14);
            this.page4ExportData.Controls.Add(this.label15);
            this.page4ExportData.Name = "page4ExportData";
            this.page4ExportData.Size = new System.Drawing.Size(841, 549);
            this.page4ExportData.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(245, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(347, 103);
            this.label12.TabIndex = 20;
            this.label12.Text = "调音完成，现在你可以生成调音配置文件了\r\n你也可以将本次调音另存为调音目标，并使用此目标将其它耳机调成这个耳机的风格";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveAsTarget
            // 
            this.btnSaveAsTarget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAsTarget.FlatAppearance.BorderSize = 0;
            this.btnSaveAsTarget.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveAsTarget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSaveAsTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsTarget.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveAsTarget.ForeColor = System.Drawing.Color.DarkGray;
            this.btnSaveAsTarget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveAsTarget.Location = new System.Drawing.Point(380, 434);
            this.btnSaveAsTarget.Name = "btnSaveAsTarget";
            this.btnSaveAsTarget.Size = new System.Drawing.Size(212, 29);
            this.btnSaveAsTarget.TabIndex = 20;
            this.btnSaveAsTarget.Text = "保存为目标文件";
            this.btnSaveAsTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveAsTarget.UseVisualStyleBackColor = true;
            // 
            // btnApplyTarget
            // 
            this.btnApplyTarget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyTarget.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApplyTarget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnApplyTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyTarget.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnApplyTarget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApplyTarget.Location = new System.Drawing.Point(245, 375);
            this.btnApplyTarget.Name = "btnApplyTarget";
            this.btnApplyTarget.Size = new System.Drawing.Size(347, 53);
            this.btnApplyTarget.TabIndex = 20;
            this.btnApplyTarget.Text = "生成调音配置文件";
            this.btnApplyTarget.UseVisualStyleBackColor = true;
            // 
            // btnChangeTarget
            // 
            this.btnChangeTarget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeTarget.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChangeTarget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnChangeTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeTarget.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnChangeTarget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeTarget.Location = new System.Drawing.Point(419, 136);
            this.btnChangeTarget.Name = "btnChangeTarget";
            this.btnChangeTarget.Size = new System.Drawing.Size(173, 32);
            this.btnChangeTarget.TabIndex = 20;
            this.btnChangeTarget.Text = "使用其它配置文件";
            this.btnChangeTarget.UseVisualStyleBackColor = true;
            // 
            // btnPage4Back
            // 
            this.btnPage4Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage4Back.FlatAppearance.BorderSize = 2;
            this.btnPage4Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage4Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPage4Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage4Back.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPage4Back.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPage4Back.Location = new System.Drawing.Point(601, 514);
            this.btnPage4Back.Name = "btnPage4Back";
            this.btnPage4Back.Size = new System.Drawing.Size(117, 32);
            this.btnPage4Back.TabIndex = 20;
            this.btnPage4Back.Text = "回退";
            this.btnPage4Back.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.FlatAppearance.BorderSize = 2;
            this.btnFinish.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFinish.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnFinish.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFinish.Location = new System.Drawing.Point(724, 514);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(117, 32);
            this.btnFinish.TabIndex = 21;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // lblTargetInfo
            // 
            this.lblTargetInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetInfo.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTargetInfo.ForeColor = System.Drawing.Color.White;
            this.lblTargetInfo.Location = new System.Drawing.Point(245, 171);
            this.lblTargetInfo.Name = "lblTargetInfo";
            this.lblTargetInfo.Size = new System.Drawing.Size(348, 98);
            this.lblTargetInfo.TabIndex = 11;
            this.lblTargetInfo.Text = "配置文件：XXXX\r\n调音目标：XXXX\r\n录制麦克风：XXXX";
            this.lblTargetInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(244, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 31);
            this.label11.TabIndex = 11;
            this.label11.Text = "当前目标文件：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(839, 1);
            this.label14.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(609, 55);
            this.label15.TabIndex = 12;
            this.label15.Text = "第四步：导出配置文件";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // page0Begin
            // 
            this.page0Begin.Controls.Add(this.btnBegin);
            this.page0Begin.Controls.Add(this.label17);
            this.page0Begin.Controls.Add(this.label16);
            this.page0Begin.Name = "page0Begin";
            this.page0Begin.Size = new System.Drawing.Size(841, 549);
            this.page0Begin.TabIndex = 4;
            // 
            // btnBegin
            // 
            this.btnBegin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBegin.FlatAppearance.BorderSize = 2;
            this.btnBegin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBegin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBegin.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBegin.Location = new System.Drawing.Point(300, 369);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(243, 82);
            this.btnBegin.TabIndex = 3;
            this.btnBegin.Text = "开 始";
            this.btnBegin.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(7, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(831, 205);
            this.label17.TabIndex = 5;
            this.label17.Text = "开始调音前，请注意\r\n\r\n● 关闭耳机虚拟环绕声　　\r\n● 找到一个相对安静的地方\r\n● 正确佩戴耳机　　　　　\r\n（调音预计会花费10分钟）";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(3, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(835, 76);
            this.label16.TabIndex = 5;
            this.label16.Text = "目标调音法";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(425, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "// 开发者提示：在页面空白处右键选择 Switch Pages... 可以切换到其它页面";
            this.label18.Visible = false;
            // 
            // dlgHsvtOpener
            // 
            this.dlgHsvtOpener.Filter = "HSVT 调音目标|*.hsvt";
            // 
            // dlgHsvtSaver
            // 
            this.dlgHsvtSaver.Filter = "HSVT 调音目标|*.hsvt";
            // 
            // dlgHsvxSaver
            // 
            this.dlgHsvxSaver.Filter = "调音文件 |*.hsvx";
            // 
            // FrmAutoFit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(873, 581);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tblMain);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAutoFit";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "目标调音";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblMain.ResumeLayout(false);
            this.page1Prequest.ResumeLayout(false);
            this.page2Minium.ResumeLayout(false);
            this.page3ThinAdjust.ResumeLayout(false);
            this.page4ExportData.ResumeLayout(false);
            this.page0Begin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Creek.UI.MultiPanel.MultiPaneControl tblMain;
        private Creek.UI.MultiPanel.MultiPanePage page1Prequest;
        private Creek.UI.MultiPanel.MultiPanePage page2Minium;
        private Creek.UI.MultiPanel.MultiPanePage page3ThinAdjust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private 耳机虚拟环绕声.CtlBarSlider numInitialVolume;
        private System.Windows.Forms.Label label9;
        private Creek.UI.MultiPanel.MultiPanePage page4ExportData;
        private System.Windows.Forms.Button btnPage1Next;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPage2Next;
        private 耳机虚拟环绕声.CtlBarSlider numMininumSound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private 耳机虚拟环绕声.CtlEQView ctlEqView;
        private 耳机虚拟环绕声.CtlBarSlider numFreqAdjust;
        private System.Windows.Forms.Button btnPage2Back;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPage3Back;
        private System.Windows.Forms.Button btnPage3Next;
        private System.Windows.Forms.Button btnNextFreq;
        private System.Windows.Forms.Button btnPrevFreq;
        private System.Windows.Forms.Label lblCurrentFreq;
        private System.Windows.Forms.Label lblFreqIndex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFreqOutOfRangeHint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Creek.UI.MultiPanel.MultiPanePage page0Begin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblTargetInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnChangeTarget;
        private System.Windows.Forms.Button btnPage4Back;
        private System.Windows.Forms.Button btnSaveAsTarget;
        private System.Windows.Forms.Button btnApplyTarget;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.OpenFileDialog dlgHsvtOpener;
        private System.Windows.Forms.SaveFileDialog dlgHsvtSaver;
        private System.Windows.Forms.SaveFileDialog dlgHsvxSaver;
    }
}

