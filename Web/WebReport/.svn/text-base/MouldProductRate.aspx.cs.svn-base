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
using Admin.Model.Machine_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.Model.Product_MDL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class WebReport_MouldProductRate : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MouldProductRate");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            trProductNo.Visible = false;
            dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");
            dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail(0, "", "") as IList, true, "Mould_Code", "Mould_Code");
            dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, true, "Item_Code", "Item_Code");
            //txtBeginDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string BeginDate = txtBeginDate.Value.Trim();
        if (string.IsNullOrEmpty(BeginDate))
        {
            dboSetCtrls.SetExecMsg(this, "startdate", true);
            return;
        }
        string EndDate = (txtEndDate.Value.Trim() == string.Empty) ? System.DateTime.Now.ToString("yyyy-MM-dd") : txtEndDate.Value.Trim();
        if (dboSetCtrls.CheckDateTime("string", BeginDate, EndDate))
        {
            dboSetCtrls.SetExecMsg(this, "起始日期不能大于终止日期!!");
            return;
        }
        Session["MouldProductRate_BeginDate"]   = BeginDate;
        Session["MouldProductRate_EndDate"]     = EndDate;
        Session["MouldProductRate_MachineNo"]   = ddlMachineNo.SelectedValue.Trim();
        Session["MouldProductRate_MouldNo"]     = ddlMouldNo.SelectedValue.Trim();
        Session["MouldProductRate_ProductNo"]   = ddlProductNo.SelectedValue.Trim();
        Session["MouldProductRate_UserID"] = this.Page.User.Identity.Name.Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=MouldProductRate') </script>");
    }
}
