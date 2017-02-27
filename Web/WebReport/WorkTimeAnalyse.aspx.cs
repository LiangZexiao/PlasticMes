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
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class WebReport_WorkTimeAnalyse : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["ClickMould"] = @"WebReport/WorkTimeAnalyse.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "WorkTimeAnalyse");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            dboSetCtrls.SetDropDownList(ddlPosition, MachineMstr_BLL.selectMachineMstr() as IList, true, "Machine_SeatCode", "Machine_SeatCode");
            dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(ddlPosition.SelectedValue.Trim()) as IList, true, "Machine_Code", "Machine_Code");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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
        Session["WorkTimeAnalyse_BeginDate"] = BeginDate;
        Session["WorkTimeAnalyse_EndDate"]   = EndDate;
        Session["WorkTimeAnalyse_MachineNo"] = ddlMachineNo.SelectedValue.Trim();
        Session["WorkTimeAnalyse_Position"]  = ddlPosition.SelectedValue.Trim();
        Session["WorkTimeAnalyse_UserID"] = this.Page.User.Identity.Name.Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=WorkTimeAnalyse') </script>");
    }
    protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
    {
        dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(ddlPosition.SelectedValue.Trim()) as IList, true, "Machine_Code", "Machine_Code");
    }
}
