using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HL7ServerTransfer
{
    public partial class frmBase : Form
    {
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

        protected HL7Source.Resource _Resource;
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
                    //2.1. Message type parser
                    Int32 iMessageCode = 0;
                    //2.1. Display message
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
                //4.Error handling
                //Write exception here
                return DialogResult.None;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public DialogResult ShowMessageBox(string messageId, MessageType messageType)
        {
            //1. Assign defaul return value
            DialogResult result = DialogResult.None;
            try
            {
                string messageText = HL7Source.Message.GetMessageById(messageId);
                //2. Display message if found
                if (messageText != "")
                {
                    //2.1. Message type parser
                    Int32 iMessageCode = 0;
                    //2.1. Display message
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
                //4.Error handling
                //Write exception here
                return DialogResult.None;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public DialogResult ShowMessageBox(string messageId, MessageType messageType, string para)
        {
            //1. Assign defaul return value
            DialogResult result = DialogResult.None;
            try
            {
                string messageText = string.Format(HL7Source.Message.GetMessageById(messageId), para);
                //2. Display message if found
                if (messageText != "")
                {
                    //2.1. Message type parser
                    Int32 iMessageCode = 0;
                    //2.1. Display message
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
                //4.Error handling
                //Write exception here
                return DialogResult.None;
            }
        }
        /// <summary>
        /// lay text cua cua 1 control
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected string getNameControl(Control ctrl)
        {
            try
            {
                return ctrl.Text.Replace(":", "");
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// set status cua client co connected den web service khong?
        /// </summary>
        /// <param name="strText"></param>
        protected void setStatusServerConnected(string strText)
        {
            lblMsgServerConnected.Text = strText;
        }
        /// <summary>
        /// set status thao tac cua client
        /// </summary>
        /// <param name="strText"></param>
        protected void setStatusMsg(string strText)
        {
            lblMsg.Text = strText;
        }
        
        
    }
}