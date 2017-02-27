using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Admin.DBUtility;
using Admin.Model.Product_MDL;
using Admin.IDAL.Product_IDAL;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class OrderMstr_DAL : IOrderMstr
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();

        const string SQL_SELECT = "SELECT ID, OrderNo, ItemNo, ItemName, Customer, OrderNum, CONVERT(CHAR(10),DeliveryDate,121) DeliveryDate, PreDate, DelayDate, OrderStatus, CompleteNum, Creater, WOFlag, CheckFlag, Checker, CONVERT(CHAR(10),CreateDate,121) CreateDate, Remark, CONVERT(CHAR(10),CheckDate,121) CheckDate FROM OrderMstr WHERE 1=1 ";
        const string SQL_SELECT_STATUS = "SELECT ID, OrderNo, ItemNo, ItemName, Customer, OrderNum, CONVERT(CHAR(10),DeliveryDate,121) DeliveryDate, PreDate, DelayDate, OrderStatus, CompleteNum, Creater, WOFlag, CheckFlag, Checker, CONVERT(CHAR(10),CreateDate,121) CreateDate, Remark, CONVERT(CHAR(10),CheckDate,121) CheckDate FROM OrderMstr WHERE 1=1 AND CheckFlag='1' AND OrderStatus<>'03' ";        
        const string SQL_INSERT = "INSERT INTO OrderMstr(OrderNo, ItemNo, ItemName, Customer, OrderNum, DeliveryDate, PreDate, DelayDate, OrderStatus, CompleteNum, Creater, WOFlag, CheckFlag, Checker, CreateDate, Remark) " +
                                  " VALUES(@OrderNo, @ItemNo, @ItemName, @Customer, @OrderNum, @DeliveryDate, @PreDate, @DelayDate, @OrderStatus, @CompleteNum, @Creater, @WOFlag, '0', '', @CreateDate, @Remark)";
        const string SQL_UPDATE = "UPDATE OrderMstr SET ItemNo=@ItemNo, ItemName=@ItemName, Customer=@Customer, OrderNum=@OrderNum, DeliveryDate=@DeliveryDate, PreDate=@PreDate, DelayDate=@DelayDate, CompleteNum=@CompleteNum, Creater=@Creater, WOFlag=@WOFlag, CreateDate=@CreateDate, Remark=@Remark WHERE ID=@ID AND CheckFlag<>'1' ";
        const string SQL_DELETE = "DELETE OrderMstr WHERE ID=@ID";
        const string SQL_CHECK_YES = "UPDATE OrderMstr SET CheckFlag='1', Checker=@Checker, CheckDate=GETDATE() WHERE ID=@ID";
        const string SQL_CHECK_NO = "UPDATE OrderMstr SET CheckFlag='2', Checker=@Checker, CheckDate=GETDATE() WHERE ID=@ID";

        const string SQL_QUERY_MonitorOdr = "SELECT ID, OrderNo, ItemNo, ItemName, Customer, OrderNum, CONVERT(CHAR(10),DeliveryDate,121) DeliveryDate, PreDate, DelayDate, OrderStatus, CompleteNum, Creater, WOFlag, CheckFlag, Checker, "+
                "CONVERT(CHAR(10),CreateDate,121) CreateDate, Remark, CONVERT(CHAR(10),CheckDate,121) CheckDate,ISNULL(SumQty,0) SumQty,ISNULL(SumNum ,0) SumNum FROM OrderMstr LEFT JOIN " +
                "(SELECT OrderID OrderNo_1,SUM(Switch2+Switch3) AS SumQty FROM CollectRealProductData GROUP BY OrderID) B ON OrderNo=OrderNo_1 "+ 
                "LEFT JOIN (SELECT OrderNo OrderNo_2,SUM(Num) SumNum FROM INStorage WHERE InType='00' GROUP BY OrderNo) C ON OrderNo=OrderNo_2 WHERE 1=1 ";
        
        const string SQL_QUERY_MonitorMtl = @"  SELECT ID, OrderNo, ItemNo, ItemName, Customer, OrderNum, 
                                                CONVERT(CHAR(10),DeliveryDate,121) DeliveryDate, PreDate, DelayDate, 
                                                OrderStatus, CompleteNum, Creater, WOFlag, CheckFlag, Checker, 
                                                CONVERT(CHAR(10),CreateDate,121) CreateDate, Remark, 
                                                CONVERT(CHAR(10),CheckDate,121) CheckDate,
                                                ISNULL(StandNum,0) StandNum,ISNULL(MtlNum,0) MtlNum,'' FlagField 
                                                FROM OrderMstr LEFT JOIN 
                                                (

                                                SELECT DISTINCT OrderNo OrderNo_1,ProdNO,
                                                'StandNum'=CAST(OrderNum*((Item_Weight+Item_WaterGapWeight)/(1-Item_LossRate)) AS DECIMAL(10,2))
                                                FROM OrderMstr LEFT JOIN ItemMstr0 ON ItemNo=Item_Code LEFT JOIN ProductMaterial ON Item_Code=ProdNO 

                                                ) B ON OrderNo=OrderNo_1 
                                                LEFT JOIN
                                                (
                                                SELECT Order_No OrderNo_2,ISNULL(SumNum,0) MtlNum FROM dbo.WorkOrder A
                                                LEFT JOIN (SELECT WorkOrder,ISNULL(SUM(Num),0) SumNum 
                                                FROM dbo.ReceiveMaterial GROUP BY WorkOrder) AS B ON A.WO_No=WorkOrder 
                                                )C
                                                ON OrderNo=OrderNo_2 

                                                WHERE 1=1 ";

        /// <summary>
        /// 用于订单监控
        /// </summary>
        /// <param name="id"></param>
        /// <param name="colname"></param>
        /// <param name="coltext"></param>
        /// <returns></returns>
        public IList<OrderMstr_MDL> queryOrderMstrToMonitorOdr(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_QUERY_MonitorOdr);
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

            IList<OrderMstr_MDL> OrderMstrList = new List<OrderMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    OrderMstr_MDL OrderMstr = new OrderMstr_MDL(sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? "" : sdr.GetString(1),
                        (sdr.IsDBNull(2)) ? "" : sdr.GetString(2),
                        (sdr.IsDBNull(3)) ? "" : sdr.GetString(3),
                        (sdr.IsDBNull(4)) ? "" : sdr.GetString(4),
                        (sdr.IsDBNull(5)) ? "" : sdr.GetInt32(5).ToString(),
                        (sdr.IsDBNull(6)) ? "" : sdr.GetString(6),
                        (sdr.IsDBNull(7)) ? "" : sdr.GetDecimal(7).ToString(),
                        (sdr.IsDBNull(8)) ? "" : sdr.GetDecimal(8).ToString(),
                        (sdr.IsDBNull(9)) ? "" : sdr.GetString(9),
                        (sdr.IsDBNull(10)) ? "" : sdr.GetInt32(10).ToString(),

                        (sdr.IsDBNull(11)) ? "" : sdr.GetString(11).ToString(),
                        (sdr.IsDBNull(12)) ? "" : (sdr.GetBoolean(12).ToString().ToUpper() == "TRUE") ? "1" : "0",
                        (sdr.IsDBNull(13)) ? "" : sdr.GetString(13).ToString(),
                        (sdr.IsDBNull(14)) ? "" : sdr.GetString(14).ToString(),
                        (sdr.IsDBNull(15)) ? "" : sdr.GetString(15),
                        (sdr.IsDBNull(16)) ? "" : sdr.GetString(16).ToString(),
                        (sdr.IsDBNull(17)) ? "" : sdr.GetString(17).ToString(),
                        (sdr.IsDBNull(18)) ? "" : sdr.GetInt32(18).ToString(),
                        (sdr.IsDBNull(19)) ? "" : sdr.GetDecimal(19).ToString()
                        );
                    OrderMstrList.Add(OrderMstr);
                }
            }
            return OrderMstrList;
        }
        
        public IList<OrderMstr_MDL> queryOrderMstrToMonitorMtl(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_QUERY_MonitorMtl);
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

            IList<OrderMstr_MDL> OrderMstrList = new List<OrderMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    OrderMstr_MDL OrderMstr = new OrderMstr_MDL(sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? "" : sdr.GetString(1),
                        (sdr.IsDBNull(2)) ? "" : sdr.GetString(2),
                        (sdr.IsDBNull(3)) ? "" : sdr.GetString(3),
                        (sdr.IsDBNull(4)) ? "" : sdr.GetString(4),
                        (sdr.IsDBNull(5)) ? "" : sdr.GetInt32(5).ToString(),
                        (sdr.IsDBNull(6)) ? "" : sdr.GetString(6),
                        (sdr.IsDBNull(7)) ? "" : sdr.GetDecimal(7).ToString(),
                        (sdr.IsDBNull(8)) ? "" : sdr.GetDecimal(8).ToString(),
                        (sdr.IsDBNull(9)) ? "" : sdr.GetString(9),
                        (sdr.IsDBNull(10)) ? "" : sdr.GetInt32(10).ToString(),

                        (sdr.IsDBNull(11)) ? "" : sdr.GetString(11).ToString(),
                        (sdr.IsDBNull(12)) ? "" : (sdr.GetBoolean(12).ToString().ToUpper() == "TRUE") ? "1" : "0",
                        (sdr.IsDBNull(13)) ? "" : sdr.GetString(13).ToString(),
                        (sdr.IsDBNull(14)) ? "" : sdr.GetString(14).ToString(),
                        (sdr.IsDBNull(15)) ? "" : sdr.GetString(15),
                        (sdr.IsDBNull(16)) ? "" : sdr.GetString(16).ToString(),
                        (sdr.IsDBNull(17)) ? "" : sdr.GetString(17).ToString(),
                        (sdr.IsDBNull(18)) ? "" : sdr.GetDecimal(18).ToString(),
                        (sdr.IsDBNull(19)) ? "" : sdr.GetDecimal(19).ToString(),
                        (sdr.IsDBNull(20)) ? "" : sdr.GetString(20)
                        );
                    OrderMstrList.Add(OrderMstr);
                }
            }
            return OrderMstrList;
        }

        public IList<OrderMstr_MDL> selectOrderMstr(int id, string colname, string coltext)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
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

            IList<OrderMstr_MDL> OrderMstrList = new List<OrderMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    OrderMstr_MDL OrderMstr = new OrderMstr_MDL(sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? "" : sdr.GetString(1),
                        (sdr.IsDBNull(2)) ? "" : sdr.GetString(2),
                        (sdr.IsDBNull(3)) ? "" : sdr.GetString(3),
                        (sdr.IsDBNull(4)) ? "" : sdr.GetString(4),
                        (sdr.IsDBNull(5)) ? "" : sdr.GetInt32(5).ToString(),
                        (sdr.IsDBNull(6)) ? "" : sdr.GetString(6),
                        (sdr.IsDBNull(7)) ? "" : sdr.GetDecimal(7).ToString(),
                        (sdr.IsDBNull(8)) ? "" : sdr.GetDecimal(8).ToString(),
                        (sdr.IsDBNull(9)) ? "" : sdr.GetString(9),
                        (sdr.IsDBNull(10)) ? "" : sdr.GetInt32(10).ToString(),

                        (sdr.IsDBNull(11)) ? "" : sdr.GetString(11).ToString(),
                        (sdr.IsDBNull(12)) ? "" : (sdr.GetBoolean(12).ToString().ToUpper() == "TRUE") ? "1" : "0" ,
                        (sdr.IsDBNull(13)) ? "" : sdr.GetString(13).ToString(),
                        (sdr.IsDBNull(14)) ? "" : sdr.GetString(14).ToString(),
                        (sdr.IsDBNull(15)) ? "" : sdr.GetString(15),
                        (sdr.IsDBNull(16)) ? "" : sdr.GetString(16).ToString(),
                        (sdr.IsDBNull(17)) ? "" : sdr.GetString(17).ToString()
                        );
                    OrderMstrList.Add(OrderMstr);
                }
            }
            return OrderMstrList;
        }

        public IList<OrderMstr_MDL> existsOrderMstr(string OrderNO)
        {
            StringBuilder sqlCmd = new StringBuilder(SQL_SELECT);
            SqlParameter[] sqlParas = { fsp.FormatInParam("@OrderNO", SqlDbType.VarChar, OrderNO) };

            sqlCmd.Append(string.Format(" AND OrderNO=@OrderNO"));
            IList<OrderMstr_MDL> OrderMstrList = new List<OrderMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    OrderMstr_MDL OrderMstr = new OrderMstr_MDL(sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? "" : sdr.GetString(1),
                        (sdr.IsDBNull(2)) ? "" : sdr.GetString(2),
                        (sdr.IsDBNull(3)) ? "" : sdr.GetString(3),
                        (sdr.IsDBNull(4)) ? "" : sdr.GetString(4),
                        (sdr.IsDBNull(5)) ? "" : sdr.GetInt32(5).ToString(),
                        (sdr.IsDBNull(6)) ? "" : sdr.GetString(6),
                        (sdr.IsDBNull(7)) ? "" : sdr.GetDecimal(7).ToString(),
                        (sdr.IsDBNull(8)) ? "" : sdr.GetDecimal(8).ToString(),
                        (sdr.IsDBNull(9)) ? "" : sdr.GetString(9),
                        (sdr.IsDBNull(10)) ? "" : sdr.GetInt32(10).ToString(),

                        (sdr.IsDBNull(11)) ? "" : sdr.GetString(11).ToString(),
                        (sdr.IsDBNull(12)) ? "" : (sdr.GetBoolean(12).ToString().ToUpper() == "TRUE") ? "1" : "0",
                        (sdr.IsDBNull(13)) ? "" : sdr.GetString(13).ToString(),
                        (sdr.IsDBNull(14)) ? "" : sdr.GetString(14).ToString(),
                        (sdr.IsDBNull(15)) ? "" : sdr.GetString(15),
                        (sdr.IsDBNull(16)) ? "" : sdr.GetString(16).ToString(),
                        (sdr.IsDBNull(17)) ? "" : sdr.GetString(17).ToString()
                       );
                    OrderMstrList.Add(OrderMstr);
                }
            }
            return OrderMstrList;
        }
        
        public IList<OrderMstr_MDL> selectOrderMstr(string OrderStatus)
        {
            IList<OrderMstr_MDL> OrderMstrList = new List<OrderMstr_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, SQL_SELECT_STATUS, null))
            {
                while (sdr.Read())
                {
                    OrderMstr_MDL OrderMstr = new OrderMstr_MDL(sdr.GetInt32(0),
                        (sdr.IsDBNull(1)) ? "" : sdr.GetString(1),
                        (sdr.IsDBNull(2)) ? "" : sdr.GetString(2),
                        (sdr.IsDBNull(3)) ? "" : sdr.GetString(3),
                        (sdr.IsDBNull(4)) ? "" : sdr.GetString(4),
                        (sdr.IsDBNull(5)) ? "" : sdr.GetInt32(5).ToString(),
                        (sdr.IsDBNull(6)) ? "" : sdr.GetString(6),
                        (sdr.IsDBNull(7)) ? "" : sdr.GetDecimal(7).ToString(),
                        (sdr.IsDBNull(8)) ? "" : sdr.GetDecimal(8).ToString(),
                        (sdr.IsDBNull(9)) ? "" : sdr.GetString(9),
                        (sdr.IsDBNull(10)) ? "" : sdr.GetInt32(10).ToString(),

                        (sdr.IsDBNull(11)) ? "" : sdr.GetString(11).ToString(),
                        (sdr.IsDBNull(12)) ? "" : (sdr.GetBoolean(12).ToString().ToUpper() == "TRUE") ? "1" : "0",
                        (sdr.IsDBNull(13)) ? "" : sdr.GetString(13).ToString(),
                        (sdr.IsDBNull(14)) ? "" : sdr.GetString(14).ToString(),
                        (sdr.IsDBNull(15)) ? "" : sdr.GetString(15),
                        (sdr.IsDBNull(16)) ? "" : sdr.GetString(16).ToString(),
                        (sdr.IsDBNull(17)) ? "" : sdr.GetString(17).ToString()
                       );
                    OrderMstrList.Add(OrderMstr);
                }
            }
            return OrderMstrList;
        }

        public void checkOrderMstr(int vID, string vChecker, string flag)
        {
            SqlParameter[] sqlParas ={ 
                fsp.FormatInParam("@Checker",SqlDbType.VarChar,vChecker),
                fsp.FormatInParam("@ID", SqlDbType.Int, vID),
            };
            string sql = (flag == "YES") ? SQL_CHECK_YES : SQL_CHECK_NO;
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, sqlParas);
        }

        public void insertOrderMstr(
               string vOrderNO, string vItemNO, string vItemName, string vCustomer, string vOrderNum,
               string vDeliveryDate, string vPreDate, string vDelayDate, string vOrderStatus, string vCompleteNum,
               string vWOFlag, string vCheckFlag, string vChecker, string vRemark, string vCreater,
               string vCreateDate)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@OrderNO",SqlDbType.VarChar,vOrderNO),
                fsp.FormatInParam("@ItemNO", SqlDbType.VarChar, vItemNO),
                fsp.FormatInParam("@ItemName", SqlDbType.VarChar, vItemName),
                fsp.FormatInParam("@Customer", SqlDbType.VarChar, vCustomer),
                fsp.FormatInParam("@OrderNum", SqlDbType.Int, vOrderNum),
                fsp.FormatInParam("@DeliveryDate", SqlDbType.DateTime, vDeliveryDate),
                fsp.FormatInParam("@PreDate", SqlDbType.Decimal, vPreDate),
                fsp.FormatInParam("@DelayDate",SqlDbType.Decimal, vDelayDate),
                fsp.FormatInParam("@OrderStatus",SqlDbType.VarChar, vOrderStatus),
                fsp.FormatInParam("@CompleteNum", SqlDbType.VarChar, vCompleteNum),

                fsp.FormatInParam("@WOFlag", SqlDbType.VarChar, vWOFlag),
                fsp.FormatInParam("@CheckFlag",SqlDbType.VarChar, vCheckFlag),
                fsp.FormatInParam("@Checker",SqlDbType.VarChar, vChecker),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, vRemark),
                fsp.FormatInParam("@Creater",SqlDbType.VarChar, vCreater),
                fsp.FormatInParam("@CreateDate", SqlDbType.DateTime, vCreateDate)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
        }

        public void updateOrderMstr(int vID,
               string vOrderNO, string vItemNO, string vItemName, string vCustomer, string vOrderNum, 
               string vDeliveryDate, string vPreDate, string vDelayDate, string vOrderStatus, string vCompleteNum,
               string vWOFlag, string vCheckFlag, string vChecker, string vRemark, string vCreater,
               string vCreateDate)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@OrderNO",SqlDbType.VarChar,vOrderNO),
                fsp.FormatInParam("@ItemNO", SqlDbType.VarChar, vItemNO),
                fsp.FormatInParam("@ItemName", SqlDbType.VarChar, vItemName),
                fsp.FormatInParam("@Customer", SqlDbType.VarChar, vCustomer),
                fsp.FormatInParam("@OrderNum", SqlDbType.Int, vOrderNum),
                fsp.FormatInParam("@DeliveryDate", SqlDbType.DateTime, vDeliveryDate),
                fsp.FormatInParam("@PreDate", SqlDbType.Decimal, vPreDate),
                fsp.FormatInParam("@DelayDate",SqlDbType.Decimal, vDelayDate),
                fsp.FormatInParam("@OrderStatus",SqlDbType.VarChar, vOrderStatus),
                fsp.FormatInParam("@CompleteNum", SqlDbType.VarChar, vCompleteNum),

                fsp.FormatInParam("@WOFlag", SqlDbType.VarChar, vWOFlag),
                fsp.FormatInParam("@CheckFlag",SqlDbType.VarChar, vCheckFlag),
                fsp.FormatInParam("@Checker",SqlDbType.VarChar, vChecker),
                fsp.FormatInParam("@Remark",SqlDbType.VarChar, vRemark),
                fsp.FormatInParam("@Creater",SqlDbType.VarChar, vCreater),
                fsp.FormatInParam("@CreateDate", SqlDbType.DateTime, vCreateDate),
                fsp.FormatInParam("@ID",SqlDbType.Int, vID)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
        }

        public void deleteOrderMstr(int ID)
        {
            SqlParameter[] sqlParas ={ fsp.FormatInParam("@ID", SqlDbType.Int, ID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE, sqlParas);
        }

        public void cancelOrderMstr(ArrayList IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in IDList)
                ExecBatch += string.Format("DELETE OrderMstr WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
    }
}
