using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;
using Admin.IDAL.Quality_IDAL;

namespace Admin.BLL.Quality_BLL
{
    public class QC_ThroughDefect_BLL
    {
        private static readonly IQC_ThroughDefect factory = Admin.DALFactory.DataAccess.selectQCAdjust();
        public static IList<QC_ThroughDefect_MDL> selectQCAdjust(int _ID, string colname, string coltext)
        {
            return factory.selectQCAdjust(_ID, colname, coltext);
        }
        public static int ChangeQCAdjust(int vID,
            string vDispatchNo, string vCardId, int vQueLiaoNum, int vHuaHenNum, int vSeChaNum, int vXiaCiNum, int vQueJiaoNum,
            int vSuoShuiNum, int vBianXingNum, int vLiaoHuaNum, int vPiFengNum, int vChicunNum,
            int vShaoJiaoNum, int vJiaWenNum, int vKaiLieNum, int vQiTaNum, string vAdjustDate, string vCreateDate, string vEmpID, string vbz, string IU)
        {
            return factory.ChangeQCAdjust(vID,
              vDispatchNo, vCardId, vQueLiaoNum, vHuaHenNum, vSeChaNum, vXiaCiNum,
              vQueJiaoNum, vSuoShuiNum, vBianXingNum, vLiaoHuaNum, vPiFengNum,
              vChicunNum, vShaoJiaoNum, vJiaWenNum, vKaiLieNum, vQiTaNum, vAdjustDate, vCreateDate, vEmpID,vbz, IU);
        }
        public static void deleteQCAdjust(int _id)
        {
            factory.deleteQCAdjust(_id);
        }
        public static void cancelQCAdjust(ArrayList _IDList)
        {
            factory.cancelQCAdjust(_IDList);
        }
        public static void checkQCAdjust_Vice(string strFlag, string strChecker, ArrayList _IDList)
        {
            factory.checkQCAdjust_Vice(strFlag, strChecker, _IDList);
        }
    }
}
