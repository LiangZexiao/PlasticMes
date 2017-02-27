using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class EventInfo
    {
        private int id;
        private string eventname;
        private string remark;

        public EventInfo() { }

        public EventInfo(int id,string eventname,string remark) 
        {
            this.id = id;
            this.eventname = eventname;
            this.remark = remark;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Eventname
        {
            get { return eventname; }
            set { eventname = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
