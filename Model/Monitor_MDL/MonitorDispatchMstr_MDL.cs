using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Monitor_MDL
{
    public class MonitorDispatchMstr_MDL
    {
        private int _ID;
        private string _DispatchNo;
        private string _ProductNo;
        private string _ProductRemark;
        private string _MouldNo;
        private string _DispatchNum;
        private string _ProductNum;
        private string _StartDate;
        private string _StopDate;
        private string _BeginTime;
        private string _NeedTime;
        private string _MachineNo;
        private string _WorkOrderNo;
        private string _GoodQty;
        private string _BadQty;

       public MonitorDispatchMstr_MDL() { }
       public MonitorDispatchMstr_MDL(int vID, string vDispatchNo, string vProductNo, string vProductRemark, string vMouldNo,
                string vDispatchNum, string vProductNum, string vStartDate, string vStopDate, string vBeginTime, string vNeedTime, string vMachineNo, string vWorkOrderNo)
        {
            this._ID = vID;
            this._DispatchNo = vDispatchNo;
            this._ProductNo = vProductNo;
            this._ProductRemark = vProductRemark;
            this._MouldNo = vMouldNo;
            this._DispatchNum = vDispatchNum;
            this._ProductNum = vProductNum;
            this._StartDate = vStartDate;
            this._StopDate = vStopDate;
            this._BeginTime = vBeginTime;
            this._NeedTime = vNeedTime;
            this._MachineNo = vMachineNo;
            this._WorkOrderNo = vWorkOrderNo;
        }
        public MonitorDispatchMstr_MDL(int vID, string vDispatchNo, string vProductNo, string vProductRemark, 
            string vMouldNo,string vDispatchNum, string vProductNum,string vgoodqty,string vbadqty, string vStartDate, string vStopDate, string vBeginTime, string vNeedTime, string vMachineNo, string vWorkOrderNo)
        {
            this._ID = vID;
            this._DispatchNo = vDispatchNo;
            this._ProductNo = vProductNo;
            this._ProductRemark = vProductRemark;
            this._MouldNo = vMouldNo;
            this._DispatchNum = vDispatchNum;
            this._ProductNum = vProductNum;

            this._GoodQty = vgoodqty;
            this._BadQty = vbadqty;

            this._StartDate = vStartDate;
            this._StopDate = vStopDate;
            this._BeginTime = vBeginTime;
            this._NeedTime = vNeedTime;
            this._MachineNo = vMachineNo;
            this._WorkOrderNo = vWorkOrderNo;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; }
        }


       public string DispatchNo
       {
           get { return _DispatchNo; }
           set { _DispatchNo = value; }
       }

       public string ProductNo
       {
           get { return _ProductNo; }
           set { _ProductNo = value; }
       }

       public string ProductRemark
       {
           get { return _ProductRemark; }
           set { _ProductRemark = value; }
       }

       public string MouldNo
       {
           get { return _MouldNo; }
           set { _MouldNo = value; }
       }

       public string DispatchNum
       {
           get { return _DispatchNum; }
           set { _DispatchNum = value; }
       }

       public string ProductNum
       {
           get { return _ProductNum; }
           set { _ProductNum = value; }
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

       public string StartDate
       {
           get { return _StartDate; }
           set { _StartDate = value; }
       }

       public string StopDate
       {
           get { return _StopDate; }
           set { _StopDate = value; }
       }

       public string BeginTime
       {
           get { return _BeginTime; }
           set { _BeginTime = value; }
       }

       public string NeedTime
       {
           get { return _NeedTime; }
           set { _NeedTime = value; }
       }
        public string WorkOrderNo
        {
            get { return _WorkOrderNo; }
            set { _WorkOrderNo = value; }
        }

    }
}
