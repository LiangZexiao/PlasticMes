using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class WorkOrder_MDL : LikeQuery
    {
        private int _ID;
        private string _WO_No;
        private string _OrderNo;
        private string _ProductNo;
        private string _MouldNo;
        private string _WO_SocketAmount;
        private string _WO_Planner;
        private string _WO_DueDate;
        private string _WO_OriginalQty;
        private string _OrderNum;

        private string _WO_Qty; 
        private string _WO_DoneQty;
        private string _WO_Priority;
        private string _WO_Dalayable;
        private string _WO_DalayDay;
        private string _WO_AheadDay;
        private string _WO_SchStartDate;
        private string _WO_SchEndDate;
        private string _WO_ActualStartDate;
        private string _WO_ActualEndDate;

        private string _WO_Status;
        private string _WO_DispatchQty;
        private string _WO_DispatchFlag;
        private string _WO_ApproveFlag;
        private string _WO_ApprovedBy;
        private string _WO_ApprovedDate;
        private string _Remark;

        private string _WorkOrderNo;
        private string _MtlNum;
        private string _Item_Weight;
        private string _StandNum;


        public WorkOrder_MDL() {}
        public WorkOrder_MDL(string OrderNo, string WorkOrderNo, string MtlNum) 
        {
            this._OrderNo = OrderNo;
            this._WorkOrderNo = WorkOrderNo;
            this._MtlNum = MtlNum;
        }

        public string WorkOrderNo
        {
            get { return _WorkOrderNo; }
            set { _WorkOrderNo = value; }
        }
        public string MtlNum
        {
            get { return _MtlNum; }
            set { _MtlNum = value; }
        }

       public WorkOrder_MDL(int vID,
             string vWO_No, string vOrder_No, string vProductNo, string vMouldNo, string vWO_SocketAmount,
             string vWO_Planner, string vWO_DueDate, string vWO_OriginalQty, string vOrderNum, string vWO_Qty,
             string vWO_DoneQty, string vWO_Priority, string vWO_Dalayable, string vWO_DalayDay, string vWO_AheadDay,
             string vWO_SchStartDate, string vWO_SchEndDate, string vWO_ActualStartDate, string vWO_ActualEndDate, string vWO_Status, 
             string vWO_DispatchQty, string vWO_DispatchFlag, string vWO_ApproveFlag, string vWO_ApprovedBy, string vWO_ApprovedDate, 
             string vRemark)
        {
            this._ID = vID;
            this._WO_No = vWO_No;
            this._OrderNo = vOrder_No;
            this._ProductNo = vProductNo;
            this._MouldNo = vMouldNo;
            this._WO_SocketAmount = vWO_SocketAmount;

            this._WO_OriginalQty = vWO_OriginalQty;
            this._OrderNum = vOrderNum;

            this._WO_Qty = vWO_Qty;
            this._WO_DoneQty = vWO_DoneQty;
            this._WO_Priority = vWO_Priority;
            this._WO_Dalayable = vWO_Dalayable;
            this._WO_DalayDay = vWO_DalayDay;
            this._WO_AheadDay = vWO_AheadDay;
            this._WO_SchStartDate = vWO_SchStartDate;
            this._WO_SchEndDate = vWO_SchEndDate;
            this._WO_ActualStartDate = vWO_ActualStartDate;

            this._WO_ActualEndDate = vWO_ActualEndDate;
            this._WO_Status = vWO_Status;
            this._WO_DispatchQty = vWO_DispatchQty;
            this._WO_DispatchFlag = vWO_DispatchFlag; 
            this._WO_ApproveFlag = vWO_ApproveFlag;
            this._WO_ApprovedBy = vWO_ApprovedBy;
            this._WO_ApprovedDate = vWO_ApprovedDate;
            this._Remark = vRemark;

            this._WO_Planner = vWO_Planner;//创建人
            this._WO_DueDate = vWO_DueDate;//创建时间
        }
        //********************************************
       public string Item_Weight
       {
           get { return _Item_Weight; }
           set { _Item_Weight = value; }
       }

       public string StandNum
       {
           get { return _StandNum; }
           set { _StandNum = value; }
       }
        //********************************************
       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       public string WO_No
       {
           get { return _WO_No; }
           set { _WO_No = value; }
       }

       public string OrderNo
       {
           get { return _OrderNo; }
           set { _OrderNo = value; }
       }

       public string ProductNo
       {
           get { return _ProductNo; }
           set { _ProductNo = value; }
       }

       public string MouldNo
       {
           get { return _MouldNo; }
           set { _MouldNo = value; }
       }

       public string WO_SocketAmount
       {
           get { return _WO_SocketAmount; }
           set { _WO_SocketAmount = value; }
       }

       public string WO_Planner
       {
           get { return _WO_Planner; }
           set { _WO_Planner = value; }
       }

       public string WO_DueDate
       {
           get { return _WO_DueDate; }
           set { _WO_DueDate = value; }
       }

       public string WO_OriginalQty
       {
           get { return _WO_OriginalQty; }
           set { _WO_OriginalQty = value; }
       }

       public string OrderNum
       {
           get { return _OrderNum; }
           set { _OrderNum = value; }
       }

       public string WO_Qty
       {
           get { return _WO_Qty; }
           set { _WO_Qty = value; }
       }

       public string WO_DoneQty
       {
           get { return _WO_DoneQty; }
           set { _WO_DoneQty = value; }
       }

       public string WO_Priority
       {
           get { return _WO_Priority; }
           set { _WO_Priority = value; }
       }

       public string WO_Dalayable
       {
           get { return _WO_Dalayable; }
           set { _WO_Dalayable = value; }
       }

       public string WO_DalayDay
       {
           get { return _WO_DalayDay; }
           set { _WO_DalayDay = value; }
       }

       public string WO_AheadDay
       {
           get { return _WO_AheadDay; }
           set { _WO_AheadDay = value; }
       }

       public string WO_SchStartDate
       {
           get { return _WO_SchStartDate; }
           set { _WO_SchStartDate = value; }
       }

       public string WO_SchEndDate
       {
           get { return _WO_SchEndDate; }
           set { _WO_SchEndDate = value; }
       }

       public string WO_ActualStartDate
       {
           get { return _WO_ActualStartDate; }
           set { _WO_ActualStartDate = value; }
       }

       public string WO_ActualEndDate
       {
           get { return _WO_ActualEndDate; }
           set { _WO_ActualEndDate = value; }
       }

       public string WO_Status
       {
           get { return _WO_Status; }
           set { _WO_Status = value; }
       }

       public string WO_DispatchQty
       {
           get { return _WO_DispatchQty; }
           set { _WO_DispatchQty = value; }
       }

       public string WO_DispatchFlag
       {
           get { return _WO_DispatchFlag; }
           set { _WO_DispatchFlag = value; }
       }

       public string WO_ApproveFlag
       {
           get { return _WO_ApproveFlag; }
           set { _WO_ApproveFlag = value; }
       }

       public string WO_ApprovedBy
       {
           get { return _WO_ApprovedBy; }
           set { _WO_ApprovedBy = value; }
       }

       public string WO_ApprovedDate
       {
           get { return _WO_ApprovedDate; }
           set { _WO_ApprovedDate = value; }
       }

       public string Remark
       {
           get { return _Remark; }
           set { _Remark = value; }
       }
    }
}
