using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooData.BusinessHandler;
using WahooData.DBO;
using System.Reflection;
using System.Threading;

namespace WahooV2.WahooUserControl
{
    public partial class usMonitor : controlBase
    {
        #region "Contructor & variable"
        private int _mIdClient = -1;
        private List<DownloadReport> lstAll;
        private int iRowofPage = 20;
        private int iAllPage = 1;
        private int iCurrPge = 1;

        public usMonitor()
        {
            InitializeComponent();

        }

        public usMonitor(int idClient)
        {
            InitializeComponent();
            this._mIdClient = idClient;
        }

        public int IdClient
        {
            get { return _mIdClient; }
            set { _mIdClient = value; }
        }

        #endregion

        #region "Methods"
        /// <summary>
        /// get list client set to CBO
        /// </summary>
        private void BindClientCombo()
        {
            Client client = new Client();
            client.Id = -1;
            client.Name = WahooConfiguration.Message.GetMessageById("MONITOR_CBO001");
            List<Client> objClient = new List<Client>();
            objClient.Add(client);
            objClient.AddRange(WahooBusinessHandler.Get_ListClient(new Client()));
            cbClient.DataSource = objClient;
            cbClient.DisplayMember = "name";
            cbClient.ValueMember = "id";
        }

        /// <summary>
        /// get list option set to CBO
        /// </summary>
        private void BindFilterCombo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Value");
            table.Columns.Add("Text");
            DataRow row1 = table.NewRow();
            row1["Value"] = "0";
            row1["Text"] = WahooConfiguration.Message.GetMessageById("MONITOR_CBO001");
            table.Rows.Add(row1);
            DataRow row2 = table.NewRow();
            row2["Value"] = "1";
            row2["Text"] = WahooConfiguration.Message.GetMessageById("MONITOR_CBO002");
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["Value"] = "2";
            row3["Text"] = WahooConfiguration.Message.GetMessageById("MONITOR_CBO003");
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["Value"] = "3";
            row4["Text"] = WahooConfiguration.Message.GetMessageById("MONITOR_CBO004");
            table.Rows.Add(row4);
            cbFilterSearch.DataSource = table;
            cbFilterSearch.DisplayMember = "Text";
            cbFilterSearch.ValueMember = "Value";
        }

        private void ShowResult(int indexRow)
        {
            if (gridReport.RowCount > 0)
            {
                List<DownloadReport> lst = ((List<DownloadReport>)gridReport.DataSource);
                DownloadReport report = lst[indexRow];
                gbResult.Text = report.Filename;
                txtDownloadTime.Text = report.TimeDownloaded.ToString();
                txtDownloadStatus.Text = (report.Success.Equals(true)) ? WahooConfiguration.Message.GetMessageById("MONITOR_Text003") : WahooConfiguration.Message.GetMessageById("MONITOR_Text002");
                txtSentToPrintStatus.Text = (report.IsSentToPrint.Equals(true)) ? WahooConfiguration.Message.GetMessageById("MONITOR_Text003") : WahooConfiguration.Message.GetMessageById("MONITOR_Text002");
                txtSentToPrintTime.Text = report.TimeSentToPrint.ToString();
                txtIpAddress.Text = report.IpAddress.ToString();
            }
            else
            {
                gbResult.Text = string.Empty;
                txtDownloadStatus.Text = string.Empty;
                txtDownloadTime.Text = string.Empty;
                txtSentToPrintStatus.Text = string.Empty;
                txtSentToPrintTime.Text = string.Empty;
                txtIpAddress.Text = string.Empty;
            }
        }

        private List<DownloadReport> getObjList(DownloadReport condition)
        {

            return WahooBusinessHandler.Get_ListDownloadReport(new DownloadReport());

        }

        private void LoadResourceInfo()
        {
            resource = new WahooConfiguration.Resource();
            gbSearchInfo.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "GROUP_NAME");
            chkSearchDate.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "CHECKBOX_NAME");
            label1.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_FILENAME");
            label7.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_FILE");
            label6.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_CLIENT");
            label2.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_DOWNLOADSTATUS");
            label4.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_SENTTOPRINTERSTATUS");
            label8.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_IPADDRESS");
            label3.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_DOWNLOADTIME");
            label5.Text = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "LABEL_NAME_SENDTOPRINTERTIME");
            clIpAddress.HeaderText = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "GRID_COLUMN_IPADDRESS");
            clFilename.HeaderText = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "GRID_COLUMN_FILENAME");
            clSuccess.HeaderText = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "GRID_COLUMN_DOWNLOADED");
            clIsSentToPrint.HeaderText = resource.GetResourceByKey("MONITOR_FORM_CONTROL", "GRID_COLUMN_SENTTOPRINTER");


        }

        private List<DownloadReport> headerChange(int iPageIndex)
        {
            WahooData.DBO.ConditionDR condition = new ConditionDR();

            if (!txtFilename.Text.Equals(string.Empty))
            {
                condition.Filename = txtFilename.Text.ToLower();
            }
            if (WahooConfiguration.DataTypeProtect.ProtectInt32(cbClient.SelectedValue) != -1)
            {
                condition.IdClient = WahooConfiguration.DataTypeProtect.ProtectInt32(cbClient.SelectedValue);
            }
            if (IdClient != -1)
            {
                condition.IdClient = _mIdClient;
            }
            if (cbFilterSearch.SelectedValue != null)
            {
                switch (cbFilterSearch.SelectedValue.ToString())
                {
                    case "1":
                        condition.FileStatus = true;
                        break;
                    case "2":
                        condition.FileStatus = true;
                        break;
                    case "3":
                        condition.FileStatus = false;
                        break;
                    default:
                        break;
                }
            }
            if (chkSearchDate.Checked)
            {
                condition.DateFrom = dptDateFrom.Value;
                condition.DateTo = dptDateTo.Value;
            }
            condition.PageNum = iPageIndex;
            condition.PageSize = iRowofPage;
            int allRow = 0;
            List<DownloadReport> lstTemp = null;
            lstTemp = WahooBusinessHandler.Get_ListDownloadReport(condition, ref allRow);
            iAllPage = getPage(allRow);
            return lstTemp;
        }

        private int getPage(int iAllRow)
        {
            int iPage = 0;
            iPage = (iAllRow % iRowofPage != 0) ? iAllRow / iRowofPage + 1 : iAllRow / iRowofPage;
            return iPage;
        }

        #endregion

        #region "Event"

        /// <summary>
        /// Event for use enable datepicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSearchDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchDate.Checked)
            {
                dptDateFrom.Enabled = true;
                dptDateTo.Enabled = true;
            }
            else
            {
                dptDateFrom.Enabled = false;
                dptDateTo.Enabled = false;
            }
            iCurrPge = 1;
            gridReport.DataSource = headerChange(iCurrPge);
        }
        /// <summary>
        /// xu ly xu kien text thay doi cua textbox file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            iCurrPge = 1;
            gridReport.DataSource = headerChange(iCurrPge);
        }
        /// <summary>
        /// xu ly xu kien value thay doi cua CBO file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            iCurrPge = 1; gridReport.DataSource = headerChange(iCurrPge);
        }
        /// <summary>
        /// xu ly xu kien value thay doi cua CBO file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            iCurrPge = 1; gridReport.DataSource = headerChange(iCurrPge);
        }
        /// <summary>
        /// xu ly xu kien load cua usercontrol 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usMonitor_Load(object sender, EventArgs e)
        {
            gridReport.AutoGenerateColumns = false;
            BindClientCombo();
            BindFilterCombo();
            if (_mIdClient != -1)
            {
                cbClient.SelectedValue = _mIdClient;
                cbClient.Enabled = false;
            }
            //lay tong so dong tren 1 page
            WahooConfiguration.Config cfg = new WahooConfiguration.Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            iRowofPage = WahooConfiguration.DataTypeProtect.ProtectInt32(cfg.ReadSetting("MaxNumberRowofPage"));
            //dung linq truy van du lieu, chi lay page dau tien
            gridReport.DataSource = headerChange(1);
            //set thong tin cho Control page
            if (gridReport.RowCount > 0)
            {
                gridReport.Rows[0].Selected = true;
            }
            ShowResult(0);
            chkSearchDate.Focus();
            cbClient.SelectedIndexChanged += new EventHandler(cbClient_SelectedIndexChanged);
            cbFilterSearch.SelectedIndexChanged += new EventHandler(cbFilterSearch_SelectedIndexChanged);
            txtFilename.TextChanged += new EventHandler(txtFilename_TextChanged);
            this.Disposed += new EventHandler(usMonitor_Disposed);
            gridReport.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(gridReport_DataBindingComplete);
            usPagingBar1.setActiveControl(iAllPage, iCurrPge);
            usPagingBar1.selectedPagebyUser += new usPagingBar.getSelectPagebyUser(usPagingBar1_selectedPagebyUser);
            lbPage.Text = "1/" + iAllPage.ToString();
        }

        void usPagingBar1_selectedPagebyUser(object sender, EventArgs e)
        {
            int select = WahooConfiguration.DataTypeProtect.ProtectInt32(((ToolStripButton)sender).ToolTipText);
            gridReport.DataSource = headerChange(select);
            lbPage.Text = select.ToString() + "/" + iAllPage.ToString();
        }
        /// <summary>
        /// xu ly xu kien data duoc bind den data source cua grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (gridReport.DataSource != null)
            {
                txtTotalFiles.Text = gridReport.Rows.Count.ToString() + " " + WahooConfiguration.Message.GetMessageById("MONITOR_TEXT001");
                //                setcontrolBar(getPage((List<DownloadReport>)gridReport.DataSource), ref iCurrPge);
            }
        }
        /// <summary>
        /// xu ly xu kien value thay doi cua CBO file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usMonitor_Disposed(object sender, EventArgs e)
        {
            cbClient.SelectedIndexChanged -= new EventHandler(cbClient_SelectedIndexChanged);
            cbFilterSearch.SelectedIndexChanged -= new EventHandler(cbFilterSearch_SelectedIndexChanged);
            txtFilename.TextChanged -= new EventHandler(txtFilename_TextChanged);
            gridReport.DataBindingComplete -= new DataGridViewBindingCompleteEventHandler(gridReport_DataBindingComplete);
            chkSearchDate.CheckedChanged -= new EventHandler(chkSearchDate_CheckedChanged);
        }

        private void dptDateFrom_ValueChanged(object sender, EventArgs e)
        {
            iCurrPge = 1; gridReport.DataSource = headerChange(iCurrPge);
        }

        private void dptDateTo_ValueChanged(object sender, EventArgs e)
        {
            iCurrPge = 1; gridReport.DataSource = headerChange(iCurrPge);
        }

        private void gridReport_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ShowResult(e.RowIndex);
        }

        private void usMonitor_ControlAdded(object sender, ControlEventArgs e)
        {
            LoadResourceInfo();
        }

        #endregion

    }
}
