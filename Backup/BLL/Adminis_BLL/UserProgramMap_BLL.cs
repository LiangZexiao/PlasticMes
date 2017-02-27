using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class UserProgramMap_BLL
    {
        private static readonly IUserProgramMap factory = Admin.DALFactory.DataAccess.selectUserProgramMap();
        /// <summary>
        /// 初始,单笔,模糊查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<UserProgramMap_MDL> selectUserProgramMap(int _ID, string colname, string coltext)
        {
            return factory.selectUserProgramMap(_ID, colname, coltext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_UserID"></param>
        /// <param name="_ProgramID"></param>
        /// <returns></returns>
        public static IList<UserProgramMap_MDL> existsUserProgramMap(string _UserID, string _ProgramID)
        {
            return factory.existsUserProgramMap(_UserID, _ProgramID);
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static void insertUserProgramMap(string _UserID, string _ProgramID, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag, DateTime _aDate, DateTime _mDate)            
        {
           //factory.insertUserProgramMap(_UserID, _ProgramID, _AddFlag, _CnlFlag, _MdyFlag, _QuyFlag, _PrtFlag, _ChkFlag, _aDate, _mDate);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static int ChangeUserProgramMap(int _ID, string _UserID, string _ProgramID, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag,string _ChkFlagNO ,DateTime _aDate, DateTime _mDate, string IU)
            
        {
            UserProgramMap_MDL obj = new UserProgramMap_MDL(
                _ID, _UserID, _ProgramID, _ProgramID, _AddFlag, _CnlFlag, _MdyFlag, _QuyFlag, _PrtFlag, _ChkFlag,_ChkFlagNO, _aDate.ToString(), _mDate.ToString()
                );
            return factory.ChangeUserProgramMap(obj, IU);
        }
        public static int ChangeUserProgramMap(int _ID, string _UserID, string _ProgramID, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag,   DateTime _aDate, DateTime _mDate, string IU)
        {
            UserProgramMap_MDL obj = new UserProgramMap_MDL(
                _ID, _UserID, _ProgramID, _ProgramID, _AddFlag, _CnlFlag, _MdyFlag, _QuyFlag, _PrtFlag, _ChkFlag,  _aDate.ToString(), _mDate.ToString()
                );
            return factory.ChangeUserProgramMap(obj, IU);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="_ID"></param>
        public static void deleteUserProgramMap(int _ID)
        {
            factory.deleteUserProgramMap(_ID);
        }
        /// <summary>
        /// 多笔记录查询
        /// </summary>
        /// <param name="_IDList"></param>
        public static void cancelUserProgramMap(ArrayList _IDList)
        {
            factory.cancelUserProgramMap(_IDList);
        }

    }
}
