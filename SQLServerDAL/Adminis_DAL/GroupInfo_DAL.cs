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
    public class GroupInfo_DAL : IGroupInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();
        
        private const string SQL_SELECT = "SELECT DISTINCT ID, GroupID, GroupName, Header, Action, MemberNum, Remark, aDate, mDate FROM GroupInfo WHERE 1=1 ";
        private const string SQL_SELECT2 = "SELECT DISTINCT ID, GroupID, GroupName, Header, Action, MemberNum, Remark, aDate, mDate FROM GroupInfo WHERE 1=1 AND GroupID<>'1' ";
        private const string SQL_INSERT = "INSERT INTO GroupInfo(GroupID, GroupName, Header, Action, MemberNum, Remark, aDate, mDate) VALUES(@GroupID, @GroupName, @Header, @Action, @MemberNum, @Remark, GETDATE(), GETDATE())";
        private const string SQL_UPDATE = "UPDATE GroupInfo SET GroupID=@GroupID, GroupName=@GroupName, Header=@Header,Action=@Action,MemberNum=@MemberNum, Remark=@Remark,mDate=GETDATE() WHERE ID=@ID";
        private const string SQL_DELETE = "DELETE GroupInfo WHERE ID=@ID";

        public IList<GroupInfo_MDL> selectGroupInfo() { return null; }
        public IList<GroupInfo_MDL> selectGroupInfo(int id) { return null; }
        public IList<GroupInfo_MDL> selectGroupInfo(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(" AND ID=@ID");
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            return getListOfGroupInfo(sqlWhere, sqlParas);
        }
        public IList<GroupInfo_MDL> selectGroupInfo(int id, string colname, string coltext,int t)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(" AND ID=@ID");
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }

            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

          
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT2);
            sqlCmd.Append(sqlWhere);

            IList<GroupInfo_MDL> groupinfolist = new List<GroupInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY GroupID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    GroupInfo_MDL groupinfo = new GroupInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr["GroupID"] == DBNull.Value) ? "" : sdr["GroupID"].ToString().Trim(),
                        (sdr["GroupName"] == DBNull.Value) ? "" : sdr["GroupName"].ToString().Trim(),
                        (sdr["Header"] == DBNull.Value) ? "" : sdr["Header"].ToString().Trim(),
                        (sdr["Action"] == DBNull.Value) ? "" : sdr["Action"].ToString().Trim(),
                        (sdr["MemberNum"] == DBNull.Value) ? 0 : int.Parse(sdr["MemberNum"].ToString().Trim()),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString().Trim(),
                        (sdr["aDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["aDate"].ToString().Trim()),
                        (sdr["mDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["mDate"].ToString().Trim())
                        );
                    groupinfolist.Add(groupinfo);
                }
            }
            return groupinfolist;
        }

        public IList<GroupInfo_MDL> existsGroupInfo(string GroupID)
        {
            StringBuilder sqlWhere = new StringBuilder(" AND GroupID=@GroupID");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@GroupID", SqlDbType.VarChar, GroupID) };

            return getListOfGroupInfo(sqlWhere, sqlParas);
        }

        private IList<GroupInfo_MDL> getListOfGroupInfo(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            sqlCmd.Append(sqlWhere);

            IList<GroupInfo_MDL> groupinfolist = new List<GroupInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY GroupID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    GroupInfo_MDL groupinfo = new GroupInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr["GroupID"] == DBNull.Value) ? "" : sdr["GroupID"].ToString().Trim(),
                        (sdr["GroupName"] == DBNull.Value) ? "" : sdr["GroupName"].ToString().Trim(),
                        (sdr["Header"] == DBNull.Value) ? "" : sdr["Header"].ToString().Trim(),
                        (sdr["Action"] == DBNull.Value) ? "" : sdr["Action"].ToString().Trim(),
                        (sdr["MemberNum"] == DBNull.Value) ? 0 : int.Parse(sdr["MemberNum"].ToString().Trim()),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString().Trim(),
                        (sdr["aDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["aDate"].ToString().Trim()),
                        (sdr["mDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["mDate"].ToString().Trim())
                        );
                    groupinfolist.Add(groupinfo);
                }
            }
            return groupinfolist;

        }

        public int ChangeGroupInfo(GroupInfo_MDL obj, string IU)
        {
            try
            {
                SqlParameter[] sqlParas ={
                fsp.FormatInParam("@GroupID", SqlDbType.VarChar, obj.GroupID),
                fsp.FormatInParam("@GroupName", SqlDbType.VarChar, obj.GroupName),
                fsp.FormatInParam("@Header", SqlDbType.VarChar, obj.Header),
                fsp.FormatInParam("@Action", SqlDbType.VarChar, obj.Action),
                fsp.FormatInParam("@MemberNum", SqlDbType.Int, obj.MemberNum),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark),
                fsp.FormatInParam("@ID", SqlDbType.Int, obj.ID)
            };
                if (IU == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
            }
            catch (Exception cc)
            {
                return -1;
            }
        }

        public int deleteGroupInfo(int _ID)
        {
            try
            {
                SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
                return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
            }
            catch (Exception cc)
            {
                return -1;
            }
        }

        public int cancelGroupInfo(ArrayList _IDList)
        {
            try
            {
                string ExecBatch = "BEGIN TRANSACTION ";
                foreach (string s in _IDList)
                {
                    string IsPerson = string.Format("Select Count(*) From SysUserInfo Where GroupID=(Select GroupID From GroupInfo Where ID={0})",s);
                    object temp = SqlHelper.ExecuteScalar(CommandType.Text, IsPerson, null); 
                    {
                        if (temp.ToString() != string.Empty) 
                        {
                            if (Int32.Parse(temp.ToString()) == 0)
                            {
                                ExecBatch += string.Format("DELETE GroupProgramMap WHERE GroupID = ( select GroupID from GroupInfo Where id={0}) IF( @@ERROR<>0) GOTO StopDot ", s);
                                ExecBatch += string.Format("DELETE GroupInfo Where ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
                            }
                        }
                    }
                }
                ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
            }
            catch (Exception cc)
            {
                return -1;
            }
        }
    }
}
