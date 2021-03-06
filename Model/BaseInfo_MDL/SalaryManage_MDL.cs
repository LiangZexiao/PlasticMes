using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class SalaryManage_MDL
    {
        private int _iD;

        private string _employeeName;
        private string _cardID;
        private string _EmpID;

        private string _DoNo;
        private string _MachineNo;
        private string _MouldNo;
        private string _ProductNo;
        private string _ProductDesc;
        private string _Num;
        
        private string _BeginDate;
        private string _EndDate;


        private string _MachineWage;
        private string _TimeWage;
    
        private string _Remark;
        private string _CreateDate;

        public SalaryManage_MDL() { }
        public SalaryManage_MDL(string vDoNo) { this._DoNo = vDoNo; }
        public SalaryManage_MDL(int vID, string vEmployeeName, string vCardID, string vDoNo, string vMachineNo, string vMouldNo, string vProductNo, string vProductDesc, string vNum,
                                string vBeginDate, string vEndDate, string vMachineWage, string vTimeWage, string vRemark, string vCreateDate,string vEmpID)
        {
            this._iD = vID;
            this._employeeName = vEmployeeName;
            this._cardID = vCardID;
            this._DoNo = vDoNo;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
            this._ProductNo = vProductNo;
            this._ProductDesc = vProductDesc;
            this._Num = vNum;
           
            this._BeginDate = vBeginDate;
            this._EndDate = vEndDate;

            this._MachineWage = vMachineWage;
            this._TimeWage = vTimeWage;
         
            this._Remark = vRemark;
            this._CreateDate = vCreateDate;
            this._EmpID = vEmpID;
        }

        public int ID
        {
            get { return this._iD; }
            set { this._iD = value; }
        }

        public string EmployeeName
        {
            get { return this._employeeName; }
            set { this._employeeName = value; }
        }

        public string CardID
        {
            get { return this._cardID; }
            set { this._cardID = value; }
        }

        public string Do_No
        {
            get { return this._DoNo; }
            set { this._DoNo = value; }
        }

        public string MachineNo
        {
            get { return this._MachineNo; }
            set { this._MachineNo = value; }
        }
        public string MouldNo
        {
            get { return this._MouldNo; }
            set { this._MouldNo = value; }
        }
        public string ProductNo
        {
            get { return this._ProductNo; }
            set { this._ProductNo = value; }
        }
        public string ProductDesc
        {
            get { return this._ProductDesc; }
            set { this._ProductDesc = value; }
        }
        public string Num
        {
            get { return this._Num; }
            set { this._Num = value; }
        }
        public string EmpID
        {
            get { return this._EmpID; }
            set { _EmpID = value; }
        }
        public string BeginDate
        {
            get { return this._BeginDate; }
            set { this._BeginDate = value; }
        }

        public string EndDate
        {
            get { return this._EndDate; }
            set { this._EndDate = value; }
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
      
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

    }
}
