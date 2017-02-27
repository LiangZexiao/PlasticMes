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
    public class BadReason_BLL
    {
        private static readonly IBadReason factory = Admin.DALFactory.DataAccess.selectBadReason();
        public static IList<BadReason_MDL> selectBadReason()
        {
            return factory.selectBadReason();
        }
    }
}
