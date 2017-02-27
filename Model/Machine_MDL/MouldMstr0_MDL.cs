using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Machine_MDL
{
    public class MouldMstr0_MDL:LikeQuery
    {
        private int _ID;
        private string _Mould_Code;
        private string _Mould_Name_CN;
        private string _Mould_Name_EN;
        private string _Mould_Type;
        private string _FitMachineTonMin;
        private string _FitMachineTonMax;
        private string _ProductNo;
        private string _SocketNum;
        private string _GoodSocketNum;

        private string _Mould_Group;
        private string _Mould_Manufacturer;
        private string _Mould_MadeDate;
        private string _Mould_RackNo;

        private string _Mould_Price;
        private string _Mould_MaintenaneCycle;
        private string _Mould_ChgTime;
        private string _Mould_ChgCost;
        private byte[] _Mould_Photo;
        private object _Mould_PhotoType;
        private string _Memo;

        public MouldMstr0_MDL() {}
        public MouldMstr0_MDL(int vID,
             string vMould_Code,
             string vMould_Name_CN,
             string vMould_Name_EN,
             string vMould_Type,
             string vProductNo,
             string vSocketNum,
             string vGoodSocketNum,
             string vFitMachineTonMin,
             string vFitMachineTonMax,
             string vMould_Group,
             string vMould_Manufacturer,
             string vMould_MadeDate,
             string vMould_RackNo,
             string vMould_Price,
             string vMould_MaintenaneCycle,
             string vMould_ChgTime,
             string vMould_ChgCost,
             byte[] vMould_Photo,
             object vMould_PhotoType,
             string vMemo
            )
        {
            this._ID = vID;
            this._Mould_Code = vMould_Code;
            this._Mould_Name_CN = vMould_Name_CN;
            this._Mould_Name_EN = vMould_Name_EN;
            this._Mould_Type = vMould_Type;
            this._ProductNo = vProductNo;
            this._SocketNum = vSocketNum;
            this._GoodSocketNum = vGoodSocketNum;
            this._FitMachineTonMin = vFitMachineTonMin;
            this._FitMachineTonMax = vFitMachineTonMax;

            this._Mould_Group = vMould_Group;
            this._Mould_Manufacturer = vMould_Manufacturer;
            this._Mould_MadeDate = vMould_MadeDate;
            this._Mould_RackNo = vMould_RackNo;
            this._Mould_Price = vMould_Price;

            this._Mould_MaintenaneCycle = vMould_MaintenaneCycle;
            this._Mould_ChgTime = vMould_ChgTime;
            this._Mould_ChgCost = vMould_ChgCost;
            this._Mould_Photo = vMould_Photo;
            this._Mould_PhotoType = vMould_PhotoType;
            this._Memo = vMemo;


        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Mould_Code
        {
            get { return _Mould_Code; }
            set { _Mould_Code = value; }
        }

        public string Mould_Name_CN
        {
            get { return _Mould_Name_CN; }
            set { _Mould_Name_CN = value; }
        }

        public string Mould_Name_EN
        {
            get { return _Mould_Name_EN; }
            set { _Mould_Name_EN = value; }
        }

        public string Mould_Type
        {
            get { return _Mould_Type; }
            set { _Mould_Type = value; }
        }

        public string FitMachineTonMin
        {
            get { return (string.IsNullOrEmpty(_FitMachineTonMin)) ? "0" : _FitMachineTonMin; }
            set { _FitMachineTonMin = value; }
        }
        
        public string FitMachineTonMax
        {
            get { return (string.IsNullOrEmpty(_FitMachineTonMax)) ? "0" : _FitMachineTonMax; }
            set { _FitMachineTonMax = value; }
        }

        public string ProductNo
        {
            get { return _ProductNo; }
            set { _ProductNo = value; }
        }

        public string SocketNum
        {
            get { return (string.IsNullOrEmpty(_SocketNum)) ? "0" : _SocketNum; }
            set { _SocketNum = value; }
        }

        public string GoodSocketNum
        {
            get { return (string.IsNullOrEmpty(_GoodSocketNum)) ? "0" : _GoodSocketNum; }
            set { _GoodSocketNum = value; }
        }

        public string Mould_Group
        {
            get { return _Mould_Group; }
            set { _Mould_Group = value; }
        }

        public string Mould_Manufacturer
        {
            get { return _Mould_Manufacturer; }
            set { _Mould_Manufacturer = value; }
        }

        public string Mould_MadeDate
        {
            get { return _Mould_MadeDate; }
            set { _Mould_MadeDate = value; }
        }

        public string Mould_RackNo
        {
            get { return _Mould_RackNo; }
            set { _Mould_RackNo = value; }
        }

        public string Mould_Price
        {
            get { return _Mould_Price; }
            set { _Mould_Price = value; }
        }

        public string Mould_MaintenaneCycle
        {
            get { return _Mould_MaintenaneCycle; }
            set { _Mould_MaintenaneCycle = value; }
        }

        public string Mould_ChgTime
        {
            get { return _Mould_ChgTime; }
            set { _Mould_ChgTime = value; }
        }

        public string Mould_ChgCost
        {
            get { return _Mould_ChgCost; }
            set { _Mould_ChgCost = value; }
        }

        public byte[] Mould_Photo
        {
            get { return _Mould_Photo; }
            set { _Mould_Photo = value; }
        }

        public object Mould_PhotoType
        {
            get { return _Mould_PhotoType; }
            set { _Mould_PhotoType = value; }
        }

        public string Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }
        
    }
}