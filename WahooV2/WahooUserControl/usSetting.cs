using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooConfiguration;

namespace WahooV2.WahooUserControl
{
    public partial class usSetting : controlBase
    {

        public usSetting()
        {
            InitializeComponent();
        }

        #region "Event"
        /// <summary>
        /// Event form load, get information from config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usSetting_Load(object sender, EventArgs e)
        {
            setNumberictoTextbox(txtDashboardRefresh);
            setNumberictoTextbox(txtExecuteInterval);
            setNumberictoTextbox(txtTransferSpeed);
            txtDashboardRefresh.Focus();
            loadData();
            AssigeTag(this);
        }
        /// <summary>
        /// btn save data event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                if (saveData())
                {
                    this.ShowMessageBox("CONF019", string.Format(WahooConfiguration.Message.GetMessageById("CONF019")), MessageType.INFORM);
                }
                else
                {
                    this.ShowMessageBox("CONF020", string.Format(WahooConfiguration.Message.GetMessageById("CONF020")), MessageType.INFORM);
                }
            }

        }
        #endregion       
        #region
        /// <summary>
        /// validate all cotrol on screen
        /// </summary>
        /// <returns></returns>
        private bool isValidate()
        {
            try
            {
                int.Parse(txtDashboardRefresh.Text);
                txtDashboardRefresh.Focus();
                int.Parse(txtExecuteInterval.Text);
                txtExecuteInterval.Focus();
                double.Parse(txtTransferSpeed.Text);
                txtTransferSpeed.Focus();
                return true;
            }
            catch
            {
                this.ShowMessageBox("ERR035", string.Format(WahooConfiguration.Message.GetMessageById("ERR035")), MessageType.ERROR);
                return false;
            }
        }       
        /// <summary>
        /// update data to app config file
        /// </summary>
        /// <returns ></returns>
        private bool saveData()
        {
            try
            {
                Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
                configObl.WriteSetting(AliasMessage.DASHBOARD_INTERVAL_CONFIG, txtDashboardRefresh.Text);
                configObl.WriteSetting(AliasMessage.EXECUTE_INTERVAL_CONFIG, txtExecuteInterval.Text);
                configObl.WriteSetting(AliasMessage.TRANSFER_SPEED_CONFIG, txtTransferSpeed.Text);
                configObl.WriteSetting(AliasMessage.WSDL_URL_CONFIG, txtWsdlUrl.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Load datat form app config file
        /// </summary>
        private void loadData()
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string interval = configObl.ReadSetting(AliasMessage.DASHBOARD_INTERVAL_CONFIG);
            string executeInterval = configObl.ReadSetting(AliasMessage.EXECUTE_INTERVAL_CONFIG);
            string transferSpeed = configObl.ReadSetting(AliasMessage.TRANSFER_SPEED_CONFIG);
            try
            {
                int.Parse(interval);
                txtDashboardRefresh.Text = interval;
            }
            catch
            {
                txtDashboardRefresh.Text = "20";
            }
            try
            {
                int.Parse(executeInterval);
                txtExecuteInterval.Text = executeInterval;
            }
            catch
            {
                txtExecuteInterval.Text = "20";
            }
            try
            {
                double.Parse(transferSpeed);
                txtTransferSpeed.Text = transferSpeed;
            }
            catch
            {
                txtTransferSpeed.Text = "16";
            }
            txtWsdlUrl.Text = configObl.ReadSetting(AliasMessage.WSDL_URL_CONFIG);
        }
        #endregion

        


    }
}
