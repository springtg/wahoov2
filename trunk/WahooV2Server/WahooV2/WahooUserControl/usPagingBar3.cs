using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WahooV2.WahooUserControl
{
    public partial class usPagingBar3 : UserControl
    {
        private const string strNameFist = "btnFirst";
        private const string strNameLast = "btnLast";
        private const string strNameNext = "btnNext";
        private const string strNamePrev = "btnPrev";
        private const int _iMaxPage = 10;
        private const int _iMinPage = 1;
        private int _iBlock = 0;
        private int _iAllPage = 0;
        private int _iCurrPage = 0;
        public delegate void getSelectPagebyUser(object sender, EventArgs e);
        public event getSelectPagebyUser selectedPagebyUser;

        public usPagingBar3()
        {
            InitializeComponent();
        }

        private ToolStripButton createButtonToolTip(string strName, string strText, int iValue)
        {
            ToolStripButton tmp = new ToolStripButton();
            tmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tmp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            tmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            tmp.Name = strName;
            tmp.Size = new System.Drawing.Size(29, 22);
            tmp.Text = strText;
            tmp.Tag = iValue;
            tmp.ToolTipText = Convert.ToString(iValue);
            return tmp;
        }
        public void InitControl(int iAllPage, int iCurPage)
        {
            _iAllPage = iAllPage;
            _iCurrPage = iCurPage;
            createButtonBar((_iAllPage >= _iMaxPage) ? _iMaxPage : _iAllPage, iCurPage, true, 0);
        }

        private void createButtonBar(int iNumberPage, int iCurPage, bool isStart, int iBlock)
        {
            toolStrip1.Items.Clear();
            int iBlockBottom = (iCurPage / _iMaxPage) + _iMaxPage;//gioi han duoi
            int iBlockTop = (iCurPage % _iMaxPage) + _iMaxPage;//gioi han tren
            //tao 4 button dieu khien
            ToolStripButton btnFist = createButtonToolTip(strNameFist, "<<", _iMinPage);
            btnFist.Click += new EventHandler(btnFist_Click);
            ToolStripButton btnPrev = createButtonToolTip(strNamePrev, "<", (isStart == true) ? ((_iCurrPage - 1 == 0) ? _iMinPage : _iCurrPage - 1) : ((_iCurrPage - _iMaxPage == 0) ? _iMinPage : _iCurrPage - _iMaxPage));
            btnPrev.Click += new EventHandler(btnPrev_Click);
            ToolStripButton btnLast = createButtonToolTip(strNameLast, ">>", _iAllPage);
            btnLast.Click += new EventHandler(btnLast_Click);
            ToolStripButton btnNext = createButtonToolTip(strNameNext, ">", (isStart == true) ? ((_iCurrPage + _iMaxPage <= _iAllPage) ? _iCurrPage + _iMaxPage : _iAllPage) : ((_iCurrPage - _iMaxPage > 0) ? _iCurrPage - _iMaxPage : _iMaxPage));
            btnNext.Click += new EventHandler(btnNext_Click);
            toolStrip1.Items.Add(btnFist);
            toolStrip1.Items.Add(btnPrev);
            for (int i = 1; i <= iNumberPage; i++)
            {
                ToolStripButton tmp = (isStart == true) ? createButtonToolTip("btn" + Convert.ToString(i), Convert.ToString((_iCurrPage - 1) + i), ((_iCurrPage - 1) + i)) : createButtonToolTip("btn" + Convert.ToString(i), Convert.ToString((_iCurrPage - 10) + i), ((_iCurrPage - 10) + i));
                tmp.Click += new EventHandler(tmp_Click);
                toolStrip1.Items.Add(tmp);
            }
            toolStrip1.Items.Add(btnNext);
            toolStrip1.Items.Add(btnLast);
            if (isStart)
            {
                setCurrPage("btn1");
            }
            else
            {
                setCurrPage("btn" + Convert.ToString(iNumberPage));
            }
            if (_iCurrPage.Equals("1"))
            {
                btnFist.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (_iCurrPage.Equals(WahooConfiguration.DataTypeProtect.ProtectInt32(((ToolStripButton)sender).Tag) - 1) && _iCurrPage < _iAllPage)
            if (_iCurrPage.Equals((_iBlock + 1) * _iMaxPage) && _iCurrPage < _iAllPage)
            {
                _iCurrPage = _iCurrPage + 1;
                int iBlockBottom = (_iCurrPage / _iMaxPage) + _iMaxPage;//gioi han duoi
                int iBlockTop = (_iCurrPage % _iMaxPage) + _iMaxPage;//gioi han tren
                _iBlock = _iCurrPage / _iMaxPage;// = iBlockBottom;
                int numPage = ((_iMaxPage * _iBlock) + _iMaxPage > _iAllPage) ? _iAllPage - (_iMaxPage * _iBlock) : _iMaxPage;
                createButtonBar(numPage, _iCurrPage, true, _iBlock);
            }
            else
            {
                ToolStripButton btnTmp = getSender();
                if (btnTmp != null)
                {
                    moveSelected((object)btnTmp, e, 1);
                }
            }
        }
        private ToolStripButton getSender()
        {
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (item.Checked)
                {
                    return item;
                }
            }
            return null;
        }
        private ToolStripButton getSender(int iValue)
        {
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (item.Tag.Equals(iValue))
                {
                    return item;
                }
            }
            return null;
        }
        void btnLast_Click(object sender, EventArgs e)
        {

            _iBlock = (_iAllPage % _iMaxPage == 0) ? (_iAllPage / _iMaxPage) : ((_iAllPage / _iMaxPage) + 1);
            _iBlock = _iBlock - 1;
            _iCurrPage = _iBlock * _iMaxPage + 1;
            int numPage = ((_iMaxPage * _iBlock) + _iMaxPage > _iAllPage) ? _iAllPage -(_iMaxPage * _iBlock) : _iMaxPage;
            createButtonBar(numPage, _iCurrPage, true, _iBlock);
        }

        void btnPrev_Click(object sender, EventArgs e)
        {
            //if ( _iCurrPage > _iMaxPage)
            if (_iCurrPage.Equals((_iBlock * _iMaxPage) + 1) && _iCurrPage < _iAllPage)
            {
                _iCurrPage = _iCurrPage - 1;
                int iBlockBottom = (_iCurrPage / _iMaxPage) + _iMaxPage;//gioi han duoi
                int iBlockTop = (_iCurrPage % _iMaxPage) + _iMaxPage;//gioi han tren
                _iBlock = _iCurrPage / _iMaxPage - 1;// = iBlockBottom;
                int numPage = ((_iMaxPage * _iBlock) + _iMaxPage > _iAllPage) ? _iAllPage - (_iMaxPage * _iBlock) : _iMaxPage;
                createButtonBar(numPage, _iCurrPage, false, _iBlock);
            }
            else
            {
                ToolStripButton btnTmp = getSender();
                if (btnTmp != null)
                {
                    moveSelected((object)btnTmp, e, -1);
                }
            }
        }

        void btnFist_Click(object sender, EventArgs e)
        {
            _iCurrPage = 1;
            _iBlock = 0;
            int numPage = ((_iMaxPage * _iBlock) + _iMaxPage > _iAllPage) ? _iAllPage - (_iMaxPage * _iBlock) : _iMaxPage;
            createButtonBar(numPage, _iCurrPage, true, _iBlock);
        }

        void tmp_Click(object sender, EventArgs e)
        {
            //TODO: xu ly cho tung nut
            moveSelected(sender, e, 0);
        }

        private void setCurrPage(ToolStripButton ctrl)
        {
            ctrl.Checked = true;
            if (_iCurrPage.Equals(1))
            {
                setEnableControl(strNameFist, false);
                setEnableControl(strNamePrev, false);
            }
            else
            {
                setEnableControl(strNameFist, true);
                setEnableControl(strNamePrev, true);
            }
            if (_iCurrPage.Equals(_iAllPage))
            {
                setEnableControl(strNameLast, false);
                setEnableControl(strNameNext, false);
            }
            else
            {
                setEnableControl(strNameLast, true);
                setEnableControl(strNameNext, true);
            }
        }
        private void setUnCurrPage(ToolStripButton ctrl)
        {
            ctrl.Checked = false;
        }
        private void setCurrPage(string strName)
        {
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (!item.Name.Equals(strNameFist) && !item.Name.Equals(strNameLast) && !item.Name.Equals(strNameNext) && !item.Name.Equals(strNamePrev))
                {
                    if (item.Name.Equals(strName))
                    {
                        setCurrPage(item);
                    }
                    else
                    {
                        setUnCurrPage(item);
                    }
                }
            }
        }
        private void setCurrPage(int iValue)
        {
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (!item.Name.Equals(strNameFist) && !item.Name.Equals(strNameLast) && !item.Name.Equals(strNameNext) && !item.Name.Equals(strNamePrev))
                {
                    if (item.Tag.Equals(iValue))
                    {
                        setCurrPage(item);
                    }
                    else
                    {
                        setUnCurrPage(item);
                    }
                }
            }
        }

        /// <summary>
        /// set gia tri page cho
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="iValue"></param>
        private void setValuetoControl(ToolStripButton ctrl, int iValue)
        {
            ctrl.Tag = iValue;
            ctrl.ToolTipText = iValue.ToString();
            if (!ctrl.Name.Equals(strNameFist) && !ctrl.Name.Equals(strNameLast) && !ctrl.Name.Equals(strNameNext) && !ctrl.Name.Equals(strNamePrev))
            {
                ctrl.Text = iValue.ToString();
            }
        }

        private void setValuetoControl(bool isNext)
        {
            int iBlockBottom = (_iCurrPage / _iMaxPage) + _iMaxPage;//gioi han duoi
            int iBlockTop = (_iCurrPage % _iMaxPage) + _iMaxPage;//gioi han tren
            int iValue = iBlockBottom;
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (!item.Name.Equals(strNameFist) && !item.Name.Equals(strNameLast) && !item.Name.Equals(strNameNext) && !item.Name.Equals(strNamePrev))
                {
                    if (isNext)
                    {
                        setValuetoControl(item, ((WahooConfiguration.DataTypeProtect.ProtectInt32(item.Tag) + 1) * _iBlock) + 1);
                    }
                    else
                    {
                        setValuetoControl(item, WahooConfiguration.DataTypeProtect.ProtectInt32(item.Tag) - 1);
                    }
                }
                else
                {

                    //tao 4 button dieu khien
                    setValuetoControl(item, _iMinPage);
                    setValuetoControl(item, (_iCurrPage - 1 < _iMinPage) ? _iMinPage : _iCurrPage - 1);
                    setValuetoControl(item, _iAllPage);
                    setValuetoControl(item, (_iCurrPage + 1 > _iMaxPage) ? _iMaxPage : _iCurrPage + 1);

                }
            }
        }
        private void setEnableControl(string strName, bool enable)
        {
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (item.Name.Equals(strName))
                {
                    item.Enabled = enable;
                }
            }
        }

        private int getCurrBlock(int iCurPage)
        {

            int iAllBlock = (_iAllPage % _iMaxPage == 0) ? _iAllPage / _iMaxPage : ((_iAllPage / _iMaxPage) + (_iAllPage % _iMaxPage));
            return iCurPage / _iMaxPage;
        }

        private void usPagingBar_Load(object sender, EventArgs e)
        {

        }

        private int getselectPage(object sender, EventArgs e)
        {
            int temp = WahooConfiguration.DataTypeProtect.ProtectInt32(((ToolStripButton)sender).Tag);
            selectedPagebyUser(sender, e);
            return temp;
        }

        private void moveSelected(object sender, EventArgs e, int IsNext)
        {
            switch (IsNext)
            {
                case 1:
                    _iCurrPage = getselectPage(sender, e) + 1;
                    break;
                case -1:
                    _iCurrPage = getselectPage(sender, e) - 1;
                    setCurrPage(_iCurrPage);
                    break;
                case 0:
                    _iCurrPage = getselectPage(sender, e);
                    break;
            }
            if (IsNext != -1)
            {
                if (((ToolStripButton)sender).Name.Equals(strNameNext) || ((ToolStripButton)sender).Name.Equals(strNamePrev))
                {
                    setCurrPage(_iCurrPage);//((ToolStripButton)sender).Name);
                }
                else
                {
                    ToolStripButton Tmp = getSender(_iCurrPage);
                    if (Tmp != null)
                    {
                        setCurrPage(Tmp.Name);
                    }
                }
            }
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (item.Name.Equals(strNameNext))
                {
                    setValuetoControl(item, _iCurrPage + 1);
                }
                if (item.Name.Equals(strNamePrev))
                {
                    setValuetoControl(item, _iCurrPage - 1);
                }
            }
        }


    }
}

