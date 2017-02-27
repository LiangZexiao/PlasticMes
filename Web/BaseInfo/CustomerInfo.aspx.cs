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
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class BaseInfo_CustomerInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"BaseInfo/CustomerInfo.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "CustomerInfo");
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
        IList<CustomerInfo_MDL> tempList = CustomerInfo_BLL.selectCustomerInfo(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string CustomerNo   = txtCustomerNo.Text.Trim();
        string CustomerName = txtCustomerName.Text.Trim();
        string LinkMan      = txtLinkMan.Text.Trim();
        string Bank         = txtBank.Text.Trim();
        string Account      = txtAccount.Text.Trim();
        string TelNumber    = txtTel.Text.Trim();
        string FaxNumber    = txtFax.Text.Trim();
        string WebSite      = txtWebSite.Text.Trim();
        string EMail        = txtEMail.Text.Trim();
        string OfficeAddr   = txtOfficeAddr.Text.Trim();

        string WareHouse    = txtWareHouse.Text.Trim();
        string BalanceKind  = ddlBalanceKind.SelectedValue.Trim();
        string Remark       = txtRemark.Text.Trim();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (CustomerInfo_BLL.existsCustomerInfo(txtCustomerNo.Text.Trim()).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的客户编号!!");
                    return;
                }
            }
            CustomerInfo_BLL.ChangeCustomerInfo(vID,
                      CustomerNo, CustomerName, LinkMan, Bank, Account, TelNumber, FaxNumber, WebSite, EMail, OfficeAddr,
                      WareHouse, BalanceKind, Remark, IU
                   );
            dboSetCtrls.SetExecMsg(this, IU, true);
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
                CustomerInfo_BLL.cancelCustomerInfo(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                CustomerInfo_BLL.cancelCustomerInfo(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtCustomerNo);
            object[] textboxid = {
                txtID, txtCustomerNo, txtCustomerName, txtLinkMan, txtTel,
                txtFax, txtWebSite, txtEMail, txtOfficeAddr, txtWareHouse,

                txtBank, txtAccount, txtRemark
            };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            ddlBalanceKind.SelectedIndex = 0;
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtCustomerNo);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        IList<CustomerInfo_MDL> tempIList = CustomerInfo_BLL.selectCustomerInfo(Int32.Parse(vID), "", "");
        txtCustomerNo.Text  = tempIList[0].CustomerNo;
        txtCustomerName.Text= tempIList[0].CustomerName;
        txtLinkMan.Text     = tempIList[0].LinkMan;
        txtTel.Text         = tempIList[0].Tel;
        txtFax.Text         = tempIList[0].Fax;
        txtWebSite.Text     = tempIList[0].WebSite;
        txtEMail.Text       = tempIList[0].EMail;
        txtOfficeAddr.Text  = tempIList[0].OfficeAddr;
        txtWareHouse.Text   = tempIList[0].WareHouse;
        txtBank.Text        = tempIList[0].Bank;
        txtAccount.Text     = tempIList[0].Account;
        ddlBalanceKind      = dboSetCtrls.SetSelectedIndex(ddlBalanceKind, tempIList[0].BalanceKind);
        txtRemark.Text      = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
