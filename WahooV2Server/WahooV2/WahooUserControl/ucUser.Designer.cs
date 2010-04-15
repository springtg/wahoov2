namespace WahooV2.WahooUserControl
{
    partial class ucUser
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
            this.gridUser = new System.Windows.Forms.DataGridView();
            this.menuTrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOrganization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIs_Deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDate_Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDate_Updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            this.menuTrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridUser
            // 
            this.gridUser.AllowUserToAddRows = false;
            this.gridUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUser.BackgroundColor = System.Drawing.Color.White;
            this.gridUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUsername,
            this.Role,
            this.clFirstname,
            this.clLastName,
            this.clOrganization,
            this.clEmail,
            this.clPhone,
            this.clDescription,
            this.clId,
            this.clPassword,
            this.clIs_Deleted,
            this.clDate_Created,
            this.clDate_Updated});
            this.gridUser.ContextMenuStrip = this.menuTrip;
            this.gridUser.Location = new System.Drawing.Point(0, 0);
            this.gridUser.MultiSelect = false;
            this.gridUser.Name = "gridUser";
            this.gridUser.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridUser.RowHeadersWidth = 30;
            this.gridUser.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUser.Size = new System.Drawing.Size(1106, 690);
            this.gridUser.TabIndex = 1;
            this.gridUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridUser_MouseDown);
            this.gridUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUser_CellDoubleClick);
            this.gridUser.SelectionChanged += new System.EventHandler(this.gridUser_SelectionChanged);
            // 
            // menuTrip
            // 
            this.menuTrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserItem,
            this.editUserItem,
            this.deleteUserItem});
            this.menuTrip.Name = "menuTrip";
            this.menuTrip.Size = new System.Drawing.Size(142, 70);
            // 
            // newUserItem
            // 
            this.newUserItem.Image = global::WahooV2.Properties.Resources.wh_user_add;
            this.newUserItem.Name = "newUserItem";
            this.newUserItem.Size = new System.Drawing.Size(141, 22);
            this.newUserItem.Text = "New User";
            this.newUserItem.Click += new System.EventHandler(this.NewUserItem_Click);
            // 
            // editUserItem
            // 
            this.editUserItem.Image = global::WahooV2.Properties.Resources.wh_user_edit;
            this.editUserItem.Name = "editUserItem";
            this.editUserItem.Size = new System.Drawing.Size(141, 22);
            this.editUserItem.Text = "Edit User";
            this.editUserItem.Click += new System.EventHandler(this.EditUserItem_Click);
            // 
            // deleteUserItem
            // 
            this.deleteUserItem.Image = global::WahooV2.Properties.Resources.wh_user_delete;
            this.deleteUserItem.Name = "deleteUserItem";
            this.deleteUserItem.Size = new System.Drawing.Size(141, 22);
            this.deleteUserItem.Text = "Delete User";
            this.deleteUserItem.Click += new System.EventHandler(this.DeleteUserItem_Click);
            // 
            // clUsername
            // 
            this.clUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clUsername.DataPropertyName = "Username";
            this.clUsername.FillWeight = 120F;
            this.clUsername.HeaderText = "Username";
            this.clUsername.Name = "clUsername";
            this.clUsername.ReadOnly = true;
            // 
            // Role
            // 
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            this.Role.Visible = false;
            // 
            // clFirstname
            // 
            this.clFirstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clFirstname.DataPropertyName = "Firstname";
            this.clFirstname.FillWeight = 120F;
            this.clFirstname.HeaderText = "First Name";
            this.clFirstname.Name = "clFirstname";
            this.clFirstname.ReadOnly = true;
            // 
            // clLastName
            // 
            this.clLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clLastName.DataPropertyName = "LastName";
            this.clLastName.FillWeight = 120F;
            this.clLastName.HeaderText = "Last Name";
            this.clLastName.Name = "clLastName";
            this.clLastName.ReadOnly = true;
            // 
            // clOrganization
            // 
            this.clOrganization.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clOrganization.DataPropertyName = "Organization";
            this.clOrganization.FillWeight = 120F;
            this.clOrganization.HeaderText = "Organization";
            this.clOrganization.Name = "clOrganization";
            this.clOrganization.ReadOnly = true;
            // 
            // clEmail
            // 
            this.clEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clEmail.DataPropertyName = "Email";
            this.clEmail.FillWeight = 120F;
            this.clEmail.HeaderText = "Email";
            this.clEmail.Name = "clEmail";
            this.clEmail.ReadOnly = true;
            // 
            // clPhone
            // 
            this.clPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clPhone.DataPropertyName = "Phone";
            this.clPhone.FillWeight = 120F;
            this.clPhone.HeaderText = "Phone Number";
            this.clPhone.Name = "clPhone";
            this.clPhone.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.FillWeight = 280F;
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
            // clPassword
            // 
            this.clPassword.DataPropertyName = "Password";
            this.clPassword.HeaderText = "Password";
            this.clPassword.Name = "clPassword";
            this.clPassword.ReadOnly = true;
            this.clPassword.Visible = false;
            // 
            // clIs_Deleted
            // 
            this.clIs_Deleted.DataPropertyName = "Is_Deleted";
            this.clIs_Deleted.HeaderText = "Is_Deleted";
            this.clIs_Deleted.Name = "clIs_Deleted";
            this.clIs_Deleted.ReadOnly = true;
            this.clIs_Deleted.Visible = false;
            // 
            // clDate_Created
            // 
            this.clDate_Created.DataPropertyName = "Date_Created";
            this.clDate_Created.HeaderText = "Date_Created";
            this.clDate_Created.Name = "clDate_Created";
            this.clDate_Created.ReadOnly = true;
            this.clDate_Created.Visible = false;
            // 
            // clDate_Updated
            // 
            this.clDate_Updated.DataPropertyName = "Date_Updated";
            this.clDate_Updated.HeaderText = "Date_Updated";
            this.clDate_Updated.Name = "clDate_Updated";
            this.clDate_Updated.ReadOnly = true;
            this.clDate_Updated.Visible = false;
            // 
            // ucUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gridUser);
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.ucUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            this.menuTrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridUser;
        private System.Windows.Forms.ContextMenuStrip menuTrip;
        private System.Windows.Forms.ToolStripMenuItem newUserItem;
        private System.Windows.Forms.ToolStripMenuItem editUserItem;
        private System.Windows.Forms.ToolStripMenuItem deleteUserItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIs_Deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDate_Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDate_Updated;
    }
}
