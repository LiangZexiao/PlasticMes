using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.BaseInfo_MDL;
using Admin.IDAL.BaseInfo_IDAL; 

namespace Admin.BLL.BaseInfo_BLL
{
    public class MouldMstr_BLL
    {
        private static readonly IMouldMstr factory = Admin.DALFactory.DataAccess.selectMouldMstr();
        public static IList<MouldMstr_MDL> selectMouldMstr(int _ID, string colname, string coltext)
        {
            return factory.selectMouldMstr(_ID, colname, coltext);
        }

        public static IList<MouldMstr_MDL> existsMouldMstr(string _MouldNo, string _ProductNo)
        {
            return factory.existsMouldMstr(_MouldNo, _ProductNo);
        }

        public static void ChangeMouldMstr(int vID, string vMouldNo, string vProductNo, int vGoodSocketNum, string vRemark, string IU)
        {
            factory.ChangeMouldMstr(vID, vMouldNo, vProductNo, vGoodSocketNum, vRemark, IU);
        }

        public static void cancelMouldMstr(ArrayList _idlist)
        {
            factory.cancelMouldMstr(_idlist);
        }

    }
}
