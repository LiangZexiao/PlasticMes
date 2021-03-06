﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Collect_MDL;

namespace Admin.IDAL.Collect_IDAL
{
    public interface ICommunicationInfo
    {
        IList<CommunicationInfo_MDL> selectCommunicationInfo(int _ID, string colname, string coltext);
        IList<CommunicationInfo_MDL> existsCommunicationInfo(string vMachineNo, string vCollectorNo);
        IList<CommunicationInfo_MDL> existsCommunicationInfo2(string vcoltext, string vcolname);
        int ChangeCommunicationInfo(string vMachineNo, string vCollectorNo, string vIPAddr, string vPort, string vNetGate,
               string vCommStatus, string vRemark,string vWorkShopID,string vWorkShop,int vID, string IU);
        void cancelCommunicationInfo(ArrayList _IDList);
    }
}
