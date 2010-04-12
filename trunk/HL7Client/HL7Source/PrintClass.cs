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
using PdfSharp.Pdf.Printing;

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
        public bool PrintPdfFile(string path, string printerPath,string acrobatExe)
        {
            PdfFilePrinter.AdobeReaderPath = acrobatExe;
            PdfFilePrinter pdoc = new PdfSharp.Pdf.Printing.PdfFilePrinter(path, printerPath);
            try
            {
                pdoc.Print();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
            return true;
        }
    }
}
