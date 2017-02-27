using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.Model.Product_MDL;
using Admin.Model;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class SuitManage_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        string TableName = "PlantBristlesProdInfo";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "plantBristlesCode","plantBristlesDesc","WireBrushMould","WireBrushMouldDesc","suitMachine","holeNum","holeDiameter",
        "wireBrushWeight","wireWeight","systemNo","cutLength","outNum","getKnifeFoot",
        "StandEmployee","wireTypeCode","wireDesc","modiHeight","brushWireTypeCode","rally","TrayNum","ColumnNum","ColumnCount",
        "productImg","ver","verModiContent","verModiReason","lastUpdator","lastUpdateDate","remark" };

        string[] FieldName4 = { "plantBristlesCode","plantBristlesDesc","WireBrushMould","WireBrushMouldDesc","suitMachine","holeNum","holeDiameter",
        "wireBrushWeight","wireWeight","systemNo","cutLength","outNum","getKnifeFoot",
        "StandEmployee","wireTypeCode","wireDesc","modiHeight","brushWireTypeCode","rally","TrayNum","ColumnNum","ColumnCount",
        "ver","verModiContent","verModiReason","lastUpdator","lastUpdateDate","remark" };

        string[] FieldName3 = { "plantBristlesCode","plantBristlesDesc","WireBrushMould","WireBrushMouldDesc","suitMachine","holeNum","holeDiameter",
        "wireBrushWeight","wireWeight","systemNo","cutLength","outNum","getKnifeFoot",
        "StandEmployee","wireTypeCode","wireDesc","modiHeight","brushWireTypeCode","rally","TrayNum","ColumnNum","ColumnCount",
        "productImg","ver","verModiContent","verModiReason","lastUpdator","CONVERT(CHAR(10),lastUpdateDate,120) lastUpdateDate",
        "remark" };

        string TableName2 = "PlantBristlesProdInfoDetail";
        string[] FieldNameDeatil = { "ID" };
        string[] FieldNameDeatil2 = { "plantBristlesCode", "WireBrushMould", "WireBrushMouldDesc", "CreateDate" };


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="colname">列名</param>
        /// <param name="coltext">值</param>
        /// <returns></returns>
        public IList<SuitManage_MDL> selectSuitManage(int id, string colname, string coltext)
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
        public IList<SuitManage_MDL> selectSuitManage(int t)
        {
            string sqlCmd ;
            sqlCmd = "SELECT Machine_Code  FROM MachineMstr union SELECT MachineCode FROM PlantBristlesMachineInfo";
            IList<SuitManage_MDL> WorkPaperList = new List<SuitManage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), null))
            {
                while (sdr.Read())
                {
                    SuitManage_MDL WorkPaper = new SuitManage_MDL(
                        0,(sdr["Machine_Code"] == DBNull.Value) ? "" : sdr["Machine_Code"].ToString(),"","",""
                    );
                    WorkPaperList.Add(WorkPaper);
                }
            }
            return WorkPaperList;
        }

        public IList<SuitManage_MDL> selectSuitManageDetail(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format(" AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} like '%" + coltext + "%'", colname));
            }
            return getDetail(sqlWhere, sqlParas);
           
        }
        public IList<SuitManage_MDL> selectSuitManageDetail(int id, string colname, string coltext,string colname2, string coltext2)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format(" AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} = '" + coltext + "'", colname));
            }
            if (colname2 != "" && coltext2 != "")
            {
                sqlWhere.Append(string.Format(" AND {0} = '" + coltext2 + "'", colname2));
            }
            return getDetail(sqlWhere, sqlParas);

        }

        private IList<SuitManage_MDL> getDetail(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldNameDeatil.Length + FieldNameDeatil2.Length];
            System.Array.Copy(FieldNameDeatil, 0, SELECT, 0, FieldNameDeatil.Length);
            System.Array.Copy(FieldNameDeatil2, 0, SELECT, FieldNameDeatil.Length, FieldNameDeatil2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName2, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY plantBristlesCode");

            IList<SuitManage_MDL> WorkPaperList = new List<SuitManage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SuitManage_MDL WorkPaper = new SuitManage_MDL(
                        (sdr["ID"] == DBNull.Value) ? 0 : int.Parse(sdr["ID"].ToString()),
                        (sdr["plantBristlesCode"] == DBNull.Value) ? "" : sdr["plantBristlesCode"].ToString(),
                        (sdr["WireBrushMould"] == DBNull.Value) ? "" : sdr["WireBrushMould"].ToString(),
                        (sdr["WireBrushMouldDesc"] == DBNull.Value) ? "" : sdr["WireBrushMouldDesc"].ToString(),
                         (sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString()
                    );
                    WorkPaperList.Add(WorkPaper);
                }
            }
            return WorkPaperList;
        }
        private IList<SuitManage_MDL> getDataListOfWorkPaper(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName3.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName3, 0, SELECT, FieldName1.Length, FieldName3.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY ID");

            IList<SuitManage_MDL> WorkPaperList = new List<SuitManage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SuitManage_MDL WorkPaper = new SuitManage_MDL(
                        (sdr["ID"] == DBNull.Value) ? 0 : int.Parse(sdr["ID"].ToString()),
                        (sdr["plantBristlesCode"] == DBNull.Value) ? "" : sdr["plantBristlesCode"].ToString(),
                        (sdr["plantBristlesDesc"] == DBNull.Value) ? "" : sdr["plantBristlesDesc"].ToString(),
                        (sdr["WireBrushMould"] == DBNull.Value) ? "" : sdr["WireBrushMould"].ToString(),
                        (sdr["WireBrushMouldDesc"] == DBNull.Value) ? "" : sdr["WireBrushMouldDesc"].ToString(),
                        (sdr["suitMachine"] == DBNull.Value) ? "" : sdr["suitMachine"].ToString(),
                        (sdr["holeNum"] == DBNull.Value) ? "0" : sdr["holeNum"].ToString(),
                        (sdr["holeDiameter"] == DBNull.Value) ? "0" : sdr["holeDiameter"].ToString(),
                        (sdr["wireBrushWeight"] == DBNull.Value) ? "0" : sdr["wireBrushWeight"].ToString(),
                        (sdr["wireWeight"] == DBNull.Value) ? "0" : sdr["wireWeight"].ToString(),
                        (sdr["systemNo"] == DBNull.Value) ? "" : sdr["systemNo"].ToString(),
                        (sdr["cutLength"] == DBNull.Value) ? "0" : sdr["cutLength"].ToString(),
                        (sdr["outNum"] == DBNull.Value) ? "0" : sdr["outNum"].ToString(),
                        (sdr["getKnifeFoot"] == DBNull.Value) ? "" : sdr["getKnifeFoot"].ToString(),
                        (sdr["StandEmployee"] == DBNull.Value) ? "" : sdr["StandEmployee"].ToString(),
                        (sdr["wireTypeCode"] == DBNull.Value) ? "" : sdr["wireTypeCode"].ToString(),
                        (sdr["wireDesc"] == DBNull.Value) ? "" : sdr["wireDesc"].ToString(),
                        (sdr["modiHeight"] == DBNull.Value) ? "" : sdr["modiHeight"].ToString(),
                        (sdr["brushWireTypeCode"] == DBNull.Value) ? "" : sdr["brushWireTypeCode"].ToString(),
                        (sdr["rally"] == DBNull.Value) ? "" : sdr["rally"].ToString(),
                        (sdr["TrayNum"] == DBNull.Value) ? "0" : sdr["TrayNum"].ToString(),
                        (sdr["ColumnNum"] == DBNull.Value) ? "0" : sdr["ColumnNum"].ToString(),
                        (sdr["ColumnCount"] == DBNull.Value) ? "0" : sdr["ColumnCount"].ToString(),
                        (sdr["productImg"] == DBNull.Value) ? null : (byte[])sdr["productImg"],
                        (sdr["ver"] == DBNull.Value) ? "" : sdr["ver"].ToString(),
                        (sdr["verModiContent"] == DBNull.Value) ? "" : sdr["verModiContent"].ToString(),
                        (sdr["verModiReason"] == DBNull.Value) ? "" : sdr["verModiReason"].ToString(),
                        (sdr["lastUpdator"] == DBNull.Value) ? "" : sdr["lastUpdator"].ToString(),
                        (sdr["lastUpdateDate"] == DBNull.Value) ? "" : sdr["lastUpdateDate"].ToString(),
                        (sdr["remark"] == DBNull.Value) ? "" : sdr["remark"].ToString()
                    );
                    WorkPaperList.Add(WorkPaper);
                }
            }
            return WorkPaperList;
        }

        public IList<SuitManage_MDL> existsPlantBristlesCode(string plantBristlesCode,string colname)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            sqlWhere.Append(string.Format("AND {0}='" + plantBristlesCode + "'", colname));
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }
        public int InsertSuitManage(SuitManage_MDL dboCall, string UI)
        {
            SqlParameter[] sqlParas ={
                    fsp.FormatInParam("@plantBristlesCode", SqlDbType.VarChar,dboCall.PlantBristlesCode),
                    fsp.FormatInParam("@plantBristlesDesc", SqlDbType.VarChar,dboCall.PlantBristlesDesc),
                    fsp.FormatInParam("@WireBrushMould", SqlDbType.VarChar,dboCall.WireBrushMould),
                    fsp.FormatInParam("@WireBrushMouldDesc", SqlDbType.VarChar,dboCall.WireBrushMouldDesc),
                    fsp.FormatInParam("@suitMachine", SqlDbType.VarChar,dboCall.SuitMachine),
                    fsp.FormatInParam("@holeNum", SqlDbType.VarChar,dboCall.HoleNum),
                    fsp.FormatInParam("@holeDiameter", SqlDbType.VarChar,dboCall.HoleDiameter),
                    fsp.FormatInParam("@wireBrushWeight", SqlDbType.VarChar,dboCall.WireBrushWeight),
                    fsp.FormatInParam("@wireWeight", SqlDbType.VarChar,dboCall.WireWeight),
                    fsp.FormatInParam("@systemNo", SqlDbType.VarChar,dboCall.SystemNo),
                    fsp.FormatInParam("@cutLength", SqlDbType.VarChar,dboCall.CutLength),
                    fsp.FormatInParam("@outNum", SqlDbType.VarChar,dboCall.OutNum),
                    fsp.FormatInParam("@getKnifeFoot", SqlDbType.VarChar,dboCall.GetKnifeFoot),
                    fsp.FormatInParam("@StandEmployee", SqlDbType.VarChar,dboCall.StandEmployee),
                    fsp.FormatInParam("@wireTypeCode", SqlDbType.VarChar,dboCall.WireTypeCode),
                    fsp.FormatInParam("@wireDesc", SqlDbType.VarChar,dboCall.WireDesc),
                    fsp.FormatInParam("@modiHeight", SqlDbType.VarChar,dboCall.ModiHeight),
                    fsp.FormatInParam("@brushWireTypeCode", SqlDbType.VarChar,dboCall.BrushWireTypeCode),
                    fsp.FormatInParam("@rally", SqlDbType.VarChar,dboCall.Rally),
                    fsp.FormatInParam("@TrayNum", SqlDbType.VarChar,dboCall.TrayNum),
                    fsp.FormatInParam("@ColumnNum", SqlDbType.VarChar,dboCall.ColumnNum),
                    fsp.FormatInParam("@ColumnCount", SqlDbType.VarChar,dboCall.ColumnCount),
                    fsp.FormatInParam("@productImg", SqlDbType.Image,dboCall.ProductImg),
                    fsp.FormatInParam("@ver", SqlDbType.VarChar,dboCall.Ver),
                    fsp.FormatInParam("@verModiContent", SqlDbType.VarChar,dboCall.VerModiContent),
                    fsp.FormatInParam("@verModiReason", SqlDbType.VarChar,dboCall.VerModiReason),
                    fsp.FormatInParam("@lastUpdator", SqlDbType.VarChar,dboCall.LastUpdator),
                    fsp.FormatInParam("@lastUpdateDate", SqlDbType.VarChar,dboCall.LastUpdateDate),
                    fsp.FormatInParam("@remark", SqlDbType.VarChar,dboCall.Remark),

                    fsp.FormatInParam("@ID", SqlDbType.VarChar,dboCall.ID)
             };
            try
            {
                byte[] temp_Photo = dboCall.ProductImg;
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName2), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, ((temp_Photo.Length > 4) ? FieldName2 : FieldName4)), sqlParas);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                dboCall = null;
            }
        }

        public int InsertSuitManageDetail(SuitManage_MDL dboCall, string UI)
        {
            SqlParameter[] sqlParas ={
                    fsp.FormatInParam("@plantBristlesCode", SqlDbType.VarChar,dboCall.PlantBristlesCode),
                    fsp.FormatInParam("@WireBrushMould", SqlDbType.VarChar,dboCall.WireBrushMould),
                    fsp.FormatInParam("@WireBrushMouldDesc", SqlDbType.VarChar,dboCall.WireBrushMouldDesc),
                    fsp.FormatInParam("@CreateDate", SqlDbType.VarChar,dboCall.CreateDate),
                    fsp.FormatInParam("@ID", SqlDbType.VarChar,dboCall.ID)
             };
            try
            {
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName2, FieldNameDeatil2), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName2, FieldNameDeatil2), sqlParas);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                dboCall = null;
            }
        }

        public int DeleteMachineSuit(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
            {
                ExecBatch += string.Format("delete PlantBristlesProdInfoDetail where PlantBristlesCode = (select PlantBristlesCode from PlantBristlesProdInfo where id={0})  IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot  ", s);
                ExecBatch += string.Format("DELETE PlantBristlesProdInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int DeleteMachineSuitDetail(string _PlantBristlesCode)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("DELETE PlantBristlesProdInfoDetail WHERE PlantBristlesCode='{0}' IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", _PlantBristlesCode);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
