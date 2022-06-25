namespace 耳机虚拟环绕声
{
    partial class FrmEQManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tblData = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnCreateByGuide = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkSwapChannel = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkInvertChannel = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditEQ = new System.Windows.Forms.Button();
            this.tblParam = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chtEq = new 耳机虚拟环绕声.CtlEQView();
            this.numBalance = new 耳机虚拟环绕声.CtlBarSlider();
            this.btnApply = new System.Windows.Forms.Button();
            this.numAntiCrossfeed = new 耳机虚拟环绕声.CtlBarSlider();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
            this.tblParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 1);
            this.label2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "音频增强";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(24, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 25);
            this.label11.TabIndex = 5;
            this.label11.Text = "配置文件";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblData
            // 
            this.tblData.AllowUserToAddRows = false;
            this.tblData.AllowUserToDeleteRows = false;
            this.tblData.AllowUserToResizeColumns = false;
            this.tblData.AllowUserToResizeRows = false;
            this.tblData.BackgroundColor = System.Drawing.Color.Black;
            this.tblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblData.CausesValidation = false;
            this.tblData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tblData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.tblData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblData.ColumnHeadersHeight = 40;
            this.tblData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tblData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblData.DefaultCellStyle = dataGridViewCellStyle4;
            this.tblData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tblData.EnableHeadersVisualStyles = false;
            this.tblData.GridColor = System.Drawing.Color.Black;
            this.tblData.Location = new System.Drawing.Point(20, 123);
            this.tblData.MultiSelect = false;
            this.tblData.Name = "tblData";
            this.tblData.ReadOnly = true;
            this.tblData.RowHeadersVisible = false;
            this.tblData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tblData.RowTemplate.Height = 40;
            this.tblData.Size = new System.Drawing.Size(574, 456);
            this.tblData.TabIndex = 6;
            this.tblData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblData_CellClick);
            this.tblData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblData_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "配置文件名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.ActiveLinkColor = System.Drawing.Color.LightGray;
            this.Column4.FillWeight = 54F;
            this.Column4.HeaderText = "";
            this.Column4.LinkColor = System.Drawing.Color.White;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.VisitedLinkColor = System.Drawing.Color.White;
            this.Column4.Width = 54;
            // 
            // Column5
            // 
            this.Column5.ActiveLinkColor = System.Drawing.Color.LightGray;
            this.Column5.FillWeight = 54F;
            this.Column5.HeaderText = "";
            this.Column5.LinkColor = System.Drawing.Color.White;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.VisitedLinkColor = System.Drawing.Color.White;
            this.Column5.Width = 54;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(608, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "详情";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreateNew.FlatAppearance.BorderSize = 0;
            this.btnCreateNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnCreateNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNew.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnCreateNew.ForeColor = System.Drawing.Color.Silver;
            this.btnCreateNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreateNew.Location = new System.Drawing.Point(357, 79);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(101, 32);
            this.btnCreateNew.TabIndex = 10;
            this.btnCreateNew.Text = "手动创建";
            this.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // btnCreateByGuide
            // 
            this.btnCreateByGuide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateByGuide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateByGuide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnCreateByGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateByGuide.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnCreateByGuide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreateByGuide.Location = new System.Drawing.Point(133, 79);
            this.btnCreateByGuide.Name = "btnCreateByGuide";
            this.btnCreateByGuide.Size = new System.Drawing.Size(218, 32);
            this.btnCreateByGuide.TabIndex = 10;
            this.btnCreateByGuide.Text = "给入门用户的创建向导";
            this.btnCreateByGuide.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(211, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 32);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkSwapChannel
            // 
            this.chkSwapChannel.BackColor = System.Drawing.Color.Black;
            this.chkSwapChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSwapChannel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.chkSwapChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSwapChannel.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.chkSwapChannel.Location = new System.Drawing.Point(3, 41);
            this.chkSwapChannel.Name = "chkSwapChannel";
            this.chkSwapChannel.Size = new System.Drawing.Size(305, 28);
            this.chkSwapChannel.TabIndex = 11;
            this.chkSwapChannel.Text = "交换左右声道";
            this.toolTip1.SetToolTip(this.chkSwapChannel, "如果您使用的耳机有左右声道相反的情况，可以使用这个功能。");
            this.chkSwapChannel.UseVisualStyleBackColor = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // chkInvertChannel
            // 
            this.chkInvertChannel.BackColor = System.Drawing.Color.Black;
            this.chkInvertChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInvertChannel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.chkInvertChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertChannel.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.chkInvertChannel.Location = new System.Drawing.Point(3, 75);
            this.chkInvertChannel.Name = "chkInvertChannel";
            this.chkInvertChannel.Size = new System.Drawing.Size(305, 28);
            this.chkInvertChannel.TabIndex = 11;
            this.chkInvertChannel.Text = "反转单侧声道";
            this.toolTip1.SetToolTip(this.chkInvertChannel, "如果你感觉声场混乱，试着打开或关闭这个功能，选择你认为听起来最舒适的程度");
            this.chkInvertChannel.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 27);
            this.label10.TabIndex = 12;
            this.label10.Text = "抗串扰";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label10, "部分耳机一侧声道的音频会混入另一侧声道。");
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "平衡";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label4, "如果您的耳机一边声音大一边声音小，可以拖动这个选项直到左右音量平衡");
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "均衡器";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label5, "更改输出信号的频率响应特性\r\n");
            // 
            // btnEditEQ
            // 
            this.btnEditEQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditEQ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditEQ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEditEQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEQ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditEQ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditEQ.Location = new System.Drawing.Point(233, 179);
            this.btnEditEQ.Name = "btnEditEQ";
            this.btnEditEQ.Size = new System.Drawing.Size(79, 29);
            this.btnEditEQ.TabIndex = 10;
            this.btnEditEQ.Text = "编辑";
            this.btnEditEQ.UseVisualStyleBackColor = true;
            // 
            // tblParam
            // 
            this.tblParam.Controls.Add(this.txtName);
            this.tblParam.Controls.Add(this.chtEq);
            this.tblParam.Controls.Add(this.chkSwapChannel);
            this.tblParam.Controls.Add(this.btnEditEQ);
            this.tblParam.Controls.Add(this.numBalance);
            this.tblParam.Controls.Add(this.btnApply);
            this.tblParam.Controls.Add(this.btnSave);
            this.tblParam.Controls.Add(this.numAntiCrossfeed);
            this.tblParam.Controls.Add(this.chkInvertChannel);
            this.tblParam.Controls.Add(this.label5);
            this.tblParam.Controls.Add(this.label6);
            this.tblParam.Controls.Add(this.label10);
            this.tblParam.Controls.Add(this.label4);
            this.tblParam.Enabled = false;
            this.tblParam.Location = new System.Drawing.Point(600, 119);
            this.tblParam.Name = "tblParam";
            this.tblParam.Size = new System.Drawing.Size(318, 468);
            this.tblParam.TabIndex = 15;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Black;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtName.Location = new System.Drawing.Point(81, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 29);
            this.txtName.TabIndex = 15;
            // 
            // chtEq
            // 
            this.chtEq.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chtEq.Location = new System.Drawing.Point(7, 216);
            this.chtEq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chtEq.Name = "chtEq";
            this.chtEq.Size = new System.Drawing.Size(305, 207);
            this.chtEq.TabIndex = 14;
            // 
            // numBalance
            // 
            this.numBalance.BackColor = System.Drawing.Color.Black;
            this.numBalance.BigStep = 5;
            this.numBalance.Location = new System.Drawing.Point(81, 144);
            this.numBalance.Max = 1000;
            this.numBalance.Min = -1000;
            this.numBalance.Name = "numBalance";
            this.numBalance.Size = new System.Drawing.Size(227, 30);
            this.numBalance.SmallStep = 3;
            this.numBalance.TabIndex = 13;
            this.numBalance.ThumbText = "0";
            this.numBalance.ThumbWidth = 65;
            this.numBalance.Value = 0;
            this.numBalance.ValueChanged += new System.EventHandler<System.EventArgs>(this.numBalance_ValueChanged);
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(104, 427);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(101, 32);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numAntiCrossfeed
            // 
            this.numAntiCrossfeed.BackColor = System.Drawing.Color.Black;
            this.numAntiCrossfeed.BigStep = 5;
            this.numAntiCrossfeed.Location = new System.Drawing.Point(81, 110);
            this.numAntiCrossfeed.Max = 1000;
            this.numAntiCrossfeed.Min = -1000;
            this.numAntiCrossfeed.Name = "numAntiCrossfeed";
            this.numAntiCrossfeed.Size = new System.Drawing.Size(227, 30);
            this.numAntiCrossfeed.SmallStep = 3;
            this.numAntiCrossfeed.TabIndex = 13;
            this.numAntiCrossfeed.ThumbText = "0.0 dB";
            this.numAntiCrossfeed.ThumbWidth = 65;
            this.numAntiCrossfeed.Value = 0;
            this.numAntiCrossfeed.ValueChanged += new System.EventHandler<System.EventArgs>(this.numAntiCrossfeed_ValueChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "名称";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnImport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImport.Location = new System.Drawing.Point(522, 79);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 32);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "配置文件|*.hsvc";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "配置文件|*.hsvc";
            // 
            // FrmEQManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(940, 598);
            this.Controls.Add(this.tblParam);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCreateByGuide);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.tblData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEQManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音频增强 - 提升耳机音质";
            this.Load += new System.EventHandler(this.FrmEQManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
            this.tblParam.ResumeLayout(false);
            this.tblParam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView tblData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Button btnCreateByGuide;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkSwapChannel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkInvertChannel;
        private System.Windows.Forms.Label label10;
        private CtlBarSlider numAntiCrossfeed;
        private System.Windows.Forms.Label label4;
        private CtlBarSlider numBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditEQ;
        private System.Windows.Forms.Panel tblParam;
        private CtlEQView chtEq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}