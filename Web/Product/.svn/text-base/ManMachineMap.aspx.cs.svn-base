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
using Admin.BLL.Machine_BLL;
using Admin.Model.Product_MDL;
using Admin.BLL.Product_BLL;
using Admin.BLL.BaseInfo_BLL;

using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Product_DAL;

public partial class Product_ManMachineMap : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"Product/ManMachineMap.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ManMachineMap");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }

        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            BindData();
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, false, "Machine_Code", "Machine_Code");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<ManMachineMap_MDL> tempList = ManMachineMap_BLL.selectManMachineMap(0, colname, coltext);        
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetGridView(ddlWorkGrade, GridView1, "WorkGrade");
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;

        string vEmployeeID = txtEmployeeID.Text.Trim();
        string vMachineNo = ddlMachineNo.SelectedValue.Trim();
        string vWorkGrade = ddlWorkGrade.SelectedValue.Trim();
        string vWorkDate = txtWorkDate.Value.Trim();
        string vRemark = txtRemark.Text.Trim();

        try
        {
            if (tempButton.ID == "igbInsert")
            {
                ManMachineMap_BLL.insertManMachineMap(vEmployeeID, vMachineNo, vWorkGrade, vWorkDate, vRemark);
                dboSetCtrls.SetExecMsg(this, "insert", true);
            }
            else
            {
                ManMachineMap_BLL.updateManMachineMap(int.Parse(txtID.Text.Trim()), vEmployeeID, vMachineNo, vWorkGrade, vWorkDate, vRemark);
                dboSetCtrls.SetExecMsg(this, "update", true);
            }
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            if (tempButton.ID == "igbInsert")
                dboSetCtrls.SetExecMsg(this, "insert", false);
            else
                dboSetCtrls.SetExecMsg(this, "update", false);
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            if (tempButton.ID == "igbDelete")
                ManMachineMap_BLL.deleteManMachineMap(Int32.Parse(txtID.Text.Trim()));
            else
            {
                ArrayList pIDList = new ArrayList();
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                ManMachineMap_BLL.cancelManMachineMap(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmployeeID);
            object[] textboxid = { txtID, txtEmployeeID, txtRemark };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            txtWorkDate.Value = null;
            ddlMachineNo.SelectedIndex = ddlWorkGrade.SelectedIndex = 0;
        }
        else if (tempButton.ID == "btnPrint")
        {
            this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportName=ProductMstr&ReportType=1') </script>");
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
        string CtrlName = sender.GetType().Name.Trim();
        if (CtrlName == "ImageButton")
            GridView1.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
        else
        {
            string strPageIndex = txtPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView1.PageIndex = int.Parse(strPageIndex) - 1;
        }
        BindData();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string vID = txtID.Text = hdnID.Value =
       ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmployeeID);
        IList<ManMachineMap_MDL> tempIList = ManMachineMap_BLL.selectManMachineMap(Int32.Parse(vID), "", "");

        txtID.Text = hdnID.Value = vID;
        txtEmployeeID.Text = tempIList[0].EmployeeID;
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempIList[0].MachineNo);
        ddlWorkGrade = dboSetCtrls.SetSelectedIndex(ddlWorkGrade, tempIList[0].WorkGrade);
        txtWorkDate.Value = tempIList[0].WorkDate;
        txtRemark.Text = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
