using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Machine_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.BLL.BaseInfo_BLL
{
    public class MouldDetail_BLL
    {
        private static readonly IMouldDetail factory = Admin.DALFactory.DataAccess.selectMouldDetail();
        public static IList<MouldDetail_MDL> selectMouldDetail()
        {
            return factory.selectMouldDetail();
        }

        public static IList<MouldDetail_MDL> selectMouldDetail(int id, string colname, string coltext)
        {
            return factory.selectMouldDetail(id, colname, coltext);
        }

        public static IList<MouldDetail_MDL> existsMouldDetail(string Mould_Code)
        {
            return factory.existsMouldDetail(Mould_Code);
        }

        public static void ChangeMouldDetail(int ID,
                string Mould_Code,string Mould_Desc,string Clip_Code,string Clip_Desc,string Clip_UsedNum,string GoodsNo,string Mould_SpecialFittingsNo,string Mould_Manufacturer,string Mould_MadeDate,
                string Mould_CopyRight,string SocketNum,string GoodSocketNum,string FitMachineG,string PositioningHoleDiameter,string RefBadRate,string LostMaterialRate,string InjectionCycle,string MinInjectionCycle,
                string MaxInjectionCycle,string MachineCycle,string Mould_InjectPress, string Mould_ShotTemp,string Mould_Lenght,string Mould_Width,string Mould_Thickth,string Mould_Weight,string Mould_PushDistance,string TemplateDistance,string TackOutFunction,
                string Robort,string RobortProgram,string ShotLenghten,string ProtectCycle,string MouldStatus,string WarehouseLocation,string ModiRecord,string LastModifier,string LastModiDate,string Ver,string Lu_law_Table,string Remark,
                string Mould_Soaked,string Mould_Fixture,string IU)
        {
            MouldDetail_MDL obj = new MouldDetail_MDL(ID,
                Mould_Code, Mould_Desc, Clip_Code, Clip_Desc, Clip_UsedNum, GoodsNo,Mould_SpecialFittingsNo, Mould_Manufacturer, Mould_MadeDate, Mould_CopyRight, SocketNum, GoodSocketNum, FitMachineG,
                PositioningHoleDiameter, RefBadRate, LostMaterialRate, InjectionCycle, MinInjectionCycle, MaxInjectionCycle, MachineCycle,Mould_InjectPress, Mould_ShotTemp, Mould_Lenght, Mould_Width, Mould_Thickth, Mould_Weight, Mould_PushDistance,
                TemplateDistance,TackOutFunction,Robort,RobortProgram,ShotLenghten,ProtectCycle,MouldStatus,WarehouseLocation,ModiRecord,LastModifier,LastModiDate,Ver,Lu_law_Table,Remark
                ,Mould_Soaked,Mould_Fixture);

            factory.updateMouldDetail(obj, IU);
        }

        public static void deleteMouldDetail(int _ID)
        {
            factory.deleteMouldDetail(_ID);
        }

        public static void cancelMouldDetail(ArrayList _IDList)
        {
            factory.cancelMouldDetail(_IDList);
        }
    }
}
