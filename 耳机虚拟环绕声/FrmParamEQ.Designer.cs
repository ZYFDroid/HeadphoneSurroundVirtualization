namespace 耳机虚拟环绕声
{
    partial class FrmParamEQ
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
            this.panelOuterContainer = new System.Windows.Forms.Panel();
            this.tblChartContainer = new System.Windows.Forms.Panel();
            this.ctlEqView = new 耳机虚拟环绕声.CtlEQView();
            this.mnuEqs = new System.Windows.Forms.ContextMenuStrip();
            this.mnuDist30 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.numFC = new System.Windows.Forms.NumericUpDown();
            this.numDBGain = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelOuterContainer.SuspendLayout();
            this.tblChartContainer.SuspendLayout();
            this.mnuEqs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDBGain)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOuterContainer
            // 
            this.panelOuterContainer.BackColor = System.Drawing.Color.Black;
            this.panelOuterContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOuterContainer.Controls.Add(this.tblChartContainer);
            this.panelOuterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuterContainer.Location = new System.Drawing.Point(0, 0);
            this.panelOuterContainer.Name = "panelOuterContainer";
            this.panelOuterContainer.Size = new System.Drawing.Size(684, 537);
            this.panelOuterContainer.TabIndex = 0;
            this.panelOuterContainer.SizeChanged += new System.EventHandler(this.panelOuterContainer_SizeChanged);
            this.panelOuterContainer.Resize += new System.EventHandler(this.panelOuterContainer_Resize);
            // 
            // tblChartContainer
            // 
            this.tblChartContainer.Controls.Add(this.ctlEqView);
            this.tblChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChartContainer.Location = new System.Drawing.Point(0, 0);
            this.tblChartContainer.Name = "tblChartContainer";
            this.tblChartContainer.Size = new System.Drawing.Size(680, 533);
            this.tblChartContainer.TabIndex = 0;
            // 
            // ctlEqView
            // 
            this.ctlEqView.ContextMenuStrip = this.mnuEqs;
            this.ctlEqView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlEqView.Location = new System.Drawing.Point(0, 0);
            this.ctlEqView.Margin = new System.Windows.Forms.Padding(37, 49, 37, 49);
            this.ctlEqView.Name = "ctlEqView";
            this.ctlEqView.Size = new System.Drawing.Size(680, 533);
            this.ctlEqView.TabIndex = 0;
            this.ctlEqView.SizeChanged += new System.EventHandler(this.ctlEqView_SizeChanged);
            this.ctlEqView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ctlEqView_MouseDoubleClick);
            this.ctlEqView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctlEqView_MouseDown);
            this.ctlEqView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctlEqView_MouseMove);
            this.ctlEqView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctlEqView_MouseUp);
            // 
            // mnuEqs
            // 
            this.mnuEqs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDist30,
            this.mnuInvert,
            this.mnuClearAll});
            this.mnuEqs.Name = "mnuEqs";
            this.mnuEqs.Size = new System.Drawing.Size(181, 92);
            // 
            // mnuDist30
            // 
            this.mnuDist30.Name = "mnuDist30";
            this.mnuDist30.Size = new System.Drawing.Size(180, 22);
            this.mnuDist30.Text = "一键分布30个点";
            this.mnuDist30.Click += new System.EventHandler(this.mnuDist30_Click);
            // 
            // mnuInvert
            // 
            this.mnuInvert.Name = "mnuInvert";
            this.mnuInvert.Size = new System.Drawing.Size(180, 22);
            this.mnuInvert.Text = "上下颠倒";
            this.mnuInvert.Click += new System.EventHandler(this.mnuInvert_Click);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(180, 22);
            this.mnuClearAll.Text = "清空";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "中心频率（Hz）";
            // 
            // numFC
            // 
            this.numFC.DecimalPlaces = 1;
            this.numFC.Location = new System.Drawing.Point(0, 3);
            this.numFC.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numFC.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFC.Name = "numFC";
            this.numFC.Size = new System.Drawing.Size(203, 29);
            this.numFC.TabIndex = 13;
            this.numFC.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFC.ValueChanged += new System.EventHandler(this.numFC_ValueChanged);
            // 
            // numDBGain
            // 
            this.numDBGain.DecimalPlaces = 2;
            this.numDBGain.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numDBGain.Location = new System.Drawing.Point(0, 62);
            this.numDBGain.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDBGain.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.numDBGain.Name = "numDBGain";
            this.numDBGain.Size = new System.Drawing.Size(203, 29);
            this.numDBGain.TabIndex = 13;
            this.numDBGain.ValueChanged += new System.EventHandler(this.numFC_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "增益（dB）";
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemove.Location = new System.Drawing.Point(0, 97);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(202, 35);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(4, 491);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(202, 46);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "应用";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numFC);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numDBGain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 138);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelOuterContainer);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(901, 537);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(684, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4, 0, 11, 0);
            this.panel4.Size = new System.Drawing.Size(217, 537);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(4, 194);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label3.Size = new System.Drawing.Size(131, 68);
            this.label3.TabIndex = 16;
            this.label3.Text = "* 双击图表快速添加\r\n* 鼠标中键整体拖动\r\n* 右键查看更多选项";
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(4, 159);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(202, 35);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "添加";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FrmParamEQ
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(917, 561);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(701, 452);
            this.Name = "FrmParamEQ";
            this.Padding = new System.Windows.Forms.Padding(12, 12, 4, 12);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "频响曲线校正 - FIR图形均衡器";
            this.Load += new System.EventHandler(this.FrmParamEQ_Load);
            this.panelOuterContainer.ResumeLayout(false);
            this.tblChartContainer.ResumeLayout(false);
            this.mnuEqs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDBGain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOuterContainer;
        private System.Windows.Forms.Panel tblChartContainer;
        private CtlEQView ctlEqView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFC;
        private System.Windows.Forms.NumericUpDown numDBGain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ContextMenuStrip mnuEqs;
        private System.Windows.Forms.ToolStripMenuItem mnuDist30;
        private System.Windows.Forms.ToolStripMenuItem mnuInvert;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;
    }
}