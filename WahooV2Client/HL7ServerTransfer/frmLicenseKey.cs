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
            string strEncode = clientCode + clientName + email;
            if (txtLicenseKey.Text == EncodeMd5.EncodeString(strEncode))
            {
                frmMain _frmMain = new frmMain();
                this.Hide();
                _frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                this.ShowMessageBox("ERR001", string.Format(HL7Source.Message.GetMessageById("ERR001")), MessageType.ERROR);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSettingInfo _mfrmSettingInfo = new frmSettingInfo();
            this.Hide();
            _mfrmSettingInfo.ShowDialog();
            this.Close();
        }
    }
}