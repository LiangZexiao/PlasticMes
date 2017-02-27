﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Maintain_MDL
{
    public class MaintainInfo_MDL : LikeQuery
    {
        private int _ID;
        private string v_RepairBillID;
        private string v_RepareDate;
        private string v_DeviceType;
        private string v_RepairTypeID;
        private string v_DeviceNo;
        private string v_RepairType;
        private string v_DeviceTypeID;
        private string v_RepairContent;
        private string v_BeginDate;
        private string v_EndDate;
        private string v_CompleteFlag;

        private string v_Applier;
        private string v_DutyMan;
        private string v_Checker;
        private string v_Remark;
        private string v_MessageFlag;
        private decimal v_RepairHour;
        private int v_MaxMouldNum;


        public MaintainInfo_MDL() { }
        public MaintainInfo_MDL(string vRepairBillID) { this.v_RepairBillID = vRepairBillID; }

        public MaintainInfo_MDL(int vID,
             string vRepairBillID, string vRepareDate, string vDeviceType, string vDeviceTypeID, string vDeviceNo,
             string vRepairType, string vRepairTypeID, string vRepairContent, string vBeginDate, string vEndDate,
             string vCompleteFlag, string vApplier, string vDutyMan, string vChecker, string vRemark, string vMessageFlag,
             decimal vRepairHour, int vMaxMouldNum
          )
        {
            this._ID = vID;
            this.v_RepairBillID = vRepairBillID;
            this.v_RepareDate = vRepareDate;
            this.v_DeviceType = vDeviceType;
            this.v_DeviceTypeID = vDeviceTypeID;
            this.v_DeviceNo = vDeviceNo;
            this.v_RepairType = vRepairType;
            this.v_RepairTypeID = vRepairTypeID;
            this.v_RepairContent = vRepairContent;
            this.v_BeginDate = vBeginDate;
            this.v_EndDate = vEndDate;
            this.v_CompleteFlag = vCompleteFlag;

            this.v_Applier = vApplier;
            this.v_DutyMan = vDutyMan;
            this.v_Checker = vChecker;
            this.v_Remark = vRemark;
            this.v_MessageFlag = vMessageFlag;
            this.v_RepairHour = vRepairHour;
            this.v_MaxMouldNum = vMaxMouldNum;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string RepairBillID
        {
            get { return v_RepairBillID; }
            set { v_RepairBillID = value; }
        }

        public string RepareDate
        {
            get { return v_RepareDate; }
            set { v_RepareDate = value; }
        }

        public string DeviceType
        {
            get { return v_DeviceType; }
            set { v_DeviceType = value; }
        }

        public string DeviceTypeID
        {
            get { return v_DeviceTypeID; }
            set { v_DeviceTypeID = value; }
        }

        public string DeviceNo
        {
            get { return v_DeviceNo; }
            set { v_DeviceNo = value; }
        }

        public string RepairType
        {
            get { return v_RepairType; }
            set { v_RepairType = value; }
        }

        public string RepairTypeID
        {
            get { return v_RepairTypeID; }
            set { v_RepairTypeID = value; }
        }

        public string RepairContent
        {
            get { return v_RepairContent; }
            set { v_RepairContent = value; }
        }

        public string BeginDate
        {
            get { return v_BeginDate; }
            set { v_BeginDate = value; }
        }

        public string EndDate
        {
            get { return v_EndDate; }
            set { v_EndDate = value; }
        }

        public string CompleteFlag
        {
            get { return v_CompleteFlag; }
            set { v_CompleteFlag = value; }
        }

        public string Applier
        {
            get { return v_Applier; }
            set { v_Applier = value; }
        }

        public string DutyMan
        {
            get { return v_DutyMan; }
            set { v_DutyMan = value; }
        }

        public string Checker
        {
            get { return v_Checker; }
            set { v_Checker = value; }
        }

        public string Remark
        {
            get { return v_Remark; }
            set { v_Remark = value; }
        }
        public string MessageFlag
        {
            get { return v_MessageFlag; }
            set { v_MessageFlag = value; }
        }
        public decimal RepairHour
        {
            get { return v_RepairHour; }
            set { v_RepairHour = value; }
        }
        public int MaxMouldNum
        {
            get { return v_MaxMouldNum; }
            set { v_MaxMouldNum = value; }
        }

    }
}
