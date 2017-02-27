using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Customer_MDL;
using Admin.Model;

namespace Admin.SQLServerDAL.Customer_DAL
{
    public class CustomerInfo_DAL
    {
        TableMstr tm = new TableMstr();
        DataOperator objDataOperator = new DataOperator();

        const string TABLENAME = "chiefMes..CustomerInfo";
        string fID = "ID";
        string fCustomerNo = "CustomerNo";
        string fCustomerName = "CustomerName";
        string fLinkMan = "LinkMan";
        string fBank = "Bank";
        string fAccount = "Account";
        string fTel = "Tel";
        string fFax = "Fax";
        string fWebSite = "WebSite";
        string fEMail = "EMail";
        string fOfficeAddr = "OfficeAddr";
        string fWareHouse = "WareHouse";
        string fBalanceKind = "BalanceKind";
        string fRemark = "Remark";

        public DataTable selectCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            string[] ColumnsName = {fID,fCustomerNo,
                fCustomerName,
                fLinkMan,
                fBank,
                fAccount,
                fTel,
                fFax,
                fWebSite,
                fEMail,
                fOfficeAddr,
                fWareHouse,
                fBalanceKind,
                fRemark
            };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.LikeColumnsName = dboCustomerInfo.LikeFieldName;
            tm.LikeColumnsText = dboCustomerInfo.LikeFieldText;

            return objDataOperator.ExecQueryCmd(tm);
        }

        public bool isexistpkCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fCustomerNo };
            tm.KeyColumnsText = new string[1] { dboCustomerInfo.CustomerNo };

            return (objDataOperator.ExecQueryCmd(tm).Rows.Count != 0) ? false : true;
        }

        public CustomerInfo_MDL chooseCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            string[] ColumnsName = {fID,fCustomerNo,
                fCustomerName,
                fLinkMan,
                fBank,
                fAccount,
                fTel,
                fFax,
                fWebSite,
                fEMail,
                fOfficeAddr,
                fWareHouse,
                fBalanceKind,
                fRemark
            };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboCustomerInfo.ID };

            DataTable dt = objDataOperator.ExecQueryCmd(tm);
            CustomerInfo_MDL tempObject = new CustomerInfo_MDL(
                        dt.Rows[0][fCustomerNo].ToString().Trim(),
                        dt.Rows[0][fCustomerName].ToString().Trim(),
                        dt.Rows[0][fLinkMan].ToString().Trim(),
                        dt.Rows[0][fBank].ToString().Trim(),
                        dt.Rows[0][fAccount].ToString().Trim(),
                        dt.Rows[0][fTel].ToString().Trim(),
                        dt.Rows[0][fFax].ToString().Trim(),
                        dt.Rows[0][fWebSite].ToString().Trim(),
                        dt.Rows[0][fEMail].ToString().Trim(),
                        dt.Rows[0][fOfficeAddr].ToString().Trim(),
                        dt.Rows[0][fWareHouse].ToString().Trim(),
                        dt.Rows[0][fBalanceKind].ToString().Trim(),
                        dt.Rows[0][fRemark].ToString().Trim()
                );
            return tempObject;
        }

        public int insertCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            string[] ColumnsName = {fCustomerNo,                
                fCustomerName,
                fLinkMan,
                fBank,
                fAccount,
                fTel,
                fFax,
                fWebSite,
                fEMail,
                fOfficeAddr,
                fWareHouse,
                fBalanceKind,
                fRemark
            };
            string[] ColumnsText = {dboCustomerInfo.CustomerNo,                
                dboCustomerInfo.CustomerName,
                dboCustomerInfo.LinkMan,
                dboCustomerInfo.Bank,
                dboCustomerInfo.Account,
                dboCustomerInfo.Tel,
                dboCustomerInfo.Fax,
                dboCustomerInfo.WebSite,
                dboCustomerInfo.EMail,
                dboCustomerInfo.OfficeAddr,
                dboCustomerInfo.WareHouse,
                dboCustomerInfo.BalanceKind,
                dboCustomerInfo.Remark
            };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecInsertCmd(tm);
        }

        public int updateCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            string[] ColumnsName = {fCustomerNo,                
                fCustomerName,
                fLinkMan,
                fBank,
                fAccount,
                fTel,
                fFax,
                fWebSite,
                fEMail,
                fOfficeAddr,
                fWareHouse,
                fBalanceKind,
                fRemark
            };
            string[] ColumnsText = {dboCustomerInfo.CustomerNo,                
                dboCustomerInfo.CustomerName,
                dboCustomerInfo.LinkMan,
                dboCustomerInfo.Bank,
                dboCustomerInfo.Account,
                dboCustomerInfo.Tel,
                dboCustomerInfo.Fax,
                dboCustomerInfo.WebSite,
                dboCustomerInfo.EMail,
                dboCustomerInfo.OfficeAddr,
                dboCustomerInfo.WareHouse,
                dboCustomerInfo.BalanceKind,
                dboCustomerInfo.Remark
            };

            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboCustomerInfo.ID };
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecUpdateCmd(tm);
        }

        public int deleteCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboCustomerInfo.ID };
            return objDataOperator.ExecDeleteCmd(tm);
        }

        public int cancelCustomerInfo(CustomerInfo_MDL dboCustomerInfo)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.IDTextList = dboCustomerInfo.IDs;

            return objDataOperator.ExecCancelCmd(tm);
        }
    }
}
