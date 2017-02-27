using System;
using System.Collections.Generic;
using System.Text;
using Admin.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using Admin.SQLServerDAL;

namespace Admin.SQLServerDAL.BaseInfo_DAL
{
    public class WorkRate_DAL
    {
        SQLExecutant MyExec = new SQLExecutant();

        public DataTable SelectWorkRate()
        {
            string sql = "select * from itemmstr where workrate <> ''";
            return MyExec.ExecQueryCmd(sql);
        }
        public DataTable SelectWorkRate(string item_code)
        {
            string sql = "select * from itemmstr where item_code='" + item_code + "'";
            return MyExec.ExecQueryCmd(sql);
        }
        public DataTable SelectWorkRate(string item_code, string workrate)
        {
            string sql = "select * from itemmstr where item_code='" + item_code + "' and workrate<> ''";
            return MyExec.ExecQueryCmd(sql);
        }
        public DataTable SelectWorkRate(int id)
        {
            string sql = "select * from itemmstr where id=" + id + "";
            return MyExec.ExecQueryCmd(sql);
        }
        public void DeleteWorkRate(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("update ItemMstr set workrate='' WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        public void UpdateWorkRate(int id, string workrate, string overtime_num)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("update ItemMstr set workrate='{1}',overtime_num='{2}' WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", id, workrate, overtime_num);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }
        public void UpdateWorkRate(string item_code, string workrate, string overtime_num)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            ExecBatch += string.Format("update ItemMstr set workrate='{1}' , overtime_num='{2}' WHERE item_code='{0}' IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", item_code, workrate, overtime_num);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

    }
}
