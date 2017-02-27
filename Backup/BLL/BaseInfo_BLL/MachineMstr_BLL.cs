using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Machine_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.BLL.BaseInfo_BLL
{
    public class MachineMstr_BLL
    {
        private static readonly IMachineMstr factory = Admin.DALFactory.DataAccess.selectMachineMstr();
        public static IList<MachineMstr_MDL> selectMachineMstr()
        {
            return factory.selectMachineMstr();
        }
        public static DataTable selectWorkShop()
        {
            return factory.selectWorkShop();
        }
        public static DataTable selectMachinePlant(string MachineNo)
        {
            return factory.selectMachinePlant(MachineNo);
        }
        public static DataTable selectAllMachinePlant()
        {
            return factory.selectAllMachinePlant();
        }
        public static string selectParentWorkShop(string MachineCode)
        {
            return factory.selectParentWorkShop(MachineCode);
        }

        public static IList<MachineMstr_MDL> selectMachineMstr(string Machine_SeatCode)
        {
            return factory.selectMachineMstr(Machine_SeatCode);
        }

        public static IList<MachineMstr_MDL> selectMachineMstr(int _ID, string colname, string coltext)
        {
            return factory.selectMachineMstr(_ID, colname, coltext);
        }

        public static IList<MachineMstr_MDL> existsMachineMstr(string _MachineMstrID)
        {
            return factory.existsMachineMstr(_MachineMstrID);
        }

        public static void updateMachineMstr(int vID,
                string vMachine_Code,string  vMachine_Type, string vMachine_Manufacturer, 
                string vMachine_AssetNo, string vMachine_EquipmentNo, string vMachine_MadeDate, 
                string vMachine_LockPower, string vMachine_ShotQty, 
               string  vMachine_PushDistance, string vMachine_LoadMouldLgt, string vMachine_LoadMouldWdt, string vMinMouldThick, string vMaxMouldThick,
                 string vShotDiameter,
               string  vHydPressTackOut,string  vDrawPoleDistance, string vRobort, string vMachine_Power,
               string  vMachine_MaterialChgAmt,byte[] vMachine_Photo, string vRemark,  string IU)
        {
            MachineMstr_MDL Obj = new MachineMstr_MDL(vID,
                vMachine_Code, vMachine_Type, vMachine_Manufacturer,
                vMachine_AssetNo, vMachine_EquipmentNo, vMachine_MadeDate,
                vMachine_LockPower, vMachine_ShotQty,
                vMachine_PushDistance, vMachine_LoadMouldLgt, vMachine_LoadMouldWdt, vMinMouldThick, vMaxMouldThick,
                 vShotDiameter,
                vHydPressTackOut, vDrawPoleDistance, vRobort, vMachine_Power,
                vMachine_MaterialChgAmt, vMachine_Photo, vRemark);
                
            factory.updateMachineMstr(Obj, IU);
        }

        public static void deleteMachineMstr(int _id)
        {
            factory.deleteMachineMstr(_id);
        }

        public static void cancelMachineMstr(ArrayList _idlist)
        {
            factory.cancelMachineMstr(_idlist);
        }

        public static DataTable selectMachineCode(int MachineShotQty, string productNo)
        {
            return factory.selectMachineCode(MachineShotQty, productNo);
        }
    }
}
