using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;

namespace Admin.IDAL.Product_IDAL
{
    public interface IMPSResult
    {
        IList<MPSResult_MDL> selectMPSResult();
        IList<MPSResult_MDL> selectMPSResult(int _ID, string colname, string coltext);
        IList<MPSResult_MDL> existsMPSResult(string MPSNo);

        void ChangeMPSResult(int ID,
           string MPSNo, string WONo, string ProductNo, string MachineNo, string MouldNo,
           string Num, DateTime SchStartDate, DateTime SchEndDate, string Status,
           string RearrangeFlag, string ErrMsg, DateTime CreateDate, string Checker, string Creater, string IU);
        void ChangeMPSResult(int ID,
           string MPSNo, string WONo, string ProductNo, string MachineNo, string MouldNo,
           string Num, DateTime SchStartDate, DateTime SchEndDate, string Status,
           string RearrangeFlag, string ErrMsg, DateTime CreateDate, string Checker, string Creater, string IU,out int xid);

        void cancelMPSResult(ArrayList _idlist);


        IList<MPSResultDetail_MDL> selectMPSResultDetail(int MasterID, int vID);
        int MPSResultDetail(int vDetailID, int vMasterID, string vWorkOrderNo, string vDeliveryDate, string vDeliveryQty);
        void cancelMPSResultDetail(ArrayList _idlist);
    }
}
