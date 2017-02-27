using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Monitor_MDL;
using Admin.BLL.Monitor_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Collect_DataShow : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    CollectRealProductDataInfo_BLL bllCollectRealProductDataInfo = new CollectRealProductDataInfo_BLL();
    CollectRealProductDataInfo_MDL mdlCollectRealProductDataInfo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"Collect/DataShow.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "DataShow");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnInsert.Visible = false;
            if (o[2]) btnUpdate.Visible = false;
            if (o[3]) btnDelete.Visible = btnCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            btnSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1, new string[3] { "CollectorID", "MachineNo", "UpLoadTime" });
            SetTextBoxVisible();
        }
    }

    public void BindData()
    {
        string colname = ddlQuery.SelectedValue.Trim();
        string coltext = (txtQuery.Visible) ? txtQuery.Text.Trim() : txtQUpLoadTime.Value.Trim();

        mdlCollectRealProductDataInfo = (colname != "" && coltext != "") ? new CollectRealProductDataInfo_MDL(colname, coltext) : new CollectRealProductDataInfo_MDL();
        DataTable dt = bllCollectRealProductDataInfo.selectCollectRealProductDataInfo(mdlCollectRealProductDataInfo);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfLabel(lblGridViewInfo, GridView1, dt);
        dboSetCtrls.SetInfoOfLinkButtonPage(lkbFirstPage, lkbPriorPage, lkbNextPage, lkbLastPage, GridView1);
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;

        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
       CollectRealProductDataInfo_MDL tempObject = bllCollectRealProductDataInfo.chooseCollectRealProductDataInfo(new CollectRealProductDataInfo_MDL(vID));

        txtCollectorID.Text = tempObject.CollectorID;
        txtOrderID.Text     = tempObject.OrderID;
        txtItemNo.Text      = tempObject.ItemNo;
        txtMachineNo.Text   = tempObject.MachineNo;
        txtMouldNo.Text     = tempObject.MouldNo;
        txtBeginTime.Text   = tempObject.BeginTime;
        txtEndTime.Text = tempObject.EndTime;
        txtSwitch1.Text = tempObject.Switch1;
        txtSwitch2.Text = tempObject.Switch2;
        txtSwitch3.Text = tempObject.Switch3;
        txtSwitch4.Text = tempObject.Switch4;
        txtSwitch5.Text = tempObject.Switch5;
        txtSwitch6.Text = tempObject.Switch6;
        txtSwitch7.Text = tempObject.Switch7;
        txtSwitch8.Text = tempObject.Switch8;
        txtTemp1.Text = tempObject.Temp1;
        txtTemp2.Text = tempObject.Temp2;
        txtTemp3.Text = tempObject.Temp3;
        txtTemp4.Text = tempObject.Temp4;
        txtTemp5.Text = tempObject.Temp5;
        txtTemp6.Text = tempObject.Temp6;
        txtTemp7.Text = tempObject.Temp7;
        txtTemp8.Text = tempObject.Temp8;
        txtShotPress1.Text = tempObject.ShotPress1;
        txtShotPress2.Text = tempObject.ShotPress2;
        txtShotPress3.Text = tempObject.ShotPress3;
        txtShotPress4.Text = tempObject.ShotPress4;
        txtKeepPress1.Text = tempObject.KeepPress1;
        txtKeepPress2.Text = tempObject.KeepPress2;
        txtKeepPress3.Text = tempObject.KeepPress3;

        txtFastLockMouldPress.Text = tempObject.FastLockMouldPress;
        txtLowPressLockMouldPress.Text = tempObject.LowPressLockMouldPress;
        txtHighPressLockMouldPress.Text = tempObject.HighPressLockMouldPress;

        txtP1.Text = tempObject.P1;
        txtP2.Text = tempObject.P2;
        txtDisplacement1.Text = tempObject.Displacement1;
        txtDisplacement2.Text = tempObject.Displacement2;
        txtUpLoadTime.Text = tempObject.UpLoadTime;
    }

    protected void CtrlPageInfo_Click(object sender, EventArgs e)
    {
        string CtrlName = sender.GetType().Name.Trim();
        if (CtrlName == "LinkButton")
            GridView1.PageIndex = System.Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
        else
        {
            string strPageIndex = txtPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView1.PageIndex = int.Parse(strPageIndex) - 1;
        }
        BindData();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void btnVisible_Click(object sender, EventArgs e)
    {
        Button tempButton = sender as Button;
        if (tempButton.ID != "btnQuery")
            MultiView1.ActiveViewIndex = 0;
        BindData();
    }
    protected void ddlQuery_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetTextBoxVisible();
    }

    private void SetTextBoxVisible()
    {
        string SelectedValue = ddlQuery.SelectedValue.Trim();
        if (SelectedValue == "UpLoadTime")
        {
            txtQuery.Visible = false;
            txtQUpLoadTime.Value = null;
            txtQUpLoadTime.Visible = true;
        }
        else
        {
            txtQuery.Visible = true;
            txtQUpLoadTime.Visible = false;
        }
    }
}
