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
    public class BadReason_DAL : IBadReason
    {
        const string SQL_SELECT = "SELECT ID, ReasonID, IMReasonName,OMReasonName FROM BadReason WHERE 1=1 ";
        public IList<BadReason_MDL> selectBadReason()
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);

            IList<BadReason_MDL> BadReasonList = new List<BadReason_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), null))
            {
                while (sdr.Read())
                {
                    BadReason_MDL BadReason = new BadReason_MDL(
                        sdr.GetInt32(0),
                        sdr.GetString(1).Trim(),
                        sdr.GetString(2).Trim(),
                        sdr.GetString(2).Trim()
                        );
                    BadReasonList.Add(BadReason);
                }
            }
            return BadReasonList;
        }
    }
}
