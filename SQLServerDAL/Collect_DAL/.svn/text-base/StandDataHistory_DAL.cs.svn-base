using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Collect_DAL
{
    public class StandDataHistory_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        private string KeepPress = @"KeepPress1,KeepPress2, KeepPress3, KeepPress4, KeepPress5, 
                                    KeepPress6, KeepPress7, KeepPress8, KeepPress9, KeepPress10, 
                                    KeepPress11, KeepPress12, KeepPress13, KeepPress14, KeepPress15, 
                                    KeepPress16, KeepPress17, KeepPress18, KeepPress19, KeepPress20, 
                                    KeepPress21, KeepPress22, KeepPress23, KeepPress24, KeepPress25, 
                                    KeepPress26, KeepPress27, KeepPress28, KeepPress29, KeepPress30, 
                                    KeepPress31, KeepPress32, KeepPress33, KeepPress34, KeepPress35, 
                                    KeepPress36, KeepPress37, KeepPress38, KeepPress39, KeepPress40, 
                                    KeepPress41, KeepPress42, KeepPress43, KeepPress44, KeepPress45, 
                                    KeepPress46, KeepPress47, KeepPress48, KeepPress49, KeepPress50, 
                                    KeepPress51, KeepPress52, KeepPress53, KeepPress54, KeepPress55, 
                                    KeepPress56, KeepPress57, KeepPress58, KeepPress59, KeepPress60, 
                                    KeepPress61, KeepPress62, KeepPress63, KeepPress64, KeepPress65, 
                                    KeepPress66, KeepPress67, KeepPress68, KeepPress69, KeepPress70, 
                                    KeepPress71, KeepPress72, KeepPress73, KeepPress74, KeepPress75, 
                                    KeepPress76, KeepPress77, KeepPress78, KeepPress79, KeepPress80, 
                                    KeepPress81, KeepPress82, KeepPress83, KeepPress84, KeepPress85, 
                                    KeepPress86, KeepPress87, KeepPress88, KeepPress89, KeepPress90, 
                                    KeepPress91, KeepPress92, KeepPress93, KeepPress94, KeepPress95, 
                                    KeepPress96, KeepPress97, KeepPress98, KeepPress99, KeepPress100";

        public int updateStandDataHistory(string MachineNo, string MouldNo, string ProductNo, string TotalNum)
        {
            string sql = "BEGIN TRANSACTION UPDATE StandDataHistory SET StandFlag='0' WHERE MachineNo=@MachineNo AND MouldNo=@MouldNo AND ProductNo=@ProductNo IF(@@ERROR<>0) GOTO StopDot ";
            sql += "UPDATE StandDataHistory SET StandFlag='1' WHERE MachineNo=@MachineNo AND MouldNo=@MouldNo AND ProductNo=@ProductNo AND TotalNum=@TotalNum IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ";
            sql += "COMMIT TRANSACTION RETURN StopDot:ROLLBACK TRANSACTION RETURN";
            StringBuilder sqlCmd = new StringBuilder(sql);
            SqlParameter[] sqlParas = {
                                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                                        fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                                        fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                                        fsp.FormatInParam("@TotalNum", SqlDbType.VarChar, TotalNum)
                                     };
            int i = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, sqlParas);
            return i;
        }

        public DataTable selectPress(string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate, string ActionNum)
        {
            string strSQL = string.Format(@"SELECT ID,MachineNo,MouldNo,WorkOrderNo,ProductNo,CONVERT(CHAR(19),BeginCycle,121) BeginCycle,{0} FROM StandDataHistory WHERE 1=1 ", KeepPress);
            strSQL += " AND MachineNo=@MachineNo AND MouldNo=@MouldNo AND ProductNo=@ProductNo";

            if (ActionNum == "-100") strSQL += " AND StandFlag='1'";// -100表示取试模记录中的一笔标准记录
            else
            {
                if (ActionNum != "-9") strSQL += " AND TotalNum=@TotalNum";//-9表示全部的试模记录
                else strSQL += " AND TotalNum=1";

                if (!string.IsNullOrEmpty(bDate)) strSQL += " AND CONVERT(CHAR(19),BeginCycle,121)>=@bDate";
                if (!string.IsNullOrEmpty(eDate)) strSQL += " AND CONVERT(CHAR(19),BeginCycle,121)<=@eDate";
            }
            strSQL += @" ORDER BY CONVERT(CHAR(19),BeginCycle,121) DESC";

            SqlParameter[] sqlParas = { 
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate),
                    fsp.FormatInParam("@TotalNum", SqlDbType.VarChar, ActionNum)
                };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        public DataTable selectGeneralField(string TechnicalPara, string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate, string ActionNum)
        {
            string strSQL = string.Format(@"SELECT a.ID, MachineNo, MouldNo, WorkOrderNo, ProductNo, CONVERT(CHAR(19),BeginCycle,121) BeginCycle,");
            if (TechnicalPara == "InjectCycle")
            {
                strSQL += string.Format("ISNULL(Cycletime,0) Cycletime ");
            }// 注塑周期
            if (TechnicalPara == "ShotTemp")
            {
                strSQL += string.Format("ISNULL(ShotTemp1,0) ShotTemp1,ISNULL(ShotTemp2,0) ShotTemp2,ISNULL(ShotTemp3,0) ShotTemp3 ");
            }// 注塑温度
            if (TechnicalPara == "MaxPress")
            {
                strSQL += string.Format("ISNULL(KeepPress_Max,0) KeepPress_Max ");
            }// 注塑最大压力
            if (TechnicalPara == "PreInjectTime")
            {
                strSQL += string.Format("ISNULL(PreInjectTime,0) PreInjectTime ");
            }// 预塑时间
            if (TechnicalPara == "InjectTime")
            {
                strSQL += string.Format("ISNULL(FillTime,0) FillTime");
            }// 注塑时间

            if (TechnicalPara == "InjectNum")
            {
                strSQL += string.Format("ISNULL(CAST(FillDistance * PI()*(ScrewDiameter*ScrewDiameter)/4 AS DECIMAL(18,2)),0) InjectNum ");
            }// 注塑物料用量
            strSQL += string.Format(" FROM StandDataHistory a LEFT JOIN MachineMstr ON a.MachineNo=Machine_Code WHERE 1=1 AND MachineNo=@MachineNo AND MouldNo=@MouldNo AND ProductNo=@ProductNo");

            if (ActionNum == "-100") strSQL += " AND StandFlag='1'";// -100表示取试模记录中一笔为标准
            else
            {
                if (ActionNum != "-9") strSQL += " AND TotalNum=@TotalNum";//-9表示全部的试模记录
                //else strSQL += " AND TotalNum=1";

                if (!string.IsNullOrEmpty(bDate)) strSQL += " AND CONVERT(CHAR(19),BeginCycle,121)>=@bDate";
                if (!string.IsNullOrEmpty(eDate)) strSQL += " AND CONVERT(CHAR(19),BeginCycle,121)<=@eDate";
            }
            strSQL += @" ORDER BY CONVERT(CHAR(19),BeginCycle,121)";

            SqlParameter[] sqlParas = { 
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate),
                    fsp.FormatInParam("@TotalNum", SqlDbType.VarChar, ActionNum)  
                };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        /// <summary>
        /// 获得机器编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMachineNoFromStandDataHistory()
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT MachineNo FROM StandDataHistory");

            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), null);
            return dt;
        }
        /// <summary>
        /// 获得模具编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMouldNoFromStandDataHistory(string MachineNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT MouldNo FROM StandDataHistory WHERE MachineNo=@MachineNo");
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo) };

            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
            return dt;
        }
        /// <summary>
        /// 获得产品编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectProductNoFromStandDataHistory(string MachineNo, string MouldNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT ProductNo FROM StandDataHistory WHERE MachineNo=@MachineNo AND MouldNo=@MouldNo");
            SqlParameter[] sqlParas ={
                                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                                        fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo)
                                     };

            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
            return dt;
        }

        /// <summary>
        /// 获得啤的序号
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <returns></returns>
        public DataTable selectActionNumFromStandDataHistory(string MachineNo, string MouldNo, string ProductNo)
        {
            string sql = "SELECT DISTINCT TotalNum FROM StandDataHistory WHERE MachineNo=@MachineNo AND MouldNo=@MouldNo AND ProductNo=@ProductNo ORDER BY 1";
            StringBuilder sqlCmd = new StringBuilder(sql);
            SqlParameter[] sqlParas ={
                                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                                        fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                                        fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo)
                                     };

            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);
            return dt;
        }
    }
}
