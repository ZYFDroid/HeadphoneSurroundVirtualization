namespace 耳机虚拟环绕声
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSrc = new System.Windows.Forms.ComboBox();
            this.cmbDst = new System.Windows.Forms.ComboBox();
            this.surroundProc = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLowLancey = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.chkBypass = new System.Windows.Forms.CheckBox();
            this.lblMasterGain = new System.Windows.Forms.Label();
            this.numMasterGain = new System.Windows.Forms.TrackBar();
            this.mtmOutR = new MP3模拟器.CtlBarMeter();
            this.mtmOutL = new MP3模拟器.CtlBarMeter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numCompressOverflow = new MP3模拟器.CtlBarMeter();
            this.lblCompressRelease = new System.Windows.Forms.Label();
            this.lblCompressAttack = new System.Windows.Forms.Label();
            this.lblCompressRatio = new System.Windows.Forms.Label();
            this.lblCompressGate = new System.Windows.Forms.Label();
            this.numCompressRelease = new NAudio.Gui.Pot();
            this.numCompressAttack = new NAudio.Gui.Pot();
            this.numCompressRatio = new NAudio.Gui.Pot();
            this.numCompressGate = new NAudio.Gui.Pot();
            this.barSR = new MP3模拟器.CtlBarMeter();
            this.barSL = new MP3模拟器.CtlBarMeter();
            this.barRR = new MP3模拟器.CtlBarMeter();
            this.barRL = new MP3模拟器.CtlBarMeter();
            this.barLF = new MP3模拟器.CtlBarMeter();
            this.barFC = new MP3模拟器.CtlBarMeter();
            this.barFR = new MP3模拟器.CtlBarMeter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.dragger = new System.Windows.Forms.PictureBox();
            this.barFL = new MP3模拟器.CtlBarMeter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPanelLocation = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMasterGain)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragger)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择你的虚拟环绕声设备（一般叫CABLE Input)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择你的耳机";
            // 
            // cmbSrc
            // 
            this.cmbSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSrc.FormattingEnabled = true;
            this.cmbSrc.Location = new System.Drawing.Point(6, 39);
            this.cmbSrc.Name = "cmbSrc";
            this.cmbSrc.Size = new System.Drawing.Size(335, 20);
            this.cmbSrc.TabIndex = 1;
            // 
            // cmbDst
            // 
            this.cmbDst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDst.ForeColor = System.Drawing.Color.Black;
            this.cmbDst.FormattingEnabled = true;
            this.cmbDst.Location = new System.Drawing.Point(6, 80);
            this.cmbDst.Name = "cmbDst";
            this.cmbDst.Size = new System.Drawing.Size(335, 20);
            this.cmbDst.TabIndex = 1;
            // 
            // surroundProc
            // 
            this.surroundProc.WorkerReportsProgress = true;
            this.surroundProc.WorkerSupportsCancellation = true;
            this.surroundProc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.surroundProc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.surroundProc_ProgressChanged);
            this.surroundProc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.surroundProc_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLowLancey);
            this.groupBox1.Controls.Add(this.btnHelp);
            this.groupBox1.Controls.Add(this.cmbSrc);
            this.groupBox1.Controls.Add(this.cmbDst);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(847, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 108);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // chkLowLancey
            // 
            this.chkLowLancey.AutoSize = true;
            this.chkLowLancey.Checked = true;
            this.chkLowLancey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowLancey.Location = new System.Drawing.Point(142, 62);
            this.chkLowLancey.Name = "chkLowLancey";
            this.chkLowLancey.Size = new System.Drawing.Size(192, 16);
            this.chkLowLancey.TabIndex = 10;
            this.chkLowLancey.Text = "低延迟模式（重新开启后生效）";
            this.toolTip1.SetToolTip(this.chkLowLancey, "低延迟模式，延迟更低但会导致音频卡顿。听音乐时推荐关闭");
            this.chkLowLancey.UseVisualStyleBackColor = true;
            this.chkLowLancey.CheckedChanged += new System.EventHandler(this.chkLowLancey_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(266, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 25);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "如何配置";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // chkBypass
            // 
            this.chkBypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.chkBypass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.chkBypass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBypass.Location = new System.Drawing.Point(83, 172);
            this.chkBypass.Name = "chkBypass";
            this.chkBypass.Size = new System.Drawing.Size(58, 25);
            this.chkBypass.TabIndex = 9;
            this.chkBypass.Text = "旁路";
            this.chkBypass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkBypass, "临时关闭虚拟环绕声。如果您正在聆听已经过其它虚拟环绕声技术处理过的音频，可以临时打开这个选项");
            this.chkBypass.UseVisualStyleBackColor = true;
            this.chkBypass.CheckedChanged += new System.EventHandler(this.chkBypass_CheckedChanged);
            // 
            // lblMasterGain
            // 
            this.lblMasterGain.Location = new System.Drawing.Point(560, 209);
            this.lblMasterGain.Name = "lblMasterGain";
            this.lblMasterGain.Size = new System.Drawing.Size(68, 29);
            this.lblMasterGain.TabIndex = 7;
            this.lblMasterGain.Text = "0dB\r\n增益";
            this.lblMasterGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMasterGain
            // 
            this.numMasterGain.BackColor = System.Drawing.Color.Black;
            this.numMasterGain.Location = new System.Drawing.Point(83, 203);
            this.numMasterGain.Maximum = 4000;
            this.numMasterGain.Minimum = -2000;
            this.numMasterGain.Name = "numMasterGain";
            this.numMasterGain.Size = new System.Drawing.Size(482, 45);
            this.numMasterGain.TabIndex = 6;
            this.numMasterGain.TickFrequency = 500;
            this.numMasterGain.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.numMasterGain.Scroll += new System.EventHandler(this.numMasterGain_Scroll);
            // 
            // mtmOutR
            // 
            this.mtmOutR.BackColor = System.Drawing.Color.Black;
            this.mtmOutR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mtmOutR.DisplayText = "R";
            this.mtmOutR.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtmOutR.Location = new System.Drawing.Point(486, 50);
            this.mtmOutR.Name = "mtmOutR";
            this.mtmOutR.Size = new System.Drawing.Size(142, 104);
            this.mtmOutR.TabIndex = 6;
            this.mtmOutR.Value = 0F;
            // 
            // mtmOutL
            // 
            this.mtmOutL.BackColor = System.Drawing.Color.Black;
            this.mtmOutL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mtmOutL.DisplayText = "L";
            this.mtmOutL.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtmOutL.Location = new System.Drawing.Point(338, 50);
            this.mtmOutL.Name = "mtmOutL";
            this.mtmOutL.Size = new System.Drawing.Size(142, 104);
            this.mtmOutL.TabIndex = 6;
            this.mtmOutL.Value = 0F;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numCompressOverflow);
            this.groupBox3.Controls.Add(this.lblCompressRelease);
            this.groupBox3.Controls.Add(this.lblCompressAttack);
            this.groupBox3.Controls.Add(this.lblCompressRatio);
            this.groupBox3.Controls.Add(this.lblCompressGate);
            this.groupBox3.Controls.Add(this.numCompressRelease);
            this.groupBox3.Controls.Add(this.numCompressAttack);
            this.groupBox3.Controls.Add(this.numCompressRatio);
            this.groupBox3.Controls.Add(this.numCompressGate);
            this.groupBox3.Location = new System.Drawing.Point(856, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 121);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "压缩器";
            // 
            // numCompressOverflow
            // 
            this.numCompressOverflow.BackColor = System.Drawing.Color.Black;
            this.numCompressOverflow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.numCompressOverflow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCompressOverflow.DisplayText = "";
            this.numCompressOverflow.Location = new System.Drawing.Point(327, 19);
            this.numCompressOverflow.Name = "numCompressOverflow";
            this.numCompressOverflow.Size = new System.Drawing.Size(14, 91);
            this.numCompressOverflow.TabIndex = 7;
            this.numCompressOverflow.Value = 0F;
            // 
            // lblCompressRelease
            // 
            this.lblCompressRelease.Location = new System.Drawing.Point(253, 77);
            this.lblCompressRelease.Name = "lblCompressRelease";
            this.lblCompressRelease.Size = new System.Drawing.Size(77, 39);
            this.lblCompressRelease.TabIndex = 1;
            this.lblCompressRelease.Text = "400ms\r\n释放时间";
            this.lblCompressRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCompressRelease, "压缩器未触发时完整释放的时间");
            // 
            // lblCompressAttack
            // 
            this.lblCompressAttack.Location = new System.Drawing.Point(171, 77);
            this.lblCompressAttack.Name = "lblCompressAttack";
            this.lblCompressAttack.Size = new System.Drawing.Size(77, 39);
            this.lblCompressAttack.TabIndex = 1;
            this.lblCompressAttack.Text = "40ms\r\n启动时间";
            this.lblCompressAttack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCompressAttack, "压缩器从触发到完成压缩的时间");
            // 
            // lblCompressRatio
            // 
            this.lblCompressRatio.Location = new System.Drawing.Point(89, 77);
            this.lblCompressRatio.Name = "lblCompressRatio";
            this.lblCompressRatio.Size = new System.Drawing.Size(77, 39);
            this.lblCompressRatio.TabIndex = 1;
            this.lblCompressRatio.Text = "1:1\r\n压缩比";
            this.lblCompressRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCompressRatio, "最大压缩量");
            // 
            // lblCompressGate
            // 
            this.lblCompressGate.Location = new System.Drawing.Point(6, 77);
            this.lblCompressGate.Name = "lblCompressGate";
            this.lblCompressGate.Size = new System.Drawing.Size(77, 39);
            this.lblCompressGate.TabIndex = 1;
            this.lblCompressGate.Text = "0dB\r\n噪音门限";
            this.lblCompressGate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCompressGate, "触发压缩的声音大小");
            // 
            // numCompressRelease
            // 
            this.numCompressRelease.Location = new System.Drawing.Point(257, 20);
            this.numCompressRelease.Maximum = 4000D;
            this.numCompressRelease.Minimum = 0D;
            this.numCompressRelease.Name = "numCompressRelease";
            this.numCompressRelease.Size = new System.Drawing.Size(67, 54);
            this.numCompressRelease.TabIndex = 0;
            this.numCompressRelease.Value = 400D;
            this.numCompressRelease.ValueChanged += new System.EventHandler(this.numCompress_ValueChanged);
            // 
            // numCompressAttack
            // 
            this.numCompressAttack.Location = new System.Drawing.Point(175, 20);
            this.numCompressAttack.Maximum = 200D;
            this.numCompressAttack.Minimum = 0D;
            this.numCompressAttack.Name = "numCompressAttack";
            this.numCompressAttack.Size = new System.Drawing.Size(67, 54);
            this.numCompressAttack.TabIndex = 0;
            this.numCompressAttack.Value = 40D;
            this.numCompressAttack.ValueChanged += new System.EventHandler(this.numCompress_ValueChanged);
            // 
            // numCompressRatio
            // 
            this.numCompressRatio.Location = new System.Drawing.Point(93, 20);
            this.numCompressRatio.Maximum = 79D;
            this.numCompressRatio.Minimum = 0D;
            this.numCompressRatio.Name = "numCompressRatio";
            this.numCompressRatio.Size = new System.Drawing.Size(67, 54);
            this.numCompressRatio.TabIndex = 0;
            this.numCompressRatio.Value = 0D;
            this.numCompressRatio.ValueChanged += new System.EventHandler(this.numCompress_ValueChanged);
            this.numCompressRatio.Load += new System.EventHandler(this.numCompressRatio_Load);
            // 
            // numCompressGate
            // 
            this.numCompressGate.Location = new System.Drawing.Point(10, 20);
            this.numCompressGate.Maximum = 20D;
            this.numCompressGate.Minimum = 0D;
            this.numCompressGate.Name = "numCompressGate";
            this.numCompressGate.Size = new System.Drawing.Size(67, 54);
            this.numCompressGate.TabIndex = 0;
            this.numCompressGate.Value = 20D;
            this.numCompressGate.ValueChanged += new System.EventHandler(this.numCompress_ValueChanged);
            // 
            // barSR
            // 
            this.barSR.BackColor = System.Drawing.Color.Black;
            this.barSR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barSR.DisplayText = "SR";
            this.barSR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barSR.Location = new System.Drawing.Point(175, 105);
            this.barSR.Name = "barSR";
            this.barSR.Size = new System.Drawing.Size(72, 49);
            this.barSR.TabIndex = 0;
            this.barSR.Value = 0F;
            // 
            // barSL
            // 
            this.barSL.BackColor = System.Drawing.Color.Black;
            this.barSL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barSL.DisplayText = "SL";
            this.barSL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barSL.Location = new System.Drawing.Point(175, 50);
            this.barSL.Name = "barSL";
            this.barSL.Size = new System.Drawing.Size(72, 49);
            this.barSL.TabIndex = 0;
            this.barSL.Value = 0F;
            // 
            // barRR
            // 
            this.barRR.BackColor = System.Drawing.Color.Black;
            this.barRR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barRR.DisplayText = "RR";
            this.barRR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barRR.Location = new System.Drawing.Point(253, 105);
            this.barRR.Name = "barRR";
            this.barRR.Size = new System.Drawing.Size(72, 49);
            this.barRR.TabIndex = 0;
            this.barRR.Value = 0F;
            // 
            // barRL
            // 
            this.barRL.BackColor = System.Drawing.Color.Black;
            this.barRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barRL.DisplayText = "RL";
            this.barRL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barRL.Location = new System.Drawing.Point(253, 50);
            this.barRL.Name = "barRL";
            this.barRL.Size = new System.Drawing.Size(72, 49);
            this.barRL.TabIndex = 0;
            this.barRL.Value = 0F;
            // 
            // barLF
            // 
            this.barLF.BackColor = System.Drawing.Color.Black;
            this.barLF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barLF.DisplayText = "LF";
            this.barLF.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barLF.Location = new System.Drawing.Point(97, 105);
            this.barLF.Name = "barLF";
            this.barLF.Size = new System.Drawing.Size(72, 49);
            this.barLF.TabIndex = 0;
            this.barLF.Value = 0F;
            // 
            // barFC
            // 
            this.barFC.BackColor = System.Drawing.Color.Black;
            this.barFC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFC.DisplayText = "FC";
            this.barFC.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barFC.Location = new System.Drawing.Point(97, 50);
            this.barFC.Name = "barFC";
            this.barFC.Size = new System.Drawing.Size(72, 49);
            this.barFC.TabIndex = 0;
            this.barFC.Value = 0F;
            // 
            // barFR
            // 
            this.barFR.BackColor = System.Drawing.Color.Black;
            this.barFR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFR.DisplayText = "FR";
            this.barFR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barFR.Location = new System.Drawing.Point(19, 105);
            this.barFR.Name = "barFR";
            this.barFR.Size = new System.Drawing.Size(72, 49);
            this.barFR.TabIndex = 0;
            this.barFR.Value = 0F;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.Black;
            this.btnBegin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBegin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBegin.FlatAppearance.BorderSize = 0;
            this.btnBegin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnBegin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBegin.Image = global::耳机虚拟环绕声.Properties.Resources.btnSurroundOn;
            this.btnBegin.Location = new System.Drawing.Point(683, 9);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(67, 69);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(756, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 69);
            this.btnClose.TabIndex = 8;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dragger
            // 
            this.dragger.BackColor = System.Drawing.Color.Transparent;
            this.dragger.Location = new System.Drawing.Point(10, 6);
            this.dragger.Name = "dragger";
            this.dragger.Size = new System.Drawing.Size(667, 83);
            this.dragger.TabIndex = 9;
            this.dragger.TabStop = false;
            this.dragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseDown);
            this.dragger.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseMove);
            this.dragger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseUp);
            // 
            // barFL
            // 
            this.barFL.BackColor = System.Drawing.Color.Black;
            this.barFL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFL.DisplayText = "FL";
            this.barFL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barFL.Location = new System.Drawing.Point(19, 50);
            this.barFL.Name = "barFL";
            this.barFL.Size = new System.Drawing.Size(72, 49);
            this.barFL.TabIndex = 0;
            this.barFL.Value = 0F;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnPage1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPage2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPage3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPage4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(146, 191);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btnPage1
            // 
            this.btnPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage1.FlatAppearance.BorderSize = 0;
            this.btnPage1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Image = global::耳机虚拟环绕声.Properties.Resources.rightIndicator;
            this.btnPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage1.Location = new System.Drawing.Point(3, 3);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(140, 41);
            this.btnPage1.TabIndex = 0;
            this.btnPage1.Text = "环绕声";
            this.btnPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage1.UseVisualStyleBackColor = true;
            // 
            // btnPage2
            // 
            this.btnPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage2.FlatAppearance.BorderSize = 0;
            this.btnPage2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage2.ForeColor = System.Drawing.Color.LightGray;
            this.btnPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage2.Location = new System.Drawing.Point(3, 50);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(140, 41);
            this.btnPage2.TabIndex = 0;
            this.btnPage2.Text = "音频增强";
            this.btnPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage2.UseVisualStyleBackColor = true;
            // 
            // btnPage3
            // 
            this.btnPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage3.FlatAppearance.BorderSize = 0;
            this.btnPage3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage3.ForeColor = System.Drawing.Color.LightGray;
            this.btnPage3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage3.Location = new System.Drawing.Point(3, 97);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(140, 41);
            this.btnPage3.TabIndex = 0;
            this.btnPage3.Text = "设备配置";
            this.btnPage3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage3.UseVisualStyleBackColor = true;
            // 
            // btnPage4
            // 
            this.btnPage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage4.FlatAppearance.BorderSize = 0;
            this.btnPage4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage4.ForeColor = System.Drawing.Color.LightGray;
            this.btnPage4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage4.Location = new System.Drawing.Point(3, 144);
            this.btnPage4.Name = "btnPage4";
            this.btnPage4.Size = new System.Drawing.Size(140, 44);
            this.btnPage4.TabIndex = 0;
            this.btnPage4.Text = "关于";
            this.btnPage4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblMasterGain);
            this.panel1.Controls.Add(this.chkBypass);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.numMasterGain);
            this.panel1.Controls.Add(this.barFL);
            this.panel1.Controls.Add(this.mtmOutR);
            this.panel1.Controls.Add(this.barFR);
            this.panel1.Controls.Add(this.mtmOutL);
            this.panel1.Controls.Add(this.barFC);
            this.panel1.Controls.Add(this.barLF);
            this.panel1.Controls.Add(this.barRL);
            this.panel1.Controls.Add(this.barSL);
            this.panel1.Controls.Add(this.barRR);
            this.panel1.Controls.Add(this.barSR);
            this.panel1.Location = new System.Drawing.Point(166, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 370);
            this.panel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "主控";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(340, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "输出";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(19, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 25);
            this.label11.TabIndex = 1;
            this.label11.Text = "输入";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanelLocation
            // 
            this.lblPanelLocation.AutoSize = true;
            this.lblPanelLocation.ForeColor = System.Drawing.Color.Black;
            this.lblPanelLocation.Location = new System.Drawing.Point(164, 106);
            this.lblPanelLocation.Name = "lblPanelLocation";
            this.lblPanelLocation.Size = new System.Drawing.Size(41, 12);
            this.lblPanelLocation.TabIndex = 12;
            this.lblPanelLocation.Text = "114514";
            this.lblPanelLocation.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "增益";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::耳机虚拟环绕声.Properties.Resources.bg_hesuvi2;
            this.ClientSize = new System.Drawing.Size(1793, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPanelLocation);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dragger);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBegin);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "耳机虚拟环绕声";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMasterGain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragger)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSrc;
        private System.Windows.Forms.ComboBox cmbDst;
        private System.Windows.Forms.Button btnBegin;
        private System.ComponentModel.BackgroundWorker surroundProc;
        private System.Windows.Forms.GroupBox groupBox1;
        private MP3模拟器.CtlBarMeter mtmOutR;
        private MP3模拟器.CtlBarMeter mtmOutL;
        private System.Windows.Forms.Label lblMasterGain;
        private System.Windows.Forms.TrackBar numMasterGain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCompressRelease;
        private System.Windows.Forms.Label lblCompressAttack;
        private System.Windows.Forms.Label lblCompressRatio;
        private System.Windows.Forms.Label lblCompressGate;
        private NAudio.Gui.Pot numCompressRelease;
        private NAudio.Gui.Pot numCompressAttack;
        private NAudio.Gui.Pot numCompressRatio;
        private NAudio.Gui.Pot numCompressGate;
        private MP3模拟器.CtlBarMeter numCompressOverflow;
        private MP3模拟器.CtlBarMeter barFL;
        private MP3模拟器.CtlBarMeter barSR;
        private MP3模拟器.CtlBarMeter barSL;
        private MP3模拟器.CtlBarMeter barRR;
        private MP3模拟器.CtlBarMeter barRL;
        private MP3模拟器.CtlBarMeter barLF;
        private MP3模拟器.CtlBarMeter barFC;
        private MP3模拟器.CtlBarMeter barFR;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkBypass;
        private System.Windows.Forms.CheckBox chkLowLancey;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox dragger;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Button btnPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPanelLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

