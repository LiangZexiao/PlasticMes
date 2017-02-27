using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Admin.BLL.Machine_BLL;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.Product_BLL;
using Admin.Model.Product_MDL;
using Admin.BLL.Quality_BLL;
using Admin.Model.Quality_MDL;
using Admin.BLL.Collect_BLL;
using Admin.Model.Machine_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Call_DAL;
using Admin.DBUtility;
using Admin.SQLServerDAL.BaseInfo_DAL;

public partial class Product_AdjustMachine : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    public SortDirection GridViewSortDirection
    {
        get { return (ViewState["sortDirection"] == null) ? SortDirection.Ascending : (SortDirection)ViewState["sortDirection"]; }
        set { ViewState["sortDirection"] = value; }
    }

    private string GridViewSortExpression
    {
        get { return (ViewState["sortExpression"] == null) ? "DispatchNo" : ViewState["sortExpression"].ToString().Trim(); }
        set { ViewState["sortExpression"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Product_AdjustMachine));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "AdjustMachine");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            BindData(GridViewSortExpression, "ASC");
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            IList<StopReason_MDL> ListStop=new StopReason_DAL().selectStopReason();
            dboSetCtrls.SetDropDownList(ddlWorker, new CallConfig_DAL().selectEmployee(0, "rankdesc", "机修").Tables[0], "EmployeeID", "EmployeeName_CN");
            dboSetCtrls.SetDropDownList(ddlStopMachine, new StopReason_DAL().selectStopReason2() as IList, true, "ReasonID", "ReasonName");
        }
    }

    public void BindData(string sortExpression, string sortDirection)
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        if (inStartDate.Value.ToString().Trim() == string.Empty) inStartDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (inEndDate.Value.ToString().Trim() == string.Empty) inEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string BeginDate = inStartDate.Value.Trim() ;
        string EndDate = inEndDate.Value.Trim() ;

        IList<AdjustMachine_MDL> tempList = AdjustMachine_BLL.selectAdjustMachine(0, colname, coltext, BeginDate, EndDate);
        GridView1.DataSource = SetCtrls.GetDataTableFromIList(tempList, sortExpression, sortDirection);
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        txtMachineNo.Text = txtHiddenMachineNo.Value.Trim();
        txtMouldNo.Text = txtHiddenMouldNo.Value.Trim();
        txtProductNo.Text = txtHiddenProductNo.Value.Trim();
        txtProdDesc.Text = txtHiddenProdDesc.Value.Trim(); 

        string vDispatchNo = txtDispatchNo.Value.Trim();
        string vWorkOrderNo = vDispatchNo.Substring(0, vDispatchNo.Length - 3);
        string vMachineNo = txtMachineNo.Text.Trim();
        string vMouldNo = txtMouldNo.Text.Trim();
        string vProductNo = txtProductNo.Text.Trim();
        string vTotalQty = (txtTotalQty.Text.Trim() == "") ? "0" : txtTotalQty.Text.Trim();
        string vStartDate = txtStartDate.Value.Trim();
        string vEndDate = txtEndDate.Value.Trim();
        string vProductDesc = txtProdDesc.Text.Trim();
        string vModiHistoryContent = txtModiHistoryContent.Text.Trim();
        string vWorker = ddlWorker.SelectedValue.Trim();
        string vEmpName = ddlWorker.SelectedItem.Text.Trim();
        string vCardType = ddlStopMachine.SelectedValue.Trim();
        string vCardValue = ddlStopMachine.SelectedItem.Text.Trim();
        string vUserID = this.Page.User.Identity.Name.Trim();
        string vtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string vMemo = txtMemo.Text.Trim();


        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        if (IU == "INSERT")
        {
            string strSQL = @"select DispatchNo from tblAdjustMachine 
                      where DispatchNo='{0}' and startdate<='{1}' and '{2}'<=enddate ";
            strSQL = string.Format(strSQL, vDispatchNo, vStartDate, vEndDate);
            DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                dboSetCtrls.SetExecMsg(this, "此工单在你所选择的时间段已经存在，时间段不能重叠！");
                return;
            }
        }
        if (IU == "UPDATE")
        {
            ArrayList myArrListNew = new ArrayList();
            ArrayList MyItemMstrName = new ArrayList();
            ArrayList myArrListOld = Session["AdjustMachinemyArrListOld"] as ArrayList;
            MyItemMstrName.Add("派工单号:");
            MyItemMstrName.Add("产品编号:");
            MyItemMstrName.Add("模具编号:");
            MyItemMstrName.Add("机器编号:");
            MyItemMstrName.Add("调机人:");
            MyItemMstrName.Add("调机良品数:");
            MyItemMstrName.Add("调机开始时间:");
            MyItemMstrName.Add("调机结束时间:");
            MyItemMstrName.Add("备注:");
            MyItemMstrName.Add("调机原因:");

            myArrListNew.Add(vDispatchNo);
            myArrListNew.Add(vProductNo);
            myArrListNew.Add(vMouldNo);
            myArrListNew.Add(vMachineNo);
            myArrListNew.Add(vEmpName);
            myArrListNew.Add(vTotalQty);
            myArrListNew.Add(vStartDate);
            myArrListNew.Add(vEndDate);
            myArrListNew.Add(vMemo);
            myArrListNew.Add(vCardValue);  

            string vModiHistoryContentx = "";
            for (int i = 0; i < myArrListOld.Count; i++)
            {
                if (myArrListOld[i].ToString() != myArrListNew[i].ToString())
                {
                    vModiHistoryContentx += MyItemMstrName[i].ToString() + myArrListOld[i].ToString() + "-->" + myArrListNew[i].ToString() + ((i == myArrListNew.Count - 1) ? "；" : ",");
                }
            }
            if (vModiHistoryContentx != "")
            {
                vModiHistoryContentx = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 用户:" + this.Page.User.Identity.Name.Trim() + "修改的记录如下： " + vModiHistoryContentx;
                string strstr = vModiHistoryContentx + vModiHistoryContent;
                vModiHistoryContent = strstr;
            }
            if (vModiHistoryContent.Length > 8000)
            {
                vModiHistoryContent = vModiHistoryContent.Substring(0, 7990).ToString();
            }
            txtModiHistoryContent.Text = vModiHistoryContent;
        }

        try
        {
            int flages = AdjustMachine_BLL.ChangeAdjustMachine(vID, vWorkOrderNo, vDispatchNo, vTotalQty,
                        vMachineNo, vMouldNo, vProductNo, vStartDate, vEndDate, vProductDesc, vWorker, vUserID
                        , vtime, vMemo, vModiHistoryContent,vCardType, IU);
            if (flages > 0)
            {
                dboSetCtrls.SetExecMsg(this, IU, true);
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
     }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                pIDList.Add(txtID.Text.Trim());
                AdjustMachine_BLL.cancelAdjustMachine(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                AdjustMachine_BLL.cancelAdjustMachine(pIDList);
                BindData(GridViewSortExpression, (GridViewSortDirection == SortDirection.Ascending) ? "Asc" : "Desc");
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }

    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtID);
            igbDelete.Enabled = true;

            object[] textboxid = { txtProdDesc, txtMouldNo, txtProductNo, txtTotalQty, txtMemo };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            txtStartDate.Value = "";
            txtDispatchNo.Value = "";
            txtEndDate.Value = "";
            txtModiHistoryContent.Text = "";
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData(GridViewSortExpression, (GridViewSortDirection == SortDirection.Ascending) ? "Asc" : "Desc");
        }
    }

    protected void CtrlPageInfo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempImageButton = sender as ImageButton;
        if (tempImageButton.ID == "igbSearch")
        {
            string strPageIndex = txtPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView1.PageIndex = int.Parse(strPageIndex) - 1;
        }
        else
            GridView1.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
        BindData(GridViewSortExpression, (GridViewSortDirection == SortDirection.Ascending) ? "Asc" : "Desc");
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        string vCmd = e.CommandName.Trim();

        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtID);

        IList<AdjustMachine_MDL> tempIList = AdjustMachine_BLL.selectAdjustMachine(Int32.Parse(vID), "", "", "", "");
        ArrayList myArrListOld = new ArrayList();
        myArrListOld.Add(tempIList[0].DispatchNo);
        myArrListOld.Add(tempIList[0].ProductNo);
        myArrListOld.Add(tempIList[0].MouldNo);
        myArrListOld.Add(tempIList[0].MachineNo);
        myArrListOld.Add(tempIList[0].EmpName);
        myArrListOld.Add(tempIList[0].TotalQty);
        myArrListOld.Add(tempIList[0].StartDate);
        myArrListOld.Add(tempIList[0].EndDate);
        myArrListOld.Add(tempIList[0].Remark);
        myArrListOld.Add(tempIList[0].ReasonName);
        Session["AdjustMachinemyArrListOld"] = myArrListOld;

        txtDispatchNo.Value = tempIList[0].DispatchNo;
        txtProductNo.Text = tempIList[0].ProductNo;
        txtProdDesc.Text = tempIList[0].ProductDesc;
        txtMouldNo.Text = tempIList[0].MouldNo;
        txtMachineNo.Text = tempIList[0].MachineNo;
        ddlWorker = dboSetCtrls.SetSelectedIndex(ddlWorker, tempIList[0].AdjustMan);
        ddlStopMachine = dboSetCtrls.SetSelectedIndex(ddlStopMachine, tempIList[0].CardType);
        txtTotalQty.Text = tempIList[0].TotalQty;
        txtMemo.Text = tempIList[0].Remark;
        txtStartDate.Value =tempIList[0].StartDate==""?"": Convert.ToDateTime(tempIList[0].StartDate).ToString("yyyy-MM-dd HH:mm:ss");
        txtEndDate.Value =tempIList[0].EndDate==""?"": Convert.ToDateTime(tempIList[0].EndDate).ToString("yyyy-MM-dd HH:mm:ss");
        txtModiHistoryContent.Text = tempIList[0].ModiHistoryContent;

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            BindData(sortExpression, "DESC");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            BindData(sortExpression, "ASC");
        }
        GridViewSortExpression = sortExpression;
    }

    #region
    [Ajax.AjaxMethod()]
    public ArrayList getSearchDispatchNo(string dispatchno)
    {
        ArrayList retItems = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "DO_No", dispatchno);

        for (int t = 0; t < tempList.Count; t++)
        {
            retItems.Add(tempList[t].DO_No.Trim());
            retItems.Add(tempList[t].ProductNo.Trim());
            retItems.Add(tempList[t].ProductDesc.Trim());
            retItems.Add(tempList[t].MouldNo.Trim());
            retItems.Add(tempList[t].MachineNo.Trim());
            retItems.Add(tempList[t].DispatchNum.Trim());
        }
        return retItems;
    }
    #endregion
}