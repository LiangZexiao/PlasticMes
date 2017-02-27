using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class RightclassInfo
    {
        private int id;
        private string classname;
        private DateTime createdate;
        private DateTime updatedate;

        public RightclassInfo() { }
        public RightclassInfo(int id,string classname,DateTime createdate,DateTime updatedate)
        {
            this.id = id;
            this.classname = classname;
            this.createdate = createdate;
            this.updatedate = updatedate;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Classname
        {
            get { return classname; }
            set { classname = value; }
        }
        public DateTime Createdate
        {
            get { return createdate; }
            set { createdate = value; }
        }
        public DateTime Updatedate
        {
            get { return updatedate; }
            set { updatedate = value; }
        }
    }
}
