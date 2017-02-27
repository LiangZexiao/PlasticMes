using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;

namespace Admin.IDAL.Quality_IDAL
{
    public interface IQC_Table
    {
        IList<QC_Table_MDL> selectQC_Table(int id, string colname, string coltext);
        //IList<QC_Table_MDL> selectQC_Table(string OrderNo, string BeginDate, string EndDate);
        IList<QC_Table_MDL> existsQC_Table(string vDO_No);
        IList<QC_Table_MDL> existsQC_Table(string colname,string coltext);

        //void insertQC_Table(
        //     string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
        //     string vGoodQty, string vProductDate, string vProductDesc, string vWorker, string vUserID,
        //     string vtime, string vMemo);

        int ChangeQC_Table(int vID,
             string vWorkOrderNo, string vDispatchNo, string vTotalQty, string vMachineNo, string vMouldNo, string vProductNo,
             string vBadQty, string vProductDate, string vProductDesc, string vWorker, string vUserID,
             string vtime, string vMemo, string IU);
        void ChangeQC_Table2(int vID, string WorkOrderNo, string DispatchNo, string TotalQty, string MachineNo, string MouldNo, string ProductNo,
            string BadQty, string ProductDate, string ProductDesc, string Worker, string UserID,
            string time, string Memo, string IU, out int xid);

        void deleteQC_Table(int ID);
        void cancelQC_Table(ArrayList IDList);

        //void checkQC_Table(int vID, string vChecker, string flag);

        IList<QC_TableDetail_MDL> selectQC_TableDetail(int MasterID, int vID);
        int QC_TableDetail(int ID, int MasterID, string DispatchNo, string BadReasonID, int BadQty);
        void cancelQC_TableDetail(ArrayList IDList);
    }
}
