using System;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;
using System.Collections;

namespace Admin.IDAL.Product_IDAL
{
    public interface  IAdjustMachine
    {
        IList<AdjustMachine_MDL> selectAdjustMachine(int id, string colname, string coltext,string begindate,string enddate);
        IList<AdjustMachine_MDL> existsAdjustMachine(string vDO_No);
        IList<AdjustMachine_MDL> existsAdjustMachine(string colname, string coltext);
        int ChangeAdjustMachine(int vID,
             string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
             string vStartDate,string vEndDate, string vProductDesc, string vAdjustMan, string vUserID,
             string vtime, string vRemark, string vModiHistoryContent, string vCardType, string IU);
        void ChangeAdjustMachine(int vID, string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
            string vStartDate, string vEndDate, string vProductDesc, string vAdjustMan, string vUserID,
            string vtime, string vRemark, string vModiHistoryContent, string vCardType, string IU, out int xid);

        void deleteAdjustMachine(int ID);
        void cancelAdjustMachine(ArrayList IDList);

    }
}
