using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class RightInfo
    {
        private int id;
        private int eventid;
        private string requesturl;
        private int classid;
        private string programid;
        private string remark;
        private DateTime createdate;
        private DateTime updatedate;
        private string eventname;
        private string classname;

        public RightInfo() { }

        public RightInfo(int id,
            int eventid,
            string requesturl,
            int classid,
            string programid,
            string remark,
            DateTime createdate,
            DateTime updatedate)
        {
            this.id = id;
            this.eventid = eventid;
            this.requesturl = requesturl;
            this.classid = classid;
            this.programid = programid;
            this.remark = remark;
            this.createdate = createdate;
            this.updatedate = updatedate;
        }

        public RightInfo(int id,
            int eventid,
            string requesturl,
            int classid,
            string programid,
            string remark,
            DateTime createdate,
            DateTime updatedate,
            string eventname,
            string classname)
        {
            this.id = id;
            this.eventid = eventid;
            this.requesturl = requesturl;
            this.classid = classid;
            this.programid = programid;
            this.remark = remark;
            this.createdate = createdate;
            this.updatedate = updatedate;
            this.eventname = eventname;
            this.classname = classname;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int Eventid
        {
            get { return eventid; }
            set { eventid = value; }
        }
        public string Requesturl
        {
            get { return requesturl; }
            set { requesturl = value; }
        }
        public int Classid
        {
            get { return classid; }
            set { classid = value; }
        }

        public string ProgramID
        {
            get { return programid; }
            set { programid = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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

        public string Eventname
        {
            get { return eventname; }
            set { eventname = value; }
        }
        public string Classname
        {
            get { return classname; }
            set { classname = value; }
        }
    }
}
