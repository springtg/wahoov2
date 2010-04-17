using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using WahooCommon;
using WahooConfiguration;
using WahooData.DBO;
using WahooServiceControl;
using System.Xml;
using System.Globalization;
using WahooData.BusinessHandler;
using log4net;

namespace WahooV2.Common
{
    public class SoapProtocol
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Execute Upload data for channel
        /// </summary>
        /// <param name="objChannel"></param>
        public void Execute(Channel objChannel)
        {
            try
            {
                //Download file connect
                DownloadFileConnect(objChannel);
                //Download file status
                DownloadFileStatus(objChannel);
                //Uppload file
                //Folder upload temp to contain file which is encrypted to uplad
                string pathForUpload = Application.StartupPath + @"\UploadTemp";
                if (!Directory.Exists(pathForUpload))
                {
                    Directory.CreateDirectory(pathForUpload);
                }
                //Xoa tat ca cac file trong thu muc UploadTemp
                string[] files = Directory.GetFiles(pathForUpload);
                foreach (string s in files)
                {
                    File.Delete(s);
                }
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                string keyBlowfish = configObl.ReadSetting(AliasMessage.BLOWFISH_KEY_CONFIG);
                //EncryptFolder
                Cryption.EncryptFolderToUpload(objChannel.FilePath, pathForUpload, keyBlowfish);
                //Upload files which was encrypted
                Upload(objChannel, pathForUpload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Download file status to upload infomation in DownloadReport table
        /// </summary>
        /// <param name="objChannel"></param>
        public void DownloadFileStatus(Channel objChannel)
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                //Transfer speed
                double transferSpeed = 16;
                try
                {
                    transferSpeed = double.Parse(configObl.ReadSetting(AliasMessage.TRANSFER_SPEED_CONFIG));
                }
                catch
                {
                    transferSpeed = 16;
                }
                //Download file connect to temp folder
                string pathForDownload = Application.StartupPath + @"\DownloadTemp";
                if (!Directory.Exists(pathForDownload))
                {
                    Directory.CreateDirectory(pathForDownload);
                }
                pathForDownload += "\\" + objChannel.Client.ClientCode;
                if (!Directory.Exists(pathForDownload))
                {
                    Directory.CreateDirectory(pathForDownload);
                }
                //delete all files in status folder
                string[] files = Directory.GetFiles(pathForDownload);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create web service object
                WahooWebServiceControl _WahooWebServiceControl = new WahooWebServiceControl(objChannel.WsdlUrl);
                _WahooWebServiceControl.ServerFolder = objChannel.ServerFolder + "\\status";
                if (!_WahooWebServiceControl.CreateDirectory(_WahooWebServiceControl.ServerFolder))
                {
                    return;
                }
                //Download file status tu client va xoa no
                ArrayList logList = _WahooWebServiceControl.DownloadFolder(pathForDownload, false, transferSpeed);
                foreach (WahooServiceLog log in logList)
                {
                    if (log.ErrorStatus.ToUpper() == AliasMessage.SUCCESSED_STATUS.ToUpper())
                    {
                        try
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            string pathXml = pathForDownload + "\\" + log.FileName;
                            xmlDoc.Load(pathXml);
                            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Infomation");
                            foreach (XmlNode node in nodeList)
                            {
                                ImportReport(node, DataTypeProtect.ProtectInt32(objChannel.Client.Id, 0));
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// Dua thong tin cua file status vao database de bao cao
        /// </summary>
        /// <param name="node"></param>
        /// <param name="idClient"></param>
        private void ImportReport(XmlNode node, int idClient)
        {
            try
            {
                //Get filename
                string fileName = node.ChildNodes[0].InnerText;
                //Get download success status
                Boolean isDownloaded = false;
                if (node.ChildNodes[1].InnerText == "1")
                {
                    isDownloaded = true;
                }
                else
                {
                    isDownloaded = false;
                }
                //Get time downloaded
                string timeDownloaded = node.ChildNodes[2].InnerText;
                //Get sent to print machine success status
                Boolean isSentToPrint = false;
                if (node.ChildNodes[3].InnerText == "1")
                {
                    isSentToPrint = true;
                }
                else
                {
                    isSentToPrint = false;
                }
                //Get time sent to print
                string timeSentToPrint = node.ChildNodes[4].InnerText;
                //Get ip address
                string ipAddress = node.ChildNodes[5].InnerText;
                CultureInfo provider = CultureInfo.InvariantCulture;
                provider = new CultureInfo("en-us");
                //Insert to database
                DownloadReport objInsert = new DownloadReport();
                objInsert.IdClient = idClient;
                objInsert.IpAddress = ipAddress;
                objInsert.Filename = fileName;
                objInsert.Success = isDownloaded;
                objInsert.TimeDownloaded = DateTime.ParseExact(timeDownloaded, "d", provider);
                objInsert.IsSentToPrint = isSentToPrint;
                objInsert.TimeSentToPrint = DateTime.ParseExact(timeSentToPrint, "d", provider);
                int result = WahooBusinessHandler.Add_DownloadReport(objInsert);
            }
            catch
            {

            }
        }
        /// <summary>
        /// Download file connect de biet client co connect den server ko
        /// </summary>
        /// <param name="objChannel"></param>
        /// <returns></returns>
        public Boolean DownloadFileConnect(Channel objChannel)
        {
            StreamReader sr = null;
            FileStream imgStream = null;
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                //Transfer speed
                double transferSpeed = 16;
                try
                {
                    transferSpeed = double.Parse(configObl.ReadSetting(AliasMessage.TRANSFER_SPEED_CONFIG));
                }
                catch
                {
                    transferSpeed = 16;
                }
                Boolean storeFile = false;
                if (objChannel.WsdlUrl == null || objChannel.WsdlUrl.Trim() == string.Empty)
                {
                    return false;
                }
                //Download file connect to temp folder
                string pathForDownload = Application.StartupPath + @"\DownloadTemp";
                if (!Directory.Exists(pathForDownload))
                {
                    Directory.CreateDirectory(pathForDownload);
                }
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create web service object
                WahooWebServiceControl _WahooWebServiceControl = new WahooWebServiceControl(objChannel.WsdlUrl);
                _WahooWebServiceControl.ServerFolder = objChannel.ServerFolder;
                //Download file from server to DownloadFolderTemp
                string fileName = pathForDownload + "\\CONNECT_" + objChannel.Client.ClientCode.ToUpper() + ".txt";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                WahooServiceLog log = _WahooWebServiceControl.DownloadFile(pathForDownload, fileName, storeFile, transferSpeed);
                if (log.ErrorStatus.ToUpper() == AliasMessage.SUCCESSED_STATUS)
                {
                    string connectFilePath = fileName;
                    sr = new StreamReader(connectFilePath);
                    string contentConnect = sr.ReadLine();
                    if (contentConnect.ToUpper() != AliasMessage.CONNECTED_STATUS)
                    {
                        try
                        {
                            ////Lay image disconnect va dua vao database
                            //string imagePath = Application.StartupPath + "/Resource/disconect.gif";
                            //FileInfo fInfo = new FileInfo(imagePath);
                            //long numBytes = fInfo.Length;
                            //imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                            //BinaryReader br = new BinaryReader(imgStream);
                            //objChannel.ImageConnect = br.ReadBytes((int)numBytes);
                            //objChannel.Update();
                            objChannel.IsConnected = true;
                            objChannel.Update();
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {
                            if (imgStream != null)
                            {
                                imgStream.Close();
                            }
                        }
                        if (sr != null)
                        {
                            sr.Close();
                        }
                        return false;
                    }
                    if (sr != null)
                    {
                        sr.Close();
                    }
                    try
                    {
                        ////Lay image disconnect va dua vao database
                        //string imagePath = Application.StartupPath + "/Resource/disconect.gif";
                        //FileInfo fInfo = new FileInfo(imagePath);
                        //long numBytes = fInfo.Length;
                        //imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                        //BinaryReader br = new BinaryReader(imgStream);
                        //objChannel.ImageConnect = br.ReadBytes((int)numBytes);
                        //objChannel.Update();
                        objChannel.IsConnected = false;
                        objChannel.Update();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        if (imgStream != null)
                        {
                            imgStream.Close();
                        }
                    }
                    return true;
                }
                else
                {
                    try
                    {
                        ////Lay image disconnect va dua vao database
                        //string imagePath = Application.StartupPath + "/Resource/disconect.gif";
                        //FileInfo fInfo = new FileInfo(imagePath);
                        //long numBytes = fInfo.Length;
                        //imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                        //BinaryReader br = new BinaryReader(imgStream);
                        //objChannel.ImageConnect = br.ReadBytes((int)numBytes);
                        //objChannel.Update();
                        objChannel.IsConnected = false;
                        objChannel.Update();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (imgStream != null)
                        {
                            imgStream.Close();
                        }
                    }
                    return false;
                }
            }
            catch
            {
                if (sr != null)
                {
                    sr.Close();
                }
                try
                {
                    ////Lay image disconnect va dua vao database
                    //string imagePath = Application.StartupPath + "/Resource/disconect.gif";
                    //FileInfo fInfo = new FileInfo(imagePath);
                    //long numBytes = fInfo.Length;
                    //imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                    //BinaryReader br = new BinaryReader(imgStream);
                    //objChannel.ImageConnect = br.ReadBytes((int)numBytes);
                    //objChannel.Update();
                    objChannel.IsConnected = false;
                    objChannel.Update();
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (imgStream != null)
                    {
                        imgStream.Close();
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// Upload tat ca cac file trong thu muc cua channel len server
        /// </summary>
        /// <param name="objChannel"></param>
        /// <param name="folderToUpload"></param>
        private void Upload(Channel objChannel, string folderToUpload)
        {
            try
            {
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create web service object
                WahooWebServiceControl _WahooWebServiceControl = new WahooWebServiceControl(objChannel.WsdlUrl);
                _WahooWebServiceControl.ServerFolder = objChannel.ServerFolder;
                if (!_WahooWebServiceControl.CreateDirectory(_WahooWebServiceControl.ServerFolder))
                {
                    return;
                }
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                //Transfer speed
                double transferSpeed = 16;
                try
                {
                    transferSpeed = double.Parse(configObl.ReadSetting(AliasMessage.TRANSFER_SPEED_CONFIG));
                }
                catch
                {
                    transferSpeed = 16;
                }
                string pauseLog = "0";
                try
                {
                    pauseLog = configObl.ReadSetting(AliasMessage.PAUSE_LOG_CONFIG);
                }
                catch
                {
                    pauseLog = "0";
                }
                //Get files to upload
                string[] files = Directory.GetFiles(folderToUpload);
                foreach (string file in files)
                {
                    if (file != "")
                    {
                        //Create parameter to transfer throught thread
                        ArrayList arrParameter = new ArrayList();
                        arrParameter.Add(objChannel.ServerFolder);
                        arrParameter.Add(objChannel.WsdlUrl);
                        arrParameter.Add(file);
                        arrParameter.Add(objChannel.StoreFile.ToString());
                        arrParameter.Add(transferSpeed.ToString());
                        arrParameter.Add(pauseLog);
                        arrParameter.Add(objChannel.Id.ToString());
                        UploadFile(arrParameter);
                        //Create thread to download file
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(this.UploadFile), arrParameter);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Upload file den server
        /// </summary>
        /// <param name="arrParameter"></param>
        private void UploadFile(object arrParameter)
        {
            try
            {
                //Get infomation about arrParameter
                string serverFolder = ((ArrayList)arrParameter)[0].ToString();
                string webUrl = ((ArrayList)arrParameter)[1].ToString();
                string file = ((ArrayList)arrParameter)[2].ToString();
                Boolean storeFile = false;
                if (((ArrayList)arrParameter)[3].ToString().ToUpper() == "TRUE")
                {
                    storeFile = true;
                }
                else
                {
                    storeFile = false;
                }
                double transferSpeed = 0;
                try
                {
                    transferSpeed = double.Parse(((ArrayList)arrParameter)[4].ToString());
                }
                catch
                {
                    transferSpeed = 16;
                }
                string pauseLog = ((ArrayList)arrParameter)[5].ToString();
                int idChannel = DataTypeProtect.ProtectInt32(((ArrayList)arrParameter)[6].ToString(), 0);
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                WahooWebServiceControl _WahooWebServiceControl = new WahooWebServiceControl(webUrl);
                _WahooWebServiceControl.ServerFolder = serverFolder;
                WahooServiceLog log = _WahooWebServiceControl.Upload(file, storeFile, transferSpeed);
                //Write log in database
                if (Path.GetFileName(file) != "BlowfishKey.txt")
                {
                    //If not pause log->create log
                    if (pauseLog == "0")
                    {
                        HistoryOfChannel objInsertHist = new HistoryOfChannel();
                        objInsertHist.DateExecute = DateTime.Now;
                        objInsertHist.IdChannel = idChannel;
                        objInsertHist.Description = log.Description;
                        objInsertHist.Status = log.ErrorStatus;
                        int resultHist = WahooBusinessHandler.Add_HistoryOfChannel(objInsertHist);
                    }
                    //Update sent and error in channel
                    Channel objUpdateChannel = new Channel();
                    objUpdateChannel.Id = idChannel;
                    objUpdateChannel = WahooBusinessHandler.Get_Channel(objUpdateChannel);
                    objUpdateChannel.Sent = objUpdateChannel.Sent + 1;
                    if (log.ErrorStatus == AliasMessage.FAILED_STATUS)
                    {
                        objUpdateChannel.Error = objUpdateChannel.Error + 1;
                    }
                    objUpdateChannel.Update();
                }
            }
            catch (Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);                
            }
        }
    }
}
