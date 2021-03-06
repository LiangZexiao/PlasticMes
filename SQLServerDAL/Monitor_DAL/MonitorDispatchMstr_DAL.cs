﻿using System;
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
    public class MonitorDispatchMstr_DAL : IMonitorDispatchMstr
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        public IList<MonitorDispatchMstr_MDL> selectMonitorDispatchMstr(string colname, string coltext)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, coltext),
                                        fsp.FormatInParam("@colname", SqlDbType.VarChar, colname)
            };

            IList<MonitorDispatchMstr_MDL> MonitorDispatchMstrlist = new List<MonitorDispatchMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Monitor_DispatchOrderMstr", sqlParas))
            {
                while (sdr.Read())
                {
                    MonitorDispatchMstr_MDL MonitorDispatchMstr = new MonitorDispatchMstr_MDL(
                        sdr.GetInt32(0),
                        (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                        (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                        (sdr["ProductRemark"] == DBNull.Value) ? "" : sdr["ProductRemark"].ToString().Trim(),
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                        (sdr["DispatchNum"] == DBNull.Value) ? "" : sdr["DispatchNum"].ToString().Trim(),
                        (sdr["ProductNum"] == DBNull.Value) ? "" : sdr["ProductNum"].ToString().Trim(),
                        (sdr["GoodQty"] == DBNull.Value) ? "0" : sdr["GoodQty"].ToString().Trim(),
                        (sdr["BadQty"] == DBNull.Value) ? "0" : sdr["BadQty"].ToString().Trim(),
                        (sdr["StartDate"] == DBNull.Value) ? "" : sdr["StartDate"].ToString().Trim(),
                        (sdr["StopDate"] == DBNull.Value) ? "" : sdr["StopDate"].ToString().Trim(),
                        (sdr["BeginTime"] == DBNull.Value) ? "" : sdr["BeginTime"].ToString().Trim(),
                        (sdr["NeedTime"] == DBNull.Value) ? "" : sdr["NeedTime"].ToString().Trim(),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim()
                        );
                    MonitorDispatchMstrlist.Add(MonitorDispatchMstr);
                }
            }
            return MonitorDispatchMstrlist;
        }
        public IList<MonitorDispatchMstr_MDL> selectMonitorDispatchMstr(string colname, string coltext,string DispatchStatus, int PageSize, int PageIndex, out int RowCount)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, coltext),
                                        fsp.FormatInParam("@colname", SqlDbType.VarChar, colname),            
                                        fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, DispatchStatus),
                                        fsp.FormatInParam("@PageSize", SqlDbType.Int, PageSize),
                                        fsp.FormatInParam("@PageIndex", SqlDbType.Int, PageIndex)};

            IList<MonitorDispatchMstr_MDL> MonitorDispatchMstrlist = new List<MonitorDispatchMstr_MDL>();
            DataSet sds = SqlHelper.ReturnDataSet(CommandType.StoredProcedure, "Monitor_DispatchOrderMstr", sqlParas);
            DataTable sdt = sds.Tables[0];
            if (PageIndex == 1)
            {
                RowCount = int.Parse(sds.Tables[1].Rows[0][0].ToString());
                //RowCount = sds.Tables[0].Rows.Count;
            }
            else
            {
                RowCount = 0;
            }
            if (sds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < sds.Tables[0].Rows.Count; i++)
                {
                    MonitorDispatchMstr_MDL MonitorDispatchMstr = new MonitorDispatchMstr_MDL(
                        int.Parse(sds.Tables[0].Rows[i]["ID"].ToString()),
                        (sds.Tables[0].Rows[i]["DispatchNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["DispatchNo"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["ProductNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["ProductNo"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["ProductRemark"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["ProductRemark"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["MouldNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["MouldNo"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["DispatchNum"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["DispatchNum"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["ProductNum"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["ProductNum"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["GoodQty"] == DBNull.Value) ? "0" : sds.Tables[0].Rows[i]["GoodQty"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["BadQty"] == DBNull.Value) ? "0" : sds.Tables[0].Rows[i]["BadQty"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["StartDate"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["StartDate"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["StopDate"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["StopDate"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["BeginTime"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["BeginTime"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["NeedTime"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["NeedTime"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["MachineNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["MachineNo"].ToString().Trim(),
                        (sds.Tables[0].Rows[i]["WorkOrderNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["WorkOrderNo"].ToString().Trim()
                        );
                    MonitorDispatchMstrlist.Add(MonitorDispatchMstr);
                }
            }
            return MonitorDispatchMstrlist;
        }

        public IList<MonitorDispatchDtil_MDL> selectMonitorDispatchDtil(int vID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, vID) };

            IList<MonitorDispatchDtil_MDL> MonitorDispatchMstrlist = new List<MonitorDispatchDtil_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Monitor_DispatchOrderDtil", sqlParas))
            {
                while (sdr.Read())
                {
                    MonitorDispatchDtil_MDL MonitorDispatchMstr = new MonitorDispatchDtil_MDL(
                        sdr.GetInt32(0),
                        (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                        (sdr["PlanDate"] == DBNull.Value) ? "" : sdr["PlanDate"].ToString().Trim(),
                        (sdr["PlanQty"] == DBNull.Value) ? "" : sdr["PlanQty"].ToString().Trim(),
                        (sdr["RealQty"] == DBNull.Value) ? "" : sdr["RealQty"].ToString().Trim(),
                        (sdr["DiffQty"] == DBNull.Value) ? "" : sdr["DiffQty"].ToString().Trim(),
                        (sdr["AddDiffQty"] == DBNull.Value) ? "" : sdr["AddDiffQty"].ToString().Trim(),
                        (sdr["CompleteRate"] == DBNull.Value) ? "" : sdr["CompleteRate"].ToString().Trim()
                        );
                    MonitorDispatchMstrlist.Add(MonitorDispatchMstr);
                }
            }
            return MonitorDispatchMstrlist;
        }

        
    }
}
