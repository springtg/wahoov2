using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace HL7Source
{
    public class PrintClass
    {
        public PrintClass()
        {
        }

        public bool PrintDocFile(string path, string printerPath)
        {
            Boolean result = false;
            Microsoft.Office.Interop.Word.Document doc = null;
            object nullObject = Type.Missing;
            try
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                object fileName = path;

                object readOnly = true;
                wordApp.ActivePrinter = printerPath;
                doc = wordApp.Documents.Open(

                   ref fileName, ref nullObject, ref readOnly, ref nullObject,

                   ref nullObject, ref nullObject, ref nullObject, ref nullObject,

                   ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,

                   ref nullObject, ref nullObject, ref nullObject);

                wordApp.Visible = false;
                doc.PrintOut(ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                ref nullObject);
                if (doc != null)
                {
                    doc.Close(ref nullObject, ref nullObject, ref nullObject);
                }


                result = true;
            }
            catch (Exception ex)
            {
                if (doc != null)
                {
                    doc.Close(ref nullObject, ref nullObject, ref nullObject);
                }
                result = false;
            }

            return result;
        }
        /// <summary>
        /// Cho phep nguoi dung goi ham in file, de thuc hien viec in file pdf
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strPrinterName"></param>
        /// <returns></returns>
        public bool PrintPdfFile(string strFileName, string strPrinterName)
        {
            if (isValidateFile(strFileName))
            {
                RunInternalExe("FoxitReader.exe", strPrinterName, strFileName);
                return true;
            }
            return false;
        }
        /// <summary>
        /// kiem tra file chuyen den may in co hop le khong?
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        private bool isValidateFile(string strFileName)
        {
            //Neu file la empty
            if (strFileName.Equals(string.Empty))
            {
                return false;
            }
            //neu file khong ton tai
            if (!File.Exists(strFileName))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// thuc hien viec in file pdf, tu command line cho foxitReader
        /// </summary>
        /// <param name="exeName"></param>
        /// <param name="strPrinterName"></param>
        /// <param name="strFileName"></param>
        private void RunInternalExe(string exeName, string strPrinterName, string strFileName)
        {
            //Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Get the assembly's root name
            string rootName = assembly.GetName().Name;

            //Get the resource stream
            Stream resourceStream = assembly.GetManifestResourceStream(rootName + ".Resources." + exeName);

            //Verify the internal exe exists
            if (resourceStream == null)
                return;
            BinaryReader br = new BinaryReader(resourceStream);
            FileStream fs = new FileStream(exeName, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);
            byte[] ba = new byte[resourceStream.Length];
            resourceStream.Read(ba, 0, ba.Length);
            bw.Write(ba);
            br.Close();
            bw.Close();
            PrintDialog p = new PrintDialog();
            if (DialogResult.OK == p.ShowDialog())
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = exeName;
                string str2 = string.Format("/t \"{0}\" \"{1}\"", strFileName, strPrinterName);
                info.Arguments = str2;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.CreateNoWindow = true;
                info.ErrorDialog = false;
                info.UseShellExecute = false;
                Process.Start(info);// exeName, @"/p C:\1.pdf");
            }
        }
        /// <summary>
        /// Lay tat cac may in duoc install tren may, dua vao CBO
        /// </summary>
        /// <param name="cboPrinter"></param>
        /// <param name="cfg"></param>
        public void getAllPrinter(ref ComboBox cboPrinter, Config cfg)
        {
            try
            {
                foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cboPrinter.Items.Add(strPrinter);
                }
                string strPrinterDefault = cfg.ReadSetting(Alias.PRINTER_NAME_DEFAULT);
                if (!strPrinterDefault.Equals(string.Empty))
                {
                    cboPrinter.SelectedItem = strPrinterDefault;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// kiem tra 1 file co phai la file PDF khong?
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public bool isPDFFile(string strFileName)
        {
            if (Path.GetExtension(strFileName).ToUpper().Equals(".PDF"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// kiem tra file, xem file do co phai la file DOC khong?
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public bool isDOCFile(string strFileName)
        {
            if (Path.GetExtension(strFileName).ToUpper().Equals(".DOC"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///method to check if a printer is online or offline
        /// </summary>
        /// <param name="printerName">name of the Printer</param>
        /// <returns></returns>
        public bool IsPrinterOnline(string printerName)
        {
            string str = "";
            bool online = false;

            //set the scope of this search to the local machine
            ManagementScope scope = new ManagementScope(ManagementPath.DefaultPath);
            //connect to the machine
            scope.Connect();

            //query for the ManagementObjectSearcher
            SelectQuery query = new SelectQuery("select * from Win32_Printer");

            ManagementClass m = new ManagementClass("Win32_Printer");

            ManagementObjectSearcher obj = new ManagementObjectSearcher(scope, query);

            //get each instance from the ManagementObjectSearcher object
            using (ManagementObjectCollection printers = m.GetInstances())
                //now loop through each printer instance returned
                foreach (ManagementObject printer in printers)
                {
                    //first make sure we got something back
                    if (printer != null)
                    {
                        //get the current printer name in the loop
                        str = printer["Name"].ToString().ToLower();

                        //check if it matches the name provided
                        if (str.Equals(printerName.ToLower()))
                        {
                            //since we found a match check it's status
                            if (printer["WorkOffline"].ToString().ToLower().Equals("true") || printer["PrinterStatus"].Equals(7))
                                //it's offline
                                online = false;
                            else
                                //it's online
                                online = true;
                        }
                    }
                    else
                        throw new Exception("No printers were found");
                }
            return online;
        }

    }
}
