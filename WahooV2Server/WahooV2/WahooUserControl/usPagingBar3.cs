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
        private const string strNamePrevious = "btnPrevious";
        private const int _iMaxPage = 10;
        private const int _iMinPage = 1;
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
            createButtonBar((_iAllPage >= _iMaxPage) ? _iMaxPage : _iAllPage, iCurPage,true);
        }

        private void createButtonBar(int iNumberPage, int iCurPage, bool isStart)
        {
            toolStrip1.Items.Clear();
            int iBlockBottom = (iCurPage / _iMaxPage) + _iMaxPage;//gioi han duoi
            int iBlockTop = (iCurPage % _iMaxPage) + _iMaxPage;//gioi han tren
            //tao 4 button dieu khien
            ToolStripButton btnFist = createButtonToolTip("btnFirst", "<<", _iMinPage);
            btnFist.Click += new EventHandler(btnFist_Click);
            ToolStripButton btnPrev = createButtonToolTip("btnPrev", "<", (_iCurrPage - 1 < _iMinPage) ? _iMinPage : _iCurrPage - 1);
            ToolStripButton btnLast = createButtonToolTip("btnLast", ">>", _iAllPage);
            ToolStripButton btnNext = createButtonToolTip("btnNext", ">", (_iCurrPage + 1 > _iMaxPage) ? _iMaxPage : _iCurrPage + 1);
            toolStrip1.Items.Add(btnFist);
            toolStrip1.Items.Add(btnPrev);
            for (int i = 0; i < iNumberPage; i++)
            {
                ToolStripButton tmp = createButtonToolTip("btn" + Convert.ToString(i + 1), Convert.ToString(i + 1), iCurPage + i);
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
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
        }

        void btnFist_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void tmp_Click(object sender, EventArgs e)
        {
            //TODO: xu ly cho tung nut
            moveSelected(sender, e);
        }

        private void setCurrPage(ToolStripButton ctrl)
        {
            ctrl.Checked = true;
        }
        private void setUnCurrPage(ToolStripButton ctrl)
        {
            ctrl.Checked = false;
        }
        private void setCurrPage(string strName)
        {
            foreach (ToolStripButton item in toolStrip1.Items)
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





        private int getCurrBlock(int iCurPage)
        {


            int iAllBlock = (_iAllPage % _iMaxPage == 0) ? _iAllPage / _iMaxPage : ((_iAllPage / _iMaxPage) + (_iAllPage % _iMaxPage));

            return iCurPage / _iMaxPage;
        }

        

        private void usPagingBar_Load(object sender, EventArgs e)
        {

        }
        
        


        public void setActiveControl(int iAllPageNum, int iCurrPage)
        {
            //_allPage = iAllPageNum;
            //enableAllControl(toolStrip1, "btn");
            //setUnCurrentPage();
            ////neu la la it hon 10 page thi hien thi tat cac cac nut la disable 1 nut hai ben
            //if (iAllPageNum <= 10)
            //{
            //    //diable 4 nut hai ben
            //    btnFirst.Enabled = false;
            //    btnLast.Enabled = false;
            //    btnNext.Enabled = false;
            //    btnPrevious.Enabled = false;
            //    for (int i = 10; i > iAllPageNum; i--)
            //    {
            //        setDisableBTN("btn" + i.ToString());
            //    }
            //    if (iAllPageNum.Equals(0) || iAllPageNum.Equals(1))
            //    {
            //        btn1.Enabled = false;
            //        return;
            //    }
            //}
            ////set page hien tai
            //setCurrentpage(btn1, iCurrPage, iAllPageNum);
            ////set value cho control
            //for (int i = 0; i < iAllPageNum; i++)
            //{
            //    setValuetoControl("btn" + Convert.ToString(i + 1), i + 1);
            //}
            //btnFirst.Tag = 1;
            //btnLast.Tag = iAllPageNum;
            //btnNext.Tag = iCurrPage + 1;
            //btnPrevious.Tag = (iCurrPage - 1 == 0) ? 1 : iCurrPage - 1;
            //btnFirst.ToolTipText = Convert.ToString(1);
            //btnNext.ToolTipText = Convert.ToString(iCurrPage + 1);
            //btnLast.ToolTipText = Convert.ToString(iAllPageNum);
            //btnPrevious.ToolTipText = (iCurrPage == 0) ? Convert.ToString(iCurrPage - 1) : Convert.ToString(iCurrPage);
        }

        private void setDisableBTN(string btnName)
        {
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (item.Name.Equals(btnName))
                {
                    item.Visible = false;
                }
            }
        }

        

        

       

        private void setValuetoControl(string ctrlname, int iPageValue)
        {
            //if (iPageValue > _allPage)
            //{
            //    return;
            //}
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (item.Name.Equals(ctrlname))
                {
                    item.Tag = iPageValue;
                    item.ToolTipText = iPageValue.ToString();
                    if (!item.Name.Equals(strNameFist) && !item.Name.Equals(strNameLast) && !item.Name.Equals(strNameNext) && !item.Name.Equals(strNamePrevious))
                    {
                        item.Text = iPageValue.ToString();
                    }
                }
            }
        }

       

        private int getselectPage(object sender, EventArgs e)
        {
            int temp = WahooConfiguration.DataTypeProtect.ProtectInt32(((ToolStripButton)sender).Tag);
            selectedPagebyUser(sender, e);
            return temp;
        }

       
        private void btnNext_Click(object sender, EventArgs e)
        {
            //int topCurr = WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag);
            //int _last = WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag);
            //if (iPageSelect.Equals(topCurr) && iPageSelect.Equals(_last - 1))
            //{
            //    moveTop(sender, e, btn10);
            //}
            //else
            //{
            //    MoveSelected(sender, e, btnNext);
            //    //moveNext(sender, e, btnNext);
            //}
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btnLast);
            // moveLast(sender, e, btnLast);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btnFirst);
            //  moveFirst(sender, e, btnFirst);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //int bottomCurr = WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag);
            //int _first = WahooConfiguration.DataTypeProtect.ProtectInt32(btnFirst.Tag);
            //iPageSelect = getselectPage(sender, e, btnPrevious);
            //if (iPageSelect.Equals(bottomCurr - 1))//&& iPageSelect.Equals(_first))
            //{
            //    moveBottom(sender, e, btn1);
            //}
            //else
            //{
            //    bPrev = true;
            //    MoveSelected(sender, e, btnNext);
            //movePrevious(sender, e, btnPrevious);
            //moveNext(sender, e, btnNext);
            // }
            // movePrevious(sender, e, btnPrevious);
        }

        private void moveNext(object sender, EventArgs e, ToolStripButton ctrl)
        {
            //if (_allPage > 10)
            //{
            //    int iSectionPage = iPageSelect;//= (_allPage % 10) - (_allPage / 10); 
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //    if (WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) + 1 <= _allPage)
            //    {
            //        setValuetoControl(btnPrevious.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 1);
            //        setValuetoControl(btn1.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) + 1);
            //        setValuetoControl(btn2.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn2.Tag) + 1);
            //        setValuetoControl(btn3.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn3.Tag) + 1);
            //        setValuetoControl(btn4.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn4.Tag) + 1);
            //        setValuetoControl(btn5.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn5.Tag) + 1);
            //        setValuetoControl(btn6.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn6.Tag) + 1);
            //        setValuetoControl(btn7.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn7.Tag) + 1);
            //        setValuetoControl(btn8.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn8.Tag) + 1);
            //        setValuetoControl(btn9.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn9.Tag) + 1);
            //        setValuetoControl(btn10.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) + 1);
            //        setValuetoControl(btnNext.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag) + 1);
            //        setCurrentpage(iPageSelect);
            //    }
            //    else
            //    {
            //        setCurrentpage(iPageSelect);
            //    }
            //}
            //else
            //{
            //    int iSectionPage = iPageSelect;//= (_allPage % 10) - (_allPage / 10); 
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //    setCurrentpage(iPageSelect);
            //}
        }

        private void movePrevious(object sender, EventArgs e, ToolStripButton ctrl)
        {
            //if (_allPage > 10)
            //{
            //    int iSectionPage = iPageSelect;
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //    if (WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) - 1 >= 1)
            //    {
            //        setValuetoControl(btnPrevious.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 1);
            //        setValuetoControl(btn1.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) - 1);
            //        setValuetoControl(btn2.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn2.Tag) - 1);
            //        setValuetoControl(btn3.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn3.Tag) - 1);
            //        setValuetoControl(btn4.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn4.Tag) - 1);
            //        setValuetoControl(btn5.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn5.Tag) - 1);
            //        setValuetoControl(btn6.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn6.Tag) - 1);
            //        setValuetoControl(btn7.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn7.Tag) - 1);
            //        setValuetoControl(btn8.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn8.Tag) - 1);
            //        setValuetoControl(btn9.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn9.Tag) - 1);
            //        setValuetoControl(btn10.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) - 1);
            //        setValuetoControl(btnNext.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag) - 1);
            //        setCurrentpage(iPageSelect);
            //    }
            //    else
            //    {
            //        setCurrentpage(iPageSelect);
            //    }
            //}
            //else
            //{
            //    int iSectionPage = iPageSelect;
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //    setCurrentpage(iPageSelect);
            //}

        }

        private void moveFirst(object sender, EventArgs e, ToolStripButton ctrl)
        {
            getselectPage(sender, e);
            // setActiveControl(_allPage, 1);

        }

        private void moveLast(object sender, EventArgs e, ToolStripButton ctrl)
        {
            //int iSectionPage = iPageSelect;
            //iPageSelect = getselectPage(sender, e, ctrl);
            //if (_allPage > 10)
            //{
            //    if (_allPage > 10)
            //    {
            //        setValuetoControl(btnPrevious.Name, _allPage - 10);
            //    }
            //    if (_allPage > 9)
            //    {
            //        setValuetoControl(btn1.Name, _allPage - 9);
            //    }
            //    if (_allPage > 8)
            //    {
            //        setValuetoControl(btn2.Name, _allPage - 8);
            //    }
            //    if (_allPage > 7)
            //    {
            //        setValuetoControl(btn3.Name, _allPage - 7);
            //    }
            //    if (_allPage > 6)
            //    {
            //        setValuetoControl(btn4.Name, _allPage - 6);
            //    }
            //    if (_allPage > 5)
            //    {
            //        setValuetoControl(btn5.Name, _allPage - 5);
            //    }
            //    if (_allPage > 4)
            //    {
            //        setValuetoControl(btn6.Name, _allPage - 4);
            //    }
            //    if (_allPage > 3)
            //    {
            //        setValuetoControl(btn7.Name, _allPage - 3);
            //    }
            //    if (_allPage > 2)
            //    {
            //        setValuetoControl(btn8.Name, _allPage - 2);
            //    }
            //    if (_allPage > 1)
            //    {
            //        setValuetoControl(btn9.Name, _allPage - 1);
            //    }
            //    setValuetoControl(btn10.Name, _allPage);
            //    setValuetoControl(btnNext.Name, _allPage);
            //    setCurrentpage(_allPage);
            //}
            //else
            //{
            //    setCurrentpage(_allPage);
            //}
        }
        bool bPrev = false;
        private void moveSelected(object sender, EventArgs e)
        {
            _iCurrPage = getselectPage(sender, e);
            setCurrPage(((ToolStripButton)sender).Name);
            //if (!bPrev)
            //{
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //}
            //else
            //{
            //      iPageSelect = getselectPage(sender, e, ctrl)-2;
            //}
            //setCurrentpage(iPageSelect);
            //bPrev = false;
        }

        private void moveTop(object sender, EventArgs e, ToolStripButton ctrl)
        {
            //int topCurr = WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag);
            //if (topCurr + iMax <= _allPage)
            //{
            //    int iSectionPage = iPageSelect;//= (_allPage % 10) - (_allPage / 10); 
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //    if (topCurr + 1 <= _allPage)
            //    {
            //        setValuetoControl(btnPrevious.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 10);
            //        setValuetoControl(btn1.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) + 10);
            //        setValuetoControl(btn2.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn2.Tag) + 10);
            //        setValuetoControl(btn3.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn3.Tag) + 10);
            //        setValuetoControl(btn4.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn4.Tag) + 10);
            //        setValuetoControl(btn5.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn5.Tag) + 10);
            //        setValuetoControl(btn6.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn6.Tag) + 10);
            //        setValuetoControl(btn7.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn7.Tag) + 10);
            //        setValuetoControl(btn8.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn8.Tag) + 10);
            //        setValuetoControl(btn9.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn9.Tag) + 10);
            //        if (topCurr > 10)
            //        {
            //            setValuetoControl(btn10.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) + 10);
            //        }
            //        else
            //        {
            //            btn10.Visible = false;
            //        }
            //        setValuetoControl(btnNext.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag) + 10);
            //        setCurrentpage(iPageSelect + 1);
            //    }
            //    else
            //    {
            //        setCurrentpage(iPageSelect);
            //    }
            //}
            //else
            //{

            //    setValuetoControl(btn1.Name, _allPage - 9);
            //    setValuetoControl(btnPrevious.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) - 1);
            //    setValuetoControl(btn2.Name, _allPage - 8);
            //    setValuetoControl(btn3.Name, _allPage - 7);
            //    setValuetoControl(btn4.Name, _allPage - 6);
            //    setValuetoControl(btn5.Name, _allPage - 5);
            //    setValuetoControl(btn6.Name, _allPage - 4);
            //    setValuetoControl(btn7.Name, _allPage - 3);
            //    setValuetoControl(btn8.Name, _allPage - 2);
            //    setValuetoControl(btn9.Name, _allPage - 1);
            //    setValuetoControl(btn10.Name, _allPage);
            //    setValuetoControl(btnNext.Name, _allPage);
            //    setCurrentpage(iPageSelect + 1);
            //    //int iSectionPage = iPageSelect;//= (_allPage % 10) - (_allPage / 10); 
            //    //iPageSelect = getselectPage(sender, e, ctrl);
            //    //setCurrentpage(iPageSelect);
            //}
        }

        private void moveBottom(object sender, EventArgs e, ToolStripButton ctrl)
        {
            //int topCurr = WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag);
            //if (topCurr - iMax >= 1)
            //{
            //    //int iSectionPage = iPageSelect;
            //    //iPageSelect = getselectPage(sender, e, ctrl)-1;
            //    if (topCurr - 1 >= 1)
            //    {
            //        setValuetoControl(btnPrevious.Name, (WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 10 == 0) ? 1 : (WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 10));
            //        setValuetoControl(btn1.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) - 10);
            //        setValuetoControl(btn2.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn2.Tag) - 10);
            //        setValuetoControl(btn3.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn3.Tag) - 10);
            //        setValuetoControl(btn4.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn4.Tag) - 10);
            //        setValuetoControl(btn5.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn5.Tag) - 10);
            //        setValuetoControl(btn6.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn6.Tag) - 10);
            //        setValuetoControl(btn7.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn7.Tag) - 10);
            //        setValuetoControl(btn8.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn8.Tag) - 10);
            //        setValuetoControl(btn9.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn9.Tag) - 10);
            //        setValuetoControl(btn10.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) - 10);
            //        setValuetoControl(btnNext.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag) - 10);
            //        setCurrentpage(iPageSelect);
            //    }
            //    else
            //    {
            //        setCurrentpage(iPageSelect);
            //    }
            //}
            //else
            //{
            //    int iSectionPage = iPageSelect;
            //    iPageSelect = getselectPage(sender, e, ctrl);
            //    setCurrentpage(iPageSelect);
            //}



        }
    }
}

