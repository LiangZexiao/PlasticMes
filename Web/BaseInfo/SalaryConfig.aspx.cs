using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.Model.Adminis_MDL;
using Admin.BLL.Adminis_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.App_Code;

public partial class BaseInfo_SalaryConfig : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"BaseInfo/Employee.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "Employee");
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
        if (!Page.IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<SalaryConfig_MDL> tempList = new SalaryConfig_DAL().selectSalaryConfig(0, colname, coltext);//Employee_BLL.selectEmployee(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        //dboSetCtrls.SetGridView(ddlStatus, GridView1, "WorkType");

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int ID = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string WorkType = ddlWorkType.SelectedValue.ToString();
        string WorkDesc = ddlWorkType.SelectedItem.Text.ToString();
        string Level = WorkType=="2"?"": ddlLevel.SelectedValue.ToString();
        string LevelDesc = WorkType == "2" ? "" : ddlLevel.SelectedItem.Text.ToString();
        string MoneyPreHour = txtMoneyPreHour.Text.Trim();
        SalaryConfig_MDL SC_MDL = new SalaryConfig_MDL(ID, WorkType,WorkDesc, Level,LevelDesc, MoneyPreHour);
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (IU == "INSERT")
            {
                if (new SalaryConfig_DAL().existsSalaryConfig(WorkType, Level).Count > 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同配置!");
                    return;
                }
            }
            int t=new SalaryConfig_DAL().ChangeSalaryConfig(SC_MDL,IU);
            dboSetCtrls.SetExecMsg(this, IU, t>0?true:false);
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
                new SalaryConfig_DAL().cancelSalaryConfig(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                new SalaryConfig_DAL().cancelSalaryConfig(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "dropdownlist", ddlWorkType);
            object[] textboxid = { txtMoneyPreHour };
            ddlWorkType.SelectedIndex = 0;
            binddrop(ddlWorkType.SelectedValue.Trim());

            ddlLevel.Enabled = true;
         //ddlLevel.SelectedIndex  = 0;
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "dropdownlist", ddlWorkType);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();

        IList<SalaryConfig_MDL> tempIList = new SalaryConfig_DAL().selectSalaryConfig(Int32.Parse(vID), "", ""); // Employee_BLL.selectEmployee(Int32.Parse(vID), "", "");

        ddlWorkType = dboSetCtrls.SetSelectedIndex(ddlWorkType, tempIList[0].WorkType); //tempIList[0].Department;
        binddrop(tempIList[0].WorkType);
        ddlLevel = dboSetCtrls.SetSelectedIndex(ddlLevel, tempIList[0].Level);
        txtMoneyPreHour.Text = tempIList[0].MoneyPreHour;
        
       
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void ddlWorkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string WorkType=ddlWorkType.SelectedValue.ToString();
        binddrop(WorkType);
    }

    void binddrop(string str)
    {
        string WorkType = str;
        ddlLevel.Items.Clear();
        if ( WorkType == "2" || WorkType == "3")
        {
            ddlLevel.Enabled = false;
            //ddlLevel.Items.Add(new ListItem("选择", ""));
            //ddlLevel.Items.Add(new ListItem("A级", "1"));
            //ddlLevel.Items.Add(new ListItem("B级", "2"));
            //ddlLevel.Items.Add(new ListItem("C级", "3"));
            //ddlLevel.Items.Add(new ListItem("D级", "4"));
            //ddlLevel.Items.Add(new ListItem("E级", "5"));
        }
        else
        {
            ddlLevel.Enabled = true;
            ddlLevel.Items.Add(new ListItem("选择", ""));
            ddlLevel.Items.Add(new ListItem("立式注塑机:50", "50"));  //立式
            ddlLevel.Items.Add(new ListItem("注塑机克重:100", "100"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:160", "160"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:200", "200"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:250", "250"));//双色机器
            ddlLevel.Items.Add(new ListItem("注塑机克重:300", "300"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:350", "350"));//双色机器
            ddlLevel.Items.Add(new ListItem("注塑机克重:400", "400"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:500", "500"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:700", "700"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:800", "800"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:1000", "1000"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:1200", "1200"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:1500", "1500"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:2000", "2000"));
            ddlLevel.Items.Add(new ListItem("注塑机克重:3000", "3000"));
        }
    }
}
