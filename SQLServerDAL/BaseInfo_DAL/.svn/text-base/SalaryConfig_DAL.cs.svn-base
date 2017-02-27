using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.BaseInfo_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class SalaryConfig_DAL
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT ID,WorkType,WorkDesc,Level,LevelDesc,MoneyPreHour FROM SalaryConfig WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO SalaryConfig(WorkType,WorkDesc,Level,LevelDesc,MoneyPreHour) VALUES(@WorkType,@WorkDesc,@Level,@LevelDesc,@MoneyPreHour)";
        private const string SQL_UPDATE = "UPDATE SalaryConfig SET  WorkType=@WorkType,WorkDesc=@WorkDesc,Level=@Level,LevelDesc=@LevelDesc,MoneyPreHour=@MoneyPreHour  WHERE ID=@ID ";
        private const string SQL_DELETE = "DELETE SalaryConfig WHERE ID=@ID";

        public IList<SalaryConfig_MDL> selectSalaryConfig() { return null; }
        public IList<SalaryConfig_MDL> selectSalaryConfig(int id) { return null; }
        public IList<SalaryConfig_MDL> selectSalaryConfig(int id, string colname, string coltext)
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

            IList<SalaryConfig_MDL> SalaryConfiginfoList = new List<SalaryConfig_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryConfig_MDL SalaryConfiginfo = new SalaryConfig_MDL(
                        sdr.GetInt32(0),
                        (sdr["WorkType"] == DBNull.Value) ? "" : sdr["WorkType"].ToString(),
                        (sdr["WorkDesc"] == DBNull.Value) ? "" : sdr["WorkDesc"].ToString(),
                        (sdr["Level"] == DBNull.Value) ? "" : sdr["Level"].ToString(),
                        (sdr["LevelDesc"] == DBNull.Value) ? "" : sdr["LevelDesc"].ToString(),
                        (sdr["MoneyPreHour"] == DBNull.Value) ? "" :sdr["MoneyPreHour"].ToString()
                        );
                    SalaryConfiginfoList.Add(SalaryConfiginfo);
                }
            }
            return SalaryConfiginfoList;
        }
   

        public IList<SalaryConfig_MDL> existsSalaryConfig(string _WorkType)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT WorkType FROM SalaryConfig WHERE WorkType=@WorkType");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@WorkType", SqlDbType.VarChar, _WorkType) };

            IList<SalaryConfig_MDL> SalaryConfiginfoList = new List<SalaryConfig_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryConfig_MDL SalaryConfiginfo = new SalaryConfig_MDL((sdr["WorkType"] == DBNull.Value) ? "0" : sdr["WorkType"].ToString());
                    SalaryConfiginfoList.Add(SalaryConfiginfo);
                }
            }
            return SalaryConfiginfoList;
        }
        public IList<SalaryConfig_MDL> existsSalaryConfig(string _WorkType,string _Level)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT * FROM SalaryConfig WHERE WorkType=@WorkType and Level=@Level");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@WorkType", SqlDbType.VarChar, _WorkType),
                                        fsp.FormatInParam("@Level", SqlDbType.VarChar, _Level)};

            IList<SalaryConfig_MDL> SalaryConfiginfoList = new List<SalaryConfig_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryConfig_MDL SalaryConfiginfo = new SalaryConfig_MDL((sdr["WorkType"] == DBNull.Value) ? "0" : sdr["WorkType"].ToString());
                    SalaryConfiginfoList.Add(SalaryConfiginfo);
                }
            }
            return SalaryConfiginfoList;
        }

        public int ChangeSalaryConfig(SalaryConfig_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@WorkType", SqlDbType.VarChar, obj.WorkType),
                fsp.FormatInParam("@WorkDesc", SqlDbType.VarChar, obj.WorkDesc),
                fsp.FormatInParam("@Level", SqlDbType.VarChar, obj.Level),
                fsp.FormatInParam("@LevelDesc", SqlDbType.VarChar, obj.LevelDesc),
                fsp.FormatInParam("@MoneyPreHour", SqlDbType.VarChar, obj.MoneyPreHour),
                fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID)
            };

            try
            {
                if (IU == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
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

        public void deleteSalaryConfig(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelSalaryConfig(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE SalaryConfig WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
