using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooData.DBO;
using WahooData.Controller;

namespace WahooV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserController objControl = new UserController();
            User objUser = new User();
            objUser.Id=2;
            objUser = objControl.GetItem(objUser);
            objUser.Date_Created = DateTime.Now;
            objUser.Date_Updated = DateTime.Now;
            objUser.Description = "Bạn là ai vay?";
            objUser.Email = "cuong@aps.com";
            objUser.FirstName = "cuong11";
            if (objUser.Update())
            {
                List<User> objList = objControl.GetItemsCollection(new User());
                int cout = objList.Count;
            }
        }
    }
}
