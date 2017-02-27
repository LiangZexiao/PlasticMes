using System;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using System.Data;

namespace Admin.SQLServerDAL
{
    public class Common
    {
        public string GetSafeSqlText(bool isFlag, string pValue)
        {
            StringBuilder tempBuilder = new StringBuilder(pValue);
            tempBuilder.Replace("'", "''");
            if (isFlag)
            {
                tempBuilder.Replace("[", "[[]");
                tempBuilder.Replace("%", "[%]");
                tempBuilder.Replace("_", "[_]");
            }
            return tempBuilder.ToString().Trim();
        }

        public string[] GetSqlSafeParameter(string[] inParameter, bool[] isLikeSafe)
        {
            StringBuilder sBuilder;
            for (int i = 0;
                (i < inParameter.Length && inParameter.Length == isLikeSafe.Length);
                i++)
            {
                sBuilder = new StringBuilder(inParameter[i]);
                sBuilder.Replace("'", "''");
                if (isLikeSafe[i])
                {
                    inParameter[i].Replace("[", "[[]");
                    inParameter[i].Replace("%", "[%]");
                    inParameter[i].Replace("_", "[_]");
                }
                inParameter[i] = sBuilder.ToString().Trim();
                sBuilder = null;
            }
            return inParameter;
        }

        //090718吴礼政 临时插入方法(需整合至底层,祝整合愉快)
        /// <summary>
        /// 查询已完成数量
        /// </summary>
        /// <param name="Type">注塑或植毛</param>
        /// <param name="DispatchNo">工单号</param>
        /// <returns></returns>
        public static string GetTempStr(string Type, string WrokNo)
        {
            string Sql_GetTempStr;
            if (Type == "IM")
            {
                Sql_GetTempStr = @"Select Cast(M.GoodSocketNum*DH.TotalNum as Int) Num  From Dispatchorder D Inner Join DataHistoryMain DH On D.Do_No=DH.DispatchOrder Inner Join MouldDetail M On DH.MouldNo=M.Mould_Code Where D.Do_No Like '{0}%'";
                Sql_GetTempStr = string.Format(Sql_GetTempStr, WrokNo);
            }
            else
            {
                Sql_GetTempStr = @"Select Cast(PM.GroupNum* O.TotalNum* P.OutNum as Int) NUM FROM DISPATCHORDER D Inner join PlantBristlesMachineInfo PM On d.MachineNo = PM.MachineCode INNER JOIN DATAHISTORYMAIN O ON D.DO_No = O.DispatchOrder Inner Join PlantBristlesProdInfo P On D.ProductNo = P.PlantBristlesCode Where D.Do_No Like '{0}%'";
                Sql_GetTempStr = string.Format(Sql_GetTempStr, WrokNo);
            }
            DataTable dt = SqlHelper.ReturnTableValue(CommandType.Text, Sql_GetTempStr, null);
            int Num = 0;
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Num += Int32.Parse(dt.Rows[0][0].ToString());
                }
                Sql_GetTempStr = @"Select Sum(QueLiaoNum)+Sum(HuaHenNum)+Sum(SeChaNum)+Sum(XiaCiNum)+Sum(QueJiaoNum)+Sum(SuoShuiNum)+Sum(BianXingNum)+Sum(LiaoHuaNum)+Sum(PiFengNum)+Sum(ChicunNum)+Sum(ShaoJiaoNum)+Sum(JiaWenNum)+Sum(KaiLieNum)+Sum(QiTaNum) From QCAdjust Where DispatchNo Like '{0}%'";
                Sql_GetTempStr = string.Format(Sql_GetTempStr, WrokNo);
                object obj1 = SqlHelper.ExecuteScalar(CommandType.Text, Sql_GetTempStr, null);
                int tempQCQCAdjust = 0;
                if (obj1.ToString() != string.Empty)
                    tempQCQCAdjust = Int32.Parse(obj1.ToString());
                Sql_GetTempStr = @"Select Sum(BadQty) From QC_TableDetail Where DispatchNo Like '{0}%'";
                Sql_GetTempStr = string.Format(Sql_GetTempStr, WrokNo);
                object obj2 = SqlHelper.ExecuteScalar(CommandType.Text, Sql_GetTempStr, null);
                int tempQC_TableDetail = 0;
                if (obj2.ToString() != string.Empty)
                    tempQC_TableDetail = Int32.Parse(obj2.ToString());
                return Convert.ToString((Num - tempQCQCAdjust - tempQC_TableDetail));
            }
            else
            {
                return "0";
            }
        }
        //090720吴礼政临时插入方法(需整合至底层,祝整合愉快)
        public static string GetType(string DispatchNo)
        {
            string Sql_GetType = "Select MachineNo From DispatchOrder Where Do_No Like '{0}%'";
            Sql_GetType = string.Format(Sql_GetType, DispatchNo);
            object obj = SqlHelper.ExecuteScalar(CommandType.Text, Sql_GetType, null);
            if (obj == null)
                return string.Empty;
            else
                return obj.ToString().Substring(0, 2);
        }
    }
}
