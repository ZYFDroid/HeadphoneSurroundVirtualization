namespace 耳机虚拟环绕声
{
    partial class CtlBarSlider
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panWidth = new System.Windows.Forms.Panel();
            this.btnDragger = new System.Windows.Forms.Button();
            this.panWidth.SuspendLayout();
            this.SuspendLayout();
            // 
            // panWidth
            // 
            this.panWidth.Controls.Add(this.btnDragger);
            this.panWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.panWidth.Location = new System.Drawing.Point(0, 0);
            this.panWidth.Name = "panWidth";
            this.panWidth.Size = new System.Drawing.Size(150, 30);
            this.panWidth.TabIndex = 0;
            this.panWidth.Click += new System.EventHandler(this.panWidth_Click);
            this.panWidth.Paint += new System.Windows.Forms.PaintEventHandler(this.CtlBarSlider_Paint);
            // 
            // btnDragger
            // 
            this.btnDragger.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDragger.FlatAppearance.BorderSize = 2;
            this.btnDragger.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDragger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDragger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDragger.ForeColor = System.Drawing.Color.White;
            this.btnDragger.Location = new System.Drawing.Point(85, 0);
            this.btnDragger.Name = "btnDragger";
            this.btnDragger.Size = new System.Drawing.Size(65, 30);
            this.btnDragger.TabIndex = 0;
            this.btnDragger.Text = "0.0 dB";
            this.btnDragger.UseVisualStyleBackColor = true;
            this.btnDragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDragger_MouseDown);
            this.btnDragger.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDragger_MouseMove);
            this.btnDragger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDragger_MouseUp);
            // 
            // CtlBarSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panWidth);
            this.Name = "CtlBarSlider";
            this.Size = new System.Drawing.Size(474, 30);
            this.Load += new System.EventHandler(this.CtlBarSlider_Load);
            this.Click += new System.EventHandler(this.CtlBarSlider_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CtlBarSlider_Paint);
            this.panWidth.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panWidth;
        private System.Windows.Forms.Button btnDragger;
    }
}
