using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Admin.App_Code;
using System.Collections.Generic;
using Admin.Model.BaseInfo_MDL;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.SQLServerDAL.RightCtrl;

public partial class BaseInfo_RawMaterial : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "RawMaterial");
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
        if (!Page.IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
        }
    }

    protected void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<RawMaterial_MDL> tempList = new RawMaterial_DAL().selectRawMaterial(colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int ID = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string RawNo = tbRawNo.Text.Trim().ToString();
        string RawName = tbRawName.Text.Trim().ToString();
        string RawModel = tbRawModel.Text.Trim().ToString();
        string RawBrand = tbRawBrand.Text.Trim().ToString();
        float spec = Convert.ToSingle(tbSpec.Text.Trim().ToString());
        string RawColor = tbRawColor.Text.Trim().ToString();
        string Memo = txtMemo.Text.Trim().ToString();
        RawMaterial_MDL SC_MDL = new RawMaterial_MDL(ID, RawNo, RawName, RawModel, RawBrand, spec, RawColor, Memo);
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (IU == "INSERT")
            {
                if (new RawMaterial_DAL().existsRawMaterial(RawNo).Count > 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同原料编号记录!");
                    return;
                }
            }
            int t = new RawMaterial_DAL().ChangeRawMaterial(SC_MDL, IU);
            dboSetCtrls.SetExecMsg(this, IU, t > 0 ? true : false);
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
                new RawMaterial_DAL().cancelRawMaterial(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                new RawMaterial_DAL().cancelRawMaterial(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "TEXTBOX", tbRawNo);
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "TEXTBOX", tbRawNo);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();

        IList<RawMaterial_MDL> tempIList = new RawMaterial_DAL().selectRawMaterial(Int32.Parse(vID), "", ""); // Employee_BLL.selectEmployee(Int32.Parse(vID), "", "");

        tbRawNo.Text = tempIList[0].RawNo.ToString();
        tbRawName.Text = tempIList[0].RawName.ToString();
        tbRawModel.Text = tempIList[0].RawModel.ToString();
        tbRawBrand.Text = tempIList[0].RawBrand.ToString();
        tbSpec.Text = tempIList[0].Spec.ToString();
        tbRawColor.Text = tempIList[0].RawColor.ToString();
        txtMemo.Text = tempIList[0].Memo.ToString();


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
