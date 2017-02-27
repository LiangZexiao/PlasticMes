using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Collect_MDL;
using Admin.IDAL.Collect_IDAL;

namespace Admin.BLL.Collect_BLL
{
    public class ErrDataInfo_BLL
    {
        private static readonly IErrDataInfo factory = Admin.DALFactory.DataAccess.selectErrDataInfo();
        public static IList<ErrDataInfo_MDL> selectErrDataInfo(int _ID, string colname, string coltext)
        {
            return factory.selectErrDataInfo(_ID, colname, coltext);
        }

        public static void ChangeErrDataInfo(string vMachineNo, string vMouldNo, string vDispatchNo, string vWorkOrderNo, string vOriginalData,
               string vModifyData, string vUploadDate, string vModifyFlag, string vInputFlag, string vOperator,
               string vOperatorDate,  int vID, string IU)
        {
            factory.ChangeErrDataInfo(vMachineNo, vMouldNo, vDispatchNo, vWorkOrderNo, vOriginalData,
               vModifyData, vUploadDate, vModifyFlag, vInputFlag, vOperator,
               vOperatorDate, vID, IU);
        }

        public static void cancelErrDataInfo(ArrayList _idlist)
        {
            factory.cancelErrDataInfo(_idlist);
        }
    }
}
