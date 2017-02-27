using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;

namespace Admin.IDAL.Quality_IDAL
{
    public interface IStandTechnicsParams
    {
        IList<StandTechnicsParams_MDL> selectStandTechnicsParams(int _ID, string colname, string coltext);
        void updateStandTechnicsParams(StandTechnicsParams_MDL obj, string IU);

        void deleteStandTechnicsParams(int _id);
        void cancelStandTechnicsParams(ArrayList _idlist);

    }
}
