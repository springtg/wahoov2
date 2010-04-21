using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using HL7Source;
using HL7ServerTransfer.Job;
using HL7ServerTransfer.Properties;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using System.Xml;
using Microsoft.Office.Interop.Word;
using Quartz;
using log4net;

namespace HL7ServerTransfer
{
    public partial class frmMain : frmBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Variable for store running program at startup
        RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
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
                _cPrinter = new PrintClass();
                //Load info
                ResetHL7Setup();
                //System.Drawing.Printing.PrintDocument printDoc;
                //printDoc = new System.Drawing.Printing.PrintDocument();                
                //if (printDoc.PrinterSettings.CanDuplex == true)
                //    printDoc.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Vertical;
                //this._mExecuting = false;
                //neu la lan dau tien chay chuong trinh thi ko goi ham StartDownloadAndStartSchedule();
                if(!Settings.Default.boolRunFirstTime)
                    StartDownloadAndStartSchedule();
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
                //if (txtPrintedFormat == "")
                //{
                //    this.ShowMessageBox("ERR007", string.Format(HL7Source.Message.GetMessageById("ERR007")), MessageType.ERROR);
                //    return;
                //}
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
                    ////Write log in Log folder
                    //string logFolder = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                    //if (!Directory.Exists(logFolder))
                    //{
                    //    Directory.CreateDirectory(logFolder);
                    //}
                    ////Write log
                    //Log.Write(ex, logFolder);
                }
                //this.ShowMessageBox("INF001", string.Format(HL7Source.Message.GetMessageById("INF001")), MessageType.INFORM);
                StartDownloadAndStartSchedule();
            }
            catch (Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
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
        /// Change infomations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeInfomationsItem_Click(object sender, EventArgs e)
        {
            frmSettingInfo _mfrmSettingInfo = new frmSettingInfo();
            this.Hide();
            _mfrmSettingInfo.ShowDialog();
            this.Close();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetHL7Setup();
        }

        //private void chkPdf_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
        //    string acrobatFile = configObl.ReadSetting(Alias.ACROBAT_EXE_PATH);
        //    if (chkPdf.Checked)
        //    {
        //        if (!File.Exists(acrobatFile))
        //        {
        //            ChooseAcrobatExe frmChooseAcroExe = new ChooseAcrobatExe();
        //            frmChooseAcroExe.ShowDialog();
        //        }
        //    }
        //}

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
            if (txtURL.Text.Trim() == "")
            {
                this.ShowMessageBox("ERR003", string.Format(HL7Source.Message.GetMessageById("ERR003")), MessageType.ERROR);
                return false;
            }
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
    }
}