using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooData.DBO;
using WahooData.BusinessHandler;
using WahooConfiguration;

namespace WahooV2.WahooUserControl
{
    public partial class ucClients : controlBase
    {

        #region variable

        //Check client is loaded
        private int _mCheckLoad = 0;

        private int _mIdClient = -1;
        private string _mIdClientName = string.Empty;

        public string MIdClientName
        {
            get { return _mIdClientName; }
            set { _mIdClientName = value; }
        }

        public int IdClient
        {
            get { return _mIdClient; }
            set { _mIdClient = value; }
        }

        //Declare delegate for click out of gird
        public delegate void GridClient_MouseDown(object sender, MouseEventArgs e);
        public event GridClient_MouseDown GridMouseDown;

        //Declare delegate for gird selected index changed
        public delegate void GridClient_SelectIndexChanged(object sender, EventArgs e);
        public event GridClient_SelectIndexChanged GridSelectChanged;

        public delegate void ToolStripMenuItem_Click(object sender, EventArgs e);
        public event ToolStripMenuItem_Click MonitorItem_Click;

        #endregion variable

        public ucClients()
        {
            InitializeComponent();
        }
        #region event

        /// <summary>
        /// Double click in cell->form edit selected client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditClient();
        }
        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucClients_Load(object sender, EventArgs e)
        {
            BindGrid();
            this._mCheckLoad = 1;
        }

        private void BindGrid()
        {
            try
            {
                //Lay danh sach cac Client
                List<Client> objListClient = WahooBusinessHandler.Get_ListClient(new Client());
                
                gridClient.DataSource = objListClient;
                if (gridClient.SelectedRows.Count > 0)
                {
                    this._mIdClient = DataTypeProtect.ProtectInt32(gridClient.SelectedRows[0].Cells[this.clId.Name].Value.ToString(), 0);
                    //this._mClientCode = gridClient.SelectedRows[0].Cells[this.clClientCode.Name].Value.ToString();
                }
                //When load finished, _mCheckload =1
                //this._mCheckLoad = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Create new client button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newClientItem_Click(object sender, EventArgs e)
        {
            CreateClient();
        }
        /// <summary>
        /// Edit client button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editClientItem_Click(object sender, EventArgs e)
        {
            EditClient();
        }
        /// <summary>
        /// Delete client button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteClientItem_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }
        /// <summary>
        /// Grid selected index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridClient_SelectionChanged(object sender, EventArgs e)
        {
            if (GridSelectChanged != null)
            {
                if (this._mCheckLoad == 0)
                {
                    return;
                }
                if (gridClient.SelectedRows.Count > 0)
                {
                    this._mIdClient = DataTypeProtect.ProtectInt32(gridClient.SelectedRows[0].Cells[this.clId.Name].Value.ToString());
                    //this._mClientCode = gridClient.SelectedRows[0].Cells[this.clClientCode.Name].Value.ToString();
                }
                GridSelectChanged(sender, e);
            }
        }
        /// <summary>
        /// Show button when click right mouse or left mouse in(out) grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (GridMouseDown != null)
            {
                DataGridView.HitTestInfo hti = gridClient.HitTest(e.X, e.Y);
                //Click left mouse
                if (e.Button == MouseButtons.Left)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //Click out of grid
                        if (hti.RowIndex == -1)
                        {
                            this._mIdClient = 0;
                            //this._mClientCode = "";
                            gridClient.ClearSelection();
                        }
                        //Click in grid
                        else
                        {
                            this._mIdClient = DataTypeProtect.ProtectInt32(gridClient.Rows[hti.RowIndex].Cells[this.clId.Name].Value.ToString(),0);
                            //this._mClientCode = gridClient.Rows[hti.RowIndex].Cells[this.clClientCode.Name].Value.ToString();
                        }
                    }
                }
                //Click right mouse
                if (e.Button == MouseButtons.Right)
                {
                    if (hti.Type != DataGridViewHitTestType.ColumnHeader)
                    {
                        //Click out of grid
                        if (hti.RowIndex == -1)
                        {
                            editClientItem.Visible = false;
                            deleteClientItem.Visible = false;
                            itemClientMonitor.Visible = false;
                            this._mIdClient = 0;
                            //this._mClientCode = "";
                            gridClient.ClearSelection();
                        }
                        //Click in grid
                        else
                        {
                            gridClient.Rows[hti.RowIndex].Selected = true;
                            this._mIdClient = DataTypeProtect.ProtectInt32(gridClient.Rows[hti.RowIndex].Cells[this.clId.Name].Value.ToString(),0);
                            //this._mClientCode = gridClient.Rows[hti.RowIndex].Cells[this.clClientCode.Name].Value.ToString();
                            editClientItem.Visible = true;
                            deleteClientItem.Visible = true;
                            itemClientMonitor.Visible = true;
                        }
                    }
                }
                GridMouseDown(sender, e);
            }
        }

        #endregion event

        #region function

        /// <summary>
        /// Edit client
        /// </summary>
        public void EditClient()
        {
            if (gridClient.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                //Show form edit client
                frmEditClient _frmEditClient = new frmEditClient();
                _frmEditClient.ClientId = DataTypeProtect.ProtectInt32(gridClient.SelectedRows[0].Cells[this.clId.Name].Value.ToString(),0);
                _frmEditClient.Status = AliasMessage.UPDATE_STATUS;
                _frmEditClient.ShowDialog();
                //Update infomation which is edited to grid
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Create client
        /// </summary>
        public void CreateClient()
        {
            //Show form create client
            frmEditClient _frmEditClient = new frmEditClient();
            _frmEditClient.Status = AliasMessage.CREATE_STATUS;
            _frmEditClient.ShowDialog();
            BindGrid();
        }
        /// <summary>
        /// Delete client
        /// </summary>
        public void DeleteClient()
        {
            if (gridClient.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show(string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_QUEST001")), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = DataTypeProtect.ProtectInt32(gridClient.SelectedRows[0].Cells[this.clId.Name].Value.ToString(),0);
                //Delete Client
                Client objDelete = new Client();
                objDelete.Id = id;
                if (objDelete.Delete())
                {
                    BindGrid();
                }
                else
                {
                    this.ShowMessageBox("CLIENT_ERR008", string.Format(WahooConfiguration.Message.GetMessageById("CLIENT_ERR008")), MessageType.ERROR);
                }
            }
        }

        #endregion function  

        private void gridClient_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable dt = ((DataTable)((DataGridView)sender).DataSource);
        }

        private void itemClientMonitor_Click(object sender, EventArgs e)
        {
            MonitorItem_Click(sender, e);
        }
    }
}
