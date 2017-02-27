using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.BaseInfo_MDL;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.BLL.BaseInfo_BLL
{
    public class Employee_BLL
    {
        private static readonly IEmployeeInfo factory = Admin.DALFactory.DataAccess.selectEmployeeInfo();
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<Employee_MDL> selectEmployee(int _ID, string colname, string coltext)
        {
            return factory.selectEmployee(_ID, colname, coltext);
        }
        public static DataTable selectEmployee(string colname, string coltext)
        {
            return factory.selectEmployee(colname, coltext);
        }
        public static IList<Employee_MDL> selectEmployee(int _ID, string colname, string coltext,bool flag)
        {
            return factory.selectEmployee(_ID, colname, coltext,flag);
        }

        /// <summary>
        /// 判断是否存在相同的员工编号
        /// </summary>
        /// <param name="_EmployeeID"></param>
        /// <returns></returns>
        public static IList<Employee_MDL> existsEmployee(string _EmployeeID)
        {
            return factory.existsEmployee(_EmployeeID);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="EmployeeID"></param>
        /// <param name="Name_CN"></param>
        /// <param name="Name_EN"></param>
        /// <param name="Photo"></param>
        /// <param name="PhotoType"></param>
        /// <param name="IDCardNo"></param>
        /// <param name="Sex"></param>
        /// <param name="Birthday"></param>
        /// <param name="Department"></param>
        /// <param name="Province"></param>
        /// <param name="Rank"></param>
        /// <param name="RankDesc"></param>
        /// <param name="HireDate"></param>
        /// <param name="Memo"></param>
        public static int ChangeEmployee(int ID, string EmployeeID, string Name_CN, string Name_EN, byte[] Photo, object PhotoType,
            string IDCardNo, string Sex, DateTime Birthday, string Department, string Province, string RankLevel, string Rank,
            string RankDesc, DateTime HireDate, string Memo, string Tel,string EMail,string Valid, string IU)
        {
            Employee_MDL obj = new Employee_MDL(ID, EmployeeID, Name_CN,  Photo,  IDCardNo, Sex, Birthday.ToString(), Department, Department,
                Province, RankLevel, Rank, RankDesc, HireDate.ToString(), Tel, Memo, EMail,Valid);
            return factory.ChangeEmployee(obj, IU);
        }

        /// <summary>
        /// 删除单笔记录
        /// </summary>
        /// <param name="_id"></param>
        public static void deleteEmployee(int _id)
        {
            factory.deleteEmployee(_id);
        }

        /// <summary>
        /// 批次删除记录
        /// </summary>
        /// <param name="_idlist"></param>
        public static void cancelEmployee(ArrayList _idlist)
        {
            factory.cancelEmployee(_idlist);
        }
    }
}
