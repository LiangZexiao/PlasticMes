using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.DBUtility;
using Admin.IDAL.Product_IDAL;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class ManMachineMap_DAL : IManMachineMap
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();

        const string SQL_SELECT = "SELECT DISTINCT a.ID, a.EmployeeID, EmployeeName_CN,MachineNo, WorkGrade, CONVERT(CHAR(10),WorkDate,121) WorkDate, Remark FROM ManMachineMap a LEFT JOIN Employee b ON a.EmployeeID=b.EmployeeID WHERE 1=1";
        const string SQL_INSERT = @"INSERT INTO ManMachineMap(EmployeeID, MachineNo, WorkGrade, WorkDate, Remark) VALUES(@EmployeeID, @MachineNo, @WorkGrade, @WorkDate, @Remark)";
        const string SQL_UPDATE = @"UPDATE ManMachineMap SET EmployeeID=@EmployeeID, MachineNo=@MachineNo, WorkGrade=@WorkGrade, WorkDate=@WorkDate, Remark=@Remark WHERE ID=@ID";
        const string SQL_DELETE = "DELETE ManMachineMap WHERE ID=@ID";//MaterialNum2=@MaterialNum2,

        public IList<ManMachineMap_MDL> selectManMachineMap(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlCmd.Append(string.Format("AND a.ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            IList<ManMachineMap_MDL> ManMachineMapList = new List<ManMachineMap_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ManMachineMap_MDL ManMachineMap = new ManMachineMap_MDL(sdr.GetInt32(0),
                         (sdr["EmployeeID"] == DBNull.Value) ? "" : sdr["EmployeeID"].ToString(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString(),
                         (sdr["WorkGrade"] == DBNull.Value) ? "" : sdr["WorkGrade"].ToString(),
                         (sdr["WorkDate"] == DBNull.Value) ? "" : sdr["WorkDate"].ToString(),
                         (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                         (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString()
                        );
                    ManMachineMapList.Add(ManMachineMap);
                }
            }
            return ManMachineMapList;
        }

        public IList<ManMachineMap_MDL> existsManMachineMap(string EmployeeID)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = { fsp.FormatInParam("@EmployeeID", SqlDbType.VarChar, EmployeeID) };

            sqlCmd.Append(string.Format(" AND EmployeeID=@EmployeeID"));
            IList<ManMachineMap_MDL> ManMachineMapList = new List<ManMachineMap_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ManMachineMap_MDL ManMachineMap = new ManMachineMap_MDL(sdr.GetInt32(0),
                         (sdr["EmployeeID"] == DBNull.Value) ? "" : sdr["EmployeeID"].ToString(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString(),
                         (sdr["WorkGrade"] == DBNull.Value) ? "" : sdr["WorkGrade"].ToString(),
                         (sdr["WorkDate"] == DBNull.Value) ? "" : sdr["WorkDate"].ToString(),
                         (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                         (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString()
                       );
                    ManMachineMapList.Add(ManMachineMap);
                }
            }
            return ManMachineMapList;
        }

        public void insertManMachineMap(
             string vEmployeeID, string vMachineNo, string vWorkGrade, string vWorkDate,string vRemark)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@EmployeeID", SqlDbType.VarChar,vEmployeeID),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, vMachineNo),
                fsp.FormatInParam("@WorkGrade", SqlDbType.VarChar, vWorkGrade),
                fsp.FormatInParam("@WorkDate", SqlDbType.VarChar, vWorkDate),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, vRemark)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
        }

        public void updateManMachineMap(int vID,
            string vEmployeeID, string vMachineNo, string vWorkGrade, string vWorkDate, string vRemark)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@EmployeeID", SqlDbType.VarChar,vEmployeeID),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, vMachineNo),
                fsp.FormatInParam("@WorkGrade", SqlDbType.VarChar, vWorkGrade),
                fsp.FormatInParam("@WorkDate", SqlDbType.VarChar, vWorkDate),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, vRemark),
                fsp.FormatInParam("@ID", SqlDbType.Int, vID)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }

        public void deleteManMachineMap(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelManMachineMap(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE ManMachineMap WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

    }
}
