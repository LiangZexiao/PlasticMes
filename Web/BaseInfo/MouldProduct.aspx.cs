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
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.BaseInfo_BLL;

using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class BaseInfo_MouldMstr : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MouldProduct");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible =igbNewadd.Visible= false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }

        if (!IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);

            dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, false, "Item_Code", "Item_NameCH");
            dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "Mould_Code", "Mould_Code");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<MouldMstr_MDL> tempList = MouldMstr_BLL.selectMouldMstr(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int ID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());        
        string MouldNo = ddlMouldNo.SelectedValue.Trim();
        string ProductNo = ddlProductNo.SelectedValue.Trim();
        int GoodSocketNum = (txtGoodSocketNum.Text.Trim() == "") ? 0 : int.Parse(txtGoodSocketNum.Text.Trim());
        string Remark = txtRemark.Text.Trim();

        if (MouldNo == "" || ProductNo == "")
        {
            dboSetCtrls.SetExecMsg(this, "模具和产品编号都不能为空!!");
            return;
        }
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (MouldMstr_BLL.existsMouldMstr(MouldNo, ProductNo).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的对照关系!!");
                    return;
                }
            }

            MouldMstr_BLL.ChangeMouldMstr(ID, MouldNo, ProductNo, GoodSocketNum, Remark, IU);
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
                MouldMstr_BLL.cancelMouldMstr(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                MouldMstr_BLL.cancelMouldMstr(pIDList);
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
            ArrayList tempArrayList = new ArrayList();
            tempArrayList.Add(ddlMouldNo);
            tempArrayList.Add(ddlProductNo);
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, new string[1] { "dropdownlist" }, tempArrayList);

            object[] textboxid = { txtID, txtGoodSocketNum, txtRemark };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            ddlMouldNo.SelectedIndex = ddlProductNo.SelectedIndex = 0;
            lblProductNoShow.Text = ddlProductNo.SelectedValue.Trim();
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
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();
        ArrayList tempArrayList = new ArrayList();
        tempArrayList.Add(ddlMouldNo);
        tempArrayList.Add(ddlProductNo);
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, new string[1] { "dropdownlist" }, tempArrayList);
        IList<MouldMstr_MDL> tempIList = MouldMstr_BLL.selectMouldMstr(Int32.Parse(vID), "", "");

        dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, false, "Item_Code", "Item_NameCH");
        ddlProductNo = dboSetCtrls.SetSelectedIndex(ddlProductNo, tempIList[0].ProductNo);
        lblProductNoShow.Text = ddlProductNo.SelectedValue.Trim();

        dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "Mould_Code", "Mould_Code");
        ddlMouldNo = dboSetCtrls.SetSelectedIndex(ddlMouldNo, tempIList[0].Mould_Code);

        txtGoodSocketNum.Text = tempIList[0].GoodSocketNum.ToString();
        txtRemark.Text = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void ddlProductNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblProductNoShow.Text = ddlProductNo.SelectedValue.Trim();
    }
}
