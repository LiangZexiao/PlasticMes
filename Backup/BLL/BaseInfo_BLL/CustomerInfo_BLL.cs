using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.BaseInfo_MDL;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.IDAL.BaseInfo_IDAL; 

namespace Admin.BLL.BaseInfo_BLL
{
    public class CustomerInfo_BLL
    {
        private static readonly ICustomerInfo factory = Admin.DALFactory.DataAccess.selectCustomerInfo();
        public static IList<CustomerInfo_MDL> selectCustomerInfo(int _ID, string colname, string coltext)
        {
            return factory.selectCustomerInfo(_ID, colname, coltext);
        }

        public static IList<CustomerInfo_MDL> existsCustomerInfo(string _CustomerNo)
        {
            return factory.existsCustomerInfo(_CustomerNo);
        }

        public static void ChangeCustomerInfo(int ID,
             string vCustomerNo, string vCustomerName, string vLinkMan, string vBank, string vAccount, string vTel, string vFax, string vWebSite, string vEMail, string vOfficeAddr,
             string vWareHouse, string vBalanceKind, string vRemark, string IU)
        {
            CustomerInfo_MDL obj = new CustomerInfo_MDL(ID,
             vCustomerNo, vCustomerName, vLinkMan, vBank, vAccount, vTel, vFax, vWebSite, vEMail, vOfficeAddr,
             vWareHouse, vBalanceKind, vRemark);
            factory.ChangeCustomerInfo(obj, IU);
        }

        public static void deleteCustomerInfo(int _id)
        {
            factory.deleteCustomerInfo(_id);
        }

        public static void cancelCustomerInfo(ArrayList _idlist)
        {
            factory.cancelCustomerInfo(_idlist);
        }
    }
}
