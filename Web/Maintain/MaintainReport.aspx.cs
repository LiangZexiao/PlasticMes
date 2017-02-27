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
using System.Collections.Generic;

public partial class Maintain_MaintainReport : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strDeviceType, strDeviceNo, strUserID, strBeginDate, strEndDate;
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MaintainReport");
            ViewState["authority"] = o;

            if (o[4]) igbPrint.Visible = false;
            DicInit();
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!this.IsPostBack)
        {
            //txtStartDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            SetDeviceNo();
        }
    }
    private void DicInit()
    {
        this.dicSearch.Add("strDeviceType", "");
        this.dicSearch.Add("strDeviceNo", "");
        this.dicSearch.Add("strUserID", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
    }

    protected void ddlDeviceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetDeviceNo();
    }

    private void SetDeviceNo()
    {
        string DeviceType = ddlDeviceType.SelectedValue.Trim();
        if (DeviceType != "3")
        {
            ddlDeviceNo.Visible = true; txtDeviceNo.Visible = false;
            ddlDeviceNo.Items.Clear();
            if (DeviceType == "1")
                dboSetCtrls.SetDropDownList(ddlDeviceNo, MachineMstr_BLL.selectMachineMstr(0,"","") as IList, true, "Machine_Code", "Machine_Code");
            else
                dboSetCtrls.SetDropDownList(ddlDeviceNo, MouldDetail_BLL.selectMouldDetail(0, "", "") as IList, true, "MouldCode", "MouldCode");
        }
        else
        {
            ddlDeviceNo.Visible = false; 
            txtDeviceNo.Visible = true;
            txtDeviceNo.Text = null;
        }
    }
    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        string BeginDate = txtStartDate.Value.Trim();
        int flag;

        string ReportName = "MaintainReport";
        if (string.IsNullOrEmpty(BeginDate))
        {
            dboSetCtrls.SetExecMsg(this, "startdate", true);
            return;
        }
        string EndDate = (txtEndDate.Value.Trim() == string.Empty) ? System.DateTime.Now.ToString("yyyy-MM-dd") : txtEndDate.Value.Trim();

        Session["MaintainReport_BeginDate"] = BeginDate;
        this.strBeginDate = BeginDate;
        Session["MaintainReport_EndDate"] = EndDate;
        this.strEndDate = EndDate;
        Session["MaintainReport_DeviceType"] = ddlDeviceType.SelectedValue.ToString().Trim();
        this.strDeviceType = ddlDeviceType.SelectedValue.ToString().Trim();
        Session["MaintainReport_DeviceNo"] = ddlDeviceNo.SelectedValue.ToString().Trim();
        this.strDeviceNo = ddlDeviceNo.SelectedValue.ToString().Trim();
        Session["MaintainReport_UserID"] = this.Page.User.Identity.Name.Trim();
        this.strUserID = this.Page.User.Identity.Name.Trim();
        flag = getSearchFlag();
        Session[ReportName + "_Flag"] = flag.ToString().Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=" + ReportName + "') </script>");
    }

    private int getSearchFlag()
    {
        int flag = 1;
        string retValue;

        this.dicSearch.TryGetValue("strDeviceType", out retValue);
        if (this.strDeviceType != retValue)
        {
            this.dicSearch.Remove("strDeviceType");
            this.dicSearch.Add("strDeviceType", strDeviceType);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strDeviceNo", out retValue);
        if (this.strDeviceNo != retValue)
        {
            this.dicSearch.Remove("strDeviceNo");
            this.dicSearch.Add("strDeviceNo", strDeviceNo);
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
