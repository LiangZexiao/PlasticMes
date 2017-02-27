using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using Admin.IDAL.Monitor_IDAL;
using Admin.Model.Monitor_MDL;

namespace Admin.SQLServerDAL.Monitor_DAL
{
    public class MonitorMachine_DAL : IMonitorMachine
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();
        const string SQL_SELECT = @"select top 1 dispatchno,devicestatus,clientip,ReasonName,LastUpdateDate from dbo.DeviceRealStatus " +
                                  "  left join StopReason st on st.ReasonID=devicestatus " +
                                   " where 1=1 ";
        const string SQL_SELECT2 = @"SELECT top 1  c.MachineNo,c.MouldNo,DM.GoodSocketNum,c.WorkOrderNo,c.do_no,DispatchNum,d.MaterialCode,c.productNo productNo,c.ProductDesc,Item_WaterGapScale,ISNULL(CycleTime,0.00) AS LiveCycle," +
                     " ISNULL(c.StandCycle,0.00) AS StandardCycle,dbo.GetProdNum(do_no,'','') as productNum ,dbo.GetBadNum(do_no,'','') as badnum " +
                     " from DispatchOrder c " +
                     " left join datahistorymain ma on ma.dispatchorder=c.do_no" +
                     " LEFT JOIN ItemMstr d ON c.ProductNo=d.Item_Code		" +
                     " LEFT JOIN MouldDetail DM ON DM.Mould_Code=c.mouldno  where 1=1 ";
        const string SQL_SELECT3 = @"SELECT top 1  c.MachineNo,c.MouldNo,c.WorkOrderNo,c.do_no,DispatchNum,  " +
                    " c.productNo productNo,c.ProductDesc,dbo.GetProdNum(do_no,'','') as productNum ," +
                    " dbo.GetBadNum(do_no,'','') as badnum " +
                    " from DispatchOrder c where 1=1  ";

        string selectSMS = @"select ID,CellNumber,SMSContent from SMSDetail 
                             where CONVERT(varchar(10),CreateTime,120)=CONVERT(varchar(10),getdate(),120) and Status=0";

        public IList<MonitorMachine_MDL> selectMonitorMachine(string DispatchOrder, string ClientIP)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (DispatchOrder != "")
                sqlWhere.Append(string.Format(" AND dispatchno='{0}' ", DispatchOrder));
            if (ClientIP != "")
                sqlWhere.Append(string.Format(" AND clientip  = '" + cmm.GetSafeSqlText(true, ClientIP) + "' "));
            //sqlWhere.Append(" order by LastUpdateDate desc");

            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT, sqlWhere));

            IList<MonitorMachine_MDL> MonitorMachinelist = new List<MonitorMachine_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append("  order by LastUpdateDate desc").ToString(), null))
            {
                while (sdr.Read())
                {
                    MonitorMachine_MDL MonitorMachine = new MonitorMachine_MDL(
                        (sdr["dispatchno"] == DBNull.Value) ? "" : sdr["dispatchno"].ToString().Trim(),
                        (sdr["clientip"] == DBNull.Value) ? "" : sdr["clientip"].ToString().Trim(),
                        (sdr["devicestatus"] == DBNull.Value) ? "" : sdr["devicestatus"].ToString().Trim(),
                        (sdr["ReasonName"] == DBNull.Value) ? "" : sdr["ReasonName"].ToString().Trim()
                       );
                    MonitorMachinelist.Add(MonitorMachine);
                }
            }
            return MonitorMachinelist;
        }

        public DataSet selectMonitorMachine(string DispatchOrder)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (DispatchOrder != "")
                sqlWhere.Append(string.Format(" AND do_no='{0}' ", DispatchOrder));

            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT2, sqlWhere));

            return SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.ToString(), null);

        }
        public DataSet selectNxtInjectionDO(string MachineNo)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (MachineNo != "")
                sqlWhere.Append(string.Format(" AND c.MachineNo='{0}' AND (c.DispatchStatus=6 OR c.DispatchStatus=5) ORDER BY StartDate asc", MachineNo));

            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT2, sqlWhere));

            return SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.ToString(), null);

        }

        public IList<MonitorMachine_MDL> selectMonitorMachine(string Machine_SeatCode, string MachineState, string MachineNo)
        {
            SqlParameter[] sqlParas = {
                                        fsp.FormatInParam("@inMachine_SeatCode", SqlDbType.VarChar, Machine_SeatCode),
                                        fsp.FormatInParam("@inMachineState", SqlDbType.VarChar, MachineState),
                                        fsp.FormatInParam("@iMachineNo", SqlDbType.VarChar, MachineNo)
                                    };
            IList<MonitorMachine_MDL> MonitorMachinelist = new List<MonitorMachine_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Monitor_Machine", sqlParas))
            {
                while (sdr.Read())
                {
                    MonitorMachine_MDL MonitorMachine = new MonitorMachine_MDL(
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["DeviceStatus"] == DBNull.Value) ? "" : sdr["DeviceStatus"].ToString().Trim(),
                        (sdr["Machine_SeatCode"] == DBNull.Value) ? "" : sdr["Machine_SeatCode"].ToString().Trim(),
                        (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                        (sdr["GoodQty"] == DBNull.Value) ? "0" : sdr["GoodQty"].ToString().Trim(),
                        (sdr["LiveCycle"] == DBNull.Value) ? "0.00" : sdr["LiveCycle"].ToString().Trim(),
                        (sdr["ClientIP"] == DBNull.Value) ? "" : sdr["ClientIP"].ToString().Trim(),
                        (sdr["BeginCycle"] == DBNull.Value) ? "" : sdr["BeginCycle"].ToString().Trim()
                       );
                    MonitorMachinelist.Add(MonitorMachine);
                }
            }
            return MonitorMachinelist;
        }

        public IList<MonitorMachine_MDL> selectMonitorPlantBristlesToolInfo(string Machine_SeatCode, string MachineState)
        {
            SqlParameter[] sqlParas = {
                                        fsp.FormatInParam("@inMachine_SeatCode", SqlDbType.VarChar, Machine_SeatCode),
                                        fsp.FormatInParam("@inMachineState", SqlDbType.VarChar, MachineState)
                                    };
            IList<MonitorMachine_MDL> MonitorMachinelist = new List<MonitorMachine_MDL>();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Monitor_PlantBristlesToolInfo", sqlParas))
                {
                    while (sdr.Read())
                    {
                        MonitorMachine_MDL MonitorMachine = new MonitorMachine_MDL(
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["DeviceStatus"] == DBNull.Value) ? "" : sdr["DeviceStatus"].ToString().Trim(),
                        (sdr["Machine_SeatCode"] == DBNull.Value) ? "" : sdr["Machine_SeatCode"].ToString().Trim(),
                        (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                        (sdr["GoodQty"] == DBNull.Value) ? "0" : sdr["GoodQty"].ToString().Trim(),
                        (sdr["LiveCycle"] == DBNull.Value) ? "0.00" : sdr["LiveCycle"].ToString().Trim(),
                        (sdr["ClientIP"] == DBNull.Value) ? "" : sdr["ClientIP"].ToString().Trim(),
                        (sdr["BeginCycle"] == DBNull.Value) ? "" : sdr["BeginCycle"].ToString().Trim()
                        );
                        MonitorMachinelist.Add(MonitorMachine);
                    }
                }
                return MonitorMachinelist;
            }
            catch (Exception ex)
            {
                string tem = ex.Message.ToString();
                return new List<MonitorMachine_MDL>();
            }
        }
        public DataSet selectMonitorPlantBristlesToolInfo(string DispatchOrder)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (DispatchOrder != "")
                sqlWhere.Append(string.Format(" AND do_no='{0}' ", DispatchOrder));

            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT3, sqlWhere));

            return SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.ToString(), null);

        }



        public void execStoredProcedure(string ProcedureName)
        {
            SqlHelper.execProcedure(ProcedureName);
        }


        public DataTable execSMSDetail()
        {
            return SqlHelper.execSMSDetail(selectSMS);
        }

        public int UpdateSMSDetailStatus(int id)
        {
            return SqlHelper.UpdateSMSDetailStatus(id);
        }
    }
}
