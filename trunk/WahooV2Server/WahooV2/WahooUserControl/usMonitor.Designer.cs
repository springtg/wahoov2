using System;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTotalFiles = new System.Windows.Forms.TextBox();
            this.cbFilterSearch = new System.Windows.Forms.ComboBox();
            this.gridReport = new System.Windows.Forms.DataGridView();
            this.clFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataSendPrinter = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnlNavigative = new System.Windows.Forms.Panel();
            this.usPagingBar21 = new WahooV2.WahooUserControl.usPagingBar2();
            this.lbPage = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.dptDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbSearchInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usPagingBar31 = new WahooV2.WahooUserControl.usPagingBar3();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.gbResult.SuspendLayout();
            this.pnlNavigative.SuspendLayout();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReport.BackgroundColor = System.Drawing.Color.White;
            this.gridReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clFilename,
            this.clIpAddress,
            this.colDateDown,
            this.colDataSendPrinter,
            this.clSuccess,
            this.clIsSentToPrint});
            this.gridReport.Location = new System.Drawing.Point(3, 108);
            this.gridReport.MultiSelect = false;
            this.gridReport.Name = "gridReport";
            this.gridReport.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridReport.RowHeadersWidth = 20;
            this.gridReport.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReport.Size = new System.Drawing.Size(1100, 535);
            this.gridReport.TabIndex = 1;
            this.gridReport.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridReport_RowEnter);
            // 
            // clFilename
            // 
            this.clFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clFilename.DataPropertyName = "filename";
            this.clFilename.FillWeight = 150F;
            this.clFilename.HeaderText = "File name";
            this.clFilename.Name = "clFilename";
            this.clFilename.ReadOnly = true;
            // 
            // clIpAddress
            // 
            this.clIpAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clIpAddress.DataPropertyName = "IpAddress";
            this.clIpAddress.FillWeight = 51F;
            this.clIpAddress.HeaderText = "Ip address";
            this.clIpAddress.Name = "clIpAddress";
            this.clIpAddress.ReadOnly = true;
            // 
            // colDateDown
            // 
            this.colDateDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateDown.DataPropertyName = "TimeDownloaded";
            dataGridViewCellStyle3.Format = "MM/dd/yyyy hh:mm:ss tt";
            this.colDateDown.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDateDown.FillWeight = 51.11018F;
            this.colDateDown.HeaderText = "Dowload Date";
            this.colDateDown.Name = "colDateDown";
            this.colDateDown.ReadOnly = true;
            // 
            // colDataSendPrinter
            // 
            this.colDataSendPrinter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDataSendPrinter.DataPropertyName = "TimeSentToPrint";
            dataGridViewCellStyle4.Format = "MM/dd/yyyy hh:mm:ss tt";
            this.colDataSendPrinter.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDataSendPrinter.FillWeight = 50F;
            this.colDataSendPrinter.HeaderText = "Time send to Printer";
            this.colDataSendPrinter.Name = "colDataSendPrinter";
            this.colDataSendPrinter.ReadOnly = true;
            // 
            // clSuccess
            // 
            this.clSuccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clSuccess.DataPropertyName = "Downloaded";
            this.clSuccess.FillWeight = 25.55509F;
            this.clSuccess.HeaderText = "Downloaded";
            this.clSuccess.Name = "clSuccess";
            this.clSuccess.ReadOnly = true;
            // 
            // clIsSentToPrint
            // 
            this.clIsSentToPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clIsSentToPrint.DataPropertyName = "SentToPrint";
            this.clIsSentToPrint.FillWeight = 30.66611F;
            this.clIsSentToPrint.HeaderText = "Sent to print";
            this.clIsSentToPrint.Name = "clIsSentToPrint";
            this.clIsSentToPrint.ReadOnly = true;
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
            this.gbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbResult.Enabled = false;
            this.gbResult.Location = new System.Drawing.Point(16, 329);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(1100, 116);
            this.gbResult.TabIndex = 2;
            this.gbResult.TabStop = false;
            this.gbResult.Visible = false;
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
            // pnlNavigative
            // 
            this.pnlNavigative.Controls.Add(this.usPagingBar21);
            this.pnlNavigative.Controls.Add(this.lbPage);
            this.pnlNavigative.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigative.Location = new System.Drawing.Point(0, 649);
            this.pnlNavigative.Name = "pnlNavigative";
            this.pnlNavigative.Size = new System.Drawing.Size(1106, 41);
            this.pnlNavigative.TabIndex = 3;
            // 
            // usPagingBar21
            // 
            this.usPagingBar21.Location = new System.Drawing.Point(371, 8);
            this.usPagingBar21.Name = "usPagingBar21";
            this.usPagingBar21.Size = new System.Drawing.Size(413, 25);
            this.usPagingBar21.TabIndex = 11;
            // 
            // lbPage
            // 
            this.lbPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(1065, 14);
            this.lbPage.Name = "lbPage";
            this.lbPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbPage.Size = new System.Drawing.Size(0, 13);
            this.lbPage.TabIndex = 3;
            this.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.gbSearchInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchInfo.Controls.Add(this.usPagingBar31);
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
            this.gbSearchInfo.Size = new System.Drawing.Size(1100, 99);
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
            // usPagingBar31
            // 
            this.usPagingBar31.Location = new System.Drawing.Point(709, 69);
            this.usPagingBar31.Name = "usPagingBar31";
            this.usPagingBar31.Size = new System.Drawing.Size(365, 24);
            this.usPagingBar31.TabIndex = 11;
            // 
            // usMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNavigative);
            this.Controls.Add(this.gridReport);
            this.Controls.Add(this.gbSearchInfo);
            this.Controls.Add(this.gbResult);
            this.Name = "usMonitor";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.usMonitor_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.usMonitor_ControlAdded);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.pnlNavigative.ResumeLayout(false);
            this.pnlNavigative.PerformLayout();
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
        private System.Windows.Forms.Panel pnlNavigative;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataSendPrinter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsSentToPrint;
        private System.Windows.Forms.Label lbPage;
        private usPagingBar2 usPagingBar21;
        private usPagingBar3 usPagingBar31;
    }
}
