using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Maintain_MDL;


namespace Admin.IDAL.Maintain_IDAL
{
    public interface IMaintainInfo
    {
        IList<MaintainInfo_MDL> selectMaintainInfo(int id, string colname, string coltext, string WebUIName);
        //IList<MaintainInfo_MDL> selectMaintainInfo(string vWorkOrderNo);
        IList<MaintainInfo_MDL> existsMaintainInfo(string vRepairBillID);
        IList<MaintainInfo_MDL> existsMaintainInfo(string vRepareDate, string vDeviceNo);

        void ChangeMaintainInfo(int vID,
            string vRepairBillID, string vRepareDate, string vDeviceType, string vDeviceNo, string vRepairType,
            string vRepairContent, string vBeginDate, string vEndDate, string vCompleteFlag, string vApplier,
            string vDutyMan, string vChecker, string vRemark, string vMessageFlag,decimal vRepairHour,int vMaxMouldNum, string IU);

        //void checkMaintainInfo(int vID, string vChecker, string flag);
        //void deleteMaintainInfo(int ID);
        void cancelMaintainInfo(ArrayList IDList);
        int DeleteMainInfo(string types);
    }
}
