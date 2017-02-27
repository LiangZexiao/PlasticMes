using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Admin.DBUtility;
using Admin.Model;
using Admin.Model.Collect_MDL;
using Admin.IDAL.Collect_IDAL;

namespace Admin.SQLServerDAL.Collect_DAL
{
    public class ErrDataInfo_DAL : IErrDataInfo
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();

        const string SQL_SELECT = @"SELECT ID, MachineNo, MouldNo, DispatchNo, WorkOrderNo, OriginalData, ModifyData, UploadDate,
                            ModifyFlagID, ModifyFlag, InputFlagID, InputFlag, Operator, OperatorDate FROM View_ErrDataInfo WHERE 1=1 ";

        const string SQL_INSERT = @"INSERT INTO ErrDataInfo(MachineNo, MouldNo, DispatchNo, WorkOrderNo, 
                            OriginalData, ModifyData, UploadDate, ModifyFlag, InputFlag, Operator, OperatorDate) 
                                    VALUES(@MachineNo, @MouldNo, @DispatchNo, @WorkOrderNo, 
                            @OriginalData, @ModifyData, @UploadDate, @ModifyFlag, @InputFlag, @Operator, @OperatorDate)";

        const string SQL_UPDATE = @"UPDATE ErrDataInfo SET MachineNo=@MachineNo, MouldNo=@MouldNo, DispatchNo=@DispatchNo, WorkOrderNo=@WorkOrderNo, 
                            OriginalData=@OriginalData, ModifyData=@ModifyData, UploadDate=@UploadDate, ModifyFlag=@ModifyFlag, InputFlag=@InputFlag, Operator=@Operator, OperatorDate=@OperatorDate WHERE ID=@ID  ";

        public IList<ErrDataInfo_MDL> selectErrDataInfo(int id, string colname, string coltext)
        {
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

            IList<ErrDataInfo_MDL> ErrDataInfoList = new List<ErrDataInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ErrDataInfo_MDL ErrDataInfo = new ErrDataInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString(),
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString(),
                        (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString(),
                        (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString(),
                        (sdr["OriginalData"] == DBNull.Value) ? "" : sdr["OriginalData"].ToString(),
                        (sdr["ModifyData"] == DBNull.Value) ? "" : sdr["ModifyData"].ToString(),
                        (sdr["UploadDate"] == DBNull.Value) ? "" : sdr["UploadDate"].ToString(),
                        (sdr["ModifyFlagID"] == DBNull.Value) ? "" : sdr["ModifyFlagID"].ToString(),
                        (sdr["ModifyFlag"] == DBNull.Value) ? "" : sdr["ModifyFlag"].ToString(),
                        (sdr["InputFlagID"] == DBNull.Value) ? "" : sdr["InputFlagID"].ToString(),

                        (sdr["InputFlag"] == DBNull.Value) ? "0" : sdr["InputFlag"].ToString(),
                        (sdr["Operator"] == DBNull.Value) ? "0" : sdr["Operator"].ToString(),
                        (sdr["OperatorDate"] == DBNull.Value) ? "" : sdr["OperatorDate"].ToString()
                        );
                    ErrDataInfoList.Add(ErrDataInfo);
                }
            }
            return ErrDataInfoList;
        }

        public void ChangeErrDataInfo(string vMachineNo, string vMouldNo, string vDispatchNo, string vWorkOrderNo, string vOriginalData,
               string vModifyData, string vUploadDate, string vModifyFlag, string vInputFlag, string vOperator,
               string vOperatorDate, int vID, string IU)
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, vMachineNo),
                        fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, vMouldNo),
                        fsp.FormatInParam("@DispatchNo", SqlDbType.VarChar, vDispatchNo),
                        fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, vWorkOrderNo),
                        fsp.FormatInParam("@OriginalData", SqlDbType.VarChar, vOriginalData),
                        fsp.FormatInParam("@ModifyData", SqlDbType.VarChar, vModifyData),
                        fsp.FormatInParam("@UploadDate", SqlDbType.VarChar, vUploadDate),
                        fsp.FormatInParam("@ModifyFlag", SqlDbType.VarChar, vModifyFlag),
                        fsp.FormatInParam("@InputFlag", SqlDbType.VarChar, vInputFlag),
                        fsp.FormatInParam("@Operator", SqlDbType.VarChar, vOperator),

                        fsp.FormatInParam("@OperatorDate", SqlDbType.VarChar, vOperatorDate),
                        fsp.FormatInParam("@ID", SqlDbType.VarChar, vID)
            };
            if (IU.ToUpper() == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }

        public void cancelErrDataInfo(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE ErrDataInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }       
    }
}
