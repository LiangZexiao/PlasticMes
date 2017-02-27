﻿using System;
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
using Admin.SQLServerDAL.Product_DAL;

public partial class WebReport_MoldCycleDetail : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strDispatchNo, strMachineNo, strUserID, strBeginDate, strEndDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(WebReport_MoldCycleDetail));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MoldCycleDetail");
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
            //dboSetCtrls.SetDropDownList(ddlDispatchOrder, DispatchOrder_BLL.selectDispatchOrder("0","0") as IList, true, "Machine_Code", "Machine_Code");
           // dboSetCtrls.SetDropDownList(ddlDispatchOrder, DispatchOrder_BLL.selectDispatchOrder(0,"","") as IList, true, "DO_NO", "DO_NO");
            //dboSetCtrls.SetDropDownList(ddlMouldNo, MouldMstr_JH_BLL.selectMouldDetail(0, "", "") as IList, true, "Mould_Code", "Mould_Code");
            //dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_JH_BLL.selectItemMstr(0, "", "") as IList, true, "Item_Code", "Item_Code");
            txtBeginDate.Value = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            search.Value = "";
            this.search.Disabled = false;
            //dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstrAll() as IList, true, "Machine_MaterialChgAmt", "Remark");
        }
    }

    private void DicInit()
    {
        this.dicSearch.Add("strDispatchNo", "");
        this.dicSearch.Add("strMachineNo", "");
        this.dicSearch.Add("strUserID", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
    }

    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        int flag;
        if (search.Value.Trim() == "" && txtMachineNo.Value.Trim() == "")
        {
            dboSetCtrls.SetExecMsg(this, "必须输入派工单号或者机器编号!");
            search.Focus();
            return;
        }
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
        TimeSpan timespan = Convert.ToDateTime(EndDate).Subtract(Convert.ToDateTime(BeginDate));
        if (timespan.Days>7)
        {
            dboSetCtrls.SetExecMsg(this, "查询的生产日期不能超过7天!");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            txtBeginDate.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm");
            return;
        }

        string ReportName = "CycleDetail";//CycleDetail
        Session[ReportName + "_BeginDate"] = BeginDate;
        this.strBeginDate = Session[ReportName + "_BeginDate"].ToString().Trim();
        Session[ReportName + "_EndDate"] = EndDate ;
        this.strEndDate = Session[ReportName + "_EndDate"].ToString().Trim();
        Session[ReportName + "_DisparchOrder"] = search.Value.Trim();//ddlDispatchOrder.SelectedValue.Trim();
        this.strDispatchNo = Session[ReportName + "_DisparchOrder"].ToString().Trim();
        //string SeatCode = ddlMachine_SeatCode.SelectedValue.Trim();
        //Session[ReportName + "_SeatCode"] = SeatCode;
        //this.strSeatCode = SeatCode;
        string MachineNo = txtMachineNo.Value.Trim();
        Session[ReportName + "_MachineNo"] = MachineNo; 
        Session[ReportName + "_UserID"] = this.Page.User.Identity.Name.Trim();
        this.strUserID = this.Page.User.Identity.Name.Trim();
        flag = getSearchFlag();
        Session[ReportName + "_Flag"] = flag.ToString().Trim();

        //this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
        // @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=MoldCycleDetail') </script>");
        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=" + ReportName + "') </script>");
    }

    private int getSearchFlag()
    {
        int flag =1;
        string retValue;

        this.dicSearch.TryGetValue("strDispatchNo", out retValue);
        if (this.strDispatchNo != retValue)
        {
            this.dicSearch.Remove("strDispatchNo");
            this.dicSearch.Add("strDispatchNo", strDispatchNo);
            flag =0;
        }
        this.dicSearch.TryGetValue("strMachineNo", out retValue);
        if (this.strMachineNo != retValue)
        {
            this.dicSearch.Remove("strMachineNo");
            this.dicSearch.Add("strMachineNo", strMachineNo);
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

    #region //派工单号
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhDoNo(string str)
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
