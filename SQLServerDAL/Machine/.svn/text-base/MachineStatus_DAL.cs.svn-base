using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model;
using Admin.Model.Machine_MDL;

namespace Admin.SQLServerDAL.Machine
{
    public class MachineStatus_DAL
    {
        TableMstr tm = new TableMstr();
        DataOperator objDataOperator = new DataOperator();
        string TABLENAME = "MachineStatus";
        string fID = "ID";
        string fMachineCode = "MachineCode";
        string fDispFlag = "DispFlag";
        //string cfDispFlag = "CASE DispFlag WHEN '0' THEN '绿色' WHEN '1' THEN '棕色' WHEN '2' THEN '黄色' ELSE '红色' END AS DispFlag";
        string cfDispFlag = "DispFlag";
        string fStatus = "Status";
        //string cfStatus = "CASE Status WHEN '0' THEN '在生产' WHEN '1' THEN '待生产' WHEN '2' THEN '暂停' ELSE '维修' END AS Status";
        string cfStatus = "Status";
        string fBeginDateTime = "BeginDateTime";
        string cfBeginDateTime = "CONVERT(CHAR(10),BeginDateTime,121) BeginDateTime";
        string fEndDateTime = "EndDateTime";
        string cfEndDateTime = "CONVERT(CHAR(10),EndDateTime,121) EndDateTime";
        string fOperator = "Operator";
        string fCreater = "Creater";
        string fCreateDateTime = "CreateDateTime";
        string fMemo = "Memo";

        public DataTable selectMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            string[] ColumnsName = {
                fID,
                fMachineCode,
                cfDispFlag,
                cfStatus,
                cfBeginDateTime,
                cfEndDateTime,
                fOperator,
                fCreater,
                fCreateDateTime,
                fMemo
            };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.LikeColumnsName = dboMachineStatus.LikeFieldName;
            tm.LikeColumnsText = dboMachineStatus.LikeFieldText;
            return objDataOperator.ExecQueryCmd(tm);
        }

        public bool isexistpkMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[2] { fMachineCode, fStatus };
            tm.KeyColumnsText = new string[2] { dboMachineStatus.V_MachineCode, dboMachineStatus.V_Status};
            return (objDataOperator.ExecQueryCmd(tm).Rows.Count != 0) ? false : true;
        }

        public MachineStatus_MDL chooseMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            string[] ColumnsName = { fID,
                fMachineCode,
                fDispFlag,
                fStatus,
                cfBeginDateTime,
                cfEndDateTime,
                fOperator,
                fCreater,
                fCreateDateTime,
                fMemo
            };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineStatus.V_ID };

            DataTable dt = objDataOperator.ExecQueryCmd(tm);
            MachineStatus_MDL tempObject = new MachineStatus_MDL(
                    dt.Rows[0][fMachineCode].ToString().Trim(),
                    dt.Rows[0][fDispFlag].ToString().Trim(),
                    dt.Rows[0][fStatus].ToString().Trim(),
                    dt.Rows[0][fBeginDateTime].ToString().Trim(),
                    dt.Rows[0][fEndDateTime].ToString().Trim(),
                    dt.Rows[0][fOperator].ToString().Trim(),
                    dt.Rows[0][fCreater].ToString().Trim(),
                    dt.Rows[0][fCreateDateTime].ToString().Trim(),
                    dt.Rows[0][fMemo].ToString().Trim()
                );
            return tempObject;
        }

        public int insertMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            string[] ColumnsName = { fMachineCode,
                fDispFlag,
                fStatus,
                fBeginDateTime,
                fEndDateTime,
                fOperator,
                fCreater,
                fCreateDateTime,
                fMemo
            };
            string[] ColumnsText = {
                dboMachineStatus.V_MachineCode,
                dboMachineStatus.V_DispFlag,
                dboMachineStatus.V_Status,
                dboMachineStatus.V_BeginDateTime,
                dboMachineStatus.V_EndDateTime,
                dboMachineStatus.V_Operator,
                dboMachineStatus.V_Creater,
                dboMachineStatus.V_CreateDateTime,
                dboMachineStatus.V_Memo
            };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecInsertCmd(tm);
        }

        public int updateMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            string[] ColumnsName = { fMachineCode,
                fDispFlag,
                fStatus,
                fBeginDateTime,
                fEndDateTime,
                fOperator,
                fCreater,
                fCreateDateTime,
                fMemo
            };
            string[] ColumnsText = {
                dboMachineStatus.V_MachineCode,
                dboMachineStatus.V_DispFlag,
                dboMachineStatus.V_Status,
                dboMachineStatus.V_BeginDateTime,
                dboMachineStatus.V_EndDateTime,
                dboMachineStatus.V_Operator,
                dboMachineStatus.V_Creater,
                dboMachineStatus.V_CreateDateTime,
                dboMachineStatus.V_Memo
            };

            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineStatus.V_ID };
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsText;
            return objDataOperator.ExecUpdateCmd(tm);
        }

        public int deleteMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboMachineStatus.V_ID };
            return objDataOperator.ExecDeleteCmd(tm);
        }

        public int cancelMachineStatus(MachineStatus_MDL dboMachineStatus)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { fID };
            tm.IDTextList = dboMachineStatus.V_IDs;
            return objDataOperator.ExecCancelCmd(tm);
        }
    }
}