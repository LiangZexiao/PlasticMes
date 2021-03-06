﻿using System;
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
    public class SysProgramInfo_DAL : ISysProgramInfo
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        private const string SQL_SELECT = "SELECT DISTINCT ID, ProgramID, ProgramName, RequestURL, ClassID, ClassName, OrderID, Locked, aDate, mDate FROM View_SysProgramInfo WHERE 1=1 ";
        private const string SQL_SELECT_ID = "SELECT DISTINCT ID, ProgramID, ProgramName, RequestURL, ClassID,OrderID,Locked, aDate, mDate FROM SysProgramInfo WHERE 1=1 ";

        private const string SQL_INSERT = "INSERT INTO SysProgramInfo(ProgramID, ProgramName, RequestURL, ClassID,OrderID,Locked, aDate, mDate) VALUES(@ProgramID, @ProgramName, @RequestURL, @ClassID,@OrderID,@Locked, @aDate, @mDate)";
        private const string SQL_UPDATE = "UPDATE SysProgramInfo SET ProgramID=@ProgramID, ProgramName=@ProgramName, RequestURL=@RequestURL, ClassID=@ClassID, OrderID=@OrderID,Locked=@Locked,mDate=@mDate  WHERE ID=@ID";
        private const string SQL_DELETE = "DELETE SysProgramInfo WHERE ID=@ID";

        private const string SQL_SELECT_USER = "SELECT DISTINCT a.ProgramID,ProgramName,RequestURL,a.OrderID,a.classid  FROM SysProgramInfo a LEFT JOIN UserProgramMap b ON a.ProgramID=b.ProgramID WHERE b.UserID=@UserID AND a.ClassID=@ClassID AND a.Locked<>'1' ";//ORDER BY a.OrderID";
        private const string SQL_SELECT_GROUP = "SELECT DISTINCT a.ProgramID,ProgramName,RequestURL,a.OrderID,a.classid  FROM SysProgramInfo a LEFT JOIN GroupProgramMap b ON a.ProgramID=b.ProgramID LEFT JOIN SysUserInfo c ON b.GroupID=c.GroupID WHERE c.UserID=@UserID AND a.ClassID=@ClassID AND a.Locked<>'1' ";
        private const string SQL_SELECT_EXIT = "SELECT DISTINCT a.ProgramID,ProgramName,RequestURL,a.OrderID,a.classid  FROM SysProgramInfo a WHERE a.ProgramID='MdyPassword' AND a.Locked<>'1' ";
        
        public IList<ProgramInfo_MDL> selectProgramInfo() { return null; }
        public IList<ProgramInfo_MDL> selectProgramInfo(int id) { return null; }
        public IList<ProgramInfo_MDL> selectProgramInfo(string userid,string classid)
        {
            //StringBuilder sqlCmd = (classid == "6") ? new StringBuilder(string.Format("{0} UNION {1} UNION {2}", SQL_SELECT_USER, SQL_SELECT_GROUP, SQL_SELECT_EXIT)) : new StringBuilder(string.Format("{0} UNION {1}", SQL_SELECT_USER, SQL_SELECT_GROUP));
            //StringBuilder sqlCmd = new StringBuilder(string.Format("{0} UNION {1} UNION {2}", SQL_SELECT_USER, SQL_SELECT_GROUP, SQL_SELECT_EXIT));
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0} UNION {1}", SQL_SELECT_USER, SQL_SELECT_GROUP));
            SqlParameter[] sqlParas = new SqlParameter[] {
                fsp.FormatInParam("@UserID", SqlDbType.VarChar, userid),
                fsp.FormatInParam("@ClassID", SqlDbType.VarChar, classid)
            };

            IList<ProgramInfo_MDL> programinfolist = new List<ProgramInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" order by classid ,OrderID ").ToString(), sqlParas))
            {
                while(sdr.Read())
                {
                    ProgramInfo_MDL programinfo = new ProgramInfo_MDL(
                        (sdr.IsDBNull(0)) ? string.Empty : sdr.GetString(0).Trim(),
                        (sdr.IsDBNull(1)) ? string.Empty : sdr.GetString(1).Trim(),
                        (sdr.IsDBNull(2)) ? string.Empty : sdr.GetString(2).Trim()
                        );
                    programinfolist.Add(programinfo);
                }
            }
            return programinfolist;
        }
        /// <summary>
        /// search record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public IList<ProgramInfo_MDL> selectProgramInfo(int id, string colname, string coltext)
        {
            

            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = new SqlParameter[2];
            

            if (id != 0)
            {
                sqlCmd.Append(string.Format("AND ID=@ID"));
                sqlParas[0]=  fsp.FormatInParam("@ID", SqlDbType.Int, id);
            }

            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} =@" + colname, colname));
                if (id != 0)
                {
                    sqlParas[1] = fsp.FormatInParam("@" + colname, SqlDbType.VarChar, coltext);
                }
                else
                {
                    sqlParas[0] = fsp.FormatInParam("@" + colname, SqlDbType.VarChar, coltext);
                }
            }

            IList<ProgramInfo_MDL> programinfolist = new List<ProgramInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ClassID ,OrderID ").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    ProgramInfo_MDL programinfo = new ProgramInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? string.Empty : sdr.GetString(1).Trim(),
                        (sdr.IsDBNull(2)) ? string.Empty : sdr.GetString(2).Trim(),
                        (sdr.IsDBNull(3)) ? string.Empty : sdr.GetString(3).Trim(),
                        (sdr.IsDBNull(4)) ? string.Empty : sdr.GetString(4).Trim(),
                        (sdr.IsDBNull(5)) ? string.Empty : sdr.GetString(5).Trim(),
                        (sdr.IsDBNull(6)) ? string.Empty : sdr.GetString(6).Trim(),
                        (sdr.IsDBNull(7)) ? string.Empty : sdr.GetString(7).Trim(),
                        (sdr.IsDBNull(8)) ? string.Empty : sdr.GetString(8).Trim(),
                        (sdr.IsDBNull(9)) ? string.Empty : sdr.GetString(9).Trim()
                        );
                    programinfolist.Add(programinfo);
                }
            }
            return programinfolist;
        }
        /// <summary>
        /// confirm whether exist a same record
        /// </summary>
        /// <param name="_ProgramID"></param>
        /// <returns></returns>
        public IList<ProgramInfo_MDL> existsProgramInfo(string _ProgramID)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);            
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProgramID", SqlDbType.VarChar, _ProgramID) };

            IList<ProgramInfo_MDL> programinfolist = new List<ProgramInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" AND ProgramID=@ProgramID").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                   ProgramInfo_MDL programinfo = new ProgramInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? string.Empty : sdr.GetString(1).Trim(),
                        (sdr.IsDBNull(2)) ? string.Empty : sdr.GetString(2).Trim(),
                        (sdr.IsDBNull(3)) ? string.Empty : sdr.GetString(3).Trim(),
                        (sdr.IsDBNull(4)) ? string.Empty : sdr.GetString(4).Trim(),
                        (sdr.IsDBNull(5)) ? string.Empty : sdr.GetString(5).Trim(),
                        (sdr.IsDBNull(6)) ? string.Empty : sdr.GetString(6).Trim(),
                        (sdr.IsDBNull(7)) ? string.Empty : sdr.GetString(7).Trim(),
                        (sdr.IsDBNull(8)) ? string.Empty : sdr.GetString(8).Trim(),
                        (sdr.IsDBNull(9)) ? string.Empty : sdr.GetString(9).Trim()
                        );
                    programinfolist.Add(programinfo);
                }
            }
            return programinfolist;
        }
        /// <summary>
        /// new add a record
        /// </summary>
        /// <param name="_ProgramID"></param>
        /// <param name="_ProgramName"></param>
        /// <param name="_RequestURL"></param>
        /// <param name="_ClassID"></param>
        /// <param name="_OrderID"></param>
        /// <param name="_aDate"></param>
        /// <param name="_mDate"></param>
        public void insertProgramInfo(string _ProgramID, string _ProgramName, string _RequestURL, string _ClassID, string _OrderID, string _Locked, DateTime _aDate, DateTime _mDate)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@ProgramID", SqlDbType.VarChar, _ProgramID),
                fsp.FormatInParam("@ProgramName", SqlDbType.VarChar, _ProgramName),
                fsp.FormatInParam("@RequestURL", SqlDbType.VarChar, _RequestURL),
                fsp.FormatInParam("@ClassID", SqlDbType.VarChar, _ClassID),
                fsp.FormatInParam("@OrderID", SqlDbType.VarChar, _OrderID),
                fsp.FormatInParam("@Locked", SqlDbType.VarChar, _Locked),
                fsp.FormatInParam("@aDate", SqlDbType.DateTime, _aDate),
                fsp.FormatInParam("@mDate", SqlDbType.DateTime, _mDate)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
        }
        /// <summary>
        /// modify a record
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_ProgramID"></param>
        /// <param name="_ProgramName"></param>
        /// <param name="_RequestURL"></param>
        /// <param name="_ClassID"></param>
        /// <param name="_OrderID"></param>
        /// <param name="_mDate"></param>
        public void updateProgramInfo(int _ID, string _ProgramID, string _ProgramName, string _RequestURL, string _ClassID, string _OrderID, string _Locked, DateTime _mDate)
        {
            SqlParameter[] sqlParas = { 
                fsp.FormatInParam("@ProgramID", SqlDbType.VarChar, _ProgramID),
                fsp.FormatInParam("@ProgramName", SqlDbType.VarChar, _ProgramName),
                fsp.FormatInParam("@RequestURL", SqlDbType.VarChar, _RequestURL),
                fsp.FormatInParam("@ClassID", SqlDbType.VarChar, _ClassID),
                fsp.FormatInParam("@OrderID", SqlDbType.VarChar, _OrderID),
                fsp.FormatInParam("@Locked", SqlDbType.VarChar, _Locked),
                fsp.FormatInParam("@mDate", SqlDbType.DateTime, _mDate),
                fsp.FormatInParam("@ID", SqlDbType.Int, _ID)
            };

            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }
        /// <summary>
        /// delete single record
        /// </summary>
        /// <param name="_ID"></param>
        public void deleteProgramInfo(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }
        /// <summary>
        /// delete batch or a lot records
        /// </summary>
        /// <param name="_IDList"></param>
        public void cancelProgramInfo(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE SysProgramInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}