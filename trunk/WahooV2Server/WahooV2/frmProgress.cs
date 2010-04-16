using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WahooV2
{
    public partial class frmProgress : Form
    {
        string message;
        public frmProgress(string msg)
        {
            message = msg;
            InitializeComponent();            
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            lblProgress.Text = message;
        }        
    }
}
