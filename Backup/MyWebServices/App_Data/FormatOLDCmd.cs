using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.OLDServerDAL
{
    public class FormatOLDCmd
    {
        /// <summary>
        /// 获取 SQL 的查询语句(表名,所要显示的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetSelectCmd(string OleDbTableName, string[] OleDbFieldName)
        {
            string FieldName = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < OleDbFieldName.Length); i++)
            {
                tempFieldName = ConvertFieldName(OleDbFieldName[i]);
                if (i != OleDbFieldName.Length - 1)
                    FieldName += tempFieldName + ",";
                else
                    FieldName += tempFieldName;
            }
            if (string.IsNullOrEmpty(FieldName)) return "";
            return string.Format("SELECT {0} FROM {1} WHERE 1=1 ", FieldName, OleDbTableName);
        }
        /// <summary>
        /// 获取 SQL 的插入语句(表名,所要插入的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetInsertCmd(string OleDbTableName, string[] OleDbFieldName)
        {
            string FieldName = string.Empty;
            string FieldText = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < OleDbFieldName.Length); i++)
            {
                tempFieldName = RecoverFieldName(OleDbFieldName[i]);
                if (i != OleDbFieldName.Length - 1)
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
            return string.Format("INSERT INTO {0} ({1}) VALUES({2})", OleDbTableName, FieldName, FieldText);
        }
        /// <summary>
        /// 获取 SQL 的更新语句(表名,所要更新的字段名)
        /// </summary>
        /// <param name="SqlTableName"></param>
        /// <param name="SqlFieldName"></param>
        /// <returns></returns>
        public string GetUpdateCmd(string OleDbTableName, string[] OleDbFieldName)
        {
            string OleDbPartNormal = string.Empty;
            string tempFieldName = string.Empty;
            for (int i = 0; (i < OleDbFieldName.Length); i++)
            {
                tempFieldName = RecoverFieldName(OleDbFieldName[i]);
                OleDbPartNormal += tempFieldName + "=";
                if (i != OleDbFieldName.Length - 1)
                    OleDbPartNormal += "@" + tempFieldName + ",";
                else
                    OleDbPartNormal += "@" + tempFieldName;
            }

            if (string.IsNullOrEmpty(OleDbPartNormal)) return string.Empty;
            string sqlstr = string.Format("UPDATE {0} SET {1} WHERE ID=@ID", OleDbTableName, OleDbPartNormal);
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
