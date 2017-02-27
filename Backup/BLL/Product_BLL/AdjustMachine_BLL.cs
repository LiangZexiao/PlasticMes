using System;
using System.Collections.Generic;
using System.Text;
using Admin.IDAL.Product_IDAL;
using Admin.Model.Product_MDL;
using System.Collections;

namespace Admin.BLL.Product_BLL
{
    public class AdjustMachine_BLL
    {
        private static readonly IAdjustMachine factory = Admin.DALFactory.DataAccess.selectAdjustMachine();
        public static IList<AdjustMachine_MDL> selectAdjustMachine(int _ID, string colname, string coltext,string begindate,string enddate)
        {
            return factory.selectAdjustMachine(_ID, colname, coltext,begindate,enddate);
        }
        public static IList<AdjustMachine_MDL> existsAdjustMachine(string vDO_No)
        {
            return factory.existsAdjustMachine(vDO_No);
        }
        public static IList<AdjustMachine_MDL> existsAdjustMachine(string colname, string coltext)
        {
            return factory.existsAdjustMachine(colname, coltext);
        }

        public static int ChangeAdjustMachine(int vID,
             string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
             string vStartDate,string vEndDate, string vProductDesc, string vAdjustMan, string vUserID,
             string vtime, string vRemark,string vModiHistoryContent,string vCardType, string IU)
        {
            return factory.ChangeAdjustMachine(vID,
              vWorkOrderNo, vDispatchNo, vTotalQty, vMachineNo, vMouldNo, vProductNo,
              vStartDate, vEndDate, vProductDesc, vAdjustMan, vUserID,
              vtime, vRemark, vModiHistoryContent, vCardType, IU);
        }

        public static void ChangeAdjustMachine(int vID,
             string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
             string vStartDate, string vEndDate, string vProductDesc, string vAdjustMan, string vUserID,
             string vtime, string vRemark, string vModiHistoryContent, string vCardType, string IU, out int xid)
        {
            factory.ChangeAdjustMachine(vID,
             vWorkOrderNo, vDispatchNo, vTotalQty, vMachineNo, vMouldNo, vProductNo,
             vStartDate, vEndDate, vProductDesc, vAdjustMan, vUserID,
             vtime, vRemark, vModiHistoryContent, vCardType, IU, out xid);
        }

        public static void deleteAdjustMachine(int _id)
        {
            factory.deleteAdjustMachine(_id);
        }

        public static void cancelAdjustMachine(ArrayList _idlist)
        {
            factory.cancelAdjustMachine(_idlist);
        }
    }
}
