using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.IDAL.Product_IDAL;

namespace Admin.BLL.Product_BLL
{
    public class MPSResult_BLL
    {
        private static readonly IMPSResult factory = Admin.DALFactory.DataAccess.selectMPSResult();
        public static IList<MPSResult_MDL> selectMPSResult()
        {
            return factory.selectMPSResult();
        }

        public static IList<MPSResult_MDL> selectMPSResult(int _ID, string colname, string coltext)
        {
            return factory.selectMPSResult(_ID, colname, coltext);
        }

        public static IList<MPSResult_MDL> existsMPSResult(string MPSNo)
        {
            return factory.existsMPSResult(MPSNo);
        }

        public static void ChangeMPSResult(int ID,
           string MPSNo,string WONo, string ProductNo, string MachineNo, string MouldNo,
           string Num, DateTime SchStartDate, DateTime SchEndDate, string Status,
           string RearrangeFlag, string ErrMsg, DateTime CreateDate, string Checker, string Creater, string IU)
        {
            factory.ChangeMPSResult(ID,
                MPSNo, WONo, ProductNo, MachineNo, MouldNo, Num, SchStartDate, SchEndDate, Status,
                RearrangeFlag, ErrMsg, CreateDate, Checker, Creater, IU);
        }

        public static void ChangeMPSResult(int ID,
          string MPSNo, string WONo, string ProductNo, string MachineNo, string MouldNo,
          string Num, DateTime SchStartDate, DateTime SchEndDate, string Status,
          string RearrangeFlag, string ErrMsg, DateTime CreateDate, string Checker, string Creater, string IU,out int xid)
        {
            factory.ChangeMPSResult(ID,
                MPSNo, WONo, ProductNo, MachineNo, MouldNo, Num, SchStartDate, SchEndDate, Status,
                RearrangeFlag, ErrMsg, CreateDate, Checker, Creater, IU,out xid);
        }

        public static void cancelMPSResult(ArrayList _idlist)
        {
            factory.cancelMPSResult(_idlist);
        }

        public static IList<MPSResultDetail_MDL> selectMPSResultDetail(int MasterID, int vID)
        {
            return factory.selectMPSResultDetail(MasterID, vID);
        }

        public static int MPSResultDetail(int vDetailID, int vMasterID, string vWorkOrderNo, string vDeliveryDate, string vDeliveryQty)
        {
            return factory.MPSResultDetail(vDetailID, vMasterID, vWorkOrderNo, vDeliveryDate, vDeliveryQty);
        }

        public static void cancelMPSResultDetail(ArrayList _idlist)
        {
            factory.cancelMPSResultDetail(_idlist);
        }
    }
}
