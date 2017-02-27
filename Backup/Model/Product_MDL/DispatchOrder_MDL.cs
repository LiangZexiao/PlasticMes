﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class DispatchOrder_MDL : LikeQuery
    {
        private int _ID;

        private string _WorkOrderNo;
        private string _DO_No;
        private string _MachineNo;
        private string _MouldNo;
        private string _ProductNo;
        private string _ProductDesc;
        private string _ActualStartDate;

        private string _StartDate;
        private string _StopDate;
        private string _ActualStopDate;
        private string _BadQty;
        private string _DispatchDate;
        private string _DispatchNum;
        private string _CheckStatus;
        private string _DispatchStatus;
        private string _Remark;
        private string _StandCycle;
        private string _MaxInjectionCycle;
        private string _MinInjectionCycle;
        private string _UpdateCycleStatus;
        //private string _GroupNum;
        private string _Creater;

        public DispatchOrder_MDL() { }
        public DispatchOrder_MDL(string vDO_No) { this._DO_No = vDO_No; }
        public DispatchOrder_MDL(int vID,
              string vDO_No, string vWorkOrderNo, string vMachineNo, string vMouldNo, string vProductNo, string vProductDesc,
              string vStartDate, string vStopDate, string vActualStartDate,
            string vActualStopDate, string vBadQty,
              string vDispatchDate, string vDispatchNum,string vCheckStatus, string vDispatchStatus, string vRemark,string vStandCycle
           )
        {
            this._ID = vID;

            this._DO_No = vDO_No;
            this._WorkOrderNo = vWorkOrderNo;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
            this._ProductNo = vProductNo;
            this._ProductDesc = vProductDesc;

            this._StartDate = vStartDate;
            this._StopDate = vStopDate;
            this._ActualStartDate = vActualStartDate;

            this._ActualStopDate = vActualStopDate;
            this._BadQty = vBadQty;

            this._DispatchDate = vDispatchDate;
            this._DispatchNum = vDispatchNum;
            this._CheckStatus = vCheckStatus;
            this._DispatchStatus = vDispatchStatus;
            this._Remark = vRemark;
            this._StandCycle = vStandCycle;
        }

        public DispatchOrder_MDL(int vID,
            string vDO_No, string vWorkOrderNo, string vMachineNo, string vMouldNo, string vProductNo, string vProductDesc,
            string vStartDate, string vStopDate, string vActualStartDate,
          string vActualStopDate, string vBadQty,
            string vDispatchDate, string vDispatchNum, string vCheckStatus, string vDispatchStatus, string vRemark, string vStandCycle, string _vMaxInjectionCycle, string _vMinInjectionCycle, string _vUpdateCycleStatus
         )
        {
            this._ID = vID;

            this._DO_No = vDO_No;
            this._WorkOrderNo = vWorkOrderNo;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
            this._ProductNo = vProductNo;
            this._ProductDesc = vProductDesc;

            this._StartDate = vStartDate;
            this._StopDate = vStopDate;
            this._ActualStartDate = vActualStartDate;

            this._ActualStopDate = vActualStopDate;
            this._BadQty = vBadQty;

            this._DispatchDate = vDispatchDate;
            this._DispatchNum = vDispatchNum;
            this._CheckStatus = vCheckStatus;
            this._DispatchStatus = vDispatchStatus;
            this._Remark = vRemark;
            this._StandCycle = vStandCycle;
            this._MaxInjectionCycle=_vMaxInjectionCycle;
            this._MinInjectionCycle = _vMinInjectionCycle;
            this._UpdateCycleStatus = _vUpdateCycleStatus;
        }
        public DispatchOrder_MDL(int vID,
           string vDO_No, string vWorkOrderNo, string vMachineNo, string vMouldNo, string vProductNo, string vProductDesc,
           string vStartDate, string vStopDate, string vActualStartDate,
         string vActualStopDate, string vBadQty,
           string vDispatchDate, string vDispatchNum, string vCheckStatus, string vDispatchStatus, string vRemark, string vStandCycle, string _vMaxInjectionCycle, string _vMinInjectionCycle, string _vUpdateCycleStatus, string vCreater
        )
        {
            this._ID = vID;

            this._DO_No = vDO_No;
            this._WorkOrderNo = vWorkOrderNo;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
            this._ProductNo = vProductNo;
            this._ProductDesc = vProductDesc;

            this._StartDate = vStartDate;
            this._StopDate = vStopDate;
            this._ActualStartDate = vActualStartDate;

            this._ActualStopDate = vActualStopDate;
            this._BadQty = vBadQty;

            this._DispatchDate = vDispatchDate;
            this._DispatchNum = vDispatchNum;
            this._CheckStatus = vCheckStatus;
            this._DispatchStatus = vDispatchStatus;
            this._Remark = vRemark;
            this._StandCycle = vStandCycle;
            this._MaxInjectionCycle = _vMaxInjectionCycle;
            this._MinInjectionCycle = _vMinInjectionCycle;
            this._UpdateCycleStatus = _vUpdateCycleStatus;
            //this._GroupNum = _vGroupNum;
            this._Creater = vCreater;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string DO_No
        {
            get { return _DO_No; }
            set { _DO_No = value; }
        }

        public string WorkOrderNo
        {
            get { return this._WorkOrderNo; }
            set { _WorkOrderNo = value; }
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


        public string ProductDesc
        {
            get { return _ProductDesc; }
            set { _ProductDesc = value; }
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

        public string ActualStartDate
        {
            get { return _ActualStartDate; }
            set { _ActualStartDate = value; }
        }

        public string ActualStopDate
        {
            get { return _ActualStopDate; }
            set { _ActualStopDate = value; }
        }

        public string BadQty
        {
            get { return _BadQty; }
            set { _BadQty = value; }
        }
        public string DispatchDate
        {
            get { return _DispatchDate; }
            set { _DispatchDate = value; }
        }

        public string DispatchNum
        {
            get { return _DispatchNum; }
            set { _DispatchNum = value; }
        }

        

        public string CheckStatus
        {
            get { return _CheckStatus; }
            set { _CheckStatus = value; }
        }

        public string DispatchStatus
        {
            get { return _DispatchStatus; }
            set { _DispatchStatus = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string StandCycle
        {
            get { return _StandCycle; }
            set { _StandCycle = value; }
        }

        public string MaxInjectionCycle
        {
            get { return _MaxInjectionCycle; }
            set { _MaxInjectionCycle = value; }
        }

        public string MinInjectionCycle
        {
            get { return _MinInjectionCycle; }
            set { _MinInjectionCycle = value; }
        }

        public string UpdateCycleStatus
        {
            get { return _UpdateCycleStatus; }
            set { _UpdateCycleStatus = value; }
        }

        //public string GroupNum
        //{
        //    get { return _GroupNum; }
        //    set { _GroupNum = value; }
        //}

        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }

       
    }
}
