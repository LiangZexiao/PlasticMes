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

using Admin.Model.Monitor_MDL;
using Admin.BLL.Monitor_BLL;
using Admin.BLL.Product_BLL;
using Admin.App_Code;
using Admin.SQLServerDAL.RightCtrl;
using System.Text;

public partial class Monitor_MonitorMaterial : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //o[4]--打印,列印
    //o[5]--审核
    //*****************************************************
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MonitorMaterial");
            ViewState["authority"] = o;
            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbNewadd.Visible = false;
            if (o[3]) igbCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            BindData(int.Parse(GridView1.ToolTip));
            MultiView1.ActiveViewIndex = 0;
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            GridView1.Style.Add("word-break", "keep-all");
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

        IList<MonitorMaterial_MDL> tempList = MonitorMaterial_BLL.selectMonitorMaterial(colname, coltext,DispatchStatus, PageSize, PageIndex, out RowCount);
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
            this.MultiView1.ActiveViewIndex = 0;
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

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            bool flag = false;
            for (int j = 0; j < GridView1.Columns.Count;j++ )
            {
                if ((GridView1.Columns[j] as BoundField).DataField.Trim() == "LeaveTime")
                {
                    flag = true;
                    float Value = float.Parse(GridView1.Rows[i].Cells[j].Text);
                    if (Value <= 1.000f && Value >0)
                    {
                        GridView1.Rows[i].BackColor = System.Drawing.Color.Red;
                    }
                    break;
                }
            }
            if (!flag)
                break;
        }
    }
    protected void ddlCheckStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.ToolTip = "1";
        BindData(1);
    }


    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton tempLinkButton = sender as LinkButton;

        for (int i = 0; i < Tinf.Rows[0].Cells.Count - 3; i++)
            Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");

        int CellsIndex = 0;
        switch (tempLinkButton.ID.Trim())
        {
            case "LinkButton1":
                CellsIndex = 0;
                MultiView1.Visible = true;
                MultiView2.Visible = false;
                MultiView2.ActiveViewIndex = -1;
                break;
            default:
                CellsIndex = 1;
                MultiView2.Visible = true;
                MultiView1.Visible = false;
                MultiView2.ActiveViewIndex = 0;
                break;
        }
        Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BindMaterial(1);
    }

    private void BindMaterial(int iPageIndex)
    {
        string colname = ddlQuery2.SelectedValue.ToString().Trim();
        string coltext = tbQuery.Text.ToString().Trim();
        string beginCycle = inStartDate.Value.ToString().Trim();
        string endCycle = inEndDate.Value.ToString().Trim();
        int RowCount = 0;
        DataTable dt = MonitorMaterial_BLL.selectMaterial(colname, coltext, beginCycle, endCycle);
        if (iPageIndex == 1)
        {
            this.GridView2.PageIndex = 0;
            this.Label1.Text = RowCount.ToString();

        }
        else
        {
            RowCount = int.Parse(this.Label4.Text);
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();

        dboSetCtrls.SetInfoOfPage(Label2, Label3, GridView2, dt.Rows.Count);
        dboSetCtrls.SetInfoOfImageButton(ibFirst, ibPrior, ibNext, ibLast, Label3, GridView2);
    }

    protected void ClickPageInfo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton tempImageButton = sender as ImageButton;
        if (tempImageButton.ID == "ibSearch")
        {
            string strPageIndex = tbPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView2.ToolTip = strPageIndex;
        }
        else
            GridView2.ToolTip = ((ImageButton)sender).CommandName;
        int vToolTip = System.Convert.ToInt32(GridView2.ToolTip);
        int PageCount = System.Convert.ToInt32(Label3.Text.Trim().Split('/')[1]);
        int tmpPara = (vToolTip >= PageCount) ? PageCount : vToolTip;
        this.GridView2.PageIndex = vToolTip;
        if (vToolTip <= PageCount)
            BindData(vToolTip);
    }

}