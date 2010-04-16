using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WahooV2
{
    public partial class frmProgress : Form
    {
        string message;
        public frmProgress(string msg)
        {
            message = msg;
            InitializeComponent();
            this.Shown += new EventHandler(frmProgress_Shown);
        }

        void frmProgress_Shown(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            lblProgress.Text = message;
            DateTime dt = DateTime.Now;
            Thread.Sleep(2000);
            this.DialogResult = DialogResult.OK;
            
            //this.Close();
        }        
    }
}
