using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Quality_DAL
{
    public class OEE_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        public DataTable selectOEETable(string WorkShopNo,string MachineNo, string ProductNo, string bDate, string eDate)
        {
            SqlParameter[] sqlParas ={
                                        fsp.FormatInParam("@iWorkShopNo", SqlDbType.VarChar, WorkShopNo),
                                        fsp.FormatInParam("@iMachineNo", SqlDbType.VarChar, MachineNo),
                                        fsp.FormatInParam("@iProductNo", SqlDbType.VarChar, ProductNo),
                                        fsp.FormatInParam("@BeginDate", SqlDbType.VarChar, bDate),
                                        fsp.FormatInParam("@EndDate", SqlDbType.VarChar, eDate)
                                    };
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.StoredProcedure, "SELECT_OEE", sqlParas);
            return dt;
        }
    }
}
