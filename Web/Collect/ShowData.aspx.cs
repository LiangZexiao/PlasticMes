﻿using System;
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
using Admin.Model.Collect_MDL;
using Admin.BLL.Collect_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Collect_ShowData : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ShowData");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            //if (o[1]) btnInsert.Visible = false;
            //if (o[2]) btnUpdate.Visible = false;
            //if (o[3]) btnDelete.Visible =  false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
           // BindData(int.Parse(GridView1.ToolTip));
            MultiView1.ActiveViewIndex = 0;
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
          //  dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
          //  dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1, new string[4] { "MachineNo", "TotalNum", "UpLoadTime", "DispatchOrder" });
            SetTextBoxVisible();
            //ddlQuery.Items.Add(new ListItem("IP", "ClientIp"));
            this.txtBeginDate.Value =this.txtEndDate.Value= System.DateTime.Now.ToString("yyyy-MM-dd HH:mm").Trim();
        }
    }

    private void BindData(int iPageIndex)
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext =  txtQuery.Text.Trim() ;
        string BeginDate = txtBeginDate.Value.Trim() == string.Empty ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"): txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim() == string.Empty ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"): txtEndDate.Value.Trim();
        int PageSize = GridView1.PageSize;
        int PageIndex = iPageIndex;
        int RowCount = 0;
        IList<DataHistory_MDL> tempList = DataHistory_BLL.selectDataHistory(colname, coltext,BeginDate,EndDate, PageSize, PageIndex, out RowCount);

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
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            //dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "textbox", txtMPSNo as object);
            //object[] textboxid = { txtMPSNo, txtNum, txtErrMsg, txtChecker };
            //object[] htmltextid = { txtDueDate, txtSchStartDate, txtSchEndDate };
            //ddlWONo.SelectedIndex = ddlMachineNo.SelectedIndex = ddlProductNo.SelectedIndex = ddlMouldNo.SelectedIndex = 0;
            //rblStatus.SelectedIndex = rblRearrangeFlag.SelectedIndex = 0;
            //dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            //dboSetCtrls.InitCtrls(this, "htmlinputtext", htmltextid);
        }
        else
        {
            if (tempButton.ID != "igbQuery")
            {

                MultiView1.ActiveViewIndex = 0;
               BindData(int.Parse(GridView1.ToolTip));
            }
            else
            {
                string coltext = txtQuery.Text.Trim() ;
                if (coltext == "")
                {
                    dboSetCtrls.SetExecMsg(this, "查询条件不能为空！");
                    return;
                }
                else
                {
                    string BeginDate = BeginDate = txtBeginDate.Value.Trim() == string.Empty ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"): txtBeginDate.Value.Trim();
                    string EndDate = (txtEndDate.Value.Trim() == string.Empty) ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") : txtEndDate.Value.Trim();
                    if (dboSetCtrls.CheckDateTime("string", BeginDate, EndDate))
                    {
                        dboSetCtrls.SetExecMsg(this, "起始日期不能大于终止日期!!");
                        return;
                    }
                    else
                    {
                        this.GridView1.ToolTip = "1";
                        BindData(1);
                    }
                }
            }
           // GridView1.ToolTip = "1";
           
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

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();

        IList<DataHistory_MDL> tempIList = DataHistory_BLL.selectDataHistory(Int32.Parse(vID));

        txtMachineNo.Text = tempIList[0].MachineNo;
        txtMouldNo.Text = tempIList[0].MouldNo;
        txtProductNo.Text = tempIList[0].ProductNo;
        txtWorkOrderNo.Text = tempIList[0].WorkOrderNo;
        txtDispatchOrder.Text = tempIList[0].DispatchOrder;
        
        txtTotalNum.Text = tempIList[0].TotalNum;
        txtBeginCycle.Text = tempIList[0].BeginTime;
        txtCycletime.Text = tempIList[0].Cycletime;

        
        txtKeepPress_Max.Text = tempIList[0].KeepPress_Max;

        txtShotTemp1.Text = tempIList[0].ShotTemp1;
        txtShotTemp2.Text = tempIList[0].ShotTemp2;

        txtIntervalInfo.Text = tempIList[0].IntervalInfo;

        txtFillTime.Text = tempIList[0].FillTime;

        txtUpLoadTime.Text = tempIList[0].UpLoadTime;
        txtInjectNum.Text = tempIList[0].InjectNum;


        MultiView1.ActiveViewIndex = 1;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
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
            
        }
        else
        {
            txtQuery.Visible = true;
            
        }
    }
}