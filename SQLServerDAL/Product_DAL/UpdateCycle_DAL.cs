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
    public class UpdateCycle_DAL
    {
        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();

        const string SQL_SELECT = @"select do.id,do.do_no,do.productno,do.productdesc,do.workorderno,do.machineno,do.mouldno,uc.standcycle,do.MaxInjectionCycle,do.MinInjectionCycle,uc.updatestandcycle, uc.updateemployee, uc.updatetime from dispatchorder  do inner join updatecycle uc on do.do_no=uc.Do_no where 1=1   ";//and substring(do.do_no,len(do.do_no)-2,1)='0'
        const string SQL_SELECT2 = @"select ID,DO_NO,StandCycle,MaxInjectionCycle,MinInjectionCycle,UpdateStandCycle,UpdateMaxInjectionCycle,UpdateMinInjectionCycle,convert(char(10),UpdateTime,121) UpdateTime,convert(char(10),CreateTime,121) CreateTime, UpdateEmployee from updatecycle where 1=1";
        const string SQL_INSERT = @"INSERT INTO updatecycle(DO_NO, ProductNo, ProductDesc, MachineNo, MouldNo, StandCycle,MaxInjectionCycle,MinInjectionCycle,UpdateStandCycle,UpdateMaxInjectionCycle,UpdateMinInjectionCycle, UpdateTime, CreateTime,UpdateEmployee ) 
                                   VALUES(@DO_NO,@ProductNo, @ProductDesc, @MachineNo, @MouldNo, @StandCycle,@MaxInjectionCycle,@MinInjectionCycle,@UpdateStandCycle,@UpdateMaxInjectionCycle,@UpdateMinInjectionCycle, @UpdateTime, @CreateTime,@UpdateEmployee )";
        const string SQL_UPDATE = @"UPDATE updatecycle SET DO_NO=@DO_NO, ProductNo=@ProductNo, ProductDesc=@ProductDesc, MachineNo=@ProductDesc, MouldNo=@ProductDesc, UpdateStandCycle=@UpdateStandCycle,UpdateMaxInjectionCycle=@UpdateMaxInjectionCycle,UpdateMinInjectionCycle=@UpdateMinInjectionCycle, UpdateTime=@UpdateTime, UpdateEmployee=@UpdateEmployee  WHERE ProductNo=@ProductNo ";
        const string SQL_UPDATE2 = @"UPDATE dispatchorder SET standcycle=@StandCycle,MaxInjectionCycle=@MaxInjectionCycle,MinInjectionCycle=@MinInjectionCycle ,UpdateCycleStatus=0 WHERE ProductNo=@ProductNo ";

        
        public IList<UpdateCycle_MDL> selectDispatchOrder(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND do.ID=@ID "));
            if (colname != "" && coltext != "")
                sqlWhere.Append(string.Format("AND {0} like '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }

        public IList<UpdateCycle_MDL> selectDispatchOrder(string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (colname != "" && coltext != "")
                sqlWhere.Append(string.Format("AND {0} = '" + cmm.GetSafeSqlText(true, coltext) + "'", colname));

            return getDataListOfDispatchOrder(sqlWhere, null);
        }

        private IList<UpdateCycle_MDL> getDataListOfDispatchOrder(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT, sqlWhere));

            IList<UpdateCycle_MDL> DispatchOrderList = new List<UpdateCycle_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY uc.ID DESC").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    UpdateCycle_MDL DispatchOrder = new UpdateCycle_MDL(
                         (sdr["DO_No"] == DBNull.Value) ? "" : sdr["DO_No"].ToString().Trim(),
                         (sdr["WorkOrderNo"] == DBNull.Value) ? "" : sdr["WorkOrderNo"].ToString().Trim(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                         (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),
                         (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                         (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),
                         (sdr["UpdateStandCycle"] == DBNull.Value) ? "" : sdr["UpdateStandCycle"].ToString(),
                         (sdr["StandCycle"] == DBNull.Value) ? "" : sdr["StandCycle"].ToString(),
                         (sdr["MaxInjectionCycle"] == DBNull.Value) ? "" : sdr["MaxInjectionCycle"].ToString(),
                         (sdr["MinInjectionCycle"] == DBNull.Value) ? "" : sdr["MinInjectionCycle"].ToString(),
                         (sdr["updateemployee"] == DBNull.Value) ? "" : sdr["updateemployee"].ToString(),
                         (sdr["updatetime"] == DBNull.Value) ? "" : sdr["updatetime"].ToString()

                       );
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;
        }

        public IList<UpdateCycle_MDL> selectUpdateCycle(int id, string colname, string coltext)
        {
            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = new SqlParameter[] {               
               fsp.FormatInParam("@ID", SqlDbType.Int, id)
           };

            if (id != 0)
                sqlWhere.Append(string.Format("AND ID=@ID "));
            if (colname != "" && coltext != "")
                sqlWhere.Append(string.Format("AND {0} like '%" + cmm.GetSafeSqlText(true, coltext) + "%'", colname));

            return getDataListOfDispatchOrder(sqlWhere, sqlParas);
        }

        private IList<UpdateCycle_MDL> getDataListOfUpdateCycle(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            StringBuilder sqlCmd = new StringBuilder(string.Format("{0}{1}", SQL_SELECT2, sqlWhere));

            IList<UpdateCycle_MDL> DispatchOrderList = new List<UpdateCycle_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.Append(" ORDER BY ID DESC").ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    UpdateCycle_MDL DispatchOrder = new UpdateCycle_MDL(sdr.GetInt32(0),
                         (sdr["DO_No"] == DBNull.Value) ? "" : sdr["DO_No"].ToString().Trim(),

                         (sdr["ProductNo"] == DBNull.Value) ? "" : sdr["ProductNo"].ToString().Trim(),
                         (sdr["ProductDesc"] == DBNull.Value) ? "" : sdr["ProductDesc"].ToString().Trim(),
                         (sdr["MachineNo"] == DBNull.Value) ? "" : sdr["MachineNo"].ToString().Trim(),
                         (sdr["MouldNo"] == DBNull.Value) ? "" : sdr["MouldNo"].ToString().Trim(),


                         (sdr["StandCycle"] == DBNull.Value) ? "0" : sdr["StandCycle"].ToString().Trim(),
                         (sdr["MaxInjectionCycle"] == DBNull.Value) ? "0" : sdr["MaxInjectionCycle"].ToString().Trim(),
                         (sdr["MinInjectionCycle"] == DBNull.Value) ? "0" : sdr["MinInjectionCycle"].ToString().Trim(),
                         (sdr["UpdateStandCycle"] == DBNull.Value) ? "0" : sdr["UpdateStandCycle"].ToString().Trim(),
                         (sdr["UpdateMaxInjectionCycle"] == DBNull.Value) ? "0" : sdr["UpdateMaxInjectionCycle"].ToString().Trim(),
                         (sdr["UpdateMinInjectionCycle"] == DBNull.Value) ? "0" : sdr["UpdateMinInjectionCycle"].ToString(),
                         (sdr["UpdateTime"] == DBNull.Value) ? "" : sdr["UpdateTime"].ToString(),
                         (sdr["CreateTime"] == DBNull.Value) ? "" : sdr["CreateTime"].ToString(),
                         (sdr["UpdateEmployee"] == DBNull.Value) ? "" : sdr["UpdateEmployee"].ToString()
                       );
                    DispatchOrderList.Add(DispatchOrder);
                }
            }
            return DispatchOrderList;
        }

        public int ChangeUpdateCycle(UpdateCycle_MDL Obj, string IU)
        {
            SqlParameter[] sqlParas = {
                         fsp.FormatInParam("@DO_NO", SqlDbType.VarChar, Obj.DO_NO),

                         //qizh 2009.08.19
                         fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, Obj.ProductNo ),
                         fsp.FormatInParam("@ProductDesc", SqlDbType.VarChar, Obj.ProductDesc),
                         fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, Obj.MachineNo),
                         fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, Obj.MouldNo),

                         fsp.FormatInParam("@StandCycle", SqlDbType.VarChar, Obj.StandCycle ),
                         fsp.FormatInParam("@MaxInjectionCycle", SqlDbType.VarChar, Obj.MaxInjectionCycle),
                         fsp.FormatInParam("@MinInjectionCycle", SqlDbType.VarChar, Obj.MinInjectionCycle),
                         fsp.FormatInParam("@UpdateStandCycle", SqlDbType.VarChar, Obj.UpdateStandCycle),
                         fsp.FormatInParam("@UpdateMaxInjectionCycle", SqlDbType.VarChar, Obj.UpdateMaxInjectionCycle),
                         fsp.FormatInParam("@UpdateMinInjectionCycle", SqlDbType.VarChar, Obj.UpdateMinInjectionCycle),
                         fsp.FormatInParam("@UpdateTime", SqlDbType.VarChar, Obj.UpdateTime ),
                         fsp.FormatInParam("@CreateTime", SqlDbType.VarChar, Obj.CreateTime),
                         fsp.FormatInParam("@UpdateEmployee", SqlDbType.VarChar, Obj.UpdateEmployee),              
                         fsp.FormatInParam("@ID", SqlDbType.Int, Obj.ID)
            };
            if (IU == "INSERT")
               return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT, sqlParas);
            else
               Obj = null;
               return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE, sqlParas);
            
        }

        public int ChangeDispatchOrder(UpdateCycle_MDL Obj, string IU)
        {
            SqlParameter[] sqlParas = {
                         fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, Obj.ProductNo),

                         ////qizh 2009.08.19
                         //fsp.FormatInParam("@ProductNo", SqlDbType.VarChar, Obj.ProductNo ),
                         //fsp.FormatInParam("@ProductDesc", SqlDbType.VarChar, Obj.ProductDesc),
                         //fsp.FormatInParam("@MachineNo", SqlDbType.VarChar, Obj.MachineNo),
                         //fsp.FormatInParam("@MouldNo", SqlDbType.VarChar, Obj.MouldNo),

                         fsp.FormatInParam("@StandCycle", SqlDbType.VarChar, Obj.UpdateStandCycle ),
                         fsp.FormatInParam("@MaxInjectionCycle", SqlDbType.VarChar, Obj.UpdateMaxInjectionCycle),
                         fsp.FormatInParam("@MinInjectionCycle", SqlDbType.VarChar, Obj.UpdateMinInjectionCycle)
            };
            if (IU == "INSERT")
                return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE2, sqlParas);
            else
                Obj = null;
                return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE2, sqlParas);
            
        }

        public int deleteUpdateCycle(string vDO_NO)
        {
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_NO", SqlDbType.VarChar, vDO_NO) };
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("DELETE UpdateCycle WHERE DO_NO=@DO_NO IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ");            
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
           return  SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, sqlParas);
            //SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE DispatchOrder WHERE ID=@ID", sqlParas);
        }

        public int cancelDispatchOrder(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
            {
                ExecBatch += string.Format("DELETE UpdateCycle WHERE DO_NO={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            }
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public int UpdateDispatchOrder(string vProductNo, string vUpdateStandCycle, string vUpdateMaxInjectionCycle, string vUpdateMinInjectionCycle, string vUpdateTime,string vUpdateEmployee)
        {
            try
            {
                string SQL_UPDATEDis = 
                @"BEGIN TRANSACTION " +
                " UPDATE updatecycle SET UpdateStandCycle=" + vUpdateStandCycle + ",UpdateMaxInjectionCycle=" + vUpdateMaxInjectionCycle + "," +
                " UpdateMinInjectionCycle=" + vUpdateMinInjectionCycle + ", " +
                " UpdateTime='" + vUpdateTime + "', UpdateEmployee='" + vUpdateEmployee + "'  WHERE ProductNo='" + vProductNo + "' " +
                " IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot " +
                " UPDATE dispatchorder SET UpdateCycleStatus=0, standcycle=" + vUpdateStandCycle + ",MaxInjectionCycle=" + vUpdateMaxInjectionCycle + ",MinInjectionCycle=" + vUpdateMinInjectionCycle + " WHERE ProductNo='" + vProductNo + "' " +
                " IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot " +
                " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATEDis, null);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IList<UpdateCycle_MDL> existsDispatchOrder(string DO_No)
        {
            StringBuilder sqlWhere = new StringBuilder(" AND DO_No=@DO_No");
            SqlParameter[] sqlParas = { fsp.FormatInParam("@DO_No", SqlDbType.VarChar, DO_No) };

            return getDataListOfUpdateCycle(sqlWhere, sqlParas);
        }
    }
}
