using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class SalaryManageTotal_MDL
    {
        //private int _iD;

        private string _employeeName;
        //private string _cardID;      

        private string _MachineWage;
        private string _TimeWage;
        private string _AdjustWage;
        private string _OtherWage;

        private string _CheckWage;
        private string _JobWage;
        private string _ServiceWage;
        private string _EmpID;
          
        private string _TotalWage;
        //private string _CreateDate;

        public SalaryManageTotal_MDL() { }
        public SalaryManageTotal_MDL(string vName) { this._employeeName = vName; }
        public SalaryManageTotal_MDL(string vEmployeeName, string vMachineWage, string vTimeWage,
            string vAdjustWage, string vOtherWage, string vTotalWage, string vCheckWage,
            string vJobWage, string vServiceWage,string vEmpID)
        {
            //this._iD = vID;
            this._employeeName = vEmployeeName;
            
          
            this._MachineWage = vMachineWage;
            this._TimeWage = vTimeWage;
            this._AdjustWage = vAdjustWage;
            this._OtherWage = vOtherWage;
            this._TotalWage = vTotalWage;
            this._CheckWage = vCheckWage;
            this._JobWage = vJobWage;
            this._ServiceWage = vServiceWage;
            this._EmpID = vEmpID;

            //this._Remark = vRemark;
            //this._CreateDate = vCreateDate;
        }

        //public int ID
        //{
        //    get { return this._iD; }
        //    set { this._iD = value; }
        //}

        public string EmployeeName
        {
            get { return this._employeeName; }
            set { this._employeeName = value; }
        }

        public string MachineWage
        {
            get { return this._MachineWage; }
            set { this._MachineWage = value; }
        }
        public string TimeWage
        {
            get { return this._TimeWage; }
            set { this._TimeWage = value; }
        }
        public string AdjustWage
        {
            get { return this._AdjustWage; }
            set { this._AdjustWage = value; }
        }
        public string OtherWage
        {
            get { return this._OtherWage; }
            set { this._OtherWage = value; }
        }
        public string TotalWage
        {
            get { return this._TotalWage; }
            set { this._TotalWage = value; }
        }
        public string CheckWage
        {
            get { return this._CheckWage; }
            set { this._CheckWage = value; }
        }
        public string JobWage
        {
            get { return this._JobWage; }
            set { this._JobWage = value; }
        }
        public string ServiceWage
        {
            get { return this._ServiceWage; }
            set { this._ServiceWage = value; }
        }
        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        //public string CreateDate
        //{
        //    get { return _CreateDate; }
        //    set { _CreateDate = value; }
        //}

    }
}
