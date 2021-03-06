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
    public class AlarmInfo_DAL : IAlarmInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = @"SELECT DISTINCT a.ID, 
                                CASE AlarmSource WHEN '1' THEN '周期异常' WHEN '2' THEN '压力异常' 
                                WHEN '3' THEN '温度异常'     WHEN '4' THEN '停机异常' 
                                WHEN '5' THEN '维修提醒' WHEN '6' THEN '生产数量提醒' 
                                WHEN '7' THEN '物料提醒'    END AS AlarmSource, 
                                AlarmMachine, EmployeeName_CN, AlarmMemo, CASE AlarmStatus WHEN '0' THEN '未解除' ELSE '已解除' END AS AlarmStatus, 
                                CASE SendType WHEN '0' THEN '未发送' ELSE '已发送' END AS SendType, AlarmTotalTime, CreateDate, 
                            a.Remark,CASE ISNULL(IsReadFlag,0) WHEN '1' THEN '未查阅' ELSE '已查阅' END AS IsReadFlag
                            FROM AlarmInfo a LEFT JOIN Employee b ON a.DutyOn=b.EmployeeID WHERE 1=1 ";

        private const string SQL_SELECT2 = @"SELECT  AlarmMachine as 报警机器,AlarmMemo as 报警内容, CASE AlarmStatus WHEN '0' THEN '未解除' ELSE '已解除' END AS 报警状态, 
                                CASE SendType WHEN '0' THEN '未发送' ELSE '已发送' END AS 发送标记, CreateDate as 报警时间 
                              FROM AlarmInfo  WHERE 1=1 ";

        public IList<AlarmInfo_MDL> selectAlarmInfo(int id, string alarmsource, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = null;
            
            if (id != 0)
            {
                sqlCmd.Append(string.Format(" AND a.ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (alarmsource != "")
            {
                    sqlCmd.Append(string.Format(" AND AlarmSource=@AlarmSource"));
                    sqlParas = new SqlParameter[1] { fsp.FormatInParam("@AlarmSource", SqlDbType.Int, alarmsource) };
                
            }

            if (!string.IsNullOrEmpty(colname) && !string.IsNullOrEmpty(coltext))
            {
                sqlCmd.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }
            sqlCmd.Append(" ORDER BY IsReadFlag,CreateDate DESC");
            IList<AlarmInfo_MDL> AlarmInfolist = new List<AlarmInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    AlarmInfo_MDL AlarmInfo = new AlarmInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr["AlarmSource"] == DBNull.Value) ? "" : sdr["AlarmSource"].ToString().Trim(),
                        (sdr["AlarmMachine"] == DBNull.Value) ? "" : sdr["AlarmMachine"].ToString().Trim(),
                        (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString().Trim(),
                        (sdr["AlarmMemo"] == DBNull.Value) ? "" : sdr["AlarmMemo"].ToString().Trim(),
                        (sdr["AlarmStatus"] == DBNull.Value) ? "" : sdr["AlarmStatus"].ToString().Trim(),
                        (sdr["SendType"] == DBNull.Value) ? "" : sdr["SendType"].ToString().Trim(),
                        (sdr["AlarmTotalTime"] == DBNull.Value) ? "0 秒" : sdr["AlarmTotalTime"].ToString().Trim() + " 秒",
                        (sdr["CreateDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["CreateDate"].ToString().Trim()),
                        (sdr["Remark"] == DBNull.Value) ? string.Empty : sdr["Remark"].ToString().Trim(),
                        (sdr["IsReadFlag"] == DBNull.Value) ? string.Empty : sdr["IsReadFlag"].ToString().Trim()                        
                        );
                    AlarmInfolist.Add(AlarmInfo);
                }
            }
            return AlarmInfolist;
        }

        public  DataSet selectAlarmExcel(string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT2);
            SqlParameter[] sqlParas = null;
            DataSet ds = null;
         
            if (!string.IsNullOrEmpty(colname) && !string.IsNullOrEmpty(coltext))
            {
                sqlCmd.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }
            sqlCmd.Append(" ORDER BY IsReadFlag,CreateDate DESC");
            ds=SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.ToString(), sqlParas);
            return ds;
        }

        public IList<AlarmInfo_MDL> selectAlarmInfo()
        {
            StringBuilder sqlCmd = new StringBuilder(@"SELECT DISTINCT a.AlarmSource AlarmSourceID,CASE a.AlarmSource 
                           WHEN '1' THEN '周期异常' WHEN '2' THEN '压力异常' 
                                WHEN '3' THEN '温度异常'     WHEN '4' THEN '停机异常' 
                                WHEN '5' THEN '维修提醒' WHEN '6' THEN '生产数量提醒' 
                                WHEN '7' THEN '物料提醒' END AS AlarmSource,ISNULL(NewsCnt,0) NewsCnt 
                            FROM AlarmInfo a LEFT JOIN 
                            (
                            SELECT DISTINCT AlarmSource,
                            COUNT(*) NewsCnt FROM AlarmInfo 
                            WHERE IsReadFlag='1' GROUP BY AlarmSource
                            ) b ON a.AlarmSource=b.AlarmSource");
            SqlParameter[] sqlParas = null;

            IList<AlarmInfo_MDL> AlarmInfolist = new List<AlarmInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    AlarmInfo_MDL AlarmInfo = new AlarmInfo_MDL(
                        (sdr["AlarmSource"] == DBNull.Value) ? "1" : sdr["AlarmSource"].ToString().Trim(),
                        (sdr["NewsCnt"] == DBNull.Value) ? "0" : sdr["NewsCnt"].ToString().Trim()
                        );
                    AlarmInfolist.Add(AlarmInfo);
                }
            }
            return AlarmInfolist;
        }

        public void updateAlarmInfo(int vID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, vID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE AlarmInfo SET IsReadFlag=0 WHERE ID=@ID", sqlParas);
        }
    }
}
