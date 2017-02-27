using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class UpdateMacCycle_MDL : LikeQuery
    {
        private int _ID;
        private string _DispatchNo;
        private string _MachineNo;
        private string _MouldNo;
        private string _ProductNo;
        private string _ProductDesc;
        private string _EndDate;
        private string _LastCycle;
        private string _ThisCycle;

        public UpdateMacCycle_MDL( string vDispatchNo, string vMachineNo, string vMouldNo, string vProductNo
                             ,string vProductDesc,string vLastCycle,string vThisCycle,string vEndDate)
        {
            this._DispatchNo=vDispatchNo ;
            this._MachineNo=vMachineNo;
            this._MouldNo=vMouldNo ;
            this._ProductNo=vProductNo;
            this._ProductDesc=vProductDesc;
            this._LastCycle=vLastCycle;
            this._ThisCycle=vThisCycle;
            this._EndDate = vEndDate;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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
            set { _ProductNo= value; }
        }
        public string ProductDesc
        {
            get { return _ProductDesc; }
            set { _ProductDesc = value; }
        }
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        public string LastCycle
        {
            get { return _LastCycle; }
            set { _LastCycle = value; }
        }
        public string ThisCycle
        {
            get { return _ThisCycle; }
            set { _ThisCycle = value; }
        }

    }
}
