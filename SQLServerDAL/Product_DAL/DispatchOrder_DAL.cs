using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.DBUtility;
using Admin.IDAL.Product_IDAL;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class DispatchOrder_DAL : IDispatchOrder
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();

        const string SQL_SELECT = @"SELECT DISTINCT ID, DO_No, WorkOrderNo, MachineNo, MouldNo, ProductNo,ProductDesc ,
                                    CONVERT(CHAR(16), StartDate,121) StartDate,  CONVERT(CHAR(16),  StopDate,121) StopDate, ActualStartDate,  ActualStopDate, BadQty, 
                                    CONVERT(CHAR(19),DispatchDate,121) DispatchDate, DispatchNum, CheckStatus,
                                    DispatchStatus, Remark,StandCycle,MaxInjectionCycle,MinInjectionCycle,UpdateCycleStatus,Creater FROM DispatchOrder WHERE 1=1 ";
        const string SQL_SELECT3 = @"SELECT DISTINCT top 15 ID, DO_No, WorkOrderNo, MachineNo, MouldNo, ProductNo,ProductDesc ,
                                    CONVERT(CHAR(16), StartDate,121) StartDate,  CONVERT(CHAR(16),  StopDate,121) StopDate, ActualStartDate,  ActualStopDate, BadQty, 
                                    CONVERT(CHAR(19),DispatchDate,121) DispatchDate, DispatchNum, CheckStatus,
                                    DispatchStatus, Remark,StandCycle,MaxInjectionCycle,MinInjectionCycle,UpdateCycleStatus,Creater FROM DispatchOrder WHERE 1=1 ";
        const string SQL_SELECT2 = "select distinct workorderno from dispatchorder where 1=1 ";
        const string SQL_INSERT = @"INSERT INTO DispatchOrder(DO_No, WorkOrderNo, MachineNo, MouldNo, ProductNo,ProductDesc, StartDate, StopDate, ActualStartDate,  ActualStopDate, BadQty, DispatchDate, DispatchNum,CheckStatus, DispatchStatus, Remark,StandCycle,MaxInjectionCycle,MinInjectionCycle,UpdateCycleStatus,Creater) 
                                   VALUES(@DO_No, @WorkOrderNo, @MachineNo, @MouldNo, @ProductNo,@ProductDesc, @StartDate, @StopDate, @ActualStartDate,  @ActualStopDate, @BadQty, getdate(), @DispatchNum, @CheckStatus,@DispatchStatus, @Remark,@StandCycle,@MaxInjectionCycle,@MinInjectionCycle,@UpdateCycleStatus ,@Creater);SELECT   @a=@@IDENTITY;";
        const string SQL_UPDATE = @"UPDATE  DispatchOrder SET DO_No=@DO_No, WorkOrderNo=@WorkOrderNo, MachineNo=@MachineNo, MouldNo=@MouldNo, ProductNo=@ProductNo,ProductDesc=@ProductDesc, StartDate=@StartDate, StopDate=@StopDate, ActualStartDate=@ActualStartDate,  ActualStopDate=@ActualStopDate, BadQty=@BadQty, 
                                   DispatchNum=@DispatchNum,CheckStatus=@CheckStatus, DispatchStatus=@DispatchStatus, Remark=@Remark,StandCycle=@StandCycle,MaxInjectionCycle=@MaxInjectionCycle,MinInjectionCycle=@MinInjectionCycle WHERE ID=@ID ";

        public IList<DispatchOrder_MDL> selectDispatchOrder(string status)
        {
            StringBuilder sqlWhere = new StringBuilder("SELECT DISTINCT DO_No,StartDate FROM DispatchOrder WHERE 1=1 ");
            SqlParameter[] sqlParas = new SqlParameter[] { fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, status) };

            if (status != "")
            {
                if (status == "0")//0 表示 未审核的
                    sqlWhere.Append(string.Format("AND CheckStatus='0' "));
                else if (status == "1")//1 表示 已经审核的
                    sqlWhere.Append(string.Format("AND CheckStatus='1' "));
                //else if (status == "2")//2 表示 在生产或者已经完成生产的
                //    sqlWhere.Append(string.Format(" AND DispatchStatus='2' "));
                else if (status == "-0")
                    sqlWhere.Append(string.Format("AND DispatchStatus<>'0' "));
                else if (status == "-12")
                    sqlWhere.Append(string.Format("AND DispatchStatus<>'1' AND WO_ApproveFlag<>'2' "));
                //else if (status == "-12")
                //    sqlWhere.Append(string.Format("AND DispatchStatus<>'1' AND WO_ApproveFlag<>'2' "));
                else
                    sqlWhere.Append(string.Format("AND CheckStatus=@DispatchStatus "));
            }

            IList<DispatchOrder_MDL> DispatchOrderList = new List<DispatchOrder_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlWhere.Append(" ORDER BY StartDate desc ").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    DispatchOrder_MDL DispatchOrder = new DispatchOrder_MDL((sdr["DO_No"] == DBNull.Value) ? "" : sdr["DO_No"].ToString().Trim());
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;

        }
       
        public IList<DispatchOrder_MDL> selectDispatchOrder(string CheckStatus, string DispatchStatus)
        {
            StringBuilder sqlWhere = new StringBuilder("SELECT DISTINCT DO_No, StartDate FROM DispatchOrder WHERE 1=1 ");
            SqlParameter[] sqlParas = new SqlParameter[] { fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, DispatchStatus) ,
                                                        fsp.FormatInParam("@CheckStatus", SqlDbType.VarChar, CheckStatus)};

            if (CheckStatus != "")
            {
                if (CheckStatus == "0")//0 表示 未审核的
                    sqlWhere.Append(string.Format("AND CheckStatus <>'0' "));
                else if (CheckStatus == "1")//1 表示 已经审核的
                    sqlWhere.Append(string.Format("AND CheckStatus <>'1' "));
                //else if (status == "2")//2 表示 在生产或者已经完成生产的
                //   sqlWhere.Append(string.Format(" AND DispatchStatus<>'2' "));
                //else if (status == "-01")
                //    sqlWhere.Append(string.Format("AND DispatchStatus<>'0' AND WO_ApproveFlag<>'1' "));
                //else if (status == "-02")
                //    sqlWhere.Append(string.Format("AND DispatchStatus<>'0' AND WO_ApproveFlag<>'2' "));
                //else if (status == "-12")
                //    sqlWhere.Append(string.Format("AND DispatchStatus<>'1' AND WO_ApproveFlag<>'2' "));
                else
                    sqlWhere.Append(string.Format("AND DispatchStatus=@DispatchStatus and CheckStatus=@CheckStatus"));
            }
            if (DispatchStatus != "")
            {
                if (DispatchStatus == "0")//0 表示 未审核的
                    sqlWhere.Append(string.Format(" AND DispatchStatus <>'0' "));
                else if (DispatchStatus == "1")//1 表示 已经审核的
                    sqlWhere.Append(string.Format(" AND DispatchStatus <> '1' "));
                else if (DispatchStatus == "2")//2 表示 在生产或者已经完成生产的
                    sqlWhere.Append(string.Format(" AND DispatchStatus <>'2' "));
                else
                    sqlWhere.Append(string.Format("AND DispatchStatus=@DispatchStatus and CheckStatus=@CheckStatus"));
            }

            IList<DispatchOrder_MDL> DispatchOrderList = new List<DispatchOrder_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlWhere.Append(" ORDER BY StartDate desc ").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    DispatchOrder_MDL DispatchOrder = new DispatchOrder_MDL((sdr["DO_No"] == DBNull.Value) ? "" : sdr["DO_No"].ToString().Trim());
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;

        }

        public IList<DispatchOrder_MDL> selectDispatchOrder(string MachineNo, int isBoo)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, MachineNo),
               fsp.FormatInParam("@isBoo", SqlDbType.Int, isBoo)
           };

            if (MachineNo != "")
            {
                sqlWhere.Append(string.Format("AND MachineNo=@MachineNo "));
            }
            if (isBoo.ToString() != "")
            {
                sqlWhere.Append(string.Format("AND DispatchStatus=@isBoo "));
            }

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }
        
        public IList<DispatchOrder_MDL> selectDispatchOrder(int id, string status, string colname, string coltext, string indexs)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id),
               fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, status)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (status != "")
                sqlWhere.Append(string.Format("AND CheckStatus=@DispatchStatus "));
            if (colname != "" && coltext != "")
            {
                if (colname != "DispatchDate")
                    sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                else
                    sqlWhere.Append(string.Format("AND CONVERT(CHAR(10), {0},121) = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
            }
            if (indexs != "")
            {
                sqlWhere.Append(string.Format(" AND substring(DO_No,len(DO_No)-2,1) ='" + indexs + "'"));
            }
            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }

        public IList<DispatchOrder_MDL> selectDispatchOrder(int id, string status, string colname, string coltext, string Machine_Code, string indexs)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id),
               fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, status)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (status != "")
                sqlWhere.Append(string.Format("AND CheckStatus=@DispatchStatus "));
            if (colname != "" && coltext != "")
            {
                if (colname != "DispatchDate")
                    sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                else
                    sqlWhere.Append(string.Format("AND CONVERT(CHAR(10), {0},121) = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
            }
            if (indexs != "")
            {
                sqlWhere.Append(string.Format(" AND substring(DO_No,len(DO_No)-2,1) ='" + indexs + "'"));
            }
            if (Machine_Code != "")
            {
                sqlWhere.Append(string.Format("AND machineno LIKE '" + cmm.GetSafeSqlText(true, Machine_Code) + "%'"));
            }

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }


        public DataSet selectDispatchOrderDateSet(int id, string status, string colname, string coltext, string Machine_Code, string indexs)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id),
               fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, status)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (status != "")
                sqlWhere.Append(string.Format("AND CheckStatus=@DispatchStatus "));
            if (colname != "" && coltext != "")
            {
                if (colname != "DispatchDate")
                    sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                else
                    sqlWhere.Append(string.Format("AND CONVERT(CHAR(10), {0},121) = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
            }
            if (indexs != "")
            {
                sqlWhere.Append(string.Format(" AND substring(DO_No,len(DO_No)-2,1) ='" + indexs + "'"));
            }
            if (Machine_Code != "")
            {
                sqlWhere.Append(string.Format("AND machineno LIKE '" + cmm.GetSafeSqlText(true, Machine_Code) + "%'"));
            }

            return getDataSet(sqlWhere, sqlParas);
        }


        private DataSet getDataSet(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT, sqlWhere));

            IList<DispatchOrder_MDL> DispatchOrderList = new List<DispatchOrder_MDL>();
            return SqlHelper.ReturnDataSet(CommandType.Text, sqlCmd.Append(" ORDER BY StartDate desc").ToString(), sqlParas);
        }

        public IList<DispatchOrder_MDL> selectDispatchOrder(int id, string status, string colname, string coltext )
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id),
               fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, status)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (status != "")
            {
                if (status == "0")//0 表示 未审核的
                    sqlWhere.Append(string.Format("AND CheckStatus='0' "));
                else if (status == "1")//1 表示 已经审核的
                    sqlWhere.Append(string.Format("AND CheckStatus='1' "));
                //else if (status == "2")//2 表示 在生产或者已经完成生产的
                //    sqlWhere.Append(string.Format(" AND DispatchStatus='2' "));
                else if (status == "-0")
                    sqlWhere.Append(string.Format("AND DispatchStatus<>'0' "));
                else if (status == "-12")
                    sqlWhere.Append(string.Format("AND DispatchStatus='2' AND CheckStatus='1' "));
                else if (status == "-01")
                    sqlWhere.Append(string.Format("AND DispatchStatus='0' AND CheckStatus='1' "));
                else if (status == "-11")
                    sqlWhere.Append(string.Format("AND DispatchStatus='1' AND CheckStatus='1' "));
                else if (status == "-00")
                    sqlWhere.Append(string.Format("AND DispatchStatus='0' AND CheckStatus='0' "));
                else
                    sqlWhere.Append(string.Format("AND CheckStatus=@DispatchStatus "));
            }
                //sqlWhere.Append(string.Format("AND CheckStatus=@DispatchStatus "));
            if (colname != "" && coltext != "")
            {
                if (colname != "StartDate")
                    sqlWhere.Append(string.Format("AND {0} LIKE '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));
                else
                    sqlWhere.Append(string.Format("AND CONVERT(CHAR(10), {0},121) = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));
            }
           

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }
        
        public IList<DispatchOrder_MDL> selectDispatchOrder(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (colname != "" && coltext != "")
                sqlWhere.Append(string.Format("AND {0} = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }
       
        public IList<DispatchOrder_MDL> selectDispatchOrderDetail(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (colname != "" && coltext != "")
                sqlWhere.Append(string.Format("AND {0} = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }

        public IList<DispatchOrder_MDL> existsDispatchOrder(string DO_No)
        {
            StringBuilder sqlWhere = new StringBuilder(" AND DO_No=@DO_No");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_No", SqlDbType.VarChar, DO_No) };

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }
        
        public IList<DispatchOrder_MDL> existsDispatchOrder(string DO_No, string colname)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format(" and {0} =@DO_No", colname));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_No", SqlDbType.VarChar, DO_No) };

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }
       
        private IList<DispatchOrder_MDL> getDataListOfDispatchOrder(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT, sqlWhere));

            IList<DispatchOrder_MDL> DispatchOrderList = new List<DispatchOrder_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY DispatchDate desc").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    DispatchOrder_MDL DispatchOrder = new DispatchOrder_MDL(sdr.GetInt32(0),
                         (sdr["DO_No"] == DBNull.Value) ? "" : sdr["DO_No"].ToString().Trim(),
                         (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                         (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                         (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                         (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),


                         (sdr["StartDate"] == DBNull.Value) ? "" : sdr["StartDate"].ToString(),
                         (sdr["StopDate"] == DBNull.Value) ? "" : sdr["StopDate"].ToString(),
                         (sdr["ActualStartDate"] == DBNull.Value) ? "" : sdr["ActualStartDate"].ToString(),
                         (sdr["ActualStopDate"] == DBNull.Value) ? "" : sdr["ActualStopDate"].ToString(),
                         (sdr["BadQty"] == DBNull.Value) ? "0" : sdr["BadQty"].ToString(),

                         (sdr["DispatchDate"] == DBNull.Value) ? "" : sdr["DispatchDate"].ToString(),
                         (sdr["DispatchNum"] == DBNull.Value) ? "0" : sdr["DispatchNum"].ToString(),
                         (sdr["CheckStatus"] == DBNull.Value) ? "0" : sdr["CheckStatus"].ToString(),
                         (sdr["DispatchStatus"] == DBNull.Value) ? "0" : sdr["DispatchStatus"].ToString(),
                         (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                         (sdr["StandCycle"] == DBNull.Value) ? "" : sdr["StandCycle"].ToString(),
                         (sdr["MaxInjectionCycle"] == DBNull.Value) ? "" : sdr["MaxInjectionCycle"].ToString(),
                         (sdr["MinInjectionCycle"] == DBNull.Value) ? "" : sdr["MinInjectionCycle"].ToString(), 
                         (sdr["UpdateCycleStatus"] == DBNull.Value) ? "" : sdr["UpdateCycleStatus"].ToString(),
                         //(//sdr["GroupNum"] == DBNull.Value) ? "0" : sdr["GroupNum"].ToString(),
                         (sdr["Creater"] == DBNull.Value) ? "0" : sdr["Creater"].ToString()
                       );
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;
        }

        public IList<DispatchOrder_MDL> existsDispatchOrder(string DO_No, string colname, string status)
        {
            StringBuilder sqlWhere = new StringBuilder(string.Format(" and {0} =@DO_No and DispatchStatus<>{1}", colname, status));
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_No", SqlDbType.VarChar, DO_No) };

            return getDataListOfDispatchOrderDetail(sqlWhere, sqlParas);
        }
        
        private IList<DispatchOrder_MDL> getDataListOfDispatchOrderDetail(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT3, sqlWhere));

            IList<DispatchOrder_MDL> DispatchOrderList = new List<DispatchOrder_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY StartDate DESC").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    DispatchOrder_MDL DispatchOrder = new DispatchOrder_MDL(sdr.GetInt32(0),
                         (sdr["DO_No"] == DBNull.Value) ? "" : sdr["DO_No"].ToString().Trim(),
                         (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                         (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                         (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                         (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),

                         (sdr["StartDate"] == DBNull.Value) ? "" : sdr["StartDate"].ToString(),
                         (sdr["StopDate"] == DBNull.Value) ? "" : sdr["StopDate"].ToString(),
                         (sdr["ActualStartDate"] == DBNull.Value) ? "" : sdr["ActualStartDate"].ToString(),
                         (sdr["ActualStopDate"] == DBNull.Value) ? "" : sdr["ActualStopDate"].ToString(),
                         (sdr["BadQty"] == DBNull.Value) ? "0" : sdr["BadQty"].ToString(),

                         (sdr["DispatchDate"] == DBNull.Value) ? "" : sdr["DispatchDate"].ToString(),
                         (sdr["DispatchNum"] == DBNull.Value) ? "0" : sdr["DispatchNum"].ToString(),
                         (sdr["CheckStatus"] == DBNull.Value) ? "0" : sdr["CheckStatus"].ToString(),
                         (sdr["DispatchStatus"] == DBNull.Value) ? "0" : sdr["DispatchStatus"].ToString(),
                         (sdr["Remark"] == DBNull.Value) ? "" : sdr["Remark"].ToString(),
                         (sdr["StandCycle"] == DBNull.Value) ? "" : sdr["StandCycle"].ToString(),
                         (sdr["MaxInjectionCycle"] == DBNull.Value) ? "" : sdr["MaxInjectionCycle"].ToString(),
                         (sdr["MinInjectionCycle"] == DBNull.Value) ? "" : sdr["MinInjectionCycle"].ToString(),
                         (sdr["UpdateCycleStatus"] == DBNull.Value) ? "" : sdr["UpdateCycleStatus"].ToString(),
                         //(sdr["GroupNum"] == DBNull.Value) ? "0" : sdr["GroupNum"].ToString(),
                         (sdr["Creater"] == DBNull.Value) ? "0" : sdr["Creater"].ToString()
                       );
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;
        }

        public void ChangeDispatchOrder(DispatchOrder_MDL Obj, string IU)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@DO_No", SqlDbType.VarChar, Obj.DO_No),
                fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, Obj.WorkOrderNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, Obj.MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, Obj.MouldNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, Obj.ProductNo),
                fsp.FormatInParam("@ProductDesc", SqlDbType.VarChar, Obj.ProductDesc),

                fsp.FormatInParam("@StartDate", SqlDbType.VarChar, Obj.StartDate),
                fsp.FormatInParam("@StopDate", SqlDbType.VarChar, Obj.StopDate),
                fsp.FormatInParam("@ActualStartDate", SqlDbType.VarChar, Obj.ActualStartDate),
                fsp.FormatInParam("@ActualStopDate", SqlDbType.VarChar, Obj.ActualStopDate),
                fsp.FormatInParam("@BadQty", SqlDbType.VarChar, Obj.BadQty),

                //fsp.FormatInParam("@DispatchDate", SqlDbType.VarChar, Obj.DispatchDate),
                fsp.FormatInParam("@DispatchNum", SqlDbType.VarChar, Obj.DispatchNum),
                fsp.FormatInParam("@CheckStatus", SqlDbType.VarChar, Obj.CheckStatus),
                fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, Obj.DispatchStatus),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, Obj.Remark),
                fsp.FormatInParam("@StandCycle", SqlDbType.VarChar, Obj.StandCycle),
                fsp.FormatInParam("@MaxInjectionCycle", SqlDbType.VarChar, Obj.MaxInjectionCycle),
                fsp.FormatInParam("@MinInjectionCycle", SqlDbType.VarChar, Obj.MinInjectionCycle),
                //fsp.FormatInParam("@GroupNum", SqlDbType.VarChar, Obj.GroupNum),
                fsp.FormatInParam("@ID", SqlDbType.Int, Obj.ID)
            };
            if (IU == "INSERT")
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
                SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
            Obj = null;
        }

        public void ChangeDispatchOrder(DispatchOrder_MDL Obj, string IU, out int xid)
        {
            SqlParameter[] sqlParas = {
                fsp.FormatInParam("@DO_No", SqlDbType.VarChar, Obj.DO_No),
                fsp.FormatInParam("@WorkOrderNo", SqlDbType.VarChar, Obj.WorkOrderNo),
                fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, Obj.MachineNo),
                fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, Obj.MouldNo),
                fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, Obj.ProductNo),
                fsp.FormatInParam("@ProductDesc", SqlDbType.VarChar, Obj.ProductDesc),

                fsp.FormatInParam("@StartDate", SqlDbType.VarChar, Obj.StartDate),
                fsp.FormatInParam("@StopDate", SqlDbType.VarChar, Obj.StopDate),
                fsp.FormatInParam("@ActualStartDate", SqlDbType.VarChar, Obj.ActualStartDate),
                fsp.FormatInParam("@ActualStopDate", SqlDbType.VarChar, Obj.ActualStopDate),
                fsp.FormatInParam("@BadQty", SqlDbType.VarChar, Obj.BadQty),

                //fsp.FormatInParam("@DispatchDate", SqlDbType.VarChar, Obj.DispatchDate),
                fsp.FormatInParam("@DispatchNum", SqlDbType.VarChar, Obj.DispatchNum),
                fsp.FormatInParam("@CheckStatus", SqlDbType.VarChar, Obj.CheckStatus),
                fsp.FormatInParam("@DispatchStatus", SqlDbType.VarChar, Obj.DispatchStatus),
                fsp.FormatInParam("@Remark", SqlDbType.VarChar, Obj.Remark),
                fsp.FormatInParam("@StandCycle", SqlDbType.VarChar, Obj.StandCycle),
                fsp.FormatInParam("@MaxInjectionCycle", SqlDbType.VarChar, Obj.MaxInjectionCycle),
                fsp.FormatInParam("@MinInjectionCycle", SqlDbType.VarChar, Obj.MinInjectionCycle),
                fsp.FormatInParam("@UpdateCycleStatus", SqlDbType.VarChar, Obj.UpdateCycleStatus),
                //fsp.FormatInParam("@GroupNum", SqlDbType.VarChar, Obj.GroupNum),
                fsp.FormatInParam("@Creater", SqlDbType.VarChar, Obj.Creater),
                fsp.FormatInParam("@ID", SqlDbType.Int, Obj.ID)
            };
            if (IU == "INSERT")
            {
                xid = SqlHelper.ExecuteNonQuery2(CommandType.Text, SQL_INSERT, sqlParas);
            }
            else
            {
                xid = SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
                //xid = -1;
            }
            Obj = null;
        }

        public void cancelDispatchOrder(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
            {
                ExecBatch += string.Format("DELETE DispatchOrder WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public void deleteDispatchOrder(int vID)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@ID", SqlDbType.Int, vID) };
            SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE DispatchOrder WHERE ID=@ID", sqlParas);
        }

        public void checkDispatchOrder(string strFlag, string strChecker, ArrayList _IDList)
        {
            string strStatus = strFlag;//(strFlag == "Yes") ? "2" : "0";
            string ExecBatch = "BEGIN TRANSACTION ";

            foreach (string s in _IDList)
            {
                ExecBatch += string.Format(@"UPDATE DispatchOrder SET CheckStatus='{1}',DispatchStatus='{1}',CheckDate=getdate(),CheckMan='{2}'
                            WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s, strStatus, strChecker);
                // if (strFlag == "Yes")
                //ExecBatch += string.Format("UPDATE WorkOrder SET WO_Status='4' WHERE WO_No=(SELECT WorkOrderNo FROM DispatchOrder WHERE ID={0}) IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public IList<DispatchOrder_MDL> QueryWorkOrder()
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;
            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }
       
        private IList<DispatchOrder_MDL> getDataListOfWorkOrder(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT2, sqlWhere));

            IList<DispatchOrder_MDL> DispatchOrderList = new List<DispatchOrder_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY StartDate DESC").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    DispatchOrder_MDL DispatchOrder = new DispatchOrder_MDL(0,
                         "",(sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                         "","","","","","","","","","","","","","",""
                       );
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;
        }
    }
}
