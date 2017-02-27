using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Quality_DAL
{
    public class QualityTrack_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();

        /// <summary>
        /// 获取标准的周期值
        /// </summary>
        /// <param name="vProductNo"></param>
        /// <returns></returns>
        public DataTable selectStandCycle(string vProductNo)
        {
            string strSQL = "select  b.DO_NO,ISNULL(b.MinInjectionCycle,0) MinCycle,ISNULL(b.StandCycle,0) StandCycle,ISNULL(b.MaxInjectionCycle,0) MaxCycle from   DispatchOrder as b  where DO_NO=@ProductNo";
            
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo) };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        /// <summary>
        /// 获取标准的机器周期值
        /// </summary>
        /// <param name="vProductNo"></param>
        /// <returns></returns>
         
        public DataTable selectStandMachineCycle(string vProductNo)
        {
            string strSQL = "select  MachineCycle from   moulddetail as b  where mould_code=@ProductNo";

            SqlParameter[] sqlParas = { fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo) };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        /// <summary>
        /// 查询出标准的温度值
        /// </summary>
        /// <param name="vMachineNo"></param>
        /// <param name="vMouldNo"></param>
        /// <param name="vProductNo"></param>
        /// <returns></returns>
        
        public DataTable selectStandShotTemp(string vMachineNo, string vMouldNo, string vProductNo)
        {
            string strSQL = @"select Mould_ShotTemp as ShotTemp1,0 as ShotTemp2,0 as ShotTemp3 from moulddetail  WHERE 1=1  AND mould_code=@MouldNo ";

            SqlParameter[] sqlParas = { 
                                        fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, vMachineNo),            
                                        fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, vMouldNo),
                                        fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo) 
                                     };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL, sqlParas);
        }

        private double getKeepPress(string vKeepPress, int vNo)
        {
            int b;
            double returnValue;
            vKeepPress.PadRight(300, '0');
            b = (vNo - 1) * 3;

            returnValue=System.Convert.ToInt32(vKeepPress.Substring(b, 3), 16) / 10.0;
            return returnValue;
        }
        


        /// <summary>
        /// 注塑压力
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <param name="ProductNo"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable selectPress(string vDispatchOrder, string vMachineNo, string vMouldNo, string vProductNo, string bDate, string eDate, string[] TotalNum)
        {
            DataTable dtTmp;
            string strKeepPress;

            SqlParameter[] sqlParas = { 
                    fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, vDispatchOrder),
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, vMachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, vMouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate),
                    fsp.FormatInParam("@bTotalNum",SqlDbType.Int, TotalNum[TotalNum.Length - 1]),
                    fsp.FormatInParam("@eTotalNum",SqlDbType.Int,TotalNum[0])

                };
            dtTmp = SqlHelper.ReturnTableValue(CommandType.StoredProcedure, "GetDataOfPress100", sqlParas);
            foreach (DataRow dr in dtTmp.Rows)
            {
                if (dr["KeepPress"] != null && (!string.IsNullOrEmpty(dr["KeepPress"].ToString().Trim())))
                {
                    strKeepPress = dr["KeepPress"].ToString().Trim();
                    dr["KeepPress1"] = getKeepPress(strKeepPress, 1);
                    dr["KeepPress2"] = getKeepPress(strKeepPress,2);
                    dr["KeepPress3"] = getKeepPress(strKeepPress, 3);
                    dr["KeepPress4"] = getKeepPress(strKeepPress, 4);
                    dr["KeepPress5"] = getKeepPress(strKeepPress, 5);
                    dr["KeepPress6"] = getKeepPress(strKeepPress, 6);
                    dr["KeepPress7"] = getKeepPress(strKeepPress, 7);
                    dr["KeepPress8"] = getKeepPress(strKeepPress, 8);
                    dr["KeepPress9"] = getKeepPress(strKeepPress, 9);
                    dr["KeepPress10"] = getKeepPress(strKeepPress, 10);
                    /*dr["KeepPress11"] = getKeepPress(strKeepPress, 11);
                    dr["KeepPress12"] = getKeepPress(strKeepPress, 12);
                    dr["KeepPress13"] = getKeepPress(strKeepPress, 13);
                    dr["KeepPress14"] = getKeepPress(strKeepPress, 14);
                    dr["KeepPress15"] = getKeepPress(strKeepPress, 15);
                    dr["KeepPress16"] = getKeepPress(strKeepPress, 16);
                    dr["KeepPress17"] = getKeepPress(strKeepPress, 17);
                    dr["KeepPress18"] = getKeepPress(strKeepPress, 18);
                    dr["KeepPress19"] = getKeepPress(strKeepPress, 19);
                    dr["KeepPress20"] = getKeepPress(strKeepPress, 20);
                    dr["KeepPress21"] = getKeepPress(strKeepPress, 21);
                    dr["KeepPress22"] = getKeepPress(strKeepPress, 22);
                    dr["KeepPress23"] = getKeepPress(strKeepPress, 23);
                    dr["KeepPress24"] = getKeepPress(strKeepPress, 24);
                    dr["KeepPress25"] = getKeepPress(strKeepPress, 25);
                    dr["KeepPress26"] = getKeepPress(strKeepPress, 26);
                    dr["KeepPress27"] = getKeepPress(strKeepPress, 27);
                    dr["KeepPress28"] = getKeepPress(strKeepPress, 28);
                    dr["KeepPress29"] = getKeepPress(strKeepPress, 29);
                    dr["KeepPress30"] = getKeepPress(strKeepPress, 30);
                    dr["KeepPress31"] = getKeepPress(strKeepPress, 31);
                    dr["KeepPress32"] = getKeepPress(strKeepPress, 32);
                    dr["KeepPress33"] = getKeepPress(strKeepPress, 33);
                    dr["KeepPress34"] = getKeepPress(strKeepPress, 34);
                    dr["KeepPress35"] = getKeepPress(strKeepPress, 35);
                    dr["KeepPress36"] = getKeepPress(strKeepPress, 36);
                    dr["KeepPress37"] = getKeepPress(strKeepPress, 37);
                    dr["KeepPress38"] = getKeepPress(strKeepPress, 38);
                    dr["KeepPress39"] = getKeepPress(strKeepPress, 39);
                    dr["KeepPress40"] = getKeepPress(strKeepPress, 40);
                    dr["KeepPress41"] = getKeepPress(strKeepPress, 41);
                    dr["KeepPress42"] = getKeepPress(strKeepPress, 42);
                    dr["KeepPress43"] = getKeepPress(strKeepPress, 43);
                    dr["KeepPress44"] = getKeepPress(strKeepPress, 44);
                    dr["KeepPress45"] = getKeepPress(strKeepPress, 45);
                    dr["KeepPress46"] = getKeepPress(strKeepPress, 46);
                    dr["KeepPress47"] = getKeepPress(strKeepPress, 47);
                    dr["KeepPress48"] = getKeepPress(strKeepPress, 48);
                    dr["KeepPress49"] = getKeepPress(strKeepPress, 49);
                    dr["KeepPress50"] = getKeepPress(strKeepPress, 50);
                    dr["KeepPress51"] = getKeepPress(strKeepPress, 51);
                    dr["KeepPress52"] = getKeepPress(strKeepPress, 52);
                    dr["KeepPress53"] = getKeepPress(strKeepPress, 53);
                    dr["KeepPress54"] = getKeepPress(strKeepPress, 54);
                    dr["KeepPress55"] = getKeepPress(strKeepPress, 55);
                    dr["KeepPress56"] = getKeepPress(strKeepPress, 56);
                    dr["KeepPress57"] = getKeepPress(strKeepPress, 57);
                    dr["KeepPress58"] = getKeepPress(strKeepPress, 58);
                    dr["KeepPress59"] = getKeepPress(strKeepPress, 59);
                    dr["KeepPress60"] = getKeepPress(strKeepPress, 60);
                    dr["KeepPress61"] = getKeepPress(strKeepPress, 61);
                    dr["KeepPress62"] = getKeepPress(strKeepPress, 62);
                    dr["KeepPress63"] = getKeepPress(strKeepPress, 63);
                    dr["KeepPress64"] = getKeepPress(strKeepPress, 64);
                    dr["KeepPress65"] = getKeepPress(strKeepPress, 65);
                    dr["KeepPress66"] = getKeepPress(strKeepPress, 66);
                    dr["KeepPress67"] = getKeepPress(strKeepPress, 67);
                    dr["KeepPress68"] = getKeepPress(strKeepPress, 68);
                    dr["KeepPress69"] = getKeepPress(strKeepPress, 69);
                    dr["KeepPress70"] = getKeepPress(strKeepPress, 70);
                    dr["KeepPress71"] = getKeepPress(strKeepPress, 71);
                    dr["KeepPress72"] = getKeepPress(strKeepPress, 72);
                    dr["KeepPress73"] = getKeepPress(strKeepPress, 73);
                    dr["KeepPress74"] = getKeepPress(strKeepPress, 74);
                    dr["KeepPress75"] = getKeepPress(strKeepPress, 75);
                    dr["KeepPress76"] = getKeepPress(strKeepPress, 76);
                    dr["KeepPress77"] = getKeepPress(strKeepPress, 77);
                    dr["KeepPress78"] = getKeepPress(strKeepPress, 78);
                    dr["KeepPress79"] = getKeepPress(strKeepPress, 79);
                    dr["KeepPress80"] = getKeepPress(strKeepPress, 80);
                    dr["KeepPress81"] = getKeepPress(strKeepPress, 81);
                    dr["KeepPress82"] = getKeepPress(strKeepPress, 82);
                    dr["KeepPress83"] = getKeepPress(strKeepPress, 83);
                    dr["KeepPress84"] = getKeepPress(strKeepPress, 84);
                    dr["KeepPress85"] = getKeepPress(strKeepPress, 85);
                    dr["KeepPress86"] = getKeepPress(strKeepPress, 86);
                    dr["KeepPress87"] = getKeepPress(strKeepPress, 87);
                    dr["KeepPress88"] = getKeepPress(strKeepPress, 88);
                    dr["KeepPress89"] = getKeepPress(strKeepPress, 89);
                    dr["KeepPress90"] = getKeepPress(strKeepPress, 90);
                    dr["KeepPress91"] = getKeepPress(strKeepPress, 91);
                    dr["KeepPress92"] = getKeepPress(strKeepPress, 92);
                    dr["KeepPress93"] = getKeepPress(strKeepPress, 93);
                    dr["KeepPress94"] = getKeepPress(strKeepPress, 94);
                    dr["KeepPress95"] = getKeepPress(strKeepPress, 95);
                    dr["KeepPress96"] = getKeepPress(strKeepPress, 96);
                    dr["KeepPress97"] = getKeepPress(strKeepPress, 97);
                    dr["KeepPress98"] = getKeepPress(strKeepPress, 98);
                    dr["KeepPress99"] = getKeepPress(strKeepPress, 99);
                    dr["KeepPress100"] = getKeepPress(strKeepPress, 100);*/
                }
            }
            return dtTmp;
        }

        /// <summary>
        /// 现场的周期,温度,最大压力,填充时间
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <param name="ProductNo"></param>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public DataTable selectUnifyField(string vDispatchOrder,string vMachineNo, string vMouldNo, string vProductNo, string bDate, string eDate, string[] TotalNum)
        {
            SqlParameter[] sqlParas = {
                    fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, vDispatchOrder),
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, vMachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, vMouldNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, vProductNo),
                    fsp.FormatInParam("@bDate", SqlDbType.VarChar, bDate),
                    fsp.FormatInParam("@eDate", SqlDbType.VarChar, eDate),
                    fsp.FormatInParam("@bTotalNum",SqlDbType.Int, TotalNum[0]),
                    fsp.FormatInParam("@eTotalNum",SqlDbType.Int, TotalNum[TotalNum.Length - 1])
                };
            DataTable getDataTable = SqlHelper.ReturnTableValue(CommandType.StoredProcedure, "GetDataOfDrawPicture", sqlParas);
            return getDataTable;
        }
    }
}
