using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface IGroupInfo
    {
        IList<GroupInfo_MDL> selectGroupInfo();
        IList<GroupInfo_MDL> selectGroupInfo(int id);
        IList<GroupInfo_MDL> selectGroupInfo(int id, string colname, string coltext);
        IList<GroupInfo_MDL> selectGroupInfo(int id, string colname, string coltext,int t);
        IList<GroupInfo_MDL> existsGroupInfo(string GroupID);
        int ChangeGroupInfo(GroupInfo_MDL obj , string IU);
        int deleteGroupInfo(int ID);
        int cancelGroupInfo(ArrayList IDlist);
    }
}
