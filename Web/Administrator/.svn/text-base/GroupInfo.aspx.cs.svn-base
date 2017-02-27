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
using Admin.BLL.Adminis_BLL;
using Admin.Model.Adminis_MDL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Administrator_GroupInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        try  
        {
            //Session["ClickMould"] = @"Administrator/GroupInfo.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "GroupInfo");
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
        }
    }
    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<GroupInfo_MDL> tempList = GroupInfo_BLL.selectGroupInfo(0, colname, coltext,-1);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtGroupID);

            object[] textboxid = { txtID, txtGroupID, txtGroupName, txtHeader, txtAction, txtMemberNum,txtRemark };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int id = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string GroupID = txtGroupID.Text.Trim();
        string GroupName = txtGroupName.Text.Trim();
        string Header = txtHeader.Text.Trim();
        string Action = txtAction.Text.Trim();
        int MemberNum = Int32.Parse(string.IsNullOrEmpty(txtMemberNum.Text.Trim()) ? "1" : txtMemberNum.Text.Trim());
        string Remark = txtRemark.Text;
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (GroupInfo_BLL.existsGroupInfo(GroupID).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的群组代号!!");
                    return;
                }
            }
            GroupInfo_BLL.ChangeGroupInfo(id, GroupID, GroupName, Header, Action, MemberNum, Remark, IU);
            dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            if (tempButton.ID == "igbDelete")
                GroupInfo_BLL.deleteGroupInfo(Int32.Parse(txtID.Text));
            else
            {
                ArrayList pIDList = new ArrayList();
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                GroupInfo_BLL.cancelGroupInfo(pIDList);
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);
            BindData();
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtGroupID);

        string vID = txtID.Text = hdnID.Value =
                ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        IList<GroupInfo_MDL> tempIList = GroupInfo_BLL.selectGroupInfo(Int32.Parse(vID), "", "");

        txtGroupID.Text     = tempIList[0].GroupID;
        txtGroupName.Text   = tempIList[0].GroupName;
        txtHeader.Text      = tempIList[0].Header;
        txtAction.Text      = tempIList[0].Action;
        txtMemberNum.Text   = tempIList[0].MemberNum.ToString().Trim();
        txtRemark.Text      = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
