using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Security;
using CryptLby;
using System.Data.OleDb;

namespace Admin.DBUtility
{
    public abstract class SqlHelper
    {
        static string Key = @"&%#@?,:*";
        static string EncryptString = "";

        //Database connection strings
        public static string tmpCntStringOfdb = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        public static string CntStringOfdb = tmpCntStringOfdb;
        public static string RSAofCntStrOfdb = tmpCntStringOfdb;

        /// <summary>
        /// DES获取"加密"字符串
        /// </summary>
        private static void EncryptWebConfig()
        {
            EncryptString = new Cryption().Encrypt(tmpCntStringOfdb, Key);
        }
        /// <summary>
        /// DES获取"解密"字符串
        /// </summary>
        private static void DecryptWebConfig()
        {
            CntStringOfdb = new Cryption().Decrypt(tmpCntStringOfdb, Key);
        }

        //Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;

            using (SqlConnection conn = new SqlConnection(@CntStringOfdb))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                try
                {
                    val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Dispose();
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return -1;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public static int ExecuteNonQuery2(CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            SqlConnection conn = new SqlConnection(@CntStringOfdb);
            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                cmd.Parameters.Add("@a", SqlDbType.Int);
                cmd.Parameters["@a"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int val = Convert.ToInt32(cmd.Parameters["@a"].Value);
                cmd.Parameters.Clear();
                return val;
            }
            catch (Exception ex)
            {
                conn.Dispose(); ;
                cmd.Dispose();
                string ErrMsg = ex.Message.ToString();
                return -1;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            //EncryptWebConfig();//加密

            //DecryptWebConfig();//解密

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(CntStringOfdb);
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
                conn.Dispose(); ;
                cmd.Dispose();
                string ErrMsg = ex.Message.ToString();
                return null;
            }
        }

        public static DataTable ReturnTableValue(CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                try
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    ad.SelectCommand = cmd;
                    ad.Fill(ds, "tablecol");
                    cmd.Parameters.Clear();
                    return ds.Tables["tablecol"];
                }
                catch (Exception ex)
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return new DataTable();
                }

            }
        }

        public static DataSet ReturnDataSet(CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                try
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    ad.SelectCommand = cmd;
                    ad.Fill(ds);

                    cmd.Parameters.Clear();
                    return ds;
                }
                catch (Exception ex)
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return new DataSet();
                }

            }
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                try
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return null;
                }

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
        public static int ExecuteNonQuery(string cmdConStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            using (SqlConnection conn = new SqlConnection(cmdConStr))
            {
                try
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return -1;
                }
                finally
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                }
            }
        }

        public static SqlDataReader ExecuteReader(string cmdConStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            SqlConnection conn = new SqlConnection(cmdConStr);

            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception ex)
            {
                conn.Dispose(); ;
                cmd.Dispose();
                string ErrMsg = ex.Message.ToString();
                return null;
            }

        }

        public static DataTable ReturnTableValue(string cmdConStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            using (SqlConnection conn = new SqlConnection(cmdConStr))
            {
                try
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ad.SelectCommand = cmd;
                    ad.Fill(ds, "tablecol");
                    cmd.Parameters.Clear();
                    return ds.Tables["tablecol"];
                }
                catch (Exception ex)
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return new DataTable();
                }
            }
        }


        public static object ExecuteScalar(string cmdConStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParas)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            using (SqlConnection conn = new SqlConnection(cmdConStr))
            {
                try
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParas);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Dispose(); ;
                    cmd.Dispose();
                    string ErrMsg = ex.Message.ToString();
                    return null;
                }
            }
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>

        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParas)
        {
            parmCache[cacheKey] = cmdParas;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        private static void PrepareCommand(SqlCommand cmdObj, SqlConnection cmdConn, CommandType cmdType, string cmdText, SqlParameter[] cmdParas)
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
                    foreach (SqlParameter para in cmdParas)
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

        public static void execProcedure(string procedure)
        {
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                SqlCommand cmd = new SqlCommand(procedure, conn);
                cmd.CommandTimeout = 3600;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public static DataTable execSMSDetail(string sql)
        {
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    conn.Dispose();
                    return new DataTable();
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public static int UpdateSMSDetailStatus(int id)
        {
            string SQL = "update SMSDetail set [Status]=1,HandleTime=getdate() where ID={0}";
            SQL = string.Format(SQL, id);
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = CntStringOfdb;
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(SQL, conn);
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
            }
        }


        public static DataTable ReturnTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(CntStringOfdb))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    conn.Dispose();
                    return new DataTable();
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
    }
}