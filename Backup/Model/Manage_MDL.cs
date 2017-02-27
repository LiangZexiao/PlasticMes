using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class Manage_MDL
    {
        private string _ClassId;

        private string _ClassName;

        public Manage_MDL()
        {
        }
        public Manage_MDL(string vclassid,string vclassname)
        {
            this._ClassId = vclassid;
            this._ClassName = vclassname;
        }

        public string ClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; }
        }

        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }
    }
}
