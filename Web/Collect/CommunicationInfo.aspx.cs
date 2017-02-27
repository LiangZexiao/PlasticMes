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
using Admin.Model.Collect_MDL;
using Admin.BLL.Collect_BLL;
using Admin.Model.Machine_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.BaseInfo_DAL;

public partial class Collect_CommunicationInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "CommunicationInfo");
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
            MultiView1.ActiveViewIndex = 0; 
            BindData();           
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            DataTable dt=new MachineMstr_DAL().selectWorkShop();
           // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
           // dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, "Machine_Code", "Machine_Code");
            dboSetCtrls.SetDropDownList(ddlMachineNo, new Admin.SQLServerDAL.Product_DAL.SuitManage_DAL().selectSuitManage(0) as IList, true, "PlantBristlesCode", "PlantBristlesCode");
            dboSetCtrls.SetDropDownList(ddlWorkShop, dt, " MachineNo", "WorkShop");
        }
    }
    public void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<CommunicationInfo_MDL> tempList = CommunicationInfo_BLL.selectCommunicationInfo(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
        //string sql = "SELECT ID, MachineNo, CollectorNo, IPAddr as ipsip, Port, NetGate, CommStatus AS CommStatusID,CASE CommStatus WHEN '0' THEN '不启用' ELSE '启用' END AS CommStatus, Remark FROM  dbo.CommunicationInfo";

    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vMachineNo = ddlMachineNo.SelectedValue.Trim();
        string vCollectorNo = txtCollectorNo.Text.Trim();
        string vIPAddr = txtIPAddr.Text.Trim();
        string vPort = txtPort.Text.Trim();
        string vNetGate = txtNetGate.Text.Trim();
        string vCommStatus = rblCommStatus.SelectedValue.Trim();
        string vRemark = txtRemark.Text.Trim();
        string vWorkShop = ddlWorkShop.SelectedItem.Text.Trim();
        string vWorkShopID = ddlWorkShop.SelectedValue.Trim();

        int s = 0;
        string IU = IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (vMachineNo == "")
                {
                    dboSetCtrls.SetExecMsg(this, "机器编号不能为空!!");
                    return;
                }
                if (CommunicationInfo_BLL.existsCommunicationInfo(vMachineNo, vCollectorNo).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的数据!!");
                    return;
                }
                if(CommunicationInfo_BLL.existsCommunicationInfo2("IPAddr",vIPAddr).Count>0)
                {
                    dboSetCtrls.SetExecMsg(this, "该IP地址已经使用!!");
                    return;
                }
            }
            s = CommunicationInfo_BLL.ChangeCommunicationInfo(vMachineNo, vCollectorNo, vIPAddr, vPort, vNetGate,
                vCommStatus, vRemark,vWorkShopID,vWorkShop, vID, IU);
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
                CommunicationInfo_BLL.cancelCommunicationInfo(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                CommunicationInfo_BLL.cancelCommunicationInfo(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "dropdownlist", ddlMachineNo);
            object[] textboxid = {txtCollectorNo, txtIPAddr, txtPort, txtNetGate, txtRemark};
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            ddlMachineNo.SelectedIndex = rblCommStatus.SelectedIndex = 0;
            ddlWorkShop.SelectedIndex  = 0;
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "dropdownlist", ddlMachineNo);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();
        IList<CommunicationInfo_MDL> tempIList = CommunicationInfo_BLL.selectCommunicationInfo(Int32.Parse(vID), "", "");

       // ClientScript.RegisterStartupScript(this.GetType(), "aa", "<script>alert('ip地址是：" + tempIList[0].IPAddr + "')</script>");
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempIList[0].MachineNo);
        txtCollectorNo.Text = tempIList[0].CollectorNo;
        txtIPAddr.Text = tempIList[0].IPAddr;
        ddlWorkShop = dboSetCtrls.SetSelectedIndex(ddlWorkShop, tempIList[0].WorkShopID);
        
        txtPort.Text = tempIList[0].Port;
        txtNetGate.Text = tempIList[0].NetGate;
        rblCommStatus.SelectedValue = tempIList[0].CommStatusID;
        txtRemark.Text = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
