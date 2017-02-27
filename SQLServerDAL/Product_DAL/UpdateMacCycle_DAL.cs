using System;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;
using System.Data.SqlClient;
using System.Data;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class UpdateMacCycle_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        const string SQL_SELECT = @"select a.DispatchNo,a.MachineNo,a.MouldNo,b.ProductNo,b.ProductDesc,
                                    lastcycle,thiscycle,Convert(char(19),a.Enddate,121) as EndDate
                                    from tblMachineCyleLog a
                                    left join DispatchOrder b on a.DispatchNo=b.Do_No 
                                    where 1=1  ";
        
        public IList<UpdateMacCycle_MDL> selectUpdateMacCycle(int id, string colname, string coltext,string BeginDate,string EndDate)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id)
           };

            if (id != 0)
                sqlWhere.Append(string.Format(" AND ID=@ID "));
            if (colname != "" && coltext != "")
                sqlWhere.Append(string.Format(" AND {0} like '%" + cmm.GetSafeSqlText(true, coltext) + "%' ", colname));
            if (BeginDate != "" && EndDate != "")
            {
                sqlWhere.Append(string.Format(" and Convert(char(16),a.Enddate,121) between '{0}' and '{1}' ", BeginDate, EndDate));
            }
            return selectUpdateMacCycle(sqlWhere, sqlParas);
        }

        private IList<UpdateMacCycle_MDL> selectUpdateMacCycle(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT, sqlWhere));

            IList<UpdateMacCycle_MDL> UpdateMacCycleList = new List<UpdateMacCycle_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY a.ID ").ToString(), sqlParas))
            {
                if (sdr == null) return null ;
                while (sdr.Read())
                {
                    UpdateMacCycle_MDL UpdateMacCycle = new UpdateMacCycle_MDL(
                         //(sdr["ID"] == DBNull.Value) ? 0 : int.Parse(sdr["ID"].ToString().Trim()),
                         (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                         (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                         (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                         (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),
                         (sdr["lastcycle"] == DBNull.Value) ? "" : sdr["lastcycle"].ToString(),
                         (sdr["thiscycle"] == DBNull.Value) ? "" : sdr["thiscycle"].ToString(),
                         (sdr["EndDate"] == DBNull.Value) ? "" : sdr["EndDate"].ToString()
                       );
                    UpdateMacCycleList.Add(UpdateMacCycle);
                }
            }
            return UpdateMacCycleList;
        }
    }
}
