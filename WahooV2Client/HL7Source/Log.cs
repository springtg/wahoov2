using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HL7Source
{
    public class Log
    {
        //Write log with exception
        public static void Write(Exception ex,string pathLog)
        {
            if (!Directory.Exists(pathLog))
            {
                return;
            }
            string log_file = pathLog+"\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";            
            DateTime ctime = DateTime.Now;
            System.IO.StreamWriter sw = System.IO.File.AppendText(log_file);
            sw.WriteLine("|<<----------------Message:" + ctime.ToString("yyyy/MM/dd hh:mm:ss") + "----------------");
            sw.WriteLine("==>WKSNAME     : " + Environment.MachineName);
            sw.WriteLine("==>OS Version  : " + Environment.OSVersion);
            sw.WriteLine("==>DESCRIPTION : " + ex.Message);
            sw.WriteLine("==>DETAIL      : ");
            sw.WriteLine(ex.ToString());
            sw.WriteLine("-------------------Message:" + ctime.ToString("yyyy/MM/dd hh:mm:ss") + "---------------->>|");
            sw.Close();
        }
        //Write log with string message
        public static void Write(string message, string pathLog)
        {
            if (!Directory.Exists(pathLog))
            {
                return;
            }
            string log_file = pathLog + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";            
            DateTime ctime = DateTime.Now;
            System.IO.StreamWriter sw = System.IO.File.AppendText(log_file);
            sw.WriteLine("|<<----------------Message:" + ctime.ToString("yyyy/MM/dd hh:mm:ss") + "----------------");
            sw.WriteLine("==>WKSNAME     : " + Environment.MachineName);
            sw.WriteLine("==>OS Version  : " + Environment.OSVersion);
            sw.WriteLine("==>DESCRIPTION : " + message);
            sw.WriteLine("==>DETAIL      : ");
            sw.WriteLine("-------------------Message:" + ctime.ToString("yyyy/MM/dd hh:mm:ss") + "---------------->>|");
            sw.Close();
        }
    }
}

