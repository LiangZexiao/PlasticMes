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
using System.IO;
using Admin.App_Code;
using Admin.SQLServerDAL.Call_DAL;
using Admin.Model.Product_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.Product_DAL;

public partial class Product_ClampManage : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    private ClampManage_DAL ClampManages = new ClampManage_DAL();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ClampManage");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnNewadd.Visible = btnInsert.Visible = false;
            if (o[2])  btnUpdate.Visible = false;
            if (o[3]) btnCancel.Visible = btnDelete.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
            dataBind();
          //  dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            btnCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            dboSetCtrls.SetDropDownList(ddlPlantBristlesMachine, new MachineSuit_DAL().selectMachineSuit(0, "", "") as IList, false, "MachineCode", "MachineCode");
            
        }
    }

    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.Trim().ToString();
        string coltext = txtQuery.Text.Trim().ToString();
        if (Request.QueryString["MouldNo"]!=null && Request.QueryString["MouldNo"].ToString().Trim() != "")
        {
            colname = "FixtureCode";
            coltext = Request.QueryString["MouldNo"].ToString().Trim();
            btnNewadd.Visible = false;
            btnCancel.Visible = false;
            btnInsert.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        IList<ClampManage_MDL> tempList = ClampManages.selectClampManage(0, colname, coltext);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtFixtureCode);
            // this.ddlMachineNo.SelectedValue = "";
            /// this.ddlUnit.SelectedValue = "";
            // this.txtCycle.Text = "";
            // this.txtNum.Text = "";
            txtFixtureCode.Text = txtWarehouseLocation.Text = txtProgram.Text = txtFixtureDesc.Text =txtRemark.Text="";
            txtVer.Text = "1";
            ddlPlantBristlesMachine.SelectedIndex = 0; 
        }
        else
        {
            if (tempButton.ID != "btnQuery")
                MultiView1.ActiveViewIndex = 0;
            dataBind();
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
        dataBind();
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
                // ItemMstr_BLL.cancelItemMstr(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                // t = new WorkPaper_DAL().cancelItemMstr(pIDList);
                // ItemMstr_BLL.cancelItemMstr(pIDList);                
            }
            t = ClampManages.DeleteClampManage(pIDList);
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
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        string vFixtureCode=txtFixtureCode.Text.Trim(); 
        string vFixtureDesc=txtFixtureDesc.Text.Trim(); 
        string vWarehouseLocation=txtWarehouseLocation.Text.Trim();
        string vPlantBristlesMachine=ddlPlantBristlesMachine.SelectedValue;
        string vProgram=txtProgram.Text.Trim();
        string vModiContent="";
        string vLastModifier=this.Page.User.Identity.Name.Trim();
        string vLastModiDate=System.DateTime.Now.ToString("yyyy-MM-dd");
        string vVer=txtVer.Text.Trim();
        string vRemark=txtRemark.Text.Trim();
        string vMachineCycle = txtMachineCycle.Text.Trim();

        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";
        try
        {
            ClampManage_MDL call = new ClampManage_MDL(txtID.Text.Trim().ToString(), vFixtureCode, vFixtureDesc,
                       vWarehouseLocation, vPlantBristlesMachine, vProgram, vModiContent, vLastModifier
                       , vLastModiDate, vVer, vRemark, vMachineCycle);
            if (UI == "INSERT")
            {
                if (new ClampManage_DAL().selectClampManage(0, "FixtureCode", vFixtureCode,1).Count > 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同夹具编号!");
                    return;
                }
            }
            //if (vImgType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            //{
            //    dboSetCtrls.SetExecMsg(this, "产品图只能是图片!");
            //    return;
            //}
            if (ClampManages.InsertClampManage(call, UI) == 1)
            {
                dboSetCtrls.SetExecMsg(this, UI, true);
                //BindData();
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, UI, false);
            }
        }
        catch //(Exception ex)
        {
            // string temp = ex.ToString().Trim();
            // Response.Write(ex.Message);
            dboSetCtrls.SetExecMsg(this, UI, false);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;

        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtFixtureCode);
        string vID = txtID.Text = hdnID.Value =((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();


        IList<ClampManage_MDL> tempList = ClampManages.selectClampManage(int.Parse(vID), "", "");


        txtFixtureCode.Text = tempList[0].FixtureCode;
        txtFixtureDesc.Text = tempList[0].FixtureDesc;
        txtWarehouseLocation.Text = tempList[0].WarehouseLocation;
        ddlPlantBristlesMachine = dboSetCtrls.SetSelectedIndex(ddlPlantBristlesMachine, tempList[0].PlantBristlesMachine);
        txtProgram.Text = tempList[0].Program;
        txtVer.Text = tempList[0].Ver;
        txtRemark.Text = tempList[0].Remark;
        txtMachineCycle.Text = tempList[0].MachineCycle;

    }
}
