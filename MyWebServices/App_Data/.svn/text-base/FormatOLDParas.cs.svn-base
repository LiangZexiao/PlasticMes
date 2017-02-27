using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace Admin.OLDServerDAL
{
    public class FormatOLDParas
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="paraValue"></param>
        /// <returns></returns>
        public OleDbParameter FormatInParam(string paraName, OleDbType dbType, object paraValue)
        {
            return SetOleDbParas(paraName, paraValue, ParameterDirection.Input, dbType, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <param name="paraValue"></param>
        /// <returns></returns>
        public OleDbParameter FormatInParam(string paraName, OleDbType dbType, int dbSize, object paraValue)
        {
            return SetOleDbParas(paraName, paraValue, ParameterDirection.Input, dbType, dbSize);
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
        public OleDbParameter FormatInParam(string paraName, OleDbType dbType, int dbSize, string dataSource, DataRowVersion version)
        {
            return SetOleDbParas(paraName, dataSource, version, ParameterDirection.Input, dbType, dbSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="dbSize"></param>
        /// <returns></returns>
        public OleDbParameter FormatOutParam(string paraName, OleDbType dbType, int dbSize)
        {
            return SetOleDbParas(paraName, null, ParameterDirection.Output, dbType, dbSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public OleDbParameter FormatOutParam(string paraName, OleDbType dbType)
        {
            return SetOleDbParas(paraName, null, ParameterDirection.Output, dbType, 0);
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
        private OleDbParameter SetOleDbParas(string paraName, object paraValue, ParameterDirection paraDrtion, OleDbType dbType, int dbSize)
        {
            if (!paraName.StartsWith("@"))
                paraName = "@" + paraName;

            OleDbParameter param = (dbSize > 0) ? new OleDbParameter(paraName, dbType, dbSize) : new OleDbParameter(paraName, dbType);
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
        private OleDbParameter SetOleDbParas(string paraName, string dataSource, DataRowVersion drVersion, ParameterDirection paraDrtion, OleDbType dbType, int dbSize)
        {
            OleDbParameter param = (dbSize > 0) ? new OleDbParameter(paraName, dbType, dbSize) : new OleDbParameter(paraName, dbType);
            param.Direction = paraDrtion;
            param.SourceColumn = dataSource;
            param.SourceVersion = drVersion;
            return param;
        }
    }
}
