using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.BaseInfo_MDL;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IMouldMstr
    {
        IList<MouldMstr_MDL> selectMouldMstr(int _ID, string colname, string coltext);
        IList<MouldMstr_MDL> existsMouldMstr(string vMouldNo, string vProductNo);
        void ChangeMouldMstr(int ID, string vMouldNo, string vProductNo, int vGoodSocketNum, string vRemark, string IU);
        void cancelMouldMstr(ArrayList _IDList);
    }
}
