using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class ManMachineMap_MDL
    {
        private int _ID;

        private string _EmployeeID;
        private string _MachineNo;
        private string _WorkGrade;
        private string _WorkDate;
        private string _Remark;
        private string _EmployeeName_CN;

        public ManMachineMap_MDL(){}
        public ManMachineMap_MDL(int vID,
           string vEmployeeID,
           string vMachineNo,
           string vWorkGrade,
           string vWorkDate,
           string vRemark,
           string vEmployeeName_CN
            )
        {
            this._ID = vID;

            this._EmployeeID = vEmployeeID;
            this._MachineNo = vMachineNo;
            this._WorkGrade = vWorkGrade;
            this._WorkDate = vWorkDate;
            this._Remark = vRemark;
            this._EmployeeName_CN = vEmployeeName_CN;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; }
        }

        public string WorkGrade
        {
            get { return _WorkGrade; }
            set { _WorkGrade = value; }
        }

        public string WorkDate
        {
            get { return _WorkDate; }
            set { _WorkDate = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string EmployeeName_CN
        {
            get { return _EmployeeName_CN; }
            set { _EmployeeName_CN = value; }
        }
        
    }
}
