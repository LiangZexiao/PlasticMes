using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.Collect_MDL;
using Admin.IDAL.Collect_IDAL;

namespace Admin.SQLServerDAL.Collect_DAL
{
    public class DataHistory_DAL : IDataHistory
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();

        public IList<DataHistory_MDL> selectDataHistory(int id)
        {
            string sqlCmdText = string.Format("SELECT * FROM View_DataHistory WHERE ID={0}", id);
            DataTable sdt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmdText, null);

            return getDataHistory(sdt);
        }
        
        public IList<DataHistory_MDL> selectDataHistory(string colname, string coltext, int PageSize, int PageIndex, out int RowCount)
        {
            string strWhere = string.Empty;
            if (colname != "" && coltext != "")
            {
                if (colname == "UpLoadTime")
                    strWhere = (string.Format(" CONVERT(CHAR(10),UpLoadTime,121)='" + coltext + "'", colname));
                else
                    strWhere = (string.Format(" {0} LIKE '%" + coltext + "%'", colname));
            }
            //@tblName varchar(255), -- 表名
            //@strGetFields varchar(8000)= '*', -- 需要返回的列 
            //@fldName varchar(255)='', -- 排序的字段名
            //@PageSize int = 10, -- 页尺寸
            //@PageIndex int = 1, -- 页码
            //@doCount bit = 0, -- 返回记录总数, 非 0 值则返回
            //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
            //@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where)

            SqlParameter[] sqlParas = sqlParas = new SqlParameter[8] { 
                    fsp.FormatInParam("@tblName", SqlDbType.VarChar, "View_DataHistory"),
                    fsp.FormatInParam("@strGetFields", SqlDbType.VarChar, "*"),
                    fsp.FormatInParam("@fldName", SqlDbType.VarChar, "BeginCycle"),
                    fsp.FormatInParam("@PageSize", SqlDbType.Int, PageSize),
                    fsp.FormatInParam("@PageIndex", SqlDbType.Int, PageIndex),
                    fsp.FormatInParam("@doCount", SqlDbType.Char, (PageIndex==1)?"1":"0"), 
                    fsp.FormatInParam("@OrderType", SqlDbType.Char, "1"), 
                    fsp.FormatInParam("@strWhere", SqlDbType.VarChar, strWhere) 
                };

            DataSet sds = SqlHelper.ReturnDataSet(CommandType.StoredProcedure, "Pagination", sqlParas);
            DataTable sdt = sds.Tables[0];
            if (PageIndex == 1)
            {
                RowCount = int.Parse(sds.Tables[1].Rows[0][0].ToString());
            }
            else
            {
                RowCount = 0;
            }
            return getDataHistory(sdt);
        }
        
        public IList<DataHistory_MDL> selectDataHistory(string colname, string coltext,string BeginDate,string EndDate, int PageSize, int PageIndex, out int RowCount)
        {
            string strWhere = " 1=1 ";// string.Empty;
            if (colname != "" && coltext != "")
            {
                if (colname == "UpLoadTime")
                    strWhere += (string.Format(" and CONVERT(CHAR(10),UpLoadTime,121)='" + coltext + "'", colname));
                else
                    strWhere += (string.Format(" and  {0} LIKE '%" + coltext + "%'", colname));
            }
            if (BeginDate != "" && EndDate != "")
            {
                strWhere += (string.Format(" and CONVERT(CHAR(16),BeginCycle,121) >= '" + BeginDate + "' and  CONVERT(CHAR(16),BeginCycle,121) <= '" + EndDate + "'", colname));
            }
            //@tblName varchar(255), -- 表名
            //@strGetFields varchar(8000)= '*', -- 需要返回的列 
            //@fldName varchar(255)='', -- 排序的字段名
            //@PageSize int = 10, -- 页尺寸
            //@PageIndex int = 1, -- 页码
            //@doCount bit = 0, -- 返回记录总数, 非 0 值则返回
            //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
            //@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where)

            SqlParameter[] sqlParas = sqlParas = new SqlParameter[8] { 
                    fsp.FormatInParam("@tblName", SqlDbType.VarChar, "View_DataHistory"),
                    fsp.FormatInParam("@strGetFields", SqlDbType.VarChar, "*"),
                    fsp.FormatInParam("@fldName", SqlDbType.VarChar, "BeginCycle"),
                    fsp.FormatInParam("@PageSize", SqlDbType.Int, PageSize),
                    fsp.FormatInParam("@PageIndex", SqlDbType.Int, PageIndex),
                    fsp.FormatInParam("@doCount", SqlDbType.Char, (PageIndex==1)?"1":"0"), 
                    fsp.FormatInParam("@OrderType", SqlDbType.Char, "1"), 
                    fsp.FormatInParam("@strWhere", SqlDbType.VarChar, strWhere) 
                };

            DataSet sds = SqlHelper.ReturnDataSet(CommandType.StoredProcedure, "Pagination", sqlParas);
            DataTable sdt = sds.Tables[0];
            if (PageIndex == 1)
            {
                RowCount = int.Parse(sds.Tables[1].Rows[0][0].ToString());
            }
            else
            {
                RowCount = 0;
            }
            return getDataHistory(sdt);
        }

        private IList<DataHistory_MDL> getDataHistory(DataTable sdt)
        {
            try
            {
                IList<DataHistory_MDL> DataHistoryList = new List<DataHistory_MDL>();
                foreach (DataRow sdr in sdt.Rows)
                {
                    DataHistory_MDL DataHistory = new DataHistory_MDL(sdr["ID"].ToString(),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                        (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                        (sdr["DispatchOrder"] == DBNull.Value) ? "" : sdr["DispatchOrder"].ToString().Trim(),
                        (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                        (sdr["TotalNum"] == DBNull.Value) ? "0" : sdr["TotalNum"].ToString().Trim(),
                        (sdr["Cycletime"] == DBNull.Value) ? "0" : sdr["Cycletime"].ToString().Trim(),
                        (sdr["BeginCycle"] == DBNull.Value) ? DateTime.Now.ToString("yyyy-MM-dd") : DateTime.Parse(sdr["BeginCycle"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                        (sdr["EndCycle"] == DBNull.Value) ? DateTime.Now.ToString("yyyy-MM-dd") : DateTime.Parse(sdr["EndCycle"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                        (sdr["ClientIp"] == DBNull.Value) ? "" : sdr["ClientIp"].ToString(),

                        //(sdr["KeepPress1"] == DBNull.Value) ? "0" : sdr["KeepPress1"].ToString(),//KeepPress1
                        //(sdr["KeepPress2"] == DBNull.Value) ? "0" : sdr["KeepPress2"].ToString(),
                        //(sdr["KeepPress3"] == DBNull.Value) ? "0" : sdr["KeepPress3"].ToString(),
                        //(sdr["KeepPress4"] == DBNull.Value) ? "0" : sdr["KeepPress4"].ToString(),
                        //(sdr["KeepPress5"] == DBNull.Value) ? "0" : sdr["KeepPress5"].ToString(),
                        //(sdr["KeepPress6"] == DBNull.Value) ? "0" : sdr["KeepPress6"].ToString(),
                        //(sdr["KeepPress7"] == DBNull.Value) ? "0" : sdr["KeepPress7"].ToString(),
                        //(sdr["KeepPress8"] == DBNull.Value) ? "0" : sdr["KeepPress8"].ToString(),
                        //(sdr["KeepPress9"] == DBNull.Value) ? "0" : sdr["KeepPress9"].ToString(),
                        //(sdr["KeepPress10"] == DBNull.Value) ? "0" : sdr["KeepPress10"].ToString(),//KeepPress10

                        //(sdr["KeepPress11"] == DBNull.Value) ? "0" : sdr["KeepPress11"].ToString(),//KeepPress11
                        //(sdr["KeepPress12"] == DBNull.Value) ? "0" : sdr["KeepPress12"].ToString(),
                        //(sdr["KeepPress13"] == DBNull.Value) ? "0" : sdr["KeepPress13"].ToString(),
                        //(sdr["KeepPress14"] == DBNull.Value) ? "0" : sdr["KeepPress14"].ToString(),
                        //(sdr["KeepPress15"] == DBNull.Value) ? "0" : sdr["KeepPress15"].ToString(),
                        //(sdr["KeepPress16"] == DBNull.Value) ? "0" : sdr["KeepPress16"].ToString(),
                        //(sdr["KeepPress17"] == DBNull.Value) ? "0" : sdr["KeepPress17"].ToString(),
                        //(sdr["KeepPress18"] == DBNull.Value) ? "0" : sdr["KeepPress18"].ToString(),
                        //(sdr["KeepPress19"] == DBNull.Value) ? "0" : sdr["KeepPress19"].ToString(),
                        //(sdr["KeepPress20"] == DBNull.Value) ? "0" : sdr["KeepPress20"].ToString(),//KeepPress20

                        //(sdr["KeepPress21"] == DBNull.Value) ? "0" : sdr["KeepPress21"].ToString(),//KeepPress21
                        //(sdr["KeepPress22"] == DBNull.Value) ? "0" : sdr["KeepPress22"].ToString(),
                        //(sdr["KeepPress23"] == DBNull.Value) ? "0" : sdr["KeepPress23"].ToString(),
                        //(sdr["KeepPress24"] == DBNull.Value) ? "0" : sdr["KeepPress24"].ToString(),
                        //(sdr["KeepPress25"] == DBNull.Value) ? "0" : sdr["KeepPress25"].ToString(),
                        //(sdr["KeepPress26"] == DBNull.Value) ? "0" : sdr["KeepPress26"].ToString(),
                        //(sdr["KeepPress27"] == DBNull.Value) ? "0" : sdr["KeepPress27"].ToString(),
                        //(sdr["KeepPress28"] == DBNull.Value) ? "0" : sdr["KeepPress28"].ToString(),
                        //(sdr["KeepPress29"] == DBNull.Value) ? "0" : sdr["KeepPress29"].ToString(),
                        //(sdr["KeepPress30"] == DBNull.Value) ? "0" : sdr["KeepPress30"].ToString(),//KeepPress30

                        //(sdr["KeepPress31"] == DBNull.Value) ? "0" : sdr["KeepPress31"].ToString(),//KeepPress31
                        //(sdr["KeepPress32"] == DBNull.Value) ? "0" : sdr["KeepPress32"].ToString(),
                        //(sdr["KeepPress33"] == DBNull.Value) ? "0" : sdr["KeepPress33"].ToString(),
                        //(sdr["KeepPress34"] == DBNull.Value) ? "0" : sdr["KeepPress34"].ToString(),
                        //(sdr["KeepPress35"] == DBNull.Value) ? "0" : sdr["KeepPress35"].ToString(),
                        //(sdr["KeepPress36"] == DBNull.Value) ? "0" : sdr["KeepPress36"].ToString(),
                        //(sdr["KeepPress37"] == DBNull.Value) ? "0" : sdr["KeepPress37"].ToString(),
                        //(sdr["KeepPress38"] == DBNull.Value) ? "0" : sdr["KeepPress38"].ToString(),
                        //(sdr["KeepPress39"] == DBNull.Value) ? "0" : sdr["KeepPress39"].ToString(),
                        //(sdr["KeepPress40"] == DBNull.Value) ? "0" : sdr["KeepPress40"].ToString(),//KeepPress40

                        //(sdr["KeepPress41"] == DBNull.Value) ? "0" : sdr["KeepPress41"].ToString(),//KeepPress41
                        //(sdr["KeepPress42"] == DBNull.Value) ? "0" : sdr["KeepPress42"].ToString(),
                        //(sdr["KeepPress43"] == DBNull.Value) ? "0" : sdr["KeepPress43"].ToString(),
                        //(sdr["KeepPress44"] == DBNull.Value) ? "0" : sdr["KeepPress44"].ToString(),
                        //(sdr["KeepPress45"] == DBNull.Value) ? "0" : sdr["KeepPress45"].ToString(),
                        //(sdr["KeepPress46"] == DBNull.Value) ? "0" : sdr["KeepPress46"].ToString(),
                        //(sdr["KeepPress47"] == DBNull.Value) ? "0" : sdr["KeepPress47"].ToString(),
                        //(sdr["KeepPress48"] == DBNull.Value) ? "0" : sdr["KeepPress48"].ToString(),
                        //(sdr["KeepPress49"] == DBNull.Value) ? "0" : sdr["KeepPress49"].ToString(),
                        //(sdr["KeepPress50"] == DBNull.Value) ? "0" : sdr["KeepPress50"].ToString(),//KeepPress50

                        //(sdr["KeepPress51"] == DBNull.Value) ? "0" : sdr["KeepPress51"].ToString(),//KeepPress51
                        //(sdr["KeepPress52"] == DBNull.Value) ? "0" : sdr["KeepPress52"].ToString(),
                        //(sdr["KeepPress53"] == DBNull.Value) ? "0" : sdr["KeepPress53"].ToString(),
                        //(sdr["KeepPress54"] == DBNull.Value) ? "0" : sdr["KeepPress54"].ToString(),
                        //(sdr["KeepPress55"] == DBNull.Value) ? "0" : sdr["KeepPress55"].ToString(),
                        //(sdr["KeepPress56"] == DBNull.Value) ? "0" : sdr["KeepPress56"].ToString(),
                        //(sdr["KeepPress57"] == DBNull.Value) ? "0" : sdr["KeepPress57"].ToString(),
                        //(sdr["KeepPress58"] == DBNull.Value) ? "0" : sdr["KeepPress58"].ToString(),
                        //(sdr["KeepPress59"] == DBNull.Value) ? "0" : sdr["KeepPress59"].ToString(),
                        //(sdr["KeepPress60"] == DBNull.Value) ? "0" : sdr["KeepPress60"].ToString(),//KeepPress60

                        //(sdr["KeepPress61"] == DBNull.Value) ? "0" : sdr["KeepPress61"].ToString(),//KeepPress61
                        //(sdr["KeepPress62"] == DBNull.Value) ? "0" : sdr["KeepPress62"].ToString(),
                        //(sdr["KeepPress63"] == DBNull.Value) ? "0" : sdr["KeepPress63"].ToString(),
                        //(sdr["KeepPress64"] == DBNull.Value) ? "0" : sdr["KeepPress64"].ToString(),
                        //(sdr["KeepPress65"] == DBNull.Value) ? "0" : sdr["KeepPress65"].ToString(),
                        //(sdr["KeepPress66"] == DBNull.Value) ? "0" : sdr["KeepPress66"].ToString(),
                        //(sdr["KeepPress67"] == DBNull.Value) ? "0" : sdr["KeepPress67"].ToString(),
                        //(sdr["KeepPress68"] == DBNull.Value) ? "0" : sdr["KeepPress68"].ToString(),
                        //(sdr["KeepPress69"] == DBNull.Value) ? "0" : sdr["KeepPress69"].ToString(),
                        //(sdr["KeepPress70"] == DBNull.Value) ? "0" : sdr["KeepPress70"].ToString(),//KeepPress70

                        //(sdr["KeepPress71"] == DBNull.Value) ? "0" : sdr["KeepPress71"].ToString(),//KeepPress71
                        //(sdr["KeepPress72"] == DBNull.Value) ? "0" : sdr["KeepPress72"].ToString(),
                        //(sdr["KeepPress73"] == DBNull.Value) ? "0" : sdr["KeepPress73"].ToString(),
                        //(sdr["KeepPress74"] == DBNull.Value) ? "0" : sdr["KeepPress74"].ToString(),
                        //(sdr["KeepPress75"] == DBNull.Value) ? "0" : sdr["KeepPress75"].ToString(),
                        //(sdr["KeepPress76"] == DBNull.Value) ? "0" : sdr["KeepPress76"].ToString(),
                        //(sdr["KeepPress77"] == DBNull.Value) ? "0" : sdr["KeepPress77"].ToString(),
                        //(sdr["KeepPress78"] == DBNull.Value) ? "0" : sdr["KeepPress78"].ToString(),
                        //(sdr["KeepPress79"] == DBNull.Value) ? "0" : sdr["KeepPress79"].ToString(),
                        //(sdr["KeepPress80"] == DBNull.Value) ? "0" : sdr["KeepPress80"].ToString(),//KeepPress80

                        //(sdr["KeepPress81"] == DBNull.Value) ? "0" : sdr["KeepPress81"].ToString(),//KeepPress81
                        //(sdr["KeepPress82"] == DBNull.Value) ? "0" : sdr["KeepPress82"].ToString(),
                        //(sdr["KeepPress83"] == DBNull.Value) ? "0" : sdr["KeepPress83"].ToString(),
                        //(sdr["KeepPress84"] == DBNull.Value) ? "0" : sdr["KeepPress84"].ToString(),
                        //(sdr["KeepPress85"] == DBNull.Value) ? "0" : sdr["KeepPress85"].ToString(),
                        //(sdr["KeepPress86"] == DBNull.Value) ? "0" : sdr["KeepPress86"].ToString(),
                        //(sdr["KeepPress87"] == DBNull.Value) ? "0" : sdr["KeepPress87"].ToString(),
                        //(sdr["KeepPress88"] == DBNull.Value) ? "0" : sdr["KeepPress88"].ToString(),
                        //(sdr["KeepPress89"] == DBNull.Value) ? "0" : sdr["KeepPress89"].ToString(),
                        //(sdr["KeepPress90"] == DBNull.Value) ? "0" : sdr["KeepPress90"].ToString(),//KeepPress90

                        //(sdr["KeepPress91"] == DBNull.Value) ? "0" : sdr["KeepPress91"].ToString(),//KeepPress91
                        //(sdr["KeepPress92"] == DBNull.Value) ? "0" : sdr["KeepPress92"].ToString(),
                        //(sdr["KeepPress93"] == DBNull.Value) ? "0" : sdr["KeepPress93"].ToString(),
                        //(sdr["KeepPress94"] == DBNull.Value) ? "0" : sdr["KeepPress94"].ToString(),
                        //(sdr["KeepPress95"] == DBNull.Value) ? "0" : sdr["KeepPress95"].ToString(),
                        //(sdr["KeepPress96"] == DBNull.Value) ? "0" : sdr["KeepPress96"].ToString(),
                        //(sdr["KeepPress97"] == DBNull.Value) ? "0" : sdr["KeepPress97"].ToString(),
                        //(sdr["KeepPress98"] == DBNull.Value) ? "0" : sdr["KeepPress98"].ToString(),
                        //(sdr["KeepPress99"] == DBNull.Value) ? "0" : sdr["KeepPress99"].ToString(),
                        //(sdr["KeepPress100"] == DBNull.Value) ? "0" : sdr["KeepPress100"].ToString(),//KeepPress100

                        (sdr["ShotTemp1"] == DBNull.Value) ? "0" : sdr["ShotTemp1"].ToString().Trim(),
                        (sdr["ShotTemp2"] == DBNull.Value) ? "0" : sdr["ShotTemp2"].ToString().Trim(),

                        (sdr["IntervalInfo"] == DBNull.Value) ? "0" : sdr["IntervalInfo"].ToString().Trim(),
                        (sdr["FillTime"] == DBNull.Value) ? "0" : sdr["FillTime"].ToString().Trim(),

                        (sdr["UpLoadTime"] == DBNull.Value) ? DateTime.Now.ToString("yyyy-MM-dd") : DateTime.Parse(sdr["UpLoadTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                        (sdr["KeepPress_Max"] == DBNull.Value) ? "0" : sdr["KeepPress_Max"].ToString().Trim(),
                        (sdr["InjectNum"] == DBNull.Value) ? "0" : sdr["InjectNum"].ToString().Trim()
                        );
                    DataHistoryList.Add(DataHistory);
                }
                return DataHistoryList;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new List<DataHistory_MDL>(); ;
            }
        }

        /// <summary>
        /// 获得机器编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMachineNoFromDataHistory(string bDate, string eDate)
        {
            try
            {
                StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT do.MachineNo MachineNo ,clientip clientip  FROM  DataHistory INNER JOIN DispatchOrder do ON do.DO_NO=DispatchOrder "
                    +" WHERE CONVERT(CHAR(16),BeginCycle,121)>=@bDate AND CONVERT(CHAR(16),BeginCycle,121)<=@eDate and do.machineno like 'im%' ");

                SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                            fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
                };
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.Append(" ORDER BY MachineNo desc ").ToString(), sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获得模具编号
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <returns></returns>
        public DataTable selectMouldNoFromDataHistory(string MachineNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT i.MouldNo FROM DataHistory a INNER JOIN DispatchOrder i ON a.DispatchOrder=i.DO_NO GROUP BY i.MouldNo ");
            //if (!string.IsNullOrEmpty(MachineNo))
            //    sqlCmd.Append(" AND MachineNo=@MachineNo ");
            try
            {
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), new SqlParameter[1] { fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo) });
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获得产品编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectProductNoFromDataHistory(string MachineNo, string MouldNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT ProductNo FROM DataHistory WHERE 1=1 ");
            if (!string.IsNullOrEmpty(MachineNo))
                sqlCmd.Append(" AND MachineNo=@MachineNo ");
            if (!string.IsNullOrEmpty(MouldNo))
                sqlCmd.Append(" AND MouldNo=@MouldNo ");

            SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                            fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo)
            };
            try
            {
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.Append("ORDER BY ProductNo").ToString(), sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获取产品编号(20080402)
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable SelectProductNoFrDh(string bDate, string eDate)
        {
            StringBuilder sqlCmd = new StringBuilder(@"SELECT DISTINCT LTRIM(RTRIM(DispatchOrder)) DispatchOrder FROM DataHistory INNER JOIN DispatchOrder do ON do.DO_NO=DispatchOrder  
                                        WHERE CONVERT(CHAR(16),BeginCycle,121)>=@bDate AND CONVERT(CHAR(16),BeginCycle,121)<=@eDate and do.machineno like 'im%'");

            SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                            fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
            };
            try
            {
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.Append(" ORDER BY DispatchOrder desc ").ToString(), sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获取模具编号(20080402)
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="ProductNo"></param>
        /// <returns></returns>
        public DataTable SelectMouldNoFrDh(string bDate, string eDate, string ProductNo)
        {
            StringBuilder sqlCmd = new StringBuilder(@"SELECT DISTINCT LTRIM(RTRIM(MouldNo)) MouldNo,LTRIM(RTRIM(MachineNo)) MachineNo FROM DataHistory 
                                        WHERE CONVERT(CHAR(16),BeginCycle,121)>=@bDate AND CONVERT(CHAR(16),BeginCycle,121)<=@eDate 
                                        AND DispatchOrder=@DispatchOrder ORDER BY MouldNo");
            SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, ProductNo),
                            fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                            fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
            };
            try
            {
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获取机器编号(20080402)
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="ProductNo"></param>
        /// <param name="MouldNo"></param>
        /// <returns></returns>
        public DataTable SelectMachineNoFrDh(string bDate, string eDate, string ProductNo, string MouldNo)
        {
            StringBuilder sqlCmd = new StringBuilder(@"SELECT DISTINCT DispatchOrder DispatchNo FROM DataHistory 
                                        WHERE CONVERT(CHAR(16),BeginCycle,121)>=@bDate AND CONVERT(CHAR(16),BeginCycle,121)<=@eDate 
                                        AND clientip=@ProductNo  ORDER BY DispatchOrder");
            SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                            fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                            fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                            fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
            };
            try
            {
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获得啤的序号
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <returns></returns>
        public DataTable selectActionNumFromDataHistory(string Dispatchorder,string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate)
        {
            SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@Dispatchorder", SqlDbType.VarChar, Dispatchorder),
                            fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                            fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                            fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                            fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                            fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate)
            };
            try
            {
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.StoredProcedure, "SELECT_TotalNum", sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// 获得派工单号
        /// </summary>
        /// <returns></returns>
        public DataTable selectDispatchOrderFromDataHistory(string MachineNo, string ProductDate)
        {
            try
            {
                StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT DispatchOrder, WorkerNo FROM DataHistory WHERE 1=1 ");

                if (!string.IsNullOrEmpty(MachineNo))
                    sqlCmd.Append(string.Format(" AND MachineNo=@MachineNo"));
                if (!string.IsNullOrEmpty(ProductDate))
                    sqlCmd.Append(string.Format(" AND CONVERT(CHAR(10),BeginCycle,121)=@BeginCycle"));

                SqlParameter[] sqlParas = {
                            fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                            fsp.FormatInParam("@BeginCycle", SqlDbType.VarChar, ProductDate)
            };
                DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
                return dt;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return null;
            }
        }
    }
}
