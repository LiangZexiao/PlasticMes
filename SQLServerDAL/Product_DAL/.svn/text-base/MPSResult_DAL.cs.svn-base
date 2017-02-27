using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.Product_MDL;
using Admin.IDAL.Product_IDAL;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class MPSResult_DAL : IMPSResult
    {
        SQLPreparer objDataAction = new SQLPreparer();
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();

        private const string SQL_SELECT = "SELECT a.ID, a.MPSNo, a.WorkOrderNo, a.ProductNo, a.MachineNo, a.MouldNo, a.Num, "+
"CONVERT(CHAR(10),a.DueDate,121) DueDate, CONVERT(CHAR(10),a.SchStartDate,121) SchStartDate, CONVERT(CHAR(10),a.SchEndDate,121) SchEndDate, "+
 "a.Status, a.RearrangeFlag  AS RearrangeFlag, a.ErrMsg,CONVERT(CHAR(10),"+
"a.CreateDate,121) CreateDate, a.Checker, a.Creater,isnull(DeliveryQty,0) as DeliveryQty"+
" FROM MPSResult as a left join "+
"(select sum(isnull(DeliveryQty,0)) as DeliveryQty,masterid from MPSResultDetail where 1=1 group by masterid )"+
"as b on  a.id= b.masterid  where 1=1 ";
        
        private const string SQL_SELECT_SINGLE = "SELECT ID, MPSNo, WorkOrderNo, ProductNo, MachineNo, MouldNo, Num, " +
                "CONVERT(CHAR(10),DueDate,121) DueDate, CONVERT(CHAR(10),SchStartDate,121) SchStartDate, CONVERT(CHAR(10),SchEndDate,121) SchEndDate, " +
                 "CASE Status WHEN '1' THEN '1' ELSE '0' END AS Status, CASE RearrangeFlag WHEN '1' THEN '1' ELSE '0' END AS RearrangeFlag, ErrMsg,CONVERT(CHAR(10),CreateDate,121) CreateDate, Checker, Creater,isnull(DeliveryQty,0) as DeliveryQty "+
            "  FROM MPSResult as a left join (select sum(isnull(DeliveryQty,0)) as DeliveryQty,masterid from MPSResultDetail where 1=1 group by masterid ) as b on  a.id= b.masterid where 1=1 ";

        private const string SQL_INSERT = "INSERT INTO MPSResult(MPSNo, WorkOrderNo, ProductNo, MachineNo, MouldNo, Num, SchStartDate, SchEndDate, Status, RearrangeFlag, ErrMsg, CreateDate, Checker, Creater) " +
                 "VALUES(@MPSNo, @WorkOrderNo, @ProductNo, @MachineNo, @MouldNo, @Num, @SchStartDate, @SchEndDate, @Status, @RearrangeFlag, @ErrMsg, @CreateDate, @Checker, @Creater) ;SELECT   @a=@@IDENTITY;";
        private const string SQL_INSERT2 = "INSERT INTO MPSResult(MPSNo, WorkOrderNo, ProductNo, MachineNo, MouldNo, Num, SchStartDate, SchEndDate, Status, RearrangeFlag, ErrMsg, CreateDate, Checker, Creater) " +
                "VALUES(@MPSNo, @WorkOrderNo, @ProductNo, @MachineNo, @MouldNo, @Num, @SchStartDate, @SchEndDate, @Status, @RearrangeFlag, @ErrMsg, @CreateDate, @Checker, @Creater)  ";

        private const string SQL_UPDATE = "UPDATE MPSResult SET MPSNo=@MPSNo, WorkOrderNo=@WorkOrderNo, ProductNo=@ProductNo, MachineNo=@MachineNo, MouldNo=@MouldNo, Num=@Num, SchStartDate=@SchStartDate, SchEndDate=@SchEndDate, Status=@Status, RearrangeFlag=@RearrangeFlag, ErrMsg=@ErrMsg, CreateDate=@CreateDate, Checker=@Checker, Creater=@Creater WHERE ID=@ID";
        private const string SQL_DELETE = "DELETE MPSResult WHERE ID=@ID";

        public IList<MPSResult_MDL> selectMPSResult(){ return null; }
        public IList<MPSResult_MDL> selectMPSResult(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlCmd = new StringBuilder(SQL_SELECT_SINGLE);
                sqlCmd.Append(string.Format(" AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {                
                sqlCmd.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            return getDataListOfMPSResult(sqlCmd, sqlParas);
        }

        public IList<MPSResult_MDL> existsMPSResult(string MPSNo)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT_SINGLE);
            SqlParameter[] sqlParas = { fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, MPSNo) };
            sqlCmd.Append(string.Format(" AND WorkOrderNo=@WorkOrderNo", MPSNo));

            return getDataListOfMPSResult(sqlCmd, sqlParas);
        }

        private IList<MPSResult_MDL> getDataListOfMPSResult(StringBuilder sqlCmd, SqlParameter[] sqlParas)
        {
            IList<MPSResult_MDL> MPSResultList = new List<MPSResult_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MPSResult_MDL dboMPSResult = new MPSResult_MDL(
                        sdr.GetInt32(0),
                        (sdr["MPSNo"] == DBNull.Value) ? "" : sdr["MPSNo"].ToString().Trim(),
                        (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                        (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                        (sdr["Num"] == DBNull.Value) ? "0" : sdr["Num"].ToString().Trim(),
                        (sdr["DueDate"] == DBNull.Value) ? "" : sdr["DueDate"].ToString().Trim(),
                        (sdr["SchStartDate"] == DBNull.Value) ? "" : sdr["SchStartDate"].ToString().Trim(),
                        (sdr["SchEndDate"] == DBNull.Value) ? "" : sdr["SchEndDate"].ToString().Trim(),
                        (sdr["Status"] == DBNull.Value) ? "" : sdr["Status"].ToString().Trim(),

                        (sdr["RearrangeFlag"] == DBNull.Value) ? "" : sdr["RearrangeFlag"].ToString().Trim(),
                        (sdr["ErrMsg"] == DBNull.Value) ? "" : sdr["ErrMsg"].ToString().Trim(),
                        (sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString().Trim(),
                        (sdr["Checker"] == DBNull.Value) ? "" : sdr["Checker"].ToString().Trim(),
                        (sdr["Creater"] == DBNull.Value) ? "" : sdr["Creater"].ToString().Trim(),
                        (sdr["DeliveryQty"] == DBNull.Value) ? "" : sdr["DeliveryQty"].ToString().Trim()
                        );
                    MPSResultList.Add(dboMPSResult);
                }
            }
            return MPSResultList;
        }

        public void ChangeMPSResult(int vID, string MPSNo, string WorkOrderNo, string ProductNo, string MachineNo, string MouldNo,
             string Num, DateTime SchStartDate, DateTime SchEndDate, string Status,
             string RearrangeFlag, string ErrMsg, DateTime CreateDate, string Checker, string Creater, string IU)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@MPSNo", SqlDbType.VarChar, MPSNo),
                fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, WorkOrderNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),

                fsp.FormatInParam("@Num", SqlDbType.VarChar, Num),
                fsp.FormatInParam("@SchStartDate", SqlDbType.DateTime, SchStartDate),
                fsp.FormatInParam("@SchEndDate", SqlDbType.DateTime, SchEndDate),
                fsp.FormatInParam("@Status", SqlDbType.VarChar, Status),

                fsp.FormatInParam("@RearrangeFlag", SqlDbType.VarChar, RearrangeFlag),
                fsp.FormatInParam("@ErrMsg", SqlDbType.VarChar, ErrMsg),
                fsp.FormatInParam("@CreateDate", SqlDbType.VarChar, CreateDate),
                fsp.FormatInParam("@Checker", SqlDbType.VarChar, Checker),
                fsp.FormatInParam("@Creater", SqlDbType.VarChar, Creater),

                fsp.FormatInParam("@ID", SqlDbType.Int, vID)
            };
            if(IU == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT2, sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }
        public void ChangeMPSResult(int vID, string MPSNo, string WorkOrderNo, string ProductNo, string MachineNo, string MouldNo,
            string Num, DateTime SchStartDate, DateTime SchEndDate, string Status,
            string RearrangeFlag, string ErrMsg, DateTime CreateDate, string Checker, string Creater, string IU,out int xid)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@MPSNo", SqlDbType.VarChar, MPSNo),
                fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, WorkOrderNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),

                fsp.FormatInParam("@Num", SqlDbType.VarChar, Num),
                fsp.FormatInParam("@SchStartDate", SqlDbType.DateTime, SchStartDate),
                fsp.FormatInParam("@SchEndDate", SqlDbType.DateTime, SchEndDate),
                fsp.FormatInParam("@Status", SqlDbType.VarChar, "1"),

                fsp.FormatInParam("@RearrangeFlag", SqlDbType.VarChar, RearrangeFlag),
                fsp.FormatInParam("@ErrMsg", SqlDbType.VarChar, ErrMsg),
                fsp.FormatInParam("@CreateDate", SqlDbType.VarChar, CreateDate),
                fsp.FormatInParam("@Checker", SqlDbType.VarChar, Checker),
                fsp.FormatInParam("@Creater", SqlDbType.VarChar, Creater),

                fsp.FormatInParam("@ID", SqlDbType.Int, vID)
            };
            if (IU == "INSERT")
            {
                xid = SqlHelper.ExecuteNonQuery2(CommandType.Text, SQL_INSERT, sqlParas);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
                xid = -1;
            }

        }

        public void cancelMPSResult(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
            {
                ExecBatch += string.Format("DELETE MPSResult WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
                ExecBatch += string.Format("DELETE MPSResultDetail WHERE MasterID={0} IF(@@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
        //********************************
        //以下是处理排产的明细资料
        //********************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MasterID"></param>
        /// <param name="vID"></param>
        /// <returns></returns>
        public IList<MPSResultDetail_MDL> selectMPSResultDetail(int MasterID, int vID)
        {
            string sql = @"SELECT ID, MasterID, WorkOrderNo, CONVERT(CHAR(10),DeliveryDate,121) DeliveryDate, DeliveryQty FROM MPSResultDetail WHERE 1=1 AND MasterID='" + MasterID.ToString().Trim() + "'";
            StringBuilder sqlCmd = new StringBuilder(sql);
            SqlParameter[] sqlParas = null;
            if (vID != 0)
            {
                sqlCmd.Append(string.Format(" AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, vID) };
            }
            sqlCmd.Append(" ORDER BY DeliveryDate");
            
            IList<MPSResultDetail_MDL> MPSResultDetailList = new List<MPSResultDetail_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MPSResultDetail_MDL dboMPSResultDetail = new MPSResultDetail_MDL(sdr.GetInt32(0),
                        (sdr["MasterID"] == DBNull.Value) ? "" : sdr["MasterID"].ToString(),
                        (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                        (sdr["DeliveryDate"] == DBNull.Value) ? "" : sdr["DeliveryDate"].ToString(),
                        (sdr["DeliveryQty"] == DBNull.Value) ? "0" : sdr["DeliveryQty"].ToString()
                        );
                    MPSResultDetailList.Add(dboMPSResultDetail);
                }
            }
            return MPSResultDetailList;
        }

        public int MPSResultDetail(int vID, int vMasterID, string vWorkOrderNo, string vDeliveryDate, string vDeliveryQty)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatOutParam("@returnVal", SqlDbType.Int),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID),
                fsp.FormatInParam("@MasterID",SqlDbType.VarChar,vMasterID),
                fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, vWorkOrderNo),
                fsp.FormatInParam("@DeliveryDate", SqlDbType.VarChar, vDeliveryDate),
                fsp.FormatInParam("@DeliveryQty", SqlDbType.VarChar, vDeliveryQty)                
            };
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "dtl_MPSResultDetail", sqlParas);
            return int.Parse(sqlParas[0].Value.ToString());
        }

        public void cancelMPSResultDetail(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE MPSResultDetail WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
