﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using Admin.DBUtility;

namespace Admin.OLDServerDAL
{

    public class ERPOldExecutant
    {
        public static readonly string CntStrLocal = OleDBHelper.CntStringOfdb;//连接服务器
        //public static readonly string CntStrLocal = ConfigurationManager.ConnectionStrings["SQLConnStringLocal"].ConnectionString;//连接本机

        OleDbConnection objConnection = new OleDbConnection(OleDBHelper.CntStringOfdb);//CntStrLocal);
        OleDbCommand objCommand = null;
        OleDbDataAdapter objDataAdapter = null;
        OleDbDataReader objDataReader = null;
        int AffectNum = 0;
        DataSet ds = null;

        public DataTable ExecQueryCmd(string strSQL)
        {
            try
            {
                objCommand = new OleDbCommand(strSQL, objConnection);
                objDataAdapter = new OleDbDataAdapter(objCommand);
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
                objCommand = new OleDbCommand(strSQL, objConnection);
                objDataAdapter = new OleDbDataAdapter(objCommand);
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
                objCommand = new OleDbCommand(strSQL, objConnection);
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
                objCommand = new OleDbCommand(strSQL, objConnection);
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

        public OleDbDataReader ExecuteReader(string strSQL)
        {
            try
            {
                objCommand = new OleDbCommand(strSQL, objConnection);
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

        public int ExecModifyCmd(string CommandInsertText, params OleDbParameter[] CommandParameters)
        {
            try
            {
                objCommand = new OleDbCommand(CommandInsertText, objConnection);
                foreach (OleDbParameter para in CommandParameters)
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


        public DataTable ExecQueryCmd(string CommandSPName, params OleDbParameter[] CommandParameters)
        {
            try
            {
                objCommand = new OleDbCommand(CommandSPName, objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;

                foreach (OleDbParameter para in CommandParameters)
                    objCommand.Parameters.Add(para);

                objDataAdapter = new OleDbDataAdapter(objCommand);
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
            objCommand = new OleDbCommand(ProcedureName, objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < PrameterName.Length; i++)
            {
               // objCommand.Parameters.Add(PrameterName[i], SqlDbType.Char);  rem by arthur
                objCommand.Parameters[PrameterName[i]].Value = ParameterText[i];
            }
            OleDbTransaction objTransaction = objConnection.BeginTransaction();
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
