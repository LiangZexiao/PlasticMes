using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;
using Admin.SQLServerDAL.Machine;

namespace Admin.BLL.Machine_BLL
{
    public  class MachineStatusConfig_BLL
    {
        public DataTable SelectMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig)
        {
            MachineStatusConfig_DAL tempObject = new MachineStatusConfig_DAL();
            return tempObject.SelectMachineStatusConfig(dboMachineStatusConfig);
        }

        public bool IsexistpkMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig_MDL)
        {
            MachineStatusConfig_DAL dboMachineStatusConfig_DAL = new MachineStatusConfig_DAL();
            return dboMachineStatusConfig_DAL.IsexistpkMachineStatusConfig(dboMachineStatusConfig_MDL);
        }

        public int InsertMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig)
        {
            MachineStatusConfig_DAL tempObject = new MachineStatusConfig_DAL();
            return tempObject.InsertMachineStatusConfig(dboMachineStatusConfig);
        }

        public int UpdateMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig)
        {
            MachineStatusConfig_DAL tempObject = new MachineStatusConfig_DAL();
            return tempObject.UpdateMachineStatusConfig(dboMachineStatusConfig);
        }

        public int DeleteMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig)
        {
            MachineStatusConfig_DAL tempObject = new MachineStatusConfig_DAL();
            return tempObject.DeleteMachineStatusConfig(dboMachineStatusConfig);
        }

        public int CancelMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig)
        {
            MachineStatusConfig_DAL tempObject = new MachineStatusConfig_DAL();
            return tempObject.CancelMachineStatusConfig(dboMachineStatusConfig);
        }

        public MachineStatusConfig_MDL ChooseMachineStatusConfig(MachineStatusConfig_MDL dboMachineStatusConfig)
        {
            MachineStatusConfig_DAL tempObject = new MachineStatusConfig_DAL();
            return tempObject.ChooseMachineStatusConfig(dboMachineStatusConfig);
        }

    }
}
