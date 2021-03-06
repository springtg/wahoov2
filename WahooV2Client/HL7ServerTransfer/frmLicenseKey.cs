using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HL7Source;

namespace HL7ServerTransfer
{
    public partial class frmLicenseKey : frmBase
    {
        public frmLicenseKey()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            configObl.WriteSetting(Alias.LICENSE_KEY_CONFIG, txtLicenseKey.Text);
            string clientCode = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG);
            string clientName = configObl.ReadSetting(Alias.CLIENT_NAME_CONFIG);
            string email = configObl.ReadSetting(Alias.CLIENT_EMAIL_CONFIG);
            string strEncode = clientCode.Replace(" ", "").Trim() + clientName.Replace(" ", "").Trim() + email.Replace(" ", "").Trim();
            //TODO: su dung no clience
            if (!txtLicenseKey.Text.Trim().Equals(string.Empty))
              //if( txtLicenseKey.Text.Replace(" ", "").Trim().ToUpper() == EncodeMd5.EncodeString(strEncode.ToUpper()).Trim().ToUpper())
            {
                frmMain _frmMain = new frmMain();
                this.Hide();
                _frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                ShowMessageBox("MSG_TEXT_ERR001", MessageType.ERROR, getNameControl(label1));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSettingInfo _mfrmSettingInfo = new frmSettingInfo();
            this.Hide();
            _mfrmSettingInfo.ShowDialog();
            this.Close();
        }

        private void LoadResourceInfo()
        {
            _Resource = new HL7Source.Resource();
            this.Text = _Resource.GetResourceByKey("FORM_LICENSE_KEY", "FORM_TEXT_001");
            label1.Text = _Resource.GetResourceByKey("FORM_LICENSE_KEY", "LABEL_TEXT_0001");
            btnOk.Text = _Resource.GetResourceByKey("FORM_LICENSE_KEY", "BUTTON_TEXT_001");
            btnBack.Text = _Resource.GetResourceByKey("FORM_LICENSE_KEY", "BUTTON_TEXT_002");
        }

        private void frmLicenseKey_Load(object sender, EventArgs e)
        {
            LoadResourceInfo();
        }

    }
}