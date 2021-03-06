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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblChartContainer = new System.Windows.Forms.Panel();
            this.ctlEqView = new 耳机虚拟环绕声.CtlEQView();
            this.label1 = new System.Windows.Forms.Label();
            this.numFC = new System.Windows.Forms.NumericUpDown();
            this.numDBGain = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tblChartContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDBGain)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tblChartContainer);
            this.panel1.Location = new System.Drawing.Point(25, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 484);
            this.panel1.TabIndex = 0;
            // 
            // tblChartContainer
            // 
            this.tblChartContainer.Controls.Add(this.ctlEqView);
            this.tblChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChartContainer.Location = new System.Drawing.Point(0, 0);
            this.tblChartContainer.Name = "tblChartContainer";
            this.tblChartContainer.Size = new System.Drawing.Size(597, 480);
            this.tblChartContainer.TabIndex = 0;
            // 
            // ctlEqView
            // 
            this.ctlEqView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlEqView.Location = new System.Drawing.Point(0, 0);
            this.ctlEqView.Margin = new System.Windows.Forms.Padding(5);
            this.ctlEqView.Name = "ctlEqView";
            this.ctlEqView.Size = new System.Drawing.Size(597, 480);
            this.ctlEqView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(632, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "中心频率（Hz）";
            // 
            // numFC
            // 
            this.numFC.DecimalPlaces = 1;
            this.numFC.Location = new System.Drawing.Point(3, 3);
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
            this.numDBGain.Location = new System.Drawing.Point(3, 62);
            this.numDBGain.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numDBGain.Minimum = new decimal(new int[] {
            15,
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
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(637, 194);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(202, 35);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "添加";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemove.Location = new System.Drawing.Point(4, 97);
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
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(636, 462);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(203, 46);
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
            this.panel2.Location = new System.Drawing.Point(633, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 138);
            this.panel2.TabIndex = 15;
            // 
            // FrmParamEQ
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(860, 531);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmParamEQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "频响曲线校正 - FIR图形均衡器";
            this.Load += new System.EventHandler(this.FrmParamEQ_Load);
            this.panel1.ResumeLayout(false);
            this.tblChartContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDBGain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel tblChartContainer;
        private CtlEQView ctlEqView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFC;
        private System.Windows.Forms.NumericUpDown numDBGain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel2;
    }
}