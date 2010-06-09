using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using HL7Source;
using HL7ServerTransfer.Job;
using HL7ServerTransfer.Properties;
using System.IO;
using Quartz;
using log4net;
using System.Net;
using System.Management;

namespace HL7ServerTransfer
{
    public partial class frmMain : frmBase
    {
        private const string STRERROR = "ERROR";
        private const string STRNOERROR = "NOERROR";
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Variable for store running program at startup
        //Sua lai theo thong tin
        RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        //RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        //Is downloading
        private Boolean _mExecuting = false;
        //Folder in web server
        private string _serverFolder = "";
        private Boolean _mUpdateInfo = false;
        private HL7Source.PrintClass _cPrinter;
        ISchedulerFactory schedFact;
        IScheduler sched;

        public frmMain()
        {
            InitializeComponent();
            schedFact = new Quartz.Impl.StdSchedulerFactory();
            sched = schedFact.GetScheduler();
            sched.Start();
        }

        #region Event

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ////Luu RunFirstTime = false
                //Settings.Default.boolRunFirstTime = true;
                //Settings.Default.Save();
                _cPrinter = new PrintClass();
                //Load info
                ResetHL7Setup();

                //start timerUploadfileConnect
                this.timerUploadfileConnect.Interval = Alias.INTERVAL_UPLOAD_FILECONNECT * 1000;
                this.timerUploadfileConnect.Start();

                //neu la lan dau tien chay chuong trinh thi ko goi ham StartDownloadAndStartSchedule();
                if (!Settings.Default.boolRunFirstTime)
                {
                    StartDownloadAndStartSchedule();
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    frmMain_Resize(sender, e);
                }
            }
            catch (Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
            }
        }

        private void btnSourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.SelectedPath = @"C:\";
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                txtDownloadFolder.Text = dlgFolder.SelectedPath;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInfo())
                {
                    return;
                }
                string txtPrintedFormat = "";
                if (chkDoc.Checked)
                {
                    txtPrintedFormat += ".doc;.docx;";
                }
                if (chkPdf.Checked)
                {
                    txtPrintedFormat += ".pdf;";
                }
                if (chkXsl.Checked)
                {
                    txtPrintedFormat += ".xls;.xlsx";
                }

                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                configObl.WriteSetting(Alias.INTERVAL_DOWNLOAD_CONFIG, txtInterval.Text);
                configObl.WriteSetting(Alias.WEB_SERVICE_ADDRESS_CONFIG, txtURL.Text);
                configObl.WriteSetting(Alias.FOLDER_DOWNLOAD_CONFIG, txtDownloadFolder.Text);
                configObl.WriteSetting(Alias.TRANSFER_SPEED_CONFIG, txtTransferSpeed.Text);
                configObl.WriteSetting(Alias.PRINTER_NAME_DEFAULT, cbPrinter.Text);
                configObl.WriteSetting(Alias.PRINTED_EXTENTION_FILE, txtPrintedFormat);
                configObl.WriteSetting(Alias.NUMBER_OF_COPIES_CONFIG, txtNumOfCopies.Text);
                //Set for schedule
                string scheduleStr = "";
                string scheduleDateStr = "";
                if (chkMonday.Checked)
                {
                    scheduleDateStr += "MON,";
                }
                if (chkTuesday.Checked)
                {
                    scheduleDateStr += "TUE,";
                }
                if (chkWednesday.Checked)
                {
                    scheduleDateStr += "WED,";
                }
                if (chkThursday.Checked)
                {
                    scheduleDateStr += "THU,";
                }
                if (chkFriday.Checked)
                {
                    scheduleDateStr += "FRI,";
                }
                if (chkSaturday.Checked)
                {
                    scheduleDateStr += "SAT,";
                }
                if (chkSunday.Checked)
                {
                    scheduleDateStr += "SUN,";
                }
                //bo dau ',' o cuoi scheduleDateStr
                scheduleDateStr = scheduleDateStr.Length > 0 ? scheduleDateStr.Substring(0, scheduleDateStr.Length - 1) : scheduleDateStr;
                string scheduleTimeFrom = dtpFrom.Value.Hour.ToString() + "," + dtpFrom.Value.Minute.ToString() + "," + dtpFrom.Value.Second.ToString();
                string scheduleTimeTo = dtpTo.Value.Hour.ToString() + "," + dtpTo.Value.Minute.ToString() + "," + dtpTo.Value.Second.ToString();
                scheduleStr = scheduleDateStr + "|" + scheduleTimeFrom + "|" + scheduleTimeTo;
                configObl.WriteSetting(Alias.SCHEDULE_CONFIG, scheduleStr);
                if (!this._mUpdateInfo)
                {
                    configObl.WriteSetting(Alias.IS_SETTING_INFO_CONFIG, "1");
                    this._mUpdateInfo = true;
                }
                try
                {
                    Settings.Default.boolStartup = chkStartup.Checked;
                    Settings.Default.Save();

                    //Save running startup variable
                    if (chkStartup.Checked)
                    {
                        // Add the value in the registry so that the application runs at startup
                        rkApp.SetValue("MyApp", System.Windows.Forms.Application.ExecutablePath.ToString());
                    }
                    else
                    {
                        // Remove the value from the registry so that the application doesn't start
                        rkApp.DeleteValue("MyApp", false);
                    }

                    //Luu RunFirstTime = false
                    Settings.Default.boolRunFirstTime = false;
                    Settings.Default.Save();

                    this.ShowMessageBox("INF001", string.Format(HL7Source.Message.GetMessageById("INF001")), MessageType.INFORM);
                }
                catch (Exception ex)
                {
                    this.ShowMessageBox("INF002", string.Format(HL7Source.Message.GetMessageById("INF002")), MessageType.INFORM);
                    if (_logger.IsErrorEnabled)
                        _logger.Error(ex);
                }
                //this.ShowMessageBox("INF001", string.Format(HL7Source.Message.GetMessageById("INF001")), MessageType.INFORM);
                // StartDownloadAndStartSchedule();//dong lenh nay duoc doi qua btnstart
            }
            catch (Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Reset HL7Setup
        /// </summary>
        private void ResetHL7Setup()
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                //Set timer interval for download
                int timeInterval = 0;
                try
                {
                    timeInterval = int.Parse(configObl.ReadSetting(Alias.INTERVAL_DOWNLOAD_CONFIG));
                }
                catch
                {
                    timeInterval = 10;
                }
                if (timeInterval < 10)
                {
                    timeInterval = 10;
                }

                //thay timer bang Quartz
                //tmDownload.Interval = timeInterval * 1000;
                //Set web service address

                txtURL.Text = configObl.ReadSetting(Alias.WEB_SERVICE_ADDRESS_CONFIG);
                //Set server folder
                this._serverFolder = configObl.ReadSetting(Alias.SERVER_FOLDER_CONFIG);
                //Set client code
                txtClientCode.Text = configObl.ReadSetting(Alias.CLIENT_CODE_CONFIG);
                //Set client name
                txtClientName.Text = configObl.ReadSetting(Alias.CLIENT_NAME_CONFIG);
                //Set email
                txtEmail.Text = configObl.ReadSetting(Alias.CLIENT_EMAIL_CONFIG);
                //Set license key
                txtLicenseKey.Text = configObl.ReadSetting(Alias.LICENSE_KEY_CONFIG);
                //Set local folder
                txtDownloadFolder.Text = configObl.ReadSetting(Alias.FOLDER_DOWNLOAD_CONFIG);
                //Set interval
                txtInterval.Text = timeInterval.ToString();
                //Set transfer speed
                txtTransferSpeed.Text = configObl.ReadSetting(Alias.TRANSFER_SPEED_CONFIG);
                #region "Tab Printer Setting"
                //Find printers
                _cPrinter.getAllPrinter(ref cbPrinter, configObl);
                //Set file format
                string formatFiles = configObl.ReadSetting(Alias.PRINTED_EXTENTION_FILE);
                string[] arrFormats = formatFiles.Split(';');
                Boolean checkDoc = false;
                Boolean checkPdf = false;
                Boolean checkXsl = false;
                foreach (string format in arrFormats)
                {
                    if (format.ToLower() == ".doc")
                    {
                        checkDoc = true;
                    }
                    else if (format.ToLower() == ".pdf")
                    {
                        checkPdf = true;
                    }
                    else if (format.ToLower() == ".xsl")
                    {
                        checkXsl = true;
                    }
                    else
                    {
                    }
                }
                if (checkXsl)
                {
                    chkXsl.Checked = true;
                }
                else
                {
                    chkXsl.Checked = false;
                }
                if (checkDoc)
                {
                    chkDoc.Checked = true;
                }
                else
                {
                    chkDoc.Checked = false;
                }
                if (checkPdf)
                {
                    chkPdf.Checked = true;
                }
                else
                {
                    chkPdf.Checked = false;
                }
                //Set number of copies
                txtNumOfCopies.Text = configObl.ReadSetting(Alias.NUMBER_OF_COPIES_CONFIG);
                #endregion
                //Set schedule
                string scheduleStr = configObl.ReadSetting(Alias.SCHEDULE_CONFIG);
                string[] scheduleDateArr = scheduleStr.Split('|')[0].Split(',');
                foreach (string date in scheduleDateArr)
                {
                    switch (date)
                    {
                        case "MON":
                            chkMonday.Checked = true;
                            break;
                        case "TUE":
                            chkTuesday.Checked = true;
                            break;
                        case "WED":
                            chkWednesday.Checked = true;
                            break;
                        case "THU":
                            chkThursday.Checked = true;
                            break;
                        case "FRI":
                            chkFriday.Checked = true;
                            break;
                        case "SAT":
                            chkSaturday.Checked = true;
                            break;
                        case "SUN":
                            chkSunday.Checked = true;
                            break;
                        default:
                            break;
                    }
                }
                string[] scheduleTimerFromArr = scheduleStr.Split('|')[1].Split(',');
                DateTime fromValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                    int.Parse(scheduleTimerFromArr[0]), int.Parse(scheduleTimerFromArr[1]), int.Parse(scheduleTimerFromArr[2]));
                dtpFrom.Value = fromValue;
                string[] scheduleTimerToArr = scheduleStr.Split('|')[2].Split(',');
                DateTime toValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                    int.Parse(scheduleTimerToArr[0]), int.Parse(scheduleTimerToArr[1]), int.Parse(scheduleTimerToArr[2]));
                dtpTo.Value = toValue;
                if (configObl.ReadSetting(Alias.IS_SETTING_INFO_CONFIG) == "1")
                {
                    this._mUpdateInfo = true;
                }
                else
                {
                    this._mUpdateInfo = false;
                }
            }
            catch (Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
            }
        }


        /// <summary>
        /// Check information
        /// </summary>
        /// <returns></returns>
        private Boolean CheckInfo()
        {
            try
            {
                int.Parse(txtInterval.Text);
            }
            catch
            {
                this.ShowMessageBox("ERR002", string.Format(HL7Source.Message.GetMessageById("ERR002")), MessageType.ERROR);
                return false;
            }
            try
            {
                double.Parse(txtTransferSpeed.Text);
            }
            catch
            {
                this.ShowMessageBox("ERR005", string.Format(HL7Source.Message.GetMessageById("ERR005")), MessageType.ERROR);
                return false;
            }
            //NTXUAN: Cap nhat, ko cho bao loi va URL web service, khi update lai setting
            //if (txtURL.Text.Trim() == "")
            //{
            //    this.ShowMessageBox("ERR003", string.Format(HL7Source.Message.GetMessageById("ERR003")), MessageType.ERROR);
            //    return false;
            //}
            if (txtDownloadFolder.Text == "")
            {
                this.ShowMessageBox("ERR004", string.Format(HL7Source.Message.GetMessageById("ERR004")), MessageType.ERROR);
                return false;
            }
            try
            {
                int.Parse(txtNumOfCopies.Text);
            }
            catch
            {
                this.ShowMessageBox("ERR006", string.Format(HL7Source.Message.GetMessageById("ERR006")), MessageType.ERROR);
                return false;
            }
            if (dtpFrom.Value > dtpTo.Value)
            {
                this.ShowMessageBox("ERR008", string.Format(HL7Source.Message.GetMessageById("ERR008")), MessageType.ERROR);
                return false;
            }
            return true;
        }

        private void StartDownloadAndStartSchedule()
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string scheduleStr = configObl.ReadSetting(Alias.SCHEDULE_CONFIG);
            string scheduleDateStr = scheduleStr.Split('|')[0];
            //kiem tra xem ngay hien tai co download ko
            if (scheduleDateStr.Length > 0)
            {
                bool isDayExe = false;
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        if (scheduleDateStr.Contains("MON"))
                            isDayExe = true;
                        break;
                    case DayOfWeek.Tuesday:
                        if (scheduleDateStr.Contains("TUE"))
                            isDayExe = true;
                        break;
                    case DayOfWeek.Wednesday:
                        if (scheduleDateStr.Contains("WED"))
                            isDayExe = true;
                        break;
                    case DayOfWeek.Thursday:
                        if (scheduleDateStr.Contains("THU"))
                            isDayExe = true;
                        break;
                    case DayOfWeek.Friday:
                        if (scheduleDateStr.Contains("FRI"))
                            isDayExe = true;
                        break;
                    case DayOfWeek.Saturday:
                        if (scheduleDateStr.Contains("SAT"))
                            isDayExe = true;
                        break;
                    case DayOfWeek.Sunday:
                        if (scheduleDateStr.Contains("SUN"))
                            isDayExe = true;
                        break;
                    default:
                        break;
                }
                if (isDayExe)
                {
                    //thoi gian bat dau thuc hien
                    string[] scheduleTimerFromArr = scheduleStr.Split('|')[1].Split(',');
                    DateTime dateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                      int.Parse(scheduleTimerFromArr[0]), int.Parse(scheduleTimerFromArr[1]), int.Parse(scheduleTimerFromArr[2]));

                    //thoi gian ket thuc
                    string[] scheduleTimerToArr = scheduleStr.Split('|')[2].Split(',');
                    DateTime dateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                    int.Parse(scheduleTimerToArr[0]), int.Parse(scheduleTimerToArr[1]), int.Parse(scheduleTimerToArr[2]));

                    if (DateTime.Now < dateEnd)
                    {
                        int timeInterval = 0;
                        try
                        {
                            timeInterval = int.Parse(configObl.ReadSetting(Alias.INTERVAL_DOWNLOAD_CONFIG));
                        }
                        catch
                        {
                            timeInterval = 10;
                        }
                        if (timeInterval < 10)
                        {
                            timeInterval = 10;
                        }
                        JobDetail jobDetail = sched.GetJobDetail("ExecuteJob", "Group1");
                        if (DateTime.Now > dateStart)
                        {
                            if (jobDetail == null)
                            {
                                jobDetail = new JobDetail("ExecuteJob", "Group1", typeof(DownloadJob));
                                SimpleTrigger trigger = new SimpleTrigger("ExecuteTrigger", DateTime.UtcNow, dateEnd.ToUniversalTime(), SimpleTrigger.RepeatIndefinitely, TimeSpan.FromSeconds(timeInterval));
                                sched.ScheduleJob(jobDetail, trigger);
                            }
                            else
                            {
                                foreach (Trigger tri in sched.GetTriggersOfJob("ExecuteJob", "Group1"))
                                {
                                    sched.UnscheduleJob(tri.Name, tri.Group);
                                }
                                SimpleTrigger newtrigger = new SimpleTrigger("ExecuteTrigger", "Group1", "ExecuteJob", "Group1", DateTime.UtcNow, dateEnd.ToUniversalTime(), SimpleTrigger.RepeatIndefinitely, TimeSpan.FromSeconds(timeInterval));
                                sched.ScheduleJob(jobDetail, newtrigger);
                            }
                        }
                        else
                        {
                            if (jobDetail == null)
                            {
                                jobDetail = new JobDetail("ExecuteJob", "Group1", typeof(DownloadJob));
                                SimpleTrigger trigger = new SimpleTrigger("ExecuteTrigger", dateStart.ToUniversalTime(), dateEnd.ToUniversalTime(), SimpleTrigger.RepeatIndefinitely, TimeSpan.FromSeconds(timeInterval));
                                sched.ScheduleJob(jobDetail, trigger);
                            }
                            else
                            {
                                foreach (Trigger tri in sched.GetTriggersOfJob("ExecuteJob", "Group1"))
                                {
                                    sched.UnscheduleJob(tri.Name, tri.Group);
                                }
                                SimpleTrigger newtrigger = new SimpleTrigger("ExecuteTrigger", "Group1", "ExecuteJob", "Group1", dateStart.ToUniversalTime(), dateEnd.ToUniversalTime(), SimpleTrigger.RepeatIndefinitely, TimeSpan.FromSeconds(timeInterval));
                                sched.ScheduleJob(jobDetail, newtrigger);
                            }
                        }
                    }
                }
                // Start Schedule
                StartSchedule();
            }
        }

        /// <summary>
        /// Start Schedule
        /// </summary>
        private void StartSchedule()
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string scheduleStr = configObl.ReadSetting(Alias.SCHEDULE_CONFIG);
            string scheduleDateStr = scheduleStr.Split('|')[0];

            //neu co it nhat 1 ngay trong tuan dc chon
            if (scheduleDateStr.Length > 0)
            {
                //thoi gian bat dau thuc hien
                string[] scheduleTimerFromArr = scheduleStr.Split('|')[1].Split(',');
                DateTime dateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                  int.Parse(scheduleTimerFromArr[0]), int.Parse(scheduleTimerFromArr[1]), int.Parse(scheduleTimerFromArr[2]));

                //thoi gian ket thuc
                string[] scheduleTimerToArr = scheduleStr.Split('|')[2].Split(',');
                DateTime dateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                int.Parse(scheduleTimerToArr[0]), int.Parse(scheduleTimerToArr[1]), int.Parse(scheduleTimerToArr[2]));


                int timeInterval = 0;
                try
                {
                    timeInterval = int.Parse(configObl.ReadSetting(Alias.INTERVAL_DOWNLOAD_CONFIG));
                }
                catch
                {
                    timeInterval = 10;
                }
                if (timeInterval < 10)
                {
                    timeInterval = 10;
                }
                //cronExpression ~ thuc hien vao luc 00:00:00 moi nay trong scheduleDateStr
                string cronExpression = string.Format("0 0 0 ? * {0} *", scheduleDateStr);

                JobDetail jobDetail = sched.GetJobDetail("ScheduleJob", "Group1");
                if (jobDetail == null)
                {
                    jobDetail = new JobDetail("ScheduleJob", "Group1", typeof(ScheduleJob));
                    jobDetail.JobDataMap["TimeStart"] = dateStart;
                    jobDetail.JobDataMap["TimeEnd"] = dateEnd;
                    jobDetail.JobDataMap["TimeRepeat"] = timeInterval;
                    CronTrigger trigger = new CronTrigger("SCheduleJobTrigger", "Group1", cronExpression);
                    sched.ScheduleJob(jobDetail, trigger);
                }
                else
                {
                    foreach (Trigger tri in sched.GetTriggersOfJob("ScheduleJob", "Group1"))
                    {
                        sched.UnscheduleJob(tri.Name, tri.Group);
                    }
                    jobDetail.JobDataMap["TimeStart"] = dateStart;
                    jobDetail.JobDataMap["TimeEnd"] = dateEnd;
                    jobDetail.JobDataMap["TimeRepeat"] = timeInterval;
                    CronTrigger newtrigger = new CronTrigger("SCheduleJobTrigger", "Group1", "ScheduleJob", "Group1", cronExpression);
                    sched.ScheduleJob(jobDetail, newtrigger);
                }
            }
        }

        #endregion

        private void timerUploadfileConnect_Tick(object sender, EventArgs e)
        {
            if (!bgwUploadfileConnect.IsBusy)
            {
                bgwUploadfileConnect.RunWorkerAsync();
            }
        }

        private void bgwUploadfileConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            UploadFileConnect();
        }



        /// <summary>
        /// Upload File Connect
        /// </summary>
        private void UploadFileConnect()
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
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
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void setTextNotify()
        {
            _Resource = new HL7Source.Resource();
            notifyIcon1.ShowBalloonTip(100, _Resource.GetResourceByKey("FORM_BASE_KEY", "NOTIFY_TEXT_0001"),
            _Resource.GetResourceByKey("FORM_BASE_KEY", "NOTIFY_TEXT_0002"), ToolTipIcon.Info);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                setTextNotify();
                this.minimizeToolStripMenuItem.Visible = false;
                this.retoreToolStripMenuItem.Visible = true;
                Hide();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                sched.Shutdown();
                if (watcher != null)
                    watcher.Stop();
            }
        }

        private void retoreToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.retoreToolStripMenuItem.Visible = false;
                this.minimizeToolStripMenuItem.Visible = true;
                this.ShowInTaskbar = true;
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.minimizeToolStripMenuItem.Visible = false;
                this.retoreToolStripMenuItem.Visible = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                setTextNotify();
            }
        }

        private void exitToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon1.Dispose();
                this.Close();
                System.Windows.Forms.Application.Exit();
            }
        }
        #region "Start Program"


        public bool ConnectionAvailable(string strServer)
        {

            try
            {

                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);

                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();

                if (HttpStatusCode.OK == rspFP.StatusCode)
                {

                    // HTTP = 200 - Internet connection available, server online

                    rspFP.Close();

                    return true;

                }

                else
                {

                    // Other status - Server or connection not available

                    rspFP.Close();

                    return false;

                }

            }

            catch (WebException)
            {
                // Exception - connection not available

                return false;

            }

        }
        private string isError = STRNOERROR;
        ManagementEventWatcher watcher;
        private void InitToStart(string urltext, string fd, bool bdoc, bool bxls, string printername, object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = (BackgroundWorker)sender;
            try
            {
                bgw.ReportProgress(1, "Checking.........");
                TimeWait(3);
                //kiem tra thong tin nguoi dung

                //kiem tra setting: URL + inbound folder
                bgw.ReportProgress(1, "Checking Webservice URL.....");
                TimeWait(3);
                if (urltext.Equals(string.Empty))
                {
                    //TODO: thong bao loi cho nguoi dung                    
                    ShowMessageBox("MSG_TEXT_ERR002", MessageType.ERROR);
                    e.Result = STRERROR;
                    bgw.ReportProgress(100, STRERROR);
                    return;
                }
                else
                {
                    bgw.ReportProgress(1, "Checking Connection to Webservice URL.....");
                    TimeWait(3);
                    if (ConnectionAvailable(urltext))
                    {
                        bgw.ReportProgress(1, "URL is connected");
                        toolStripStatusLabel_Status.Text = "Connected to " + ExtractDomainName(urltext, true);
                        TimeWait(3);
                    }
                    else
                    {

                        ShowMessageBox("MSG_TEXT_ERR004", MessageType.ERROR);
                        e.Result = STRERROR;
                        bgw.ReportProgress(100, STRERROR);
                        return;
                    }
                    //TODO: kiem tra connect den
                    //neu khong conect duoc, thong bao cho nguoi dung

                }
                bgw.ReportProgress(1, "Checking download folder.....");
                TimeWait(3);
                if (fd.Equals(string.Empty))
                {
                    ShowMessageBox("MSG_TEXT_ERR003", MessageType.ERROR);
                    e.Result = STRERROR;
                    bgw.ReportProgress(100, STRERROR);
                    return;
                }
                //Kiem tra schedule
                //Kiem tra Printing setting                
                bgw.ReportProgress(1, "Checking Printer setting........");
                TimeWait(3);
                if (bdoc || bxls)
                {
                    if (printername.Equals(string.Empty))
                    {
                        ShowMessageBox("MSG_TEXT_ERR005", MessageType.ERROR);
                        e.Result = STRERROR;
                        bgw.ReportProgress(100, STRERROR);
                        return;
                    }
                    PrintClass pr = new PrintClass();
                    if (!pr.IsPrinterOnline(printername))
                    {
                        ShowMessageBox("MSG_TEXT_ERR007", MessageType.WARNING, printername);
                        toolStripStatusLabel_Printer.Text = printername + " : Offline";
                    }
                    else
                        toolStripStatusLabel_Printer.Text = printername + " : Online";
                    //handle printer status
                    ConnectionOptions opt = new ConnectionOptions();

                    //Sets required privilege
                    /////////////////////////////////////////////////////////////
                    opt.EnablePrivileges = true;
                    ManagementScope scope = new ManagementScope("root\\CIMV2", opt);
                    //  string wqlQuery = @"SELECT * FROM __InstanceModificationEvent WITHIN 3 WHERE TargetInstance ISA 'Win32_Printer' AND TargetInstance.Name = '"+printername+"'";

                    WqlEventQuery query = new WqlEventQuery();//wqlQuery);
                    query.EventClassName = "__InstanceModificationEvent";
                    query.WithinInterval = new TimeSpan(0, 0, 1);
                    query.Condition = @"TargetInstance ISA 'Win32_Printer' AND TargetInstance.Name = '" + printername + "'";
                    watcher = new ManagementEventWatcher(scope, query);
                    watcher.EventArrived +=
                    new EventArrivedEventHandler(onEvent);
                    watcher.Start();
                }
                e.Result = STRNOERROR;
                bgw.ReportProgress(100, STRNOERROR);
                return;
            }
            catch (Exception ex)
            {
                e.Result = STRERROR;
                bgw.ReportProgress(100, STRERROR);
                return;
            }

        }
        public void onEvent(object sender, EventArrivedEventArgs e)
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string strprintername = configObl.ReadSetting("PrinterNameDefault");
            PrintClass pr = new PrintClass();
            if (!pr.IsPrinterOnline(strprintername))
            {
                toolStripStatusLabel_Printer.Text = strprintername + " : Offline";
            }
            else
                toolStripStatusLabel_Printer.Text = strprintername + " : Online";
            //watcher.Stop();
        }
        public string ExtractDomainName(string Url, bool isSSL)
        {
            int pos = Url.IndexOf("://");
            if (pos == -1 || pos > 5)
                if (isSSL)
                    Url = "https://" + Url;
                else
                    Url = "http://" + Url;
            return new Uri(Url).Host;
        }

        Waiting waitform = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            waitform = new Waiting("Checking.........");
            waitform.Location = new System.Drawing.Point(this.Location.X + 100, this.Location.Y + 100);
            waitform.Show();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sched.PauseAll();
            timerUploadfileConnect.Enabled = false;
            btnAccept.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            toolStripStatusLabel_StatusApp.Text = "Stopped";
            if (watcher != null)
            {
                watcher.Stop();
            }
        }

        private void TimeWait(int inttime)
        {
            DateTime dt = new DateTime();
            while (dt.AddSeconds(inttime) > DateTime.Now)
            {
            }
        }

        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string strprintername = configObl.ReadSetting("PrinterNameDefault");
            InitToStart(txtURL.Text, txtDownloadFolder.Text, chkDoc.Checked, chkPdf.Checked, strprintername, sender, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!e.UserState.Equals(STRERROR))
            {
                waitform.LBMessage = Convert.ToString(e.UserState);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Result.Equals(STRERROR))
            {
                timerUploadfileConnect.Enabled = true;
                sched.ResumeAll();
                btnAccept.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                StartDownloadAndStartSchedule();
                toolStripStatusLabel_StatusApp.Text = "Started";
                if (watcher != null)
                {
                    watcher.Start();
                }
            }
            else
            {
                btnAccept.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                toolStripStatusLabel_Printer.Text = string.Empty;
                toolStripStatusLabel_Status.Text = string.Empty;
                toolStripStatusLabel_StatusApp.Text = "Can't Start";
            }
            waitform.Close();
        }
    }
}