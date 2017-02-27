using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.BaseInfo_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class CustomerInfo_DAL : ICustomerInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        const string SQL_SELECT = "SELECT ID, CustomerNo, CustomerName, LinkMan, Bank, Account, Tel, Fax, WebSite, EMail, OfficeAddr, WareHouse, BalanceKind, Remark FROM CustomerInfo WHERE 1=1 ";
        const string SQL_INSERT = "INSERT INTO CustomerInfo(CustomerNo, CustomerName, LinkMan, Bank, Account, Tel, Fax, WebSite, EMail, OfficeAddr, WareHouse, BalanceKind, Remark) VALUES(@CustomerNo, @CustomerName, @LinkMan, @Bank, @Account, @Tel, @Fax, @WebSite, @EMail, @OfficeAddr, @WareHouse, @BalanceKind, @Remark)";
        const string SQL_UPDATE = "UPDATE CustomerInfo SET CustomerName=@CustomerName, LinkMan=@LinkMan, Bank=@Bank, Account=@Account, Tel=@Tel, Fax=@Fax, WebSite=@WebSite, EMail=@EMail, OfficeAddr=@OfficeAddr, WareHouse=@WareHouse, BalanceKind=@BalanceKind, Remark=@Remark WHERE ID=@ID ";
        const string SQL_DELETE = "DELETE CustomerInfo WHERE ID=@ID";
        public IList<CustomerInfo_MDL> selectCustomerInfo() { return null; }
        public IList<CustomerInfo_MDL> selectCustomerInfo(int id) { return null; }
        public IList<CustomerInfo_MDL> selectCustomerInfo(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
            }

            return getListOfCustomerInfo(sqlWhere, sqlParas);
        }

        public IList<CustomerInfo_MDL> existsCustomerInfo(string CustomerNo)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format(" AND CustomerNo=@CustomerNo"));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@CustomerNo", SqlDbType.VarChar, CustomerNo) };

            return getListOfCustomerInfo(sqlWhere, sqlParas);
        }

        private IList<CustomerInfo_MDL> getListOfCustomerInfo(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            sqlCmd.Append(sqlWhere);

            IList<CustomerInfo_MDL> CustomerInfoList = new List<CustomerInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY CustomerNo").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    CustomerInfo_MDL CustomerInfo = new CustomerInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr["CustomerNo"] == DBNull.Value) ? "" : sdr["CustomerNo"].ToString().Trim(),
                        (sdr["CustomerName"] == DBNull.Value) ? "" : sdr["CustomerName"].ToString().Trim(),
                        (sdr["LinkMan"] == DBNull.Value) ? "" : sdr["LinkMan"].ToString().Trim(),
                        (sdr["Bank"] == DBNull.Value) ? "" : sdr["Bank"].ToString().Trim(),
                        (sdr["Account"] == DBNull.Value) ? "" : sdr["Account"].ToString().Trim(),

                        (sdr["Tel"] == DBNull.Value) ? "" : sdr["Tel"].ToString().Trim(),
                        (sdr["Fax"] == DBNull.Value) ? "" : sdr["Fax"].ToString().Trim(),
                        (sdr["WebSite"] == DBNull.Value) ? "" : sdr["WebSite"].ToString().Trim(),
                        (sdr["EMail"] == DBNull.Value) ? "" : sdr["EMail"].ToString().Trim(),
                        (sdr["OfficeAddr"] == DBNull.Value) ? "" : sdr["OfficeAddr"].ToString().Trim(),

                        (sdr["WareHouse"] == DBNull.Value) ? "" : sdr["WareHouse"].ToString().Trim(),
                        (sdr["BalanceKind"] == DBNull.Value) ? "" : sdr["BalanceKind"].ToString().Trim(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString().Trim()
                        );
                    CustomerInfoList.Add(CustomerInfo);
                }
            }
            return CustomerInfoList;
        }

        public void ChangeCustomerInfo(CustomerInfo_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@CustomerNo", SqlDbType.VarChar, obj.CustomerNo),
                fsp.FormatInParam("@CustomerName", SqlDbType.VarChar, obj.CustomerName),
                fsp.FormatInParam("@LinkMan", SqlDbType.VarChar, obj.LinkMan),
                fsp.FormatInParam("@Bank", SqlDbType.VarChar, obj.Bank),
                fsp.FormatInParam("@Account", SqlDbType.VarChar, obj.Account),
                fsp.FormatInParam("@Tel", SqlDbType.VarChar, obj.Tel),
                fsp.FormatInParam("@Fax", SqlDbType.VarChar, obj.Fax),
                fsp.FormatInParam("@WebSite", SqlDbType.VarChar, obj.WebSite),
                fsp.FormatInParam("@EMail", SqlDbType.VarChar, obj.EMail),
                fsp.FormatInParam("@OfficeAddr", SqlDbType.VarChar, obj.OfficeAddr),

                fsp.FormatInParam("@WareHouse", SqlDbType.VarChar, obj.WareHouse),
                fsp.FormatInParam("@BalanceKind", SqlDbType.VarChar, obj.BalanceKind),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark),
                fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID)
            };
            if (IU.ToUpper() == "INSERT") 
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else  
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }

        public void deleteCustomerInfo(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelCustomerInfo(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE CustomerInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
