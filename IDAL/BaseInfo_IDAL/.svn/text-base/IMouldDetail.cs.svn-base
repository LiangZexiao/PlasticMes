using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IMouldDetail
    {
        IList<MouldDetail_MDL> selectMouldDetail();
        IList<MouldDetail_MDL> selectMouldDetail(int id, string vcolname, string vcoltext);
        IList<MouldDetail_MDL> existsMouldDetail(string Mould_Code);
        void updateMouldDetail(MouldDetail_MDL obj, string IU);
        void deleteMouldDetail(int _ID);
        void cancelMouldDetail(ArrayList _IDList);
    }
}
