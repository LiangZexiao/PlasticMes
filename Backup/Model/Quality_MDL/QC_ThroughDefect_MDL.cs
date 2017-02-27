using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Quality_MDL
{
    public class QC_ThroughDefect_MDL : LikeQuery
    {
        private int _ID;
        private string _DispatchNo;
        private string _CardId;
        private string _QueLiaoNum;
        private string _HuaHenNum;
        private string _SeChaNum;

        private string _XiaCiNum;
        private string _QueJiaoNum;
        private string _SuoShuiNum;
        private string _BianXingNum;
        private string _LiaoHuaNum;

        private string _PiFengNum;
        private string _ChicunNum;
        private string _ShaoJiaoNum;
        private string _JiaWenNum;
        private string _KaiLieNum;
        private string _QiTaNum;
        private string _AdjustDate;
        private string _CreateDate;
        private string _EmpID;
        private string _Confirm;
        private string _ConfirmDate;
        private string _bz;

        public QC_ThroughDefect_MDL() { }
        public QC_ThroughDefect_MDL(int vID,
               string vDispatchNo, string vCardId, string vQueLiaoNum, string vHuaHenNum,
               string vSeChaNum, string vXiaCiNum, string vQueJiaoNum, string vSuoShuiNum, string vBianXingNum, string vLiaoHuaNum, string vPiFengNum,
               string vChicunNum, string vShaoJiaoNum, string vJiaWenNum, string vKaiLieNum, string vQiTaNum, string vAdjustDate, string vCreateDate, string vEmpID, string vConfirm, string vConfirmDate,string vbz
           )
        {
            this._ID = vID;
            this._DispatchNo = vDispatchNo;
            this._CardId = vCardId;
            this._XiaCiNum = vXiaCiNum;
            this._QueLiaoNum = vQueLiaoNum;
            this._HuaHenNum = vHuaHenNum;
            this._SeChaNum = vSeChaNum;
            this._QueJiaoNum = vQueJiaoNum;
            this._SuoShuiNum = vSuoShuiNum;
            this._BianXingNum = vBianXingNum;
            this._LiaoHuaNum = vLiaoHuaNum;

            this._PiFengNum = vPiFengNum;
            this._ChicunNum = vChicunNum;
            this._ShaoJiaoNum = vShaoJiaoNum;
            this._JiaWenNum = vJiaWenNum;
            this._KaiLieNum = vKaiLieNum;
            this._QiTaNum = vQiTaNum;
            this._AdjustDate = vAdjustDate;
            this._CreateDate = vCreateDate;
            this._EmpID = vEmpID;
            this._Confirm = vConfirm;
            this._ConfirmDate = vConfirmDate;
            this._bz = vbz;
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

        public string CardId
        {
            get { return _CardId; }
            set { _CardId = value; }
        }

        public string QueLiaoNum
        {
            get { return _QueLiaoNum; }
            set { _QueLiaoNum = value; }
        }

        public string HuaHenNum
        {
            get { return _HuaHenNum; }
            set { _HuaHenNum = value; }
        }

        public string SeChaNum
        {
            get { return _SeChaNum; }
            set { _SeChaNum = value; }
        }

        public string XiaCiNum
        {
            get { return _XiaCiNum; }
            set { _XiaCiNum = value; }
        }

        public string QueJiaoNum
        {
            get { return _QueJiaoNum; }
            set { _QueJiaoNum = value; }
        }

        public string SuoShuiNum
        {
            get { return _SuoShuiNum; }
            set { _SuoShuiNum = value; }
        }

        public string BianXingNum
        {
            get { return _BianXingNum; }
            set { _BianXingNum = value; }
        }

        public string LiaoHuaNum
        {
            get { return _LiaoHuaNum; }
            set { _LiaoHuaNum = value; }
        }

        public string PiFengNum
        {
            get { return _PiFengNum; }
            set { _PiFengNum = value; }
        }

        public string ChicunNum
        {
            get { return _ChicunNum; }
            set { _ChicunNum = value; }
        }

        public string ShaoJiaoNum
        {
            get { return _ShaoJiaoNum; }
            set { _ShaoJiaoNum = value; }
        }

        public string JiaWenNum
        {
            get { return _JiaWenNum; }
            set { _JiaWenNum = value; }
        }

        public string KaiLieNum
        {
            get { return _KaiLieNum; }
            set { _KaiLieNum = value; }
        }

        public string QiTaNum
        {
            get { return _QiTaNum; }
            set { _QiTaNum = value; }
        }

        public string AdjustDate
        {
            get { return _AdjustDate; }
            set { _AdjustDate = value; }
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

        public string Confirm
        {
            get { return _Confirm; }
            set { _Confirm = value; }
        }

        public string ConfirmDate
        {
            get { return _ConfirmDate; }
            set { _ConfirmDate = value; }
        }

        public string bz
        {
            get { return _bz; }
            set { _bz = value; }
        }
    }
}
