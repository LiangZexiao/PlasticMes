using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class SysProgramInfo_BLL
    {
        private static readonly ISysProgramInfo factory = Admin.DALFactory.DataAccess.selectProgramInfo();

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static IList<ProgramInfo_MDL> selectProgramInfo(string userid,string classid)
        {
            return factory.selectProgramInfo(userid, classid);
        }

        /// <summary>
        /// 初始,单笔,模糊查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<ProgramInfo_MDL> selectProgramInfo(int _ID, string colname, string coltext)
        {
            return factory.selectProgramInfo(_ID, colname, coltext);
        }

        /// <summary>
        /// 查询是否存在相同的主键值
        /// </summary>
        /// <param name="_ProgramID"></param>
        /// <returns></returns>
        public static IList<ProgramInfo_MDL> existsProgramInfo(string _ProgramID)
        {
            return factory.existsProgramInfo(_ProgramID);
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static void insertProgramInfo(string _ProgramID, string _ProgramName, string _RequestURL, string _ClassID,
            string _OrderID, string Locked, DateTime _aDate, DateTime _mDate)
        {
            factory.insertProgramInfo(_ProgramID, _ProgramName, _RequestURL, _ClassID, _OrderID, Locked, _aDate, _mDate);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static void updateProgramInfo(int _ID, string _ProgramID, string _ProgramName, string _RequestURL, string _ClassID,
            string _OrderID, string _Locked, DateTime _mDate)
        {
            factory.updateProgramInfo(_ID, _ProgramID, _ProgramName, _RequestURL, _ClassID, _OrderID, _Locked, _mDate);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="_ID"></param>
        public static void deleteProgramInfo(int _ID)
        {
            factory.deleteProgramInfo(_ID);
        }

        /// <summary>
        /// 多笔记录删除
        /// </summary>
        /// <param name="_IDList"></param>
        public static void cancelProgramInfo(ArrayList _IDList)
        {
            factory.cancelProgramInfo(_IDList);
        }
    }
}
