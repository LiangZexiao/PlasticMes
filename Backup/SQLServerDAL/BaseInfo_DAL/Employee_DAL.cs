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
    public class Employee_DAL : IEmployeeInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT ="SELECT ID, EmployeeID, EmployeeName_CN, Photo, IDCardNo, Sex, Birthday, Department, DeptName,Province, RankLevel, Rank, RankDesc, HireDate, Remark,Tel,IcCardNo,DeptID,EMail,IcCardRight,InvalidCode,Invalid  FROM View_Employee WHERE 1=1 and employeeid<>'admin'";
        private const string SQL_SELECTS = "SELECT ID, EmployeeID, EmployeeName_CN,  Photo,IDCardNo, Sex, Birthday, Department, DeptName, Province, RankLevel, Rank, RankDesc, HireDate, Remark,Tel,IcCardNo,DeptID,EMail,IcCardRight,InvalidCode,Invalid  FROM View_Employee WHERE 1=1 ";

        private const string SQL_INSERT = "INSERT INTO Employee(EmployeeID, EmployeeName_CN,  Photo,  IDCardNo, Sex, Birthday, Department, Province, RankLevel, Rank, RankDesc, HireDate, Remark,Tel,EMail,Invalid) VALUES(@EmployeeID, @EmployeeName_CN,  @Photo,  @IDCardNo, @Sex, @Birthday, @Department, @Province, @RankLevel, @Rank, @RankDesc, @HireDate, @Remark,@Tel,@EMail,@Invalid)";
        private const string SQL_INSERT2 = "INSERT INTO Employee(EmployeeID, EmployeeName_CN,  IDCardNo, Sex, Birthday, Department, Province, RankLevel, Rank, RankDesc, HireDate, Remark,Tel,EMail,Invalid) VALUES(@EmployeeID, @EmployeeName_CN, @IDCardNo, @Sex, @Birthday, @Department, @Province, @RankLevel, @Rank, @RankDesc, @HireDate, @Remark,@Tel,@EMail,@Invalid)";
        private const string SQL_UPDATE = "UPDATE Employee SET EmployeeName_CN=@EmployeeName_CN,  Photo=@Photo,  IDCardNo=@IDCardNo, Sex=@Sex, Birthday=@Birthday, Department=@Department, Province=@Province, RankLevel=@RankLevel, Rank=@Rank, RankDesc=@RankDesc,HireDate=@HireDate, Remark=@Remark,Tel=@Tel,EMail=@EMail,Invalid=@Invalid WHERE ID=@ID ";
        private const string SQL_UPDATE2 = "UPDATE Employee SET EmployeeName_CN=@EmployeeName_CN, IDCardNo=@IDCardNo, Sex=@Sex, Birthday=@Birthday, Department=@Department, Province=@Province, RankLevel=@RankLevel, Rank=@Rank, RankDesc=@RankDesc,HireDate=@HireDate, Remark=@Remark,Tel=@Tel,EMail=@EMail,Invalid=@Invalid WHERE ID=@ID ";
        private const string SQL_DELETE = "DELETE Employee WHERE ID=@ID";
        private const string SQL_SELECT2 = @"SELECT distinct EmployeeName_CN,EmployeeID FROM Employee
                                           WHERE  1=1 and rankdesc in('领班','质检','机修') and invalid=1  ";

        public IList<Employee_MDL> selectEmployee() { return null; }
        public IList<Employee_MDL> selectEmployee(int id) { return null; }
        public IList<Employee_MDL> selectEmployee(int id, string colname, string coltext)
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

            IList<Employee_MDL> employeeinfoList = new List<Employee_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY EmployeeName_CN asc").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    Employee_MDL employeeinfo = new Employee_MDL(
                        sdr.GetInt32(0),
                        (sdr["EmployeeID"] == DBNull.Value) ? "" : sdr["EmployeeID"].ToString(),
                        (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString(),
                        (sdr["Photo"] == DBNull.Value) ? null : (byte[])sdr["Photo"],

                        (sdr["IDCardNo"] == DBNull.Value) ? "" : sdr["IDCardNo"].ToString(),
                        (sdr["Sex"] == DBNull.Value) ? "男" : sdr["Sex"].ToString(),
                        (sdr["Birthday"] == DBNull.Value) ? "" : sdr["Birthday"].ToString(),
                        (sdr["Department"] == DBNull.Value) ? "" : sdr["Department"].ToString(),

                        (sdr["DeptName"] == DBNull.Value) ? "" : sdr["DeptName"].ToString(),
                        (sdr["Province"] == DBNull.Value) ? "" : sdr["Province"].ToString(),
                        (sdr["RankLevel"] == DBNull.Value) ? "" : sdr["RankLevel"].ToString(),
                        (sdr["Rank"] == DBNull.Value) ? "" : sdr["Rank"].ToString(),
                        (sdr["RankDesc"] == DBNull.Value) ? "" : sdr["RankDesc"].ToString(),

                        (sdr["HireDate"] == DBNull.Value) ? "" : sdr["HireDate"].ToString(),
                        (sdr["Tel"] == DBNull.Value) ? "" : sdr["Tel"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["IcCardNo"] == DBNull.Value) ? "" : sdr["IcCardNo"].ToString(),
                        (sdr["DeptID"] == DBNull.Value) ? "" : sdr["DeptID"].ToString(),
                        (sdr["EMail"] == DBNull.Value) ? "" : sdr["EMail"].ToString(),
                        (sdr["IcCardRight"] == DBNull.Value) ? "" : sdr["IcCardRight"].ToString(),
                        (sdr["InvalidCode"] == DBNull.Value) ? "" : sdr["InvalidCode"].ToString(),
                        (sdr["Invalid"] == DBNull.Value) ? "" : sdr["Invalid"].ToString()
                        );
                    employeeinfoList.Add(employeeinfo);
                }
            }
            return employeeinfoList;
        }
        public DataTable  selectEmployee(string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT2);
            
            SqlParameter[] sqlParas = null;

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            return SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.Append(" ORDER BY EmployeeName_CN asc").ToString(), sqlParas);
        }


        public IList<Employee_MDL> selectEmployee(int id, string colname, string coltext,bool flag)
        {
            StringBuilder sqlCmd = new StringBuilder(flag ? SQL_SELECT : SQL_SELECTS);
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

            IList<Employee_MDL> employeeinfoList = new List<Employee_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY EmployeeID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    Employee_MDL employeeinfo = new Employee_MDL(
                        sdr.GetInt32(0),
                        (sdr["EmployeeID"] == DBNull.Value) ? "" : sdr["EmployeeID"].ToString(),
                        (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString(),
                        (sdr["Photo"] == DBNull.Value) ? null : (byte[])sdr["Photo"],

                        (sdr["IDCardNo"] == DBNull.Value) ? "" : sdr["IDCardNo"].ToString(),
                        (sdr["Sex"] == DBNull.Value) ? "男" : sdr["Sex"].ToString(),
                        (sdr["Birthday"] == DBNull.Value) ? "" : sdr["Birthday"].ToString(),
                        (sdr["Department"] == DBNull.Value) ? "" : sdr["Department"].ToString(),

                        (sdr["DeptName"] == DBNull.Value) ? "" : sdr["DeptName"].ToString(),
                        (sdr["Province"] == DBNull.Value) ? "" : sdr["Province"].ToString(),
                        (sdr["RankLevel"] == DBNull.Value) ? "" : sdr["RankLevel"].ToString(),
                        (sdr["Rank"] == DBNull.Value) ? "" : sdr["Rank"].ToString(),
                        (sdr["RankDesc"] == DBNull.Value) ? "" : sdr["RankDesc"].ToString(),

                        (sdr["HireDate"] == DBNull.Value) ? "" : sdr["HireDate"].ToString(),
                        (sdr["Tel"] == DBNull.Value) ? "" : sdr["Tel"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["IcCardNo"] == DBNull.Value) ? "" : sdr["IcCardNo"].ToString(),
                        (sdr["DeptID"] == DBNull.Value) ? "" : sdr["DeptID"].ToString(),
                        (sdr["EMail"] == DBNull.Value) ? "" : sdr["EMail"].ToString(),
                        (sdr["IcCardRight"] == DBNull.Value) ? "" : sdr["IcCardRight"].ToString(),
                        (sdr["InvalidCode"] == DBNull.Value) ? "" : sdr["InvalidCode"].ToString(),
                        (sdr["Invalid"] == DBNull.Value) ? "" : sdr["Invalid"].ToString()
                        );
                    employeeinfoList.Add(employeeinfo);
                }
            }
            return employeeinfoList;
        }

        public IList<Employee_MDL> existsEmployee(string _EmployeeID)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT EmployeeID FROM Employee WHERE EmployeeID=@EmployeeID");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@EmployeeID", SqlDbType.VarChar, _EmployeeID) };

            IList<Employee_MDL> employeeinfoList = new List<Employee_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    Employee_MDL employeeinfo = new Employee_MDL((sdr["EmployeeID"] == DBNull.Value) ? "0" : sdr["EmployeeID"].ToString());
                    employeeinfoList.Add(employeeinfo);
                }
            }
            return employeeinfoList;
        }

        public int ChangeEmployee(Employee_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@EmployeeID", SqlDbType.VarChar, obj.EmployeeID),
                fsp.FormatInParam("@EmployeeName_CN", SqlDbType.VarChar, obj.EmployeeName_CN),
                fsp.FormatInParam("@Photo", SqlDbType.Image, obj.Photo),
                fsp.FormatInParam("@IDCardNo", SqlDbType.VarChar, obj.IDCardNo),
                fsp.FormatInParam("@Sex", SqlDbType.VarChar, obj.Sex),
                fsp.FormatInParam("@Birthday", SqlDbType.DateTime, obj.Birthday),
                fsp.FormatInParam("@Department", SqlDbType.VarChar, obj.Department),
                fsp.FormatInParam("@Province", SqlDbType.VarChar, obj.Province),

                fsp.FormatInParam("@RankLevel", SqlDbType.VarChar, obj.RankLevel),
                fsp.FormatInParam("@Rank", SqlDbType.VarChar, obj.Rank),
                fsp.FormatInParam("@RankDesc", SqlDbType.VarChar, obj.RankDesc),
                fsp.FormatInParam("@HireDate", SqlDbType.DateTime, obj.HireDate),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark),
                fsp.FormatInParam("@Tel",SqlDbType.VarChar,obj.Tel),
                fsp.FormatInParam("@EMail",SqlDbType.VarChar,obj.EMail),
                fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID),
                fsp.FormatInParam("@Invalid", SqlDbType.Int, obj.Invalid)
            };
            byte[] temp_Photo = obj.Photo;
            object temp_PhotoType = "";// obj.PhotoType;
            string sqlCmd = string.Empty;
            if (temp_Photo.Length == 0 || temp_PhotoType == null)
                sqlCmd = (IU.ToUpper() == "INSERT") ? SQL_INSERT2 : SQL_UPDATE2;
            else
                sqlCmd = (IU.ToUpper() == "INSERT") ? SQL_INSERT : SQL_UPDATE;

           return  SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCmd, sqlParas);
        }

        public void deleteEmployee(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelEmployee(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE Employee WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
