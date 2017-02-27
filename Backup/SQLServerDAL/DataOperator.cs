using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model;

namespace Admin.SQLServerDAL
{
    public class DataOperator
    {
        private const string SYS_DATETIME = "GETDATE()";
        private string CommandSqlText = string.Empty;
        SQLExecutant sqlExecutant = new SQLExecutant();
        Common objCommon = new Common();

        /// <summary>
        /// 查询记录
        /// look up about record
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public DataTable ExecQueryCmd(TableMstr tm)
        {
            int ColNameLgt = (tm.ColumnsName != null) ? tm.ColumnsName.Length : 0;
            int KeyColNameLgt = (tm.KeyColumnsName != null) ? tm.KeyColumnsName.Length : 0;
            int KeyColTextLgt = (tm.KeyColumnsText != null) ? tm.KeyColumnsText.Length : 0;
            string sqlTableName = tm.TableName;
            string sqlLikeColName = tm.LikeColumnsName, sqlLikeColText = objCommon.GetSafeSqlText(true, tm.LikeColumnsText);
            string sqlPartNormal = string.Empty;
            string sqlPartPraKey = string.Empty;
            string sqlOrderFieldName = (tm.OrderFieldName != "") ? tm.OrderFieldName : string.Empty;
            string sqlOrderDirection = (tm.OrderDirection != "") ? tm.OrderDirection : string.Empty;

            for (int i = 0; i < ColNameLgt; i++)
                sqlPartNormal += (i != ColNameLgt - 1) ? string.Format("{0},", tm.ColumnsName[i]) : tm.ColumnsName[i];
            if (string.IsNullOrEmpty(sqlPartNormal)) sqlPartNormal = "*";

            for (int i = 0; (i < KeyColNameLgt && KeyColNameLgt == KeyColTextLgt && KeyColTextLgt != 0); i++)
            {
                if (!string.IsNullOrEmpty(tm.KeyColumnsText[i]))
                {
                    sqlPartPraKey += string.Format("{0}=", tm.KeyColumnsName[i]);
                    if (i != KeyColNameLgt - 1)
                        sqlPartPraKey += string.Format("'{0}' AND ", objCommon.GetSafeSqlText(false, tm.KeyColumnsText[i]));
                    else
                        sqlPartPraKey += string.Format("'{0}'     ", objCommon.GetSafeSqlText(false, tm.KeyColumnsText[i]));
                }
            }

            if (string.IsNullOrEmpty(sqlPartPraKey))
                CommandSqlText = string.Format("SELECT {0} FROM {1} WHERE 1=1", sqlPartNormal, sqlTableName);
            else
                CommandSqlText = string.Format("SELECT {0} FROM {1} WHERE {2}", sqlPartNormal, sqlTableName, sqlPartPraKey);
            if (sqlLikeColName != "" && sqlLikeColText != "")
                CommandSqlText += string.Format(" AND {0} LIKE '%{1}%'", sqlLikeColName, sqlLikeColText);
            if (sqlOrderFieldName != "" && sqlOrderDirection != "")
                CommandSqlText += string.Format(" ORDER BY {0} {1}", sqlOrderFieldName, sqlOrderDirection);
            return sqlExecutant.ExecQueryCmd(CommandSqlText);
        }

        /// <summary>
        /// new add one record to table
        /// 新增记录
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public int ExecInsertCmd(TableMstr tm)
        {
            int ColNameLgt = tm.ColumnsName.Length, ColTextLgt = tm.ColumnsText.Length;
            string sqlTableName = tm.TableName;
            string sqlPartName = string.Empty, sqlPartText = string.Empty;

            for (int i = 0; (i < ColNameLgt && ColNameLgt == ColTextLgt && ColNameLgt != 0); i++)
            {
                if (i != ColNameLgt - 1)
                {
                    sqlPartName += string.Format("{0},", tm.ColumnsName[i]);

                    if (tm.ColumnsText[i].ToUpper() != SYS_DATETIME)
                        sqlPartText += string.Format("'{0}',", objCommon.GetSafeSqlText(false, tm.ColumnsText[i]));
                    else
                        sqlPartText += string.Format("{0},", tm.ColumnsText[i]);
                }
                else
                {
                    sqlPartName += string.Format(tm.ColumnsName[i]);

                    if (tm.ColumnsText[i].ToUpper() != SYS_DATETIME)
                        sqlPartText += string.Format("'{0}'", objCommon.GetSafeSqlText(false, tm.ColumnsText[i]));
                    else
                        sqlPartText += string.Format(tm.ColumnsText[i]);
                }
            }
            if (string.IsNullOrEmpty(sqlPartText)) return 0;

            CommandSqlText = string.Format("INSERT INTO {0} ({1}) VALUES({2})", sqlTableName, sqlPartName, sqlPartText);
            return sqlExecutant.ExecModifyCmd(CommandSqlText);
        }

        /// <summary>
        /// update the record
        /// 更新记录
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public int ExecUpdateCmd(TableMstr tm)
        {
            int ColNameLgt = tm.ColumnsName.Length, ColTextLgt = tm.ColumnsText.Length;
            int KeyColNameLgt = tm.KeyColumnsName.Length, KeyColTextLgt = tm.KeyColumnsText.Length;
            string sqlTableName = tm.TableName;
            string sqlPartNormal = string.Empty, sqlPartPraKey = string.Empty;

            for (int i = 0; (i < ColNameLgt && ColNameLgt == ColTextLgt && ColNameLgt != 0); i++)
            {
                sqlPartNormal += string.Format("{0}=", tm.ColumnsName[i]);
                if (i != ColNameLgt - 1)
                {
                    if (tm.ColumnsText[i].ToUpper() != SYS_DATETIME)
                        sqlPartNormal += string.Format("'{0}',", objCommon.GetSafeSqlText(false, tm.ColumnsText[i]));
                    else
                        sqlPartNormal += string.Format("{0},", tm.ColumnsText[i]);
                }
                else
                {
                    if (tm.ColumnsText[i].ToUpper() != SYS_DATETIME)
                        sqlPartNormal += string.Format("'{0}'", objCommon.GetSafeSqlText(false, tm.ColumnsText[i]));
                    else
                        sqlPartNormal += string.Format("{0}", tm.ColumnsText[i]);
                }
            }

            for (int i = 0; (i < KeyColNameLgt && KeyColNameLgt == KeyColTextLgt && KeyColNameLgt != 0); i++)
            {
                sqlPartPraKey += string.Format("{0}=", tm.KeyColumnsName[i]);
                if (i != KeyColNameLgt - 1)
                    sqlPartPraKey += string.Format("'{0}' AND ", objCommon.GetSafeSqlText(false, tm.KeyColumnsText[i]));
                else
                    sqlPartPraKey += string.Format("'{0}'     ", objCommon.GetSafeSqlText(false, tm.KeyColumnsText[i]));
            }
            if (string.IsNullOrEmpty(sqlPartPraKey)) return 0;

            CommandSqlText = string.Format("UPDATE {0} SET {1} WHERE {2}", sqlTableName, sqlPartNormal, sqlPartPraKey);
            return sqlExecutant.ExecModifyCmd(CommandSqlText);
        }

        /// <summary>
        /// single record is deleted
        /// 删除单笔记录
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public int ExecDeleteCmd(TableMstr tm)
        {
            int KeyColNameLgt = tm.KeyColumnsName.Length;
            int KeyColTextLgt = tm.KeyColumnsText.Length;
            string sqlTableName = tm.TableName;
            string sqlPartPraKey = string.Empty;

            for (int i = 0; (KeyColNameLgt == KeyColTextLgt && KeyColNameLgt != 0 && i < KeyColNameLgt); i++)
            {
                sqlPartPraKey += string.Format("{0}=", tm.KeyColumnsName[i]);
                if (i != KeyColNameLgt - 1)
                    sqlPartPraKey += string.Format("'{0}' AND ", objCommon.GetSafeSqlText(false, tm.KeyColumnsText[i]));
                else
                    sqlPartPraKey += string.Format("'{0}'     ", objCommon.GetSafeSqlText(false, tm.KeyColumnsText[i]));
            }
            if (string.IsNullOrEmpty(sqlPartPraKey)) return 0;

            CommandSqlText = string.Format("DELETE {0} WHERE {1}", sqlTableName, sqlPartPraKey);
            return sqlExecutant.ExecModifyCmd(CommandSqlText);
        }

        /// <summary>
        /// batch record is canceled
        /// 批次删除
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public int ExecCancelCmd(TableMstr tm)
        {
            int count = tm.IDTextList.Count;
            if (count == 0) return count;

            CommandSqlText = "BEGIN TRANSACTION ";
            foreach (string tempIDvalue in tm.IDTextList)
            {
                CommandSqlText += string.Format("DELETE FROM {0} WHERE {1}='{2}' IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ",
                    tm.TableName, tm.KeyColumnsName[0], objCommon.GetSafeSqlText(false, tempIDvalue.Trim()));
            }

            CommandSqlText += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN  ";
            return sqlExecutant.ExecModifyCmd(CommandSqlText);
        }
    }
}

