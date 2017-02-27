using System;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Call_MDL;
using System.Data.SqlClient;
using System.Data;
using Admin.DBUtility;
using System.Collections;

namespace Admin.SQLServerDAL.Call_DAL
{
   public class CallMachineVacation_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();
        string TableName = "tblMachineVac";
        string[] strFieldNameID = { "ID" };
        string[] strFieldName = { "MachineNo", "StartDate", "EndDate", "Creator", "CreateDate" };
        private const string SQL_SELECT = @"SELECT DISTINCT ID,b.WorkShop, MachineNo, Convert(char(16),StartDate,121) StartDate, 
                                     Convert(char(16),EndDate,121) EndDate, Creator,Convert(char(19),CreateDate,121) CreateDate
                                    FROM tblMachineVac a 
                                    inner join v_Machine b on a.MachineNo=b.MachineCode WHERE 1=1 ";
  
        public IList<CallMachineVacation_MDL> selectMachineVacation(int id, string colname, string coltext,string workshop)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlWhere.Append(string.Format(" AND ID=@ID", id));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }
            if (workshop != "")
            {
                sqlWhere.Append(" AND (workshopid='" + workshop + "' or parentworkshopid='" + workshop + "')");
                sqlParas = null;
            }

            return getListMachineVacation(sqlWhere, sqlParas);
        }
        private IList<CallMachineVacation_MDL> getListMachineVacation(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY id");

            IList<CallMachineVacation_MDL> MaVainfo = new List<CallMachineVacation_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    CallMachineVacation_MDL MaVa = new CallMachineVacation_MDL(
                        sdr.GetInt32(0),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["StartDate"] == DBNull.Value) ? "" : sdr["StartDate"].ToString().Trim(),
                        (sdr["EndDate"] == DBNull.Value) ? "" : sdr["EndDate"].ToString().Trim(),
                        (sdr["Creator"] == DBNull.Value) ? "" : sdr["Creator"].ToString().Trim(),
                        (sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString().Trim(),
                        (sdr["WorkShop"] == DBNull.Value) ? "" : sdr["WorkShop"].ToString().Trim()
                        );
                    MaVainfo.Add(MaVa);
                }
            }
            return MaVainfo;
        }
        public IList<CallMachineVacation_MDL> selectMachineVac(string begindate, string enddate, string workshop, string machineno)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (begindate != ""  && enddate != "")
            {
                sqlWhere.Append(string.Format(" AND StartDate<='{0}' ", begindate));
                sqlWhere.Append(string.Format(" AND EndDate>='{0}' ", enddate));
            }
            if (machineno != "")
            {
                sqlWhere.Append(" AND a.MachineNo='" + machineno + "'");
            }
            if (workshop != "")
            {
                sqlWhere.Append(" AND (workshopid='" + workshop + "' or parentworkshopid='" + workshop + "')");
            }
            return getListMachineVacation(sqlWhere, sqlParas);
        }

        public int  ChangeMachineVacation(CallMachineVacation_MDL obj, string IU)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@MachineNo",SqlDbType.VarChar, obj.MachineNo),
                fsp.FormatInParam("@StartDate",SqlDbType.VarChar, obj.StartDate),
                fsp.FormatInParam("@EndDate",SqlDbType.VarChar, obj.EndDate),
                fsp.FormatInParam("@Creator",SqlDbType.VarChar, obj.Creator),
                fsp.FormatInParam("@CreateDate",SqlDbType.VarChar, obj.CreateDate),
                fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
            try
            {
                if (IU == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, strFieldName), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, strFieldName), sqlParas);
            }
            catch (Exception ex)
            {
                obj = null;
                return 0;
            }
            finally
            {
                obj = null;
            }
        }
        public void deleteMachineVacation(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE tblMachineVac WHERE ID=@ID", sqlParas);
        }
        public void deleteMachineVacation(string beginDate,string endDate,string workshop,string machineno)
        {
            string strSQL = @"delete  a 
                        from tblMachineVac  a
                        left join v_Machine b on a.machineno=b.machinecode
                        where ( startdate<='"+beginDate+"' and '"+endDate+"'<=EndDate) ";
            if (machineno!="")
            {
                 strSQL+=" and  a.machineno='"+machineno+"'";
            }
            if (workshop!="")
            {
                strSQL+=" and (workshopid='"+workshop+"' or parentworkshopid='"+workshop+"') ";
            }
            SqlHelper.ExecuteNonQuery(CommandType.Text,strSQL);
        }

        public int cancelMachineVacation(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE tblMachineVac WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }



    }
}
