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
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class WebReport_ProdPlan : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "CompleteSchedule");
            ViewState["authority"] = o;

            if (o[4]) btnPrint.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!this.IsPostBack)
        {
            txtStartDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["ProductReport_FirstDate"] = txtStartDate.Value.Trim();        
        Session["ProductReport_MachineNo"] = "";
        Session["ProductReport_UserID"] = this.Page.User.Identity.Name.Trim();
        Session["ProductReport_ReportKind"] = ddlReportType.SelectedValue.Trim();

        //Response.Redirect("");
        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=ProductReport') </script>");
    }
}
