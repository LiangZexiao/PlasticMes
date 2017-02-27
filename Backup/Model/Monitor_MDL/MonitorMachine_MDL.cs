using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Monitor_MDL
{
    public class MonitorMachine_MDL
    {
        private int _ID;
        private int _DispatchIndex;
        private string _MachineNo;
        private string _DeviceStatus;
        private string _DeviceStatusName;
        private string _Machine_SeatCode;
        private string _MouldNo;
        private string _GoodSocketNum;
        private string _DispatchNo;
        private string _DispatchNum;
        private string _MaterialNo;
        private string _ProductNoName;
        private string _WaterGapScale;
        private string _StandardMinCycle;
        private string _StandardCycle;
        private string _StandardMaxCycle;

        private string _LiveCycle;
        private string _ProductedQty;
        private string _GoodQty;
        private string _BadQty;
        private string _BeginCycle;
        private string _ClientIP;

        public MonitorMachine_MDL() { }
        public MonitorMachine_MDL(int vID, int vDispatchIndex,
                        string vMachineNo, string vDeviceStatus, string vDeviceStatusName, string vMachine_SeatCode, string vMouldNo, string vGoodSocketNum,
                        string vDispatchNo, string vDispatchNum, string vMaterialNo, string vProductNoName, string vWaterGapScale,
                        string vStandardMinCycle, string vStandardCycle, string vStandardMaxCycle, string vLiveCycle, string vProductedQty,
                        string vGoodQty, string vBadQty, string vBeginCycle)
        {
            this._ID = vID;
            this._DispatchIndex = vDispatchIndex;
            this._MachineNo = vMachineNo;
            this._DeviceStatus = vDeviceStatus;
            this._DeviceStatusName = vDeviceStatusName;
            this._Machine_SeatCode = vMachine_SeatCode;
            this._MouldNo = vMouldNo;
            this._GoodSocketNum = vGoodSocketNum;

            this._DispatchNo = vDispatchNo;
            this._DispatchNum = vDispatchNum;
            this._MaterialNo = vMaterialNo;
            this._ProductNoName = vProductNoName;
            this._WaterGapScale = vWaterGapScale;

            this._StandardMinCycle = vStandardMinCycle;
            this._StandardCycle = vStandardCycle;
            this._StandardMaxCycle = vStandardMaxCycle;
            this._LiveCycle = vLiveCycle;
            this._ProductedQty = vProductedQty;

            this._GoodQty = vGoodQty;
            this._BadQty = vBadQty;
            this._BeginCycle = vBeginCycle;
        }
        public MonitorMachine_MDL(int vID, int vDispatchIndex,
                       string vMachineNo, string vDeviceStatus, string vDeviceStatusName, string vMachine_SeatCode, string vMouldNo,
                       string vDispatchNo, string vDispatchNum, string vProductNoName, string vProductedQty,
                       string vGoodQty, string vBadQty, string vBeginCycle, string vLiveCycle
           )
        {
            this._ID = vID;
            this._DispatchIndex = vDispatchIndex;
            this._MachineNo = vMachineNo;
            this._DeviceStatus = vDeviceStatus;
            this._DeviceStatusName = vDeviceStatusName;
            this._Machine_SeatCode = vMachine_SeatCode;
            this._MouldNo = vMouldNo;

            this._DispatchNo = vDispatchNo;
            this._DispatchNum = vDispatchNum;
            this._ProductNoName = vProductNoName;
            this._ProductedQty = vProductedQty;

            this._GoodQty = vGoodQty;
            this._BadQty = vBadQty;
            this._BeginCycle = vBeginCycle;
            this._LiveCycle = vLiveCycle;
        }
        public MonitorMachine_MDL(string vMachineNo, string vDeviceStatus, string vMachine_SeatCode, string vDispatchNo,
                      string vGoodQty, string vLiveCycle, string vClientIP, string vBeginCycle
          )
        {
            this._MachineNo = vMachineNo;
            this._DeviceStatus = vDeviceStatus;
            this._Machine_SeatCode = vMachine_SeatCode;

            this._DispatchNo = vDispatchNo;
            this._GoodQty = vGoodQty;
            this._LiveCycle = vLiveCycle;
            this._ClientIP = vClientIP;
            this._BeginCycle = vBeginCycle;
        }

        public MonitorMachine_MDL(string vDispatchNo, string vClientIP, string vDeviceStatus, string vDeviceStatusName)
        {
            this._DispatchNo = vDispatchNo;
            this._ClientIP = vClientIP;
            this._DeviceStatus = vDeviceStatus;
            this._DeviceStatusName = vDeviceStatusName;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int DispatchIndex
        {
            get { return _DispatchIndex; }
            set { _DispatchIndex = value; }
        }
        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; }
        }

        public string DeviceStatus
        {
            get { return _DeviceStatus; }
            set { _DeviceStatus = value; }
        }
        public string DeviceStatusName
        {
            get { return _DeviceStatusName; }
            set { _DeviceStatusName = value; }
        }

        public string Machine_SeatCode
        {
            get { return _Machine_SeatCode; }
            set { _Machine_SeatCode = value; }
        }
        public string MouldNo
        {
            get { return _MouldNo; }
            set { _MouldNo = value; }
        }

        public string GoodSocketNum
        {
            get { return _GoodSocketNum; }
            set { _GoodSocketNum = value; }
        }

        public string DispatchNo
        {
            get { return _DispatchNo; }
            set { _DispatchNo = value; }
        }

        public string DispatchNum
        {
            get { return _DispatchNum; }
            set { _DispatchNum = value; }
        }

        public string MaterialNo
        {
            get { return _MaterialNo; }
            set { _MaterialNo = value; }
        }

        public string ProductNoName
        {
            get { return _ProductNoName; }
            set { _ProductNoName = value; }
        }

        public string WaterGapScale
        {
            get { return _WaterGapScale; }
            set { _WaterGapScale = value; }
        }

        public string StandardMinCycle
        {
            get { return _StandardMinCycle; }
            set { _StandardMinCycle = value; }
        }

        public string StandardCycle
        {
            get { return _StandardCycle; }
            set { _StandardCycle = value; }
        }

        public string StandardMaxCycle
        {
            get { return _StandardMaxCycle; }
            set { _StandardMaxCycle = value; }
        }

        public string LiveCycle
        {
            get { return _LiveCycle; }
            set { _LiveCycle = value; }
        }

        public string ProductedQty
        {
            get { return _ProductedQty; }
            set { _ProductedQty = value; }
        }

        public string GoodQty
        {
            get { return _GoodQty; }
            set { _GoodQty = value; }
        }

        public string BadQty
        {
            get { return _BadQty; }
            set { _BadQty = value; }
        }

        public string BeginCycle
        {
            get { return _BeginCycle; }
            set { _BeginCycle = value; }
        }
        public string ClientIP
        {
            get { return _ClientIP; }
            set { _ClientIP = value; }
        }


    }
}
