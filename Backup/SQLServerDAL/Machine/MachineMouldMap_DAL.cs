using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model;
using Admin.Model.Machine_MDL;

namespace Admin.SQLServerDAL.Machine
{
    public class MachineMouldMap_DAL
    {
        TableMstr tm = new TableMstr();
        DataOperator objDataOperator = new DataOperator();
        const string TABLENAME = "MachineMouldMap";
        string fID = "ID";
        string fMachine_Code = "Machine_Code";
        string fMould_Code = "Mould_Code";
        string fMemo = "Memo";

        public DataTable selectMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
        {
            string[] ColumnsName = {fID,fMachine_Code,fMould_Code,fMemo};
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.LikeColumnsName = dboMachineMouldMap.LikeFieldName;
            tm.LikeColumnsText = dboMachineMouldMap.LikeFieldText;

            return objDataOperator.ExecQueryCmd(tm);
        }

        public MachineMouldMap_MDL chooseMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
        {
            string[] ColumnsName = {fMachine_Code,fMould_Code,fMemo};

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineMouldMap.V_ID };

            DataTable dt = objDataOperator.ExecQueryCmd(tm);
            MachineMouldMap_MDL tempObject = new MachineMouldMap_MDL(
                        dt.Rows[0][fMachine_Code].ToString().Trim(),
                        dt.Rows[0][fMould_Code].ToString().Trim(),
                        dt.Rows[0][fMemo].ToString().Trim()
                );
            return tempObject;
        }
        public bool isexistpkMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
       {
           tm.TableName = TABLENAME;
           tm.KeyColumnsName = new string[2] { fMachine_Code, fMould_Code };
           tm.KeyColumnsText = new string[2] { dboMachineMouldMap.V_Machine_Code, dboMachineMouldMap.V_Mould_Code };

           return (objDataOperator.ExecQueryCmd(tm).Rows.Count != 0) ? false : true;
       }
        public int insertMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
        {
            string[] ColumnsName = {fMachine_Code,fMould_Code,fMemo};
            string[] ColumnsText = {
                dboMachineMouldMap.V_Machine_Code,
                dboMachineMouldMap.V_Mould_Code,
                dboMachineMouldMap.V_Memo
            };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecInsertCmd(tm);
        }

        public int updateMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
        {
            string[] ColumnsName = {fMachine_Code,fMould_Code,fMemo};
            string[] ColumnsText = {
                dboMachineMouldMap.V_Machine_Code,
                dboMachineMouldMap.V_Mould_Code, 
                dboMachineMouldMap.V_Memo 
            };

            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineMouldMap.V_ID };
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecUpdateCmd(tm);
        }

        public int deleteMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineMouldMap.V_ID };
            return objDataOperator.ExecDeleteCmd(tm);
        }

        public int cancelMachineMouldMap(MachineMouldMap_MDL dboMachineMouldMap)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.IDTextList = dboMachineMouldMap.V_IDs;
            return objDataOperator.ExecCancelCmd(tm);
        }
    }
}
