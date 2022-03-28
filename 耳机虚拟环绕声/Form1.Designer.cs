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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSrc = new System.Windows.Forms.ComboBox();
            this.cmbDst = new System.Windows.Forms.ComboBox();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.Button();
            this.surroundProc = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择你的虚拟环绕声设备（一般叫VB CABLE)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择你的耳机";
            // 
            // cmbSrc
            // 
            this.cmbSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrc.FormattingEnabled = true;
            this.cmbSrc.Location = new System.Drawing.Point(14, 55);
            this.cmbSrc.Name = "cmbSrc";
            this.cmbSrc.Size = new System.Drawing.Size(370, 20);
            this.cmbSrc.TabIndex = 1;
            // 
            // cmbDst
            // 
            this.cmbDst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDst.FormattingEnabled = true;
            this.cmbDst.Location = new System.Drawing.Point(14, 119);
            this.cmbDst.Name = "cmbDst";
            this.cmbDst.Size = new System.Drawing.Size(370, 20);
            this.cmbDst.TabIndex = 1;
            // 
            // lblIndicator
            // 
            this.lblIndicator.Location = new System.Drawing.Point(14, 143);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(370, 23);
            this.lblIndicator.TabIndex = 3;
            this.lblIndicator.Text = "现在你非常环绕！";
            this.lblIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIndicator.Visible = false;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(22, 169);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(351, 71);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.Text = "开始环绕";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // surroundProc
            // 
            this.surroundProc.WorkerReportsProgress = true;
            this.surroundProc.WorkerSupportsCancellation = true;
            this.surroundProc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.surroundProc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.surroundProc_ProgressChanged);
            this.surroundProc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.surroundProc_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 252);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.cmbDst);
            this.Controls.Add(this.cmbSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "耳机虚拟环绕声";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSrc;
        private System.Windows.Forms.ComboBox cmbDst;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Button btnBegin;
        private System.ComponentModel.BackgroundWorker surroundProc;
    }
}

