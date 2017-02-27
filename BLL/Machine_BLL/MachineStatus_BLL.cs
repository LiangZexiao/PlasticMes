using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Admin.Model.Machine_MDL;
using Admin.SQLServerDAL.Machine;

namespace Admin.BLL.Machine_BLL
{
    public class MachineStatus_BLL
    {
        MachineStatus_DAL dalMachineStatus = new MachineStatus_DAL();

        public DataTable selectMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            return dalMachineStatus.selectMachineStatus(dboMachineStatus);
        }

        public bool isexistpkMachineStatus(MachineStatus_MDL dboMachineStatus_MDL)
        {
            return dalMachineStatus.isexistpkMachineStatus(dboMachineStatus_MDL);
        }

        public int insertMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            return dalMachineStatus.insertMachineStatus(dboMachineStatus);
        }

        public int updateMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            return dalMachineStatus.updateMachineStatus(dboMachineStatus);
        }

        public int deleteMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            return dalMachineStatus.deleteMachineStatus(dboMachineStatus);
        }

        public int cancelMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            return dalMachineStatus.cancelMachineStatus(dboMachineStatus);
        }
        public MachineStatus_MDL chooseMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            return dalMachineStatus.chooseMachineStatus(dboMachineStatus);
        }
        
    }
}
