﻿using System;
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
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.SQLServerDAL;

public partial class Call_Call_Cycle : System.Web.UI.Page
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
            this.Select1.DataSource = new CallConfig_DAL().selectEmployee(0, "", "") ;
            this.Select1.DataTextField = "EmployeeName_CN";
            this.Select1.DataValueField = "EmployeeID";
            this.Select1.DataBind();
            bindcheck();
            Session["sendEmp"] = "//////////";
            this.CheckBoxList1.Enabled = false;

            // this.Button1.Enabled = false;
            this.Button1.Visible = false;
            RadioButtonList1.Enabled = false;
        }
    }
    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.Trim().ToString();
        string coltext = txtQuery.Text.Trim().ToString();
        int types = ddlType.SelectedValue.Trim().ToString() == "" ? 0 : int.Parse(ddlType.SelectedValue.Trim().ToString());
        IList<CallConfig_MDL> tempList = calldal.selectWorkPaper(types, 1, 0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        
        
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);

        ddlMachineNo.Items.Clear();
        ddlMachineNo.Items.Add(new ListItem("", "选择"));
        IList<MachineMstr_MDL> mytempList = MachineMstr_BLL.selectMachineMstr(0, "", "");//注塑机器
        IList<MachineSuit_MDL> tempList2 = new MachineSuit_DAL().selectMachineSuit(0, "", "");//植毛机器
        for (int i = 0; i < mytempList.Count; i++)
        {
            ddlMachineNo.Items.Add(new ListItem(mytempList[i].Machine_Code, mytempList[i].Machine_Code));
        }
        for (int i = 0; i < tempList2.Count; i++)
        {
            ddlMachineNo.Items.Add(new ListItem(tempList2[i].MachineCode, tempList2[i].MachineCode));
        }
        ddlWorkShop.Items.Clear();
        ddlWorkShop.Items.Add(new ListItem("选择", ""));
        DataTable dtWorkShop = MachineMstr_BLL.selectWorkShop();
        foreach (DataRow dr in dtWorkShop.Rows)
        {
            ddlWorkShop.Items.Add(new ListItem(dr["WorkShop"].ToString().Trim(), dr["MachineNo"].ToString().Trim()));
        }
    }
    void bindcheck()
    {
        CheckBoxList1.Items.Clear();
        CheckBoxList1.Items.Add(new ListItem("换模", "1"));
        CheckBoxList1.Items.Add(new ListItem("换料", "2"));
        CheckBoxList1.Items.Add(new ListItem("换单", "3"));
        CheckBoxList1.Items.Add(new ListItem("辅设故障", "4"));
        CheckBoxList1.Items.Add(new ListItem("机器故障", "5"));
        CheckBoxList1.Items.Add(new ListItem("模具故障", "6"));
        CheckBoxList1.Items.Add(new ListItem("待料", "7"));
        CheckBoxList1.Items.Add(new ListItem("无定单", "8"));
        CheckBoxList1.Items.Add(new ListItem("其他", "9"));
        CheckBoxList1.Items.Add(new ListItem("待人", "11"));
        CheckBoxList1.Items.Add(new ListItem("自定义", "12"));//这里您可以绑定数据库里的数据
        RadioButtonList1.Items.Clear();
        RadioButtonList1.Items.Add(new ListItem("换模", "1"));
        RadioButtonList1.Items.Add(new ListItem("换料", "2"));
        RadioButtonList1.Items.Add(new ListItem("换单", "3"));
        RadioButtonList1.Items.Add(new ListItem("辅设故障", "4"));
        RadioButtonList1.Items.Add(new ListItem("机器故障", "5"));
        RadioButtonList1.Items.Add(new ListItem("模具故障", "6"));
        RadioButtonList1.Items.Add(new ListItem("待料", "7"));
        RadioButtonList1.Items.Add(new ListItem("无定单", "8"));
        RadioButtonList1.Items.Add(new ListItem("其他", "9"));
        RadioButtonList1.Items.Add(new ListItem("待人", "11"));
        RadioButtonList1.Items.Add(new ListItem("自定义", "12"));//这里您可以绑定数据库里的数据
    }

    /// <summary>
    /// update by fsq 2010-06-21
    /// 优化算法。
    /// </summary>
    void bindselect2()
    {
        if (hdnemp.Value != "")
        {

            string[] ddsa = hdnemp.Value.Split(',');
            string sql = "select * from employee where invalid=1 ";
            string strEmployID = string.Empty;
            for (int i = 0; i < ddsa.Length; i++)
            {
                strEmployID += "'" + ddsa[i].ToString() + "',";
                //if (i != ddsa.Length - 1)
                //    sql += "and EmployeeID='" + ddsa[i].ToString() + "' or ";
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
    void bindSendemployee(string senemp)
    {
        if (senemp != "")
        {
            string[] ddsa = senemp.Split(',');
            string sql = "SELECT distinct EmployeeName_CN,EmployeeID FROM Employee WHERE invalid=1   ";
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
    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "btnNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "DROPDOWNLIST", ddlExecute);
          //  this.ddlMachineNo.SelectedIndex = 0;
           // this.ddlUnit.SelectedValue = "0";
            this.txtCycle.Text = "";
            this.txtNum.Text = "";
            ddlExecute.Enabled = true;
            ddlExecute.SelectedIndex = 0;
            ddlMachineNo.Enabled = true;
            ddlBc.Enabled = true;
            ddlBc.SelectedIndex = 0;
            ddlWorkShop.Enabled = true;
            ddlWorkShop.SelectedIndex = 0;
            Session["sendEmp"] = "//////////";
            CheckBoxList1.Visible = true;
            CheckBoxList1.Enabled = false;
            RadioButtonList1.Visible = false;
            this.CheckBoxList1.AutoPostBack = false;

            //this.txtmax.Enabled = false;
            //this.txtmin.Enabled = false;
            //txtNum.Enabled = false;
            //lblFileName.Enabled = false;
            //Label4.Enabled = false;
            //Label5.Enabled = false;
            Label1.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Button1.Visible = true;
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
        string CallStr = this.ddlExecute.SelectedItem.Text.Trim().ToString();
        string CallTypeID = "1";
        string UnitType = "分钟";// this.ddlUnit.SelectedItem.Text.ToString();
        string UnitTypeID = "4";// this.ddlUnit.SelectedValue.ToString();
        string CallValue = this.txtNum.Text.Trim().ToString();
        string UnitValue = this.txtCycle.Text.Trim().ToString();
        string CreateTime = DateTime.Now.ToString("yyyy-MM-dd");
        string MachineNo = this.ddlMachineNo.SelectedValue.ToString().Trim();
        string subMachine = this.ddlWorkShop.SelectedValue.ToString().Trim();
        string types = ddlExecute.SelectedValue.Trim().ToString();//报警类型ＩＤ
        string BcCode = ddlBc.SelectedValue.Trim().ToString();//班次类型
        string sendnum = this.txtsend.Text.Trim().ToString();

        string upNum = (double.Parse(this.txtmax.Text.Trim().ToString() == "" ? "0" : this.txtmax.Text.Trim().ToString()) / 100).ToString();
        string downNum = (double.Parse(this.txtmin.Text.Trim().ToString() == "" ? "0" : this.txtmin.Text.Trim().ToString()) / 100).ToString();

        string cellEmployee = types == "4" ? Session["sendEmp"].ToString() : (hdnemp.Value == "" ? "" : hdnemp.Value);//短消息接收人员Session["sendEmp"].ToString();//
        string[] strs = null;
        string HuanMu, HuanLiao, HuanDan, FuShe, JiQi, MuJu, DaiLiao, WuDingDan, QiTa, DaiRen, ZiDingYi;
        HuanMu= HuanLiao=HuanDan=FuShe= JiQi= MuJu= DaiLiao=WuDingDan=QiTa= DaiRen= ZiDingYi="";
        if (types == "4")
        {
            strs = cellEmployee.Split('/');
            HuanMu = strs[0].ToString();
            HuanLiao = strs[1].ToString();
            HuanDan = strs[2].ToString();
            FuShe = strs[3].ToString();
            JiQi = strs[4].ToString();
            MuJu = strs[5].ToString();
            DaiLiao = strs[6].ToString();
            WuDingDan = strs[7].ToString();
            QiTa = strs[8].ToString();
            DaiRen = strs[9].ToString();
            ZiDingYi = strs[10].ToString();
        }
        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";
        try
        {
           if (UI == "INSERT")
            {
                if (ddlMachineNo.SelectedItem.Text == "全部")//应用到所有时先删除已有的
                {
                    calldal.DeleteCall(types, subMachine, BcCode);
                }
                else
                {
                    if (types != "4" && calldal.selectWorkPaper(types, "1", "MachineNo", MachineNo).Count > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, "该机器的配置已存在!");
                        return;
                    }
                }
            }
            

            if (ddlMachineNo.SelectedItem.Text == "全部" && UI == "INSERT")//应用到所有时 
            {
                //IList<MachineMstr_MDL> temp = MachineMstr_BLL.selectMachineMstr(0, "","");
                DataTable dtTmp = MachineMstr_BLL.selectMachinePlant(subMachine);
                foreach (DataRow dr in dtTmp.Rows)
                { 
                    if (types == "4")
                    {
                        calldal.InsertCall(new CallConfig_MDL(txtID.Text.Trim().ToString(), types
                                      , CallStr, CallTypeID, UnitType, UnitTypeID,
                                       types == "4" ? "0" : CallValue, UnitValue, CreateTime,
                                       dr["MachineCode"].ToString().Trim(), "", sendnum, types == "4" ? "0" :
                                       upNum, types == "4" ? "0" : downNum, cellEmployee, HuanMu, HuanLiao
                                       , HuanDan, FuShe, JiQi, MuJu, DaiLiao, WuDingDan, QiTa, DaiRen,
                                       ZiDingYi, BcCode), UI);
                    }
                    else
                    {
                        calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(),
                            types, CallStr, CallTypeID, UnitType, UnitTypeID, types == "4" ? "0" :
                            CallValue, UnitValue, CreateTime, dr["MachineCode"].ToString().Trim(), "",
                            sendnum, types == "4" ? "0" : upNum, types == "4" ? "0"
                             : downNum, cellEmployee, BcCode), UI);
                    }
                }
                //for (int i = 0; i < temp.Count; i++)
                //{
                //    if (types == "4")
                //    {
                //        calldal.InsertCall(new CallConfig_MDL(txtID.Text.Trim().ToString(), types
                //                      , CallStr, CallTypeID, UnitType, UnitTypeID, 
                //                       types == "4" ? "0" : CallValue, UnitValue, CreateTime, 
                //                       temp[i].Machine_Code.ToString(), "", sendnum, types == "4" ? "0" :
                //                       upNum, types == "4" ? "0" : downNum, cellEmployee, HuanMu, HuanLiao
                //                       , HuanDan, FuShe, JiQi, MuJu, DaiLiao, WuDingDan, QiTa, DaiRen,
                //                       ZiDingYi,BcCode), UI);
                //    }
                //    else
                //    {
                //        calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(),
                //            types, CallStr, CallTypeID, UnitType, UnitTypeID, types == "4" ? "0" : 
                //            CallValue, UnitValue, CreateTime, temp[i].Machine_Code.ToString(), "", 
                //            sendnum, types == "4" ? "0" : upNum, types == "4" ? "0" 
                //             : downNum, cellEmployee,BcCode), UI);
                //    }
                //}
                dboSetCtrls.SetExecMsg(this, "INSERT", true);
                Session["sendEmp"] = "//////////";
            }
            else
            {
                IList<MachineMstr_MDL> temp4 = MachineMstr_BLL.selectMachineMstr(0, "Machine_code", ddlMachineNo.SelectedValue.Trim());
                int flagex = 0;
                if (types == "4")
                {
                    if (UI == "INSERT")
                    {
                        calldal.DeleteCallDetail(types, MachineNo, UnitValue);
                    }
                    for (int i = 0; i < temp4.Count; i++)
                    {
                        flagex = calldal.InsertCall(new CallConfig_MDL(txtID.Text.Trim().ToString(),
                            types, CallStr, CallTypeID, UnitType, UnitTypeID, types == "4" ? "0" :
                            CallValue, UnitValue, CreateTime, temp4[i].Machine_Code.ToString(), "",
                            sendnum, types == "4" ? "0" : upNum, types == "4" ? "0" : downNum,
                            cellEmployee, HuanMu, HuanLiao, HuanDan, FuShe, JiQi, MuJu, DaiLiao
                            , WuDingDan, QiTa, DaiRen, ZiDingYi,BcCode), UI);
                    }
                }
                else
                {
                    for (int i = 0; i < temp4.Count; i++)
                    {
                        flagex = calldal.InsertCall_1(new CallConfig_MDL(txtID.Text.Trim().ToString(),
                            types, CallStr, CallTypeID, UnitType, UnitTypeID, types == "4" ? "0" :
                            CallValue, UnitValue, CreateTime, temp4[i].Machine_Code.ToString(),
                            "", sendnum, types == "4" ? "0" : upNum, types == "4" ? "0" :
                            downNum, cellEmployee,BcCode), UI);
                    }
                }
                if (flagex >0)
                {
                    dboSetCtrls.SetExecMsg(this, UI, true);
                    //BindData();
                }
                else
                {
                    dboSetCtrls.SetExecMsg(this, UI, false);
                }
            }
           // bindSendemployee("0", "MachineNo", MachineNo);
          
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

    protected void ddlWorkShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        string MachineNo = ddlWorkShop.SelectedValue.Trim();
        if (MachineNo == "") return;
        ddlMachineNo.Items.Clear();
        DataTable dtMachine = MachineMstr_BLL.selectMachinePlant(MachineNo);
        DataRow dr=dtMachine.NewRow();
        dr["MachineCode"]="全部";
        dtMachine.Rows.InsertAt(dr, 0);
        dboSetCtrls.SetDropDownList(ddlMachineNo, dtMachine, "MachineCode", "MachineCode");
    }

    /// <summary>
    /// update by fsq 2009.12.14
    /// 增加车间的选择，根据车间选择机器
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        bindcheck();
      //  Response.Write(hdnemp.Value);
        dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnUpdate, btnInsert, btnDelete, "DROPDOWNLIST", ddlExecute);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();
        //Response.Write(vID);
        IList<CallConfig_MDL> tempList = calldal.selectWorkPaper(0, 1, int.Parse(vID), "", "");
        if (tempList[0].CallID == "4")
        {
            CheckBoxList1.Visible = false;
            this.CheckBoxList1.Enabled = false;
            RadioButtonList1.Visible = true;
            RadioButtonList1.Enabled = true;

            this.txtmax.Enabled = false;
            this.txtmin.Enabled = false;
            Session["sendEmp"] = tempList[0].SendEmployee;
            // this.Button1.Enabled = false;
            this.Button1.Visible = true;
            this.Button2.Visible = true;
            this.Button3.Visible = true;
            this.Button4.Visible = true;
            Label1.Visible = Label6.Visible = Label7.Visible = Label8.Visible = false;

            
            txtNum.Enabled = false;
            lblFileName.Enabled = false;
            Label4.Enabled = false;
            Label5.Enabled = false;
            

            hdnemp.Value = "";
            bindselect2();

        }
        else
        {
            this.CheckBoxList1.Enabled = false;
            CheckBoxList1.Visible = true;
            RadioButtonList1.Visible = false;
            RadioButtonList1.Enabled = false;
            // this.Button1.Enabled = false;
            this.Button1.Visible = false;
            this.Button2.Visible = false;
            this.Button3.Visible = false;
            this.Button4.Visible = false;
            this.txtmax.Enabled = true;
            this.txtmin.Enabled = true;
            txtNum.Enabled = true;
            lblFileName.Enabled = true;
            Label4.Enabled = true;
            Label5.Enabled = true;
            bindSendemployee(tempList[0].SendEmployee);
            Label1.Visible = Label6.Visible = Label7.Visible = Label8.Visible = true;
        }
       // this.ddlMachineNo.SelectedValue = tempList[0].MachineNo;
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempList[0].MachineNo);
        ddlWorkShop = dboSetCtrls.SetSelectedIndex(ddlWorkShop, MachineMstr_BLL.selectParentWorkShop(tempList[0].MachineNo));
        //ddlUnit = dboSetCtrls.SetSelectedIndex(ddlUnit, tempList[0].UnitTypeID);
        ddlExecute = dboSetCtrls.SetSelectedIndex(ddlExecute, tempList[0].CallID);
        ddlBc = dboSetCtrls.SetSelectedIndex(ddlBc, tempList[0].BcCode);
       // this.ddlUnit.SelectedValue = tempList[0].UnitTypeID;
        this.txtCycle.Text = tempList[0].UnitValue;
        this.txtNum.Text = tempList[0].CallValue;
        //this.ddlExecute.SelectedValue = tempList[0].CallID;
        this.txtsend.Text = tempList[0].SendNum;
        this.txtmax.Text =Convert.ToString( (Double.Parse(tempList[0].UpNum)*100));
        this.txtmin.Text = Convert.ToString(Double.Parse(tempList[0].DownNum)*100);
        ddlExecute.Enabled = false;
        ddlMachineNo.Enabled = false;
        ddlWorkShop.Enabled = false;
        //ddlBc.Enabled = false;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = Session["sendEmp"].ToString();
        //   Response.Write(str);
        Session["sendEmp10"] = str.Substring(str.LastIndexOf('/') + 1) == "" ? " " : str.Substring(str.LastIndexOf('/'));
        // Response.Write(str);
        int bbs = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '/')
            {
                if (bbs < 10)
                {
                    Session["sendEmp" + bbs] = str.Substring(0, i) + "/";
                    // Response.Write(Session["sendEmp" + bbs]+"<br/>");
                    str = str.Substring(i + 1, str.Length - i - 1);
                }
                else
                {
                    Session["sendEmp" + bbs] = str.Substring(0, i);
                    // Response.Write(Session["sendEmp" + bbs]+"<br/>");
                    str = str.Substring(i + 1, str.Length - i - 1);
                }
                i = -1;
                bbs++;
                //continue;
            }
        }


        if (!RadioButtonList1.Visible)
        {
            for (int t = 0; t < CheckBoxList1.Items.Count; t++)
            {

                if (CheckBoxList1.Items[t].Selected)
                {
                    if (t < CheckBoxList1.Items.Count-1)
                    {
                        Session["sendEmp" + t] = hdnemp.Value.ToString() + "/";
                        CheckBoxList1.Items[t].Selected = false;
                        CheckBoxList1.Items[t].Enabled = false;
                    }
                    else
                    {
                        Session["sendEmp" + (RadioButtonList1.Items.Count-1)] = hdnemp.Value.ToString();
                        CheckBoxList1.Items[t].Selected = false;
                        CheckBoxList1.Items[t].Enabled = false;
                    }

                }
            }
        }
        else
        {
            for (int t = 0; t < RadioButtonList1.Items.Count; t++)
            {
                if (RadioButtonList1.Items[t].Selected)
                {
                    if (t < RadioButtonList1.Items.Count-1)
                    {
                        Session["sendEmp" + t] = hdnemp.Value.ToString() + "/";
                    }
                    else
                    {
                        Session["sendEmp" + (RadioButtonList1.Items.Count-1)] = hdnemp.Value.ToString();
                        // RadioButtonList1.Items[t].Selected = false;
                        //RadioButtonList1.Items[t].Enabled = false;
                    }
                    //  RadioButtonList1.Items[t].Selected = false;
                    //  RadioButtonList1.Items[t].Enabled = false;
                }
            }
        }


        Session["sendEmp"] = (Session["sendEmp0"] == DBNull.Value ? "" : Session["sendEmp0"].ToString());
        Session["sendEmp"] += (Session["sendEmp1"] == DBNull.Value ? "" : Session["sendEmp1"].ToString());
        Session["sendEmp"] += (Session["sendEmp2"] == DBNull.Value ? "" : Session["sendEmp2"].ToString());
        Session["sendEmp"] += (Session["sendEmp3"] == DBNull.Value ? "" : Session["sendEmp3"].ToString());
        Session["sendEmp"] += (Session["sendEmp4"] == DBNull.Value ? "" : Session["sendEmp4"].ToString());
        Session["sendEmp"] += (Session["sendEmp5"] == DBNull.Value ? "" : Session["sendEmp5"].ToString());
        Session["sendEmp"] += (Session["sendEmp6"] == DBNull.Value ? "" : Session["sendEmp6"].ToString());
        Session["sendEmp"] += (Session["sendEmp7"] == DBNull.Value ? "" : Session["sendEmp7"].ToString());
        Session["sendEmp"] += (Session["sendEmp8"] == DBNull.Value ? "" : Session["sendEmp8"].ToString());
        Session["sendEmp"] += (Session["sendEmp9"] == DBNull.Value ? "" : Session["sendEmp9"].ToString());
        Session["sendEmp"] += (Session["sendEmp10"] == DBNull.Value ? "" : Session["sendEmp10"].ToString());
        if (Session["sendEmp10"] == DBNull.Value)
        {
            Session["sendEmp"] = Session["sendEmp"].ToString().Substring(0, Session["sendEmp"].ToString().Length - 2);
        }
        Session["sendEmp"] = Session["sendEmp"].ToString().Trim();
        // Response.Write(Session["sendEmp8"].ToString()+"<br/>");
        // Response.Write(Session["sendEmp"].ToString());
        bindselect2();
        this.hdnemp.Value = "";


    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       string sendemp = Session["sendEmp"].ToString();
       Select2.Items.Clear();
       string[] strs = null;
       strs = sendemp.Split('/');
      
        for (int i = 0; i < RadioButtonList1.Items.Count; i++)
        {
            if (RadioButtonList1.Items[i].Selected)
            {
                bindSendemployee(strs[i].ToString());
            }
        }
    }
    protected void ddlExecute_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddls = (DropDownList)sender;
        string str = ddlExecute.SelectedValue.Trim();
        if (ddls.ID == "ddlExecute")
        {
            
            if (ddls.SelectedValue == "4")//停机
            {

                this.CheckBoxList1.Enabled = true;
                this.CheckBoxList1.Attributes.Add("onclick", "moveOption2(document.form1.Select2, document.form1.Select1)");
                // this.Button1.Enabled = false;
                this.Button1.Visible = true;
                this.Button2.Visible = true;
                this.Button3.Visible = this.Button4.Visible = true;

                Label1.Visible = Label6.Visible = Label7.Visible = Label8.Visible = false;
                this.txtmax.Enabled = false;
                this.txtmin.Enabled = false;
                txtNum.Enabled = false;
                lblFileName.Enabled = false;
                Label4.Enabled = false;
                Label5.Enabled = false;
                //lblBc.Enabled = false;
                bindcheck();
                //ddlMachineNo.Items.Clear()
                //dboSetCtrls.SetDropDownList(ddlMachineNo, new MachineSuit_DAL().selectMachineMstrAll() as IList, true, "Machine_MaterialChgAmt", "Remark");
            }
            else
            {
                this.CheckBoxList1.Enabled = false;
                // this.Button1.Enabled = false;
                this.Button1.Visible = false;
                this.Button2.Visible = false;
                this.Button3.Visible = false;
                this.Button4.Visible = false;

                Label1.Visible = Label6.Visible = Label7.Visible = Label8.Visible = true;
                this.txtmax.Enabled = true;
                this.txtmin.Enabled = true;
                txtNum.Enabled = true;
                lblFileName.Enabled = true;
                Label4.Enabled = true;
                Label5.Enabled = true;
                //ddlBc.Enabled = true;
                // IList<MachineMstr_MDL> tempList = MachineMstr_BLL.selectMachineMstr(0, "", "");

                //dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");
                //dboSetCtrls.SetDropDownList(ddlMachineNo, new MachineSuit_DAL().selectMachineMstr() as IList, true, "Machine_MaterialChgAmt", "Remark");

            }
        }
    }
}
