using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Admin.DBUtility;
using System.Data;
using System.Collections;
using Admin.Model.BaseInfo_MDL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class ColorManage_DAL
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT ID,Number,ColorName,Depth FROM ColorMessage WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO ColorMessage(Number,ColorName,Depth) VALUES(@Number,@ColorName,@Depth)";
        private const string SQL_UPDATE = "UPDATE ColorMessage SET  Number=@Number,ColorName=@ColorName,Depth=@Depth  WHERE ID=@ID ";
        private const string SQL_DELETE = "DELETE ColorMessage WHERE ID=@ID";

        public IList<ColorMessage_MDL> selectColorManage() { return null; }
        public IList<ColorMessage_MDL> selectColorManage(int id) { return null; }
        public IList<ColorMessage_MDL> selectColorManage(string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = null;

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            IList<ColorMessage_MDL> ColorManageList = new List<ColorMessage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ColorMessage_MDL ColorManage = new ColorMessage_MDL(
                        sdr.GetInt32(0),
                        (sdr["Number"] == DBNull.Value) ? "" : sdr["Number"].ToString(),
                        (sdr["ColorName"] == DBNull.Value) ? "" : sdr["ColorName"].ToString(),
                        (sdr["Depth"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["Depth"].ToString())
                        );
                    ColorManageList.Add(ColorManage);
                }
            }
            return ColorManageList;
        }

        public IList<ColorMessage_MDL> selectColorManage(int id, string colname, string coltext)
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

            IList<ColorMessage_MDL> ColorManageList = new List<ColorMessage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ColorMessage_MDL ColorManage = new ColorMessage_MDL(
                        sdr.GetInt32(0),
                        (sdr["Number"] == DBNull.Value) ? "" : sdr["Number"].ToString(),
                        (sdr["ColorName"] == DBNull.Value) ? "" : sdr["ColorName"].ToString(),
                        (sdr["Depth"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["Depth"].ToString())
                        );
                    ColorManageList.Add(ColorManage);
                }
            }
            return ColorManageList;
        }

        public IList<ColorMessage_MDL> existsColorManage(int _Depth)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT Number FROM ColorMessage WHERE Depth=@Depth");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@Depth", SqlDbType.Int, _Depth) };

            IList<ColorMessage_MDL> ColorManageList = new List<ColorMessage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ColorMessage_MDL ColorManage = new ColorMessage_MDL((sdr["Number"] == DBNull.Value) ? "0" : sdr["Number"].ToString());
                    ColorManageList.Add(ColorManage);
                }
            }
            return ColorManageList;
        }
        public IList<ColorMessage_MDL> existsColorManage(string _Number, int _Depth)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT * FROM ColorMessage WHERE Number=@Number and Depth=@Depth");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@Number", SqlDbType.VarChar, _Number),
                                        fsp.FormatInParam("@Depth", SqlDbType.Int, _Depth)};

            IList<ColorMessage_MDL> ColorManageList = new List<ColorMessage_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ColorMessage_MDL ColorManage = new ColorMessage_MDL((sdr["Number"] == DBNull.Value) ? "0" : sdr["Number"].ToString());
                    ColorManageList.Add(ColorManage);
                }
            }
            return ColorManageList;
        }

        public int ChangeColorManage(ColorMessage_MDL obj, string IU)
        {
            IList<ColorMessage_MDL> list = null;
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@Number", SqlDbType.VarChar, obj.Number),
                fsp.FormatInParam("@ColorName", SqlDbType.VarChar, obj.ColorName),
                fsp.FormatInParam("@Depth", SqlDbType.Int, obj.Depth),
                fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID)
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

        public void deleteColorManage(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelColorManage(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE ColorMessage WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
