using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WahooData.DBO.Base
{
    public class ColumnAttribute : System.Attribute
    {
        string _columnName;
        int _columnLength;
        SqlDbType _columnType;

        private bool _isPrimaryKey = false;

        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }


        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }



        public int ColumnLength
        {
            get { return _columnLength; }
            set { _columnLength = value; }
        }

        public SqlDbType ColumnType
        {
            get { return _columnType; }
            set { _columnType = value; }
        }


        public ColumnAttribute(string columnName, SqlDbType columnType, int columnLength, bool isPrimaryKey)
        {
            this.ColumnLength = columnLength;
            this.ColumnName = columnName;
            this.ColumnType = columnType;
            this.IsPrimaryKey = isPrimaryKey;
        }

        public ColumnAttribute(string columnName, SqlDbType columnType, int columnLength)
        {
            this.ColumnLength = columnLength;
            this.ColumnName = columnName;
            this.ColumnType = columnType;
        }
    }

}
