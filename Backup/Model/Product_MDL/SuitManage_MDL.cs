using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class SuitManage_MDL
    {
        private int _iD;

        private string _plantBristlesCode;

        private string _plantBristlesDesc;

        private string _WireBrushMould;

        private string _WireBrushMouldDesc;
        
        private string _suitMachine;

        private string _holeNum;

        private string _holeDiameter;

        private string _wireBrushWeight;

        private string _wireWeight;

        private string _systemNo;

        private string _cutLength;

        private string _outNum;

        private string _getKnifeFoot;

        private string _wireTypeCode;

        private string _wireDesc;

        private string _modiHeight;

        private string _brushWireTypeCode;

        private string _rally;

        private string _TrayNum;

        private string _ColumnNum;

        private string _ColumnCount;

        private byte[] _productImg;

        private string _StandEmployee;

        private string _ver;

        private string _verModiContent;

        private string _verModiReason;

        private string _lastUpdator;

        private string _lastUpdateDate;

        private string _remark;

        private string _CreateDate;

     
        public SuitManage_MDL() { }

        public SuitManage_MDL(int vID, string vPlantBristlesCode, string vPlantBristlesDesc,string vWireBrushMould,string vWireBrushMouldDesc, string vSuitMachine, string vHoleNum, string vHoleDiameter,
                              string vWireBrushWeight, string vWireWeight, string vSystemNo, string vCutLength, string vOutNum, string vGetKnifeFoot,
                              string vStandEmployee, string vWireTypeCode, string vWireDesc, string vModiHeight, string vBrushWireTypeCode, string vRally, string vTrayNum, string vColumnNum, string vColumnCount,
                              byte[] vProductImg, string vVer, string vVerModiContent, string vVerModiReason, string vLastUpdator, string vLastUpdateDate, string vRemark)
        {
            this._iD = vID;
            this._plantBristlesCode = vPlantBristlesCode;
            this._plantBristlesDesc = vPlantBristlesDesc;
            this._WireBrushMould = vWireBrushMould;
            this._WireBrushMouldDesc = vWireBrushMouldDesc;
            this._suitMachine = vSuitMachine;
            this._holeNum = vHoleNum;
            this._holeDiameter = vHoleDiameter;
            this._wireBrushWeight = vWireBrushWeight;
            this._wireWeight = vWireWeight;
            this._systemNo = vSystemNo;
            this._cutLength = vCutLength;
            this._outNum = vOutNum;
            this._getKnifeFoot = vGetKnifeFoot;
            this._wireTypeCode = vWireTypeCode;
            this._wireDesc = vWireDesc;
            this._modiHeight = vModiHeight;
            this._brushWireTypeCode = vBrushWireTypeCode;
            this._rally = vRally;
            this._TrayNum = vTrayNum;
            this._ColumnNum = vColumnNum;
            this._ColumnCount = vColumnCount;
            this._productImg = vProductImg;
            this._StandEmployee = vStandEmployee;
            this._ver = vVer;
            this._verModiContent = vVerModiContent;
            this._verModiReason = vVerModiReason;
            this._lastUpdator = vLastUpdator;
            this._lastUpdateDate = vLastUpdateDate;
            this._remark = vRemark;
        }

        public SuitManage_MDL(int vID, string vPlantBristlesCode, string vWireBrushMould, string vWireBrushMouldDesc,string vCreateDate)
        {
            this._iD = vID;
            this._plantBristlesCode = vPlantBristlesCode;
            this._WireBrushMould = vWireBrushMould;
            this._WireBrushMouldDesc = vWireBrushMouldDesc;
            this._CreateDate = vCreateDate;
        }
        public int ID
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

        public string PlantBristlesCode
        {
            get
            {
                return this._plantBristlesCode;
            }
            set
            {
                this._plantBristlesCode = value;
            }
        }

      
        public string PlantBristlesDesc
        {
            get
            {
                return this._plantBristlesDesc;
            }
            set
            {
                this._plantBristlesDesc = value;
            }
        }
        public string WireBrushMould
        {
            get { return _WireBrushMould; }
            set { _WireBrushMould = value; }
        }


        public string WireBrushMouldDesc
        {
            get { return _WireBrushMouldDesc; }
            set { _WireBrushMouldDesc = value; }
        }

      
        public string SuitMachine
        {
            get
            {
                return this._suitMachine;
            }
            set
            {
                this._suitMachine = value;
            }
        }

      
        public string HoleNum
        {
            get
            {
                return this._holeNum;
            }
            set
            {
                this._holeNum = value;
            }
        }

      
        public string HoleDiameter
        {
            get
            {
                return this._holeDiameter;
            }
            set
            {
                this._holeDiameter = value;
            }
        }

      
        public string WireBrushWeight
        {
            get
            {
                return this._wireBrushWeight;
            }
            set
            {
                this._wireBrushWeight = value;
            }
        }

      
        public string WireWeight
        {
            get
            {
                return this._wireWeight;
            }
            set
            {
                this._wireWeight = value;
            }
        }

      
        public string SystemNo
        {
            get
            {
                return this._systemNo;
            }
            set
            {
                this._systemNo = value;
            }
        }

      
        public string CutLength
        {
            get
            {
                return this._cutLength;
            }
            set
            {
                this._cutLength = value;
            }
        }

      
        public string OutNum
        {
            get
            {
                return this._outNum;
            }
            set
            {
                this._outNum = value;
            }
        }

      
        public string GetKnifeFoot
        {
            get
            {
                return this._getKnifeFoot;
            }
            set
            {
                this._getKnifeFoot = value;
            }
        }
      
        public string WireTypeCode
        {
            get
            {
                return this._wireTypeCode;
            }
            set
            {
                this._wireTypeCode = value;
            }
        }

      
        public string WireDesc
        {
            get
            {
                return this._wireDesc;
            }
            set
            {
                this._wireDesc = value;
            }
        }

      
        public string ModiHeight
        {
            get
            {
                return this._modiHeight;
            }
            set
            {
                this._modiHeight = value;
            }
        }

      
        public string BrushWireTypeCode
        {
            get
            {
                return this._brushWireTypeCode;
            }
            set
            {
                this._brushWireTypeCode = value;
            }
        }

      
        public string Rally
        {
            get
            {
                return this._rally;
            }
            set
            {
                this._rally = value;
            }
        }

        public string TrayNum
        {
            get { return _TrayNum; }
            set { _TrayNum = value; }
        }

        public string ColumnNum
        {
            get { return _ColumnNum; }
            set { _ColumnNum = value; }
        }

        public string ColumnCount
        {
            get { return _ColumnCount; }
            set { _ColumnCount = value; }
        }
        public byte[] ProductImg
        {
            get
            {
                return this._productImg;
            }
            set
            {
                this._productImg = value;
            }
        }

        public string StandEmployee
        {
            get
            {
                return this._StandEmployee;
            }
            set
            {
                this._StandEmployee = value;
            }
        }

      
        public string Ver
        {
            get
            {
                return this._ver;
            }
            set
            {
                this._ver = value;
            }
        }

      
        public string VerModiContent
        {
            get
            {
                return this._verModiContent;
            }
            set
            {
                this._verModiContent = value;
            }
        }

      
        public string VerModiReason
        {
            get
            {
                return this._verModiReason;
            }
            set
            {
                this._verModiReason = value;
            }
        }

      
        public string LastUpdator
        {
            get
            {
                return this._lastUpdator;
            }
            set
            {
                this._lastUpdator = value;
            }
        }

      
        public string LastUpdateDate
        {
            get
            {
                return this._lastUpdateDate;
            }
            set
            {
                this._lastUpdateDate = value;
            }
        }

      
        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }


        

      
    }
}
