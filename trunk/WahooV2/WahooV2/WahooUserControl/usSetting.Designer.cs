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
            this.txtTransferSpeed = new WahooV2.ExControl.TextBoxForNum();
            this.txtExecuteInterval = new WahooV2.ExControl.TextBoxForNum();
            this.txtDashboardRefresh = new WahooV2.ExControl.TextBoxForNum();
            this.txtWsdlUrl = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbaRsa = new System.Windows.Forms.TabPage();
            this.txtPublicKeyFile = new System.Windows.Forms.TextBox();
            this.btnCreateNewFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tabSetting.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.tbaRsa.SuspendLayout();
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
            this.tabSetting.SelectedIndexChanged += new System.EventHandler(this.tabSetting_SelectedIndexChanged);
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.txtTransferSpeed);
            this.tabInformation.Controls.Add(this.txtExecuteInterval);
            this.tabInformation.Controls.Add(this.txtDashboardRefresh);
            this.tabInformation.Controls.Add(this.txtWsdlUrl);
            this.tabInformation.Controls.Add(this.btnSave);
            this.tabInformation.Controls.Add(this.label4);
            this.tabInformation.Controls.Add(this.label3);
            this.tabInformation.Controls.Add(this.label2);
            this.tabInformation.Controls.Add(this.label1);
            this.tabInformation.Location = new System.Drawing.Point(4, 22);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformation.Size = new System.Drawing.Size(996, 371);
            this.tabInformation.TabIndex = 0;
            this.tabInformation.Text = "Information";
            this.tabInformation.UseVisualStyleBackColor = true;
            // 
            // txtTransferSpeed
            // 
            this.txtTransferSpeed.Location = new System.Drawing.Point(220, 93);
            this.txtTransferSpeed.MaxLength = 13;
            this.txtTransferSpeed.Name = "txtTransferSpeed";
            this.txtTransferSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtTransferSpeed.StrFormat = "";
            this.txtTransferSpeed.TabIndex = 6;
            this.txtTransferSpeed.Text = "0";
            this.txtTransferSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransferSpeed.Value = null;
            // 
            // txtExecuteInterval
            // 
            this.txtExecuteInterval.Location = new System.Drawing.Point(220, 57);
            this.txtExecuteInterval.MaxLength = 13;
            this.txtExecuteInterval.Name = "txtExecuteInterval";
            this.txtExecuteInterval.Size = new System.Drawing.Size(100, 20);
            this.txtExecuteInterval.StrFormat = "";
            this.txtExecuteInterval.TabIndex = 5;
            this.txtExecuteInterval.Text = "0";
            this.txtExecuteInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExecuteInterval.Value = null;
            // 
            // txtDashboardRefresh
            // 
            this.txtDashboardRefresh.Location = new System.Drawing.Point(220, 21);
            this.txtDashboardRefresh.MaxLength = 13;
            this.txtDashboardRefresh.Name = "txtDashboardRefresh";
            this.txtDashboardRefresh.Size = new System.Drawing.Size(100, 20);
            this.txtDashboardRefresh.StrFormat = "";
            this.txtDashboardRefresh.TabIndex = 4;
            this.txtDashboardRefresh.Text = "0";
            this.txtDashboardRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDashboardRefresh.Value = null;
            // 
            // txtWsdlUrl
            // 
            this.txtWsdlUrl.Location = new System.Drawing.Point(220, 129);
            this.txtWsdlUrl.Name = "txtWsdlUrl";
            this.txtWsdlUrl.Size = new System.Drawing.Size(307, 20);
            this.txtWsdlUrl.TabIndex = 7;
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
            // tbaRsa
            // 
            this.tbaRsa.Controls.Add(this.txtPublicKeyFile);
            this.tbaRsa.Controls.Add(this.btnCreateNewFile);
            this.tbaRsa.Controls.Add(this.label5);
            this.tbaRsa.Controls.Add(this.txtPrivateKeyFile);
            this.tbaRsa.Controls.Add(this.label6);
            this.tbaRsa.Controls.Add(this.btnBrowse);
            this.tbaRsa.Location = new System.Drawing.Point(4, 22);
            this.tbaRsa.Name = "tbaRsa";
            this.tbaRsa.Padding = new System.Windows.Forms.Padding(3);
            this.tbaRsa.Size = new System.Drawing.Size(996, 371);
            this.tbaRsa.TabIndex = 1;
            this.tbaRsa.Text = "RSA";
            this.tbaRsa.UseVisualStyleBackColor = true;
            // 
            // txtPublicKeyFile
            // 
            this.txtPublicKeyFile.BackColor = System.Drawing.Color.White;
            this.txtPublicKeyFile.Enabled = false;
            this.txtPublicKeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublicKeyFile.ForeColor = System.Drawing.Color.Black;
            this.txtPublicKeyFile.Location = new System.Drawing.Point(113, 57);
            this.txtPublicKeyFile.Name = "txtPublicKeyFile";
            this.txtPublicKeyFile.ReadOnly = true;
            this.txtPublicKeyFile.Size = new System.Drawing.Size(204, 20);
            this.txtPublicKeyFile.TabIndex = 3;
            // 
            // btnCreateNewFile
            // 
            this.btnCreateNewFile.Location = new System.Drawing.Point(113, 94);
            this.btnCreateNewFile.Name = "btnCreateNewFile";
            this.btnCreateNewFile.Size = new System.Drawing.Size(87, 23);
            this.btnCreateNewFile.TabIndex = 5;
            this.btnCreateNewFile.Text = "Create new";
            this.btnCreateNewFile.UseVisualStyleBackColor = true;
            this.btnCreateNewFile.Click += new System.EventHandler(this.btnCreateNewFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Public key file:";
            // 
            // txtPrivateKeyFile
            // 
            this.txtPrivateKeyFile.BackColor = System.Drawing.Color.White;
            this.txtPrivateKeyFile.Enabled = false;
            this.txtPrivateKeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrivateKeyFile.ForeColor = System.Drawing.Color.Black;
            this.txtPrivateKeyFile.Location = new System.Drawing.Point(113, 21);
            this.txtPrivateKeyFile.Name = "txtPrivateKeyFile";
            this.txtPrivateKeyFile.ReadOnly = true;
            this.txtPrivateKeyFile.Size = new System.Drawing.Size(238, 20);
            this.txtPrivateKeyFile.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Private key file:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(323, 56);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
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
            this.tbaRsa.ResumeLayout(false);
            this.tbaRsa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tabInformation;
        private System.Windows.Forms.TabPage tbaRsa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWsdlUrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private WahooV2.ExControl.TextBoxForNum txtDashboardRefresh;
        private WahooV2.ExControl.TextBoxForNum txtTransferSpeed;
        private WahooV2.ExControl.TextBoxForNum txtExecuteInterval;
        private System.Windows.Forms.TextBox txtPublicKeyFile;
        private System.Windows.Forms.Button btnCreateNewFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrivateKeyFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
    }
}
