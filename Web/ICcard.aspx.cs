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
using Admin.App_Code;
using Admin.SQLServerDAL.Call_DAL;
using Admin.Model.Call_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL;
using Admin.SQLServerDAL.Collect_DAL;
using Admin.SQLServerDAL.Product_DAL;
using System.IO;
using Newtonsoft.Json;


public partial class ICcard : System.Web.UI.Page
{
    static SQLExecutant sc = new SQLExecutant();
    static DataTable dts;
    DataTable dt;
    SetCtrls dboSetCtrls = new SetCtrls();
    bool[] o = new bool[7] { false, false, false, false, false, false, false };

    public override void VerifyRenderingInServerForm(Control control)
    {
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ICcard");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
            this.txtBeginDate.Value = this.txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstr() as IList, true, "Machine_MaterialChgAmt", "Remark");
            dboSetCtrls.SetDropDownList(DropDownList1, new MachineSuit_DAL().SelectReasonAll(true) as IList, true, "ReasonName", "ReasonName");
            dataBind();
            //**************************************************
            if (Request["stop"] != null)
            {
                    string json = JsonConvert.SerializeObject(dts);
                    Response.Clear();
                    Response.ContentType = "text/plain";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Write(json);
                    Response.End(); 
            }
            //***************************************************
        }
    }

    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.ToString().Trim();
        string coltext = this.txtQuery.Text.ToString().Trim();
        string begindate = this.txtBeginDate.Value.Trim() == "" ? "" : this.txtBeginDate.Value.Trim();
        string enddate = this.txtEndDate.Value.Trim() == "" ? "" : this.txtEndDate.Value.Trim();
        dt = new ICCard_DAL().selectICCard(ddlMachine_SeatCode.SelectedValue, DropDownList1.SelectedValue, colname, coltext, begindate, enddate);
        this.GridView1.DataSource = dt;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, dt.Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
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
        dataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        string colname = this.ddlQuery.SelectedValue.ToString().Trim();
        string coltext = this.txtQuery.Text.ToString().Trim();
        string begindate = this.txtBeginDate.Value.Trim() == "" ? "" : this.txtBeginDate.Value.Trim();
        string enddate = this.txtEndDate.Value.Trim() == "" ? "" : this.txtEndDate.Value.Trim();
        if (begindate != "" && enddate != "")
        {
            if (DateTime.Parse(begindate) > DateTime.Parse(enddate))
            {
                dboSetCtrls.SetExecMsg(this, "开始时间不能大于结束时间！");
                return;
            }
        }
        dts = new ICCard_DAL().selectICCard(ddlMachine_SeatCode.SelectedValue, DropDownList1.SelectedValue, colname, coltext, begindate, enddate); ;    
        this.GridView1.DataSource = dts;
        this.GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, dts.Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void imgBtExcel_Click(object sender, ImageClickEventArgs e)
    {
        if ((GridView1.Rows.Count) > 0)
        {
            Response.Clear();
            //Response.Buffer = false;
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AppendHeader("Content-Disposition", "attachment;filename=ICcard.xls");
            Response.ContentType = "application/vnd.ms-excel";//导出excel文件  application/vnd.ms-excel
            GridView1.Page.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            GridView1.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
        }
    }
}

