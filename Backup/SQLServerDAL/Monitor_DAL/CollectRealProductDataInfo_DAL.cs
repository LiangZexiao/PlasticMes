using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Monitor_MDL;
using Admin.Model;

namespace Admin.SQLServerDAL.Monitor_DAL
{
    public class CollectRealProductDataInfo_DAL
    {
        TableMstr tm = new TableMstr();
        DataOperator objDataOperator = new DataOperator();

        private const string TABLENAME      = "CollectRealProductData";

        private string fID          = "ID"; 
        private string fCollectorID = "CollectorID";
        private string fOrderID     = "OrderID";
        private string fItemNo      = "ItemNo";
        private string fMachineNo   = "MachineNo";
        private string fMouldNo     = "MouldNo";
        private string fBeginTime   = "BeginTime";
        private string cfBeginTime  = "CONVERT(CHAR(10),BeginTime,121) BeginTime";
        private string fEndTime     = "EndTime";
        private string cfEndTime    = "CONVERT(CHAR(10),EndTime,121) EndTime";

        private string fSwitch1 = "Switch1";
        private string fSwitch2 = "Switch2";
        private string fSwitch3 = "Switch3";
        private string fSwitch4 = "Switch4";
        private string fSwitch5 = "Switch5";
        private string fSwitch6 = "Switch6";
        private string fSwitch7 = "Switch7";
        private string fSwitch8 = "Switch8";

        private string fTemp1 = "Temp1";
        private string fTemp2 = "Temp2";
        private string fTemp3 = "Temp3";
        private string fTemp4 = "Temp4";
        private string fTemp5 = "Temp5";
        private string fTemp6 = "Temp6";
        private string fTemp7 = "Temp7";
        private string fTemp8 = "Temp8";

        private string fShotPress1 = "ShotPress1";
        private string fShotPress2 = "ShotPress2";
        private string fShotPress3 = "ShotPress3";
        private string fShotPress4 = "ShotPress4";
        private string fKeepPress1 = "KeepPress1";
        private string fKeepPress2 = "KeepPress2";
        private string fKeepPress3 = "KeepPress3";
        private string fFastLockMouldPress = "FastLockMouldPress";
        private string fLowPressLockMouldPress = "LowPressLockMouldPress";
        private string fHighPressLockMouldPress = "HighPressLockMouldPress";

        private string fP1 = "P1";
        private string fP2 = "P2";
        private string fDisplacement1 = "Displacement1";
        private string fDisplacement2 = "Displacement2";
        private string fUpLoadTime    = "UpLoadTime";
        private string cfUpLoadTime   = "CONVERT(CHAR(10),UpLoadTime,121) UpLoadTime";
        private string cfUpLoadTime2   = "CONVERT(CHAR(10),UpLoadTime,121)";

        public DataTable selectCollectRealProductDataInfo(CollectRealProductDataInfo_MDL dboCollectRealProductDataInfo)
        {
            string[] ColumnsName = {fID,
                fCollectorID,fOrderID,fItemNo,fMachineNo,fMouldNo,cfBeginTime,cfEndTime,
                fSwitch1,fSwitch2,fSwitch3,fSwitch4,fSwitch5,fSwitch6,fSwitch7,fSwitch8,
                fTemp1,fTemp2,fTemp3,fTemp4,fTemp5,fTemp6,fTemp7,fTemp8,
                fShotPress1,fShotPress2,fShotPress3,fShotPress4,
                fKeepPress1,fKeepPress2,fKeepPress3,
                fFastLockMouldPress,fLowPressLockMouldPress,fHighPressLockMouldPress,
                fP1,fP2,fDisplacement1,fDisplacement2,cfUpLoadTime
            };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.LikeColumnsName = (dboCollectRealProductDataInfo.LikeFieldName == fUpLoadTime) ? cfUpLoadTime2 : dboCollectRealProductDataInfo.LikeFieldName;
            tm.LikeColumnsText = dboCollectRealProductDataInfo.LikeFieldText;
            tm.OrderFieldName = fUpLoadTime;
            tm.OrderDirection = "DESC";
            return objDataOperator.ExecQueryCmd(tm);
        }

        public CollectRealProductDataInfo_MDL chooseCollectRealProductDataInfo(CollectRealProductDataInfo_MDL dboCollectRealProductDataInfo)
        {
            string[] ColumnsName = {
                fCollectorID,fOrderID,fItemNo,fMachineNo,fMouldNo,cfBeginTime,cfEndTime,
                fSwitch1,fSwitch2,fSwitch3,fSwitch4,fSwitch5,fSwitch6,fSwitch7,fSwitch8,
                fTemp1,fTemp2,fTemp3,fTemp4,fTemp5,fTemp6,fTemp7,fTemp8,
                fShotPress1,fShotPress2,fShotPress3,fShotPress4,
                fKeepPress1,fKeepPress2,fKeepPress3,
                fFastLockMouldPress,fLowPressLockMouldPress,fHighPressLockMouldPress,
                fP1,fP2,fDisplacement1,fDisplacement2,cfUpLoadTime
            };
            tm.TableName = TABLENAME;
            tm.ColumnsName = ColumnsName;
            tm.KeyColumnsName = new string[1] { fID };
            tm.KeyColumnsText = new string[1] { dboCollectRealProductDataInfo.ID };

            DataTable dt = objDataOperator.ExecQueryCmd(tm);
            CollectRealProductDataInfo_MDL tempCollectRealProductDataInfo = new CollectRealProductDataInfo_MDL(

                dt.Rows[0][fCollectorID].ToString().Trim(),
                dt.Rows[0][fOrderID].ToString().Trim(),
                dt.Rows[0][fItemNo].ToString().Trim(),
                dt.Rows[0][fMachineNo].ToString().Trim(),
                dt.Rows[0][fMouldNo].ToString().Trim(),
                dt.Rows[0][fBeginTime].ToString().Trim(),
                dt.Rows[0][fEndTime].ToString().Trim(),

                dt.Rows[0][fSwitch1].ToString().Trim(),
                dt.Rows[0][fSwitch2].ToString().Trim(),
                dt.Rows[0][fSwitch3].ToString().Trim(),
                dt.Rows[0][fSwitch4].ToString().Trim(),
                dt.Rows[0][fSwitch5].ToString().Trim(),
                dt.Rows[0][fSwitch6].ToString().Trim(),
                dt.Rows[0][fSwitch7].ToString().Trim(),
                dt.Rows[0][fSwitch8].ToString().Trim(),

                dt.Rows[0][fTemp1].ToString().Trim(),
                dt.Rows[0][fTemp2].ToString().Trim(),
                dt.Rows[0][fTemp3].ToString().Trim(),
                dt.Rows[0][fTemp4].ToString().Trim(),
                dt.Rows[0][fTemp5].ToString().Trim(),
                dt.Rows[0][fTemp6].ToString().Trim(),
                dt.Rows[0][fTemp7].ToString().Trim(),
                dt.Rows[0][fTemp8].ToString().Trim(),
                dt.Rows[0][fShotPress1].ToString().Trim(), 
                dt.Rows[0][fShotPress2].ToString().Trim(), 
                dt.Rows[0][fShotPress3].ToString().Trim(), 
                dt.Rows[0][fShotPress4].ToString().Trim(),
                dt.Rows[0][fKeepPress1].ToString().Trim(), 
                dt.Rows[0][fKeepPress2].ToString().Trim(), 
                dt.Rows[0][fKeepPress3].ToString().Trim(),
                dt.Rows[0][fFastLockMouldPress].ToString().Trim(), 
                dt.Rows[0][fLowPressLockMouldPress].ToString().Trim(),
                dt.Rows[0][fHighPressLockMouldPress].ToString().Trim(),
                dt.Rows[0][fP1].ToString().Trim(),
                dt.Rows[0][fP2].ToString().Trim(),
                dt.Rows[0][fDisplacement1].ToString().Trim(),
                dt.Rows[0][fDisplacement2].ToString().Trim(),
                dt.Rows[0][fUpLoadTime].ToString().Trim()
            );
            return tempCollectRealProductDataInfo;
        }
    }
}
