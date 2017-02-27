using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.SQLServerDAL.CrystalReports_DAL;

public partial class CrystalReports_SelectCell : System.Web.UI.Page
{
    CrystalReports crd = new CrystalReports();
    public int numbers;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.binds();
        }
    }

    public void binds()
    {
        string tabname = Request.QueryString["tabname"].ToString() == "" ? "" : Request.QueryString["tabname"].ToString();
        this.Select1.DataSource = crd.SelCell(tabname);
        this.Select1.DataTextField = "colname";
        this.Select1.DataValueField = "colname";
        this.Select1.DataBind();
        numbers = int.Parse(crd.SelCell(tabname).Rows.Count.ToString());
        this.Select1.Multiple = true;
    }
    protected void btnok_Click(object sender, ImageClickEventArgs e)
    {
        string ids = Request.QueryString["d"].ToString();
        string name = "txt" + ids;
        //string name2 = "drop" + ids;
        string selcell = Request.Form["Select1"].ToString();
        //Response.Write(name);
        ClientScript.RegisterStartupScript(this.GetType(), "saa", "<script>opener.document.form1." + name + ".value = '" + selcell + "';window.close();</script>");



    }
    protected void btnclose_Click(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>window.close();</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ids = Request.QueryString["d"].ToString();
        string name = "lb3" + ids.ToString();
        // Response.Write(ids);
        string selcell = Request.Form["Select1"].ToString();// this.Select1.s.Value.ToString();
        ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('" + selcell + "')</script>");
        // ClientScript.RegisterStartupScript(this.GetType(), "saa", "<script>opener.document.form1.tabcoll.value = 'daidai';window.close();</script>");
    }
}
