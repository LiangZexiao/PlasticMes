using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;
using Admin.IDAL.Monitor_IDAL;

namespace Admin.BLL.Monitor_BLL
{
    public class MonitorDispatchMstr_BLL
    {
        private static readonly IMonitorDispatchMstr factory = Admin.DALFactory.DataAccess.selectMonitorDispatchMstr();
        public static IList<MonitorDispatchMstr_MDL> selectMonitorDispatchMstr(string colname, string coltext)
        {
            return factory.selectMonitorDispatchMstr(colname, coltext);
        }
        public static IList<MonitorDispatchMstr_MDL> selectMonitorDispatchMstr(string colname, string coltext,string DispatchStatus, int PageSize, int PageIndex, out int RowCount)
        {
            return factory.selectMonitorDispatchMstr(colname, coltext,DispatchStatus, PageSize, PageIndex, out RowCount);
        }

        public static IList<MonitorDispatchDtil_MDL> selectMonitorDispatchDtil(int vID)
        {
            return factory.selectMonitorDispatchDtil(vID);
        }
    }
}
