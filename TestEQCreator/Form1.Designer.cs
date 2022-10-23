namespace TestEQCreator
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
            this.ctlBarSlider1 = new 耳机虚拟环绕声.CtlBarSlider();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelOuterContainer = new System.Windows.Forms.Panel();
            this.tblChartContainer = new System.Windows.Forms.Panel();
            this.ctlEqView = new 耳机虚拟环绕声.CtlEQView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numFC = new System.Windows.Forms.NumericUpDown();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numDBGain = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelOuterContainer.SuspendLayout();
            this.tblChartContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDBGain)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlBarSlider1
            // 
            this.ctlBarSlider1.BackColor = System.Drawing.Color.Black;
            this.ctlBarSlider1.BigStep = 5;
            this.ctlBarSlider1.Location = new System.Drawing.Point(12, 530);
            this.ctlBarSlider1.Max = 10000;
            this.ctlBarSlider1.Min = 0;
            this.ctlBarSlider1.Name = "ctlBarSlider1";
            this.ctlBarSlider1.Size = new System.Drawing.Size(842, 30);
            this.ctlBarSlider1.SmallStep = 3;
            this.ctlBarSlider1.TabIndex = 0;
            this.ctlBarSlider1.ThumbText = "500 Hz";
            this.ctlBarSlider1.ThumbWidth = 65;
            this.ctlBarSlider1.Value = 500;
            this.ctlBarSlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.ctlBarSlider1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 72);
            this.button1.TabIndex = 1;
            this.button1.Text = "播放";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(390, 452);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 72);
            this.button2.TabIndex = 1;
            this.button2.Text = "停止";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 426);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelOuterContainer);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(842, 426);
            this.panel3.TabIndex = 17;
            // 
            // panelOuterContainer
            // 
            this.panelOuterContainer.BackColor = System.Drawing.Color.Black;
            this.panelOuterContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOuterContainer.Controls.Add(this.tblChartContainer);
            this.panelOuterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuterContainer.Location = new System.Drawing.Point(0, 0);
            this.panelOuterContainer.Name = "panelOuterContainer";
            this.panelOuterContainer.Size = new System.Drawing.Size(680, 426);
            this.panelOuterContainer.TabIndex = 0;
            // 
            // tblChartContainer
            // 
            this.tblChartContainer.Controls.Add(this.ctlEqView);
            this.tblChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChartContainer.Location = new System.Drawing.Point(0, 0);
            this.tblChartContainer.Name = "tblChartContainer";
            this.tblChartContainer.Size = new System.Drawing.Size(676, 422);
            this.tblChartContainer.TabIndex = 0;
            // 
            // ctlEqView
            // 
            this.ctlEqView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlEqView.Location = new System.Drawing.Point(0, 0);
            this.ctlEqView.Margin = new System.Windows.Forms.Padding(37, 49, 37, 49);
            this.ctlEqView.Name = "ctlEqView";
            this.ctlEqView.Size = new System.Drawing.Size(676, 422);
            this.ctlEqView.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(680, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4, 0, 11, 0);
            this.panel4.Size = new System.Drawing.Size(162, 426);
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
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(4, 159);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(147, 35);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "添加";
            this.btnNew.UseVisualStyleBackColor = true;
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
            this.panel2.Size = new System.Drawing.Size(147, 138);
            this.panel2.TabIndex = 15;
            // 
            // numFC
            // 
            this.numFC.DecimalPlaces = 1;
            this.numFC.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.numFC.Size = new System.Drawing.Size(147, 29);
            this.numFC.TabIndex = 13;
            this.numFC.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemove.Location = new System.Drawing.Point(0, 97);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(147, 35);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(-1, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "增益（dB）";
            // 
            // numDBGain
            // 
            this.numDBGain.DecimalPlaces = 2;
            this.numDBGain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.numDBGain.Size = new System.Drawing.Size(147, 29);
            this.numDBGain.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "中心频率（Hz）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(866, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctlBarSlider1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "频响曲线辅助工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelOuterContainer.ResumeLayout(false);
            this.tblChartContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDBGain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private 耳机虚拟环绕声.CtlBarSlider ctlBarSlider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelOuterContainer;
        private System.Windows.Forms.Panel tblChartContainer;
        private 耳机虚拟环绕声.CtlEQView ctlEqView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numFC;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDBGain;
        private System.Windows.Forms.Label label1;
    }
}

