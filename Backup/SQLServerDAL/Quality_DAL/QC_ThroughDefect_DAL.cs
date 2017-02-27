using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.Model.Quality_MDL;
using Admin.Model;
using Admin.IDAL.Quality_IDAL;

namespace Admin.SQLServerDAL.Quality_DAL
{
    public class QC_ThroughDefect_DAL : IQC_ThroughDefect
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        private const string SQL_SELECT = @"SELECT ID,DispatchNo,CardId,QueLiaoNum,HuaHenNum,SeChaNum, XiaCiNum, QueJiaoNum,
         SuoShuiNum, BianXingNum, LiaoHuaNum, PiFengNum, ChicunNum, ShaoJiaoNum,
         JiaWenNum, KaiLieNum, QiTaNum, AdjustDate, CreateDate, EmpID, Confirm, ConfirmDate,bz FROM QCAdjust_Vice WHERE 1=1";
        private const string SQL_INSERT = "INSERT INTO QCAdjust_Vice(DispatchNo, CardId, QueLiaoNum, HuaHenNum, SeChaNum,XiaCiNum, QueJiaoNum, SuoShuiNum, BianXingNum, LiaoHuaNum,PiFengNum, ChicunNum, ShaoJiaoNum, JiaWenNum, KaiLieNum, QiTaNum, AdjustDate, CreateDate, EmpID,bz)  " +
                                          " VALUES(@DispatchNo, @CardId, @QueLiaoNum, @HuaHenNum, @SeChaNum,@XiaCiNum, @QueJiaoNum, @SuoShuiNum, @BianXingNum, @LiaoHuaNum,@PiFengNum, @ChicunNum, @ShaoJiaoNum, @JiaWenNum, @KaiLieNum, @QiTaNum, @AdjustDate, @CreateDate, @EmpID,@bz) ";
        private const string SQL_INSERT2 = "INSERT INTO QCAdjust(DispatchNo, CardId, QueLiaoNum, HuaHenNum, SeChaNum,XiaCiNum, QueJiaoNum, SuoShuiNum, BianXingNum, LiaoHuaNum,PiFengNum, ChicunNum, ShaoJiaoNum, JiaWenNum, KaiLieNum, QiTaNum, AdjustDate, CreateDate, EmpID)  " +
                                          " VALUES('{0}', '{1}', {2}, {3}, {4},{5}, {6}, {7}, {8}, {9},{10}, {11}, {12}, {13}, {14}, {15}, '{16}', '{17}', '{18}') ";
        private const string SQL_UPDATE = @"UPDATE QCAdjust_Vice SET DispatchNo = @DispatchNo, CardId = @CardId, QueLiaoNum = @QueLiaoNum, HuaHenNum = @HuaHenNum, SeChaNum = @SeChaNum, XiaCiNum = @XiaCiNum, QueJiaoNum = @QueJiaoNum,
             SuoShuiNum = @SuoShuiNum, BianXingNum = @BianXingNum, LiaoHuaNum = @LiaoHuaNum, PiFengNum = @PiFengNum, ChicunNum = @ChicunNum, ShaoJiaoNum = @ShaoJiaoNum, JiaWenNum = @JiaWenNum, KaiLieNum = @KaiLieNum, QiTaNum = @QiTaNum,AdjustDate=@AdjustDate,CreateDate=@CreateDate,EmpID=@EmpID,bz=@bz WHERE ID=@ID ";

        public IList<QC_ThroughDefect_MDL> selectQCAdjust() { return null; }
        public IList<QC_ThroughDefect_MDL> selectQCAdjust(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            return getListQCAdjust(sqlWhere, sqlParas);
        }

        private IList<QC_ThroughDefect_MDL> getListQCAdjust(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            IList<QC_ThroughDefect_MDL> QCAdjustList = new List<QC_ThroughDefect_MDL>();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(sqlWhere).ToString(), sqlParas))
                {
                    while (sdr.Read())
                    {
                        QC_ThroughDefect_MDL QCAdjust = new QC_ThroughDefect_MDL(sdr.GetInt32(0),
                            (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),
                            (sdr["CardId"] == DBNull.Value) ? "" : sdr["CardId"].ToString().Trim(),
                            (sdr["QueLiaoNum"] == DBNull.Value) ? "" : sdr["QueLiaoNum"].ToString().Trim(),
                            (sdr["HuaHenNum"] == DBNull.Value) ? "" : sdr["HuaHenNum"].ToString().Trim(),
                            (sdr["SeChaNum"] == DBNull.Value) ? "" : sdr["SeChaNum"].ToString().Trim(),
                            (sdr["XiaCiNum"] == DBNull.Value) ? "0" : sdr["XiaCiNum"].ToString(),
                            (sdr["QueJiaoNum"] == DBNull.Value) ? "0" : sdr["QueJiaoNum"].ToString(),
                            (sdr["SuoShuiNum"] == DBNull.Value) ? "0" : sdr["SuoShuiNum"].ToString(),
                            (sdr["BianXingNum"] == DBNull.Value) ? "0" : sdr["BianXingNum"].ToString(),
                            (sdr["LiaoHuaNum"] == DBNull.Value) ? "0" : sdr["LiaoHuaNum"].ToString(),
                            (sdr["PiFengNum"] == DBNull.Value) ? "0" : sdr["PiFengNum"].ToString(),
                            (sdr["ChicunNum"] == DBNull.Value) ? "0" : sdr["ChicunNum"].ToString(),
                            (sdr["ShaoJiaoNum"] == DBNull.Value) ? "0" : sdr["ShaoJiaoNum"].ToString(),
                            (sdr["JiaWenNum"] == DBNull.Value) ? "0" : sdr["JiaWenNum"].ToString(),
                            (sdr["KaiLieNum"] == DBNull.Value) ? "0" : sdr["KaiLieNum"].ToString(),
                            (sdr["QiTaNum"] == DBNull.Value) ? "0" : sdr["QiTaNum"].ToString().Trim(),
                            (sdr["AdjustDate"] == DBNull.Value) ? "0" : sdr["AdjustDate"].ToString(),
                            (sdr["CreateDate"] == DBNull.Value) ? "0" : sdr["CreateDate"].ToString(),
                            (sdr["EmpID"] == DBNull.Value) ? "0" : sdr["EmpID"].ToString().Trim(),
                            (sdr["Confirm"] == DBNull.Value) ? "0" : sdr["Confirm"].ToString(),
                            (sdr["ConfirmDate"] == DBNull.Value) ? "0" : sdr["ConfirmDate"].ToString().Trim(),
                            (sdr["bz"] == DBNull.Value) ? "0" : sdr["bz"].ToString().Trim()
                           );
                        QCAdjustList.Add(QCAdjust);
                    }
                }
                return QCAdjustList;
            }
            catch
            {
                return QCAdjustList;
            }
        }
        public int ChangeQCAdjust(int vID, string DispatchNo, string CardId, int QueLiaoNum, int HuaHenNum, int SeChaNum, int XiaCiNum,
            int QueJiaoNum, int SuoShuiNum, int BianXingNum, int LiaoHuaNum, int PiFengNum, int ChicunNum, int ShaoJiaoNum,
            int JiaWenNum, int KaiLieNum, int QiTaNum, string AdjustDate, string CreateDate, string EmpID, string vbz, string IU)
        {
            try
            {
                SqlParameter[] sqlParas = {
                fsp.FormatInParam("@DispatchNo",SqlDbType.VarChar,DispatchNo),
                fsp.FormatInParam("@CardId", SqlDbType.VarChar, CardId),
                fsp.FormatInParam("@QueLiaoNum", SqlDbType.Int, QueLiaoNum),
                fsp.FormatInParam("@HuaHenNum", SqlDbType.Int, HuaHenNum),
                fsp.FormatInParam("@SeChaNum", SqlDbType.Int, SeChaNum),

                fsp.FormatInParam("@XiaCiNum", SqlDbType.Int, XiaCiNum),
                fsp.FormatInParam("@QueJiaoNum", SqlDbType.Int, QueJiaoNum),
                fsp.FormatInParam("@SuoShuiNum", SqlDbType.Int, SuoShuiNum),
                fsp.FormatInParam("@BianXingNum",SqlDbType.Int, BianXingNum),
                fsp.FormatInParam("@LiaoHuaNum",SqlDbType.Int, LiaoHuaNum),

                fsp.FormatInParam("@PiFengNum", SqlDbType.Int, PiFengNum),
                fsp.FormatInParam("@ChicunNum", SqlDbType.Int, ChicunNum),
                fsp.FormatInParam("@ShaoJiaoNum",SqlDbType.VarChar, ShaoJiaoNum),
                fsp.FormatInParam("@JiaWenNum",SqlDbType.Int, JiaWenNum),
                fsp.FormatInParam("@KaiLieNum",SqlDbType.Int, KaiLieNum),
                fsp.FormatInParam("@QiTaNum",SqlDbType.Int, QiTaNum),
                fsp.FormatInParam("@AdjustDate",SqlDbType.VarChar, AdjustDate),
                fsp.FormatInParam("@CreateDate",SqlDbType.VarChar, CreateDate),
                fsp.FormatInParam("@EmpID",SqlDbType.VarChar, EmpID),
                fsp.FormatInParam("@bz",SqlDbType.VarChar, vbz),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
                return SqlHelper.ExecuteNonQuery(CommandType.Text, (IU == "INSERT") ? SQL_INSERT : SQL_UPDATE, sqlParas);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public void deleteQCAdjust(int _ID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE QCAdjust_Vice WHERE ID=@ID ", sqlParas);
        }

        public void cancelQCAdjust(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE QCAdjust_Vice WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public void checkQCAdjust_Vice(string strFlag, string strChecker, ArrayList _IDList)
        {

            string ExecBatch = "BEGIN TRANSACTION ";
            if (strFlag.Trim() == "0")
            {
                foreach (string s in _IDList)
                {
                    ExecBatch += string.Format(@"UPDATE QCAdjust_Vice SET ConfirmDate=NULL,Confirm='' WHERE ID={0} AND Confirm<>'' ", s);
                }
            }
            else
            {
                foreach (string s in _IDList)
                {
                    ExecBatch += string.Format(@"UPDATE QCAdjust_Vice SET ConfirmDate=getdate(),Confirm='{1}' WHERE ID={0} AND ISNULL(Confirm,'')=''  IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s, strChecker);

                    IList<QC_ThroughDefect_MDL> tempIList = selectQCAdjust(Int32.Parse(s), "", "");

                    object[] sqlParas ={ tempIList[0].DispatchNo, tempIList[0].CardId, tempIList[0].QueLiaoNum, tempIList[0].HuaHenNum,
                        tempIList[0].SeChaNum, tempIList[0].XiaCiNum, tempIList[0].QueJiaoNum, tempIList[0].SuoShuiNum,
                        tempIList[0].BianXingNum, tempIList[0].LiaoHuaNum, tempIList[0].PiFengNum, tempIList[0].ChicunNum,
                        tempIList[0].ShaoJiaoNum, tempIList[0].JiaWenNum, tempIList[0].KaiLieNum, tempIList[0].QiTaNum,
                        tempIList[0].AdjustDate, tempIList[0].CreateDate, tempIList[0].EmpID };
                    ExecBatch += string.Format(SQL_INSERT2 + "  IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot", sqlParas);
                }
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
