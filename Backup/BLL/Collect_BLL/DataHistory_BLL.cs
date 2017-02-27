using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Collect_MDL;
using Admin.SQLServerDAL.Collect_DAL;
using Admin.IDAL.Collect_IDAL;

namespace Admin.BLL.Collect_BLL
{
    public class DataHistory_BLL
    {
        private static readonly IDataHistory factory = Admin.DALFactory.DataAccess.selectDataHistory();
        public static IList<DataHistory_MDL> selectDataHistory(int ID)
        {
            return factory.selectDataHistory(ID);
        }

        public static IList<DataHistory_MDL> selectDataHistory(string colname, string coltext, int PageSize, int PageIndex, out int RowCount)
        {
            return factory.selectDataHistory(colname, coltext, PageSize, PageIndex, out RowCount);
        } 
        public static IList<DataHistory_MDL> selectDataHistory(string colname, string coltext,string BeginDate,string EndDate, int PageSize, int PageIndex, out int RowCount)
        {
            return factory.selectDataHistory(colname, coltext,BeginDate,EndDate, PageSize, PageIndex, out RowCount);
        }

        /// <summary>
        /// 获取产品编号(20080402)
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable SelectProductNoFrDh(string bDate, string eDate)
        {
            return factory.SelectProductNoFrDh(bDate, eDate);
        }

        /// <summary>
        /// 获取模具编号(20080402)
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="ProductNo"></param>
        /// <returns></returns>
        public DataTable SelectMouldNoFrDh(string bDate, string eDate, string ProductNo)
        {
            return factory.SelectMouldNoFrDh(bDate, eDate, ProductNo);
        }

        /// <summary>
        /// 获取机器编号(20080402)
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="ProductNo"></param>
        /// <param name="MouldNo"></param>
        /// <returns></returns>
        public DataTable SelectMachineNoFrDh(string bDate, string eDate, string ProductNo, string MouldNo)
        {
            return factory.SelectMachineNoFrDh(bDate, eDate, ProductNo, MouldNo);
        }

        /// <summary>
        /// 获得机器编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMachineNoFromDataHistory(string bDate, string eDate)
        {
            DataHistory_DAL dal = new DataHistory_DAL();
            return dal.selectMachineNoFromDataHistory( bDate,  eDate);
        }

        /// <summary>
        /// 模具编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMouldNoFromDataHistory(string MachineNo)
        {
            DataHistory_DAL dal = new DataHistory_DAL();
            return dal.selectMouldNoFromDataHistory(MachineNo);
        }

        /// <summary>
        /// 获得产品编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectProductNoFromDataHistory(string MachineNo, string MouldNo)
        {
            DataHistory_DAL dal = new DataHistory_DAL();
            return dal.selectProductNoFromDataHistory(MachineNo, MouldNo);
        }

        /// <summary>
        /// 获得啤的序号
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <returns></returns>
        
        public DataTable selectActionNumFromDataHistory(string Dispatchorder,string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate)
        {
            DataHistory_DAL dal = new DataHistory_DAL();
            return dal.selectActionNumFromDataHistory(Dispatchorder,MachineNo, MouldNo, ProductNo, bDate, eDate);
        }

        /// <summary>
        /// 获得派工单号
        /// </summary>
        /// <returns></returns>
        public DataTable selectDispatchOrderFromDataHistory(string MachineNo, string ProductDate)
        {
            DataHistory_DAL dal = new DataHistory_DAL();
            return dal.selectDispatchOrderFromDataHistory(MachineNo, ProductDate);
        }
    }
}
