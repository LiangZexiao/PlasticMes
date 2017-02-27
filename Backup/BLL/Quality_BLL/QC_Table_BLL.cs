using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;
using Admin.IDAL.Quality_IDAL;

namespace Admin.BLL.Quality_BLL
{
    public class QC_Table_BLL
    {
        private static readonly IQC_Table factory = Admin.DALFactory.DataAccess.selectQCTable();
        public static IList<QC_Table_MDL> selectQC_Table(int _ID, string colname, string coltext)
        {
            return factory.selectQC_Table(_ID, colname, coltext);
        }
        public static IList<QC_Table_MDL> existsQC_Table(string vDO_No)
        {
            return factory.existsQC_Table(vDO_No);
        }
        public static IList<QC_Table_MDL> existsQC_Table(string colname, string coltext)
        {
            return factory.existsQC_Table(colname, coltext);
        }

        public static int ChangeQC_Table(int vID,
             string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
             string vBadQty, string vProductDate, string vProductDesc, string vWorker, string vUserID,
             string vtime, string vMemo, string IU)
        {
           return factory.ChangeQC_Table(vID,
             vWorkOrderNo, vDispatchNo, vTotalQty, vMachineNo, vMouldNo, vProductNo,
             vBadQty, vProductDate, vProductDesc, vWorker, vUserID,
             vtime, vMemo, IU);
        }
        public static void ChangeQC_Table2(int vID,
             string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
             string vBadQty, string vProductDate, string vProductDesc, string vWorker, string vUserID,
             string vtime, string vMemo, string IU, out int xid)
        {
            factory.ChangeQC_Table2(vID,
             vWorkOrderNo, vDispatchNo, vTotalQty, vMachineNo, vMouldNo, vProductNo,
             vBadQty, vProductDate, vProductDesc, vWorker, vUserID,
             vtime, vMemo, IU, out xid);
        }

        public static void deleteQC_Table(int _id)
        {
            factory.deleteQC_Table(_id);
        }

        public static void cancelQC_Table(ArrayList _idlist)
        {
            factory.cancelQC_Table(_idlist);
        }

        public static IList<QC_TableDetail_MDL> selectQC_TableDetail(int MasterID, int vID)
        {
            return factory.selectQC_TableDetail(MasterID, vID);
        }

        public static int QC_TableDetail(int ID, int MasterID, string DispatchNo, string BadReasonID, int BadQty)
        {
            return factory.QC_TableDetail(ID, MasterID, DispatchNo, BadReasonID, BadQty);
        }

        public static void cancelQC_TableDetail(ArrayList _idlist)
        {
            factory.cancelQC_TableDetail(_idlist);
        }

    }
}
