using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface IUserInfo
    {
        IList<UserInfo_MDL> selectUserInfo();
        IList<UserInfo_MDL> selectUserInfo(int id);
        IList<UserInfo_MDL> selectUserInfo(string userid, string password);
        IList<UserInfo_MDL> selectUserInfo(int id,string colname, string coltext);
        IList<UserInfo_MDL> existsUserInfo(string userid);
        int insertUserInfo(string userid, string username, string password, string sex, string email,
            string deptid, string groupid, string islock, string lastip, DateTime aDate, DateTime mDate);
        int updateUserInfo(int id, string userid, string username, string password, string sex, string email,
            string deptid,string groupid, string islock, string lastip, DateTime mDate);
        int updateUserInfo(int id, string lastip, DateTime mDate);
        int updateUserInfo(string userid, string new1);
        void deleteUserInfo(int id);
        void cancelUserInfo(ArrayList idlist);
    }
}
