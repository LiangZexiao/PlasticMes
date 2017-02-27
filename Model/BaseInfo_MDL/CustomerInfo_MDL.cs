using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class CustomerInfo_MDL : LikeQuery
    {
        private int _ID;
        private string _CustomerNo;
        private string _CustomerName;
        private string _LinkMan;
        private string _Bank;
        private string _Account;
        private string _Tel;
        private string _Fax;
        private string _WebSite;
        private string _EMail;
        private string _OfficeAddr;
        private string _WareHouse;
        private string _BalanceKind;
        private string _Remark;

        public CustomerInfo_MDL() {}
        public CustomerInfo_MDL(int vID,
             string vCustomerNo,string vCustomerName,string vLinkMan,string vBank,string vAccount,
             string vTel,string vFax,string vWebSite,string vEMail,string vOfficeAddr,
             string vWareHouse,string vBalanceKind,string vRemark)
        {
            this._ID = vID;
            this._CustomerNo = vCustomerNo;
            this._CustomerName = vCustomerName;
            this._LinkMan = vLinkMan;
            this._Bank = vBank;
            this._Account = vAccount;
            this._Tel = vTel;
            this._Fax = vFax;
            this._WebSite = vWebSite;
            this._EMail = vEMail;
            this._OfficeAddr = vOfficeAddr;

            this._WareHouse = vWareHouse;
            this._BalanceKind = vBalanceKind;
            this._Remark = vRemark;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string CustomerNo
        {
            get { return _CustomerNo; }
            set { _CustomerNo = value; }
        }

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public string LinkMan
        {
            get { return _LinkMan; }
            set { _LinkMan = value; }
        }

        public string Bank
        {
            get { return _Bank; }
            set { _Bank = value; }
        }

        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        public string WebSite
        {
            get { return _WebSite; }
            set { _WebSite = value; }
        }

        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        public string OfficeAddr
        {
            get { return _OfficeAddr; }
            set { _OfficeAddr = value; }
        }

        public string WareHouse
        {
            get { return _WareHouse; }
            set { _WareHouse = value; }
        }

        public string BalanceKind
        {
            get { return _BalanceKind; }
            set { _BalanceKind = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

    }
}
