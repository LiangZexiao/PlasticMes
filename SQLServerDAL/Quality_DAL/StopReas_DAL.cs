using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
namespace Admin.SQLServerDAL.Quality_DAL
{
   public  class StopReas_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
       public DataTable selectOEETable(string MachineNo, string bDate, string eDate, string Printer)
        {
            SqlParameter[] sqlParas ={
                                        fsp.FormatInParam("@MachineNox", SqlDbType.VarChar, MachineNo),
                                        fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                                        fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate),
                                        fsp.FormatInParam("@Printer", SqlDbType.VarChar, Printer)
                                    };
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.StoredProcedure, "V1_rptStopReason", sqlParas);
            return dt;
        }
    }
}
