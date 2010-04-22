using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooCommon;

namespace EncryptFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _pass = "!@#vtc123work";
            string _init = "@1B2c3D4e5F6g7H8";
            RijndaelEnhanced rH = new RijndaelEnhanced(_pass, _init);
            txtDecrypt.Text = rH.Encrypt(txtEncrypt.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _pass = "!@#vtc123work";
            string _init = "@1B2c3D4e5F6g7H8";
            RijndaelEnhanced rH = new RijndaelEnhanced(_pass, _init);
            txtEncryptDec.Text = rH.Decrypt(txtDecryptDec.Text);
        }
    }
}
