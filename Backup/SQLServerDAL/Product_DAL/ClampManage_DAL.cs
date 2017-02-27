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
    public class ClampManage_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        string TableName = "PlantBristlesToolInfo";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "FixtureCode", "FixtureDesc", "WarehouseLocation", "PlantBristlesMachine", "Program", "ModiContent", "LastModifier", "LastModiDate", "Ver", "Remark", "MachineCycle" };


        

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="colname">列名</param>
        /// <param name="coltext">值</param>
        /// <returns></returns>
        public IList<ClampManage_MDL> selectClampManage(int id, string colname, string coltext)
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
        /// 查询所有
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="colname">列名</param>
        /// <param name="coltext">值</param>
        /// <returns></returns>
        public IList<ClampManage_MDL> selectClampManage(int id, string colname, string coltext,int t)
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
                sqlWhere.Append(string.Format("AND {0} = '" + coltext + "'", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }
        private IList<ClampManage_MDL> getDataListOfWorkPaper(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY ID");

            IList<ClampManage_MDL> WorkPaperList = new List<ClampManage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ClampManage_MDL WorkPaper = new ClampManage_MDL(
                        (sdr["ID"] == DBNull.Value) ? "" : sdr["ID"].ToString(),
                        (sdr["FixtureCode"] == DBNull.Value) ? "" : sdr["FixtureCode"].ToString(),
                        (sdr["FixtureDesc"] == DBNull.Value) ? "" : sdr["FixtureDesc"].ToString(),
                        (sdr["WarehouseLocation"] == DBNull.Value) ? "" : sdr["WarehouseLocation"].ToString().Trim(),
                        (sdr["PlantBristlesMachine"] == DBNull.Value) ? "" : sdr["PlantBristlesMachine"].ToString(),
                        (sdr["Program"] == DBNull.Value) ? "" : sdr["Program"].ToString(),
                        (sdr["ModiContent"] == DBNull.Value) ? "" : sdr["ModiContent"].ToString(),
                        (sdr["LastModifier"] == DBNull.Value) ? "" : sdr["LastModifier"].ToString(),
                        (sdr["LastModiDate"] == DBNull.Value) ? "" : sdr["LastModiDate"].ToString(),
                        (sdr["Ver"] == DBNull.Value) ? "" : sdr["Ver"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["MachineCycle"] == DBNull.Value) ? "" : sdr["MachineCycle"].ToString()

                    );
                    WorkPaperList.Add(WorkPaper);
                }
            }
            return WorkPaperList;
        }

        public int InsertClampManage(ClampManage_MDL dboCall, string UI)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@FixtureCode", SqlDbType.VarChar,dboCall.FixtureCode),
                fsp.FormatInParam("@FixtureDesc", SqlDbType.VarChar,dboCall.FixtureDesc),
                fsp.FormatInParam("@WarehouseLocation", SqlDbType.VarChar,dboCall.WarehouseLocation),
                fsp.FormatInParam("@PlantBristlesMachine", SqlDbType.VarChar,dboCall.PlantBristlesMachine),
                fsp.FormatInParam("@Program", SqlDbType.VarChar,dboCall.Program),
                fsp.FormatInParam("@ModiContent", SqlDbType.VarChar,dboCall.ModiContent),
                fsp.FormatInParam("@LastModifier", SqlDbType.VarChar,dboCall.LastModifier),
                fsp.FormatInParam("@LastModiDate", SqlDbType.VarChar,dboCall.LastModiDate),
                fsp.FormatInParam("@Ver", SqlDbType.VarChar,dboCall.Ver),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar,dboCall.Remark),
                fsp.FormatInParam("@MachineCycle", SqlDbType.VarChar,dboCall.MachineCycle),
                fsp.FormatInParam("@ID", SqlDbType.VarChar,dboCall.ID)
             };
            try
            {
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName2), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName2), sqlParas);
            }
            finally
            {
                dboCall = null;
            }
        }

        public int DeleteClampManage(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE PlantBristlesToolInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
