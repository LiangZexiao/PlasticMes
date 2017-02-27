using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Monitor_MDL
{
    public class CollectRealProductDataInfo_MDL : LikeQuery
    {
        private string _ID;
        private ArrayList _IDs;
        private string _CollectorID; 
        private string _OrderID; 
        private string _ItemNo; 
        private string _MachineNo; 
        private string _MouldNo; 
        private string _BeginTime; 

        private string _EndTime;
        private string _Switch1;
        private string _Switch2;
        private string _Switch3;
        private string _Switch4;
        private string _Switch5;
        private string _Switch6;
        private string _Switch7;
        private string _Switch8;

        private string _Temp1;
        private string _Temp2;
        private string _Temp3;
        private string _Temp4;
        private string _Temp5;
        private string _Temp6;
        private string _Temp7;
        private string _Temp8;

        private string _ShotPress1;
        private string _ShotPress2;
        private string _ShotPress3;
        private string _ShotPress4;
        private string _KeepPress1;
        private string _KeepPress2;
        private string _KeepPress3;
        private string _FastLockMouldPress;
        private string _LowPressLockMouldPress;
        private string _HighPressLockMouldPress;

        private string _P1; 
        private string _P2;
        private string _Displacement1;
        private string _Displacement2;

        private string _UpLoadTime;

        public CollectRealProductDataInfo_MDL() {}
        public CollectRealProductDataInfo_MDL(ArrayList vIDs) { this._IDs = vIDs; }
        public CollectRealProductDataInfo_MDL(string ID)
        {
            this._ID = ID;
        }

        public CollectRealProductDataInfo_MDL(
            string ID, string CollectorID, string OrderID,string ItemNo, string MachineNo, string MouldNo, string BeginTime, string EndTime,
            string Switch1,string Switch2,string Switch3,string Switch4,string Switch5,string Switch6,string Switch7,string Switch8,
            string Temp1, string Temp2,string Temp3,string Temp4,string Temp5,string Temp6,string Temp7,string Temp8,
            string ShotPress1, string ShotPress2, string ShotPress3, string ShotPress4,
            string KeepPress1, string KeepPress2, string KeepPress3,
            string FastLockMouldPress, string LowPressLockMouldPress, string HighPressLockMouldPress,
            string P1, string P2,string Displacement1,string Displacement2,string UpLoadTime 
          )
        {
        this._ID = ID;
        this._CollectorID = CollectorID;
        this._OrderID = OrderID;
        this._ItemNo = ItemNo;
        this._MachineNo = MachineNo;
        this._MouldNo = MouldNo;
        this._BeginTime = BeginTime;
        this._EndTime = EndTime;

        this._Switch1 =Switch1;
        this._Switch2 =Switch2;
        this._Switch3 =Switch3;
        this._Switch4 =Switch4;
        this._Switch5 =Switch5;
        this._Switch6 =Switch6;
        this._Switch7 =Switch7;
        this._Switch8 =Switch8;

        this._Temp1 =Temp1;
        this._Temp2 =Temp2;
        this._Temp3 =Temp3;
        this._Temp4 =Temp4;
        this._Temp5 =Temp5;
        this._Temp6 =Temp6;
        this._Temp7 =Temp7;
        this._Temp8 =Temp8;

        this._ShotPress1 = ShotPress1;
        this._ShotPress2 = ShotPress2;
        this._ShotPress3 = ShotPress3;
        this._ShotPress4 = ShotPress4;
        this._KeepPress1 = KeepPress1;
        this._KeepPress2 = KeepPress2;
        this._KeepPress3 = KeepPress3;
        this._FastLockMouldPress = FastLockMouldPress;
        this._LowPressLockMouldPress = LowPressLockMouldPress;
        this._HighPressLockMouldPress = HighPressLockMouldPress;

        this._P1 = P1;
        this._P2 = P2;
        this._Displacement1 = Displacement1;
        this._Displacement2 = Displacement2;

        this._UpLoadTime = UpLoadTime;
        }

        public CollectRealProductDataInfo_MDL(
            string CollectorID, string OrderID, string ItemNo, string MachineNo, string MouldNo, string BeginTime, string EndTime,
            string Switch1, string Switch2, string Switch3, string Switch4, string Switch5, string Switch6, string Switch7, string Switch8,
            string Temp1, string Temp2, string Temp3, string Temp4, string Temp5, string Temp6, string Temp7, string Temp8,
            string ShotPress1, string ShotPress2, string ShotPress3,string ShotPress4,
            string KeepPress1, string KeepPress2, string KeepPress3,
            string FastLockMouldPress,string LowPressLockMouldPress,string HighPressLockMouldPress,
            string P1, string P2, string Displacement1, string Displacement2, string UpLoadTime
          )
        {
            this._CollectorID = CollectorID;
            this._OrderID = OrderID;
            this._ItemNo = ItemNo;
            this._MachineNo = MachineNo;
            this._MouldNo = MouldNo;
            this._BeginTime = BeginTime;
            this._EndTime = EndTime;

            this._Switch1 = Switch1;
            this._Switch2 = Switch2;
            this._Switch3 = Switch3;
            this._Switch4 = Switch4;
            this._Switch5 = Switch5;
            this._Switch6 = Switch6;
            this._Switch7 = Switch7;
            this._Switch8 = Switch8;

            this._Temp1 = Temp1;
            this._Temp2 = Temp2;
            this._Temp3 = Temp3;
            this._Temp4 = Temp4;
            this._Temp5 = Temp5;
            this._Temp6 = Temp6;
            this._Temp7 = Temp7;
            this._Temp8 = Temp8;

            this._ShotPress1 = ShotPress1;
            this._ShotPress2 = ShotPress2;
            this._ShotPress3 = ShotPress3;
            this._ShotPress4 = ShotPress4;
            this._KeepPress1 = KeepPress1;
            this._KeepPress2 = KeepPress2;
            this._KeepPress3 = KeepPress3;
            this._FastLockMouldPress = FastLockMouldPress;
            this._LowPressLockMouldPress = LowPressLockMouldPress;
            this._HighPressLockMouldPress = HighPressLockMouldPress;

            this._P1 = P1;
            this._P2 = P2;
            this._Displacement1 = Displacement1;
            this._Displacement2 = Displacement2;

            this._UpLoadTime = UpLoadTime;
        }
        
        public CollectRealProductDataInfo_MDL(string likefieldname, string likefieldvalue)             
        {
            this.LikeFieldName = likefieldname; 
            this.LikeFieldText = likefieldvalue;
        }

        public string ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        public ArrayList IDs
        {
            get { return _IDs; }
            set { _IDs = value; }
        }

        public string CollectorID
        {
            get { return this._CollectorID; }
            set { this._CollectorID = value; }
        }
        public string OrderID
        {
            get { return this._OrderID; }
            set { this._OrderID = value; }
        }
        public string ItemNo
        {
            get { return this._ItemNo; }
            set { this._ItemNo = value; }
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
        public string BeginTime
        {
            get { return this._BeginTime; }
            set { this._BeginTime = value; }
        }
        public string EndTime
        {
            get { return this._EndTime; }
            set { this._EndTime = value; }
        }

        public string Switch1
        {
            get { return this._Switch1; }
            set { this._Switch1 = value; }
        }

        public string Switch2
        {
            get { return this._Switch2; }
            set { this._Switch2 = value; }
        }
        public string Switch3
        {
            get { return this._Switch3; }
            set { this._Switch3 = value; }
        }
        public string Switch4
        {
            get { return this._Switch4; }
            set { this._Switch4 = value; }
        }
        public string Switch5
        {
            get { return this._Switch5; }
            set { this._Switch5 = value; }
        }
        public string Switch6
        {
            get { return this._Switch6; }
            set { this._Switch6 = value; }
        }
        public string Switch7
        {
            get { return this._Switch7; }
            set { this._Switch7 = value; }
        }
        public string Switch8
        {
            get { return this._Switch8; }
            set { this._Switch8 = value; }
        }

        public string Temp1
        {
            get { return this._Temp1; }
            set { this._Temp1 = value; }
        }

        public string Temp2
        {
            get { return this._Temp2; }
            set { this._Temp2 = value; }
        }

        public string Temp3
        {
            get { return this._Temp3; }
            set { this._Temp3 = value; }
        }

        public string Temp4
        {
            get { return this._Temp4; }
            set { this._Temp4 = value; }
        }

        public string Temp5
        {
            get { return this._Temp5; }
            set { this._Temp5 = value; }
        }

        public string Temp6
        {
            get { return this._Temp6; }
            set { this._Temp6 = value; }
        }

        public string Temp7
        {
            get { return this._Temp7; }
            set { this._Temp7 = value; }
        }

        public string Temp8
        {
            get { return this._Temp8; }
            set { this._Temp8 = value; }
        }

        public string ShotPress1
        {
            get { return this._ShotPress1; }
            set { this._ShotPress1 = value; }
        }

                public string ShotPress2
        {
            get { return this._ShotPress2; }
            set { this._ShotPress2 = value; }
        }
                public string ShotPress3
        {
            get { return this._ShotPress3; }
            set { this._ShotPress3 = value; }
        }
                public string ShotPress4
        {
            get { return this._ShotPress4; }
            set { this._ShotPress4 = value; }
        }

        public string KeepPress1
        {
            get { return this._KeepPress1; }
            set { this._KeepPress1 = value; }
        }

        public string KeepPress2
        {
            get { return this._KeepPress2; }
            set { this._KeepPress2 = value; }
        }

        public string KeepPress3
        {
            get { return this._KeepPress3; }
            set { this._KeepPress3 = value; }
        }

        public string FastLockMouldPress
        {
            get { return this._FastLockMouldPress; }
            set { this._FastLockMouldPress = value; }
        }

        public string LowPressLockMouldPress
        {
            get { return this._LowPressLockMouldPress; }
            set { this._LowPressLockMouldPress = value; }
        }

        public string HighPressLockMouldPress
        {
            get { return this._HighPressLockMouldPress; }
            set { this._HighPressLockMouldPress = value; }
        }

        public string P1
        {
            get { return this._P1; }
            set { this._P1 = value; }
        }

        public string P2
        {
            get { return this._P2; }
            set { this._P2 = value; }
        }

        public string Displacement1
        {
            get { return this._Displacement1; }
            set { this._Displacement1 = value; }
        }

        public string Displacement2
        {
            get { return this._Displacement2; }
            set { this._Displacement2 = value; }
        }

        public string UpLoadTime
        {
            get { return this._UpLoadTime; }
            set { this._UpLoadTime = value; }
        }
    }
}
