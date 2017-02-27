using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.BaseInfo_MDL;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.IDAL.BaseInfo_IDAL; 


namespace Admin.BLL.BaseInfo_BLL
{
    public class StopReason_BLL
    {
        private static readonly IStopReason factory = Admin.DALFactory.DataAccess.selectStopReason();
        public static IList<StopReason_MDL> selectStopReason()
        {
            return factory.selectStopReason();
        }
    }
}
