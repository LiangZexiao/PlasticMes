using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;
using Admin.SQLServerDAL.Monitor_DAL;

namespace Admin.BLL.Monitor_BLL
{
    public class UseMaterial_BLL
    {
        UseMaterial_DAL dal = new UseMaterial_DAL();
        public DataTable select_Stand_NUM(string OrderNo)
        {
            return dal.select_Stand_NUM(OrderNo);
        }

        public DataTable select_Lived_NUM(string OrderNo, string ProdNO, string BeginDate, string EndDate)
        {
            return dal.select_Lived_NUM(OrderNo, ProdNO, BeginDate, EndDate);
        }

        /// <summary>
        /// 物料监控
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <param name="WorkOrderNo"></param>
        /// <param name="ProductNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataTable selectMonitorMaterialNum(string MachineNo, string MouldNo, string WorkOrderNo, string ProductNo, string BeginDate, string EndDate, string colname, string coltext)
        {
            return dal.selectMonitorMaterialNum(MachineNo, MouldNo, WorkOrderNo, ProductNo, BeginDate, EndDate, colname, coltext);
        }
    }
}
