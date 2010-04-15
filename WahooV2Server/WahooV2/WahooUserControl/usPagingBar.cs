using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WahooV2.WahooUserControl
{
    public partial class usPagingBar : UserControl
    {
        private const string strNameFist = "btnFirst";
        private const string strNameLast = "btnLast";
        private const string strNameNext = "btnNext";
        private const string strNamePrevious = "btnPrevious";
        public delegate void getSelectPagebyUser(object sender, EventArgs e);
        public event getSelectPagebyUser selectedPagebyUser;
        private int _allPage;


        public int iPageSelect = 1;

        public usPagingBar()
        {
            InitializeComponent();
        }

        private void usPagingBar_Load(object sender, EventArgs e)
        {

        }

        public void ResetAllControl()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn10.Enabled = true;
            btnFirst.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;

        }

        public void setActiveControl(int iAllPageNum, int iCurrPage)
        {
            _allPage = iAllPageNum;
            ResetAllControl();
            setUnCurrentPage();
            //neu la la it hon 10 page thi hien thi tat cac cac nut la disable 1 nut hai ben
            if (iAllPageNum <= 10)
            {
                //diable 4 nut hai ben
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
            }
            //set page hien tai
            setCurrentpage(btn1, iCurrPage, iAllPageNum);
            //set value cho control
            for (int i = 0; i < iAllPageNum; i++)
            {
                setValuetoControl("btn" + i.ToString(), i);
            }
            btnFirst.Tag = 1;
            btnLast.Tag = iAllPageNum;
            btnNext.Tag = iCurrPage + 1;
            btnPrevious.Tag = iCurrPage - 1;
            btnFirst.ToolTipText = Convert.ToString(1);
            btnNext.ToolTipText = Convert.ToString(iCurrPage + 1);
            btnLast.ToolTipText = Convert.ToString(iAllPageNum);
            btnPrevious.ToolTipText = (iCurrPage == 0) ? Convert.ToString(iCurrPage - 1) : Convert.ToString(iCurrPage);
        }

        private void setUnCurrentPage()
        {
            btn1.Checked = false;
            btn2.Checked = false;
            btn3.Checked = false;
            btn4.Checked = false;
            btn5.Checked = false;
            btn6.Checked = false;
            btn7.Checked = false;
            btn8.Checked = false;
            btn9.Checked = false;
            btn10.Checked = false;
            btnFirst.Checked = false;
            btnLast.Checked = false;
            btnNext.Checked = false;
            btnPrevious.Checked = false;
        }

        private void setCurrentpage(ToolStripButton ctrl, int currpage, int allPage)
        {
            ResetAllControl();
            setUnCurrentPage();
            if (!ctrl.Name.Equals(strNameFist) && !ctrl.Name.Equals(strNameLast) && !ctrl.Name.Equals(strNameNext) && !ctrl.Name.Equals(strNamePrevious))
            {
                ctrl.Checked = true;
            }
            else
            {
                //if (!ctrl.Name.Equals(strNameNext) && !ctrl.Name.Equals(strNamePrevious))
                // {
                //   btn1.Checked = true;
                // }
            }
            //if (ctrl.Name.Equals(strNameNext) || ctrl.Name.Equals(strNamePrevious))
            //{

            //    int temp = Convert.ToInt32(ctrl.Tag);
            //    foreach (ToolStripButton item in toolStrip1.Items)
            //    {
            //        if (ctrl.Tag.Equals(allPage))
            //        {
            //            continue;
            //        }
            //        if (item.Tag.Equals(currpage))
            //        {
            //            setValuetoControl(currpage);
            //        }
            //    }
            //}
            //page hien tai la 1 thi hai nut ben trai disable
            if (currpage.Equals(1))
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            //page hien tai la all page thi hai nut ben phai disable
            if (currpage.Equals(allPage))
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }

        }

        private void setCurrentpage(int value)
        {
            ResetAllControl();
            setUnCurrentPage();
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (!item.Name.Equals(strNameFist) && !item.Name.Equals(strNameLast) && !item.Name.Equals(strNameNext) && !item.Name.Equals(strNamePrevious))
                {
                    if (item.Tag.Equals(value))
                    {
                        item.Checked = true;
                    }
                }
            }
            if (value.Equals(1))
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            //page hien tai la all page thi hai nut ben phai disable
            if (value.Equals(_allPage))
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            setValuetoControl(btnNext.Name, value + 1);
            setValuetoControl(btnPrevious.Name, value - 1);
        }

        private void setValuetoControl(string ctrlname, int iPageValue)
        {
            if (iPageValue > _allPage)
            {
                return;
            }
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

        private void btn1_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn1);
            MoveSelected(sender, e, btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn2);
            MoveSelected(sender, e, btn2);
        }

        private int getselectPage(object sender, EventArgs e, ToolStripButton ctrl)
        {
            int temp = WahooConfiguration.DataTypeProtect.ProtectInt32(ctrl.Tag);
            selectedPagebyUser(sender, e);
            return temp;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn3);
            MoveSelected(sender, e, btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn4);
            MoveSelected(sender, e, btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn5);
            MoveSelected(sender, e, btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn6);
            MoveSelected(sender, e, btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn7);
            MoveSelected(sender, e, btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btn8);
            MoveSelected(sender, e, btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            MoveSelected(sender, e, btn9);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            MoveSelected(sender, e, btn10);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            moveNext(sender, e, btnNext);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btnLast);
            moveLast(sender, e, btnLast);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //iPageSelect = getselectPage(sender, e, btnFirst);
            moveFirst(sender, e, btnFirst);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            movePrevious(sender, e, btnPrevious);
        }

        private void moveNext(object sender, EventArgs e, ToolStripButton ctrl)
        {
            if (_allPage > 10)
            {
                int iSectionPage = iPageSelect;//= (_allPage % 10) - (_allPage / 10); 
                iPageSelect = getselectPage(sender, e, ctrl);
                if (WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) + 1 <= _allPage)
                {
                    setValuetoControl(btnPrevious.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 1);
                    setValuetoControl(btn1.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) + 1);
                    setValuetoControl(btn2.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn2.Tag) + 1);
                    setValuetoControl(btn3.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn3.Tag) + 1);
                    setValuetoControl(btn4.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn4.Tag) + 1);
                    setValuetoControl(btn5.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn5.Tag) + 1);
                    setValuetoControl(btn6.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn6.Tag) + 1);
                    setValuetoControl(btn7.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn7.Tag) + 1);
                    setValuetoControl(btn8.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn8.Tag) + 1);
                    setValuetoControl(btn9.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn9.Tag) + 1);
                    setValuetoControl(btn10.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) + 1);
                    setValuetoControl(btnNext.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag) + 1);
                    setCurrentpage(iPageSelect);
                }
                else
                {
                    setCurrentpage(iPageSelect);
                }
            }
            //setCurrentpage(btnNext, iPageSelect , _allPage);
        }

        private void movePrevious(object sender, EventArgs e, ToolStripButton ctrl)
        {
            if (_allPage > 10)
            {
                int iSectionPage = iPageSelect;
                iPageSelect = getselectPage(sender, e, ctrl);
                if (WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) - 1 >= 1)
                {
                    setValuetoControl(btnPrevious.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnPrevious.Tag) - 1);
                    setValuetoControl(btn1.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn1.Tag) - 1);
                    setValuetoControl(btn2.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn2.Tag) - 1);
                    setValuetoControl(btn3.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn3.Tag) - 1);
                    setValuetoControl(btn4.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn4.Tag) - 1);
                    setValuetoControl(btn5.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn5.Tag) - 1);
                    setValuetoControl(btn6.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn6.Tag) - 1);
                    setValuetoControl(btn7.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn7.Tag) - 1);
                    setValuetoControl(btn8.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn8.Tag) - 1);
                    setValuetoControl(btn9.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn9.Tag) - 1);
                    setValuetoControl(btn10.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btn10.Tag) - 1);
                    setValuetoControl(btnNext.Name, WahooConfiguration.DataTypeProtect.ProtectInt32(btnNext.Tag) - 1);
                    setCurrentpage(iPageSelect);
                }
                else
                {
                    setCurrentpage(iPageSelect);
                }
            }

        }

        private void moveFirst(object sender, EventArgs e, ToolStripButton ctrl)
        {
            getselectPage(sender, e, ctrl);
            setActiveControl(_allPage, 1);

        }

        private void moveLast(object sender, EventArgs e, ToolStripButton ctrl)
        {
            getselectPage(sender, e, ctrl);
            setValuetoControl(btnPrevious.Name, _allPage - 10);
            setValuetoControl(btn1.Name, _allPage - 9);
            setValuetoControl(btn2.Name, _allPage - 8);
            setValuetoControl(btn3.Name, _allPage - 7);
            setValuetoControl(btn4.Name, _allPage - 6);
            setValuetoControl(btn5.Name, _allPage - 5);
            setValuetoControl(btn6.Name, _allPage - 4);
            setValuetoControl(btn7.Name, _allPage - 3);
            setValuetoControl(btn8.Name, _allPage - 2);
            setValuetoControl(btn9.Name, _allPage - 1);
            setValuetoControl(btn10.Name, _allPage);
            setValuetoControl(btnNext.Name, _allPage);
            setCurrentpage(_allPage);
        }

        private void MoveSelected(object sender, EventArgs e, ToolStripButton ctrl)
        {
            iPageSelect = getselectPage(sender, e, ctrl);
            setCurrentpage(iPageSelect);
        }
    }
}

