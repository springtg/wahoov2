using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WahooData.DBO.Base
{
    public class TableAttribute : System.Attribute
    {
        private string _strTableName;

        public string TableName
        {
            get { return _strTableName; }
            set { _strTableName = value; }
        }


        public TableAttribute(string strTableName)
        {
            this.TableName = strTableName;
        }
    }
}
