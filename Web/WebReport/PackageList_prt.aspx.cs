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
using Admin.Model.Product_MDL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Product_DAL;

public partial class WebReport_PackageList_prt : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    string CacheName = "PackageList_prt";
    string ReportName = "PackageList";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "PackageList_prt");
            ViewState["authority"] = o;

            if (o[4]) btnPrint.Visible = !o[4];
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
    }

    protected void GetPackageList_prt()
    {
        string ProdNO = txtProdNO.Text.Trim();
        PackageList_MDL mdlPackageList = new PackageList_MDL(false, ProdNO);
        PackageList_BLL bllPackageList = new PackageList_BLL();
        PackageList_XSD xsdPackageList = new PackageList_XSD();

        DataTable dt =  new PackageList_DAL().selectPackageList(0, "id", Session["PackageList_ID"].ToString().Trim(), 0);// bllPackageList.selectPackageList(mdlPackageList);
        dt.TableName = "PackageList";
        xsdPackageList.Merge(dt);
        SetCache(xsdPackageList);
    }

    protected void SetCache(DataSet ds)
    {
        Cache.Remove(Session.SessionID + CacheName);
        Cache.Add(Session.SessionID + CacheName, ds, null, DateTime.Now.AddMinutes(10),
            TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        GetPackageList_prt();
        DataSet ds = Cache[Session.SessionID + CacheName] as DataSet;
        //Response.Redirect("~/ViewReport.aspx?CacheName=" + CacheName + "&ReportName=" + ReportName);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
                 @"<script> window.open('../ViewReport.aspx?CacheName=" + CacheName + "&ReportName=" + ReportName + "') </script>");
    }
}