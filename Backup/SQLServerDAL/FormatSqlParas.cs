using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Admin.SQLServerDAL
{
    public class FormatSqlParas
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="paraValue"></param>
        /// <returns></returns>
        public SqlParameter FormatInParam(string paraName, SqlDbType dbType,object paraValue)
        {
            return SetSqlParas(paraName, paraValue, ParameterDirection.Input, dbType, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <param name="paraValue"></param>
        /// <returns></returns>
        public SqlParameter FormatInParam(string paraName, SqlDbType dbType, int dbSize, object paraValue)
        {
            return SetSqlParas(paraName, paraValue, ParameterDirection.Input, dbType, dbSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <param name="dataSource"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public SqlParameter FormatInParam(string paraName, SqlDbType dbType, int dbSize, string dataSource, DataRowVersion version)
        {
            return SetSqlParas(paraName, dataSource, version, ParameterDirection.Input, dbType, dbSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <returns></returns>
        public SqlParameter FormatOutParam(string paraName, SqlDbType dbType, int dbSize)
        {
            return SetSqlParas(paraName, null, ParameterDirection.Output, dbType, dbSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public SqlParameter FormatOutParam(string paraName, SqlDbType dbType)
        {
            return SetSqlParas(paraName, null, ParameterDirection.Output, dbType, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="paraValue"></param>
        /// <param name="paraDrtion"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <returns></returns>
        private SqlParameter SetSqlParas(string paraName, object paraValue, ParameterDirection paraDrtion, SqlDbType dbType, int dbSize)
        {
            if (!paraName.StartsWith("@"))
                paraName = "@" + paraName;

            SqlParameter param = (dbSize > 0) ? new SqlParameter(paraName, dbType, dbSize) : new SqlParameter(paraName, dbType);
            param.Direction = paraDrtion;

            if (!(param.Direction == ParameterDirection.Output && paraValue == null))
            {
                param.Value = paraValue;
            }
            return param;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dataSource"></param>
        /// <param name="drVersion"></param>
        /// <param name="paraDrtion"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <returns></returns>
        private SqlParameter SetSqlParas(string paraName, string dataSource, DataRowVersion drVersion, ParameterDirection paraDrtion, SqlDbType dbType, int dbSize)
        {
            SqlParameter param = (dbSize > 0) ? new SqlParameter(paraName, dbType, dbSize) : new SqlParameter(paraName, dbType);
            param.Direction = paraDrtion;
            param.SourceColumn = dataSource;
            param.SourceVersion = drVersion;
            return param;
        }
    }
}
