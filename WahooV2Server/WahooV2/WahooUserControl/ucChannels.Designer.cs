﻿namespace WahooV2.WahooUserControl
{
    partial class ucChannels
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridChannel = new System.Windows.Forms.DataGridView();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsDeployed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newChannelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editChannelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteChannelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deployChannelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deployAllChannelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undeployAllChannelItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridChannel)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridChannel
            // 
            this.gridChannel.AllowUserToAddRows = false;
            this.gridChannel.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridChannel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridChannel.BackgroundColor = System.Drawing.Color.White;
            this.gridChannel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChannel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChannel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clId,
            this.clStatus,
            this.clChannelName,
            this.clDescription,
            this.clIsDeployed});
            this.gridChannel.ContextMenuStrip = this.menuStrip;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridChannel.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChannel.Location = new System.Drawing.Point(0, 0);
            this.gridChannel.MultiSelect = false;
            this.gridChannel.Name = "gridChannel";
            this.gridChannel.ReadOnly = true;
            this.gridChannel.RowHeadersWidth = 30;
            this.gridChannel.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridChannel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChannel.Size = new System.Drawing.Size(1106, 690);
            this.gridChannel.TabIndex = 1;
            this.gridChannel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridChannel_MouseDown);
            this.gridChannel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChannel_CellDoubleClick);
            this.gridChannel.SelectionChanged += new System.EventHandler(this.gridChannel_SelectionChanged);
            // 
            // clId
            // 
            this.clId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clId.DataPropertyName = "Id";
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            // 
            // clStatus
            // 
            this.clStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clStatus.DataPropertyName = "Status";
            this.clStatus.FillWeight = 150F;
            this.clStatus.HeaderText = "Status";
            this.clStatus.Name = "clStatus";
            this.clStatus.ReadOnly = true;
            // 
            // clChannelName
            // 
            this.clChannelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clChannelName.DataPropertyName = "ChannelName";
            this.clChannelName.FillWeight = 300F;
            this.clChannelName.HeaderText = "Channel Name";
            this.clChannelName.Name = "clChannelName";
            this.clChannelName.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.FillWeight = 550F;
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            // 
            // clIsDeployed
            // 
            this.clIsDeployed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clIsDeployed.DataPropertyName = "IsDeployed";
            this.clIsDeployed.HeaderText = "IsDeployed";
            this.clIsDeployed.Name = "clIsDeployed";
            this.clIsDeployed.ReadOnly = true;
            this.clIsDeployed.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChannelItem,
            this.editChannelItem,
            this.deleteChannelItem,
            this.disableItem,
            this.deployChannelItem,
            this.deployAllChannelItem,
            this.undeployAllChannelItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(161, 158);
            // 
            // newChannelItem
            // 
            this.newChannelItem.Image = global::WahooV2.Properties.Resources.wh_channel_add;
            this.newChannelItem.Name = "newChannelItem";
            this.newChannelItem.Size = new System.Drawing.Size(160, 22);
            this.newChannelItem.Text = "New Channel";
            this.newChannelItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // editChannelItem
            // 
            this.editChannelItem.Image = global::WahooV2.Properties.Resources.wh_channel_edit;
            this.editChannelItem.Name = "editChannelItem";
            this.editChannelItem.Size = new System.Drawing.Size(160, 22);
            this.editChannelItem.Text = "Edit Channel";
            this.editChannelItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // deleteChannelItem
            // 
            this.deleteChannelItem.Image = global::WahooV2.Properties.Resources.wh_channel_delete;
            this.deleteChannelItem.Name = "deleteChannelItem";
            this.deleteChannelItem.Size = new System.Drawing.Size(160, 22);
            this.deleteChannelItem.Text = "Delete Channel";
            this.deleteChannelItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // disableItem
            // 
            this.disableItem.Image = global::WahooV2.Properties.Resources.wh_lock;
            this.disableItem.Name = "disableItem";
            this.disableItem.Size = new System.Drawing.Size(160, 22);
            this.disableItem.Text = "Disable";
            this.disableItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // deployChannelItem
            // 
            this.deployChannelItem.Image = global::WahooV2.Properties.Resources.wh_go;
            this.deployChannelItem.Name = "deployChannelItem";
            this.deployChannelItem.Size = new System.Drawing.Size(160, 22);
            this.deployChannelItem.Text = "Deploy Channel";
            this.deployChannelItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // deployAllChannelItem
            // 
            this.deployAllChannelItem.Image = global::WahooV2.Properties.Resources.wh_start_all;
            this.deployAllChannelItem.Name = "deployAllChannelItem";
            this.deployAllChannelItem.Size = new System.Drawing.Size(160, 22);
            this.deployAllChannelItem.Text = "Deploy All";
            this.deployAllChannelItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // undeployAllChannelItem
            // 
            this.undeployAllChannelItem.Image = global::WahooV2.Properties.Resources.wh_stop_all;
            this.undeployAllChannelItem.Name = "undeployAllChannelItem";
            this.undeployAllChannelItem.Size = new System.Drawing.Size(160, 22);
            this.undeployAllChannelItem.Text = "Undeploy All";
            this.undeployAllChannelItem.Click += new System.EventHandler(this.ClickToolStripItem);
            // 
            // ucChannels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridChannel);
            this.Name = "ucChannels";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.ucChannels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridChannel)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridChannel;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newChannelItem;
        private System.Windows.Forms.ToolStripMenuItem editChannelItem;
        private System.Windows.Forms.ToolStripMenuItem deleteChannelItem;
        private System.Windows.Forms.ToolStripMenuItem disableItem;
        private System.Windows.Forms.ToolStripMenuItem deployChannelItem;
        private System.Windows.Forms.ToolStripMenuItem deployAllChannelItem;
        private System.Windows.Forms.ToolStripMenuItem undeployAllChannelItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsDeployed;
    }
}
