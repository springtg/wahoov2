using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WahooV2
{
    public partial class frmProgress : Form
    {
        string m_inform_msg;

        public string Inform_msg
        {
            get { return m_inform_msg; }
            set { m_inform_msg = value; }
        }
        public frmProgress(String msg)
        {
            try
            {
                m_inform_msg = msg;
                InitializeComponent();
                int t_height, t_width;
                t_height = GetHeight4Text(m_inform_msg, lblMessage.Font);
                t_width = GetWidth4Text(m_inform_msg, lblMessage.Font);
                lblMessage.Text = m_inform_msg;
                lblMessage.Size = new Size(t_width, t_height + 10);
                this.Size = new Size(t_width + 100, t_height + 20);
            }
            catch
            {
            }
        }
        private int GetWidth4Text(String v_text, System.Drawing.Font v_font)
        {
            try
            {
                Graphics g;
                Bitmap b = new Bitmap(1, 1);
                g = Graphics.FromImage(b);
                return (int)(g.MeasureString(v_text, v_font).Width + 5);
            }
            catch
            {
                return -1;
            }
        }

        private int GetHeight4Text(String v_text, System.Drawing.Font v_font)
        {
            try
            {
                Graphics g;
                Bitmap b = new Bitmap(1, 1);
                g = Graphics.FromImage(b);
                return (int)(g.MeasureString(v_text, v_font).Height + 10);
            }
            catch
            {
                return -1;
            }
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            lblMessage.Text = m_inform_msg;
        }

        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = m_inform_msg;
            int t_height, t_width;
            t_height = GetHeight4Text(m_inform_msg, lblMessage.Font);
            t_width = GetWidth4Text(m_inform_msg, lblMessage.Font);
            lblMessage.Text = m_inform_msg;
            lblMessage.Size = new Size(t_width, t_height + 10);
            this.Size = new Size(t_width + 100, t_height + 20);
        }
    }
}