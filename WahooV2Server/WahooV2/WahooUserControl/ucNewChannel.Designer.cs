namespace WahooV2.WahooUserControl
{
    partial class ucNewChannel
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
            this.gbChannelInfomation = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.chkStoreFile = new System.Windows.Forms.CheckBox();
            this.txtChannelDescription = new System.Windows.Forms.TextBox();
            this.lblChannelDescription = new System.Windows.Forms.Label();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.gbClientInfomation = new System.Windows.Forms.GroupBox();
            this.gbClientInfo = new System.Windows.Forms.GroupBox();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtZipcode = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblClientDescription = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.cbClientList = new System.Windows.Forms.ComboBox();
            this.lblChooseClient = new System.Windows.Forms.Label();
            this.gbChannelInfomation.SuspendLayout();
            this.gbClientInfomation.SuspendLayout();
            this.gbClientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbChannelInfomation
            // 
            this.gbChannelInfomation.Controls.Add(this.btnBrowse);
            this.gbChannelInfomation.Controls.Add(this.txtFilePath);
            this.gbChannelInfomation.Controls.Add(this.lblPath);
            this.gbChannelInfomation.Controls.Add(this.chkStoreFile);
            this.gbChannelInfomation.Controls.Add(this.txtChannelDescription);
            this.gbChannelInfomation.Controls.Add(this.lblChannelDescription);
            this.gbChannelInfomation.Controls.Add(this.txtChannelName);
            this.gbChannelInfomation.Controls.Add(this.chkEnable);
            this.gbChannelInfomation.Controls.Add(this.lblChannelName);
            this.gbChannelInfomation.Location = new System.Drawing.Point(10, 8);
            this.gbChannelInfomation.Name = "gbChannelInfomation";
            this.gbChannelInfomation.Size = new System.Drawing.Size(836, 247);
            this.gbChannelInfomation.TabIndex = 0;
            this.gbChannelInfomation.TabStop = false;
            this.gbChannelInfomation.Text = "Channel Information";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::WahooV2.Properties.Resources.wh_folder_explore;
            this.btnBrowse.Location = new System.Drawing.Point(568, 53);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(33, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.White;
            this.txtFilePath.Location = new System.Drawing.Point(98, 55);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(464, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(6, 63);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(86, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Outbound folder:";
            // 
            // chkStoreFile
            // 
            this.chkStoreFile.AutoSize = true;
            this.chkStoreFile.Location = new System.Drawing.Point(98, 89);
            this.chkStoreFile.Name = "chkStoreFile";
            this.chkStoreFile.Size = new System.Drawing.Size(90, 17);
            this.chkStoreFile.TabIndex = 4;
            this.chkStoreFile.Text = "Backup file(s)";
            this.chkStoreFile.UseVisualStyleBackColor = true;
            // 
            // txtChannelDescription
            // 
            this.txtChannelDescription.Location = new System.Drawing.Point(98, 114);
            this.txtChannelDescription.Multiline = true;
            this.txtChannelDescription.Name = "txtChannelDescription";
            this.txtChannelDescription.Size = new System.Drawing.Size(503, 127);
            this.txtChannelDescription.TabIndex = 5;
            // 
            // lblChannelDescription
            // 
            this.lblChannelDescription.AutoSize = true;
            this.lblChannelDescription.Location = new System.Drawing.Point(25, 166);
            this.lblChannelDescription.Name = "lblChannelDescription";
            this.lblChannelDescription.Size = new System.Drawing.Size(63, 13);
            this.lblChannelDescription.TabIndex = 0;
            this.lblChannelDescription.Text = "Description:";
            // 
            // txtChannelName
            // 
            this.txtChannelName.Location = new System.Drawing.Point(98, 19);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(210, 20);
            this.txtChannelName.TabIndex = 1;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Checked = true;
            this.chkEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnable.Location = new System.Drawing.Point(326, 22);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(59, 17);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.Location = new System.Drawing.Point(12, 26);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(80, 13);
            this.lblChannelName.TabIndex = 0;
            this.lblChannelName.Text = "Channel Name:";
            // 
            // gbClientInfomation
            // 
            this.gbClientInfomation.Controls.Add(this.gbClientInfo);
            this.gbClientInfomation.Controls.Add(this.cbClientList);
            this.gbClientInfomation.Controls.Add(this.lblChooseClient);
            this.gbClientInfomation.Location = new System.Drawing.Point(13, 261);
            this.gbClientInfomation.Name = "gbClientInfomation";
            this.gbClientInfomation.Size = new System.Drawing.Size(833, 417);
            this.gbClientInfomation.TabIndex = 1;
            this.gbClientInfomation.TabStop = false;
            this.gbClientInfomation.Text = "Client Information";
            // 
            // gbClientInfo
            // 
            this.gbClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClientInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbClientInfo.Controls.Add(this.txtClientCode);
            this.gbClientInfo.Controls.Add(this.txtClientName);
            this.gbClientInfo.Controls.Add(this.txtMail);
            this.gbClientInfo.Controls.Add(this.txtDescription);
            this.gbClientInfo.Controls.Add(this.txtPhone);
            this.gbClientInfo.Controls.Add(this.txtZipcode);
            this.gbClientInfo.Controls.Add(this.lblMail);
            this.gbClientInfo.Controls.Add(this.lblClientDescription);
            this.gbClientInfo.Controls.Add(this.txtState);
            this.gbClientInfo.Controls.Add(this.lblPhone);
            this.gbClientInfo.Controls.Add(this.lblZipCode);
            this.gbClientInfo.Controls.Add(this.txtCity);
            this.gbClientInfo.Controls.Add(this.lblState);
            this.gbClientInfo.Controls.Add(this.txtAddr2);
            this.gbClientInfo.Controls.Add(this.lblCity);
            this.gbClientInfo.Controls.Add(this.lblAddress2);
            this.gbClientInfo.Controls.Add(this.lblClientCode);
            this.gbClientInfo.Controls.Add(this.txtAddr1);
            this.gbClientInfo.Controls.Add(this.lblClientName);
            this.gbClientInfo.Controls.Add(this.lblAddress1);
            this.gbClientInfo.Enabled = false;
            this.gbClientInfo.Location = new System.Drawing.Point(8, 51);
            this.gbClientInfo.Name = "gbClientInfo";
            this.gbClientInfo.Size = new System.Drawing.Size(819, 359);
            this.gbClientInfo.TabIndex = 2;
            this.gbClientInfo.TabStop = false;
            // 
            // txtClientCode
            // 
            this.txtClientCode.Location = new System.Drawing.Point(100, 29);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(210, 20);
            this.txtClientCode.TabIndex = 1;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(568, 29);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(210, 20);
            this.txtClientName.TabIndex = 2;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(100, 194);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(210, 20);
            this.txtMail.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 230);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(468, 112);
            this.txtDescription.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(568, 155);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(210, 20);
            this.txtPhone.TabIndex = 8;
            // 
            // txtZipcode
            // 
            this.txtZipcode.Location = new System.Drawing.Point(568, 113);
            this.txtZipcode.Name = "txtZipcode";
            this.txtZipcode.Size = new System.Drawing.Size(210, 20);
            this.txtZipcode.TabIndex = 6;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(14, 201);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "Mail:";
            // 
            // lblClientDescription
            // 
            this.lblClientDescription.AutoSize = true;
            this.lblClientDescription.Location = new System.Drawing.Point(14, 245);
            this.lblClientDescription.Name = "lblClientDescription";
            this.lblClientDescription.Size = new System.Drawing.Size(63, 13);
            this.lblClientDescription.TabIndex = 0;
            this.lblClientDescription.Text = "Description:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(100, 155);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(210, 20);
            this.txtState.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(482, 162);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Phone:";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(486, 120);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(53, 13);
            this.lblZipCode.TabIndex = 0;
            this.lblZipCode.Text = "Zip Code:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(100, 113);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(210, 20);
            this.txtCity.TabIndex = 5;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(14, 162);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "State:";
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(568, 70);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(210, 20);
            this.txtAddr2.TabIndex = 4;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(14, 120);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 0;
            this.lblCity.Text = "City:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(486, 77);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(57, 13);
            this.lblAddress2.TabIndex = 0;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblClientCode
            // 
            this.lblClientCode.AutoSize = true;
            this.lblClientCode.Location = new System.Drawing.Point(14, 36);
            this.lblClientCode.Name = "lblClientCode";
            this.lblClientCode.Size = new System.Drawing.Size(64, 13);
            this.lblClientCode.TabIndex = 0;
            this.lblClientCode.Text = "Client Code:";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(100, 70);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(210, 20);
            this.txtAddr1.TabIndex = 3;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(486, 36);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(67, 13);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "Client Name:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(14, 77);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(57, 13);
            this.lblAddress1.TabIndex = 0;
            this.lblAddress1.Text = "Address 1:";
            // 
            // cbClientList
            // 
            this.cbClientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientList.FormattingEnabled = true;
            this.cbClientList.Location = new System.Drawing.Point(112, 19);
            this.cbClientList.Name = "cbClientList";
            this.cbClientList.Size = new System.Drawing.Size(287, 21);
            this.cbClientList.TabIndex = 1;
            this.cbClientList.SelectedIndexChanged += new System.EventHandler(this.cbClientList_SelectedIndexChanged);
            // 
            // lblChooseClient
            // 
            this.lblChooseClient.AutoSize = true;
            this.lblChooseClient.Location = new System.Drawing.Point(15, 27);
            this.lblChooseClient.Name = "lblChooseClient";
            this.lblChooseClient.Size = new System.Drawing.Size(74, 13);
            this.lblChooseClient.TabIndex = 0;
            this.lblChooseClient.Text = "Choose client:";
            // 
            // ucNewChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbChannelInfomation);
            this.Controls.Add(this.gbClientInfomation);
            this.Name = "ucNewChannel";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.ucNewChannel_Load);
            this.gbChannelInfomation.ResumeLayout(false);
            this.gbChannelInfomation.PerformLayout();
            this.gbClientInfomation.ResumeLayout(false);
            this.gbClientInfomation.PerformLayout();
            this.gbClientInfo.ResumeLayout(false);
            this.gbClientInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbChannelInfomation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.CheckBox chkStoreFile;
        private System.Windows.Forms.TextBox txtChannelDescription;
        private System.Windows.Forms.Label lblChannelDescription;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.GroupBox gbClientInfomation;
        private System.Windows.Forms.GroupBox gbClientInfo;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtZipcode;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblClientDescription;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblZipCode;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtAddr2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.TextBox txtAddr1;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.ComboBox cbClientList;
        private System.Windows.Forms.Label lblChooseClient;

    }
}
