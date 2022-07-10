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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ctlBarSlider2 = new 耳机虚拟环绕声.CtlBarSlider();
            this.ctlBarSlider1 = new 耳机虚拟环绕声.CtlBarSlider();
            this.ctlEQView1 = new 耳机虚拟环绕声.CtlEQView();
            this.ctlBarSlider3 = new 耳机虚拟环绕声.CtlBarSlider();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "生成频率规范";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(185, 491);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "输出EAPO配置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ctlBarSlider2
            // 
            this.ctlBarSlider2.BackColor = System.Drawing.Color.Black;
            this.ctlBarSlider2.BigStep = 5;
            this.ctlBarSlider2.Location = new System.Drawing.Point(83, 386);
            this.ctlBarSlider2.Max = 1500;
            this.ctlBarSlider2.Min = -1500;
            this.ctlBarSlider2.Name = "ctlBarSlider2";
            this.ctlBarSlider2.Size = new System.Drawing.Size(616, 30);
            this.ctlBarSlider2.SmallStep = 3;
            this.ctlBarSlider2.TabIndex = 5;
            this.ctlBarSlider2.ThumbText = "0.0 dB";
            this.ctlBarSlider2.ThumbWidth = 65;
            this.ctlBarSlider2.Value = 0;
            this.ctlBarSlider2.ValueChanged += new System.EventHandler<System.EventArgs>(this.ctlBarSlider2_ValueChanged);
            // 
            // ctlBarSlider1
            // 
            this.ctlBarSlider1.BackColor = System.Drawing.Color.Black;
            this.ctlBarSlider1.BigStep = 5;
            this.ctlBarSlider1.Location = new System.Drawing.Point(83, 349);
            this.ctlBarSlider1.Max = 19;
            this.ctlBarSlider1.Min = 0;
            this.ctlBarSlider1.Name = "ctlBarSlider1";
            this.ctlBarSlider1.Size = new System.Drawing.Size(616, 30);
            this.ctlBarSlider1.SmallStep = 3;
            this.ctlBarSlider1.TabIndex = 4;
            this.ctlBarSlider1.ThumbText = "551 Hz";
            this.ctlBarSlider1.ThumbWidth = 65;
            this.ctlBarSlider1.Value = 7;
            this.ctlBarSlider1.ValueChanged += new System.EventHandler<System.EventArgs>(this.ctlBarSlider1_Load);
            // 
            // ctlEQView1
            // 
            this.ctlEQView1.Location = new System.Drawing.Point(83, 37);
            this.ctlEQView1.Name = "ctlEQView1";
            this.ctlEQView1.Size = new System.Drawing.Size(616, 305);
            this.ctlEQView1.TabIndex = 1;
            // 
            // ctlBarSlider3
            // 
            this.ctlBarSlider3.BackColor = System.Drawing.Color.Black;
            this.ctlBarSlider3.BigStep = 5;
            this.ctlBarSlider3.Location = new System.Drawing.Point(83, 422);
            this.ctlBarSlider3.Max = 0;
            this.ctlBarSlider3.Min = -7000;
            this.ctlBarSlider3.Name = "ctlBarSlider3";
            this.ctlBarSlider3.Size = new System.Drawing.Size(616, 30);
            this.ctlBarSlider3.SmallStep = 3;
            this.ctlBarSlider3.TabIndex = 6;
            this.ctlBarSlider3.ThumbText = "0.0 dB";
            this.ctlBarSlider3.ThumbWidth = 65;
            this.ctlBarSlider3.Value = 0;
            this.ctlBarSlider3.ValueChanged += new System.EventHandler<System.EventArgs>(this.ctlBarSlider3_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(866, 572);
            this.Controls.Add(this.ctlBarSlider3);
            this.Controls.Add(this.ctlBarSlider2);
            this.Controls.Add(this.ctlBarSlider1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ctlEQView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private 耳机虚拟环绕声.CtlEQView ctlEQView1;
        private System.Windows.Forms.Button button2;
        private 耳机虚拟环绕声.CtlBarSlider ctlBarSlider1;
        private 耳机虚拟环绕声.CtlBarSlider ctlBarSlider2;
        private 耳机虚拟环绕声.CtlBarSlider ctlBarSlider3;
    }
}

