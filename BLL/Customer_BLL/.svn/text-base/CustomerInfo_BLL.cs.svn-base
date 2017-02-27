using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Customer_MDL;
using Admin.SQLServerDAL.Customer_DAL;

namespace Admin.BLL.Customer_BLL
{
    public class CustomerInfo_BLL
    {
        CustomerInfo_DAL dalCustomerInfo = new CustomerInfo_DAL();
        public DataTable selectCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.selectCustomerInfo(mdlCustomerInfo);
        }

        public bool isexistpkCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.isexistpkCustomerInfo(mdlCustomerInfo);
        }

        public int insertCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.insertCustomerInfo(mdlCustomerInfo);
        }

        public int updateCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.updateCustomerInfo(mdlCustomerInfo);
        }

        public int deleteCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.deleteCustomerInfo(mdlCustomerInfo);
        }

        public int cancelCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.cancelCustomerInfo(mdlCustomerInfo);
        }

        public CustomerInfo_MDL chooseCustomerInfo(CustomerInfo_MDL mdlCustomerInfo)
        {
            return dalCustomerInfo.chooseCustomerInfo(mdlCustomerInfo);
        }
    }
}
