using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Quality_MDL
{
    public class StandTechnicsParams_MDL : LikeQuery
    {
        private int _ID = 0;
        private ArrayList _IDs;
        private string _FileNo;
        private string _MachineNo;
        private string _MouldNo;
        private string _ProductNo;

        private string _RegrindRate;
        private string _Season;
        private string _Version;
        private string _Engineer;
        private string _AdjustDate; 
        
        private string _SetShotMouthTemp; 
        private string _ShotMouthTemp1; 
        private string _ShotMouthTemp2; 
        private string _ShotMouthTemp3; 
        private string _MaterialPipeTemp; 
        
        private string _GlueMeltTime; 
        private string _ScrewTurnSpeed; 
        private string _FillingTime; 
        private string _PeriodTime; 
        private string _ShotGlueDelay; ////
        
        private string _ShotGluePoint;
        private string _ThimbleNum; 
        private string _MouldCloseNum; 
        private string _CoolingTime; 
        private string _FillingLimit; 
        
        private string _GlueMeltTimeLimit; 
        private string _GlueMeltDelay; 
        private string _BeforeMeltSpeed;
        private string _BeforeMeltPress;
        private string _BeforeMeltTime;

        private string _MeltSpeed1; 
        
        private string _MeltPress1; 
        private string _MeltPosition1; 
        private string _MeltSpeed2; 
        private string _MeltPress2; 
        private string _MeltPosition2;

        private string _AfterMeltSpeed; 
        private string _AfterMeltPress; 
        private string _AfterMeltPosition; 
        private string _MeltBackPress; 
        private string _ShotBaseFastSpeed1; 
        
        private string _ShotPosition1; 
        private string _ShotPress1; 
        private string _ShotBaseFastSpeed2; 
        private string _ShotPress2; 
        private string _ShotPosition2;
        
        private string _ShotBaseFastSpeed3; 
        private string _ShotPress3; 
        private string _ShotPosition3; 
        private string _ShotBaseFastSpeed4; 
        private string _ShotPress4; 
        
        private string _ShotPosition4; 
        private string _KeepPressSpeed1;
        private string _KeepPress1;
        private string _KeepPressPosition1; 
        private string _KeepPress2; 
        
        private string _KeepPressPosition2; 
        private string _KeepPress3; 
        private string _KeepPressPosition3; 
        private string _ShotBaseFastSpeed; 
        private string _ShotBaseFastPress; ////
        
        private string _ShotBaseFastTime; 
        private string _ShotBaseSlowSpeed; 
        private string _ShotBaseSlowPress; 
        private string _ShotBackSpeed; 
        private string _ShotBackPress; 
        
        private string _ShotBackTemp; 
        private string _AdjustMouldPress; 
        private string _FastLockMouldSpeed; 
        private string _FastLockMouldPress; 
        private string _FastLockMouldPosition; 
        
        private string _LowPressLockMouldSpeed; 
        private string _LowPressLockMouldPress; 
        private string _LowPressLockMouldPosition; 
        private string _HighPressLockMouldSpeed; 
        private string _HighPressLockMouldPress; 
        
        private string _HighPressLockMouldPosition; 
        private string _LowSpeedOpenMouldSpeed; 
        private string _LowSpeedOpenMouldPress; 
        private string _LowSpeedOpenMouldPosition; 
        private string _HighSpeedOpenMouldSpeed; 
        
        private string _HighSpeedOpenMouldPress; 
        private string _HighSpeedOpenMouldPosition;
        private string _ReduceSpeedOpenMouldSpeed; 
        private string _ReduceSpeedOpenMouldPress; 
        private string _ReduceSpeedOpenMouldPosition; 
        
        private string _ThimbleBeginMouldPosition; 
        private string _ThimbleActKind; 
        private string _ThimbleGoSpeed; 
        private string _ThimbleGoPress; 
        private string _ThimbleGoPosition; 
        
        private string _ThimbleBackSpeed; 
        private string _ThimbleBackPress; 
        private string _ThimbleBackPosition; 
        private string _ThimbleNum1; 
        private string _ThimbleShakeTime; 
        
        private string _ThimbleStayTime;

        private string _PushSpeed;
        private string _PushPress;
        private string _BeforeGetWaterSpeed;
        private string _BeforeGetWaterTemp;
        private string _BeforeGetWaterMouldTemp;

        private string _AfterGetWaterSpeed;
        private string _AfterGetWaterTemp;
        private string _AfterGetWaterMouldTemp;
        private string _GrossWeight;
        private string _MaterialNo;

        private byte[] _Photo;
        private object _PhotoType;
        private string _Remark;
        private string _QualiteRemark;

        public StandTechnicsParams_MDL() { }
        public StandTechnicsParams_MDL(int _ID,
             string _FileNo, string _MachineNo, string _MouldNo, string _ProductNo,
             string _RegrindRate, string _Season, string _Version,  string _Engineer, string _AdjustDate,
             string _SetShotMouthTemp, string _ShotMouthTemp1, string _ShotMouthTemp2, string _ShotMouthTemp3, string _MaterialPipeTemp,
             string _GlueMeltTime,string _ScrewTurnSpeed, string _FillingTime, string _PeriodTime,  string _ShotGlueDelay,
             string _ShotGluePoint, string _ThimbleNum, string _MouldCloseNum, string _CoolingTime, string _FillingLimit,
             string _GlueMeltTimeLimit, string _GlueMeltDelay,string _BeforeMeltSpeed,string _BeforeMeltPress, string _BeforeMeltTime,
            
             string _MeltSpeed1,

             string _MeltPress1, string _MeltPosition1, string _MeltSpeed2, string _MeltPress2, string _MeltPosition2, 
             string _AfterMeltSpeed, string _AfterMeltPress, string _AfterMeltPosition, string _MeltBackPress, string _ShotBaseFastSpeed1,        
             string _ShotPosition1, string _ShotPress1, string _ShotBaseFastSpeed2, string _ShotPress2, string _ShotPosition2,
             string _ShotBaseFastSpeed3, string _ShotPress3, string _ShotPosition3, string _ShotBaseFastSpeed4,string _ShotPress4,  
             string _ShotPosition4, string _KeepPressSpeed1,string _KeepPress1,string _KeepPressPosition1, string _KeepPress2, 
             string _KeepPressPosition2, string _KeepPress3, string _KeepPressPosition3,string _ShotBaseFastSpeed, string _ShotBaseFastPress, 
             string _ShotBaseFastTime, string _ShotBaseSlowSpeed, string _ShotBaseSlowPress, string _ShotBackSpeed, string _ShotBackPress, 
             string _ShotBackTemp, string _AdjustMouldPress, string _FastLockMouldSpeed,string _FastLockMouldPress, string _FastLockMouldPosition, 
             string _LowPressLockMouldSpeed, string _LowPressLockMouldPress, string _LowPressLockMouldPosition, string _HighPressLockMouldSpeed, string _HighPressLockMouldPress,
             string _HighPressLockMouldPosition, string _LowSpeedOpenMouldSpeed, string _LowSpeedOpenMouldPress, string _LowSpeedOpenMouldPosition, string _HighSpeedOpenMouldSpeed,
             string _HighSpeedOpenMouldPress, string _HighSpeedOpenMouldPosition, string _ReduceSpeedOpenMouldSpeed, string _ReduceSpeedOpenMouldPress, string _ReduceSpeedOpenMouldPosition, 
             string _ThimbleBeginMouldPosition, string _ThimbleActKind, string _ThimbleGoSpeed, string _ThimbleGoPress, string _ThimbleGoPosition, 
             string _ThimbleBackSpeed, string _ThimbleBackPress, string _ThimbleBackPosition, string _ThimbleNum1, string _ThimbleShakeTime,     
             string _ThimbleStayTime,

             string _PushSpeed, string _PushPress, string _BeforeGetWaterSpeed, string _BeforeGetWaterTemp, string _BeforeGetWaterMouldTemp,
             string _AfterGetWaterSpeed, string _AfterGetWaterTemp, string _AfterGetWaterMouldTemp, string _GrossWeight, string _MaterialNo,
             byte[] _Photo, object _PhotoType, string _Remark, string _QualiteRemark

          )
        {
            this._ID = _ID;
            this._FileNo = _FileNo; 
            this._MachineNo = _MachineNo; 
            this._MouldNo = _MouldNo; 
            this._ProductNo = _ProductNo; 

            this._RegrindRate = _RegrindRate; 
            this._Season = _Season; 
            this._Version = _Version; 
            this._Engineer = _Engineer; 
            this._AdjustDate = _AdjustDate; 

            this._SetShotMouthTemp = _SetShotMouthTemp; 
            this._ShotMouthTemp1 = _ShotMouthTemp1; 
            this._ShotMouthTemp2 = _ShotMouthTemp2; 
            this._ShotMouthTemp3 = _ShotMouthTemp3; 
            this._MaterialPipeTemp = _MaterialPipeTemp; 

            this._GlueMeltTime = _GlueMeltTime; 
            this._ScrewTurnSpeed = _ScrewTurnSpeed; 
            this._FillingTime = _FillingTime; 
            this._PeriodTime = _PeriodTime; 
            this._ShotGlueDelay = _ShotGlueDelay; ////

            this._ShotGluePoint = _ShotGluePoint;
            this._ThimbleNum = _ThimbleNum; 
            this._MouldCloseNum = _MouldCloseNum; 
            this._CoolingTime = _CoolingTime; 
            this._FillingLimit = _FillingLimit; 

            this._GlueMeltTimeLimit = _GlueMeltTimeLimit; 
            this._GlueMeltDelay = _GlueMeltDelay; 
            this._BeforeMeltSpeed = _BeforeMeltSpeed;
            this._BeforeMeltPress = _BeforeMeltPress;
            this._BeforeMeltTime = _BeforeMeltTime;

            this._MeltSpeed1 = _MeltSpeed1; 

            this._MeltPress1 = _MeltPress1; 
            this._MeltPosition1 = _MeltPosition1; 
            this._MeltSpeed2 = _MeltSpeed2; 
            this._MeltPress2 = _MeltPress2; 
            this._MeltPosition2 = _MeltPosition2; 

            this._AfterMeltSpeed = _AfterMeltSpeed; 
            this._AfterMeltPress = _AfterMeltPress; 
            this._AfterMeltPosition = _AfterMeltPosition; 
            this._MeltBackPress = _MeltBackPress; 
            this._ShotBaseFastSpeed1 = _ShotBaseFastSpeed1; 

            this._ShotPosition1 = _ShotPosition1; 
            this._ShotPress1 = _ShotPress1; 
            this._ShotBaseFastSpeed2 = _ShotBaseFastSpeed2; 
            this._ShotPress2 = _ShotPress2; 
            this._ShotPosition2 = _ShotPosition2;

            this._ShotBaseFastSpeed3 = _ShotBaseFastSpeed3; 
            this._ShotPress3 = _ShotPress3; 
            this._ShotPosition3 = _ShotPosition3; 
            this._ShotBaseFastSpeed4 = _ShotBaseFastSpeed4; 
            this._ShotPress4 = _ShotPress4; 

            this._ShotPosition4 = _ShotPosition4; 
            this._KeepPressSpeed1 = _KeepPressSpeed1;
            this._KeepPress1 = _KeepPress1;
            this._KeepPressPosition1 = _KeepPressPosition1; 
            this._KeepPress2 = _KeepPress2; 

            this._KeepPressPosition2 = _KeepPressPosition2; 
            this._KeepPress3 = _KeepPress3; 
            this._KeepPressPosition3 = _KeepPressPosition3; 
            this._ShotBaseFastSpeed = _ShotBaseFastSpeed; 
            this._ShotBaseFastPress = _ShotBaseFastPress; 

            this._ShotBaseFastTime = _ShotBaseFastTime; 
            this._ShotBaseSlowSpeed = _ShotBaseSlowSpeed; 
            this._ShotBaseSlowPress = _ShotBaseSlowPress; 
            this._ShotBackSpeed = _ShotBackSpeed; 
            this._ShotBackPress = _ShotBackPress; 

            this._ShotBackTemp = _ShotBackTemp; 
            this._AdjustMouldPress = _AdjustMouldPress; 
            this._FastLockMouldSpeed = _FastLockMouldSpeed; 
            this._FastLockMouldPress = _FastLockMouldPress; 
            this._FastLockMouldPosition = _FastLockMouldPosition; 

            this._LowPressLockMouldSpeed = _LowPressLockMouldSpeed; 
            this._LowPressLockMouldPress = _LowPressLockMouldPress; 
            this._LowPressLockMouldPosition = _LowPressLockMouldPosition; 
            this._HighPressLockMouldSpeed = _HighPressLockMouldSpeed; 
            this._HighPressLockMouldPress = _HighPressLockMouldPress; 

            this._HighPressLockMouldPosition = _HighPressLockMouldPosition; 
            this._LowSpeedOpenMouldSpeed = _LowSpeedOpenMouldSpeed; 
            this._LowSpeedOpenMouldPress = _LowSpeedOpenMouldPress; 
            this._LowSpeedOpenMouldPosition = _LowSpeedOpenMouldPosition; 
            this._HighSpeedOpenMouldSpeed = _HighSpeedOpenMouldSpeed; 

            this._HighSpeedOpenMouldPress = _HighSpeedOpenMouldPress; 
            this._HighSpeedOpenMouldPosition = _HighSpeedOpenMouldPosition;
            this._ReduceSpeedOpenMouldSpeed = _ReduceSpeedOpenMouldSpeed; 
            this._ReduceSpeedOpenMouldPress = _ReduceSpeedOpenMouldPress; 
            this._ReduceSpeedOpenMouldPosition = _ReduceSpeedOpenMouldPosition; 

            this._ThimbleBeginMouldPosition = _ThimbleBeginMouldPosition; 
            this._ThimbleActKind = _ThimbleActKind; 
            this._ThimbleGoSpeed = _ThimbleGoSpeed; 
            this._ThimbleGoPress = _ThimbleGoPress; 
            this._ThimbleGoPosition = _ThimbleGoPosition; 

            this._ThimbleBackSpeed = _ThimbleBackSpeed; 
            this._ThimbleBackPress = _ThimbleBackPress; 
            this._ThimbleBackPosition = _ThimbleBackPosition; 
            this._ThimbleNum1 = _ThimbleNum1; 
            this._ThimbleShakeTime = _ThimbleShakeTime;

            this._ThimbleStayTime = _ThimbleStayTime;

            this._PushSpeed = _PushSpeed;
            this._PushPress =_PushPress;
            this._BeforeGetWaterSpeed =_BeforeGetWaterSpeed;
            this._BeforeGetWaterTemp = _BeforeGetWaterTemp; 
            this._BeforeGetWaterMouldTemp =_BeforeGetWaterMouldTemp;
            this._AfterGetWaterSpeed =_AfterGetWaterSpeed;
            this._AfterGetWaterTemp =_AfterGetWaterTemp; 
            this._AfterGetWaterMouldTemp =_AfterGetWaterMouldTemp; 
            this._GrossWeight =_GrossWeight;
            this._MaterialNo =_MaterialNo;
            this._Photo =_Photo;
            this._PhotoType =_PhotoType;
            this._Remark =_Remark;
            this._QualiteRemark = _QualiteRemark;
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

        public string FileNo
        {
            get { return _FileNo; }
            set { _FileNo = value; }
        }

        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; }
        }

        public string MouldNo
        {
            get { return _MouldNo; }
            set { _MouldNo = value; }
        }

        public string ProductNo
        {
            get { return _ProductNo; }
            set { _ProductNo = value; }
        }

        public string RegrindRate
        {
            get { return string.IsNullOrEmpty(_RegrindRate) ? "0" : _RegrindRate; }
            set { _RegrindRate = value; }
        }

        public string Season
        {
            get { return _Season; }
            set { _Season = value; }
        }

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        public string Engineer
        {
            get { return _Engineer; }
            set { _Engineer = value; }
        }//10

        public string AdjustDate
        {
            get { return _AdjustDate; }
            set { _AdjustDate = value; }
        }

        public string SetShotMouthTemp
        {
            get { return string.IsNullOrEmpty(_SetShotMouthTemp) ? "0" : _SetShotMouthTemp; }
            set { _SetShotMouthTemp = value; }
        }

        public string ShotMouthTemp1
        {
            get { return string.IsNullOrEmpty(_ShotMouthTemp1) ? "0" : _ShotMouthTemp1; }
            set { _ShotMouthTemp1 = value; }
        }

        public string ShotMouthTemp2
        {
            get { return string.IsNullOrEmpty(_ShotMouthTemp2) ? "0" : _ShotMouthTemp2; }
            set { _ShotMouthTemp2 = value; }
        }

        public string ShotMouthTemp3
        {
            get { return string.IsNullOrEmpty(_ShotMouthTemp3) ? "0" : _ShotMouthTemp3; }
            set { _ShotMouthTemp3 = value; }
        }

        public string MaterialPipeTemp
        {
            get { return string.IsNullOrEmpty(_MaterialPipeTemp) ? "0" : _MaterialPipeTemp; }
            set { _MaterialPipeTemp = value; }
        }

        public string GlueMeltTime
        {
            get { return string.IsNullOrEmpty(_GlueMeltTime) ? "0" : _GlueMeltTime; }
            set { _GlueMeltTime = value; }
        }

        public string ScrewTurnSpeed
        {
            get { return string.IsNullOrEmpty(_ScrewTurnSpeed) ? "0" : _ScrewTurnSpeed; }
            set { _ScrewTurnSpeed = value; }
        }

        public string FillingTime
        {
            get { return string.IsNullOrEmpty(_FillingTime) ? "0" : _FillingTime; }
            set { _FillingTime = value; }
        }

        public string PeriodTime
        {
            get { return string.IsNullOrEmpty(_PeriodTime) ? "0" : _PeriodTime; }
            set { _PeriodTime = value; }
        }//20

        public string ShotGlueDelay
        {
            get { return string.IsNullOrEmpty(_ShotGlueDelay) ? "0" : _ShotGlueDelay; }
            set { _ShotGlueDelay = value; }
        }

        public string ShotGluePoint
        {
            get { return string.IsNullOrEmpty(_ShotGluePoint) ? "0" : _ShotGluePoint; }
            set { _ShotGluePoint = value; }
        }

        public string ThimbleNum
        {
            get { return string.IsNullOrEmpty(_ThimbleNum) ? "0" : _ThimbleNum; }
            set { _ThimbleNum = value; }
        }

        public string MouldCloseNum
        {
            get { return string.IsNullOrEmpty(_MouldCloseNum) ? "0" : _MouldCloseNum; }
            set { _MouldCloseNum = value; }
        }

        public string CoolingTime
        {
            get { return string.IsNullOrEmpty(_CoolingTime) ? "0" : _CoolingTime; }
            set { _CoolingTime = value; }
        }

        public string FillingLimit
        {
            get { return string.IsNullOrEmpty(_FillingLimit) ? "0" : _FillingLimit; }
            set { _FillingLimit = value; }
        }

        public string GlueMeltTimeLimit
        {
            get { return string.IsNullOrEmpty(_GlueMeltTimeLimit) ? "0" : _GlueMeltTimeLimit; }
            set { _GlueMeltTimeLimit = value; }
        }

        public string GlueMeltDelay
        {
            get { return string.IsNullOrEmpty(_GlueMeltDelay) ? "0" : _GlueMeltDelay; }
            set { _GlueMeltDelay = value; }
        }

        public string BeforeMeltSpeed
        {
            get { return string.IsNullOrEmpty(_BeforeMeltSpeed) ? "0" : _BeforeMeltSpeed; }
            set { _BeforeMeltSpeed = value; }
        }

        public string BeforeMeltPress
        {
            get { return string.IsNullOrEmpty(_BeforeMeltPress) ? "0" : _BeforeMeltPress; }
            set { _BeforeMeltPress = value; }
        }//30
        public string BeforeMeltTime
        {
            get { return string.IsNullOrEmpty(_BeforeMeltTime) ? "0" : _BeforeMeltTime; }
            set { _BeforeMeltTime = value; }
        }//31

        public string MeltSpeed1
        {
            get { return string.IsNullOrEmpty(_MeltSpeed1) ? "0" : _MeltSpeed1; }
            set { _MeltSpeed1 = value; }
        }

        public string MeltPress1
        {
            get { return string.IsNullOrEmpty(_MeltPress1) ? "0" : _MeltPress1; }
            set { _MeltPress1 = value; }
        }

        public string MeltPosition1
        {
            get { return string.IsNullOrEmpty(_MeltPosition1) ? "0" : _MeltPosition1; }
            set { _MeltPosition1 = value; }
        }

        public string MeltSpeed2
        {
            get { return string.IsNullOrEmpty(_MeltSpeed2) ? "0" : _MeltSpeed2; }
            set { _MeltSpeed2 = value; }
        }

        public string MeltPress2
        {
            get { return string.IsNullOrEmpty(_MeltPress2) ? "0" : _MeltPress2; }
            set { _MeltPress2 = value; }
        }

        public string MeltPosition2
        {
            get { return string.IsNullOrEmpty(_MeltPosition2) ? "0" : _MeltPosition2; }
            set { _MeltPosition2 = value; }
        }

        public string AfterMeltSpeed
        {
            get { return string.IsNullOrEmpty(_AfterMeltSpeed) ? "0" : _AfterMeltSpeed; }
            set { _AfterMeltSpeed = value; }
        }

        public string AfterMeltPress
        {
            get { return string.IsNullOrEmpty(_AfterMeltPress) ? "0" : _AfterMeltPress; }
            set { _AfterMeltPress = value; }
        }

        public string AfterMeltPosition
        {
            get { return string.IsNullOrEmpty(_AfterMeltPosition) ? "0" : _AfterMeltPosition; }
            set { _AfterMeltPosition = value; }
        }

        public string MeltBackPress
        {
            get { return string.IsNullOrEmpty(_MeltBackPress) ? "0" : _MeltBackPress; }
            set { _MeltBackPress = value; }
        }//40

        public string ShotBaseFastSpeed1
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastSpeed1) ? "0" : _ShotBaseFastSpeed1; }
            set { _ShotBaseFastSpeed1 = value; }
        }
        
        public string ShotPosition1
        {
            get { return string.IsNullOrEmpty(_ShotPosition1) ? "0" : _ShotPosition1; }
            set { _ShotPosition1 = value; }
        }        

        public string ShotPress1
        {
            get { return string.IsNullOrEmpty(_ShotPress1) ? "0" : _ShotPress1; }
            set { _ShotPress1 = value; }
        }

        public string ShotBaseFastSpeed2
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastSpeed2) ? "0" : _ShotBaseFastSpeed2; }
            set { _ShotBaseFastSpeed2 = value; }
        }

        public string ShotPress2
        {
            get { return string.IsNullOrEmpty(_ShotPress2) ? "0" : _ShotPress2; }
            set { _ShotPress2 = value; }
        }

        public string ShotPosition2
        {
            get { return string.IsNullOrEmpty(_ShotPosition2) ? "0" : _ShotPosition2; }
            set { _ShotPosition2 = value; }
        }

        public string ShotBaseFastSpeed3
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastSpeed3) ? "0" : _ShotBaseFastSpeed3; }
            set { _ShotBaseFastSpeed3 = value; }
        }

        public string ShotPress3
        {
            get { return string.IsNullOrEmpty(_ShotPress3) ? "0" : _ShotPress3; }
            set { _ShotPress3 = value; }
        }

        public string ShotPosition3
        {
            get { return string.IsNullOrEmpty(_ShotPosition3) ? "0" : _ShotPosition3; }
            set { _ShotPosition3 = value; }
        }

        public string ShotBaseFastSpeed4
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastSpeed4) ? "0" : _ShotBaseFastSpeed4; }
            set { _ShotBaseFastSpeed4 = value; }
        }//50

        public string ShotPress4
        {
            get { return string.IsNullOrEmpty(_ShotPress4) ? "0" : _ShotPress4; }
            set { _ShotPress4 = value; }
        }

        public string ShotPosition4
        {
            get { return string.IsNullOrEmpty(_ShotPosition4) ? "0" : _ShotPosition4; }
            set { _ShotPosition4 = value; }
        }

        public string KeepPressSpeed1
        {
            get { return string.IsNullOrEmpty(_KeepPressSpeed1) ? "0" : _KeepPressSpeed1; }
            set { _KeepPressSpeed1 = value; }
        }

        public string KeepPress1
        {
            get { return string.IsNullOrEmpty(_KeepPress1) ? "0" : _KeepPress1; }
            set { _KeepPress1 = value; }
        }

        public string KeepPressPosition1
        {
            get { return string.IsNullOrEmpty(_KeepPressPosition1) ? "0" : _KeepPressPosition1; }
            set { _KeepPressPosition1 = value; }
        }

        public string KeepPress2
        {
            get { return string.IsNullOrEmpty(_KeepPress2) ? "0" : _KeepPress2; }
            set { _KeepPress2 = value; }
        }

        public string KeepPressPosition2
        {
            get { return string.IsNullOrEmpty(_KeepPressPosition2) ? "0" : _KeepPressPosition2; }
            set { _KeepPressPosition2 = value; }
        }

        public string KeepPress3
        {
            get { return string.IsNullOrEmpty(_KeepPress3) ? "0" : _KeepPress3; }
            set { _KeepPress3 = value; }
        }

        public string KeepPressPosition3
        {
            get { return string.IsNullOrEmpty(_KeepPressPosition3) ? "0" : _KeepPressPosition3; }
            set { _KeepPressPosition3 = value; }
        }

        public string ShotBaseFastSpeed
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastSpeed) ? "0" : _ShotBaseFastSpeed; }
            set { _ShotBaseFastSpeed = value; }
        }//60

        public string ShotBaseFastPress
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastPress) ? "0" : _ShotBaseFastPress; }
            set { _ShotBaseFastPress = value; }
        }

        public string ShotBaseFastTime
        {
            get { return string.IsNullOrEmpty(_ShotBaseFastTime) ? "0" : _ShotBaseFastTime; }
            set { _ShotBaseFastTime = value; }
        }        

        public string ShotBaseSlowSpeed
        {
            get { return string.IsNullOrEmpty(_ShotBaseSlowSpeed) ? "0" : _ShotBaseSlowSpeed; }
            set { _ShotBaseSlowSpeed = value; }
        }

        public string ShotBaseSlowPress
        {
            get { return string.IsNullOrEmpty(_ShotBaseSlowPress) ? "0" : _ShotBaseSlowPress; }
            set { _ShotBaseSlowPress = value; }
        }

        public string ShotBackSpeed
        {
            get { return string.IsNullOrEmpty(_ShotBackSpeed) ? "0" : _ShotBackSpeed; }
            set { _ShotBackSpeed = value; }
        }

        public string ShotBackPress
        {
            get { return string.IsNullOrEmpty(_ShotBackPress) ? "0" : _ShotBackPress; }
            set { _ShotBackPress = value; }
        }

        public string ShotBackTemp
        {
            get { return string.IsNullOrEmpty(_ShotBackTemp) ? "0" : _ShotBackTemp; }
            set { _ShotBackTemp = value; }
        }

        public string AdjustMouldPress
        {
            get { return string.IsNullOrEmpty(_AdjustMouldPress) ? "0" : _AdjustMouldPress; }
            set { _AdjustMouldPress = value; }
        }

        public string FastLockMouldSpeed
        {
            get { return string.IsNullOrEmpty(_FastLockMouldSpeed) ? "0" : _FastLockMouldSpeed; }
            set { _FastLockMouldSpeed = value; }
        }

        public string FastLockMouldPress
        {
            get { return string.IsNullOrEmpty(_FastLockMouldPress) ? "0" : _FastLockMouldPress; }
            set { _FastLockMouldPress = value; }
        }//70

        public string FastLockMouldPosition
        {
            get { return string.IsNullOrEmpty(_FastLockMouldPosition) ? "0" : _FastLockMouldPosition; }
            set { _FastLockMouldPosition = value; }
        }

        public string LowPressLockMouldSpeed
        {
            get { return string.IsNullOrEmpty(_LowPressLockMouldSpeed) ? "0" : _LowPressLockMouldSpeed; }
            set { _LowPressLockMouldSpeed = value; }
        }

        public string LowPressLockMouldPress
        {
            get { return string.IsNullOrEmpty(_LowPressLockMouldPress) ? "0" : _LowPressLockMouldPress; }
            set { _LowPressLockMouldPress = value; }
        }

        public string LowPressLockMouldPosition
        {
            get { return string.IsNullOrEmpty(_LowPressLockMouldPosition) ? "0" : _LowPressLockMouldPosition; }
            set { _LowPressLockMouldPosition = value; }
        }

        public string HighPressLockMouldSpeed
        {
            get { return string.IsNullOrEmpty(_HighPressLockMouldSpeed) ? "0" : _HighPressLockMouldSpeed; }
            set { _HighPressLockMouldSpeed = value; }
        }

        public string HighPressLockMouldPress
        {
            get { return string.IsNullOrEmpty(_HighPressLockMouldPress) ? "0" : _HighPressLockMouldPress; }
            set { _HighPressLockMouldPress = value; }
        }

        public string HighPressLockMouldPosition
        {
            get { return string.IsNullOrEmpty(_HighPressLockMouldPosition) ? "0" : _HighPressLockMouldPosition; }
            set { _HighPressLockMouldPosition = value; }
        }

        public string LowSpeedOpenMouldSpeed
        {
            get { return string.IsNullOrEmpty(_LowSpeedOpenMouldSpeed) ? "0" : _LowSpeedOpenMouldSpeed; }
            set { _LowSpeedOpenMouldSpeed = value; }
        }

        public string LowSpeedOpenMouldPress
        {
            get { return string.IsNullOrEmpty(_LowSpeedOpenMouldPress) ? "0" : _LowSpeedOpenMouldPress; }
            set { _LowSpeedOpenMouldPress = value; }
        }

        public string LowSpeedOpenMouldPosition
        {
            get { return string.IsNullOrEmpty(_LowSpeedOpenMouldPosition) ? "0" : _LowSpeedOpenMouldPosition; }
            set { _LowSpeedOpenMouldPosition = value; }
        }//80

        public string HighSpeedOpenMouldSpeed
        {
            get { return string.IsNullOrEmpty(_HighSpeedOpenMouldSpeed) ? "0" : _HighSpeedOpenMouldSpeed; }
            set { _HighSpeedOpenMouldSpeed = value; }
        }

        public string HighSpeedOpenMouldPress
        {
            get { return string.IsNullOrEmpty(_HighSpeedOpenMouldPress) ? "0" : _HighSpeedOpenMouldPress; }
            set { _HighSpeedOpenMouldPress = value; }
        }

        public string HighSpeedOpenMouldPosition
        {
            get { return string.IsNullOrEmpty(_HighSpeedOpenMouldPosition) ? "0" : _HighSpeedOpenMouldPosition; }
            set { _HighSpeedOpenMouldPosition = value; }
        }

        public string ReduceSpeedOpenMouldSpeed
        {
            get { return string.IsNullOrEmpty(_ReduceSpeedOpenMouldSpeed) ? "0" : _ReduceSpeedOpenMouldSpeed; }
            set { _ReduceSpeedOpenMouldSpeed = value; }
        }

        public string ReduceSpeedOpenMouldPress
        {
            get { return string.IsNullOrEmpty(_ReduceSpeedOpenMouldPress) ? "0" : _ReduceSpeedOpenMouldPress; }
            set { _ReduceSpeedOpenMouldPress = value; }
        }

        public string ReduceSpeedOpenMouldPosition
        {
            get { return string.IsNullOrEmpty(_ReduceSpeedOpenMouldPosition) ? "0" : _ReduceSpeedOpenMouldPosition; }
            set { _ReduceSpeedOpenMouldPosition = value; }
        }

        public string ThimbleBeginMouldPosition
        {
            get { return string.IsNullOrEmpty(_ThimbleBeginMouldPosition) ? "0" : _ThimbleBeginMouldPosition; }
            set { _ThimbleBeginMouldPosition = value; }
        }

        public string ThimbleActKind
        {
            get { return _ThimbleActKind; }
            set { _ThimbleActKind = value; }
        }

        public string ThimbleGoSpeed
        {
            get { return string.IsNullOrEmpty(_ThimbleGoSpeed) ? "0" : _ThimbleGoSpeed; }
            set { _ThimbleGoSpeed = value; }
        }

        public string ThimbleGoPress
        {
            get { return string.IsNullOrEmpty(_ThimbleGoPress) ? "0" : _ThimbleGoPress; }
            set { _ThimbleGoPress = value; }
        }//90

        public string ThimbleGoPosition
        {
            get { return string.IsNullOrEmpty(_ThimbleGoPosition) ? "0" : _ThimbleGoPosition; }
            set { _ThimbleGoPosition = value; }
        }

        public string ThimbleBackSpeed
        {
            get { return string.IsNullOrEmpty(_ThimbleBackSpeed) ? "0" : _ThimbleBackSpeed; }
            set { _ThimbleBackSpeed = value; }
        }

        public string ThimbleBackPress
        {
            get { return string.IsNullOrEmpty(_ThimbleBackPress) ? "0" : _ThimbleBackPress; }
            set { _ThimbleBackPress = value; }
        }

        public string ThimbleBackPosition
        {
            get { return string.IsNullOrEmpty(_ThimbleBackPosition) ? "0" : _ThimbleBackPosition; }
            set { _ThimbleBackPosition = value; }
        }

        public string ThimbleNum1
        {
            get { return string.IsNullOrEmpty(_ThimbleNum1) ? "0" : _ThimbleNum1; }
            set { _ThimbleNum1 = value; }
        }

        public string ThimbleShakeTime
        {
            get { return string.IsNullOrEmpty(_ThimbleShakeTime) ? "0" : _ThimbleShakeTime; }
            set { _ThimbleShakeTime = value; }
        }

        public string ThimbleStayTime
        {
            get { return string.IsNullOrEmpty(_ThimbleStayTime) ? "0" : _ThimbleStayTime; }
            set { _ThimbleStayTime = value; }
        }//7


        public string PushSpeed
        {
            get { return string.IsNullOrEmpty(_PushSpeed) ? "0" : _PushSpeed; }
            set { _PushSpeed = value; }
        }//7

        public string PushPress
        {
            get { return string.IsNullOrEmpty(_PushPress) ? "0" : _PushPress; }
            set { _PushPress = value; }
        }//7

        public string BeforeGetWaterSpeed
        {
            get { return string.IsNullOrEmpty(_BeforeGetWaterSpeed) ? "0" : _BeforeGetWaterSpeed; }
            set { _BeforeGetWaterSpeed = value; }
        }//7

        public string BeforeGetWaterTemp
        {
            get { return string.IsNullOrEmpty(_BeforeGetWaterTemp) ? "0" : _BeforeGetWaterTemp; }
            set { _BeforeGetWaterTemp = value; }
        }//7

        public string BeforeGetWaterMouldTemp
        {
            get { return string.IsNullOrEmpty(_BeforeGetWaterMouldTemp) ? "0" : _BeforeGetWaterMouldTemp; }
            set { _BeforeGetWaterMouldTemp = value; }
        }
        
        public string AfterGetWaterSpeed
        {
            get { return string.IsNullOrEmpty(_AfterGetWaterSpeed) ? "0" : _AfterGetWaterSpeed; }
            set { _AfterGetWaterSpeed = value; }
        }
         
        public string AfterGetWaterTemp
        {
            get { return string.IsNullOrEmpty(_AfterGetWaterTemp) ? "0" : _AfterGetWaterTemp; }
            set { _AfterGetWaterTemp = value; }
        }
        
        public string AfterGetWaterMouldTemp
        {
            get { return string.IsNullOrEmpty(_AfterGetWaterMouldTemp) ? "0" : _AfterGetWaterMouldTemp; }
            set { _AfterGetWaterMouldTemp = value; }
        }

        public string GrossWeight
        {
            get { return string.IsNullOrEmpty(_GrossWeight) ? "0" : _GrossWeight; }
            set { _GrossWeight = value; }
        }

        public string MaterialNo
        {
            get { return _MaterialNo; }
            set { _MaterialNo = value; }
        }

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        public object PhotoType
        {
            get { return _PhotoType; }
            set { _PhotoType = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string QualiteRemark
        {
            get { return _QualiteRemark; }
            set { _QualiteRemark = value; }
        }
    }
}
