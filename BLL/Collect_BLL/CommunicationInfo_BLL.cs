﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Collect_MDL;
using Admin.IDAL.Collect_IDAL;

namespace Admin.BLL.Collect_BLL
{
    public class CommunicationInfo_BLL
    {
        private static readonly ICommunicationInfo factory = Admin.DALFactory.DataAccess.selectCommunicationInfo();
        public static IList<CommunicationInfo_MDL> selectCommunicationInfo(int _ID, string colname, string coltext)
        {
            return factory.selectCommunicationInfo(_ID, colname, coltext);
        }

        public static IList<CommunicationInfo_MDL> existsCommunicationInfo(string vMachineNo, string vCollectorNo)
        {
            return factory.existsCommunicationInfo(vMachineNo, vCollectorNo);
        }
        public static IList<CommunicationInfo_MDL> existsCommunicationInfo2(string vcoltext, string vcolname)
        {
            return factory.existsCommunicationInfo(vcoltext, vcolname);
        }

        public static int ChangeCommunicationInfo(string vMachineNo, string vCollectorNo, string vIPAddr, string vPort, string vNetGate,
               string vCommStatus, string vRemark,string vWorkShopID,string vWorkShop, int vID, string IU)
        {
           return factory.ChangeCommunicationInfo(vMachineNo, vCollectorNo, vIPAddr, vPort, vNetGate,
               vCommStatus, vRemark,vWorkShopID,vWorkShop,vID, IU);
        }

        public static void cancelCommunicationInfo(ArrayList _idlist)
        {
            factory.cancelCommunicationInfo(_idlist);
        }
    }
}
