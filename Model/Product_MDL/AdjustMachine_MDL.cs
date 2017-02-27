using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class AdjustMachine_MDL : LikeQuery
    {
         private int _ID;
        private string _WorkOrderNo;
        private string _DispatchNo;
        private string _MachineNo;
        private string _MouldNo;
        private string _ProductNo;

        private string _TotalQty;
        private string _StartDate;
        private string _EndDate;
        private string _ProductDesc;

        private string _AdjustMan;
        private string _EmpName;
        private string _Checker;
        private string _CheckDate;
        private string _Remark;
        private string _ModiHistoryContent;
        private string _CardType;
        private string _ReasonName;

       public AdjustMachine_MDL(){}
       public AdjustMachine_MDL(int vID,
              string vWorkOrderNo, string vDispatchNo, string vMachineNo, string vMouldNo,
              string vProductNo, string vTotalQty, string vStartDate,string vEndDate,
              string vProductDesc, string vAdjustMan,string vChecker, string vCheckDate,
              string vRemark, string vEmpName, string vModiHistoryContent,string vCardType,
              string vReasonName
          )
       {
           this._ID = vID;
           this._WorkOrderNo = vWorkOrderNo;
           this._DispatchNo = vDispatchNo;
           this._TotalQty = vTotalQty;
           this._MachineNo = vMachineNo;
           this._MouldNo = vMouldNo;
           this._ProductNo = vProductNo;
           this._StartDate = vStartDate;
           this._EndDate = vEndDate;
           this._ProductDesc = vProductDesc;
           this._AdjustMan = vAdjustMan;
           this._EmpName = vEmpName;
           this._Checker = vChecker;
           this._CheckDate = vCheckDate;
           this._Remark = vRemark;
           this._ModiHistoryContent = vModiHistoryContent;
           this._CardType = vCardType;
           this._ReasonName = vReasonName;

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

       public string ProductDesc
       {
           get { return _ProductDesc; }
           set { _ProductDesc = value; }
       }

       public string AdjustMan
       {
           get { return _AdjustMan; }
           set { _AdjustMan = value; }
       }
       public string EmpName
       {
           get { return _EmpName; }
           set { _EmpName = value; }
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

       public string Remark
       {
           get { return _Remark; }
           set { _Remark = value; }
       }
       public string ModiHistoryContent
       {
           get { return _ModiHistoryContent; }
           set { _ModiHistoryContent = value; }
       }
       public string CardType
       {
           get { return _CardType; }
           set { _CardType = value; }
       }
       public string ReasonName
       {
           get { return _ReasonName; }
           set { _ReasonName = value; }
       }
        
    }
}
