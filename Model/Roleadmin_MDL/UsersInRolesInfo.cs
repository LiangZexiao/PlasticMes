using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class UsersInRolesInfo
    {
        private int userid;
        private int roleid;

        public UsersInRolesInfo() { }
        public UsersInRolesInfo(int userid,int roleid)
        {
            this.userid = userid;
            this.roleid = roleid;
        }
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        public int Roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }
    }
}
