using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Machine_MDL
{
    public class MachineStatusConfig_MDL:LikeQuery
    {
        private string v_ID;
        private ArrayList v_IDs;
        private string v_StatusID;        
        private string v_StatusName;
        private string v_Img;
        private byte[] v_Imgs;
        private object v_ImgType;
        private string v_Color;
        private string v_Memo;

        public MachineStatusConfig_MDL() {}
        public MachineStatusConfig_MDL(ArrayList vIDs) { this.v_IDs = vIDs; }
        public MachineStatusConfig_MDL(
            string vStatusID,
            string vStatusName,
            byte[] vImgs,
            object vImgType,
            string vColor,
            string vMemo)
        {
            this.v_StatusID = vStatusID;
            this.v_StatusName = vStatusName;
            this.v_Imgs = vImgs;
            this.v_ImgType = vImgType;
            this.v_Color = vColor;
            this.v_Memo = vMemo;
        }
        public MachineStatusConfig_MDL(
            string vID,
            string vStatusID,
            string vStatusName,
            byte[] vImgs,
            object vImgType,
            string vColor,
            string vMemo)
        {
            this.v_ID = vID;
            this.v_StatusID = vStatusID;
            this.v_StatusName = vStatusName;
            this.v_Imgs = vImgs;
            this.v_ImgType = vImgType;
            this.v_Color = vColor;
            this.v_Memo = vMemo;
        }

        public MachineStatusConfig_MDL(string likefieldname,string likefieldvalue)
        {
            this.LikeFieldName = likefieldname; 
            this.LikeFieldText = likefieldvalue;
        }
         
       public MachineStatusConfig_MDL(bool isFlag,string PK_FieldValue)
       {
           if (isFlag)
               this.v_ID = PK_FieldValue;
           else
               this.v_StatusID = PK_FieldValue;
       }

        public string V_ID
        {
            get { return v_ID; }
            set { v_ID = value; }
        }

        public ArrayList V_IDs
        {
            get { return v_IDs; }
            set { v_IDs = value; }
        }

        public string V_StatusID
        {
            get { return v_StatusID; }
            set { v_StatusID = value; }
        }

        public string V_StatusName
        {
            get { return v_StatusName; }
            set { v_StatusName = value; }
        }

        public string V_Img
        {
            get { return v_Img; }
            set { v_Img = value; }
        }
        public byte[] V_Imgs
        {
            get { return v_Imgs; }
            set { v_Imgs = value; }
        }

        public object V_ImgType
        {
            get { return v_ImgType; }
            set { v_ImgType = value; }
        }

        public string V_Color
        {
            get { return v_Color; }
            set { v_Color = value; }
        }
        public string V_Memo
        {
            get { return v_Memo; }
            set { v_Memo = value; }
        }       
  
    }
}
