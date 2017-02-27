using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Collect_MDL
{
    public class DataHistory_MDL : LikeQuery
    {
        private string _ID;
        private string _MachineNo;
        private string _MouldNo;
        private string _WorkOrderNo;
        private string _DispatchOrder;
        private string _ProductNo;
        private string _TotalNum;
        private string _Cycletime;
        private string _BeginTime;
        private string _EndTime;
        private string _ClientIp;

        private string _KeepPress1;
        private string _KeepPress2;
        private string _KeepPress3;
        private string _KeepPress4;
        private string _KeepPress5;
        private string _KeepPress6;
        private string _KeepPress7;
        private string _KeepPress8;
        private string _KeepPress9;
        private string _KeepPress10;

        private string _KeepPress11;
        private string _KeepPress12;
        private string _KeepPress13;
        private string _KeepPress14;
        private string _KeepPress15;
        private string _KeepPress16;
        private string _KeepPress17;
        private string _KeepPress18;
        private string _KeepPress19;
        private string _KeepPress20;

        private string _KeepPress21;
        private string _KeepPress22;
        private string _KeepPress23;
        private string _KeepPress24;
        private string _KeepPress25;
        private string _KeepPress26;
        private string _KeepPress27;
        private string _KeepPress28;
        private string _KeepPress29;
        private string _KeepPress30;

        private string _KeepPress31;
        private string _KeepPress32;
        private string _KeepPress33;
        private string _KeepPress34;
        private string _KeepPress35;
        private string _KeepPress36;
        private string _KeepPress37;
        private string _KeepPress38;
        private string _KeepPress39;
        private string _KeepPress40;

        private string _KeepPress41;
        private string _KeepPress42;
        private string _KeepPress43;
        private string _KeepPress44;
        private string _KeepPress45;
        private string _KeepPress46;
        private string _KeepPress47;
        private string _KeepPress48;
        private string _KeepPress49;
        private string _KeepPress50;

        private string _KeepPress51;
        private string _KeepPress52;
        private string _KeepPress53;
        private string _KeepPress54;
        private string _KeepPress55;
        private string _KeepPress56;
        private string _KeepPress57;
        private string _KeepPress58;
        private string _KeepPress59;
        private string _KeepPress60;
        
        private string _KeepPress61;
        private string _KeepPress62;
        private string _KeepPress63;
        private string _KeepPress64;
        private string _KeepPress65;
        private string _KeepPress66;
        private string _KeepPress67;
        private string _KeepPress68;
        private string _KeepPress69;
        private string _KeepPress70;

        private string _KeepPress71;
        private string _KeepPress72;
        private string _KeepPress73;
        private string _KeepPress74;
        private string _KeepPress75;
        private string _KeepPress76;
        private string _KeepPress77;
        private string _KeepPress78;
        private string _KeepPress79;
        private string _KeepPress80;

        private string _KeepPress81;
        private string _KeepPress82;
        private string _KeepPress83;
        private string _KeepPress84;
        private string _KeepPress85;
        private string _KeepPress86;
        private string _KeepPress87;
        private string _KeepPress88;
        private string _KeepPress89;
        private string _KeepPress90;

        private string _KeepPress91;
        private string _KeepPress92;
        private string _KeepPress93;
        private string _KeepPress94;
        private string _KeepPress95;
        private string _KeepPress96;
        private string _KeepPress97;
        private string _KeepPress98;
        private string _KeepPress99;
        private string _KeepPress100;
        private string _KeepPress_Max;

        private string _ShotTemp1;
        private string _ShotTemp2;

        private string _IntervalInfo;
      
        private string _FillTime;
        
        private string _UpLoadTime;
        private string _InjectNum;

        public DataHistory_MDL() { }
        public DataHistory_MDL(string ID,
            string MachineNo, string MouldNo, string WorkOrderNo, string DispatchOrder, string ProductNo,
            string TotalNum,   string Cycletime, string BeginTime, string EndTime,string vClientIp,
            string ShotTemp1, string ShotTemp2, 
            string IntervalInfo,  string FillTime,  string UpLoadTime, string KeepPress_Max, string InjectNum 
          )
        {
            this._ID = ID;
            this._MachineNo = MachineNo;
            this._MouldNo = MouldNo;
            this._WorkOrderNo = WorkOrderNo;
            this._DispatchOrder = DispatchOrder;
            this._ProductNo = ProductNo;
            this._TotalNum = TotalNum;
            this._Cycletime = Cycletime;

            this._BeginTime = BeginTime;
            this._EndTime = EndTime;
        
            this._ClientIp = vClientIp;

            //this._KeepPress1 = KeepPress1;
            //this._KeepPress2 = KeepPress2;
            //this._KeepPress3 = KeepPress3;
            //this._KeepPress4 = KeepPress4;
            //this._KeepPress5 = KeepPress5;
            //this._KeepPress6 = KeepPress6;
            //this._KeepPress7 = KeepPress7;
            //this._KeepPress8 = KeepPress8;
            //this._KeepPress9 = KeepPress9;
            //this._KeepPress10 = KeepPress10;

            //this._KeepPress11 = KeepPress11;
            //this._KeepPress12 = KeepPress12;
            //this._KeepPress13 = KeepPress13;
            //this._KeepPress14 = KeepPress14;
            //this._KeepPress15 = KeepPress15;
            //this._KeepPress16 = KeepPress16;
            //this._KeepPress17 = KeepPress17;
            //this._KeepPress18 = KeepPress18;
            //this._KeepPress19 = KeepPress19;
            //this._KeepPress20 = KeepPress20;

            //this._KeepPress21 = KeepPress21;
            //this._KeepPress22 = KeepPress22;
            //this._KeepPress23 = KeepPress23;
            //this._KeepPress24 = KeepPress24;
            //this._KeepPress25 = KeepPress25;
            //this._KeepPress26 = KeepPress26;
            //this._KeepPress27 = KeepPress27;
            //this._KeepPress28 = KeepPress28;
            //this._KeepPress29 = KeepPress29;
            //this._KeepPress30 = KeepPress30;

            //this._KeepPress31 = KeepPress31;
            //this._KeepPress32 = KeepPress32;
            //this._KeepPress33 = KeepPress33;
            //this._KeepPress34 = KeepPress34;
            //this._KeepPress35 = KeepPress35;
            //this._KeepPress36 = KeepPress36;
            //this._KeepPress37 = KeepPress37;
            //this._KeepPress38 = KeepPress38;
            //this._KeepPress39 = KeepPress39;
            //this._KeepPress40 = KeepPress40;

            //this._KeepPress41 = KeepPress41;
            //this._KeepPress42 = KeepPress42;
            //this._KeepPress43 = KeepPress43;
            //this._KeepPress44 = KeepPress44;
            //this._KeepPress45 = KeepPress45;
            //this._KeepPress46 = KeepPress46;
            //this._KeepPress47 = KeepPress47;
            //this._KeepPress48 = KeepPress48;
            //this._KeepPress49 = KeepPress49;
            //this._KeepPress50 = KeepPress50;

            //this._KeepPress51 = KeepPress51;
            //this._KeepPress52 = KeepPress52;
            //this._KeepPress53 = KeepPress53;
            //this._KeepPress54 = KeepPress54;
            //this._KeepPress55 = KeepPress55;
            //this._KeepPress56 = KeepPress56;
            //this._KeepPress57 = KeepPress57;
            //this._KeepPress58 = KeepPress58;
            //this._KeepPress59 = KeepPress59;
            //this._KeepPress60 = KeepPress60;

            //this._KeepPress61 = KeepPress61;
            //this._KeepPress62 = KeepPress62;
            //this._KeepPress63 = KeepPress63;
            //this._KeepPress64 = KeepPress64;
            //this._KeepPress65 = KeepPress65;
            //this._KeepPress66 = KeepPress66;
            //this._KeepPress67 = KeepPress67;
            //this._KeepPress68 = KeepPress68;
            //this._KeepPress69 = KeepPress69;
            //this._KeepPress70 = KeepPress70;

            //this._KeepPress71 = KeepPress71;
            //this._KeepPress72 = KeepPress72;
            //this._KeepPress73 = KeepPress73;
            //this._KeepPress74 = KeepPress74;
            //this._KeepPress75 = KeepPress75;
            //this._KeepPress76 = KeepPress76;
            //this._KeepPress77 = KeepPress77;
            //this._KeepPress78 = KeepPress78;
            //this._KeepPress79 = KeepPress79;
            //this._KeepPress80 = KeepPress80;

            //this._KeepPress81 = KeepPress81;
            //this._KeepPress82 = KeepPress82;
            //this._KeepPress83 = KeepPress83;
            //this._KeepPress84 = KeepPress84;
            //this._KeepPress85 = KeepPress85;
            //this._KeepPress86 = KeepPress86;
            //this._KeepPress87 = KeepPress87;
            //this._KeepPress88 = KeepPress88;
            //this._KeepPress89 = KeepPress89;
            //this._KeepPress90 = KeepPress90;

            //this._KeepPress91 = KeepPress91;
            //this._KeepPress92 = KeepPress92;
            //this._KeepPress93 = KeepPress93;
            //this._KeepPress94 = KeepPress94;
            //this._KeepPress95 = KeepPress95;
            //this._KeepPress96 = KeepPress96;
            //this._KeepPress97 = KeepPress97;
            //this._KeepPress98 = KeepPress98;
            //this._KeepPress99 = KeepPress99;
            //this._KeepPress100 = KeepPress100;

            this._ShotTemp1 = ShotTemp1;
            this._ShotTemp2 = ShotTemp2;

            this._IntervalInfo = IntervalInfo;
           
            this._FillTime = FillTime;
        
            this._UpLoadTime = UpLoadTime;
            this._KeepPress_Max = KeepPress_Max;
            this._InjectNum = InjectNum;
        }

        public DataHistory_MDL(string MachineNo, string MouldNo, string WorkOrderNo, string DispatchOrder, string ProductNo, 
            string TotalNum,   string Cycletime, string BeginTime, string EndTime,string vClientIp,

            //string KeepPress1, string KeepPress2, string KeepPress3, string KeepPress4, string KeepPress5, 
            //string KeepPress6, string KeepPress7, string KeepPress8, string KeepPress9, string KeepPress10, 
            //string KeepPress11, string KeepPress12, string KeepPress13, string KeepPress14, string KeepPress15, 
            //string KeepPress16, string KeepPress17, string KeepPress18, string KeepPress19, string KeepPress20,
            //string KeepPress21, string KeepPress22, string KeepPress23, string KeepPress24, string KeepPress25,
            //string KeepPress26, string KeepPress27, string KeepPress28, string KeepPress29, string KeepPress30,
            //string KeepPress31, string KeepPress32, string KeepPress33, string KeepPress34, string KeepPress35,
            //string KeepPress36, string KeepPress37, string KeepPress38, string KeepPress39, string KeepPress40,
            //string KeepPress41, string KeepPress42, string KeepPress43, string KeepPress44, string KeepPress45,
            //string KeepPress46, string KeepPress47, string KeepPress48, string KeepPress49, string KeepPress50,
            //string KeepPress51, string KeepPress52, string KeepPress53, string KeepPress54, string KeepPress55,
            //string KeepPress56, string KeepPress57, string KeepPress58, string KeepPress59, string KeepPress60,
            //string KeepPress61, string KeepPress62, string KeepPress63, string KeepPress64, string KeepPress65,
            //string KeepPress66, string KeepPress67, string KeepPress78, string KeepPress69, string KeepPress70,
            //string KeepPress71, string KeepPress72, string KeepPress73, string KeepPress74, string KeepPress75,
            //string KeepPress76, string KeepPress77, string KeepPress68, string KeepPress79, string KeepPress80,
            //string KeepPress81, string KeepPress82, string KeepPress83, string KeepPress84, string KeepPress85,
            //string KeepPress86, string KeepPress87, string KeepPress88, string KeepPress89, string KeepPress90,
            //string KeepPress91, string KeepPress92, string KeepPress93, string KeepPress94, string KeepPress95,
            //string KeepPress96, string KeepPress97, string KeepPress98, string KeepPress99, string KeepPress100,
            string ShotTemp1, string ShotTemp2,
            string IntervalInfo,string FillTime,  string UpLoadTime, string KeepPress_Max, string InjectNum
          )
        {
            this._MachineNo = MachineNo;
            this._MouldNo = MouldNo;
            this._WorkOrderNo = WorkOrderNo;
            this._DispatchOrder = DispatchOrder;
            this._ProductNo = ProductNo;
            this._TotalNum = TotalNum;
            this._Cycletime = Cycletime;
            this._BeginTime = BeginTime;
            this._EndTime = EndTime;
            this._ClientIp = vClientIp;

            //this._KeepPress1 = KeepPress1;
            //this._KeepPress2 = KeepPress2;
            //this._KeepPress3 = KeepPress3;
            //this._KeepPress4 = KeepPress4;
            //this._KeepPress5 = KeepPress5;
            //this._KeepPress6 = KeepPress6;
            //this._KeepPress7 = KeepPress7;
            //this._KeepPress8 = KeepPress8;
            //this._KeepPress9 = KeepPress9;
            //this._KeepPress10 = KeepPress10;

            //this._KeepPress11 = KeepPress11;
            //this._KeepPress12 = KeepPress12;
            //this._KeepPress13 = KeepPress13;
            //this._KeepPress14 = KeepPress14;
            //this._KeepPress15 = KeepPress15;
            //this._KeepPress16 = KeepPress16;
            //this._KeepPress17 = KeepPress17;
            //this._KeepPress18 = KeepPress18;
            //this._KeepPress19 = KeepPress19;
            //this._KeepPress20 = KeepPress20;

            //this._KeepPress21 = KeepPress21;
            //this._KeepPress22 = KeepPress22;
            //this._KeepPress23 = KeepPress23;
            //this._KeepPress24 = KeepPress24;
            //this._KeepPress25 = KeepPress25;
            //this._KeepPress26 = KeepPress26;
            //this._KeepPress27 = KeepPress27;
            //this._KeepPress28 = KeepPress28;
            //this._KeepPress29 = KeepPress29;
            //this._KeepPress30 = KeepPress30;

            //this._KeepPress31 = KeepPress31;
            //this._KeepPress32 = KeepPress32;
            //this._KeepPress33 = KeepPress33;
            //this._KeepPress34 = KeepPress34;
            //this._KeepPress35 = KeepPress35;
            //this._KeepPress36 = KeepPress36;
            //this._KeepPress37 = KeepPress37;
            //this._KeepPress38 = KeepPress38;
            //this._KeepPress39 = KeepPress39;
            //this._KeepPress40 = KeepPress40;

            //this._KeepPress41 = KeepPress41;
            //this._KeepPress42 = KeepPress42;
            //this._KeepPress43 = KeepPress43;
            //this._KeepPress44 = KeepPress44;
            //this._KeepPress45 = KeepPress45;
            //this._KeepPress46 = KeepPress46;
            //this._KeepPress47 = KeepPress47;
            //this._KeepPress48 = KeepPress48;
            //this._KeepPress49 = KeepPress49;
            //this._KeepPress50 = KeepPress50;

            //this._KeepPress51 = KeepPress51;
            //this._KeepPress52 = KeepPress52;
            //this._KeepPress53 = KeepPress53;
            //this._KeepPress54 = KeepPress54;
            //this._KeepPress55 = KeepPress55;
            //this._KeepPress56 = KeepPress56;
            //this._KeepPress57 = KeepPress57;
            //this._KeepPress58 = KeepPress58;
            //this._KeepPress59 = KeepPress59;
            //this._KeepPress60 = KeepPress60;

            //this._KeepPress61 = KeepPress61;
            //this._KeepPress62 = KeepPress62;
            //this._KeepPress63 = KeepPress63;
            //this._KeepPress64 = KeepPress64;
            //this._KeepPress65 = KeepPress65;
            //this._KeepPress66 = KeepPress66;
            //this._KeepPress67 = KeepPress67;
            //this._KeepPress68 = KeepPress68;
            //this._KeepPress69 = KeepPress69;
            //this._KeepPress70 = KeepPress70;

            //this._KeepPress71 = KeepPress71;
            //this._KeepPress72 = KeepPress72;
            //this._KeepPress73 = KeepPress73;
            //this._KeepPress74 = KeepPress74;
            //this._KeepPress75 = KeepPress75;
            //this._KeepPress76 = KeepPress76;
            //this._KeepPress77 = KeepPress77;
            //this._KeepPress78 = KeepPress78;
            //this._KeepPress79 = KeepPress79;
            //this._KeepPress80 = KeepPress80;

            //this._KeepPress81 = KeepPress81;
            //this._KeepPress82 = KeepPress82;
            //this._KeepPress83 = KeepPress83;
            //this._KeepPress84 = KeepPress84;
            //this._KeepPress85 = KeepPress85;
            //this._KeepPress86 = KeepPress86;
            //this._KeepPress87 = KeepPress87;
            //this._KeepPress88 = KeepPress88;
            //this._KeepPress89 = KeepPress89;
            //this._KeepPress90 = KeepPress90;

            //this._KeepPress91 = KeepPress91;
            //this._KeepPress92 = KeepPress92;
            //this._KeepPress93 = KeepPress93;
            //this._KeepPress94 = KeepPress94;
            //this._KeepPress95 = KeepPress95;
            //this._KeepPress96 = KeepPress96;
            //this._KeepPress97 = KeepPress97;
            //this._KeepPress98 = KeepPress98;
            //this._KeepPress99 = KeepPress99;
            //this._KeepPress100 = KeepPress100;

            this._ShotTemp1 = ShotTemp1;
            this._ShotTemp2 = ShotTemp2;
            

            this._IntervalInfo = IntervalInfo;
            
            this._FillTime = FillTime;
            
            this._UpLoadTime = UpLoadTime;
            this._KeepPress_Max = KeepPress_Max;
            this._InjectNum = InjectNum;
        }

        public DataHistory_MDL(string likefieldname, string likefieldvalue)
        {
            this.LikeFieldName = likefieldname; 
            this.LikeFieldText = likefieldvalue;
        }

        public string ID
        {
            get { return this._ID; }
            set { this._ID = value; }
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

        public string WorkOrderNo
        {
            get { return this._WorkOrderNo; }
            set { this._WorkOrderNo = value; }
        }
        public string DispatchOrder
        {
            get { return this._DispatchOrder; }
            set { this._DispatchOrder = value; }
        }
        public string ProductNo
        {
            get { return this._ProductNo; }
            set { this._ProductNo = value; }
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

        public string TotalNum
        {
            get { return this._TotalNum; }
            set { this._TotalNum = value; }
        }

      


        public string Cycletime
        {
            get { return this._Cycletime; }
            set { this._Cycletime = value; }
        }

        public string ClientIp
        {
            get { return _ClientIp; }
            set { _ClientIp = value; }
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
        public string KeepPress4
        {
            get { return this._KeepPress4; }
            set { this._KeepPress4 = value; }
        }
        public string KeepPress5
        {
            get { return this._KeepPress5; }
            set { this._KeepPress5 = value; }
        }
        public string KeepPress6
        {
            get { return this._KeepPress6; }
            set { this._KeepPress6 = value; }
        }

        public string KeepPress7
        {
            get { return this._KeepPress7; }
            set { this._KeepPress7 = value; }
        }

        public string KeepPress8
        {
            get { return this._KeepPress8; }
            set { this._KeepPress8 = value; }
        }

        public string KeepPress9
        {
            get { return this._KeepPress9; }
            set { this._KeepPress9 = value; }
        }        

        public string KeepPress10
        {
            get { return this._KeepPress10; }
            set { this._KeepPress10 = value; }
        }

        public string KeepPress11
        {
            get { return this._KeepPress11; }
            set { this._KeepPress11 = value; }
        }

        public string KeepPress12
        {
            get { return this._KeepPress12; }
            set { this._KeepPress12 = value; }
        }

        public string KeepPress13
        {
            get { return this._KeepPress13; }
            set { this._KeepPress13 = value; }
        }

        public string KeepPress14
        {
            get { return this._KeepPress14; }
            set { this._KeepPress14 = value; }
        }

        public string KeepPress15
        {
            get { return this._KeepPress15; }
            set { this._KeepPress15 = value; }
        }

        public string KeepPress16
        {
            get { return this._KeepPress16; }
            set { this._KeepPress16 = value; }
        }

        public string KeepPress17
        {
            get { return this._KeepPress17; }
            set { this._KeepPress17 = value; }
        }
        
        public string KeepPress18
        {
            get { return this._KeepPress18; }
            set { this._KeepPress18 = value; }
        }

        public string KeepPress19
        {
            get { return this._KeepPress19; }
            set { this._KeepPress19 = value; }
        }

        public string KeepPress20
        {
            get { return this._KeepPress20; }
            set { this._KeepPress20 = value; }
        }

        public string KeepPress21
        {
            get { return this._KeepPress21; }
            set { this._KeepPress21 = value; }
        }

        public string KeepPress22
        {
            get { return this._KeepPress22; }
            set { this._KeepPress22 = value; }
        }

        public string KeepPress23
        {
            get { return this._KeepPress23; }
            set { this._KeepPress23 = value; }
        }

        public string KeepPress24
        {
            get { return this._KeepPress24; }
            set { this._KeepPress24 = value; }
        }

        public string KeepPress25
        {
            get { return this._KeepPress25; }
            set { this._KeepPress25 = value; }
        }

        public string KeepPress26
        {
            get { return this._KeepPress26; }
            set { this._KeepPress26 = value; }
        }

        public string KeepPress27
        {
            get { return this._KeepPress27; }
            set { this._KeepPress27 = value; }
        }

        public string KeepPress28
        {
            get { return this._KeepPress28; }
            set { this._KeepPress28 = value; }
        }

        public string KeepPress29
        {
            get { return this._KeepPress29; }
            set { this._KeepPress29 = value; }
        }

        public string KeepPress30
        {
            get { return this._KeepPress30; }
            set { this._KeepPress30 = value; }
        }

        public string KeepPress31
        {
            get { return this._KeepPress31; }
            set { this._KeepPress31 = value; }
        }

        public string KeepPress32
        {
            get { return this._KeepPress32; }
            set { this._KeepPress32 = value; }
        }

        public string KeepPress33
        {
            get { return this._KeepPress33; }
            set { this._KeepPress33 = value; }
        }

        public string KeepPress34
        {
            get { return this._KeepPress34; }
            set { this._KeepPress34 = value; }
        }

        public string KeepPress35
        {
            get { return this._KeepPress35; }
            set { this._KeepPress35 = value; }
        }

        public string KeepPress36
        {
            get { return this._KeepPress36; }
            set { this._KeepPress36 = value; }
        }

        public string KeepPress37
        {
            get { return this._KeepPress37; }
            set { this._KeepPress37 = value; }
        }

        public string KeepPress38
        {
            get { return this._KeepPress38; }
            set { this._KeepPress38 = value; }
        }

        public string KeepPress39
        {
            get { return this._KeepPress39; }
            set { this._KeepPress39 = value; }
        }

        public string KeepPress40
        {
            get { return this._KeepPress40; }
            set { this._KeepPress40 = value; }
        }

        public string KeepPress41
        {
            get { return this._KeepPress41; }
            set { this._KeepPress41 = value; }
        }

        public string KeepPress42
        {
            get { return this._KeepPress42; }
            set { this._KeepPress42 = value; }
        }

        public string KeepPress43
        {
            get { return this._KeepPress43; }
            set { this._KeepPress43 = value; }
        }

        public string KeepPress44
        {
            get { return this._KeepPress44; }
            set { this._KeepPress44 = value; }
        }

        public string KeepPress45
        {
            get { return this._KeepPress45; }
            set { this._KeepPress45 = value; }
        }

        public string KeepPress46
        {
            get { return this._KeepPress46; }
            set { this._KeepPress46 = value; }
        }

        public string KeepPress47
        {
            get { return this._KeepPress47; }
            set { this._KeepPress47 = value; }
        }
        
        public string KeepPress48
        {
            get { return this._KeepPress48; }
            set { this._KeepPress48 = value; }
        }

        public string KeepPress49
        {
            get { return this._KeepPress49; }
            set { this._KeepPress49 = value; }
        }

        public string KeepPress50
        {
            get { return this._KeepPress50; }
            set { this._KeepPress50 = value; }
        }

        public string KeepPress51
        {
            get { return this._KeepPress51; }
            set { this._KeepPress51 = value; }
        }

        public string KeepPress52
        {
            get { return this._KeepPress52; }
            set { this._KeepPress52 = value; }
        }

        public string KeepPress53
        {
            get { return this._KeepPress53; }
            set { this._KeepPress53 = value; }
        }

        public string KeepPress54
        {
            get { return this._KeepPress54; }
            set { this._KeepPress54 = value; }
        }

        public string KeepPress55
        {
            get { return this._KeepPress55; }
            set { this._KeepPress55 = value; }
        }

        public string KeepPress56
        {
            get { return this._KeepPress56; }
            set { this._KeepPress56 = value; }
        }

        public string KeepPress57
        {
            get { return this._KeepPress57; }
            set { this._KeepPress57 = value; }
        }

        public string KeepPress58
        {
            get { return this._KeepPress58; }
            set { this._KeepPress58 = value; }
        }

        public string KeepPress59
        {
            get { return this._KeepPress59; }
            set { this._KeepPress59 = value; }
        }

        public string KeepPress60
        {
            get { return this._KeepPress60; }
            set { this._KeepPress60 = value; }
        }

        public string KeepPress61
        {
            get { return this._KeepPress61; }
            set { this._KeepPress61 = value; }
        }

        public string KeepPress62
        {
            get { return this._KeepPress62; }
            set { this._KeepPress62 = value; }
        }

        public string KeepPress63
        {
            get { return this._KeepPress63; }
            set { this._KeepPress63 = value; }
        }

        public string KeepPress64
        {
            get { return this._KeepPress64; }
            set { this._KeepPress64 = value; }
        }

        public string KeepPress65
        {
            get { return this._KeepPress65; }
            set { this._KeepPress65 = value; }
        }

        public string KeepPress66
        {
            get { return this._KeepPress66; }
            set { this._KeepPress66 = value; }
        }

        public string KeepPress67
        {
            get { return this._KeepPress67; }
            set { this._KeepPress67 = value; }
        }

        public string KeepPress68
        {
            get { return this._KeepPress68; }
            set { this._KeepPress68 = value; }
        }

        public string KeepPress69
        {
            get { return this._KeepPress69; }
            set { this._KeepPress69 = value; }
        }

        public string KeepPress70
        {
            get { return this._KeepPress70; }
            set { this._KeepPress70 = value; }
        }

        public string KeepPress71
        {
            get { return this._KeepPress71; }
            set { this._KeepPress71 = value; }
        }

        public string KeepPress72
        {
            get { return this._KeepPress72; }
            set { this._KeepPress72 = value; }
        }

        public string KeepPress73
        {
            get { return this._KeepPress73; }
            set { this._KeepPress73 = value; }
        }

        public string KeepPress74
        {
            get { return this._KeepPress74; }
            set { this._KeepPress74 = value; }
        }

        public string KeepPress75
        {
            get { return this._KeepPress75; }
            set { this._KeepPress75 = value; }
        }

        public string KeepPress76
        {
            get { return this._KeepPress76; }
            set { this._KeepPress76 = value; }
        }

        public string KeepPress77
        {
            get { return this._KeepPress77; }
            set { this._KeepPress77 = value; }
        }

        public string KeepPress78
        {
            get { return this._KeepPress78; }
            set { this._KeepPress78 = value; }
        }

        public string KeepPress79
        {
            get { return this._KeepPress79; }
            set { this._KeepPress79 = value; }
        }

        public string KeepPress80
        {
            get { return this._KeepPress80; }
            set { this._KeepPress80 = value; }
        }

        public string KeepPress81
        {
            get { return this._KeepPress81; }
            set { this._KeepPress81 = value; }
        }

        public string KeepPress82
        {
            get { return this._KeepPress82; }
            set { this._KeepPress82 = value; }
        }

        public string KeepPress83
        {
            get { return this._KeepPress83; }
            set { this._KeepPress83 = value; }
        }

        public string KeepPress84
        {
            get { return this._KeepPress84; }
            set { this._KeepPress84 = value; }
        }

        public string KeepPress85
        {
            get { return this._KeepPress85; }
            set { this._KeepPress85 = value; }
        }

        public string KeepPress86
        {
            get { return this._KeepPress86; }
            set { this._KeepPress86 = value; }
        }

        public string KeepPress87
        {
            get { return this._KeepPress87; }
            set { this._KeepPress87 = value; }
        }

        public string KeepPress88
        {
            get { return this._KeepPress88; }
            set { this._KeepPress88 = value; }
        }

        public string KeepPress89
        {
            get { return this._KeepPress89; }
            set { this._KeepPress89 = value; }
        }

        public string KeepPress90
        {
            get { return this._KeepPress90; }
            set { this._KeepPress90 = value; }
        }

        public string KeepPress91
        {
            get { return this._KeepPress91; }
            set { this._KeepPress91 = value; }
        }

        public string KeepPress92
        {
            get { return this._KeepPress92; }
            set { this._KeepPress92 = value; }
        }

        public string KeepPress93
        {
            get { return this._KeepPress93; }
            set { this._KeepPress93 = value; }
        }

        public string KeepPress94
        {
            get { return this._KeepPress94; }
            set { this._KeepPress94 = value; }
        }

        public string KeepPress95
        {
            get { return this._KeepPress95; }
            set { this._KeepPress95 = value; }
        }

        public string KeepPress96
        {
            get { return this._KeepPress96; }
            set { this._KeepPress96 = value; }
        }

        public string KeepPress97
        {
            get { return this._KeepPress97; }
            set { this._KeepPress97 = value; }
        }

        public string KeepPress98
        {
            get { return this._KeepPress98; }
            set { this._KeepPress98 = value; }
        }

        public string KeepPress99
        {
            get { return this._KeepPress99; }
            set { this._KeepPress99 = value; }
        }

        public string KeepPress100
        {
            get { return this._KeepPress100; }
            set { this._KeepPress100 = value; }
        }
        
        public string KeepPress_Max
        {
            get { return this._KeepPress_Max; }
            set { this._KeepPress_Max = value; }
        }

        public string ShotTemp1
        {
            get { return this._ShotTemp1; }
            set { this._ShotTemp1 = value; }
        }
        public string ShotTemp2
        {
            get { return this._ShotTemp2; }
            set { this._ShotTemp2 = value; }
        }

        

        public string IntervalInfo
        {
            get { return this._IntervalInfo; }
            set { this._IntervalInfo = value; }
        }
        
       
        
        public string FillTime
        {
            get { return this._FillTime; }
            set { this._FillTime = value; }
        }
       
      
        public string UpLoadTime
        {
            get { return this._UpLoadTime; }
            set { this._UpLoadTime = value; }
        }
        public string InjectNum
        {
            get { return this._InjectNum; }
            set { this._InjectNum = value; }
        }
    }
}
