using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class BMClassInfo
    {
        private int id;
        private string classname;

        public BMClassInfo() { }
        public BMClassInfo(int id,string classname)
        {
            this.id = id;
            this.classname = classname;
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
    }
}
