using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;

namespace Admin.IDAL.Machine_IDAL
{
    public interface IMachineMstr0
    {
        //IList<MachineMstr_MDL> selectMachineMstr();
        //IList<MachineMstr_MDL> selectMachineMstr(int id);
        IList<MachineMstr0_MDL> selectMachineMstr();
        IList<MachineMstr0_MDL> selectMachineMstr(string Machine_SeatCode);
        IList<MachineMstr0_MDL> selectMachineMstr(int _ID, string colname, string coltext);
        IList<MachineMstr0_MDL> existsMachineMstr(string _MachineMstrID);
        void insertMachineMstr(string Machine_Code, string Machine_NameCH, string Machine_NameEN, string Machine_Type,
            string Machine_Manufacturer, string Machine_Model, string Machine_Brand, DateTime Machine_PurchaseDate, DateTime Machine_MadeDate,
            string Machine_Power, string Machine_MouldCapacity, string Machine_MinLockPower, string Machine_MaxLockPower, string Machine_ShotQty,
            string Machine_MaintainCycle, string Machine_Price, string Machine_RentCost, string Machine_SeatCode, string Machine_MaterialChgTime,
            string Machine_MaterialChgCost, string Machine_MaterialChgAmt, byte[] Machine_Photo, object Machine_PhotoType, string Bearings,
            string ScrewDiameter, string InjectionPress, string MachineVolume, string SerialNo, string TackOut,
            string Screw, string Condition,
            string MinMouldThick, string MaxMouldThick, string LoadMouldMaxLenght, string LoadMouldMaxWidth, string PushDistance,
            string PushStress, string OpenMouldDistance,
            string Robort, string Note);
        
        void updateMachineMstr(int ID,  string Machine_Code, string Machine_NameCH, string Machine_NameEN, string Machine_Type,
            string Machine_Manufacturer, string Machine_Model, string Machine_Brand, DateTime Machine_PurchaseDate, DateTime Machine_MadeDate,
            string Machine_Power, string Machine_MouldCapacity, string Machine_MinLockPower, string Machine_MaxLockPower, string Machine_ShotQty,
            string Machine_MaintainCycle, string Machine_Price, string Machine_RentCost, string Machine_SeatCode, string Machine_MaterialChgTime,
            string Machine_MaterialChgCost, string Machine_MaterialChgAmt, byte[] Machine_Photo, object Machine_PhotoType, string Bearings,
            string ScrewDiameter, string InjectionPress, string MachineVolume, string SerialNo, string TackOut,
            string Screw, string Condition,
            string MinMouldThick, string MaxMouldThick, string LoadMouldMaxLenght, string LoadMouldMaxWidth, string PushDistance,
            string PushStress, string OpenMouldDistance,
            string Robort, string Note);

        void deleteMachineMstr(int _ID);
        void cancelMachineMstr(ArrayList _IDList);
    }
}
