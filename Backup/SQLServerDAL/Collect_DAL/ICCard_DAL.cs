using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Admin.DBUtility;
using Admin.Model;
namespace Admin.SQLServerDAL.Collect_DAL
{
    public  class ICCard_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();
        SQLExecutant sc = new SQLExecutant();

//        string tabname = @"select b.dispatchno,do.Machineno,a.employeeid,a.employeename_cn,a.rank,a.iccardno 
//                        ,e.reasonname,b.start_date as createdate,b.start_date as start_date,b.end_date as end_date
//                        from DeviceRealStatus as b inner join StopReason as e  on e.reasonid=b.devicestatus 
//                        inner join view_employee as a on a.iccardno=b.cardid
//                        left join dispatchorder do on do.DO_NO=b.dispatchno 
//                        where 1=1  And a.Invalid ='正常' and ReasonID Not In('0','10','14','15','16')";

        /// <summary>
        /// update by fsq 2010-03-25
        /// remark:优化程序，改成从存储过程中查询数据
        /// 
        /// </summary>
        /// <param name="Auto"></param>
        /// <param name="ReasonName"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <param name="begindate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public DataTable selectICCard(string Auto,string ReasonName,string colname, string coltext,string begindate,string enddate)
        {
            //string sql = tabname;
            //if (colname != "" && coltext != "")
            //{
            //    sql += string.Format(" and  {0} like '%" + coltext + "%'", colname);
            //}
            //if (begindate != "" && enddate != "")
            //{
            //    sql += string.Format(" and ((convert(char(16),start_date,121) >= '" + begindate + "' and convert(char(16),start_date,121) <= '" + enddate + "')  ");
            //    sql += string.Format(" or (convert(char(16),End_date,121) >= '" + begindate + "' and convert(char(16),End_date,121) <= '" + enddate + "'))");

            //    //sql += string.Format(" and convert(char(16),start_date,121) >= '" + begindate + "' and  convert(char(16),start_date,121) <='" + enddate + "'");
            //}
            //if (Auto != string.Empty)
            //{
            //    if (Auto == "IM04")
            //        sql += " And (do.MachineNo like '" + Auto + "%' or do.MachineNo like 'PM%')";
            //    else
            //        sql += " And do.MachineNo like '" + Auto + "%'";
            //}
            //if (ReasonName != string.Empty) 
            //{
            //    sql += " And e.ReasonName='" + ReasonName + "'";
            //}
            //sql += " order by do.Machineno desc ";
            //return sc.ExecQueryCmd(sql);
            SqlParameter[] cmdSqlParameter = null;
            string cmdProcedureName = "st_StopMachine";
            cmdSqlParameter = new SqlParameter[6]{
                   fsp.FormatInParam("@SeatCode", SqlDbType.VarChar,Auto.Trim()),
                   fsp.FormatInParam("@ReasonName", SqlDbType.VarChar, ReasonName.Trim()),
                   fsp.FormatInParam("@Colname", SqlDbType.VarChar, colname.Trim()),
                   fsp.FormatInParam("@Coltext", SqlDbType.VarChar, coltext.Trim()),
                   fsp.FormatInParam("@BeginDate", SqlDbType.VarChar, begindate.Trim()),
                   fsp.FormatInParam("@EndDate", SqlDbType.VarChar, enddate.Trim())
            };
            SQLExecutant sqlExec = new SQLExecutant();
            DataTable dt = new DataTable();
            dt = sqlExec.ExecQueryCmd(cmdProcedureName, cmdSqlParameter);
            return dt; 
        }
    }
}
