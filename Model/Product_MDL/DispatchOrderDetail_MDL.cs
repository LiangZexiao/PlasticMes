using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class DispatchOrderDetail_MDL
    {
        private int _ID;
        private string _MasterID;
        private string _DispatchNo;
        private string _StartDate;
        private string _EndDate;
        private string _Qty;       

       public DispatchOrderDetail_MDL() {}
       public DispatchOrderDetail_MDL(int vID, string vMasterID, string vDispatchNo, string vStartDate, string vEndDate, string vQty)
       {
            this._ID = vID;
            this._MasterID = vMasterID;
            this._DispatchNo = vDispatchNo;            
            this._StartDate = vStartDate;
            this._EndDate = vEndDate;
            this._Qty = vQty;
       }
       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       public string MasterID
       {
           get { return _MasterID; }
           set { _MasterID = value; }
       }

       public string DispatchNo
       {
           get { return _DispatchNo; }
           set { _DispatchNo = value; }
       }

       public string StartDate
       {
           get { return _StartDate; }
           set { _StartDate = value; }
       }

       public string EndDate
       {
           get { return _EndDate; }
           set { _EndDate = value; }
       }

       public string Qty
       {
           get { return _Qty; }
           set { _Qty = value; }
       }
    }
}
