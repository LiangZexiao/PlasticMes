using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;
using Admin.IDAL.Quality_IDAL;

namespace Admin.BLL.Quality_BLL
{
    public class StandTechnicsParams_BLL
    {
        private static readonly IStandTechnicsParams factory = Admin.DALFactory.DataAccess.selectStandTechnicsParams();
        public static IList<StandTechnicsParams_MDL> selectStandTechnicsParams(int _ID, string colname, string coltext)
        {
            return factory.selectStandTechnicsParams(_ID, colname, coltext);
        }

        public static void updateStandTechnicsParams(int vID, string vFileNo, string vMachineNo, string vMouldNo, string vProductNo,
             string vRegrindRate, string vSeason, string vVersion, string vEngineer, string vAdjustDate,
             string vSetShotMouthTemp, string vShotMouthTemp1, string vShotMouthTemp2, string vShotMouthTemp3, string vMaterialPipeTemp,
             string vGlueMeltTime, string vScrewTurnSpeed, string vFillingTime, string vPeriodTime, string vShotGlueDelay,
             string vShotGluePoint, string vThimbleNum, string vMouldCloseNum, string vCoolingTime, string vFillingLimit,
             string vGlueMeltTimeLimit, string vGlueMeltDelay, string vBeforeMeltSpeed, string vBeforeMeltPress, string vBeforeMeltTime,
             string vMeltSpeed1,
             string vMeltPress1, string vMeltPosition1, string vMeltSpeed2, string vMeltPress2, string vMeltPosition2,
             string vAfterMeltSpeed, string vAfterMeltPress, string vAfterMeltPosition, string vMeltBackPress, string vShotBaseFastSpeed1,
             string vShotPosition1, string vShotPress1, string vShotBaseFastSpeed2, string vShotPress2, string vShotPosition2,
             string vShotBaseFastSpeed3, string vShotPress3, string vShotPosition3, string vShotBaseFastSpeed4, string vShotPress4,
             string vShotPosition4, string vKeepPressSpeed1, string vKeepPress1, string vKeepPressPosition1, string vKeepPress2,
             string vKeepPressPosition2, string vKeepPress3, string vKeepPressPosition3, string vShotBaseFastSpeed, string vShotBaseFastPress,
             string vShotBaseFastTime, string vShotBaseSlowSpeed, string vShotBaseSlowPress, string vShotBackSpeed, string vShotBackPress,
             string vShotBackTemp, string vAdjustMouldPress, string vFastLockMouldSpeed, string vFastLockMouldPress, string vFastLockMouldPosition,
             string vLowPressLockMouldSpeed, string vLowPressLockMouldPress, string vLowPressLockMouldPosition, string vHighPressLockMouldSpeed, string vHighPressLockMouldPress,
             string vHighPressLockMouldPosition, string vLowSpeedOpenMouldSpeed, string vLowSpeedOpenMouldPress, string vLowSpeedOpenMouldPosition, string vHighSpeedOpenMouldSpeed,
             string vHighSpeedOpenMouldPress, string vHighSpeedOpenMouldPosition, string vReduceSpeedOpenMouldSpeed, string vReduceSpeedOpenMouldPress, string vReduceSpeedOpenMouldPosition,
             string vThimbleBeginMouldPosition, string vThimbleActKind, string vThimbleGoSpeed, string vThimbleGoPress, string vThimbleGoPosition,
             string vThimbleBackSpeed, string vThimbleBackPress, string vThimbleBackPosition, string vThimbleNum1, string vThimbleShakeTime,
             string vThimbleStayTime,
             string vPushSpeed, string vPushPress, string vBeforeGetWaterSpeed, string vBeforeGetWaterTemp, string vBeforeGetWaterMouldTemp,
             string vAfterGetWaterSpeed, string vAfterGetWaterTemp, string vAfterGetWaterMouldTemp, string vGrossWeight, string vMaterialNo,
             byte[] vPhoto, object vPhotoType, string vRemark,string vQualiteRemark, string IU)
        {
            StandTechnicsParams_MDL obj = new StandTechnicsParams_MDL(vID, vFileNo, vMachineNo, vMouldNo, vProductNo,
             vRegrindRate, vSeason, vVersion, vEngineer, vAdjustDate,
             vSetShotMouthTemp, vShotMouthTemp1, vShotMouthTemp2, vShotMouthTemp3, vMaterialPipeTemp,
             vGlueMeltTime, vScrewTurnSpeed, vFillingTime, vPeriodTime, vShotGlueDelay,
             vShotGluePoint, vThimbleNum, vMouldCloseNum, vCoolingTime, vFillingLimit,
             vGlueMeltTimeLimit, vGlueMeltDelay, vBeforeMeltSpeed, vBeforeMeltPress, vBeforeMeltTime,
             vMeltSpeed1,
             vMeltPress1, vMeltPosition1, vMeltSpeed2, vMeltPress2, vMeltPosition2,
             vAfterMeltSpeed, vAfterMeltPress, vAfterMeltPosition, vMeltBackPress, vShotBaseFastSpeed1,
             vShotPosition1, vShotPress1, vShotBaseFastSpeed2, vShotPress2, vShotPosition2,
             vShotBaseFastSpeed3, vShotPress3, vShotPosition3, vShotBaseFastSpeed4, vShotPress4,
             vShotPosition4, vKeepPressSpeed1, vKeepPress1, vKeepPressPosition1, vKeepPress2,
             vKeepPressPosition2, vKeepPress3, vKeepPressPosition3, vShotBaseFastSpeed, vShotBaseFastPress,
             vShotBaseFastTime, vShotBaseSlowSpeed, vShotBaseSlowPress, vShotBackSpeed, vShotBackPress,
             vShotBackTemp, vAdjustMouldPress, vFastLockMouldSpeed, vFastLockMouldPress, vFastLockMouldPosition,
             vLowPressLockMouldSpeed, vLowPressLockMouldPress, vLowPressLockMouldPosition, vHighPressLockMouldSpeed, vHighPressLockMouldPress,
             vHighPressLockMouldPosition, vLowSpeedOpenMouldSpeed, vLowSpeedOpenMouldPress, vLowSpeedOpenMouldPosition, vHighSpeedOpenMouldSpeed,
             vHighSpeedOpenMouldPress, vHighSpeedOpenMouldPosition, vReduceSpeedOpenMouldSpeed, vReduceSpeedOpenMouldPress, vReduceSpeedOpenMouldPosition,
             vThimbleBeginMouldPosition, vThimbleActKind, vThimbleGoSpeed, vThimbleGoPress, vThimbleGoPosition,
             vThimbleBackSpeed, vThimbleBackPress, vThimbleBackPosition, vThimbleNum1, vThimbleShakeTime,
             vThimbleStayTime,
             vPushSpeed, vPushPress, vBeforeGetWaterSpeed, vBeforeGetWaterTemp, vBeforeGetWaterMouldTemp,
             vAfterGetWaterSpeed, vAfterGetWaterTemp, vAfterGetWaterMouldTemp, vGrossWeight, vMaterialNo,
             vPhoto, vPhotoType, vRemark, vQualiteRemark);

            factory.updateStandTechnicsParams(obj, IU);
        }

        public static void deleteStandTechnicsParams(int _id)
        {
            factory.deleteStandTechnicsParams(_id);
        }

        public static void cancelStandTechnicsParams(ArrayList _idlist)
        {
            factory.cancelStandTechnicsParams(_idlist);
        }
    }
}
