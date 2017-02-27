using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin.DBUtility
{
   public  class DataBase : IDisposable
	{
		private SqlConnection conn;

		/// <summary>
		/// 传入输入参数
		/// </summary>
		/// <param name="paraName">参数名</param>
		/// <param name="dbType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <param name="values">参数值</param>
		/// <returns>新的 parameter 对象</returns>
		public SqlParameter MakeInParam(string paraName, SqlDbType dbType, int size, object values)
		{
			return MakeParam(paraName, dbType, size, ParameterDirection.Input, values);
		}

		public SqlParameter MakeInParam(string paraName, SqlDbType dbType, int size, string dataSource, DataRowVersion version)
		{
			return MakeParam(paraName, dbType, size, ParameterDirection.Input, dataSource, version);
		}

		/// <summary>
		/// 传入输出参数
		/// </summary>
		/// <param name="paraName">参数名</param>
		/// <param name="dbType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <returns>新的 parameter 对象</returns>
		public SqlParameter MakeOutParam(string paraName, SqlDbType dbType, int size)
		{
			return MakeParam(paraName, dbType, size, ParameterDirection.Output, null);
		}

		/// <summary>
		/// 生成存储过程参数
		/// </summary>
		/// <param name="paraName">参数名</param>
		/// <param name="dbType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <param name="direction">参数方向</param>
		/// <param name="values">值</param>
		/// <returns>新的 parameter 对象</returns>
		private SqlParameter MakeParam(string paraName, SqlDbType dbType, int size, ParameterDirection direction, object values)
		{
			SqlParameter param;
			if (size > 0)
			{
				param = new SqlParameter(paraName, dbType, size);
			}
			else
			{
				param = new SqlParameter(paraName, dbType);
			}
			param.Direction = direction;
			if (!(param.Direction == ParameterDirection.Output && values == null))
			{
				param.Value = values;
			}
			return param;
		}

		/// <summary>
		/// 生成存储过程参数
		/// </summary>
		/// <param name="paraName">参数名</param>
		/// <param name="dbType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <param name="direction">参数方向</param>
		/// <param name="dataSource">源列</param>
		/// <param name="version">源版本</param>
		/// <returns>新的 parameter 对象</returns>
		private SqlParameter MakeParam(string paraName, SqlDbType dbType, int size,  ParameterDirection direction, string dataSource, DataRowVersion version)
		{
			SqlParameter param;
			if (size > 0)
			{
				param = new SqlParameter(paraName, dbType, size);
			}
			else
			{
				param = new SqlParameter(paraName, dbType);
			}
			param.Direction = direction;
			param.SourceColumn = dataSource;
			param.SourceVersion = version;
			return param;
		}

		/// <summary>
		/// 创建一个Command对象来执行存储过程
		/// </summary>
		/// <param name="procName">存储过程的名称</param>
		/// <param name="paras">存储过程所需参数</param>
		/// <returns>返回SqlCommand对象</returns>
		public SqlCommand CreateCommand(string procName, SqlParameter[] paras)
		{
			Open();
			SqlCommand cmd = new SqlCommand(procName, conn);
            cmd.CommandTimeout = 3600;
			cmd.CommandType = CommandType.StoredProcedure;

			if (paras != null)
			{
				foreach (SqlParameter parameter in paras)
				{
					cmd.Parameters.Add(parameter);
				}
			}
			return cmd;
		}

		/// <summary>
		/// 打开数据库连接
		/// </summary>
		public void Open()
		{
            
			if (conn == null)
			{
                conn = new SqlConnection(SqlHelper.CntStringOfdb);
			}
			if (conn.State == ConnectionState.Closed)
			{
				conn.Open();
			}
		}

		/// <summary>
		/// 关闭数据库连接
		/// </summary>
		public void Close()
		{
			if (conn != null)
			{
				conn.Dispose();;
			}
		}

		#region IDisposable 成员

		/// <summary>
		/// 释放资源
		/// </summary>
		public void Dispose()
		{
			if (conn != null)
			{
				conn.Dispose();
				conn = null;
			}
		}

		#endregion
	}
}
