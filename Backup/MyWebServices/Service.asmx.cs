using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using Admin.OLDServerDAL;
using Admin.DBUtility;
using Admin.OLEDBQuery;

namespace Admin
{
    [WebService(Namespace = "http://192.168.3.109/")]
    public class Service : System.Web.Services.WebService
    {
        OLEDBQuery.OLEDBQuery Querys = new OLEDBQuery.OLEDBQuery();
        public Service()
        {

            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        /// <summary>
        /// 模糊查询产品信息
        /// </summary>
        /// <param name="StrWhere">产品编号</param>
        /// <returns></returns>
        [WebMethod]
        public DataSet OLEDBQueryProduct(string StrWhere)
        {
            DataSet ds = Querys.OLEDBQueryProduct(StrWhere);
            return ds;
        }
        /// <summary>
        /// 模糊查询工单信息
        /// </summary>
        /// <param name="StrWhere">工单号</param>
        /// <returns></returns>
        [WebMethod]
        public DataSet OLEDBQueryDispatchOrder(string StrWhere)
        {
            DataSet ds = Querys.OLEDBQueryDispatchOrder(StrWhere);
            return ds;
        }
        /// <summary>
        /// 精确查询工单信息
        /// </summary>
        /// <param name="StrWhere">工单号</param>
        /// <returns></returns>
        [WebMethod]
        public DataSet OLEDBQueryDispatchOrderDetail(string StrWhere)
        {
            DataSet ds = Querys.OLEDBQueryDispatchOrderDetail(StrWhere);
            return ds;
        }
        /// <summary>
        /// 精确查询产品信息
        /// </summary>
        /// <param name="StrWhere">产品编号</param>
        /// <returns></returns>
        [WebMethod]
        public DataSet OLEDBQueryProductDetail(string StrWhere)
        {
            DataSet ds = Querys.OLEDBQueryProductDetail(StrWhere);
            return ds;
        }

        /// <summary>
        /// 查询BOM清单
        /// </summary>
        /// <param name="StrWhere">产品编号</param>
        /// <returns></returns>
        [WebMethod]
        public DataSet OLEDBQueryBOM(string StrWhere)
        {
            DataSet ds = Querys.OLEDBQueryBOM(StrWhere);
            return ds;
        }

        /// <summary>
        /// 查询铁丝编码
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet OLEDBQueryWireDetail()
        {
            DataSet ds = Querys.OLEDBQueryWireDetail();
            return ds;
        }

    }
}