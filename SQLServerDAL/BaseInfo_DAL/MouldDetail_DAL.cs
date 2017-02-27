using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model;
using Admin.Model.Machine_MDL;
using Admin.IDAL.BaseInfo_IDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class MouldDetail_DAL : IMouldDetail
    {
        FormatSqlParas fsp = new FormatSqlParas();
        FormatSqlCmd fsc = new FormatSqlCmd();
        Common cmm = new Common();
        string TableName = "MouldDetail";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "Mould_Code","Mould_Desc","Clip_Code","Clip_Desc","Clip_UsedNum","GoodsNo","Mould_SpecialFittingsNo","Mould_Manufacturer","Mould_MadeDate","Mould_CopyRight",
            "SocketNum","GoodSocketNum","FitMachineG","PositioningHoleDiameter","RefBadRate","LostMaterialRate","InjectionCycle","MinInjectionCycle","MaxInjectionCycle",
            "MachineCycle","Mould_InjectPress","Mould_ShotTemp","Mould_Lenght","Mould_Width","Mould_Thickth","Mould_Weight","Mould_PushDistance","TemplateDistance","TackOutFunction",
            "Robort","RobortProgram","ShotLenghten","ProtectCycle","MouldStatus","WarehouseLocation","ModiRecord","LastModifier","LastModiDate","Ver","Lu_law_Table"
            ,"Remark","Mould_Soaked","Mould_Fixture"};
       // string[] FieldName3 = { "Mould_Photo", "Mould_PhotoType" };

        public IList<MouldDetail_MDL> selectMouldDetail(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                sqlParas = null;
            }
            return getMouldMstrList(sqlWhere, sqlParas);
        }

        public IList<MouldDetail_MDL> selectMouldDetail()
        {
            StringBuilder sqlCmd = new StringBuilder("SELECT DISTINCT Mould_Code FROM MouldDetail WHERE 1=1 ORDER BY 1");
            IList<MouldDetail_MDL> bole = new List<MouldDetail_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), null))
            {
                while (sdr.Read())
                {
                    MouldDetail_MDL MachineMstr = new MouldDetail_MDL((sdr["Mould_Code"] == DBNull.Value) ? null : sdr["Mould_Code"].ToString());
                    bole.Add(MachineMstr);
                }
            }
            return bole;
        }

        public IList<MouldDetail_MDL> existsMouldDetail(string vMouldNo)
        {
            StringBuilder sqlWhere = new StringBuilder(" AND Mould_Code=@MouldNo");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, vMouldNo) };

            return getMouldMstrList(sqlWhere, sqlParas);
        }

        private IList<MouldDetail_MDL> getMouldMstrList(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length ];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            //System.Array.Copy(FieldName3, 0, SELECT, FieldName1.Length + FieldName2.Length, FieldName3.Length);

            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));
            sqlCmd.Append(sqlWhere);

            IList<MouldDetail_MDL> MouldDetailList = new List<MouldDetail_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY Mould_Code").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    MouldDetail_MDL MouldDetail = new MouldDetail_MDL(
                        sdr.GetInt32(0),
                        (sdr["Mould_Code"] == DBNull.Value) ? "" : sdr["Mould_Code"].ToString(),
                        (sdr["Mould_Desc"] == DBNull.Value) ? "" : sdr["Mould_Desc"].ToString(),
                        (sdr["Clip_Code"] == DBNull.Value) ? "" : sdr["Clip_Code"].ToString(),
                        (sdr["Clip_Desc"] == DBNull.Value) ? "" : sdr["Clip_Desc"].ToString(),
                        (sdr["Clip_UsedNum"] == DBNull.Value) ? "0" : sdr["Clip_UsedNum"].ToString(),
                        (sdr["GoodsNo"] == DBNull.Value) ? "" : sdr["GoodsNo"].ToString(), 
                        (sdr["Mould_SpecialFittingsNo"] == DBNull.Value) ? "" : sdr["Mould_SpecialFittingsNo"].ToString(),
                        (sdr["Mould_Manufacturer"] == DBNull.Value) ? "" : sdr["Mould_Manufacturer"].ToString(),
                        (sdr["Mould_MadeDate"] == DBNull.Value) ? "" : sdr["Mould_MadeDate"].ToString(),
                        (sdr["Mould_CopyRight"] == DBNull.Value) ? "" : sdr["Mould_CopyRight"].ToString(),
                        (sdr["SocketNum"] == DBNull.Value) ? "0" : sdr["SocketNum"].ToString(),
                        (sdr["GoodSocketNum"] == DBNull.Value) ? "0" : sdr["GoodSocketNum"].ToString(),
                        (sdr["FitMachineG"] == DBNull.Value) ? "" : sdr["FitMachineG"].ToString(),
                        (sdr["PositioningHoleDiameter"] == DBNull.Value) ? "0" : sdr["PositioningHoleDiameter"].ToString(),
                        (sdr["RefBadRate"] == DBNull.Value) ? "0" : sdr["RefBadRate"].ToString(),
                        (sdr["LostMaterialRate"] == DBNull.Value) ? "0" : sdr["LostMaterialRate"].ToString(),
                        (sdr["InjectionCycle"] == DBNull.Value) ? "0" : sdr["InjectionCycle"].ToString(),
                        (sdr["MinInjectionCycle"] == DBNull.Value) ? "0" : sdr["MinInjectionCycle"].ToString(),
                        (sdr["MaxInjectionCycle"] == DBNull.Value) ? "0" : sdr["MaxInjectionCycle"].ToString(),
                        (sdr["MachineCycle"] == DBNull.Value) ? "0" : sdr["MachineCycle"].ToString(),
                        (sdr["Mould_InjectPress"] == DBNull.Value) ? "0" : sdr["Mould_InjectPress"].ToString(),
                        (sdr["Mould_ShotTemp"] == DBNull.Value) ? "0" : sdr["Mould_ShotTemp"].ToString(),
                        (sdr["Mould_Lenght"] == DBNull.Value) ? "0" : sdr["Mould_Lenght"].ToString(),
                        (sdr["Mould_Width"] == DBNull.Value) ? "0" : sdr["Mould_Width"].ToString(),
                        (sdr["Mould_Thickth"] == DBNull.Value) ? "0" : sdr["Mould_Thickth"].ToString(),
                        (sdr["Mould_Weight"] == DBNull.Value) ? "0" : sdr["Mould_Weight"].ToString(),
                        (sdr["Mould_PushDistance"] == DBNull.Value) ?  "0"  : sdr["Mould_PushDistance"].ToString(),
                        (sdr["TemplateDistance"] == DBNull.Value) ? "0" : sdr["TemplateDistance"].ToString(),
                        (sdr["TackOutFunction"] == DBNull.Value) ? "" : sdr["TackOutFunction"].ToString(),
                        (sdr["Robort"] == DBNull.Value) ? "" : sdr["Robort"].ToString(),
                        (sdr["RobortProgram"] == DBNull.Value) ? "" : sdr["RobortProgram"].ToString(),
                        (sdr["ShotLenghten"] == DBNull.Value) ? "" : sdr["ShotLenghten"].ToString(),
                        (sdr["ProtectCycle"] == DBNull.Value) ? "0" : sdr["ProtectCycle"].ToString(),
                        (sdr["MouldStatus"] == DBNull.Value) ? "" : sdr["MouldStatus"].ToString(),
                        (sdr["WarehouseLocation"] == DBNull.Value) ? "" : sdr["WarehouseLocation"].ToString(),
                        (sdr["ModiRecord"] == DBNull.Value) ? "" : sdr["ModiRecord"].ToString(),
                        (sdr["LastModifier"] == DBNull.Value) ? "" : sdr["LastModifier"].ToString(),
                        (sdr["LastModiDate"] == DBNull.Value) ? "" : sdr["LastModiDate"].ToString(),
                        (sdr["Ver"] == DBNull.Value) ? "" : sdr["Ver"].ToString(),
                        (sdr["Lu_law_Table"] == DBNull.Value) ? "" : sdr["Lu_law_Table"].ToString(),
                        (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                        (sdr["Mould_Soaked"] == DBNull.Value) ? "" : sdr["Mould_Soaked"].ToString(),
                        (sdr["Mould_Fixture"] == DBNull.Value) ? "" : sdr["Mould_Fixture"].ToString()
                        );
                    MouldDetailList.Add(MouldDetail);
                }
            }
            return MouldDetailList;
        }

        public void updateMouldDetail(MouldDetail_MDL obj, string IU)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@Mould_Code", SqlDbType.VarChar, obj.MouldCode),
                        fsp.FormatInParam("@Mould_Desc", SqlDbType.VarChar, obj.MouldDesc),
                        fsp.FormatInParam("@Clip_Code", SqlDbType.VarChar, obj.ClipCode),
                        fsp.FormatInParam("@Clip_Desc", SqlDbType.VarChar, obj.ClipDesc),
                        fsp.FormatInParam("@Clip_UsedNum", SqlDbType.VarChar, obj.ClipUsedNum),
                        fsp.FormatInParam("@GoodsNo", SqlDbType.VarChar, obj.GoodsNo),
                        fsp.FormatInParam("@Mould_SpecialFittingsNo", SqlDbType.VarChar, obj.MouldSpecialFittingsNo),
                        fsp.FormatInParam("@Mould_Manufacturer", SqlDbType.VarChar, obj.MouldManufacturer),
                        fsp.FormatInParam("@Mould_MadeDate", SqlDbType.VarChar, obj.MouldMadeDate),
                        fsp.FormatInParam("@Mould_CopyRight", SqlDbType.VarChar, obj.MouldCopyRight),
                        fsp.FormatInParam("@SocketNum", SqlDbType.VarChar, obj.SocketNum),
                        fsp.FormatInParam("@GoodSocketNum", SqlDbType.VarChar, obj.GoodSocketNum),
                        fsp.FormatInParam("@FitMachineG", SqlDbType.VarChar, obj.FitMachineG),
                        fsp.FormatInParam("@PositioningHoleDiameter", SqlDbType.VarChar, obj.PositioningHoleDiameter),
                        fsp.FormatInParam("@RefBadRate", SqlDbType.VarChar, obj.RefBadRate),
                        fsp.FormatInParam("@LostMaterialRate", SqlDbType.VarChar, obj.LostMaterialRate),
                        fsp.FormatInParam("@InjectionCycle", SqlDbType.VarChar, obj.InjectionCycle),
                        fsp.FormatInParam("@MinInjectionCycle", SqlDbType.VarChar, obj.MinInjectionCycle),
                        fsp.FormatInParam("@MaxInjectionCycle", SqlDbType.VarChar, obj.MaxInjectionCycle),
                        fsp.FormatInParam("@MachineCycle", SqlDbType.VarChar, obj.MachineCycle),
                        fsp.FormatInParam("@Mould_InjectPress", SqlDbType.VarChar, obj.MouldInjectPress),
                        fsp.FormatInParam("@Mould_ShotTemp", SqlDbType.VarChar, obj.Mould_ShotTemp),
                        fsp.FormatInParam("@Mould_Lenght", SqlDbType.VarChar, obj.MouldLenght),
                        fsp.FormatInParam("@Mould_Width", SqlDbType.VarChar, obj.MouldWidth),
                        fsp.FormatInParam("@Mould_Thickth", SqlDbType.VarChar, obj.MouldThickth),
                        fsp.FormatInParam("@Mould_Weight", SqlDbType.VarChar, obj.MouldWeight),
                        fsp.FormatInParam("@Mould_PushDistance", SqlDbType.VarChar, obj.MouldPushDistance),
                        fsp.FormatInParam("@TemplateDistance", SqlDbType.VarChar, obj.TemplateDistance),
                        fsp.FormatInParam("@TackOutFunction", SqlDbType.VarChar, obj.TackOutFunction),
                        fsp.FormatInParam("@Robort", SqlDbType.VarChar, obj.Robort),
                        fsp.FormatInParam("@RobortProgram", SqlDbType.VarChar, obj.RobortProgram),
                        fsp.FormatInParam("@ShotLenghten", SqlDbType.VarChar, obj.ShotLenghten),
                        fsp.FormatInParam("@ProtectCycle", SqlDbType.VarChar, obj.ProtectCycle),
                        fsp.FormatInParam("@MouldStatus", SqlDbType.VarChar, obj.MouldStatus),
                        fsp.FormatInParam("@WarehouseLocation", SqlDbType.VarChar, obj.WarehouseLocation),
                        fsp.FormatInParam("@ModiRecord", SqlDbType.VarChar, obj.ModiRecord),
                        fsp.FormatInParam("@LastModifier", SqlDbType.VarChar, obj.LastModifier),
                        fsp.FormatInParam("@LastModiDate", SqlDbType.VarChar, obj.LastModiDate),
                        fsp.FormatInParam("@Ver", SqlDbType.VarChar, obj.Ver),
                        fsp.FormatInParam("@Lu_law_Table", SqlDbType.VarChar, obj.Lu_lawTable),
                        fsp.FormatInParam("@Remark", SqlDbType.VarChar, obj.Remark),
                        fsp.FormatInParam("@Mould_Soaked", SqlDbType.VarChar, obj.Mould_Soaked),
                        fsp.FormatInParam("@Mould_Fixture", SqlDbType.VarChar, obj.Mould_Fixture),
                        fsp.FormatInParam("@ID",SqlDbType.Int, obj.ID)
            };
            //byte[] temp_Photo = obj.Mould_Photo;
            //object temp_PhotoType = obj.Mould_PhotoType;
            string[] FieldNames = null;
            //if (temp_Photo.Length == 0 || temp_PhotoType == null)
            //{
            //    FieldNames = new string[FieldName2.Length];
            //    System.Array.Copy(FieldName2, 0, FieldNames, 0, FieldName2.Length);
            //}
            //else
            //{
                FieldNames = new string[FieldName2.Length ];
                System.Array.Copy(FieldName2, 0, FieldNames, 0, FieldName2.Length);
                //System.Array.Copy(FieldName3, 0, FieldNames, FieldName2.Length, FieldName3.Length);
           // }
            try
            {
                if (IU.ToUpper() == "INSERT")
                    SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldNames), sqlParas);
                else
                    SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldNames), sqlParas);
            }
            finally
            {
                obj = null;
            }
        }

        public void deleteMouldDetail(int vID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, vID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE MouldDetail WHERE ID=@ID", sqlParas);
        }

        public void cancelMouldDetail(ArrayList vIDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in vIDList)
                ExecBatch += string.Format("DELETE MouldDetail WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
