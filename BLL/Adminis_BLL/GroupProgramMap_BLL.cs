using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class GroupProgramMap_BLL
    {
        private static readonly IGroupProgramMap factory = Admin.DALFactory.DataAccess.selectGroupProgramMap();
        /// <summary>
        /// 初始,单笔,模糊查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<GroupProgramMap_MDL> selectGroupProgramMap(int _ID, string colname, string coltext)
        {
            return factory.selectGroupProgramMap(_ID, colname, coltext);
        }

        /// <summary>
        /// 判断是否存在相同的部门编号
        /// </summary>
        /// <param name="_GroupID"></param>
        /// <param name="_ProgramID"></param>
        /// <returns></returns>
        public static IList<GroupProgramMap_MDL> existsGroupProgramMap(string _GroupID, string _ProgramID)
        {
            return factory.existsGroupProgramMap(_GroupID, _ProgramID);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static int ChangeGroupProgramMap(int _ID, string _GroupID, string _ProgramID, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag, DateTime _aDate, DateTime _mDate, string IU)
        {
            GroupProgramMap_MDL obj = new GroupProgramMap_MDL(_ID, _GroupID, _GroupID, _ProgramID, _ProgramID, _AddFlag, _CnlFlag, _MdyFlag, _QuyFlag, _PrtFlag, _ChkFlag, _aDate, _mDate);
            return factory.ChangeGroupProgramMap(obj, IU);
        }
        public static int ChangeGroupProgramMap(int _ID, string _GroupID, string _ProgramID, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag, string _ChkFlagNO, DateTime _aDate, DateTime _mDate, string IU)
        {
            GroupProgramMap_MDL obj = new GroupProgramMap_MDL(_ID, _GroupID, _GroupID, _ProgramID, _ProgramID, _AddFlag, _CnlFlag, _MdyFlag, _QuyFlag, _PrtFlag, _ChkFlag,_ChkFlagNO, _aDate, _mDate);
            return factory.ChangeGroupProgramMap(obj, IU);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="_ID"></param>
        public static void deleteGroupProgramMap(int _ID)
        {
            factory.deleteGroupProgramMap(_ID);
        }

        /// <summary>
        /// 多笔记录删除
        /// </summary>
        /// <param name="_IDList"></param>
        public static void cancelGroupProgramMap(ArrayList _IDList)
        {
            factory.cancelGroupProgramMap(_IDList);
        }

    }
}
