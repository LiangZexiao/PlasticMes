﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Collect_MDL
{
    public class CommunicationInfo_MDL : LikeQuery
    {
        private int _ID;
        private string _MachineNo;
        private string _CollectorNo;
        private string _IPAddr;
        private string _Port;
        private string _NetGate;
        private string _CommStatusID;
        private string _CommStatus;
        private string _Remark;
        private string _WorkShopID;
        private string _WorkShop;

        public CommunicationInfo_MDL() {}
        public CommunicationInfo_MDL(int vID,
             string vMachineNo,string vCollectorNo,string vIPAddr,string vPort,string vNetGate,
           string vCommStatusID, string vCommStatus,string vRemark,string WorkShop,string WorkShopID)            
        {
            this._ID = vID;
            this._MachineNo = vMachineNo;
            this._CollectorNo = vCollectorNo;
            this._IPAddr = vIPAddr;
            this._Port = vPort;
            this._NetGate = vNetGate;
            this._CommStatusID = vCommStatusID;
            this._CommStatus = vCommStatus;
            this._Remark = vRemark;
            this._WorkShop = WorkShop;
            this._WorkShopID = WorkShopID;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; }
        }

        public string CollectorNo
        {
            get { return _CollectorNo; }
            set { _CollectorNo = value; }
        }

        public string IPAddr
        {
            get { return _IPAddr; }
            set { _IPAddr = value; }
        }

        public string Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        public string NetGate
        {
            get { return _NetGate; }
            set { _NetGate = value; }
        }

        public string CommStatusID
        {
            get { return _CommStatusID; }
            set { _CommStatusID = value; }
        }

        public string CommStatus
        {
            get { return _CommStatus; }
            set { _CommStatus = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string WorkShop
        {
            get { return _WorkShop; }
            set { _WorkShop = value; }
        }
        public string WorkShopID
        {
            get { return _WorkShopID; }
            set { _WorkShopID = value; }
        }

    }
}
