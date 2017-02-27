using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model.Collect_MDL;
using Admin.DBUtility;
using Admin.Model;

namespace Admin.SQLServerDAL.Collect_DAL
{
    public class CardDetail_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();
        SQLExecutant sc = new SQLExecutant();

        const string tabname = @"SELECT id, dispatchNo,MachineNo,iccardno, 
                                cardtype, employeename_cn,employeeid
                                ,begindate, enddate  from (
                                SELECT cd.id, dono  dispatchNo, do.MachineNo, cardid  AS iccardno, cardtype, 
                                 dbo.GetEmpNameByID(cd.EmpID) AS employeename_cn,cd.EmpID AS employeeid, begindate, enddate
                                FROM  cardDetail cd  INNER JOIN dispatchorder do ON do.DO_NO = cd.dono WHERE 1 = 1  ";
        const string SQL_SELECT1 = @"select IPAddr,ci.MachineNo from CommunicationInfo ci left join DispatchOrder do on ci.MachineNo=do.MachineNo where 1=1 ";
        const string SQL_SELECT = @"SELECT ID,DONO,ClientIP,CardID,CardType,BeginDate,EndDate,Remark  FROM CardDetail WHERE 1=1 ";
        const string SQL_INSERT = @"INSERT INTO CardDetail(DONO,ClientIP,CardID,CardType,BeginDate,EndDate,CreateDate,Remark) values(@DONO,@ClientIP,@CardID,@CardType,@BeginDate,@EndDate,@CreateDate,@Remark)";
        const string SQL_INSERTDeviceRealStatus = @" INSERT INTO dbo.DeviceRealStatus(CardID, DispatchNo, DeviceStatus, Start_Date,End_Date , LastUpdateDate, ClientIP) values (@CardID,@DONO,@CardType,@BeginDate,@EndDate,@CreateDate,@ClientIP)  ";
        const string SQL_UPDATE = @"UPDATE CardDetail Set CardID=@CardID,CardType=@CardType,BeginDate=@BeginDate,EndDate=@EndDate,Remark=@Remark WHERE ID=@ID ";
        const string SQL_UPDATEDeviceRealStatus = @" UPDATE DeviceRealStatus  set DeviceStatus=@CardType,Start_Date=@BeginDate,End_Date=@EndDate,LastUpdateDate=@CreateDate where CardID=@CardID and DispatchNo=@DONO and DeviceStatus=@OdlCardType and Start_Date=@OdlBeginDate and End_Date=@OdlEndDate ";

            

        public DataTable selectICCard(string Auto, string BCType, string colname, string coltext, string begindate, string enddate)
        {
            string sql = tabname;
            if (begindate != "" && enddate != "")
            {
                sql += string.Format(" and ((convert(char(16),begindate,121) >= '" + begindate + "' and convert(char(16),begindate,121) <= '" + enddate + "')  ");
                sql += string.Format(" or (convert(char(16),enddate,121) >= '" + begindate + "' and convert(char(16),enddate,121) <= '" + enddate + "'))");
            }
            if (Auto != string.Empty)
            {
                if (Auto == "IM04")
                    sql += " And (do.MachineNo like '" + Auto + "%' or do.MachineNo like 'PM%')";
                else
                    sql += " And do.MachineNo like '" + Auto + "%'";
            }
            if (BCType != string.Empty)
            {
                sql += " And CardType='" + BCType + "'";
            }
            sql += ") a  where 1=1 ";
            if (colname != "" && coltext != "")
            {
                sql += string.Format(" and  {0} like '%" + coltext + "%'", colname);
            }
            sql += " order by MachineNo desc ";
            return sc.ExecQueryCmd(sql);

        }

        public DataTable selectIPAddr(string DO_NO, string colname, string coltext)
        {
            string sql = SQL_SELECT1;
            if (colname != "" && coltext != "")
            {
                sql += string.Format(" and  {0} like '%" + coltext + "%'", colname);
            }
            if (DO_NO != "")
            {
                sql += string.Format(" and DO_NO ='" + DO_NO + "'");
            }
            return SqlHelper.ReturnDataSet(CommandType.Text, sql, null).Tables[0];

        }

        public DataTable selectICCardDetail(int ID, string colname, string coltext, string begindate, string enddate)
        {
            string sql = SQL_SELECT;
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, ID)
           };

            if (ID != 0)
            {
                sql += (string.Format(" AND  ID=@ID "));
            }
            if (colname != "" && coltext != "")
            {
                sql += string.Format(" and  {0} like '%" + coltext + "%'", colname);
            }
            if (begindate != "")
            {
                sql += string.Format(" and BeginDate > '" + begindate + "'");
            }
            if (enddate != "")
            {
                sql += string.Format(" and EndDate < '" + enddate + "'");
            }
            sql += " order by BeginDate desc ";
            return SqlHelper.ReturnDataSet(CommandType.Text, sql, sqlParas).Tables[0];
        }

        public int deleteCardDetail(string vDO_NO)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_NO", SqlDbType.VarChar, vDO_NO) };
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("DELETE CardDetail WHERE id=@DO_NO IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ");
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, sqlParas);
            //SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE DispatchOrder WHERE ID=@ID", sqlParas);
        }

        public int cancelCardDetail(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
            {
                ExecBatch += string.Format("DELETE CardDetail WHERE id={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int ChangeCardDetail(CardDetail_MDL Obj, string IU)
        {
            SqlParameter[] sqlParas = {
                         fsp.FormatInParam("@DONO", SqlDbType.VarChar, Obj.DoNo),
                         fsp.FormatInParam("@ClientIP", SqlDbType.VarChar, Obj.ClientIP ),
                         fsp.FormatInParam("@CardID", SqlDbType.VarChar, Obj.CardID),
                         fsp.FormatInParam("@CardType", SqlDbType.VarChar, Obj.CardType),
                         fsp.FormatInParam("@BeginDate", SqlDbType.VarChar, Obj.BeginDate),
                         fsp.FormatInParam("@EndDate", SqlDbType.VarChar, Obj.EndDate),
                         fsp.FormatInParam("@CreateDate", SqlDbType.VarChar, Obj.CreateDate),
                         fsp.FormatInParam("@Remark", SqlDbType.VarChar, Obj.Remark), 
                         fsp.FormatInParam("@OdlCardType", SqlDbType.VarChar, Obj.OdlCardType), 
                         fsp.FormatInParam("@OdlBeginDate", SqlDbType.VarChar, Obj.OdlBeginDate),   
                         fsp.FormatInParam("@OdlEndDate", SqlDbType.VarChar, Obj.OdlEndDate),                
                         fsp.FormatInParam("@ID", SqlDbType.VarChar, Obj.ID)
            };
            if (IU == "INSERT")
            {
                if (Obj.CardType == "10" || Obj.CardType == "14")//10：交班 14：上班这3种刷卡记录不写停机状态
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
                }
                else
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT + "   " + SQL_INSERTDeviceRealStatus, sqlParas);
                }
            }
            else
            {
                if (Obj.CardType == "10" || Obj.CardType == "14")//10：交班 14：上班这3种刷卡记录不写停机状态
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
                }
                else
                {
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE + "      " + SQL_UPDATEDeviceRealStatus, sqlParas);
                }

            }
            //Obj = null;
        }
    }
}
