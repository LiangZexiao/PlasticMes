using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model;
using Admin.DBUtility;
using Admin.IDAL;

namespace Admin.SQLServerDAL
{
    public class DataControl //: DataAccess
    {
        private static readonly string CntStrLocal = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        //private static readonly string CntStrLocal = ConfigurationManager.ConnectionStrings["SQLConnStringLocal"].ConnectionString;
        //private static readonly string CntStrLocal = ConfigurationManager.AppSettings["SQLConnStringLocal"].ToString();
        private const string SQL_Table_Stru =
            "DECLARE @sql NVARCHAR(4000);SET @sql=N'SELECT * FROM '+@table ;SET @sql=@sql+N' WHERE 1=1';EXEC sp_executesql @sql";

        //增加方法
        public int InsertTable(TableInfo t)
        {
            string strSQL = string.Format("INSERT INTO {0}({1}) VALUES({2})", t.TableName, t.Columns.Replace('|', ','), t.Values);
            SqlConnection objConnection = new SqlConnection(CntStrLocal);
            SqlCommand objCommand = new SqlCommand(strSQL, objConnection);

            objCommand.Connection.Open();
            int AffectNum = objCommand.ExecuteNonQuery();
            objCommand.Connection.Close();

            return AffectNum;
        }

        protected string[] GetArray(StringBuilder paras, char type)
        {
            return Convert.ToString(paras).Split(type);
        }

        //修改方法
        public int UpdateTable(TableInfo t)
        {
            string[] columnArray = GetArray(t.Columns, '|');
            string[] newvalueArray = GetArray(t.NewValue, '|');

            string[] valueArray = GetArray(t.Values, '|');
            string[] pkArrary = GetArray(t.PKColumns, '|');

            StringBuilder type = new StringBuilder();
            StringBuilder value = new StringBuilder();
            string dbDateTime = "GETDATE()";

            for (int i = 0; i < columnArray.Length - 1; i++)
            {
                type.Append(columnArray[i]);
                type.Append("=");

                if (newvalueArray[i].ToUpper() != dbDateTime)
                    type.Append("'");

                type.Append(newvalueArray[i].Replace("'", "''"));
                if (newvalueArray[i].ToUpper() != dbDateTime)
                    type.Append("'");
                type.Append(",");
            }

            type.Append(columnArray[columnArray.Length - 1]);
            type.Append("=");
            if (newvalueArray[newvalueArray.Length - 1].ToUpper() != dbDateTime)
                type.Append("'");
            type.Append(newvalueArray[newvalueArray.Length - 1].Replace("'", "''"));
            if (newvalueArray[newvalueArray.Length - 1].ToUpper() != dbDateTime)
                type.Append("'");

            for (int i = 0; i < pkArrary.Length - 1; i++)
            {
                value.Append(pkArrary[i]);
                value.Append("=");
                value.Append("'");
                value.Append(valueArray[i].Replace("'", "''"));
                value.Append("'");
                value.Append("AND ");
            }

            value.Append(pkArrary[pkArrary.Length - 1]);
            value.Append("=");
            value.Append("'");
            value.Append(valueArray[valueArray.Length - 1].Replace("'", "''"));
            value.Append("'");

            string strSQL = string.Format("UPDATE {0} SET {1} WHERE {2}", t.TableName, type, value);

            SqlConnection objConnection = new SqlConnection(CntStrLocal);
            SqlCommand objCommand = new SqlCommand(strSQL, objConnection);

            objCommand.Connection.Open();
            int AffectNum = objCommand.ExecuteNonQuery();
            objCommand.Connection.Close();

            return AffectNum;
        }

        //删除方法
        public int DeleteTable(TableInfo t)
        {
            string[] valueArray = GetArray(t.Values, '|');
            string[] pkArrary = GetArray(t.PKColumns, '|');

            StringBuilder value = new StringBuilder();

            for (int i = 0; i < pkArrary.Length - 1; i++)
            {
                value.Append(pkArrary[i]);
                value.Append("=");
                value.Append("'");
                value.Append(valueArray[i].Replace("'", "''"));
                value.Append("'");
                value.Append(" AND ");
            }

            value.Append(pkArrary[pkArrary.Length - 1]);
            value.Append("=");
            value.Append("'");
            value.Append(valueArray[valueArray.Length - 1].Replace("'", "''"));
            value.Append("'");

            string strSQL = string.Format("DELETE FROM {0} WHERE {1}", t.TableName, value);

            SqlConnection objConnection = new SqlConnection(CntStrLocal);
            SqlCommand objCommand = new SqlCommand(strSQL, objConnection);

            objCommand.Connection.Open();
            int AffectNum = objCommand.ExecuteNonQuery();
            objCommand.Connection.Close();
            return AffectNum;
        }

        //删除方法
        public int CancelTable(TableInfo t)
        {
            int count = t.IDValue.Count;

            if (count == 0) return count;
            string strSQL = "BEGIN TRANSACTION ";
            for (int i = 0; i < count; i++)
            {
                strSQL += string.Format("DELETE FROM {0} WHERE {1}='{2}' IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ",
                    t.TableName, t.PKColumns, t.IDValue[i].ToString().Trim().Replace("'", "''"));
            }
            strSQL += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN  ";

            SqlConnection objConnection = new SqlConnection(CntStrLocal);
            SqlCommand objCommand = new SqlCommand(strSQL, objConnection);

            objCommand.Connection.Open();
            int AffectNum = objCommand.ExecuteNonQuery();
            objCommand.Connection.Close();
            return AffectNum;
        }

        public DataTable SelectTable(TableInfo t)
        {
            string[] valueArray = GetArray(t.Values, '|');
            string[] pkArrary = GetArray(t.PKColumns, '|');

            string LikeFieldName = t.LikeFieldName.ToString().Trim();
            string LikeFieldValues = t.LikeFieldValues.ToString().Trim();
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < pkArrary.Length - 1; i++)
            {
                value.Append(pkArrary[i]);
                value.Append("=");
                value.Append("'");
                value.Append(valueArray[i].Replace("'", "''"));
                value.Append("'");
                value.Append(" AND ");
            }

            value.Append(pkArrary[pkArrary.Length - 1]);
            value.Append("=");
            value.Append("'");
            value.Append(valueArray[valueArray.Length - 1].Replace("'", "''"));
            value.Append("'");

            string strSQL = "";
            if (value.Length <= 3)
            {
                strSQL = string.Format("SELECT {0} FROM {1} WHERE 1=1", t.Columns.Replace('|', ','), t.TableName);
            }
            else
            {
                strSQL = string.Format("SELECT {0} FROM {1} WHERE {2}", t.Columns.Replace('|', ','), t.TableName, value);
            }

            if (LikeFieldName != "" && LikeFieldValues != "")
            {
                strSQL += string.Format(" AND {0} LIKE '%{1}%'", t.LikeFieldName,
                t.LikeFieldValues.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
            }
            SqlConnection objConnection = new SqlConnection(CntStrLocal);
            SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
            SqlDataAdapter ad = new SqlDataAdapter(objCommand);
            DataSet ds = new DataSet();

            ad.Fill(ds, "alltable");
            return ds.Tables["alltable"];
        }

        public DataTable QueryTable(TableInfo t)
        {
            string[] valueArray = GetArray(t.Values, '|');
            string[] pkArrary = GetArray(t.PKColumns, '|');

            StringBuilder value = new StringBuilder();

            for (int i = 0; i < pkArrary.Length - 1; i++)
            {
                value.Append(pkArrary[i]);
                value.Append("=");
                value.Append("'");
                value.Append(valueArray[i]);
                value.Append("'");
                value.Append(" AND ");
            }

            value.Append(pkArrary[pkArrary.Length - 1]);
            value.Append("=");
            value.Append("'");
            value.Append(valueArray[valueArray.Length - 1]);
            value.Append("'");

            string strSQL = "";

            if (value.Length <= 3)
            {
                strSQL = string.Format("SELECT {0} FROM {1} WHERE 1=1 ", t.Columns.Replace('|', ','), t.TableName);
            }
            else
            {
                strSQL = string.Format("SELECT {0} FROM {1} WHERE {2} ", t.Columns.Replace('|', ','), t.TableName, value);
            }
            strSQL += string.Format(" AND {0} LIKE '%{1}%'", t.LikeFieldName,
                t.LikeFieldValues.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));

            SqlConnection objConnection = new SqlConnection(CntStrLocal);
            SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
            SqlDataAdapter ad = new SqlDataAdapter(objCommand);
            DataSet ds = new DataSet();

            ad.Fill(ds, "alltable");
            return ds.Tables["alltable"];
        }
    }
}