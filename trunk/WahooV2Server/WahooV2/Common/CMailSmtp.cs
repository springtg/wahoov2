﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Threading;
using System.ComponentModel;
namespace WahooV2.Common
{
    public class CMailSmtp
    {
        //All private filed
        private string mMailFrom;
        private string mMailTo;
        private string mMailSubject;
        private string mMailBody;
        private string mSMTPServer;
        private int mSMTPPort;
        private string mSMTPUsername;
        private string mSMTPPassword;
        private bool mSMTPSSL;
        private MailMessage MailObject;
        private bool mSendAsync;
        private bool mTryAgianOnFailure;
        private int mTryAgainDelayTime;
        private string[] mMailAttachments;
        private string mErrorMsg;
        private bool mIsBodyHtml;
        
        public CMailSmtp()
        {
            // Default values
            MailObject = new MailMessage();
            mIsBodyHtml = false; ;
            mMailFrom = "";
            mMailTo = "";
            mMailSubject = "";
            mMailBody = "";
            mSMTPServer = "";
            mSMTPPort = 25;
            mSMTPUsername = "";
            mSMTPPassword = "";
            mSMTPSSL = false;
            mSendAsync = false;
            mTryAgianOnFailure = true;
            mTryAgainDelayTime = 10000;
            mMailAttachments = new string[1];

        }

        // Properties
        public string MailFrom { set { mMailFrom = value; } get { return mMailFrom; } }
        public string MailTo { set { mMailTo = value; } get { return mMailTo; } }
        public string MailSubject { set { mMailSubject = value; } get { return mMailSubject; } }
        public string MailBody { set { mMailBody = value; } get { return mMailBody; } }
        public string SMTPServer { set { mSMTPServer = value; } get { return mSMTPServer; } }
        public int SMTPPort { set { mSMTPPort = value; } get { return mSMTPPort; } }
        public string SMTPUsername { set { mSMTPUsername = value; } get { return mSMTPUsername; } }
        public string SMTPPassword { set { mSMTPPassword = value; } get { return mSMTPPassword; } }
        public bool SMTPSSL { set { mSMTPSSL = value; } get { return mSMTPSSL; } }
        public bool SendAsync { set { mSendAsync = value; } get { return mSendAsync; } }
        public bool TryAgianOnFailure { set { mTryAgianOnFailure = value; } get { return mTryAgianOnFailure; } }
        public int TryAgainDelayTime { set { mTryAgainDelayTime = value; } get { return mTryAgainDelayTime; } }
        public string[] MailAttachments { set { mMailAttachments = value; } get { return mMailAttachments; } }
        public string ErrorMsg { set { mErrorMsg = value; } }
        public bool MIsBodyHtml { set { mIsBodyHtml = value; } get { return mIsBodyHtml; } }


        /// <summary>
        /// Phuong Thuc goi mail
        /// </summary>
        /// <returns>true=goi thanh cong; false=khong thanh cong</returns>
        public Boolean Send()
        {
            // build the email message
            MailMessage Email = new MailMessage();
            MailAddress MailFrom = new MailAddress(mMailFrom, mMailFrom);
            Email.From = MailFrom;
            Email.To.Add(mMailTo);

            Email.Subject = mMailSubject;
            Email.Body = mMailBody;
            Email.IsBodyHtml = mIsBodyHtml;

            for (int k = 0; k < MailAttachments.Length; k++)
            {
                if (File.Exists(MailAttachments[k]))
                {
                    Attachment TempAttachment = new Attachment(MailAttachments[k]);
                    Email.Attachments.Add(TempAttachment);
                }
            }
            // Smtp Client
            SmtpClient SmtpMail = new SmtpClient(mSMTPServer, mSMTPPort);
            SmtpMail.UseDefaultCredentials = false;
            SmtpMail.Credentials = new NetworkCredential(mSMTPUsername, mSMTPPassword);
            SmtpMail.EnableSsl = mSMTPSSL;

            SmtpMail.SendCompleted += new SendCompletedEventHandler(this.SendCompleted);
            Boolean bTemp = true;
            try
            {
                string sTemp = "";
                if (mSendAsync)
                    SmtpMail.SendAsync(Email, sTemp);
                else
                    SmtpMail.Send(Email);
            }
            catch (SmtpFailedRecipientsException e)
            {
                for (int k = 0; k < e.InnerExceptions.Length; k++)
                {
                    bTemp = false;

                    SmtpStatusCode StatusCode = e.InnerExceptions[k].StatusCode;
                    if (StatusCode == SmtpStatusCode.MailboxUnavailable ||
                        StatusCode == SmtpStatusCode.MailboxBusy)
                    {
                        try
                        {
                            if (mTryAgianOnFailure)
                            {
                                Thread.Sleep(mTryAgainDelayTime);
                                // send the message
                                string sTemp = "";
                                if (mSendAsync)
                                    SmtpMail.SendAsync(Email, sTemp);
                                else
                                    SmtpMail.Send(Email);
                                // Message was sent.
                                bTemp = true;

                            }
                        }
                        catch { bTemp = false; }
                    }
                }
            }
            return bTemp;
        }
        public void SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MailMessage mail = (MailMessage)e.UserState;
            string subject = mail.Subject;

            if (e.Cancelled)
            {
                string cancelled = string.Format("[{0}] Send canceled.", subject);
                ErrorMsg = "Cancelled";
            }
            if (e.Error != null)
            {
                ErrorMsg = String.Format("[{0}] {1}", subject, e.Error.ToString());
            }
            else
            {
                ErrorMsg = "Message sent.";
            }
        }

    }
}
