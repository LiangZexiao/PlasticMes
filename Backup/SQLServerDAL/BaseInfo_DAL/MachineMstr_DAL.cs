using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.Machine_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class MachineMstr_DAL : IMachineMstr
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();

        string TableName = "MachineMstr";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "Machine_Code", "Machine_Type", "Machine_Manufacturer", 
                "Machine_AssetNo", "Machine_EquipmentNo", "DateTime_Machine_MadeDate", 
                "Machine_LockPower", "Machine_ShotQty","Machine_PushDistance", "Machine_LoadMouldLgt", 
                "Machine_LoadMouldWdt", "MinMouldThick", "MaxMouldThick","ShotDiameter","HydPressTackOut", "DrawPoleDistance", "Robort", "Machine_Power",
                 "Machine_MaterialChgAmt","Remark"};
        string[] FieldName3 = { "Machine_Photo" };

        public DataTable selectWorkShop()
        {
            string strSQL = @"select distinct MachineNo,WorkShop
                            from (
                            select distinct parentworkshopid as MachineNo,parentworkshop as WorkShop
                            from   MachineMstr
                            union all 
                            select distinct workshopid as MachineNo,workshop as WorkShop
                            from   MachineMstr  
                            union all 
                            select distinct parentworkshopid as MachineNo,parentworkshop as WorkShop
                            from plantbristlesmachineinfo
                            union all 
                            select distinct workshopid as MachineNo,workshop as WorkShop
                            from plantbristlesmachineinfo) a order by machineno";
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, strSQL, null);
            return dt;
        }
        public DataTable selectMachinePlant(string MachineNo)
        {
            string strSQL = @"select distinct MachineCode
                            from v_machine 
                            where (workshopid='{0}' or parentworkshopid='{0}') ";
            strSQL = string.Format(strSQL, MachineNo);
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, strSQL, null);
            return dt;
        }
        public DataTable selectAllMachinePlant()
        {
            string strSQL = @"select distinct MachineCode
                            from v_machine  ";
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, strSQL, null);
            return dt;
        }
        public string selectParentWorkShop(string MachineCode)
        {
            string strSQL = @"select ParentWorkShopid
                    from (
                    select Parentworkshopid,machine_Code as MachineCode
                    from MachineMstr 
                    union all 
                    select Parentworkshopid,machinecode as MachineCode
                    from plantbristlesmachineinfo )a 
                    where MachineCode='{0}' ";
            strSQL = string.Format(strSQL, MachineCode);
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, strSQL, null);
            string ParentWork = dt.Rows[0]["ParentWorkShopid"].ToString().Trim();
            return ParentWork;
        }


        public IList<MachineMstr_MDL> selectMachineMstr(int id, string colname, string coltext)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length + FieldName3.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            System.Array.Copy(FieldName3, 0, SELECT, FieldName1.Length + FieldName2.Length, FieldName3.Length);

            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlCmd.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            IList<MachineMstr_MDL> MachineMstrList = new List<MachineMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY Machine_Code").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MachineMstr_MDL MachineMstr = new MachineMstr_MDL(
                        sdr.GetInt32(0),
                        (sdr["Machine_Code"] == DBNull.Value) ? "" : sdr["Machine_Code"].ToString(),
                        (sdr["Machine_Type"] == DBNull.Value) ? "" : sdr["Machine_Type"].ToString(),
                        (sdr["Machine_Manufacturer"] == DBNull.Value) ? "" : sdr["Machine_Manufacturer"].ToString(),
                        (sdr["Machine_AssetNo"] == DBNull.Value) ? "" : sdr["Machine_AssetNo"].ToString(),
                        (sdr["Machine_EquipmentNo"] == DBNull.Value) ? "" : sdr["Machine_EquipmentNo"].ToString(),
                        (sdr["Machine_MadeDate"] == DBNull.Value) ? "" : sdr["Machine_MadeDate"].ToString(),

                        (sdr["Machine_LockPower"] == DBNull.Value) ? "0" : sdr["Machine_LockPower"].ToString(),
                        (sdr["Machine_ShotQty"] == DBNull.Value) ? "0" : sdr["Machine_ShotQty"].ToString(),
                        (sdr["Machine_PushDistance"] == DBNull.Value) ? "0" : sdr["Machine_PushDistance"].ToString(),
                        (sdr["Machine_LoadMouldLgt"] == DBNull.Value) ? "0" : sdr["Machine_LoadMouldLgt"].ToString(),
                        (sdr["Machine_LoadMouldWdt"] == DBNull.Value) ? "0" : sdr["Machine_LoadMouldWdt"].ToString(),
                        (sdr["MinMouldThick"] == DBNull.Value) ? "0" : sdr["MinMouldThick"].ToString(),
                        (sdr["MaxMouldThick"] == DBNull.Value) ? "0" : sdr["MaxMouldThick"].ToString(),

                        (sdr["ShotDiameter"] == DBNull.Value) ? "0" : sdr["ShotDiameter"].ToString(),
                        (sdr["HydPressTackOut"] == DBNull.Value) ? "0" : (sdr["HydPressTackOut"].ToString() != "0" && sdr["HydPressTackOut"].ToString() != "1") ? "0" : sdr["HydPressTackOut"].ToString(),
                        (sdr["DrawPoleDistance"] == DBNull.Value) ? "0" : sdr["DrawPoleDistance"].ToString(),
                        (sdr["Robort"] == DBNull.Value) ? "" : sdr["Robort"].ToString(),
                        (sdr["Machine_Power"] == DBNull.Value) ? "0" : sdr["Machine_Power"].ToString(),

                        (sdr["Machine_MaterialChgAmt"] == DBNull.Value) ? "0" : sdr["Machine_MaterialChgAmt"].ToString(),
                        (sdr["Machine_Photo"] == DBNull.Value) ? null : (byte[])sdr["Machine_Photo"],
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString()
                        );
                    MachineMstrList.Add(MachineMstr);
                }
            }
            return MachineMstrList;
        }
        public IList<MachineMstr_MDL> selectMachineMstr()
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT Substring(Machine_Code,3,2) as setcode,case Substring(Machine_Code,3,2) when '01' then '一车间' when '02' then '二车间' when '03' then '三车间' else  '植毛车间' end Machine_SeatCode FROM MachineMstr ORDER BY 1 ");//Machine_SeatCode FROM MachineMstr ORDER BY 1");
            IList<MachineMstr_MDL> MachineMstrList = new List<MachineMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), null))
            {
                while (sdr.Read())
                {
                    MachineMstr_MDL MachineMstr = new MachineMstr_MDL(
                         0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", (sdr["setcode"] == DBNull.Value) ? "" : sdr["setcode"].ToString(), null, (sdr["Machine_SeatCode"] == DBNull.Value) ? "" : sdr["Machine_SeatCode"].ToString());
                    MachineMstrList.Add(MachineMstr);
                }
            }
            return MachineMstrList;
        }

        public IList<MachineMstr_MDL> selectMachineMstr(string Machine_SeatCode)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT Machine_Code FROM MachineMstr WHERE 1=1 ");
            SqlParameter[] sqlParas = null;
            if (!string.IsNullOrEmpty(Machine_SeatCode))
            {
                sqlCmd.Append(string.Format("AND Substring(Machine_Code,1,1)=@Machine_SeatCode"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@Machine_SeatCode", SqlDbType.VarChar, Machine_SeatCode) };
            }
            IList<MachineMstr_MDL> MachineMstrList = new List<MachineMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY 1").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MachineMstr_MDL MachineMstr = new MachineMstr_MDL(
                         0,
                         (sdr.IsDBNull(0)) ? "" : sdr.GetString(0), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, ""
                        );
                    MachineMstrList.Add(MachineMstr);
                }
            }
            return MachineMstrList;
        }

        public IList<MachineMstr_MDL> existsMachineMstr(string Machine_Code)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT Machine_Code FROM MachineMstr WHERE Machine_Code=@Machine_Code");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@Machine_Code", SqlDbType.VarChar, Machine_Code) };

            IList<MachineMstr_MDL> bole = new List<MachineMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MachineMstr_MDL MachineMstr = new MachineMstr_MDL((sdr["Machine_Code"] == DBNull.Value) ? null : sdr["Machine_Code"].ToString());
                    bole.Add(MachineMstr);
                }
            }
            return bole;
        }

        public void updateMachineMstr(MachineMstr_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@Machine_Code", SqlDbType.VarChar, obj.Machine_Code),
                        fsp.FormatInParam("@Machine_Type", SqlDbType.VarChar, obj.Machine_Type),
                        fsp.FormatInParam("@Machine_Manufacturer", SqlDbType.VarChar, obj.Machine_Manufacturer),
                        fsp.FormatInParam("@Machine_AssetNo", SqlDbType.VarChar, obj.Machine_AssetNo),
                        fsp.FormatInParam("@Machine_EquipmentNo", SqlDbType.VarChar, obj.Machine_EquipmentNo),
                        fsp.FormatInParam("@Machine_MadeDate", SqlDbType.VarChar, obj.Machine_MadeDate),

                        fsp.FormatInParam("@Machine_LockPower", SqlDbType.VarChar, obj.Machine_LockPower),
                        fsp.FormatInParam("@Machine_ShotQty", SqlDbType.VarChar, obj.Machine_ShotQty),
                        fsp.FormatInParam("@Machine_PushDistance", SqlDbType.VarChar, obj.Machine_PushDistance),
                        fsp.FormatInParam("@Machine_LoadMouldLgt", SqlDbType.VarChar, obj.Machine_LoadMouldLgt),
                        fsp.FormatInParam("@Machine_LoadMouldWdt", SqlDbType.VarChar, obj.Machine_LoadMouldWdt),
                        fsp.FormatInParam("@MinMouldThick", SqlDbType.VarChar, obj.MinMouldThick),
                        fsp.FormatInParam("@MaxMouldThick", SqlDbType.VarChar, obj.MaxMouldThick),

                        fsp.FormatInParam("@ShotDiameter", SqlDbType.VarChar, obj.ShotDiameter),
                        fsp.FormatInParam("@HydPressTackOut", SqlDbType.VarChar, obj.HydPressTackOut),
                        fsp.FormatInParam("@DrawPoleDistance", SqlDbType.VarChar, obj.DrawPoleDistance),
                        fsp.FormatInParam("@Robort", SqlDbType.VarChar, obj.Robort),
                        fsp.FormatInParam("@Machine_Power", SqlDbType.VarChar, obj.Machine_Power),

                        fsp.FormatInParam("@Machine_MaterialChgAmt", SqlDbType.VarChar, obj.Machine_MaterialChgAmt),
                        fsp.FormatInParam("@Machine_Photo", SqlDbType.Image, obj.Machine_Photo),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark),
                        fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
            byte[] temp_Photo = obj.Machine_Photo;
            string[] SQL = null;
            if (temp_Photo.Length == 0)
            {
                SQL = new string[FieldName2.Length];
                System.Array.Copy(FieldName2, 0, SQL, 0, FieldName2.Length);
            }
            else
            {
                SQL = new string[FieldName2.Length + FieldName3.Length];
                System.Array.Copy(FieldName2, 0, SQL, 0, FieldName2.Length);
                System.Array.Copy(FieldName3, 0, SQL, FieldName2.Length, FieldName3.Length);
            }
            if (IU.ToUpper() == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, SQL), sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, SQL), sqlParas);
        }

        public void deleteMachineMstr(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE MachineMstr WHERE ID=@ID", sqlParas);
        }

        public void cancelMachineMstr(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE MachineMstr WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public DataTable selectMachineCode(int MachineShotQty, string productNo)
        {
            string strSql = @"select Machine_code,ProductNo,ActualStopDate,Item_Color from MachineMstr mm left join DispatchOrder do 
                            on mm.Machine_Code=do.MachineNo left join ItemMstr im on do.ProductNo=im.Item_Code
                            where Machine_ShotQty>={0} or ProductNo='{1}'
                            order by (case when im.Item_Color is not null then im.Item_Color else 9999 end)  asc,
                            do.ActualStopDate desc";
            strSql = string.Format(strSql, MachineShotQty, productNo);

            DataTable dt = SqlHelper.execSMSDetail(strSql);
            return dt;
        }
    }
}