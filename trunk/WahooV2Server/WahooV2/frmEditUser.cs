using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WahooConfiguration;
using WahooData.DBO;
using WahooData.BusinessHandler;
using log4net;
namespace WahooV2
{
    public partial class frmEditUser : frmBase
    {
        #region variable
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Status( Create or update)
        private string _mStatus = "";

        public string Status
        {
            get { return _mStatus; }
            set { _mStatus = value; }
        }
        //User Id
        private int _mUserId = 0;
        public int UserId
        {
            get { return _mUserId; }
            set { _mUserId = value; }
        }        

        #endregion variable

        #region Constructor

        public frmEditUser()
        {
            InitializeComponent();
        }

        #endregion

        #region Event

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                //neu edit user ma ko thay doi
                if ((!HasChangeonControl(this)) && (this._mStatus == AliasMessage.UPDATE_STATUS))
                {
                    this.Close();                    
                }
                else if (CheckUser())
                {                    
                    //If update user
                    if (this._mStatus == AliasMessage.UPDATE_STATUS)
                    {
                        User objUserUpdate = new User();
                        objUserUpdate.Id = DataTypeProtect.ProtectInt32(this._mUserId, 0);
                        objUserUpdate = WahooBusinessHandler.Get_User(objUserUpdate);
                        objUserUpdate.Password = txtpassword.Text;
                        objUserUpdate.FirstName = txtFirstName.Text;
                        objUserUpdate.LastName = txtLastName.Text;
                        objUserUpdate.Organization = txtOrganization.Text;
                        objUserUpdate.Email = txtEmail.Text;
                        objUserUpdate.Phone = txtPhone.Text;
                        objUserUpdate.Description = txtDescription.Text;
                        objUserUpdate.Date_Updated = DateTime.Now;

                        if (objUserUpdate.Update())
                        {
                            this.ShowMessageBox("USER_CONF001", MessageType.INFORM);
                            this.Close();                            
                        }
                        else
                        {
                            this.ShowMessageBox("USER_ERR010", MessageType.ERROR);
                        }
                    }
                    //If create new user
                    else if (this._mStatus == AliasMessage.CREATE_STATUS)
                    {
                        //Kiem tra UserName da co chua
                        User objSearchUser = new User();
                        objSearchUser.Username = txtUsername.Text;
                        List<User> objListUser = WahooBusinessHandler.Get_ListUser(objSearchUser);
                        if (objListUser.Count > 0)
                        {
                            this.ShowMessageBox("USER_ERR012", MessageType.ERROR);
                            return;
                        }
                                                
                        User objUserCreate = new User();
                        objUserCreate.Username = txtUsername.Text;
                        objUserCreate.Password = txtpassword.Text;
                        objUserCreate.FirstName = txtFirstName.Text;
                        objUserCreate.LastName = txtLastName.Text;
                        objUserCreate.Organization = txtOrganization.Text;
                        objUserCreate.Email = txtEmail.Text;
                        objUserCreate.Phone = txtPhone.Text;
                        objUserCreate.Description = txtDescription.Text;
                        objUserCreate.Date_Created = DateTime.Now;
                        objUserCreate.Date_Updated = DateTime.Now;
                        
                        if (WahooBusinessHandler.Add_User(objUserCreate)>0)
                        {
                            this.ShowMessageBox("USER_CONF002", MessageType.INFORM);
                            this.Close();
                        }
                        else
                        {
                            this.ShowMessageBox("USER_ERR011", MessageType.ERROR);
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("USER_ERR009", MessageType.ERROR);
            }
        }

        private void frmEditUser_Load(object sender, EventArgs e)
        {
            LoadTextOfCotrolFromResource();
            //If update user
            if (this._mStatus == AliasMessage.UPDATE_STATUS)
            {                
                //gbUser.Text = AliasMessage.EDIT_USER_GROUP_CONTROL;
                User objUser = new User();
                objUser.Id = DataTypeProtect.ProtectInt32(this._mUserId, 0);
                objUser = WahooBusinessHandler.Get_User(objUser);

                txtUsername.Text = DataTypeProtect.ProtectString(objUser.Username);
                this.txtUsername.ReadOnly = true;
                txtFirstName.Text = DataTypeProtect.ProtectString(objUser.FirstName);
                txtLastName.Text = DataTypeProtect.ProtectString(objUser.LastName);
                txtOrganization.Text = DataTypeProtect.ProtectString(objUser.Organization);
                txtEmail.Text = DataTypeProtect.ProtectString(objUser.Email);
                txtPhone.Text = DataTypeProtect.ProtectString(objUser.Phone);
                txtDescription.Text = DataTypeProtect.ProtectString(objUser.Description);
                txtpassword.Text = DataTypeProtect.ProtectString(objUser.Password);
                txtConfirmPass.Text = DataTypeProtect.ProtectString(objUser.Password);
            }
            //If create new user
            else if (this._mStatus == AliasMessage.CREATE_STATUS)
            {
                this.txtUsername.ReadOnly = false;
                //gbUser.Text = AliasMessage.CREATE_USER_GROUP_CONTROL;
            }

            AssigeTag(this);
        }

        #endregion

        #region Function

        /// <summary>
        /// Bind text control from resource file.
        /// </summary>
        private void LoadTextOfCotrolFromResource()
        {
            Resource objResource = new Resource();
            if (this._mStatus == AliasMessage.CREATE_STATUS)
            {
                this.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "FORM_NAME_CREATE");
                gbUser.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "FORM_NAME_CREATE");
            }
            else if (this._mStatus == AliasMessage.UPDATE_STATUS)
            {
                this.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "FORM_NAME_UPDATE");
                gbUser.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "FORM_NAME_UPDATE");
            }
            lblConfPass.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_CONFIGPASSWORD");
            lblDesCription.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_DESCRIPTION");
            lblEmail.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_EMAIL");
            lblFName.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_FIRSTNAME");
            lblLName.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_LASTNAME");
            lblOrganization.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_ORGANIZATION");
            lblPass.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_PASSWORD");
            lblPhone.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_PHONE");
            lblUserName.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "LABEL_NAME_USERNAME");
            btnCancel.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "BUTTON_NAME_CANCEL");
            btnFinish.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "BUTTON_NAME_FINISH");
        }

        /// <summary>
        /// Check user info to save
        /// </summary>
        /// <returns></returns>
        private bool CheckUser()
        {            
            if (txtUsername.Text.Trim() == "")
            {
                this.ShowMessageBox("USER_ERR001", MessageType.ERROR);
                txtUsername.Focus();
                return false;
            }
            if (txtpassword.Text.Trim() == "")
            {
                this.ShowMessageBox("USER_ERR002", MessageType.ERROR);
                txtpassword.Focus();
                return false;
            }
            if (txtpassword.Text != txtConfirmPass.Text)
            {
                this.ShowMessageBox("USER_ERR003", MessageType.ERROR);
                txtConfirmPass.Focus();
                return false;
            }
            if (txtFirstName.Text.Trim() == "")
            {
                this.ShowMessageBox("USER_ERR004", MessageType.ERROR);
                txtFirstName.Focus();
                return false;
            }
            if (txtLastName.Text.Trim() == "")
            {
                this.ShowMessageBox("USER_ERR005", MessageType.ERROR);
                txtLastName.Focus();
                return false;
            }
            if (txtOrganization.Text.Trim() == "")
            {
                this.ShowMessageBox("USER_ERR006", MessageType.ERROR);
                txtOrganization.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                this.ShowMessageBox("USER_ERR007", MessageType.ERROR);
                txtEmail.Focus();
                return false;
            }
            Regex re = new Regex(@"^(^\w.*@\w.*$)?$");
            Match theMatch = re.Match(txtEmail.Text);
            if (!theMatch.Success)
            {
                this.ShowMessageBox("USER_ERR008", MessageType.ERROR);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        #endregion
    }
}
