using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using Admin.IDAL.Adminis_IDAL;
using Admin.Model.Adminis_MDL;


namespace Admin.SQLServerDAL.Adminis_DAL
{
    public class UserProgramMap_DAL : IUserProgramMap
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT ID, UserID, ProgramID,ProgramName, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, aDate, mDate FROM View_UserProgramMap WHERE 1=1 and userid<>'admin' ";
        private const string SQL_INSERT = "INSERT INTO UserProgramMap(UserID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, aDate, mDate) VALUES(@UserID, @ProgramID, @AddFlag, @CnlFlag,@MdyFlag,@QuyFlag,@PrtFlag, @ChkFlag,@ChkFlagNO, @aDate, @mDate)";
        private const string SQL_UPDATE = "UPDATE UserProgramMap SET UserID=@UserID, ProgramID=@ProgramID, AddFlag=@AddFlag, CnlFlag=@CnlFlag, MdyFlag=@MdyFlag, QuyFlag=@QuyFlag, PrtFlag=@PrtFlag, ChkFlag=@ChkFlag,ChkFlagNO=@ChkFlagNO, mDate=@mDate  WHERE ID=@ID";
        private const string SQL_DELETE = "DELETE UserProgramMap WHERE ID=@ID";

        public IList<UserProgramMap_MDL> selectUserProgramMap() { return null; }
        public IList<UserProgramMap_MDL> selectUserProgramMap(int id) { return null; }
        public IList<UserProgramMap_MDL> selectUserProgramMap(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlWhere.Append(string.Format(" AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            return getDataListOfUserProgramMap(sqlWhere, sqlParas);
        }
        public IList<UserProgramMap_MDL> existsUserProgramMap(string UserID, string ProgramID)
        {            
            StringBuilder sqlWhere = new StringBuilder(string.Format("AND UserID=@UserID AND ProgramID=@ProgramID"));
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@UserID", SqlDbType.VarChar, UserID),
                fsp.FormatInParam("@ProgramID",SqlDbType.VarChar, ProgramID) 
            };

            return getDataListOfUserProgramMap(sqlWhere, sqlParas);
        }

        private IList<UserProgramMap_MDL> getDataListOfUserProgramMap(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            sqlCmd.Append(sqlWhere.Append(" ORDER BY userid,classid,orderid ").ToString());

            IList<UserProgramMap_MDL> userprogrammapList = new List<UserProgramMap_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    UserProgramMap_MDL userprogrammap = new UserProgramMap_MDL(
                        sdr.GetInt32(0),
                        (sdr["UserID"] == DBNull.Value) ? "" : sdr["UserID"].ToString().Trim(),
                        (sdr["ProgramID"] == DBNull.Value) ? "" : sdr["ProgramID"].ToString().Trim(),
                        (sdr["ProgramName"] == DBNull.Value) ? "" : sdr["ProgramName"].ToString().Trim(),
                        (sdr["AddFlag"] == DBNull.Value) ? "0" : sdr["AddFlag"].ToString().Trim(),
                        (sdr["CnlFlag"] == DBNull.Value) ? "0" : sdr["CnlFlag"].ToString().Trim(),
                        (sdr["MdyFlag"] == DBNull.Value) ? "0" : sdr["MdyFlag"].ToString().Trim(),
                        (sdr["QuyFlag"] == DBNull.Value) ? "0" : sdr["QuyFlag"].ToString().Trim(),
                        (sdr["PrtFlag"] == DBNull.Value) ? "0" : sdr["PrtFlag"].ToString().Trim(),
                        (sdr["ChkFlag"] == DBNull.Value) ? "0" : sdr["ChkFlag"].ToString().Trim(),
                        (sdr["ChkFlagNO"] == DBNull.Value) ? "0" : sdr["ChkFlagNO"].ToString().Trim(),
                        (sdr["aDate"] == DBNull.Value) ? "" : sdr["aDate"].ToString().Trim(),
                        (sdr["mDate"] == DBNull.Value) ? "" : sdr["mDate"].ToString().Trim()
                        );
                    userprogrammapList.Add(userprogrammap);
                }
            }
            return userprogrammapList;
        }

        public int ChangeUserProgramMap(UserProgramMap_MDL obj, string IU)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@UserID",SqlDbType.VarChar, obj.UserID),
                fsp.FormatInParam("@ProgramID",SqlDbType.VarChar, obj.ProgramID),
                fsp.FormatInParam("@AddFlag",SqlDbType.Char, obj.AddFlag),
                fsp.FormatInParam("@CnlFlag",SqlDbType.Char, obj.CnlFlag),
                fsp.FormatInParam("@MdyFlag",SqlDbType.Char, obj.MdyFlag),
                fsp.FormatInParam("@QuyFlag",SqlDbType.Char, obj.QuyFlag),
                fsp.FormatInParam("@PrtFlag",SqlDbType.Char, obj.PrtFlag),
                fsp.FormatInParam("@ChkFlag",SqlDbType.Char, obj.ChkFlag),
                fsp.FormatInParam("@ChkFlagNO",SqlDbType.Char, obj.ChkFlagNO),
                fsp.FormatInParam("@aDate",SqlDbType.DateTime, obj.aDate),
                fsp.FormatInParam("@mDate",SqlDbType.DateTime, obj.mDate),
                fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
            if (IU.ToUpper() == "INSERT")
               return  SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
               return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }
        //
        public void deleteUserProgramMap(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelUserProgramMap(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE UserProgramMap WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
