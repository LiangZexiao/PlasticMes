using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface IGroupProgramMap
    {
        IList<GroupProgramMap_MDL> selectGroupProgramMap();
        IList<GroupProgramMap_MDL> selectGroupProgramMap(int id);
        IList<GroupProgramMap_MDL> selectGroupProgramMap(int id, string colname, string coltext);
        IList<GroupProgramMap_MDL> existsGroupProgramMap(string _GroupID, string _ProgramID);
        int ChangeGroupProgramMap(GroupProgramMap_MDL obj, string IU);
        void deleteGroupProgramMap(int id);
        void cancelGroupProgramMap(ArrayList idlist);
    }
}
