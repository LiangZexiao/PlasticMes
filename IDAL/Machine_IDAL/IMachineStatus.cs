using System;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;

namespace Admin.IDAL.Machine_IDAL
{
    public interface IMachineStatus
    {
        void selectMachineStatus(Admin.Model.Machine_MDL.MachineStatus_MDL dboMachineStatus);
        void insertMachineStatus(Admin.Model.Machine_MDL.MachineStatus_MDL dboMachineStatus);
        void updateMachineStatus(Admin.Model.Machine_MDL.MachineStatus_MDL dboMachineStatus);
        void deleteMachineStatus(Admin.Model.Machine_MDL.MachineStatus_MDL dboMachineStatus);
    }
}
