using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Machine_MDL
{
    public class MouldDetail_MDL
    {
        private int _ID;
        
        private string _MouldCode;
        
        private string _MouldDesc;
        
        private string _ClipCode;
        
        private string _ClipDesc;

        private string _ClipUsedNum;

        private string _GoodsNo;
        
        private string _MouldSpecialFittingsNo;
        
        private string _MouldManufacturer;
        
        private string  _MouldMadeDate;
        
        private string _MouldCopyRight;

        private string _SocketNum;

        private string _GoodSocketNum;
        
        private string _FitMachineG;

        private string _PositioningHoleDiameter;
        
        private string _RefBadRate;
        
        private string _LostMaterialRate;

        private string _InjectionCycle;

        private string _MinInjectionCycle;

        private string _MaxInjectionCycle;

        private string _MachineCycle;

        private string _MouldInjectPress;

        private string _Mould_ShotTemp;

        private string _MouldLenght;

        private string _MouldWidth;

        private string _MouldThickth;

        private string _MouldWeight;

        private string _MouldPushDistance;

        private string _TemplateDistance;
        
        private string _TackOutFunction;
        
        private string _Robort;
        
        private string _RobortProgram;
        
        private string _ShotLenghten;
        
        private string _ProtectCycle;
        
        private string _MouldStatus;
        
        private string _WarehouseLocation;
        
        private string _ModiRecord;
        
        private string _LastModifier;
        
        private string _LastModiDate;
        
        private string _Ver;
        
        private string _Lu_lawTable;
        
        private string _Remark;

        /// <summary>
        /// add by fsq 2010-03-30
        /// 新增泡水、夹具工序每小时额外工资
        /// </summary>
        private string _Mould_Soaked;
        private string _Mould_Fixture;

        public MouldDetail_MDL() { }
        public MouldDetail_MDL(string vMould_Code) { this._MouldCode = vMould_Code; }
        public MouldDetail_MDL(string vMould_Code, string vGoodSocketNum)
        {
            this._MouldCode = vMould_Code;

            this._GoodSocketNum = vGoodSocketNum;
        }
        public MouldDetail_MDL(
            int vID,
            string vMould_Code,
            string vMould_Desc,
            string vClip_Code,
            string vClip_Desc,

            string vClip_UsedNum,
            string vGoodsNo,
            string vMould_SpecialFittingsNo,
            string vMould_Manufacturer,
            string vMould_MadeDate,
            string vMould_CopyRight,

            string vSocketNum,
            string vGoodSocketNum,
            string vFitMachineG,
            string vPositioningHoleDiameter,
            string vRefBadRate,

            string vLostMaterialRate,
            string vInjectionCycle,
            string vMinInjectionCycle,
            string vMaxInjectionCycle,
            string vMachineCycle,
            string vMould_InjectPress,
            string vMould_ShotTemp,

            string vMould_Lenght,
            string vMould_Width,
            string vMould_Thickth,
            string vMould_Weight,
            string vMould_PushDistance,

            string vTemplateDistance,
            string vTackOutFunction,
            string vRobort,
            string vRobortProgram,
            string vShotLenghten,

            string vProtectCycle,
            string vMouldStatus,
            string vWarehouseLocation,
            string vModiRecord,
            string vLastModifier,

            string vLastModiDate,
            string vVer,
            string vLu_law_Table,
            string vRemark,
            string vMould_Soaked,
            string vMould_Fixture
            )
        {
            this._ID = vID;
            this._MouldCode = vMould_Code;
            this._MouldDesc = vMould_Desc;
            this._ClipCode = vClip_Code;
            this._ClipDesc = vClip_Desc;
            this._ClipUsedNum = vClip_UsedNum;
            this._GoodsNo = vGoodsNo;
            this._MouldSpecialFittingsNo = vMould_SpecialFittingsNo;
            this._MouldManufacturer = vMould_Manufacturer;
            this._MouldMadeDate = vMould_MadeDate;
            this._MouldCopyRight = vMould_CopyRight;
            this._SocketNum = vSocketNum;
            this._GoodSocketNum = vGoodSocketNum;
            this._FitMachineG = vFitMachineG;
            this._PositioningHoleDiameter = vPositioningHoleDiameter;
            this._RefBadRate = vRefBadRate;
            this._LostMaterialRate = vLostMaterialRate;
            this._InjectionCycle = vInjectionCycle;
            this._MinInjectionCycle = vMinInjectionCycle;
            this._MaxInjectionCycle = vMaxInjectionCycle;
            this._MachineCycle = vMachineCycle;
            this._MouldInjectPress = vMould_InjectPress;
            this._Mould_ShotTemp = vMould_ShotTemp;
            this._MouldLenght = vMould_Lenght;
            this._MouldWidth = vMould_Width;
            this._MouldThickth = vMould_Thickth;
            this._MouldWeight = vMould_Weight;
            this._MouldPushDistance = vMould_PushDistance;
            this._TemplateDistance = vTemplateDistance;
            this._TackOutFunction = vTackOutFunction;
            this._Robort = vRobort;
            this._RobortProgram = vRobortProgram;
            this._ShotLenghten = vShotLenghten;
            this._ProtectCycle = vProtectCycle;
            this._MouldStatus = vMouldStatus;
            this._WarehouseLocation = vWarehouseLocation;
            this._ModiRecord = vModiRecord;
            this._LastModifier = vLastModifier;
            this._LastModiDate = vLastModiDate;
            this._Ver = vVer;
            this._Lu_lawTable = vLu_law_Table;
            this._Remark = vRemark;
            this._Mould_Fixture = vMould_Fixture;
            this._Mould_Soaked = vMould_Soaked;
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }
        
        public string MouldCode
        {
            get
            {
                return this._MouldCode;
            }
            set
            {
                this._MouldCode = value;
            }
        }
        
        public string MouldDesc
        {
            get
            {
                return this._MouldDesc;
            }
            set
            {
                this._MouldDesc = value;
            }
        }
        public string Mould_Soaked
        {
            get { return this._Mould_Soaked; }
            set { this._Mould_Soaked = value; }
        }
        public string Mould_Fixture
        {
            get { return this._Mould_Fixture; }
            set { this._Mould_Fixture = value; }
        }
        
        public string ClipCode
        {
            get
            {
                return this._ClipCode;
            }
            set
            {
                this._ClipCode = value;
            }
        }
        
        public string ClipDesc
        {
            get
            {
                return this._ClipDesc;
            }
            set
            {
                this._ClipDesc = value;
            }
        }

        public string ClipUsedNum
        {
            get
            {
                return this._ClipUsedNum;
            }
            set
            {
                this._ClipUsedNum = value;
            }
        }

        public string GoodsNo
        {
            get { return _GoodsNo; }
            set { _GoodsNo = value; }
        }
        public string MouldSpecialFittingsNo
        {
            get
            {
                return this._MouldSpecialFittingsNo;
            }
            set
            {
                this._MouldSpecialFittingsNo = value;
            }
        }
        
        public string MouldManufacturer
        {
            get
            {
                return this._MouldManufacturer;
            }
            set
            {
                this._MouldManufacturer = value;
            }
        }
        
        public string MouldMadeDate
        {
            get
            {
                return this._MouldMadeDate;
            }
            set
            {
                this._MouldMadeDate = value;
            }
        }
        
        public string MouldCopyRight
        {
            get
            {
                return this._MouldCopyRight;
            }
            set
            {
                this._MouldCopyRight = value;
            }
        }
        
        public string SocketNum
        {
            get
            {
                return this._SocketNum;
            }
            set
            {
                this._SocketNum = value;
            }
        }
        
        public string GoodSocketNum
        {
            get
            {
                return this._GoodSocketNum;
            }
            set
            {
                this._GoodSocketNum = value;
            }
        }
        
        public string FitMachineG
        {
            get
            {
                return this._FitMachineG;
            }
            set
            {
                this._FitMachineG = value;
            }
        }
        
        public string PositioningHoleDiameter
        {
            get
            {
                return this._PositioningHoleDiameter;
            }
            set
            {
                this._PositioningHoleDiameter = value;
            }
        }
        
        public string RefBadRate
        {
            get
            {
                return this._RefBadRate;
            }
            set
            {
                this._RefBadRate = value;
            }
        }
        
        public string LostMaterialRate
        {
            get
            {
                return this._LostMaterialRate;
            }
            set
            {
                this._LostMaterialRate = value;
            }
        }
        
        public string InjectionCycle
        {
            get
            {
                return this._InjectionCycle;
            }
            set
            {
                this._InjectionCycle = value;
            }
        }
        
        public string MinInjectionCycle
        {
            get
            {
                return this._MinInjectionCycle;
            }
            set
            {
                this._MinInjectionCycle = value;
            }
        }
        
        public string MaxInjectionCycle
        {
            get
            {
                return this._MaxInjectionCycle;
            }
            set
            {
                this._MaxInjectionCycle = value;
            }
        }
        public string MachineCycle
        {
            get { return _MachineCycle; }
            set { _MachineCycle = value; }
        }

        
        public string MouldInjectPress
        {
            get
            {
                return this._MouldInjectPress;
            }
            set
            {
                this._MouldInjectPress = value;
            }
        }

        public string Mould_ShotTemp
        {
            get { return _Mould_ShotTemp; }
            set { _Mould_ShotTemp = value; }
        }
        
        public string MouldLenght
        {
            get
            {
                return this._MouldLenght;
            }
            set
            {
                this._MouldLenght = value;
            }
        }
        
        public string MouldWidth
        {
            get
            {
                return this._MouldWidth;
            }
            set
            {
                this._MouldWidth = value;
            }
        }
        
        public string MouldThickth
        {
            get
            {
                return this._MouldThickth;
            }
            set
            {
                this._MouldThickth = value;
            }
        }
        
        public string MouldWeight
        {
            get
            {
                return this._MouldWeight;
            }
            set
            {
                this._MouldWeight = value;
            }
        }
        
        public string MouldPushDistance
        {
            get
            {
                return this._MouldPushDistance;
            }
            set
            {
                this._MouldPushDistance = value;
            }
        }
        
        public string TemplateDistance
        {
            get
            {
                return this._TemplateDistance;
            }
            set
            {
                this._TemplateDistance = value;
            }
        }
        
        public string TackOutFunction
        {
            get
            {
                return this._TackOutFunction;
            }
            set
            {
                this._TackOutFunction = value;
            }
        }
        
        public string Robort
        {
            get
            {
                return this._Robort;
            }
            set
            {
                this._Robort = value;
            }
        }
        
        public string RobortProgram
        {
            get
            {
                return this._RobortProgram;
            }
            set
            {
                this._RobortProgram = value;
            }
        }
        
        public string ShotLenghten
        {
            get
            {
                return this._ShotLenghten;
            }
            set
            {
                this._ShotLenghten = value;
            }
        }
        
        public string ProtectCycle
        {
            get
            {
                return this._ProtectCycle;
            }
            set
            {
                this._ProtectCycle = value;
            }
        }
        
        public string MouldStatus
        {
            get
            {
                return this._MouldStatus;
            }
            set
            {
                this._MouldStatus = value;
            }
        }
        
        public string WarehouseLocation
        {
            get
            {
                return this._WarehouseLocation;
            }
            set
            {
                this._WarehouseLocation = value;
            }
        }
        
        public string ModiRecord
        {
            get
            {
                return this._ModiRecord;
            }
            set
            {
                this._ModiRecord = value;
            }
        }
        
        public string LastModifier
        {
            get
            {
                return this._LastModifier;
            }
            set
            {
                this._LastModifier = value;
            }
        }
        
        public string LastModiDate
        {
            get
            {
                return this._LastModiDate;
            }
            set
            {
                this._LastModiDate = value;
            }
        }
        
        public string Ver
        {
            get
            {
                return this._Ver;
            }
            set
            {
                this._Ver = value;
            }
        }
        
        public string Lu_lawTable
        {
            get
            {
                return this._Lu_lawTable;
            }
            set
            {
                this._Lu_lawTable = value;
            }
        }
        
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }
        

       

       
        
    }
}
