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

public partial class Quality_QC_Table : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(Quality_QC_Table));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);

            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "QC_Table");
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
            // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            // dboSetCtrls.SetDropDownList(ddlWorkOrderNo, WorkOrder_BLL.selectWorkOrder(0, "1", "", "") as IList, false, "Wo_No", "Wo_No");
   
            dboSetCtrls.SetDropDownList(ddlWorker, new CallConfig_DAL().selectEmployee(0, "rank", "5").Tables[0], "EmployeeID", "EmployeeName_CN");//Employee_BLL.selectEmployee(0, "", "") as IList, false, "EmployeeID", "EmployeeName_CN");
            dboSetCtrls.SetDropDownList(ddlBadReason, BadReason_BLL.selectBadReason() as IList, false, "ReasonID", "IMReasonName");
            // txtCheckDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");

            //this.txtProductDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    public void BindData(string sortExpression, string sortDirection)
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();

        IList<QC_Table_MDL> tempList = QC_Table_BLL.selectQC_Table(0, colname, coltext);
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
        txtTotalQty.Text = txtHiddenTotalQty.Value.Trim();
        txtProductDate.Text = txtHiddenProductDate.Value.Trim();
        txtTime.Text  = txtHiddenTime.Value.Trim();

        string vDispatchNo = txtDispatchNo.Value.Trim();
        string vWorkOrderNo = vDispatchNo.Substring(0, vDispatchNo.Length - 3);
        string vMachineNo = txtMachineNo.Text.Trim();
        string vMouldNo = txtMouldNo.Text.Trim();
        string vProductNo = txtProductNo.Text.Trim();
        string vTotalQty = (txtTotalQty.Text.Trim() == "") ? "0" : txtTotalQty.Text.Trim();

        string vGoodQty = (txtGoodQty.Text.Trim() == "") ? "0" : txtGoodQty.Text.Trim();
        string vProductDate = txtProductDate.Text.Trim()+" "+txtTime.Text.Trim();
        string vProductDesc = txtProdDesc.Text.Trim();
        decimal vSourceBadNum=0, vDesBadNum=0;
        string vWorker = ddlWorker.SelectedValue.Trim();
        string vUserID = this.Page.User.Identity.Name.Trim();
        string vtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string vMemo = txtMemo.Text.Trim();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        int xid = 0;
        int yid = 0;
        if (IU == "UPDATE")
        {
            ArrayList myArrListOld = Session["QcArrListOld"] as ArrayList;
            vDesBadNum += Convert.ToDecimal(txtBadQty.Text.Trim() == "" ? "0" : txtBadQty.Text.Trim());
            for (int i = 0; i < myArrListOld.Count; i++)
            {
                vSourceBadNum+= Convert.ToDecimal(myArrListOld[i].ToString());
            }
            txtBadQtySum.Text = txtBadQtySum.Text.Trim() == "" ? "0" : txtBadQtySum.Text.Trim();
            txtBadQtySum.Text = Convert.ToString(Convert.ToDecimal(txtBadQtySum.Text.Trim()) + (vDesBadNum - vSourceBadNum));
            txtGoodQty.Text = Convert.ToString(Convert.ToDecimal(vTotalQty) - Convert.ToDecimal(txtBadQtySum.Text.Trim()));
        }
  
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                //if (QC_Table_BLL.existsQC_Table("DispatchNo", vDispatchNo).Count > 0)
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "sa", "<script>alert('保存失败,存在此派工单记录！');</script>");
                //    return;
                //}
            }
            if (tempButton.ID != "igbInsert" && GridView2.Visible)
            {
                int vDetailID = (txtDetailID.Text.Trim() == "") ? 0 : int.Parse(txtDetailID.Text.Trim());
                string vBadReason = ddlBadReason.SelectedValue.Trim();
                int vBadQty = (txtBadQty.Text.Trim() == "") ? 0 : int.Parse(txtBadQty.Text.Trim());
                //int t = QC_Table_BLL.QC_TableDetail(0, vID, vDispatchNo, vBadReason, vBadQty);
                string badqtysums = (txtBadQtySum.Text.Trim() == "") ? "0" : txtBadQtySum.Text.Trim();
                if ((vBadQty + int.Parse(badqtysums)) > int.Parse(vTotalQty))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "sa", "<script>alert('保存失败,报废品数大于生产总数！');</script>");
                    return;
                }
                int flages = QC_Table_BLL.ChangeQC_Table(vID, vWorkOrderNo, txtDispatchNo.Value.Trim(), vTotalQty, txtMachineNo.Text, txtMouldNo.Text, vProductNo,
                   badqtysums, vProductDate, vProductDesc, vWorker, vUserID, vtime, vMemo, IU);


                if (vBadReason != "")
                {
                    yid = vID;
                    int t = QC_Table_BLL.QC_TableDetail(vDetailID, vID, txtDispatchNo.Value.Trim(), vBadReason, vBadQty);

                    BindDataDetail(vID);
                }
                if (flages > 0)
                {
                    dboSetCtrls.SetExecMsg(this, IU, true);
                }
                else
                {
                    dboSetCtrls.SetExecMsg(this, IU, false);
                }
            }
            if (tempButton.ID == "igbInsert" && GridView2.Visible)
            {

                int vDetailID = (txtDetailID.Text.Trim() == "") ? 0 : int.Parse(txtDetailID.Text.Trim());
                string vBadReason = ddlBadReason.SelectedValue.Trim();
                int vBadQty = (txtBadQty.Text.Trim() == "") ? 0 : int.Parse(txtBadQty.Text.Trim());
                if (Session["xid"].ToString() != null && vBadReason != "" && vBadQty != 0)
                {
                    yid = int.Parse(Session["xid"].ToString());
                    int t = QC_Table_BLL.QC_TableDetail(vDetailID, int.Parse(Session["xid"].ToString()), vDispatchNo, vBadReason, vBadQty);
                    if (t > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "sa", "<script>alert('保存失败！');</script>");
                        return;
                    }
                }

                BindDataDetail(int.Parse(Session["xid"].ToString()));
            }
            if (tempButton.ID == "igbInsert" && GridView2.Visible == false)
            {
                int vBadQty = (txtBadQty.Text.Trim() == "") ? 0 : int.Parse(txtBadQty.Text.Trim());
                if (vBadQty > int.Parse(vTotalQty))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "sa", "<script>alert('保存失败,报废品数大于生产总数！');</script>");
                    return;
                }
                QC_Table_BLL.ChangeQC_Table2(vID, vWorkOrderNo, vDispatchNo, vTotalQty, vMachineNo, vMouldNo, vProductNo,
                    vBadQty.ToString(), vProductDate, vProductDesc, vWorker, vUserID, vtime, vMemo, IU, out xid);

                int vDetailID = (txtDetailID.Text.Trim() == "") ? 0 : int.Parse(txtDetailID.Text.Trim());
                string vBadReason = ddlBadReason.SelectedValue.Trim();
                //int vBadQty = (txtBadQty.Text.Trim() == "") ? 0 : int.Parse(txtBadQty.Text.Trim());
                if (vBadReason != "")
                {
                    int t = QC_Table_BLL.QC_TableDetail(vDetailID, xid, vDispatchNo, vBadReason, vBadQty);
                    Session["xid"] = xid.ToString();
                    txtID.Text = xid.ToString();
                    GridView2.Visible = true;
                    if (t == 0)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                    }
                    else
                    {
                        dboSetCtrls.SetExecMsg(this, IU, false);
                    }
                    BindDataDetail(xid);
                }
                else
                {
                    if (xid > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                    }
                    else
                    {
                        dboSetCtrls.SetExecMsg(this, IU, false);
                    }
                }
                // ClientScript.RegisterStartupScript(this.GetType(), "sa", "<script>alert('"+xid.ToString()+"');</script>");

            }
            IList<QC_Table_MDL> myList = QC_Table_BLL.selectQC_Table(xid == 0 ? yid : xid, "", "");
            // IList<QC_Table_MDL> myList = QC_Table_BLL.selectQC_Table(int.Parse(txtID.Text), "", "");
            this.txtGoodQty.Text = myList[0].GoodQty.Trim();
            txtBadQtySum.Text = myList[0].BadQty.Trim();
            txtBadQty.Text = "";
            ddlBadReason.SelectedIndex = 0;

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
                if (GridView2.Visible)
                {
                    pIDList = dboSetCtrls.GetCancelRecordID(GridView2);
                    QC_Table_BLL.cancelQC_TableDetail(pIDList);
                    if (pIDList.Count == GridView2.Rows.Count)
                    {
                        pIDList.Add(txtID.Text.Trim());
                        QC_Table_BLL.cancelQC_Table(pIDList);
                    }
                    BindDataDetail(Int32.Parse(txtID.Text.Trim()));
                    IList<QC_Table_MDL> tempIList = QC_Table_BLL.selectQC_Table(Int32.Parse(txtID.Text.Trim()), "", "");

                }
                else
                {
                    pIDList.Add(txtID.Text.Trim());
                    QC_Table_BLL.cancelQC_Table(pIDList);
                }
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                QC_Table_BLL.cancelQC_Table(pIDList);
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

            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            object[] textboxid = { txtProdDesc, txtMouldNo,txtBadQtySum, txtBadQty, txtProductNo, txtTotalQty, txtGoodQty, txtMemo };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            //txtProductDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ddlWorker.SelectedIndex = ddlBadReason.SelectedIndex = 0;
            txtDispatchNo.Value = "";
            trDetail.Visible = true;
            GridView2.Visible = false;
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

        IList<QC_Table_MDL> tempIList = QC_Table_BLL.selectQC_Table(Int32.Parse(vID), "", "");
        string DispatchNo = tempIList[0].DispatchNo;

        if (DispatchNo.Substring(DispatchNo.Length - 3, 1) == "0")//为注塑派工单时
        {
            dboSetCtrls.SetDropDownList(ddlBadReason, BadReason_BLL.selectBadReason() as IList, false, "ReasonID", "IMReasonName");
        }
        else
        {
            dboSetCtrls.SetDropDownList(ddlBadReason, BadReason_BLL.selectBadReason() as IList, false, "ReasonID", "OMReasonName");
        }
        txtDispatchNo.Value = tempIList[0].DispatchNo;
        txtProductNo.Text = tempIList[0].ProductNo;
        txtProdDesc.Text = tempIList[0].ProductDesc;
        txtMouldNo.Text = tempIList[0].MouldNo;
        txtMachineNo.Text = tempIList[0].MachineNo;
        ddlWorker = dboSetCtrls.SetSelectedIndex(ddlWorker, tempIList[0].Worker);
        txtTotalQty.Text = tempIList[0].TotalQty;
        txtGoodQty.Text = tempIList[0].GoodQty;
        txtBadQtySum.Text = tempIList[0].BadQty;
        txtMemo.Text = tempIList[0].Memo;
        txtProductDate.Text = tempIList[0].ProductDate==""?"":Convert.ToDateTime(tempIList[0].ProductDate).ToString("yyyy-MM-dd");
        txtTime.Text = tempIList[0].ProductDate == "" ? "" : Convert.ToDateTime(tempIList[0].ProductDate).ToString("HH:mm");

        if (vCmd == "select")
            BindDataDetail(int.Parse(vID));
        trDetail.Visible = true;
        GridView2.Visible = true;
        ddlBadReason.SelectedIndex = 0;
        //txtBadQtySum.Text = "";
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

    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList tempDropDownList = sender as DropDownList;
        string DispatchNo = "";

        if (tempDropDownList.ID == "ddlDispatchNo")
        {
            IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "DO_No", DispatchNo);
            if (tempList.Count > 0)
            {
                string ProductNo = tempList[0].ProductNo.Trim();
                txtProductNo.Text = ProductNo;
                txtProdDesc.Text = tempList[0].ProductDesc.Trim();
                txtMouldNo.Text = tempList[0].MouldNo;
                txtMachineNo.Text = tempList[0].MachineNo;
                //ClientScript.RegisterStartupScript(this.GetType(), "ds", "<script>alert('" + DispatchNo.Substring(DispatchNo.Length - 4, 1) + "');</script>");
                if (DispatchNo.Substring(DispatchNo.Length - 3, 1) == "0")//为注塑派工单时
                {
                    dboSetCtrls.SetDropDownList(ddlBadReason, BadReason_BLL.selectBadReason() as IList, false, "ReasonID", "IMReasonName");
                }
                else
                {
                    dboSetCtrls.SetDropDownList(ddlBadReason, BadReason_BLL.selectBadReason() as IList, false, "ReasonID", "OMReasonName");
                }
            }
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string vID = txtDetailID.Text =
           ((GridView2.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();

        IList<QC_TableDetail_MDL> tempIList = QC_Table_BLL.selectQC_TableDetail(Int32.Parse(txtID.Text.Trim()), Int32.Parse(vID));

        ddlBadReason = dboSetCtrls.SetSelectedIndex(ddlBadReason, tempIList[0].BadReasonID);
        txtBadQty.Text = tempIList[0].BadQty;
    }
    
    private void BindDataDetail(int MasterID)
    {
        IList<QC_TableDetail_MDL> tempList = QC_Table_BLL.selectQC_TableDetail(MasterID, 0);
        ArrayList myArrListOld = new ArrayList();
        for (int i = 0; i < tempList.Count; i++)
        {
            myArrListOld.Add(tempList[i].BadQty);
        }
        Session["QcArrListOld"] = myArrListOld;
        GridView2.DataSource = tempList;
        GridView2.DataBind();
    }

    #region
    [Ajax.AjaxMethod()]
    public ArrayList getSearchDispatchNo(string dispatchno)
    {
        ArrayList retItems = new ArrayList();
        string ProducedNum = "0";
        string strSQL = "select isnull(dbo.GetProdNum('"+dispatchno+"','',''),0) as ProducedNum ";
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
            retItems.Add(tempList[t].ActualStartDate==""?"":Convert.ToDateTime(tempList[t].ActualStartDate).ToString("yyyy-MM-dd"));
            retItems.Add(tempList[t].ActualStartDate == "" ? "" : Convert.ToDateTime(tempList[t].ActualStartDate).ToString("HH:mm"));
        }
        return retItems;
    }
    #endregion
    
}