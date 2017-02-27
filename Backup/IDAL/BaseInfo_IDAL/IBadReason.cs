using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.BaseInfo_MDL;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IBadReason
    {
        IList<BadReason_MDL> selectBadReason();

    }
}
