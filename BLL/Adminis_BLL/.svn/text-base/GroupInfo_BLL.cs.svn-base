using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class GroupInfo_BLL
    {
        private static readonly IGroupInfo factory = Admin.DALFactory.DataAccess.selectGroupInfo();

        /// <summary>
        /// 初始,单笔,模糊查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<GroupInfo_MDL> selectGroupInfo(int _ID, string colname, string coltext)
        {
            return factory.selectGroupInfo(_ID, colname, coltext);
        }
        /// <summary>
        /// 初始,单笔,模糊查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<GroupInfo_MDL> selectGroupInfo(int _ID, string colname, string coltext,int t)
        {
            return factory.selectGroupInfo(_ID, colname, coltext,t);
        }
        /// <summary>
        /// 判断是否存在相同的群组编号
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public static IList<GroupInfo_MDL> existsGroupInfo(string GroupID)
        {
            return factory.existsGroupInfo(GroupID);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static int ChangeGroupInfo(int ID, string GroupID, string GroupName, string Header, string Action,
            int MemberNum, string Remark, string IU)
        {
            GroupInfo_MDL obj = new GroupInfo_MDL(ID, GroupID, GroupName, Header, Action, MemberNum, Remark, DateTime.Now, DateTime.Now);
           return  factory.ChangeGroupInfo(obj, IU);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="_ID"></param>
        public static int deleteGroupInfo(int ID)
        {
            return factory.deleteGroupInfo(ID);
        }

        /// <summary>
        /// 多笔记录删除
        /// </summary>
        /// <param name="_IDList"></param>
        public static int cancelGroupInfo(ArrayList IDList)
        {
            return factory.cancelGroupInfo(IDList);
        }
    }
}
