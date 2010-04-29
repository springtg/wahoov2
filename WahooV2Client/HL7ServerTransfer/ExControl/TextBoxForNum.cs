using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace WahooV2.ExControl
{
    class TextBoxForNum : TextBox
    {
        private string value;
        private string _strFormat = string.Empty;
        private bool _bNull = false;

        public bool BNull
        {
            get { return _bNull; }
            set { _bNull = value; }
        }

        public string StrFormat
        {
            get { return _strFormat; }
            set { _strFormat = value; }
        }

        public string Strvalue
        {
            get {
                if (StrFormat.Equals(string.Empty))
                {
                    return this.Text;
                }
                else
                {
                    return this.Text.Replace(",", "");
                }
            }
        }


        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.MaxLength = 13;
            this.TextAlign = HorizontalAlignment.Right;
        }
        #endregion

        public TextBoxForNum()
        {
            InitializeComponent();
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void OnTextChanged(object sender, EventArgs e)
        {
            double result = 0;
            try
            {
                result = double.Parse(this.Text);
            }
            catch
            {
                result = 0;
            }
            if (result == 0)
            {
                if (!_bNull)
                {
                    this.Text = "0";
                }
                else
                {
                    this.Text = string.Empty;
                }
            }
            else
            {
                //this.Text = result.ToString("", CultureInfo.InvariantCulture);
                //this.Text = result.ToString("#,#", CultureInfo.InvariantCulture);
                if (_strFormat.Equals(string.Empty))
                {
                    this.Text = result.ToString("", CultureInfo.InvariantCulture);
                }
                else
                {
                    this.Text = result.ToString(StrFormat, CultureInfo.InvariantCulture);
                }
            }
            this.SelectionStart = this.Text.Length;
        }
    }
}

