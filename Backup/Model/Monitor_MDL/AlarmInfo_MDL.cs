using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Monitor_MDL
{
    public class AlarmInfo_MDL : LikeQuery
    {
        private int vID;
        private ArrayList vIDs;
        private string vAlarmSource;
        private string vAlarmMachine;
        private string vDutyOn;
        private string vAlarmMemo;
        private string vAlarmStatus;
        private string vSendType;
        private string vAlarmTotalTime;
        private DateTime vCreateDate;
        private string vRemark;
        private string vIsReadFlag;
        private string vNewsCnt;

       public AlarmInfo_MDL() {}
       //public AlarmInfo_MDL(ArrayList vIDs) { this.vIDs = vIDs; }
        public AlarmInfo_MDL(string vAlarmSource, string vNewsCnt)
        {
            this.vAlarmSource = vAlarmSource;
            this.vNewsCnt = vNewsCnt;
        }


       public AlarmInfo_MDL(int vID, string vAlarmSource, string vAlarmMachine, string vDutyOn, string vAlarmMemo,
                string vAlarmStatus, string vSendType, string vAlarmTotalTime, DateTime vCreateDate, string vRemark, string vIsReadFlag)
        {
            this.vID = vID;
            this.vAlarmSource = vAlarmSource;
            this.vAlarmMachine = vAlarmMachine;
            this.vDutyOn = vDutyOn;
            this.vAlarmMemo = vAlarmMemo;
            this.vAlarmStatus = vAlarmStatus;
            this.vSendType = vSendType;
            this.vAlarmTotalTime = vAlarmTotalTime;
            this.vCreateDate = vCreateDate;
            this.vRemark = vRemark;
            this.vIsReadFlag = vIsReadFlag;
        }

       public int ID
       {
           get { return vID; }
           set { vID = value; }
       }
       
       public ArrayList IDs
       {
           get { return vIDs; }
           set { vIDs = value; }
       }
       
       public string AlarmSource
       {
           get { return vAlarmSource; }
           set { vAlarmSource = value; }
       }
       
       public string AlarmMachine
       {
           get { return vAlarmMachine; }
           set { vAlarmMachine = value; }
       }
       
       public string DutyOn
       {
           get { return vDutyOn; }
           set { vDutyOn = value; }
       }
       
       public string AlarmMemo
       {
           get { return vAlarmMemo; }
           set { vAlarmMemo = value; }
       }
       
       public string AlarmStatus
       {
           get { return vAlarmStatus; }
           set { vAlarmStatus = value; }
       }
       
       public string SendType
       {
           get { return vSendType; }
           set { vSendType = value; }
       }
       
       public string AlarmTotalTime
       {
           get { return vAlarmTotalTime; }
           set { vAlarmTotalTime = value; }
       }
       
       public DateTime CreateDate
       {
           get { return vCreateDate; }
           set { vCreateDate = value; }
       }
       
       public string Remark
       {
           get { return vRemark; }
           set { vRemark = value; }
       }
        public string IsReadFlag
       {
           get { return vIsReadFlag; }
           set { vIsReadFlag = value; }
       }
        
       public string NewsCnt
       {
           get { return vNewsCnt; }
           set { vNewsCnt = value; }
       }

    }
}
