using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;
using HL7Source;
using System.Xml;
using System.IO;

namespace WahooService
{
    public partial class WahooService : ServiceBase
    {
        private Boolean _mExecuting;
        private System.Timers.Timer wahooTimer;
        private System.ComponentModel.BackgroundWorker bgwMain;
        private Boolean _mExecutingConvert;
        public WahooService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            wahooTimer.Enabled = true;
            string configPath = Application.StartupPath + @"\HL7Client.exe.config";
            Config configObl = new Config(configPath);
            string clientCode = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG);
            string clientName = configObl.ReadSetting(Alias.CLIENT_NAME_CONFIG);
            string email = configObl.ReadSetting(Alias.CLIENT_EMAIL_CONFIG);
            string strEncode = clientCode + clientName + email;
            string licenseKey = configObl.ReadSetting(Alias.LICENSE_KEY_CONFIG);
            if (licenseKey != EncodeMd5.EncodeString(strEncode))
            {
                string _mServiceName = "HL7ClientService";
                wahooTimer.Enabled = false;
                System.ServiceProcess.ServiceController controller = new ServiceController(_mServiceName);
                controller.Stop();
                return;
            }
            else
            {
                wahooTimer.Enabled = true;
            }
            int timeInterval = 0;
            try
            {
                timeInterval = int.Parse(configObl.ReadSetting(Alias.INTERVAL_DOWNLOAD_CONFIG));
            }
            catch
            {
                timeInterval = 20;
            }
            wahooTimer.Interval = timeInterval * 1000;
            _mExecuting = false;
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            wahooTimer.Enabled = false;
        }

        private void bgwMain_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DownloadData();
                int temp = 0;
                try
                {
                    Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                    temp = int.Parse(configObl.ReadSetting(Alias.INTERVAL_DOWNLOAD_CONFIG));
                }
                catch
                {
                    temp = 0;
                }
                if (temp < 10)
                {
                    temp = 10;
                }
                temp = temp * 1000;
                if (this.wahooTimer.Interval != temp)
                {
                    this.wahooTimer.Stop();
                    this.wahooTimer.Interval = temp;
                    this.wahooTimer.Start();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ////Write log in Log folder
                //string logFolder = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                //if (!Directory.Exists(logFolder))
                //{
                //    Directory.CreateDirectory(logFolder);
                //}
                ////Write log
                //Log.Write(ex, logFolder);
                Cursor.Current = Cursors.Default;
            }
        }
        private void InitializeComponent()
        {
            this.wahooTimer = new System.Timers.Timer();
            this.bgwMain = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.wahooTimer)).BeginInit();
            // 
            // wahooTimer
            // 
            this.wahooTimer.Enabled = true;
            this.wahooTimer.Interval = 20000;
            this.wahooTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.wahooTimer_Elapsed);
            // 
            // bgwMain
            // 
            this.bgwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMain_DoWork);
            ((System.ComponentModel.ISupportInitialize)(this.wahooTimer)).EndInit();

        }
        /// <summary>
        /// Download data to web server
        /// </summary>
        private void DownloadData()
        {
            try
            {
                string configPath = Application.StartupPath + @"\HL7Client.exe.config";
                Config configObl = new Config(configPath);
                string url = configObl.ReadSetting(Alias.WEB_SERVICE_ADDRESS_CONFIG);
                //Upload file connect to server
                UploadFileConnect();
                string clientFolder = configObl.ReadSetting(Alias.FOLDER_DOWNLOAD_CONFIG);
                if (!Directory.Exists(clientFolder))
                {
                    return;
                }
                string serverFolder = configObl.ReadSetting(Alias.SERVER_FOLDER_CONFIG) + "\\" + configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG);
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                HL7Service _mHL7Service = new HL7Service(url);
                if (url.Trim() == "" || clientFolder.Trim() == "" || serverFolder.Trim() == "")
                {
                    return;
                }
                Boolean storeFile = false;
                string DownloadFolderTemp = AppDomain.CurrentDomain.BaseDirectory + @"\DownloadTemp";
                if (!Directory.Exists(DownloadFolderTemp))
                {
                    Directory.CreateDirectory(DownloadFolderTemp);
                }
                _mHL7Service.ServerFolder = serverFolder;
                //Check file blowfish was downloaded and get blowfishKey
                string blowfishKey = GetBlowfishKey(url);
                if (blowfishKey != "")
                {
                    //Get name of files from web service
                    object[] filesToDownload = _mHL7Service.GetDownloadFiles();
                    //Download files
                    foreach (string file in filesToDownload)
                    {
                        //Not download file blowfishKey(because file blowfishKey was downloaded before) and file not fully
                        if (Path.GetFileName(file).Contains(".part") == false)
                        {
                            if (_mHL7Service.GetFileSizeToDownload(file) > 0)
                            {
                                //Check file which will be downloaded exists in folder DownloadTemp
                                string fileTemp = DownloadFolderTemp + "\\" + Path.GetFileName(file);
                                if (File.Exists(fileTemp))
                                {
                                    File.Delete(fileTemp);
                                }
                                DownloadFile(url, serverFolder, DownloadFolderTemp, Path.GetFileName(file), blowfishKey, clientFolder);
                            }
                        }
                    }
                    UploadFileStatus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UploadFileConnect()
        {
            try
            {
                string configPath = Application.StartupPath + @"\HL7Client.exe.config";
                Config configObl = new Config(configPath);
                string url = configObl.ReadSetting(Alias.WEB_SERVICE_ADDRESS_CONFIG);
                string clientCode = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG).ToUpper();
                //Move data to folder UploadTemp to upload
                string pathForUpload = System.Windows.Forms.Application.StartupPath + @"\UploadTemp";
                if (!Directory.Exists(pathForUpload))
                {
                    Directory.CreateDirectory(pathForUpload);
                }
                pathForUpload += @"\Connect";
                if (!Directory.Exists(pathForUpload))
                {
                    Directory.CreateDirectory(pathForUpload);
                }
                string clientFolder = pathForUpload;
                //Create connect file to inform program is connected
                StreamWriter swConnectFile = null;
                string connectFile = pathForUpload + "\\CONNECT_" + clientCode + ".txt";
                try
                {
                    if (!File.Exists(connectFile))
                    {
                        swConnectFile = File.AppendText(connectFile);
                        swConnectFile.WriteLine("CONNECTED");
                        if (swConnectFile != null)
                        {
                            swConnectFile.Close();
                        }
                    }
                }
                catch
                {
                    if (swConnectFile != null)
                    {
                        swConnectFile.Close();
                    }
                }
                //Server folder must be \Upload\ClientCode\Connect
                string serverFolder = configObl.ReadSetting(Alias.SERVER_FOLDER_CONFIG) + "\\" + configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG) + "\\Connect";
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create object web service
                HL7Service _mHL7Service = new HL7Service(url);
                //Create folder \Upload\ClientCode in web service to upload data
                if (!_mHL7Service.CreateDirectory(serverFolder))
                {
                    return;
                }
                //Check data valid
                if (url.Trim() == "" || clientFolder.Trim() == "" || serverFolder.Trim() == "")
                {
                    return;
                }
                Boolean storeFile = true;
                _mHL7Service.ServerFolder = serverFolder;
                double transferSpeed = 16;
                try
                {
                    transferSpeed = double.Parse(configObl.ReadSetting(Alias.TRANSFER_SPEED_CONFIG));
                }
                catch
                {
                    transferSpeed = 16;
                }
                _mHL7Service.Upload(connectFile, storeFile, transferSpeed);
            }
            catch (Exception ex)
            {

            }
        }
        private void UploadFileStatus()
        {
            try
            {
                string configPath = Application.StartupPath + @"\HL7Client.exe.config";
                Config configObl = new Config(configPath);
                string url = configObl.ReadSetting(Alias.WEB_SERVICE_ADDRESS_CONFIG);
                string clientCode = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG).ToUpper();
                //Move data to folder UploadTemp to upload
                string oldPathForUpload = System.Windows.Forms.Application.StartupPath + @"\status\status.xml";
                if (!File.Exists(oldPathForUpload))
                {
                    return;
                }
                //Upload file status with name must diferrent together.
                string pathForUpload = System.Windows.Forms.Application.StartupPath + @"\status\status_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                File.Move(oldPathForUpload, pathForUpload);
                //Server folder must be \Upload\ClientCode
                string serverFolder = configObl.ReadSetting(Alias.SERVER_FOLDER_CONFIG) + "\\" + configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG) + "\\status";
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create object web service
                HL7Service _mHL7Service = new HL7Service(url);
                //Create folder \Upload\ClientCode in web service to upload data
                if (!_mHL7Service.CreateDirectory(serverFolder))
                {
                    return;
                }
                Boolean storeFile = false;
                _mHL7Service.ServerFolder = serverFolder;
                double transferSpeed = 16;
                try
                {
                    transferSpeed = double.Parse(configObl.ReadSetting(Alias.TRANSFER_SPEED_CONFIG));
                }
                catch
                {
                    transferSpeed = 16;
                }
                _mHL7Service.Upload(pathForUpload, storeFile, transferSpeed);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Download file from server
        /// </summary>
        /// <param name="webUrl"></param>
        /// <param name="serverFolder"></param>
        /// <param name="localFolder"></param>
        /// <param name="filename"></param>
        /// <param name="blowfishKey"></param>
        /// <param name="clientFolder"></param>
        private void DownloadFile(string webUrl, string serverFolder, string localFolder, string file, string blowfishKey, string clientFolder)
        {
            try
            {
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create web service object
                HL7Service _mHL7WebService = new HL7Service(webUrl);
                _mHL7WebService.ServerFolder = serverFolder;
                //Download file from server to DownloadFolderTemp
                HL7Log log = _mHL7WebService.DownloadFile(localFolder, file, false);
                //Then import file to database
                string dateExecute = DateTime.Now.ToString("yyyyMMdd");
                log.IsSentToPrint = false;
                //If download file success
                if (log.IsDownloaded)
                {
                    string pathForDownload = System.Windows.Forms.Application.StartupPath + @"\DownloadTemp";
                    if (!Directory.Exists(pathForDownload))
                    {
                        Directory.CreateDirectory(pathForDownload);
                    }
                    string sourceFile = pathForDownload + "\\" + log.FileName;
                    //Transfer file                    
                    //If have blowfish key
                    if (blowfishKey != "")
                    {
                        try
                        {
                            string tempFile = clientFolder + "\\" + Path.GetFileName(file);
                            if (File.Exists(tempFile))
                            {
                                File.Delete(tempFile);
                            }
                            //Create temp file
                            StreamWriter sw = File.AppendText(tempFile);
                            if (sw != null)
                            {
                                sw.Close();
                            }
                            try
                            {
                                if (Cryption.DecryptFile(sourceFile, tempFile, blowfishKey))
                                {
                                    //Delete source file
                                    if (File.Exists(sourceFile))
                                    {
                                        File.Delete(sourceFile);
                                    }
                                    //Sent to print
                                    log.IsSentToPrint = SentToPrint(tempFile);
                                }
                                else
                                {
                                    //Delete source file
                                    if (File.Exists(sourceFile))
                                    {
                                        File.Delete(sourceFile);
                                    }
                                    string errorFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Error";
                                    if (!Directory.Exists(errorFolderPath))
                                    {
                                        Directory.CreateDirectory(errorFolderPath);
                                    }
                                    errorFolderPath += @"\" + DateTime.Now.ToString("yyyyMMdd");
                                    if (!Directory.Exists(errorFolderPath))
                                    {
                                        Directory.CreateDirectory(errorFolderPath);
                                    }
                                    string fileDest = errorFolderPath + @"\" + Path.GetFileName(sourceFile);
                                    if (File.Exists(fileDest))
                                    {
                                        File.Delete(fileDest);
                                    }
                                    File.Move(sourceFile, fileDest);
                                    log.Description += string.Format(HL7Source.Message.GetMessageById("LOG009"));
                                    log.ErrorStatus = "ERROR";
                                }
                            }
                            catch
                            {
                                //Delete source file
                                if (File.Exists(sourceFile))
                                {
                                    File.Delete(sourceFile);
                                }
                                string errorFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Error";
                                if (!Directory.Exists(errorFolderPath))
                                {
                                    Directory.CreateDirectory(errorFolderPath);
                                }
                                errorFolderPath += @"\" + DateTime.Now.ToString("yyyyMMdd");
                                if (!Directory.Exists(errorFolderPath))
                                {
                                    Directory.CreateDirectory(errorFolderPath);
                                }
                                string fileDest = errorFolderPath + @"\" + Path.GetFileName(sourceFile);
                                if (File.Exists(fileDest))
                                {
                                    File.Delete(fileDest);
                                }
                                File.Move(sourceFile, fileDest);
                                log.Description += string.Format(HL7Source.Message.GetMessageById("LOG009"));
                                log.ErrorStatus = "ERROR";
                            }
                        }
                        catch
                        {
                            //Delete source file
                            if (File.Exists(sourceFile))
                            {
                                File.Delete(sourceFile);
                            }
                            return;
                        }
                    }
                    //Other wise -> move to error folder
                    else
                    {
                        string errorFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Error";
                        if (!Directory.Exists(errorFolderPath))
                        {
                            Directory.CreateDirectory(errorFolderPath);
                        }
                        errorFolderPath += @"\" + DateTime.Now.ToString("yyyyMMdd");
                        if (!Directory.Exists(errorFolderPath))
                        {
                            Directory.CreateDirectory(errorFolderPath);
                        }
                        string fileDest = errorFolderPath + @"\" + Path.GetFileName(sourceFile);
                        if (File.Exists(fileDest))
                        {
                            File.Delete(fileDest);
                        }
                        File.Move(sourceFile, fileDest);
                        log.Description += string.Format(HL7Source.Message.GetMessageById("LOG009"));
                        log.ErrorStatus = "ERROR";
                    }
                }
                log.TimeSentToPrint = DateTime.Now.ToString("yyyyMMddHHmmss");
                WiteFileStatus(log);
                ////Write log in Log folder
                //string logFolder = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                //if (!Directory.Exists(logFolder))
                //{
                //    Directory.CreateDirectory(logFolder);
                //}
                //Write log
                //Log.Write(log.Description, logFolder);
            }
            catch (Exception ex)
            {
                ////Write log in Log folder
                //string logFolder = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                //if (!Directory.Exists(logFolder))
                //{
                //    Directory.CreateDirectory(logFolder);
                //}
                ////Write log
                //Log.Write(ex, logFolder);
            }
        }
        /// <summary>
        /// Sent file to print machine
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Boolean SentToPrint(string path)
        {
            Boolean result = false;
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string printedExtFile = configObl.ReadSetting(Alias.PRINTED_EXTENTION_FILE);
            string[] extArr = printedExtFile.Split(';');
            Boolean isPrint = false;
            //Check file is printed or not
            foreach (string ext in extArr)
            {
                if (Path.GetExtension(path) == ext)
                {
                    isPrint = true;
                    break;
                }
            }
            if (!isPrint)
            {
                return false;
            }
            string printerPath = configObl.ReadSetting(Alias.PRINTER_NAME_DEFAULT);
            PrintClass printObj = new PrintClass();

            if (Path.GetExtension(path).ToUpper() == ".DOC")
            {
                result = printObj.PrintDocFile(path, printerPath);
            }
            return result;
        }
        /// <summary>
        /// Write file status to send to server
        /// </summary>
        /// <param name="log"></param>
        private void WiteFileStatus(HL7Log log)
        {
            string statusFolder = AppDomain.CurrentDomain.BaseDirectory + "\\status";
            if (!Directory.Exists(statusFolder))
            {
                Directory.CreateDirectory(statusFolder);
            }
            string statusFile = statusFolder + "\\status.xml";
            if (!File.Exists(statusFile))
            {
                //Create file xml
                XmlTextWriter xmlWriter = new XmlTextWriter(statusFile, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("Infomations");
                xmlWriter.Close();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(statusFile);
            //Get xml root
            XmlNode root = xmlDoc.DocumentElement;
            XmlElement nodeRoot = xmlDoc.CreateElement("Infomation");
            //Create filename node
            XmlElement nodeFilename = xmlDoc.CreateElement("Filename");
            nodeFilename.InnerText = log.FileName;
            nodeRoot.AppendChild(nodeFilename);
            //Create success download status node
            XmlElement nodeDownloadStatus = xmlDoc.CreateElement("Downloaded");
            if (log.IsDownloaded)
            {
                nodeDownloadStatus.InnerText = "1";
            }
            else
            {
                nodeDownloadStatus.InnerText = "0";
            }
            nodeRoot.AppendChild(nodeDownloadStatus);
            //Create time downloaded node
            XmlElement nodeTimeDownloaded = xmlDoc.CreateElement("TimeDownloaded");
            nodeTimeDownloaded.InnerText = log.TimeDownloaded;
            nodeRoot.AppendChild(nodeTimeDownloaded);
            //Create is sent to print machine node
            XmlElement nodeIsSentToPrint = xmlDoc.CreateElement("SentToPrint");
            if (log.IsSentToPrint)
            {
                nodeIsSentToPrint.InnerText = "1";
            }
            else
            {
                nodeIsSentToPrint.InnerText = "0";
            }
            nodeRoot.AppendChild(nodeIsSentToPrint);
            //Create time sent to print node
            XmlElement nodeTimeSentToPrint = xmlDoc.CreateElement("TimeSentToPrint");
            nodeTimeSentToPrint.InnerText = log.TimeSentToPrint;
            nodeRoot.AppendChild(nodeTimeSentToPrint);
            //Create time ip address node
            XmlElement nodeIpAddres = xmlDoc.CreateElement("IpAddress");
            nodeIpAddres.InnerText = log.IpAddress;
            nodeRoot.AppendChild(nodeIpAddres);
            root.AppendChild(nodeRoot);
            xmlDoc.Save(statusFile);
        }

        /// <summary>
        /// Download file blowfishKey
        /// </summary>
        /// <param name="webUrl"></param>
        /// <param name="localFolder"></param>
        /// <param name="transferSpeed"></param>
        public string GetBlowfishKey(string webUrl)
        {
            try
            {
                string blowfishKey = "";
                //Accept SSL in web service
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //Create web service object
                HL7Service _mHL7WebService = new HL7Service(webUrl);
                string key = _mHL7WebService.GetBlowfishKey();
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                string originalKey = configObl.ReadSetting(Alias.BLOWFISH_KEY_CONFIG);
                if (key != originalKey)
                {
                    configObl.WriteSetting(Alias.BLOWFISH_KEY_CONFIG, key);
                    blowfishKey = key;
                }
                else
                {
                    blowfishKey = originalKey;
                }
                return blowfishKey;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void wahooTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this._mExecuting == false)
            {
                this._mExecuting = true;
                if (!bgwMain.IsBusy)
                {
                    bgwMain.RunWorkerAsync();
                }
                this._mExecuting = false;
            }  
        }

    }
}
