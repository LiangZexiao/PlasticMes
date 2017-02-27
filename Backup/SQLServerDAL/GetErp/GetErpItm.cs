using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Admin.Model;
using Admin.DBUtility;

namespace Admin.SQLServerDAL.GetErp
{
    public class GetErpItm
    {
        //private string SELECTSQL = "SELECT TOP 50 IT1.ITMREF_0,IT1.ITMDES1_0,IT1.ITMDES3_0 from YSZS.ITMMASTER IT1  ";//ģ����ѯ��Ʒ��Ϣ
        //private string SELECTSQL2 = "SELECT TOP 1 IT1.ITMREF_0,IT1.ITMDES1_0,IT1.ITMDES3_0 from YSZS.ITMMASTER IT1 "; //��ȷ��ѯ��Ʒ��Ϣ
        //private string SELECTSQL3 = "select  IT1.ITMREF_0 as ITMREF,IT1.ITMDES1_0 as ITMDES,IT2.CPNITMREF_0 as CPNITMREF," +
        //        "CAST(CAST(IT2.LIKQTY_0 AS DECIMAL(10,3)) AS varchar (50))+IT2.STU_0  as  XLK,IT2.ITMDES1_0 as ITMDES_1,IT2.ROWID as ROWID " +
        //        "from YSZS.ITMMASTER IT1 left join (" +
        //        "	select s1.CPNITMREF_0,s1.ITMREF_0,s1.LIKQTY_0,s1.ROWID,s2.ITMDES1_0,s2.ITMDES3_0,s2.STU_0 " +
        //        "	from  YSZS.BOMD s1 left join YSZS.ITMMASTER s2 on  s1.CPNITMREF_0=s2.ITMREF_0 " +
        //        "	where s1.ITMREF_0='{0}' " +
        //        ") IT2 on IT2.ITMREF_0=IT1.ITMREF_0 where IT1.ITMREF_0='{1}'";   //��ѯBOM�嵥
        //private string SELECTSQL4 = "SELECT TOP 50 MF.MFGNUM_0, MF.UOM_0,MF.UOMEXTQTY_0,MF.ITMREF_0,IT1.ITMDES1_0,IT1.ITMDES3_0 from YSZS.MFGITM MF left join " +
        //    " YSZS.ITMMASTER IT1 ON MF.ITMREF_0=IT1.ITMREF_0" +
        //    " LEFT JOIN YSZS.MFGHEAD MF2 ON MF.MFGNUM_0=MF2.MFGNUM_0 WHERE  MF2.MFGSTA_0 =1 AND (SUBSTRING(MF.ITMREF_0,1,1)='2' OR SUBSTRING(MF.ITMREF_0,1,1)='4') ";
        //private string SELECTSQL5 = "select s2.ITMREF_0,s2.ITMDES1_0,s2.ITMDES3_0,s2.STU_0  from   YSZS.ITMMASTER s2 where len(s2.ITMREF_0)= 7 and substring(s2.ITMREF_0,1,3)='199' ";//��ѯ��˿����
        //ERPSQLExecutant erpex = new ERPSQLExecutant();
        //FormatSqlParas fsp = new FormatSqlParas();
        //Common cmm = new Common();
        //FormatSqlCmd fsc = new FormatSqlCmd();
        ERPWebSer.Service webser = new ERPWebSer.Service();

        /// <summary>
        /// ģ����ѯ��Ʒ��Ϣ
        /// </summary>
        /// <param name="sqlWhere">��Ʒ���</param>
        /// <returns></returns>
        
        public DataSet QueryErp(string sqlWhere)
        {
            //SqlParameter[] sqlParas = null;
            //if (sqlWhere != "")
            //{
            //    //SELECTSQL+=" where k1.ITMREF_0 ="
            //    SELECTSQL += string.Format(" WHERE IT1.ITMREF_0 LIKE '{0}%'", sqlWhere);
            //    // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ITMREF_0", SqlDbType.VarChar, sqlWhere) };
            //}
            try
            {
                DataSet ds = webser.OLEDBQueryProduct(sqlWhere);
                return ds;
               // return ERPSQLHelper.ReturnDataSet(CommandType.Text, SELECTSQL, sqlParas);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// ģ����ѯ������Ϣ
        /// </summary>
        /// <param name="sqlWhere">������</param>
        /// <returns></returns>
        public DataSet QueryErpDispatch(string sqlWhere)
        {
            //SqlParameter[] sqlParas = null;
            //if (sqlWhere != "")
            //{
            //    //SELECTSQL+=" where k1.ITMREF_0 ="
            //    SELECTSQL4 += string.Format(" and MF.MFGNUM_0 like '{0}%'", sqlWhere);
            //    // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ITMREF_0", SqlDbType.VarChar, sqlWhere) };
            //}
            try
            {
                DataSet ds = webser.OLEDBQueryDispatchOrder(sqlWhere);
                return ds;
               // return ERPSQLHelper.ReturnDataSet(CommandType.Text, SELECTSQL4, sqlParas);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// ��ȷ��ѯ������Ϣ
        /// </summary>
        /// <param name="sqlWhere">������</param>
        /// <returns></returns>
        public DataSet QueryErpDispatchDetail(string sqlWhere)
        {
           // SqlParameter[] sqlParas = null;
           // if (sqlWhere != "")
           // {
                //SELECTSQL+=" where k1.ITMREF_0 ="
               // SELECTSQL4 += string.Format(" AND MF.MFGNUM_0 = '{0}'", sqlWhere);
                // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ITMREF_0", SqlDbType.VarChar, sqlWhere) };
          //  }
            try
            {
                DataSet ds = webser.OLEDBQueryDispatchOrderDetail(sqlWhere);
                return ds;
               // SELECTSQL4 += " ORDER BY MF.ITMREF_0 ";
                //return ERPSQLHelper.ReturnDataSet(CommandType.Text, SELECTSQL4, sqlParas);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// ��ȷ��ѯ��Ʒ��Ϣ
        /// </summary>
        /// <param name="sqlWhere">��Ʒ���</param>
        /// <returns></returns>
        public DataSet QueryErpDetail(string sqlWhere)
        {
            //SqlParameter[] sqlParas = null;
            //if (sqlWhere != "")
            //{
            //    //SELECTSQL+=" where k1.ITMREF_0 ="
            //    SELECTSQL2 += string.Format(" WHERE IT1.ITMREF_0 = '{0}'", sqlWhere);
            //    // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ITMREF_0", SqlDbType.VarChar, sqlWhere) };
            //}
            try
            {
                // return ws.QueryErp(ERPSQLHelper.tmpCntStringOfdb, SELECTSQL2);
               // return ERPSQLHelper.ReturnDataSet(CommandType.Text, SELECTSQL2, sqlParas);
                DataSet ds = webser.OLEDBQueryProductDetail(sqlWhere);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// ��ѯBOM�嵥
        /// </summary>
        /// <param name="sqlWhere">��Ʒ���</param>
        /// <returns></returns>
        /// 
        public DataSet QueryErpBomDetail(string sqlWhere)
        {
            //SqlParameter[] sqlParas = null;
            //if (sqlWhere != "")
            //{
            //    //SELECTSQL+=" where k1.ITMREF_0 ="
            //    SELECTSQL3 = string.Format(SELECTSQL3, sqlWhere, sqlWhere);
                // sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ITMREF_0", SqlDbType.VarChar, sqlWhere) };
                try
                {
                    //return ws.QueryErp(ERPSQLHelper.tmpCntStringOfdb, SELECTSQL3);
                   // return ERPSQLHelper.ReturnDataSet(CommandType.Text, SELECTSQL3, sqlParas);
                    DataSet ds=webser.OLEDBQueryBOM(sqlWhere);
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }
            //}
            //else
            //{
            //    return null;
           // }

        }
        /// <summary>
        /// ��ѯ��˿����
        /// </summary>
        /// <returns></returns>
        public DataSet QueryErpWireDetail()
        {
            SqlParameter[] sqlParas = null;
          
                try
                {
                    //return ws.QueryErp(ERPSQLHelper.tmpCntStringOfdb, SELECTSQL3);
                    //return ERPSQLHelper.ReturnDataSet(CommandType.Text, SELECTSQL5, sqlParas);
                    DataSet ds = webser.OLEDBQueryWireDetail();
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }
           

        }

    }
}