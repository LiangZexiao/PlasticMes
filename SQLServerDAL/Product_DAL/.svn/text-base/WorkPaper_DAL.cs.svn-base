using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.Model;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class WorkPaper_DAL
    {
        TableMstr tm = new TableMstr();
        SQLPreparer objPreparer = new SQLPreparer();
        //  FormatSqlParas fsp = new FormatSqlParas();


        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        string TableName = "WorkPaper";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "ProdCode", "WorkGuidanceImg"};

     

        public IList<WorkPaper_MDL> selectWorkPaper(int id, string colname, string coltext)
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
                sqlWhere.Append(string.Format(" AND {0} LIKE '%" + coltext + "%'", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }
        public DataTable selectWorkPaper(int id, string colname, string coltext, int t)
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
            return getDataListOfWorkPaper(sqlWhere, sqlParas, t);
        }
        private DataTable getDataListOfWorkPaper(StringBuilder sqlWhere, SqlParameter[] sqlParas, int t)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));
            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY id");
            return SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
        }

        public IList<WorkPaper_MDL> existsWorkPaper(string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} = '" + coltext + "'", colname));
            }
            return getDataListOfWorkPaper(sqlWhere, sqlParas);
        }
        private IList<WorkPaper_MDL> getDataListOfWorkPaper(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY ID");

            IList<WorkPaper_MDL> WorkPaperList = new List<WorkPaper_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    WorkPaper_MDL WorkPaper = new WorkPaper_MDL(
                        (sdr["ID"] == DBNull.Value) ? "0" : sdr["ID"].ToString(),
                        (sdr["ProdCode"] == DBNull.Value) ? "" : sdr["ProdCode"].ToString(),
                        (sdr["WorkGuidanceImg"] == DBNull.Value) ? null : (byte[])sdr["WorkGuidanceImg"]
                    );
                    WorkPaperList.Add(WorkPaper);
                }
            }
            return WorkPaperList;
        }



        public int insertWorkPaper(WorkPaper_MDL dboWorkPaper, string UI)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@ProdCode", SqlDbType.VarChar,dboWorkPaper.ProdCode),
                fsp.FormatInParam("@WorkGuidanceImg", SqlDbType.Image,dboWorkPaper.WorkGuidanceImg),
                fsp.FormatInParam("@ID", SqlDbType.VarChar,dboWorkPaper.ID)
             };
            try
            {
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName2), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName2), sqlParas);
            }
            catch (Exception ex)
            {
                dboWorkPaper = null;
                return -1;
            }
            finally
            {
                dboWorkPaper = null;
            }
        }
       
        public int deleteWorkPaper(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE WorkPaper WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
      
    }
}