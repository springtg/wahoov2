namespace WahooV2.WahooUserControl
{
    partial class usMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTotalFiles = new System.Windows.Forms.TextBox();
            this.cbFilterSearch = new System.Windows.Forms.ComboBox();
            this.gridReport = new System.Windows.Forms.DataGridView();
            this.clIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSuccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsSentToPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.chkSearchDate = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dptDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSentToPrintTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSentToPrintStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.txtDownloadTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDownloadStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.dptDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbSearchInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlNavigative = new System.Windows.Forms.Panel();
            this.txtPage = new WahooV2.ExControl.TextBoxForNum();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFisrt = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.gbResult.SuspendLayout();
            this.gbSearchInfo.SuspendLayout();
            this.pnlNavigative.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotalFiles
            // 
            this.txtTotalFiles.Enabled = false;
            this.txtTotalFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFiles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalFiles.Location = new System.Drawing.Point(709, 23);
            this.txtTotalFiles.Name = "txtTotalFiles";
            this.txtTotalFiles.ReadOnly = true;
            this.txtTotalFiles.Size = new System.Drawing.Size(100, 22);
            this.txtTotalFiles.TabIndex = 8;
            // 
            // cbFilterSearch
            // 
            this.cbFilterSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterSearch.FormattingEnabled = true;
            this.cbFilterSearch.Location = new System.Drawing.Point(432, 61);
            this.cbFilterSearch.Name = "cbFilterSearch";
            this.cbFilterSearch.Size = new System.Drawing.Size(259, 21);
            this.cbFilterSearch.TabIndex = 10;
            // 
            // gridReport
            // 
            this.gridReport.AllowUserToAddRows = false;
            this.gridReport.AllowUserToDeleteRows = false;
            this.gridReport.AllowUserToResizeRows = false;
            this.gridReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIpAddress,
            this.clFilename,
            this.clSuccess,
            this.clIsSentToPrint});
            this.gridReport.Location = new System.Drawing.Point(3, 108);
            this.gridReport.MultiSelect = false;
            this.gridReport.Name = "gridReport";
            this.gridReport.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridReport.RowHeadersWidth = 60;
            this.gridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReport.Size = new System.Drawing.Size(1096, 410);
            this.gridReport.TabIndex = 1;
            this.gridReport.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridReport_RowEnter);
            this.gridReport.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridReport_DataBindingComplete_1);
            // 
            // clIpAddress
            // 
            this.clIpAddress.DataPropertyName = "IpAddress";
            this.clIpAddress.HeaderText = "Ip address";
            this.clIpAddress.Name = "clIpAddress";
            this.clIpAddress.ReadOnly = true;
            this.clIpAddress.Width = 200;
            // 
            // clFilename
            // 
            this.clFilename.DataPropertyName = "filename";
            this.clFilename.HeaderText = "File name";
            this.clFilename.Name = "clFilename";
            this.clFilename.ReadOnly = true;
            this.clFilename.Width = 450;
            // 
            // clSuccess
            // 
            this.clSuccess.DataPropertyName = "Downloaded";
            this.clSuccess.HeaderText = "Downloaded";
            this.clSuccess.Name = "clSuccess";
            this.clSuccess.ReadOnly = true;
            this.clSuccess.Width = 120;
            // 
            // clIsSentToPrint
            // 
            this.clIsSentToPrint.DataPropertyName = "SentToPrint";
            this.clIsSentToPrint.HeaderText = "Sent to print";
            this.clIsSentToPrint.Name = "clIsSentToPrint";
            this.clIsSentToPrint.ReadOnly = true;
            this.clIsSentToPrint.Width = 120;
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(432, 23);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(259, 21);
            this.cbClient.TabIndex = 7;
            // 
            // chkSearchDate
            // 
            this.chkSearchDate.AutoSize = true;
            this.chkSearchDate.Location = new System.Drawing.Point(9, 26);
            this.chkSearchDate.Name = "chkSearchDate";
            this.chkSearchDate.Size = new System.Drawing.Size(49, 17);
            this.chkSearchDate.TabIndex = 0;
            this.chkSearchDate.Text = "Date";
            this.chkSearchDate.UseVisualStyleBackColor = true;
            this.chkSearchDate.CheckedChanged += new System.EventHandler(this.chkSearchDate_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(163, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "~";
            // 
            // dptDateTo
            // 
            this.dptDateTo.CustomFormat = "";
            this.dptDateTo.Enabled = false;
            this.dptDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptDateTo.Location = new System.Drawing.Point(183, 23);
            this.dptDateTo.Name = "dptDateTo";
            this.dptDateTo.Size = new System.Drawing.Size(102, 20);
            this.dptDateTo.TabIndex = 6;
            this.dptDateTo.ValueChanged += new System.EventHandler(this.dptDateTo_ValueChanged);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(825, 19);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(189, 20);
            this.txtIpAddress.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(721, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ip Address:";
            // 
            // txtSentToPrintTime
            // 
            this.txtSentToPrintTime.Location = new System.Drawing.Point(483, 63);
            this.txtSentToPrintTime.Name = "txtSentToPrintTime";
            this.txtSentToPrintTime.Size = new System.Drawing.Size(172, 20);
            this.txtSentToPrintTime.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sent to print time:";
            // 
            // txtSentToPrintStatus
            // 
            this.txtSentToPrintStatus.Location = new System.Drawing.Point(114, 67);
            this.txtSentToPrintStatus.Name = "txtSentToPrintStatus";
            this.txtSentToPrintStatus.Size = new System.Drawing.Size(189, 20);
            this.txtSentToPrintStatus.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sent to print status:";
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.txtIpAddress);
            this.gbResult.Controls.Add(this.label8);
            this.gbResult.Controls.Add(this.txtSentToPrintTime);
            this.gbResult.Controls.Add(this.label5);
            this.gbResult.Controls.Add(this.txtSentToPrintStatus);
            this.gbResult.Controls.Add(this.label4);
            this.gbResult.Controls.Add(this.txtDownloadTime);
            this.gbResult.Controls.Add(this.label3);
            this.gbResult.Controls.Add(this.txtDownloadStatus);
            this.gbResult.Controls.Add(this.label2);
            this.gbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbResult.Enabled = false;
            this.gbResult.Location = new System.Drawing.Point(0, 567);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(1102, 119);
            this.gbResult.TabIndex = 2;
            this.gbResult.TabStop = false;
            // 
            // txtDownloadTime
            // 
            this.txtDownloadTime.Location = new System.Drawing.Point(483, 18);
            this.txtDownloadTime.Name = "txtDownloadTime";
            this.txtDownloadTime.Size = new System.Drawing.Size(172, 20);
            this.txtDownloadTime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Downloaded time:";
            // 
            // txtDownloadStatus
            // 
            this.txtDownloadStatus.Location = new System.Drawing.Point(114, 19);
            this.txtDownloadStatus.Name = "txtDownloadStatus";
            this.txtDownloadStatus.Size = new System.Drawing.Size(189, 20);
            this.txtDownloadStatus.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Download status:";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(64, 62);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(264, 20);
            this.txtFilename.TabIndex = 9;
            // 
            // dptDateFrom
            // 
            this.dptDateFrom.CustomFormat = "";
            this.dptDateFrom.Enabled = false;
            this.dptDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptDateFrom.Location = new System.Drawing.Point(64, 23);
            this.dptDateFrom.Name = "dptDateFrom";
            this.dptDateFrom.Size = new System.Drawing.Size(91, 20);
            this.dptDateFrom.TabIndex = 5;
            this.dptDateFrom.ValueChanged += new System.EventHandler(this.dptDateFrom_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "File(s):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Client(s):";
            // 
            // gbSearchInfo
            // 
            this.gbSearchInfo.Controls.Add(this.txtTotalFiles);
            this.gbSearchInfo.Controls.Add(this.cbFilterSearch);
            this.gbSearchInfo.Controls.Add(this.cbClient);
            this.gbSearchInfo.Controls.Add(this.chkSearchDate);
            this.gbSearchInfo.Controls.Add(this.label11);
            this.gbSearchInfo.Controls.Add(this.dptDateTo);
            this.gbSearchInfo.Controls.Add(this.dptDateFrom);
            this.gbSearchInfo.Controls.Add(this.label7);
            this.gbSearchInfo.Controls.Add(this.txtFilename);
            this.gbSearchInfo.Controls.Add(this.label6);
            this.gbSearchInfo.Controls.Add(this.label1);
            this.gbSearchInfo.Location = new System.Drawing.Point(3, 3);
            this.gbSearchInfo.Name = "gbSearchInfo";
            this.gbSearchInfo.Size = new System.Drawing.Size(1096, 99);
            this.gbSearchInfo.TabIndex = 0;
            this.gbSearchInfo.TabStop = false;
            this.gbSearchInfo.Text = "Search Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File name:";
            // 
            // pnlNavigative
            // 
            this.pnlNavigative.Controls.Add(this.txtPage);
            this.pnlNavigative.Controls.Add(this.btnPrevious);
            this.pnlNavigative.Controls.Add(this.btnFisrt);
            this.pnlNavigative.Controls.Add(this.btnEnd);
            this.pnlNavigative.Controls.Add(this.btnNext);
            this.pnlNavigative.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigative.Location = new System.Drawing.Point(0, 524);
            this.pnlNavigative.Name = "pnlNavigative";
            this.pnlNavigative.Size = new System.Drawing.Size(1102, 43);
            this.pnlNavigative.TabIndex = 3;
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(527, 12);
            this.txtPage.MaxLength = 3;
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(39, 20);
            this.txtPage.StrFormat = "";
            this.txtPage.TabIndex = 1;
            this.txtPage.Text = "0";
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPage.Value = null;
            this.txtPage.TextChanged += new System.EventHandler(this.txtPage_TextChanged);
            this.txtPage.Validated += new System.EventHandler(this.txtPage_Validated);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(486, 12);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFisrt
            // 
            this.btnFisrt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFisrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFisrt.Location = new System.Drawing.Point(454, 12);
            this.btnFisrt.Name = "btnFisrt";
            this.btnFisrt.Size = new System.Drawing.Size(30, 20);
            this.btnFisrt.TabIndex = 0;
            this.btnFisrt.Text = "<<";
            this.btnFisrt.UseVisualStyleBackColor = true;
            this.btnFisrt.Click += new System.EventHandler(this.btnFisrt_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(607, 12);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(30, 20);
            this.btnEnd.TabIndex = 0;
            this.btnEnd.Text = ">>";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(575, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // usMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNavigative);
            this.Controls.Add(this.gridReport);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbSearchInfo);
            this.Name = "usMonitor";
            this.Size = new System.Drawing.Size(1102, 686);
            this.Load += new System.EventHandler(this.usMonitor_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.usMonitor_ControlAdded);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.gbSearchInfo.ResumeLayout(false);
            this.gbSearchInfo.PerformLayout();
            this.pnlNavigative.ResumeLayout(false);
            this.pnlNavigative.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotalFiles;
        private System.Windows.Forms.ComboBox cbFilterSearch;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.CheckBox chkSearchDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dptDateTo;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSentToPrintTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSentToPrintStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.TextBox txtDownloadTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDownloadStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.DateTimePicker dptDateFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbSearchInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsSentToPrint;
        private System.Windows.Forms.Panel pnlNavigative;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFisrt;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnEnd;
        private WahooV2.ExControl.TextBoxForNum txtPage;
    }
}
