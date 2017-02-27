using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Collect_MDL
{
    public class CardDetail_MDL
    {
        private int _iD;

        private string _doNo;

        private string _clientIP;

        private string _cardID;

        private string _cardType;

        private string _beginDate;

        private string _endDate;

        private string _createDate;

        private string _remark;

        private string _odlBeginDate;

        private string _odlEndDate;

        private string _odlCardType;


        public CardDetail_MDL() { }

        public CardDetail_MDL(int vID, string vDONO, string vClientIP, string vCardID, string vCardType, string vBeginDate, string vEndDate, string vCreateDate, string vRemark)
        {
            this.ID = vID;
            this.DoNo = vDONO;
            this.ClientIP = vClientIP;
            this.CardID = vCardID;
            this.CardType = vCardType;
            this.BeginDate = vBeginDate;
            this.EndDate = vEndDate;
            this.CreateDate = vCreateDate;
            this.Remark = vRemark;
        }

        public CardDetail_MDL(int vID, string vDONO, string vClientIP, string vCardID, string vCardType, string vBeginDate, string vEndDate, string vCreateDate, string vRemark,string vodlBeginDate,string vodlEndDate,string vodlCardType)
        {
            this.ID = vID;
            this.DoNo = vDONO;
            this.ClientIP = vClientIP;
            this.CardID = vCardID;
            this.CardType = vCardType;
            this.BeginDate = vBeginDate;
            this.EndDate = vEndDate;
            this.CreateDate = vCreateDate;
            this.Remark = vRemark;
            this.OdlBeginDate = vodlBeginDate;
            this.OdlEndDate = vodlEndDate;
            this.OdlCardType = vodlCardType;
        }


        public int ID
        {
            get
            {
                return this._iD;
            }
            set
            {
                this._iD = value;
            }
        }


        public string DoNo
        {
            get
            {
                return this._doNo;
            }
            set
            {
                this._doNo = value;
            }
        }


        public string ClientIP
        {
            get
            {
                return this._clientIP;
            }
            set
            {
                this._clientIP = value;
            }
        }


        public string CardID
        {
            get
            {
                return this._cardID;
            }
            set
            {
                this._cardID = value;
            }
        }


        public string CardType
        {
            get
            {
                return this._cardType;
            }
            set
            {
                this._cardType = value;
            }
        }


        public string BeginDate
        {
            get
            {
                return this._beginDate;
            }
            set
            {
                this._beginDate = value;
            }
        }


        public string EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }


        public string CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }


        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }
        public string OdlEndDate
        {
            get { return _odlEndDate; }
            set { _odlEndDate = value; }
        }

        public string OdlBeginDate
        {
            get { return _odlBeginDate; }
            set { _odlBeginDate = value; }
        }


        public string OdlCardType
        {
            get { return _odlCardType; }
            set { _odlCardType = value; }
        }


    }
}
