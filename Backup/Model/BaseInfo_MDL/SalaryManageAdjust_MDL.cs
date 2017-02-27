using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class SalaryManageAdjust_MDL
    {
        private int _iD;

        private string _employeeName;
        private string _EmpID;
        private string _cardID;
        private string _do_No;
        private string _machineNo;
        private string _mouldNo;
        private string _productNo;
        private string _productDesc;

        private string _BeginDate;
        private string _EndDate;

     
        private string _AdjustWage;
      
        private string _Remark;
        private string _CreateDate;

        public SalaryManageAdjust_MDL() { }
        public SalaryManageAdjust_MDL(string vDO_NO) { this._do_No = vDO_NO; }
        public SalaryManageAdjust_MDL(int vID, string vEmployeeName, string vCardID, string vDo_No, string vMachineNo, string vMouldNo, string vProductNo,
                                string vProductDesc, string vBeginDate, string vEndDate, string vAdjustWage,  string vRemark,
                           string vCreateDate,string vEmpID)
        {
            this._iD = vID;
            this._employeeName = vEmployeeName;
            this._cardID = vCardID;
            this._do_No = vDo_No;
            this._machineNo = vMachineNo;
            this._mouldNo = vMouldNo;
            this._productNo = vProductNo;
            this._productDesc = vProductDesc;
            
            this._BeginDate = vBeginDate;
            this._EndDate = vEndDate;
            
            this._AdjustWage = vAdjustWage;

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
            get { return this._do_No; }
            set { this._do_No = value; }
        }

        public string MachineNo
        {
            get { return this._machineNo; }
            set { this._machineNo = value; }
        }

        public string MouldNo
        {
            get { return this._mouldNo; }
            set { this._mouldNo = value; }
        }

        public string ProductNo
        {
            get { return _productNo; }
            set { _productNo = value; }
        }

        public string ProductDesc
        {
            get { return _productDesc; }
            set { _productDesc = value; }
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

        public string AdjustWage
        {
            get { return this._AdjustWage; }
            set { this._AdjustWage = value; }
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
        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

    }
}
