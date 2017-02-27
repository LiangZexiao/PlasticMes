using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.BaseInfo_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class StopReason_DAL : IStopReason
    {
        const string SQL_SELECT = "SELECT ID, ReasonID, ReasonName FROM StopReason WHERE 1=1 ";
        const string SQL_SELECT2 =@"SELECT ID, ReasonID, ReasonName FROM StopReason
                                 WHERE 1=1 and ReasonID not in(0,10,14,15,16) ";
        public IList<StopReason_MDL> selectStopReason()
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);

            IList<StopReason_MDL> StopReasonList = new List<StopReason_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), null))
            {
                while (sdr.Read())
                {
                    StopReason_MDL StopReason = new StopReason_MDL(
                        sdr.GetInt32(0),
                        sdr.GetString(1).Trim(),
                        sdr.GetString(2).Trim()
                        );
                    StopReasonList.Add(StopReason);
                }
            }
            return StopReasonList;
        }
        public IList<StopReason_MDL> selectStopReason2()
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT2);

            IList<StopReason_MDL> StopReasonList = new List<StopReason_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), null))
            {
                while (sdr.Read())
                {
                    StopReason_MDL StopReason = new StopReason_MDL(
                        sdr.GetInt32(0),
                        sdr.GetString(1).Trim(),
                        sdr.GetString(2).Trim()
                        );
                    StopReasonList.Add(StopReason);
                }
            }
            return StopReasonList;
        }
    }
}
