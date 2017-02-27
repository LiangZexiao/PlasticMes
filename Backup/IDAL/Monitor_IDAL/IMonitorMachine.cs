using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;

namespace Admin.IDAL.Monitor_IDAL
{
    public interface IMonitorMachine
    {
        IList<MonitorMachine_MDL> selectMonitorMachine(string Machine_SeatCode, string MachineState, string iMachineNo);
        IList<MonitorMachine_MDL> selectMonitorMachine(string DispatchOrder, string ClientIP);
        DataSet selectMonitorMachine(string DispatchOrder);
        DataSet selectNxtInjectionDO(string MachineNo);
        IList<MonitorMachine_MDL> selectMonitorPlantBristlesToolInfo(string Machine_SeatCode, string MachineState);
        DataSet selectMonitorPlantBristlesToolInfo(string DispatchOrder);
        void execStoredProcedure(string ProcedureName);
        DataTable execSMSDetail();
        int UpdateSMSDetailStatus(int id);
    }
}
