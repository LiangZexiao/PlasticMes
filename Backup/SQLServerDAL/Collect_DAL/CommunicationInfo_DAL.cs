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
    public class CommunicationInfo_DAL : ICommunicationInfo
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();
        const string SQL_SELECT = @"SELECT ID, MachineNo, CollectorNo, IPAddr, Port, NetGate, CommStatus, CommStatusID,
                            Remark,WorkShop,WorkShopID FROM View_CommunicationInfo WHERE 1=1 ";

        const string SQL_INSERT = @"INSERT INTO CommunicationInfo(MachineNo, CollectorNo, IPAddr, Port, NetGate, CommStatus, Remark) 
                                    VALUES(@MachineNo, @CollectorNo, @IPAddr, @Port, @NetGate, @CommStatus, @Remark)";

        const string SQL_UPDATE = @"UPDATE CommunicationInfo SET MachineNo=@MachineNo, CollectorNo=@CollectorNo, IPAddr=@IPAddr, Port=@Port, 
                            NetGate=@NetGate, CommStatus=@CommStatus, Remark=@Remark WHERE ID=@ID  ";

        public IList<CommunicationInfo_MDL> selectCommunicationInfo(int id, string colname, string coltext)
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

            return getListCommunicationInfo(sqlCmd, sqlParas);
        }

        public IList<CommunicationInfo_MDL> existsCommunicationInfo(string vMachineNo, string vCollectorNo)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT * FROM CommunicationInfo WHERE MachineNo=@MachineNo AND CollectorNo=@CollectorNo");
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar,vMachineNo),
                        fsp.FormatInParam("@CollectorNo", SqlDbType.VarChar,vCollectorNo)
            };

            return getListCommunicationInfo(sqlCmd, sqlParas);
        }
        public IList<CommunicationInfo_MDL> existsCommunicationInfo2(string vcoltext, string vcolname)
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT * FROM CommunicationInfo WHERE "+vcolname+" = @colname");
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@colname", SqlDbType.VarChar,vcoltext)
            };

            return getListCommunicationInfo(sqlCmd, sqlParas);
        }

        private IList<CommunicationInfo_MDL> getListCommunicationInfo(StringBuilder sqlCmd, SqlParameter[] sqlParas)
        {
            IList<CommunicationInfo_MDL> CommunicationInfoList = new List<CommunicationInfo_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    CommunicationInfo_MDL CommunicationInfo = new CommunicationInfo_MDL(
                        sdr.GetInt32(0),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString(),
                        (sdr["CollectorNo"] == DBNull.Value) ? "" : sdr["CollectorNo"].ToString(),
                        (sdr["IPAddr"] == DBNull.Value) ? "" : sdr["IPAddr"].ToString(),
                        (sdr["Port"] == DBNull.Value) ? "" : sdr["Port"].ToString(),
                        (sdr["NetGate"] == DBNull.Value) ? "" : sdr["NetGate"].ToString(),
                        (sdr["CommStatusID"] == DBNull.Value) ? "" : sdr["CommStatusID"].ToString(),
                        (sdr["CommStatus"] == DBNull.Value) ? "" : sdr["CommStatus"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["WorkShop"] == DBNull.Value) ? "" : sdr["WorkShop"].ToString(),
                        (sdr["WorkShopID"] == DBNull.Value) ? "" : sdr["WorkShopID"].ToString()
                        );
                    CommunicationInfoList.Add(CommunicationInfo);
                }
            }
            return CommunicationInfoList;
        }

        public int ChangeCommunicationInfo(string vMachineNo, string vCollectorNo, string vIPAddr, string vPort, string vNetGate,
               string vCommStatus, string vRemark, string vWorkShopID, string vWorkShop, int vID, string IU)
        {
            string strSQL;
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar,vMachineNo),
                        fsp.FormatInParam("@CollectorNo", SqlDbType.VarChar,vCollectorNo),
                        fsp.FormatInParam("@IPAddr", SqlDbType.VarChar,vIPAddr),
                        fsp.FormatInParam("@Port", SqlDbType.VarChar,vPort),
                        fsp.FormatInParam("@NetGate", SqlDbType.VarChar,vNetGate),
                        fsp.FormatInParam("@CommStatus", SqlDbType.VarChar,vCommStatus),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar,vRemark),
                        fsp.FormatInParam("@ID", SqlDbType.VarChar,vID)
            };
            int s = 0;
            if (IU.ToUpper() == "INSERT")
                s = SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
                s = SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
            if (vMachineNo.ToUpper().Substring(0, 2) == "IM")
            {
                 strSQL = "update MachineMstr set WorkShopID='{0}', WorkShop='{1}'  where Machine_Code='{2}'";
            }
            else
            {
                 strSQL = "update PlantBristlesMachineInfo set WorkShopID='{0}', WorkShop='{1}' where MachineCode='{2}'";
            }
            strSQL = string.Format(strSQL, vWorkShopID, vWorkShop, vMachineNo);
            s = SqlHelper.ExecuteNonQuery(CommandType.Text, strSQL);
            return s;
        }

        public void cancelCommunicationInfo(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE CommunicationInfo WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
