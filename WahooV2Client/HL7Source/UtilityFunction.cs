using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HL7Source
{
    public class UtilityFunction
    {
        //Check drive available 
        public static bool isDriveExist(string driverName)
        {
            driverName = driverName.Substring(0, 1) + @":\";

            bool bolValue = false;

            System.Collections.ArrayList usedDrive = new System.Collections.ArrayList();

            //get all current drives                        
            foreach (string driveLetter in System.IO.Directory.GetLogicalDrives())
            {
                usedDrive.Add(driveLetter);
            }
            //Check drive name exists
            foreach (string s in usedDrive)
            {
                if (usedDrive.Contains(driverName))
                {
                    return true;
                }
            }
            return bolValue;
        }

        /// <summary>
        /// kiem tra 1 email co dung format khong?
        /// </summary>
        /// <param name="strMail"></param>
        /// <returns></returns>
        public static bool isMailValid(string strMail)
        {
            Regex re = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            //Regex re = new Regex(@"^(^\w.*@\w.*$)?$");
            
            Match theMatch = re.Match(strMail);
            if (theMatch.Success)
                return true;//mail dung dinh dang
            else
                return false;//mail khong dung dinh dang
        }
    }
}
