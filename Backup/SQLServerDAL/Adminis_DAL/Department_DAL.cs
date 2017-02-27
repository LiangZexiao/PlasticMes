using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.IDAL.Adminis_IDAL;
using Admin.Model.Adminis_MDL;

namespace Admin.SQLServerDAL.Adminis_DAL
{
    public class Department_DAL : IDepartment
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT DISTINCT ID, DeptID, DeptName, Manger, Remark FROM Department WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO Department(DeptID, DeptName, Manger, Remark) VALUES(@DeptID,@DeptName,@Manger,@Remark)";
        private const string SQL_UPDATE = "UPDATE Department SET DeptID=@DeptID, DeptName=@DeptName, Manger=@Manger, Remark=@Remark WHERE ID=@ID";

        public IList<Department_MDL> selectDepartment() { return null; }
        public IList<Department_MDL> selectDepartment(int id) { return null; }
        public IList<Department_MDL> selectDepartment(int id, string colname, string coltext)
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

            return getListDepartment(sqlWhere, sqlParas);
        }

        public IList<Department_MDL> existsDepartment(string _DeptID)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format("AND DeptID=@DeptID"));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DeptID", SqlDbType.Int, _DeptID) };

            return getListDepartment(sqlWhere, sqlParas);
        }

        private IList<Department_MDL> getListDepartment(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            sqlCmd.Append(sqlWhere);

            IList<Department_MDL> programinfo = new List<Department_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY DeptID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    Department_MDL department = new Department_MDL(
                        sdr.GetInt32(0),
                        (sdr["DeptID"] == DBNull.Value) ? "" : sdr["DeptID"].ToString().Trim(),
                        (sdr["DeptName"] == DBNull.Value) ? "" : sdr["DeptName"].ToString().Trim(),
                        (sdr["Manger"] == DBNull.Value) ? "" : sdr["Manger"].ToString().Trim(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString().Trim()
                        );
                    programinfo.Add(department);
                }
            }
            return programinfo;
        }

        public void ChangeDepartment(Department_MDL obj, string IU)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@DeptID",SqlDbType.VarChar, obj.DeptID),
                fsp.FormatInParam("@DeptName",SqlDbType.VarChar, obj.DeptName),
                fsp.FormatInParam("@Manger",SqlDbType.VarChar, obj.Manger),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, obj.Remark),
                fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
            if(IU == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }

        //
        public void deleteDepartment(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE Department WHERE ID=@ID", sqlParas);
        }

        public void cancelDepartment(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE Department WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
