using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;
using WahooData.DBO;
using WahooData.BusinessHandler;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using log4net;

namespace WahooV2
{
    public partial class frmEditClient : frmBase
    {
        #region variable
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Staus to Create or Update
        private string _mStatus = "";

        public string Status
        {
            get { return _mStatus; }
            set { _mStatus = value; }
        }
        //Client Id
        private int _mClientId = 0;
        public int ClientId
        {
            get { return _mClientId; }
            set { _mClientId = value; }
        }

        #endregion variable

        public frmEditClient()
        {
            InitializeComponent();
        }

        private void frmEditClient_Load(object sender, EventArgs e)
        {            
            Resource objResource = new Resource();            
            //If update client
            if (this._mStatus == AliasMessage.UPDATE_STATUS)
            {
                this.txtClientCode.ReadOnly = true;
                this.Text = objResource.GetResourceByKey("CLIENT_FORM_CONTROL", "UPDATE_NAME_COLUMN");
                lblTop.Text = objResource.GetResourceByKey("CLIENT_FORM_CONTROL", "UPDATE_NAME_COLUMN");
                Client objClient = new Client();
                objClient.Id=DataTypeProtect.ProtectInt32(this._mClientId,0);
                //Lay ra Client
                objClient = WahooBusinessHandler.Get_Client(objClient);
                txtClientCode.Text = DataTypeProtect.ProtectString(objClient.ClientCode);
                txtClientName.Text = DataTypeProtect.ProtectString(objClient.Name);
                txtAddr1.Text = DataTypeProtect.ProtectString(objClient.Address1);
                txtAddr2.Text = DataTypeProtect.ProtectString(objClient.Address2);
                txtCity.Text = DataTypeProtect.ProtectString(objClient.City);
                txtState.Text = DataTypeProtect.ProtectString(objClient.State);
                txtZipcode.Text = DataTypeProtect.ProtectString(objClient.Zip);
                txtPhone.Text = DataTypeProtect.ProtectString(objClient.Phone);
                txtMail.Text = DataTypeProtect.ProtectString(objClient.Mail);
                txtDescription.Text = DataTypeProtect.ProtectString(objClient.Description);
                txtContactName.Text = DataTypeProtect.ProtectString(objClient.ContactName);
                txtLicenseKey.Text = DataTypeProtect.ProtectString(objClient.LicenseKey);
            }
            //If create new client
            else if (this._mStatus == AliasMessage.CREATE_STATUS)
            {
                this.txtClientCode.ReadOnly = false;
                lblTop.Text = objResource.GetResourceByKey("CLIENT_FORM_CONTROL", "CREATE_NAME_COLUMN");
                this.Text = objResource.GetResourceByKey("CLIENT_FORM_CONTROL", "CREATE_NAME_COLUMN");
            }
            else
            {
            }            
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckClient())
                {
                    txtLicenseKey.Text = CreateLicenseKey();                    
                    //If update info
                    if (this._mStatus == AliasMessage.UPDATE_STATUS)
                    {
                        Client objUpdate = new Client();
                        objUpdate.Id = DataTypeProtect.ProtectInt32(this._mClientId, 0);
                        //Lay thong tin cua Client can update
                        objUpdate = WahooBusinessHandler.Get_Client(objUpdate);
                        //Truyen thong tin de update
                        objUpdate.Name = txtClientName.Text;
                        objUpdate.Address1 = txtAddr1.Text;
                        objUpdate.Address2 = txtAddr2.Text;
                        objUpdate.City = txtCity.Text;
                        objUpdate.State = txtState.Text;
                        objUpdate.Zip = txtZipcode.Text;
                        objUpdate.Phone = txtPhone.Text;
                        objUpdate.Mail = txtMail.Text.Trim();
                        objUpdate.Description = txtDescription.Text;
                        objUpdate.ClientCode = txtClientCode.Text;
                        objUpdate.ContactName = txtContactName.Text;
                        objUpdate.LicenseKey = txtLicenseKey.Text;
                        objUpdate.DateUpdated = DateTime.Now;
                        if (objUpdate.Update())
                        {
                            //MessageBox.Show("License key: " + txtLicenseKey.Text);
                            this.ShowMessageBox("CLIENT_CONF001", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_CONF001")), MessageType.INFORM);
                            this.Close();
                        }
                        else
                        {
                            this.ShowMessageBox("CLIENT_ERR005", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR005")), MessageType.ERROR);
                        }
                    }
                    //If create new client
                    else if (this._mStatus == AliasMessage.CREATE_STATUS)
                    {
                        //Kiem tra xem thu ClientCode da ton tai hay chua
                        Client objClientSearch = new Client();
                        objClientSearch.ClientCode = txtClientCode.Text;
                        List<Client> objListClient = WahooBusinessHandler.Get_ListClient(objClientSearch);
                        if (objListClient.Count > 0)
                        {
                            this.ShowMessageBox("CLIENT_ERR006", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR006")), MessageType.ERROR);
                            return;
                        }
                        //Tao moi Client
                        Client objCreate = new Client();
                        objCreate.Name = txtClientName.Text;
                        objCreate.Address1 = txtAddr1.Text;
                        objCreate.Address2 = txtAddr2.Text;
                        objCreate.City = txtCity.Text;
                        objCreate.State = txtState.Text;
                        objCreate.Zip = txtZipcode.Text;
                        objCreate.Phone = txtPhone.Text;
                        objCreate.Mail = txtMail.Text.Trim();
                        objCreate.Description = txtDescription.Text;
                        objCreate.ClientCode = txtClientCode.Text;
                        objCreate.ContactName = txtContactName.Text;
                        objCreate.LicenseKey = txtLicenseKey.Text;
                        objCreate.DateCreated=objCreate.DateUpdated = DateTime.Now;
                        int result = WahooBusinessHandler.Add_Client(objCreate);
                        if (result>0)
                        {
                            MessageBox.Show("License key: " + txtLicenseKey.Text);
                            this.ShowMessageBox("CLIENT_CONF002", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_CONF002")), MessageType.INFORM);
                            this.Close();
                        }
                        else
                        {
                            this.ShowMessageBox("CLIENT_ERR007", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR007")), MessageType.INFORM);
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("CLIENT_ERR008", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR008")), MessageType.ERROR);
            }
        }
        #region function

        /// <summary>
        /// Check client info to save to database
        /// </summary>
        /// <returns></returns>
        private bool CheckClient()
        {
            bool result = true;
            if (txtClientName.Text.Trim() == "")
            {
                this.ShowMessageBox("CLIENT_ERR001", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR001")), MessageType.ERROR);
                txtClientName.Focus();
                return false;
            }
            else if (txtClientCode.Text.Trim() == "")
            {
                this.ShowMessageBox("CLIENT_ERR002", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR002")), MessageType.ERROR);
                txtClientCode.Focus();
                return false;
            }
            else if (txtMail.Text.Trim() == "")
            {
                this.ShowMessageBox("CLIENT_ERR003", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR003")), MessageType.ERROR);
                txtMail.Focus();
                return false;
            }
            Regex re = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            //Regex re = new Regex(@"^(^\w.*@\w.*$)?$");
            Match theMatch = re.Match(txtMail.Text.Trim());
            if (!theMatch.Success || txtMail.Text.Contains(" "))
            {
                this.ShowMessageBox("CLIENT_ERR004", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR004")), MessageType.ERROR);
                txtMail.Focus();
                return false;
            }            
            return result;
        }
        /// <summary>
        /// Create License key
        /// </summary>
        /// <returns></returns>
        private string CreateLicenseKey()
        {
            //Declarations
            //Byte[] originalBytes;
            //Byte[] encodedBytes;
            //MD5 md5;
            string clientCode = txtClientCode.Text.Trim();
            string clientName = txtClientName.Text.Replace(" ", "").Trim();
            string email = txtMail.Text.Replace(" ", "").Trim();
            string strEncode = clientCode + clientName + email;
            strEncode = strEncode.ToUpper();
            ////Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            //md5 = new MD5CryptoServiceProvider();
            //originalBytes = ASCIIEncoding.Default.GetBytes(strEncode);
            //encodedBytes = md5.ComputeHash(originalBytes);
            ////Convert encoded bytes back to a 'readable' string
            string licenseKey = WahooCommon.EncodeMd5.EncodeString(strEncode);// BitConverter.ToString(encodedBytes);
            return licenseKey;
        }
        #endregion function          

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
