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
    public class UserInfo_DAL : IUserInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();
        //private const string SELECT_USERINFO = "SELECT ID, UserID, UserName, Password, Sex, Email, DeptID, GroupID, IsLock, LastIP, aDate, mDate, cDate FROM SysUserInfo WHERE 1=1 ";
        private const string SELECT_USERINFO = "SELECT ID, UserID, UserName, EmployeeName_CN, Password, Sex, Email, DeptID, GroupID, IsLock, LastIP, aDate, mDate, cDate,DeptName,GroupName FROM View_SysUserInfo WHERE 1=1 and userid<>'admin' ";
        private const string SELECT_USERINF2 = "SELECT ID, UserID, UserName, EmployeeName_CN, Password, Sex, Email, DeptID, GroupID, IsLock, LastIP, aDate, mDate, cDate,DeptName,GroupName FROM View_SysUserInfo WHERE 1=1  ";
        private const string INSERT_USERINFO = "INSERT INTO SysUserInfo(UserID, UserName, Password, Sex, Email, DeptID,GroupID, IsLock, LastIP, aDate, mDate) VALUES(@userid,@username,@password,@sex,@email,@deptid,@GroupID,@islock,@lastip,@aDate,@mDate)";
        //private const string UPDATE_USERINFO = "UPDATE SysUserInfo SET UserID=@userid, UserName=@username, Password=@password, Sex=@sex, Email=@email, DeptID=@deptid,GroupID=@GroupID,IsLock=@islock, LastIP=@lastip, mDate=@mDate WHERE ID=@ID";
        private const string UPDATE_USERINFO = "UPDATE SysUserInfo SET UserID=@userid, UserName=@username, Sex=@sex, Email=@email, DeptID=@deptid,GroupID=@GroupID,IsLock=@islock, LastIP=@lastip, mDate=@mDate WHERE ID=@ID";
        private const string UPDATE_USERINFO2 = "UPDATE SysUserInfo SET LastIP=@lastip, mDate=@mDate WHERE ID=@ID";
        private const string UPDATE_USERINFO3 = "UPDATE SysUserInfo SET Password=@Password WHERE UserID=@UserID";
        private const string DELETE_USERINFO = "DELETE SysUserInfo WHERE ID=@ID";

        public IList<UserInfo_MDL> selectUserInfo() { return null; }
        public IList<UserInfo_MDL> selectUserInfo(int id)
        {
            StringBuilder sqlCmd = new StringBuilder(SELECT_USERINFO);
            sqlCmd.Append(string.Format("WHERE ID=@ID"));
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, id) };

            return getListUserInfo(sqlCmd, sqlParas);
        }

        public IList<UserInfo_MDL> selectUserInfo(string userid, string password)
        {
            StringBuilder sqlCmd = new StringBuilder(SELECT_USERINF2);
            sqlCmd.Append("AND UserID=@UserID AND Password=@Password");
            SqlParameter[] sqlParas = new SqlParameter[]{
                fsp.FormatInParam("@UserID", SqlDbType.VarChar, userid),
                fsp.FormatInParam("@Password", SqlDbType.VarChar, password)
            };
        
            return getListUserInfo(sqlCmd, sqlParas);
        }

        public IList<UserInfo_MDL> selectUserInfo(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SELECT_USERINFO);
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlCmd.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0}='" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
                sqlParas = null;
            }

            return getListUserInfo(sqlCmd, sqlParas);
        }

        public IList<UserInfo_MDL> existsUserInfo(string UserID)
        {
            StringBuilder sqlCmd = new StringBuilder(SELECT_USERINF2);            
            sqlCmd.Append(string.Format("AND UserID=@UserID"));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@UserID", SqlDbType.VarChar, UserID) };

            return getListUserInfo(sqlCmd, sqlParas);
        }

        private IList<UserInfo_MDL> getListUserInfo(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            IList<UserInfo_MDL> userinfoList = new List<UserInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlWhere.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    UserInfo_MDL userinfo = new UserInfo_MDL(
                            sdr.GetInt32(0),
                            (sdr["UserID"] == DBNull.Value) ? "" : sdr["UserID"].ToString().Trim(),
                            (sdr["UserName"] == DBNull.Value) ? "" : sdr["UserName"].ToString().Trim(),
                            (sdr["EmployeeName_CN"] == DBNull.Value) ? "" : sdr["EmployeeName_CN"].ToString().Trim(),
                            (sdr["Password"] == DBNull.Value) ? "" : sdr["Password"].ToString().Trim(),
                            (sdr["Sex"] == DBNull.Value) ? "" : sdr["Sex"].ToString().Trim(),
                            (sdr["Email"] == DBNull.Value) ? "" : sdr["Email"].ToString().Trim(),
                            (sdr["DeptID"] == DBNull.Value) ? "" : sdr["DeptID"].ToString().Trim(),
                            (sdr["GroupID"] == DBNull.Value) ? "" : sdr["GroupID"].ToString().Trim(),
                            (sdr["IsLock"] == DBNull.Value) ? "" : sdr["IsLock"].ToString().Trim(),
                            (sdr["LastIP"] == DBNull.Value) ? "" : sdr["LastIP"].ToString().Trim(),
                            (sdr["aDate"] == DBNull.Value) ? "" : sdr["aDate"].ToString().Trim(),
                            (sdr["mDate"] == DBNull.Value) ? "" : sdr["mDate"].ToString().Trim(),
                            (sdr["cDate"] == DBNull.Value) ? "" : sdr["cDate"].ToString().Trim(),
                            (sdr["DeptName"] == DBNull.Value) ? "" : sdr["DeptName"].ToString().Trim(),
                            (sdr["GroupName"] == DBNull.Value) ? "" : sdr["GroupName"].ToString().Trim()
                        );
                    userinfoList.Add(userinfo);
                }
            }
            return userinfoList;
        }

        public int insertUserInfo(string userid, string username, string password, string sex, string email,
            string deptid,string groupid, string islock, string lastip, DateTime aDate, DateTime mDate)
        {
            try
            {
                SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@userid",SqlDbType.VarChar, userid),
                fsp.FormatInParam("@username",SqlDbType.VarChar, username),
                fsp.FormatInParam("@password",SqlDbType.VarChar, password),
                fsp.FormatInParam("@sex",SqlDbType.VarChar, sex),
                fsp.FormatInParam("@email",SqlDbType.VarChar, email),
                fsp.FormatInParam("@deptid",SqlDbType.VarChar, deptid),
                fsp.FormatInParam("@GroupID",SqlDbType.VarChar, groupid),
                fsp.FormatInParam("@islock",SqlDbType.VarChar, islock),
                fsp.FormatInParam("@lastip",SqlDbType.VarChar, lastip),
                fsp.FormatInParam("@aDate",SqlDbType.DateTime, aDate),
                fsp.FormatInParam("@mDate",SqlDbType.DateTime, mDate)
            };
                return SqlHelper.ExecuteNonQuery(CommandType.Text, INSERT_USERINFO, sqlParas);
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        public int updateUserInfo(int id, string userid, string username, string password, string sex, string email,
            string deptid, string groupid, string islock, string lastip, DateTime mDate)
        {
            try
            {
                SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@userid",SqlDbType.VarChar, userid),
                fsp.FormatInParam("@username",SqlDbType.VarChar, username),
                fsp.FormatInParam("@password",SqlDbType.VarChar, password),
                fsp.FormatInParam("@sex",SqlDbType.VarChar, sex),
                fsp.FormatInParam("@email",SqlDbType.VarChar, email),
                fsp.FormatInParam("@deptid",SqlDbType.VarChar, deptid),
                fsp.FormatInParam("@GroupID",SqlDbType.VarChar, groupid),
                fsp.FormatInParam("@islock",SqlDbType.VarChar, islock),
                fsp.FormatInParam("@lastip",SqlDbType.VarChar, lastip),
                fsp.FormatInParam("@mDate",SqlDbType.DateTime, mDate),
                fsp.FormatInParam("@ID",SqlDbType.Int, id)
                };

                return SqlHelper.ExecuteNonQuery(CommandType.Text, UPDATE_USERINFO, sqlParas);
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        public int updateUserInfo(int id, string lastip, DateTime mDate)
        {
            try
            {
                SqlParameter[] sqlParas ={
                fsp.FormatInParam("@lastip",SqlDbType.VarChar, lastip),
                fsp.FormatInParam("@mDate",SqlDbType.DateTime, mDate),
                fsp.FormatInParam("@ID",SqlDbType.Int, id)
                 };

                return SqlHelper.ExecuteNonQuery(CommandType.Text, UPDATE_USERINFO2, sqlParas);
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int updateUserInfo(string userid, string password)
        {
            try
            {
                SqlParameter[] sqlParas ={
                fsp.FormatInParam("@UserID", SqlDbType.VarChar, userid),
                fsp.FormatInParam("@Password", SqlDbType.VarChar, password)
                };

               return SqlHelper.ExecuteNonQuery(CommandType.Text, UPDATE_USERINFO3, sqlParas);
            }
            catch (Exception ec)
            {
                return -1;
            }

        }
        //
        public void deleteUserInfo(int id)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, DELETE_USERINFO, sqlParas);
        }

        public void cancelUserInfo(ArrayList idlist)
        {
            string BATCH_USERINFO = "BEGIN TRANSACTION ";
            foreach (string s in idlist)
            {
                BATCH_USERINFO += string.Format("DELETE UserProgramMap WHERE userid=(select userid from SysUserInfo where id={0} ) IF(@@ERROR<>0) GOTO StopDot ", s);
                BATCH_USERINFO += string.Format("DELETE SysUserInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            BATCH_USERINFO += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, BATCH_USERINFO, null);
        }
    }
}