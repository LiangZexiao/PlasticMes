using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class Employee_MDL
    {
        private int _ID;
        private ArrayList _IDs;
        private string _EmployeeID;
        private string _EmployeeName_CN;
        private byte[] _Photo;

        private string _IDCardNo;
        private string _Sex;
        private string _Birthday;
        private string _Department;
        private string _DeptName;
        private string _Province;
        private string _RankLevel;
        private string _Rank;
        private string _RankDesc;
        private string _HireDate;
        private string _Remark;
        private string _Tel;
        private string _IcCarId;
        private string _DeptID;
        private string _EMail;
        private string _IcCardRight;
        private string  _Invalid;
        private string _InvalidCode;

        public Employee_MDL() { }
        public Employee_MDL(string vEmployeeID) { this._EmployeeID = vEmployeeID; }
        public Employee_MDL(int vID,
             string vEmployeeID, string vEmployeeName_CN,  byte[] vPhoto, string vIDCardNo,
              string vSex, string vBirthday, string vDepartment, string vDeptName, string vProvince, string vRankLevel,
             string vRank, string vRankDesc, string vHireDate, string vTel, string vRemark )
        {
            this._ID = vID;
            this._EmployeeID = vEmployeeID;
            this._EmployeeName_CN = vEmployeeName_CN;
            this._Photo = vPhoto;
            this._IDCardNo = vIDCardNo;
            this._Sex = vSex;
            this._Birthday = vBirthday;
            this._Department = vDepartment;
            this._DeptName = vDeptName;
            this._Province = vProvince;
            this._RankLevel = vRankLevel;

            this._Rank = vRank;
            this._RankDesc = vRankDesc;
            this._HireDate = vHireDate;
            this._Tel = vTel;
            this._Remark = vRemark;
        }
        public Employee_MDL(int vID,
            string vEmployeeID, string vEmployeeName_CN, byte[] vPhoto, string vIDCardNo,
             string vSex, string vBirthday, string vDepartment, string vDeptName
            , string vProvince, string vRankLevel,string vRank, string vRankDesc, string vHireDate
             , string vTel, string vRemark, string vemail,string valid)
        {
            this._ID = vID;
            this._EmployeeID = vEmployeeID;
            this._EmployeeName_CN = vEmployeeName_CN;
            this._Photo = vPhoto;
            this._IDCardNo = vIDCardNo;

            this._Sex = vSex;
            this._Birthday = vBirthday;
            this._Department = vDepartment;
            this._DeptName = vDeptName;
            this._Province = vProvince;
            this._RankLevel = vRankLevel;

            this._Rank = vRank;
            this._RankDesc = vRankDesc;
            this._HireDate = vHireDate;
            this._Tel = vTel;
            this._Remark = vRemark;
            this._EMail = vemail;
            this._Invalid = valid;
        }

        //public Employee_MDL(int vID,
        //   string vEmployeeID, string vEmployeeName_CN, byte[] vPhoto, string vIDCardNo,
        //    string vSex, string vBirthday, string vDepartment, string vDeptName, string vProvince, string vRankLevel,
        //   string vRank, string vRankDesc, string vHireDate, string vTel, string vRemark, string viccarid,string vDeptID)
        //{
        //    this._ID = vID;
        //    this._EmployeeID = vEmployeeID;
        //    this._EmployeeName_CN = vEmployeeName_CN;
        //    this._Photo = vPhoto;
        //    this._IDCardNo = vIDCardNo;
           
        //    this._Sex = vSex;
        //    this._Birthday = vBirthday;
        //    this._Department = vDepartment;
        //    this._DeptName = vDeptName;
        //    this._Province = vProvince;
        //    this._RankLevel = vRankLevel;

        //    this._Rank = vRank;
        //    this._RankDesc = vRankDesc;
        //    this._HireDate = vHireDate;
        //    this._Tel = vTel;
        //    this._Remark = vRemark;
        //    this._IcCarId = viccarid;
        //    this._DeptID = vDeptID;
        //}

        public Employee_MDL(int vID,
          string vEmployeeID, string vEmployeeName_CN,  byte[] vPhoto,  string vIDCardNo,
          string vSex, string vBirthday, string vDepartment, string vDeptName, string vProvince, string vRankLevel,
          string vRank, string vRankDesc, string vHireDate, string vTel, string vRemark, string viccarid, string vDeptID,string vemail)
        {
            this._ID = vID;
            this._EmployeeID = vEmployeeID;
            this._EmployeeName_CN = vEmployeeName_CN;
            this._Photo = vPhoto;
            this._IDCardNo = vIDCardNo;
            
            this._Sex = vSex;
            this._Birthday = vBirthday;
            this._Department = vDepartment;
            this._DeptName = vDeptName;
            this._Province = vProvince;
            this._RankLevel = vRankLevel;

            this._Rank = vRank;
            this._RankDesc = vRankDesc;
            this._HireDate = vHireDate;
            this._Tel = vTel;
            this._Remark = vRemark;
            this._IcCarId = viccarid;
            this._DeptID = vDeptID;
            this._EMail = vemail;
        }
        
        public Employee_MDL(int vID,
          string vEmployeeID, string vEmployeeName_CN,  byte[] vPhoto,  string vIDCardNo,
          string vSex, string vBirthday, string vDepartment, string vDeptName, string vProvince, string vRankLevel,
          string vRank, string vRankDesc, string vHireDate, string vTel, string vRemark, string viccarid
            , string vDeptID, string vemail, string vIcCardRight,string validcode,string valid)
        {
            this._ID = vID;
            this._EmployeeID = vEmployeeID;
            this._EmployeeName_CN = vEmployeeName_CN;
            this._Photo = vPhoto;
            this._IDCardNo = vIDCardNo;
            
            this._Sex = vSex;
            this._Birthday = vBirthday;
            this._Department = vDepartment;
            this._DeptName = vDeptName;
            this._Province = vProvince;
            this._RankLevel = vRankLevel;

            this._Rank = vRank;
            this._RankDesc = vRankDesc;
            this._HireDate = vHireDate;
            this._Tel = vTel;
            this._Remark = vRemark;
            this._IcCarId = viccarid;
            this._DeptID = vDeptID;
            this._EMail = vemail;
            this._IcCardRight = vIcCardRight;
            this._InvalidCode = validcode;
            this._Invalid = valid;
        }
        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public ArrayList IDs
        {
            get { return _IDs; }
            set { _IDs = value; }
        }

        public string IcCarId
        {
            get { return _IcCarId; }
            set { _IcCarId = value; }
        }


        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public string EmployeeName_CN
        {
            get { return _EmployeeName_CN; }
            set { _EmployeeName_CN = value; }
        }

       
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

       

        public string IDCardNo
        {
            get { return _IDCardNo; }
            set { _IDCardNo = value; }
        }

      

        public string DeptID
        {
            get { return _DeptID; }
            set { _DeptID = value; }
        }

        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        public string Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }

        public string RankLevel
        {
            get { return _RankLevel; }
            set { _RankLevel = value; }
        }

        public string Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }

        public string RankDesc
        {
            get { return _RankDesc; }
            set { _RankDesc = value; }
        }

        public string HireDate
        {
            get { return _HireDate; }
            set { _HireDate = value; }
        }

        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }


        public string IcCardRight
        {
            get { return _IcCardRight; }
            set { _IcCardRight = value; }
        }


        public string Invalid
        {
            get { return _Invalid; }
            set { _Invalid = value; }
        }
        public string InvalidCode
        {
            get { return _InvalidCode; }
            set { _InvalidCode = value; }
        }
    }
}
