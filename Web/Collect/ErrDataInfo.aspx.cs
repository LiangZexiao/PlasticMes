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
using Admin.Model.Product_MDL;
using Admin.Model.Collect_MDL;
using Admin.BLL.Collect_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using System.IO;
using System.Text;

public partial class Collect_ErrDataInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Collect_ErrDataInfo));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ErrDataInfo");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[1]) igbInsert.Visible = false;
            if (o[3]) igbCancel.Visible = igbDelete .Visible= false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!Page.IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
           // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            //dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, false, "Machine_Code", "Machine_Code");
            
        }
    }

    public void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<ErrDataInfo_MDL> tempList = ErrDataInfo_BLL.selectErrDataInfo(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        txtMachineNo.Text = txtHiddenMachineNo.Value.Trim();
        txtMouldNo.Text = txtHiddenMouldNo.Value.Trim();

        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vMachineNo = txtMachineNo.Text.Trim();
        string vMouldNo = txtMouldNo.Text.Trim();
        string vDispatchNo = txtDispatchNo.Text.Trim();
        string vWorkOrderNo = ddlWorkOrderNo.SelectedValue.Trim();
        
        string vOriginalData = txtOriginalData.Text.Trim();
        string vModifyData = txtModifyData.Text.Trim();
        string vUploadDate = (txtUploadDate.Value.Trim() == "") ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : txtUploadDate.Value.Trim();
        string vModifyFlag = rblModifyFlag.SelectedValue.Trim();
        string vInputFlag = rblInputFlag.SelectedValue.Trim();
        string UserID = this.Page.User.Identity.Name.Trim();
        string Time = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {            
            ErrDataInfo_BLL.ChangeErrDataInfo(vMachineNo, vMouldNo, vDispatchNo, vWorkOrderNo, vOriginalData,
               vModifyData, vUploadDate, vModifyFlag, vInputFlag, UserID,
               Time, vID, IU);
            dboSetCtrls.SetExecMsg(this, IU, true);
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
                ErrDataInfo_BLL.cancelErrDataInfo(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                ErrDataInfo_BLL.cancelErrDataInfo(pIDList);
                BindData();
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete);
            //dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "dropdownlist", txtMachineNo);

            txtOriginalData.Text = txtModifyData.Text = null;
            txtUploadDate.Disabled = false;
            rblModifyFlag.SelectedIndex = rblInputFlag.SelectedIndex = 0;
            txtDispatchNo.Text = "";
            txtMouldNo.Text = "";

        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
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
        BindData();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete);
        //dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "dropdownlist", txtMachineNo);

        string vID = txtID.Text = hdnID.Value = 
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        IList<ErrDataInfo_MDL> tempIList = ErrDataInfo_BLL.selectErrDataInfo(Int32.Parse(vID), "", "");

        //ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempIList[0].MachineNo);
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "MachineNo", tempIList[0].MachineNo);
        if (tempList.Count > 0)
        {
            dboSetCtrls.SetDropDownList(ddlWorkOrderNo, tempList as IList, false, "workorderno", "workorderno");
            //dboSetCtrls.SetDropDownList(ddlMouldNo, tempList as IList, false, "mouldno", "mouldno");
            //dboSetCtrls.SetDropDownList(ddlDispatchNo, tempList as IList, false, "DO_No", "DO_No");
        }
        //ddlDispatchNo = dboSetCtrls.SetSelectedIndex(ddlDispatchNo, tempIList[0].DispatchNo);
        txtDispatchNo.Text = tempIList[0].DispatchNo.Trim();
        //ddlMouldNo = dboSetCtrls.SetSelectedIndex(ddlMouldNo, tempIList[0].MouldNo);
        txtMouldNo.Text = tempIList[0].MouldNo.Trim();
        txtMachineNo.Text = tempIList[0].MachineNo.Trim();
        ddlWorkOrderNo = dboSetCtrls.SetSelectedIndex(ddlWorkOrderNo, tempIList[0].WorkOrderNo);
        
        txtOriginalData.Text        = tempIList[0].OriginalData;
        txtModifyData.Text          = tempIList[0].ModifyData;
        txtUploadDate.Value         = tempIList[0].UploadDate;
        rblModifyFlag.SelectedValue = (tempIList[0].ModifyFlag.ToUpper() == "TRUE") ? "1" : "0";
        rblInputFlag.SelectedValue  = (tempIList[0].InputFlag.ToUpper() == "TRUE") ? "1" : "0";
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void ddlDispatchNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList tempDropDownList = sender as DropDownList;
        string DispatchNo = tempDropDownList.SelectedValue.Trim();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "MachineNo", DispatchNo);
        if (tempList.Count > 0)
        {
            dboSetCtrls.SetDropDownList(ddlWorkOrderNo, tempList as IList, false, "workorderno", "workorderno");
            //dboSetCtrls.SetDropDownList(ddlMouldNo, tempList as IList, false, "mouldno", "mouldno");
            //dboSetCtrls.SetDropDownList(ddlDispatchNo, tempList as IList, false, "DO_No", "DO_No");
        }

    }

    protected void imgBtExcel_Click(object sender, ImageClickEventArgs e)
    {
        if ((GridView1.Rows.Count) > 0)
        {
            string colname = ddlQuery.SelectedValue.ToString().Trim();
            string coltext = txtQuery.Text.ToString().Trim();
            IList<ErrDataInfo_MDL> tempList = ErrDataInfo_BLL.selectErrDataInfo(0, colname, coltext);
            GridView gridTmp = new GridView();
            gridTmp.DataSource = tempList;
            gridTmp.DataBind();
            gridTmp.AllowPaging = false;

            Response.Clear();
            Response.Buffer = false;
            Response.Charset = "GB2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=ErrDataInfo.xls");
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            gridTmp.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
        }
    }

    #region
    [Ajax.AjaxMethod()]
    public ArrayList getSearchDispatchNo(string dispatchno)
    {
        ArrayList retItems = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "DO_No", dispatchno);

        for (int t = 0; t < tempList.Count; t++)
        {
            retItems.Add(tempList[t].MouldNo.Trim());
            retItems.Add(tempList[t].MachineNo.Trim());
        }
        return retItems;
    }
    #endregion
}
