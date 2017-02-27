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
using Admin.BLL.Machine_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.Model.Machine_MDL;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.DBUtility;

public partial class Maintain_MaintainPlan : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["ClickMould"] = @"Maintain/MaintainPlan.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MaintainPlan");
            ViewState["authority"] = o;
            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = igbNewadd .Visible= false;
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

            DataTable dtTmpRepair = Employee_BLL.selectEmployee("rankdesc", "机修");
            DataTable dtTmp = Employee_BLL.selectEmployee("", "");
            dboSetCtrls.SetDropDownList(ddlApplier, dtTmp, false, "EmployeeID", "EmployeeName_CN");
            dboSetCtrls.SetDropDownList(ddlDutyMan, dtTmpRepair, false, "EmployeeID", "EmployeeName_CN");
            dboSetCtrls.SetDropDownList(ddlChecker, dtTmp, false, "EmployeeID", "EmployeeName_CN");
            
            SetDeviceNo();
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<MaintainInfo_MDL> tempList = MaintainInfo_BLL.selectMaintainInfo(0, colname, coltext, "MaintainPlan");
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vRepairBillID = txtRepairBillID.Text.Trim();
        string vRepareDate =txtRepareDate.Value.Trim();
        string vDeviceType = ddlDeviceType.SelectedValue.Trim();
        string vDeviceNo = (ddlDeviceNo.Visible) ? ddlDeviceNo.SelectedValue.Trim() : txtDeviceNo.Text.Trim();
        string vRepairContent = txtRepairContent.Text.Trim();

        string vBeginDate = txtBeginDate.Value.Trim();
        string vEndDate = txtEndDate.Value.Trim();
        string vCompleteFlag = rblCompleteFlag.SelectedValue.Trim();
        string vApplier = ddlApplier.SelectedValue.Trim();
        string vDutyMan = ddlDutyMan.SelectedValue.Trim();
        decimal vRepairHour = txtRepairHour.Text.Trim()==""? 0:decimal.Parse(txtRepairHour.Text.Trim());
        int vMaxMouldNum = txtMaxMouldNum.Text.Trim() == "" ? 0 : int.Parse(txtMaxMouldNum.Text.Trim());
        string vChecker = ddlChecker.SelectedValue.Trim();
        string vRemark = txtRemark.Text.Trim();
        string vMessageFlag = rblMessageFlag.SelectedValue.Trim();
        string IU = IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        if (IU == "INSERT")
        {
            if (ddlDeviceNo.SelectedItem.Text == "全部")//应用到所有时先删除已有的
            {
                MaintainInfo_BLL.DeleteMainInfo(vDeviceType);
            }
        }
        try
        {
            if (tempButton.ID == "igbInsert" && ddlDeviceNo.SelectedItem.Text!= "全部")
            {
                if (MaintainInfo_BLL.existsMaintainInfo(txtRepareDate.Value.Trim(),vDeviceNo).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "该设备的维护计划已经存在!!");
                    return;
                }
            }
            if (IU == "INSERT" && ddlDeviceNo.SelectedItem.Text == "全部")
            {
                for (int i = 0; i < ddlDeviceNo.Items.Count; i++)
                {
                    if (ddlDeviceNo.Items[i].Value != "全部" && ddlDeviceNo.Items[i].Value != "" && ddlDeviceNo.Items[i].Value != "选择")
                    {
                        vDeviceNo = ddlDeviceNo.Items[i].Value;
                        MaintainInfo_BLL.ChangeMaintainInfo(vID, vRepairBillID, vRepareDate, vDeviceType, vDeviceNo, "0",
                            vRepairContent, vBeginDate, vEndDate, vCompleteFlag, vApplier,
                            vDutyMan, vChecker, vRemark, vMessageFlag, vRepairHour, vMaxMouldNum, IU);
                    }
                }
            }
            else
            {
                MaintainInfo_BLL.ChangeMaintainInfo(vID, vRepairBillID, vRepareDate, vDeviceType, vDeviceNo, "0",
                    vRepairContent, vBeginDate, vEndDate, vCompleteFlag, vApplier,
                    vDutyMan, vChecker, vRemark, vMessageFlag, vRepairHour, vMaxMouldNum, IU);
            }
            dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            dboSetCtrls.SetExecMsg(this, IU, false);
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

    protected void btnVisible_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtRepairBillID);
            object[] textboxid = { txtID, txtRepairBillID, txtDeviceNo, txtRepairContent, txtRemark,txtRepairHour };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            txtBeginDate.Value = "00:00";
            txtEndDate.Value = "00:00";
            txtRepareDate.Value = null;
            ddlDeviceType.SelectedIndex = rblCompleteFlag.SelectedIndex = rblMessageFlag.SelectedIndex = 1;
            ddlApplier.SelectedIndex = ddlDutyMan.SelectedIndex = ddlChecker.SelectedIndex = 0;
            string strToday="A"+System.DateTime.Now.ToString("yyyyMMdd");
            string strSQL = @"select top 1 repairBillID   from  RepairDevice
                        where repairBillID like '{0}%'
                        order by ID DESC  ";
            string endNum;
            strSQL = string.Format(strSQL, strToday);
            DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                endNum = dtTmp.Rows[0]["repairBillID"].ToString().Substring(dtTmp.Rows[0]["repairBillID"].ToString().Length - 3, 3);
                endNum = (Convert.ToInt32(endNum) + 1).ToString().PadLeft(3, '0').Trim();
                txtRepairBillID.Text = dtTmp.Rows[0]["repairBillID"].ToString().Substring(0, 9).Trim() + endNum;
            }
            else   txtRepairBillID.Text = strToday + "001";

        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
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
        IList<MaintainInfo_MDL> tempIList = MaintainInfo_BLL.selectMaintainInfo(Int32.Parse(vID), "", "", "MaintainPlan");

        txtRepairBillID.Text = tempIList[0].RepairBillID;
        txtRepareDate.Value = tempIList[0].RepareDate;
        ddlDeviceType = dboSetCtrls.SetSelectedIndex(ddlDeviceType, tempIList[0].DeviceTypeID);

        SetDeviceNo();

        if (ddlDeviceNo.Visible)
            ddlDeviceNo = dboSetCtrls.SetSelectedIndex(ddlDeviceNo, tempIList[0].DeviceNo);
        else
            txtDeviceNo.Text = tempIList[0].DeviceNo;

        txtRepairContent.Text = tempIList[0].RepairContent;
        txtBeginDate.Value = tempIList[0].BeginDate;
        txtEndDate.Value = tempIList[0].EndDate;
        rblCompleteFlag.SelectedValue = tempIList[0].CompleteFlag.ToUpper();
        ddlApplier = dboSetCtrls.SetSelectedIndex(ddlApplier, tempIList[0].Applier);
        ddlDutyMan = dboSetCtrls.SetSelectedIndex(ddlDutyMan, tempIList[0].DutyMan);
        ddlChecker = dboSetCtrls.SetSelectedIndex(ddlChecker, tempIList[0].Checker);
        rblMessageFlag.SelectedValue = tempIList[0].MessageFlag.ToUpper();
        txtRemark.Text = tempIList[0].Remark;
        txtRepairHour.Text = tempIList[0].RepairHour.ToString().Trim();
        txtMaxMouldNum.Text = tempIList[0].MaxMouldNum.ToString().Trim();
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
            ddlDeviceNo.Visible = true;
            txtDeviceNo.Visible = false;
            ddlDeviceNo.Items.Clear();
            if (DeviceType == "1")
            {
                DataTable dtTmp = MachineMstr_BLL.selectAllMachinePlant();
                foreach (DataRow dr in dtTmp.Rows)
                {
                    ddlDeviceNo.Items.Add(new ListItem(dr["MachineCode"].ToString().Trim(), dr["MachineCode"].ToString().Trim()));
                }
                //IList<MachineMstr_MDL> mytempList = MachineMstr_BLL.selectAllMachinePlant();//注塑机器
                //IList<MachineSuit_MDL> tempList2 = new MachineSuit_DAL().selectMachineSuit(0, "", "");//植毛机器
                //for (int i = 0; i < mytempList.Count; i++)
                //{
                //    ddlDeviceNo.Items.Add(new ListItem(mytempList[i].Machine_Code, mytempList[i].Machine_Code));
                //}
                //for (int i = 0; i < tempList2.Count; i++)
                //{
                //    ddlDeviceNo.Items.Add(new ListItem(tempList2[i].MachineCode, tempList2[i].MachineCode));
                //}
            }
            else
                dboSetCtrls.SetDropDownList(ddlDeviceNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "MouldCode", "MouldCode");
            ddlDeviceNo.Items.Insert(0, new ListItem("全部", "全部"));
        }
        else
        {
            ddlDeviceNo.Visible = false;
            txtDeviceNo.Visible = true;
            txtDeviceNo.Text = null;
        }
    }


}
