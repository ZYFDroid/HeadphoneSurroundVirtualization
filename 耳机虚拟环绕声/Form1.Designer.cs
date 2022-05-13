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
            this.lblIndicator = new System.Windows.Forms.Label();
            this.surroundProc = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLowLancey = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBypass = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMasterGain = new System.Windows.Forms.Label();
            this.numMasterGain = new System.Windows.Forms.TrackBar();
            this.mtmOutR = new MP3模拟器.CtlBarMeter();
            this.mtmOutL = new MP3模拟器.CtlBarMeter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numCompressOverflow = new MP3模拟器.CtlBarMeter();
            this.lblCompressRelease = new System.Windows.Forms.Label();
            this.lblCompressAttack = new System.Windows.Forms.Label();
            this.lblCompressRatio = new System.Windows.Forms.Label();
            this.lblCompressGate = new System.Windows.Forms.Label();
            this.numCompressRelease = new NAudio.Gui.Pot();
            this.numCompressAttack = new NAudio.Gui.Pot();
            this.numCompressRatio = new NAudio.Gui.Pot();
            this.numCompressGate = new NAudio.Gui.Pot();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.barSR = new MP3模拟器.CtlBarMeter();
            this.barSL = new MP3模拟器.CtlBarMeter();
            this.barRR = new MP3模拟器.CtlBarMeter();
            this.barRL = new MP3模拟器.CtlBarMeter();
            this.barLF = new MP3模拟器.CtlBarMeter();
            this.barFC = new MP3模拟器.CtlBarMeter();
            this.barFR = new MP3模拟器.CtlBarMeter();
            this.barFL = new MP3模拟器.CtlBarMeter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMasterGain)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // lblIndicator
            // 
            this.lblIndicator.Location = new System.Drawing.Point(630, 99);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(10, 10);
            this.lblIndicator.TabIndex = 3;
            this.lblIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIndicator.Visible = false;
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
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbSrc);
            this.groupBox1.Controls.Add(this.cmbDst);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 108);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备选项";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "设备选项";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBypass);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblMasterGain);
            this.groupBox2.Controls.Add(this.numMasterGain);
            this.groupBox2.Controls.Add(this.mtmOutR);
            this.groupBox2.Controls.Add(this.mtmOutL);
            this.groupBox2.Location = new System.Drawing.Point(369, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 362);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主控";
            // 
            // chkBypass
            // 
            this.chkBypass.AutoSize = true;
            this.chkBypass.Location = new System.Drawing.Point(16, 336);
            this.chkBypass.Name = "chkBypass";
            this.chkBypass.Size = new System.Drawing.Size(48, 16);
            this.chkBypass.TabIndex = 9;
            this.chkBypass.Text = "旁路";
            this.toolTip1.SetToolTip(this.chkBypass, "临时关闭虚拟环绕声。如果您正在聆听已经过其它虚拟环绕声技术处理过的音频，可以临时打开这个选项");
            this.chkBypass.UseVisualStyleBackColor = true;
            this.chkBypass.CheckedChanged += new System.EventHandler(this.chkBypass_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "主控";
            // 
            // lblMasterGain
            // 
            this.lblMasterGain.Location = new System.Drawing.Point(6, 305);
            this.lblMasterGain.Name = "lblMasterGain";
            this.lblMasterGain.Size = new System.Drawing.Size(68, 29);
            this.lblMasterGain.TabIndex = 7;
            this.lblMasterGain.Text = "0dB\r\n增益";
            this.lblMasterGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMasterGain
            // 
            this.numMasterGain.Location = new System.Drawing.Point(19, 20);
            this.numMasterGain.Maximum = 4000;
            this.numMasterGain.Minimum = -2000;
            this.numMasterGain.Name = "numMasterGain";
            this.numMasterGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.numMasterGain.Size = new System.Drawing.Size(45, 290);
            this.numMasterGain.TabIndex = 6;
            this.numMasterGain.TickFrequency = 500;
            this.numMasterGain.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.numMasterGain.Scroll += new System.EventHandler(this.numMasterGain_Scroll);
            // 
            // mtmOutR
            // 
            this.mtmOutR.BackColor = System.Drawing.Color.Black;
            this.mtmOutR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mtmOutR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtmOutR.Location = new System.Drawing.Point(93, 26);
            this.mtmOutR.Name = "mtmOutR";
            this.mtmOutR.Size = new System.Drawing.Size(11, 321);
            this.mtmOutR.TabIndex = 6;
            this.mtmOutR.Value = 0F;
            // 
            // mtmOutL
            // 
            this.mtmOutL.BackColor = System.Drawing.Color.Black;
            this.mtmOutL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mtmOutL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtmOutL.Location = new System.Drawing.Point(78, 26);
            this.mtmOutL.Name = "mtmOutL";
            this.mtmOutL.Size = new System.Drawing.Size(11, 321);
            this.mtmOutL.TabIndex = 6;
            this.mtmOutL.Value = 0F;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.numCompressOverflow);
            this.groupBox3.Controls.Add(this.lblCompressRelease);
            this.groupBox3.Controls.Add(this.lblCompressAttack);
            this.groupBox3.Controls.Add(this.lblCompressRatio);
            this.groupBox3.Controls.Add(this.lblCompressGate);
            this.groupBox3.Controls.Add(this.numCompressRelease);
            this.groupBox3.Controls.Add(this.numCompressAttack);
            this.groupBox3.Controls.Add(this.numCompressRatio);
            this.groupBox3.Controls.Add(this.numCompressGate);
            this.groupBox3.Location = new System.Drawing.Point(13, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 121);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "压缩器";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "压缩器";
            // 
            // numCompressOverflow
            // 
            this.numCompressOverflow.BackColor = System.Drawing.Color.Black;
            this.numCompressOverflow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.numCompressOverflow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.barSR);
            this.groupBox4.Controls.Add(this.barSL);
            this.groupBox4.Controls.Add(this.barRR);
            this.groupBox4.Controls.Add(this.barRL);
            this.groupBox4.Controls.Add(this.barLF);
            this.groupBox4.Controls.Add(this.barFC);
            this.groupBox4.Controls.Add(this.barFR);
            this.groupBox4.Controls.Add(this.barFL);
            this.groupBox4.Location = new System.Drawing.Point(13, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 121);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "输入视图";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "输入视图";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(303, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "右侧";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(261, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "左侧";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(219, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "右后";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(177, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "左后";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(135, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "低音";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(93, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "前置";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(51, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "右前";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "左前";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barSR
            // 
            this.barSR.BackColor = System.Drawing.Color.Black;
            this.barSR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barSR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barSR.Location = new System.Drawing.Point(316, 20);
            this.barSR.Name = "barSR";
            this.barSR.Size = new System.Drawing.Size(14, 75);
            this.barSR.TabIndex = 0;
            this.barSR.Value = 0F;
            // 
            // barSL
            // 
            this.barSL.BackColor = System.Drawing.Color.Black;
            this.barSL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barSL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barSL.Location = new System.Drawing.Point(274, 20);
            this.barSL.Name = "barSL";
            this.barSL.Size = new System.Drawing.Size(14, 75);
            this.barSL.TabIndex = 0;
            this.barSL.Value = 0F;
            // 
            // barRR
            // 
            this.barRR.BackColor = System.Drawing.Color.Black;
            this.barRR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barRR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barRR.Location = new System.Drawing.Point(232, 20);
            this.barRR.Name = "barRR";
            this.barRR.Size = new System.Drawing.Size(14, 75);
            this.barRR.TabIndex = 0;
            this.barRR.Value = 0F;
            // 
            // barRL
            // 
            this.barRL.BackColor = System.Drawing.Color.Black;
            this.barRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barRL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barRL.Location = new System.Drawing.Point(190, 20);
            this.barRL.Name = "barRL";
            this.barRL.Size = new System.Drawing.Size(14, 75);
            this.barRL.TabIndex = 0;
            this.barRL.Value = 0F;
            // 
            // barLF
            // 
            this.barLF.BackColor = System.Drawing.Color.Black;
            this.barLF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barLF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barLF.Location = new System.Drawing.Point(148, 20);
            this.barLF.Name = "barLF";
            this.barLF.Size = new System.Drawing.Size(14, 75);
            this.barLF.TabIndex = 0;
            this.barLF.Value = 0F;
            // 
            // barFC
            // 
            this.barFC.BackColor = System.Drawing.Color.Black;
            this.barFC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barFC.Location = new System.Drawing.Point(106, 20);
            this.barFC.Name = "barFC";
            this.barFC.Size = new System.Drawing.Size(14, 75);
            this.barFC.TabIndex = 0;
            this.barFC.Value = 0F;
            // 
            // barFR
            // 
            this.barFR.BackColor = System.Drawing.Color.Black;
            this.barFR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barFR.Location = new System.Drawing.Point(64, 20);
            this.barFR.Name = "barFR";
            this.barFR.Size = new System.Drawing.Size(14, 75);
            this.barFR.TabIndex = 0;
            this.barFR.Value = 0F;
            // 
            // barFL
            // 
            this.barFL.BackColor = System.Drawing.Color.Black;
            this.barFL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barFL.Location = new System.Drawing.Point(22, 20);
            this.barFL.Name = "barFL";
            this.barFL.Size = new System.Drawing.Size(14, 75);
            this.barFL.TabIndex = 0;
            this.barFL.Value = 0F;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::耳机虚拟环绕声.Properties.Resources.doubi;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(470, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBegin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBegin.FlatAppearance.BorderSize = 5;
            this.btnBegin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBegin.Image = global::耳机虚拟环绕声.Properties.Resources.btnSurroundOn;
            this.btnBegin.Location = new System.Drawing.Point(13, 450);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(471, 69);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(497, 531);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.btnBegin);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "耳机虚拟环绕声";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMasterGain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSrc;
        private System.Windows.Forms.ComboBox cmbDst;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Button btnBegin;
        private System.ComponentModel.BackgroundWorker surroundProc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private MP3模拟器.CtlBarMeter barFL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private MP3模拟器.CtlBarMeter barSR;
        private MP3模拟器.CtlBarMeter barSL;
        private MP3模拟器.CtlBarMeter barRR;
        private MP3模拟器.CtlBarMeter barRL;
        private MP3模拟器.CtlBarMeter barLF;
        private MP3模拟器.CtlBarMeter barFC;
        private MP3模拟器.CtlBarMeter barFR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkBypass;
        private System.Windows.Forms.CheckBox chkLowLancey;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

