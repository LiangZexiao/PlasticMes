using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model;

namespace Admin.SQLServerDAL
{
    public class SQLPreparer
    {
        string CommandSqlText = string.Empty;
        SQLExecutant sqlExecutant = new SQLExecutant();
        DataOperator objDataOperator = new DataOperator();
        //******************************************************************
        //
        //组装成标准的sql语句
        //模拟执行标准的sql语句
        //
        //******************************************************************

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public DataTable ExecQueryCmd(TableMstr tm)
        {
            return objDataOperator.ExecQueryCmd(tm);
        }

        /// <summary>
        /// 组装新增记录的命令
        /// 最后执行INSERT命令
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="CommandSqlPara"></param>
        /// <returns></returns>
        public int ExecInsertCmd(TableMstr tm, params SqlParameter[] CommandSqlPara)
        {
            int ColNameLgt = tm.ColumnsName.Length, ColTextLgt = tm.ColumnsText.Length;
            string sqlTableName = tm.TableName;
            string sqlPartName = string.Empty, sqlPartText = string.Empty;

            for (int i = 0; (i < ColNameLgt && ColNameLgt == ColTextLgt); i++)
            {
                if (i != ColNameLgt - 1)
                {
                    sqlPartName += tm.ColumnsName[i] + ",";
                    sqlPartText += (tm.ColumnsText[i].StartsWith("@")) ? tm.ColumnsText[i] + "," : "@" + tm.ColumnsText[i] + ",";
                }
                else
                {
                    sqlPartName += tm.ColumnsName[i];
                    sqlPartText += (tm.ColumnsText[i].StartsWith("@")) ? tm.ColumnsText[i] : "@" + tm.ColumnsText[i];
                }
            }
            if (string.IsNullOrEmpty(sqlPartText)) return 0;

            CommandSqlText = string.Format("INSERT INTO {0} ({1}) VALUES({2})", sqlTableName, sqlPartName, sqlPartText);
            return sqlExecutant.ExecModifyCmd(CommandSqlText, CommandSqlPara);
        }

        /// <summary>
        /// 组装更新记录的命令
        /// 最后执行UPDATE命令
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="CommandSqlPara"></param>
        /// <returns></returns>
        public int ExecUpdateCmd(TableMstr tm, params SqlParameter[] CommandSqlPara)
        {
            int ColNameLgt = tm.ColumnsName.Length, ColTextLgt = tm.ColumnsText.Length;
            int KeyColNameLgt = tm.KeyColumnsName.Length, KeyColTextLgt = tm.KeyColumnsText.Length;
            string sqlTableName = tm.TableName;
            string sqlPartNormal = string.Empty, sqlPartPraKey = string.Empty;

            for (int i = 0; (i < ColNameLgt && ColNameLgt == ColTextLgt); i++)
            {
                sqlPartNormal += tm.ColumnsName[i] + "=";
                if (i != ColNameLgt - 1)
                    sqlPartNormal += (tm.ColumnsText[i].StartsWith("@")) ? tm.ColumnsText[i] + "," : "@" + tm.ColumnsText[i] + ",";
                else
                    sqlPartNormal += (tm.ColumnsText[i].StartsWith("@")) ? tm.ColumnsText[i] : "@" + tm.ColumnsText[i];
            }

            for (int i = 0; (i < KeyColNameLgt && KeyColNameLgt == KeyColTextLgt && KeyColNameLgt != 0); i++)
            {
                sqlPartPraKey += tm.KeyColumnsName[i] + "=";
                if (i != KeyColNameLgt - 1)
                    sqlPartPraKey += (tm.KeyColumnsText[i].StartsWith("@")) ? tm.KeyColumnsText[i] + " AND " : "@" + tm.KeyColumnsText[i] + " AND ";
                else
                    sqlPartPraKey += (tm.KeyColumnsText[i].StartsWith("@")) ? tm.KeyColumnsText[i] : "@" + tm.KeyColumnsText[i];
            }
            if (string.IsNullOrEmpty(sqlPartPraKey)) return 0;

            CommandSqlText = string.Format("UPDATE {0} SET {1} WHERE {2}", sqlTableName, sqlPartNormal, sqlPartPraKey);
            return sqlExecutant.ExecModifyCmd(CommandSqlText, CommandSqlPara);
        }

        /// <summary>
        /// 单笔记录删除
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public int ExecDeleteCmd(TableMstr tm)
        {
            return objDataOperator.ExecDeleteCmd(tm);
        }

        /// <summary>
        /// 批次删除
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public int ExecCancelCmd(TableMstr tm)
        {
            return objDataOperator.ExecCancelCmd(tm);
        }

        /// <summary>
        /// 组装新增记录的命令
        /// 最后返回INSERT命令的语句
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public string GetSqlInsertCmd(string tablename, string[] colname, string[] coltext)
        {
            int ColNameLgt = colname.Length, ColTextLgt = coltext.Length;
            string sqlTableName = tablename;
            string sqlPartName = string.Empty, sqlPartText = string.Empty;

            for (int i = 0; (i < ColNameLgt && ColNameLgt == ColTextLgt); i++)
            {
                if (i != ColNameLgt - 1)
                {
                    sqlPartName += colname[i] + ",";
                    sqlPartText += (coltext[i].StartsWith("@")) ? coltext[i] + "," : "@" + coltext[i] + ",";
                }
                else
                {
                    sqlPartName += colname[i];
                    sqlPartText += (coltext[i].StartsWith("@")) ? coltext[i] : "@" + coltext[i];
                }
            }
            if (string.IsNullOrEmpty(sqlPartText)) return string.Empty;

            CommandSqlText = string.Format("INSERT INTO {0} ({1}) VALUES({2})", sqlTableName, sqlPartName, sqlPartText);
            return CommandSqlText;
        }

        /// <summary>
        /// 组装更新记录的命令
        /// 最后返回UPDATE命令的语句
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public string GetSqlUpdateCmd(string tablename, string[] colname, string[] coltext, string[] colnamekey, string[] coltextkey)
        {
            int ColNameLgt = colname.Length, ColTextLgt = coltext.Length;
            int KeyColNameLgt = colnamekey.Length, KeyColTextLgt = coltextkey.Length;
            string sqlTableName = tablename;
            string sqlPartNormal = string.Empty, sqlPartPraKey = string.Empty;

            for (int i = 0; (i < ColNameLgt && ColNameLgt == ColTextLgt); i++)
            {
                sqlPartNormal += colname[i] + "=";
                if (i != ColNameLgt - 1)
                    sqlPartNormal += (coltext[i].StartsWith("@")) ? coltext[i] + "," : "@" + coltext[i] + ",";
                else
                    sqlPartNormal += (coltext[i].StartsWith("@")) ? coltext[i] : "@" + coltext[i];
            }

            for (int i = 0; (i < KeyColNameLgt && KeyColNameLgt == KeyColTextLgt && KeyColNameLgt != 0); i++)
            {
                sqlPartPraKey += colnamekey[i] + "=";
                if (i != KeyColNameLgt - 1)
                    sqlPartPraKey += (coltextkey[i].StartsWith("@")) ? coltextkey[i] + " AND " : "@" + coltextkey[i] + " AND ";
                else
                    sqlPartPraKey += (coltextkey[i].StartsWith("@")) ? coltextkey[i] : "@" + coltextkey[i];
            }
            if (string.IsNullOrEmpty(sqlPartPraKey)) return "";

            CommandSqlText = string.Format("UPDATE {0} SET {1} WHERE {2}", sqlTableName, sqlPartNormal, sqlPartPraKey);
            return CommandSqlText;
        }
    }
}