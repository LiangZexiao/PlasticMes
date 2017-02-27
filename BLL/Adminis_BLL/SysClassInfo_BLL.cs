using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;
using Admin.IDAL.Adminis_IDAL;

namespace Admin.BLL.Adminis_BLL
{
    public class SysClassInfo_BLL
    {
        private static readonly ISysClassInfo factory = Admin.DALFactory.DataAccess.selectSysClassInfo();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<SysClassInfo_MDL> selectSysClassInfo(int _ID, string colname, string coltext)
        {
            return factory.selectSysClassInfo(_ID, colname, coltext);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static IList<SysClassInfo_MDL> selectSysClassInfo(string userid)
        {
            return factory.selectSysClassInfo(userid);
        }

        /// <summary>
        /// 判断是否存在相同的系统类别编号
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static IList<SysClassInfo_MDL> existsSysClassInfo(string classid)
        {
            return factory.existsSysClassInfo(classid);
        }

        /// <summary>
        /// 新增一个系统类别
        /// </summary>
        /// <param name="_classid"></param>
        /// <param name="_classname"></param>
        /// <param name="_remark"></param>
        public static void insertSysClassInfo(string _classid, string _classname, string _remark)
        {
            factory.insertSysClassInfo(_classid, _classname, _remark);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_classid"></param>
        /// <param name="_classname"></param>
        /// <param name="_remark"></param>
        public static void updateSysClassInfo(int _id, string _classid, string _classname, string _remark)
        {
            factory.updateSysClassInfo(_id, _classid, _classname, _remark);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="_id"></param>
        public static void deleteSysClassInfo(int _id)
        {
            factory.deleteSysClassInfo(_id);
        }

        /// <summary>
        /// 批次删除
        /// </summary>
        /// <param name="_idlist"></param>
        public static void cancelSysClassInfo(ArrayList _idlist)
        {
            factory.cancelSysClassInfo(_idlist);
        }
    }
}
