﻿using System;
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
using Admin.BLL.Product_BLL;
using Admin.Model.Product_MDL;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.DBUtility;


public partial class BaseInfo_SalaryManageAdjust : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(BaseInfo_SalaryManageAdjust));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "SalaryManage");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = ibgOutPut.Visible = false;
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
            // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        if (txtInBeginDate.Value.ToString().Trim() == string.Empty) txtInBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (txtInEndDate.Value.ToString().Trim() == string.Empty) txtInEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string BeginDate = txtInBeginDate.Value.Trim() ;
        string EndDate = txtInEndDate.Value.Trim();

        IList<SalaryManageAdjust_MDL> tempList = new SalaryManageAdjust_DAL().selectSalaryManage(0, colname, coltext, BeginDate, EndDate); //CustomerInfo_BLL.selectCustomerInfo(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());

        txtMachineNo.Text = txtHiddenMachineNo.Value.Trim();
        txtProductNo.Text = txtHiddenProductNo.Value.Trim();
        txtProdDesc.Text = txtHiddenProdDesc.Value.Trim();
        txtEmpName.Text = txtHiddenEmpName.Value.Trim();

        string EmployeeName = txtEmpName.Text.Trim();
        string CardID = "";//txtCardID.Text.Trim();
        string Do_No = txtDispatchNo.Text.Trim();
        string MachineNo = txtMachineNo.Text.Trim();
        string MouldNo = "";// txtMouldNo.Text.Trim();
        string ProductNo = txtProductNo.Text.Trim();
        string ProductDesc = txtProdDesc.Text;
        string vEmpID = txtEmpID.Text.Trim();

        string BeginDate = txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim();

        string AdjustWage = txtMachineWage.Text.Trim() == "" ? "0" : txtMachineWage.Text.Trim();
        //string TimeWage = txtTimeWage.Text.Trim() == "" ? "0" : txtTimeWage.Text.Trim();
        //string CheckWage = txtCheckWage.Text.Trim() == "" ? "0" : txtCheckWage.Text.Trim();
        //string JobWage = txtJobWage.Text.Trim() == "" ? "0" : txtJobWage.Text.Trim();
        //string ServiceWage = txtServiceWage.Text.Trim() == "" ? "0" : txtServiceWage.Text.Trim();
        //string OtherWage = txtOtherWage.Text.Trim() == "" ? "0" : txtOtherWage.Text.Trim();
     
        string Remark = txtRemark.Text.Trim();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            SalaryManageAdjust_MDL sm = new SalaryManageAdjust_MDL(vID, EmployeeName, CardID, Do_No, MachineNo, MouldNo, ProductNo, ProductDesc, BeginDate, EndDate,
                            AdjustWage, Remark, "", vEmpID);
            int t = new SalaryManageAdjust_DAL().ChangeSalaryManage(sm, IU);
            if (t > 0)
            {
                dboSetCtrls.SetExecMsg(this, IU, true);
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }
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
                new SalaryManageAdjust_DAL().cancelSalaryManage(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                new SalaryManageAdjust_DAL().cancelSalaryManage(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmpName);
            txtEmpID.Text = "";
            txtBeginDate.Value = "";
            txtEndDate.Value = "";
            txtDispatchNo.Text = "";
            txtMachineNo.Text = "";
            txtProductNo.Text = "";
            txtProdDesc.Text = "";
            txtMachineWage.Text = "";
            txtEmpName.Text = "";
            txtRemark.Text = "";
                                                              
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmpName);

        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        string vCmd = e.CommandName.Trim();

        IList<SalaryManageAdjust_MDL> tempIList = new SalaryManageAdjust_DAL().selectSalaryManage(Int32.Parse(vID), "", "");
        txtDispatchNo.Text = tempIList[0].Do_No;
        txtEmpName.Text = tempIList[0].EmployeeName;
        txtEmpID.Text = tempIList[0].EmpID;
        txtMachineNo.Text = tempIList[0].MachineNo;
        txtBeginDate.Value = tempIList[0].BeginDate.ToString() == "" ? "" : Convert.ToDateTime(tempIList[0].BeginDate.ToString()).ToString("yyyy-MM-dd HH:mm");
        txtEndDate.Value = tempIList[0].EndDate.ToString() == "" ? "" : Convert.ToDateTime(tempIList[0].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm");
        txtProductNo.Text = tempIList[0].ProductNo;
        txtProdDesc.Text = tempIList[0].ProductDesc;

        txtMachineWage.Text = tempIList[0].AdjustWage;
        txtRemark.Text = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtInBeginDate.Value.ToString().Trim() == "" || txtInEndDate.Value.ToString().Trim() =="")
        {
            dboSetCtrls.SetExecMsg(this, "请选择需生成工资的时间段！");
            return;
        }

        int t = new SalaryManageAdjust_DAL().InsertIntoSalaryManage(txtInBeginDate.Value.ToString(), txtInEndDate.Value.ToString());
        if (t > 0)
        {
            dboSetCtrls.SetExecMsg(this, "生成 "+txtInBeginDate.Value.ToString()+ " 到 "+txtInEndDate.Value.ToString()+"成功！");
        }
        else
        {
            dboSetCtrls.SetExecMsg(this, "生成失败：原因：该时间段内已没有需要生成工资的记录。");
        }
        BindData();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //string colname = ddlQuery.SelectedValue.ToString().Trim();
        //string coltext = txtQuery.Text.ToString().Trim();
        //string BeginDate = txtInBeginDate.Value.Trim();
        //string EndDate = txtDate2.Value.Trim();
        //IList<SalaryManage_MDL> tempList = new SalaryManage_DAL().selectSalaryManage(0, colname, coltext, BeginDate, EndDate); //CustomerInfo_BLL.selectCustomerInfo(0, colname, coltext);

        Response.Clear();
        //GridView ddd = new GridView();
        //ddd.DataSource = tempList;// (GridView1.DataSource as DataTable).DefaultView;
        //ddd.DataBind();
        if ((GridView1.Rows.Count) > 0)
        {
            string colname = ddlQuery.SelectedValue.ToString().Trim();
            string coltext = txtQuery.Text.ToString().Trim();

            if (txtInBeginDate.Value.ToString().Trim() == string.Empty) txtInBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            if (txtInEndDate.Value.ToString().Trim() == string.Empty) txtInEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string BeginDate = txtInBeginDate.Value.Trim();
            string EndDate = txtInEndDate.Value.Trim();

            GridView ddd = new GridView();
            DataSet ds = new SalaryManageAdjust_DAL().selectSalaryManage2(0, colname, coltext, BeginDate, EndDate);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=SalaryManage.xls");
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

    #region
    [Ajax.AjaxMethod()]
    public ArrayList getSearchEmpName(string EmpNo)
    {
        ArrayList retItems = new ArrayList();
        string strSQL = "select dbo.GetEmpNameByID('" + EmpNo + "') Name ";
        DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
        if (dtTmp != null)
        {
            retItems.Add(dtTmp.Rows[0]["Name"].ToString().Trim());
        }
        return retItems;
    }
    #endregion

    #region
    [Ajax.AjaxMethod()]
    public ArrayList getSearchDispatchNo(string dispatchno)
    {
        ArrayList retItems = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "DO_No", dispatchno);

        for (int t = 0; t < tempList.Count; t++)
        {
            retItems.Add(tempList[t].MachineNo.Trim());
            retItems.Add(tempList[t].ProductNo.Trim());
            retItems.Add(tempList[t].ProductDesc.Trim());
        }
        return retItems;
    }
    #endregion
}