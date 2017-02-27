using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using Admin.IDAL.Monitor_IDAL;
using Admin.Model.Monitor_MDL;

namespace Admin.SQLServerDAL.Monitor_DAL
{
    public class MonitorMaterial_DAL : IMonitorMaterial
    {
        Common cmm = new Common();
        FormatSqlParas fsp = new FormatSqlParas();

        string sql = @"select cast(sum(TotalWeight) as numeric(20,2)) as TotalWeight,cast(sum(WaterGapScale) as numeric(20,2)) as WaterGapScale ,sum(ProductNum) as ProductNum,RawNo,RawName,RawBrand,RawModel,RawColor 
                       from(select (COUNT(1)*Item_Weight*Percentage)/100 TotalWeight,(COUNT(1)*Item_Weight*Percentage)/100*Item_WaterGapScale as WaterGapScale ,COUNT(1) as ProductNum ,
                       RawNo,RawName,RawBrand,RawModel,RawColor
                       from DataHistory dh 
                       join DispatchOrder do on dh.DispatchOrder=do.DO_No 
                       join ItemMstr im on do.ProductNo=im.Item_Code 
                       join ItemMstrDetail imd on do.ProductNo=imd.Item_Code
                       join RawMaterial rm on imd.MaterialCode=rm.RawNo
                       where 1=1";
                    
        string ss = @"  group by Item_Weight ,ProductNo,Item_Weight,RawNo,RawName,RawBrand,RawModel,RawColor,Percentage,Item_WaterGapScale
                       ) as A
                       group by RawNo,RawNo,RawName,RawBrand,RawModel,RawColor";
        public IList<MonitorMaterial_MDL> selectMonitorMaterial(string colname, string coltext)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@strwhere", SqlDbType.VarChar, colname), fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, coltext) };

            IList<MonitorMaterial_MDL> MonitorMateriallist = new List<MonitorMaterial_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Monitor_Material", sqlParas))
            {
                while (sdr.Read())
                {
                    MonitorMaterial_MDL MonitorMaterial = new MonitorMaterial_MDL(
                        (sdr["DispatchNo"] == DBNull.Value) ? "" : sdr["DispatchNo"].ToString().Trim(),//派工单号
                        (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),   //生产编号
                        (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),    //模具
                        (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),  //机器编号
                        (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),  //产品编号
                        (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),  //产品描述
                        (sdr["MaterialCode"] == DBNull.Value) ? "" : sdr["MaterialCode"].ToString().Trim(),//物料编号
                        (sdr["TOTALWEIGHT"] == DBNull.Value) ? "0" : sdr["TOTALWEIGHT"].ToString().Trim(),     //总重量
                        (sdr["TOTALGRASSWEIGHT"] == DBNull.Value) ? "0" : sdr["TOTALGRASSWEIGHT"].ToString().Trim(), //水口重量
                        (sdr["ProductNum"] == DBNull.Value) ? "0" : sdr["ProductNum"].ToString().Trim()    //生产数量 
                       );
                    MonitorMateriallist.Add(MonitorMaterial);
                }
            }
            return MonitorMateriallist;
        }
        public IList<MonitorMaterial_MDL> selectMonitorMaterial(string colname, string coltext,string DispatchStatus, int PageSize, int PageIndex, out int RowCount)
        {
            //@tblName varchar(255), -- 表名
            //@strGetFields varchar(8000)= '*', -- 需要返回的列 
            //@fldName varchar(255)='', -- 排序的字段名
            //@PageSize int = 10, -- 页尺寸
            //@PageIndex int = 1, -- 页码
            //@doCount bit = 0, -- 返回记录总数, 非 0 值则返回
            //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
            //@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where)

            SqlParameter[] sqlParas = { fsp.FormatInParam("@strwhere", SqlDbType.VarChar, colname),
                                        fsp.FormatInParam("@DispatchOrder", SqlDbType.VarChar, coltext),
                                        fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, DispatchStatus),
                                        fsp.FormatInParam("@PageSize", SqlDbType.Int, PageSize),
                                        fsp.FormatInParam("@PageIndex", SqlDbType.Int, PageIndex)};

            IList<MonitorMaterial_MDL> MonitorMateriallist = new List<MonitorMaterial_MDL>();
            DataSet sds = SqlHelper.ReturnDataSet(CommandType.StoredProcedure, "Monitor_Material", sqlParas);
            DataTable sdt = sds.Tables[0];

            if (PageIndex == 1)
            {
                RowCount = int.Parse(sds.Tables[1].Rows[0][0].ToString());
            }
            else
            {
                RowCount = 0;
            }
            if(sds.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < sds.Tables[0].Rows.Count;i++ )
                {
                    MonitorMaterial_MDL MonitorMaterial = new MonitorMaterial_MDL(
                        (sds.Tables[0].Rows[i]["DispatchNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["DispatchNo"].ToString().Trim(),//派工单号
                        (sds.Tables[0].Rows[i]["WorkOrderNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["WorkOrderNo"].ToString().Trim(),   //生产编号
                        (sds.Tables[0].Rows[i]["MouldNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["MouldNo"].ToString().Trim(),    //模具
                        (sds.Tables[0].Rows[i]["MachineNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["MachineNo"].ToString().Trim(),  //机器编号
                        (sds.Tables[0].Rows[i]["ProductNo"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["ProductNo"].ToString().Trim(),  //产品编号
                        (sds.Tables[0].Rows[i]["ProductDesc"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["ProductDesc"].ToString().Trim(),  //产品描述
                        (sds.Tables[0].Rows[i]["MaterialCode"] == DBNull.Value) ? "" : sds.Tables[0].Rows[i]["MaterialCode"].ToString().Trim(),//物料编号
                        (sds.Tables[0].Rows[i]["TOTALWEIGHT"] == DBNull.Value) ? "0" : sds.Tables[0].Rows[i]["TOTALWEIGHT"].ToString().Trim(),     //总重量
                        (sds.Tables[0].Rows[i]["TOTALGRASSWEIGHT"] == DBNull.Value) ? "0" : sds.Tables[0].Rows[i]["TOTALGRASSWEIGHT"].ToString().Trim(), //水口重量
                        (sds.Tables[0].Rows[i]["ProductNum"] == DBNull.Value) ? "0" : sds.Tables[0].Rows[i]["ProductNum"].ToString().Trim()    //生产数量 
                       );
                    MonitorMateriallist.Add(MonitorMaterial);
                }
        }
            return MonitorMateriallist;
        }

        public DataTable selectMaterial(string colname,string coltext,string beginCycle,string endCycle)
        {
            StringBuilder sqlCmd = new StringBuilder(sql);
            if (colname != "" && coltext != "")
            {
                sqlCmd.Append(string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
            }

            if (beginCycle!="" && endCycle!="")
            {
                sqlCmd.Append(" AND BeginCycle>'"+beginCycle+"' AND EndCycle<'"+endCycle+"'");
            }
            if (beginCycle!="" && endCycle=="")
            {
                sqlCmd.Append(" AND BeginCycle>'" + beginCycle+"'");
            }
            if (beginCycle=="" && endCycle!="")
            {
                sqlCmd.Append(" AND EndCycle<'" + endCycle+"'");
            }
            sqlCmd.Append("  group by Item_Weight ,ProductNo,Item_Weight,RawNo,RawName,RawBrand,RawModel,RawColor,Percentage,Item_WaterGapScale) as A  Group by RawNo,RawNo,RawName,RawBrand,RawModel,RawColor");

            DataTable dt = SqlHelper.ReturnTable(sqlCmd.ToString());

            return dt;
        }

    }
}
