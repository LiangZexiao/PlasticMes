using System;
using System.Collections.Generic;
using System.Text;
using Admin.IDAL.Product_IDAL;
using Admin.Model.Product_MDL;
using System.Data.SqlClient;
using System.Data;
using Admin.DBUtility;
using System.Collections;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class AdjustMachine_DAL:IAdjustMachine
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        private const string SQL_SELECT = @"SELECT a.ID, WorkOrderNo, DispatchNo, MachineNo, MouldNo, ProductNo, 
                            TotalQty,case when StartDate is null then '' else  CONVERT(CHAR(19),StartDate,121) end StartDate,
                            case when EndDate is null then '' else CONVERT(CHAR(19),EndDate,121) end  EndDate,
                            ProductDesc, AdjustMan, Checker,CONVERT(CHAR(19),CheckDate,121) CheckDate, a.Remark
                            ,dbo.GetEmpNameByID(AdjustMan) EmployeeName_CN,
                            ModiHistoryContent,a.CardType,c.ReasonName 
                           FROM tblAdjustMachine a 
                           left join StopReason c on a.CardType=c.ReasonID 
                           WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO tblAdjustMachine(WorkOrderNo, DispatchNo, TotalQty,MachineNo, MouldNo, ProductNo, StartDate,EndDate,ProductDesc, AdjustMan, Checker, CheckDate, Remark,ModiHistoryContent,CardType) " +
                                          " VALUES(@WorkOrderNo, @DispatchNo, @TotalQty, @MachineNo, @MouldNo, @ProductNo, @StartDate,@EndDate, @ProductDesc, @AdjustMan, @Checker, @CheckDate, @Remark,@ModiHistoryContent,@CardType) ;";
        private const string SQL_UPDATE = @"UPDATE tblAdjustMachine SET WorkOrderNo=@WorkOrderNo, DispatchNo=@DispatchNo, TotalQty=@TotalQty,
                         MachineNo=@MachineNo, MouldNo=@MouldNo, ProductNo=@ProductNo, StartDate=@StartDate,EndDate=@EndDate,
                         ProductDesc=@ProductDesc, AdjustMan=@AdjustMan, Checker=@Checker, CheckDate=@CheckDate,
                         Remark=@Remark,ModiHistoryContent=@ModiHistoryContent,CardType=@CardType  WHERE ID=@ID ";

        public IList<AdjustMachine_MDL> selectAdjustMachine() { return null; }
        public IList<AdjustMachine_MDL> selectAdjustMachine(int id, string colname, string coltext,string begindate,string enddate)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND a.ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }
            if (begindate != "" && enddate != "")
            {
                sqlWhere.Append(string.Format("AND CONVERT(CHAR(16),StartDate,120) BETWEEN '{0}' AND '{1}' ", begindate, enddate));
                sqlParas = null;
            }

            return getListAdjustMachine(sqlWhere, sqlParas);
        }

        public IList<AdjustMachine_MDL> existsAdjustMachine(string ProductNo)
        {
            StringBuilder sqlWhere = new StringBuilder(" AND ProductNo=@ProductNo");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo) };

            return getListAdjustMachine(sqlWhere, sqlParas);
        }

        public IList<AdjustMachine_MDL> existsAdjustMachine(string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format(" AND {0}=@ProductNo", colname));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, coltext) };

            return getListAdjustMachine(sqlWhere, sqlParas);
        }

        private IList<AdjustMachine_MDL> getListAdjustMachine(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            IList<AdjustMachine_MDL> AdjustMachineList = new List<AdjustMachine_MDL>();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(sqlWhere).ToString(), sqlParas))
                {
                    while (sdr.Read())
                    {
                        AdjustMachine_MDL AdjustMachine = new AdjustMachine_MDL(sdr.GetInt32(0),
                            (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                            (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                            (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                            (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                            (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                            (sdr["TotalQty"] == DBNull.Value) ? "0" : sdr["TotalQty"].ToString(),
                            (sdr["StartDate"] == DBNull.Value) ? "" : (sdr["StartDate"].ToString() == "1900-01-01") ? "" : sdr["StartDate"].ToString(),
                            (sdr["EndDate"] == DBNull.Value) ? "" : (sdr["EndDate"].ToString() == "1900-01-01") ? "" : sdr["EndDate"].ToString(),
                            (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),
                            (sdr["AdjustMan"] == DBNull.Value) ? "" : sdr["AdjustMan"].ToString().Trim(),
                            (sdr["Checker"] == DBNull.Value) ? "" : sdr["Checker"].ToString().Trim(),
                            (sdr["CheckDate"] == DBNull.Value) ? "" : sdr["CheckDate"].ToString(),
                            (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                            (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString().Trim(),
                            (sdr["ModiHistoryContent"] == DBNull.Value) ? "" : sdr["ModiHistoryContent"].ToString().Trim(),
                            (sdr["CardType"] == DBNull.Value) ? "" : sdr["CardType"].ToString().Trim(),
                            (sdr["ReasonName"] == DBNull.Value) ? "" : sdr["ReasonName"].ToString().Trim()
                           );
                        AdjustMachineList.Add(AdjustMachine);
                    }
                }
                return AdjustMachineList;
            }
            catch
            {
                return AdjustMachineList;
            }
        }

        public int ChangeAdjustMachine(int vID, string WorkOrderNo, string DispatchNo, string TotalQty, string MachineNo,
                    string MouldNo, string ProductNo,string StartDate,string EndDate,
                    string ProductDesc, string AdjustMan, string UserID,
                    string time, string Remark, string ModiHistoryContent, string CardType, string IU)
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
                fsp.FormatInParam("@StartDate", SqlDbType.VarChar, StartDate),
                fsp.FormatInParam("@EndDate", SqlDbType.VarChar, EndDate),
                fsp.FormatInParam("@ProductDesc",SqlDbType.VarChar, ProductDesc),
                fsp.FormatInParam("@AdjustMan",SqlDbType.VarChar, AdjustMan),

                fsp.FormatInParam("@Checker", SqlDbType.VarChar, UserID),
                fsp.FormatInParam("@CheckDate", SqlDbType.VarChar, time),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, Remark),
                fsp.FormatInParam("@ModiHistoryContent",SqlDbType.VarChar, ModiHistoryContent),
                fsp.FormatInParam("@CardType",SqlDbType.VarChar, CardType),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
                return SqlHelper.ExecuteNonQuery(CommandType.Text, (IU == "INSERT") ? SQL_INSERT : SQL_UPDATE, sqlParas);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public void ChangeAdjustMachine(int vID, string WorkOrderNo, string DispatchNo, string TotalQty, string MachineNo,
                    string MouldNo, string ProductNo, string StartDate, string EndDate, string ProductDesc, string AdjustMan,
                    string UserID, string time, string Remark, string ModiHistoryContent, string CardType, string IU, out int xid)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@WorkOrderNo",SqlDbType.VarChar,WorkOrderNo),
                fsp.FormatInParam("@DispatchNo", SqlDbType.VarChar, DispatchNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),

                fsp.FormatInParam("@TotalQty", SqlDbType.VarChar, TotalQty),
                fsp.FormatInParam("@StartDate", SqlDbType.VarChar, StartDate),
                fsp.FormatInParam("@EndDate", SqlDbType.VarChar, EndDate),
                fsp.FormatInParam("@ProductDesc",SqlDbType.VarChar, ProductDesc),
                fsp.FormatInParam("@AdjustMan",SqlDbType.VarChar, AdjustMan),

                fsp.FormatInParam("@Checker", SqlDbType.VarChar, UserID),
                fsp.FormatInParam("@CheckDate", SqlDbType.VarChar, time),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, Remark),
                fsp.FormatInParam("@ModiHistoryContent",SqlDbType.VarChar, ModiHistoryContent),
                fsp.FormatInParam("@CardType",SqlDbType.VarChar, CardType),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
            xid = SqlHelper.ExecuteNonQuery2(CommandType.Text, (IU == "INSERT") ? SQL_INSERT : SQL_UPDATE, sqlParas);
        }

        public void deleteAdjustMachine(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE tblAdjustMachine WHERE ID=@ID ", sqlParas);
        }

        public void cancelAdjustMachine(ArrayList IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in IDList)
            {
                ExecBatch += string.Format("DELETE tblAdjustMachine WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
