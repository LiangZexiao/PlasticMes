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
using Admin.SQLServerDAL.Product_DAL;
using System.Collections.Generic;

public partial class WebReport_QualityForDay : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strWorkOrderNo, strDispatchNo, strSeatCode, strUserID, strBeginDate, strEndDate;

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "QualityForDay");
            ViewState["authority"] = o;
            if (o[4]) igbPrint.Visible = false;
            DicInit();
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            txtBeginDate.Value = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //dboSetCtrls.SetDropDownList(ddlWorkOrderNo, DispatchOrder_BLL.QueryWorkOrder() as IList, false, "WorkOrderNo", "WorkOrderNo");
            //dboSetCtrls.SetDropDownList(ddlDispatchOrder, DispatchOrder_BLL.selectDispatchOrder(0, "", "") as IList, false, "DO_No", "DO_No");
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstrAll() as IList, true, "Machine_MaterialChgAmt", "Remark");
        }
    }
    private void DicInit()
    {
        this.dicSearch.Add("strWorkOrderNo", "");
        this.dicSearch.Add("strDispatchNo", "");
        this.dicSearch.Add("strSeatCode", "");
        this.dicSearch.Add("strUserID", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
    }

    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        int flag;
        string BeginDate = txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim() ;

        string workorderno=txtWorkOrderNo.Value.Trim();
        string dispatchorder=txtDispatchOrder.Value.Trim();

        //if (workorderno != "" && dispatchorder == "")
        //{
        //    string prode= DispatchOrder_BLL.selectDispatchOrder(0, "WorkOrderNo", workorderno)[0]
        //}
        string ReportName = "QuilityForDay";
        Session[ReportName + "_WorkOrderNo"] = workorderno;
        this.strWorkOrderNo = Session[ReportName + "_WorkOrderNo"].ToString().Trim();
        Session[ReportName + "_DispatchOrder"] = dispatchorder;
        this.strDispatchNo = Session[ReportName + "_DispatchOrder"].ToString().Trim(); 
        string SeatCode = ddlMachine_SeatCode.SelectedValue.Trim();
        Session[ReportName + "_SeatCode"] = SeatCode;
        this.strSeatCode = SeatCode;
        Session[ReportName + "_BeginDate"] = BeginDate;
        this.strBeginDate = BeginDate;
        Session[ReportName + "_EndDate"] = EndDate;
        this.strEndDate = EndDate;
        Session[ReportName + "_UserID"] = this.Page.User.Identity.Name.Trim();
        this.strUserID = Session[ReportName + "_UserID"].ToString().Trim();
        flag = getSearchFlag();
        Session[ReportName + "_Flag"] = flag.ToString().Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=" + ReportName + "') </script>");
    }
    private int getSearchFlag()
    {
        int flag = 1;
        string retValue;

        this.dicSearch.TryGetValue("strWorkOrderNo", out retValue);
        if (this.strWorkOrderNo != retValue)
        {
            this.dicSearch.Remove("strWorkOrderNo");
            this.dicSearch.Add("strWorkOrderNo", strWorkOrderNo);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strDispatchNo", out retValue);
        if (this.strDispatchNo != retValue)
        {
            this.dicSearch.Remove("strDispatchNo");
            this.dicSearch.Add("strDispatchNo", strDispatchNo);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strSeatCode", out retValue);
        if (this.strSeatCode != retValue)
        {
            this.dicSearch.Remove("strSeatCode");
            this.dicSearch.Add("strSeatCode", strSeatCode);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strUserID", out retValue);
        if (this.strUserID != retValue)
        {
            this.dicSearch.Remove("strUserID");
            this.dicSearch.Add("strUserID", strUserID);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strBeginDate", out retValue);
        if (this.strBeginDate != retValue)
        {
            this.dicSearch.Remove("strBeginDate");
            this.dicSearch.Add("strBeginDate", strBeginDate);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strEndDate", out retValue);
        if (this.strEndDate != retValue)
        {
            this.dicSearch.Remove("strEndDate");
            this.dicSearch.Add("strEndDate", strEndDate);
            flag = 0;
        }
        return flag;
    }

}
