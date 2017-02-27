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

public partial class Quality_QC_ThroughDefect : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private bool flg = false;

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
        Ajax.Utility.RegisterTypeForAjax(typeof(Quality_QC_ThroughDefect));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "QC_ThroughDefect");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
            if (o[5])
            {
                igbCheckYdouble.Visible = false;
            }
            if (o[6]) igbCheckNdouble.Visible = false;

            //暂时屏蔽驳回审核功能待确定是否需要此功能
            igbCheckNdouble.Visible = false;

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
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");

            dboSetCtrls.SetDropDownList(ddlWorker, new CallConfig_DAL().selectEmployee(0, "rank", "5").Tables[0], "EmployeeID", "EmployeeName_CN");//Employee_BLL.selectEmployee(0, "", "") as IList, false, "EmployeeID", "EmployeeName_CN");
        }
    }

    public void BindData(string sortExpression, string sortDirection)
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();

        IList<QC_ThroughDefect_MDL> tempList = QC_ThroughDefect_BLL.selectQCAdjust(0, colname, coltext);
        GridView1.DataSource = SetCtrls.GetDataTableFromIList(tempList, sortExpression, sortDirection);
        GridView1.DataBind();
        //*****************
        flg = true;

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton tempButton = sender as ImageButton;
            int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
            txtMachineNo.Text = txtHiddenMachineNo.Value.Trim();
            txtMouldNo.Text = txtHiddenMouldNo.Value.Trim();
            txtProductNo.Text = txtHiddenProductNo.Value.Trim();
            txtProdDesc.Text = txtHiddenProdDesc.Value.Trim();
            txtTotalQty.Text = txtHiddenTotalQty.Value.Trim();
            txtProductDate.Text = txtHiddenProductDate.Value.Trim();
            txtTime.Text = txtHiddenTime.Value.Trim();

            string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
            string ProductNo = txtDispatchNo.Value.Trim();
            int QueLiaoNum = (TextNumber1.Text.Trim() == "") ? 0 : int.Parse(TextNumber1.Text.Trim());
            int HuaHenNum = (TextNumber2.Text.Trim() == "") ? 0 : int.Parse(TextNumber2.Text.Trim());
            int SeChaNum = (TextNumber3.Text.Trim() == "") ? 0 : int.Parse(TextNumber3.Text.Trim());
            int XiaCiNum = (TextNumber4.Text.Trim() == "") ? 0 : int.Parse(TextNumber4.Text.Trim());
            int QueJiaoNum = (TextNumber5.Text.Trim() == "") ? 0 : int.Parse(TextNumber5.Text.Trim());
            int SuoShuiNum = (TextNumber6.Text.Trim() == "") ? 0 : int.Parse(TextNumber6.Text.Trim());
            int BianXingNum = (TextNumber7.Text.Trim() == "") ? 0 : int.Parse(TextNumber7.Text.Trim());
            int LiaoHuaNum = (TextNumber8.Text.Trim() == "") ? 0 : int.Parse(TextNumber8.Text.Trim());
            int PiFengNum = (TextNumber9.Text.Trim() == "") ? 0 : int.Parse(TextNumber9.Text.Trim());
            int ChicunNum = (TextNumber10.Text.Trim() == "") ? 0 : int.Parse(TextNumber10.Text.Trim());
            int ShaoJiaoNum = (TextNumber11.Text.Trim() == "") ? 0 : int.Parse(TextNumber11.Text.Trim());
            int JiaWenNum = (TextNumber12.Text.Trim() == "") ? 0 : int.Parse(TextNumber12.Text.Trim());
            int KaiLieNum = (TextNumber13.Text.Trim() == "") ? 0 : int.Parse(TextNumber13.Text.Trim());
            int QiTaNum = (TextNumber14.Text.Trim() == "") ? 0 : int.Parse(TextNumber14.Text.Trim());
            string bz = txtMemo.Text.Trim();
            string vtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string vUserID = this.Page.User.Identity.Name.Trim();

            int flages = QC_ThroughDefect_BLL.ChangeQCAdjust(vID, ProductNo, "", QueLiaoNum, HuaHenNum, SeChaNum, XiaCiNum, QueJiaoNum, SuoShuiNum,
                BianXingNum, LiaoHuaNum, PiFengNum, ChicunNum, ShaoJiaoNum, JiaWenNum, KaiLieNum, QiTaNum, vtime, vtime, vUserID, bz, IU);

            if (flages > 0)
            {
                dboSetCtrls.SetExecMsg(this, IU, true);
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "sa", "<script>alert('保存失败！');</script>");
            return;
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

            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            object[] textboxid = { txtProdDesc, txtMouldNo, txtBadQtySum, txtProductNo, txtTotalQty, txtGoodQty, txtMemo };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            //txtProductDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ddlWorker.SelectedIndex  = 0;
            txtDispatchNo.Value = "";
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
        txtBadQtySum.Text = "";
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtID);

        IList<QC_ThroughDefect_MDL> tempIList = QC_ThroughDefect_BLL.selectQCAdjust(Int32.Parse(vID), "", "");
        string DispatchNo = tempIList[0].DispatchNo;

        string ProducedNum = "0";
        string strSQL = "select isnull(dbo.GetProdNum('" + DispatchNo + "','',''),0) as ProducedNum ";
        DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
        if (dtTmp != null)
        {
            ProducedNum = dtTmp.Rows[0]["ProducedNum"].ToString();
        }
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "DO_No", DispatchNo);
        txtDispatchNo.Value = DispatchNo;
        for (int t = 0; t < tempList.Count; t++)
        {
            txtProductNo.Text = tempList[0].ProductNo;
            txtProdDesc.Text = tempList[0].ProductDesc;
            txtMouldNo.Text = tempList[0].MouldNo;
            txtMachineNo.Text = tempList[0].MachineNo;
            txtTotalQty.Text = tempList[0].DispatchNum;
            txtProductDate.Text = tempList[0].ActualStartDate == "" ? "" : Convert.ToDateTime(tempList[0].ActualStartDate).ToString("yyyy-MM-dd");
            txtTime.Text = tempList[0].ActualStartDate == "" ? "" : Convert.ToDateTime(tempList[0].ActualStartDate).ToString("HH:mm");
        }
        TextNumber1.Text = tempIList[0].QueLiaoNum;
        TextNumber2.Text = tempIList[0].HuaHenNum;
        TextNumber3.Text = tempIList[0].SeChaNum;
        TextNumber4.Text = tempIList[0].XiaCiNum;
        TextNumber5.Text = tempIList[0].QueJiaoNum;
        TextNumber6.Text = tempIList[0].SuoShuiNum;
        TextNumber7.Text = tempIList[0].BianXingNum;
        TextNumber8.Text = tempIList[0].LiaoHuaNum;
        TextNumber9.Text = tempIList[0].PiFengNum;
        TextNumber10.Text = tempIList[0].ChicunNum;
        TextNumber11.Text = tempIList[0].ShaoJiaoNum;
        TextNumber12.Text = tempIList[0].JiaWenNum;
        TextNumber13.Text = tempIList[0].KaiLieNum;
        TextNumber14.Text = tempIList[0].QiTaNum;
        txtMemo.Text = tempIList[0].bz;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
        //********************************2016/10/8
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string temp = "";
            for (int i = 0; i < ((DataRowView)e.Row.DataItem).Row.ItemArray.Length; i++)
            {
                temp += ((DataRowView)e.Row.DataItem).Row.ItemArray[i].ToString();
                temp += ",";
            }
            e.Row.Attributes.Add("ondblclick", "window.open('../zhEcharts/CiPin.aspx?temp=" + temp + "','_blank','height=600, width=800, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no')");
        }
        //*********************************2016/10/8
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

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = row.FindControl("chkItemInner") as CheckBox;
                if (chk.Checked)
                {
                    string strSQL = "select ID,DispatchNo,Confirm from QCAdjust_Vice where ID={0}";
                    strSQL = string.Format(strSQL, ((row.Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim());
                    DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                    if (dtTmp != null && dtTmp.Rows[0]["Confirm"].ToString() != "")
                    {
                        dboSetCtrls.SetExecMsg(this, "工单号:" + dtTmp.Rows[0]["DispatchNo"].ToString() + "已审核，不能删除!");
                        return;
                    }
                    pIDList.Add(((row.Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim());
                }
            }
            if (tempButton.ID == "igbDelete")
            {
                QC_ThroughDefect_BLL.cancelQCAdjust(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                QC_ThroughDefect_BLL.cancelQCAdjust(pIDList);
                BindData(GridViewSortExpression, (GridViewSortDirection == SortDirection.Ascending) ? "Asc" : "Desc");
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }
    #region
    [Ajax.AjaxMethod()]
    public ArrayList getSearchDispatchNo(string dispatchno)
    {
        ArrayList retItems = new ArrayList();
        string ProducedNum = "0";
        string strSQL = "select isnull(dbo.GetProdNum('" + dispatchno + "','',''),0) as ProducedNum ";
        DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
        if (dtTmp != null)
        {
            ProducedNum = dtTmp.Rows[0]["ProducedNum"].ToString();
        }
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "DO_No", dispatchno);

        for (int t = 0; t < tempList.Count; t++)
        {
            retItems.Add(tempList[t].DO_No.Trim());
            retItems.Add(tempList[t].ProductNo.Trim());
            retItems.Add(tempList[t].ProductDesc.Trim());
            retItems.Add(tempList[t].MouldNo.Trim());
            retItems.Add(tempList[t].MachineNo.Trim());
            retItems.Add(ProducedNum);
            retItems.Add(tempList[t].ActualStartDate == "" ? "" : Convert.ToDateTime(tempList[t].ActualStartDate).ToString("yyyy-MM-dd"));
            retItems.Add(tempList[t].ActualStartDate == "" ? "" : Convert.ToDateTime(tempList[t].ActualStartDate).ToString("HH:mm"));
            retItems.Add(tempList[t].BadQty.Trim());
        }
        return retItems;
    }
    #endregion
    protected void btnCheck_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tmpImageButton = sender as ImageButton;
        ArrayList pIDList = new ArrayList();

        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chk = row.FindControl("chkItemInner") as CheckBox;
            if (chk.Checked)
            {
                pIDList.Add(((row.Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim());
            }
        }
        try
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (pIDList.Count == 0)
            {
                dboSetCtrls.SetExecMsg(this, "没记录,不可审核");
                return;
            }
            string strFlag = (tmpImageButton.ID == "igbCheckNdouble" || tmpImageButton.ID == "igbCheckNsingle") ? "0" : "1";
            string strUserID = this.Page.User.Identity.Name.Trim();

            QC_ThroughDefect_BLL.checkQCAdjust_Vice(strFlag, strUserID, pIDList);
            dboSetCtrls.SetExecMsg(this, "check", true);
            BindData(GridViewSortExpression, (GridViewSortDirection == SortDirection.Ascending) ? "Asc" : "Desc");
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "check", false);
        }
        finally
        {
            tmpImageButton = null;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
       
    }
}
