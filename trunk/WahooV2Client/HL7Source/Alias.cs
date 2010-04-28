using System;
using System.Collections.Generic;
using System.Text;

namespace HL7Source
{
    public class Alias
    {
        public const string datetimeFormat = "yyyyMMddHHmmss";
        //attribute of file config
        public const string CLIENT_CODE_CONFIG = "ClientCode";
        public const string CLIENT_NAME_CONFIG = "ClientName";
        public const string CLIENT_EMAIL_CONFIG = "ClientEmail";
        public const string LICENSE_KEY_CONFIG = "LicenseKey";
        public const string BLOWFISH_KEY_CONFIG = "BlowfishKey";
        public const string WEB_SERVICE_ADDRESS_CONFIG = "WsdlUrl";
        public const string SERVER_FOLDER_CONFIG = "ServerFolder";
        public const string TRANSFER_SPEED_CONFIG = "TransferSpeed";
        public const string PRINTER_NAME_DEFAULT = "PrinterNameDefault";
        public const string ACROBAT_EXE_PATH = "AcrobatExe";
        public const string PRINTED_EXTENTION_FILE = "PrintedExtFile";
        public const string IS_SETTING_INFO_CONFIG = "IsSettingInfo";
        public const string NUMBER_OF_COPIES_CONFIG = "NumberOfCopies";
        public const string SCHEDULE_CONFIG = "Schedule";
        //Client download files
        public const string FOLDER_DOWNLOAD_CONFIG = "FolderDownload";
        public const string INTERVAL_DOWNLOAD_CONFIG = "IntervalForDownload";
        public static string SUCCESSED_STATUS = "SUCCESSED";
        public static string FAILED_STATUS = "FAILED";
        
        //trang thai cua Execute download.
        public static bool IsExecuting = false;
        //thoi gian de upload file connect(s)
        public static int INTERVAL_UPLOAD_FILECONNECT = 3;
    }
}
