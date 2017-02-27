using System;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using Admin.SQLServerDAL;


namespace Admin.SQLServerDAL.CrystalReports_DAL
{
    public class CrystalReports
    {
        private string sql = "select * from information_schema.tables where table_type <> 'view' order by table_name ";
        SQLExecutant sc = new SQLExecutant();


      //  public static string strcon = ConfigurationManager.ConnectionStrings["SQLConnStringKey"].ConnectionString;
       // SqlConnection conn = null;
        public DataTable SelTab()
        {
            return sc.ExecQueryCmd(sql);
            //using (conn = new SqlConnection(strcon))
            //{
            //    using (SqlDataAdapter adap = new SqlDataAdapter(sql, conn))
            //    {
            //        using (DataSet ds = new DataSet())
            //        {
            //            conn.Open();
            //            try
            //            {
            //                adap.Fill(ds);
            //                return ds.Tables[0];
            //            }
            //            catch
            //            {
            //                conn.Close();
            //                return new DataTable();
            //            }
            //            finally
            //            {
            //                conn.Close();
            //            }
            //        }
            //    }
            //}
        }
        public DataTable SelCell(string tabname)
        {
            string sql2 = "select   distinct   sysobjects.[name]   as   [tblname],   syscolumns.colid,   syscolumns.[name]   as   [colname]  from   syscolumns,   sysobjects   where   sysobjects.id=syscolumns.id   and   sysobjects.[name]='" + tabname + "' ";
            return sc.ExecQueryCmd(sql2);
            //using (conn = new SqlConnection(strcon))
            //{
            //    using (DataSet ds = new DataSet())
            //    {
            //        using (SqlDataAdapter adap = new SqlDataAdapter(sql2, conn))
            //        {
            //            conn.Open();
            //            try
            //            {
            //                adap.Fill(ds);
            //                return ds.Tables[0];
            //            }
            //            catch
            //            {
            //                conn.Close();
            //                return new DataTable();
            //            }
            //            finally
            //            {
            //                conn.Close();
            //            }
            //        }
            //    }
            //}
        }
        public DataTable setsql(string sql)
        {
            return sc.ExecQueryCmd(sql);
            //string sql2 = sql;
            //using (conn = new SqlConnection(strcon))
            //{
            //    using (DataSet ds = new DataSet())
            //    {
            //        using (SqlDataAdapter adap = new SqlDataAdapter(sql2, conn))
            //        {
            //            conn.Open();
            //            try
            //            {
            //                adap.Fill(ds);
            //                return ds.Tables[0];
            //            }
            //            catch
            //            {
            //                conn.Close();
            //                return new DataTable();
            //            }
            //            finally
            //            {
            //                conn.Close();
            //            }
            //        }
            //    }
            //}
        }

    }
}
