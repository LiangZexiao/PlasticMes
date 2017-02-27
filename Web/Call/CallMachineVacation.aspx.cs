using System;
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
using Admin.Model.Machine_MDL;
using Admin.Model.BaseInfo_MDL;
using Admin.SQLServerDAL;
using Admin.BLL.Product_BLL;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;

public partial class Call_CallMachineVacation : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    private CallMachineVacation_DAL callmac = new CallMachineVacation_DAL();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MachineVacation");
            ViewState["authority"] = o;
            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnNewadd.Visible = btnInsert.Visible = false;
            if (o[2]) btnUpdate.Visible = false;
            if (o[3]) btnCancel.Visible = btnDelete.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
            btnCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");
            ddlWorkShop.Items.Clear();
            ddlWorkShopSearch.Items.Clear();
            ddlWorkShop.Items.Add(new ListItem("选择", ""));
            ddlWorkShopSearch.Items.Add(new ListItem("选择", ""));
            DataTable dtWorkShop = MachineMstr_BLL.selectWorkShop();
            foreach (DataRow dr in dtWorkShop.Rows)
            {
                ddlWorkShop.Items.Add(new ListItem(dr["WorkShop"].ToString().Trim(), dr["MachineNo"].ToString().Trim()));
                ddlWorkShopSearch.Items.Add(new ListItem(dr["WorkShop"].ToString().Trim(), dr["MachineNo"].ToString().Trim()));
            }
            ddlWorkShop.SelectedIndex = 0;
            ddlWorkShopSearch.SelectedIndex = 0;
            dataBind();
        }

    }

    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.Trim().ToString();
        string coltext = txtQuery.Text.Trim().ToString();
        string workshop = this.ddlWorkShopSearch.SelectedValue.Trim().ToString() ;
        IList<CallMachineVacation_MDL> tempList = callmac.selectMachineVacation(0, colname, coltext,workshop);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "btnNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "DROPDOWNLIST", ddlQuery);
            this.ddlMachineNo.SelectedIndex = 0;
            ddlMachineNo.Enabled = true;
            ddlWorkShop.Enabled = true;
            ddlWorkShop.SelectedIndex = 0;
        }
        else
        {
            if (tempButton.ID != "btnQuery")
                MultiView1.ActiveViewIndex = 0;
            dataBind();
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            int t = 0;
            if (tempButton.ID == "btnDelete")
            {
                pIDList.Add(txtID.Text.Trim());
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
           
            }
            t = callmac.cancelMachineVacation(pIDList);
            dataBind();
            if (t > 0)
            {
                dboSetCtrls.SetExecMsg(this, "delete", true);
            }
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }

    protected void ddlWorkShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        string MachineNo = ddlWorkShop.SelectedValue.Trim();
        if (MachineNo == "") return;
        ddlMachineNo.Items.Clear();
        DataTable dtMachine = MachineMstr_BLL.selectMachinePlant(MachineNo);
        DataRow dr = dtMachine.NewRow();
        dr["MachineCode"] = "全部";
        dtMachine.Rows.InsertAt(dr, 0);
        dboSetCtrls.SetDropDownList(ddlMachineNo, dtMachine, "MachineCode", "MachineCode");
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

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        string CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string MachineNo = this.ddlMachineNo.SelectedValue.ToString().Trim();
        string StartDate = txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim();
        string WorkShop = this.ddlWorkShop.SelectedValue.ToString().Trim();
        string Creator=this.Page.User.Identity.Name.Trim();
        string vID = txtID.Text.Trim() == "" ? "0" : txtID.Text.Trim();
        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";

        try
        {
            CallMachineVacation_MDL maVac = new CallMachineVacation_MDL(int.Parse(vID), MachineNo
               , StartDate, EndDate, Creator,CreateTime);
            if (UI == "INSERT")
            {
                if (ddlMachineNo.SelectedItem.Text == "全部")//应用到所有时先删除已有的机器
                {
                    callmac.deleteMachineVacation(StartDate,EndDate,WorkShop,"");
                }
                else
                {
                    if (callmac.selectMachineVac(StartDate,EndDate,"",MachineNo).Count > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, "该机器的配置已存在!");
                        return;
                    }
                }
            }

            if (ddlMachineNo.SelectedItem.Text == "全部" && UI == "INSERT")//应用到所有时 
            {
                DataTable dtTmp = MachineMstr_BLL.selectMachinePlant(WorkShop);

                foreach (DataRow dr in dtTmp.Rows)
                {
                    MachineNo = dr["MachineCode"].ToString().Trim();
                    callmac.ChangeMachineVacation(new CallMachineVacation_MDL(Convert.ToInt32(vID), MachineNo, StartDate, EndDate, Creator, CreateTime)
                         , UI);
                }
                dboSetCtrls.SetExecMsg(this, "INSERT", true);
            }
            else
            {
                if (callmac.ChangeMachineVacation(maVac, UI) == 1)
                {
                    dboSetCtrls.SetExecMsg(this, UI, true);
                }
                else
                {
                    dboSetCtrls.SetExecMsg(this, UI, false);
                }
            }
        }
        catch //(Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, UI, false);
        }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnUpdate, btnInsert, btnDelete, "DROPDOWNLIST",ddlQuery);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();
         IList<CallMachineVacation_MDL> tempList = callmac.selectMachineVacation(int.Parse(vID), "", "", "");

        ddlQuery = dboSetCtrls.SetSelectedIndex(ddlQuery, tempList[0].MachineNo);
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempList[0].MachineNo);
        ddlWorkShop = dboSetCtrls.SetSelectedIndex(ddlWorkShop, tempList[0].MachineNo.Substring(0, 2).ToUpper() == "IM" ||
                                          tempList[0].MachineNo.Substring(0, 2).ToUpper() == "PM" ?
                                          MachineMstr_BLL.selectParentWorkShop(tempList[0].MachineNo) : "");
        this.txtBeginDate.Value = tempList[0].StartDate.Trim();
        this.txtEndDate.Value = tempList[0].EndDate.Trim();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
