using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.Model.Monitor_MDL;
using Admin.IDAL.Monitor_IDAL;

namespace Admin.BLL.Monitor_BLL
{
    public class AlarmInfo_BLL
    {
        private static readonly IAlarmInfo factory = Admin.DALFactory.DataAccess.selectAlarmInfo();


        public static IList<AlarmInfo_MDL> selectAlarmInfo()
        {
            return factory.selectAlarmInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="AlarmSource"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public static IList<AlarmInfo_MDL> selectAlarmInfo(int _ID, string AlarmSource, string colname, string coltext)
        {
            return factory.selectAlarmInfo(_ID, AlarmSource, colname, coltext);
        }


        public static void updateAlarmInfo(int _ID)
        {
            factory.updateAlarmInfo(_ID);
        }

        //public static DataTable selectAlarmInfo(int _ID, string AlarmSource, string colname, string coltext)
        //{
        //    return factory.selectAlarmInfo(_ID, AlarmSource, colname, coltext);
        //}

        //public AlarmInfo_MDL chooseAlarmInfo(AlarmInfo_MDL dboAlarmInfo)
        //{
        //    AlarmInfo_DAL tempObject = new AlarmInfo_DAL();
        //    return tempObject.chooseAlarmInfo(dboAlarmInfo);
        //}

    }
}
