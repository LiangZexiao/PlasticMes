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
using System.Drawing.Imaging;
using System.Drawing;
using Admin.Model.Monitor_MDL;
using Admin.BLL.Monitor_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Monitor_DAL;

public partial class Monitor_Alarm : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    
    private string SourceID
    {
        get { return (ViewState["SourceID"] == null) ? "1" : ViewState["SourceID"].ToString().Trim(); }
        set { ViewState["SourceID"] = value; }
    }

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MonitorAlert");
            ViewState["authority"] = o;
            if(o[0]) btnQuery.Visible=false;
           
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["SourceID"] == null)
                SourceID = "3";
            else
                SourceID = Request.QueryString["SourceID"].ToString().Trim();
            BindData(SourceID);
            MultiView1.ActiveViewIndex = 0;
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
        }
    }

    private void BindData(string SourceID)
    {
        string colname = this.ddlQuery.SelectedValue;
        string coltext = this.txtQuery.Text.Trim().ToString();

        IList<AlarmInfo_MDL> tempList = AlarmInfo_BLL.selectAlarmInfo(0, "", colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void CtrlPageInfo_Click(object sender, ImageClickEventArgs e)
    {
        //ImageButton tempLinkButton = sender as ImageButton;
        //GridView1.PageIndex = Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
       // BindData(SourceID);
        ImageButton tempImageButton = sender as ImageButton;
        if (tempImageButton.ID == "igbSearch")
        {
            string strPageIndex = txtPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView1.PageIndex = int.Parse(strPageIndex) - 1;
        }
        else
            GridView1.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
        BindData("1");
    }

    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtAlarmSource);
            object[] textboxid = {txtID, 
                    txtAlarmSource, txtAlarmMachine, txtDutyOn, txtAlarmMemo,txtAlarmTotalTime,
                    txtCreateDate, txtRemark
                };
            object[] htmltextid = { txtCreateDate };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            dboSetCtrls.InitCtrls(this, "htmlinputtext", htmltextid);
            rblAlarmStatus.SelectedIndex = rblSendType.SelectedIndex = 0;
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData(SourceID);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView ctrl = sender as GridView;
        dboSetCtrls.SetGridViewColorOfMouseEvent(ctrl);
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], false, igbInsert, igbUpdate, igbDelete, "textbox", txtAlarmSource);
        string vID = string.Empty;

        vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[0].Controls[0]) as LinkButton).Text.Trim();

        IList<AlarmInfo_MDL> tempObject = AlarmInfo_BLL.selectAlarmInfo(int.Parse(vID), "", "", "");

        txtAlarmSource.Text = tempObject[0].AlarmSource;
        txtAlarmMachine.Text = tempObject[0].AlarmMachine;
        txtDutyOn.Text = tempObject[0].DutyOn;
        txtAlarmMemo.Text = tempObject[0].AlarmMemo;
        rblAlarmStatus.SelectedValue = (tempObject[0].AlarmStatus.ToUpper() == "已解除") ? "1" : "0";
        rblSendType.SelectedValue = (tempObject[0].SendType.Trim() == "已发送") ? "1" : "0";
        txtAlarmTotalTime.Text = tempObject[0].AlarmTotalTime;
        txtCreateDate.Text = tempObject[0].CreateDate.ToString("yyyy-MM-dd");
        txtRemark.Text = tempObject[0].Remark;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if ((GridView1.Rows.Count) > 0)
        {
            string colname = this.ddlQuery.SelectedValue;
            string coltext = this.txtQuery.Text.Trim().ToString();

            DataSet ds = new AlarmInfo_DAL().selectAlarmExcel(colname, coltext);
            GridView ddd = new GridView();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddd.DataSource = ds;
                    ddd.DataBind();
                    ddd.AllowPaging = false;

                    Response.Clear();
                    Response.Buffer = false;
                    Response.Charset = "GB2312";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=MonitorAlert.xls");
                    Response.ContentEncoding = System.Text.Encoding.Default;
                    Response.ContentType = "application/ms-excel";
                    this.EnableViewState = false;
                    System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                    ddd.RenderControl(oHtmlTextWriter);
                    Response.Write(oStringWriter.ToString());
                    Response.End();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
        }
    }
}
