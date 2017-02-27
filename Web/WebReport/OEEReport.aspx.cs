using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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

public partial class WebReport_OEEReport : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strMachineNo,strBeginDate, strEndDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(WebReport_OEEReport));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "OEEReport");
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
            //dboSetCtrls.SetDropDownList(ddlMachineNo, new SuitManage_DAL().selectSuitManage(0) as IList, true, "PlantBristlesCode", "PlantBristlesCode");
        }
    }
    private void DicInit()
    {
        this.dicSearch.Add("strMachineNo", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
    }

    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        int flag;
        string BeginDate = txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim();

        string ReportName = "OEEReport";
        Session[ReportName + "_MachineNo"] = search.Value.Trim() == "" ? "全部" : search.Value.Trim();
        this.strMachineNo = Session[ReportName + "_MachineNo"].ToString().Trim();
        Session[ReportName + "_ProductNo"] = "";
        Session[ReportName + "_WorkShopNo"] = "全部";
        Session[ReportName + "_BeginDate"] = BeginDate;
        this.strBeginDate = Session[ReportName + "_BeginDate"].ToString().Trim();
        Session[ReportName + "_EndDate"] = EndDate;
        this.strEndDate = Session[ReportName + "_EndDate"].ToString().Trim();
        flag = getSearchFlag();
        Session[ReportName + "_Flag"] = flag.ToString().Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=" + ReportName + "') </script>");
    }
    private int getSearchFlag()
    {
        int flag = 1;
        string retValue;

        this.dicSearch.TryGetValue("strMachineNo", out retValue);
        if (this.strMachineNo != retValue)
        {
            this.dicSearch.Remove("strMachineNo");
            this.dicSearch.Add("strMachineNo", strMachineNo);
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

    #region //给工单号和派工单号赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str)
    {
        ArrayList itmes = new ArrayList();

        IList<MachineMstr_MDL> tempList = MachineMstr_BLL.selectMachineMstr(0, "Machine_Code", str);
        for (int t = 0; t < (tempList.Count > 50 ? 50 : tempList.Count); t++)
        {
            itmes.Add(tempList[t].Machine_Code);
        }
        return itmes;
    }
    #endregion
}
