﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;
using Admin.IDAL.Monitor_IDAL;

namespace Admin.BLL.Monitor_BLL
{
    public class MonitorMaterial_BLL
    {
        private static readonly IMonitorMaterial factory = Admin.DALFactory.DataAccess.selectMonitorMaterial();

        public static IList<MonitorMaterial_MDL> selectMonitorMaterial(string colname, string coltext)
        {
            return factory.selectMonitorMaterial(colname, coltext);
        }
        public static IList<MonitorMaterial_MDL> selectMonitorMaterial(string colname, string coltext, string DispatchStatus, int PageSize, int PageIndex, out int RowCount)
        {
            return factory.selectMonitorMaterial(colname, coltext, DispatchStatus, PageSize, PageIndex, out RowCount);
        }

        public static DataTable selectMaterial(string colname, string coltext, string beginCycle, string endCycle)
        {
            return factory.selectMaterial(colname, coltext, beginCycle, endCycle);
        }
    }
}
