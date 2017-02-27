using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Admin.Model.Machine_MDL
{
    public class MachineMouldMap_MDL:LikeQuery
    {
        private string v_ID;
        private ArrayList v_IDs;
        private string v_Machine_Code;
        private string v_Mould_Code;
        private string v_Memo;

        public MachineMouldMap_MDL() {}
        public MachineMouldMap_MDL(string vID) { this.v_ID = vID; }
        public MachineMouldMap_MDL(ArrayList vIDs) { this.v_IDs = vIDs; }

        public MachineMouldMap_MDL(string vMachine_Code,string vMould_Code,string vMemo)           
        {
            this.v_Machine_Code = vMachine_Code;
            this.v_Mould_Code = vMould_Code;
            this.v_Memo = vMemo;
        }
        public MachineMouldMap_MDL(string vID, string vMachine_Code, string vMould_Code, string vMemo)
       {
           this.v_ID = vID;
           this.v_Machine_Code = vMachine_Code;
           this.v_Mould_Code = vMould_Code;
           this.v_Memo = vMemo;       
       }
       public MachineMouldMap_MDL(string likefieldname, string likefieldvalue)
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
       public string V_Machine_Code
       {
           get { return v_Machine_Code; }
           set { v_Machine_Code = value; }
       }
       public string V_Mould_Code
       {
           get { return v_Mould_Code; }
           set { v_Mould_Code = value; }
       }
       public string V_Memo
       {
           get { return v_Memo; }
           set { v_Memo = value; }
       }      
    }
}
