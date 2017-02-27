using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;

namespace Admin.IDAL.Machine_IDAL
{
    public interface IMouldMstr0
    {
        IList<MouldMstr0_MDL> selectMouldMstr(int id, string colname, string coltext);
        IList<MouldMstr0_MDL> existsMouldMstr(string Mould_Code, string IncludeProduct1);
        void insertMouldMstr(
             string vMould_Code, string vMould_Name_CN, string vMould_Name_EN, string vMould_Type, string vFitMachineTonMin, string vFitMachineTonMax,
             string vProductNo, string vSocketNum, string vGoodSocketNum,
            
             string vMould_Group, string vMould_Manufacturer, string vMould_MadeDate,
             string vMould_RackNo, string vMould_Price, string vMould_MaintenaneCycle, string vMould_ChgTime, string vMould_ChgCost,
             byte[] vMould_Photo, object vMould_PhotoType, string vMemo);
        void updateMouldMstr(int vID,
             string vMould_Code, string vMould_Name_CN, string vMould_Name_EN, string vMould_Type, string vFitMachineTonMin, string vFitMachineTonMax,
             string vProductNo, string vSocketNum, string vGoodSocketNum,

             string vMould_Group, string vMould_Manufacturer, string vMould_MadeDate,
             string vMould_RackNo, string vMould_Price, string vMould_MaintenaneCycle, string vMould_ChgTime, string vMould_ChgCost,
             byte[] vMould_Photo, object vMould_PhotoType, string vMemo);
        void deleteMouldMstr(int _ID);
        void cancelMouldMstr(ArrayList _IDList);
    }
}
