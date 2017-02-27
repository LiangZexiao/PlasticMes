using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.Monitor_DAL
{
    public class UseMaterial_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        string strSQL_Stand = "SELECT DISTINCT WO_No,a.Item_Code,WO_Qty,CONVERT(CHAR(10),WO_ApprovedDate,121) WO_ApprovedDate,Item_Weight,"+
                "'StandNum'=CAST(WO_Qty*((Item_Weight+Item_WaterGapWeight)/(1-Item_LossRate)) AS DECIMAL(10,2)) "+
                "FROM WorkOrder a LEFT JOIN ItemMstr0 b ON a.Item_Code=b.Item_Code WHERE 1=1 ";

        string strSQL_Lived = "SELECT DISTINCT a.WO_No,a.ItemNo," +
                "CASE WHEN CONVERT(CHAR(10),UpLoadTime,121)=@BeginDate THEN SUM(Switch2+Switch3)*StandPara+ISNULL(PreNum,0) ELSE SUM(Switch2+Switch3)*StandPara End AS LivedNum," +
                "CONVERT(CHAR(10),UpLoadTime,121) UpLoadTime " +
                "FROM CollectRealProductData_2 a LEFT JOIN ("+
                "SELECT DISTINCT Item_Code,ISNULL(((Item_Weight+Item_WaterGapWeight) * 1)/(1-Item_LossRate),0) StandPara FROM ItemMstr0) c ON a.ItemNo=Item_Code "+
                "LEFT JOIN (SELECT WO_No,ItemNo,'PreNum'=SUM(Switch2+Switch3)*StandPara FROM CollectRealProductData_2 "+
                "LEFT JOIN (SELECT DISTINCT Item_Code,ISNULL(((Item_Weight+Item_WaterGapWeight ) * 1)/(1-Item_LossRate),0) StandPara FROM ItemMstr0 c) E ON ItemNo=Item_Code "+
                "WHERE WO_No=@WorkOrderNo AND CONVERT(CHAR(10),UpLoadTime,121)<@BeginDate GROUP BY WO_No,ItemNo,StandPara " +
                ") d ON a.WO_No=d.WO_No and a.ItemNo=d.ItemNo and c.Item_Code=d.ItemNo WHERE 1=1 ";

        //string strSQL_Stand2 = "SELECT DISTINCT OrderNo,ProdNO,OrderNum,CONVERT(CHAR(10),DeliveryDate,121) DeliveryDate," +
        //         "'StandNum'=CAST(OrderNum*((Item_Weight+Item_WaterGapWeight)/(1-Item_LossRate)) AS DECIMAL(10,2))" +
        //         "FROM OrderMstr LEFT JOIN ItemMstr0 ON ItemNo=Item_Code LEFT JOIN ProductMaterial ON Item_Code=ProdNO WHERE 1=1 ";

        string strSQL_Lived2 = @"SELECT MachineNo, MouldNo, WorkOrderNo, ProductNo, 
                                ISNULL(GoalNum,0) GoalNum, ISNULL(CompleteNum,0) CompleteNum, 
                                ISNULL(StandNum,0) StandNum, ISNULL(ReceiveNum,0) ReceiveNum, 
                                ISNULL(ProductNum,0) ProductNum, ISNULL(WaterGapNum,0) WaterGapNum,
                                ISNULL(ResidualNum,0) ResidualNum, ISNULL(WasteNum,0) WasteNum, 
                                CASE WHEN ISNULL(ResidualTime,0)<=0 THEN '0' ELSE ISNULL(ResidualTime,0) END AS ResidualTime
                                FROM View_MonitorMaterial WHERE 1=1 ";

        public DataTable select_Stand_NUM(string WorkOrderNo)
        {
            if (!string.IsNullOrEmpty(WorkOrderNo)) strSQL_Stand += " AND WO_No=@WorkOrderNo";
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, WorkOrderNo) };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL_Stand, sqlParas);
        }

        public DataTable select_Lived_NUM(string WorkOrderNo, string ItemNo, string BeginDate, string EndDate)
        {
            if (!string.IsNullOrEmpty(WorkOrderNo)) strSQL_Lived += " AND a.WO_No=@WorkOrderNo";
            if (!string.IsNullOrEmpty(ItemNo)) strSQL_Lived += " AND a.ItemNo=@ItemNo";

            if ((BeginDate != "") && (EndDate == "")) strSQL_Lived += " AND CONVERT(CHAR(10),UpLoadTime,121)>=CONVERT(CHAR(10),@BeginDate,121)";
            else if ((BeginDate == "") && (EndDate != "")) strSQL_Lived += " AND CONVERT(CHAR(10),UpLoadTime,121)<=CONVERT(CHAR(10),@EndDate,121)";
            else if ((BeginDate != "") && (EndDate != "")) strSQL_Lived += " AND CONVERT(CHAR(10),UpLoadTime,121)>=CONVERT(CHAR(10),@BeginDate,121) AND CONVERT(CHAR(10),UpLoadTime,121)<=CONVERT(CHAR(10),@EndDate,121)";
            strSQL_Lived += " GROUP BY a.WO_No,a.ItemNo,StandPara,CONVERT(CHAR(10),UpLoadTime,121),ISNULL(PreNum,0)";
            strSQL_Lived += " ORDER BY UpLoadTime";

            SqlParameter[] sqlParas = {
                    fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, WorkOrderNo),
                    fsp.FormatInParam("@ItemNo", SqlDbType.VarChar, ItemNo),
                    fsp.FormatInParam("@BeginDate", SqlDbType.VarChar, BeginDate),
                    fsp.FormatInParam("@EndDate", SqlDbType.VarChar, EndDate)
                };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL_Lived, sqlParas);
        }

        public DataTable selectMonitorMaterialNum(string MachineNo, string MouldNo, string WorkOrderNo, string ProductNo, string BeginDate, string EndDate, string colname, string coltext)
        {
            if (!string.IsNullOrEmpty(MachineNo)) strSQL_Lived2 += " AND MachineNo=@MachineNo";
            if (!string.IsNullOrEmpty(MouldNo)) strSQL_Lived2 += " AND MouldNo=@MouldNo";
            if (!string.IsNullOrEmpty(WorkOrderNo)) strSQL_Lived2 += " AND WorkOrderNo=@WorkOrderNo";
            if (!string.IsNullOrEmpty(ProductNo)) strSQL_Lived2 += " AND ProductNo=@ProductNo";

            if ((BeginDate != "") && (EndDate == "")) strSQL_Lived2 += " AND CONVERT(CHAR(10),UpLoadTime,121)>=CONVERT(CHAR(10),@BeginDate,121)";
            else if ((BeginDate == "") && (EndDate != "")) strSQL_Lived2 += " AND CONVERT(CHAR(10),UpLoadTime,121)<=CONVERT(CHAR(10),@EndDate,121)";
            else if ((BeginDate != "") && (EndDate != "")) strSQL_Lived2 += " AND CONVERT(CHAR(10),UpLoadTime,121)>=CONVERT(CHAR(10),@BeginDate,121) AND CONVERT(CHAR(10),UpLoadTime,121)<=CONVERT(CHAR(10),@EndDate,121)";

            if (colname != string.Empty && coltext != string.Empty)
            {
                Common cmm = new Common();
                strSQL_Lived2 += string.Format(" AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname);
            }
            strSQL_Lived2 += " ORDER BY ResidualTime desc";

            SqlParameter[] sqlParas = {
                    fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
                    fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, MouldNo),
                    fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, WorkOrderNo),
                    fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, ProductNo),
                    fsp.FormatInParam("@BeginDate", SqlDbType.VarChar, BeginDate),
                    fsp.FormatInParam("@EndDate", SqlDbType.VarChar, EndDate)
                };
            return SqlHelper.ReturnTableValue(CommandType.Text, strSQL_Lived2, sqlParas);
        }
    }
}
