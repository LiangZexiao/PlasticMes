using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Collect_MDL;

namespace Admin.IDAL.Collect_IDAL
{
    public interface IErrDataInfo
    {
        IList<ErrDataInfo_MDL> selectErrDataInfo(int _ID, string colname, string coltext);
        void ChangeErrDataInfo(string vMachineNo, string vMouldNo, string vDispatchNo, string vWorkOrderNo, string vOriginalData,
               string vModifyData, string vUploadDate, string vModifyFlag, string vInputFlag, string vOperator,
               string vOperatorDate, int vID, string IU);

        void cancelErrDataInfo(ArrayList _IDList);
    }
}
