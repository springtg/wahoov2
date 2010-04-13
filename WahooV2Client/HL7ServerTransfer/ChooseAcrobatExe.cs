using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HL7Source;
using System.IO;

namespace HL7ServerTransfer
{
    public partial class ChooseAcrobatExe : Form
    {
        public ChooseAcrobatExe()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(!File.Exists(txtAcrobatExeFile.Text))
            {
                MessageBox.Show("You must choose file AcroRd32.exe file");
                return;
            }
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            configObl.WriteSetting(Alias.ACROBAT_EXE_PATH, txtAcrobatExeFile.Text);
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgFile = new OpenFileDialog();
            if (dlgFile.ShowDialog() == DialogResult.OK)
            {
                txtAcrobatExeFile.Text = dlgFile.FileName;
            }
        }
    }
}