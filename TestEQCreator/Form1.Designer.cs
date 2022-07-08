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
            this.ctlEQView1 = new 耳机虚拟环绕声.CtlEQView();
            this.ctlFQ = new 耳机虚拟环绕声.CtlBarSlider();
            this.numDisplayFactor = new 耳机虚拟环绕声.CtlBarSlider();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctlEQView1
            // 
            this.ctlEQView1.Location = new System.Drawing.Point(83, 37);
            this.ctlEQView1.Name = "ctlEQView1";
            this.ctlEQView1.Size = new System.Drawing.Size(616, 305);
            this.ctlEQView1.TabIndex = 1;
            // 
            // ctlFQ
            // 
            this.ctlFQ.BackColor = System.Drawing.Color.Black;
            this.ctlFQ.BigStep = 5;
            this.ctlFQ.Location = new System.Drawing.Point(83, 386);
            this.ctlFQ.Max = 30000;
            this.ctlFQ.Min = 100;
            this.ctlFQ.Name = "ctlFQ";
            this.ctlFQ.Size = new System.Drawing.Size(616, 30);
            this.ctlFQ.SmallStep = 3;
            this.ctlFQ.TabIndex = 2;
            this.ctlFQ.ThumbText = "0.0 dB";
            this.ctlFQ.ThumbWidth = 65;
            this.ctlFQ.Value = 100;
            this.ctlFQ.ValueChanged += new System.EventHandler<System.EventArgs>(this.ctlFQ_ValueChanged);
            this.ctlFQ.Load += new System.EventHandler(this.ctlFQ_Load);
            // 
            // numDisplayFactor
            // 
            this.numDisplayFactor.BackColor = System.Drawing.Color.Black;
            this.numDisplayFactor.BigStep = 5;
            this.numDisplayFactor.Location = new System.Drawing.Point(83, 422);
            this.numDisplayFactor.Max = 30000;
            this.numDisplayFactor.Min = 100;
            this.numDisplayFactor.Name = "numDisplayFactor";
            this.numDisplayFactor.Size = new System.Drawing.Size(616, 30);
            this.numDisplayFactor.SmallStep = 3;
            this.numDisplayFactor.TabIndex = 2;
            this.numDisplayFactor.ThumbText = "0.0 dB";
            this.numDisplayFactor.ThumbWidth = 65;
            this.numDisplayFactor.Value = 100;
            this.numDisplayFactor.ValueChanged += new System.EventHandler<System.EventArgs>(this.numVD);
            this.numDisplayFactor.Load += new System.EventHandler(this.ctlFQ_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(866, 572);
            this.Controls.Add(this.numDisplayFactor);
            this.Controls.Add(this.ctlFQ);
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
        private 耳机虚拟环绕声.CtlBarSlider ctlFQ;
        private 耳机虚拟环绕声.CtlBarSlider numDisplayFactor;
    }
}

