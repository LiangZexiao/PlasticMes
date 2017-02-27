using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface IUserProgramMap
    {
        IList<UserProgramMap_MDL> selectUserProgramMap();
        IList<UserProgramMap_MDL> selectUserProgramMap(int id);
        IList<UserProgramMap_MDL> selectUserProgramMap(int id, string colname, string coltext);
        IList<UserProgramMap_MDL> existsUserProgramMap(string _UserID, string _ProgramID);
        //void insertUserProgramMap(string _UserID, string _ProgramID, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag, DateTime _aDate, DateTime _mDate);
        int ChangeUserProgramMap(UserProgramMap_MDL obj, string IU);
        void deleteUserProgramMap(int id);
        void cancelUserProgramMap(ArrayList idlist);
    }
}
