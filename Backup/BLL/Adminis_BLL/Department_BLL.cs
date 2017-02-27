using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class Department_BLL
    {
        private static readonly IDepartment  factory = Admin.DALFactory.DataAccess.selectDepartment();

        /// <summary>
        /// 初始,单笔,模糊查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<Department_MDL> selectDepartment(int _ID, string colname, string coltext)
        {
            return factory.selectDepartment(_ID, colname, coltext);
        }

        /// <summary>
        /// 判断是否存在相同的部门编号
        /// </summary>
        /// <param name="_DeptID"></param>
        /// <returns></returns>
        public static IList<Department_MDL> existsDepartment(string _DeptID)
        {
            return factory.existsDepartment(_DeptID);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_DeptName"></param>
        /// <param name="_Manger"></param>
        /// <param name="_Remark"></param>
        public static void ChangeDepartment(int _ID, string _DeptID, string _DeptName, string _Manger, string _Remark, string IU)
        {
            Department_MDL obj = new Department_MDL(_ID, _DeptID, _DeptName, _Manger, _Remark);
            factory.ChangeDepartment(obj, IU);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="_ID"></param>
        public static void deleteDepartment(int _ID)
        {
            factory.deleteDepartment(_ID);
        }

        /// <summary>
        /// 多笔记录查询
        /// </summary>
        /// <param name="_IDList"></param>
        public static void cancelDepartment(ArrayList _IDList)
        {
            factory.cancelDepartment(_IDList);
        }
    }
}
