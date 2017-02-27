using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Quality_MDL
{
    public class QC_Table_MDL : LikeQuery
    {
        private int _ID;
        private string _WorkOrderNo;
        private string _DispatchNo;
        private string _MachineNo;
        private string _MouldNo;
        private string _ProductNo;

        private string _TotalQty;
        private string _GoodQty;
        private string _BadQty;
        private string _ProductDate;
        private string _ProductDesc;

        private string _Worker;
        private string _Checker;
        private string _CheckDate;
        private string _Memo;

       public QC_Table_MDL(){}
       public QC_Table_MDL(int vID,
              string vWorkOrderNo, string vDispatchNo, string vMachineNo, string vMouldNo,
              string vProductNo, string vTotalQty, string vGoodQty, string vBadQty, string vProductDate, string vProductDesc, string vWorker,
              string vChecker, string vCheckDate, string vMemo
          )
       {
           this._ID = vID;
           this._WorkOrderNo = vWorkOrderNo;
           this._DispatchNo = vDispatchNo;
           this._TotalQty = vTotalQty;
           this._MachineNo = vMachineNo;
           this._MouldNo = vMouldNo;
           this._ProductNo = vProductNo;
           this._GoodQty = vGoodQty;
           this._BadQty = vBadQty;
           this._ProductDate = vProductDate;
           this._ProductDesc = vProductDesc;

           this._Worker = vWorker;
           this._Checker = vChecker;
           this._CheckDate = vCheckDate;
           this._Memo = vMemo;
       }

       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       public string WorkOrderNo
       {
           get { return _WorkOrderNo; }
           set { _WorkOrderNo = value; }
       }

       public string DispatchNo
       {
           get { return _DispatchNo; }
           set { _DispatchNo = value; }
       }

       public string MachineNo
       {
           get { return _MachineNo; }
           set { _MachineNo = value; }
       }

       public string MouldNo
       {
           get { return _MouldNo; }
           set { _MouldNo = value; }
       }

        public string ProductNo
        {
            get { return _ProductNo; }
            set { _ProductNo = value; }
        }
       
       public string TotalQty
       {
           get { return _TotalQty; }
           set { _TotalQty = value; }
       }

       public string GoodQty
       {
           get { return _GoodQty; }
           set { _GoodQty = value; }
       }

        public string BadQty
       {
           get { return _BadQty; }
           set { _BadQty = value; }
       }
        
       public string ProductDate
       {
           get { return _ProductDate; }
           set { _ProductDate = value; }
       }

       public string ProductDesc
       {
           get { return _ProductDesc; }
           set { _ProductDesc = value; }
       }

       public string Worker
       {
           get { return _Worker; }
           set { _Worker = value; }
       }

       public string Checker
       {
           get { return _Checker; }
           set { _Checker = value; }
       }

       public string CheckDate
       {
           get { return _CheckDate; }
           set { _CheckDate = value; }
       }

       public string Memo
       {
           get { return _Memo; }
           set { _Memo = value; }
       }
    }
}
