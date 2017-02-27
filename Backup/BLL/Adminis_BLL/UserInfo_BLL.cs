using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class UserInfo_BLL
    {
        private static readonly IUserInfo factory = DALFactory.DataAccess.selectUserInfo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<UserInfo_MDL> selectUserInfo(int id,string colname, string coltext)
        {
            return factory.selectUserInfo(id,colname, coltext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static IList<UserInfo_MDL> selectUserInfo(string userid,string password)
        {
            return factory.selectUserInfo(userid,password);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<UserInfo_MDL> selectUserInfo(int id)
        {
            return factory.selectUserInfo(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo_MDL> selectUserInfo()
        {
            return factory.selectUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static IList<UserInfo_MDL> existsUserInfo(string userid)
        {
            return factory.existsUserInfo(userid);
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="deptid"></param>
        /// <param name="islock"></param>
        /// <param name="lastip"></param>
        /// <param name="aDate"></param>
        /// <param name="mDate"></param>
        public static int insertUserInfo(string userid, string username, string password, string sex, string email,
            string deptid, string groupid, string islock, string lastip, DateTime aDate, DateTime mDate)
        {
            return factory.insertUserInfo(userid, username, password, sex, email,deptid, groupid, islock, lastip, aDate, mDate);    
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="deptid"></param>
        /// <param name="islock"></param>
        /// <param name="lastip"></param>
        /// <param name="mDate"></param>
        public static int updateUserInfo(int id, string userid, string username, string password, string sex,
            string email, string deptid, string groupid, string islock, string lastip, DateTime mDate)
        {
            return factory.updateUserInfo(id, userid, username, password, sex, email, deptid,groupid, islock, lastip, mDate);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastip"></param>
        /// <param name="mDate"></param>
        public static int updateUserInfo(int id, string lastip, DateTime mDate)
        {
            return factory.updateUserInfo(id, lastip, mDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="new1"></param>
        public static int updateUserInfo(string userid, string new1)
        {
            return factory.updateUserInfo(userid, new1);
        }
        /// <summary>
        /// 单笔记录删除
        /// </summary>
        /// <param name="id"></param>
        public static void deleteUserInfo(int id)
        {
            factory.deleteUserInfo(id);
        }
        /// <summary>
        /// 批次记录删除
        /// </summary>
        /// <param name="idlist"></param>
        public static void cancelUserInfo(ArrayList idlist)
        {
            factory.cancelUserInfo(idlist);
        }
    }
}
