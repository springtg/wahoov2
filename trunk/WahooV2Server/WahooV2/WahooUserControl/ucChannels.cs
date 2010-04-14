using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;
using WahooV2.WahooUserControl;
using WahooData.BusinessHandler;
using WahooData.DBO;
using log4net;

namespace WahooV2.WahooUserControl
{
    public partial class ucChannels : controlBase
    {
        #region variable
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Declare delegate for gird double click
        public delegate void GridChannel_CellDoubleClick(object sender, DataGridViewCellEventArgs e);
        public event GridChannel_CellDoubleClick GridDoubleClick;

        //Declare delegate for gird cell selected index change
        public delegate void GridChannel_SelectionChanged(object sender, EventArgs e);
        public event GridChannel_SelectionChanged GridSelectionChanged;

        //Declare delegate for click out of gird
        public delegate void GridChannel_MouseDown(object sender, MouseEventArgs e);
        public event GridChannel_MouseDown GridMouseDown;

        //Declare delegate for click to toolstrip menu item
        public delegate void ToolStripMenuItem_Click(object sender, EventArgs e);
        public event ToolStripMenuItem_Click MenuItem_Click;

        //Variable lc to check channel is loading(even selection index change is block)
        private int _mCheckLoad = 0;
        public int CheckLoad
        {
            get { return _mCheckLoad; }
            set { _mCheckLoad = value; }
        }

        //IdChannel
        private int _mIdChannels = 0;

        public int IdChannels
        {
            get { return _mIdChannels; }
            set { _mIdChannels = value; }
        }

        //Channel status (enabled or disabled)
        private string _mEnableChannel = string.Empty;

        public string EnableChannel
        {
            get { return _mEnableChannel; }
            set { _mEnableChannel = value; }
        }

        //Channel status execute( START,PAUSE,STOP...)
        private bool _mIsDeployChannel = false;

        public bool IsDeployChannel
        {
            get { return _mIsDeployChannel; }
            set { _mIsDeployChannel = value; }
        }

        //Number of channel        
        public int NumberOfChannel
        {
            get { return this.gridChannel.Rows.Count; }
        }
                
        #endregion variable

        #region Contructor

        public ucChannels()
        {
            InitializeComponent();
        }

        #endregion

        #region Event

        /// <summary>
        /// Load list channel into data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucChannels_Load(object sender, EventArgs e)
        {
            LoadTextOfCotrolFromResource();
            BindGrid();
            _mCheckLoad = 1;
        }

        public void BindGrid()
        {
            try
            {
                List<Channel> objListChannels = WahooBusinessHandler.Get_ListChannel(new Channel());

                //bind list Channel vao datatable
                DataTable dtChannel = new DataTable();
                DataColumn clId = new DataColumn("Id", typeof(int));
                DataColumn clChannelName = new DataColumn("ChannelName", typeof(string));
                DataColumn clStatus = new DataColumn("Status", typeof(string));
                DataColumn clDescription = new DataColumn("Description", typeof(string));
                DataColumn clIsDeployed = new DataColumn("IsDeployed", typeof(bool));
                dtChannel.Columns.Add(clId);
                dtChannel.Columns.Add(clChannelName);
                dtChannel.Columns.Add(clStatus);
                dtChannel.Columns.Add(clDescription);
                dtChannel.Columns.Add(clIsDeployed);
                
                foreach (Channel objChannel in objListChannels)
                {
                    DataRow dr = dtChannel.NewRow();
                    dr["Id"] = objChannel.Id;
                    dr["Status"] = objChannel.Active.Value ? AliasMessage.ENABLED_STATUS : AliasMessage.DISABLED_STATUS;
                    dr["ChannelName"] = objChannel.ChannelName;
                    dr["Description"] = objChannel.Description;
                    dr["IsDeployed"] = objChannel.IsDeployed;
                    dtChannel.Rows.Add(dr);
                }

                gridChannel.DataSource = dtChannel;                
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
        /// Double click to cell in channel grid to edit channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridChannel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridDoubleClick != null)
            {
                //Transform selected data
                if (gridChannel.SelectedRows.Count > 0)
                {
                    this._mIdChannels = DataTypeProtect.ProtectInt32(gridChannel.SelectedRows[0].Cells[this.clId.Name].Value, 0);
                    EnableChannel = DataTypeProtect.ProtectString(gridChannel.SelectedRows[0].Cells[this.clStatus.Name].Value);
                    IsDeployChannel = DataTypeProtect.ProtectBoolean(gridChannel.SelectedRows[0].Cells[this.clIsDeployed.Name].Value, false);
                }
                else
                {
                    this._mIdChannels = 0;
                    EnableChannel = string.Empty;
                    IsDeployChannel = false;
                }
                GridDoubleClick(sender, e);
            }
        }

        /// <summary>
        /// Selected index in grid change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridChannel_SelectionChanged(object sender, EventArgs e)
        {
            if (GridSelectionChanged != null)
            {
                if (_mCheckLoad == 0)
                {
                    return;
                }
                //Transform selected data
                if (gridChannel.SelectedRows.Count > 0)
                {
                    this._mIdChannels = DataTypeProtect.ProtectInt32(gridChannel.SelectedRows[0].Cells[this.clId.Name].Value, 0);
                    EnableChannel = DataTypeProtect.ProtectString(gridChannel.SelectedRows[0].Cells[this.clStatus.Name].Value);
                    IsDeployChannel = DataTypeProtect.ProtectBoolean(gridChannel.SelectedRows[0].Cells[this.clIsDeployed.Name].Value, false);
                }
                else
                {
                    this._mIdChannels = 0;
                    EnableChannel = string.Empty;
                    IsDeployChannel = false;
                }
                GridSelectionChanged(sender, e);
            }
        }

        /// <summary>
        /// Click channel when mouse out of grid, in grid by right mouse click or left mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridChannel_MouseDown(object sender, MouseEventArgs e)
        {
            if (GridMouseDown != null)
            {
                DataGridView.HitTestInfo hti = gridChannel.HitTest(e.X, e.Y);
                //When click left mouse
                if (e.Button == MouseButtons.Left)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //When click out of grid
                        if (hti.RowIndex == -1)
                        {
                            this._mIdChannels = 0;
                            gridChannel.ClearSelection();
                        }
                        //When click in of grid
                        else
                        {
                            this._mIdChannels = DataTypeProtect.ProtectInt32(gridChannel.Rows[hti.RowIndex].Cells[this.clId.Name].Value, 0);
                            EnableChannel = DataTypeProtect.ProtectString(gridChannel.Rows[hti.RowIndex].Cells[this.clStatus.Name].Value);
                            IsDeployChannel = DataTypeProtect.ProtectBoolean(gridChannel.Rows[hti.RowIndex].Cells[this.clIsDeployed.Name].Value, false);
                        }
                    }
                }
                //When click right mouse
                if (e.Button == MouseButtons.Right)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //When click out of grid
                        if (hti.RowIndex == -1)
                        {
                            editChannelItem.Visible = false;
                            deleteChannelItem.Visible = false;
                            disableItem.Visible = false;
                            deployChannelItem.Visible = false;
                            this._mIdChannels = 0;
                            EnableChannel = string.Empty;
                            IsDeployChannel = false;
                            gridChannel.ClearSelection();
                        }
                        //When click in of grid
                        else
                        {
                            gridChannel.Rows[hti.RowIndex].Selected = true;
                            string enableStatus = DataTypeProtect.ProtectString(gridChannel.Rows[hti.RowIndex].Cells[this.clStatus.Name].Value);
                            //If channel status is enabled-> show disable channel
                            if (enableStatus==AliasMessage.ENABLED_STATUS)
                            {
                                disableItem.Text = AliasMessage.DISABLED_CHANNEL_CONTROL;
                                disableItem.Image = global::WahooV2.Properties.Resources.wh_lock;
                            }
                            //If channel status is disabled-> show enable channel
                            else
                            {
                                disableItem.Text = AliasMessage.ENABLED_CHANNEL_CONTROL;
                                disableItem.Image = global::WahooV2.Properties.Resources.wh_unlock;
                            }
                            bool deployStatus = DataTypeProtect.ProtectBoolean(gridChannel.Rows[hti.RowIndex].Cells[this.clIsDeployed.Name].Value, false);
                            //If channel status execute is not deploy
                            if (deployStatus)
                            {
                                deployChannelItem.Text = AliasMessage.UNDEPLOY_CHANNEL_CONTROL;
                                deployChannelItem.Image = global::WahooV2.Properties.Resources.wh_stop;
                            }
                            //Otherwise, show undeploy channel
                            else
                            {
                                //Show deploy channel button
                                deployChannelItem.Text = AliasMessage.DEPLOY_CHANNEL_CONTROL;
                                deployChannelItem.Image = global::WahooV2.Properties.Resources.wh_go;                                
                            }
                            //Show buttons when click in grid for channel
                            editChannelItem.Visible = true;
                            deleteChannelItem.Visible = true;
                            disableItem.Visible = true;
                            deployChannelItem.Visible = true;
                            this._mIdChannels = DataTypeProtect.ProtectInt32(gridChannel.Rows[hti.RowIndex].Cells[this.clId.Name].Value, 0);
                            EnableChannel = enableStatus;
                            IsDeployChannel = deployStatus;
                        }
                    }
                    else
                    {
                        editChannelItem.Visible = false;
                        deleteChannelItem.Visible = false;
                        disableItem.Visible = false;
                        deployChannelItem.Visible = false;
                        this._mIdChannels = 0;
                        EnableChannel = string.Empty;
                        IsDeployChannel = false;
                        gridChannel.ClearSelection();
                    }
                }
                GridMouseDown(sender, e);
            }
        }

        /// <summary>
        /// When choose function by click right mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickToolStripItem(object sender, EventArgs e)
        {
            MenuItem_Click(sender, e);
        }

        #endregion

        #region function

        /// <summary>
        /// Update channel status (enabled or disabled)
        /// </summary>
        /// <returns></returns>
        public int UpdateChannel_Status()
        {
            int vReturn = -1;
            if (gridChannel.SelectedRows.Count == 0)
            {
                return vReturn;
            }
            try
            {
                Channel objChannel=new Channel();
                objChannel.Id = _mIdChannels;
                objChannel = WahooBusinessHandler.Get_Channel(objChannel);

                if (objChannel.Active == true)
                {
                    objChannel.Active = false;
                    objChannel.Update();
                    gridChannel.SelectedRows[0].Cells[clStatus.Name].Value = AliasMessage.DISABLED_STATUS;
                    vReturn = 0;
                }
                else
                {
                    objChannel.Active = true;
                    objChannel.Update();
                    gridChannel.SelectedRows[0].Cells[clStatus.Name].Value = AliasMessage.ENABLED_STATUS;
                    vReturn = 1;
                }                
                return vReturn;
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
        /// Delete channel
        /// </summary>
        public void DeleteChannel()
        {
            if (gridChannel.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show(WahooConfiguration.Message.GetMessageById("CHANNEL_QUEST001"), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Channel objChannel = new Channel();
                    objChannel.Id = _mIdChannels;                    
                    objChannel.Delete();
                    BindGrid();
                }
                catch (Exception ex)
                {
                    //Write log
                    if (_logger.IsErrorEnabled)
                        _logger.Error(ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Deploy channel to download or upload data
        /// </summary>
        /// <returns></returns>
        public int DeployChannel()
        {
            int vReturn = -1;
            if (gridChannel.SelectedRows.Count == 0)
            {
                return vReturn;
            }
            try
            {
                Channel objChannel = new Channel();
                objChannel.Id = _mIdChannels;
                objChannel = WahooBusinessHandler.Get_Channel(objChannel);

                if (objChannel.IsDeployed == true)
                {
                    objChannel.IsDeployed = false;
                    objChannel.Update();
                    gridChannel.SelectedRows[0].Cells[clIsDeployed.Name].Value = false;
                    vReturn = 0;
                }
                else
                {
                    objChannel.IsDeployed = true;
                    objChannel.Update();
                    gridChannel.SelectedRows[0].Cells[clIsDeployed.Name].Value = true;
                    vReturn = 1;
                }                
                return vReturn;
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
        /// Deploy all channel
        /// </summary>
        public void DeployAllChannel()
        {
            try
            {
                List<Channel> objListChannel = WahooBusinessHandler.Get_ListChannel(new Channel());
                foreach (Channel objChanel in objListChannel)
                {
                    if (objChanel.IsDeployed != true)
                    {
                        objChanel.IsDeployed = true;
                        objChanel.Update();
                        foreach (DataGridViewRow dgrow in gridChannel.Rows)
                        {
                            dgrow.Cells[clIsDeployed.Name].Value = true;
                        }
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
        /// Undeploy all channel
        /// </summary>
        public void UndeployAllChannel()
        {
            try
            {
                List<Channel> objListChannel = WahooBusinessHandler.Get_ListChannel(new Channel());
                foreach (Channel objChanel in objListChannel)
                {
                    if (objChanel.IsDeployed != false)
                    {
                        objChanel.IsDeployed = false;
                        objChanel.Update();
                        foreach (DataGridViewRow dgrow in gridChannel.Rows)
                        {
                            dgrow.Cells[clIsDeployed.Name].Value = false;
                        }
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
        /// Bind text control from resource file.
        /// </summary>
        private void LoadTextOfCotrolFromResource()
        {
            Resource objResource = new Resource();
            
            clChannelName.HeaderText = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "HEADER_NAME_CHANNELNAME");
            clDescription.HeaderText = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "HEADER_NAME_DESCRIPTION");
            clStatus.HeaderText = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "HEADER_NAME_STATUS");

            newChannelItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_NEWCHANNEL");
            editChannelItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_EDITCHANNEL");
            deleteChannelItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_DELETECHANNEL");
            disableItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_DISABLECHANNEL");
            deployChannelItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_DEPLOYCHANNEL");
            deployAllChannelItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_DEPLOYALLCHANNEL");
            undeployAllChannelItem.Text = objResource.GetResourceByKey("CHANNELS_FORM_CONTROL", "MENUITEM_NAME_UNDEPLOYALLCHANNEL");
        }

        #endregion function        
    }
}
