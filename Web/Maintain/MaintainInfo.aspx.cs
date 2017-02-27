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
using Admin.BLL.BaseInfo_BLL;
using Admin.Model.Maintain_MDL;
using Admin.BLL.Maintain_BLL;
using Admin.Model.Machine_MDL;
using Admin.BLL.Machine_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.DBUtility;


public partial class Maintain_MaintainInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"Maintain/MaintainInfo.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MaintainInfo");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }

        if (!IsPostBack)  //第一次打工页面
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");

            //IList tempList = Employee_BLL.selectEmployee(0, "", "") as IList;
            //dboSetCtrls.SetDropDownList(ddlApplier, tempList, false, "EmployeeID", "EmployeeName_CN");
            //dboSetCtrls.SetDropDownList(ddlDutyMan, tempList, false, "EmployeeID", "EmployeeName_CN");
            //dboSetCtrls.SetDropDownList(ddlChecker, tempList, false, "EmployeeID", "EmployeeName_CN");

            DataTable dtTmpRepair = Employee_BLL.selectEmployee("rankdesc", "机修");
            DataTable dtTmp = Employee_BLL.selectEmployee("", "");
            dboSetCtrls.SetDropDownList(ddlApplier, dtTmp, false, "EmployeeID", "EmployeeName_CN");
            dboSetCtrls.SetDropDownList(ddlDutyMan, dtTmpRepair, false, "EmployeeID", "EmployeeName_CN");
            dboSetCtrls.SetDropDownList(ddlChecker, dtTmp, false, "EmployeeID", "EmployeeName_CN");
            SetDeviceNo();

        }
    }

    public void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();

        IList<MaintainInfo_MDL> tempList = MaintainInfo_BLL.selectMaintainInfo(0, colname, coltext, "MaintainInfo");

        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vRepairBillID = txtRepairBillID.Text.Trim();
        string vRepareDate = (txtRepareDate.Value.Trim() == "") ? DateTime.Now.ToString("yyyy-MM-dd") : txtRepareDate.Value.Trim();
        string vDeviceType = ddlDeviceType.SelectedValue.Trim();
        string vDeviceNo = (ddlDeviceNo.Visible) ? ddlDeviceNo.SelectedValue.Trim() : txtDeviceNo.Text.Trim();
        string vRepairType = ddlRepairType.SelectedValue.Trim();
        string vRepairContent = txtRepairContent.Text.Trim();
        string vBeginDate = txtBeginDate.Value.Trim();
        string vEndDate = txtEndDate.Value.Trim();
        string vCompleteFlag = rblCompleteFlag.SelectedValue.Trim();
        string vApplier = ddlApplier.SelectedValue.Trim();
        string vDutyMan = ddlDutyMan.SelectedValue.Trim();
        string vChecker = ddlChecker.SelectedValue.Trim();
        string vRemark = txtRemark.Text.Trim();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        string vMessageFlag = "false";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (MaintainInfo_BLL.existsMaintainInfo(vRepairBillID).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的维修单编号!!");
                    return;
                }
            }
            MaintainInfo_BLL.ChangeMaintainInfo(vID,
                  vRepairBillID, vRepareDate, vDeviceType, vDeviceNo, vRepairType,
                 vRepairContent, vBeginDate, vEndDate, vCompleteFlag, vApplier,
                 vDutyMan, vChecker, vRemark, vMessageFlag,0,0, IU);
            dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
    }

    protected void btnVisible_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtRepairBillID);
            object[] textboxid = { txtID, txtRepairBillID, txtDeviceNo, txtRepairContent, txtRemark };

            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            txtBeginDate.Value = "07:20";
            txtEndDate.Value = "07:20";
            txtRepareDate.Value = null;
            ddlDeviceType.SelectedIndex = ddlRepairType.SelectedIndex = rblCompleteFlag.SelectedIndex = 1;
            ddlApplier.SelectedIndex = ddlDutyMan.SelectedIndex = ddlChecker.SelectedIndex = 0;
            string strToday = "B" + System.DateTime.Now.ToString("yyyyMMdd");
            string strSQL = @"select top 1 repairBillID   from  RepairDevice
                        where repairBillID like '{0}%'
                        order by ID DESC  ";
            string endNum;
            strSQL = string.Format(strSQL, strToday);
            DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                endNum = dtTmp.Rows[0]["repairBillID"].ToString().Substring(dtTmp.Rows[0]["repairBillID"].ToString().Length -3, 3);
                endNum = (Convert.ToInt32(endNum) + 1).ToString().PadLeft(3, '0').Trim();
                txtRepairBillID.Text = dtTmp.Rows[0]["repairBillID"].ToString().Substring(0, 9).Trim() + endNum;
            }
            else txtRepairBillID.Text = strToday + "001";
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                pIDList.Add(txtID.Text.Trim());
                MaintainInfo_BLL.cancelMaintainInfo(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                MaintainInfo_BLL.cancelMaintainInfo(pIDList);
                BindData();
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }

    protected void CtrlPageInfo_Click(object sender, EventArgs e)
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtRepairBillID);

        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();
        IList<MaintainInfo_MDL> tempIList = MaintainInfo_BLL.selectMaintainInfo(Int32.Parse(vID), "", "", "MaintainInfo");

        txtRepairBillID.Text = tempIList[0].RepairBillID;
        txtRepareDate.Value = tempIList[0].RepareDate;
        ddlDeviceType = dboSetCtrls.SetSelectedIndex(ddlDeviceType, tempIList[0].DeviceTypeID);

        SetDeviceNo();

        if (ddlDeviceNo.Visible)
            ddlDeviceNo = dboSetCtrls.SetSelectedIndex(ddlDeviceNo, tempIList[0].DeviceNo);
        else
            txtDeviceNo.Text = tempIList[0].DeviceNo;

        ddlRepairType = dboSetCtrls.SetSelectedIndex(ddlRepairType, tempIList[0].RepairTypeID);
        txtRepairContent.Text = tempIList[0].RepairContent;
        txtBeginDate.Value = tempIList[0].BeginDate;
        txtEndDate.Value = tempIList[0].EndDate;
        rblCompleteFlag.SelectedValue = tempIList[0].CompleteFlag.ToUpper();
        ddlApplier = dboSetCtrls.SetSelectedIndex(ddlApplier, tempIList[0].Applier);
        ddlDutyMan = dboSetCtrls.SetSelectedIndex(ddlDutyMan, tempIList[0].DutyMan);
        ddlChecker = dboSetCtrls.SetSelectedIndex(ddlChecker, tempIList[0].Checker);
        txtRemark.Text = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void ddlDeviceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetDeviceNo();
    }

    private void SetDeviceNo()
    {
        string DeviceType = ddlDeviceType.SelectedValue.Trim();
        if (DeviceType != "3")
        {
            ddlDeviceNo.Visible = true; txtDeviceNo.Visible = false;
            ddlDeviceNo.Items.Clear();
            if (DeviceType == "1")
                dboSetCtrls.SetDropDownList(ddlDeviceNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, false, "Machine_Code", "Machine_Code");
            else
                dboSetCtrls.SetDropDownList(ddlDeviceNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "MouldCode", "MouldCode");
        }
        else
        {
            ddlDeviceNo.Visible = false; txtDeviceNo.Visible = true;
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
}
