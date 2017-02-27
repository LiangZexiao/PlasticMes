using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;
using Admin.SQLServerDAL.Machine;

namespace Admin.BLL.Machine_BLL
{
    public class MachineCollectMap_BLL
    {
        public DataTable selectMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            MachineCollectMap_DAL tempObject = new MachineCollectMap_DAL();
            return tempObject.selectMachineCollectMap(dboMachineCollectMap);
        }

        public bool isexistpkMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap_MDL)
        {
            MachineCollectMap_DAL dboMachineCollectMap_DAL = new MachineCollectMap_DAL();
            return dboMachineCollectMap_DAL.isexistpkMachineCollectMap(dboMachineCollectMap_MDL);
        }

        public int insertMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            MachineCollectMap_DAL tempObject = new MachineCollectMap_DAL();
            return tempObject.insertMachineCollectMap(dboMachineCollectMap);
        }

        public int updateMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            MachineCollectMap_DAL tempObject = new MachineCollectMap_DAL();
            return tempObject.updateMachineCollectMap(dboMachineCollectMap);
        }

        public int deleteMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            MachineCollectMap_DAL tempObject = new MachineCollectMap_DAL();
            return tempObject.deleteMachineCollectMap(dboMachineCollectMap);
        }

        public MachineCollectMap_MDL chooseMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            MachineCollectMap_DAL tempObject = new MachineCollectMap_DAL();
            return tempObject.chooseMachineCollectMap(dboMachineCollectMap);
        }

        public int cancelMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            MachineCollectMap_DAL tempObject = new MachineCollectMap_DAL();
            return tempObject.cancelMachineCollectMap(dboMachineCollectMap);
        }
    }
}
