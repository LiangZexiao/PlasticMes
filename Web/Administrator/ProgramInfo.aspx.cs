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

public partial class Administrator_ProgramInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"Administrator/ProgramInfo.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ProgramInfo");
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
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlClassID, SysClassInfo_BLL.selectSysClassInfo(0, "", "") as IList, "ClassID", "ClassName");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<ProgramInfo_MDL> tempList = SysProgramInfo_BLL.selectProgramInfo(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int id = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string ProgramID = txtProgramID.Text.Trim();
        string ProgramName = txtProgramName.Text.Trim();
        string RequestURL = txtRequestURL.Text.Trim();
        string ClassID = ddlClassID.SelectedValue.Trim();
        string OrderID = txtOrderID.Text.Trim();
        string Locked = (chkLocked.Checked) ? "1" : "0";
        DateTime Date = System.DateTime.Now;
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (SysProgramInfo_BLL.existsProgramInfo(ProgramID).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的程式代号!!");
                    return;
                }
                SysProgramInfo_BLL.insertProgramInfo(ProgramID, ProgramName, RequestURL, ClassID, OrderID,Locked, Date, Date);
                dboSetCtrls.SetExecMsg(this, "insert", true);
            }
            else
            {                
                SysProgramInfo_BLL.updateProgramInfo(id, ProgramID, ProgramName, RequestURL, ClassID, OrderID, Locked, Date);
                dboSetCtrls.SetExecMsg(this, "update", true);
            }
        }
        catch
        {
            if (tempButton.ID == "igbInsert") dboSetCtrls.SetExecMsg(this, "insert", false);
            else dboSetCtrls.SetExecMsg(this, "update", true);
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
                SysProgramInfo_BLL.cancelProgramInfo(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                SysProgramInfo_BLL.cancelProgramInfo(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtProgramID);

            object[] textboxid = { txtID, txtProgramID, txtProgramName, txtRequestURL, txtOrderID };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            ddlClassID.SelectedIndex = 0;
            chkLocked.Checked = false;
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtProgramID);

        string vID = txtID.Text = hdnID.Value =
                ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        IList<ProgramInfo_MDL> tempIList = SysProgramInfo_BLL.selectProgramInfo(Int32.Parse(vID), "", "");

        txtProgramID.Text   = tempIList[0].ProgramID;
        txtProgramName.Text = tempIList[0].ProgramName;
        txtRequestURL.Text  = tempIList[0].RequestURL;
        ddlClassID = dboSetCtrls.SetSelectedIndex(ddlClassID, tempIList[0].ClassID);
        txtOrderID.Text     = tempIList[0].OrderID;
        chkLocked.Checked = (tempIList[0].Locked == "是") ? true : false;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
