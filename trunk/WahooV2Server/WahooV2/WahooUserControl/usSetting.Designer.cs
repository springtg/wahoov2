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
            this.txtBlowfishKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransferSpeed = new WahooV2.ExControl.TextBoxForNum();
            this.txtExecuteInterval = new WahooV2.ExControl.TextBoxForNum();
            this.txtDashboardRefresh = new WahooV2.ExControl.TextBoxForNum();
            this.txtWsdlUrl = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBlowfishKey
            // 
            this.txtBlowfishKey.Location = new System.Drawing.Point(205, 133);
            this.txtBlowfishKey.Name = "txtBlowfishKey";
            this.txtBlowfishKey.Size = new System.Drawing.Size(100, 20);
            this.txtBlowfishKey.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 9;
            this.label7.Tag = "?";
            this.label7.Text = "Encryption Key:";
            // 
            // txtTransferSpeed
            // 
            this.txtTransferSpeed.Location = new System.Drawing.Point(205, 96);
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
            this.txtExecuteInterval.Location = new System.Drawing.Point(205, 60);
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
            this.txtDashboardRefresh.Location = new System.Drawing.Point(205, 24);
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
            this.txtWsdlUrl.Location = new System.Drawing.Point(205, 168);
            this.txtWsdlUrl.Name = "txtWsdlUrl";
            this.txtWsdlUrl.Size = new System.Drawing.Size(307, 20);
            this.txtWsdlUrl.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(368, 223);
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
            this.label4.Location = new System.Drawing.Point(9, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Web service address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transfer Speed(Kbps):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Execute interval (Seconds):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard refresh interval (Seconds):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtWsdlUrl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBlowfishKey);
            this.groupBox1.Controls.Add(this.txtExecuteInterval);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTransferSpeed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDashboardRefresh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 204);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(13, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(541, 2);
            this.label5.TabIndex = 12;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(462, 223);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // usSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Name = "usSetting";
            this.Size = new System.Drawing.Size(1010, 690);
            this.Load += new System.EventHandler(this.usSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWsdlUrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private WahooV2.ExControl.TextBoxForNum txtDashboardRefresh;
        private WahooV2.ExControl.TextBoxForNum txtTransferSpeed;
        private WahooV2.ExControl.TextBoxForNum txtExecuteInterval;
        private System.Windows.Forms.TextBox txtBlowfishKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
    }
}
