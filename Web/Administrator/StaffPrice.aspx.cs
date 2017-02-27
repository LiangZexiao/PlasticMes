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
using Admin.Model.Product_MDL;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.Product_BLL;
using Admin.BLL.Machine_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL;
public partial class Administrator_StaffPrice : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //o[4]--打印,列印
    //o[5]--审核
    //***************************************************** 
    bool[] o = new bool[7] { false, false, false, false, false, false ,false};
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "DispatchOrder");
            ViewState["authority"] = o;

            if (o[0]) btn_query.Visible = false;
            if (o[4]) btn_print.Visible = false;

        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            bindgr();
        }

    }
    protected void digbQuery_Click(object sender, ImageClickEventArgs e)
    {
        //string db_productNo = this.txtname.Text.Trim().ToString();
        //Session["db_productNo"] = db_productNo;
        //this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
        //         @"<script> window.open('../repPrinter.aspx?ReportName=staffprice&ReportType=1') </script>");
    }
    protected void igbQuery_Click(object sender, ImageClickEventArgs e)
    {
        bindgr();
    }
    void bindgr()
    {
    //    string productNo = "";// this.txtname.Text.Trim().ToString();
    //    string tabcell = "";
    //    if (this.ddlquery.SelectedValue.ToString() != "")
    //    {
    //        tabcell = this.ddlquery.SelectedValue.ToString();
    //        if (this.txtname.Text.Trim().ToString()!="")
    //        productNo = this.txtname.Text.Trim().ToString();
    //    }

    //    string ProductDatePlanStart = txtProductDatePlanStart.Value.Trim().ToString();
    //    string strTime1 = txtTime_1.Value.Trim().ToString();
    //    string ProductDatePlanEnd = txtProductDatePlanEnd.Value.Trim().ToString();
    //    string strTime2 = txtTime_2.Value.Trim().ToString();
    //    // Response.Write(ProductDatePlanStart +"" + strTime1);
    //    string StartDate = ProductDatePlanStart + " " + strTime1 + ":00";
    //    string StopDate = ProductDatePlanEnd + " " + strTime2 + ":00";


    //    Admin.SQLServerDAL.Common cmm = new Common();
    //    productNo = cmm.GetSafeSqlText(true, productNo);
    //    string strSQL = "";
    //    SQLExecutant sqlExec = new SQLExecutant();
    //    DataTable dt = new DataTable();
    //    DataSet ds = new DataSet();
    //    if (productNo == "" && ProductDatePlanStart == "" && ProductDatePlanEnd == "")
    //    {
    //        strSQL = "select * from staff_view where 1=1 ";
    //        //if (!string.IsNullOrEmpty(strSQL))
    //        //{
    //        //    dt = sqlExec.ExecQueryCmd(strSQL);

    //        //    ds.Merge(dt);
    //        //    this.gridStaff.DataSource = ds.Tables[0];
    //        //    this.gridStaff.DataBind();

    //        // ClientScript.RegisterStartupScript(this.GetType(), "aa", "<script>alert('"+ds.Tables[0].Rows.Count.ToString()+"')</script>");
    //        //}
    //    }
    //    else if (productNo != "" && tabcell !="" && ProductDatePlanStart == "" && ProductDatePlanEnd == "")
    //    {
    //        strSQL = "select * from staff_view where 1=1   and "+tabcell+" like '%" + productNo + "%'";
    //    }
    //    else if (productNo == "" && tabcell != ""  && ProductDatePlanStart != "" && ProductDatePlanEnd != "")
    //    {
    //        strSQL = "select * from staff_view where 1=1   and  入库时间 >='" + StartDate + "' and 入库时间 <= '" + StopDate + "'";
    //    }
    //    else
    //    {
    //        strSQL = "select * from staff_view where 1=1   and " + tabcell + " like '%" + productNo + "%' and  入库时间 >='" + StartDate + "' and 入库时间 <= '" + StopDate + "'";
    //    }
    //    //  Response.Write(strSQL);
    //    dt = sqlExec.ExecQueryCmd(strSQL + " ORDER BY 入库时间 DESC");

    //    ds.Merge(dt);
    //    this.gridStaff.DataSource = ds.Tables[0];
    //    this.gridStaff.DataBind();
    //    dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, gridStaff, ds.Tables[0].Rows.Count);
    //    dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, gridStaff);
    }
    protected void CtrlPageInfo_Click(object sender, ImageClickEventArgs e)
    {

        //ImageButton tempImageButton = sender as ImageButton;
        //if (tempImageButton.ID == "igbSearch")
        //{
        //    string strPageIndex = txtPageIndex.Text.Trim();
        //    if (strPageIndex == "" || strPageIndex == null) return;
        //    gridStaff.PageIndex = int.Parse(strPageIndex) - 1;
        //}
        //else
        //    gridStaff.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
        //bindgr();
    }
}
