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
        #region "Method"
        public frmSettingInfo()
        {
            InitializeComponent();
        }        
        /// <summary>
        /// Check info valid
        /// </summary>
        /// <returns></returns>
        private bool CheckInfo()
        {
            if (txtClientCode.Text.Trim() == string.Empty)
            {
                //must fill client code
                ShowMessageBox("MSG_TEXT_ERROR_0000", MessageType.ERROR, getNameControl(label1));
                txtClientCode.Focus();
                return false;
            }
            if (txtClientName.Text.Trim() == string.Empty)
            {
                //must fill in client name
                ShowMessageBox("MSG_TEXT_ERROR_0000", MessageType.ERROR, getNameControl(label2));
                txtClientName.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == string.Empty)
            {
                //must fill in email.
                ShowMessageBox("MSG_TEXT_ERROR_0000", MessageType.ERROR, getNameControl(label3));
                txtEmail.Focus();
                return false;
            }
            else
            {
                if (!HL7Source.UtilityFunction.isMailValid(txtEmail.Text.Trim()))
                {
                    ShowMessageBox("MSG_TEXT_ERROR_0002", MessageType.ERROR);
                    txtEmail.Focus();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Load info from resource file
        /// </summary>
        private void LoadResourceInfo()
        {
            _Resource = new HL7Source.Resource();
            groupBox1.Text = _Resource.GetResourceByKey("FORM_SETTING_INFO", "GROUP_TEXT_001");
            label1.Text = _Resource.GetResourceByKey("FORM_SETTING_INFO", "LABEL_TEXT_0001");
            label2.Text = _Resource.GetResourceByKey("FORM_SETTING_INFO", "LABEL_TEXT_0002");
            label3.Text = _Resource.GetResourceByKey("FORM_SETTING_INFO", "LABEL_TEXT_0003");
            btnAccept.Text = _Resource.GetResourceByKey("FORM_SETTING_INFO", "BUTTON_TEXT_001");
            tbnClose.Text = _Resource.GetResourceByKey("FORM_SETTING_INFO", "BUTTON_TEXT_002");
        }
        #endregion
        #region "Event"
        /// <summary>
        /// event load form va init value for control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSettingInfo_Load(object sender, EventArgs e)
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                txtClientCode.Text = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG);
                txtClientName.Text = configObl.ReadSetting(Alias.CLIENT_NAME_CONFIG);
                txtEmail.Text = configObl.ReadSetting(Alias.CLIENT_EMAIL_CONFIG);
                LoadResourceInfo();
            }
            catch
            {
                ShowMessageBox("MSG_TEXT_ERROR_0001", MessageType.ERROR);
                this.Close();
            }
        }
        /// <summary>
        /// Event close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                configObl.WriteSetting(Alias.CLIENT_CODE_CONFIG, txtClientCode.Text.Trim().ToUpper());
                configObl.WriteSetting(Alias.CLIENT_NAME_CONFIG, txtClientName.Text.Trim());
                configObl.WriteSetting(Alias.CLIENT_EMAIL_CONFIG, txtEmail.Text.Trim().ToLower());
                string licenseKey = configObl.ReadSetting(Alias.LICENSE_KEY_CONFIG);
                string strEncode = txtClientCode.Text.Trim().ToUpper() + txtClientName.Text.Trim() + txtEmail.Text.Trim().ToLower();
                if (licenseKey.Trim().ToLower()== EncodeMd5.EncodeString(strEncode).Trim().ToLower())
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
        #endregion
    }
}