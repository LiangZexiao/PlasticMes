#region chief
/*
 * update by fsq 2009.12.11
 * remark:新增一个班次类型（BcCode）
 * 
 * */
#endregion 

using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Call_MDL
{

    public class CallConfig_MDL
    {
        private string _iD;

        private string _callStr;

        private string _callTypeID;

        private string _unitType;

        private string _unitTypeID;

        private string _callValue;

        private string _unitValue;

        private string _createTime;

        private string _machineNo;

        private string _dONO;
        private string _callID;

        private string _sendNum;


        private string _upNum;
        private string _downNum;

        private string _sendEmployee;

        private string _HuanMu;

        private string _HuanLiao;

        private string _HuanDan;

        private string _FuShe;

        private string _JiQi;

        private string _MuJu;

        private string _DaiLiao;

        private string _WuDingDan;

        private string _QiTa;

        private string _DaiRen;

        private string _ZiDingYi;

        private string _BcCode;

       
        

        public CallConfig_MDL() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="callStr">类型(异常/提示)</param>
        /// <param name="callTypeID">类型id</param>
        /// <param name="unitType">计量单位</param>
        /// <param name="unitTypeID">计量单位ID</param>
        /// <param name="callValue">临界值</param>
        /// <param name="unitValue">单位值</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="machineNo">机器编号</param>
        /// <param name="dONO">派工单号</param>
        public CallConfig_MDL(string ID, string callStr, string callTypeID, string unitType, string unitTypeID, string callValue, string unitValue, string createTime, string machineNo, string dONO, string vSendNum)
        {
            this._iD = ID;
            this._callStr = callStr;

            this._callTypeID = callTypeID;

            this._unitType = unitType;

            this._unitTypeID = unitTypeID;

            this._callValue = callValue;

            this._unitValue = unitValue;

            this._createTime = createTime;

            this._machineNo = machineNo;

            this._dONO = dONO;

            this._sendNum = vSendNum;
        }
        
        public CallConfig_MDL(string ID, string CallID, string callStr, string callTypeID,
             string unitType, string unitTypeID, string callValue, string unitValue,
             string createTime, string machineNo, string dONO, string vSendNum, 
             string vupNum, string vdownNum, string vsendEmployee,string vBcCode)
        {
            this._iD = ID;
            this._callStr = callStr;

            this._callTypeID = callTypeID;

            this._unitType = unitType;

            this._unitTypeID = unitTypeID;

            this._callValue = callValue;

            this._unitValue = unitValue;

            this._createTime = createTime;

            this._machineNo = machineNo;

            this._dONO = dONO;
            this.CallID = CallID;
            this._sendNum = vSendNum;
            this._upNum = vupNum;
            this._downNum = vdownNum;

            this._sendEmployee = vsendEmployee;
            this._BcCode = vBcCode;
        }

        public CallConfig_MDL(string ID, string CallID, string callStr, string callTypeID,
             string unitType, string unitTypeID, string callValue, string unitValue,
             string createTime, string machineNo, string dONO, string vSendNum,
             string vupNum, string vdownNum, string vsendEmployee,
             string vHuanMu, string vHuanLiao, string vHuanDan, string vFuShe,
             string vJiQi, string vMuJu, string vDaiLiao, string vWuDingDan,
             string vQiTa, string vDaiRen, string vZiDingY,string vBcCode)
        {
            this._iD = ID;
            this._callStr = callStr;

            this._callTypeID = callTypeID;

            this._unitType = unitType;

            this._unitTypeID = unitTypeID;

            this._callValue = callValue;

            this._unitValue = unitValue;

            this._createTime = createTime;

            this._machineNo = machineNo;

            this._dONO = dONO;
            this.CallID = CallID;
            this._sendNum = vSendNum;
            this._upNum = vupNum;
            this._downNum = vdownNum;

            this._sendEmployee = vsendEmployee;
            this._HuanMu = vHuanMu;
            this._HuanLiao = vHuanLiao;
            this._HuanDan = vHuanDan;
            this._FuShe = vFuShe;
            this._JiQi = vJiQi;
            this._MuJu = vMuJu;
            this._DaiLiao = vDaiLiao;
            this._WuDingDan = vWuDingDan;
            this._QiTa = vQiTa;
            this._DaiRen = vDaiRen;
            this._ZiDingYi = vZiDingY;
            this._BcCode = vBcCode;
        }
        
        public string ID
        {
            get
            {
                return this._iD;
            }
            set
            {
                this._iD = value;
            }
        }

        public string CallID
        {
            get { return _callID; }
            set { _callID = value; }
        }

        public string CallStr
        {
            get
            {
                return this._callStr;
            }
            set
            {
                this._callStr = value;
            }
        }

        public string CallTypeID
        {
            get
            {
                return this._callTypeID;
            }
            set
            {
                this._callTypeID = value;
            }
        }

        public string UnitType
        {
            get
            {
                return this._unitType;
            }
            set
            {
                this._unitType = value;
            }
        }

        public string UnitTypeID
        {
            get
            {
                return this._unitTypeID;
            }
            set
            {
                this._unitTypeID = value;
            }
        }

        public string CallValue
        {
            get
            {
                return this._callValue;
            }
            set
            {
                this._callValue = value;
            }
        }

        public string UnitValue
        {
            get
            {
                return this._unitValue;
            }
            set
            {
                this._unitValue = value;
            }
        }

        public string CreateTime
        {
            get
            {
                return this._createTime;
            }
            set
            {
                this._createTime = value;
            }
        }

        public string MachineNo
        {
            get
            {
                return this._machineNo;
            }
            set
            {
                this._machineNo = value;
            }
        }

        public string DONO
        {
            get
            {
                return this._dONO;
            }
            set
            {
                this._dONO = value;
            }
        }

        public string SendNum
        {
            get { return _sendNum; }
            set { _sendNum = value; }
        }
     
        public string UpNum
        {
            get { return _upNum; }
            set { _upNum = value; }
        }

        public string DownNum
        {
            get { return _downNum; }
            set { _downNum = value; }
        }

        public string SendEmployee
        {
            get { return _sendEmployee; }
            set { _sendEmployee = value; }
        }

        public string HuanMu
        {
            get { return _HuanMu; }
            set { _HuanMu = value; }
        }

        public string HuanLiao
        {
            get { return _HuanLiao; }
            set { _HuanLiao = value; }
        }

        public string HuanDan
        {
            get { return _HuanDan; }
            set { _HuanDan = value; }
        }

        public string JiQi
        {
            get { return _JiQi; }
            set { _JiQi = value; }
        }

        public string MuJu
        {
            get { return _MuJu; }
            set { _MuJu = value; }
        }

        public string DaiLiao
        {
            get { return _DaiLiao; }
            set { _DaiLiao = value; }
        }

        public string WuDingDan
        {
            get { return _WuDingDan; }
            set { _WuDingDan = value; }
        }

        public string QiTa
        {
            get { return _QiTa; }
            set { _QiTa = value; }
        }
        
        public string DaiRen
        {
            get { return _DaiRen; }
            set { _DaiRen = value; }
        }
       
        public string ZiDingYi
        {
            get { return _ZiDingYi; }
            set { _ZiDingYi = value; }
        }

        public string FuShe
        {
            get { return _FuShe; }
            set { _FuShe = value; }
        }

        public string BcCode
        {
            get { return _BcCode; }
            set { _BcCode = value; }
        }

    }
}
