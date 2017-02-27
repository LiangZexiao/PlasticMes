using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;

namespace Admin.IDAL.Monitor_IDAL
{
    public interface IAlarmInfo
    {
        IList<AlarmInfo_MDL> selectAlarmInfo();
        //IList<AlarmInfo_MDL> selectAlarmInfo(int id);
        IList<AlarmInfo_MDL> selectAlarmInfo(int id, string AlarmSource, string colname, string coltext);
        void updateAlarmInfo(int _ID);
        //DataTable selectAlarmInfo(int id, string AlarmSource, string colname, string coltext);
        //IList<AlarmInfo_MDL> existsAlarmInfo(string GroupID);
        //void insertAlarmInfo(string GroupID, string GroupName, string Header, string Action, int MemberNum, string Remark);
        //void updateAlarmInfo(int ID, string GroupID, string GroupName, string Header, string Action, int MemberNum, string Remark);
        //void deleteAlarmInfo(int ID);
        //void cancelAlarmInfo(ArrayList IDlist);
    }
}
