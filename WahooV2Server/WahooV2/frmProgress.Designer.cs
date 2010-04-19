namespace WahooV2
{
    partial class frmProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgress));
            this.pbxProcessImg = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProcessImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxProcessImg
            // 
            this.pbxProcessImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pbxProcessImg.Image = ((System.Drawing.Image)(resources.GetObject("pbxProcessImg.Image")));
            this.pbxProcessImg.Location = new System.Drawing.Point(3, 3);
            this.pbxProcessImg.Name = "pbxProcessImg";
            this.pbxProcessImg.Size = new System.Drawing.Size(45, 25);
            this.pbxProcessImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxProcessImg.TabIndex = 12;
            this.pbxProcessImg.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(51, 3);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(340, 25);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmRefresh
            // 
            this.tmRefresh.Enabled = true;
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // frmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(398, 30);
            this.ControlBox = false;
            this.Controls.Add(this.pbxProcessImg);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgress";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pbxProcessImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbxProcessImg;
        internal System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer tmRefresh;
    }
}