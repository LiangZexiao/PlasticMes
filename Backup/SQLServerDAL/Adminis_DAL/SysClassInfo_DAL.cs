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
    public class SysClassInfo_DAL : ISysClassInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT_USER = "SELECT DISTINCT b.ID,a.ClassID,ClassName FROM SysProgramInfo a LEFT JOIN SysClassInfo b ON a.ClassID=b.ClassID LEFT JOIN UserProgramMap c ON a.ProgramID=c.ProgramID WHERE a.Locked<>'1' AND c.UserID=@UserID ";
        private const string SQL_SELECT_GROUP = "SELECT DISTINCT b.ID,a.ClassID,ClassName FROM SysProgramInfo a LEFT JOIN SysClassInfo b ON a.ClassID=b.ClassID LEFT JOIN GroupProgramMap c ON a.ProgramID=c.ProgramID LEFT JOIN SysUserInfo d ON c.GroupID=d.GroupID  WHERE a.Locked<>'1' AND d.UserID=@UserID ";
        private const string SQL_SELECT_EXIT = "SELECT DISTINCT a.ID,a.ClassID,a.ClassName FROM SysClassInfo a WHERE ClassID='12' ";
        
        private const string SQL_SELECT = "SELECT DISTINCT ID,ClassID,ClassName,Remark FROM SysClassInfo WHERE 1=1 ";
        private const string SQL_INSERT = "INSERT INTO SysClassInfo(ClassID,ClassName,Remark) VALUES(@ClassID,@ClassName,@Remark)";
        private const string SQL_UPDATE = "UPDATE SysClassInfo SET ClassName=@ClassName,Remark=@Remark WHERE ID=@ID";
        private const string SQL_DELETE = "DELETE SysClassInfo WHERE ID=@ID";

        public IList<SysClassInfo_MDL> selectSysClassInfo() { return null; }
        public IList<SysClassInfo_MDL> selectSysClassInfo(string userid)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0} UNION {1} UNION {2} ORDER BY a.ClassID ", SQL_SELECT_USER, SQL_SELECT_GROUP, SQL_SELECT_EXIT));
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@UserID", SqlDbType.VarChar, userid) };

            IList<SysClassInfo_MDL> infolist = new List<SysClassInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SysClassInfo_MDL info = new SysClassInfo_MDL(
                        (sdr.IsDBNull(0)) ? 0 : sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? string.Empty : sdr.GetString(1).ToString().Trim(),
                        (sdr.IsDBNull(2)) ? string.Empty : sdr.GetString(2).ToString().Trim()
                        );
                    infolist.Add(info);
                }
            }
            return infolist;
        }

        public IList<SysClassInfo_MDL> selectSysClassInfo(int id, string colname, string coltext)
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

            IList<SysClassInfo_MDL> sysclassinfoList = new List<SysClassInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" order by classid ").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SysClassInfo_MDL sysclassinfo = new SysClassInfo_MDL(
                        sdr.GetInt32(0),
                        sdr.GetString(1),
                        sdr.GetString(2),
                        (sdr.IsDBNull(3)) ? string.Empty : sdr.GetString(3).ToString().Trim()
                        );
                    sysclassinfoList.Add(sysclassinfo);
                }
            }
            return sysclassinfoList;
        }

        public IList<SysClassInfo_MDL> existsSysClassInfo(string _ClassID)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ClassID", SqlDbType.VarChar, _ClassID) };
            sqlCmd.Append(string.Format("AND ClassID=@ClassID"));                

            IList<SysClassInfo_MDL> team = new List<SysClassInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    SysClassInfo_MDL member = new SysClassInfo_MDL(
                        sdr.GetInt32(0),
                        sdr.GetString(1),
                        sdr.GetString(2)
                        );
                    team.Add(member);
                }
            }
            return team;
        }

        public void insertSysClassInfo(string _ClassID, string _ClassName, string _Remark)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@ClassID",SqlDbType.VarChar, _ClassID),
                fsp.FormatInParam("@ClassName",SqlDbType.VarChar, _ClassName),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, _Remark)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
        }

        //
        public void updateSysClassInfo(int _ID, string _ClassID, string _ClassName, string _Remark)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@ClassID",SqlDbType.VarChar, _ClassID),
                fsp.FormatInParam("@ClassName",SqlDbType.VarChar, _ClassName),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, _Remark),
                fsp.FormatInParam("@ID",SqlDbType.Int, _ID)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }

        //
        public void deleteSysClassInfo(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelSysClassInfo(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE SysClassInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}