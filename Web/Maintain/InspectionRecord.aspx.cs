using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.DBUtility;

public partial class Maintain_InspectionRecord : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    string sqlStr = "";

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "InspectionRecord");
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

        if (!IsPostBack)  //第一次打开页面
        {
            //sqlStr = "select B.ItemName ,B.ItemLevel ,A.CheckResult,A.CheckMan,A.CheckDate ,A.Remark from MachineInspection a left join InspectionItem  b on a.ItemID=b.ItemID order by CheckDate,b.ItemID ";
            
            BindData();

            MultiView1.ActiveViewIndex = 0;
            
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");

            //dboSetCtrls.SetDropDownList(ddlApplier, dtTmp, false, "EmployeeID", "EmployeeName_CN");
            //dboSetCtrls.SetDropDownList(ddlDutyMan, dtTmpRepair, false, "EmployeeID", "EmployeeName_CN");
            //dboSetCtrls.SetDropDownList(ddlChecker, dtTmp, false, "EmployeeID", "EmployeeName_CN");

            SetDeviceNo();
        }
    }

    public void BindData()
    {

        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();

        sqlStr = "select a.ID,a.MachineNo, B.ItemName ,case when B.ItemLevel=0 then '中等' when b.ItemLevel=1 then '重要'  end as ItemLevel ," +
            "case when A.CheckResult=0 then '不合格' when A.CheckResult=1  then '合格' end as CheckResult,A.CheckMan,A.CheckDate ,A.Remark " +
            "from MachineInspection a left join InspectionItem  b on a.ItemID=b.ItemID where 1=1 {0} order by CheckDate,a.MachineNo,b.ItemID";

        #region    查询条件

        string strWhere = "";

        if (coltext == "")
        {}else
        {
            switch (colname)
            {
                case "CurrentOperator":
                    strWhere += "and  A.CheckMan like '%" + coltext + "%'";
                    break;
                case "DeviceNo":
                    strWhere += "and  A.MachineNo like '%" + coltext + "%'";
                    break;
            }
        }

        if (ddlImport.Text.Trim()=="all")
        {}else
        {
            strWhere +=" and b.ItemLevel=" + ddlImport.Text.Trim();
        }

        if (chkIsOK.Checked)
        {
            strWhere += " and  a.CheckResult=0";

        }

        if (txtInBeginDate.Value.Trim() == "" && txtInEndDate.Value.Trim() == "")
        {}else

        {
            if (txtInBeginDate.Value == "")
            {
                strWhere += " and A.CheckDate< '" +txtInEndDate.Value +"'";
            }
            else
            {
                if (txtInEndDate.Value == "")
                {
                    strWhere += " and A.CheckDate> '" + txtInBeginDate.Value + "'";
                }
                else
                {
                    strWhere += "and  A.CheckDate>'" + txtInBeginDate.Value + "' and  A.CheckDate<'" + txtInEndDate.Value + "'";
                }
            }
        }
        #endregion

        sqlStr =string.Format (sqlStr, strWhere );

        using (DataTable  sdr =SqlHelper.ReturnTable ( sqlStr))
        {
            GridView1.DataSource = sdr;
            GridView1.DataBind();
            dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1,sdr.Rows.Count );
            dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        ImageButton tempButton = sender as ImageButton;

        //int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        //string vRepairBillID = txtRepairBillID.Text.Trim();
        //string vRepareDate = (txtRepareDate.Value.Trim() == "") ? DateTime.Now.ToString("yyyy-MM-dd") : txtRepareDate.Value.Trim();
        //string vDeviceType = ddlDeviceType.SelectedValue.Trim();
        //string vDeviceNo = (ddlDeviceNo.Visible) ? ddlDeviceNo.SelectedValue.Trim() : txtDeviceNo.Text.Trim();
        //string vRepairType = ddlRepairType.SelectedValue.Trim();
        //string vRepairContent = txtRepairContent.Text.Trim();
        //string vBeginDate = txtBeginDate.Value.Trim();
        //string vEndDate = txtEndDate.Value.Trim();
        //string vCompleteFlag = rblCompleteFlag.SelectedValue.Trim();
        //string vApplier = ddlApplier.SelectedValue.Trim();
        //string vDutyMan = ddlDutyMan.SelectedValue.Trim();
        //string vChecker = ddlChecker.SelectedValue.Trim();
        //string vRemark = txtRemark.Text.Trim();
        

        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        string strSql = "";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (txtMachineNo.Text.Trim() == "")
                { dboSetCtrls.SetExecMsg(this, "设备编号不能为空!"); }
                else
                {
                    strSql = "select Machine_Code  from MachineMstr where Machine_Code='" + txtMachineNo.Text.Trim() + "' order by Machine_Code";
                    using (DataTable sdt = SqlHelper.ReturnTable(strSql))
                    {
                        if (sdt.Rows.Count == 0)
                        {
                            dboSetCtrls.SetExecMsg(this, "该设备编号未找到相应的资料，请核对!");
                            sdt.Dispose();
                            return;
                        }
                    }
                }
                strSql = "select * from MachineInspection where MachineNo='{0}' and CONVERT (char(10), CheckDate,120)=CONVERT (char(10), GETDATE (),120)";
                strSql = string.Format(strSql, txtMachineNo.Text.Trim());
                using (DataTable sdt = SqlHelper.ReturnTable(sqlStr))
                {
                    if (sdt.Rows.Count > 1)
                    {
                        dboSetCtrls.SetExecMsg(this, "在当天内已有相同的设备点检记录!");
                        sdt.Dispose();
                        return;
                    }
                }

                int ii = 0;
                foreach (GridViewRow ge in GridView2.Rows)
                {
                    strSql = "insert MachineInspection(ItemID,MachineNo,CheckDate,CheckMan,CheckResult,Remark) values('{0}','" + txtMachineNo.Text.Trim() + "', GETDATE(),'" + txtOperator.Text.Trim() +
                    "',{1},'{2}' )";

                    CheckBox chkItem = ge.FindControl("chkItemHG") as CheckBox;
                    TextBox txtRemark = ge.FindControl("txtRemark") as TextBox;
                    string strgeID = ge.Cells[0].Text.ToString().Trim();

                    if (chkItem.Checked)
                    {
                        strSql = string.Format(strSql, strgeID, 0, txtRemark.Text.Trim());
                        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null);
                        ii = ii + 1;
                    }
                    else
                    {
                        if (txtRemark.Text.Trim() == "")
                        { }
                        else
                        {
                            strSql = string.Format(strSql, strgeID, 0, txtRemark.Text.Trim());
                            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null);
                            ii = ii + 1;
                        }
                    }
                }

                if (ii == 0)
                { dboSetCtrls.SetExecMsg(this, "请选择点检项目!"); }
                else
                    dboSetCtrls.SetExecMsg(this, IU, true);
            }
            else
            { 
                //修改记录
                //strSql = "update MachineInspection set MachineNo='',CheckDate ='',CheckMan ='',CheckResult =1,Remark ='' where ID =''";
                //SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null);
                dboSetCtrls.SetExecMsg(this, IU, true);
            }
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
            //dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtRepairBillID);
            //object[] textboxid = { txtID, txtRepairBillID, txtDeviceNo, txtRepairContent, txtRemark };

            //dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            //txtBeginDate.Value = "07:20";
            //txtEndDate.Value = "07:20";
            //txtRepareDate.Value = null;
            //ddlDeviceType.SelectedIndex = ddlRepairType.SelectedIndex = rblCompleteFlag.SelectedIndex = 1;
            //ddlApplier.SelectedIndex = ddlDutyMan.SelectedIndex = ddlChecker.SelectedIndex = 0;

            txtOperator.Text = this.Page.User.Identity.Name.Trim();
            txtOperator.ReadOnly = true;
            wpInspectionDate.Visible = false;
            txtInspectionDate.Text = DateTime.Now.ToString();
            txtInspectionDate.ReadOnly = true;
            txtInspectionDate.Visible = true;
            txtMachineNo.ReadOnly = false;
            
            igbUpdate.Visible = false;
            igbDelete.Visible = false;
            
            string strSQL = "";
            //查询用户权限
            if (this.Page.User.Identity.Name.Trim() =="9999")
                strSQL = "select itemid,ItemName,case when ItemLevel=0 then '中等' when ItemLevel=1 then '重要'  end as ItemLevel ,ItemType  from InspectionItem";
            else
                strSQL = "select itemid,ItemName,case when ItemLevel=0 then '中等' when ItemLevel=1 then '重要'  end as ItemLevel ,ItemType  from InspectionItem where ItemType='日检'";

            BindGridView2(strSQL);

            GridView2.Visible = true;

        }
        else
        {
            if (tempButton.ID != "igbQuery")
            {
                MultiView1.ActiveViewIndex = 0;
                BindData();
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        string strSql = "";
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                pIDList.Add(txtID.Text.Trim());
                //MaintainInfo_BLL.cancelMaintainInfo(pIDList);
            }
            else
            {

                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);

                for (int i = 0; i < pIDList.Count; i++)
                {
                    strSql = "delete from MachineInspection where ID= {0}";
                    strSql=string.Format(strSql,int.Parse(pIDList[i].ToString()));
                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null);
                }
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
        //dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtRepairBillID);

        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        sqlStr = "select a.ID,a.MachineNo, B.ItemName , B.ItemLevel,A.CheckResult,A.CheckMan,A.CheckDate,B.ItemType,A.Remark "+
                 "from MachineInspection a left join InspectionItem  b on a.ItemID=b.ItemID where a.ID = {0}" +
                 "order by CheckDate,a.machineno,a.ItemID " ;

        sqlStr=string.Format(sqlStr, vID);

        using (DataTable sdt = SqlHelper.ReturnTable(sqlStr))
        {
            txtMachineNo.Text =sdt.Rows[0]["MachineNo"].ToString ();
            txtMachineNo.ReadOnly = true;
            txtOperator.Text =sdt.Rows[0]["CheckMan"].ToString ();
            txtOperator.ReadOnly = false;
            wpInspectionDate.Value = sdt.Rows[0]["CheckDate"].ToString ();
            wpInspectionDate.Visible = true;
            txtInspectionDate.Visible = false;
            GridView2.Visible = false;
            
            //rdHG.SelectedValue = sdt.Rows[0]["CheckResult"].ToString ();  
            //rdHG.SelectedIndex =int.Parse (sdt.Rows[0]["CheckResult"].ToString()); 
        }

       // IList<MaintainInfo_MDL> tempIList = MaintainInfo_BLL.selectMaintainInfo(Int32.Parse(vID), "", "", "InspectionRecord");

        //SetDeviceNo();


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
        //string DeviceType = ddlDeviceType.SelectedValue.Trim();
        //if (DeviceType != "3")
        //{
        //    ddlDeviceNo.Visible = true; txtDeviceNo.Visible = false;
        //    ddlDeviceNo.Items.Clear();

        //    if (DeviceType == "1")
        //        dboSetCtrls.SetDropDownList(ddlDeviceNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, false, "Machine_Code", "Machine_Code");
        //    else
        //        dboSetCtrls.SetDropDownList(ddlDeviceNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "MouldCode", "MouldCode");
        //}
        //else
        //{
        //    ddlDeviceNo.Visible = false; txtDeviceNo.Visible = true;
        //}
    }

    public void BindGridView2(string strSql)
    {
        using (DataTable sdr = SqlHelper.ReturnTable(strSql))
        {
            GridView2.DataSource = sdr;
            GridView2.DataBind();
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
