using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;

namespace Admin.IDAL.Quality_IDAL
{
    public interface IQC_ThroughDefect
    {
        IList<QC_ThroughDefect_MDL> selectQCAdjust(int id, string colname, string coltext);
        int ChangeQCAdjust(int vID, string DispatchNo, string CardId, int QueLiaoNum, int HuaHenNum, int SeChaNum, int XiaCiNum,
            int QueJiaoNum, int SuoShuiNum, int BianXingNum, int LiaoHuaNum, int PiFengNum, int ChicunNum, int ShaoJiaoNum,
            int JiaWenNum, int KaiLieNum, int QiTaNum, string AdjustDate, string CreateDate, string EmpID, string bz, string IU);
        void deleteQCAdjust(int ID);
        void cancelQCAdjust(ArrayList _idlist);
        void checkQCAdjust_Vice(string strFlag, string strChecker, ArrayList _IDList);
    }
}
