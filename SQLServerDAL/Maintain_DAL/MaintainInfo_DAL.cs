﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.Maintain_MDL;
using Admin.IDAL.Maintain_IDAL;

namespace Admin.SQLServerDAL.Maintain_DAL
{
    public class MaintainInfo_DAL : IMaintainInfo
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();

        string TableName = "RepairDevice";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "RepairBillID", "RepareDate", "DeviceType", "DeviceTypeID", "DeviceNo", "RepairType", "RepairTypeID", "RepairContent", "BeginDate", "EndDate", "CompleteFlag", "Applier", "DutyMan"
                                  , "Checker", "Remark", "MessageFlag","RepairHour","MaxMouldNum" };
        string[] FieldName3 = { "RepairBillID", "RepareDate", "DeviceType", "DeviceNo", "RepairType", "RepairContent", "BeginDate",
                                  "EndDate", "CompleteFlag", "Applier", "DutyMan", "Checker", "Remark", "MessageFlag","RepairHour","MaxMouldNum" };

        public IList<MaintainInfo_MDL> selectMaintainInfo(int id, string colname, string coltext, string WebUIName)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            string sTableName = (WebUIName == "MaintainPlan") ? "View_RepairDevice_MaintainPlan" : "View_RepairDevice_MaintainInfo";

            string SQL_SELECT = fsc.GetSelectCmd(sTableName, SELECT);
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlCmd.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            IList<MaintainInfo_MDL> MaintainInfoList = new List<MaintainInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MaintainInfo_MDL MaintainInfo = new MaintainInfo_MDL(sdr.GetInt32(0),
                        (sdr["RepairBillID"] == DBNull.Value) ? "" : sdr["RepairBillID"].ToString(),
                        (sdr["RepareDate"] == DBNull.Value) ? "" : sdr["RepareDate"].ToString(),
                        (sdr["DeviceType"] == DBNull.Value) ? "" : sdr["DeviceType"].ToString(),
                        (sdr["DeviceTypeID"] == DBNull.Value) ? "" : sdr["DeviceTypeID"].ToString(),
                        (sdr["DeviceNo"] == DBNull.Value) ? "" : sdr["DeviceNo"].ToString(),
                        (sdr["RepairType"] == DBNull.Value) ? "" : sdr["RepairType"].ToString(),
                        (sdr["RepairTypeID"] == DBNull.Value) ? "" : sdr["RepairTypeID"].ToString(),
                        (sdr["RepairContent"] == DBNull.Value) ? "" : sdr["RepairContent"].ToString(),
                        (sdr["BeginDate"] == DBNull.Value) ? "0" : sdr["BeginDate"].ToString(),
                        (sdr["EndDate"] == DBNull.Value) ? "0" : sdr["EndDate"].ToString(),
                        (sdr["CompleteFlag"] == DBNull.Value) ? "" : sdr["CompleteFlag"].ToString(),
                        (sdr["Applier"] == DBNull.Value) ? "" : sdr["Applier"].ToString(),
                        (sdr["DutyMan"] == DBNull.Value) ? "" : sdr["DutyMan"].ToString(),
                        (sdr["Checker"] == DBNull.Value) ? "" : sdr["Checker"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["MessageFlag"] == DBNull.Value) ? "" : sdr["MessageFlag"].ToString(),
                        (sdr["RepairHour"] == DBNull.Value) ? 0: Convert.ToDecimal(sdr["RepairHour"].ToString()),
                        (sdr["MaxMouldNum"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["MaxMouldNum"].ToString())
                        );
                    MaintainInfoList.Add(MaintainInfo);
                }
            }
            return MaintainInfoList;
        }

        public IList<MaintainInfo_MDL> existsMaintainInfo(string vRepairBillID)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT * FROM RepairDevice WHERE 1=1 AND RepairBillID=@RepairBillID");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@RepairBillID", SqlDbType.VarChar, vRepairBillID) };

            IList<MaintainInfo_MDL> MaintainInfoList = new List<MaintainInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MaintainInfo_MDL MaintainInfo = new MaintainInfo_MDL((sdr["RepairBillID"] == DBNull.Value) ? "" : sdr["RepairBillID"].ToString());
                    MaintainInfoList.Add(MaintainInfo);
                }
            }
            return MaintainInfoList;
        }
        public IList<MaintainInfo_MDL> existsMaintainInfo(string vRepareDate, string vDeviceNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT  *  FROM RepairDevice WHERE 1=1 AND RepareDate='" + vRepareDate + "' and DeviceNo=@DeviceNo ");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DeviceNo", SqlDbType.VarChar, vDeviceNo) };

            IList<MaintainInfo_MDL> MaintainInfoList = new List<MaintainInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MaintainInfo_MDL MaintainInfo = new MaintainInfo_MDL((sdr["RepairBillID"] == DBNull.Value) ? "" : sdr["RepairBillID"].ToString());
                    MaintainInfoList.Add(MaintainInfo);
                }
            }
            return MaintainInfoList;
        }

        public void ChangeMaintainInfo(int vID,
            string vRepairBillID, string vRepareDate, string vDeviceType, string vDeviceNo, string vRepairType,
            string vRepairContent, string vBeginDate, string vEndDate, string vCompleteFlag, string vApplier,
            string vDutyMan, string vChecker, string vRemark, string vMessageFlag, decimal vRepairHour, int vMaxMouldNum, string IU
            )
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@RepairBillID", SqlDbType.VarChar, vRepairBillID),
                        fsp.FormatInParam("@RepareDate", SqlDbType.VarChar, vRepareDate),
                        fsp.FormatInParam("@DeviceType", SqlDbType.VarChar, vDeviceType),
                        fsp.FormatInParam("@DeviceNo", SqlDbType.VarChar, vDeviceNo),
                        fsp.FormatInParam("@RepairType", SqlDbType.VarChar, vRepairType),

                        fsp.FormatInParam("@RepairContent", SqlDbType.VarChar, vRepairContent),
                        fsp.FormatInParam("@BeginDate", SqlDbType.VarChar, vBeginDate),
                        fsp.FormatInParam("@EndDate", SqlDbType.VarChar, vEndDate),
                        fsp.FormatInParam("@CompleteFlag", SqlDbType.VarChar, vCompleteFlag),
                        fsp.FormatInParam("@Applier", SqlDbType.VarChar, vApplier),

                        fsp.FormatInParam("@DutyMan", SqlDbType.VarChar, vDutyMan),
                        fsp.FormatInParam("@Checker", SqlDbType.VarChar, vChecker),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar, vRemark),
                        fsp.FormatInParam("@MessageFlag",SqlDbType.VarChar,vMessageFlag),
                        fsp.FormatInParam("@RepairHour",SqlDbType.VarChar,vRepairHour),
                        fsp.FormatInParam("@MaxMouldNum",SqlDbType.VarChar,vMaxMouldNum),
                        fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
            string[] SELECT = new string[FieldName3.Length];
            System.Array.Copy(FieldName3, 0, SELECT, 0, FieldName3.Length);

            if (IU == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, SELECT), sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, SELECT), sqlParas);
        }

        public void cancelMaintainInfo(ArrayList vIDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in vIDList)
                 ExecBatch += string.Format("DELETE RepairDevice WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        /// <summary>
        /// add by fsq 2010.07.04
        /// </summary>
        /// <returns></returns>
        public int DeleteMainInfo(string types)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format(@"DELETE RepairDevice where repairBillID like 'A%' and DeviceType='{0}' 
                        IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", types);

            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}