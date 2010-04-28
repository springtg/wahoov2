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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashboard));
            this.lblLine = new System.Windows.Forms.Label();
            this.gbLogInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogSize = new WahooV2.ExControl.TextBoxForNum();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
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
            this.tabEmailNotification = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEmailServer = new System.Windows.Forms.TabPage();
            this.txtServerPort = new WahooV2.ExControl.TextBoxForNum();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnEmailServerSettingSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmailServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabEmailAdress = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMessage = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSaveMessage = new System.Windows.Forms.Button();
            this.txtMailBody = new System.Windows.Forms.TextBox();
            this.txtMailSubject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startAllChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timerRefresh = new System.Timers.Timer();
            this.tmPicture = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbLogInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabLogHistory.SuspendLayout();
            this.tabAllLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistAllLog)).BeginInit();
            this.tabErrorLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorLog)).BeginInit();
            this.tabEmailNotification.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabEmailServer.SuspendLayout();
            this.tabEmailAdress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabMessage.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.gbLogInfo.Controls.Add(this.pictureBox2);
            this.gbLogInfo.Controls.Add(this.label1);
            this.gbLogInfo.Controls.Add(this.txtLogSize);
            this.gbLogInfo.Controls.Add(this.btnSave);
            this.gbLogInfo.Controls.Add(this.btnClear);
            this.gbLogInfo.Controls.Add(this.btnPause);
            this.gbLogInfo.Controls.Add(this.tabLogHistory);
            this.gbLogInfo.Location = new System.Drawing.Point(3, 418);
            this.gbLogInfo.Name = "gbLogInfo";
            this.gbLogInfo.Size = new System.Drawing.Size(1100, 269);
            this.gbLogInfo.TabIndex = 2;
            this.gbLogInfo.TabStop = false;
            this.gbLogInfo.Text = "Log Information";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(362, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1, 1);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(970, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log size:";
            // 
            // txtLogSize
            // 
            this.txtLogSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogSize.BNull = false;
            this.txtLogSize.Location = new System.Drawing.Point(1021, 241);
            this.txtLogSize.MaxLength = 2;
            this.txtLogSize.Name = "txtLogSize";
            this.txtLogSize.Size = new System.Drawing.Size(35, 20);
            this.txtLogSize.StrFormat = "";
            this.txtLogSize.TabIndex = 4;
            this.txtLogSize.Text = "0";
            this.txtLogSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLogSize.Value = null;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.Image = global::WahooV2.Properties.Resources.wh_save;
            this.btnSave.Location = new System.Drawing.Point(1060, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClear.Image = global::WahooV2.Properties.Resources.wh_delete;
            this.btnClear.Location = new System.Drawing.Point(39, 239);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.SystemColors.Control;
            this.btnPause.Image = global::WahooV2.Properties.Resources.wh_pause;
            this.btnPause.Location = new System.Drawing.Point(9, 239);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(24, 24);
            this.btnPause.TabIndex = 1;
            this.btnPause.Tag = "0";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tabLogHistory
            // 
            this.tabLogHistory.Controls.Add(this.tabAllLog);
            this.tabLogHistory.Controls.Add(this.tabErrorLog);
            this.tabLogHistory.Controls.Add(this.tabEmailNotification);
            this.tabLogHistory.ItemSize = new System.Drawing.Size(150, 18);
            this.tabLogHistory.Location = new System.Drawing.Point(6, 19);
            this.tabLogHistory.Name = "tabLogHistory";
            this.tabLogHistory.SelectedIndex = 0;
            this.tabLogHistory.Size = new System.Drawing.Size(1092, 216);
            this.tabLogHistory.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabLogHistory.TabIndex = 0;
            // 
            // tabAllLog
            // 
            this.tabAllLog.Controls.Add(this.gridHistAllLog);
            this.tabAllLog.Location = new System.Drawing.Point(4, 22);
            this.tabAllLog.Name = "tabAllLog";
            this.tabAllLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllLog.Size = new System.Drawing.Size(1084, 190);
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
            this.gridHistAllLog.Location = new System.Drawing.Point(-4, 3);
            this.gridHistAllLog.MultiSelect = false;
            this.gridHistAllLog.Name = "gridHistAllLog";
            this.gridHistAllLog.ReadOnly = true;
            this.gridHistAllLog.RowHeadersVisible = false;
            this.gridHistAllLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistAllLog.Size = new System.Drawing.Size(1089, 185);
            this.gridHistAllLog.TabIndex = 0;
            // 
            // clDescriptionAllLog
            // 
            this.clDescriptionAllLog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clDescriptionAllLog.DataPropertyName = "Description";
            this.clDescriptionAllLog.HeaderText = "Description";
            this.clDescriptionAllLog.Name = "clDescriptionAllLog";
            this.clDescriptionAllLog.ReadOnly = true;
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
            this.tabErrorLog.Size = new System.Drawing.Size(1084, 190);
            this.tabErrorLog.TabIndex = 1;
            this.tabErrorLog.Text = "Error Log";
            this.tabErrorLog.UseVisualStyleBackColor = true;
            // 
            // gridErrorLog
            // 
            this.gridErrorLog.AllowUserToAddRows = false;
            this.gridErrorLog.AllowUserToDeleteRows = false;
            this.gridErrorLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
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
            // tabEmailNotification
            // 
            this.tabEmailNotification.Controls.Add(this.tabControl1);
            this.tabEmailNotification.Location = new System.Drawing.Point(4, 22);
            this.tabEmailNotification.Name = "tabEmailNotification";
            this.tabEmailNotification.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmailNotification.Size = new System.Drawing.Size(1084, 190);
            this.tabEmailNotification.TabIndex = 2;
            this.tabEmailNotification.Text = "email notification";
            this.tabEmailNotification.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEmailServer);
            this.tabControl1.Controls.Add(this.tabEmailAdress);
            this.tabControl1.Controls.Add(this.tabMessage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 18);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1078, 184);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabEmailServer
            // 
            this.tabEmailServer.Controls.Add(this.button1);
            this.tabEmailServer.Controls.Add(this.txtServerPort);
            this.tabEmailServer.Controls.Add(this.txtPassword);
            this.tabEmailServer.Controls.Add(this.txtUsername);
            this.tabEmailServer.Controls.Add(this.btnEmailServerSettingSave);
            this.tabEmailServer.Controls.Add(this.label5);
            this.tabEmailServer.Controls.Add(this.label4);
            this.tabEmailServer.Controls.Add(this.label3);
            this.tabEmailServer.Controls.Add(this.txtEmailServer);
            this.tabEmailServer.Controls.Add(this.label2);
            this.tabEmailServer.Location = new System.Drawing.Point(4, 22);
            this.tabEmailServer.Name = "tabEmailServer";
            this.tabEmailServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmailServer.Size = new System.Drawing.Size(1070, 158);
            this.tabEmailServer.TabIndex = 0;
            this.tabEmailServer.Text = "Email Server Setting";
            this.tabEmailServer.UseVisualStyleBackColor = true;
            // 
            // txtServerPort
            // 
            this.txtServerPort.BNull = true;
            this.txtServerPort.Location = new System.Drawing.Point(78, 38);
            this.txtServerPort.MaxLength = 13;
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(192, 20);
            this.txtServerPort.StrFormat = "";
            this.txtServerPort.TabIndex = 3;
            this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServerPort.Value = null;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(78, 60);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // btnEmailServerSettingSave
            // 
            this.btnEmailServerSettingSave.Location = new System.Drawing.Point(105, 108);
            this.btnEmailServerSettingSave.Name = "btnEmailServerSettingSave";
            this.btnEmailServerSettingSave.Size = new System.Drawing.Size(166, 23);
            this.btnEmailServerSettingSave.TabIndex = 8;
            this.btnEmailServerSettingSave.Text = "Save Email Server Setting";
            this.btnEmailServerSettingSave.UseVisualStyleBackColor = true;
            this.btnEmailServerSettingSave.Click += new System.EventHandler(this.btnEmailServerSettingSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Server port:";
            // 
            // txtEmailServer
            // 
            this.txtEmailServer.Location = new System.Drawing.Point(78, 16);
            this.txtEmailServer.Name = "txtEmailServer";
            this.txtEmailServer.Size = new System.Drawing.Size(192, 20);
            this.txtEmailServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mail server:";
            // 
            // tabEmailAdress
            // 
            this.tabEmailAdress.Controls.Add(this.dataGridView1);
            this.tabEmailAdress.Location = new System.Drawing.Point(4, 22);
            this.tabEmailAdress.Name = "tabEmailAdress";
            this.tabEmailAdress.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmailAdress.Size = new System.Drawing.Size(1070, 158);
            this.tabEmailAdress.TabIndex = 1;
            this.tabEmailAdress.Text = "Email Adress List";
            this.tabEmailAdress.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(528, 152);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DisplayName";
            this.dataGridViewTextBoxColumn7.HeaderText = "Display Name";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn8.HeaderText = "Email";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // tabMessage
            // 
            this.tabMessage.Controls.Add(this.btnRefresh);
            this.tabMessage.Controls.Add(this.btnSaveMessage);
            this.tabMessage.Controls.Add(this.txtMailBody);
            this.tabMessage.Controls.Add(this.txtMailSubject);
            this.tabMessage.Controls.Add(this.label7);
            this.tabMessage.Controls.Add(this.label6);
            this.tabMessage.Location = new System.Drawing.Point(4, 22);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessage.Size = new System.Drawing.Size(1070, 158);
            this.tabMessage.TabIndex = 2;
            this.tabMessage.Text = "Message";
            this.tabMessage.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(616, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSaveMessage
            // 
            this.btnSaveMessage.Location = new System.Drawing.Point(616, 20);
            this.btnSaveMessage.Name = "btnSaveMessage";
            this.btnSaveMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMessage.TabIndex = 4;
            this.btnSaveMessage.Text = "Save";
            this.btnSaveMessage.UseVisualStyleBackColor = true;
            this.btnSaveMessage.Click += new System.EventHandler(this.btnSaveMessage_Click);
            // 
            // txtMailBody
            // 
            this.txtMailBody.Location = new System.Drawing.Point(104, 45);
            this.txtMailBody.Multiline = true;
            this.txtMailBody.Name = "txtMailBody";
            this.txtMailBody.Size = new System.Drawing.Size(494, 107);
            this.txtMailBody.TabIndex = 3;
            // 
            // txtMailSubject
            // 
            this.txtMailSubject.Location = new System.Drawing.Point(104, 20);
            this.txtMailSubject.Name = "txtMailSubject";
            this.txtMailSubject.Size = new System.Drawing.Size(494, 20);
            this.txtMailSubject.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Message body:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Subject:";
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
            // gridDashboard
            // 
            this.gridDashboard.AllowUserToAddRows = false;
            this.gridDashboard.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridDashboard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
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
            this.gridDashboard.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridDashboard_DataBindingComplete);
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
            this.clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clName.DataPropertyName = "ChannelName";
            this.clName.FillWeight = 150F;
            this.clName.HeaderText = "Channel Name";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.FillWeight = 300F;
            this.clDescription.HeaderText = "Channel Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            // 
            // clSent
            // 
            this.clSent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clSent.DataPropertyName = "Sent";
            this.clSent.FillWeight = 120F;
            this.clSent.HeaderText = "File(s) Sent";
            this.clSent.Name = "clSent";
            this.clSent.ReadOnly = true;
            // 
            // clError
            // 
            this.clError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clError.DataPropertyName = "Error";
            this.clError.FillWeight = 120F;
            this.clError.HeaderText = "File(s) Sent Error";
            this.clError.Name = "clError";
            this.clError.ReadOnly = true;
            // 
            // clClientConnected
            // 
            this.clClientConnected.DataPropertyName = "Img";
            this.clClientConnected.FillWeight = 120F;
            this.clClientConnected.HeaderText = "Connectivity";
            this.clClientConnected.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.clClientConnected.Name = "clClientConnected";
            this.clClientConnected.ReadOnly = true;
            this.clClientConnected.Width = 150;
            // 
            // clIsConnected
            // 
            this.clIsConnected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clIsConnected.DataPropertyName = "IsConnected";
            this.clIsConnected.HeaderText = "IsConnected";
            this.clIsConnected.Name = "clIsConnected";
            this.clIsConnected.ReadOnly = true;
            this.clIsConnected.Visible = false;
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
            // tmPicture
            // 
            this.tmPicture.Enabled = true;
            this.tmPicture.Tick += new System.EventHandler(this.tmPicture_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 391);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 1);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.gbLogInfo);
            this.Controls.Add(this.gridDashboard);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(1106, 690);
            this.Load += new System.EventHandler(this.ucDashboard_Load);
            this.gbLogInfo.ResumeLayout(false);
            this.gbLogInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabLogHistory.ResumeLayout(false);
            this.tabAllLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistAllLog)).EndInit();
            this.tabErrorLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorLog)).EndInit();
            this.tabEmailNotification.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabEmailServer.ResumeLayout(false);
            this.tabEmailServer.PerformLayout();
            this.tabEmailAdress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabMessage.ResumeLayout(false);
            this.tabMessage.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox gbLogInfo;
        private System.Windows.Forms.TabControl tabLogHistory;
        private System.Windows.Forms.TabPage tabAllLog;
        private System.Windows.Forms.DataGridView gridHistAllLog;
        private System.Windows.Forms.TabPage tabErrorLog;
        private System.Windows.Forms.DataGridView gridErrorLog;
        private System.Windows.Forms.DataGridView gridDashboard;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem startAllChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopChannelToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Timers.Timer timerRefresh;
        private System.Windows.Forms.Timer tmPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescriptionAllLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdChannelAllLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdHistAllLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private WahooV2.ExControl.TextBoxForNum txtLogSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatusExecute;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clError;
        private System.Windows.Forms.DataGridViewImageColumn clClientConnected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsConnected;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabEmailNotification;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEmailServer;
        private System.Windows.Forms.TabPage tabEmailAdress;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnEmailServerSettingSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmailServer;
        private System.Windows.Forms.Label label2;
        private WahooV2.ExControl.TextBoxForNum txtServerPort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TabPage tabMessage;
        private System.Windows.Forms.TextBox txtMailBody;
        private System.Windows.Forms.TextBox txtMailSubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSaveMessage;
        private System.Windows.Forms.Button button1;
    }
}
