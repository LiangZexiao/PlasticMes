using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface ISysProgramInfo
    {
        IList<ProgramInfo_MDL> selectProgramInfo();
        IList<ProgramInfo_MDL> selectProgramInfo(int id);
        IList<ProgramInfo_MDL> selectProgramInfo(string userid,string classid);
        IList<ProgramInfo_MDL> selectProgramInfo(int id, string colname, string coltext);
        IList<ProgramInfo_MDL> existsProgramInfo(string _ProgramID);
        void insertProgramInfo(string _ProgramID, string _ProgramName, string _RequestURL, string _ClassID,string _OrderID,
            string Locked, DateTime _aDate, DateTime _mDate);
        void updateProgramInfo(int _ID, string _ProgramID, string _ProgramName, string _RequestURL, string _ClassID,string _OrderID,
            string _Locked, DateTime _mDate);
        void deleteProgramInfo(int id);
        void cancelProgramInfo(ArrayList idlist);
    }
}
