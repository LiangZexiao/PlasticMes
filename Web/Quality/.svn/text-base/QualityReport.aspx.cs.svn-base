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

public partial class Quality_QualityReport : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "QualityReport");
            ViewState["authority"] = o;
            if (o[4]) igbPrint.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {            
            dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");
            dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail() as IList, true, "MouldCode", "MouldCode");
            dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, true, "Item_Code", "Item_Code");

            //txtBeginDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            txteDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        string BeginDate = txtbDate.Value.Trim();
        if (string.IsNullOrEmpty(BeginDate))
        {
            dboSetCtrls.SetExecMsg(this, "请输入起始时间!!");
            return;
        }
        string EndDate = (txteDate.Value.Trim() == string.Empty) ? System.DateTime.Now.ToString("yyyy-MM-dd") : txteDate.Value.Trim();

        string bTime = txtbTime.Value.Trim();
        string eTime = txteTime.Value.Trim();

        Session["QualityReport_BeginDate"] = BeginDate + " " + bTime;
        Session["QualityReport_EndDate"] = EndDate + " " + eTime;
        Session["QualityReport_ProductNo"] = ddlProductNo.SelectedValue.Trim();
        Session["QualityReport_MachineNo"] = ddlMachineNo.SelectedValue.Trim();
        Session["QualityReport_MouldNo"] = ddlMouldNo.SelectedValue.Trim();
        Session["QualityReport_UserID"] = this.Page.User.Identity.Name.Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=QualityReport') </script>");
    }
}
