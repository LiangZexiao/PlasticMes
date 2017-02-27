using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Admin.Model;
using Admin.Model.Machine_MDL;

namespace Admin.SQLServerDAL.Machine
{
    public class MachineStatusConfig_DAL
    {
        TableMstr tm = new TableMstr();
        SQLPreparer objDataAction = new SQLPreparer();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string TABLENAME  = "MachineStatusConfig";
        private const string ID         = "ID";
        private const string STATUSID   = "StatusID";
        private const string STATUSNAME = "StatusName";
        private const string IMG        = "Img"; 
        private const string IMGTYPE    = "ImgType"; 
        private const string COLOR      = "Color";
        private const string MEMO       = "Memo"; 

        public DataTable SelectMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            string[] ColumnsName = { ID, STATUSID, STATUSNAME, IMG, IMGTYPE, COLOR, MEMO };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.LikeColumnsName = TempObject.LikeFieldName;
            tm.LikeColumnsText = TempObject.LikeFieldText;
            return objDataAction.ExecQueryCmd(tm);
        }

        public bool IsexistpkMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { STATUSID };
            tm.KeyColumnsText = new string[1] { TempObject.V_StatusID };
            return (objDataAction.ExecQueryCmd(tm).Rows.Count != 0) ? false : true;
        }

        public MachineStatusConfig_MDL ChooseMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            string[] ColumnsName = { ID, STATUSID, STATUSNAME, IMG, IMGTYPE, COLOR, MEMO };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.KeyColumnsName = new string[1] { ID };
            tm.KeyColumnsText = new string[1] { TempObject.V_ID };
            DataTable dt = objDataAction.ExecQueryCmd(tm);

            MachineStatusConfig_MDL ReturnObject = new MachineStatusConfig_MDL(
                dt.Rows[0][ID].ToString().Trim(),
                dt.Rows[0][STATUSID].ToString().Trim(),
                dt.Rows[0][STATUSNAME].ToString().Trim(),
                null,
                null,
                dt.Rows[0][COLOR].ToString().Trim(),
                dt.Rows[0][MEMO].ToString().Trim());
            return ReturnObject;
        }

        //新增一条记录
        public int InsertMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            string[] ColumnsName = { STATUSID, STATUSNAME, IMG, IMGTYPE, COLOR, MEMO };

            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsName;

            SqlParameter[] parms ={
                fsp.FormatInParam(STATUSID,SqlDbType.Char, TempObject.V_StatusID),
                fsp.FormatInParam(STATUSNAME,SqlDbType.VarChar, TempObject.V_StatusName),
                fsp.FormatInParam(IMG,SqlDbType.Image, TempObject.V_Imgs),
                fsp.FormatInParam(IMGTYPE,SqlDbType.Char, TempObject.V_ImgType),
                fsp.FormatInParam(COLOR,SqlDbType.VarChar, TempObject.V_Color),
                fsp.FormatInParam(MEMO,SqlDbType.Char, TempObject.V_Memo)
            };

            return objDataAction.ExecInsertCmd(tm, parms);
        }
        //更新一条记录
        public int UpdateMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            string[] ColumnsName = { STATUSID, STATUSNAME, IMG, IMGTYPE, COLOR, MEMO };

            SqlParameter[] parms ={
                fsp.FormatInParam(ID,SqlDbType.Int, TempObject.V_ID),
                fsp.FormatInParam(STATUSID,SqlDbType.Char, TempObject.V_StatusID),
                fsp.FormatInParam(STATUSNAME,SqlDbType.VarChar, TempObject.V_StatusName),
                fsp.FormatInParam(IMG,SqlDbType.Image, TempObject.V_Imgs),
                fsp.FormatInParam(IMGTYPE,SqlDbType.Char, TempObject.V_ImgType),
                fsp.FormatInParam(COLOR,SqlDbType.VarChar, TempObject.V_Color),
                fsp.FormatInParam(MEMO,SqlDbType.Char, TempObject.V_Memo)
            };

            byte[] tempImgs = TempObject.V_Imgs;
            object tempImgType = TempObject.V_ImgType;

            if (tempImgs.Length == 0 || tempImgs == null || tempImgType == null)
            {
                ColumnsName = new string[4] { STATUSID, STATUSNAME, COLOR, MEMO };
            }
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { ID };
            tm.KeyColumnsText = new string[1] { ID };
            tm.ColumnsName = ColumnsName;
            tm.ColumnsText = ColumnsName;

            return objDataAction.ExecUpdateCmd(tm, parms);
        }

        public int DeleteMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { ID };
            tm.KeyColumnsText = new string[1] { TempObject.V_ID };

            return objDataAction.ExecDeleteCmd(tm);
        }

        public int CancelMachineStatusConfig(MachineStatusConfig_MDL TempObject)
        {
            tm.TableName = TABLENAME;
            tm.KeyColumnsName = new string[1] { ID };
            tm.IDTextList = TempObject.V_IDs;
            return objDataAction.ExecCancelCmd(tm);
        }        
    }
}
