using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HL7Source;
using System.IO;

namespace HL7ServerTransfer
{
    public partial class frmSettingInfo : frmBase
    {
        public frmSettingInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Accept infomation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (CheckInfo())
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                configObl.WriteSetting(Alias.CLIENT_CODE_CONFIG, txtClientCode.Text);
                configObl.WriteSetting(Alias.CLIENT_NAME_CONFIG, txtClientName.Text);
                configObl.WriteSetting(Alias.CLIENT_EMAIL_CONFIG, txtEmail.Text);
                string licenseKey = configObl.ReadSetting(Alias.LICENSE_KEY_CONFIG);
                string strEncode = txtClientCode.Text + txtClientName.Text + txtEmail.Text;
                if (licenseKey == EncodeMd5.EncodeString(strEncode))
                {
                    frmMain _frmMain = new frmMain();
                    this.Hide();
                    _frmMain.ShowDialog();
                }
                else
                {
                    frmLicenseKey _frmLicenseKey = new frmLicenseKey();
                    this.Hide();
                    _frmLicenseKey.ShowDialog();
                }
                this.Close();
            }
        }
        /// <summary>
        /// Check info valid
        /// </summary>
        /// <returns></returns>
        private Boolean CheckInfo()
        {
            if (txtClientCode.Text.Trim() == "")
            {
                ShowMessageBox("MSG_TEXT_ERROR_0000", MessageType.ERROR, getNameControl(label1));
                //MessageBox.Show("You must fill in client code.");
                txtClientCode.Focus();
                return false;
            }
            if (txtClientName.Text.Trim() == "")
            {
                MessageBox.Show("You must fill in client name.");
                txtClientName.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("You must fill in email.");
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void frmSettingInfo_Load(object sender, EventArgs e)
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                txtClientCode.Text = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG);
                txtClientName.Text = configObl.ReadSetting(Alias.CLIENT_NAME_CONFIG);
                txtEmail.Text = configObl.ReadSetting(Alias.CLIENT_EMAIL_CONFIG);
            }
            catch
            {
                MessageBox.Show("Have error. Please try again");
                this.Close();
            }
        }

        private void tbnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}