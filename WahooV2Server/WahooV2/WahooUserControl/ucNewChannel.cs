using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;
using WahooV2.WahooUserControl;
using WahooData.BusinessHandler;
using WahooData.DBO;
using WahooData.DBO.Base;
using log4net;

namespace WahooV2.WahooUserControl
{
    public partial class ucNewChannel : controlBase
    {        
        #region variable
        Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int loadControl = 0;

        /// <summary>
        /// IdChannel
        /// </summary>
        private int _mIdChannel = 0;

        public int IdChannel
        {
            get { return _mIdChannel; }
            set { _mIdChannel = value; }
        }
       
        /// <summary>
        /// IdClient
        /// </summary>
        public int IdClient
        {
            get { return DataTypeProtect.ProtectInt32(cbClientList.SelectedValue,0); }            
        }

        #endregion variable

        #region Contructor

        public ucNewChannel()
        {
            InitializeComponent();
        }

        #endregion

        #region function

        /// <summary>
        /// Show screen to edit channel
        /// </summary>
        /// <param name="idChannel"></param>
        public void ShowEditChannel(int idChannel)
        {
            try
            {
                Channel channelEdit = new Channel();
                channelEdit.Id = idChannel;
                channelEdit = WahooBusinessHandler.Get_Channel(channelEdit);
                //Fill in channel infomation

                txtChannelName.Text = DataTypeProtect.ProtectString(channelEdit.ChannelName);
                txtChannelName.Enabled = false;
                txtChannelName.BackColor = Color.White;
                if (channelEdit.Active.Value)
                {
                    chkEnable.Checked = true;
                }
                else
                {
                    chkEnable.Checked = false;
                }
                txtChannelDescription.Text = DataTypeProtect.ProtectString(channelEdit.Description);
                if (channelEdit.StoreFile.Value)
                {
                    chkStoreFile.Checked = true;
                }
                else
                {
                    chkStoreFile.Checked = false;
                }                
                txtFilePath.Text = DataTypeProtect.ProtectString(channelEdit.FilePath);

                Client clientEdit = channelEdit.Client;
                //Fill in client infomation
                cbClientList.SelectedValue = DataTypeProtect.ProtectInt32(clientEdit.Id,0);
                txtClientCode.Text = DataTypeProtect.ProtectString(clientEdit.ClientCode);
                txtClientName.Text = DataTypeProtect.ProtectString(clientEdit.Name);
                txtAddr1.Text = DataTypeProtect.ProtectString(clientEdit.Address1);
                txtAddr2.Text = DataTypeProtect.ProtectString(clientEdit.Address2);
                txtCity.Text = DataTypeProtect.ProtectString(clientEdit.City);
                txtState.Text = DataTypeProtect.ProtectString(clientEdit.State);
                txtZipcode.Text = DataTypeProtect.ProtectString(clientEdit.Zip);
                txtPhone.Text = DataTypeProtect.ProtectString(clientEdit.Phone);
                txtMail.Text = DataTypeProtect.ProtectString(clientEdit.Mail);                
                txtDescription.Text = DataTypeProtect.ProtectString(clientEdit.Description);
                                
                this._mIdChannel = idChannel;
                AssigeTag(this);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        /// <summary>
        /// Check info valid to save channel
        /// </summary>
        /// <returns></returns>
        public Boolean CheckValid()
        {            
                        
            //Channel name is empty
            if (txtChannelName.Text.Trim() == "")
            {
                this.ShowMessageBox("CHANNEL_ERR001", MessageType.ERROR);
                txtChannelName.Focus();
                return false;
            }
            
            //No choose client
            if (IdClient == 0)
            {
                this.ShowMessageBox("CHANNEL_ERR002", MessageType.ERROR);
                cbClientList.Focus();
                return false;
            }            

            if (txtFilePath.Text.Trim() == "")
            {
                this.ShowMessageBox("CHANNEL_ERR004", MessageType.ERROR);                
                return false;
            }
            if (!Directory.Exists(txtFilePath.Text))
            {
                this.ShowMessageBox("CHANNEL_ERR005", MessageType.ERROR);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Save channel
        /// </summary>
        /// <param name="newChannel"></param>
        /// <param name="status"></param>
        public bool SaveChannel(string status)
        {            
            try
            {
                if (CheckValid())
                {
                    if (status == AliasMessage.NEW_STATUS)
                    {
                        //Channel name is exists
                        Channel channelValid = new Channel();
                        channelValid.ChannelName = txtChannelName.Text;
                        List<Channel> listChannel = WahooBusinessHandler.Get_ListChannel(channelValid); ;
                        if (listChannel.Count > 0)
                        {
                            this.ShowMessageBox("CHANNEL_ERR006", MessageType.ERROR);
                            txtChannelName.Focus();
                            return false;
                        }

                        //Channel folder is exists
                        channelValid = new Channel();
                        channelValid.FilePath = txtFilePath.Text;
                        listChannel = WahooBusinessHandler.Get_ListChannel(channelValid); ;
                        if (listChannel.Count > 0)
                        {
                            this.ShowMessageBox("CHANNEL_ERR012", string.Format(WahooConfiguration.Message.GetMessageById("CHANNEL_ERR012"), listChannel[0].ChannelName), MessageType.ERROR);
                            return false;
                        }

                        Channel channelNew = new Channel();

                        channelNew.Active = chkEnable.Checked;
                        channelNew.ChannelName = txtChannelName.Text;
                        channelNew.DateCreated = DateTime.Now;
                        channelNew.DateUpdated = DateTime.Now;
                        channelNew.Description = txtChannelDescription.Text;
                        channelNew.Error = 0;
                        channelNew.FilePath = txtFilePath.Text;
                        channelNew.IdClient = IdClient;
                        channelNew.IsConnected = false;
                        channelNew.IsDeployed = false;
                        channelNew.Sent = 0;
                        channelNew.ServerFolder = @"\" + AliasMessage.OUTGOING_STATUS + @"\" + txtClientCode.Text;
                        channelNew.StatusExecute = AliasMessage.STOPPED_STATUS;
                        channelNew.StoreFile = chkStoreFile.Checked;
                        channelNew.WsdlUrl = DataTypeProtect.ProtectString(configObl.ReadSetting(AliasMessage.WSDL_URL_CONFIG));
                        AssigeTag(this);

                        if (WahooBusinessHandler.Add_Channel(channelNew) > 0)
                        {
                            this.ShowMessageBox("CHANNEL_CONF001", MessageType.INFORM);
                            return true;
                        }
                        else
                            this.ShowMessageBox("CHANNEL_ERR007", MessageType.ERROR);                        
                    }
                    else if (status == AliasMessage.UPDATE_STATUS)
                    {
                        //Channel folder is exists
                        Channel channelValid = new Channel();
                        channelValid.FilePath = txtFilePath.Text;
                        List<Channel> listChannel = WahooBusinessHandler.Get_ListChannel(channelValid);

                        if (listChannel.Count > 0 && listChannel[0].Id.Value != IdChannel)
                        {
                            this.ShowMessageBox("CHANNEL_ERR012", string.Format(WahooConfiguration.Message.GetMessageById("CHANNEL_ERR012"), listChannel[0].ChannelName), MessageType.ERROR);
                            return false;
                        }

                        Channel channelEdit = new Channel();
                        channelEdit.Id = IdChannel;
                        channelEdit = WahooBusinessHandler.Get_Channel(channelEdit);

                        channelEdit.Active = chkEnable.Checked;
                        channelEdit.ChannelName = txtChannelName.Text;                        
                        channelEdit.DateUpdated = DateTime.Now;
                        channelEdit.Description = txtChannelDescription.Text;
                        channelEdit.FilePath = txtFilePath.Text;
                        channelEdit.IdClient = IdClient;                        
                        channelEdit.ServerFolder = @"\" + AliasMessage.OUTGOING_STATUS + @"\" + txtClientCode.Text;
                        channelEdit.StoreFile = chkStoreFile.Checked;
                        channelEdit.WsdlUrl = DataTypeProtect.ProtectString(configObl.ReadSetting(AliasMessage.WSDL_URL_CONFIG));
                        AssigeTag(this);

                        if (channelEdit.Update())
                        {
                            this.ShowMessageBox("CHANNEL_CONF002", MessageType.INFORM);
                            return true;
                        }
                        else
                            this.ShowMessageBox("CHANNEL_ERR008", MessageType.ERROR);                        
                    }
                }
                return false;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        /// <summary>
        /// Bind text control from resource file.
        /// </summary>
        private void LoadTextOfCotrolFromResource()
        {
            Resource objResource = new Resource();            

            gbChannelInfomation.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "GROUPBOX_NAME_CHANNEL");
            gbClientInfomation.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "GROUPBOX_NAME_CLIENT");

            chkEnable.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "CHECKBOX_NAME_ENALBLE");
            chkStoreFile.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "CHECKBOX_NAME_STOREFILE");

            lblAddress1.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_ADDRESS1");
            lblAddress2.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_ADDRESS2");
            lblChannelDescription.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CHANNELDESCRIPTION");
            lblChannelName.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CHANNELNAME");
            lblChooseClient.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CHOOSECLIENT");
            lblCity.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CITY");
            lblClientCode.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CLIENTCODE");
            lblClientDescription.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CLIENTDESCRIPTION");
            lblClientName.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_CLIENTNAME");
            lblMail.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_MAIL");
            lblPath.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_PATH");
            lblPhone.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_PHONE");
            lblState.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_STATE");            
            lblZipCode.Text = objResource.GetResourceByKey("NEWCHANNEL_FORM_CONTROL", "LABLE_NAME_ZIPCODE");            
        }

        #endregion function        

        #region Event

        private void ucNewChannel_Load(object sender, EventArgs e)
        {
            LoadTextOfCotrolFromResource();
            try
            {                
                List<Client> objListClient = WahooBusinessHandler.Get_ListClient(new Client());
                Client objClient = new Client();
                objClient.Id = 0;
                objClient.Name = "--Please choose client--";
                objListClient.Insert(0, objClient);

                cbClientList.DataSource = objListClient;
                cbClientList.DisplayMember = "Name";
                cbClientList.ValueMember = "Id";
                loadControl = 1;
                AssigeTag(this);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void cbClientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadControl == 0)
            {
                return;
            }            
            if (IdClient == 0)
            {
                txtClientCode.Text = "";
                txtClientName.Text = "";
                txtAddr1.Text = "";
                txtAddr2.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtZipcode.Text = "";
                txtPhone.Text = "";
                txtMail.Text = "";                
                txtDescription.Text = "";
            }
            else
            {
                Client objClient = new Client();
                objClient.Id = IdClient;
                objClient = WahooBusinessHandler.Get_Client(objClient);

                txtClientCode.Text = DataTypeProtect.ProtectString(objClient.ClientCode);
                txtClientName.Text =DataTypeProtect.ProtectString(objClient.Name);
                txtAddr1.Text =DataTypeProtect.ProtectString(objClient.Address1);
                txtAddr2.Text =DataTypeProtect.ProtectString(objClient.Address2);
                txtCity.Text =DataTypeProtect.ProtectString(objClient.City);
                txtState.Text =DataTypeProtect.ProtectString(objClient.State);
                txtZipcode.Text =DataTypeProtect.ProtectString(objClient.Zip);
                txtPhone.Text =DataTypeProtect.ProtectString(objClient.Phone);
                txtMail.Text =DataTypeProtect.ProtectString(objClient.Mail);                
                txtDescription.Text = DataTypeProtect.ProtectString(objClient.Description);
            }            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderOpen = new FolderBrowserDialog();
            if (folderOpen.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = folderOpen.SelectedPath;
            }
        }

        #endregion        
    }
}
