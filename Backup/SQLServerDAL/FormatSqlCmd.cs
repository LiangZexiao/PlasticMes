using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.SQLServerDAL
{
    public class FormatSqlCmd
    {
        /// <summary>
        /// 获取 SQL 的查询语句(表名,所要显示的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetSelectCmd(string SqlTableName, string[] SqlFieldName)
        {
            string FieldName = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < SqlFieldName.Length); i++)
            {
                tempFieldName = ConvertFieldName(SqlFieldName[i]);
                if (i != SqlFieldName.Length - 1)
                    FieldName += tempFieldName + ",";
                else
                    FieldName += tempFieldName;
            }
            if (string.IsNullOrEmpty(FieldName)) return "";
            return string.Format("SELECT {0} FROM {1} WHERE 1=1 ", FieldName, SqlTableName);
        }
        /// <summary>
        /// 获取 SQL 的插入语句(表名,所要插入的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetInsertCmd(string SqlTableName, string[] SqlFieldName)
        {
            string FieldName = string.Empty;
            string FieldText = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < SqlFieldName.Length); i++)
            {
                tempFieldName = RecoverFieldName(SqlFieldName[i]);
                if (i != SqlFieldName.Length - 1)
                {
                    FieldName += tempFieldName + ",";
                    FieldText += "@" + tempFieldName + ",";
                }
                else
                {
                    FieldName += tempFieldName;
                    FieldText += "@" + tempFieldName;
                }
            }
            if (string.IsNullOrEmpty(FieldName)) return string.Empty;
            return string.Format("INSERT INTO {0} ({1}) VALUES({2})", SqlTableName, FieldName, FieldText);
        }
        /// <summary>
        /// 获取 SQL 的更新语句(表名,所要更新的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetUpdateCmd(string SqlTableName, string[] SqlFieldName)
        {
            string SqlPartNormal = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < SqlFieldName.Length); i++)
            {
                tempFieldName = RecoverFieldName(SqlFieldName[i]);
                SqlPartNormal += tempFieldName + "=";
                if (i != SqlFieldName.Length - 1)
                    SqlPartNormal += "@" + tempFieldName + ",";
                else
                    SqlPartNormal += "@" + tempFieldName;
            }

            if (string.IsNullOrEmpty(SqlPartNormal)) return string.Empty;
            string sqlstr=string.Format("UPDATE {0} SET {1} WHERE ID=@ID", SqlTableName, SqlPartNormal);
            return sqlstr;
        }
        /// <summary>
        /// 获取 SQL 的更新语句(表名,所要更新的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetUpdateCmd(string SqlTableName, string[] SqlFieldName,string colname,string coltext)
        {
            string SqlPartNormal = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < SqlFieldName.Length); i++)
            {
                tempFieldName = RecoverFieldName(SqlFieldName[i]);
                SqlPartNormal += tempFieldName + "=";
                if (i != SqlFieldName.Length - 1)
                    SqlPartNormal += "@" + tempFieldName + ",";
                else
                    SqlPartNormal += "@" + tempFieldName;
            }

            if (string.IsNullOrEmpty(SqlPartNormal)) return string.Empty;
            string sqlstr = string.Format("UPDATE {0} SET {1} WHERE {2}={3}", SqlTableName, SqlPartNormal, colname, coltext);
            return sqlstr;
        }

        private string ConvertFieldName(string FieldName)
        {
            if (FieldName.Length > 9 && FieldName.Substring(0, 9).ToUpper() == "DATETIME_")
                FieldName = "CONVERT(CHAR(10)," + FieldName.Remove(0, 9) + ",121) AS " + FieldName.Remove(0, 9);
            return FieldName.Trim();
        }

        private string RecoverFieldName(string FieldName)
        {
            if (FieldName.Length > 9 && FieldName.Substring(0, 9).ToUpper() == "DATETIME_")
                FieldName = FieldName.Remove(0, 9);
            return FieldName.Trim();
        }
    }
}
