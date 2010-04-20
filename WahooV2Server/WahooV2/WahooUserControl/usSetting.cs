using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;
using System.IO;
using System.Security.Cryptography;
using log4net;

namespace WahooV2.WahooUserControl
{
    public partial class usSetting : controlBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public usSetting()
        {
            InitializeComponent();
        }
        #region "Tab Info"
        #region "Event"
        /// <summary>
        /// Event form load, get information from config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usSetting_Load(object sender, EventArgs e)
        {
            setNumberictoTextbox(txtDashboardRefresh);
            setNumberictoTextbox(txtExecuteInterval);
            setNumberictoTextbox(txtTransferSpeed);
            txtDashboardRefresh.Focus();
            loadData();
            AssigeTag(this);
        }
        /// <summary>
        /// btn save data event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidate())
                {
                    if (saveData())
                    {
                        ShowMessageBox("CONF019", MessageType.INFORM);
                        AssigeTag(this);
                    }
                    else
                    {
                        ShowMessageBox("CONF020", MessageType.INFORM);
                    }
                }
            }
            catch(Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
            }
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// validate all cotrol on screen
        /// </summary>
        /// <returns></returns>
        private bool isValidate()
        {
            try
            {
                if (!hasChangeonControl(this))
                {
                    return false;
                }
                int.Parse(txtDashboardRefresh.Text);
                txtDashboardRefresh.Focus();
                int.Parse(txtExecuteInterval.Text);
                txtExecuteInterval.Focus();
                double.Parse(txtTransferSpeed.Text);
                txtTransferSpeed.Focus();
                if (txtBlowfishKey.Text.Trim().Equals(string.Empty))
                {
                    this.ShowMessageBox("ERR015", MessageType.ERROR);
                    return false;
                }
                //Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                //string originalKey = configObl.ReadSetting(AliasMessage.BLOWFISH_KEY_CONFIG);
                //if (txtBlowfishKey.Text != originalKey)
                //{
                //    configObl.WriteSetting(AliasMessage.BLOWFISH_KEY_CONFIG, txtBlowfishKey.Text);
                //    WahooServiceControl.WahooWebServiceControl hl7WebSer = new WahooServiceControl.WahooWebServiceControl(txtWsdlUrl.Text);
                //    if (!hl7WebSer.UploadBlowfishKey(txtBlowfishKey.Text))
                //    {
                //        this.ShowMessageBox("ERR015", MessageType.ERROR);
                //        return false;
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                this.ShowMessageBox("ERR035", string.Format(WahooConfiguration.Message.GetMessageById("ERR035")), MessageType.ERROR);
                return false;
            }
        }
        /// <summary>
        /// update data to app config file
        /// </summary>
        /// <returns ></returns>
        private bool saveData()
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                string originalKey = configObl.ReadSetting(AliasMessage.BLOWFISH_KEY_CONFIG);
                if (txtBlowfishKey.Text != originalKey)
                {
                    configObl.WriteSetting(AliasMessage.BLOWFISH_KEY_CONFIG, txtBlowfishKey.Text);
                   WahooServiceControl.WahooWebServiceControl hl7WebSer = new WahooServiceControl.WahooWebServiceControl(txtWsdlUrl.Text);
                    if (!hl7WebSer.UploadBlowfishKey(txtBlowfishKey.Text))
                    {
                        this.ShowMessageBox("ERR015", MessageType.ERROR);
                        return false;
                    }
                }
                configObl.WriteSetting(AliasMessage.DASHBOARD_INTERVAL_CONFIG, txtDashboardRefresh.Text);
                configObl.WriteSetting(AliasMessage.EXECUTE_INTERVAL_CONFIG, txtExecuteInterval.Text);
                configObl.WriteSetting(AliasMessage.TRANSFER_SPEED_CONFIG, txtTransferSpeed.Text);
                configObl.WriteSetting(AliasMessage.WSDL_URL_CONFIG, txtWsdlUrl.Text);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
                return false;
            }
        }
        /// <summary>
        /// Load datat form app config file
        /// </summary>
        private void loadData()
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string interval = configObl.ReadSetting(AliasMessage.DASHBOARD_INTERVAL_CONFIG);
            string executeInterval = configObl.ReadSetting(AliasMessage.EXECUTE_INTERVAL_CONFIG);
            string transferSpeed = configObl.ReadSetting(AliasMessage.TRANSFER_SPEED_CONFIG);
            try
            {
                int.Parse(interval);
                txtDashboardRefresh.Text = interval;
            }
            catch
            {
                txtDashboardRefresh.Text = "20";
            }
            try
            {
                int.Parse(executeInterval);
                txtExecuteInterval.Text = executeInterval;
            }
            catch
            {
                txtExecuteInterval.Text = "20";
            }
            try
            {
                double.Parse(transferSpeed);
                txtTransferSpeed.Text = transferSpeed;
            }
            catch
            {
                txtTransferSpeed.Text = "16";
            }
            txtWsdlUrl.Text = configObl.ReadSetting(AliasMessage.WSDL_URL_CONFIG);
            txtBlowfishKey.Text = configObl.ReadSetting(AliasMessage.BLOWFISH_KEY_CONFIG);
            LoadResouceInfo();
        }
        /// <summary>
        /// lay noi dung thong tin tu resource
        /// </summary>
        private void LoadResouceInfo()
        {
            resource = new Resource();
            label1.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_DASHBOARD");
            label2.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_EXECUTE");
            label3.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_TRANFER");
            label4.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_WSADDRESS");
            label7.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_Encryption");
            //tabInformation.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "TAB_NAME_INFO");
            //tbaRsa.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "TAB_NAME_RSA");
            btnSave.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "BUTTON_NAME_SAVE");
            btnReset.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "BUTTON_NAME_RESET");
            txtDashboardRefresh.MaxLength = WahooConfiguration.DataTypeProtect.ProtectInt32(resource.GetResourceByKey("SETTING_FORM_CONTROL", "TEXTBOX_DASHBOARD_LENGHT"), 5);
            txtExecuteInterval.MaxLength = WahooConfiguration.DataTypeProtect.ProtectInt32(resource.GetResourceByKey("SETTING_FORM_CONTROL", "TEXTBOX_EXECUTE_LENGHT"), 5);
            txtTransferSpeed.MaxLength = WahooConfiguration.DataTypeProtect.ProtectInt32(resource.GetResourceByKey("SETTING_FORM_CONTROL", "TEXTBOX_TRANSFER_LENGHT"), 5);
            //label6.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_PRIVATE");
            //label5.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_PUBLIC");
            //btnCreateNewFile.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_CREATE");
            //btnBrowse.Text = resource.GetResourceByKey("SETTING_FORM_CONTROL", "LABEL_NAME_BROWSE");
        }
        #endregion
        #endregion
        #region "Tab RSA"
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            resource = new Resource();
            dlgFolder.Description = resource.GetResourceByKey("SETTING_FORM_CONTROL", "TITLE_FOLDERBROWSER");
            dlgFolder.SelectedPath = Environment.SpecialFolder.MyDocuments.ToString();
            //if (dlgFolder.ShowDialog() == DialogResult.OK)
            //{
            //    txtPublicKeyFile.Text = dlgFolder.SelectedPath;
            //}
        }

        #endregion

        private void btnCreateNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtPublicKeyFile.Text.Trim().Equals(string.Empty))
                //{
                //    ShowMessageBox("ERR009", MessageType.ERROR);
                //    return;
                //}
                string privateKeyFile = Application.StartupPath + @"\Resource";
                if (!Directory.Exists(privateKeyFile))
                {
                    Directory.CreateDirectory(privateKeyFile);
                }
                privateKeyFile += @"\PrivateKeyFile";
                if (!Directory.Exists(privateKeyFile))
                {
                    Directory.CreateDirectory(privateKeyFile);
                }
                privateKeyFile += @"\privateKey.xml";
                if (File.Exists(privateKeyFile))
                {
                    File.Delete(privateKeyFile);
                }
                //AssignParameter();
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                //provide public and private RSA params
                StreamWriter writer = File.AppendText(privateKeyFile);
                string privateKeyXML = rsa.ToXmlString(true);
                writer.Write(privateKeyXML);
                writer.Close();
                //string publicKeyFile = txtPublicKeyFile.Text + @"\publicKey.xml";
                //if (File.Exists(publicKeyFile))
                //{
                //    File.Delete(publicKeyFile);
                //}
                //provide public only RSA params
                //writer = File.AppendText(publicKeyFile);
                string publicKeyXML = rsa.ToXmlString(false);
                writer.Write(publicKeyXML);
                writer.Close();
                ShowMessageBox("CONF006", MessageType.INFORM);
            }
            catch(Exception ex)
            {                
                ShowMessageBox("CONF007", MessageType.INFORM);
            }
        }

        private void tabSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tab = (TabControl)sender;
            if (tab.SelectedTab.Name.Equals("tbaRsa"))
            {
                string privateKeyFile = Application.StartupPath + @"\Resource\PrivateKeyFile\privateKey.xml";
                //txtPrivateKeyFile.Text = privateKeyFile;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBlowfishKey.Text = DataTypeProtect.ProtectString(txtBlowfishKey.Tag);
            txtDashboardRefresh.Text = DataTypeProtect.ProtectString(txtDashboardRefresh.Tag);
            txtExecuteInterval.Text = DataTypeProtect.ProtectString(txtExecuteInterval.Tag);
            txtTransferSpeed.Text = DataTypeProtect.ProtectString(txtTransferSpeed.Tag);
            txtWsdlUrl.Text = DataTypeProtect.ProtectString(txtWsdlUrl.Tag);
        }
    }
}
