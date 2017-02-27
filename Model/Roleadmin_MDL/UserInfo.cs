using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class UserInfo
    {
        private int id;
        private string username;
        private string password;
        private string realname;
        private string sex;
        private int  deptid;
        private string email;
        private string lastip;
        private int  islock;
        private DateTime createdate;
        private DateTime updatedate;

        public UserInfo(){}
        public UserInfo(int id,string username,string password,string realname,string sex,int deptid,string email,string lastip,int islock,DateTime createdate,DateTime updatedate)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.realname = realname;
            this.sex = sex;
            this.deptid = deptid;
            this.email = email;
            this.lastip = lastip;
            this.islock = islock;
            this.createdate = createdate;
            this.updatedate = updatedate;
        }

        public int ID
        {
            get { return id;}
            set { id = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Realname
        {
            get { return realname; }
            set { realname = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Deptid
        {
            get { return deptid; }
            set { deptid = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Lastip
        {
            get { return lastip; }
            set { lastip = value; }
        }
        public int Islock
        {
            get { return islock; }
            set { islock = value; }
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
