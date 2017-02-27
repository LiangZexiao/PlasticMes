using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class OrderMstr_MDL:LikeQuery
   {
        private int v_ID;
        //private ArrayList v_IDs;
        private string v_OrderNO;
        private string v_ItemNO;
        private string v_ItemName;
        private string v_OrderNum;
        private string v_Customer;
        private string v_DeliveryDate;
        private string v_PreDate;
        private string v_DelayDate;
        private string v_OrderStatus;

        private string v_CompleteNum = "0";
        private string v_WOFlag;
        private string v_CheckFlag;
        private string v_Checker;
        private string v_CheckDate;
        private string v_Remark;

        private string v_Creater;
        private string v_CreateDate;
        private string v_SumQty;
        private string v_SumNum;
        private string v_StandNum;
        private string v_MtlNum;

       public OrderMstr_MDL() {}
       public OrderMstr_MDL(int vID,
               string vOrderNO,
               string vItemNO,
               string vItemName,
               string vCustomer,
               string vOrderNum,
               string vDeliveryDate,
               string vPreDate,
               string vDelayDate,
               string vOrderStatus,

               string vCompleteNum,
               string vCreater,
               string vWOFlag,
               string vCheckFlag,
               string vChecker,
               string vCreateDate,
               string vRemark,
               string vCheckDate
          )
        {
            this.v_ID = vID;
            this.v_OrderNO = vOrderNO;
            this.v_ItemNO = vItemNO;
            this.v_ItemName = vItemName;
            this.v_Customer = vCustomer;
            this.v_OrderNum = vOrderNum;
            this.v_DeliveryDate = vDeliveryDate;
            this.v_PreDate = vPreDate;
            this.v_DelayDate = vDelayDate;
            this.v_OrderStatus = vOrderStatus;

            this.v_CompleteNum = vCompleteNum;
            this.v_Creater = vCreater;
            this.v_WOFlag = vWOFlag;
            this.v_CheckFlag = vCheckFlag;
            this.v_Checker = vChecker;
            this.v_CreateDate = vCreateDate;
            this.v_Remark = vRemark;
            this.v_CheckDate = vCheckDate;
        }


        public OrderMstr_MDL(int vID,
              string vOrderNO,
              string vItemNO,
              string vItemName,
              string vCustomer,
              string vOrderNum,
              string vDeliveryDate,
              string vPreDate,
              string vDelayDate,
              string vOrderStatus,

              string vCompleteNum,
              string vCreater,
              string vWOFlag,
              string vCheckFlag,
              string vChecker,
              string vCreateDate,
              string vRemark,
              string vCheckDate,
              string vSumQty,
              string vSumNum
         )
        {
            this.v_ID = vID;
            this.v_OrderNO = vOrderNO;
            this.v_ItemNO = vItemNO;
            this.v_ItemName = vItemName;
            this.v_Customer = vCustomer;
            this.v_OrderNum = vOrderNum;
            this.v_DeliveryDate = vDeliveryDate;
            this.v_PreDate = vPreDate;
            this.v_DelayDate = vDelayDate;
            this.v_OrderStatus = vOrderStatus;

            this.v_CompleteNum = vCompleteNum;
            this.v_Creater = vCreater;
            this.v_WOFlag = vWOFlag;
            this.v_CheckFlag = vCheckFlag;
            this.v_Checker = vChecker;
            this.v_CreateDate = vCreateDate;
            this.v_Remark = vRemark;
            this.v_CheckDate = vCheckDate;
            this.v_SumQty = vSumQty;//已生产的数量
            this.v_SumNum = vSumNum;//已入库的数量
        }

        public OrderMstr_MDL(int vID,
              string vOrderNO,
              string vItemNO,
              string vItemName,
              string vCustomer,
              string vOrderNum,
              string vDeliveryDate,
              string vPreDate,
              string vDelayDate,
              string vOrderStatus,

              string vCompleteNum,
              string vCreater,
              string vWOFlag,
              string vCheckFlag,
              string vChecker,
              string vCreateDate,
              string vRemark,
              string vCheckDate,
              string vStandNum,
              string vMtlNum,
              string vFlagField
         )
        {
            this.v_ID = vID;
            this.v_OrderNO = vOrderNO;
            this.v_ItemNO = vItemNO;
            this.v_ItemName = vItemName;
            this.v_Customer = vCustomer;
            this.v_OrderNum = vOrderNum;
            this.v_DeliveryDate = vDeliveryDate;
            this.v_PreDate = vPreDate;
            this.v_DelayDate = vDelayDate;
            this.v_OrderStatus = vOrderStatus;

            this.v_CompleteNum = vCompleteNum;
            this.v_Creater = vCreater;
            this.v_WOFlag = vWOFlag;
            this.v_CheckFlag = vCheckFlag;
            this.v_Checker = vChecker;
            this.v_CreateDate = vCreateDate;
            this.v_Remark = vRemark;
            this.v_CheckDate = vCheckDate;
            this.v_StandNum = vStandNum;//已生产的数量
            this.v_MtlNum = vMtlNum;//已入库的数量
        }

        public int ID
        {
           get { return v_ID; }
           set { v_ID = value; }
        }
        public string OrderNO
        {
           get { return v_OrderNO; }
           set { v_OrderNO = value; }
        }
        public string ItemNo
        {
           get { return v_ItemNO; }
           set { v_ItemNO = value; }
        }

        public string ItemName
        {
            get { return v_ItemName; }
            set { v_ItemName = value; }
        }

        public string Customer
        {
            get { return v_Customer; }
            set { v_Customer = value; }
        }

        public string OrderNum
        {
           get { return v_OrderNum; }
           set { v_OrderNum = value; }
        }

        public string DeliveryDate
        {
           get { return v_DeliveryDate; }
           set { v_DeliveryDate = value; }
        }

        public string PreDate
        {
           get { return v_PreDate; }
           set { v_PreDate = value; }
        }

        public string DelayDate
        {
           get { return v_DelayDate; }
           set { v_DelayDate = value; }
        }

        public string OrderStatus
        {
           get { return v_OrderStatus; }
           set { v_OrderStatus = value; }
        }

        public string CompleteNum
        {
           get { return v_CompleteNum; }
           set { v_CompleteNum = value; }
        }

        public string WOFlag
        {
           get { return v_WOFlag; }
           set { v_WOFlag = value; }
        }

        public string CheckFlag
        {
           get { return v_CheckFlag; }
           set { v_CheckFlag = value; }
        }

        public string Checker
        {
           get { return v_Checker; }
           set { v_Checker = value; }
        }
        public string Remark
        {
           get { return v_Remark; }
           set { v_Remark = value; }
        }

        public string Creater
        {
           get { return v_Creater; }
           set { v_Creater = value; }
        }

        public string CreateDate
        {
           get { return v_CreateDate; }
           set { v_CreateDate = value; }
        }
        public string CheckDate
        {
            get { return v_CheckDate; }
            set { v_CheckDate = value; }
        }

        public string SumQty
        {
            get { return v_SumQty; }
            set { v_SumQty = value; }
        }

        public string SumNum
        {
            get { return v_SumNum; }
            set { v_SumNum = value; }
        }

        
        public string StandNum
        {
            get { return v_StandNum; }
            set { v_StandNum = value; }
        }

        public string MtlNum
        {
            get { return v_MtlNum; }
            set { v_MtlNum = value; }
        }

   }
}
