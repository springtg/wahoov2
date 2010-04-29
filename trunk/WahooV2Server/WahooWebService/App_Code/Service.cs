using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Collections;
using System.Web.Services.Protocols;

//[WebService(Namespace = "http://www.dotnetslackers.com/wse/documentlibrarysample")]
[WebService(Namespace = "http://www.northwesterngroup.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public AuthSoapHd spAuthenticationHeader;

    public class AuthSoapHd : SoapHeader
    {
        public string strUserName;
        public string strPassword;
    }
    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    private TransferFile transferFile = new TransferFile();

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method for download file,return the array of byte")]
    public byte[] DownloadFile(string serverFolder, string filename, long Offset, int BufferSize, Boolean storeFile)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            try
            {
                string path = Server.MapPath(".") + serverFolder + "\\" + filename;
                return transferFile.ReadBinaryFile(path, Offset, BufferSize, storeFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            return null;
        }
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method,return the list of filename in download folder")]
    public ArrayList GetDownloadFiles(string serverFolder)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            string path = Server.MapPath(".") + serverFolder;
            return transferFile.GetFiles(path);
        }
        return new ArrayList();
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides mothed for upload file, return true or false")]
    public Boolean UploadFile(byte[] buffer, long Offset, string serverFolder, string fileName, Boolean storeFile, Boolean endOfFile)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            try
            {
                string path = Server.MapPath(".") + serverFolder + "\\" + fileName;
                return transferFile.WriteBinarFile(buffer, Offset, path, endOfFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return false;
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method, create directory in server")]
    public Boolean CreateDirectory(string path)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            try
            {
                string tempPath = Server.MapPath(".");
                string[] arrPath = path.Split(Path.DirectorySeparatorChar);
                for (int i = 1; i < arrPath.Length; i++)
                {
                    tempPath += @"\" + arrPath[i];
                    if (!transferFile.CreateDirectory(tempPath))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        return false;
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method, check exists directory in server")]
    public Boolean CheckExistsDirectory(string path)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            try
            {
                path = Server.MapPath(".") + path;
                return transferFile.CheckExistsDirectory(path);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        return false;
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method, get size of file in server")]
    public long GetFileSize(string serverFolder, string filename)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            string FilePath = Server.MapPath(".") + serverFolder + "\\" + filename;

            // check that requested file exists
            if (!File.Exists(FilePath))
            {
                return 0;
            }
            return new FileInfo(FilePath).Length;
        }
        return 0;

    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method, get key")]
    public string GetBlowfishKey()
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            string blowfishKeyFile = Server.MapPath(".") + "\\OutGoing\\BlowfishKey.txt";

            // check that requested file exists
            if (!File.Exists(blowfishKeyFile))
            {
                return "";
            }
            return transferFile.GetBlowfishKey(blowfishKeyFile);
        }
        return "";
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method, edit key")]
    public Boolean UploadBlowfishKey(string keyBlowfish)
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            string blowfishKeyFile = Server.MapPath(".") + "\\OutGoing\\BlowfishKey.txt";
            return transferFile.UploadBlowfishKey(blowfishKeyFile, keyBlowfish);
        }
        return false;
    }

    [SoapHeader("spAuthenticationHeader")]
    [WebMethod(Description = "Web service provides method to get IpAddress")]
    public string GetIpAddress()
    {
        if (spAuthenticationHeader.strUserName == "980@Cuong!@#$%678" && spAuthenticationHeader.strPassword == "78$>@!(C%7")
        {
            string pstrClientAddress = HttpContext.Current.Request.UserHostAddress;
            return pstrClientAddress;
        }
        return "";
    }
}
