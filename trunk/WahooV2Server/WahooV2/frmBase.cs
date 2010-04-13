using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WahooV2.ExControl;
using log4net;

namespace WahooV2
{
    public partial class frmBase : Form
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Enumerations

        public enum MessageType
        {
            UNDEFINED,
            WARNING,
            INFORM,
            ERROR,
            CONFIRM
        }
        #endregion Enumerations
        public frmBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public DialogResult ShowMessageBox(string messageId, string messageText, MessageType messageType)
        {
            //1. Assign defaul return value
            DialogResult result = DialogResult.None;
            try
            {
                //2. Display message if found
                if (messageText != "")
                {
                    switch (messageType)
                    {
                        case MessageType.WARNING:
                            MessageBox.Show(messageText, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case MessageType.INFORM:
                            MessageBox.Show(messageText, "INFORM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case MessageType.ERROR:
                            MessageBox.Show(messageText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case MessageType.CONFIRM:
                            result = MessageBox.Show(messageText, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            break;
                        default:
                            MessageBox.Show(messageText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    //2.2. If not found then display inform message
                    MessageBox.Show(String.Format("Message {0} is not found in resource file.", messageId), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //3.Return result
                return result;
            }
            catch (Exception ex)
            {
                //Write log
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                //4.Error handling
                //Write exception here
                return DialogResult.None;
            }
        }
        /// <summary>
        /// Show message with messageid from message resource
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public DialogResult ShowMessageBox(string messageId, MessageType messageType)
        {
            return ShowMessageBox(messageId, WahooConfiguration.Message.GetMessageById(messageId), messageType);
        }        

        /// <summary>
        /// Check Control has change or not
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public bool HasChangeonControl(Control ctrl)
        {
            if (ctrl == null)
            {
                return false;
            }
            foreach (Control itemCtrl in ctrl.Controls)
            {
                if (itemCtrl.GetType().Equals(typeof(TextBox)))
                {
                    TextBox txt = (TextBox)itemCtrl;
                    if (!itemCtrl.Tag.Equals(txt.Text))
                    {
                        return true;
                    }
                }
                else
                    if (itemCtrl.GetType().Equals(typeof(TextBoxForNum)))
                    {
                        TextBoxForNum txt = (TextBoxForNum)itemCtrl;
                        if (!itemCtrl.Tag.Equals(txt.Text))
                        {
                            return true;
                        }
                    }
                    else
                        if (itemCtrl.GetType().Equals(typeof(RadioButton)))
                        {
                            RadioButton rbt = (RadioButton)itemCtrl;
                            if (!itemCtrl.Tag.Equals(rbt.Checked))
                            {
                                return true;
                            }
                        }
                        else
                            if (itemCtrl.GetType().Equals(typeof(CheckBox)))
                            {
                                CheckBox chb = (CheckBox)itemCtrl;
                                if (!itemCtrl.Tag.Equals(chb.Checked))
                                {
                                    return true;
                                }
                            }
                            else
                                if (ctrl.HasChildren)
                                {
                                    if (HasChangeonControl(itemCtrl))
                                    {
                                        return true;
                                    }
                                }
            }
            return false;
        }
               
        /// <summary>
        /// Set tag = text of control
        /// </summary>
        /// <param name="ctrl"></param>
        protected void AssigeTag(Control ctrl)
        {
            if (ctrl == null)
            {
                return;
            }
            foreach (Control itemCtrl in ctrl.Controls)
            {
                if (itemCtrl.GetType().Equals(typeof(TextBox)))
                {
                    TextBox txt = (TextBox)itemCtrl;
                    itemCtrl.Tag = txt.Text;
                }
                else
                    if (itemCtrl.GetType().Equals(typeof(TextBoxForNum)))
                    {
                        TextBoxForNum txt = (TextBoxForNum)itemCtrl;
                        itemCtrl.Tag = txt.Text;
                    }
                    else
                        if (itemCtrl.GetType().Equals(typeof(RadioButton)))
                        {
                            RadioButton rbt = (RadioButton)itemCtrl;
                            itemCtrl.Tag = rbt.Checked;
                        }
                        else
                            if (itemCtrl.GetType().Equals(typeof(CheckBox)))
                            {
                                CheckBox chb = (CheckBox)itemCtrl;
                                itemCtrl.Tag = chb.Checked;
                            }
                            else
                                if (ctrl.HasChildren)
                                {
                                    AssigeTag(itemCtrl);
                                }
            }
        }
    }
}
