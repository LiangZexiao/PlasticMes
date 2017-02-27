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

public partial class Call_Call_press : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    private CallConfig_DAL calldal = new CallConfig_DAL();
    SetCtrls dboSetCtrls = new SetCtrls();
    public string bindnums;
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "CallConfig");
            ViewState["authority"] = o;
            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnNewadd.Visible = btnInsert.Visible = false;
            if (o[2]) btnUpdate.Visible = false;
            if (o[3]) btnCancel.Visible =btnDelete.Visible= false;

        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
            dataBind();
            // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            btnCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            //dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");

            this.Select1.DataSource = new CallConfig_DAL().selectEmployee(0, "", ""); //Employee_BLL.selectEmployee(0, "", "") as IList;
            this.Select1.DataTextField = "EmployeeName_CN";
            this.Select1.DataValueField = "EmployeeID";
            this.Select1.DataBind();

        }
        
    }
    
    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.Trim().ToString();
        string coltext = txtQuery.Text.Trim().ToString();
        int types = this.ddltypes.SelectedValue.Trim().ToString() == "" ? 0 : int.Parse(this.ddltypes.SelectedValue.Trim().ToString());
        IList<CallConfig_MDL> tempList = calldal.selectWorkPaper(types, 2, 0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);

        ddlMachineNo.Items.Clear();
        ddlMachineNo.Items.Add(new ListItem("选择", ""));
        IList<MachineMstr_MDL> mytempList = MachineMstr_BLL.selectMachineMstr(0, "", "");//注塑机器
        for (int i = 0; i < mytempList.Count; i++)
        {
            ddlMachineNo.Items.Add(new ListItem(mytempList[i].Machine_Code, mytempList[i].Machine_Code));
        }

        ddlMold.Items.Clear();
        IList<MouldDetail_MDL> lstMold = MouldDetail_BLL.selectMouldDetail();
        ddlMold.Items.Add(new ListItem("选择", ""));
        ddlMold.Items.Add(new ListItem("全部", "全部"));
        for (int i = 0; i < lstMold.Count; i++)
        {
            ddlMold.Items.Add(new ListItem(lstMold[i].MouldCode, lstMold[i].MouldCode));
        }

        ddlWorkShop.Items.Clear();
        ddlWorkShop.Items.Add(new ListItem("选择", ""));
        DataTable dtWorkShop = MachineMstr_BLL.selectWorkShop();
        foreach (DataRow dr in dtWorkShop.Rows)
        {
            ddlWorkShop.Items.Add(new ListItem(dr["WorkShop"].ToString().Trim(), dr["MachineNo"].ToString().Trim()));
        }

    }
  
    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "btnNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "DROPDOWNLIST", ddlExecute);
            this.ddlMachineNo.SelectedIndex = 0;
            this.txtCycle.Text = ""; 
            ddlExecute.Enabled = true;
            ddlMachineNo.Enabled = true;
            ddlBc.SelectedIndex = 0;
            ddlBc.Enabled = true;
            ddlWorkShop.Enabled = true;
            ddlWorkShop.SelectedIndex = 0;
            ddlMold.Enabled = true;
            ddlMold.SelectedIndex = 0;
            hdnemp.Value = "";
            bindselect2();
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
                // ItemMstr_BLL.cancelItemMstr(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                // t = new WorkPaper_DAL().cancelItemMstr(pIDList);
                // ItemMstr_BLL.cancelItemMstr(pIDList);                
            }
            t = calldal.DeleteCall(pIDList);
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
        dr = dtMachine.NewRow();
        dr["MachineCode"] = " ";
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
    /// update by fsq 2009.12.14
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        string CallStr = this.ddlExecute.SelectedItem.Text.ToString() + "提醒消息";//"异常消息";
        string CallTypeID = "2";
        string UnitType = "分钟";// this.ddlUnit.SelectedItem.Text.ToString();
        string UnitTypeID = "4";//this.ddlUnit.SelectedValue.ToString();
        string CallValue = "-1";// this.ddlMachineNo.SelectedValue.ToString();//this.txtNum.Text.Trim().ToString();
        string UnitValue = this.txtCycle.Text.Trim().ToString();
        string CreateTime = DateTime.Now.ToString("yyyy-MM-dd");
        string MachineNo = this.ddlMachineNo.SelectedValue.ToString().Trim();
        string MoldNo = this.ddlMold.SelectedValue.ToString().Trim();
        string subMachine = this.ddlWorkShop.SelectedValue.ToString().Trim();
        string BcCode = this.ddlBc.SelectedValue.ToString().Trim();
        string types = this.ddlExecute.SelectedValue.Trim().ToString();//报警类型ID
        string vSendNum = this.txtnum.Text.Trim().ToString();
        string cellEmployee =  hdnemp.Value == "" ? "" : hdnemp.Value;//短消息接收人员
        if (!string.IsNullOrEmpty(MoldNo)) MachineNo = MoldNo;
        // Response.Write(cellEmployee);
        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";
        try
        {
            CallConfig_MDL call = new CallConfig_MDL(txtID.Text.Trim().ToString(), types
                , CallStr, CallTypeID, UnitType, UnitTypeID, CallValue, UnitValue, CreateTime
                , MachineNo, MachineNo, vSendNum, "0.00", "0.00", cellEmployee,BcCode);
            if (UI == "INSERT")
            {
                if (ddlMachineNo.SelectedItem.Text == "全部")//应用到所有时先删除已有的机器
                {
                    calldal.DeleteCall(types,subMachine,BcCode);
                }
                else
                {
                    if (calldal.selectWorkPaper(types, "2", "MachineNo", MachineNo).Count > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, "该机器的配置已存在!");
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(MoldNo))
                {
                    if (ddlMold.SelectedItem.Text == "全部")//应用到所有时先删除已有的模具
                    {
                        calldal.DeleteCall(types, "MoldNo", BcCode);
                    }
                    else
                    {
                        if (calldal.selectWorkPaper(types, "2", "MachineNo", MoldNo).Count > 0)
                        {
                            dboSetCtrls.SetExecMsg(this, "该模具的配置已存在!");
                            return;
                        }
                    }
                }

            }

            if ((ddlMold.SelectedItem.Text == "全部" || ddlMachineNo.SelectedItem.Text == "全部" ) && UI == "INSERT")//应用到所有时 
            {
                if (ddlMachineNo.SelectedItem.Text == "全部") //机器
                {
                    DataTable dtTmp = MachineMstr_BLL.selectMachinePlant(subMachine);

                    foreach (DataRow dr in dtTmp.Rows)
                    {
                        calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(), types,
                            CallStr, CallTypeID, UnitType, UnitTypeID, CallValue, UnitValue, CreateTime,
                            dr["MachineCode"].ToString().Trim(), "", vSendNum, "0.00",
                            "0.00", cellEmployee, BcCode), UI);
                    }
                }
                else
                {
                    //模具
                    IList<MouldDetail_MDL> temp= MouldDetail_BLL.selectMouldDetail();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(), types,
                            CallStr, CallTypeID, UnitType, UnitTypeID, CallValue, UnitValue, CreateTime,
                            temp[i].MouldCode, "", vSendNum, "0.00",
                            "0.00", cellEmployee, BcCode), UI);
                    }
                }

                //IList<MachineMstr_MDL> temp = MachineMstr_BLL.selectMachineMstr(0, "", "");
                //if (ddlExecute.SelectedValue == "5")
                //{
                //    for (int i = 0; i < temp.Count; i++)
                //    {
                //        calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(), types,
                //            CallStr, CallTypeID, UnitType, UnitTypeID, CallValue, UnitValue, CreateTime,
                //            temp[i].Machine_Code, "", vSendNum, "0.00",
                //            "0.00", cellEmployee,BcCode), UI);
                //    }
                //}
                //else
                //{
                //   // IList<DispatchOrder_MDL> mylist = DispatchOrder_BLL.selectDispatchOrder("0", "0");
                //    for (int i = 0; i < temp.Count; i++)
                //    {
                //        calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(),
                //            types, CallStr, CallTypeID, UnitType, UnitTypeID, CallValue,
                //            UnitValue, CreateTime, temp[i].Machine_Code, "",
                //            vSendNum, "0.00", "0.00", cellEmployee,BcCode), UI);
                //    }
                //}
                dboSetCtrls.SetExecMsg(this, "INSERT", true);
            }
            else
            {
                if (calldal.InsertCall_1(call, UI) == 1)
                {
                    dboSetCtrls.SetExecMsg(this, UI, true);
                    
                    //BindData();
                }
                else
                {
                    dboSetCtrls.SetExecMsg(this, UI, false);
                }
            }
            bindselect2();
            hdnemp.Value = "";
        }
        catch //(Exception ex)
        {
            // string temp = ex.ToString().Trim();
            // Response.Write(ex.Message);
            dboSetCtrls.SetExecMsg(this, UI, false);
            hdnemp.Value = "";
        }

    }
    void bindSendemployee(string senemp)
    {
        if (senemp != "")
        {
            string[] ddsa = senemp.Split(',');
            string sql = "select * from employee where invalid=1  ";
            string strEmployID = string.Empty;
            for (int i = 0; i < ddsa.Length; i++)
            {
                strEmployID += "'" + ddsa[i].ToString() + "',";
                //if (i != ddsa.Length - 1)
                //    sql += " EmployeeID='" + ddsa[i].ToString() + "' or ";
                //else
                //    sql += " EmployeeID='" + ddsa[i].ToString() + "'";
            }
            if (strEmployID != string.Empty) sql += "  and EmployeeID in(" + strEmployID.Substring(0, strEmployID.Length - 1) + ")";
            SQLExecutant sc = new SQLExecutant();
            this.Select2.DataSource = sc.ExecQueryCmd(sql);
            this.Select2.DataTextField = "EmployeeName_CN";
            this.Select2.DataValueField = "EmployeeID";
            this.Select2.DataBind();
        }

    }
    void bindselect2()
    {
        if (hdnemp.Value != "")
        {
            string[] ddsa = hdnemp.Value.Split(',');
            string strEmployID = string.Empty;
            string sql = "select *  from employee where invalid=1  ";
            for (int i = 0; i < ddsa.Length; i++)
            {
                strEmployID += "'" + ddsa[i].ToString() + "',";
                //if (i != ddsa.Length - 1)
                //    sql += " EmployeeID='" + ddsa[i].ToString() + "' or ";
                //else
                //    sql += " EmployeeID='" + ddsa[i].ToString() + "'";
            }
            if (strEmployID != string.Empty) sql += "  and EmployeeID in(" + strEmployID.Substring(0, strEmployID.Length - 1) + ")";
            SQLExecutant sc = new SQLExecutant();
            this.Select2.DataSource = sc.ExecQueryCmd(sql);
            this.Select2.DataTextField = "EmployeeName_CN";
            this.Select2.DataValueField = "EmployeeID";
            this.Select2.DataBind();
        }
        else
        {
            Select2.Items.Clear();
        }
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
      
        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnUpdate, btnInsert, btnDelete, "DROPDOWNLIST", ddlExecute);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();
        //Response.Write(vID);
        IList<CallConfig_MDL> tempList = calldal.selectWorkPaper(0, 2, int.Parse(vID), "", "");
       // setDrop(tempList[0].CallID);

        ddlExecute = dboSetCtrls.SetSelectedIndex(ddlExecute, tempList[0].CallID);
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempList[0].MachineNo);
        ddlWorkShop = dboSetCtrls.SetSelectedIndex(ddlWorkShop,tempList[0].MachineNo.Substring(0,2).ToUpper()=="IM" ||
                                          tempList[0].MachineNo.Substring(0,2).ToUpper()=="PM"?
                                          MachineMstr_BLL.selectParentWorkShop(tempList[0].MachineNo):"");
        ddlBc = dboSetCtrls.SetSelectedIndex(ddlBc, tempList[0].BcCode);
        this.txtCycle.Text = tempList[0].UnitValue;
        this.txtnum.Text = tempList[0].SendNum;
        ddlExecute.Enabled = false;
        ddlMachineNo.Enabled = false;
        ddlMold = dboSetCtrls.SetSelectedIndex(ddlMold, tempList[0].MachineNo);
        ddlMold.Enabled = false;
        ddlWorkShop.Enabled = false;
        //ddlBc.Enabled = false;
        hdnemp.Value = "";
        bindselect2();

        bindSendemployee(tempList[0].SendEmployee);

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void ddlMold_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlMachineNo.SelectedValue.ToString().Trim() != "")
        {
            dboSetCtrls.SetExecMsg(this, "模具编号和机器编号二者只能选择一个,您已经选择了机器编号!");
            ddlMold.SelectedIndex = 0;
            return;
        }

    }
    protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlMold.SelectedValue.ToString().Trim() != "")
        {
            dboSetCtrls.SetExecMsg(this, "模具编号和机器编号二者只能选择一个，您已经选择了模具编号!");
            ddlMachineNo.SelectedIndex = 0;
            return;
        }
    }
}
