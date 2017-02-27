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
    public class GroupProgramMap_DAL : IGroupProgramMap
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT ID, GroupID, GroupName, ProgramID, ProgramName, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag, ChkFlagNO, aDate, mDate FROM View_GroupProgramMap WHERE 1=1 and groupid<>1 ";
        private const string SQL_INSERT = "INSERT INTO GroupProgramMap(GroupID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, aDate, mDate) VALUES(@GroupID, @ProgramID, @AddFlag, @CnlFlag,@MdyFlag,@QuyFlag,@PrtFlag, @ChkFlag,@ChkFlagNO, @aDate, @mDate)";

        private const string SQL_UPDATE = "UPDATE GroupProgramMap SET GroupID=@GroupID, ProgramID=@ProgramID, AddFlag=@AddFlag, CnlFlag=@CnlFlag, MdyFlag=@MdyFlag, QuyFlag=@QuyFlag, PrtFlag=@PrtFlag, ChkFlag=@ChkFlag,ChkFlagNO=@ChkFlagNO, mDate=@mDate  WHERE ID=@ID";
        private const string SQL_DELETE = "DELETE GroupProgramMap WHERE ID=@ID";

        public IList<GroupProgramMap_MDL> selectGroupProgramMap() { return null; }
        public IList<GroupProgramMap_MDL> selectGroupProgramMap(int id) { return null; }
        public IList<GroupProgramMap_MDL> selectGroupProgramMap(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID", id));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0}= '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
                sqlParas = null;
            }

            return DataListOfGroupProgramMap(sqlWhere, sqlParas);
        }

        public IList<GroupProgramMap_MDL> existsGroupProgramMap(string _GroupID, string _ProgramID)
        {
            StringBuilder sqlWhere = new StringBuilder("AND GroupID=@GroupID AND ProgramID=@ProgramID");
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@GroupID", SqlDbType.VarChar, _GroupID),
                fsp.FormatInParam("@ProgramID", SqlDbType.VarChar, _ProgramID)};

            return DataListOfGroupProgramMap(sqlWhere, sqlParas);
        }

        public IList<GroupProgramMap_MDL> DataListOfGroupProgramMap(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            sqlCmd.Append(sqlWhere.Append(" ORDER BY GroupID,classid,orderid "));

            IList<GroupProgramMap_MDL> bole = new List<GroupProgramMap_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    GroupProgramMap_MDL leaf = new GroupProgramMap_MDL(
                        sdr.GetInt32(0),
                        (sdr["GroupID"] == DBNull.Value) ? "0" : sdr["GroupID"].ToString().Trim(),
                        (sdr["GroupName"] == DBNull.Value) ? "0" : sdr["GroupName"].ToString().Trim(),
                        (sdr["ProgramID"] == DBNull.Value) ? "0" : sdr["ProgramID"].ToString().Trim(),
                        (sdr["ProgramName"] == DBNull.Value) ? "0" : sdr["ProgramName"].ToString().Trim(),

                        (sdr["AddFlag"] == DBNull.Value) ? "0" : sdr["AddFlag"].ToString().Trim(),
                        (sdr["CnlFlag"] == DBNull.Value) ? "0" : sdr["CnlFlag"].ToString().Trim(),
                        (sdr["MdyFlag"] == DBNull.Value) ? "0" : sdr["MdyFlag"].ToString().Trim(),
                        (sdr["QuyFlag"] == DBNull.Value) ? "0" : sdr["QuyFlag"].ToString().Trim(),
                        (sdr["PrtFlag"] == DBNull.Value) ? "0" : sdr["PrtFlag"].ToString().Trim(),
                        (sdr["ChkFlag"] == DBNull.Value) ? "0" : sdr["ChkFlag"].ToString().Trim(),
                        (sdr["ChkFlagNO"] == DBNull.Value) ? "0" : sdr["ChkFlagNO"].ToString().Trim(),

                        (sdr["aDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["aDate"].ToString().Trim()),
                        (sdr["mDate"] == DBNull.Value) ? DateTime.Parse("1900-01-01") : DateTime.Parse(sdr["mDate"].ToString().Trim())
                        );
                    bole.Add(leaf);
                }
            }
            return bole;
        }

        public int  ChangeGroupProgramMap(GroupProgramMap_MDL obj, string IU)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@GroupID",SqlDbType.VarChar, obj.GroupID),
                fsp.FormatInParam("@ProgramID", SqlDbType.VarChar, obj.ProgramID),
                fsp.FormatInParam("@AddFlag", SqlDbType.Char, obj.AddFlag),
                fsp.FormatInParam("@CnlFlag", SqlDbType.Char, obj.CnlFlag),
                fsp.FormatInParam("@MdyFlag", SqlDbType.Char, obj.MdyFlag),
                fsp.FormatInParam("@QuyFlag", SqlDbType.Char, obj.QuyFlag),
                fsp.FormatInParam("@PrtFlag", SqlDbType.Char, obj.PrtFlag),
                fsp.FormatInParam("@ChkFlag", SqlDbType.Char, obj.ChkFlag),
                fsp.FormatInParam("@ChkFlagNO", SqlDbType.Char, obj.ChkFlagNO),
                fsp.FormatInParam("@aDate",SqlDbType.DateTime, obj.aDate),
                fsp.FormatInParam("@mDate",SqlDbType.DateTime, obj.mDate),
                fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
            if(IU == "INSERT")
               return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
               return  SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }
        //
        public void deleteGroupProgramMap(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelGroupProgramMap(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE GroupProgramMap WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
