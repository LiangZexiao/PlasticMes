using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Machine_MDL;
using Admin.BLL.Machine_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Machine_MachineCollectMap : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    MachineCollectMap_BLL bllMachineCollectMap = new MachineCollectMap_BLL();
    MachineCollectMap_MDL mdlMachineCollectMap = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["ClickMould"] = @"Machine/MachineCollectMap.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MachineCollectMap");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnInsert.Visible = false;
            if (o[2]) btnUpdate.Visible = false;
            if (o[3]) btnDelete.Visible = btnCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        
        if(! this.Page.IsPostBack)
        {
            BindData();
            this.MultiView1.ActiveViewIndex = 0;
            dboSetCtrls.SetInfoDropDownList(this.ddlQuery, this.GridView1);
            btnCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
        }        
    }

    private void BindData()
    {
        string colname = this.ddlQuery.SelectedValue.ToString().Trim();
        string coltext = this.txtQuery.Text.ToString().Trim();
        mdlMachineCollectMap = (colname != "" && coltext != "")?new MachineCollectMap_MDL(colname, coltext):new MachineCollectMap_MDL();
        DataTable dt = bllMachineCollectMap.selectMachineCollectMap(mdlMachineCollectMap);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
        dboSetCtrls.SetInfoOfLabel(this.lblGridViewInfo, this.GridView1, dt);
        dboSetCtrls.SetInfoOfLinkButtonPage(this.lkbFirstPage, this.lkbPriorPage, this.lkbNextPage, this.lkbLastPage, this.GridView1);
    }

    protected void btnINS_UDP_DEL_Click(object sender, EventArgs e)
    {
        string vID = this.txtID.Text.ToString().Trim();
        string vMachineNO = this.txtMachineNO.Text.ToString().Trim();
        string vCollectNO = this.txtCollectNO.Text.ToString().Trim();
        string vRemark    = this.txtRemark.Text.ToString().Trim();

        Button tempButton = sender as Button;
        try
        { 
            if(tempButton.ID == "btnInsert")
            {
                mdlMachineCollectMap = new MachineCollectMap_MDL(false, vMachineNO);
                if (!bllMachineCollectMap.isexistpkMachineCollectMap(mdlMachineCollectMap))
                {
                    dboSetCtrls.SetExecMsg(this, "存在重复的记录!!");
                    return;
                }
                mdlMachineCollectMap = new MachineCollectMap_MDL(vMachineNO, vCollectNO, vRemark);
                if (bllMachineCollectMap.insertMachineCollectMap(mdlMachineCollectMap) == 1)
                {
                    dboSetCtrls.SetExecMsg(this, "insert",true);
                    this.BindData();
                }
                else
                    dboSetCtrls.SetExecMsg(this, "insert",false);
            }
            else
            {
                mdlMachineCollectMap = new MachineCollectMap_MDL(vID,vMachineNO,vCollectNO,vRemark);
                if (bllMachineCollectMap.updateMachineCollectMap(mdlMachineCollectMap) == 1)
                {
                    dboSetCtrls.SetExecMsg(this, "update",true);
                    this.BindData();
                }
                else
                    dboSetCtrls.SetExecMsg(this, "update",false);
            }
        }
        catch
        {

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button tempButton = sender as Button;
        bool isFlag = false;
        if (tempButton.ID == "btnDelete")
        {   
            mdlMachineCollectMap = new MachineCollectMap_MDL(true,txtID.Text.Trim());
            isFlag = (bllMachineCollectMap.deleteMachineCollectMap(mdlMachineCollectMap) == 1)?true:false;
        }
        else
        {
            ArrayList vIDs = new ArrayList();
            vIDs = dboSetCtrls.GetCancelRecordID(GridView1);
            mdlMachineCollectMap = new MachineCollectMap_MDL(vIDs);
            isFlag = (bllMachineCollectMap.cancelMachineCollectMap(mdlMachineCollectMap) == vIDs.Count && vIDs.Count != 0)?true:false;
        }
        if(isFlag)
        {
            dboSetCtrls.SetExecMsg(this, "delete", true);
            this.BindData();
        }
        else
            dboSetCtrls.SetExecMsg(this, "delete", false);
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetButtonEnabled(false, btnInsert, btnUpdate, btnDelete);

        string vID = txtID.Text = hdnID.Value = 
            ((this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        MachineCollectMap_MDL tempObject = bllMachineCollectMap.chooseMachineCollectMap(new MachineCollectMap_MDL(true,vID));
        
        txtMachineNO.Text = tempObject.V_MachineNO;
        txtCollectNO.Text = tempObject.V_CollectNO;
        txtRemark.Text    = tempObject.V_Remark;
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnVisible_Click(object sender, EventArgs e)
    {
        Button tempButton = sender as Button;
        if (tempButton.ID == "btnNewadd")
        {
            this.MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetButtonEnabled(true, btnInsert, btnUpdate, btnDelete);
            object[] textboxid = {txtMachineNO,txtCollectNO,txtRemark};
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
        }
        else
        {
            this.MultiView1.ActiveViewIndex = 0;
            BindData();
        }
    }

    protected void lkbChangPage_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = System.Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
        this.BindData();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
