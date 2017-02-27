using System;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Security;
using System.Data.OleDb;

namespace Admin.DBUtility
{
    public abstract class OleDBHelper
    {
        static string Key = @"&%#@?,:*";
        static string EncryptString = "";

        //Database connection strings
        public static string tmpCntStringOfdb = ConfigurationManager.ConnectionStrings["ERPSQLConnString"].ConnectionString;
        public static string CntStringOfdb = tmpCntStringOfdb;
        public static string RSAofCntStrOfdb = tmpCntStringOfdb;

        /// <summary>
        /// DES获取"加密"字符串
        /// </summary>
        private static void EncryptWebConfig()
        {
            EncryptString = tmpCntStringOfdb; //new Cryption().Encrypt(tmpCntStringOfdb, Key);
        }
        /// <summary>
        /// DES获取"解密"字符串
        /// </summary>
        private static void DecryptWebConfig()
        {
            CntStringOfdb = tmpCntStringOfdb;// new Cryption().Decrypt(tmpCntStringOfdb, Key);
        }

        //Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(@CntStringOfdb))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        public static int ExecuteNonQuery2(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(@CntStringOfdb);

            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
            cmd.Parameters.Add("@a", OleDbType.Integer);
            cmd.Parameters["@a"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int val = Convert.ToInt32(cmd.Parameters["@a"].Value);
            cmd.Parameters.Clear();
            return val;

        }

        public static OleDbDataReader ExecuteReader(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            //EncryptWebConfig();//加密
            //DecryptWebConfig();//解密

            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader rdr = null;
            OleDbConnection conn = new OleDbConnection(CntStringOfdb);
            conn.Open();
            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception ex)
            {
                conn.Close();
                cmd.Dispose();
                rdr = null;
                return rdr;
                //throw;
            }
        }

        public static DataTable ReturnTableValue(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(CntStringOfdb))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                OleDbDataAdapter ad = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                ad.SelectCommand = cmd;
                ad.Fill(ds, "tablecol");

                cmd.Parameters.Clear();
                return ds.Tables["tablecol"];
            }
        }

        public static DataSet ReturnDataSet(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(CntStringOfdb))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                OleDbDataAdapter ad = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                ad.SelectCommand = cmd;
                ad.Fill(ds);

                cmd.Parameters.Clear();
                return ds;
            }
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(CntStringOfdb))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        //*********************************************************************************************
        //
        //之前的代码
        //多一个连接字符串的参数,
        //*********************************************************************************************
        /// <summary>
        /// 执行修改资料库
        /// </summary>
        /// <param name="cmdConStr"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdConStr, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(cmdConStr))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static OleDbDataReader ExecuteReader(string cmdConStr, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(cmdConStr);

            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable ReturnTableValue(string cmdConStr, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(cmdConStr))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                OleDbDataAdapter ad = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ad.SelectCommand = cmd;
                ad.Fill(ds, "tablecol");

                cmd.Parameters.Clear();
                return ds.Tables["tablecol"];
            }
        }

        public static object ExecuteScalar(string cmdConStr, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParas)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(cmdConStr))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of OleDbParamters to be cached</param>

        public static void CacheParameters(string cacheKey, params OleDbParameter[] cmdParas)
        {
            parmCache[cacheKey] = cmdParas;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached OleDbParamters array</returns>
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        private static void PrepareCommand(OleDbCommand cmdObj, OleDbConnection cmdConn, CommandType cmdType, string cmdText, OleDbParameter[] cmdParas)
        {
            try
            {
                if (cmdConn.State != ConnectionState.Open)
                    cmdConn.Open();

                cmdObj.Connection = cmdConn;
                cmdObj.CommandText = cmdText;
                cmdObj.CommandType = cmdType;

                if (cmdParas != null)
                {
                    foreach (OleDbParameter para in cmdParas)
                    {
                        if (!para.ParameterName.StartsWith("@"))
                            para.ParameterName = "@" + para.ParameterName;
                        cmdObj.Parameters.Add(para);
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }
    }
}