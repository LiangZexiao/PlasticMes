using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;
using Admin.IDAL.Monitor_IDAL;

namespace Admin.BLL.Monitor_BLL
{
    public class MonitorMachine_BLL
    {
        private static readonly IMonitorMachine factory = Admin.DALFactory.DataAccess.selectMonitorMachine();

        public static DataSet selectMonitorMachine(string DispatchOrder)
        {
            return factory.selectMonitorMachine(DispatchOrder);
        }
        public static DataSet selectNxtInjectionDO(string MachineNo)
        {
            return factory.selectNxtInjectionDO(MachineNo);
        }
        public static IList<MonitorMachine_MDL> selectMonitorMachine(string DispatchOrder, string ClientIP)
        {
            return factory.selectMonitorMachine(DispatchOrder, ClientIP);
        }
        public static IList<MonitorMachine_MDL> selectMonitorMachine(string Machine_SeatCode, string MachineState, string MachineNo)
        {
            return factory.selectMonitorMachine(Machine_SeatCode, MachineState, MachineNo);
        }

        public static IList<MonitorMachine_MDL> selectMonitorPlantBristlesToolInfo(string Machine_SeatCode, string MachineState)
        {
            return factory.selectMonitorPlantBristlesToolInfo(Machine_SeatCode, MachineState);
        }
        public static DataSet selectMonitorPlantBristlesToolInfo(string DispatchOrder)
        {
            return factory.selectMonitorPlantBristlesToolInfo(DispatchOrder);
        }

        public static void execStoredProcedure(string procedureName)
        {
            factory.execStoredProcedure(procedureName);
        }

        public static DataTable execSMSDetail()
        {
            return factory.execSMSDetail();
        }

        public static int UpdateSMSDetailStatus(int id)
        {
            return factory.UpdateSMSDetailStatus(id);
        }
    }
}
