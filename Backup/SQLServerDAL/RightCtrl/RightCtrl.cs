using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.RightCtrl
{
    public class RightCtrl
    {
        private const string SQL_SELECT_USER =
            "SELECT DISTINCT QuyFlag, AddFlag, MdyFlag, CnlFlag, PrtFlag, ChkFlag,ChkFlagNO FROM UserProgramMap WHERE 1=1 ";

        private const string SQL_SELECT_GROUP =
            "SELECT DISTINCT QuyFlag, AddFlag, MdyFlag, CnlFlag, PrtFlag, ChkFlag, ChkFlagNO FROM GroupProgramMap a LEFT JOIN SysUserInfo b ON a.GroupID=b.GroupID WHERE 1=1  ";

        public static bool[] PageRightCtrl(string userid, string programe)
        {

            //*****************************************************
            //o[0]--浏览,查询
            //o[1]--新增,添加
            //o[2]--修改
            //o[3]--删除
            //o[4]--打印,列印
            //o[5]--审核
            //*****************************************************

            bool[] o = new bool[7] { false, false, false, false, false, false ,false};
            try
            {
                FormatSqlParas fsp = new FormatSqlParas();
                StringBuilder strBuilder = new StringBuilder(SQL_SELECT_USER);

                SqlParameter[] sqlParas = {                
                fsp.FormatInParam("@userid", SqlDbType.VarChar, userid),
                fsp.FormatInParam("@programe", SqlDbType.VarChar, programe) };
                

                strBuilder.Append(" AND UserID=@userid AND ProgramID=@programe");

                using (SqlDataReader SglOfDr = SqlHelper.ExecuteReader(CommandType.Text, strBuilder.ToString(), sqlParas))
                {
                    if (SglOfDr.Read())
                    {
                        o[0] = (SglOfDr.GetString(0) == "1") ? false : true;
                        o[1] = (SglOfDr.GetString(1) == "1") ? false : true;
                        o[2] = (SglOfDr.GetString(2) == "1") ? false : true;
                        o[3] = (SglOfDr.GetString(3) == "1") ? false : true;
                        o[4] = (SglOfDr.GetString(4) == "1") ? false : true;
                        o[5] = (SglOfDr.GetString(5) == "1") ? false : true;
                        o[6] = (SglOfDr.GetString(6) == "1") ? false : true;
                    }
                    else
                    {
                        strBuilder = new StringBuilder(SQL_SELECT_GROUP);
                        strBuilder.Append(" AND UserID=@userid AND ProgramID=@programe");
                        using (SqlDataReader GrpOfDr = SqlHelper.ExecuteReader(CommandType.Text, strBuilder.ToString(), sqlParas))
                        {
                            while (GrpOfDr.Read())
                            {
                                o[0] = (GrpOfDr.GetString(0) == "1") ? false : true;
                                o[1] = (GrpOfDr.GetString(1) == "1") ? false : true;
                                o[2] = (GrpOfDr.GetString(2) == "1") ? false : true;
                                o[3] = (GrpOfDr.GetString(3) == "1") ? false : true;
                                o[4] = (GrpOfDr.GetString(4) == "1") ? false : true;
                                o[5] = (GrpOfDr.GetString(5) == "1") ? false : true;
                                o[6] = (GrpOfDr.GetString(6) == "1") ? false : true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return o;
        }

    }
}
