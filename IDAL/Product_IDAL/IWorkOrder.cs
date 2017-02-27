using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;

namespace Admin.IDAL.Product_IDAL
{
    public interface IWorkOrder
    {
        IList<WorkOrder_MDL> selectWorkOrder(int id, string status, string colname, string coltext);
        //IList<WorkOrder_MDL> selectWorkOrderMtl(int id, string colname, string coltext);
        IList<WorkOrder_MDL> selectWorkOrder(string OrderNo);
        IList<WorkOrder_MDL> existsWorkOrder(string vWO_No);
        IList<WorkOrder_MDL> existsWorkOrder2(int vid);
        void ChangeWorkOrder(WorkOrder_MDL Obj, string IU);

        void checkWorkOrder(string strFlag, string strUserID, ArrayList idList);
        void deleteWorkOrder(int ID);
        void cancelWorkOrder(ArrayList IDList);
    }
}
