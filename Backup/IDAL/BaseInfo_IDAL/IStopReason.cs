using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.BaseInfo_MDL;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IStopReason
    {
        IList<StopReason_MDL> selectStopReason();
        IList<StopReason_MDL> selectStopReason2();
    }
}
