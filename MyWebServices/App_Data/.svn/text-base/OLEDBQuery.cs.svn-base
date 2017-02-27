using System;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.DBUtility;
using Admin.OLDServerDAL;


namespace Admin.OLEDBQuery
{
    /// <summary>
    /// OLEDBQuery 的摘要说明
    /// </summary>
    public class OLEDBQuery
    {
        private string QueryProduct = ConfigurationManager.ConnectionStrings["QueryProduct"].ConnectionString;   //模糊查询产品信息
        private string QueryProductDetail = ConfigurationManager.ConnectionStrings["QueryProductDetail"].ConnectionString;  //精确查询产品信息
        private string QueryBOM = ConfigurationManager.ConnectionStrings["QueryBOM"].ConnectionString;  //查询BOM清单
        private string QueryDispatchOrder = ConfigurationManager.ConnectionStrings["QueryDispatchOrder"].ConnectionString;  //模糊查询工单信息
        private string QueryDispatchOrderDetail = ConfigurationManager.ConnectionStrings["QueryDispatchOrderDetail"].ConnectionString;  //精确查询工单信息
        private string QueryWireDetail = ConfigurationManager.ConnectionStrings["QueryWireDetail"].ConnectionString;  //查询铁丝编码

        FormatOLDParas fsp = new FormatOLDParas();
        FormatOLDCmd fsc = new FormatOLDCmd();
        public OLEDBQuery()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 模糊查询产品信息
        /// </summary>
        /// <param name="sqlWhere">产品编号</param>
        /// <returns></returns>
        public DataSet OLEDBQueryProduct(string OleWhere)
        {
            if (OleWhere != "")
            {
                QueryProduct = string.Format(QueryProduct, OleWhere);
            }
            else
            {
                return null;
            }
            try
            {
                DataSet ds = OleDBHelper.ReturnDataSet(CommandType.Text, QueryProduct, null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 模糊查询工单信息
        /// </summary>
        /// <param name="sqlWhere">工单号</param>
        /// <returns></returns>
        public DataSet OLEDBQueryDispatchOrder(string OleWhere)
        {
            if (OleWhere != "")
            {
                QueryDispatchOrder = string.Format(QueryDispatchOrder, OleWhere);
            }
            else
            {
                return null;
            }
            try
            {
                DataSet ds = OleDBHelper.ReturnDataSet(CommandType.Text, QueryDispatchOrder, null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 精确查询工单信息
        /// </summary>
        /// <param name="sqlWhere">工单号</param>
        /// <returns></returns>
        public DataSet OLEDBQueryDispatchOrderDetail(string sqlWhere)
        {
            if (sqlWhere != "")
            {
                QueryDispatchOrderDetail = string.Format(QueryDispatchOrderDetail, sqlWhere);
            }
            else
            {
                return null;
            }
            try
            {
                DataSet ds = OleDBHelper.ReturnDataSet(CommandType.Text, QueryDispatchOrderDetail, null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 精确查询产品信息
        /// </summary>
        /// <param name="sqlWhere">产品编号</param>
        /// <returns></returns>
        public DataSet OLEDBQueryProductDetail(string sqlWhere)
        {
            if (sqlWhere != "")
            {
                QueryProductDetail = string.Format(QueryProductDetail, sqlWhere);
            }
            else
            {
                return null;
            }
            try
            {
                DataSet ds = OleDBHelper.ReturnDataSet(CommandType.Text, QueryProductDetail, null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 查询BOM清单
        /// </summary>
        /// <param name="sqlWhere">产品编号</param>
        /// <returns></returns>
        public DataSet OLEDBQueryBOM(string sqlWhere)
        {
            if (sqlWhere != "")
            {
                QueryBOM = string.Format(QueryBOM, sqlWhere, sqlWhere);
                try
                {
                    DataSet ds = OleDBHelper.ReturnDataSet(CommandType.Text, QueryBOM, null);
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 查询铁丝编码
        /// </summary>
        /// <returns></returns>
        public DataSet OLEDBQueryWireDetail()
        {
            try
            {
                DataSet ds = OleDBHelper.ReturnDataSet(CommandType.Text, QueryWireDetail, null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

    }
}