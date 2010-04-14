namespace WahooV2.WahooUserControl
{
    partial class ucDashboard
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashboard));
            this.lblLine = new System.Windows.Forms.Label();
            this.gbLogInfo = new System.Windows.Forms.GroupBox();
            this.tabLogHistory = new System.Windows.Forms.TabControl();
            this.tabAllLog = new System.Windows.Forms.TabPage();
            this.gridHistAllLog = new System.Windows.Forms.DataGridView();
            this.clDescriptionAllLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIdChannelAllLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIdHistAllLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabErrorLog = new System.Windows.Forms.TabPage();
            this.gridErrorLog = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDashboard = new System.Windows.Forms.DataGridView();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIdClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatusExecute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClientConnected = new System.Windows.Forms.DataGridViewImageColumn();
            this.clIsConnected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startAllChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timerRefresh = new System.Timers.Timer();
            this.gbLogInfo.SuspendLayout();
            this.tabLogHistory.SuspendLayout();
            this.tabAllLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistAllLog)).BeginInit();
            this.tabErrorLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboard)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLine.Location = new System.Drawing.Point(3, 411);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(1106, 2);
            this.lblLine.TabIndex = 1;
            // 
            // gbLogInfo
            // 
            this.gbLogInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLogInfo.Controls.Add(this.tabLogHistory);
            this.gbLogInfo.Location = new System.Drawing.Point(3, 418);
            this.gbLogInfo.Name = "gbLogInfo";
            this.gbLogInfo.Size = new System.Drawing.Size(1103, 269);
            this.gbLogInfo.TabIndex = 2;
            this.gbLogInfo.TabStop = false;
            this.gbLogInfo.Text = "Log Information";
            // 
            // tabLogHistory
            // 
            this.tabLogHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabLogHistory.Controls.Add(this.tabAllLog);
            this.tabLogHistory.Controls.Add(this.tabErrorLog);
            this.tabLogHistory.Location = new System.Drawing.Point(6, 19);
            this.tabLogHistory.Name = "tabLogHistory";
            this.tabLogHistory.SelectedIndex = 0;
            this.tabLogHistory.Size = new System.Drawing.Size(1095, 216);
            this.tabLogHistory.TabIndex = 0;
            // 
            // tabAllLog
            // 
            this.tabAllLog.Controls.Add(this.gridHistAllLog);
            this.tabAllLog.Location = new System.Drawing.Point(4, 22);
            this.tabAllLog.Name = "tabAllLog";
            this.tabAllLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllLog.Size = new System.Drawing.Size(1087, 190);
            this.tabAllLog.TabIndex = 0;
            this.tabAllLog.Text = "All Log";
            this.tabAllLog.UseVisualStyleBackColor = true;
            // 
            // gridHistAllLog
            // 
            this.gridHistAllLog.AllowUserToAddRows = false;
            this.gridHistAllLog.AllowUserToDeleteRows = false;
            this.gridHistAllLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHistAllLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistAllLog.ColumnHeadersVisible = false;
            this.gridHistAllLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDescriptionAllLog,
            this.clIdChannelAllLog,
            this.dataGridViewTextBoxColumn1,
            this.clIdHistAllLog});
            this.gridHistAllLog.Location = new System.Drawing.Point(3, 3);
            this.gridHistAllLog.MultiSelect = false;
            this.gridHistAllLog.Name = "gridHistAllLog";
            this.gridHistAllLog.ReadOnly = true;
            this.gridHistAllLog.RowHeadersVisible = false;
            this.gridHistAllLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistAllLog.Size = new System.Drawing.Size(1085, 185);
            this.gridHistAllLog.TabIndex = 0;
            // 
            // clDescriptionAllLog
            // 
            this.clDescriptionAllLog.DataPropertyName = "Description";
            this.clDescriptionAllLog.HeaderText = "Description";
            this.clDescriptionAllLog.Name = "clDescriptionAllLog";
            this.clDescriptionAllLog.ReadOnly = true;
            this.clDescriptionAllLog.Width = 750;
            // 
            // clIdChannelAllLog
            // 
            this.clIdChannelAllLog.DataPropertyName = "IdChannel";
            this.clIdChannelAllLog.HeaderText = "IdChannel";
            this.clIdChannelAllLog.Name = "clIdChannelAllLog";
            this.clIdChannelAllLog.ReadOnly = true;
            this.clIdChannelAllLog.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn1.HeaderText = "Status";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // clIdHistAllLog
            // 
            this.clIdHistAllLog.DataPropertyName = "Id";
            this.clIdHistAllLog.HeaderText = "Id";
            this.clIdHistAllLog.Name = "clIdHistAllLog";
            this.clIdHistAllLog.ReadOnly = true;
            this.clIdHistAllLog.Visible = false;
            // 
            // tabErrorLog
            // 
            this.tabErrorLog.Controls.Add(this.gridErrorLog);
            this.tabErrorLog.Location = new System.Drawing.Point(4, 22);
            this.tabErrorLog.Name = "tabErrorLog";
            this.tabErrorLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrorLog.Size = new System.Drawing.Size(1087, 190);
            this.tabErrorLog.TabIndex = 1;
            this.tabErrorLog.Text = "Error Log";
            this.tabErrorLog.UseVisualStyleBackColor = true;
            // 
            // gridErrorLog
            // 
            this.gridErrorLog.AllowUserToAddRows = false;
            this.gridErrorLog.AllowUserToDeleteRows = false;
            this.gridErrorLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridErrorLog.ColumnHeadersVisible = false;
            this.gridErrorLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.gridErrorLog.Location = new System.Drawing.Point(3, 3);
            this.gridErrorLog.MultiSelect = false;
            this.gridErrorLog.Name = "gridErrorLog";
            this.gridErrorLog.ReadOnly = true;
            this.gridErrorLog.RowHeadersVisible = false;
            this.gridErrorLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridErrorLog.Size = new System.Drawing.Size(1080, 185);
            this.gridErrorLog.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 750;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IdChannel";
            this.dataGridViewTextBoxColumn3.HeaderText = "IdChannel";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn4.HeaderText = "Status";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn5.HeaderText = "Id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // gridDashboard
            // 
            this.gridDashboard.AllowUserToAddRows = false;
            this.gridDashboard.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridDashboard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDashboard.BackgroundColor = System.Drawing.Color.White;
            this.gridDashboard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDashboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clId,
            this.clIdClient,
            this.clStatusExecute,
            this.clName,
            this.clDescription,
            this.clSent,
            this.clError,
            this.clClientConnected,
            this.clIsConnected});
            this.gridDashboard.ContextMenuStrip = this.menuStrip;
            this.gridDashboard.Location = new System.Drawing.Point(0, 0);
            this.gridDashboard.MultiSelect = false;
            this.gridDashboard.Name = "gridDashboard";
            this.gridDashboard.ReadOnly = true;
            this.gridDashboard.RowHeadersWidth = 30;
            this.gridDashboard.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridDashboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDashboard.ShowRowErrors = false;
            this.gridDashboard.Size = new System.Drawing.Size(1106, 390);
            this.gridDashboard.TabIndex = 0;
            this.gridDashboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridDashboard_MouseDown);
            this.gridDashboard.SelectionChanged += new System.EventHandler(this.gridDashboard_SelectionChanged);
            // 
            // clId
            // 
            this.clId.DataPropertyName = "Id";
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            // 
            // clIdClient
            // 
            this.clIdClient.DataPropertyName = "IdClient";
            this.clIdClient.HeaderText = "IdClient";
            this.clIdClient.Name = "clIdClient";
            this.clIdClient.ReadOnly = true;
            this.clIdClient.Visible = false;
            // 
            // clStatusExecute
            // 
            this.clStatusExecute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clStatusExecute.DataPropertyName = "StatusExecute";
            this.clStatusExecute.HeaderText = "Status";
            this.clStatusExecute.Name = "clStatusExecute";
            this.clStatusExecute.ReadOnly = true;
            // 
            // clName
            // 
            this.clName.DataPropertyName = "ChannelName";
            this.clName.FillWeight = 150F;
            this.clName.HeaderText = "Channel Name";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            this.clName.Width = 150;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.FillWeight = 300F;
            this.clDescription.HeaderText = "Channel Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 310;
            // 
            // clSent
            // 
            this.clSent.DataPropertyName = "Sent";
            this.clSent.FillWeight = 120F;
            this.clSent.HeaderText = "File(s) Sent";
            this.clSent.Name = "clSent";
            this.clSent.ReadOnly = true;
            // 
            // clError
            // 
            this.clError.DataPropertyName = "Error";
            this.clError.FillWeight = 120F;
            this.clError.HeaderText = "File(s) Sent Error";
            this.clError.Name = "clError";
            this.clError.ReadOnly = true;
            this.clError.Width = 120;
            // 
            // clClientConnected
            // 
            this.clClientConnected.DataPropertyName = "Img";
            this.clClientConnected.FillWeight = 120F;
            this.clClientConnected.HeaderText = "Connectivity";
            this.clClientConnected.Name = "clClientConnected";
            this.clClientConnected.ReadOnly = true;
            this.clClientConnected.Width = 150;
            // 
            // clIsConnected
            // 
            this.clIsConnected.DataPropertyName = "IsConnected";
            this.clIsConnected.HeaderText = "IsConnected";
            this.clIsConnected.Name = "clIsConnected";
            this.clIsConnected.ReadOnly = true;
            this.clIsConnected.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAllChannelsToolStripMenuItem,
            this.stopAllChannelsToolStripMenuItem,
            this.resetAllChannelsToolStripMenuItem,
            this.pauseChannelToolStripMenuItem,
            this.stopChannelToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(175, 114);
            // 
            // startAllChannelsToolStripMenuItem
            // 
            this.startAllChannelsToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_start_all;
            this.startAllChannelsToolStripMenuItem.Name = "startAllChannelsToolStripMenuItem";
            this.startAllChannelsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.startAllChannelsToolStripMenuItem.Text = "Start All Channels";
            this.startAllChannelsToolStripMenuItem.Click += new System.EventHandler(this.startAllChannelsToolStripMenuItem_Click);
            // 
            // stopAllChannelsToolStripMenuItem
            // 
            this.stopAllChannelsToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_stop_all;
            this.stopAllChannelsToolStripMenuItem.Name = "stopAllChannelsToolStripMenuItem";
            this.stopAllChannelsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.stopAllChannelsToolStripMenuItem.Text = "Stop All Channels";
            this.stopAllChannelsToolStripMenuItem.Click += new System.EventHandler(this.stopAllChannelsToolStripMenuItem_Click);
            // 
            // resetAllChannelsToolStripMenuItem
            // 
            this.resetAllChannelsToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_refresh;
            this.resetAllChannelsToolStripMenuItem.Name = "resetAllChannelsToolStripMenuItem";
            this.resetAllChannelsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.resetAllChannelsToolStripMenuItem.Text = "Reset All Channels";
            // 
            // pauseChannelToolStripMenuItem
            // 
            this.pauseChannelToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_start;
            this.pauseChannelToolStripMenuItem.Name = "pauseChannelToolStripMenuItem";
            this.pauseChannelToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pauseChannelToolStripMenuItem.Text = "Pause Channel";
            this.pauseChannelToolStripMenuItem.Click += new System.EventHandler(this.pauseChannelToolStripMenuItem_Click);
            // 
            // stopChannelToolStripMenuItem
            // 
            this.stopChannelToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_stop;
            this.stopChannelToolStripMenuItem.Name = "stopChannelToolStripMenuItem";
            this.stopChannelToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.stopChannelToolStripMenuItem.Text = "Stop Channel";
            this.stopChannelToolStripMenuItem.Click += new System.EventHandler(this.stopChannelToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "up.png");
            this.imageList.Images.SetKeyName(1, "down.png");
            this.imageList.Images.SetKeyName(2, "pause.png");
            this.imageList.Images.SetKeyName(3, "Start.png");
            this.imageList.Images.SetKeyName(4, "delete.png");
            this.imageList.Images.SetKeyName(5, "accept.png");
            this.imageList.Images.SetKeyName(6, "accept1.png");
            this.imageList.Images.SetKeyName(7, "StopAll.png");
            this.imageList.Images.SetKeyName(8, "Reset.png");
            this.imageList.Images.SetKeyName(9, "pause.png");
            this.imageList.Images.SetKeyName(10, "Start.png");
            this.imageList.Images.SetKeyName(11, "stop.png");
            this.imageList.Images.SetKeyName(12, "connecting.gif");
            this.imageList.Images.SetKeyName(13, "disconect.gif");
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.SynchronizingObject = this;
            this.timerRefresh.Elapsed += new System.Timers.ElapsedEventHandler(this.timerRefresh_Elapsed);
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.gbLogInfo);
            this.Controls.Add(this.gridDashboard);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.ucDashboard_Load);
            this.gbLogInfo.ResumeLayout(false);
            this.tabLogHistory.ResumeLayout(false);
            this.tabAllLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistAllLog)).EndInit();
            this.tabErrorLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboard)).EndInit();
            this.menuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timerRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox gbLogInfo;
        private System.Windows.Forms.TabControl tabLogHistory;
        private System.Windows.Forms.TabPage tabAllLog;
        private System.Windows.Forms.DataGridView gridHistAllLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescriptionAllLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdChannelAllLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdHistAllLog;
        private System.Windows.Forms.TabPage tabErrorLog;
        private System.Windows.Forms.DataGridView gridErrorLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView gridDashboard;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem startAllChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopChannelToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Timers.Timer timerRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatusExecute;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clError;
        private System.Windows.Forms.DataGridViewImageColumn clClientConnected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsConnected;
    }
}
