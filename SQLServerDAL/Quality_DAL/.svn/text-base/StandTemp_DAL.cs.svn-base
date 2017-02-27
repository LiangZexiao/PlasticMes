using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model.Quality_MDL;
using Admin.Model;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Quality_DAL
{
    public class StandTemp_DAL
    {        
        FormatSqlParas fsp = new FormatSqlParas();

        public DataTable selectStandTemp(string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate)
        {
            string strSQL = "SELECT DISTINCT MachineNo, MouldNo, ProductNo, ShotMouthTemp1, ShotMouthTemp2,ShotMouthTemp3 FROM StandTechnicsParams WHERE 1=1 ";
            if (!string.IsNullOrEmpty(MachineNo)) strSQL += " AND MachineNo=@MachineNo";
            if (!string.IsNullOrEmpty(MouldNo)) strSQL += " AND MouldNo=@MouldNo";
            if (!string.IsNullOrEmpty(ProductNo)) strSQL += " AND ProductNo=@ProductNo";

            strSQL += string.Format(" ORDER BY MachineNo");

            SqlParameter[] sqlParas = {
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
                };

            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        public DataTable selectLivedTemp(string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate)
        {
            string strSQL = @"SELECT DISTINCT MachineNo,MouldNo,ItemNo ProductNo,
                                CONVERT(CHAR(19),UpLoadTime,121) UpLoadTime,
                                AVG(Temp1) AvgTemp1,AVG(Temp2) AvgTemp2,AVG(Temp3) AvgTemp3 
                                FROM CollectRealProductData_2 WHERE 1=1 ";

            if (!string.IsNullOrEmpty(MachineNo)) strSQL += " AND MachineNo=@MachineNo";
            if (!string.IsNullOrEmpty(MouldNo)) strSQL += " AND MouldNo=@MouldNo";
            if (!string.IsNullOrEmpty(ProductNo)) strSQL += " AND ItemNo=@ProductNo";
            if (!string.IsNullOrEmpty(bDate)) strSQL += " AND CONVERT(CHAR(19),BeginTime,121)>=@bDate";
            if (!string.IsNullOrEmpty(eDate)) strSQL += " AND CONVERT(CHAR(19),EndTime,121)<=@eDate";

            strSQL += @" GROUP BY MachineNo,MouldNo,ItemNo,CONVERT(CHAR(19),UpLoadTime,121) 
                        ORDER BY CONVERT(CHAR(19),UpLoadTime,121)";

            SqlParameter[] sqlParas = { 
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
                };

            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        public DataTable selectLivedTemp_2(string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate)
        {
            string strSQL = "SELECT DISTINCT MachineNo,MouldNo,ItemNo ProductNo,AVG(Temp1) AvgTemp1,AVG(Temp2) AvgTemp2,AVG(Temp3) AvgTemp3 FROM CollectRealProductData WHERE 1=1 ";
            
            if (!string.IsNullOrEmpty(MachineNo)) strSQL += " AND MachineNo=@MachineNo";
            if (!string.IsNullOrEmpty(MouldNo)) strSQL += " AND MouldNo=@MouldNo";
            if (!string.IsNullOrEmpty(ProductNo)) strSQL += " AND ItemNo=@ProductNo";
            if (!string.IsNullOrEmpty(bDate)) strSQL += " AND CONVERT(CHAR(10),UpLoadTime,121)>=@bDate";
            if (!string.IsNullOrEmpty(eDate)) strSQL += " AND CONVERT(CHAR(10),UpLoadTime,121)<=@eDate";

            strSQL += string.Format(" GROUP BY MachineNo,MouldNo,ItemNo ORDER BY MachineNo");

            SqlParameter[] sqlParas = {
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
                };

            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }
    }
}
