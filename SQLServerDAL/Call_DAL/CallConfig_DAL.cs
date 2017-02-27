using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Admin.Model;
using Admin.DBUtility;
using Admin.Model.Call_MDL;

namespace Admin.SQLServerDAL.Call_DAL
{
    public class CallConfig_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        string TableName = "CallConfig";
        string[] FieldName1 = { "ID" };


        string[] FieldName2 = { "callID", "CallStr", "CallTypeID", "UnitType", "UnitTypeID", "CallValue", "UnitValue"
                               , "CONVERT(CHAR(10),CreateTime,121) CreateTime", "MachineNo", "DO_NO"
                               , "SendNum", "upNum", "downNum", "sendEmployee","BcCode" };
        string[] FieldName3 = { "callID", "CallStr", "CallTypeID", "UnitType", "UnitTypeID",
                               "CallValue", "UnitValue", "CreateTime", "MachineNo", "DO_NO",
                               "SendNum", "upNum", "downNum", "sendEmployee"," HuanMu","HuanLiao"
                               ,"HuanDan","FuShe","JiQi","MuJu","DaiLiao","WuDingDan","QiTa"
                               ,"DaiRen","ZiDingYi","BcCode"};
        string[] FieldName4 = { "callID", "CallStr", "CallTypeID", "UnitType", "UnitTypeID", "CallValue"
                               ,"UnitValue", "CreateTime", "MachineNo", "DO_NO", "SendNum", "upNum", 
                               "downNum", "sendEmployee","BcCode"};
        private const string SQL_SELECT2 = @"SELECT distinct EmployeeName_CN,EmployeeID FROM Employee
                                         WHERE  1=1 and rankdesc in('领班','质检','机修','其它') and invalid=1  ";
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="colname">列名</param>
        /// <param name="coltext">值</param>
        /// <returns></returns>
        public IList<CallConfig_MDL> selectWorkPaper(int id, string colname, string coltext)
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
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + coltext + "%'", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }
        /// <summary>
        /// 根据报警类型查询
        /// </summary>
        /// <param name="CallTypeID">类型ID</param>
        /// <param name="id"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public IList<CallConfig_MDL> selectWorkPaper(int CallTypeID, int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (CallTypeID != 0)
            {
                sqlWhere.Append(string.Format("AND CallID=@CallID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@CallTypeID", SqlDbType.Int, CallTypeID) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + coltext + "%'", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }

        /// <summary>
        /// 根据报警类型和短消息类型查询
        /// </summary>
        /// <param name="UnitTypeID">短消息类型ID</param>
        /// <param name="CallTypeID">报警类型ID</param>
        /// <param name="id"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public IList<CallConfig_MDL> selectWorkPaper(int CallID, int CallTypeID, int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format(" AND ID=@ID "));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (CallID != 0)
            {
                sqlWhere.Append(string.Format(" AND CallID={0} ", CallID));
                //sqlParas. = new SqlParameter[1] { fsp.FormatInParam("@UnitTypeID", SqlDbType.Int, UnitTypeID) };
            }
            if (CallTypeID != 0)
            {
                sqlWhere.Append(string.Format(" AND CallTypeID={0} ", CallTypeID));
                // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@CallTypeID", SqlDbType.Int, CallTypeID) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} LIKE '%" + coltext + "%' ", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }

        public DataSet selectEmployee(int id, string colname, string coltext)
        {
            try
            {
                StringBuilder sqlCmd = new StringBuilder(SQL_SELECT2);
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
                return SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.Append(" ORDER BY EmployeeName_CN asc").ToString(), sqlParas);
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
            
        }

        public IList<CallConfig_MDL> selectWorkPaper(string CallID, string CallTypeID, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (CallID != "0")
            {
                sqlWhere.Append(string.Format(" AND callID={0} ", CallID));
                //sqlParas. = new SqlParameter[1] { fsp.FormatInParam("@UnitTypeID", SqlDbType.Int, UnitTypeID) };
            }
            if (CallTypeID != "0")
            {
                sqlWhere.Append(string.Format(" AND CallTypeID={0} ", CallTypeID));
                // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@CallTypeID", SqlDbType.Int, CallTypeID) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} = '" + coltext + "' ", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }

        private IList<CallConfig_MDL> getDataListOfWorkPaper(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY id");

            IList<CallConfig_MDL> WorkPaperList = new List<CallConfig_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    CallConfig_MDL WorkPaper = new CallConfig_MDL(
                        (sdr["id"] == DBNull.Value) ? "0" : sdr["id"].ToString(),
                        (sdr["callID"] == DBNull.Value) ? "0" : sdr["callID"].ToString(),
                        (sdr["CallStr"] == DBNull.Value) ? "0" : sdr["CallStr"].ToString(),
                        (sdr["CallTypeID"] == DBNull.Value) ? "0" : sdr["CallTypeID"].ToString().Trim(),
                        (sdr["UnitType"] == DBNull.Value) ? "0" : sdr["UnitType"].ToString(),
                        (sdr["UnitTypeID"] == DBNull.Value) ? "0" : sdr["UnitTypeID"].ToString(),
                        (sdr["CallValue"] == DBNull.Value) ? "0" : sdr["CallValue"].ToString(),
                        (sdr["UnitValue"] == DBNull.Value) ? "0" : sdr["UnitValue"].ToString(),
                        (sdr["CreateTime"] == DBNull.Value) ? "0" : sdr["CreateTime"].ToString(),
                        (sdr["MachineNo"] == DBNull.Value) ? "0" : sdr["MachineNo"].ToString(),
                        (sdr["DO_NO"] == DBNull.Value) ? "0" : sdr["DO_NO"].ToString(),
                        (sdr["SendNum"] == DBNull.Value) ? "0" : sdr["SendNum"].ToString(),
                        (sdr["upNum"] == DBNull.Value) ? "0" : sdr["upNum"].ToString(),
                        (sdr["downNum"] == DBNull.Value) ? "0" : sdr["downNum"].ToString(),
                        (sdr["sendEmployee"] == DBNull.Value) ? "0" : sdr["sendEmployee"].ToString(),
                        (sdr["BcCode"] == DBNull.Value) ? "" : sdr["BcCode"].ToString()
                    );
                    WorkPaperList.Add(WorkPaper);
                }
            }
            return WorkPaperList;
        }

        public int InsertCall(CallConfig_MDL dboCall, string UI)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@callID", SqlDbType.VarChar,dboCall.CallID),
                fsp.FormatInParam("@CallStr", SqlDbType.VarChar,dboCall.CallStr),
                fsp.FormatInParam("@CallTypeID", SqlDbType.VarChar,dboCall.CallTypeID),
                fsp.FormatInParam("@UnitType", SqlDbType.VarChar,dboCall.UnitType),
                fsp.FormatInParam("@UnitTypeID", SqlDbType.VarChar,dboCall.UnitTypeID),
                fsp.FormatInParam("@CallValue", SqlDbType.VarChar,dboCall.CallValue),
                fsp.FormatInParam("@UnitValue", SqlDbType.VarChar,dboCall.UnitValue),
                fsp.FormatInParam("@CreateTime", SqlDbType.VarChar,dboCall.CreateTime),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar,dboCall.MachineNo),
                fsp.FormatInParam("@DO_NO", SqlDbType.VarChar,dboCall.DONO),
                fsp.FormatInParam("@SendNum", SqlDbType.VarChar,dboCall.SendNum),
                fsp.FormatInParam("@upNum", SqlDbType.VarChar,dboCall.UpNum),
                fsp.FormatInParam("@downNum", SqlDbType.VarChar,dboCall.DownNum),
                fsp.FormatInParam("@sendEmployee", SqlDbType.VarChar,dboCall.SendEmployee),
                fsp.FormatInParam("@HuanMu", SqlDbType.VarChar,dboCall.HuanMu),
                fsp.FormatInParam("@HuanLiao", SqlDbType.VarChar,dboCall.HuanLiao),
                fsp.FormatInParam("@HuanDan", SqlDbType.VarChar,dboCall.HuanDan),
                fsp.FormatInParam("@FuShe", SqlDbType.VarChar,dboCall.FuShe),
                fsp.FormatInParam("@JiQi", SqlDbType.VarChar,dboCall.JiQi),
                fsp.FormatInParam("@MuJu", SqlDbType.VarChar,dboCall.MuJu),
                fsp.FormatInParam("@DaiLiao", SqlDbType.VarChar,dboCall.DaiLiao),
                fsp.FormatInParam("@WuDingDan", SqlDbType.VarChar,dboCall.WuDingDan),
                fsp.FormatInParam("@QiTa", SqlDbType.VarChar,dboCall.QiTa),
                fsp.FormatInParam("@DaiRen", SqlDbType.VarChar,dboCall.DaiRen),
                fsp.FormatInParam("@ZiDingYi", SqlDbType.VarChar,dboCall.ZiDingYi),
                fsp.FormatInParam("@ID", SqlDbType.VarChar,dboCall.ID),
                fsp.FormatInParam("@BcCode", SqlDbType.VarChar,dboCall.BcCode)
             };
            try
            {
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName3), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName3), sqlParas);
            }
            catch (Exception ex)
            {
                dboCall = null;
                return 0;
            }
            finally
            {
                dboCall = null;
            }
        }


        public int InsertCall_1(CallConfig_MDL dboCall, string UI)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@callID", SqlDbType.VarChar,dboCall.CallID),
                fsp.FormatInParam("@CallStr", SqlDbType.VarChar,dboCall.CallStr),
                fsp.FormatInParam("@CallTypeID", SqlDbType.VarChar,dboCall.CallTypeID),
                fsp.FormatInParam("@UnitType", SqlDbType.VarChar,dboCall.UnitType),
                fsp.FormatInParam("@UnitTypeID", SqlDbType.VarChar,dboCall.UnitTypeID),
                fsp.FormatInParam("@CallValue", SqlDbType.VarChar,dboCall.CallValue),
                fsp.FormatInParam("@UnitValue", SqlDbType.VarChar,dboCall.UnitValue),
                fsp.FormatInParam("@CreateTime", SqlDbType.VarChar,dboCall.CreateTime),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar,dboCall.MachineNo),
                fsp.FormatInParam("@DO_NO", SqlDbType.VarChar,dboCall.DONO),
                fsp.FormatInParam("@SendNum", SqlDbType.VarChar,dboCall.SendNum),
                fsp.FormatInParam("@upNum", SqlDbType.VarChar,dboCall.UpNum),
                fsp.FormatInParam("@downNum", SqlDbType.VarChar,dboCall.DownNum),
                fsp.FormatInParam("@sendEmployee", SqlDbType.VarChar,dboCall.SendEmployee),
                fsp.FormatInParam("@ID", SqlDbType.VarChar,dboCall.ID),
                fsp.FormatInParam("@BcCode", SqlDbType.VarChar,dboCall.BcCode)
             };
            try
            {
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName4), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName4), sqlParas);
            }
            catch (Exception ex)
            {
                dboCall = null;
                return 0;
            }
            finally
            {
                dboCall = null;
            }
        }

        public int DeleteCall(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE CallConfig WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int DeleteCall(string types)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("DELETE CallConfig where callid={0}  IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", types);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        /// <summary>
        /// add by fsq 2009.12.14
        /// </summary>
        /// <param name="types"></param>
        /// <param name="MachineNo"></param>
        /// <returns></returns>
        public int DeleteCall(string types,string MachineNo,string bccode)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            if (MachineNo == "MoldNo")
            {
                ExecBatch += string.Format(@"DELETE CallConfig where callid={0} and MachineNo not in
                                   (select machinecode  from v_machine
                                    )  and BcCode='{1}'
                        IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", types,bccode);
            }
            else
            {

                ExecBatch += string.Format(@"DELETE CallConfig where callid={0} and MachineNo in
                                 (select machinecode
                                    from v_machine
                                    where (workshopid='{1}' or parentworkshopid='{1}')
                                    )  and BcCode='{2}'
                        IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", types, MachineNo,bccode);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int DeleteCallDetail(string types, string MachineNo, string UnitValue)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("DELETE CallConfig where callid={0} and UnitValue={1} and MachineNo like '{2}%' IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", types,UnitValue, MachineNo);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}

