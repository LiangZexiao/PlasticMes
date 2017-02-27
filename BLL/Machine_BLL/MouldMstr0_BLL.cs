using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Machine_MDL;
using Admin.SQLServerDAL.Machine;
using Admin.IDAL.Machine_IDAL;

namespace Admin.BLL.Machine_BLL
{
    public class MouldMstr0_BLL
    {
        private static readonly IMouldMstr0 factory = Admin.DALFactory.DataAccess.selectMouldMstr0();
        public static IList<MouldMstr0_MDL> selectMouldMstr(int id, string colname, string coltext)
        {
            return factory.selectMouldMstr(id, colname, coltext);
        }

        public static IList<MouldMstr0_MDL> existsMouldMstr(string Mould_Code, string ProductNo)
        {
            return factory.existsMouldMstr(Mould_Code, ProductNo);
        }

        public static void insertMouldMstr(
             string vMould_Code, string vMould_Name_CN, string vMould_Name_EN, string vMould_Type, string vFitMachineTonMin, string vFitMachineTonMax,
             string vProductNo, string vSocketNum, string vGoodSocketNum,
            
             string vMould_Group, string vMould_Manufacturer, string vMould_MadeDate,
             string vMould_RackNo, string vMould_Price, string vMould_MaintenaneCycle, string vMould_ChgTime, string vMould_ChgCost,
             byte[] vMould_Photo, object vMould_PhotoType, string vMemo)

        {
            factory.insertMouldMstr(
             vMould_Code, vMould_Name_CN, vMould_Name_EN, vMould_Type, vFitMachineTonMin, vFitMachineTonMax,
             vProductNo, vSocketNum, vGoodSocketNum,             
             vMould_Group, vMould_Manufacturer, vMould_MadeDate,
             vMould_RackNo, vMould_Price, vMould_MaintenaneCycle, vMould_ChgTime, vMould_ChgCost,
             vMould_Photo, vMould_PhotoType, vMemo);
        }

        public static void updateMouldMstr(int vID,
             string vMould_Code, string vMould_Name_CN, string vMould_Name_EN, string vMould_Type, string vFitMachineTonMin, string vFitMachineTonMax,
             string vProductNo, string vSocketNum, string vGoodSocketNum,

             string vMould_Group, string vMould_Manufacturer, string vMould_MadeDate,
             string vMould_RackNo, string vMould_Price, string vMould_MaintenaneCycle, string vMould_ChgTime, string vMould_ChgCost,
             byte[] vMould_Photo, object vMould_PhotoType, string vMemo)
        {
            factory.updateMouldMstr(vID,
             vMould_Code, vMould_Name_CN, vMould_Name_EN, vMould_Type, vFitMachineTonMin, vFitMachineTonMax,
             vProductNo, vSocketNum, vGoodSocketNum,
             vMould_Group, vMould_Manufacturer, vMould_MadeDate,
             vMould_RackNo, vMould_Price, vMould_MaintenaneCycle, vMould_ChgTime, vMould_ChgCost,
             vMould_Photo, vMould_PhotoType, vMemo);
        }

        public static void deleteMouldMstr(int _ID)
        {
            factory.deleteMouldMstr(_ID);
        }

        public static void cancelMouldMstr(ArrayList _IDList)
        {
            factory.cancelMouldMstr(_IDList);
        }
    }
}
