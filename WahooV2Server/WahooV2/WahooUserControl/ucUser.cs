using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;
using WahooV2.WahooUserControl;
using WahooData.BusinessHandler;
using WahooData.DBO;
using log4net;

namespace WahooV2.WahooUserControl
{
    public partial class ucUser : controlBase
    {
        #region variable
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Check client is loaded
        private int _mCheckLoad = 0;

        private int _mIdUser = 0;

        public int IdUser
        {
            get { return _mIdUser; }
            set { _mIdUser = value; }
        }

        //Declare delegate for click out of gird
        public delegate void GridUser_MouseDown(object sender, MouseEventArgs e);
        public event GridUser_MouseDown GridMouseDown;

        //Declare delegate for gird selected index changed
        public delegate void GridUser_SelectIndexChanged(object sender, EventArgs e);
        public event GridUser_SelectIndexChanged GridSelectChanged;

        #endregion variable

        #region Constructor

        public ucUser()
        {
            InitializeComponent();
        }

        #endregion 

        #region Event

        private void ucUser_Load(object sender, EventArgs e)
        {
            LoadTextOfCotrolFromResource();
            BindGrid();
            this._mCheckLoad = 1;
        }

        private void BindGrid()
        {
            try
            {
                //Lay danh sach cac User
                List<User> objListUser= WahooBusinessHandler.Get_ListUser(new User());                
                gridUser.DataSource = objListUser;
                if (gridUser.SelectedRows.Count > 0)
                {
                    this._mIdUser = DataTypeProtect.ProtectInt32(gridUser.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);                    
                }                
            }
            catch (Exception ex)
            {
                //Write log                
                throw ex;
            }
        }

        private void gridUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditUser();
        }

        private void gridUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (GridMouseDown != null)
            {
                DataGridView.HitTestInfo hti = gridUser.HitTest(e.X, e.Y);
                //Click left mouse
                if (e.Button == MouseButtons.Left)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //Click out of grid
                        if (hti.RowIndex == -1)
                        {
                            this._mIdUser = 0;
                            //this._mClientCode = "";
                            gridUser.ClearSelection();
                        }
                        //Click in grid
                        else
                        {
                            this._mIdUser = DataTypeProtect.ProtectInt32(gridUser.Rows[hti.RowIndex].Cells[this.clId.Name].Value.ToString(), 0);
                            //this._mClientCode = gridClient.Rows[hti.RowIndex].Cells[this.clClientCode.Name].Value.ToString();
                        }
                    }
                }
                //Click right mouse
                if (e.Button == MouseButtons.Right)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //Click out of grid
                        if (hti.RowIndex == -1)
                        {
                            editUserItem.Visible = false;
                            deleteUserItem.Visible = false;
                            this._mIdUser = 0;
                            gridUser.ClearSelection();
                        }
                        //Click in grid
                        else
                        {
                            gridUser.Rows[hti.RowIndex].Selected = true;
                            this._mIdUser = DataTypeProtect.ProtectInt32(gridUser.Rows[hti.RowIndex].Cells[this.clId.Name].Value.ToString(), 0);
                            //this._mClientCode = gridClient.Rows[hti.RowIndex].Cells[this.clClientCode.Name].Value.ToString();
                            editUserItem.Visible = true;
                            deleteUserItem.Visible = true;
                        }
                    }
                    else
                    {
                        if (hti.RowIndex == -1)
                        {
                            editUserItem.Visible = false;
                            deleteUserItem.Visible = false;
                            this._mIdUser = 0;
                            gridUser.ClearSelection();
                        }
                    }
                }
                GridMouseDown(sender, e);
            }            
        }

        private void gridUser_SelectionChanged(object sender, EventArgs e)
        {
            if (GridSelectChanged != null)
            {
                if (this._mCheckLoad == 0)
                {
                    return;
                }
                if (gridUser.SelectedRows.Count > 0)
                {
                    this._mIdUser = DataTypeProtect.ProtectInt32(gridUser.SelectedRows[0].Cells[this.clId.Name].Value.ToString());                    
                }
                GridSelectChanged(sender, e);
            }
        }

        private void NewUserItem_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private void EditUserItem_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void DeleteUserItem_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        #endregion

        #region Function

        /// <summary>
        /// Edit user
        /// </summary>
        public void EditUser()
        {
            if (gridUser.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                //Show form edit client
                frmEditUser _frmEditUser = new frmEditUser();
                _frmEditUser.UserId = DataTypeProtect.ProtectInt32(gridUser.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                _frmEditUser.Status = AliasMessage.UPDATE_STATUS;
                _frmEditUser.ShowDialog();
                //Update infomation which is edited to grid
                BindGrid();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        /// <summary>
        /// Create user
        /// </summary>
        public void CreateUser()
        {
            try
            {
                //Show form create client
                frmEditUser _frmEditUser = new frmEditUser();
                _frmEditUser.Status = AliasMessage.CREATE_STATUS;
                _frmEditUser.ShowDialog();
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete client
        /// </summary>
        public void DeleteUser()
        {
            if (gridUser.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show(string.Format(WahooConfiguration.Message.GetMessageById("USER_QUEST001"), gridUser.SelectedRows[0].Cells[this.clUsername.Name].Value.ToString()), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = DataTypeProtect.ProtectInt32(gridUser.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                    //Delete Client
                    User objDelete = new User();
                    objDelete.Id = id;
                    if (objDelete.Delete())
                    {
                        BindGrid();
                    }
                    else
                    {
                        this.ShowMessageBox("USER_ERR013", string.Format(WahooConfiguration.Message.GetMessageById("USER_ERR013")), MessageType.ERROR);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Bind text control from resource file.
        /// </summary>
        private void LoadTextOfCotrolFromResource()
        {
            Resource objResource = new Resource();
            clUsername.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_USERNAME");
            clFirstname.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_FIRSTNAME");
            clLastName.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_LASTNAME");
            clOrganization.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_ORGANIZATION");
            clEmail.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_EMAIL");
            clPhone.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_PHONE");
            clDescription.HeaderText = objResource.GetResourceByKey("USER_FORM_CONTROL", "HEADER_NAME_DESCRIPTION");
            newUserItem.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "MENUITEM_NAME_NEWUSER");
            editUserItem.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "MENUITEM_NAME_EDITUSER");
            deleteUserItem.Text = objResource.GetResourceByKey("USER_FORM_CONTROL", "MENUITEM_NAME_DELETEUSER");
        }

        #endregion
    }
}
