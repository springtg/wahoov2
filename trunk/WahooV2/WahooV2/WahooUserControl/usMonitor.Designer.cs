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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pnlNegative = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.gbResult.SuspendLayout();
            this.gbSearchInfo.SuspendLayout();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            // pnlNegative
            // 
            this.pnlNegative.AutoScroll = true;
            this.pnlNegative.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNegative.Location = new System.Drawing.Point(0, 524);
            this.pnlNegative.Name = "pnlNegative";
            this.pnlNegative.Size = new System.Drawing.Size(1102, 43);
            this.pnlNegative.TabIndex = 3;
            // 
            // usMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNegative);
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
        private System.Windows.Forms.FlowLayoutPanel pnlNegative;
    }
}
