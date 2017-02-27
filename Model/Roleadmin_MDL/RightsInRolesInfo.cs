using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class RightsInRolesInfo
    {
        private int roleid;
        private int right;

        public RightsInRolesInfo() { }
        public RightsInRolesInfo(int roleid,int right)
        {
            this.roleid = roleid;
            this.right = right;
        }
        public int Roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }
        public int Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
