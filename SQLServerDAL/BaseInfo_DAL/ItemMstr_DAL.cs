using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.Model.Product_MDL;
using Admin.Model;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class ItemMstr_DAL : IItemMstr
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        string TableName = "ItemMstr";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = {"Item_Code","ProductRemark","MouldCode","ModeDesc","Mould_SpecialFittingsNo","InsertsDesc","PackageNum","Item_Weight","Item_ActualGrossWgt",
                               "Item_WaterGapScale","Item_Color","CustomerName","MaterialCode","MaterialDesc","PowderCode","AuxiliaryMaterialName","AuxiliaryMaterialNum",
                               "OutsideAssociation","MachineAssembly","ProdPhoto","StandEmployee","Processes","VerNo","Creater","CreateDate","ModiHistoryContent","Remark"
                          };
        string[] FieldName3 = {"Item_Code","ProductRemark","MouldCode","ModeDesc","Mould_SpecialFittingsNo","InsertsDesc","PackageNum","Item_Weight","Item_ActualGrossWgt",
                               "Item_WaterGapScale","Item_Color","CustomerName","MaterialCode","MaterialDesc","PowderCode","AuxiliaryMaterialName","AuxiliaryMaterialNum",
                               "OutsideAssociation","MachineAssembly","StandEmployee","Processes","VerNo","Creater","CreateDate","ModiHistoryContent","Remark"
                          };
        string TableName2 = "ItemMstrDetail";
        string[] FieldNameDetail = { "ID" };
        string[] FieldNameDetail2 = {"Item_Code","MouldCode","ModeDesc","MaterialCode","MaterialDesc","CreateDate","Percentage"
                          };
        public IList<ItemMstr_MDL> selectItemMstr(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
            }

            return getDataListOfItemMstr(sqlWhere, sqlParas);
        }

        public IList<ItemMstr_MDL> selectItemMstrDetail(int id, string colname, string coltext,string colname2,string coltxt2)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
            }
            if (colname2 != "" && coltxt2 != "")
            {
                sqlWhere.Append(string.Format(" AND {0} = '" + cmm.GetSafeSqlText(true, coltxt2) + "'", colname2));
            }

            //return getDataListOfItemMstr(sqlWhere, sqlParas);
            string[] SELECT = new string[FieldNameDetail.Length + FieldNameDetail2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldNameDetail2, 0, SELECT, FieldNameDetail.Length, FieldNameDetail2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName2, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY Item_Code");

            IList<ItemMstr_MDL> ItemMstrList = new List<ItemMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ItemMstr_MDL ItemMstr = new ItemMstr_MDL(
                        sdr.GetInt32(0),
                        (sdr["Item_Code"] == DBNull.Value) ? "" : sdr["Item_Code"].ToString(),
                        (sdr["MouldCode"] == DBNull.Value) ? "" : sdr["MouldCode"].ToString(),
                        (sdr["ModeDesc"] == DBNull.Value) ? "" : sdr["ModeDesc"].ToString(),
                        (sdr["MaterialCode"] == DBNull.Value) ? "" : sdr["MaterialCode"].ToString(),
                        (sdr["MaterialDesc"] == DBNull.Value) ? "0" : sdr["MaterialDesc"].ToString(),
                        (sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString(),
                        (sdr["Percentage"] == DBNull.Value) ? 0 : int.Parse(sdr["Percentage"].ToString())
                        );
                    ItemMstrList.Add(ItemMstr);
                }
            }
            return ItemMstrList;
        }

        public IList<ItemMstr_MDL> existsItemMstr(string Item_Code)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format(" AND Item_Code=@Item_Code"));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@Item_Code", SqlDbType.VarChar, Item_Code) };

            return getDataListOfItemMstr(sqlWhere, sqlParas);
        }

        public int ChangeItemMstr(ItemMstr_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID),
                        fsp.FormatInParam("@Item_Code", SqlDbType.VarChar, obj.Item_Code),
                        fsp.FormatInParam("@ProductRemark", SqlDbType.VarChar, obj.ProductRemark),
                        fsp.FormatInParam("@MouldCode", SqlDbType.VarChar, obj.MouldCode),
                        fsp.FormatInParam("@ModeDesc", SqlDbType.VarChar, obj.ModeDesc),
                        fsp.FormatInParam("@Mould_SpecialFittingsNo", SqlDbType.VarChar, obj.Mould_SpecialFittingsNo),
                        fsp.FormatInParam("@InsertsDesc", SqlDbType.VarChar, obj.InsertsDesc),
                        fsp.FormatInParam("@PackageNum", SqlDbType.VarChar, obj.PackageNum),
                        fsp.FormatInParam("@Item_Weight", SqlDbType.VarChar, obj.Item_Weight),
                        fsp.FormatInParam("@Item_ActualGrossWgt", SqlDbType.VarChar, obj.Item_ActualGrossWgt),
                        fsp.FormatInParam("@Item_WaterGapScale", SqlDbType.VarChar, obj.Item_WaterGapScale),
                        fsp.FormatInParam("@Item_Color", SqlDbType.VarChar, obj.Item_Color),
                        fsp.FormatInParam("@CustomerName", SqlDbType.VarChar, obj.CustomerName),
                        fsp.FormatInParam("@MaterialCode", SqlDbType.VarChar, obj.MaterialCode),
                        fsp.FormatInParam("@MaterialDesc", SqlDbType.VarChar, obj.MaterialDesc),
                        fsp.FormatInParam("@PowderCode", SqlDbType.VarChar, obj.PowderCode),
                        fsp.FormatInParam("@AuxiliaryMaterialName", SqlDbType.VarChar, obj.AuxiliaryMaterialName),
                        fsp.FormatInParam("@AuxiliaryMaterialNum", SqlDbType.VarChar, obj.AuxiliaryMaterialNum),
                        fsp.FormatInParam("@OutsideAssociation", SqlDbType.VarChar, obj.OutsideAssociation),
                        fsp.FormatInParam("@MachineAssembly", SqlDbType.VarChar, obj.MachineAssembly),
                        fsp.FormatInParam("@ProdPhoto", SqlDbType.Image, obj.ProdPhoto),
                        fsp.FormatInParam("@StandEmployee", SqlDbType.VarChar, obj.StandEmployee),
                        fsp.FormatInParam("@Processes", SqlDbType.VarChar, obj.Processes),
                        fsp.FormatInParam("@VerNo", SqlDbType.VarChar, obj.VerNo),
                        fsp.FormatInParam("@Creater", SqlDbType.VarChar, obj.Creater),
                        fsp.FormatInParam("@CreateDate", SqlDbType.VarChar, obj.CreateDate),
                        fsp.FormatInParam("@ModiHistoryContent", SqlDbType.VarChar, obj.ModiHistoryContent),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark)
            };
            try
            {
                byte[] temp_Photo = obj.ProdPhoto;
                if (IU == "INSERT")
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName2), sqlParas);
                }
                else
                {
                    if (temp_Photo.Length > 4)
                    {
                        return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName2), sqlParas);
                    }
                    else
                    {
                        return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName3), sqlParas);
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrMsg = ex.Message.ToString();
                return -1;
            } 
            finally
            {
                obj = null;
            }
        }
        public int ChangeItemMstrDetail(ItemMstr_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID),
                        fsp.FormatInParam("@Item_Code", SqlDbType.VarChar, obj.Item_Code),
                        fsp.FormatInParam("@MouldCode", SqlDbType.VarChar, obj.MouldCode),
                        fsp.FormatInParam("@ModeDesc", SqlDbType.VarChar, obj.ModeDesc),
                        fsp.FormatInParam("@MaterialCode", SqlDbType.VarChar, obj.MaterialCode),
                        fsp.FormatInParam("@MaterialDesc", SqlDbType.VarChar, obj.MaterialDesc),
                        fsp.FormatInParam("@CreateDate", SqlDbType.VarChar, obj.CreateDate),
                        fsp.FormatInParam("@Percentage", SqlDbType.Int, obj.Percentage)
            };
            try
            {
                if (IU == "INSERT")
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName2, FieldNameDetail2), sqlParas);
                }
                else
                {
                    
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName2, FieldNameDetail2), sqlParas);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                obj = null;
            }
        }
        public int cancelItemMstrDetail(string Item_Code)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("DELETE ItemMstrDetail WHERE Item_Code='{0}' IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", Item_Code);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int cancelItemMstr(ArrayList _IDList)
        {
            try
            {
                string ExecBatch = "BEGIN TRANSACTION ";
                foreach (string s in _IDList)
                {
                    ExecBatch += string.Format("delete itemmstrdetail where item_code = (select item_code from itemmstr where id={0})  IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot  ", s);
                    ExecBatch += string.Format("DELETE ItemMstr WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot  ", s);
                }
                ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return -1;
            }
        }
   

        private IList<ItemMstr_MDL> getDataListOfItemMstr(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY Item_Code");

            IList<ItemMstr_MDL> ItemMstrList = new List<ItemMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ItemMstr_MDL ItemMstr = new ItemMstr_MDL(
                        sdr.GetInt32(0),
                        (sdr["Item_Code"] == DBNull.Value) ? "" : sdr["Item_Code"].ToString(),
                        (sdr["ProductRemark"] == DBNull.Value) ? "" : sdr["ProductRemark"].ToString(),
                        (sdr["MouldCode"] == DBNull.Value) ? "" : sdr["MouldCode"].ToString(),
                        (sdr["ModeDesc"] == DBNull.Value) ? "" : sdr["ModeDesc"].ToString(),
                        (sdr["Mould_SpecialFittingsNo"] == DBNull.Value) ? "" : sdr["Mould_SpecialFittingsNo"].ToString(),
                        (sdr["InsertsDesc"] == DBNull.Value) ? "" : sdr["InsertsDesc"].ToString(),
                        (sdr["PackageNum"] == DBNull.Value) ? "0" : sdr["PackageNum"].ToString(),
                        (sdr["Item_Weight"] == DBNull.Value) ? "0" : sdr["Item_Weight"].ToString(),
                        (sdr["Item_ActualGrossWgt"] == DBNull.Value) ? "0" : sdr["Item_ActualGrossWgt"].ToString(),
                        (sdr["Item_WaterGapScale"] == DBNull.Value) ? "0" : sdr["Item_WaterGapScale"].ToString(),
                        (sdr["Item_Color"] == DBNull.Value) ? "" : sdr["Item_Color"].ToString(),
                        (sdr["CustomerName"] == DBNull.Value) ? "" : sdr["CustomerName"].ToString(),
                        (sdr["MaterialCode"] == DBNull.Value) ? "" : sdr["MaterialCode"].ToString(),
                        (sdr["MaterialDesc"] == DBNull.Value) ? "0" : sdr["MaterialDesc"].ToString(),
                        (sdr["PowderCode"] == DBNull.Value) ? "" : sdr["PowderCode"].ToString(),
                        (sdr["AuxiliaryMaterialName"] == DBNull.Value) ? "" : sdr["AuxiliaryMaterialName"].ToString(),
                        (sdr["AuxiliaryMaterialNum"] == DBNull.Value) ? "0" : sdr["AuxiliaryMaterialNum"].ToString(),
                        (sdr["OutsideAssociation"] == DBNull.Value) ? "" : sdr["OutsideAssociation"].ToString(),
                        (sdr["MachineAssembly"] == DBNull.Value) ? "" : sdr["MachineAssembly"].ToString(), 
                        (sdr["ProdPhoto"] == DBNull.Value) ? null : (byte[])sdr["ProdPhoto"],
                        (sdr["StandEmployee"] == DBNull.Value) ? "" : sdr["StandEmployee"].ToString(),
                        (sdr["Processes"] == DBNull.Value) ? "" : sdr["Processes"].ToString(),
                        (sdr["VerNo"] == DBNull.Value) ? "" : sdr["VerNo"].ToString(),
                        (sdr["Creater"] == DBNull.Value) ? "" : sdr["Creater"].ToString(),
                        (sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString(),
                        (sdr["ModiHistoryContent"] == DBNull.Value) ? "" : sdr["ModiHistoryContent"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString()                  
                        );
                    ItemMstrList.Add(ItemMstr);
                }
            }
            return ItemMstrList;
        }
    }
}
