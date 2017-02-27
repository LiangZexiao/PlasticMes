using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;

namespace Admin.SQLServerDAL
{
    public class ERPSQLExecutant
    {
        public static readonly string CntStrLocal = ERPSQLHelper.CntStringOfdb;//连接服务器
        //public static readonly string CntStrLocal = ConfigurationManager.ConnectionStrings["SQLConnStringLocal"].ConnectionString;//连接本机

        SqlConnection objConnection = new SqlConnection(ERPSQLHelper.CntStringOfdb);//CntStrLocal);
        SqlCommand objCommand = null;
        SqlDataAdapter objDataAdapter = null;
        SqlDataReader objDataReader = null;
        int AffectNum = 0;
        DataSet ds = null;

        public DataTable ExecQueryCmd(string strSQL)
        {
            try
            {
                objCommand = new SqlCommand(strSQL, objConnection);
                objDataAdapter = new SqlDataAdapter(objCommand);
                ds = new DataSet();
                objDataAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch
            {
                throw;
            }
        }
        public DataSet ExecQueryCmd2(string strSQL)
        {
            try
            {
                objCommand = new SqlCommand(strSQL, objConnection);
                objDataAdapter = new SqlDataAdapter(objCommand);
                ds = new DataSet();
                objDataAdapter.Fill(ds);
                return ds;
            }
            catch
            {
                throw;
            }
        }
        public int ExecNoQueryCmd(string strSQL)
        {
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand(strSQL, objConnection);
                return objCommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }


        public int ExecModifyCmd(string strSQL)
        {
            try
            {
                objCommand = new SqlCommand(strSQL, objConnection);
                objCommand.Connection.Open();
                AffectNum = objCommand.ExecuteNonQuery();
                objCommand.Connection.Close();
                return AffectNum;
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ExecuteReader(string strSQL)
        {
            try
            {
                objCommand = new SqlCommand(strSQL, objConnection);
                objCommand.Connection.Open();
                objDataReader = objCommand.ExecuteReader();
                return objDataReader;
            }
            catch
            {
                objCommand.Connection.Close();
                throw;
            }
            finally
            {
                objCommand.Connection.Close();
            }
        }

        public int ExecModifyCmd(string CommandInsertText, params SqlParameter[] CommandParameters)
        {
            try
            {
                objCommand = new SqlCommand(CommandInsertText, objConnection);
                foreach (SqlParameter para in CommandParameters)
                {
                    if (!para.ParameterName.StartsWith("@"))
                        para.ParameterName = "@" + para.ParameterName;
                    objCommand.Parameters.Add(para);
                }

                objCommand.Connection.Open();
                AffectNum = objCommand.ExecuteNonQuery();
                objCommand.Connection.Close();
                return AffectNum;
            }
            catch
            {
                throw;
            }
        }


        public DataTable ExecQueryCmd(string CommandSPName, params SqlParameter[] CommandParameters)
        {
            try
            {
                objCommand = new SqlCommand(CommandSPName, objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter para in CommandParameters)
                    objCommand.Parameters.Add(para);

                objDataAdapter = new SqlDataAdapter(objCommand);
                ds = new DataSet();
                objDataAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch
            {
                throw;
            }
        }


        public string ExecModifyCmd(string ProcedureName, string[] PrameterName, string[] ParameterText)
        {
            objCommand = new SqlCommand(ProcedureName, objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < PrameterName.Length; i++)
            {
                objCommand.Parameters.Add(PrameterName[i], SqlDbType.Char);
                objCommand.Parameters[PrameterName[i]].Value = ParameterText[i];
            }
            SqlTransaction objTransaction = objConnection.BeginTransaction();
            objCommand.Transaction = objTransaction;
            try
            {
                objCommand.ExecuteNonQuery();
                objTransaction.Commit();
                return "success";
            }
            catch
            {
                objTransaction.Rollback();
                throw;
            }
        }
    }
}
