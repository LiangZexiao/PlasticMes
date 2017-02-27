using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Admin.Model.Machine_MDL
{
   public class MachineCollectMap_MDL:LikeQuery
    {
        private string v_ID;
        private ArrayList v_IDs;
        private string v_MachineNO;
        private string v_CollectNO;
        private string v_Remark;

       public MachineCollectMap_MDL() {}
       public MachineCollectMap_MDL(ArrayList vIDs) { this.v_IDs = vIDs; }
       public MachineCollectMap_MDL(bool isFlag, string coltext)
       {
           if (isFlag) this.v_ID = coltext;
           else this.v_MachineNO = coltext;
       }

       public MachineCollectMap_MDL(string vMachineNO,string vCollectNO,string vRemark)
       {
           this.v_MachineNO = vMachineNO;
           this.v_CollectNO = vCollectNO;
           this.v_Remark = vRemark;
       }
       public MachineCollectMap_MDL(string vID, string vMachineNO, string vCollectNO,string vRemark)
       {
           this.v_ID = vID;
           this.v_MachineNO = vMachineNO;
           this.v_CollectNO = vCollectNO;
           this.v_Remark = vRemark;
       }
       public MachineCollectMap_MDL(string likefieldname, string likefieldvalue)           
       {
           this.LikeFieldName = likefieldname; 
           this.LikeFieldText = likefieldvalue;
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
       public string V_MachineNO
       {
           get { return v_MachineNO; }
           set { v_MachineNO = value; }
       }

       public string V_CollectNO
       {
           get { return v_CollectNO; }
           set { v_CollectNO = value; }
       }

       public string V_Remark
       {
           get { return v_Remark; }
           set { v_Remark = value; }
       } 
    }
}
