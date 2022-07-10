namespace 耳机虚拟环绕声
{
    partial class FrmConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOnekeyConfig = new System.Windows.Forms.Button();
            this.btnConfigByHand = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblConfigStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "配置虚拟环绕设备";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(559, 1);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "第 1 步： 下载安装 VB-Cable";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(291, 91);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(70, 25);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Tag = "https://vb-audio.com/Cable/";
            this.lblVersion.Text = "官网";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.Click += new System.EventHandler(this.lnk_click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Underline);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(350, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 25);
            this.label4.TabIndex = 8;
            this.label4.Tag = "https://zyfdroid.lanzoul.com/b065zrvte";
            this.label4.Text = "网盘（提取码5fpu）";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.lnk_click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 113);
            this.label5.TabIndex = 9;
            this.label5.Text = "如何安装：\r\n1. 解压下载的压缩包\r\n2. 以管理员权限运行Setup64.exe\r\n（32位的系统你也用不了这个软件）\r\n3. 点击Install Drive" +
    "r";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(15, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(299, 35);
            this.label6.TabIndex = 3;
            this.label6.Text = "第 2 步： 配置环绕声";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOnekeyConfig
            // 
            this.btnOnekeyConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOnekeyConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOnekeyConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnOnekeyConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnekeyConfig.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOnekeyConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOnekeyConfig.Location = new System.Drawing.Point(374, 267);
            this.btnOnekeyConfig.Name = "btnOnekeyConfig";
            this.btnOnekeyConfig.Size = new System.Drawing.Size(193, 32);
            this.btnOnekeyConfig.TabIndex = 11;
            this.btnOnekeyConfig.Text = "打开音频控制面板";
            this.btnOnekeyConfig.UseVisualStyleBackColor = true;
            this.btnOnekeyConfig.Click += new System.EventHandler(this.btnOnekeyConfig_Click);
            // 
            // btnConfigByHand
            // 
            this.btnConfigByHand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigByHand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfigByHand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnConfigByHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigByHand.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConfigByHand.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConfigByHand.Location = new System.Drawing.Point(374, 421);
            this.btnConfigByHand.Name = "btnConfigByHand";
            this.btnConfigByHand.Size = new System.Drawing.Size(193, 50);
            this.btnConfigByHand.TabIndex = 11;
            this.btnConfigByHand.Text = "检查配置状态";
            this.btnConfigByHand.UseVisualStyleBackColor = true;
            this.btnConfigByHand.Click += new System.EventHandler(this.btnConfigByHand_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "第 1 步";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "第 2 步";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfigStatus
            // 
            this.lblConfigStatus.Font = new System.Drawing.Font("微软雅黑 Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigStatus.Location = new System.Drawing.Point(15, 428);
            this.lblConfigStatus.Name = "lblConfigStatus";
            this.lblConfigStatus.Size = new System.Drawing.Size(358, 35);
            this.lblConfigStatus.TabIndex = 3;
            this.lblConfigStatus.Text = "当前状态：--";
            this.lblConfigStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(16, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(357, 113);
            this.label9.TabIndex = 9;
            this.label9.Text = "1. 打开音频控制面板\r\n2. 找到「Cable Input」\r\n3. 右键选择「配置扬声器」\r\n4. 选择「7.1环绕」，然后一路下一步";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(579, 481);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnConfigByHand);
            this.Controls.Add(this.btnOnekeyConfig);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblConfigStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置向导";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOnekeyConfig;
        private System.Windows.Forms.Button btnConfigByHand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblConfigStatus;
        private System.Windows.Forms.Label label9;
    }
}