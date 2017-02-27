using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;

namespace Admin.IDAL.Product_IDAL
{
    public interface IOrderMstr
    {
        IList<OrderMstr_MDL> selectOrderMstr(int id, string colname, string coltext);
        IList<OrderMstr_MDL> queryOrderMstrToMonitorOdr(int id, string colname, string coltext);
        IList<OrderMstr_MDL> queryOrderMstrToMonitorMtl(int id, string colname, string coltext);  
        IList<OrderMstr_MDL> selectOrderMstr(string OrderStatus);
        IList<OrderMstr_MDL> existsOrderMstr(string OrderNO);
        void insertOrderMstr(string vOrderNO, string vItemNO, string vItemName, string vCustomer, string vOrderNum,
               string vDeliveryDate, string vPreDate, string vDelayDate, string vOrderStatus, string vCompleteNum,
               string vWOFlag, string vCheckFlag, string vChecker, string vRemark, string vCreater,
               string vCreateDate);
        void updateOrderMstr(int vID,
               string vOrderNO, string vItemNO, string vItemName, string vCustomer, string vOrderNum,
               string vDeliveryDate, string vPreDate, string vDelayDate, string vOrderStatus, string vCompleteNum,
               string vWOFlag, string vCheckFlag, string vChecker, string vRemark, string vCreater,
               string vCreateDate);
        void checkOrderMstr(int vID, string vChecker, string flag);
        void deleteOrderMstr(int ID);
        void cancelOrderMstr(ArrayList IDList);
    }
}
