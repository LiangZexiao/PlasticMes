using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.IDAL.Product_IDAL;


namespace Admin.BLL.Product_BLL
{
    public class ManMachineMap_BLL
    {
        private static readonly IManMachineMap factory = Admin.DALFactory.DataAccess.selectManMachineMap();
        public static IList<ManMachineMap_MDL> selectManMachineMap(int _ID, string colname, string coltext)
        {
            return factory.selectManMachineMap(_ID, colname, coltext);
        }

        public static void insertManMachineMap(string vEmployeeID, string vMachineNo, string vWorkGrade, string vWorkDate, string vRemark)
        {
            factory.insertManMachineMap(vEmployeeID, vMachineNo, vWorkGrade, vWorkDate, vRemark);
        }

        public static void updateManMachineMap(int ID,
           string vEmployeeID, string vMachineNo, string vWorkGrade, string vWorkDate, string vRemark)
        {
            factory.updateManMachineMap(ID, vEmployeeID, vMachineNo, vWorkGrade, vWorkDate, vRemark);
        }

        public static void deleteManMachineMap(int _id)
        {
            factory.deleteManMachineMap(_id);
        }

        public static void cancelManMachineMap(ArrayList _idlist)
        {
            factory.cancelManMachineMap(_idlist);
        }
    }
}
