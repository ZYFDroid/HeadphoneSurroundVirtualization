namespace MP3模拟器
{
    partial class CtlBarMeter
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
            this.mask = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mask
            // 
            this.mask.Dock = System.Windows.Forms.DockStyle.Top;
            this.mask.Location = new System.Drawing.Point(0, 0);
            this.mask.Name = "mask";
            this.mask.Size = new System.Drawing.Size(170, 231);
            this.mask.TabIndex = 1;
            // 
            // CtlBarMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.mask);
            this.DoubleBuffered = true;
            this.Name = "CtlBarMeter";
            this.Size = new System.Drawing.Size(170, 339);
            this.Load += new System.EventHandler(this.CtlBarMeter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mask;
    }
}
