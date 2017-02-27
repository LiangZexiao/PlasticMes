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
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Product_DAL;
using Admin.Model.Product_MDL;

public partial class WebReport_RptDispatchHistory : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strDispatchNo,strMachineNo, strSeatCode, strUserID, strBeginDate, strEndDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(WebReport_RptDispatchHistory));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "RptDispatchHistory");
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
            //dboSetCtrls.SetDropDownList(ddlWorkOrderNo, DispatchOrder_BLL.QueryWorkOrder() as IList,false, "WorkOrderNo", "WorkOrderNo");
            //dboSetCtrls.SetDropDownList(ddlDispatchOrder, DispatchOrder_BLL.selectDispatchOrder(0, "", "") as IList, false, "DO_No", "DO_No");
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstrAll() as IList, true, "Machine_MaterialChgAmt", "Remark");
        }
    }
    private void DicInit()
    {
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
        string EndDate = txtEndDate.Value.Trim();
        string SeatCode = ddlMachine_SeatCode.SelectedValue.Trim();

        string ReportName = "RptDispatchHistory";
        Session[ReportName + "_MachineNo"] = txtMachineNo.Value.Trim();
        Session[ReportName + "_DispatchOrder"] = search.Value.Trim() ;
        this.strDispatchNo = Session[ReportName + "_DispatchOrder"].ToString().Trim();
        this.strMachineNo = Session[ReportName + "_MachineNo"].ToString().Trim();
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

        this.dicSearch.TryGetValue("strDispatchNo", out retValue);
        if (this.strDispatchNo != retValue)
        {
            this.dicSearch.Remove("strDispatchNo");
            this.dicSearch.Add("strDispatchNo", strDispatchNo);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strMachineNo", out retValue);
        if (this.strMachineNo != retValue)
        {
            this.dicSearch.Remove("strMachineNo");
            this.dicSearch.Add("strMachineNo", strMachineNo);
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
   
    #region //给工单号和派工单号赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str)
    {
        ArrayList itmes = new ArrayList();

        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "", "DO_NO", str);
        for (int t = 0; t < tempList.Count; t++)
        {
            itmes.Add(tempList[t].DO_No);
        }


        return itmes;
    }
    #endregion

    #region 给车间赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSeatCode(string str)
    {
        ArrayList items = new ArrayList();
        if (str.Substring(str.Length - 3, 1) == "0")
        {
            IList<MachineMstr_MDL> templist = new MachineSuit_DAL().selectMachineMstrAll();
            for (int i = 0; i < templist.Count; i++)
            {
                items.Add(templist[i].Remark + "," + templist[i].Machine_MaterialChgAmt);
            }
        }
        else
        {
            IList<MachineSuit_MDL> templistx = new MachineSuit_DAL().getMachineNo();
            for (int i = 0; i < templistx.Count; i++)
            {
                items.Add(templistx[i].MachineCode + "," + templistx[i].MachineType);
            }
        }
        return items;
    }
    #endregion
}
