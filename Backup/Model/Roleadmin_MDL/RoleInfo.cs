using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    public class RoleInfo
    {
        private int id;
        private string rolename;

        public RoleInfo() { }

        public RoleInfo(int id,string rolename) 
        {
            this.id = id;
            this.rolename = rolename;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Rolename
        {
            get { return rolename; }
            set { rolename = value; }
        }
    }
}
