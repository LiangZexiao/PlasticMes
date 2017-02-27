using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.BaseInfo_MDL;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface ICustomerInfo
    {
        IList<CustomerInfo_MDL> selectCustomerInfo();
        IList<CustomerInfo_MDL> selectCustomerInfo(int id);
        IList<CustomerInfo_MDL> selectCustomerInfo(int _ID, string colname, string coltext);
        IList<CustomerInfo_MDL> existsCustomerInfo(string _CustomerNo);
        //int insertCustomerInfo(string vCustomerNo, string vCustomerName, string vLinkMan, string vBank, string vAccount, string vTel, string vFax, string vWebSite, string vEMail, string vOfficeAddr,
        //     string vWareHouse, string vBalanceKind, string vRemark);
        void ChangeCustomerInfo(CustomerInfo_MDL obj, string IU);
        void deleteCustomerInfo(int _ID);
        void cancelCustomerInfo(ArrayList _IDList);
    }
}
