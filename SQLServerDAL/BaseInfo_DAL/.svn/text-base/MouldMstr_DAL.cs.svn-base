using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.BaseInfo_MDL;
using Admin.IDAL.BaseInfo_IDAL;


namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    class MouldMstr_DAL: IMouldMstr
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();

        string TableName = "MouldMstr";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "Mould_Code", "ProductNo", "GoodSocketNum", "Remark" };       

        public IList<MouldMstr_MDL> selectMouldMstr(int id, string colname, string coltext)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);

            StringBuilder sqlWhere = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));
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

            return getMouldMstrList(sqlWhere.Append(" ORDER BY Mould_Code,ProductNo"), sqlParas);
        }

        public IList<MouldMstr_MDL> existsMouldMstr(string vMouldNo, string vProductNo)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(vMouldNo) && !string.IsNullOrEmpty(vProductNo))
            {
                sqlWhere.Append("SELECT DISTINCT 0,Mould_Code,ProductNo,GoodSocketNum,'' Remark FROM  MouldMstr WHERE 1=1 AND Mould_Code=@MouldNo AND ProductNo=@ProductNo");
            }//用于判断是否存在相同的主键值
            if (!string.IsNullOrEmpty(vMouldNo) && string.IsNullOrEmpty(vProductNo))
            {
                sqlWhere.Append("SELECT DISTINCT 0,'' Mould_Code,ProductNo,GoodSocketNum,'' Remark  FROM  MouldMstr WHERE 1=1 AND Mould_Code=@MouldNo");
            }//用于根据模具编号查询出所有的产品编号
            if (string.IsNullOrEmpty(vMouldNo) && !string.IsNullOrEmpty(vProductNo))
            {
                sqlWhere.Append("SELECT DISTINCT 0,Mould_Code,'' ProductNo,GoodSocketNum,'' Remark  FROM  MouldMstr WHERE 1=1 AND ProductNo=@ProductNo");
            }//用于根据产品编号查询出所有的模具编号
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, vMouldNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo)
            };

            return getMouldMstrList(sqlWhere, sqlParas);
        }

        private IList<MouldMstr_MDL> getMouldMstrList(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            List<MouldMstr_MDL> MouldMstrList = new List<MouldMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlWhere.ToString(), sqlParas))
            {
                while (sdr != null && sdr.Read())
                {
                    MouldMstr_MDL MouldMstr = new MouldMstr_MDL(
                        sdr.GetInt32(0),
                        (sdr["Mould_Code"] == DBNull.Value) ? "" : sdr["Mould_Code"].ToString(),
                        (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString(),
                        (sdr["GoodSocketNum"] == DBNull.Value) ? 0 : int.Parse(sdr["GoodSocketNum"].ToString()),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString()
                        );
                    MouldMstrList.Add(MouldMstr);
                }
            }
            return MouldMstrList;
        }

        public void ChangeMouldMstr(int vID, string vMouldNo, string vProductNo, int vGoodSocketNum, string vRemark, string IU)
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@Mould_Code", SqlDbType.VarChar, vMouldNo),
                        fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo),
                        fsp.FormatInParam("@GoodSocketNum", SqlDbType.Int, vGoodSocketNum),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar, vRemark),
                        fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
            string[] SQL = new string[FieldName2.Length];
            System.Array.Copy(FieldName2, 0, SQL, 0, FieldName2.Length);

            if (IU.ToUpper() == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, SQL), sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, SQL), sqlParas);
        }

        public void cancelMouldMstr(ArrayList vIDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in vIDList)
                ExecBatch += string.Format("DELETE MouldMstr WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
