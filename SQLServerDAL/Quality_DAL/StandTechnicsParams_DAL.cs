using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Quality_MDL;
using Admin.Model;
using Admin.DBUtility;
using Admin.IDAL.Quality_IDAL;
using Admin.App_Code;



namespace Admin.SQLServerDAL.Quality_DAL
{
    public class StandTechnicsParams_DAL : IStandTechnicsParams
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();

        string TableName = "StandTechnicsParams";
        string[] FieldName1 = { "ID"};
        string[] FieldName2 = { "FileNo", "MachineNo", "MouldNo", "ProductNo", "RegrindRate", "Season", "Version", "Engineer", "DateTime_AdjustDate", "SetShotMouthTemp", 
                "ShotMouthTemp1", "ShotMouthTemp2", "ShotMouthTemp3", "MaterialPipeTemp", "GlueMeltTime", "ScrewTurnSpeed", "FillingTime", "PeriodTime", "ShotGlueDelay", "ShotGluePoint",
                "ThimbleNum", "MouldCloseNum", "CoolingTime", "FillingLimit", "GlueMeltTimeLimit", "GlueMeltDelay", "BeforeMeltSpeed", "BeforeMeltPress", "BeforeMeltTime", "MeltSpeed1", "MeltPress1",
                "MeltPosition1", "MeltSpeed2", "MeltPress2", "MeltPosition2", "AfterMeltSpeed", "AfterMeltPress", "AfterMeltPosition", "MeltBackPress", "ShotBaseFastSpeed1", "ShotPress1", 
                "ShotPosition1", "ShotBaseFastSpeed2", "ShotPress2", "ShotPosition2", "ShotBaseFastSpeed3", "ShotPress3", "ShotPosition3", "ShotBaseFastSpeed4", "ShotPress4", "ShotPosition4",
                "KeepPressSpeed1", "KeepPress1", "KeepPressPosition1", "KeepPress2", "KeepPressPosition2", "KeepPress3", "KeepPressPosition3", "ShotBaseFastSpeed", "ShotBaseFastPress", "ShotBaseFastTime",
                "ShotBaseSlowSpeed", "ShotBaseSlowPress", "ShotBackSpeed", "ShotBackPress", "ShotBackTemp", "AdjustMouldPress", "FastLockMouldSpeed", "FastLockMouldPress", "FastLockMouldPosition", "LowPressLockMouldSpeed",
                "LowPressLockMouldPress", "LowPressLockMouldPosition", "HighPressLockMouldSpeed", "HighPressLockMouldPress", "HighPressLockMouldPosition",
                "LowSpeedOpenMouldSpeed", "LowSpeedOpenMouldPress", "LowSpeedOpenMouldPosition", "HighSpeedOpenMouldSpeed", "HighSpeedOpenMouldPress",
                "HighSpeedOpenMouldPosition", "ReduceSpeedOpenMouldSpeed", "ReduceSpeedOpenMouldPress", "ReduceSpeedOpenMouldPosition", "ThimbleBeginMouldPosition",
                "ThimbleActKind", "ThimbleGoSpeed", "ThimbleGoPress", "ThimbleGoPosition", "ThimbleBackSpeed",
                "ThimbleBackPress", "ThimbleBackPosition", "ThimbleNum1", "ThimbleShakeTime", "ThimbleStayTime",
                "PushSpeed", "PushPress", "BeforeGetWater", "BeforeGetWaterTemp", "BeforeGetWaterMouldTemp",
                "AfterGetWater", "AfterGetWaterTemp", "AfterGetWaterMouldTemp", "GrossWeight", "MaterialNo", "Remark","QualiteRemark" };
        string[] FieldName3 = { "Photo", "PhotoType" };

        public IList<StandTechnicsParams_MDL> selectStandTechnicsParams(int id, string colname, string coltext)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length + FieldName3.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            System.Array.Copy(FieldName3, 0, SELECT, FieldName1.Length + FieldName2.Length, FieldName3.Length);

            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));
            SqlParameter[] sqlParas = null;
            if (id != 0)
            {
                sqlCmd.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }

            IList<StandTechnicsParams_MDL> StandTechnicsParamsList = new List<StandTechnicsParams_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    StandTechnicsParams_MDL StandTechnicsParams = new StandTechnicsParams_MDL(sdr.GetInt32(0),
                        (sdr["FileNo"] == DBNull.Value) ? "" : sdr["FileNo"].ToString().Trim(),
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                        (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                        (sdr["RegrindRate"] == DBNull.Value) ? "0" : sdr["RegrindRate"].ToString(),
                        (sdr["Season"] == DBNull.Value) ? "" : sdr["Season"].ToString().Trim(),
                        (sdr["Version"] == DBNull.Value) ? "" : sdr["Version"].ToString().Trim(),
                        (sdr["Engineer"] == DBNull.Value) ? "" : sdr["Engineer"].ToString().Trim(),
                        (sdr["AdjustDate"] == DBNull.Value) ? "" : sdr["AdjustDate"].ToString(),
                        (sdr["SetShotMouthTemp"] == DBNull.Value) ? "0" : sdr["SetShotMouthTemp"].ToString(),

                        (sdr["ShotMouthTemp1"] == DBNull.Value) ? "0" : sdr["ShotMouthTemp1"].ToString(),
                        (sdr["ShotMouthTemp2"] == DBNull.Value) ? "0" : sdr["ShotMouthTemp2"].ToString(),
                        (sdr["ShotMouthTemp3"] == DBNull.Value) ? "0" : sdr["ShotMouthTemp3"].ToString(),
                        (sdr["MaterialPipeTemp"] == DBNull.Value) ? "0" : sdr["MaterialPipeTemp"].ToString(),
                        (sdr["GlueMeltTime"] == DBNull.Value) ? "0" : sdr["GlueMeltTime"].ToString(),
                        (sdr["ScrewTurnSpeed"] == DBNull.Value) ? "0" : sdr["ScrewTurnSpeed"].ToString(),
                        (sdr["FillingTime"] == DBNull.Value) ? "0" : sdr["FillingTime"].ToString(),
                        (sdr["PeriodTime"] == DBNull.Value) ? "0" : sdr["PeriodTime"].ToString(),
                        (sdr["ShotGlueDelay"] == DBNull.Value) ? "0" : sdr["ShotGlueDelay"].ToString(),
                        (sdr["ShotGluePoint"] == DBNull.Value) ? "0" : sdr["ShotGluePoint"].ToString(),

                        (sdr["ThimbleNum"] == DBNull.Value) ? "0" : sdr["ThimbleNum"].ToString(),
                        (sdr["MouldCloseNum"] == DBNull.Value) ? "0" : sdr["MouldCloseNum"].ToString(),
                        (sdr["CoolingTime"] == DBNull.Value) ? "0" : sdr["CoolingTime"].ToString(),
                        (sdr["FillingLimit"] == DBNull.Value) ? "0" : sdr["FillingLimit"].ToString(),
                        (sdr["GlueMeltTimeLimit"] == DBNull.Value) ? "0" : sdr["GlueMeltTimeLimit"].ToString(),
                        (sdr["GlueMeltDelay"] == DBNull.Value) ? "0" : sdr["GlueMeltDelay"].ToString(),
                        (sdr["BeforeMeltSpeed"] == DBNull.Value) ? "0" : sdr["BeforeMeltSpeed"].ToString(),
                        (sdr["BeforeMeltPress"] == DBNull.Value) ? "0" : sdr["BeforeMeltPress"].ToString(),
                        (sdr["BeforeMeltTime"] == DBNull.Value) ? "0" : sdr["BeforeMeltTime"].ToString(),
                        (sdr["MeltSpeed1"] == DBNull.Value) ? "0" : sdr["MeltSpeed1"].ToString(),

                        (sdr["MeltPress1"] == DBNull.Value) ? "0" : sdr["MeltPress1"].ToString(),
                        (sdr["MeltPosition1"] == DBNull.Value) ? "0" : sdr["MeltPosition1"].ToString(),
                        (sdr["MeltSpeed2"] == DBNull.Value) ? "0" : sdr["MeltSpeed2"].ToString(),
                        (sdr["MeltPress2"] == DBNull.Value) ? "0" : sdr["MeltPress2"].ToString(),
                        (sdr["MeltPosition2"] == DBNull.Value) ? "0" : sdr["MeltPosition2"].ToString(),
                        (sdr["AfterMeltSpeed"] == DBNull.Value) ? "0" : sdr["AfterMeltSpeed"].ToString(),
                        (sdr["AfterMeltPress"] == DBNull.Value) ? "0" : sdr["AfterMeltPress"].ToString(),
                        (sdr["AfterMeltPosition"] == DBNull.Value) ? "0" : sdr["AfterMeltPosition"].ToString(),
                        (sdr["MeltBackPress"] == DBNull.Value) ? "0" : sdr["MeltBackPress"].ToString(),
                        (sdr["ShotBaseFastSpeed1"] == DBNull.Value) ? "0" : sdr["ShotBaseFastSpeed1"].ToString(),

                        (sdr["ShotPress1"] == DBNull.Value) ? "0" : sdr["ShotPress1"].ToString(),
                        (sdr["ShotPosition1"] == DBNull.Value) ? "0" : sdr["ShotPosition1"].ToString(),
                        (sdr["ShotBaseFastSpeed2"] == DBNull.Value) ? "0" : sdr["ShotBaseFastSpeed2"].ToString(),
                        (sdr["ShotPress2"] == DBNull.Value) ? "0" : sdr["ShotPress2"].ToString(),
                        (sdr["ShotPosition2"] == DBNull.Value) ? "0" : sdr["ShotPosition2"].ToString(),
                        (sdr["ShotBaseFastSpeed3"] == DBNull.Value) ? "0" : sdr["ShotBaseFastSpeed3"].ToString(),
                        (sdr["ShotPress3"] == DBNull.Value) ? "0" : sdr["ShotPress3"].ToString(),
                        (sdr["ShotPosition3"] == DBNull.Value) ? "0" : sdr["ShotPosition3"].ToString(),
                        (sdr["ShotBaseFastSpeed4"] == DBNull.Value) ? "0" : sdr["ShotBaseFastSpeed4"].ToString(),
                        (sdr["ShotPress4"] == DBNull.Value) ? "0" : sdr["ShotPress4"].ToString(),

                        (sdr["ShotPosition4"] == DBNull.Value) ? "0" : sdr["ShotPosition4"].ToString(),
                        (sdr["KeepPressSpeed1"] == DBNull.Value) ? "0" : sdr["KeepPressSpeed1"].ToString(),
                        (sdr["KeepPress1"] == DBNull.Value) ? "0" : sdr["KeepPress1"].ToString(),
                        (sdr["KeepPressSpeed1"] == DBNull.Value) ? "0" : sdr["KeepPressPosition1"].ToString(),
                        (sdr["KeepPress2"] == DBNull.Value) ? "0" : sdr["KeepPress2"].ToString(),
                        (sdr["KeepPressSpeed1"] == DBNull.Value) ? "0" : sdr["KeepPressPosition2"].ToString(),
                        (sdr["KeepPress3"] == DBNull.Value) ? "0" : sdr["KeepPress3"].ToString(),
                        (sdr["KeepPressSpeed1"] == DBNull.Value) ? "0" : sdr["KeepPressPosition3"].ToString(),
                        (sdr["ShotBaseFastSpeed"] == DBNull.Value) ? "0" : sdr["ShotBaseFastSpeed"].ToString(),
                        (sdr["KeepPressSpeed1"] == DBNull.Value) ? "0" : sdr["ShotBaseFastPress"].ToString(),

                        (sdr["ShotBaseFastTime"] == DBNull.Value) ? "0" : sdr["ShotBaseFastTime"].ToString(),
                        (sdr["ShotBaseSlowSpeed"] == DBNull.Value) ? "0" : sdr["ShotBaseSlowSpeed"].ToString(),
                        (sdr["ShotBaseSlowPress"] == DBNull.Value) ? "0" : sdr["ShotBaseSlowPress"].ToString(),
                        (sdr["ShotBackSpeed"] == DBNull.Value) ? "0" : sdr["ShotBackSpeed"].ToString(),
                        (sdr["ShotBackPress"] == DBNull.Value) ? "0" : sdr["ShotBackPress"].ToString(),
                        (sdr["ShotBackTemp"] == DBNull.Value) ? "0" : sdr["ShotBackTemp"].ToString(),
                        (sdr["AdjustMouldPress"] == DBNull.Value) ? "0" : sdr["AdjustMouldPress"].ToString(),
                        (sdr["FastLockMouldSpeed"] == DBNull.Value) ? "0" : sdr["FastLockMouldSpeed"].ToString(),
                        (sdr["FastLockMouldPress"] == DBNull.Value) ? "0" : sdr["FastLockMouldPress"].ToString(),
                        (sdr["FastLockMouldPosition"] == DBNull.Value) ? "0" : sdr["FastLockMouldPosition"].ToString(),

                        (sdr["LowPressLockMouldSpeed"] == DBNull.Value) ? "0" : sdr["LowPressLockMouldSpeed"].ToString(),
                        (sdr["LowPressLockMouldPress"] == DBNull.Value) ? "0" : sdr["LowPressLockMouldPress"].ToString(),
                        (sdr["LowPressLockMouldPosition"] == DBNull.Value) ? "0" : sdr["LowPressLockMouldPosition"].ToString(),
                        (sdr["HighPressLockMouldSpeed"] == DBNull.Value) ? "0" : sdr["HighPressLockMouldSpeed"].ToString(),
                        (sdr["HighPressLockMouldPress"] == DBNull.Value ) ? "0" : sdr["HighPressLockMouldPress"].ToString(),
                        (sdr["HighPressLockMouldPosition"] == DBNull.Value) ? "0" : sdr["HighPressLockMouldPosition"].ToString(),
                        (sdr["LowSpeedOpenMouldSpeed"] == DBNull.Value) ? "0" : sdr["LowSpeedOpenMouldSpeed"].ToString(),
                        (sdr["LowSpeedOpenMouldPress"] == DBNull.Value) ? "0" : sdr["LowSpeedOpenMouldPress"].ToString(),
                        (sdr["LowSpeedOpenMouldPosition"] == DBNull.Value) ? "0" : sdr["LowSpeedOpenMouldPosition"].ToString(),
                        (sdr["HighSpeedOpenMouldSpeed"] == DBNull.Value) ? "0" : sdr["HighSpeedOpenMouldSpeed"].ToString(),

                        (sdr["HighSpeedOpenMouldPress"] == DBNull.Value) ? "0" : sdr["HighSpeedOpenMouldPress"].ToString(),
                        (sdr["HighSpeedOpenMouldPosition"] == DBNull.Value) ? "0" : sdr["HighSpeedOpenMouldPosition"].ToString(),
                        (sdr["ReduceSpeedOpenMouldSpeed"] == DBNull.Value) ? "0" : sdr["ReduceSpeedOpenMouldSpeed"].ToString(),
                        (sdr["ReduceSpeedOpenMouldPress"] == DBNull.Value) ? "0" : sdr["ReduceSpeedOpenMouldPress"].ToString(),
                        (sdr["ReduceSpeedOpenMouldPosition"] == DBNull.Value) ? "0" : sdr["ReduceSpeedOpenMouldPosition"].ToString(),
                        (sdr["ThimbleBeginMouldPosition"] == DBNull.Value) ? "0" : sdr["ThimbleBeginMouldPosition"].ToString(),
                        (sdr["ThimbleActKind"] == DBNull.Value) ? "0" : sdr["ThimbleActKind"].ToString(),
                        (sdr["ThimbleGoSpeed"] == DBNull.Value) ? "0" : sdr["ThimbleGoSpeed"].ToString(),
                        (sdr["ThimbleGoPress"] == DBNull.Value) ? "0" : sdr["ThimbleGoPress"].ToString(),
                        (sdr["ThimbleGoPosition"] == DBNull.Value) ? "0" : sdr["ThimbleGoPosition"].ToString(),

                        (sdr["ThimbleBackSpeed"] == DBNull.Value) ? "0" : sdr["ThimbleBackSpeed"].ToString(),
                        (sdr["ThimbleBackPress"] == DBNull.Value) ? "0" : sdr["ThimbleBackPress"].ToString(),
                        (sdr["ThimbleBackPosition"] == DBNull.Value) ? "0" : sdr["ThimbleBackPosition"].ToString(),
                        (sdr["ThimbleNum1"] == DBNull.Value) ? "0" : sdr["ThimbleNum1"].ToString(),
                        (sdr["ThimbleShakeTime"] == DBNull.Value) ? "0" : sdr["ThimbleShakeTime"].ToString(),
                        (sdr["ThimbleStayTime"] == DBNull.Value) ? "0" : sdr["ThimbleStayTime"].ToString(),
                        (sdr["PushSpeed"] == DBNull.Value) ? "0" : sdr["PushSpeed"].ToString(),
                        (sdr["PushPress"] == DBNull.Value) ? "0" : sdr["PushPress"].ToString(),
                        (sdr["BeforeGetWater"] == DBNull.Value) ? "" : sdr["BeforeGetWater"].ToString(),
                        (sdr["BeforeGetWaterTemp"] == DBNull.Value) ? "0" : sdr["BeforeGetWaterTemp"].ToString(),

                        (sdr["BeforeGetWaterMouldTemp"] == DBNull.Value) ? "0" : sdr["BeforeGetWaterMouldTemp"].ToString(),
                        (sdr["AfterGetWater"] == DBNull.Value) ? "" : sdr["AfterGetWater"].ToString(),
                        (sdr["AfterGetWaterTemp"] == DBNull.Value) ? "0" : sdr["AfterGetWaterTemp"].ToString(),
                        (sdr["AfterGetWaterMouldTemp"] == DBNull.Value) ? "0" : sdr["AfterGetWaterMouldTemp"].ToString(),
                        (sdr["GrossWeight"] == DBNull.Value) ? "0" : sdr["GrossWeight"].ToString(),
                        (sdr["MaterialNo"] == DBNull.Value) ? "" : sdr["MaterialNo"].ToString(),
                        (sdr["Photo"] == DBNull.Value) ? null : (byte[])sdr["Photo"],
                        (sdr["PhotoType"] == DBNull.Value) ? null : (object)sdr["PhotoType"],
                        (sdr["Remark"] == DBNull.Value) ? "0" : sdr["Remark"].ToString(),
                         (sdr["QualiteRemark"] == DBNull.Value) ? "" : sdr["QualiteRemark"].ToString()                    
                        );
                    StandTechnicsParamsList.Add(StandTechnicsParams);
                }
            }
            return StandTechnicsParamsList;
        }

        public void updateStandTechnicsParams(StandTechnicsParams_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = {
                        fsp.FormatInParam("@FileNo", SqlDbType.VarChar, obj.FileNo),
                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, obj.MachineNo),
                        fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, obj.MouldNo),
                        fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, obj.ProductNo),
                        fsp.FormatInParam("@RegrindRate", SqlDbType.VarChar, obj.RegrindRate),
                        fsp.FormatInParam("@Season", SqlDbType.VarChar, obj.Season),
                        fsp.FormatInParam("@Version", SqlDbType.VarChar, obj.Version),
                        fsp.FormatInParam("@Engineer", SqlDbType.VarChar, obj.Engineer),
                        fsp.FormatInParam("@AdjustDate", SqlDbType.VarChar, obj.AdjustDate),
                        fsp.FormatInParam("@SetShotMouthTemp", SqlDbType.VarChar, obj.SetShotMouthTemp),

                        fsp.FormatInParam("@ShotMouthTemp1", SqlDbType.VarChar, obj.ShotMouthTemp1),
                        fsp.FormatInParam("@ShotMouthTemp2", SqlDbType.VarChar, obj.ShotMouthTemp2),
                        fsp.FormatInParam("@ShotMouthTemp3", SqlDbType.VarChar, obj.ShotMouthTemp3),
                        fsp.FormatInParam("@MaterialPipeTemp", SqlDbType.VarChar, obj.MaterialPipeTemp),
                        fsp.FormatInParam("@GlueMeltTime", SqlDbType.VarChar, obj.GlueMeltTime),
                        fsp.FormatInParam("@ScrewTurnSpeed", SqlDbType.VarChar, obj.ScrewTurnSpeed),
                        fsp.FormatInParam("@FillingTime", SqlDbType.VarChar, obj.FillingTime),
                        fsp.FormatInParam("@PeriodTime", SqlDbType.VarChar, obj.PeriodTime),
                        fsp.FormatInParam("@ShotGlueDelay", SqlDbType.VarChar, obj.ShotGlueDelay),
                        fsp.FormatInParam("@ShotGluePoint", SqlDbType.VarChar, obj.ShotGluePoint),

                        fsp.FormatInParam("@ThimbleNum", SqlDbType.VarChar, obj.ThimbleNum),
                        fsp.FormatInParam("@MouldCloseNum", SqlDbType.VarChar, obj.MouldCloseNum),
                        fsp.FormatInParam("@CoolingTime", SqlDbType.VarChar, obj.CoolingTime),
                        fsp.FormatInParam("@FillingLimit", SqlDbType.VarChar, obj.FillingLimit),
                        fsp.FormatInParam("@GlueMeltTimeLimit", SqlDbType.VarChar, obj.GlueMeltTimeLimit),
                        fsp.FormatInParam("@GlueMeltDelay", SqlDbType.VarChar, obj.GlueMeltDelay),
                        fsp.FormatInParam("@BeforeMeltSpeed", SqlDbType.VarChar, obj.BeforeMeltSpeed),
                        fsp.FormatInParam("@BeforeMeltPress", SqlDbType.VarChar, obj.BeforeMeltPress),
                        fsp.FormatInParam("@BeforeMeltTime", SqlDbType.VarChar, obj.BeforeMeltTime),
                        fsp.FormatInParam("@MeltSpeed1", SqlDbType.VarChar, obj.MeltSpeed1),

                        fsp.FormatInParam("@MeltPress1", SqlDbType.VarChar, obj.MeltPress1),
                        fsp.FormatInParam("@MeltPosition1", SqlDbType.VarChar, obj.MeltPosition1),
                        fsp.FormatInParam("@MeltSpeed2", SqlDbType.VarChar, obj.MeltSpeed2),
                        fsp.FormatInParam("@MeltPress2", SqlDbType.VarChar, obj.MeltPress2),
                        fsp.FormatInParam("@MeltPosition2", SqlDbType.VarChar, obj.MeltPosition2),
                        fsp.FormatInParam("@AfterMeltSpeed", SqlDbType.VarChar, obj.AfterMeltSpeed),
                        fsp.FormatInParam("@AfterMeltPress", SqlDbType.VarChar, obj.AfterMeltPress),
                        fsp.FormatInParam("@AfterMeltPosition", SqlDbType.VarChar, obj.AfterMeltPosition),
                        fsp.FormatInParam("@MeltBackPress", SqlDbType.VarChar, obj.MeltBackPress),
                        fsp.FormatInParam("@ShotBaseFastSpeed1", SqlDbType.VarChar, obj.ShotBaseFastSpeed1),
                         
                        fsp.FormatInParam("@ShotPress1", SqlDbType.VarChar, obj.ShotPress1),
                        fsp.FormatInParam("@ShotPosition1", SqlDbType.VarChar, obj.ShotPosition1),
                        fsp.FormatInParam("@ShotBaseFastSpeed2", SqlDbType.VarChar, obj.ShotBaseFastSpeed2),
                        fsp.FormatInParam("@ShotPress2", SqlDbType.VarChar, obj.ShotPress2),
                        fsp.FormatInParam("@ShotPosition2", SqlDbType.VarChar, obj.ShotPosition2),
                        fsp.FormatInParam("@ShotBaseFastSpeed3", SqlDbType.VarChar, obj.ShotBaseFastSpeed3),
                        fsp.FormatInParam("@ShotPress3", SqlDbType.VarChar, obj.ShotPress3),
                        fsp.FormatInParam("@ShotPosition3", SqlDbType.VarChar, obj.ShotPosition3),
                        fsp.FormatInParam("@ShotBaseFastSpeed4", SqlDbType.VarChar, obj.ShotBaseFastSpeed4),
                        fsp.FormatInParam("@ShotPress4", SqlDbType.VarChar, obj.ShotPress4),


                        fsp.FormatInParam("@ShotPosition4", SqlDbType.VarChar, obj.ShotPosition4),
                        fsp.FormatInParam("@KeepPressSpeed1", SqlDbType.VarChar, obj.KeepPressSpeed1),
                        fsp.FormatInParam("@KeepPress1", SqlDbType.VarChar, obj.KeepPress1),
                        fsp.FormatInParam("@KeepPressPosition1", SqlDbType.VarChar, obj.KeepPressPosition1),
                        fsp.FormatInParam("@KeepPress2", SqlDbType.VarChar, obj.KeepPress2),
                        fsp.FormatInParam("@KeepPressPosition2", SqlDbType.VarChar, obj.KeepPressPosition2),
                        fsp.FormatInParam("@KeepPress3", SqlDbType.VarChar, obj.KeepPress3),
                        fsp.FormatInParam("@KeepPressPosition3", SqlDbType.VarChar, obj.KeepPressPosition3),
                        fsp.FormatInParam("@ShotBaseFastSpeed", SqlDbType.VarChar, obj.ShotBaseFastSpeed),
                        fsp.FormatInParam("@ShotBaseFastPress", SqlDbType.VarChar, obj.ShotBaseFastPress),
                                                
                        fsp.FormatInParam("@ShotBaseFastTime", SqlDbType.VarChar, obj.ShotBaseFastTime),
                        fsp.FormatInParam("@ShotBaseSlowSpeed", SqlDbType.VarChar, obj.ShotBaseSlowSpeed),
                        fsp.FormatInParam("@ShotBaseSlowPress", SqlDbType.VarChar, obj.ShotBaseSlowPress),
                        fsp.FormatInParam("@ShotBackSpeed", SqlDbType.VarChar, obj.ShotBackSpeed),
                        fsp.FormatInParam("@ShotBackPress", SqlDbType.VarChar, obj.ShotBackPress),
                        fsp.FormatInParam("@ShotBackTemp", SqlDbType.VarChar, obj.ShotBackTemp),
                        fsp.FormatInParam("@AdjustMouldPress", SqlDbType.VarChar, obj.AdjustMouldPress),
                        fsp.FormatInParam("@FastLockMouldSpeed", SqlDbType.VarChar, obj.FastLockMouldSpeed),
                        fsp.FormatInParam("@FastLockMouldPress", SqlDbType.VarChar, obj.FastLockMouldPress),
                        fsp.FormatInParam("@FastLockMouldPosition", SqlDbType.VarChar, obj.FastLockMouldPosition),
                                                
                        fsp.FormatInParam("@LowPressLockMouldSpeed", SqlDbType.VarChar, obj.LowPressLockMouldSpeed),
                        fsp.FormatInParam("@LowPressLockMouldPress", SqlDbType.VarChar, obj.LowPressLockMouldPress),
                        fsp.FormatInParam("@LowPressLockMouldPosition", SqlDbType.VarChar, obj.LowPressLockMouldPosition),
                        fsp.FormatInParam("@HighPressLockMouldSpeed", SqlDbType.VarChar, obj.HighPressLockMouldSpeed),
                        fsp.FormatInParam("@HighPressLockMouldPress", SqlDbType.VarChar, obj.HighPressLockMouldPress),
                        fsp.FormatInParam("@HighPressLockMouldPosition", SqlDbType.VarChar, obj.HighPressLockMouldPosition),
                        fsp.FormatInParam("@LowSpeedOpenMouldSpeed", SqlDbType.VarChar, obj.LowSpeedOpenMouldSpeed),
                        fsp.FormatInParam("@LowSpeedOpenMouldPress", SqlDbType.VarChar, obj.LowSpeedOpenMouldPress),
                        fsp.FormatInParam("@LowSpeedOpenMouldPosition", SqlDbType.VarChar, obj.LowSpeedOpenMouldPosition),
                        fsp.FormatInParam("@HighSpeedOpenMouldSpeed", SqlDbType.VarChar, obj.HighSpeedOpenMouldSpeed),
                        
                        fsp.FormatInParam("@HighSpeedOpenMouldPress", SqlDbType.VarChar, obj.HighSpeedOpenMouldPress),
                        fsp.FormatInParam("@HighSpeedOpenMouldPosition", SqlDbType.VarChar, obj.HighSpeedOpenMouldPosition),
                        fsp.FormatInParam("@ReduceSpeedOpenMouldSpeed", SqlDbType.VarChar, obj.ReduceSpeedOpenMouldSpeed),
                        fsp.FormatInParam("@ReduceSpeedOpenMouldPress", SqlDbType.VarChar, obj.ReduceSpeedOpenMouldPress),
                        fsp.FormatInParam("@ReduceSpeedOpenMouldPosition", SqlDbType.VarChar, obj.ReduceSpeedOpenMouldPosition),
                        fsp.FormatInParam("@ThimbleBeginMouldPosition", SqlDbType.VarChar, obj.ThimbleBeginMouldPosition),
                        fsp.FormatInParam("@ThimbleActKind", SqlDbType.VarChar, obj.ThimbleActKind),
                        fsp.FormatInParam("@ThimbleGoSpeed", SqlDbType.VarChar, obj.ThimbleGoSpeed),
                        fsp.FormatInParam("@ThimbleGoPress", SqlDbType.VarChar, obj.ThimbleGoPress),
                        fsp.FormatInParam("@ThimbleGoPosition", SqlDbType.VarChar, obj.ThimbleGoPosition),

                        fsp.FormatInParam("@ThimbleBackSpeed", SqlDbType.VarChar, obj.ThimbleBackSpeed),
                        fsp.FormatInParam("@ThimbleBackPress", SqlDbType.VarChar, obj.ThimbleBackPress),
                        fsp.FormatInParam("@ThimbleBackPosition", SqlDbType.VarChar, obj.ThimbleBackPosition),
                        fsp.FormatInParam("@ThimbleNum1", SqlDbType.VarChar, obj.ThimbleNum1),
                        fsp.FormatInParam("@ThimbleShakeTime", SqlDbType.VarChar, obj.ThimbleShakeTime),
                        fsp.FormatInParam("@ThimbleStayTime", SqlDbType.VarChar, obj.ThimbleStayTime),
                        fsp.FormatInParam("@PushSpeed", SqlDbType.VarChar, obj.PushSpeed),
                        fsp.FormatInParam("@PushPress", SqlDbType.VarChar, obj.PushPress),
                        fsp.FormatInParam("@BeforeGetWater", SqlDbType.VarChar, obj.BeforeGetWaterSpeed),
                        fsp.FormatInParam("@BeforeGetWaterTemp", SqlDbType.VarChar, obj.BeforeGetWaterTemp),
                                                
                        fsp.FormatInParam("@BeforeGetWaterMouldTemp", SqlDbType.VarChar, obj.BeforeGetWaterMouldTemp),
                        fsp.FormatInParam("@AfterGetWater", SqlDbType.VarChar, obj.AfterGetWaterSpeed),
                        fsp.FormatInParam("@AfterGetWaterTemp", SqlDbType.VarChar, obj.AfterGetWaterTemp),
                        fsp.FormatInParam("@AfterGetWaterMouldTemp", SqlDbType.VarChar, obj.AfterGetWaterMouldTemp),
                        fsp.FormatInParam("@GrossWeight", SqlDbType.VarChar, obj.GrossWeight),
                        fsp.FormatInParam("@MaterialNo", SqlDbType.VarChar, obj.MaterialNo),
                        fsp.FormatInParam("@Photo", SqlDbType.Image, obj.Photo),
                        fsp.FormatInParam("@PhotoType", SqlDbType.VarChar, obj.PhotoType),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark),
                        fsp.FormatInParam("@QualiteRemark", SqlDbType.VarChar, obj.QualiteRemark),
                        fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
           byte[] temp_Photo = obj.Photo;
           object temp_PhotoType = obj.PhotoType;
           string[] SQL = null;
           if (temp_Photo.Length == 0 || temp_PhotoType == null)
           {
               SQL = new string[FieldName2.Length];
               System.Array.Copy(FieldName2, 0, SQL, 0, FieldName2.Length);
           }
           else
           {
               SQL = new string[FieldName2.Length + FieldName3.Length];
               System.Array.Copy(FieldName2, 0, SQL, 0, FieldName2.Length);
               System.Array.Copy(FieldName3, 0, SQL, FieldName2.Length, FieldName3.Length);
           }
           try
           {
               if (IU.ToUpper() == "INSERT")
                   SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, SQL), sqlParas);
               else
                   SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, SQL), sqlParas);
           }
           catch(Exception ex)
           {

           }
           finally
           {
               obj = null;
           }
        }

        public void deleteStandTechnicsParams(int _ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, _ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE StandTechnicsParams WHERE ID=@ID", sqlParas);
        }

        public void cancelStandTechnicsParams(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE StandTechnicsParams WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

    }
}
