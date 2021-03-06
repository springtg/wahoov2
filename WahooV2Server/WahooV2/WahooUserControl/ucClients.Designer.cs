﻿namespace WahooV2.WahooUserControl
{
    partial class ucClients
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
            this.gridClient = new System.Windows.Forms.DataGridView();
            this.clClientCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAddress2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clZip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLicenseKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newClientItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editClientItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteClientItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemClientMonitor = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridClient)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridClient
            // 
            this.gridClient.AllowUserToAddRows = false;
            this.gridClient.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridClient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridClient.BackgroundColor = System.Drawing.Color.White;
            this.gridClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clClientCode,
            this.clDateCreated,
            this.clDateUpdated,
            this.clName,
            this.clAddress1,
            this.clAddress2,
            this.clCity,
            this.clState,
            this.clZip,
            this.clPhone,
            this.clMail,
            this.clDescription,
            this.clId,
            this.clContactName,
            this.clLicenseKey});
            this.gridClient.ContextMenuStrip = this.menuStrip;
            this.gridClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClient.Location = new System.Drawing.Point(0, 0);
            this.gridClient.MultiSelect = false;
            this.gridClient.Name = "gridClient";
            this.gridClient.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridClient.RowHeadersWidth = 30;
            this.gridClient.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClient.Size = new System.Drawing.Size(1106, 690);
            this.gridClient.TabIndex = 2;
            this.gridClient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridClient_MouseDown);
            this.gridClient.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClient_RowEnter);
            this.gridClient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClient_CellDoubleClick);
            this.gridClient.SelectionChanged += new System.EventHandler(this.gridClient_SelectionChanged);
            // 
            // clClientCode
            // 
            this.clClientCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clClientCode.DataPropertyName = "ClientCode";
            this.clClientCode.FillWeight = 70F;
            this.clClientCode.HeaderText = "Code";
            this.clClientCode.Name = "clClientCode";
            this.clClientCode.ReadOnly = true;
            // 
            // clDateCreated
            // 
            this.clDateCreated.DataPropertyName = "DateCreated";
            this.clDateCreated.HeaderText = "DateCreated";
            this.clDateCreated.Name = "clDateCreated";
            this.clDateCreated.ReadOnly = true;
            this.clDateCreated.Visible = false;
            // 
            // clDateUpdated
            // 
            this.clDateUpdated.DataPropertyName = "DateUpdated";
            this.clDateUpdated.HeaderText = "DateUpdated";
            this.clDateUpdated.Name = "clDateUpdated";
            this.clDateUpdated.ReadOnly = true;
            this.clDateUpdated.Visible = false;
            // 
            // clName
            // 
            this.clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clName.DataPropertyName = "Name";
            this.clName.FillWeight = 130F;
            this.clName.HeaderText = "Client Name";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // clAddress1
            // 
            this.clAddress1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clAddress1.DataPropertyName = "Address1";
            this.clAddress1.HeaderText = "Address 1";
            this.clAddress1.Name = "clAddress1";
            this.clAddress1.ReadOnly = true;
            // 
            // clAddress2
            // 
            this.clAddress2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clAddress2.DataPropertyName = "Address2";
            this.clAddress2.HeaderText = "Address 2";
            this.clAddress2.Name = "clAddress2";
            this.clAddress2.ReadOnly = true;
            // 
            // clCity
            // 
            this.clCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clCity.DataPropertyName = "City";
            this.clCity.HeaderText = "City";
            this.clCity.Name = "clCity";
            this.clCity.ReadOnly = true;
            // 
            // clState
            // 
            this.clState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clState.DataPropertyName = "State";
            this.clState.FillWeight = 70F;
            this.clState.HeaderText = "State";
            this.clState.Name = "clState";
            this.clState.ReadOnly = true;
            // 
            // clZip
            // 
            this.clZip.DataPropertyName = "Zip";
            this.clZip.HeaderText = "Zip";
            this.clZip.Name = "clZip";
            this.clZip.ReadOnly = true;
            this.clZip.Visible = false;
            this.clZip.Width = 50;
            // 
            // clPhone
            // 
            this.clPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clPhone.DataPropertyName = "Phone";
            this.clPhone.FillWeight = 90F;
            this.clPhone.HeaderText = "Phone";
            this.clPhone.Name = "clPhone";
            this.clPhone.ReadOnly = true;
            // 
            // clMail
            // 
            this.clMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clMail.DataPropertyName = "Mail";
            this.clMail.FillWeight = 90F;
            this.clMail.HeaderText = "Mail";
            this.clMail.Name = "clMail";
            this.clMail.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.FillWeight = 250F;
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            // 
            // clId
            // 
            this.clId.DataPropertyName = "Id";
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            // 
            // clContactName
            // 
            this.clContactName.DataPropertyName = "ContactName";
            this.clContactName.HeaderText = "Contact Name";
            this.clContactName.Name = "clContactName";
            this.clContactName.ReadOnly = true;
            this.clContactName.Visible = false;
            // 
            // clLicenseKey
            // 
            this.clLicenseKey.DataPropertyName = "LicenseKey";
            this.clLicenseKey.HeaderText = "License Key";
            this.clLicenseKey.Name = "clLicenseKey";
            this.clLicenseKey.ReadOnly = true;
            this.clLicenseKey.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newClientItem,
            this.editClientItem,
            this.deleteClientItem,
            this.itemClientMonitor});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(147, 92);
            // 
            // newClientItem
            // 
            this.newClientItem.Image = global::WahooV2.Properties.Resources.wh_user_add;
            this.newClientItem.Name = "newClientItem";
            this.newClientItem.Size = new System.Drawing.Size(146, 22);
            this.newClientItem.Text = "New Client";
            this.newClientItem.Click += new System.EventHandler(this.newClientItem_Click);
            // 
            // editClientItem
            // 
            this.editClientItem.Image = global::WahooV2.Properties.Resources.wh_user_edit;
            this.editClientItem.Name = "editClientItem";
            this.editClientItem.Size = new System.Drawing.Size(146, 22);
            this.editClientItem.Text = "Edit Client";
            this.editClientItem.Click += new System.EventHandler(this.editClientItem_Click);
            // 
            // deleteClientItem
            // 
            this.deleteClientItem.Image = global::WahooV2.Properties.Resources.wh_user_delete;
            this.deleteClientItem.Name = "deleteClientItem";
            this.deleteClientItem.Size = new System.Drawing.Size(146, 22);
            this.deleteClientItem.Text = "Delete Client";
            this.deleteClientItem.Click += new System.EventHandler(this.deleteClientItem_Click);
            // 
            // itemClientMonitor
            // 
            this.itemClientMonitor.Image = global::WahooV2.Properties.Resources.wh_report;
            this.itemClientMonitor.Name = "itemClientMonitor";
            this.itemClientMonitor.Size = new System.Drawing.Size(146, 22);
            this.itemClientMonitor.Text = "Monitor";
            this.itemClientMonitor.Click += new System.EventHandler(this.itemClientMonitor_Click);
            // 
            // ucClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridClient);
            this.Name = "ucClients";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.ucClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridClient)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridClient;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newClientItem;
        private System.Windows.Forms.ToolStripMenuItem editClientItem;
        private System.Windows.Forms.ToolStripMenuItem deleteClientItem;
        private System.Windows.Forms.ToolStripMenuItem itemClientMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clClientCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAddress2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clState;
        private System.Windows.Forms.DataGridViewTextBoxColumn clZip;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLicenseKey;
    }
}
