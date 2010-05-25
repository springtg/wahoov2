using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HL7Source;
using System.Diagnostics;

namespace HL7ServerTransfer
{
    static class Program
    {
        //public static HL7Source.Resource Resource;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Resource = new HL7Source.Resource();
            Process[] p = Process.GetProcessesByName("HL7ServerTranfer");
            if (p.Length > 1)
            {
                MessageBox.Show(HL7Source.Message.GetMessageById("HL7TRANFER_INFO_0001"));// "You can not run 2 program in a machine at the same time.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string clientCode = configObl.ReadSetting("ClientCode");
            string clientName = configObl.ReadSetting("ClientName");
            string email = configObl.ReadSetting("ClientEmail");
            string strEncode = clientCode.Replace(" ", "").Trim() + clientName.Replace(" ", "").Trim() + email.Replace(" ", "").Trim();
            string licenseKey = configObl.ReadSetting("LicenseKey").ToUpper();
            if (licenseKey.Equals(EncodeMd5.EncodeString(strEncode.ToUpper()).ToUpper()) && !licenseKey.Equals(string.Empty))
            {
                Application.Run(new frmMain());
            }
            else
            {
                Application.Run(new SettingInfo());
            }
            //Application.Run(new frmMain());
        }
    }
}