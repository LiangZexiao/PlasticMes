using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Machine_MDL;
using Admin.Model;

namespace Admin.SQLServerDAL.Machine
{ 
    public class MachineCollectMap_DAL
    {
        TableMstr tm = new TableMstr();
        DataOperator objDataOperator = new DataOperator();
        const string TABLENAME = "MachineCollectMap";
        string fID = "ID";
        string fMachineNO = "MachineNO";
        string fCollectNO = "CollectNO";
        string fRemark = "Remark";

        public DataTable selectMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            string[] ColumnsName = { fID,fMachineNO,fCollectNO,fRemark };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.LikeColumnsName = dboMachineCollectMap.LikeFieldName;
            tm.LikeColumnsText = dboMachineCollectMap.LikeFieldText;

            return objDataOperator.ExecQueryCmd(tm);
        }

        public bool isexistpkMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fMachineNO };
            tm.KeyColumnsText = new string[1] { dboMachineCollectMap.V_MachineNO };

            return (objDataOperator.ExecQueryCmd(tm).Rows.Count != 0) ? false : true;
        }

        public MachineCollectMap_MDL chooseMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            string[] ColumnsName = { fID, fMachineNO, fCollectNO, fRemark };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineCollectMap.V_ID };
            DataTable dt = objDataOperator.ExecQueryCmd(tm);
            MachineCollectMap_MDL tempObject = new MachineCollectMap_MDL(
                        dt.Rows[0][fMachineNO].ToString().Trim(),
                        dt.Rows[0][fCollectNO].ToString().Trim(),
                        dt.Rows[0][fRemark].ToString().Trim()
                );
            return tempObject;
        }

        public int insertMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            string[] ColumnsName = { fMachineNO,fCollectNO,fRemark };
            string[] ColumnsText = {
                dboMachineCollectMap.V_MachineNO,
                dboMachineCollectMap.V_CollectNO,
                dboMachineCollectMap.V_Remark
            };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecInsertCmd(tm);
        }

        public int updateMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            string[] ColumnsName = { fMachineNO,fCollectNO,fRemark };
            string[] ColumnsText = {
                dboMachineCollectMap.V_MachineNO,
                dboMachineCollectMap.V_CollectNO,
                dboMachineCollectMap.V_Remark
            };
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineCollectMap.V_ID };
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecUpdateCmd(tm);
        }

        public int deleteMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineCollectMap.V_ID };
            return objDataOperator.ExecDeleteCmd(tm);
        }

        public int cancelMachineCollectMap(MachineCollectMap_MDL dboMachineCollectMap)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.IDTextList = dboMachineCollectMap.V_IDs;
            return objDataOperator.ExecCancelCmd(tm);
        }
    }
}
