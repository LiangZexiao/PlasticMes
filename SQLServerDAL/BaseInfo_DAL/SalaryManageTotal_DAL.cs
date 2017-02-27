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
    public class SalaryManageTotal_DAL
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        string SQL_SELECT = "SELECT EmployeeName,EmpID, sum(isnull(MachineWage,0)) 'MachineWage', sum(isnull(TimeWage,0))'TimeWage', sum(isnull(AdjustWage,0))'AdjustWage',  sum(isnull(OtherWage,0))'OtherWage', sum(isnull(MachineWage,0)+ isnull(TimeWage,0)+ isnull(AdjustWage,0)+ isnull(OtherWage,0)) 'TotalWage' " +
                           ",CheckWage, JobWage, ServiceWage " +
                           " FROM salarymanage" +
                           " WHERE 1=1 ";
        string SQL_SELECT2 = "SELECT EmpID 工号, EmployeeName 姓名,sum(isnull(MachineWage,0)) '计件工资', sum(isnull(TimeWage,0))'计时工资', sum(isnull(AdjustWage,0))'调整工资',  sum(isnull(OtherWage,0))'其它工资', sum(isnull(MachineWage,0)+ isnull(TimeWage,0)+ isnull(AdjustWage,0)+ isnull(OtherWage,0)) '总工资'," +
                             "CheckWage '考核工资', JobWage '岗位工资', ServiceWage '工龄工资' " +
                            " FROM SalaryManage WHERE 1=1 ";
    
        string SQL_INSERT = " INSERT INTO SalaryManage(EmployeeName, CardID, Do_No, MachineNO, MouldNo, ProductNo, ProductDesc, BeginDate, EndDate, " +
                            " AdjustWage,  Remark, CreateDate, WageFlag) " +
                            " VALUES(@EmployeeName, @CardID, @Do_No, @MachineNo, @MouldNo, @ProductNo, @ProductDesc, @BeginDate, @EndDate, @AdjustWage, " +
                            " @Remark, GetDate(), 3 )";

        string SQL_UPDATE = " UPDATE SalaryManage SET EmployeeName = @EmployeeName, CardID = @CardID, Do_No = @Do_No, MachineNo = @MachineNo, MouldNo = @MouldNo, ProductNo = @ProductNo, ProductDesc = @ProductDesc, " +
                            " BeginDate = @BeginDate, EndDate = @EndDate, AdjustWage = @AdjustWage, " +
                            "  Remark = @Remark,  CreateDate = Getdate() WHERE ID=@ID ";

        string SQL_DELETE = " DELETE SalaryManage WHERE ID = @ID ";

        public IList<SalaryManageTotal_MDL> selectSalaryManage() { return null; }
        public IList<SalaryManageTotal_MDL> selectSalaryManage(int id) { return null; }
        public IList<SalaryManageTotal_MDL> selectSalaryManage(int id, string colname, string coltext)
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

            IList<SalaryManageTotal_MDL> SalaryManageinfoList = new List<SalaryManageTotal_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" group by  EmployeeName,EmpID, CheckWage, JobWage, ServiceWage ORDER BY EmployeeName ").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryManageTotal_MDL SalaryManageinfo = new SalaryManageTotal_MDL(
                        
                        (sdr["EmployeeName"] == DBNull.Value) ? "" : sdr["EmployeeName"].ToString(),
                        //(sdr["CardID"] == DBNull.Value) ? "" : sdr["CardID"].ToString(),
                        //(sdr["Do_No"] == DBNull.Value) ? "" : sdr["Do_No"].ToString(),
                        //(sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString(),
                        //(sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString(),
                        //(sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString(),
                        //(sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString(),

                        //(sdr["BeginDate"] == DBNull.Value) ? "" : sdr["BeginDate"].ToString(),
                        //(sdr["EndDate"] == DBNull.Value) ? "" : sdr["EndDate"].ToString(),

                        (sdr["MachineWage"] == DBNull.Value) ? "" : sdr["MachineWage"].ToString(),
                        (sdr["TimeWage"] == DBNull.Value) ? "" : sdr["TimeWage"].ToString(),
                        (sdr["AdjustWage"] == DBNull.Value) ? "" : sdr["AdjustWage"].ToString(),
                        (sdr["OtherWage"] == DBNull.Value) ? "" : sdr["OtherWage"].ToString(),
                        (sdr["TotalWage"] == DBNull.Value) ? "" : sdr["TotalWage"].ToString(),
                        (sdr["CheckWage"] == DBNull.Value) ? "" : sdr["CheckWage"].ToString(),
                        (sdr["JobWage"] == DBNull.Value) ? "" : sdr["JobWage"].ToString(),
                        (sdr["ServiceWage"] == DBNull.Value) ? "" : sdr["ServiceWage"].ToString(),
                        (sdr["EmpID"] == DBNull.Value) ? "" : sdr["EmpID"].ToString()

                      
                        //(sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        //(sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString()
                        );
                    SalaryManageinfoList.Add(SalaryManageinfo);
                }
            }
            return SalaryManageinfoList;
        }
        public IList<SalaryManageTotal_MDL> selectSalaryManage(int id, string colname, string coltext, string BeginDate, string EndDate)
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
            if (BeginDate != "" && EndDate != "")
            {
                sqlCmd.Append(string.Format("AND CONVERT(CHAR(19),BeginDate,120) BETWEEN '{0}' AND '{1}' ", BeginDate, EndDate));
                sqlParas = null;
            }
            //注塑车间植毛车间单独统计
            if (colname == "注塑车间")
            {
                sqlCmd.Append(" AND (SUBSTRING(Machineno, 1,2) ='IM' AND substring(Machineno, 3,2) <>'04' ) ");
                sqlParas = null;
            }
            else if (colname == "植毛车间")
            {
                sqlCmd.Append(" AND (SUBSTRING(Machineno, 1,2) ='PM' OR substring(Machineno, 3,2) ='04' ) ");
                sqlParas = null;
            }

            IList<SalaryManageTotal_MDL> SalaryManageinfoList = new List<SalaryManageTotal_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" group by  EmployeeName,EmpID, CheckWage, JobWage, ServiceWage ORDER BY EmployeeName ").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryManageTotal_MDL SalaryManageinfo = new SalaryManageTotal_MDL(
                        //sdr.GetInt32(0),
                        (sdr["EmployeeName"] == DBNull.Value) ? "" : sdr["EMPLOYEENAME"].ToString(),
                        //(sdr["CardID"] == DBNull.Value) ? "" : sdr["CardID"].ToString(),
                        //(sdr["Do_No"] == DBNull.Value) ? "" : sdr["Do_No"].ToString(),
                        //(sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString(),
                        //(sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString(),
                        //(sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString(),
                        //(sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString(),

                        //(sdr["BeginDate"] == DBNull.Value) ? "" : sdr["BeginDate"].ToString(),
                        //(sdr["EndDate"] == DBNull.Value) ? "" : sdr["EndDate"].ToString(),
    
                        (sdr["MachineWage"] == DBNull.Value) ? "" : sdr["MachineWage"].ToString(),
                        (sdr["TimeWage"] == DBNull.Value) ? "" : sdr["TimeWage"].ToString(),
                        (sdr["AdjustWage"] == DBNull.Value) ? "" : sdr["AdjustWage"].ToString(),
                        (sdr["OtherWage"] == DBNull.Value) ? "" : sdr["OtherWage"].ToString(),
                        (sdr["TotalWage"] == DBNull.Value) ? "" : sdr["TotalWage"].ToString(),

                        (sdr["CheckWage"] == DBNull.Value) ? "" : sdr["CheckWage"].ToString(),
                        (sdr["JobWage"] == DBNull.Value) ? "" : sdr["JobWage"].ToString(),
                        (sdr["ServiceWage"] == DBNull.Value) ? "" : sdr["ServiceWage"].ToString(),
                        (sdr["EmpID"] == DBNull.Value) ? "" : sdr["EmpID"].ToString()
                        //(sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        //(sdr["CreateDate"] == DBNull.Value) ? "" : sdr["CreateDate"].ToString()
                        );
                    SalaryManageinfoList.Add(SalaryManageinfo);
                }
            }
            return SalaryManageinfoList;
        }
        public DataSet selectSalaryManage2(int id, string colname, string coltext, string BeginDate, string EndDate)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT2);
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
            if (BeginDate != "" && EndDate != "")
            {
                sqlCmd.Append(string.Format("AND CONVERT(CHAR(19),BeginDate,120) BETWEEN '{0}' AND '{1}' ", BeginDate, EndDate));
                sqlParas = null;
            }
            //注塑车间植毛车间单独统计
            if (colname == "注塑车间")
            {
                sqlCmd.Append(" AND (SUBSTRING(Machineno, 1,2) ='IM' AND substring(Machineno, 3,2) <>'04' ) ");
                sqlParas = null;
            }
            else if (colname == "植毛车间")
            {
                sqlCmd.Append(" AND (SUBSTRING(Machineno, 1,2) ='PM' OR substring(Machineno, 3,2) ='04' ) ");
                sqlParas = null;
            }

            IList<SalaryManageTotal_MDL> SalaryManageinfoList = new List<SalaryManageTotal_MDL>();
            return SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.Append(" group by  EmployeeName,EmpID, CheckWage, JobWage, ServiceWage ORDER BY EmployeeName ").ToString(), sqlParas);
            //using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID DESC").ToString(), sqlParas))
            //{
            //    while (sdr.Read())
            //    {
            //        SalaryManage_MDL SalaryManageinfo = new SalaryManage_MDL(
            //            sdr.GetInt32(0),
            //            (sdr["姓名"] == DBNull.Value) ? "" : sdr["姓名"].ToString(),
            //            (sdr["卡号"] == DBNull.Value) ? "" : sdr["卡号"].ToString(),
            //            (sdr["派工单号"] == DBNull.Value) ? "" : sdr["派工单号"].ToString(),
            //            (sdr["机器编号"] == DBNull.Value) ? "" : sdr["机器编号"].ToString(),
            //            (sdr["模具编号"] == DBNull.Value) ? "" : sdr["模具编号"].ToString(),
            //            (sdr["产品编号"] == DBNull.Value) ? "" : sdr["产品编号"].ToString(),
            //            (sdr["工资"] == DBNull.Value) ? "" : sdr["工资"].ToString(),
            //            (sdr["备注"] == DBNull.Value) ? "" : sdr["备注"].ToString()
            //            );
            //        SalaryManageinfoList.Add(SalaryManageinfo);
            //    }
            //}
            //return SalaryManageinfoList;
        }


        public IList<SalaryManageTotal_MDL> existsSalaryManage(string _DO_DO)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT DO_DO FROM SalaryManage WHERE DO_DO=@DO_DO");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_DO", SqlDbType.VarChar, _DO_DO) };

            IList<SalaryManageTotal_MDL> SalaryManageinfoList = new List<SalaryManageTotal_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryManageTotal_MDL SalaryManageinfo = new SalaryManageTotal_MDL((sdr["DO_DO"] == DBNull.Value) ? "" : sdr["DO_DO"].ToString());
                    SalaryManageinfoList.Add(SalaryManageinfo);
                }
            }
            return SalaryManageinfoList;
        }
        public IList<SalaryManageTotal_MDL> existsSalaryManage(string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("SELECT DISTINCT * FROM SalaryManage WHERE {0}=@ColText ", colname));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ColText", SqlDbType.VarChar, coltext) };

            IList<SalaryManageTotal_MDL> SalaryManageinfoList = new List<SalaryManageTotal_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SalaryManageTotal_MDL SalaryManageinfo = new SalaryManageTotal_MDL((sdr["DO_DO"] == DBNull.Value) ? "" : sdr["DO_DO"].ToString());
                    SalaryManageinfoList.Add(SalaryManageinfo);
                }
            }
            return SalaryManageinfoList;
        }

        public int ChangeSalaryManage(SalaryManageTotal_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@EmployeeName", SqlDbType.VarChar, obj.EmployeeName),

                fsp.FormatInParam("@MachineWage", SqlDbType.VarChar, obj.MachineWage),
                fsp.FormatInParam("@TimeWage", SqlDbType.VarChar, obj.TimeWage),
                fsp.FormatInParam("@AdjustWage", SqlDbType.VarChar, obj.AdjustWage),               
                fsp.FormatInParam("@OtherWage", SqlDbType.VarChar, obj.OtherWage),
                fsp.FormatInParam("@TotalWage", SqlDbType.VarChar, obj.TotalWage),
                fsp.FormatInParam("@CheckWage", SqlDbType.VarChar, obj.CheckWage),
                fsp.FormatInParam("@JobWage", SqlDbType.VarChar, obj.JobWage),
                fsp.FormatInParam("@ServiceWage", SqlDbType.VarChar, obj.ServiceWage)


        
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

        public void deleteSalaryManage(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelSalaryManage(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE SalaryManage WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
                            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int InsertIntoSalaryManage(string beginDate, string EndDate)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@BeginDate", SqlDbType.DateTime, beginDate), fsp.FormatInParam("@EndDate", SqlDbType.DateTime, EndDate) };

            IList<SalaryManageTotal_MDL> SalaryManagelist = new List<SalaryManageTotal_MDL>();
            int t = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "InsertIntoSalaryManage", sqlParas);
            return t;
        }
    }
}
