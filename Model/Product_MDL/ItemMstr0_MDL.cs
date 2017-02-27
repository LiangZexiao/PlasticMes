using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
   public class ItemMstr0_MDL:LikeQuery
    {
        private int v_ID;

        private string v_Item_Code;
        private string v_Item_NameCH;
        private string v_Item_NameEN;
        private string v_MouldNo;
        private string v_Item_UOM;
        private string v_Item_Color;
        private string v_Item_PreTime;
        private string v_Item_Weight;
        private string v_Item_WaterGapScale;
        private string v_Item_WaterGapWeight;

        private string v_Item_Ration; 
        private string v_Item_PreBadness;
        private string v_Item_LossRate;
        private string v_Item_SetUpTime;
        private string v_Item_InjectCycle;
        private string v_Item_MinInjectCycle;
        private string v_Item_MaxInjectCycle;
        private string v_Creater;
        private string v_VerNo;
        private string v_CreateDate;
        private string v_Remark;

       public ItemMstr0_MDL() {}
       public ItemMstr0_MDL(int vID,
             string vItem_Code,
             string vItem_NameCH,
             string vItem_NameEN,
             string vMouldNo,
             string vItem_UOM,
             string vItem_PreTime,
             string vItem_Weight,
             string vItem_WaterGapScale,
             string vItem_WaterGapWeight,
             string vItem_Ration,
             string vItem_PreBadness,
             string vItem_LossRate,
             string vItem_SetUpTime,
             string vItem_InjectCycle,
             string vItem_MinInjectCycle,
             string vItem_MaxInjectCycle,
             string vCreater,
             string vVerNo,
             string vCreateDate,
             string vRemark,
             string vItem_Color)
        {
            this.v_ID = vID;
            this.v_Item_Code = vItem_Code;
            this.v_Item_NameCH = vItem_NameCH;
            this.v_Item_NameEN = vItem_NameEN;
            this.v_MouldNo = vMouldNo;
            this.v_Item_UOM = vItem_UOM;
            this.v_Item_PreTime = vItem_PreTime;
            this.v_Item_Weight = vItem_Weight;
            this.v_Item_WaterGapScale = vItem_WaterGapScale;
            this.v_Item_WaterGapWeight = vItem_WaterGapWeight;

            this.v_Item_Ration = vItem_Ration;
            this.v_Item_PreBadness = vItem_PreBadness;
            this.v_Item_LossRate = vItem_LossRate;
            this.v_Item_SetUpTime = vItem_SetUpTime;
            this.v_Item_InjectCycle = vItem_InjectCycle;
            this.v_Item_MinInjectCycle = vItem_MinInjectCycle;
            this.v_Item_MaxInjectCycle = vItem_MaxInjectCycle;
            this.v_Creater = vCreater;
            this.v_VerNo = vVerNo;
            this.v_CreateDate = vCreateDate;
            this.v_Remark = vRemark;
            this.v_Item_Color = vItem_Color;
        }
       
       public int ID
       {
           get { return v_ID; }
           set { v_ID = value; }
       }

       public string Item_Code
       {
           get { return v_Item_Code; }
           set { v_Item_Code = value; }
       }

       public string Item_NameCH
       {
           get { return v_Item_NameCH; }
           set { v_Item_NameCH = value; }
       }

       public string Item_NameEN
       {
           get { return v_Item_NameEN; }
           set { v_Item_NameEN = value; }
       }

       public string MouldNo
       {
           get { return v_MouldNo; }
           set { v_MouldNo = value; }
       }

       public string Item_UOM
       {
           get { return v_Item_UOM; }
           set { v_Item_UOM = value; }
       }

       public string Item_Color
       {
           get { return v_Item_Color; }
           set { v_Item_Color = value; }
       }

       public string Item_PreTime
       {
           get { return v_Item_PreTime; }
           set { v_Item_PreTime = value; }
       }

       public string Item_Weight
       {
           get { return v_Item_Weight; }
           set { v_Item_Weight = value; }
       }

       public string Item_WaterGapScale
       {
           get { return v_Item_WaterGapScale; }
           set { v_Item_WaterGapScale = value; }
       }

       public string Item_WaterGapWeight
       {
           get { return v_Item_WaterGapWeight; }
           set { v_Item_WaterGapWeight = value; }
       }

       public string Item_Ration
       {
           get { return v_Item_Ration; }
           set { v_Item_Ration = value; }
       }

       public string Item_PreBadness
       {
           get { return v_Item_PreBadness; }
           set { v_Item_PreBadness = value; }
       }

       public string Item_LossRate
       {
           get { return this.v_Item_LossRate; }
           set { this.v_Item_LossRate = value; }
       }

       public string Item_SetUpTime
       {
           get { return v_Item_SetUpTime; }
           set { v_Item_SetUpTime = value; }
       }

       public string Item_InjectCycle
       {
           get { return v_Item_InjectCycle; }
           set { v_Item_InjectCycle = value; }
       }

       public string Item_MinInjectCycle
       {
           get { return v_Item_MinInjectCycle; }
           set { v_Item_MinInjectCycle = value; }
       }

       public string Item_MaxInjectCycle
       {
           get { return v_Item_MaxInjectCycle; }
           set { v_Item_MaxInjectCycle = value; }
       }

       public string Creater
       {
           get { return v_Creater; }
           set { v_Creater = value; }
       }

       public string VerNo
       {
           get { return v_VerNo; }
           set { v_VerNo = value; }
       }

       public string CreateDate
       {
           get { return v_CreateDate; }
           set { v_CreateDate = value; }
       }

       public string Remark
       {
           get { return v_Remark; }
           set { v_Remark = value; }
       }

    }
}
