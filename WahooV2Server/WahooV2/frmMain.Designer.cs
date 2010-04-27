namespace WahooV2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.xpPanelLeft = new UIComponents.XPPanelGroup();
            this.xpPanelOther = new UIComponents.XPPanel(100);
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.xpPanelClient = new UIComponents.XPPanel(136);
            this.linkReport = new System.Windows.Forms.LinkLabel();
            this.linkDeleteClient = new System.Windows.Forms.LinkLabel();
            this.linkEditClient = new System.Windows.Forms.LinkLabel();
            this.linkNewClient = new System.Windows.Forms.LinkLabel();
            this.xpPanelUser = new UIComponents.XPPanel(115);
            this.linkDeleteUser = new System.Windows.Forms.LinkLabel();
            this.linkEditUser = new System.Windows.Forms.LinkLabel();
            this.linkNewUser = new System.Windows.Forms.LinkLabel();
            this.xpPanelChannelTask = new UIComponents.XPPanel(216);
            this.linkUndeployAll = new System.Windows.Forms.LinkLabel();
            this.linkDeployAll = new System.Windows.Forms.LinkLabel();
            this.linkDeployChannel = new System.Windows.Forms.LinkLabel();
            this.linkDeleteChannel = new System.Windows.Forms.LinkLabel();
            this.linkEditChannel = new System.Windows.Forms.LinkLabel();
            this.linkEnableChannel = new System.Windows.Forms.LinkLabel();
            this.linkSaveChannel = new System.Windows.Forms.LinkLabel();
            this.linkNewChannel = new System.Windows.Forms.LinkLabel();
            this.xpPanelDashboardTask = new UIComponents.XPPanel(155);
            this.linkStopChannel = new System.Windows.Forms.LinkLabel();
            this.linkPauseChannel = new System.Windows.Forms.LinkLabel();
            this.linkStopAllChannel = new System.Windows.Forms.LinkLabel();
            this.linkResetAllChannel = new System.Windows.Forms.LinkLabel();
            this.linkStartAllChannel = new System.Windows.Forms.LinkLabel();
            this.xpPanelNWG = new UIComponents.XPPanel(172);
            this.linkSetting = new System.Windows.Forms.LinkLabel();
            this.linkBridge = new System.Windows.Forms.LinkLabel();
            this.linkDashboard = new System.Windows.Forms.LinkLabel();
            this.linkReportAll = new System.Windows.Forms.LinkLabel();
            this.linkClient = new System.Windows.Forms.LinkLabel();
            this.linkUser = new System.Windows.Forms.LinkLabel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.xpPanelGroupTop = new UIComponents.XPPanelGroup();
            this.lblTop = new System.Windows.Forms.Label();
            this.bgwMain = new System.ComponentModel.BackgroundWorker();
            this.tmMain = new System.Timers.Timer();
            this.xpPanelBottom = new UIComponents.XPPanelGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelConWebService = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmCheckConnect = new System.Windows.Forms.Timer(this.components);
            this.bgwCheckConnect = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelLeft)).BeginInit();
            this.xpPanelLeft.SuspendLayout();
            this.xpPanelOther.SuspendLayout();
            this.xpPanelClient.SuspendLayout();
            this.xpPanelUser.SuspendLayout();
            this.xpPanelChannelTask.SuspendLayout();
            this.xpPanelDashboardTask.SuspendLayout();
            this.xpPanelNWG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroupTop)).BeginInit();
            this.xpPanelGroupTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelBottom)).BeginInit();
            this.xpPanelBottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "");
            this.iconList.Images.SetKeyName(1, "");
            this.iconList.Images.SetKeyName(2, "");
            this.iconList.Images.SetKeyName(3, "");
            this.iconList.Images.SetKeyName(4, "");
            this.iconList.Images.SetKeyName(5, "");
            this.iconList.Images.SetKeyName(6, "");
            this.iconList.Images.SetKeyName(7, "");
            this.iconList.Images.SetKeyName(8, "");
            this.iconList.Images.SetKeyName(9, "");
            this.iconList.Images.SetKeyName(10, "");
            this.iconList.Images.SetKeyName(11, "");
            this.iconList.Images.SetKeyName(12, "setting.png");
            this.iconList.Images.SetKeyName(13, "Start.png");
            this.iconList.Images.SetKeyName(14, "stop.png");
            this.iconList.Images.SetKeyName(15, "StopAll.png");
            this.iconList.Images.SetKeyName(16, "Users.png");
            this.iconList.Images.SetKeyName(17, "clients.png");
            this.iconList.Images.SetKeyName(18, "delete.png");
            this.iconList.Images.SetKeyName(19, "disable.png");
            this.iconList.Images.SetKeyName(20, "edit.png");
            this.iconList.Images.SetKeyName(21, "enable.png");
            this.iconList.Images.SetKeyName(22, "export.png");
            this.iconList.Images.SetKeyName(23, "import.png");
            this.iconList.Images.SetKeyName(24, "new.png");
            this.iconList.Images.SetKeyName(25, "pause.png");
            this.iconList.Images.SetKeyName(26, "Reset.png");
            this.iconList.Images.SetKeyName(27, "rule.png");
            this.iconList.Images.SetKeyName(28, "save.png");
            // 
            // xpPanelLeft
            // 
            this.xpPanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xpPanelLeft.AutoScroll = true;
            this.xpPanelLeft.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelLeft.Controls.Add(this.xpPanelOther);
            this.xpPanelLeft.Controls.Add(this.xpPanelClient);
            this.xpPanelLeft.Controls.Add(this.xpPanelUser);
            this.xpPanelLeft.Controls.Add(this.xpPanelChannelTask);
            this.xpPanelLeft.Controls.Add(this.xpPanelDashboardTask);
            this.xpPanelLeft.Controls.Add(this.xpPanelNWG);
            this.xpPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.xpPanelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.xpPanelLeft.Name = "xpPanelLeft";
            this.xpPanelLeft.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelLeft.PanelGradient")));
            this.xpPanelLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xpPanelLeft.Size = new System.Drawing.Size(166, 712);
            this.xpPanelLeft.TabIndex = 0;
            // 
            // xpPanelOther
            // 
            this.xpPanelOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelOther.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelOther.Caption = "Other";
            this.xpPanelOther.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanelOther.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanelOther.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanelOther.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelOther.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanelOther.Controls.Add(this.linkLogout);
            this.xpPanelOther.Controls.Add(this.linkHelp);
            this.xpPanelOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpPanelOther.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanelOther.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanelOther.ImageItems.ImageSet = null;
            this.xpPanelOther.Location = new System.Drawing.Point(8, 842);
            this.xpPanelOther.Name = "xpPanelOther";
            this.xpPanelOther.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelOther.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelOther.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelOther.Size = new System.Drawing.Size(133, 100);
            this.xpPanelOther.TabIndex = 5;
            this.xpPanelOther.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanelOther.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanelOther.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanelOther.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // linkLogout
            // 
            this.linkLogout.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkLogout.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkLogout.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkLogout.Image = global::WahooV2.Properties.Resources.Logout;
            this.linkLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLogout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLogout.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkLogout.Location = new System.Drawing.Point(14, 45);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkLogout.Size = new System.Drawing.Size(115, 16);
            this.linkLogout.TabIndex = 32;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked);
            // 
            // linkHelp
            // 
            this.linkHelp.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkHelp.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkHelp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkHelp.Image = global::WahooV2.Properties.Resources.Help;
            this.linkHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkHelp.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkHelp.Location = new System.Drawing.Point(14, 45);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkHelp.Size = new System.Drawing.Size(115, 16);
            this.linkHelp.TabIndex = 31;
            this.linkHelp.TabStop = true;
            this.linkHelp.Text = "Help";
            this.linkHelp.Visible = false;
            this.linkHelp.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // xpPanelClient
            // 
            this.xpPanelClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelClient.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelClient.Caption = "Client Tasks";
            this.xpPanelClient.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanelClient.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanelClient.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanelClient.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelClient.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanelClient.Controls.Add(this.linkReport);
            this.xpPanelClient.Controls.Add(this.linkDeleteClient);
            this.xpPanelClient.Controls.Add(this.linkEditClient);
            this.xpPanelClient.Controls.Add(this.linkNewClient);
            this.xpPanelClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xpPanelClient.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanelClient.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanelClient.ImageItems.ImageSet = null;
            this.xpPanelClient.Location = new System.Drawing.Point(8, 698);
            this.xpPanelClient.Name = "xpPanelClient";
            this.xpPanelClient.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelClient.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelClient.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelClient.Size = new System.Drawing.Size(133, 136);
            this.xpPanelClient.TabIndex = 3;
            this.xpPanelClient.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanelClient.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanelClient.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanelClient.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // linkReport
            // 
            this.linkReport.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReport.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkReport.Image = global::WahooV2.Properties.Resources.wh_report;
            this.linkReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkReport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkReport.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReport.Location = new System.Drawing.Point(14, 105);
            this.linkReport.Name = "linkReport";
            this.linkReport.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkReport.Size = new System.Drawing.Size(115, 16);
            this.linkReport.TabIndex = 30;
            this.linkReport.TabStop = true;
            this.linkReport.Text = "Monitor";
            this.linkReport.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReport_LinkClicked);
            // 
            // linkDeleteClient
            // 
            this.linkDeleteClient.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteClient.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDeleteClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteClient.Image = global::WahooV2.Properties.Resources.wh_user_delete;
            this.linkDeleteClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteClient.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDeleteClient.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteClient.Location = new System.Drawing.Point(14, 85);
            this.linkDeleteClient.Name = "linkDeleteClient";
            this.linkDeleteClient.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkDeleteClient.Size = new System.Drawing.Size(115, 16);
            this.linkDeleteClient.TabIndex = 29;
            this.linkDeleteClient.TabStop = true;
            this.linkDeleteClient.Text = "Delete Client";
            this.linkDeleteClient.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteClient_LinkClicked);
            // 
            // linkEditClient
            // 
            this.linkEditClient.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditClient.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEditClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkEditClient.Image = global::WahooV2.Properties.Resources.wh_user_edit;
            this.linkEditClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkEditClient.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEditClient.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditClient.Location = new System.Drawing.Point(14, 65);
            this.linkEditClient.Name = "linkEditClient";
            this.linkEditClient.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkEditClient.Size = new System.Drawing.Size(115, 16);
            this.linkEditClient.TabIndex = 28;
            this.linkEditClient.TabStop = true;
            this.linkEditClient.Text = "Edit Client";
            this.linkEditClient.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditClient_LinkClicked);
            // 
            // linkNewClient
            // 
            this.linkNewClient.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewClient.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkNewClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkNewClient.Image = global::WahooV2.Properties.Resources.wh_user_add;
            this.linkNewClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkNewClient.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkNewClient.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewClient.Location = new System.Drawing.Point(14, 45);
            this.linkNewClient.Name = "linkNewClient";
            this.linkNewClient.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkNewClient.Size = new System.Drawing.Size(115, 16);
            this.linkNewClient.TabIndex = 27;
            this.linkNewClient.TabStop = true;
            this.linkNewClient.Text = "New Client";
            this.linkNewClient.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewClient_LinkClicked);
            // 
            // xpPanelUser
            // 
            this.xpPanelUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelUser.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelUser.Caption = "User Tasks";
            this.xpPanelUser.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanelUser.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanelUser.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanelUser.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelUser.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanelUser.Controls.Add(this.linkDeleteUser);
            this.xpPanelUser.Controls.Add(this.linkEditUser);
            this.xpPanelUser.Controls.Add(this.linkNewUser);
            this.xpPanelUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xpPanelUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanelUser.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanelUser.ImageItems.ImageSet = null;
            this.xpPanelUser.Location = new System.Drawing.Point(8, 575);
            this.xpPanelUser.Name = "xpPanelUser";
            this.xpPanelUser.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelUser.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelUser.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelUser.Size = new System.Drawing.Size(133, 115);
            this.xpPanelUser.TabIndex = 2;
            this.xpPanelUser.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanelUser.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanelUser.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanelUser.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // linkDeleteUser
            // 
            this.linkDeleteUser.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteUser.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDeleteUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteUser.Image = global::WahooV2.Properties.Resources.wh_user_delete;
            this.linkDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDeleteUser.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteUser.Location = new System.Drawing.Point(14, 85);
            this.linkDeleteUser.Name = "linkDeleteUser";
            this.linkDeleteUser.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkDeleteUser.Size = new System.Drawing.Size(115, 16);
            this.linkDeleteUser.TabIndex = 26;
            this.linkDeleteUser.TabStop = true;
            this.linkDeleteUser.Text = "Delete User";
            this.linkDeleteUser.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteUser_LinkClicked);
            // 
            // linkEditUser
            // 
            this.linkEditUser.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditUser.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEditUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkEditUser.Image = global::WahooV2.Properties.Resources.wh_user_edit;
            this.linkEditUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkEditUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEditUser.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditUser.Location = new System.Drawing.Point(14, 65);
            this.linkEditUser.Name = "linkEditUser";
            this.linkEditUser.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkEditUser.Size = new System.Drawing.Size(115, 16);
            this.linkEditUser.TabIndex = 25;
            this.linkEditUser.TabStop = true;
            this.linkEditUser.Text = "Edit User";
            this.linkEditUser.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditUser_LinkClicked);
            // 
            // linkNewUser
            // 
            this.linkNewUser.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewUser.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkNewUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkNewUser.Image = global::WahooV2.Properties.Resources.wh_user_add;
            this.linkNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkNewUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkNewUser.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewUser.Location = new System.Drawing.Point(14, 45);
            this.linkNewUser.Name = "linkNewUser";
            this.linkNewUser.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkNewUser.Size = new System.Drawing.Size(115, 16);
            this.linkNewUser.TabIndex = 24;
            this.linkNewUser.TabStop = true;
            this.linkNewUser.Text = "New User";
            this.linkNewUser.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewUser_LinkClicked);
            // 
            // xpPanelChannelTask
            // 
            this.xpPanelChannelTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelChannelTask.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelChannelTask.Caption = "Channel Tasks";
            this.xpPanelChannelTask.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanelChannelTask.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanelChannelTask.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanelChannelTask.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelChannelTask.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanelChannelTask.Controls.Add(this.linkUndeployAll);
            this.xpPanelChannelTask.Controls.Add(this.linkDeployAll);
            this.xpPanelChannelTask.Controls.Add(this.linkDeployChannel);
            this.xpPanelChannelTask.Controls.Add(this.linkDeleteChannel);
            this.xpPanelChannelTask.Controls.Add(this.linkEditChannel);
            this.xpPanelChannelTask.Controls.Add(this.linkEnableChannel);
            this.xpPanelChannelTask.Controls.Add(this.linkSaveChannel);
            this.xpPanelChannelTask.Controls.Add(this.linkNewChannel);
            this.xpPanelChannelTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpPanelChannelTask.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanelChannelTask.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanelChannelTask.ImageItems.ImageSet = null;
            this.xpPanelChannelTask.Location = new System.Drawing.Point(8, 351);
            this.xpPanelChannelTask.Name = "xpPanelChannelTask";
            this.xpPanelChannelTask.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelChannelTask.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelChannelTask.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelChannelTask.Size = new System.Drawing.Size(133, 216);
            this.xpPanelChannelTask.TabIndex = 2;
            this.xpPanelChannelTask.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanelChannelTask.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanelChannelTask.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanelChannelTask.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // linkUndeployAll
            // 
            this.linkUndeployAll.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUndeployAll.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUndeployAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUndeployAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkUndeployAll.Image = global::WahooV2.Properties.Resources.wh_stop_all;
            this.linkUndeployAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkUndeployAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUndeployAll.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUndeployAll.Location = new System.Drawing.Point(14, 185);
            this.linkUndeployAll.Name = "linkUndeployAll";
            this.linkUndeployAll.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkUndeployAll.Size = new System.Drawing.Size(115, 16);
            this.linkUndeployAll.TabIndex = 23;
            this.linkUndeployAll.TabStop = true;
            this.linkUndeployAll.Text = "Undeploy All";
            this.linkUndeployAll.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUndeployAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUndeployAll_LinkClicked);
            // 
            // linkDeployAll
            // 
            this.linkDeployAll.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployAll.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDeployAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployAll.Image = global::WahooV2.Properties.Resources.wh_start_all;
            this.linkDeployAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeployAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDeployAll.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployAll.Location = new System.Drawing.Point(14, 165);
            this.linkDeployAll.Name = "linkDeployAll";
            this.linkDeployAll.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkDeployAll.Size = new System.Drawing.Size(115, 16);
            this.linkDeployAll.TabIndex = 22;
            this.linkDeployAll.TabStop = true;
            this.linkDeployAll.Text = "Deploy All";
            this.linkDeployAll.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeployAll_LinkClicked);
            // 
            // linkDeployChannel
            // 
            this.linkDeployChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDeployChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployChannel.Image = global::WahooV2.Properties.Resources.wh_go;
            this.linkDeployChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeployChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDeployChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployChannel.Location = new System.Drawing.Point(14, 145);
            this.linkDeployChannel.Name = "linkDeployChannel";
            this.linkDeployChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkDeployChannel.Size = new System.Drawing.Size(115, 16);
            this.linkDeployChannel.TabIndex = 21;
            this.linkDeployChannel.TabStop = true;
            this.linkDeployChannel.Text = "Deploy Channel";
            this.linkDeployChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeployChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeployChannel_LinkClicked);
            // 
            // linkDeleteChannel
            // 
            this.linkDeleteChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDeleteChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteChannel.Image = global::WahooV2.Properties.Resources.wh_delete;
            this.linkDeleteChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDeleteChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteChannel.Location = new System.Drawing.Point(14, 85);
            this.linkDeleteChannel.Name = "linkDeleteChannel";
            this.linkDeleteChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkDeleteChannel.Size = new System.Drawing.Size(115, 16);
            this.linkDeleteChannel.TabIndex = 14;
            this.linkDeleteChannel.TabStop = true;
            this.linkDeleteChannel.Text = "Delete Channel";
            this.linkDeleteChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDeleteChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteChannel_LinkClicked);
            // 
            // linkEditChannel
            // 
            this.linkEditChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEditChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkEditChannel.Image = global::WahooV2.Properties.Resources.wh_channel_edit;
            this.linkEditChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkEditChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEditChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditChannel.Location = new System.Drawing.Point(14, 65);
            this.linkEditChannel.Name = "linkEditChannel";
            this.linkEditChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkEditChannel.Size = new System.Drawing.Size(115, 16);
            this.linkEditChannel.TabIndex = 13;
            this.linkEditChannel.TabStop = true;
            this.linkEditChannel.Text = "Edit Channel";
            this.linkEditChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEditChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditChannel_LinkClicked);
            // 
            // linkEnableChannel
            // 
            this.linkEnableChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEnableChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEnableChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEnableChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkEnableChannel.Image = global::WahooV2.Properties.Resources.wh_unlock;
            this.linkEnableChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkEnableChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEnableChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEnableChannel.Location = new System.Drawing.Point(14, 105);
            this.linkEnableChannel.Name = "linkEnableChannel";
            this.linkEnableChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkEnableChannel.Size = new System.Drawing.Size(115, 16);
            this.linkEnableChannel.TabIndex = 15;
            this.linkEnableChannel.TabStop = true;
            this.linkEnableChannel.Text = "Enabled";
            this.linkEnableChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkEnableChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEnableChannel_LinkClicked);
            // 
            // linkSaveChannel
            // 
            this.linkSaveChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSaveChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSaveChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSaveChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkSaveChannel.Image = global::WahooV2.Properties.Resources.wh_save;
            this.linkSaveChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkSaveChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSaveChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSaveChannel.Location = new System.Drawing.Point(14, 125);
            this.linkSaveChannel.Name = "linkSaveChannel";
            this.linkSaveChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkSaveChannel.Size = new System.Drawing.Size(115, 16);
            this.linkSaveChannel.TabIndex = 20;
            this.linkSaveChannel.TabStop = true;
            this.linkSaveChannel.Text = "Save Channel";
            this.linkSaveChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSaveChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSaveChannel_LinkClicked);
            // 
            // linkNewChannel
            // 
            this.linkNewChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkNewChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkNewChannel.Image = global::WahooV2.Properties.Resources.wh_channel_add;
            this.linkNewChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkNewChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkNewChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewChannel.Location = new System.Drawing.Point(14, 45);
            this.linkNewChannel.Name = "linkNewChannel";
            this.linkNewChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkNewChannel.Size = new System.Drawing.Size(115, 16);
            this.linkNewChannel.TabIndex = 12;
            this.linkNewChannel.TabStop = true;
            this.linkNewChannel.Text = "New Channel";
            this.linkNewChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkNewChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewChannel_LinkClicked);
            // 
            // xpPanelDashboardTask
            // 
            this.xpPanelDashboardTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelDashboardTask.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelDashboardTask.Caption = "Dashboard Tasks";
            this.xpPanelDashboardTask.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanelDashboardTask.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanelDashboardTask.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanelDashboardTask.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelDashboardTask.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanelDashboardTask.Controls.Add(this.linkStopChannel);
            this.xpPanelDashboardTask.Controls.Add(this.linkPauseChannel);
            this.xpPanelDashboardTask.Controls.Add(this.linkStopAllChannel);
            this.xpPanelDashboardTask.Controls.Add(this.linkResetAllChannel);
            this.xpPanelDashboardTask.Controls.Add(this.linkStartAllChannel);
            this.xpPanelDashboardTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpPanelDashboardTask.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanelDashboardTask.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanelDashboardTask.ImageItems.ImageSet = null;
            this.xpPanelDashboardTask.Location = new System.Drawing.Point(8, 188);
            this.xpPanelDashboardTask.Name = "xpPanelDashboardTask";
            this.xpPanelDashboardTask.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelDashboardTask.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelDashboardTask.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelDashboardTask.Size = new System.Drawing.Size(133, 155);
            this.xpPanelDashboardTask.TabIndex = 4;
            this.xpPanelDashboardTask.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanelDashboardTask.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanelDashboardTask.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanelDashboardTask.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // linkStopChannel
            // 
            this.linkStopChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkStopChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkStopChannel.Image = global::WahooV2.Properties.Resources.wh_stop;
            this.linkStopChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkStopChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkStopChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopChannel.Location = new System.Drawing.Point(14, 125);
            this.linkStopChannel.Name = "linkStopChannel";
            this.linkStopChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkStopChannel.Size = new System.Drawing.Size(115, 16);
            this.linkStopChannel.TabIndex = 11;
            this.linkStopChannel.TabStop = true;
            this.linkStopChannel.Text = "Stop Channel";
            this.linkStopChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkStopChannel_LinkClicked);
            // 
            // linkPauseChannel
            // 
            this.linkPauseChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkPauseChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkPauseChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPauseChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkPauseChannel.Image = global::WahooV2.Properties.Resources.wh_pause;
            this.linkPauseChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkPauseChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkPauseChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkPauseChannel.Location = new System.Drawing.Point(14, 105);
            this.linkPauseChannel.Name = "linkPauseChannel";
            this.linkPauseChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkPauseChannel.Size = new System.Drawing.Size(115, 16);
            this.linkPauseChannel.TabIndex = 10;
            this.linkPauseChannel.TabStop = true;
            this.linkPauseChannel.Text = "Pause Channel";
            this.linkPauseChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkPauseChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPauseChannel_LinkClicked);
            // 
            // linkStopAllChannel
            // 
            this.linkStopAllChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopAllChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopAllChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkStopAllChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkStopAllChannel.Image = global::WahooV2.Properties.Resources.wh_stop_all;
            this.linkStopAllChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkStopAllChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkStopAllChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopAllChannel.Location = new System.Drawing.Point(14, 65);
            this.linkStopAllChannel.Name = "linkStopAllChannel";
            this.linkStopAllChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkStopAllChannel.Size = new System.Drawing.Size(115, 16);
            this.linkStopAllChannel.TabIndex = 8;
            this.linkStopAllChannel.TabStop = true;
            this.linkStopAllChannel.Text = "Stop All Channels";
            this.linkStopAllChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStopAllChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkStopAllChannel_LinkClicked);
            // 
            // linkResetAllChannel
            // 
            this.linkResetAllChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkResetAllChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkResetAllChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkResetAllChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkResetAllChannel.Image = global::WahooV2.Properties.Resources.wh_refresh;
            this.linkResetAllChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkResetAllChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkResetAllChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkResetAllChannel.Location = new System.Drawing.Point(14, 85);
            this.linkResetAllChannel.Name = "linkResetAllChannel";
            this.linkResetAllChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkResetAllChannel.Size = new System.Drawing.Size(115, 16);
            this.linkResetAllChannel.TabIndex = 9;
            this.linkResetAllChannel.TabStop = true;
            this.linkResetAllChannel.Text = "Reset All Channels";
            this.linkResetAllChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // linkStartAllChannel
            // 
            this.linkStartAllChannel.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStartAllChannel.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStartAllChannel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkStartAllChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkStartAllChannel.Image = global::WahooV2.Properties.Resources.wh_start_all;
            this.linkStartAllChannel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkStartAllChannel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkStartAllChannel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStartAllChannel.Location = new System.Drawing.Point(14, 45);
            this.linkStartAllChannel.Name = "linkStartAllChannel";
            this.linkStartAllChannel.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkStartAllChannel.Size = new System.Drawing.Size(115, 16);
            this.linkStartAllChannel.TabIndex = 7;
            this.linkStartAllChannel.TabStop = true;
            this.linkStartAllChannel.Text = "Start All Channels";
            this.linkStartAllChannel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkStartAllChannel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkStartAllChannel_LinkClicked);
            // 
            // xpPanelNWG
            // 
            this.xpPanelNWG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelNWG.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelNWG.Caption = "NWCG";
            this.xpPanelNWG.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanelNWG.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanelNWG.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanelNWG.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelNWG.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanelNWG.Controls.Add(this.linkSetting);
            this.xpPanelNWG.Controls.Add(this.linkBridge);
            this.xpPanelNWG.Controls.Add(this.linkDashboard);
            this.xpPanelNWG.Controls.Add(this.linkReportAll);
            this.xpPanelNWG.Controls.Add(this.linkClient);
            this.xpPanelNWG.Controls.Add(this.linkUser);
            this.xpPanelNWG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanelNWG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanelNWG.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanelNWG.ImageItems.ImageSet = null;
            this.xpPanelNWG.Location = new System.Drawing.Point(8, 8);
            this.xpPanelNWG.Name = "xpPanelNWG";
            this.xpPanelNWG.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelNWG.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanelNWG.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanelNWG.Size = new System.Drawing.Size(133, 172);
            this.xpPanelNWG.TabIndex = 0;
            this.xpPanelNWG.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanelNWG.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanelNWG.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanelNWG.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // linkSetting
            // 
            this.linkSetting.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSetting.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSetting.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkSetting.Image = global::WahooV2.Properties.Resources.wh_setting;
            this.linkSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkSetting.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSetting.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSetting.Location = new System.Drawing.Point(14, 145);
            this.linkSetting.Name = "linkSetting";
            this.linkSetting.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkSetting.Size = new System.Drawing.Size(115, 16);
            this.linkSetting.TabIndex = 6;
            this.linkSetting.TabStop = true;
            this.linkSetting.Text = "Settings";
            this.linkSetting.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSetting_LinkClicked);
            // 
            // linkBridge
            // 
            this.linkBridge.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkBridge.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkBridge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkBridge.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkBridge.Image = global::WahooV2.Properties.Resources.wh_channels;
            this.linkBridge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkBridge.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkBridge.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkBridge.Location = new System.Drawing.Point(14, 65);
            this.linkBridge.Name = "linkBridge";
            this.linkBridge.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkBridge.Size = new System.Drawing.Size(115, 16);
            this.linkBridge.TabIndex = 3;
            this.linkBridge.TabStop = true;
            this.linkBridge.Text = "Channels";
            this.linkBridge.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkBridge.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBridge_LinkClicked);
            // 
            // linkDashboard
            // 
            this.linkDashboard.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDashboard.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDashboard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDashboard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkDashboard.Image = global::WahooV2.Properties.Resources.wh_dashboard;
            this.linkDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDashboard.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDashboard.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDashboard.Location = new System.Drawing.Point(14, 45);
            this.linkDashboard.Name = "linkDashboard";
            this.linkDashboard.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkDashboard.Size = new System.Drawing.Size(115, 16);
            this.linkDashboard.TabIndex = 2;
            this.linkDashboard.TabStop = true;
            this.linkDashboard.Text = "Dashboard";
            this.linkDashboard.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkDashboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDashboard_LinkClicked);
            // 
            // linkReportAll
            // 
            this.linkReportAll.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReportAll.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReportAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkReportAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkReportAll.Image = global::WahooV2.Properties.Resources.wh_report;
            this.linkReportAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkReportAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkReportAll.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReportAll.Location = new System.Drawing.Point(14, 105);
            this.linkReportAll.Name = "linkReportAll";
            this.linkReportAll.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkReportAll.Size = new System.Drawing.Size(115, 16);
            this.linkReportAll.TabIndex = 4;
            this.linkReportAll.TabStop = true;
            this.linkReportAll.Text = "Monitor";
            this.linkReportAll.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkReportAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReportAll_LinkClicked);
            // 
            // linkClient
            // 
            this.linkClient.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkClient.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkClient.Image = global::WahooV2.Properties.Resources.wh_client;
            this.linkClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkClient.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkClient.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkClient.Location = new System.Drawing.Point(14, 85);
            this.linkClient.Name = "linkClient";
            this.linkClient.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkClient.Size = new System.Drawing.Size(115, 16);
            this.linkClient.TabIndex = 4;
            this.linkClient.TabStop = true;
            this.linkClient.Text = "Clients";
            this.linkClient.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClient_LinkClicked);
            // 
            // linkUser
            // 
            this.linkUser.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUser.DisabledLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkUser.Image = global::WahooV2.Properties.Resources.wh_user;
            this.linkUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUser.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUser.Location = new System.Drawing.Point(14, 125);
            this.linkUser.Name = "linkUser";
            this.linkUser.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.linkUser.Size = new System.Drawing.Size(115, 16);
            this.linkUser.TabIndex = 5;
            this.linkUser.TabStop = true;
            this.linkUser.Text = "Users";
            this.linkUser.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUser_LinkClicked);
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.Location = new System.Drawing.Point(166, 44);
            this.pnMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1106, 668);
            this.pnMain.TabIndex = 0;
            // 
            // xpPanelGroupTop
            // 
            this.xpPanelGroupTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelGroupTop.AutoScroll = true;
            this.xpPanelGroupTop.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroupTop.Controls.Add(this.lblTop);
            this.xpPanelGroupTop.Location = new System.Drawing.Point(166, 0);
            this.xpPanelGroupTop.Margin = new System.Windows.Forms.Padding(0);
            this.xpPanelGroupTop.Name = "xpPanelGroupTop";
            this.xpPanelGroupTop.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroupTop.PanelGradient")));
            this.xpPanelGroupTop.Size = new System.Drawing.Size(1106, 44);
            this.xpPanelGroupTop.TabIndex = 0;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTop.Location = new System.Drawing.Point(3, 11);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(76, 25);
            this.lblTop.TabIndex = 0;
            this.lblTop.Text = "lblTop";
            // 
            // bgwMain
            // 
            this.bgwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMain_DoWork);
            // 
            // tmMain
            // 
            this.tmMain.Enabled = true;
            this.tmMain.Interval = 20000;
            this.tmMain.SynchronizingObject = this;
            this.tmMain.Elapsed += new System.Timers.ElapsedEventHandler(this.tmMain_Elapsed);
            // 
            // xpPanelBottom
            // 
            this.xpPanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanelBottom.AutoScroll = true;
            this.xpPanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelBottom.Controls.Add(this.statusStrip1);
            this.xpPanelBottom.Location = new System.Drawing.Point(0, 712);
            this.xpPanelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.xpPanelBottom.Name = "xpPanelBottom";
            this.xpPanelBottom.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelBottom.PanelGradient")));
            this.xpPanelBottom.Size = new System.Drawing.Size(1272, 22);
            this.xpPanelBottom.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelConWebService});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1272, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelConWebService
            // 
            this.statusLabelConWebService.AutoSize = false;
            this.statusLabelConWebService.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.statusLabelConWebService.Name = "statusLabelConWebService";
            this.statusLabelConWebService.Size = new System.Drawing.Size(300, 17);
            this.statusLabelConWebService.Text = "Connect to web servicer";
            this.statusLabelConWebService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmCheckConnect
            // 
            this.tmCheckConnect.Enabled = true;
            this.tmCheckConnect.Interval = 5000;
            this.tmCheckConnect.Tick += new System.EventHandler(this.tmCheckConnect_Tick);
            // 
            // bgwCheckConnect
            // 
            this.bgwCheckConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckConnect_DoWork);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 734);
            this.Controls.Add(this.xpPanelBottom);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.xpPanelGroupTop);
            this.Controls.Add(this.xpPanelLeft);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Wahoo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelLeft)).EndInit();
            this.xpPanelLeft.ResumeLayout(false);
            this.xpPanelOther.ResumeLayout(false);
            this.xpPanelClient.ResumeLayout(false);
            this.xpPanelUser.ResumeLayout(false);
            this.xpPanelChannelTask.ResumeLayout(false);
            this.xpPanelDashboardTask.ResumeLayout(false);
            this.xpPanelNWG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroupTop)).EndInit();
            this.xpPanelGroupTop.ResumeLayout(false);
            this.xpPanelGroupTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelBottom)).EndInit();
            this.xpPanelBottom.ResumeLayout(false);
            this.xpPanelBottom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList iconList;
        private UIComponents.XPPanelGroup xpPanelLeft;
        private UIComponents.XPPanel xpPanelOther;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHelp;
        private UIComponents.XPPanel xpPanelClient;
        private System.Windows.Forms.LinkLabel linkReport;
        private System.Windows.Forms.LinkLabel linkDeleteClient;
        private System.Windows.Forms.LinkLabel linkEditClient;
        private System.Windows.Forms.LinkLabel linkNewClient;
        private UIComponents.XPPanel xpPanelUser;
        private System.Windows.Forms.LinkLabel linkDeleteUser;
        private System.Windows.Forms.LinkLabel linkEditUser;
        private System.Windows.Forms.LinkLabel linkNewUser;
        private UIComponents.XPPanel xpPanelChannelTask;
        private System.Windows.Forms.LinkLabel linkUndeployAll;
        private System.Windows.Forms.LinkLabel linkDeployAll;
        private System.Windows.Forms.LinkLabel linkDeployChannel;
        private System.Windows.Forms.LinkLabel linkDeleteChannel;
        private System.Windows.Forms.LinkLabel linkEditChannel;
        private System.Windows.Forms.LinkLabel linkEnableChannel;
        private System.Windows.Forms.LinkLabel linkSaveChannel;
        private System.Windows.Forms.LinkLabel linkNewChannel;
        private UIComponents.XPPanel xpPanelDashboardTask;
        private System.Windows.Forms.LinkLabel linkStopChannel;
        private System.Windows.Forms.LinkLabel linkPauseChannel;
        private System.Windows.Forms.LinkLabel linkStopAllChannel;
        private System.Windows.Forms.LinkLabel linkResetAllChannel;
        private System.Windows.Forms.LinkLabel linkStartAllChannel;
        private UIComponents.XPPanel xpPanelNWG;
        private System.Windows.Forms.LinkLabel linkSetting;
        private System.Windows.Forms.LinkLabel linkBridge;
        private System.Windows.Forms.LinkLabel linkDashboard;
        private System.Windows.Forms.LinkLabel linkReportAll;
        private System.Windows.Forms.LinkLabel linkClient;
        private System.Windows.Forms.LinkLabel linkUser;
        private System.Windows.Forms.Panel pnMain;
        private UIComponents.XPPanelGroup xpPanelGroupTop;
        private System.Windows.Forms.Label lblTop;
        private System.ComponentModel.BackgroundWorker bgwMain;
        private System.Timers.Timer tmMain;
        private UIComponents.XPPanelGroup xpPanelBottom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelConWebService;
        private System.Windows.Forms.Timer tmCheckConnect;
        private System.ComponentModel.BackgroundWorker bgwCheckConnect;
    }
}