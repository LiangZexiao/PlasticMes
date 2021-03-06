﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.Model.Quality_MDL;
using Admin.Model;
using Admin.IDAL.Quality_IDAL;

namespace Admin.SQLServerDAL.Quality_DAL
{
    public class QC_Table_DAL : IQC_Table
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        private const string SQL_SELECT = @"SELECT ID, WorkOrderNo, DispatchNo, MachineNo, MouldNo, ProductNo, 
                            TotalQty, GoodQty, BadQty,CONVERT(CHAR(10),ProductDate,121) ProductDate, ProductDesc, Worker, Checker, 
                            CONVERT(CHAR(10),CheckDate,121) CheckDate, Memo FROM QC_Table WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO QC_Table(WorkOrderNo, DispatchNo, TotalQty, BadQty, MachineNo, MouldNo, ProductNo, ProductDate, ProductDesc, Worker, Checker, CheckDate, Memo) " +
                                          " VALUES(@WorkOrderNo, @DispatchNo, @TotalQty, @BadQty, @MachineNo, @MouldNo, @ProductNo, @ProductDate, @ProductDesc, @Worker, @Checker, @CheckDate, @Memo) ;SELECT   @a=@@IDENTITY;";
        private const string SQL_UPDATE = @"UPDATE QC_Table SET WorkOrderNo=@WorkOrderNo, DispatchNo=@DispatchNo, TotalQty=@TotalQty, MachineNo=@MachineNo, MouldNo=@MouldNo, 
            ProductNo=@ProductNo, ProductDate=@ProductDate,BadQty=@BadQty, ProductDesc=@ProductDesc, Worker=@Worker, Checker=@Checker, CheckDate=@CheckDate, Memo=@Memo WHERE ID=@ID ";

        public IList<QC_Table_MDL> selectQC_Table() { return null; }
        public IList<QC_Table_MDL> selectQC_Table(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            return getListQC_Table(sqlWhere, sqlParas);
        }

        public IList<QC_Table_MDL> existsQC_Table(string ProductNo)
        {
            StringBuilder sqlWhere = new StringBuilder(" AND ProductNo=@ProductNo");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo) };

            return getListQC_Table(sqlWhere, sqlParas);
        }
        public IList<QC_Table_MDL> existsQC_Table(string colname,string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format(" AND {0}=@ProductNo",colname));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, coltext) };

            return getListQC_Table(sqlWhere, sqlParas);
        }

        private IList<QC_Table_MDL> getListQC_Table(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            IList<QC_Table_MDL> QC_TableList = new List<QC_Table_MDL>();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(sqlWhere).ToString(), sqlParas))
                {
                    while (sdr.Read())
                    {
                        QC_Table_MDL QC_Table = new QC_Table_MDL(sdr.GetInt32(0),
                            (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                            (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                            (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                            (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                            (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                            (sdr["TotalQty"] == DBNull.Value) ? "0" : sdr["TotalQty"].ToString(),
                            (sdr["GoodQty"] == DBNull.Value) ? "0" : sdr["GoodQty"].ToString(),
                            (sdr["BadQty"] == DBNull.Value) ? "0" : sdr["BadQty"].ToString(),
                            (sdr["ProductDate"] == DBNull.Value) ? "" : (sdr["ProductDate"].ToString() == "1900-01-01") ? "" : sdr["ProductDate"].ToString(),
                            (sdr["ProductDesc"] == DBNull.Value) ? "0" : sdr["ProductDesc"].ToString().Trim(),
                            (sdr["Worker"] == DBNull.Value) ? "0" : sdr["Worker"].ToString().Trim(),

                            (sdr["Checker"] == DBNull.Value) ? "" : sdr["Checker"].ToString().Trim(),
                            (sdr["CheckDate"] == DBNull.Value) ? "" : sdr["CheckDate"].ToString(),
                            (sdr["Memo"] == DBNull.Value) ? "" : sdr["Memo"].ToString()
                           );
                        QC_TableList.Add(QC_Table);
                    }
                }
                return QC_TableList;
            }
            catch
            {
                return QC_TableList;
            }
        }

        public int ChangeQC_Table(int vID, string WorkOrderNo, string DispatchNo, string TotalQty, string MachineNo, string MouldNo, string ProductNo,
             string BadQty, string ProductDate, string ProductDesc, string Worker, string UserID,
             string time, string Memo, string IU)
        {
            try
            {
                SqlParameter[] sqlParas = {
                fsp.FormatInParam("@WorkOrderNo",SqlDbType.VarChar,WorkOrderNo),
                fsp.FormatInParam("@DispatchNo", SqlDbType.VarChar, DispatchNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),

                fsp.FormatInParam("@TotalQty", SqlDbType.VarChar, TotalQty),
                fsp.FormatInParam("@BadQty", SqlDbType.VarChar, BadQty),
                fsp.FormatInParam("@ProductDate", SqlDbType.VarChar, ProductDate),
                fsp.FormatInParam("@ProductDesc",SqlDbType.VarChar, ProductDesc),
                fsp.FormatInParam("@Worker",SqlDbType.VarChar, Worker),

                fsp.FormatInParam("@Checker", SqlDbType.VarChar, UserID),
                fsp.FormatInParam("@CheckDate", SqlDbType.VarChar, time),
                fsp.FormatInParam("@Memo",SqlDbType.VarChar, Memo),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
                return SqlHelper.ExecuteNonQuery(CommandType.Text, (IU == "INSERT") ? SQL_INSERT : SQL_UPDATE, sqlParas);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public void ChangeQC_Table2(int vID, string WorkOrderNo, string DispatchNo, string TotalQty, string MachineNo, string MouldNo, string ProductNo,
            string BadQty, string ProductDate, string ProductDesc, string Worker, string UserID,
            string time, string Memo, string IU, out int xid)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@WorkOrderNo",SqlDbType.VarChar,WorkOrderNo),
                fsp.FormatInParam("@DispatchNo", SqlDbType.VarChar, DispatchNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),

                fsp.FormatInParam("@TotalQty", SqlDbType.VarChar, TotalQty),
                fsp.FormatInParam("@BadQty", SqlDbType.VarChar, BadQty),
                fsp.FormatInParam("@ProductDate", SqlDbType.VarChar, ProductDate),
                fsp.FormatInParam("@ProductDesc",SqlDbType.VarChar, ProductDesc),
                fsp.FormatInParam("@Worker",SqlDbType.VarChar, Worker),

                fsp.FormatInParam("@Checker", SqlDbType.VarChar, UserID),
                fsp.FormatInParam("@CheckDate", SqlDbType.VarChar, time),
                fsp.FormatInParam("@Memo",SqlDbType.VarChar, Memo),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
            xid = SqlHelper.ExecuteNonQuery2(CommandType.Text, (IU == "INSERT") ? SQL_INSERT : SQL_UPDATE, sqlParas);


        }

        public void deleteQC_Table(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE QC_Table WHERE ID=@ID ", sqlParas);
        }

        public void cancelQC_Table(ArrayList IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in IDList)
            {
                ExecBatch += string.Format("DELETE QC_Table WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
                ExecBatch += string.Format("DELETE QC_TableDetail WHERE MasterID={0} ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }


        public IList<QC_TableDetail_MDL> selectQC_TableDetail(int MasterID, int vID)
        {
            string sql = @"SELECT a.ID, MasterID, DispatchNo, BadReasonID, IMReasonName,OMReasonName, BadQty FROM QC_TableDetail a LEFT JOIN BadReason ON BadReasonID=ReasonID WHERE 1=1  AND MasterID='" + MasterID.ToString() + "'";
            StringBuilder sqlCmd = new StringBuilder(sql);
            SqlParameter[] sqlParas = null;
            if (vID != 0)
            {
                sqlCmd.Append(string.Format(" AND a.ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, vID) };
            }

            IList<QC_TableDetail_MDL> QC_TableDetailList = new List<QC_TableDetail_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    QC_TableDetail_MDL QC_Table;
                    if (sdr["DispatchNo"].ToString().Substring(sdr["DispatchNo"].ToString().Length - 3, 1) == "0")
                    {
                        QC_Table =new QC_TableDetail_MDL(sdr.GetInt32(0),
                       (sdr["MasterID"] == DBNull.Value) ? "" : sdr["MasterID"].ToString(),
                       (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString(),
                       (sdr["BadReasonID"] == DBNull.Value) ? "" : sdr["BadReasonID"].ToString(),
                       (sdr["IMReasonName"] == DBNull.Value) ? "" : sdr["IMReasonName"].ToString(),
                       (sdr["BadQty"] == DBNull.Value) ? "0" : sdr["BadQty"].ToString()
                       );
                    }else
                    {
                        QC_Table = new QC_TableDetail_MDL(sdr.GetInt32(0),
                      (sdr["MasterID"] == DBNull.Value) ? "" : sdr["MasterID"].ToString(),
                      (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString(),
                      (sdr["BadReasonID"] == DBNull.Value) ? "" : sdr["BadReasonID"].ToString(),
                      (sdr["OMReasonName"] == DBNull.Value) ? "" : sdr["OMReasonName"].ToString(),
                      (sdr["BadQty"] == DBNull.Value) ? "0" : sdr["BadQty"].ToString()
                      );
                    }
                   
                    QC_TableDetailList.Add(QC_Table);
                }
            }
            return QC_TableDetailList;
        }

        public int QC_TableDetail(int vID, int vMasterID, string vDispatchNo, string vBadReasonID, int vBadQty)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatOutParam("@returnVal",SqlDbType.Int),
                fsp.FormatInParam("@MasterID",SqlDbType.Int,vMasterID),
                fsp.FormatInParam("@DispatchNo", SqlDbType.VarChar, vDispatchNo),
                fsp.FormatInParam("@BadReasonID", SqlDbType.VarChar, vBadReasonID),
                fsp.FormatInParam("@BadQty", SqlDbType.Int, vBadQty),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "dtl_QCTableDetail", sqlParas);
            return int.Parse(sqlParas[0].Value.ToString());
        }

        public void cancelQC_TableDetail(ArrayList _IDList)
        {
            string sql = "";
            SQLExecutant sc = new SQLExecutant();
            DataTable dt;
            int BadQty = 0;
            int MasterID = 0;
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
            {
                sql = string.Format("select BadQty,MasterID,BadReasonID from QC_TableDetail where ID={0} ", s);
                dt = sc.ExecQueryCmd(sql);
                MasterID = int.Parse(dt.Rows[0][1].ToString());
                BadQty += int.Parse(dt.Rows[0][0].ToString());
                ExecBatch += string.Format("DELETE QC_TableDetail WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += string.Format("UPDATE QC_Table SET BadQty=BadQty-{0} WHERE ID={1} ", BadQty, MasterID);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }


        //public void insertqc_table(int vID, string WorkOrderNo, string DispatchNo, string TotalQty, string MachineNo, string MouldNo, string ProductNo,
        //     string GoodQty, string ProductDate, string ProductDesc, string Worker, string UserID,
        //     string time, string Memo, int vMasterID,  string vBadReasonID, int vBadQty)
        //{

        //}
    }
}