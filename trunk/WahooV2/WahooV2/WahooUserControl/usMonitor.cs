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

namespace WahooV2.WahooUserControl
{
    public partial class usMonitor : controlBase
    {
        private int _mIdClient = -1;

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

        private void HeaderChange()
        {
            List<DownloadReport> lst = getObjList(new DownloadReport());//getCondition()); //(List<DownloadReport>)gridReport.DataSource;
            var q = from c in lst select c;
            if (!txtFilename.Text.Equals(string.Empty))
            {
                q = q.Where(c => c.Filename.ToLower().Contains(txtFilename.Text.ToLower()));
            }
            if (WahooConfiguration.DataTypeProtect.ProtectInt32(cbClient.SelectedValue) != -1)
            {
                q = q.Where(c => c.IdClient.Equals(WahooConfiguration.DataTypeProtect.ProtectInt32(cbClient.SelectedValue)));
            }
            switch (cbFilterSearch.SelectedValue.ToString())
            {
                case "1":
                    q = q.Where(c => c.Success.Equals(true) && c.IsSentToPrint.Equals(true));
                    break;
                case "2":
                    q = q.Where(c => c.Success.Equals(true));
                    break;
                case "3":
                    q = q.Where(c => c.Success.Equals(false));
                    break;
                default:
                    break;
            }
            if (chkSearchDate.Checked)
            {
                DateTime dateFrom = dptDateFrom.Value;
                DateTime dateTo = dptDateTo.Value;
                q = q.Where(c => c.TimeDownloaded >= dateFrom && c.TimeDownloaded <= dateTo);
            }
            var rs = q.ToList();
            gridReport.DataSource = rs;
        }

        private List<DownloadReport> getObjList(DownloadReport condition)
        {
            if (this._mIdClient == -1)
            {
                return WahooBusinessHandler.Get_ListDownloadReport(new DownloadReport());
            }
            else
            {
                return WahooBusinessHandler.Get_ListDownloadReport(condition);
            }
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

        public void AutoNumberRowsForGridView(DataGridView dataGridView)
        {

            if (dataGridView != null)
            {
                for (int count = 0; (count <= (dataGridView.Rows.Count - 1)); count++)
                {

                    dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");

                }

            }

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
            HeaderChange();
        }
        /// <summary>
        /// xu ly xu kien text thay doi cua textbox file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
             HeaderChange();
        }
        /// <summary>
        /// xu ly xu kien value thay doi cua CBO file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
             HeaderChange();
        }
        /// <summary>
        /// xu ly xu kien value thay doi cua CBO file name va filter du lieu theo gia tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            HeaderChange();
        }
        /// <summary>
        /// xu ly xu kien load cua usercontrol 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usMonitor_Load(object sender, EventArgs e)
        {
            gridReport.AutoGenerateColumns = false;
            gridReport.DataSource = getObjList(new DownloadReport());
            if (gridReport.RowCount > 0)
            {
                gridReport.Rows[0].Selected = true;
            }
            ShowResult(0);
            BindClientCombo();
            BindFilterCombo();
            chkSearchDate.Focus();
            cbClient.SelectedIndexChanged += new EventHandler(cbClient_SelectedIndexChanged);
            cbFilterSearch.SelectedIndexChanged += new EventHandler(cbFilterSearch_SelectedIndexChanged);
            txtFilename.TextChanged += new EventHandler(txtFilename_TextChanged);
            this.Disposed += new EventHandler(usMonitor_Disposed);
            gridReport.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(gridReport_DataBindingComplete);
            if (_mIdClient != -1)
            {
                cbClient.SelectedValue = _mIdClient;
                cbClient.Enabled = false;
            }            
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
            HeaderChange();
        }

        private void dptDateTo_ValueChanged(object sender, EventArgs e)
        {
            HeaderChange();
        }

        private void gridReport_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ShowResult(e.RowIndex);
        }

        private void usMonitor_ControlAdded(object sender, ControlEventArgs e)
        {
            LoadResourceInfo();
        }

        private void gridReport_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AutoNumberRowsForGridView((DataGridView)sender);
        }

        #endregion

    }
}
