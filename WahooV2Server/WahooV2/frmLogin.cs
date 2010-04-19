using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooData.DBO;
using WahooData.BusinessHandler;
using System.Threading;
using WahooData.DBO.Base;
using WahooConfiguration;
using WahooServiceControl;
using log4net;

namespace WahooV2
{
    public partial class frmLogin : frmBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmMain objMain;
        frmProgress msg;
        Boolean error = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Username is empty.", "Login fail!", MessageBoxButtons.OK);
                return;
            }
            User objUser = new User();
            objUser.Username = txtUsername.Text;
            objUser.Password = txtPassword.Text;
            //Lay ra User
            List<User> objListUser = null;
            try
            {
                objListUser = WahooBusinessHandler.Get_ListUser(objUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connect to database.", "Login fail!", MessageBoxButtons.OK);
                return;
            }

            if (objListUser.Count == 0)
            {
                MessageBox.Show("Invalid usename, password", "Login fail!", MessageBoxButtons.OK);
                return;
            }
            this.Hide();
            objMain = new frmMain();
            objMain.IdUser = objListUser[0].Id.Value;
            objMain.RoleUser = objListUser[0].Role.Value;
            objMain.WindowState = FormWindowState.Maximized;
            Thread th = new Thread(new ThreadStart(InitData));
            th.Start();
            msg = new frmProgress("");
            msg.ShowDialog();
            if (msg.DialogResult == DialogResult.OK)
            {
                th.Abort();
            }
            if (error)
            {
                //Show message have error
                MessageBox.Show("Can not connect to web service.", "Login fail!", MessageBoxButtons.OK);
            }
            else
            {
                objMain.ShowDialog();
            }
            //objMain.ShowDialog();
            this.Close();            
            Cursor.Current = Cursors.Default;
        }

        private void InitData()
        {
            try
            {
                //Check connect
                //msg.Inform_msg = "Check connect to web service.....";
                DateTime dt = DateTime.Now;
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                string strWSDL = configObl.ReadSetting(AliasMessage.WSDL_URL_CONFIG);
                WahooWebServiceControl _WahooWebServiceControl = new WahooWebServiceControl(strWSDL);
                if (_WahooWebServiceControl.CheckConnect())
                {
                    msg.Inform_msg = "Check connect to web service.....";
                    while (dt.AddSeconds(2) > DateTime.Now)
                    {
                    }
                    msg.Inform_msg = "Loading data ...";
                    objMain.InitData();
                    while (dt.AddSeconds(3) > DateTime.Now)
                    {
                    }
                }
                else
                {
                    error = true;
                }
                //objMain.InitData();
                msg.DialogResult = DialogResult.OK;
                
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                error = true;
                msg.DialogResult = DialogResult.OK;                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtUsername.Text = string.Empty;
        }
    }
}
