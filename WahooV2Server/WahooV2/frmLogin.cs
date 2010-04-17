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

namespace WahooV2
{
    public partial class frmLogin : Form
    {
        private frmMain objMain;
        frmProgress msg;
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
            objUser.Username=txtUsername.Text;
            objUser.Password=txtPassword.Text;
            //Lay ra User
            List<User> objListUser=WahooBusinessHandler.Get_ListUser(objUser);
            if (objListUser.Count==0)
            {
                MessageBox.Show("Invalid usename, password", "Login fail!", MessageBoxButtons.OK);
                return;
            }
            this.Hide();
            objMain = new frmMain();
            //Thread th = new Thread(new ThreadStart(CheckConnecting));
            //th.Start();
            //msg = new frmProgress("Connecting to webservice ...");
            //msg.ShowDialog();
            //if (msg.DialogResult == DialogResult.OK)
            //{
            //    th.Abort();
            //}
            objMain.IdUser = objListUser[0].Id.Value;
            objMain.RoleUser = objListUser[0].Role.Value;
            objMain.WindowState = FormWindowState.Maximized;
            objMain.ShowDialog();
            this.Close();
            Cursor.Current = Cursors.Default;


            //this.Hide();
            //objMain = new frmMain();
            //Thread th = new Thread(new ThreadStart(CheckConnecting));
            //th.Start();
            //msg = new frmProgress("Loading data...");
            //msg.ShowDialog();
            //if (msg.DialogResult == DialogResult.OK)
            //    th.Abort();
            ////objMain.InitData();
            //objMain.ShowDialog();
            //this.Close();
            //Cursor.Current = Cursors.Default;

        }        

        private void CheckConnecting()
        {
            try
            {
                ////goi ham kien tra xem co ket noi toi webservice ko.
                //msg.Inform_msg = "Dang kiem tra ket noi den server";
                ////viet ham kiem tra ket noi
                //Thread.Sleep(5000);
                //msg.Inform_msg = "Dang kiem tra ket noi den database";
                //Thread.Sleep(5000);
                msg.DialogResult = DialogResult.OK;
                msg.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtUsername.Text = string.Empty;
        }
    }
}
