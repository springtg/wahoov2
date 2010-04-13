using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
