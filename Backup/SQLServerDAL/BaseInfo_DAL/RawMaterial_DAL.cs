using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Admin.Model.BaseInfo_MDL;
using Admin.DBUtility;
using System.Data;
using System.Collections;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class RawMaterial_DAL
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT ID,RawNo,RawName,RawModel,RawBrand,Spec,RawColor,Memo FROM RawMaterial WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO RawMaterial(RawNo,RawName,RawModel,RawBrand,Spec,RawColor,Memo) VALUES(@RawNo,@RawName,@RawModel,@RawBrand,@Spec,@RawColor,@Memo)";
        private const string SQL_UPDATE = "UPDATE RawMaterial SET  RawNo=@RawNo,RawName=@RawName,RawModel=@RawModel,RawBrand=@RawBrand,Spec=@Spec,RawColor=@RawColor,Memo=@Memo  WHERE ID=@ID ";
        private const string SQL_DELETE = "DELETE RawMaterial WHERE ID=@ID";

        public IList<RawMaterial_MDL> selectRawMaterial() { return null; }
        public IList<RawMaterial_MDL> selectRawMaterial(int id) { return null; }
        public IList<RawMaterial_MDL> selectRawMaterial(string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = null;

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            IList<RawMaterial_MDL> RawMaterialList = new List<RawMaterial_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    RawMaterial_MDL ColorManage = new RawMaterial_MDL(
                        sdr.GetInt32(0),
                        (sdr["RawNo"] == DBNull.Value) ? "" : sdr["RawNo"].ToString(),
                        (sdr["RawName"] == DBNull.Value) ? "" : sdr["RawName"].ToString(),
                        (sdr["RawModel"] == DBNull.Value) ? "" : sdr["RawModel"].ToString(),
                        (sdr["RawBrand"] == DBNull.Value) ? "" : sdr["RawBrand"].ToString(),
                        (sdr["Spec"] == DBNull.Value) ? 0 : Convert.ToSingle(sdr["Spec"].ToString()),
                        (sdr["RawColor"] == DBNull.Value) ? "" : sdr["RawColor"].ToString(),
                        (sdr["Memo"] == DBNull.Value) ? "" : sdr["Memo"].ToString()
                        );
                    RawMaterialList.Add(ColorManage);
                }
            }
            return RawMaterialList;
        }

        public IList<RawMaterial_MDL> selectRawMaterial(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
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

            IList<RawMaterial_MDL> RawMaterialList = new List<RawMaterial_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    RawMaterial_MDL RawMaterial = new RawMaterial_MDL(
                        sdr.GetInt32(0),
                       (sdr["RawNo"] == DBNull.Value) ? "" : sdr["RawNo"].ToString(),
                        (sdr["RawName"] == DBNull.Value) ? "" : sdr["RawName"].ToString(),
                        (sdr["RawModel"] == DBNull.Value) ? "" : sdr["RawModel"].ToString(),
                        (sdr["RawBrand"] == DBNull.Value) ? "" : sdr["RawBrand"].ToString(),
                        (sdr["Spec"] == DBNull.Value) ? 0 : Convert.ToSingle(sdr["Spec"].ToString()),
                        (sdr["RawColor"] == DBNull.Value) ? "" : sdr["RawColor"].ToString(),
                        (sdr["Memo"] == DBNull.Value) ? "" : sdr["Memo"].ToString()
                        );
                    RawMaterialList.Add(RawMaterial);
                }
            }
            return RawMaterialList;
        }

        public IList<RawMaterial_MDL> existsRawMaterial(string _RawNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT RawNo FROM RawMaterial WHERE RawNo=@RawNo");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@RawNo", SqlDbType.VarChar, _RawNo) };

            IList<RawMaterial_MDL> RawMaterialList = new List<RawMaterial_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    RawMaterial_MDL RawMaterial = new RawMaterial_MDL((sdr["RawNo"] == DBNull.Value) ? "0" : sdr["RawNo"].ToString());
                    RawMaterialList.Add(RawMaterial);
                }
            }
            return RawMaterialList;
        }
        public IList<RawMaterial_MDL> existsRawMaterial(string _RawNo, string _RawModel)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT * FROM RawMaterial WHERE RawNo=@RawNo and RawModel=@RawModel");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@RawNo", SqlDbType.VarChar, _RawNo),
                                        fsp.FormatInParam("@RawModel", SqlDbType.VarChar, _RawModel)};

            IList<RawMaterial_MDL> RawMaterialList = new List<RawMaterial_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    RawMaterial_MDL RawMaterial = new RawMaterial_MDL((sdr["RawNo"] == DBNull.Value) ? "0" : sdr["RawNo"].ToString());
                    RawMaterialList.Add(RawMaterial);
                }
            }
            return RawMaterialList;
        }

        public int ChangeRawMaterial(RawMaterial_MDL obj, string IU)
        {
            IList<RawMaterial_MDL> list = null;
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID),
                fsp.FormatInParam("@RawNo", SqlDbType.VarChar, obj.RawNo),
                fsp.FormatInParam("@RawName", SqlDbType.VarChar, obj.RawName),
                fsp.FormatInParam("@RawModel", SqlDbType.VarChar, obj.RawModel),
                fsp.FormatInParam("@RawBrand", SqlDbType.VarChar, obj.RawBrand),
                fsp.FormatInParam("@Spec", SqlDbType.Float, obj.Spec),
                fsp.FormatInParam("@RawColor", SqlDbType.VarChar, obj.RawColor),
                fsp.FormatInParam("@Memo", SqlDbType.VarChar, obj.Memo)

            };

            try
            {
                if (IU == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
                else
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
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

        public void deleteRawMaterial(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelRawMaterial(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE RawMaterial WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}