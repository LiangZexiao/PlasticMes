using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;

namespace Admin.IDAL.Product_IDAL
{
    public interface IManMachineMap
    {
        IList<ManMachineMap_MDL> selectManMachineMap(int id, string colname, string coltext);

        void insertManMachineMap(string vEmployeeID, string vMachineNo, string vWorkGrade, string vWorkDate, string vRemark);
        void updateManMachineMap(int ID, string vEmployeeID, string vMachineNo, string vWorkGrade, string vWorkDate, string vRemark);

        void deleteManMachineMap(int ID);
        void cancelManMachineMap(ArrayList IDList);
    }
}
