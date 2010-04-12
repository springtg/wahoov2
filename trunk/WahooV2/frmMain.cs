﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;
using WahooV2.WahooUserControl;
using log4net;

namespace WahooV2
{
    public partial class frmMain : frmBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //_mChannelStatus is update or create new channel
        private string _mChannelStatus = "";
        //Check click mouse right in channel
        private bool _mRightMouse = false;
        //IdClient
        private int _mIdClient = -1;
        private WahooConfiguration.Resource _resource;

        public frmMain()
        {
            InitializeComponent();
        }

        #region frmMain

        /// <summary>
        /// Load frmMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            InitData();
            //Write log
            if (_logger.IsDebugEnabled)
                _logger.Debug("Program started!");
        }

        /// <summary>
        /// Init data
        /// </summary>
        public void InitData()
        {
            Cursor.Current = Cursors.WaitCursor;
            //Choose Dashboard click
            linkDashboardClick();
            //Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            //int temp = 0;
            //try
            //{
            //    temp = int.Parse(configObl.ReadSetting(AliasMessage.EXECUTE_INTERVAL_CONFIG));
            //}
            //catch
            //{
            //    temp = 0;
            //}
            //if (temp < 10)
            //{
            //    temp = 10;
            //}
            ////Load interval for timer execute
            //this.tmExecute.Interval = temp * 1000;
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Click dashboard link->show controls
        /// </summary>
        private void linkDashboardClick()
        {
            lblTop.Text = AliasMessage.DASHBOARD_HEADER_LABEL_CONTROL;
            linkDashboard.Font = new Font(linkDashboard.Font, FontStyle.Bold);
            linkUser.Font = new Font(linkUser.Font, FontStyle.Regular);
            linkClient.Font = new Font(linkClient.Font, FontStyle.Regular);
            linkSetting.Font = new Font(linkSetting.Font, FontStyle.Regular);
            linkBridge.Font = new Font(linkBridge.Font, FontStyle.Regular);
            linkReportAll.Font = new Font(linkUser.Font, FontStyle.Regular);

            xpPanelDashboardTask.Visible = true;
            xpPanelChannelTask.Visible = false;
            xpPanelUser.Visible = false;
            xpPanelClient.Visible = false;

            ////View grid dashboard
            //this.checkClearControl = true;
            //foreach (Control preControl in pnMain.Controls)
            //{
            //    preControl.Dispose();
            //}
            //pnMain.Controls.Clear();
            //this.checkClearControl = false;
            //Dashboard dashboard = new Dashboard();
            //dashboard.GridSelectionChanged += new Dashboard.GridDashboard_SelectionChanged(GridDashboardSelectionChanged);
            //dashboard.GridMouseDown += new Dashboard.GridDashboard_MouseDown(GridDashboardMouseDown);
            //dashboard.Left = 0;
            //dashboard.Top = 0;
            //dashboard.Width = 858;
            //dashboard.Height = 695;
            //pnMain.Controls.Add(dashboard);
            //if (dashboard.IdDashboard != "-1")
            //{
            //    ShowControlDashboardNormal();
            //}
            //else
            //{
            //    ShowControlWhenNoChooseItemDashboard();
            //}
        }


        /// <summary>
        /// Event excute for link Logout on frmMain
        /// Create: NTXUAN - 01/04/2010
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                frmLogin _frmLogin = new frmLogin();
                this.Hide();
                _frmLogin.ShowDialog();
                this.Close();
            }
        }

        #endregion frmMain

        #region Client

        private void linkClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            ////Inform message if user have not yet save infomation channel,then if user choose CANCEL->return
            //if (CheckEdittingChannelToSave() == "CANCEL")
            //{
            //    return;
            //}
            Cursor.Current = Cursors.WaitCursor;
            //Show control when click link client
            linkClientClick();
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// Show control when click link client
        /// </summary>
        private void linkClientClick()
        {
            
            linkDashboard.Font = new Font(linkDashboard.Font, FontStyle.Regular);
            linkClient.Font = new Font(linkUser.Font, FontStyle.Bold);
            linkSetting.Font = new Font(linkSetting.Font, FontStyle.Regular);
            linkBridge.Font = new Font(linkBridge.Font, FontStyle.Regular);
            linkUser.Font = new Font(linkUser.Font, FontStyle.Regular);
            linkReportAll.Font = new Font(linkUser.Font, FontStyle.Regular);

            xpPanelDashboardTask.Visible = false;
            xpPanelChannelTask.Visible = false;
            xpPanelUser.Visible = false;
            xpPanelClient.Visible = true;

            //View client control
            clearControl();
            //this.checkClearControl = true;
            //foreach (Control preControl in pnMain.Controls)
            //{
            //    preControl.Dispose();
            //}
            //pnMain.Controls.Clear();
            //this.checkClearControl = false;
            //Khoi tao ucClient
            ucClients _ucClients = new ucClients();

            //Khai bao cac delegate
            _ucClients.GridMouseDown += new ucClients.GridClient_MouseDown(GridClientMouseDown);
            _ucClients.GridSelectChanged += new ucClients.GridClient_SelectIndexChanged(GridClientSelectIndexChanged);
            _ucClients.Disposed += new EventHandler(_ucClients_Disposed);
            //Thiet lap cac thong so cho ucClients
            _ucClients.Left = 0;
            _ucClients.Top = 0;
            _ucClients.Width = 858;
            _ucClients.Height = 695;
            pnMain.Controls.Add(_ucClients);
            //Show control when no choose item
            if (_ucClients.IdClient == 0)
            {
                ShowControlWhenNoChooseItemsClient();
            }
            //Show control when choose item
            else
            {

                ShowControlClientsNormal();
            }
            lblTop.Text = AliasMessage.CLIENT_HEADER_LABEL_CONTROL;
        }

        void _ucClients_Disposed(object sender, EventArgs e)
        {
            //SRTAR: NTXUAN - 05/04/2101: thong code, lay thong tin ID client
            _mIdClient = ((ucClients)sender).IdClient;
            _resource = new Resource();
            lblTop.Text = _resource.GetResourceByKey("MONITOR_FORM_CONTROL", "HEADER_LABLE_TEXT_FOR_CLIENT") +
                " " + WahooData.BusinessHandler.WahooBusinessHandler.Get_Client(new WahooData.DBO.Client(_mIdClient)).Name;


            //END: NTXUAN - 05/04/2101:
        }
        /// <summary>
        /// Click right mouse or left mouse in(out) client grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridClientMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ucClients _ucClients = (ucClients)pnMain.Controls[0];
                //When click out grid
                if (_ucClients.IdClient == 0)
                {
                    ShowControlWhenNoChooseItemsClient();
                }
                //When click in grid
                else
                {
                    ShowControlClientsNormal();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Grid client selectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridClientSelectIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ucClients _ucClients = (ucClients)pnMain.Controls[0];
                if (_ucClients.IdClient == 0)
                {
                    //When click out grid
                    ShowControlWhenNoChooseItemsClient();
                }
                else
                {
                    //When click in grid
                    ShowControlClientsNormal();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Show controls when no choose client
        /// </summary>
        private void ShowControlWhenNoChooseItemsClient()
        {
            linkEditClient.Visible = false;
            linkDeleteClient.Visible = false;
            linkReport.Visible = false;
            linkReport.Top = linkDeleteClient.Top = linkEditClient.Top = 40;
            xpPanelClient.Height = 65;
        }
        /// <summary>
        /// Show controls when choose client
        /// </summary>
        private void ShowControlClientsNormal()
        {
            linkEditClient.Visible = true;
            linkDeleteClient.Visible = true;
            linkReport.Visible = true;
            linkEditClient.Top = 65;
            linkDeleteClient.Top = 90;
            linkReport.Top = 115;
            xpPanelClient.Height = 140;
        }
        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkNewClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            ucClients _ucClients = null;
            try
            {
                _ucClients = (ucClients)pnMain.Controls[0];
            }
            catch
            {
                return;
            }
            //Create new client
            _ucClients.CreateClient();
        }
        /// <summary>
        /// Edit Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkEditClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            ucClients _ucClients = null;
            try
            {
                _ucClients = (ucClients)pnMain.Controls[0];
            }
            catch
            {
                return;
            }
            //Edit new client
            _ucClients.EditClient();
        }
        /// <summary>
        /// Delete Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkDeleteClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            ucClients _ucClients = null;
            try
            {
                _ucClients = (ucClients)pnMain.Controls[0];
            }
            catch
            {
                return;
            }
            //Delete new client
            _ucClients.DeleteClient();
        }

        #endregion Client

        #region "Comand function"

        /// <summary>
        /// clear all control on show panal control
        /// NTXUAN - 01/04/2010
        /// </summary>
        private bool clearControl()
        {
            // this.checkClearControl = true;
            foreach (Control preControl in pnMain.Controls)
            {
                switch (preControl.Name)
                {
                    case "usSetting":
                        usSetting setting = (usSetting)preControl;
                        if (setting.hasChangeonControl(setting, "SETTING_QUEST001"))
                        {
                            return false;
                        }
                        break;
                    case "usMonitor":
                        break;
                    case "ucNewChannel":
                        ucNewChannel newChannel = (ucNewChannel)preControl;
                        if (newChannel.hasChangeonControl(newChannel, "SETTING_QUEST001"))
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }

                preControl.Dispose();
            }
            pnMain.Controls.Clear();
            return true;
            //this.checkClearControl = false;
        }

        /// <summary>
        /// set control owner to show panel control
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="iLeft"></param>
        /// <param name="iRight"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
        private void setControltoPanel(Control ctrl, int iLeft, int iRight, int iWidth, int iHeight)
        {
            ctrl.Left = iLeft;
            ctrl.Top = iRight;
            ctrl.Width = iWidth;
            ctrl.Height = iHeight;
            pnMain.Controls.Add(ctrl);
            Cursor.Current = Cursors.Default;
        }

        private void setActiveLink(Control ctrLink, string strlbTop)
        {
            //set all link to font style default
            lblTop.Text = strlbTop;
            linkDashboard.Font = new Font(linkDashboard.Font, FontStyle.Regular);
            linkUser.Font = new Font(linkUser.Font, FontStyle.Regular);
            linkSetting.Font = new Font(linkSetting.Font, FontStyle.Regular);
            linkBridge.Font = new Font(linkBridge.Font, FontStyle.Regular);
            linkClient.Font = new Font(linkBridge.Font, FontStyle.Regular);
            linkReportAll.Font = new Font(linkUser.Font, FontStyle.Regular);
            //set bold link to select link
            ctrLink.Font = new Font(ctrLink.Font, FontStyle.Bold);
        }

        #endregion

        #region "Link Setting"
        //NTXUAN Update - 05/04/2010
        private void linkSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clearControl())
                {
                    _resource = new Resource();
                    setActiveLink(linkSetting, _resource.GetResourceByKey("SETTING_FORM_CONTROL", "HEADER_LABLE_TEXT"));

                    xpPanelDashboardTask.Visible = false;
                    xpPanelChannelTask.Visible = false;
                    xpPanelUser.Visible = false;
                    xpPanelClient.Visible = false;

                    //View seting control                
                    setControltoPanel(new usSetting(), 0, 0, 1010, 690);
                }
            }
        }
        #endregion

        #region "Link Report"
        //NTXUAN Update - 05/04/2010
        private void linkReportAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clearControl())
                {
                    //set cursor to state wate
                    Cursor.Current = Cursors.WaitCursor;
                    xpPanelDashboardTask.Visible = false;
                    xpPanelChannelTask.Visible = false;
                    xpPanelUser.Visible = false;
                    xpPanelClient.Visible = false;
                    //View control report
                    usMonitor _monitor = new usMonitor(-1);
                    setControltoPanel(_monitor, 0, 0, 1010, 690);
                    _resource = new Resource();
                    setActiveLink(linkReportAll, _resource.GetResourceByKey("MONITOR_FORM_CONTROL", "HEADER_LABLE_TEXT"));
                    //set cursor to state wate
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        #endregion

        #region User
        //TuanDM - 02/04/2010

        private void linkUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            if (clearControl())
            {
                Cursor.Current = Cursors.WaitCursor;
                linkUserClick();
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkUserClick()
        {
            lblTop.Text = AliasMessage.USER_HEADER_LABEL_CONTROL;
            linkDashboard.Font = new Font(linkDashboard.Font, FontStyle.Regular);
            linkClient.Font = new Font(linkUser.Font, FontStyle.Regular);
            linkSetting.Font = new Font(linkSetting.Font, FontStyle.Regular);
            linkBridge.Font = new Font(linkBridge.Font, FontStyle.Regular);
            linkUser.Font = new Font(linkUser.Font, FontStyle.Bold);
            linkReportAll.Font = new Font(linkUser.Font, FontStyle.Regular);

            xpPanelDashboardTask.Visible = false;
            xpPanelChannelTask.Visible = false;
            xpPanelUser.Visible = true;
            xpPanelClient.Visible = false;
            //Khoi tao ucUser
            ucUser _ucUser = new ucUser();
            //Khai bao cac delegate
            _ucUser.GridMouseDown += new ucUser.GridUser_MouseDown(ucUser_GridMouseDown);
            _ucUser.GridSelectChanged += new ucUser.GridUser_SelectIndexChanged(ucUser_GridSelectChanged);

            //Thiet lap cac thong so cho ucUser
            _ucUser.Left = 0;
            _ucUser.Top = 0;
            _ucUser.Width = 1000;
            _ucUser.Height = 695;
            pnMain.Controls.Add(_ucUser);
            //Show control when no choose item
            if (_ucUser.IdUser == 0)
            {
                ShowControlUserWhenNoChooseItems();
            }
            //Show control when choose item
            else
            {
                ShowControlUserNormal();
            }
        }

        private void ShowControlUserNormal()
        {
            linkEditUser.Visible = true;
            linkDeleteUser.Visible = true;
            linkEditUser.Top = 65;
            linkDeleteUser.Top = 90;
            xpPanelUser.Height = 115;
        }

        private void ShowControlUserWhenNoChooseItems()
        {
            linkEditUser.Visible = false;
            linkDeleteUser.Visible = false;
            linkEditUser.Top = linkDeleteUser.Top = 40;
            xpPanelUser.Height = 65;
        }

        private void ucUser_GridSelectChanged(object sender, EventArgs e)
        {
            try
            {
                ucUser _ucUser = (ucUser)pnMain.Controls[0];
                //When click out grid
                if (_ucUser.IdUser == 0)
                {
                    ShowControlUserWhenNoChooseItems();
                }
                //When click in grid
                else
                {
                    ShowControlUserNormal();
                }
            }
            catch
            {

            }
        }

        private void ucUser_GridMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ucUser _ucUser = (ucUser)pnMain.Controls[0];
                //When click out grid
                if (_ucUser.IdUser == 0)
                {
                    ShowControlUserWhenNoChooseItems();
                }
                //When click in grid
                else
                {
                    ShowControlUserNormal();
                }
            }
            catch
            {

            }
        }

        private void linkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            try
            {
                ucUser _ucUser = null;
                _ucUser = (ucUser)pnMain.Controls[0];
                //Create new client
                _ucUser.CreateUser();
            }
            catch
            {
                return;
            }
        }

        private void linkEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            try
            {
                ucUser _ucUser = null;
                _ucUser = (ucUser)pnMain.Controls[0];
                //Create new client
                _ucUser.EditUser();
            }
            catch
            {
                return;
            }
        }

        private void linkDeleteUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            try
            {
                ucUser _ucUser = null;
                _ucUser = (ucUser)pnMain.Controls[0];
                //Create new client
                _ucUser.DeleteUser();
            }
            catch
            {
                return;
            }
        }

        #endregion

        #region "Link Report for 1 Client"
        //NTXUAN - 05/04/2010
        private void linkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _resource = new Resource();
                setActiveLink(linkReportAll, _resource.GetResourceByKey("MONITOR_FORM_CONTROL", "HEADER_LABLE_TEXT_FOR_CLIENT"));

                xpPanelDashboardTask.Visible = false;
                xpPanelChannelTask.Visible = false;
                xpPanelUser.Visible = false;
                xpPanelClient.Visible = false;

                //View control report
                clearControl();
                usMonitor _monitor = new usMonitor(_mIdClient);
                setControltoPanel(_monitor, 0, 0, 1010, 690);
            }
        }

        #endregion

        #region Channel
        //TuanDM - 05/04/2010

        /// <summary>
        /// Show controls when click channel link
        /// </summary>
        private void linkBridgeClick()
        {
            //View grid channels

            lblTop.Text = AliasMessage.CHANNELS_HEADER_LABEL_CONTROL;
            linkDashboard.Font = new Font(linkDashboard.Font, FontStyle.Regular);
            linkUser.Font = new Font(linkUser.Font, FontStyle.Regular);
            linkSetting.Font = new Font(linkSetting.Font, FontStyle.Regular);
            linkClient.Font = new Font(linkClient.Font, FontStyle.Regular);
            linkBridge.Font = new Font(linkBridge.Font, FontStyle.Bold);
            linkReportAll.Font = new Font(linkUser.Font, FontStyle.Regular);

            xpPanelDashboardTask.Visible = false;
            xpPanelChannelTask.Visible = true;
            xpPanelUser.Visible = false;
            xpPanelClient.Visible = false;

            ucChannels channels = new ucChannels();
            channels.GridDoubleClick += new ucChannels.GridChannel_CellDoubleClick(Channels_GridDoubleClick);
            channels.GridSelectionChanged += new ucChannels.GridChannel_SelectionChanged(Channels_GridSelectionChanged);
            channels.GridMouseDown += new ucChannels.GridChannel_MouseDown(Channels_GridMouseDown);
            channels.MenuItem_Click += new ucChannels.ToolStripMenuItem_Click(Channels_MenuItem_Click);

            channels.Left = 0;
            channels.Top = 0;
            channels.Width = 858;
            channels.Height = 695;
            pnMain.Controls.Add(channels);
            if (channels.IdChannels == 0)
                ShowControlWhenNoChooseItemChannel();
            else
                ShowNormalControlChannel();
        }

        /// <summary>
        /// Show or not show controls when edit or create channel
        /// </summary>
        private void EditChannelShowControl()
        {
            this.linkNewChannel.Visible = false;
            this.linkEditChannel.Visible = false;
            this.linkDeleteChannel.Visible = false;
            this.linkEnableChannel.Visible = false;
            this.linkSaveChannel.Visible = true;
            linkSaveChannel.Top = linkEnableChannel.Top = linkDeleteChannel.Top = linkEditChannel.Top = linkNewChannel.Top = 45;
            linkDeployAll.Visible = false;
            linkDeployChannel.Visible = false;
            linkUndeployAll.Visible = false;
            linkDeployAll.Top = linkDeployChannel.Top = linkUndeployAll.Top = 45;
            xpPanelChannelTask.Height = 70;
        }

        /// <summary>
        /// Show item when don't choose item of channel
        /// </summary>
        private void ShowControlWhenNoChooseItemChannel()
        {
            linkEditChannel.Top = linkDeleteChannel.Top = linkEnableChannel.Top = linkSaveChannel.Top = linkDeployChannel.Top = 45;
            linkEditChannel.Visible = linkDeleteChannel.Visible = linkEnableChannel.Visible = linkSaveChannel.Visible = linkDeployChannel.Visible = false;
            linkDeployAll.Top = 70;
            linkUndeployAll.Top = 95;
            xpPanelChannelTask.Height = 120;
        }

        /// <summary>
        /// Show controls normal for channel
        /// </summary>
        private void ShowNormalControlChannel()
        {
            this.linkNewChannel.Visible = true;
            this.linkEditChannel.Visible = true;
            this.linkDeleteChannel.Visible = true;
            this.linkEnableChannel.Visible = true;
            this.linkSaveChannel.Visible = false;
            linkNewChannel.Top = 45;
            linkEditChannel.Top = 70;
            linkDeleteChannel.Top = 95;
            linkEnableChannel.Top = 120;
            linkDeployAll.Visible = true;
            linkDeployChannel.Visible = true;
            linkUndeployAll.Visible = true;
            linkDeployChannel.Top = 145;
            linkDeployAll.Top = 170;
            linkUndeployAll.Top = 195;
            xpPanelChannelTask.Height = 220;
        }

        /// <summary>
        /// Edit channel->show control
        /// </summary>
        private void ShowEditChannel(int idChannel)
        {
            ucChannels channels = (ucChannels)pnMain.Controls[0];
            clearControl();
            ucNewChannel newChannel = new ucNewChannel();
            newChannel.Left = 0;
            newChannel.Top = 0;
            newChannel.Width = 858;
            newChannel.Height = 695;
            pnMain.Controls.Add(newChannel);
            newChannel.ShowEditChannel(idChannel);
            this._mChannelStatus = AliasMessage.UPDATE_STATUS;
            this.EditChannelShowControl();
        }

        /// <summary>
        /// Save channel
        /// </summary>
        private bool SaveChannel()
        {
            try
            {
                ucNewChannel newChannel = (ucNewChannel)pnMain.Controls[0];
                return newChannel.SaveChannel(this._mChannelStatus);
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR009", MessageType.ERROR);
                return false;
            }
        }

        void Channels_MenuItem_Click(object sender, EventArgs e)
        {
            _mRightMouse = true;
            string itemText = ((ToolStripMenuItem)sender).Text;
            if (itemText == AliasMessage.NEW_CHANNEL_ITEM_CONTROL)
            {
                linkNewChannel_LinkClicked(null, null);
            }
            else if (itemText == AliasMessage.EDIT_CHANNEL_ITEM_CONTROL)
            {
                linkEditChannel_LinkClicked(null, null);
            }
            else if (itemText == AliasMessage.DELETE_CHANNEL_ITEM_CONTROL)
            {
                linkDeleteChannel_LinkClicked(null, null);
            }
            else if (itemText == AliasMessage.ENABLED_CHANNEL_CONTROL || itemText == AliasMessage.DISABLED_CHANNEL_CONTROL)
            {
                linkEnableChannel_LinkClicked(null, null);
            }
            else if (itemText == AliasMessage.DEPLOY_CHANNEL_CONTROL || itemText == AliasMessage.UNDEPLOY_CHANNEL_CONTROL)
            {
                linkDeployChannel_LinkClicked(null, null);
            }
            else if (itemText == AliasMessage.DEPLOY_ALL_CHANNEL_ITEM_CONTROL)
            {
                linkDeployAll_LinkClicked(null, null);
            }
            else if (itemText == AliasMessage.UNDEPLOY_ALL_CHANNEL_ITEM_CONTROL)
            {
                linkUndeployAll_LinkClicked(null, null);
            }
        }

        void Channels_GridMouseDown(object sender, MouseEventArgs e)
        {
            ucChannels channel = (ucChannels)pnMain.Controls[0];
            if (channel.IdChannels == 0)
            {
                //When no choose channel
                ShowControlWhenNoChooseItemChannel();
            }
            else
            {
                //When choose channel
                ShowNormalControlChannel();
            }
        }

        void Channels_GridSelectionChanged(object sender, EventArgs e)
        {
            ucChannels channels = (ucChannels)pnMain.Controls[0];
            if (channels.CheckLoad == 0)
            {
                return;
            }
            //If channel status is enable->show disable button
            if (channels.EnableChannel == AliasMessage.ENABLED_STATUS)
            {
                linkEnableChannel.Text = AliasMessage.DISABLED_CHANNEL_FORMMAIN_CONTROL;
                this.linkEnableChannel.Image = global::WahooV2.Properties.Resources.Disable;
            }
            //Otherwise,channel status is disable->show ensable button
            else
            {
                linkEnableChannel.Text = AliasMessage.ENABLED_CHANNEL_FORMMAIN_CONTROL;
                this.linkEnableChannel.Image = global::WahooV2.Properties.Resources.Enable;
            }
            //If channel is deployed->show undeploy button
            if (channels.IsDeployChannel)
            {
                linkDeployChannel.Text = AliasMessage.UNDEPLOY_CHANNEL_FORMMAIN_CONTROL;
                linkDeployChannel.Image = global::WahooV2.Properties.Resources.Stop;
            }
            //Otherwise,channel is undeployed->show undeploy button
            else
            {
                linkDeployChannel.Text = AliasMessage.DEPLOY_CHANNEL_FORMMAIN_CONTROL;
                linkDeployChannel.Image = global::WahooV2.Properties.Resources.Deploy;
            }
        }

        void Channels_GridDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int idChannel = 0;
            ucChannels channels = (ucChannels)pnMain.Controls[0];
            idChannel = channels.IdChannels;
            ShowEditChannel(idChannel);
            Cursor.Current = Cursors.Default;
        }

        private void linkBridge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            if (clearControl())
            {
                Cursor.Current = Cursors.WaitCursor;
                linkBridgeClick();
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkNewChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            if (((ucChannels)pnMain.Controls[0]).NumberOfChannel >= AliasMessage.NUMBER_CHANNEL)
            {
                this.ShowMessageBox("ERR036", string.Format(WahooConfiguration.Message.GetMessageById("ERR036"), AliasMessage.NUMBER_CHANNEL), MessageType.ERROR);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            clearControl();
            ucNewChannel newChannel = new ucNewChannel();
            newChannel.Left = 0;
            newChannel.Top = 0;
            newChannel.Width = 858;
            newChannel.Height = 695;
            pnMain.Controls.Add(newChannel);
            this._mChannelStatus = AliasMessage.NEW_STATUS;
            this.EditChannelShowControl();
            Cursor.Current = Cursors.Default;
        }

        private void linkEditChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int idChannel = 0;
                ucChannels channels = (ucChannels)pnMain.Controls[0];
                idChannel = channels.IdChannels;
                ShowEditChannel(idChannel);
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR011", MessageType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkDeleteChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ucChannels channels = (ucChannels)pnMain.Controls[0];
                channels.DeleteChannel();
                if (channels.IdChannels == 0)
                    ShowControlWhenNoChooseItemChannel();
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR009", MessageType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkEnableChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ucChannels channels = (ucChannels)pnMain.Controls[0];
                int status = channels.UpdateChannel_Status();
                //curren status is enable
                if (status == 1)
                {
                    linkEnableChannel.Text = AliasMessage.DISABLED_CHANNEL_FORMMAIN_CONTROL;
                    this.linkEnableChannel.Image = global::WahooV2.Properties.Resources.Disable;
                }
                //curren status is disable
                else if (status == 0)
                {
                    linkEnableChannel.Text = AliasMessage.ENABLED_CHANNEL_FORMMAIN_CONTROL;
                    this.linkEnableChannel.Image = global::WahooV2.Properties.Resources.Enable;
                }
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR009", MessageType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkSaveChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            Cursor.Current = Cursors.WaitCursor;
            if (!SaveChannel())
                return;
            //Clear control panel main
            clearControl();
            //Add channel to pnMain
            ucChannels channels = new ucChannels();
            channels.GridDoubleClick += new ucChannels.GridChannel_CellDoubleClick(Channels_GridDoubleClick);
            channels.GridSelectionChanged += new ucChannels.GridChannel_SelectionChanged(Channels_GridSelectionChanged);
            channels.GridMouseDown += new ucChannels.GridChannel_MouseDown(Channels_GridMouseDown);
            channels.MenuItem_Click += new ucChannels.ToolStripMenuItem_Click(Channels_MenuItem_Click);
            channels.Left = 0;
            channels.Top = 0;
            channels.Width = 858;
            channels.Height = 695;
            //if (channels.ChannelStatus == AliasMessage.ENABLED_STATUS)
            //{
            //    linkEnableChannel.Text = AliasMessage.DISABLED_CHANNEL_FORMMAIN_CONTROL;
            //    this.linkEnableChannel.ImageIndex = 19;
            //}
            //else
            //{
            //    linkEnableChannel.Text = AliasMessage.ENABLED_CHANNEL_FORMMAIN_CONTROL;
            //    this.linkEnableChannel.ImageIndex = 21;
            //}
            pnMain.Controls.Add(channels);
            ShowNormalControlChannel();
            Cursor.Current = Cursors.Default;
        }

        private void linkDeployChannel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ucChannels channels = (ucChannels)pnMain.Controls[0];
                int deploy = channels.DeployChannel();
                //curren status is Deploy
                if (deploy == 1)
                {
                    linkDeployChannel.Text = AliasMessage.UNDEPLOY_CHANNEL_FORMMAIN_CONTROL;
                    this.linkDeployChannel.Image = global::WahooV2.Properties.Resources.Stop;
                }
                //curren status is Undeploy
                else if (deploy == 0)
                {
                    linkDeployChannel.Text = AliasMessage.DEPLOY_CHANNEL_FORMMAIN_CONTROL;
                    this.linkDeployChannel.Image = global::WahooV2.Properties.Resources.Deploy;
                }
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR009", MessageType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkDeployAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ucChannels channels = (ucChannels)pnMain.Controls[0];
                channels.DeployAllChannel();
                linkDeployChannel.Text = AliasMessage.UNDEPLOY_CHANNEL_FORMMAIN_CONTROL;
                this.linkDeployChannel.Image = global::WahooV2.Properties.Resources.Stop;
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR009", MessageType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void linkUndeployAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_mRightMouse)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
            }
            else
            {
                _mRightMouse = false;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ucChannels channels = (ucChannels)pnMain.Controls[0];
                channels.UndeployAllChannel();
                linkDeployChannel.Text = AliasMessage.DEPLOY_CHANNEL_FORMMAIN_CONTROL;
                this.linkDeployChannel.Image = global::WahooV2.Properties.Resources.Deploy;
            }
            catch
            {
                this.ShowMessageBox("CHANNEL_ERR009", MessageType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
