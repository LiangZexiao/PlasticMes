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
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.DBUtility;


public partial class BaseInfo_SalaryManage : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(BaseInfo_SalaryManage));
        try
        {
            //Session["ClickMould"] = @"BaseInfo/CustomerInfo.aspx";
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
            if (o[1]) igbInsert.Visible = btnInsert.Visible = igbNewadd.Visible = false;
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
             //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        if (txtInBeginDate.Value.ToString().Trim() == string.Empty) txtInBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (txtInEndDate.Value.ToString().Trim() == string.Empty) txtInEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string BeginDate = txtInBeginDate.Value.Trim();
        string EndDate = txtInEndDate.Value.Trim();

        IList<SalaryManage_MDL> tempList = new SalaryManage_DAL().selectSalaryManage(0, colname, coltext, BeginDate, EndDate); 
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        txtEmpName.Text = txtHiddenEmpName.Value.Trim();

        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string EmployeeName = txtEmpName.Text.Trim();
        string CardID = "";//txtCardID.Text.Trim();
        string DoNo = "";// txtDo_No.Text.Trim();
        string vEmpID = txtEmpID.Value.Trim();
        string MachineNo = "";
        switch (ddlWorkShop.SelectedValue) 
        {
            case "注一车间":
                {
                    MachineNo = "IM010000";
                    break; 
                }
            case "注二车间":
                {
                    MachineNo = "IM020000";
                    break; 
                }
            case "注三车间":
                {
                    MachineNo = "IM030000";
                    break;
                }
            case "植毛-注塑":
                {
                    MachineNo = "IM040000";
                    break; 
                }
            case "植毛-植毛":
                {
                    MachineNo = "PM000000";
                    break;
                }
        }        
        string MouldNo = "";// txtMouldNo.Text.Trim();
        string ProductNo = "";//txtProductNo.Text.Trim();
        string ProductDesc = "";// txtProductDesc.Text;
        string Num ="";
        string BeginDate = txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim();     

        string MachineWage = "";//txtMachineWage.Text.Trim() == "" ? "0" : txtMachineWage.Text.Trim();
        string TimeWage = txtTimeWage.Text.Trim() == "" ? "0" : txtTimeWage.Text.Trim();
        //string CheckWage = txtCheckWage.Text.Trim() == "" ? "0" : txtCheckWage.Text.Trim();
        //string JobWage = txtJobWage.Text.Trim() == "" ? "0" : txtJobWage.Text.Trim();
        //string ServiceWage = txtServiceWage.Text.Trim() == "" ? "0" : txtServiceWage.Text.Trim();
        //string OtherWage = txtOtherWage.Text.Trim() == "" ? "0" : txtOtherWage.Text.Trim();
     
        string Remark = txtRemark.Text.Trim();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            SalaryManage_MDL sm = new SalaryManage_MDL(vID, EmployeeName, CardID, DoNo, MachineNo, MouldNo, ProductNo, ProductDesc, Num, BeginDate, EndDate, MachineWage, TimeWage,  Remark, "",vEmpID);
            int t = new SalaryManage_DAL().ChangeSalaryManage(sm, IU);
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
                new SalaryManage_DAL().cancelSalaryManage(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                new SalaryManage_DAL().cancelSalaryManage(pIDList);
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
            //object[] textboxid = {txtID, txtBeginDate, txtEndDate,  txtTimeWage,  txtRemark," "  };
            //dboSetCtrls.InitCtrls(this, "textbox", textboxid);
                                                              
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmpName);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        IList<SalaryManage_MDL> tempIList = new SalaryManage_DAL().selectSalaryManage(Int32.Parse(vID), "", "");
        //txtCardID.Text = tempIList[0].CardID;
        //txtDo_No.Text = tempIList[0].Do_No;
        //txtEmployeeName_CN.Text = tempIList[0].EmployeeName;
        //txtMachineNo.Text = tempIList[0].MachineNo;
        //txtMouldNo.Text = tempIList[0].MouldNo;
        //txtProductNo.Text = tempIList[0].ProductNo;
        //txtProductDesc.Text = tempIList[0].ProductDesc;

        //txtMachineWage.Text = tempIList[0].MachineWage;
        txtTimeWage.Text = tempIList[0].TimeWage;
        //txtCheckWage.Text = tempIList[0].CheckWage;
        //txtJobWage.Text = tempIList[0].JobWage;
        //txtServiceWage.Text = tempIList[0].ServiceWage;
        //txtOtherWage.Text = tempIList[0].OtherWage;

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
        if (txtInBeginDate.Value.ToString().Trim() == string.Empty) txtInBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (txtInEndDate.Value.ToString().Trim() == string.Empty) txtInEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string BeginDate = txtInBeginDate.Value.Trim();
        string EndDate = txtInEndDate.Value.Trim();

        int t = new SalaryManage_DAL().InsertIntoSalaryManage(BeginDate, EndDate);
        if (t > 0)
        {
            dboSetCtrls.SetExecMsg(this, "生成工资成功！");
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
        //string BeginDate = txtDate1.Value.Trim();
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
            DataSet ds = new SalaryManage_DAL().selectSalaryManage2(0, colname, coltext, BeginDate, EndDate);
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
        string strSQL = "select dbo.GetEmpNameByID('"+EmpNo+"') Name ";
        DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
        if (dtTmp != null)
        {
            retItems.Add(dtTmp.Rows[0]["Name"].ToString().Trim());
        }
        return retItems;
    }
    #endregion
}
