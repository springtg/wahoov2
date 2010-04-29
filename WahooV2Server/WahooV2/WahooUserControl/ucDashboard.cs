using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooData.DBO;
using WahooConfiguration;
using WahooData.BusinessHandler;
using log4net;

namespace WahooV2.WahooUserControl
{
    public partial class ucDashboard : controlBase
    {
        #region "Xu ly vailidate Image"
        //dieu khien su thay doi image tren grid
        private int _CurrentStep = 0;
        private int _StepCount = 5;
        private int _CurRow = -1;
        //delegate of process() function for the purpose of multithreading
        delegate void ProcessDelegate();
        #endregion

        #region variable
        Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //DataTable _mDashboard to store list of dashboard( bind with grid)
        private DataTable _mDashboard = new DataTable();
        //List of history info( bind with history grid)
        private DataTable _mHistoryData = new DataTable();
        //Check is refreshing grid data
        private Boolean _mRefresh = false;

        //Declare delegate for gird cell selected index change
        public delegate void GridDashboard_SelectionChanged(object sender, EventArgs e);
        public event GridDashboard_SelectionChanged GridSelectionChanged;

        //Declare delegate for click out of gird
        public delegate void GridDashboard_MouseDown(object sender, MouseEventArgs e);
        public event GridDashboard_MouseDown GridMouseDown;

        //Variable lc to check dashboard is loading(even selection index change is block)
        private int _mCheckLoad = 0;
        public int CheckLoad
        {
            get { return _mCheckLoad; }
            set { _mCheckLoad = value; }
        }
        //IdDashboard
        private int _mIdDashboard = 0;

        public int IdDashboard
        {
            get { return _mIdDashboard; }
            set { _mIdDashboard = value; }
        }
        //Dashboard status( Stop, pause or start)
        private string _mDashboardStatus = "-1";

        public string DashboardStatus
        {
            get { return _mDashboardStatus; }
            set { _mDashboardStatus = value; }
        }

        #endregion variable

        public ucDashboard()
        {
            InitializeComponent();
        }

        #region event

        /// <summary>
        /// Click start all channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startAllChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StartAllChannel();
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("ERR013", string.Format(WahooConfiguration.Message.GetMessageById("ERR013")), MessageType.ERROR);
            }
        }

        /// <summary>
        /// Click stop all channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopAllChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StopAllChannel();
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("ERR013", string.Format(WahooConfiguration.Message.GetMessageById("ERR013")), MessageType.ERROR);
            }
        }

        /// <summary>
        /// Click pause channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PauseChannel();
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("ERR013", string.Format(WahooConfiguration.Message.GetMessageById("ERR013")), MessageType.ERROR);
            }
        }

        /// <summary>
        /// Click stop channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StopChannel();
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("ERR013", string.Format(WahooConfiguration.Message.GetMessageById("ERR013")), MessageType.ERROR);
            }
        }

        /// <summary>
        /// Load Dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDashboard_Load(object sender, EventArgs e)
        {
            LoadValueControl();
            BindGrid();
            //gridDashboard.DataSource = WahooBusinessHandler.Get_ListChannel(new Channel());
            ////Set timer interval for timerRefresh
            //int temp = int.Parse(configObl.ReadSetting(AliasMessage.DASHBOARD_INTERVAL_CONFIG));
            //if (temp < 20)
            //{
            //    temp = 20;
            //}
            //this.timerRefresh.Interval = temp * 1000;
            ////Set info for controls 
            //string pauseLog = configObl.ReadSetting(AliasMessage.PAUSE_LOG_CONFIG);
            //if (pauseLog == "0")
            //{
            //    lblPause.ImageIndex = 2;
            //}
            //else
            //{
            //    lblPause.ImageIndex = 3;
            //}
            this.pictureBox1.Image = global::WahooV2.Properties.Resources.Connecting;
            this.pictureBox2.Image = global::WahooV2.Properties.Resources.Disconnet;
            this._mCheckLoad = 1;
            //NTXUAN: add for tab email notification: 27_04_2010
            loadEmailServerSetting();
            dataGridView1.DataSource = loadEmailList();
            loadMessageInfo();
            timerClientDisconnected.Start();
        }

        /// <summary>
        /// Selected index change in dashboard grid data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridDashboard_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridSelectionChanged != null)
                {
                    if (_mCheckLoad == 0)
                    {
                        return;
                    }
                    //Show history data follow selected dashboard
                    if (gridDashboard.SelectedRows.Count > 0)
                    {
                        this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                        this._mDashboardStatus = gridDashboard.SelectedRows[0].Cells[this.clStatusExecute.Name].Value.ToString();
                        gridHistAllLog.DataSource = new DataView(this._mHistoryData);
                        ((DataView)gridHistAllLog.DataSource).RowFilter = "IDCHANNEL=" + this._mIdDashboard.ToString();
                        ((DataView)gridHistAllLog.DataSource).Sort = "ID DESC";

                        //Bind so dong vao GridView theo Log_Size.
                        gridHistAllLog.DataSource = GetTopDataViewRows((DataView)gridHistAllLog.DataSource, DataTypeProtect.ProtectInt32(configObl.ReadSetting(AliasMessage.Log_Size), 0));

                        gridErrorLog.DataSource = new DataView(this._mHistoryData);
                        ((DataView)gridErrorLog.DataSource).RowFilter = "IDCHANNEL=" + this._mIdDashboard.ToString() + " AND STATUS='" + AliasMessage.FAILED_STATUS + "'";
                        ((DataView)gridErrorLog.DataSource).Sort = "ID DESC";

                        //Bind so dong vao GridView theo Log_Size.
                        gridErrorLog.DataSource = GetTopDataViewRows((DataView)gridErrorLog.DataSource, DataTypeProtect.ProtectInt32(configObl.ReadSetting(AliasMessage.Log_Size), 0));
                    }
                    else
                    {
                        this._mIdDashboard = 0;
                        this._mDashboardStatus = "";
                    }
                    GridSelectionChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Click left mouse or right mouse in(out) grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridDashboard_MouseDown(object sender, MouseEventArgs e)
        {
            if (GridMouseDown != null)
            {
                DataGridView.HitTestInfo hti = gridDashboard.HitTest(e.X, e.Y);
                //Click left mouse
                if (e.Button == MouseButtons.Left)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //Click out grid
                        if (hti.RowIndex == -1)
                        {
                            this._mIdDashboard = 0;
                            gridDashboard.ClearSelection();
                            ClearLog();
                        }
                        //Click in grid
                        else
                        {
                            this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.Rows[hti.RowIndex].Cells[this.clId.Name].Value.ToString(), 0);
                            this._mDashboardStatus = gridDashboard.Rows[hti.RowIndex].Cells[this.clStatusExecute.Name].Value.ToString();
                        }
                    }
                }
                //Click right mouse
                if (e.Button == MouseButtons.Right)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //Click out grid->how to show controls
                        if (hti.RowIndex == -1)
                        {
                            pauseChannelToolStripMenuItem.Visible = false;
                            stopChannelToolStripMenuItem.Visible = false;
                            this._mIdDashboard = 0;
                            gridDashboard.ClearSelection();
                            ClearLog();
                        }
                        //Click in grid
                        else
                        {
                            gridDashboard.Rows[hti.RowIndex].Selected = true;
                            string status = gridDashboard.Rows[hti.RowIndex].Cells[this.clStatusExecute.Name].Value.ToString().ToUpper();
                            //When channel is started-> show pause channel button
                            if (status == AliasMessage.STARTED_STATUS)
                            {
                                pauseChannelToolStripMenuItem.Text = AliasMessage.PAUSE_CHANNEL_CONTROL;
                                this.pauseChannelToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_pause;
                                stopChannelToolStripMenuItem.Visible = true;
                            }
                            //When channel is paused-> show start channel button
                            else if (status == AliasMessage.PAUSED_STATUS)
                            {
                                pauseChannelToolStripMenuItem.Text = AliasMessage.START_CHANNEL_CONTROL;
                                this.pauseChannelToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_start;
                                stopChannelToolStripMenuItem.Visible = true;
                            }
                            //When channel is stoped-> show start channel button and disable stop button
                            else if (status == AliasMessage.STOPPED_STATUS)
                            {
                                pauseChannelToolStripMenuItem.Text = AliasMessage.START_CHANNEL_CONTROL;
                                this.pauseChannelToolStripMenuItem.Image = global::WahooV2.Properties.Resources.wh_start;
                                stopChannelToolStripMenuItem.Visible = false;
                            }
                            else
                            {
                            }
                            pauseChannelToolStripMenuItem.Visible = true;
                            this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.Rows[hti.RowIndex].Cells[this.clId.Name].Value.ToString(), 0);
                            this._mDashboardStatus = gridDashboard.Rows[hti.RowIndex].Cells[this.clStatusExecute.Name].Value.ToString();
                        }
                    }
                }
                GridMouseDown(sender, e);
            }
        }

        #endregion event

        #region function

        private DataView GetTopDataViewRows(DataView dv, int n)
        {
            DataTable dt = dv.Table.Clone();

            for (int i = 0; i < n; i++)
            {
                if (i >= dv.Count)
                {
                    break;
                }
                dt.ImportRow(dv[i].Row);
            }
            return new DataView(dt, dv.RowFilter, dv.Sort, dv.RowStateFilter);
        }

        /// <summary>
        /// Pause channel
        /// </summary>
        /// <returns></returns>
        public string PauseChannel()
        {
            if (gridDashboard.SelectedRows.Count == 0)
            {
                return "";
            }
            string kq = "";
            try
            {
                Channel objChannel = new Channel();
                this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                objChannel.Id = this._mIdDashboard;
                objChannel = WahooBusinessHandler.Get_Channel(objChannel);
                string statusExecute = gridDashboard.SelectedRows[0].Cells[this.clStatusExecute.Name].Value.ToString();
                DataRow[] rows = _mDashboard.Select("Id=" + this._mIdDashboard.ToString());
                if (statusExecute != AliasMessage.STARTED_STATUS)
                {
                    objChannel.StatusExecute = AliasMessage.STARTED_STATUS;
                    objChannel.Update();
                    rows[0]["STATUSEXECUTE"] = AliasMessage.STARTED_STATUS;
                    kq = AliasMessage.PAUSE_CHANNEL_CONTROL;
                }
                else
                {
                    objChannel.StatusExecute = AliasMessage.PAUSED_STATUS;
                    objChannel.Update();
                    rows[0]["STATUSEXECUTE"] = AliasMessage.PAUSED_STATUS;
                    kq = AliasMessage.START_CHANNEL_CONTROL;
                }
                return kq;
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                throw ex;
            }

        }

        /// <summary>
        /// Stop channel
        /// </summary>
        /// <returns></returns>
        public void StopChannel()
        {
            if (gridDashboard.SelectedRows.Count == 0)
            {
                return;
            }
            string statusExecute = gridDashboard.SelectedRows[0].Cells[this.clStatusExecute.Name].Value.ToString();
            if (statusExecute == AliasMessage.STOPPED_STATUS)
            {
                return;
            }
            try
            {
                this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                Channel objChannel = new Channel();
                this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                objChannel.Id = this._mIdDashboard;
                objChannel = WahooBusinessHandler.Get_Channel(objChannel);
                DataRow[] rows = _mDashboard.Select("Id=" + this._mIdDashboard.ToString());
                objChannel.StatusExecute = AliasMessage.STOPPED_STATUS;
                objChannel.Update();
                rows[0]["STATUSEXECUTE"] = AliasMessage.STOPPED_STATUS;

            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                throw ex;
            }

        }

        /// <summary>
        /// Stop all channel
        /// </summary>
        public void StopAllChannel()
        {
            try
            {
                WahooBusinessHandler.UpdateAllChannelStatusExecute(AliasMessage.STOPPED_STATUS);
                foreach (DataRow row in this._mDashboard.Rows)
                {
                    if (row["STATUSEXECUTE"].ToString().ToUpper() != AliasMessage.STOPPED_STATUS)
                    {
                        row["STATUSEXECUTE"] = AliasMessage.STOPPED_STATUS;
                    }
                }
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Start all channel
        /// </summary>
        public void StartAllChannel()
        {
            try
            {
                WahooBusinessHandler.UpdateAllChannelStatusExecute(AliasMessage.STARTED_STATUS);
                foreach (DataRow row in this._mDashboard.Rows)
                {
                    if (row["STATUSEXECUTE"].ToString().ToUpper() != AliasMessage.STARTED_STATUS)
                    {
                        row["STATUSEXECUTE"] = AliasMessage.STARTED_STATUS;
                    }
                }
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Clear log when click out of grid
        /// </summary>
        private void ClearLog()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("Description", Type.GetType("System.String"));
                table.Columns.Add("IdChannel", Type.GetType("System.String"));
                table.Columns.Add("Status", Type.GetType("System.String"));
                table.Columns.Add("Id", Type.GetType("System.Int32"));
                gridHistAllLog.DataSource = table;
                gridErrorLog.DataSource = table;
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                this.ShowMessageBox("ERR013", string.Format(WahooConfiguration.Message.GetMessageById("ERR013")), MessageType.ERROR);
            }
        }

        /// <summary>
        /// Bind grid channel
        /// </summary>
        private void BindGrid()
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                Channel objChannelSearch = new Channel();
                objChannelSearch.Active = true;
                objChannelSearch.IsDeployed = true;
                List<Channel> objListChannel = WahooBusinessHandler.Get_ListChannel(objChannelSearch);
                CreateDatabaseDashboard(objListChannel);
                //Get list of dashboard
                gridDashboard.DataSource = new DataView(_mDashboard);
                List<HistoryOfChannel> objListHistoryOfChannel = WahooBusinessHandler.Get_ListHistoryOfChannel(new HistoryOfChannel());
                //Get list history data info
                CreateHistoryOfChannel(objListHistoryOfChannel);
                //When have data
                if (gridDashboard.SelectedRows.Count > 0)
                {
                    this._mIdDashboard = DataTypeProtect.ProtectInt32(gridDashboard.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                    gridHistAllLog.DataSource = new DataView(this._mHistoryData);
                    ((DataView)gridHistAllLog.DataSource).RowFilter = "IDCHANNEL=" + this._mIdDashboard.ToString();
                    ((DataView)gridHistAllLog.DataSource).Sort = "ID DESC";
                    //Bind so dong vao GridView theo Log_Size.
                    gridHistAllLog.DataSource = GetTopDataViewRows((DataView)gridHistAllLog.DataSource, DataTypeProtect.ProtectInt32(configObl.ReadSetting(AliasMessage.Log_Size), 0));

                    gridErrorLog.DataSource = new DataView(this._mHistoryData);
                    ((DataView)gridErrorLog.DataSource).RowFilter = "IDCHANNEL=" + this._mIdDashboard.ToString() + " AND STATUS='" + AliasMessage.FAILED_STATUS + "'";
                    ((DataView)gridErrorLog.DataSource).Sort = "ID DESC";
                    //Bind so dong vao GridView theo Log_Size.
                    gridErrorLog.DataSource = GetTopDataViewRows((DataView)gridErrorLog.DataSource, DataTypeProtect.ProtectInt32(configObl.ReadSetting(AliasMessage.Log_Size), 0));

                    //Get DashboardStatus
                    this._mDashboardStatus = gridDashboard.SelectedRows[0].Cells[this.clStatusExecute.Name].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadValueControl()
        {
            if (DataTypeProtect.ProtectString(configObl.ReadSetting(AliasMessage.PAUSE_LOG_CONFIG)) == "0")
            {
                btnPause.Tag = "0";
                btnPause.Image = global::WahooV2.Properties.Resources.wh_pause;
            }
            else
            {
                btnPause.Tag = "1";
                btnPause.Image = global::WahooV2.Properties.Resources.wh_start;
            }
            txtLogSize.Text = DataTypeProtect.ProtectString(configObl.ReadSetting(AliasMessage.Log_Size));
        }

        private void CreateDatabaseDashboard(List<Channel> objListChannel)
        {
            _mDashboard = new DataTable();
            _mDashboard.Columns.Add("ID", System.Type.GetType("System.Int32"));
            _mDashboard.Columns.Add("IDCLIENT", System.Type.GetType("System.Int32"));
            _mDashboard.Columns.Add("CHANNELNAME", System.Type.GetType("System.String"));
            _mDashboard.Columns.Add("DESCRIPTION", System.Type.GetType("System.String"));
            _mDashboard.Columns.Add("STATUSEXECUTE", System.Type.GetType("System.String"));
            _mDashboard.Columns.Add("SENT", System.Type.GetType("System.Decimal"));
            _mDashboard.Columns.Add("ERROR", System.Type.GetType("System.Decimal"));
            _mDashboard.Columns.Add("Img", typeof(Image));
            _mDashboard.Columns.Add("ISCONNECTED", System.Type.GetType("System.Boolean"));
            _mDashboard.Rows.Clear();
            foreach (Channel obj in objListChannel)
            {
                DataRow newRow = _mDashboard.NewRow();
                newRow["ID"] = obj.Id;
                newRow["IDCLIENT"] = obj.IdClient;
                newRow["CHANNELNAME"] = obj.ChannelName;
                newRow["DESCRIPTION"] = obj.Description;
                newRow["STATUSEXECUTE"] = obj.StatusExecute;
                newRow["SENT"] = obj.Sent;
                newRow["ERROR"] = obj.Error;
                newRow["Img"] = (obj.IsConnected == true) ? global::WahooV2.Properties.Resources.Connecting : global::WahooV2.Properties.Resources.Disconnet;
                newRow["ISCONNECTED"] = obj.IsConnected;
                _mDashboard.Rows.Add(newRow);
            }
            //pictureBox1.Image = global::WahooV2.Properties.Resources.disconect;       
        }

        private void CreateHistoryOfChannel(List<HistoryOfChannel> objListHistoryOfChannel)
        {
            _mHistoryData = new DataTable();
            _mHistoryData.Columns.Add("ID", System.Type.GetType("System.Int32"));
            _mHistoryData.Columns.Add("IDCHANNEL", System.Type.GetType("System.Int32"));
            _mHistoryData.Columns.Add("DESCRIPTION", System.Type.GetType("System.String"));
            _mHistoryData.Columns.Add("STATUS", System.Type.GetType("System.String"));
            _mHistoryData.Rows.Clear();
            foreach (HistoryOfChannel obj in objListHistoryOfChannel)
            {
                DataRow newRow = _mHistoryData.NewRow();
                newRow["ID"] = obj.Id;
                newRow["IDCHANNEL"] = obj.IdChannel;
                newRow["DESCRIPTION"] = obj.Description;
                newRow["STATUS"] = obj.Status;
                _mHistoryData.Rows.Add(newRow);
            }
        }
        #endregion function

        private void timerRefresh_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int temp = 0;
            try
            {

                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                temp = int.Parse(configObl.ReadSetting(AliasMessage.DASHBOARD_INTERVAL_CONFIG));
                BindGrid();
            }
            catch (Exception ex)
            {
                temp = 0;
                throw ex;
            }
            if (temp < 10)
            {
                temp = 10;
            }
            temp = temp * 1000;
            //Check timer interval for refresh timer( change when timer interval is changed)
            if (this.timerRefresh.Interval != temp)
            {
                this.timerRefresh.Stop();
                this.timerRefresh.Interval = temp;
                this.timerRefresh.Start();

            }
            // 

        }

        private void tmPicture_Tick(object sender, EventArgs e)
        {

            if (this.gridDashboard.Rows.Count > 0)
            {

                ReplayImage(true, this.pictureBox1.Image, this.pictureBox2.Image, gridDashboard, 5);
            }

        }
        /// <summary>
        /// chang image theo thoi gian, va validate cell hien hanh
        /// </summary>
        /// <param name="bImage1"></param>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <param name="dgv"></param>
        /// <param name="iRow"></param>
        /// <param name="iColumn"></param>
        private void ReplayImage(bool bImage1, Image img1, Image img2, DataGridView dgv, int iColumn)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                bImage1 = WahooConfiguration.DataTypeProtect.ProtectBoolean(dgv.Rows[i].Cells[clIsConnected.Name].Value, false);
                if (bImage1)
                {
                    dgv.Rows[i].Cells[7].Value = img1;
                    dgv.InvalidateCell(7, i);
                }
                else
                {
                    dgv.Rows[i].Cells[7].Value = img2;
                    dgv.InvalidateCell(7, i);
                }


            }
        }

        private void Process()
        {
            do
            {
                //record the time when current step begins to process
                this._CurrentStep++;
                Random rndIntValue = new Random();
                //let current process sleep for several seconds
                //it is only for the purpose of a demo
                //in a real scenario, it is not necessary for current step itself may take several seconds or more to finish processing
                System.Threading.Thread.Sleep(rndIntValue.Next(8) * 1000);
                if (this._CurrentStep >= this._StepCount)
                {
                    _CurrentStep = 0;
                    rndIntValue = new Random();
                }
            }
            while (this._CurrentStep < this._StepCount);

        }

        ProcessDelegate pdSteps = null;
        private void gridDashboard_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (gridDashboard.RowCount > 0)
            {
                _CurrentStep = 0;
                if (pdSteps == null)
                {
                    tmPicture.Start();
                    pdSteps = new ProcessDelegate(Process);
                    pdSteps.BeginInvoke(null, null);
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (DataTypeProtect.ProtectString(btnPause.Tag) == "0")
            {
                configObl.WriteSetting(AliasMessage.PAUSE_LOG_CONFIG, "1");
                btnPause.Tag = "1";
                btnPause.Image = global::WahooV2.Properties.Resources.wh_start;
            }
            else
            {
                configObl.WriteSetting(AliasMessage.PAUSE_LOG_CONFIG, "0");
                btnPause.Tag = "0";
                btnPause.Image = global::WahooV2.Properties.Resources.wh_pause;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear data historyofchannel of selected channel
            if (gridDashboard.SelectedRows.Count > 0)
            {
                WahooBusinessHandler.DeleteHistoryOfChannel(DataTypeProtect.ProtectInt32(gridDashboard.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0));
                ClearLog();
                //Lay lai objListHistoryOfChannel sau khi da xoa HistoryOfChannel
                List<HistoryOfChannel> objListHistoryOfChannel = WahooBusinessHandler.Get_ListHistoryOfChannel(new HistoryOfChannel());
                //Get list history data info
                CreateHistoryOfChannel(objListHistoryOfChannel);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configObl.WriteSetting(AliasMessage.Log_Size, txtLogSize.Text);

            gridHistAllLog.DataSource = new DataView(this._mHistoryData);
            ((DataView)gridHistAllLog.DataSource).RowFilter = "IDCHANNEL=" + this._mIdDashboard.ToString();
            ((DataView)gridHistAllLog.DataSource).Sort = "ID DESC";
            //Bind so dong vao GridView theo Log_Size.
            gridHistAllLog.DataSource = GetTopDataViewRows((DataView)gridHistAllLog.DataSource, DataTypeProtect.ProtectInt32(configObl.ReadSetting(AliasMessage.Log_Size), 0));

            gridErrorLog.DataSource = new DataView(this._mHistoryData);
            ((DataView)gridErrorLog.DataSource).RowFilter = "IDCHANNEL=" + this._mIdDashboard.ToString() + " AND STATUS='" + AliasMessage.FAILED_STATUS + "'";
            ((DataView)gridErrorLog.DataSource).Sort = "ID DESC";
            //Bind so dong vao GridView theo Log_Size.
            gridErrorLog.DataSource = GetTopDataViewRows((DataView)gridErrorLog.DataSource, DataTypeProtect.ProtectInt32(configObl.ReadSetting(AliasMessage.Log_Size), 0));
        }


        //NTXUAN: ADD: 27_04_2010
        #region "Email Notification"
        /// <summary>
        /// string path of config file
        /// </summary>
        string strConfigPath = System.Reflection.Assembly.GetEntryAssembly().Location + ".config";
        /// <summary>
        /// function to load information for Email setting tab from config file
        /// </summary>
        private void loadEmailServerSetting()
        {
            try
            {
                txtServerPort.TextAlign = HorizontalAlignment.Left;
                txtServerPort.BNull = true;
                configObl = new Config(strConfigPath);
                txtEmailServer.Text = configObl.ReadSetting("EmailServer");
                txtServerPort.Text = configObl.ReadSetting("ServerPort");
                txtUsername.Text = configObl.ReadSetting("UserName");
                txtPassword.Text = configObl.ReadSetting("Password");
            }
            catch
            {
                txtEmailServer.Text = string.Empty;
                txtServerPort.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }
        /// <summary>
        /// save info from tab to config file
        /// </summary>
        /// <returns></returns>
        private bool saveEmailServerSetting()
        {
            try
            {
                configObl = new Config(strConfigPath);
                configObl.WriteSetting("EmailServer", txtEmailServer.Text.Trim());
                configObl.WriteSetting("ServerPort", txtServerPort.Text.Trim());
                configObl.WriteSetting("UserName", txtUsername.Text.Trim());
                configObl.WriteSetting("Password", txtPassword.Text.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// button excute action save info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmailServerSettingSave_Click(object sender, EventArgs e)
        {
            if (saveEmailServerSetting())
            {
                ShowMessageBox("DASHBOARD_INF001", MessageType.INFORM);
            }
            else
            {
                ShowMessageBox("DASHBOARD_ERR001", MessageType.ERROR);
            }
        }
        /// <summary>
        /// Load danh sach mail list
        /// </summary>
        /// <returns></returns>
        private DataTable loadEmailList()
        {
            dataGridView1.AutoGenerateColumns = false;
            return WahooData.DBO.Base.ServiceReader.EmailNotification_Select();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataTable tb = (DataTable)((DataGridView)sender).DataSource;
            if (tb == null)
            {
                return;
            }
            if (tb.Rows.Count < 1)
            {
                return;
            }
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (isNewRow(tb.Rows[i]))
                {
                    string strDisplayName = WahooConfiguration.DataTypeProtect.ProtectString(tb.Rows[i]["DisplayName"]).Trim();
                    string strEmail = WahooConfiguration.DataTypeProtect.ProtectString(tb.Rows[i]["Email"]).Trim();
                    if (WahooData.DBO.Base.ServiceReader.EmailNotification_Insert(strDisplayName, strEmail))
                    {
                        dataGridView1.DataSource = loadEmailList();
                    }
                }
                if (isModified(tb.Rows[i]))
                {
                    int iId = WahooConfiguration.DataTypeProtect.ProtectInt32(tb.Rows[i]["ID"]);
                    string strDisplayName = WahooConfiguration.DataTypeProtect.ProtectString(tb.Rows[i]["DisplayName"]).Trim();
                    string strEmail = WahooConfiguration.DataTypeProtect.ProtectString(tb.Rows[i]["Email"]).Trim();
                    if (WahooData.DBO.Base.ServiceReader.EmailNotification_Update(iId, strDisplayName, strEmail))
                    {
                        dataGridView1.DataSource = loadEmailList();
                    }
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (((DataGridView)sender).CurrentRow.IsNewRow)
            {
                return;
            }

            if (e.ColumnIndex == 1)
            {
                if (!WahooConfiguration.DataTypeProtect.ProtectString(e.FormattedValue).Trim().Equals(string.Empty))
                {
                    if (!EmailValid(WahooConfiguration.DataTypeProtect.ProtectString(e.FormattedValue).Trim()))
                    {
                        e.Cancel = true;
                        ShowMessageBox("DASHBOARD_ERR002", MessageType.ERROR);
                    }
                }
                else
                {
                    e.Cancel = true;
                    ShowMessageBox("DASHBOARD_ERR003", MessageType.ERROR);
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                string Name = WahooConfiguration.DataTypeProtect.ProtectString(e.Row.Cells[0].Value);
                string Email = WahooConfiguration.DataTypeProtect.ProtectString(e.Row.Cells[1].Value);
                object[] obj = new object[2];
                obj[0] = Name;
                obj[1] = Email;
                if (ShowMessageBox("DASHBOARD_CFM001", MessageType.CONFIRM, obj) == DialogResult.No)// ("Are you sure you want to delete this row?", "Delete confirmation");
                {
                    e.Cancel = true;
                }
                else
                {
                    DataTable tb = ((DataTable)((DataGridView)sender).DataSource);
                    if (tb == null)
                    {
                        return;
                    }
                    if (tb.Rows.Count < 1)
                    {
                        return;
                    }
                    int id = WahooConfiguration.DataTypeProtect.ProtectInt32(tb.Rows[e.Row.Index]["ID"]);
                    if (WahooData.DBO.Base.ServiceReader.EmailNotification_Delete(id))
                    {
                        dataGridView1.DataSource = loadEmailList();
                    }
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                dataGridView1_UserDeletingRow(sender, new DataGridViewRowCancelEventArgs(dataGridView1.CurrentRow));
            }
        }
        /// <summary>
        /// load thong tin email info from config
        /// </summary>
        private void loadMessageInfo()
        {
            configObl = new Config(strConfigPath);
            txtMailSubject.Text = configObl.ReadSetting("MailSubject");
            txtMailBody.Text = configObl.ReadSetting("MailBody");
        }
        /// <summary>
        /// cap nhat thong tin cho message info
        /// </summary>
        /// <param name="strSubject"></param>
        /// <param name="strBody"></param>
        /// <returns></returns>
        private bool updateMessageInfo(string strSubject, string strBody)
        {
            try
            {
                configObl = new Config(strConfigPath);
                configObl.WriteSetting("MailSubject", strSubject);
                configObl.WriteSetting("MailBody", strBody);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            if (updateMessageInfo(txtMailSubject.Text, txtMailBody.Text))
            {
                ShowMessageBox("DASHBOARD_INF002", MessageType.INFORM);
                loadMessageInfo();
            }
            else
                ShowMessageBox("DASHBOARD_ERR004", MessageType.ERROR);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadMessageInfo();
        }

        private bool sendMailtoList(DataTable tbClient)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb != null)
                {
                    //chuan bi thong tin server
                    configObl = new Config(strConfigPath);
                    string mailServer = configObl.ReadSetting("EmailServer");
                    int mailport = WahooConfiguration.DataTypeProtect.ProtectInt32(configObl.ReadSetting("ServerPort"));
                    string mailusername = configObl.ReadSetting("UserName");
                    string mailpassword = configObl.ReadSetting("Password");
                    string mailSubject = configObl.ReadSetting("MailSubject");
                    string mailbody = configObl.ReadSetting("MailBody");

                    string strClientList = string.Empty;
                    int iCont = tbClient.Rows.Count;

                    strClientList = "<table style='width: 600px;'>";
                    strClientList += "<tr style='background-color: #FF6699'>";
                    strClientList += "<td style='width: 86px'>";
                    strClientList += "Client Code";
                    strClientList += "</td>";
                    strClientList += "<td style='width: 130px'>";
                    strClientList += "Client Name";
                    strClientList += "</td>";
                    strClientList += "<td style='width: 127px'>";
                    strClientList += "Channel Name";
                    strClientList += "</td>";
                    strClientList += "<td>";
                    strClientList += "Date";
                    strClientList += "</td>";
                    strClientList += "</tr>";
                    for (int i = 0; i < iCont; i++)
                    {
                        if (i % 2 == 0)
                            strClientList += "<tr style='background-color: #FFCCFF'>";
                        else
                            strClientList += "<tr style='background-color: #ffffee'>";
                        strClientList += "<td style='width: 86px'>" + WahooConfiguration.DataTypeProtect.ProtectString(tbClient.Rows[i]["IdClient"]) + "</td>";
                        strClientList += "<td style='width: 130px'>" + WahooConfiguration.DataTypeProtect.ProtectString(tbClient.Rows[i]["Name"]) + "</td>";
                        strClientList += "<td style='width: 127px'>" + WahooConfiguration.DataTypeProtect.ProtectString(tbClient.Rows[i]["ChannelName"]) + "</td>";
                        strClientList += "<td>" + WahooConfiguration.DataTypeProtect.ProtectString(tbClient.Rows[i]["DateLastDisconnect"]) + "</td>";
                        strClientList += "</tr>";
                    }
                    strClientList += "</table>";
                    mailbody = "<table style='width: 600px;'><tr><td>" + mailbody.Replace("[ClientList]", "</td></tr><tr><td>" + strClientList + "</td></tr><tr><td>") + "</td></tr></table>";
                    //chuan bi mail list
                    string mailTo = string.Empty;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        mailTo = mailTo + WahooConfiguration.DataTypeProtect.ProtectString(tb.Rows[i]["Email"]).Trim() + ",";
                    }
                    WahooV2.Common.CMailSmtp mail = new WahooV2.Common.CMailSmtp();
                    mail.MailTo = mailTo;
                    mail.MailSubject = mailSubject;
                    mail.MailFrom = mailusername;
                    mail.SMTPServer = mailServer;
                    mail.SMTPPort = mailport;
                    mail.MailBody = mailbody;
                    mail.MIsBodyHtml = true;
                    mail.SMTPSSL = true;
                    mail.SMTPUsername = mailusername;
                    mail.SMTPPassword = mailpassword;
                    return mail.Send();
                    //                    return true;
                }
                else
                {
                    ShowMessageBox("DASHBOARD_ERR005", MessageType.ERROR);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void timerClientDisconnected_Tick(object sender, EventArgs e)
        {

            DataTable tb = WahooData.DBO.Base.ServiceReader.getClientDisconnected();
            if (tb != null)
            {
                if (tb.Rows.Count > 0)
                {
                    if (!sendMailtoList(tb))
                        ShowMessageBox("DASHBOARD_ERR006", MessageType.ERROR);
                }
            }
        }

        #endregion

    }
}
