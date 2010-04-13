namespace WahooV2.WahooUserControl
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.gridClient.Location = new System.Drawing.Point(3, 3);
            this.gridClient.MultiSelect = false;
            this.gridClient.Name = "gridClient";
            this.gridClient.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClient.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClient.Size = new System.Drawing.Size(1102, 686);
            this.gridClient.TabIndex = 2;
            this.gridClient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridClient_MouseDown);
            this.gridClient.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClient_RowEnter);
            this.gridClient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClient_CellDoubleClick);
            this.gridClient.SelectionChanged += new System.EventHandler(this.gridClient_SelectionChanged);
            // 
            // clClientCode
            // 
            this.clClientCode.DataPropertyName = "ClientCode";
            this.clClientCode.HeaderText = "Code";
            this.clClientCode.Name = "clClientCode";
            this.clClientCode.ReadOnly = true;
            this.clClientCode.Width = 50;
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
            this.clName.DataPropertyName = "Name";
            this.clName.HeaderText = "Client Name";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            this.clName.Width = 130;
            // 
            // clAddress1
            // 
            this.clAddress1.DataPropertyName = "Address1";
            this.clAddress1.HeaderText = "Address 1";
            this.clAddress1.Name = "clAddress1";
            this.clAddress1.ReadOnly = true;
            // 
            // clAddress2
            // 
            this.clAddress2.DataPropertyName = "Address2";
            this.clAddress2.HeaderText = "Address 2";
            this.clAddress2.Name = "clAddress2";
            this.clAddress2.ReadOnly = true;
            // 
            // clCity
            // 
            this.clCity.DataPropertyName = "City";
            this.clCity.HeaderText = "City";
            this.clCity.Name = "clCity";
            this.clCity.ReadOnly = true;
            this.clCity.Width = 70;
            // 
            // clState
            // 
            this.clState.DataPropertyName = "State";
            this.clState.HeaderText = "State";
            this.clState.Name = "clState";
            this.clState.ReadOnly = true;
            this.clState.Width = 70;
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
            this.clPhone.DataPropertyName = "Phone";
            this.clPhone.HeaderText = "Phone";
            this.clPhone.Name = "clPhone";
            this.clPhone.ReadOnly = true;
            this.clPhone.Width = 70;
            // 
            // clMail
            // 
            this.clMail.DataPropertyName = "Mail";
            this.clMail.HeaderText = "Mail";
            this.clMail.Name = "clMail";
            this.clMail.ReadOnly = true;
            this.clMail.Width = 70;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 300;
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
            this.newClientItem.Image = global::WahooV2.Properties.Resources.AddClient;
            this.newClientItem.Name = "newClientItem";
            this.newClientItem.Size = new System.Drawing.Size(146, 22);
            this.newClientItem.Text = "New Client";
            this.newClientItem.Click += new System.EventHandler(this.newClientItem_Click);
            // 
            // editClientItem
            // 
            this.editClientItem.Image = global::WahooV2.Properties.Resources.EditClient;
            this.editClientItem.Name = "editClientItem";
            this.editClientItem.Size = new System.Drawing.Size(146, 22);
            this.editClientItem.Text = "Edit Client";
            this.editClientItem.Click += new System.EventHandler(this.editClientItem_Click);
            // 
            // deleteClientItem
            // 
            this.deleteClientItem.Image = global::WahooV2.Properties.Resources.ClientDelete;
            this.deleteClientItem.Name = "deleteClientItem";
            this.deleteClientItem.Size = new System.Drawing.Size(146, 22);
            this.deleteClientItem.Text = "Delete Client";
            this.deleteClientItem.Click += new System.EventHandler(this.deleteClientItem_Click);
            // 
            // itemClientMonitor
            // 
            this.itemClientMonitor.Name = "itemClientMonitor";
            this.itemClientMonitor.Size = new System.Drawing.Size(146, 22);
            this.itemClientMonitor.Text = "Monitor";
            // 
            // ucClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridClient);
            this.Name = "ucClients";
            this.Size = new System.Drawing.Size(1102, 686);
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
