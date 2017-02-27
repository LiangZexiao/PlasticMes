using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Product_MDL;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.Product_BLL;
using Admin.BLL.Machine_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL;
using Admin.SQLServerDAL.GetErp;
public partial class chief_bom : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(chief_bom));
        if (!IsPostBack)
        {           
            this.MultiView1.ActiveViewIndex = 0;
            this.search.Value = "";
            bindGr("");
        }
    }
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds = new GetErpItm().QueryErp(str);  //ERPSQLExecutant().ExecQueryCmd(sql);


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            itmes.Add(dr[0]);
        }
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }

    [Ajax.AjaxMethod()]
    public ArrayList GetSearhValues(string str)
    {
        ArrayList itmes = new ArrayList();
     
        DataSet ds = new GetErpItm().QueryErpDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);

        string itemStr1 = ds.Tables[0].Rows[0][1].ToString();
        string itemStr2 = ds.Tables[0].Rows[0][2].ToString();

        if (itemStr1 != "" && itemStr2 != "")
        {
            itmes.Add(itemStr1 + "," + itemStr2);
        }
        else if (itemStr1 == "" && itemStr2 != "")
        {
            itmes.Add(itemStr2);
        }
        else if (itemStr1 != "" && itemStr2 == "")
        {
            itmes.Add(itemStr1);
        }
        else if (itemStr1 == "" && itemStr2 == "")
        {
            itmes.Add(" ");
        }

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }
    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        string str=this.search.Value.Trim();
        if (str != "")
        {
            bindGr(str);
        }
        this.search.Value = "";
    }
    void bindGr(string str)
    {
        DataSet ds = new GetErpItm().QueryErpBomDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
}
