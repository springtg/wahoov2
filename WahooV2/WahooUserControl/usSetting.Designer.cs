namespace WahooV2.WahooUserControl
{
    partial class usSetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.tabInformation = new System.Windows.Forms.TabPage();
            this.txtWsdlUrl = new System.Windows.Forms.TextBox();
            this.txtTransferSpeed = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExecuteInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDashboardRefresh = new System.Windows.Forms.TextBox();
            this.tbaRsa = new System.Windows.Forms.TabPage();
            this.tabSetting.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSetting
            // 
            this.tabSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSetting.Controls.Add(this.tabInformation);
            this.tabSetting.Controls.Add(this.tbaRsa);
            this.tabSetting.Location = new System.Drawing.Point(3, 3);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(1004, 397);
            this.tabSetting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSetting.TabIndex = 0;
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.txtWsdlUrl);
            this.tabInformation.Controls.Add(this.txtTransferSpeed);
            this.tabInformation.Controls.Add(this.btnSave);
            this.tabInformation.Controls.Add(this.label4);
            this.tabInformation.Controls.Add(this.label3);
            this.tabInformation.Controls.Add(this.txtExecuteInterval);
            this.tabInformation.Controls.Add(this.label2);
            this.tabInformation.Controls.Add(this.label1);
            this.tabInformation.Controls.Add(this.txtDashboardRefresh);
            this.tabInformation.Location = new System.Drawing.Point(4, 22);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformation.Size = new System.Drawing.Size(996, 371);
            this.tabInformation.TabIndex = 0;
            this.tabInformation.Text = "Information";
            this.tabInformation.UseVisualStyleBackColor = true;
            // 
            // txtWsdlUrl
            // 
            this.txtWsdlUrl.Location = new System.Drawing.Point(220, 129);
            this.txtWsdlUrl.Name = "txtWsdlUrl";
            this.txtWsdlUrl.Size = new System.Drawing.Size(307, 20);
            this.txtWsdlUrl.TabIndex = 7;
            // 
            // txtTransferSpeed
            // 
            this.txtTransferSpeed.Location = new System.Drawing.Point(220, 93);
            this.txtTransferSpeed.MaxLength = 6;
            this.txtTransferSpeed.Name = "txtTransferSpeed";
            this.txtTransferSpeed.Size = new System.Drawing.Size(79, 20);
            this.txtTransferSpeed.TabIndex = 6;
            this.txtTransferSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 169);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Web service address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transfer Speed(Kbps):";
            // 
            // txtExecuteInterval
            // 
            this.txtExecuteInterval.Location = new System.Drawing.Point(220, 57);
            this.txtExecuteInterval.MaxLength = 6;
            this.txtExecuteInterval.Name = "txtExecuteInterval";
            this.txtExecuteInterval.Size = new System.Drawing.Size(79, 20);
            this.txtExecuteInterval.TabIndex = 5;
            this.txtExecuteInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Execute interval (Seconds):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard refresh interval (Seconds):";
            // 
            // txtDashboardRefresh
            // 
            this.txtDashboardRefresh.Location = new System.Drawing.Point(220, 21);
            this.txtDashboardRefresh.MaxLength = 6;
            this.txtDashboardRefresh.Name = "txtDashboardRefresh";
            this.txtDashboardRefresh.Size = new System.Drawing.Size(79, 20);
            this.txtDashboardRefresh.TabIndex = 4;
            this.txtDashboardRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbaRsa
            // 
            this.tbaRsa.Location = new System.Drawing.Point(4, 22);
            this.tbaRsa.Name = "tbaRsa";
            this.tbaRsa.Padding = new System.Windows.Forms.Padding(3);
            this.tbaRsa.Size = new System.Drawing.Size(996, 371);
            this.tbaRsa.TabIndex = 1;
            this.tbaRsa.Text = "RSA";
            this.tbaRsa.UseVisualStyleBackColor = true;
            // 
            // usSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSetting);
            this.Name = "usSetting";
            this.Size = new System.Drawing.Size(1010, 690);
            this.Load += new System.EventHandler(this.usSetting_Load);
            this.tabSetting.ResumeLayout(false);
            this.tabInformation.ResumeLayout(false);
            this.tabInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tabInformation;
        private System.Windows.Forms.TabPage tbaRsa;
        private System.Windows.Forms.TextBox txtDashboardRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWsdlUrl;
        private System.Windows.Forms.TextBox txtTransferSpeed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExecuteInterval;
        private System.Windows.Forms.Label label2;
    }
}
