using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Collect_MDL;

namespace Admin.IDAL.Collect_IDAL
{
    public interface IDataHistory
    {
        IList<DataHistory_MDL> selectDataHistory(int ID);
        IList<DataHistory_MDL> selectDataHistory(string colname, string coltext, int PageSize, int PageIndex, out int RowCount);
        IList<DataHistory_MDL> selectDataHistory(string colname, string coltext,string BeginDate,string EndDate, int PageSize, int PageIndex, out int RowCount);
        DataTable SelectProductNoFrDh(string bDate, string eDate);
        DataTable SelectMouldNoFrDh(string bDate, string eDate, string ProductNo);
        DataTable SelectMachineNoFrDh(string bDate, string eDate, string ProductNo, string MouldNo);
    }
}
