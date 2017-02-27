using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.Model.BaseInfo_MDL;
using Admin.Model;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class AuxiliaryToolInfo_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        string TableName = "AuxiliaryToolInfo";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "DeviceCode", "DeviceDesc", "AssetCode", "MadeDate", "Manufacturers", "Power", 
                                  "DeviceImg", "Description", "Remark","MouldNo","MachineNo" };
        string[] FieldName3 = { "DeviceCode", "DeviceDesc", "AssetCode", "MadeDate", "Manufacturers", "Power",
                                "Description", "Remark","MouldNo","MachineNo" };




        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="colname">列名</param>
        /// <param name="coltext">值</param>
        /// <returns></returns>
        public IList<AuxiliaryToolInfo_MDL> selectAuxiliaryToolInfo(int id, string colname, string coltext)
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
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + coltext + "%'", colname));
            }
            return getDataListOfAuxiliaryToolInfo(sqlWhere, sqlParas);
        }

        public IList<AuxiliaryToolInfo_MDL> ExistsAuxiliaryToolInfo(string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} ='" + coltext + "'", colname));
            }
            return getDataListOfAuxiliaryToolInfo(sqlWhere, sqlParas);
        }
        private IList<AuxiliaryToolInfo_MDL> getDataListOfAuxiliaryToolInfo(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY ID");

            IList<AuxiliaryToolInfo_MDL> AuxiliaryToolInfoList = new List<AuxiliaryToolInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    AuxiliaryToolInfo_MDL AuxiliaryToolInfo = new AuxiliaryToolInfo_MDL(
                        (sdr["ID"] == DBNull.Value) ? "" : sdr["ID"].ToString(),
                        (sdr["DeviceCode"] == DBNull.Value) ? "" : sdr["DeviceCode"].ToString(),
                        (sdr["DeviceDesc"] == DBNull.Value) ? "" : sdr["DeviceDesc"].ToString(),
                        (sdr["AssetCode"] == DBNull.Value) ? "" : sdr["AssetCode"].ToString().Trim(),
                        (sdr["MadeDate"] == DBNull.Value) ? "" : sdr["MadeDate"].ToString(),
                        (sdr["Manufacturers"] == DBNull.Value) ? "" : sdr["Manufacturers"].ToString(),
                        (sdr["Power"] == DBNull.Value) ? "0" : sdr["Power"].ToString(),
                        (sdr["DeviceImg"] == DBNull.Value) ? null : (byte[])sdr["DeviceImg"],
                        (sdr["Description"] == DBNull.Value) ? "" : sdr["Description"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString(),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString()

                    );
                    AuxiliaryToolInfoList.Add(AuxiliaryToolInfo);
                }
            }
            return AuxiliaryToolInfoList;
        }

        public int InsertAuxiliaryToolInfo(AuxiliaryToolInfo_MDL dboCall, string UI)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@DeviceCode", SqlDbType.VarChar,dboCall.DeviceCode),
                fsp.FormatInParam("@DeviceDesc", SqlDbType.VarChar,dboCall.DeviceDesc),
                fsp.FormatInParam("@AssetCode", SqlDbType.VarChar,dboCall.AssetCode),
                fsp.FormatInParam("@MadeDate", SqlDbType.VarChar,dboCall.MadeDate),
                fsp.FormatInParam("@Manufacturers", SqlDbType.VarChar,dboCall.Manufacturers),
                fsp.FormatInParam("@Power", SqlDbType.VarChar,dboCall.Power),
                fsp.FormatInParam("@DeviceImg", SqlDbType.Image,dboCall.DeviceImg),
                fsp.FormatInParam("@Description", SqlDbType.VarChar,dboCall.Description),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar,dboCall.Remark),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar,dboCall.MouldNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar,dboCall.MachineNo),
                fsp.FormatInParam("@ID", SqlDbType.VarChar,dboCall.ID)
             };
            try
            {
                byte[] temp_Photo = dboCall.DeviceImg;
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName2), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName,((temp_Photo.Length>4)? FieldName2:FieldName3)), sqlParas);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                dboCall = null;
            }
        }

        public int DeleteAuxiliaryToolInfo(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE AuxiliaryToolInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
