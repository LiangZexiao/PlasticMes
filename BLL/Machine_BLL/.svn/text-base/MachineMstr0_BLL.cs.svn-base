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
    public class MachineMstr0_BLL
    {
        private static readonly IMachineMstr0 factory = Admin.DALFactory.DataAccess.selectMachineMstr0();

        /// <summary>
        /// 查询出机器所在的位置
        /// </summary>
        /// <returns></returns>
        public static IList<MachineMstr0_MDL> selectMachineMstr()
        {
            return factory.selectMachineMstr();
        }
        /// <summary>
        /// 以机器所在的位置查询出机器的编号
        /// </summary>
        /// <param name="Machine_SeatCode"></param>
        /// <returns></returns>
        public static IList<MachineMstr0_MDL> selectMachineMstr(string Machine_SeatCode)
        {
            return factory.selectMachineMstr(Machine_SeatCode);
        }

        /// <summary>
        /// 查询机器的所有信息
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<MachineMstr0_MDL> selectMachineMstr(int _ID, string colname, string coltext)
        {
            return factory.selectMachineMstr(_ID, colname, coltext);
        }

        /// <summary>
        /// 判断是否存在相同的机器编号
        /// </summary>
        /// <param name="_MachineMstrID"></param>
        /// <returns></returns>
        public static IList<MachineMstr0_MDL> existsMachineMstr(string _MachineMstrID)
        {
            return factory.existsMachineMstr(_MachineMstrID);
        }

        /// <summary>
        /// 新增一台机器的信息
        /// </summary>
        /// <param name="Machine_Code"></param>
        /// <param name="Machine_NameCH"></param>
        /// <param name="Machine_NameEN"></param>
        /// <param name="Machine_Type"></param>
        /// <param name="Machine_Manufacturer"></param>
        /// <param name="Machine_Model"></param>
        /// <param name="Machine_Brand"></param>
        /// <param name="Machine_PurchaseDate"></param>
        /// <param name="Machine_MadeDate"></param>
        /// <param name="Machine_Power"></param>
        /// <param name="Machine_MouldCapacity"></param>
        /// <param name="Machine_MinLockPower"></param>
        /// <param name="Machine_MaxLockPower"></param>
        /// <param name="Machine_ShotQty"></param>
        /// <param name="Machine_MaintainCycle"></param>
        /// <param name="Machine_Price"></param>
        /// <param name="Machine_RentCost"></param>
        /// <param name="Machine_SeatCode"></param>
        /// <param name="Machine_MaterialChgTime"></param>
        /// <param name="Machine_MaterialChgCost"></param>
        /// <param name="Machine_MaterialChgAmt"></param>
        /// <param name="Machine_Photo"></param>
        /// <param name="Machine_PhotoType"></param>
        /// <param name="Bearings"></param>
        /// <param name="ScrewDiameter"></param>
        /// <param name="InjectionPress"></param>
        /// <param name="MachineVolume"></param>
        /// <param name="SerialNo"></param>
        /// <param name="TackOut"></param>
        /// <param name="Screw"></param>
        /// <param name="Robort"></param>
        /// <param name="Condition"></param>
        /// <param name="Note"></param>
        public static void insertMachineMstr(string Machine_Code, string Machine_NameCH, string Machine_NameEN, string Machine_Type,
            string Machine_Manufacturer, string Machine_Model, string Machine_Brand, DateTime Machine_PurchaseDate, DateTime Machine_MadeDate,
            string Machine_Power, string Machine_MouldCapacity, string Machine_MinLockPower, string Machine_MaxLockPower, string Machine_ShotQty,
            string Machine_MaintainCycle, string Machine_Price, string Machine_RentCost, string Machine_SeatCode, string Machine_MaterialChgTime,
            string Machine_MaterialChgCost, string Machine_MaterialChgAmt, byte[] Machine_Photo, object Machine_PhotoType, string Bearings,
            string ScrewDiameter, string InjectionPress, string MachineVolume, string SerialNo, string TackOut,
            string Screw, string Condition,
            string MinMouldThick, string MaxMouldThick, string LoadMouldMaxLenght, string LoadMouldMaxWidth, string PushDistance,
            string PushStress, string OpenMouldDistance,
            string Robort, string Note)
        {
            factory.insertMachineMstr(Machine_Code,Machine_NameCH,Machine_NameEN,Machine_Type,
           Machine_Manufacturer,Machine_Model,Machine_Brand, Machine_PurchaseDate, Machine_MadeDate,
           Machine_Power,Machine_MouldCapacity,Machine_MinLockPower,Machine_MaxLockPower,Machine_ShotQty,
           Machine_MaintainCycle,Machine_Price,Machine_RentCost,Machine_SeatCode,Machine_MaterialChgTime,
           Machine_MaterialChgCost,Machine_MaterialChgAmt, Machine_Photo, Machine_PhotoType,Bearings,
           ScrewDiameter,InjectionPress,MachineVolume,SerialNo,TackOut,
           Screw,Condition,
           MinMouldThick,MaxMouldThick,LoadMouldMaxLenght,LoadMouldMaxWidth,PushDistance,
           PushStress,OpenMouldDistance,
           Robort,Note);
        }

        public static void updateMachineMstr(int ID, string Machine_Code, string Machine_NameCH, string Machine_NameEN, string Machine_Type,
            string Machine_Manufacturer, string Machine_Model, string Machine_Brand, DateTime Machine_PurchaseDate, DateTime Machine_MadeDate,
            string Machine_Power, string Machine_MouldCapacity, string Machine_MinLockPower, string Machine_MaxLockPower, string Machine_ShotQty,
            string Machine_MaintainCycle, string Machine_Price, string Machine_RentCost, string Machine_SeatCode, string Machine_MaterialChgTime,
            string Machine_MaterialChgCost, string Machine_MaterialChgAmt, byte[] Machine_Photo, object Machine_PhotoType, string Bearings,
            string ScrewDiameter, string InjectionPress, string MachineVolume, string SerialNo, string TackOut,
            string Screw, string Condition,
            string MinMouldThick, string MaxMouldThick, string LoadMouldMaxLenght, string LoadMouldMaxWidth, string PushDistance,
            string PushStress, string OpenMouldDistance,
            string Robort, string Note)
        {
            factory.updateMachineMstr(ID,Machine_Code,Machine_NameCH,Machine_NameEN,Machine_Type,
                   Machine_Manufacturer,Machine_Model,Machine_Brand, Machine_PurchaseDate, Machine_MadeDate,
                   Machine_Power,Machine_MouldCapacity,Machine_MinLockPower,Machine_MaxLockPower,Machine_ShotQty,
                   Machine_MaintainCycle,Machine_Price,Machine_RentCost,Machine_SeatCode,Machine_MaterialChgTime,
                   Machine_MaterialChgCost,Machine_MaterialChgAmt, Machine_Photo, Machine_PhotoType,Bearings,
                   ScrewDiameter,InjectionPress,MachineVolume,SerialNo,TackOut,
                   Screw,Condition,
                   MinMouldThick,MaxMouldThick,LoadMouldMaxLenght,LoadMouldMaxWidth,PushDistance,
                   PushStress,OpenMouldDistance,
                   Robort,Note);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        public static void deleteMachineMstr(int _id)
        {
            factory.deleteMachineMstr(_id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_idlist"></param>
        public static void cancelMachineMstr(ArrayList _idlist)
        {
            factory.cancelMachineMstr(_idlist);
        }
    }
}
