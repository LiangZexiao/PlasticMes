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
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.Product_BLL;
using Admin.App_Code;
using System.Collections.Generic;

public partial class WebReport_SMSDetail : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strUserID, strBeginDate, strEndDate;

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "SMSDetail");
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
        }
    }
    private void DicInit()
    {
        this.dicSearch.Add("strUserID", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
    }

    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        int flag;
        string BeginDate = txtBeginDate.Value.Trim();
        if (string.IsNullOrEmpty(BeginDate))
        {
            dboSetCtrls.SetExecMsg(this, "startdate", true);
            return;
        }
        string EndDate = (txtEndDate.Value.Trim() == string.Empty) ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") : txtEndDate.Value.Trim();
        if (dboSetCtrls.CheckDateTime("string", BeginDate, EndDate))
        {
            dboSetCtrls.SetExecMsg(this, "起始日期不能大于终止日期!!");
            return;
        }
        string ReportName = "SMSDetail";
        Session[ReportName + "_bDate"] = txtBeginDate.Value.Trim();
        this.strBeginDate = Session[ReportName + "_bDate"].ToString().Trim();
        Session[ReportName + "_eDate"] = txtEndDate.Value.Trim();
        this.strEndDate = Session[ReportName + "_eDate"].ToString().Trim();
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
