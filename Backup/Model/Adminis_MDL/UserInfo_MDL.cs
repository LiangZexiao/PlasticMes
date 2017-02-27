using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Adminis_MDL
{
    public class UserInfo_MDL
    {
        //ID, UserID, UserName, Password, Sex, Email, DeptID, IsLock, LastIP, aDate, mDate, cDate
        private int id;
        private ArrayList idlist;
        private string userid;
        private string username;
        private string employeename_cn;
        private string password;
        private string sex;
        private string email;
        private string deptid;
        private string groupid;
        private string islock;
        private string lastip;
        private string aDate;
        private string mDate;
        private string cDate;
        private string deptName;
        private string groupName;

      
        public UserInfo_MDL(){}
        public UserInfo_MDL(ArrayList idlist) { this.idlist = idlist; }
        public UserInfo_MDL(int id,string userid,string username,string name_cn,string password,string sex,string email,
            string deptid, string groupid, string islock, string lastip, string aDate, string mDate, string cDate)
        {
                this.id = id;
                this.userid = userid;
                this.username = username;
                this.employeename_cn = name_cn;
                this.password = password;
                this.sex = sex;
                this.email = email;
                this.deptid = deptid;
                this.groupid = groupid;
                this.islock = islock;
                this.lastip = lastip;
                this.aDate = aDate;
                this.mDate = mDate;
                this.cDate = cDate;
        }
        public UserInfo_MDL(int id, string userid, string username, string name_cn, string password, string sex, string email,
            string deptid, string groupid, string islock, string lastip, string aDate, string mDate, string cDate, string vdeptName, string vgroupName)
        {
            this.id = id;
            this.userid = userid;
            this.username = username;
            this.employeename_cn = name_cn;
            this.password = password;
            this.sex = sex;
            this.email = email;
            this.deptid = deptid;
            this.groupid = groupid;
            this.islock = islock;
            this.lastip = lastip;
            this.aDate = aDate;
            this.mDate = mDate;
            this.cDate = cDate;
            this.deptName = vdeptName;
            this.groupName = vgroupName;
        }

        public int ID
        {
            get { return id;}
            set { id = value; }
        }
        public ArrayList IDList
        {
            get { return idlist; }
            set { idlist = value; }
        }
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string Employeename_cn
        {
            get { return employeename_cn; }
            set { employeename_cn = value; }
        }
        //public string Name_CN
        //{
        //    get { return this.name_cn; }
        //    set { this.name_cn = value; }
        //}

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string DeptID
        {
            get { return deptid; }
            set { deptid = value; }
        }
        public string GroupID
        {
            get { return groupid; }
            set { groupid = value; }
        }        
        public string Islock
        {
            get { return islock; }
            set { islock = value; }
        }
        public string LastIP
        {
            get { return lastip; }
            set { lastip = value; }
        }

        public string ADate
        {
            get { return aDate; }
            set { aDate = value; }
        }
        public string MDate
        {
            get { return mDate; }
            set { mDate = value; }
        }
        public string CDate
        {
            get { return cDate; }
            set { cDate = value; }
        }
        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
    }
}
