using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public  class TableInfo
    {
        private string tablename;
        private StringBuilder columns = new StringBuilder ();
        private StringBuilder values = new StringBuilder ();
        private StringBuilder newvalue = new StringBuilder ();
        private StringBuilder pkcolumns = new StringBuilder ();

        private StringBuilder likeFieldValues = new StringBuilder();
        private StringBuilder likeFieldName = new StringBuilder();
        private ArrayList _ID = new ArrayList();

        public TableInfo()
        { }

        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }            
        }

        public StringBuilder Columns
        {
            get { return columns; }
            set { columns = value;}
        }

        public StringBuilder Values
        {
            get { return values; }
            set { values = value; }
        }

        public StringBuilder NewValue
        {
            get { return newvalue; }
            set { newvalue =  value; }            
        }

        public StringBuilder PKColumns
        {
            get { return pkcolumns; }
            set { pkcolumns = value; }            
        }

        public StringBuilder LikeFieldName
        {
            get { return likeFieldName; }
            set { likeFieldName = value; }
        }

        public StringBuilder LikeFieldValues
        {
            get { return likeFieldValues; }
            set { likeFieldValues = value; }
        }

        public ArrayList IDValue
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}