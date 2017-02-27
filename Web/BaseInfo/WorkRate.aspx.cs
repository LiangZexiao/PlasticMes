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
using Admin.Model.Machine_MDL;
//using Admin.BLL.Machine_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.Model.Product_MDL;

public partial class BaseInfo_WorkRate : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    Admin.SQLServerDAL.BaseInfo_DAL.WorkRate_DAL myWork = new WorkRate_DAL();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "WorkRate");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = false;
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
            dboSetCtrls.SetDropDownList(ddlitem_code, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, false, "Item_Code", "Item_NameCH");

            // igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            // igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            //  igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
        }
    }

    /// <summary>
    /// 绑定GridView
    /// </summary>
    void BindData()
    {
        string itemcode = txtQuery.Text.Trim().ToString();
        DataTable myLst = (itemcode != "" ? myWork.SelectWorkRate(itemcode) : myWork.SelectWorkRate());
        this.GridView1.DataSource = myLst;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, myLst.Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }


    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbUpdate, "DROPDOWNLIST", ddlitem_code);
            this.txtMachine_Code.Visible = false;
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
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (hdnID.Value.Trim() == "") ? 0 : int.Parse(hdnID.Value.Trim());
        string workrate = this.txtMachine_NameCH.Text.Trim().ToString();
        string itemcode = this.ddlitem_code.SelectedValue.ToString();
        string overtime_num = this.txtovertime.Text.Trim().ToString();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (myWork.SelectWorkRate(itemcode, workrate).Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('该产品作业速度的设置已经存在!');</script>");
                    return;
                }
                else
                {
                    myWork.UpdateWorkRate(itemcode, workrate, overtime_num);
                }
            }
            else
            {
                myWork.UpdateWorkRate(vID, workrate, overtime_num);
            }
            dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        // this.
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbUpdate, "textbox", txtMachine_Code);
        this.ddlitem_code.Visible = false;
        this.txtMachine_Code.Enabled = false;
        txtMachine_Code.ReadOnly = true;
        string vID = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();
        DataTable dt = myWork.SelectWorkRate(int.Parse(vID));
        this.txtMachine_Code.Text = dt.Rows[0]["Item_Code"].ToString();
        this.txtMachine_NameCH.Text = dt.Rows[0]["workrate"].ToString();
        this.txtovertime.Text = dt.Rows[0]["overtime_num"].ToString();
        //IList<ItemMstr_MDL> tempIList = ItemMstr_BLL.selectItemMstr(Int32.Parse(vID), "", "");
        //this.txtMachine_Code.Text = tempIList[0].Item_Code.ToString();
        //this.txtMachine_NameCH.Text=tempIList[0]
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                pIDList.Add(hdnID.Value.Trim());
                myWork.DeleteWorkRate(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                myWork.DeleteWorkRate(pIDList);
                BindData();
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void hdcode_ServerChange(object sender, EventArgs e)
    {
        
    }
}
