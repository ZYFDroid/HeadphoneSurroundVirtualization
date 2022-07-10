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
            this.cmbSrc = new System.Windows.Forms.ComboBox();
            this.cmbDst = new System.Windows.Forms.ComboBox();
            this.surroundProc = new System.ComponentModel.BackgroundWorker();
            this.chkLowLancey = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.chkBypass = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnEnchanceAudio_ = new System.Windows.Forms.Button();
            this.chkFc2F = new System.Windows.Forms.CheckBox();
            this.btnSwitchConvolver = new System.Windows.Forms.Button();
            this.chkShowAllDevice = new System.Windows.Forms.CheckBox();
            this.btnEnchanceAudio = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.dragger = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage4 = new System.Windows.Forms.Button();
            this.panelPage1 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.numMasterGain = new 耳机虚拟环绕声.CtlBarSlider();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.barFL = new MP3模拟器.CtlBarMeter();
            this.mtmOutR = new MP3模拟器.CtlBarMeter();
            this.barFR = new MP3模拟器.CtlBarMeter();
            this.numCompressOverflow1 = new MP3模拟器.CtlBarMeter();
            this.mtmOutL = new MP3模拟器.CtlBarMeter();
            this.barFC = new MP3模拟器.CtlBarMeter();
            this.barLF = new MP3模拟器.CtlBarMeter();
            this.barRL = new MP3模拟器.CtlBarMeter();
            this.barSL = new MP3模拟器.CtlBarMeter();
            this.barRR = new MP3模拟器.CtlBarMeter();
            this.barSR = new MP3模拟器.CtlBarMeter();
            this.posShow = new System.Windows.Forms.Label();
            this.posHide = new System.Windows.Forms.Label();
            this.panelPage2 = new System.Windows.Forms.Panel();
            this.lblConvolver = new System.Windows.Forms.Label();
            this.btnResetConvolver = new System.Windows.Forms.Button();
            this.numCompressRelease = new 耳机虚拟环绕声.CtlBarSlider();
            this.numCompressAttack = new 耳机虚拟环绕声.CtlBarSlider();
            this.numCompressRatio = new 耳机虚拟环绕声.CtlBarSlider();
            this.numCompressGate = new 耳机虚拟环绕声.CtlBarSlider();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelPage3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panelPage4 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.updateDeviceCountdownTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragger)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelPage1.SuspendLayout();
            this.panelPage2.SuspendLayout();
            this.panelPage3.SuspendLayout();
            this.panelPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSrc
            // 
            this.cmbSrc.BackColor = System.Drawing.Color.Black;
            this.cmbSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSrc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbSrc.ForeColor = System.Drawing.Color.White;
            this.cmbSrc.FormattingEnabled = true;
            this.cmbSrc.Location = new System.Drawing.Point(112, 128);
            this.cmbSrc.Name = "cmbSrc";
            this.cmbSrc.Size = new System.Drawing.Size(335, 29);
            this.cmbSrc.TabIndex = 1;
            // 
            // cmbDst
            // 
            this.cmbDst.BackColor = System.Drawing.Color.Black;
            this.cmbDst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDst.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbDst.ForeColor = System.Drawing.Color.White;
            this.cmbDst.FormattingEnabled = true;
            this.cmbDst.Location = new System.Drawing.Point(112, 50);
            this.cmbDst.Name = "cmbDst";
            this.cmbDst.Size = new System.Drawing.Size(335, 29);
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
            // chkLowLancey
            // 
            this.chkLowLancey.AutoSize = true;
            this.chkLowLancey.BackColor = System.Drawing.Color.Black;
            this.chkLowLancey.Checked = true;
            this.chkLowLancey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowLancey.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.chkLowLancey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLowLancey.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.chkLowLancey.Location = new System.Drawing.Point(112, 91);
            this.chkLowLancey.Name = "chkLowLancey";
            this.chkLowLancey.Size = new System.Drawing.Size(202, 25);
            this.chkLowLancey.TabIndex = 10;
            this.chkLowLancey.Text = "启用（重新开启后生效）";
            this.toolTip1.SetToolTip(this.chkLowLancey, "低延迟模式，延迟更低但会导致音频卡顿。听音乐时推荐关闭");
            this.chkLowLancey.UseVisualStyleBackColor = false;
            this.chkLowLancey.CheckedChanged += new System.EventHandler(this.chkLowLancey_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnHelp.Location = new System.Drawing.Point(453, 123);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(179, 38);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "配置虚拟设备";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.chkBypass.Location = new System.Drawing.Point(82, 160);
            this.chkBypass.Name = "chkBypass";
            this.chkBypass.Size = new System.Drawing.Size(58, 25);
            this.chkBypass.TabIndex = 9;
            this.chkBypass.Text = "旁路";
            this.chkBypass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkBypass, "临时关闭虚拟环绕声。如果您正在聆听已经过其它虚拟环绕声技术处理过的音频，可以临时打开这个选项");
            this.chkBypass.UseVisualStyleBackColor = true;
            this.chkBypass.CheckedChanged += new System.EventHandler(this.chkBypass_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // btnEnchanceAudio_
            // 
            this.btnEnchanceAudio_.FlatAppearance.BorderSize = 0;
            this.btnEnchanceAudio_.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnchanceAudio_.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEnchanceAudio_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnchanceAudio_.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnEnchanceAudio_.Location = new System.Drawing.Point(453, 45);
            this.btnEnchanceAudio_.Name = "btnEnchanceAudio_";
            this.btnEnchanceAudio_.Size = new System.Drawing.Size(179, 38);
            this.btnEnchanceAudio_.TabIndex = 9;
            this.btnEnchanceAudio_.Text = "音质增强";
            this.btnEnchanceAudio_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnEnchanceAudio_, "提升耳机的音质和表现效果");
            this.btnEnchanceAudio_.UseVisualStyleBackColor = true;
            this.btnEnchanceAudio_.Click += new System.EventHandler(this.btnEnchanceAudio__Click);
            // 
            // chkFc2F
            // 
            this.chkFc2F.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFc2F.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.chkFc2F.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.chkFc2F.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkFc2F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFc2F.Location = new System.Drawing.Point(146, 160);
            this.chkFc2F.Name = "chkFc2F";
            this.chkFc2F.Size = new System.Drawing.Size(81, 25);
            this.chkFc2F.TabIndex = 9;
            this.chkFc2F.Text = "切换前置";
            this.chkFc2F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkFc2F, "将前置声道连接到左前和右前。如果前置声道的声音听起来很奇怪，可以打开这个选项");
            this.chkFc2F.UseVisualStyleBackColor = true;
            this.chkFc2F.CheckedChanged += new System.EventHandler(this.chkFc2F_CheckedChanged);
            // 
            // btnSwitchConvolver
            // 
            this.btnSwitchConvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchConvolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSwitchConvolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSwitchConvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchConvolver.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSwitchConvolver.Location = new System.Drawing.Point(20, 272);
            this.btnSwitchConvolver.Name = "btnSwitchConvolver";
            this.btnSwitchConvolver.Size = new System.Drawing.Size(184, 32);
            this.btnSwitchConvolver.TabIndex = 9;
            this.btnSwitchConvolver.Text = "切换脉冲响应文件...";
            this.toolTip1.SetToolTip(this.btnSwitchConvolver, "本软件通过对原始音频信号\r\n和”脉冲响应样本“进行卷积\r\n运算，实现虚拟环绕声。这\r\n是一种常见的技术。您可以\r\n从Hesuvi的仓库和论坛等途\r\n径获取更多环绕" +
        "脉冲样本。\r\n环绕样本和Hesuvi兼容");
            this.btnSwitchConvolver.UseVisualStyleBackColor = true;
            this.btnSwitchConvolver.Click += new System.EventHandler(this.btnSwitchConvolver_Click);
            // 
            // chkShowAllDevice
            // 
            this.chkShowAllDevice.AutoSize = true;
            this.chkShowAllDevice.BackColor = System.Drawing.Color.Black;
            this.chkShowAllDevice.Checked = true;
            this.chkShowAllDevice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowAllDevice.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.chkShowAllDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowAllDevice.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.chkShowAllDevice.Location = new System.Drawing.Point(110, 173);
            this.chkShowAllDevice.Name = "chkShowAllDevice";
            this.chkShowAllDevice.Size = new System.Drawing.Size(122, 25);
            this.chkShowAllDevice.TabIndex = 10;
            this.chkShowAllDevice.Text = "扫描所有设备";
            this.toolTip1.SetToolTip(this.chkShowAllDevice, "强制列出所有可用输出设备\r\n如果再输出设备里找不到您使用的设备，\r\n或者使用的设备跑到了虚拟设备列表里，\r\n请启用此选项。");
            this.chkShowAllDevice.UseVisualStyleBackColor = false;
            this.chkShowAllDevice.CheckedChanged += new System.EventHandler(this.chkShowAllDevice_CheckedChanged);
            // 
            // btnEnchanceAudio
            // 
            this.btnEnchanceAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnchanceAudio.FlatAppearance.BorderSize = 0;
            this.btnEnchanceAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnchanceAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEnchanceAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnchanceAudio.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnchanceAudio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnchanceAudio.Location = new System.Drawing.Point(233, 155);
            this.btnEnchanceAudio.Name = "btnEnchanceAudio";
            this.btnEnchanceAudio.Size = new System.Drawing.Size(122, 35);
            this.btnEnchanceAudio.TabIndex = 9;
            this.btnEnchanceAudio.Text = "音质增强 →";
            this.btnEnchanceAudio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnEnchanceAudio, "提升耳机的音质和表现效果");
            this.btnEnchanceAudio.UseVisualStyleBackColor = true;
            this.btnEnchanceAudio.Click += new System.EventHandler(this.btnEnchanceAudio__Click);
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
            this.dragger.Location = new System.Drawing.Point(0, -2);
            this.dragger.Name = "dragger";
            this.dragger.Size = new System.Drawing.Size(824, 105);
            this.dragger.TabIndex = 9;
            this.dragger.TabStop = false;
            this.dragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseDown);
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
            this.btnPage1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Image = global::耳机虚拟环绕声.Properties.Resources.rightIndicator;
            this.btnPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage1.Location = new System.Drawing.Point(3, 3);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(140, 41);
            this.btnPage1.TabIndex = 0;
            this.btnPage1.Tag = "1";
            this.btnPage1.Text = "环绕声";
            this.btnPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage1.UseVisualStyleBackColor = true;
            this.btnPage1.Click += new System.EventHandler(this.btnPage1_Click);
            // 
            // btnPage2
            // 
            this.btnPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage2.FlatAppearance.BorderSize = 0;
            this.btnPage2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnPage2.ForeColor = System.Drawing.Color.LightGray;
            this.btnPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage2.Location = new System.Drawing.Point(3, 50);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(140, 41);
            this.btnPage2.TabIndex = 0;
            this.btnPage2.Tag = "2";
            this.btnPage2.Text = "音频处理";
            this.btnPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage2.UseVisualStyleBackColor = true;
            this.btnPage2.Click += new System.EventHandler(this.btnPage1_Click);
            // 
            // btnPage3
            // 
            this.btnPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage3.FlatAppearance.BorderSize = 0;
            this.btnPage3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnPage3.ForeColor = System.Drawing.Color.LightGray;
            this.btnPage3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage3.Location = new System.Drawing.Point(3, 97);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(140, 41);
            this.btnPage3.TabIndex = 0;
            this.btnPage3.Tag = "3";
            this.btnPage3.Text = "设备配置";
            this.btnPage3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage3.UseVisualStyleBackColor = true;
            this.btnPage3.Click += new System.EventHandler(this.btnPage1_Click);
            // 
            // btnPage4
            // 
            this.btnPage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPage4.FlatAppearance.BorderSize = 0;
            this.btnPage4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPage4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnPage4.ForeColor = System.Drawing.Color.LightGray;
            this.btnPage4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage4.Location = new System.Drawing.Point(3, 144);
            this.btnPage4.Name = "btnPage4";
            this.btnPage4.Size = new System.Drawing.Size(140, 44);
            this.btnPage4.TabIndex = 0;
            this.btnPage4.Tag = "4";
            this.btnPage4.Text = "关于";
            this.btnPage4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPage4.UseVisualStyleBackColor = true;
            this.btnPage4.Click += new System.EventHandler(this.btnPage1_Click);
            // 
            // panelPage1
            // 
            this.panelPage1.BackColor = System.Drawing.Color.Transparent;
            this.panelPage1.Controls.Add(this.btnTest);
            this.panelPage1.Controls.Add(this.btnEnchanceAudio);
            this.panelPage1.Controls.Add(this.numMasterGain);
            this.panelPage1.Controls.Add(this.chkFc2F);
            this.panelPage1.Controls.Add(this.chkBypass);
            this.panelPage1.Controls.Add(this.label6);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label11);
            this.panelPage1.Controls.Add(this.barFL);
            this.panelPage1.Controls.Add(this.mtmOutR);
            this.panelPage1.Controls.Add(this.barFR);
            this.panelPage1.Controls.Add(this.numCompressOverflow1);
            this.panelPage1.Controls.Add(this.mtmOutL);
            this.panelPage1.Controls.Add(this.barFC);
            this.panelPage1.Controls.Add(this.barLF);
            this.panelPage1.Controls.Add(this.barRL);
            this.panelPage1.Controls.Add(this.barSL);
            this.panelPage1.Controls.Add(this.barRR);
            this.panelPage1.Controls.Add(this.barSR);
            this.panelPage1.Location = new System.Drawing.Point(166, 106);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(647, 394);
            this.panelPage1.TabIndex = 11;
            // 
            // btnTest
            // 
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnTest.Location = new System.Drawing.Point(402, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(58, 32);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "测试";
            this.btnTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // numMasterGain
            // 
            this.numMasterGain.BackColor = System.Drawing.Color.Black;
            this.numMasterGain.BigStep = 5;
            this.numMasterGain.Location = new System.Drawing.Point(96, 201);
            this.numMasterGain.Max = 4000;
            this.numMasterGain.Min = -2000;
            this.numMasterGain.Name = "numMasterGain";
            this.numMasterGain.Size = new System.Drawing.Size(531, 25);
            this.numMasterGain.SmallStep = 3;
            this.numMasterGain.TabIndex = 10;
            this.numMasterGain.ThumbText = "0.0 dB";
            this.numMasterGain.ThumbWidth = 80;
            this.numMasterGain.Value = 0;
            this.numMasterGain.ValueChanged += new System.EventHandler<System.EventArgs>(this.numMasterGain_Scroll);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "压限";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "增益";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "主控";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(338, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "输出";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(18, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 25);
            this.label11.TabIndex = 1;
            this.label11.Text = "输入";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barFL
            // 
            this.barFL.BackColor = System.Drawing.Color.Black;
            this.barFL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFL.DisplayText = "FL";
            this.barFL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barFL.Location = new System.Drawing.Point(18, 38);
            this.barFL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barFL.Name = "barFL";
            this.barFL.Size = new System.Drawing.Size(72, 49);
            this.barFL.TabIndex = 0;
            this.barFL.Value = 0F;
            // 
            // mtmOutR
            // 
            this.mtmOutR.BackColor = System.Drawing.Color.Black;
            this.mtmOutR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mtmOutR.DisplayText = "R";
            this.mtmOutR.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.mtmOutR.Location = new System.Drawing.Point(485, 38);
            this.mtmOutR.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.mtmOutR.Name = "mtmOutR";
            this.mtmOutR.Size = new System.Drawing.Size(142, 104);
            this.mtmOutR.TabIndex = 6;
            this.mtmOutR.Value = 0F;
            // 
            // barFR
            // 
            this.barFR.BackColor = System.Drawing.Color.Black;
            this.barFR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFR.DisplayText = "FR";
            this.barFR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barFR.Location = new System.Drawing.Point(18, 93);
            this.barFR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barFR.Name = "barFR";
            this.barFR.Size = new System.Drawing.Size(72, 49);
            this.barFR.TabIndex = 0;
            this.barFR.Value = 0F;
            // 
            // numCompressOverflow1
            // 
            this.numCompressOverflow1.BackColor = System.Drawing.Color.Black;
            this.numCompressOverflow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.numCompressOverflow1.DisplayText = "CMP";
            this.numCompressOverflow1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.numCompressOverflow1.Location = new System.Drawing.Point(96, 250);
            this.numCompressOverflow1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.numCompressOverflow1.Name = "numCompressOverflow1";
            this.numCompressOverflow1.Size = new System.Drawing.Size(150, 104);
            this.numCompressOverflow1.TabIndex = 6;
            this.numCompressOverflow1.Value = 0F;
            // 
            // mtmOutL
            // 
            this.mtmOutL.BackColor = System.Drawing.Color.Black;
            this.mtmOutL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mtmOutL.DisplayText = "L";
            this.mtmOutL.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.mtmOutL.Location = new System.Drawing.Point(337, 38);
            this.mtmOutL.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.mtmOutL.Name = "mtmOutL";
            this.mtmOutL.Size = new System.Drawing.Size(142, 104);
            this.mtmOutL.TabIndex = 6;
            this.mtmOutL.Value = 0F;
            // 
            // barFC
            // 
            this.barFC.BackColor = System.Drawing.Color.Black;
            this.barFC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barFC.DisplayText = "FC";
            this.barFC.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barFC.Location = new System.Drawing.Point(96, 38);
            this.barFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barFC.Name = "barFC";
            this.barFC.Size = new System.Drawing.Size(72, 49);
            this.barFC.TabIndex = 0;
            this.barFC.Value = 0F;
            // 
            // barLF
            // 
            this.barLF.BackColor = System.Drawing.Color.Black;
            this.barLF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barLF.DisplayText = "LF";
            this.barLF.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barLF.Location = new System.Drawing.Point(96, 93);
            this.barLF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barLF.Name = "barLF";
            this.barLF.Size = new System.Drawing.Size(72, 49);
            this.barLF.TabIndex = 0;
            this.barLF.Value = 0F;
            // 
            // barRL
            // 
            this.barRL.BackColor = System.Drawing.Color.Black;
            this.barRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barRL.DisplayText = "RL";
            this.barRL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barRL.Location = new System.Drawing.Point(252, 38);
            this.barRL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barRL.Name = "barRL";
            this.barRL.Size = new System.Drawing.Size(72, 49);
            this.barRL.TabIndex = 0;
            this.barRL.Value = 0F;
            // 
            // barSL
            // 
            this.barSL.BackColor = System.Drawing.Color.Black;
            this.barSL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barSL.DisplayText = "SL";
            this.barSL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barSL.Location = new System.Drawing.Point(174, 38);
            this.barSL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.barRR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barRR.Location = new System.Drawing.Point(252, 93);
            this.barRR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barRR.Name = "barRR";
            this.barRR.Size = new System.Drawing.Size(72, 49);
            this.barRR.TabIndex = 0;
            this.barRR.Value = 0F;
            // 
            // barSR
            // 
            this.barSR.BackColor = System.Drawing.Color.Black;
            this.barSR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barSR.DisplayText = "SR";
            this.barSR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.barSR.Location = new System.Drawing.Point(174, 93);
            this.barSR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barSR.Name = "barSR";
            this.barSR.Size = new System.Drawing.Size(72, 49);
            this.barSR.TabIndex = 0;
            this.barSR.Value = 0F;
            // 
            // posShow
            // 
            this.posShow.AutoSize = true;
            this.posShow.ForeColor = System.Drawing.Color.Black;
            this.posShow.Location = new System.Drawing.Point(164, 106);
            this.posShow.Name = "posShow";
            this.posShow.Size = new System.Drawing.Size(41, 12);
            this.posShow.TabIndex = 12;
            this.posShow.Text = "114514";
            this.posShow.Visible = false;
            // 
            // posHide
            // 
            this.posHide.AutoSize = true;
            this.posHide.Location = new System.Drawing.Point(830, -2);
            this.posHide.Name = "posHide";
            this.posHide.Size = new System.Drawing.Size(41, 12);
            this.posHide.TabIndex = 13;
            this.posHide.Text = "label7";
            // 
            // panelPage2
            // 
            this.panelPage2.BackColor = System.Drawing.Color.Transparent;
            this.panelPage2.Controls.Add(this.lblConvolver);
            this.panelPage2.Controls.Add(this.btnResetConvolver);
            this.panelPage2.Controls.Add(this.btnSwitchConvolver);
            this.panelPage2.Controls.Add(this.numCompressRelease);
            this.panelPage2.Controls.Add(this.numCompressAttack);
            this.panelPage2.Controls.Add(this.numCompressRatio);
            this.panelPage2.Controls.Add(this.numCompressGate);
            this.panelPage2.Controls.Add(this.label12);
            this.panelPage2.Controls.Add(this.label10);
            this.panelPage2.Controls.Add(this.label9);
            this.panelPage2.Controls.Add(this.label8);
            this.panelPage2.Controls.Add(this.label13);
            this.panelPage2.Controls.Add(this.label7);
            this.panelPage2.Location = new System.Drawing.Point(832, 106);
            this.panelPage2.Name = "panelPage2";
            this.panelPage2.Size = new System.Drawing.Size(647, 394);
            this.panelPage2.TabIndex = 14;
            // 
            // lblConvolver
            // 
            this.lblConvolver.Location = new System.Drawing.Point(109, 235);
            this.lblConvolver.Name = "lblConvolver";
            this.lblConvolver.Size = new System.Drawing.Size(533, 25);
            this.lblConvolver.TabIndex = 12;
            this.lblConvolver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetConvolver
            // 
            this.btnResetConvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetConvolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetConvolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnResetConvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetConvolver.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnResetConvolver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetConvolver.Location = new System.Drawing.Point(210, 272);
            this.btnResetConvolver.Name = "btnResetConvolver";
            this.btnResetConvolver.Size = new System.Drawing.Size(96, 32);
            this.btnResetConvolver.TabIndex = 9;
            this.btnResetConvolver.Text = "恢复默认";
            this.btnResetConvolver.UseVisualStyleBackColor = true;
            this.btnResetConvolver.Click += new System.EventHandler(this.btnResetConvolver_Click);
            // 
            // numCompressRelease
            // 
            this.numCompressRelease.BackColor = System.Drawing.Color.Black;
            this.numCompressRelease.BigStep = 5;
            this.numCompressRelease.Location = new System.Drawing.Point(112, 188);
            this.numCompressRelease.Max = 4000;
            this.numCompressRelease.Min = 0;
            this.numCompressRelease.Name = "numCompressRelease";
            this.numCompressRelease.Size = new System.Drawing.Size(507, 25);
            this.numCompressRelease.SmallStep = 3;
            this.numCompressRelease.TabIndex = 11;
            this.numCompressRelease.ThumbText = "3200ms";
            this.numCompressRelease.ThumbWidth = 80;
            this.numCompressRelease.Value = 3200;
            this.numCompressRelease.ValueChanged += new System.EventHandler<System.EventArgs>(this.numCompress_ValueChanged);
            // 
            // numCompressAttack
            // 
            this.numCompressAttack.BackColor = System.Drawing.Color.Black;
            this.numCompressAttack.BigStep = 5;
            this.numCompressAttack.Location = new System.Drawing.Point(112, 142);
            this.numCompressAttack.Max = 200;
            this.numCompressAttack.Min = 0;
            this.numCompressAttack.Name = "numCompressAttack";
            this.numCompressAttack.Size = new System.Drawing.Size(507, 25);
            this.numCompressAttack.SmallStep = 3;
            this.numCompressAttack.TabIndex = 11;
            this.numCompressAttack.ThumbText = "144ms";
            this.numCompressAttack.ThumbWidth = 80;
            this.numCompressAttack.Value = 144;
            this.numCompressAttack.ValueChanged += new System.EventHandler<System.EventArgs>(this.numCompress_ValueChanged);
            // 
            // numCompressRatio
            // 
            this.numCompressRatio.BackColor = System.Drawing.Color.Black;
            this.numCompressRatio.BigStep = 5;
            this.numCompressRatio.Location = new System.Drawing.Point(112, 96);
            this.numCompressRatio.Max = 800;
            this.numCompressRatio.Min = 0;
            this.numCompressRatio.Name = "numCompressRatio";
            this.numCompressRatio.Size = new System.Drawing.Size(507, 25);
            this.numCompressRatio.SmallStep = 3;
            this.numCompressRatio.TabIndex = 11;
            this.numCompressRatio.ThumbText = "30:1";
            this.numCompressRatio.ThumbWidth = 80;
            this.numCompressRatio.Value = 310;
            this.numCompressRatio.ValueChanged += new System.EventHandler<System.EventArgs>(this.numCompress_ValueChanged);
            // 
            // numCompressGate
            // 
            this.numCompressGate.BackColor = System.Drawing.Color.Black;
            this.numCompressGate.BigStep = 5;
            this.numCompressGate.Location = new System.Drawing.Point(112, 50);
            this.numCompressGate.Max = 0;
            this.numCompressGate.Min = -200;
            this.numCompressGate.Name = "numCompressGate";
            this.numCompressGate.Size = new System.Drawing.Size(507, 25);
            this.numCompressGate.SmallStep = 3;
            this.numCompressGate.TabIndex = 11;
            this.numCompressGate.ThumbText = "0.0 dB";
            this.numCompressGate.ThumbWidth = 80;
            this.numCompressGate.Value = 0;
            this.numCompressGate.ValueChanged += new System.EventHandler<System.EventArgs>(this.numCompress_ValueChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(15, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 25);
            this.label12.TabIndex = 3;
            this.label12.Text = "释放时间";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(15, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "启动时间";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "压缩比";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(15, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 25);
            this.label8.TabIndex = 3;
            this.label8.Text = "噪音门限";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(15, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 25);
            this.label13.TabIndex = 2;
            this.label13.Text = "卷积器";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "压缩器";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPage3
            // 
            this.panelPage3.BackColor = System.Drawing.Color.Transparent;
            this.panelPage3.Controls.Add(this.btnEnchanceAudio_);
            this.panelPage3.Controls.Add(this.button2);
            this.panelPage3.Controls.Add(this.btnHelp);
            this.panelPage3.Controls.Add(this.chkShowAllDevice);
            this.panelPage3.Controls.Add(this.chkLowLancey);
            this.panelPage3.Controls.Add(this.cmbSrc);
            this.panelPage3.Controls.Add(this.label28);
            this.panelPage3.Controls.Add(this.label2);
            this.panelPage3.Controls.Add(this.label1);
            this.panelPage3.Controls.Add(this.label15);
            this.panelPage3.Controls.Add(this.label14);
            this.panelPage3.Controls.Add(this.cmbDst);
            this.panelPage3.Location = new System.Drawing.Point(166, 515);
            this.panelPage3.Name = "panelPage3";
            this.panelPage3.Size = new System.Drawing.Size(647, 394);
            this.panelPage3.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.button2.Location = new System.Drawing.Point(453, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "重新扫描设备";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(13, 172);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 25);
            this.label28.TabIndex = 7;
            this.label28.Text = "实验选项";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "虚拟设备";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "低延迟";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(15, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 25);
            this.label15.TabIndex = 7;
            this.label15.Text = "输出设备";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(15, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 25);
            this.label14.TabIndex = 6;
            this.label14.Text = "设备选择";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPage4
            // 
            this.panelPage4.BackColor = System.Drawing.Color.Transparent;
            this.panelPage4.Controls.Add(this.label16);
            this.panelPage4.Controls.Add(this.label20);
            this.panelPage4.Controls.Add(this.label19);
            this.panelPage4.Controls.Add(this.label31);
            this.panelPage4.Controls.Add(this.label18);
            this.panelPage4.Controls.Add(this.label27);
            this.panelPage4.Controls.Add(this.label26);
            this.panelPage4.Controls.Add(this.label25);
            this.panelPage4.Controls.Add(this.label24);
            this.panelPage4.Controls.Add(this.label30);
            this.panelPage4.Controls.Add(this.label29);
            this.panelPage4.Controls.Add(this.label32);
            this.panelPage4.Controls.Add(this.lblVersion);
            this.panelPage4.Controls.Add(this.label23);
            this.panelPage4.Controls.Add(this.label22);
            this.panelPage4.Controls.Add(this.label21);
            this.panelPage4.Controls.Add(this.label17);
            this.panelPage4.Location = new System.Drawing.Point(832, 515);
            this.panelPage4.Name = "panelPage4";
            this.panelPage4.Size = new System.Drawing.Size(647, 394);
            this.panelPage4.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(15, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(194, 25);
            this.label16.TabIndex = 7;
            this.label16.Text = "关于耳机虚拟环绕声";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(15, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 25);
            this.label20.TabIndex = 7;
            this.label20.Text = "第三方库";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(15, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 25);
            this.label19.TabIndex = 7;
            this.label19.Text = "主页";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(15, 88);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 25);
            this.label31.TabIndex = 7;
            this.label31.Text = "版本";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(15, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 25);
            this.label18.TabIndex = 7;
            this.label18.Text = "源代码";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label27.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(118, 275);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(136, 25);
            this.label27.TabIndex = 7;
            this.label27.Tag = "https://github.com/File-New-Project/EarTrumpet";
            this.label27.Text = "EarTrumpet";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label27.Click += new System.EventHandler(this.aboutClick);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label26.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(118, 250);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 25);
            this.label26.TabIndex = 7;
            this.label26.Tag = "https://github.com/naudio/NAudio";
            this.label26.Text = "NAudio";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label26.Click += new System.EventHandler(this.aboutClick);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label25.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(118, 225);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(136, 25);
            this.label25.TabIndex = 7;
            this.label25.Tag = "https://github.com/HiFi-LoFi/FFTConvolver";
            this.label25.Text = "FFTConvolver";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.Click += new System.EventHandler(this.aboutClick);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label24.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(118, 200);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(216, 25);
            this.label24.TabIndex = 7;
            this.label24.Tag = "https://sourceforge.net/projects/hesuvi/";
            this.label24.Text = "HeSuVi (脉冲响应样本)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label24.Click += new System.EventHandler(this.aboutClick);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label30.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(312, 160);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(116, 25);
            this.label30.TabIndex = 7;
            this.label30.Tag = "https://gitee.com/ZYFDroid/";
            this.label30.Text = "码云Gitee";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label30.Click += new System.EventHandler(this.aboutClick);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label29.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(215, 160);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(91, 25);
            this.label29.TabIndex = 7;
            this.label29.Tag = "https://github.com/ZYFDroid";
            this.label29.Text = "Github";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label29.Click += new System.EventHandler(this.aboutClick);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label32.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(215, 87);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(241, 25);
            this.label32.TabIndex = 7;
            this.label32.Tag = "https://zyfdroid.lanzoul.com/b065zrvte";
            this.label32.Text = "新版下载（提取码:5fpu）";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label32.Click += new System.EventHandler(this.aboutClick);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(118, 88);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(91, 25);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Tag = "https://gitee.com/ZYFDroid/SimpleHeadphoneSurroundVirtualization";
            this.lblVersion.Text = "网页链接";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label23.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(118, 160);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 25);
            this.label23.TabIndex = 7;
            this.label23.Tag = "https://space.bilibili.com/10927769";
            this.label23.Text = "B站主页";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label23.Click += new System.EventHandler(this.aboutClick);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label22.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(118, 123);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 25);
            this.label22.TabIndex = 7;
            this.label22.Tag = "https://gitee.com/ZYFDroid/SimpleHeadphoneSurroundVirtualization";
            this.label22.Text = "网页链接";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label22.Click += new System.EventHandler(this.aboutClick);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label21.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(118, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 25);
            this.label21.TabIndex = 7;
            this.label21.Tag = "https://github.com/ZYFDroid";
            this.label21.Text = "ZYFDroid";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Click += new System.EventHandler(this.aboutClick);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(15, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 25);
            this.label17.TabIndex = 7;
            this.label17.Text = "作者";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Wave文件|*.wav";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(540, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 35);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "已关闭";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updateDeviceCountdownTimer
            // 
            this.updateDeviceCountdownTimer.Tick += new System.EventHandler(this.updateDeviceCountdownTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::耳机虚拟环绕声.Properties.Resources.bg_hesuvi2;
            this.ClientSize = new System.Drawing.Size(1486, 934);
            this.Controls.Add(this.panelPage4);
            this.Controls.Add(this.panelPage3);
            this.Controls.Add(this.panelPage2);
            this.Controls.Add(this.posHide);
            this.Controls.Add(this.panelPage1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.posShow);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.dragger);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "耳机虚拟环绕声";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragger)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelPage1.ResumeLayout(false);
            this.panelPage2.ResumeLayout(false);
            this.panelPage3.ResumeLayout(false);
            this.panelPage3.PerformLayout();
            this.panelPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbSrc;
        private System.Windows.Forms.ComboBox cmbDst;
        private System.Windows.Forms.Button btnBegin;
        private System.ComponentModel.BackgroundWorker surroundProc;
        private MP3模拟器.CtlBarMeter mtmOutR;
        private MP3模拟器.CtlBarMeter mtmOutL;
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
        private System.Windows.Forms.Panel panelPage1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label posShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CtlBarSlider numMasterGain;
        private System.Windows.Forms.Label label6;
        private MP3模拟器.CtlBarMeter numCompressOverflow1;
        private System.Windows.Forms.Label posHide;
        private System.Windows.Forms.Panel panelPage2;
        private CtlBarSlider numCompressRelease;
        private CtlBarSlider numCompressAttack;
        private CtlBarSlider numCompressRatio;
        private CtlBarSlider numCompressGate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelPage3;
        private System.Windows.Forms.Panel panelPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnEnchanceAudio_;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSwitchConvolver;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox chkFc2F;
        private System.Windows.Forms.Button btnResetConvolver;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblConvolver;
        private System.Windows.Forms.CheckBox chkShowAllDevice;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEnchanceAudio;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer updateDeviceCountdownTimer;
    }
}

