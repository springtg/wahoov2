namespace HL7ServerTransfer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtTransferSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnSourceFolder = new System.Windows.Forms.Button();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tmDownload = new System.Timers.Timer();
            this.bgwMain = new System.ComponentModel.BackgroundWorker();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUserInfo = new System.Windows.Forms.TabPage();
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.tabPrint = new System.Windows.Forms.TabPage();
            this.chkXsl = new System.Windows.Forms.CheckBox();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.chkDoc = new System.Windows.Forms.CheckBox();
            this.txtNumOfCopies = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbPrinter = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tmDownload)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabUserInfo.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTransferSpeed
            // 
            this.txtTransferSpeed.Location = new System.Drawing.Point(113, 84);
            this.txtTransferSpeed.Name = "txtTransferSpeed";
            this.txtTransferSpeed.Size = new System.Drawing.Size(91, 20);
            this.txtTransferSpeed.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "TransferSpeed:";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(113, 45);
            this.txtInterval.MaxLength = 13;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(91, 20);
            this.txtInterval.TabIndex = 1;
            // 
            // txtClientCode
            // 
            this.txtClientCode.Location = new System.Drawing.Point(99, 9);
            this.txtClientCode.MaxLength = 10;
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.ReadOnly = true;
            this.txtClientCode.Size = new System.Drawing.Size(100, 20);
            this.txtClientCode.TabIndex = 2;
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Checked = true;
            this.chkStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartup.Location = new System.Drawing.Point(14, 12);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(186, 17);
            this.chkStartup.TabIndex = 3;
            this.chkStartup.Text = "Run program on Windows Startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval Download:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(476, 205);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(395, 205);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnSourceFolder
            // 
            this.btnSourceFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnSourceFolder.Image")));
            this.btnSourceFolder.Location = new System.Drawing.Point(435, 123);
            this.btnSourceFolder.Name = "btnSourceFolder";
            this.btnSourceFolder.Size = new System.Drawing.Size(28, 23);
            this.btnSourceFolder.TabIndex = 6;
            this.btnSourceFolder.UseVisualStyleBackColor = true;
            this.btnSourceFolder.Click += new System.EventHandler(this.btnSourceFolder_Click);
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.BackColor = System.Drawing.Color.White;
            this.txtDownloadFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownloadFolder.ForeColor = System.Drawing.Color.Black;
            this.txtDownloadFolder.Location = new System.Drawing.Point(99, 126);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.ReadOnly = true;
            this.txtDownloadFolder.Size = new System.Drawing.Size(330, 20);
            this.txtDownloadFolder.TabIndex = 56;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(99, 84);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(408, 20);
            this.txtURL.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Inbound folder:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "WSDL URL:";
            // 
            // tmDownload
            // 
            this.tmDownload.Enabled = true;
            this.tmDownload.SynchronizingObject = this;
            this.tmDownload.Elapsed += new System.Timers.ElapsedEventHandler(this.tmDownload_Elapsed);
            // 
            // bgwMain
            // 
            this.bgwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMain_DoWork);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabUserInfo);
            this.tabMain.Controls.Add(this.tabOption);
            this.tabMain.Controls.Add(this.tabSchedule);
            this.tabMain.Controls.Add(this.tabPrint);
            this.tabMain.Location = new System.Drawing.Point(2, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(553, 198);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 9;
            // 
            // tabUserInfo
            // 
            this.tabUserInfo.Controls.Add(this.btnSourceFolder);
            this.tabUserInfo.Controls.Add(this.txtLicenseKey);
            this.tabUserInfo.Controls.Add(this.txtDownloadFolder);
            this.tabUserInfo.Controls.Add(this.label10);
            this.tabUserInfo.Controls.Add(this.txtURL);
            this.tabUserInfo.Controls.Add(this.label3);
            this.tabUserInfo.Controls.Add(this.label5);
            this.tabUserInfo.Controls.Add(this.label6);
            this.tabUserInfo.Controls.Add(this.label7);
            this.tabUserInfo.Controls.Add(this.txtEmail);
            this.tabUserInfo.Controls.Add(this.txtClientCode);
            this.tabUserInfo.Controls.Add(this.txtClientName);
            this.tabUserInfo.Controls.Add(this.label9);
            this.tabUserInfo.Location = new System.Drawing.Point(4, 22);
            this.tabUserInfo.Name = "tabUserInfo";
            this.tabUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserInfo.Size = new System.Drawing.Size(545, 172);
            this.tabUserInfo.TabIndex = 0;
            this.tabUserInfo.Text = "User Infomation";
            this.tabUserInfo.UseVisualStyleBackColor = true;
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Location = new System.Drawing.Point(375, 46);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.ReadOnly = true;
            this.txtLicenseKey.Size = new System.Drawing.Size(153, 20);
            this.txtLicenseKey.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "License key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Client code:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Client name:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(375, 9);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(153, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(99, 46);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.ReadOnly = true;
            this.txtClientName.Size = new System.Drawing.Size(153, 20);
            this.txtClientName.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Email:";
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.txtTransferSpeed);
            this.tabOption.Controls.Add(this.txtInterval);
            this.tabOption.Controls.Add(this.label4);
            this.tabOption.Controls.Add(this.label1);
            this.tabOption.Controls.Add(this.label15);
            this.tabOption.Controls.Add(this.label2);
            this.tabOption.Controls.Add(this.chkStartup);
            this.tabOption.Location = new System.Drawing.Point(4, 22);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(545, 172);
            this.tabOption.TabIndex = 1;
            this.tabOption.Text = "Option";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(207, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Kb";
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.groupBox1);
            this.tabSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(545, 172);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Schedule";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.chkMonday);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.chkTuesday);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.chkWednesday);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkThursday);
            this.groupBox1.Controls.Add(this.chkSunday);
            this.groupBox1.Controls.Add(this.chkFriday);
            this.groupBox1.Controls.Add(this.chkSaturday);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 173);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTo.Location = new System.Drawing.Point(179, 111);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(87, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(4, 12);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(64, 17);
            this.chkMonday.TabIndex = 0;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "To:";
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(86, 12);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkTuesday.TabIndex = 0;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFrom.Location = new System.Drawing.Point(40, 111);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(87, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(183, 12);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkWednesday.TabIndex = 0;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "From:";
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(4, 47);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(70, 17);
            this.chkThursday.TabIndex = 0;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(86, 82);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(62, 17);
            this.chkSunday.TabIndex = 0;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(86, 47);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(54, 17);
            this.chkFriday.TabIndex = 0;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(4, 82);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkSaturday.TabIndex = 0;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // tabPrint
            // 
            this.tabPrint.Controls.Add(this.chkXsl);
            this.tabPrint.Controls.Add(this.chkPdf);
            this.tabPrint.Controls.Add(this.chkDoc);
            this.tabPrint.Controls.Add(this.txtNumOfCopies);
            this.tabPrint.Controls.Add(this.label14);
            this.tabPrint.Controls.Add(this.label13);
            this.tabPrint.Controls.Add(this.cbPrinter);
            this.tabPrint.Controls.Add(this.label12);
            this.tabPrint.Location = new System.Drawing.Point(4, 22);
            this.tabPrint.Name = "tabPrint";
            this.tabPrint.Size = new System.Drawing.Size(545, 172);
            this.tabPrint.TabIndex = 3;
            this.tabPrint.Text = "Printer Setting";
            this.tabPrint.UseVisualStyleBackColor = true;
            // 
            // chkXsl
            // 
            this.chkXsl.AutoSize = true;
            this.chkXsl.Enabled = false;
            this.chkXsl.Location = new System.Drawing.Point(205, 53);
            this.chkXsl.Name = "chkXsl";
            this.chkXsl.Size = new System.Drawing.Size(41, 17);
            this.chkXsl.TabIndex = 38;
            this.chkXsl.Text = ".xls";
            this.chkXsl.UseVisualStyleBackColor = true;
            this.chkXsl.Visible = false;
            // 
            // chkPdf
            // 
            this.chkPdf.AutoSize = true;
            this.chkPdf.Location = new System.Drawing.Point(155, 53);
            this.chkPdf.Name = "chkPdf";
            this.chkPdf.Size = new System.Drawing.Size(44, 17);
            this.chkPdf.TabIndex = 38;
            this.chkPdf.Text = ".pdf";
            this.chkPdf.UseVisualStyleBackColor = true;
            // 
            // chkDoc
            // 
            this.chkDoc.AutoSize = true;
            this.chkDoc.Checked = true;
            this.chkDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoc.Location = new System.Drawing.Point(102, 53);
            this.chkDoc.Name = "chkDoc";
            this.chkDoc.Size = new System.Drawing.Size(47, 17);
            this.chkDoc.TabIndex = 38;
            this.chkDoc.Text = ".doc";
            this.chkDoc.UseVisualStyleBackColor = true;
            // 
            // txtNumOfCopies
            // 
            this.txtNumOfCopies.Location = new System.Drawing.Point(105, 90);
            this.txtNumOfCopies.Name = "txtNumOfCopies";
            this.txtNumOfCopies.ReadOnly = true;
            this.txtNumOfCopies.Size = new System.Drawing.Size(48, 20);
            this.txtNumOfCopies.TabIndex = 37;
            this.txtNumOfCopies.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Number of copies:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Print format file(s):";
            // 
            // cbPrinter
            // 
            this.cbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinter.FormattingEnabled = true;
            this.cbPrinter.Location = new System.Drawing.Point(102, 9);
            this.cbPrinter.Name = "cbPrinter";
            this.cbPrinter.Size = new System.Drawing.Size(137, 21);
            this.cbPrinter.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Printer:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 233);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wahoo Client";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tmDownload)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabUserInfo.ResumeLayout(false);
            this.tabUserInfo.PerformLayout();
            this.tabOption.ResumeLayout(false);
            this.tabOption.PerformLayout();
            this.tabSchedule.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPrint.ResumeLayout(false);
            this.tabPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnSourceFolder;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Timers.Timer tmDownload;
        private System.ComponentModel.BackgroundWorker bgwMain;
        private System.Windows.Forms.TextBox txtTransferSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUserInfo;
        private System.Windows.Forms.TabPage tabOption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabPrint;
        private System.Windows.Forms.TextBox txtLicenseKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbPrinter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumOfCopies;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkPdf;
        private System.Windows.Forms.CheckBox chkDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkXsl;
    }
}

