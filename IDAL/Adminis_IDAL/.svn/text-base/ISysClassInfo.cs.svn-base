using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface ISysClassInfo
    {
        IList<SysClassInfo_MDL> selectSysClassInfo(int id, string colname, string coltext);
        IList<SysClassInfo_MDL> selectSysClassInfo(string userid);
        IList<SysClassInfo_MDL> existsSysClassInfo(string classid);
        void insertSysClassInfo(string _classid, string _classname, string _remark);
        void updateSysClassInfo(int _id, string _classid, string _classname, string _Remark);
        void deleteSysClassInfo(int _id);
        void cancelSysClassInfo(ArrayList _idlist);
    }
}
