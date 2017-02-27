using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;
using System.Data;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IMachineMstr
    {
        IList<MachineMstr_MDL> selectMachineMstr();
        IList<MachineMstr_MDL> selectMachineMstr(string Machine_SeatCode);
        IList<MachineMstr_MDL> selectMachineMstr(int _ID, string colname, string coltext);
        IList<MachineMstr_MDL> existsMachineMstr(string _MachineMstrID);
        DataTable selectWorkShop();
        DataTable selectMachinePlant(string MachineNo);
        DataTable selectAllMachinePlant();
        string selectParentWorkShop(string MachineCode);
        void updateMachineMstr(MachineMstr_MDL obj, string IU);
        void deleteMachineMstr(int _ID);
        void cancelMachineMstr(ArrayList _IDList);
        DataTable selectMachineCode(int MachineShotQty, string productNo);
    }
}
