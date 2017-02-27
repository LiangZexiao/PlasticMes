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

using Admin.Model.Monitor_MDL;
using Admin.App_Code;
using Admin.BLL.Monitor_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.BaseInfo_BLL;
using Admin.Model.Product_MDL;
using Admin.Model.Machine_MDL;

public partial class Monitor_MonitorDispatchMstr : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MonitorDispatchMstr");
            ViewState["authority"] = o;
            if(o[0]) igbQuery.Visible=false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["DispatchIndex"] != null)
            {
                txtID.Text = hdnID.Value = Request.QueryString["DispatchIndex"].ToString().Trim();
                
            }
            else
            {
                BindData(int.Parse(GridView1.ToolTip));
                MultiView1.ActiveViewIndex = 0;
                igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
                //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            }
        }
    }

    private void BindData(int iPageIndex)
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        string DispatchStatus = ddlCheckStatus.SelectedValue.Trim();
        int PageSize = GridView1.PageSize;
        int PageIndex = iPageIndex;
        int RowCount = 0;
        //IList<MonitorDispatchMstr_MDL> tempList = MonitorDispatchMstr_BLL.selectMonitorDispatchMstr(colname, coltext);
        IList<MonitorDispatchMstr_MDL> tempList = MonitorDispatchMstr_BLL.selectMonitorDispatchMstr(colname, coltext,DispatchStatus, PageSize, PageIndex, out RowCount);
        if (iPageIndex == 1)
        {
            this.GridView1.PageIndex = 0;
            this.Label1.Text = RowCount.ToString();

        }
        else
        {
            RowCount = int.Parse(this.Label1.Text);
        }
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPageForManyData(lblDataCount, lblPageIndex, GridView1, RowCount);
        dboSetCtrls.SetInfoOfImageButton(igbFirst, igbPrior, igbNext, igbLast, lblPageIndex, GridView1);
       
        
    }

    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID != "igbQuery")
        {
            MultiView1.ActiveViewIndex = 0;
            BindData(int.Parse(GridView1.ToolTip));
        }
        else
        {
            this.GridView1.ToolTip = "1";
            BindData(1);
        }

    }

    protected void CtrlPageInfo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempImageButton = sender as ImageButton;
        if (tempImageButton.ID == "igbSearch")
        {
            string strPageIndex = txtPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView1.ToolTip = strPageIndex;
        }
        else
            GridView1.ToolTip = ((ImageButton)sender).CommandName;

        int vToolTip = System.Convert.ToInt32(GridView1.ToolTip);
        int PageCount = System.Convert.ToInt32(lblPageIndex.Text.Trim().Split('/')[1]);
        int tmpPara = (vToolTip >= PageCount) ? PageCount : vToolTip;
        this.GridView1.PageIndex = vToolTip;
        if (vToolTip <= PageCount)
            BindData(vToolTip);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[0].Controls[0]) as LinkButton).Text.Trim();
    }



    protected void ddlCheckStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.ToolTip = "1";
        BindData(1);
    }
}
