using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class UserRightleftInfo
    {
        private int id;
        private int rightid;
        private string requesturl;
        private string remark;
        private string classname;
        private string eventname;

        public UserRightleftInfo() { }
        public UserRightleftInfo(string requesturl,string remark) 
        {
            this.requesturl = requesturl;
            this.remark = remark;
        }
        public UserRightleftInfo(int id,int rightid,string requesturl,string remark,string classname,string eventname)
        {
            this.id = id;
            this.rightid = rightid;
            this.requesturl = requesturl;
            this.remark = remark;
            this.classname = classname;
            this.eventname = eventname;

        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int Rightid
        {
            get { return rightid; }
            set { rightid = value; }
        }
        public string Requesturl
        {
            get { return requesturl; }
            set { requesturl = value; }
        }
        public string Remark
        {
            get { return remark;}
            set { remark = value; }
        }
        public string Classname
        {
            get { return classname; }
            set { classname = value; }
        }
        public string Eventname
        {
            get { return eventname; }
            set { eventname = value; }
        }

    }
}
