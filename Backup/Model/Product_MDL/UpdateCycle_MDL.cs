using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class UpdateCycle_MDL : LikeQuery
    {
        private int    _ID;

        private string _DO_NO;

        private string _ProductNo;

        private string _ProductDesc;

        private string _MachineNo;

        private string _MouldNo;

        private string _StandCycle;

        private string _MaxInjectionCycle;

        private string _MinInjectionCycle;

        private string _UpdateStandCycle;

        private string _UpdateMaxInjectionCycle;

        private string _UpdateMinInjectionCycle;

        private string _UpdateTime;

        private string _CreateTime;

        private string _UpdateEmployee;

        private string _LastTime;

        private string _WorkOrderNo;

        public UpdateCycle_MDL() { }
       
        public UpdateCycle_MDL(int _vID, string _vDO_NO, string _vStandCycle, string _vMaxInjectionCycle, string _vMinInjectionCycle, string _vUpdateStandCycle, string _vUpdateMaxInjectionCycle,
            string _vUpdateMinInjectionCycle, string _vUpdateTime, string _vCreateTime, string _vUpdateEmployee, string _vLastTime, string _vWorkOrderNo, string _vMachineNo, string _vMouldNo, string _vProductNo, string _vProductDesc)
        {
            _ID = _vID;

            _DO_NO = _vDO_NO;

            _ProductNo = _vProductNo;

            _ProductDesc = _vProductDesc;

            _MachineNo = _vMachineNo;

            _MouldNo = _vMouldNo;
 
            _StandCycle = _vStandCycle;

            _MaxInjectionCycle = _vMaxInjectionCycle;

            _MinInjectionCycle = _vMinInjectionCycle;

            _UpdateStandCycle = _vUpdateStandCycle;

            _UpdateMaxInjectionCycle = _vUpdateMaxInjectionCycle;

            _UpdateMinInjectionCycle = _vUpdateMinInjectionCycle;

            _UpdateTime = _vUpdateTime;

            _CreateTime = _vCreateTime;

            _UpdateEmployee = _vUpdateEmployee;

            _LastTime = _vLastTime;

            _WorkOrderNo = _vWorkOrderNo;      
        }

        public UpdateCycle_MDL(string _vDO_NO, string _vProductNo, string _vProductDesc, string _vMachineNo, string _vMouldNo, string _vUpdateStandCycle, string _vUpdateMaxInjectionCycle, string _vUpdateMinInjectionCycle)
        {
            _DO_NO = _vDO_NO;

            _ProductNo = _vProductNo;

            _ProductDesc = _vProductDesc;

            _MachineNo = _vMachineNo;

            _MouldNo = _vMouldNo;

            _UpdateStandCycle = _vUpdateStandCycle;

            _UpdateMaxInjectionCycle = _vUpdateMaxInjectionCycle;

            _UpdateMinInjectionCycle = _vUpdateMinInjectionCycle;
        }
       
        public UpdateCycle_MDL(string _vDO_NO, string _vWorkOrderNo, string _vMachineNo, string _vMouldNo, string _vProductNo, string _vProductDesc, string _vUpdateStandCycle, string _vStandCycle, string _vMaxInjectionCycle, string _vMinInjectionCycle, string _vUpdateEmployee, string _vUpdateTime)
        {
            _DO_NO = _vDO_NO;
            _WorkOrderNo = _vWorkOrderNo;
            _MachineNo = _vMachineNo;
            _MouldNo = _vMouldNo;
            _ProductNo = _vProductNo;
            _ProductDesc = _vProductDesc;

            _UpdateStandCycle = _vUpdateStandCycle;
            _StandCycle = _vStandCycle;
            _MaxInjectionCycle = _vMaxInjectionCycle;

            _MinInjectionCycle = _vMinInjectionCycle;
            _UpdateEmployee = _vUpdateEmployee;
            _UpdateTime = _vUpdateTime;
        }
       
        public UpdateCycle_MDL(int _vID, string _vDO_No,string _vProductNo, string _vProductDesc, string _vMachineNo, string _vMouldNo, string _vStandCycle, string _vMaxInjectionCycle, string _vMinInjectionCycle, string _vUpdateStandCycle, string _vUpdateMaxInjectionCycle, string _vUpdateMinInjectionCycle, string _vUpdateTime
            , string _vCreateTime, string _vUpdateEmployee)
        {
            this._ID = _vID;
            this._DO_NO = _vDO_No;
            
            this._ProductNo = _vProductNo;
            this._ProductDesc = _vProductDesc;
            this._MachineNo = _vMachineNo;
            this._MouldNo = _vMouldNo;

            this._StandCycle = _vStandCycle;
            this._MaxInjectionCycle = _vMaxInjectionCycle;
            this._MinInjectionCycle = _vMinInjectionCycle;
            this._UpdateStandCycle = _vUpdateStandCycle;
            this._UpdateMaxInjectionCycle = _vUpdateMaxInjectionCycle;
            this._UpdateMinInjectionCycle = _vUpdateMinInjectionCycle;
            this._UpdateTime = _vUpdateTime;
            this._CreateTime = _vCreateTime;
            this._UpdateEmployee = _vUpdateEmployee;
        }

        public UpdateCycle_MDL(int _vID, string _vDO_No, string _vProductNo, string _vProductDesc, string _vMachineNo, string _vMouldNo, string _vStandCycle, string _vMaxInjectionCycle, string _vMinInjectionCycle, string _vUpdateStandCycle, string _vUpdateMaxInjectionCycle, string _vUpdateMinInjectionCycle, string _vUpdateTime
            ,string _vUpdateEmployee)
        {
            this._ID = _vID;
            this._DO_NO = _vDO_No;
            this._ProductNo = _vProductNo;

            this._ProductDesc = _vProductDesc;

            this._MachineNo = _vMachineNo;

            this._MouldNo = _vMouldNo;
            this._StandCycle = _vStandCycle;
            this._MaxInjectionCycle = _vMaxInjectionCycle;
            this._MinInjectionCycle = _vMinInjectionCycle;
            this._UpdateStandCycle = _vUpdateStandCycle;
            this._UpdateMaxInjectionCycle = _vUpdateMaxInjectionCycle;
            this._UpdateMinInjectionCycle = _vUpdateMinInjectionCycle;
            this._UpdateTime = _vUpdateTime;
            this._UpdateEmployee = _vUpdateEmployee;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string DO_NO
        {
            get { return _DO_NO; }
            set { _DO_NO = value; }
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
        public string UpdateStandCycle
        {
            get { return _UpdateStandCycle; }
            set { _UpdateStandCycle = value; }
        }
        public string UpdateMaxInjectionCycle
        {
            get { return _UpdateMaxInjectionCycle; }
            set { _UpdateMaxInjectionCycle = value; }
        }
        public string UpdateMinInjectionCycle
        {
            get { return _UpdateMinInjectionCycle; }
            set { _UpdateMinInjectionCycle = value; }
        }
        public string UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }
        public string CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        public string UpdateEmployee
        {
            get { return _UpdateEmployee; }
            set { _UpdateEmployee = value; }
        }
        public string LastTime
        {
            get { return _LastTime; }
            set { _LastTime = value; }
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
    }
}
