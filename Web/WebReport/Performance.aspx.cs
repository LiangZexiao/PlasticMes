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
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using System.Collections.Generic;
using Admin.SQLServerDAL.Product_DAL;


public partial class WebReport_Performance : System.Web.UI.Page
{

    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strSeatCode, strBeginDate,strEndDate, strDispatchNo, strUserID, strMachineNo;

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "Performance");
            ViewState["authority"] = o;
            if (o[4]) igbPrint.Visible = false;
            DicInit();
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstrAll() as IList, true, "Machine_MaterialChgAmt", "Remark");

        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            txtBeginDate.Value = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
    }
    private void DicInit()
    {
        this.dicSearch.Add("strSeatCode", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
        this.dicSearch.Add("strDispatchNo", "");
        this.dicSearch.Add("strBc", "");
        this.dicSearch.Add("strUserID", "");
        this.dicSearch.Add("strMachineNo", "");
    }
    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        int flag;
        string BeginDate =this.strBeginDate= txtBeginDate.Value.Trim();
        string EndDate = this.strEndDate = txtEndDate.Value.Trim();
        string ReportName = "Performance";
        Session[ReportName + "_WorkShop"] = ddlMachine_SeatCode.SelectedValue;
        this.strSeatCode = Session[ReportName + "_WorkShop"].ToString().Trim();
        Session[ReportName + "_BeginDate"] = BeginDate;
        Session[ReportName + "_EndDate"] = EndDate;
        string DispatchNo =this.strDispatchNo= txtDispatchNo.Value.Trim();
        Session[ReportName + "_DispatchNo"] = DispatchNo;
        Session[ReportName + "_UserID"] = this.strUserID=this.Page.User.Identity.Name.Trim();
        string MachineNo = this.strMachineNo = txtMachineNo.Value.Trim();
        Session[ReportName + "_MachineNo"] = MachineNo;
        flag = getSearchFlag();
        Session[ReportName + "_Flag"] = flag.ToString().Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=" + ReportName + "') </script>");
    }
    private int getSearchFlag()
    {
        int flag = 1;
        string retValue;

        this.dicSearch.TryGetValue("strSeatCode", out retValue);
        if (this.strSeatCode != retValue)
        {
            this.dicSearch.Remove("strSeatCode");
            this.dicSearch.Add("strSeatCode", strSeatCode);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strBeginDate", out retValue);
        if (this.strBeginDate != retValue)
        {
            this.dicSearch.Remove("strBeginDate");
            this.dicSearch.Add("strBeginDate", strBeginDate);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strDispatchNo", out retValue);
        if (this.strDispatchNo != retValue)
        {
            this.dicSearch.Remove("strDispatchNo");
            this.dicSearch.Add("strDispatchNo", strDispatchNo);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strEndDate", out retValue);
        if (this.strEndDate != retValue)
        {
            this.dicSearch.Remove("strEndDate");
            this.dicSearch.Add("strEndDate", strEndDate);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strUserID", out retValue);
        if (this.strUserID != retValue)
        {
            this.dicSearch.Remove("strUserID");
            this.dicSearch.Add("strUserID", strUserID);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strMachineNo", out retValue);
        if (this.strMachineNo != retValue)
        {
            this.dicSearch.Remove("strMachineNo");
            this.dicSearch.Add("strMachineNo", strMachineNo);
            flag = 0;
        }
        
        return flag;
    }
}
