using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.Model.BaseInfo_MDL;
using Admin.Model.Machine_MDL;
using Admin.BLL.Product_BLL;
using Admin.BLL.Machine_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.DBUtility;
using Admin.SQLServerDAL.GetErp;

public partial class Product_DispatchOrder : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    public SortDirection GridViewSortDirection
    {
        get { return (ViewState["sortDirectionDispatchOrder"] == null) ? SortDirection.Ascending : (SortDirection)ViewState["sortDirectionDispatchOrder"]; }
        set { ViewState["sortDirectionDispatchOrder"] = value; }
    }

    private string GridViewSortExpression
    {
        get { return (ViewState["sortExpression"] == null) ? "DispatchStatus" : ViewState["sortExpression"].ToString().Trim(); }
        set { ViewState["sortExpression"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Product_DispatchOrder));//Product_DispatchOrder
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "DispatchOrder");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = ddlDispatchStateFlag.Enabled = false;
            if (o[1]) igbInsert.Visible = igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
            if (o[5])
            {
                igbCheckYdouble.Visible =
                 igbCheckYsingle.Visible = false;
            }
            if (o[6]) igbCheckNdouble.Visible = igbCheckNsingle.Visible = false;

        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            //090718吴礼政
            //Dispatch_Type = "IM";
            BindData();
            //SortGridView2(GridViewSortExpression, "ASC");
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            igbCheckYdouble.Attributes.Add("onclick", "BatchChecked('GridView1')");
            igbCheckNdouble.Attributes.Add("onclick", "BatchChecked('GridView1')");
            this.search.Disabled = true;
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstr() as IList, true, "Machine_MaterialChgAmt", "Remark");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        string status = ddlDispatchStateFlag.SelectedValue.Trim();
        string indexs = hdnCellIndexss.Value.Trim();
        string Machine_Code = this.ddlMachine_SeatCode.SelectedValue.ToString();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, status, colname, coltext, Machine_Code, indexs);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetGridView(ddlDispatchStateFlag, GridView1, "CheckStatus");
        dboSetCtrls.SetGridView(ddlCheckStatus, GridView1, "DispatchStatus");
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    private void BindData2()
    {
        string colname = "Creater";
        string coltext = this.Page.User.Identity.Name.ToString();
        string status = ddlDispatchStateFlag.SelectedValue.Trim();
        string indexs = hdnCellIndexss.Value.Trim();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, status, colname, coltext, indexs);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetGridView(ddlDispatchStateFlag, GridView1, "CheckStatus");
        dboSetCtrls.SetGridView(ddlCheckStatus, GridView1, "DispatchStatus");
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }


    protected void btMould_Click(object sender, EventArgs e)
    {
        string strAddr = string.Empty;
        string MouldNo = ddlMouldNo.SelectedValue.Trim();
        if (MouldNo == "") MouldNo = txtHiddenMouldNo.Value.Trim();
        if (MouldNo == "") return;
        if (MouldNo.ToUpper().Trim().Substring(0, 2) == "MO")
        {
            strAddr = "BaseInfo/MouldMstr.aspx";
        }
        else
        {
            strAddr = "Product/ClampManage.aspx";
        }
        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../" + strAddr + "?MouldNo=" + MouldNo + "','_newwindow', 'status=no,scrollbars=yes,resizable=yes,width=600,height=385,left=270,top=100')</script>");
    }

    protected void btMachine_Click(object sender, EventArgs e)
    {
        string strAddr = string.Empty;
        string MachineNo = ddlMachineNo.SelectedValue.Trim();
        if (MachineNo == "") MachineNo = txtHiddenMachineNo.Value.Trim();
        if (MachineNo == "") return;
        if (MachineNo.ToUpper().Trim().Substring(0, 2) == "IM")
        {
            strAddr = "BaseInfo/MachineMstr.aspx";
        }
        else
        {
            strAddr = "Product/MachineSuit.aspx";
        }
        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
         @"<script> window.open('../" + strAddr + "?MachineNo=" + MachineNo + "','_newwindow', 'status=no,scrollbars=yes,resizable=yes,width=600,height=385,left=270,top=100')</script>");
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        //新增一个派工单 
        ImageButton tempButton = sender as ImageButton;
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        int vMasterID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vDispatchOrderNo = txtDO_No.Text.Trim();//派工单号
        string vWorkOrderNo = search.Value.Trim();//生产单号
        string vProductNo = txtProductNo.Text.Trim();//产品编号
        string vProductDesc = txtProductDesc.Text.Trim();// 产品描述
        // string vMachineNo = IU == "INSERT" ? Hidden2.Value.Trim() : ddlMachineNo.SelectedValue.ToString();//机器编号
        //  string vMouldNo = IU == "INSERT" ? Hidden1.Value.Trim() : ddlMouldNo.SelectedValue.Trim();//模具编号
        string vMachineNo = ddlMachineNo.SelectedValue.ToString();//机器编号
        string vMouldNo = ddlMouldNo.SelectedValue.Trim();//模具编号
        string vDispatchDate = (txtDispatchDate.Value.Trim() == "") ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : txtDispatchDate.Value.Trim();
        string vDispatchNum = (txtDispatchNum.Text.Trim() == "") ? "0" : txtDispatchNum.Text.Trim();
        string vStartDate = txtStartDate.Value.Trim();
        string vStopDate = txtStopDate.Value.Trim();
        string vRemark = txtRemark.Text.Trim();
        string StandCycle = txtStandCycle.Text.Trim() == "" ? "0" : txtStandCycle.Text.Trim();
        string vstate = IU == "INSERT" ? "0" : txtstate.Value.Trim();//审核状态
        string CheckStatus = IU == "INSERT" ? "0" : txtCheckStatus.Value.Trim(); //派工状态
        string SingleStatus = this.rdUrgentSingle.SelectedValue.Trim();//派工单状态 1正常单，2急单，3次急单

        if (SingleStatus == "2")//急单状态
        {
            vstate = "3";
        }
        if (SingleStatus == "3")//次急单状态
        {
            vstate = "4";
        }

        //string GroupNum = this.txtGroupNum.Text.Trim() == "" ? "0" : this.txtGroupNum.Text.Trim();
        string Creater = this.Page.User.Identity.Name.ToString();
        ArrayList arraysCycle = GetMachineMstrMaxCycle(vMouldNo, vProductNo, StandCycle);
        string MaxInjectionCycle = "";
        string MinInjectionCycle = "";
        if (arraysCycle.Count > 0)
        {
            MaxInjectionCycle = arraysCycle[0].ToString();
            MinInjectionCycle = arraysCycle[1].ToString();
        }
        else
        {
            MaxInjectionCycle = Convert.ToString(int.Parse(StandCycle) + 3);
            MinInjectionCycle = Convert.ToString(int.Parse(StandCycle) - 2);
        }
        int xid;

        //if(vDispatchNum>)
        if ("" == ddlMouldNo.SelectedValue.Trim())
        {
            dboSetCtrls.SetExecMsg(this, "请选择模具!");
            return;
        }
        if ("" == ddlMachineNo.SelectedValue.Trim())
        {
            dboSetCtrls.SetExecMsg(this, "请选择机器!");
            return;
        }
        if (DateTime.Parse(vStartDate) > DateTime.Parse(vStopDate) || DateTime.Parse(vStartDate) == DateTime.Parse(vStopDate))
        {
            dboSetCtrls.SetExecMsg(this, "结束时间要大于开始时间!");
            return;
        }
        if (tempButton.ID != "igbInsert")//修改时
        {
            if (CheckStatus == "2" || CheckStatus == "1")
            {
                dboSetCtrls.SetExecMsg(this, "此单已派工或已完成生产,不可修改!");
                return;
            }
        }
        if (SingleStatus != "1")
        {
            IList<DispatchOrder_MDL> mylist = DispatchOrder_BLL.existsDispatchOrder(vMachineNo, "MachineNo", "2");
            for (int i = 0; i < mylist.Count; i++)
            {
                if (SingleStatus == "2")
                {
                    if (i == mylist.Count - 1)
                    {
                        if (DateTime.Parse(mylist[i].StartDate) >= DateTime.Parse(vStartDate) || DateTime.Parse(mylist[i].StopDate) <= DateTime.Parse(vStartDate))
                        {
                            if (mylist[i].DispatchStatus != "2")
                            {
                                dboSetCtrls.SetExecMsg(this, "此派工时间必须大于该机器主单时间!");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (i == mylist.Count - 2)
                    {
                        if (DateTime.Parse(mylist[i].StartDate) >= DateTime.Parse(vStartDate) || DateTime.Parse(mylist[i].StopDate) <= DateTime.Parse(vStartDate))
                        {
                            if (mylist[i].DispatchStatus != "2")
                            {
                                dboSetCtrls.SetExecMsg(this, "此派工时间必须大于该机器次单时间!");
                                return;
                            }
                        }
                    }
                }
            }
        }
        if (IU == "INSERT")
        {
            if (SingleStatus == "1")
            {
                IList<DispatchOrder_MDL> mylist = DispatchOrder_BLL.existsDispatchOrder(vMachineNo, "MachineNo");
                for (int i = 0; i < mylist.Count; i++)
                {

                    if (DateTime.Parse(mylist[i].StartDate) <= DateTime.Parse(vStartDate) && DateTime.Parse(mylist[i].StopDate) >= DateTime.Parse(vStartDate))
                    {
                        if (mylist[i].DispatchStatus != "2")
                        {
                            if (mylist.Count != 0 && mylist[i].DispatchStatus != "1")
                            {
                                dboSetCtrls.SetExecMsg(this, "此机器在该时间段已派工,不可重复派工!");
                                return;
                            }
                        }
                    }
                    if (DateTime.Parse(mylist[i].StartDate) >= DateTime.Parse(vStartDate) && DateTime.Parse(mylist[i].StopDate) >= DateTime.Parse(vStartDate))
                    {
                        if (mylist[i].DispatchStatus != "2")
                        {
                            if (mylist.Count != 0 && mylist[i].DispatchStatus != "1")
                            {
                                dboSetCtrls.SetExecMsg(this, "此机器在该时间段已派工,不可重复派工!");
                                return;
                            }
                        }
                    }
                    if (DateTime.Parse(mylist[i].StartDate) >= DateTime.Parse(vStartDate) && DateTime.Parse(mylist[i].StopDate) <= DateTime.Parse(vStartDate))
                    {
                        if (mylist[i].DispatchStatus != "2")
                        {
                            if (mylist.Count != 0 && mylist[i].DispatchStatus != "1")
                            {
                                dboSetCtrls.SetExecMsg(this, "此机器在该时间段已派工,不可重复派工!");
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                if (SingleStatus == "2")
                {
                    if (GetUrgentOrTimeUrgent(vMachineNo, 3))
                    {
                        dboSetCtrls.SetExecMsg(this, "此机器已存在急单,请勿重复下急单!");
                        return;
                    }
                }
                if (SingleStatus == "3")
                {
                    if (GetUrgentOrTimeUrgent(vMachineNo, 3))
                    {
                        dboSetCtrls.SetExecMsg(this, "此机器已存在未生产急单,不能下次急单!");
                        return;
                    }
                }
                
            }
        }

        try
        {
            DispatchOrder_BLL.ChangeDispatchOrder(vMasterID,
                                    vDispatchOrderNo, vWorkOrderNo, vMachineNo, vMouldNo, vProductNo, vProductDesc,
                                    vStartDate, vStopDate, System.DateTime.Now.ToString(),
                                     DateTime.Now.ToString(), "0", vDispatchDate, vDispatchNum, CheckStatus, vstate, vRemark, StandCycle, MaxInjectionCycle, MinInjectionCycle, "0", Creater, IU, out xid);
            if (xid > 0)
            {
                dboSetCtrls.SetExecMsg(this, IU, true);
                // bindDrop(vMouldNo, vProductNo);
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }

            bindDrop(vMouldNo, vProductNo);
            dboSetCtrls.SetSelectedIndex(ddlMouldNo, vMouldNo);
            dboSetCtrls.SetSelectedIndex(ddlMachineNo, vMachineNo);

            
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
    }

    void bindDrop(string vMouldNo, string vProductNo)
    {
        string prodNo = vProductNo;
        string mouldNo = vMouldNo;
        if (prodNo != "")
        {
            if (prodNo.Substring(0, 1) == "2")
            {
                IList<ItemMstr_MDL> myList = ItemMstr_BLL.selectItemMstrDetail(0, "", "", "Item_Code", prodNo);
                dboSetCtrls.SetDropDownList(ddlMouldNo, myList as IList, false, "MouldCode", "MouldCode");
            }
            else if (prodNo.Substring(0, 1) == "4")
            {
                IList<SuitManage_MDL> myList = new SuitManage_DAL().selectSuitManageDetail(0, "", "", "PlantBristlesCode", prodNo);
                dboSetCtrls.SetDropDownList(ddlMouldNo, myList as IList, false, "WireBrushMould", "WireBrushMould");
            }
        }
        if (mouldNo != "")
        {
            if (prodNo.Substring(0, 1) == "2")
            {
                IList<MouldDetail_MDL> myList = MouldDetail_BLL.existsMouldDetail(mouldNo);// 获取模具适用机器型号
                ddlMachineNo.Items.Clear();
                ddlMachineNo.Items.Add(new ListItem("选择", ""));
                if (myList.Count > 0)
                {
                    string FitMachineG = myList[0].FitMachineG;
                    IList<MachineMstr_MDL> tempList = MachineMstr_BLL.selectMachineMstr(0, "", "");
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempList[i].Machine_ShotQty != "" && double.Parse(FitMachineG) <= double.Parse(tempList[i].Machine_ShotQty))
                        {
                            ddlMachineNo.Items.Add(new ListItem(tempList[i].Machine_Code, tempList[i].Machine_Code));
                        }
                    }
                }
            }
            else if (prodNo.Substring(0, 1) == "4")
            {
                IList<ClampManage_MDL> myList = new ClampManage_DAL().selectClampManage(0, "FixtureCode", mouldNo, 1);
                dboSetCtrls.SetDropDownList(ddlMachineNo, myList as IList, false, "PlantBristlesMachine", "PlantBristlesMachine");
            }
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string strSQL = string.Empty;
        string strDispatchNo = string.Empty;
        DataTable dtTmp;
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                int id = string.IsNullOrEmpty(txtID.Text.Trim()) ? 0 : Convert.ToInt32(txtID.Text.Trim());
                if (id == 0) return;
                strSQL = "select checkstatus,Do_No from dispatchorder where ID={0}";
                strSQL = string.Format(strSQL, id);
                dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                if (dtTmp != null && dtTmp.Rows[0]["checkstatus"].ToString() == "1")
                {
                    strDispatchNo = dtTmp.Rows[0]["Do_No"].ToString();
                    dboSetCtrls.SetExecMsg(this, "工单号:" + strDispatchNo + "已审核，不能删除!");
                    return;
                }

                pIDList.Add(txtID.Text.Trim());
                DispatchOrder_BLL.cancelDispatchOrder(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                foreach (string strID in pIDList)
                {
                    strSQL = "select checkstatus,Do_No from dispatchorder where ID={0}";
                    strSQL = string.Format(strSQL, int.Parse(strID));
                    dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                    if (dtTmp != null && dtTmp.Rows[0]["checkstatus"].ToString() == "1")
                    {
                        strDispatchNo = dtTmp.Rows[0]["Do_No"].ToString();
                        dboSetCtrls.SetExecMsg(this, "工单号:" + strDispatchNo + "已审核，不能删除!");
                        return;
                    }
                }
                DispatchOrder_BLL.cancelDispatchOrder(pIDList);
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
        try
        {
            ImageButton tempButton = sender as ImageButton;
            if (tempButton.ID == "igbNewadd")
            {
                //新增一个派工单
                MultiView1.ActiveViewIndex = 1;
                dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtDO_No);
                object[] textboxid = { txtDO_No, txtProductNo, txtStandCycle, txtProductDesc, txtDispatchNum, txtRemark };
                dboSetCtrls.InitCtrls(this, "textbox", textboxid);
                search.Value = "";
                txtDispatchDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txtDispatchDate.Disabled = true;
                txtStartDate.Value = txtStopDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                //Text1.Value = "07:20";
                //Text2.Value = "07:20";
                GridView2.Visible = false;
                this.search.Disabled = false;
                this.ddlMouldNo.AutoPostBack = false;
                ddlMouldNo.Attributes.Add("onchange", "selectIndex('ddlMouldNo')");
                ddlMachineNo.Attributes.Add("onchange", "selectIndex('ddlMachineNo')");
                ddlMouldNo.SelectedIndex = ddlMachineNo.SelectedIndex = 0;
                txtCheckStatus.Value = "";
                txtStandCycleMould.Text = "";
                this.rdUrgentSingle.SelectedIndex = 0;
            }
            else
            {
                if (tempButton.ID != "igbQuery")
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    this.GridView1.PageIndex = 0;
                }
                BindData();
            }
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
    }

    protected void ddlDispatchState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void CtrlPageInfo_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);

        //for (int i = 0; i < GridView1.Rows.Count; i++)
        //{
        //    int y = GridView1.Columns.Count - 1;
        //    int t = GridView1.Columns.Count - 2; 
        //    string Value = GridView1.Rows[i].Cells[t].Text;
        //    string txt = GridView1.Rows[i].Cells[y].Text;
        //    if (Value == "0")
        //    {
        //        GridView1.Rows[i].BackColor = System.Drawing.Color.Red;
        //    }
        //    else if (Value == "1" && txt == "0")
        //    {
        //        GridView1.Rows[i].BackColor = System.Drawing.Color.BurlyWood; //.Yellow;
        //    }
        //    else if (txt == "1")
        //    {
        //        GridView1.Rows[i].BackColor = System.Drawing.Color.Green;
        //    }
        //}
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]) as LinkButton).Text.Trim();
        string vCmd = e.CommandName.Trim();

        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtDO_No);
        IList<DispatchOrder_MDL> tempIList = DispatchOrder_BLL.selectDispatchOrder(Int32.Parse(vID), "", "", "");
        bindDrop(tempIList[0].MouldNo, tempIList[0].ProductNo);

        int vMasterID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        txtDO_No.Text = tempIList[0].DO_No;//派工单号
        search.Value = tempIList[0].WorkOrderNo;//生产单号
        txtProductNo.Text = tempIList[0].ProductNo;//产品编号
        txtProductDesc.Text = tempIList[0].ProductDesc;// 产品描述
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempIList[0].MachineNo);//机器编号
        ddlMouldNo = dboSetCtrls.SetSelectedIndex(ddlMouldNo, tempIList[0].MouldNo);//模具编号
        this.Hidden1.Value = tempIList[0].MouldNo;
        this.Hidden2.Value = tempIList[0].MachineNo;
        txtDispatchDate.Value = tempIList[0].DispatchDate;
        txtDispatchNum.Text = tempIList[0].DispatchNum;
        txtStartDate.Value = DateTime.Parse(tempIList[0].StartDate).ToString("yyyy-MM-dd HH:mm");
        txtStopDate.Value = DateTime.Parse(tempIList[0].StopDate).ToString("yyyy-MM-dd HH:mm");
        txtRemark.Text = tempIList[0].Remark;
        txtstate.Value = tempIList[0].DispatchStatus;
        GridView2.Visible = true;
        this.search.Disabled = true;
        //Text1.Value = tempIList[0].StartDate.Substring(11, 5);//tempIList[0].StartDate.Length == 16 ? "0"+tempIList[0].StartDate.Substring(10, 4) : tempIList[0].StartDate.Substring(10, 5);
        //Text2.Value = tempIList[0].StopDate.Substring(11, 5);//tempIList[0].StopDate.Length == 17 ? "0" + tempIList[0].StopDate.Substring(10, 4) : tempIList[0].StopDate.Substring(10, 5);
        txtDO_No.Text = tempIList[0].DO_No;
        txtstate.Value = tempIList[0].DispatchStatus;
        this.ddlMouldNo.AutoPostBack = true;
        txtCheckStatus.Value = tempIList[0].CheckStatus;
        Hidden3.Value = tempIList[0].DispatchStatus;
        txtStandCycle.Text = tempIList[0].StandCycle;
        //txtGroupNum.Text = tempIList[0].GroupNum;
        if (vCmd == "Detail")
            BindDataDetail(tempIList[0].MachineNo);
        ArrayList arraysCycle = GetMachineMstrCycle(tempIList[0].MouldNo, tempIList[0].ProductNo);
        txtStandCycleMould.Text = "";
        if (arraysCycle.Count > 0)
        {
            for (int i = 0; i < arraysCycle.Count; i++)
            {
                txtStandCycleMould.Text = arraysCycle[i].ToString();
            }
        }
    }

    private void BindDataDetail(string MachineNo)
    {
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrderDetail(0, "MachineNo", MachineNo);
        GridView2.DataSource = tempList;
        GridView2.DataBind();

    }

    protected void btnCheck_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tmpImageButton = sender as ImageButton;
        try
        {

            ArrayList pIDList = new ArrayList();
            string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (tmpImageButton.ID == "igbCheckYsingle" || tmpImageButton.ID == "igbCheckNsingle")
            {
                pIDList.Add(txtID.Text.Trim());
                string sltValue = Hidden3.Value;// ddlDispatchStateFlag.SelectedValue.Trim();
                if (sltValue == "2" || sltValue == "1")
                {
                    dboSetCtrls.SetExecMsg(this, "此单已派工或完成了,不可审核");
                    return;
                }
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1, "DispatchOrder");
                for (int i = 0; i < pIDList.Count; i++)
                {
                    string flgs = DispatchOrder_BLL.selectDispatchOrder(int.Parse(pIDList[i].ToString()), "", "")[0].DispatchStatus;
                    if (flgs == "2" || flgs == "1")
                    {
                        dboSetCtrls.SetExecMsg(this, "此单已派工或完成了,不可审核");
                        return;
                    }
                }
            }

            if (pIDList.Count == 0)
            {
                dboSetCtrls.SetExecMsg(this, "没记录,不可审核");
                return;
            }
            string strFlag = (tmpImageButton.ID == "igbCheckNdouble" || tmpImageButton.ID == "igbCheckNsingle") ? "0" : "1";
            string strUserID = this.Page.User.Identity.Name.Trim();
            if (strFlag == "0")
            {
                DataTable dtTmp;
                DateTime CheckDate;
                foreach (string s in pIDList)
                {
                    string strSQL = @" select  isnull(CheckDate, dateadd(n,-15,getdate())) as CheckDate from DispatchOrder   where ID={0}";
                    strSQL = string.Format(strSQL, s);
                    dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                    CheckDate = Convert.ToDateTime(dtTmp.Rows[0]["CheckDate"].ToString());
                    TimeSpan timespan = Convert.ToDateTime(today).Subtract(Convert.ToDateTime(CheckDate));
                    if (timespan.Minutes <= 10)
                    {
                        dboSetCtrls.SetExecMsg(this, "审核时间在10分钟之内,不可审核驳回！");
                        return;
                    }
                }
            }

            DispatchOrder_BLL.checkDispatchOrder(strFlag, strUserID, pIDList);
            dboSetCtrls.SetExecMsg(this, "check", true);
            BindData();
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "check", false);
        }
        finally
        {
            tmpImageButton = null;
        }
    }

    #region 090720吴礼政
    [Ajax.AjaxMethod()]
    public string Getpc(string DispatchNo)
    {
        string ProductType = Admin.SQLServerDAL.Common.GetType(DispatchNo);
        return Admin.SQLServerDAL.Common.GetTempStr(ProductType, DispatchNo);
    }
    #endregion

    #region //给工单号和派工单号赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str, string cloIndex)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds;// = new GetErpItm().QueryErpDispatch(str);  //ERPSQLExecutant().0(sql);

        if (cloIndex == "-1")//生成派工单号
        {
            ds = new GetErpItm().QueryErpDispatchDetail(str);
            string dispatchNo = ds.Tables[0].Rows[0][0].ToString();//工单号
            string oldDO_No = DispatchOrder_BLL.existsDispatchOrder(dispatchNo, "WorkOrderNo").Count == 0 ? "" : DispatchOrder_BLL.existsDispatchOrder(dispatchNo, "WorkOrderNo")[0].DO_No;
            string newDO_No = "";
            string ProductNo = ds.Tables[0].Rows[0][3].ToString();//产品编号
            string StrFlage = "";
            if (ProductNo.Substring(0, 1) == "2")//是注塑产品时
            {
                StrFlage = "0";
            }
            else
            {
                StrFlage = "1";
            }
            if (oldDO_No != "")
            {
                int number = int.Parse(oldDO_No.Substring(oldDO_No.Length - 2, 2));
                if (number <= 9)
                {
                    newDO_No = dispatchNo + StrFlage + "0" + Convert.ToString((number + 1));
                }
                else
                {
                    newDO_No = dispatchNo + StrFlage + Convert.ToString((number + 1));
                }

            }
            else
            {
                newDO_No = dispatchNo + StrFlage + "01";
            }
            itmes.Add(newDO_No);
        }
        else
        {
            ds = new GetErpItm().QueryErpDispatch(str);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                itmes.Add(dr[int.Parse(cloIndex)]);
            }
        }

        return itmes;
    }
    #endregion

    #region //派工数量
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhValues(string str)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);
        double number = double.Parse(ds.Tables[0].Rows[0][2].ToString());
        int t = (Int32)number;
        itmes.Add(t.ToString());

        return itmes;
    }
    #endregion

    #region 给产品编号 产品描述赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhSetValues(string str, string flage)
    {
        ArrayList itmes = new ArrayList();
        DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);

        string itemStr1 = "";// ds.Tables[0].Rows[i]["CPNITMREF"].ToString();

        if (flage.ToString() == "1")
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //    itemStr1 = ds.Tables[0].Rows[i]["CPNITMREF"].ToString();
                //    itmes.Add(itemStr1);
                if (i != ds.Tables[0].Rows.Count - 1)
                {
                    itemStr1 += ds.Tables[0].Rows[i][3].ToString() + ",";
                }
                else
                {
                    itemStr1 += ds.Tables[0].Rows[i][3].ToString();
                }
                // itmes.Add(itemStr1);
            }
        }
        else
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i != ds.Tables[0].Rows.Count - 1)
                {
                    itemStr1 += ds.Tables[0].Rows[i][4].ToString() + " ";
                }
                else
                {
                    itemStr1 += ds.Tables[0].Rows[i][4].ToString();
                }

            }
        }
        itmes.Add(itemStr1);
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }
    #endregion

    #region  查询模具
    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMstr(string str)
    {
        ArrayList items = new ArrayList();
        if (str != "")
        {
            try
            {
                DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);
                string prodNo = ds.Tables[0].Rows[0][3].ToString();
                //为注塑产品时prodNo.Substring(prodNo.Length - 4, 2)
                //if (prodNo.Substring(0, 1) == "2")
                //{
                IList<ItemMstr_MDL> myList = ItemMstr_BLL.selectItemMstrDetail(0, "", "", "Item_Code", prodNo);
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        if (myList[i].MouldCode != "")
                        {
                            items.Add(myList[i].MouldCode);
                        }
                    }
                }
                //}
                //else if (prodNo.Substring(0, 1) == "4")
                else
                {
                    IList<SuitManage_MDL> TmpList = new SuitManage_DAL().selectSuitManageDetail(0, "", "", "PlantBristlesCode", prodNo);
                    if (TmpList.Count > 0)
                    {
                        for (int i = 0; i < TmpList.Count; i++)
                        {
                            if (TmpList[i].WireBrushMould != "")
                            {
                                items.Add(TmpList[i].WireBrushMould);
                            }
                        }
                    }
                    else
                    {
                        items.Add("");
                    }
                }

                return items;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new ArrayList();
            }
        }
        else
        {
            return items;
        }
    }
    #endregion

    #region 查询机器
    [Ajax.AjaxMethod()]
    public ArrayList GetMachineMstr(string mouldNo, string prodNo)
    {
        ArrayList items = new ArrayList();
        if (mouldNo != "" && prodNo != "")
        {
            try
            {
                //DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);
                //string prodNo = ds.Tables[0].Rows[0][3].ToString();
                //为注塑产品时prodNo.Substring(prodNo.Length - 4, 2)
                //if (prodNo.Substring(0, 1) == "2")
                //{
                IList<MouldDetail_MDL> myList = MouldDetail_BLL.existsMouldDetail(mouldNo);// 获取模具适用机器型号
                if (myList.Count > 0)
                {
                    string FitMachineG = myList[0].FitMachineG;
                    DataTable dt = MachineMstr_BLL.selectMachineCode(Convert.ToInt32(FitMachineG), prodNo);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!items.Contains(dt.Rows[i]["Machine_code"].ToString()))
                            {
                                items.Add(dt.Rows[i]["Machine_code"].ToString());

                            }
                        }
                    }

                    //IList<MachineMstr_MDL> tempList = MachineMstr_BLL.selectMachineMstr(0, "", "");
                    //for (int i = 0; i < tempList.Count; i++)
                    //{
                    //    if (tempList[i].Machine_ShotQty != "" && double.Parse(FitMachineG) <= double.Parse(tempList[i].Machine_ShotQty))
                    //    {
                    //        items.Add(tempList[i].Machine_Code);
                    //    }
                    //}
                }
                //}
                //else if (prodNo.Substring(0, 1) == "4")
                else
                {
                    IList<ClampManage_MDL> tmpList = new ClampManage_DAL().selectClampManage(0, "FixtureCode", mouldNo, 1);
                    items.Add(tmpList[0].PlantBristlesMachine);
                }
                return items;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new ArrayList();
            }
        }
        else
        {
            return new ArrayList();
        }
    }
    #endregion

    #region 查询模具标准周期
    [Ajax.AjaxMethod()]
    public ArrayList GetMachineMstrCycle(string mouldNo, string prodNo)
    {
        ArrayList items = new ArrayList();
        if (mouldNo != "" && prodNo != "")
        {
            try
            {
                //DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);
                //string prodNo = ds.Tables[0].Rows[0][3].ToString();
                //为注塑产品时prodNo.Substring(prodNo.Length - 4, 2)
                //if (prodNo.Substring(0, 1) == "2")
                //{
                IList<MouldDetail_MDL> myList = MouldDetail_BLL.existsMouldDetail(mouldNo);// 获取模具适用机器型号
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        items.Add(myList[i].InjectionCycle);
                    }
                }
                //else if (prodNo.Substring(0, 1) == "4")
                else
                {
                    string strSQL = @"select  isnull(MachineCycle,0) MachineCycle
                                from PlantBristlesToolInfo
                                where FixtureCode='" + mouldNo.Trim() + "'";
                    DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                    if (dtTmp != null)
                    {
                        items.Add(dtTmp.Rows[0]["MachineCycle"].ToString().Trim());
                    }
                    else items.Add("0");
                }
                return items;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new ArrayList();
            }
        }
        else
        {
            return new ArrayList();
        }
    }
    #endregion

    #region 查询模具最大最小周期
    public ArrayList GetMachineMstrMaxCycle(string mouldNo, string prodNo, string SendCycle)
    {
        ArrayList items = new ArrayList();
        if (mouldNo != "" && prodNo != "")
        {
            try
            {
                //DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);
                //string prodNo = ds.Tables[0].Rows[0][3].ToString();
                //为注塑产品时prodNo.Substring(prodNo.Length - 4, 2)
                //if (prodNo.Substring(0, 1) == "2")
                //{
                IList<MouldDetail_MDL> myList = MouldDetail_BLL.existsMouldDetail(mouldNo);// 获取模具适用机器型号
                if (myList.Count > 0)
                {
                    double InjectionCycle = double.Parse(myList[0].InjectionCycle);
                    double MaxInjectionCycle = double.Parse(myList[0].MaxInjectionCycle);
                    double MinInjectionCycle = double.Parse(myList[0].MinInjectionCycle);
                    if ((InjectionCycle == MaxInjectionCycle) || (InjectionCycle == MinInjectionCycle) || (MinInjectionCycle == MaxInjectionCycle))//最大最小标准周期相等时 
                    {
                        items.Add((double.Parse(SendCycle) + 3.00));
                        items.Add((double.Parse(SendCycle) - 2.00));
                    }
                    else if ((InjectionCycle < MaxInjectionCycle) && (InjectionCycle > MinInjectionCycle))
                    {
                        double cutnum = InjectionCycle - double.Parse(SendCycle);
                        items.Add(MaxInjectionCycle - cutnum);
                        items.Add(MinInjectionCycle - cutnum);
                    }
                    else
                    {
                        items.Add((double.Parse(SendCycle) + 3.00));
                        items.Add((double.Parse(SendCycle) - 2.00));
                    }
                }
                //else if (prodNo.Substring(0, 1) == "4")
                else
                {
                    //IList<ClampManage_MDL> myList = new ClampManage_DAL().selectClampManage(0, "FixtureCode", mouldNo, 1);
                    items.Add("0");
                    items.Add("0");
                }
                return items;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new ArrayList();
            }
        }
        else
        {
            return new ArrayList();
        }
    }
    #endregion

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton tempLinkButton = sender as LinkButton;

        for (int i = 0; i < 2; i++)
            Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");

        //string Target = "MachineMstr";
        int CellsIndex = 0;
        switch (tempLinkButton.ID.Trim())
        {
            case "LinkButton1"://注塑机器　
                //Target = "MachineMstr";
                CellsIndex = 0;
                dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstr() as IList, true, "Machine_MaterialChgAmt", "Remark");
                //Dispatch_Type = "IM";
                break;
            default:
                //Target = "PlantBristlesMachineInfo";//植毛机器
                CellsIndex = 1;
                dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().getMachineNo() as IList, true, "MachineType", "MachineCode");
                //Dispatch_Type = "PM";
                break;
        }
        Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");
        hdnCellIndexss.Value = CellsIndex.ToString();
        BindData();
        //SortGridView2(GridViewSortExpression, "ASC");
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
        // SortGridView(GetColName, GetStort);
        SortGridView(GridViewSortExpression, (GridViewSortDirection == SortDirection.Ascending) ? "Asc" : "Desc");
    }

    protected void ddlMachine_SeatCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }

    private void SortGridView(string sortExpression, string direction)
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        string status = ddlDispatchStateFlag.SelectedValue.Trim();
        string indexs = hdnCellIndexss.Value.Trim();
        string Machine_Code = this.ddlMachine_SeatCode.SelectedValue.ToString();
        DataSet ds = DispatchOrder_BLL.selectDispatchOrderDateSet(0, status, colname, coltext, Machine_Code, indexs);


        //DataSet ds = GetData();                                     //查找数据源
        DataTable dt = ds.Tables[0];

        DataView dv = new DataView(dt);
        dv.Sort = sortExpression + " " + direction;
        GridView1.DataSource = dv;                       //将DataView绑定到GridView上
        GridView1.DataBind();

        dboSetCtrls.SetGridView(ddlDispatchStateFlag, GridView1, "CheckStatus");
        dboSetCtrls.SetGridView(ddlCheckStatus, GridView1, "DispatchStatus");
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, ds.Tables[0].Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);

    }

    private void SortGridView2(string sortExpression, string direction)
    {
        string colname = "Creater";
        string coltext = this.Page.User.Identity.Name.ToString();

        string status = ddlDispatchStateFlag.SelectedValue.Trim();
        string indexs = hdnCellIndexss.Value.Trim();
        string Machine_Code = this.ddlMachine_SeatCode.SelectedValue.ToString();
        DataSet ds = DispatchOrder_BLL.selectDispatchOrderDateSet(0, status, colname, coltext, Machine_Code, indexs);


        //DataSet ds = GetData();                                     //查找数据源
        DataTable dt = ds.Tables[0];

        DataView dv = new DataView(dt);
        dv.Sort = sortExpression + " " + direction;
        GridView1.DataSource = dv;                       //将DataView绑定到GridView上
        GridView1.DataBind();

        dboSetCtrls.SetGridView(ddlDispatchStateFlag, GridView1, "CheckStatus");
        dboSetCtrls.SetGridView(ddlCheckStatus, GridView1, "DispatchStatus");
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, ds.Tables[0].Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);

    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC");
        }
        GridViewSortExpression = sortExpression;
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            string vID = txtID.Text = hdnID.Value =
               ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();
            //string vCmd = GridView1.Rows[e.NewSelectedIndex].Cells[2]   //e.CommandName.Trim();

            dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtDO_No);
            IList<DispatchOrder_MDL> tempIList = DispatchOrder_BLL.selectDispatchOrder(Int32.Parse(vID), "", "", "");
            bindDrop(tempIList[0].MouldNo, tempIList[0].ProductNo);

            int vMasterID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
            txtDO_No.Text = tempIList[0].DO_No;//派工单号
            search.Value = tempIList[0].WorkOrderNo;//生产单号
            txtProductNo.Text = tempIList[0].ProductNo;//产品编号
            txtProductDesc.Text = tempIList[0].ProductDesc;// 产品描述
            ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempIList[0].MachineNo);//机器编号
            for (int i = 0; i < ddlMouldNo.Items.Count; i++)
            {
                if (ddlMouldNo.Items[i].Text == "" || ddlMouldNo.Items[i].Text == null || ddlMouldNo.Items[i].Text == "选择")
                {
                    ddlMouldNo.Items.RemoveAt(i);
                    i = i - 1;
                }
            }
            ddlMouldNo = dboSetCtrls.SetSelectedIndex(ddlMouldNo, tempIList[0].MouldNo);//模具编号
            this.Hidden1.Value = tempIList[0].MouldNo;
            this.Hidden2.Value = tempIList[0].MachineNo;
            txtDispatchDate.Value = tempIList[0].DispatchDate;
            txtDispatchNum.Text = tempIList[0].DispatchNum;
            //090718

            txtStartDate.Value = DateTime.Parse(tempIList[0].StartDate).ToString("yyyy-MM-dd HH:mm");
            txtStopDate.Value = DateTime.Parse(tempIList[0].StopDate).ToString("yyyy-MM-dd HH:mm");
            txtRemark.Text = tempIList[0].Remark;
            txtstate.Value = tempIList[0].DispatchStatus;
            GridView2.Visible = true;
            this.search.Disabled = true;
            //Text1.Value = tempIList[0].StartDate.Substring(11, 5);//tempIList[0].StartDate.Length == 16 ? "0"+tempIList[0].StartDate.Substring(10, 4) : tempIList[0].StartDate.Substring(10, 5);
            //Text2.Value = tempIList[0].StopDate.Substring(11, 5);//tempIList[0].StopDate.Length == 17 ? "0" + tempIList[0].StopDate.Substring(10, 4) : tempIList[0].StopDate.Substring(10, 5);
            txtDO_No.Text = tempIList[0].DO_No;
            txtstate.Value = tempIList[0].DispatchStatus;
            this.ddlMouldNo.AutoPostBack = true;
            txtCheckStatus.Value = tempIList[0].CheckStatus;
            Hidden3.Value = tempIList[0].DispatchStatus;
            txtStandCycle.Text = tempIList[0].StandCycle;
            //txtGroupNum.Text = tempIList[0].GroupNum;
            //if (vCmd == "Detail")
            BindDataDetail(tempIList[0].MachineNo);
            ArrayList arraysCycle = GetMachineMstrCycle(tempIList[0].MouldNo, tempIList[0].ProductNo);
            txtStandCycleMould.Text = "";
            if (arraysCycle.Count > 0)
            {
                for (int i = 0; i < arraysCycle.Count; i++)
                {
                    txtStandCycleMould.Text = arraysCycle[i].ToString();
                }
            }
            if (tempIList[0].DispatchStatus == "3")
            {
                this.rdUrgentSingle.SelectedIndex = 1;
            }
            else if (tempIList[0].DispatchStatus == "4")
            {
                this.rdUrgentSingle.SelectedIndex = 2;
            }
            else
            {
                this.rdUrgentSingle.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
    }
    protected void ddlMouldNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ListItem item;
            string vMouldNo = txtHiddenMouldNo.Value.Trim();
            string vMachineNo = txtHiddenMachineNo.Value.Trim();
            if (vMachineNo.Trim() == "")
            {
                vMachineNo = Hidden2.Value.Trim();//机器编号
            }
            if (vMouldNo.Trim() == "")
            {
                vMouldNo = Hidden1.Value.Trim();//模具编号
            }
            if (vMachineNo.Trim() == "" || vMouldNo.Trim() == "")
            {
                return;
            }
            item = new ListItem(vMouldNo, vMouldNo);
            this.ddlMouldNo.Items.Clear();
            this.ddlMouldNo.Items.Add(new ListItem("选择", ""));
            if (!ddlMouldNo.Items.Contains(item))
            {
                ddlMouldNo.Items.Add(item);
            }

            ddlMouldNo.Items[ddlMouldNo.Items.IndexOf(item)].Selected = true;
            this.ddlMachineNo.Items.Clear();
            this.ddlMachineNo.Items.Add(new ListItem("选择", ""));
            ArrayList arrays = GetMachineMstr(item.Text, txtProductNo.Text.Trim());
            if (arrays.Count > 0)
            {
                for (int i = 0; i < arrays.Count; i++)
                {
                    this.ddlMachineNo.Items.Add(new ListItem(arrays[i].ToString(), arrays[i].ToString()));
                }
            }
            item = new ListItem(vMachineNo, vMachineNo);
            ddlMachineNo.Items[ddlMachineNo.Items.IndexOf(item)].Selected = true;

            ArrayList arraysCycle = GetMachineMstrCycle(vMouldNo, txtProductNo.Text.Trim());
            txtStandCycleMould.Text = "";
            if (arraysCycle.Count > 0)
            {
                for (int i = 0; i < arraysCycle.Count; i++)
                {
                    txtStandCycleMould.Text = arraysCycle[i].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
    }
    protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Hidden2.Value = ddlMachineNo.SelectedValue;
    }
    #region //新的根据工单号生成派工单号方法
    /// <summary>
    /// 新的根据工单号生成派工单号方法
    /// </summary>
    /// <param name="DO_No">工单号</param>
    /// <returns>派工单号</returns>
    [Ajax.AjaxMethod()]
    public string GetDO_No(string workOrderNo)
    {
        if (null != workOrderNo && "" != workOrderNo)
        {
            IList<DispatchOrder_MDL> myList = DispatchOrder_BLL.selectDispatchOrder(0, "WorkOrderNo", workOrderNo);// 获取同一工单的记录集合
            List<Int64> myList1 = new List<Int64>();
            string strDO_No = "";
            if (myList.Count > 0)
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i].DO_No.Substring(0, 1) == "A" || myList[i].DO_No.Substring(0, 1) == "B")
                    {
                        strDO_No = myList[i].DO_No.Substring(1, myList[i].DO_No.Length - 1);
                    }
                    else
                    {
                        strDO_No = myList[i].DO_No;
                    }
                    Int64 a = Convert.ToInt64(strDO_No);
                    //int a = int.Parse(myList[i].DO_No);
                    myList1.Add(a);
                }
                myList1.Sort();

            }
            if (myList1.Count > 0)
            {
                return (myList1[myList1.Count - 1] + 1).ToString();
            }
            else
            {
                return workOrderNo + "001";
            }
        }
        else
        {
            return null;
        }
    }
    #endregion


    #region  新方法查询模具
    /// <summary>
    /// 根据产品编号查询模具
    /// </summary>
    /// <param name="prodNo"></param>
    /// <returns></returns>
    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMstrByNew(string prodNo)
    {
        ArrayList items = new ArrayList();
        if (prodNo != "")
        {
            try
            {

                IList<ItemMstr_MDL> myList = ItemMstr_BLL.selectItemMstrDetail(0, "", "", "Item_Code", prodNo);
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        if (myList[i].MouldCode != "")
                        {
                            items.Add(myList[i].MouldCode);
                        }
                    }
                }
                else
                {
                    IList<SuitManage_MDL> TmpList = new SuitManage_DAL().selectSuitManageDetail(0, "", "", "PlantBristlesCode", prodNo);
                    if (TmpList.Count > 0)
                    {
                        for (int i = 0; i < TmpList.Count; i++)
                        {
                            if (TmpList[i].WireBrushMould != "")
                            {
                                items.Add(TmpList[i].WireBrushMould);
                            }
                        }
                    }
                    else
                    {
                        items.Add("");
                    }
                }

                return items;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new ArrayList();
            }
        }
        else
        {
            return items;
        }
    }
    #endregion

    #region  新方法查询产品描述
    /// <summary>
    /// 根据产品编号查询产品描述
    /// </summary>
    /// <param name="prodNo"></param>
    /// <returns></returns>
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhSetValuesByNew(string prodNo)
    {
        ArrayList items = new ArrayList();
        if (prodNo != "")
        {
            try
            {

                IList<ItemMstr_MDL> myList = ItemMstr_BLL.selectItemMstr(0, "Item_Code", prodNo);
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        if (myList[i].ProductRemark != "")
                        {
                            items.Add(myList[i].ProductRemark);
                        }
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                string temp = ex.Message.ToString();
                return new ArrayList();
            }
        }
        else
        {
            return items;
        }
    }
    #endregion

    #region 查询急单次急单方法
    /// <summary>
    /// 根据机器编号查询当前机器是否存在急单或者次急单
    /// </summary>
    /// <param name="MachineNo">工单号</param>
    /// <returns>是否存在</returns>
    public bool GetUrgentOrTimeUrgent(string MachineNo, int isBoo)
    {
        IList<DispatchOrder_MDL> myList = DispatchOrder_BLL.selectDispatchOrder(MachineNo, isBoo);// 获取机器编号查询当前机器是否存在急单或者次急单的记录集合
        if (myList.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region  新方法查询机台模数
    /// <summary>
    /// 根据产品编号查询机台模数
    /// </summary>
    /// <param name="prodNo"></param>
    /// <returns></returns>
    [Ajax.AjaxMethod()]
    public string GetGoodSocketNumByNew(string vMouldNo)
    {
        try
        {
            if (vMouldNo != "")
            {


                string strSQL = @"select isnull(GoodSocketNum,0) GoodSocketNum from MouldDetail where Mould_Code='" + vMouldNo + "'";
                DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                if (dtTmp != null)
                {
                    if (dtTmp.Rows.Count > 0)
                    {
                        return dtTmp.Rows[0]["GoodSocketNum"].ToString().Trim();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return "";
            }
        }
        catch (Exception ex)
        {
            string temp = ex.Message.ToString();
            return "";
        }
    }
    #endregion

    protected void rdUrgentSingle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string strDO_No = this.txtDO_No.Text.Trim();
            if (strDO_No.Trim() != "")
            {
                if (strDO_No.Substring(0, 1) == "A" || strDO_No.Substring(0, 1) == "B")
                {
                    strDO_No = strDO_No.Substring(1, strDO_No.Length - 1);
                }
                if (this.rdUrgentSingle.SelectedValue == "1")
                {
                    this.txtDO_No.Text = strDO_No;
                }
                if (this.rdUrgentSingle.SelectedValue == "2")
                {
                    this.txtDO_No.Text = "A" + strDO_No;
                }
                if (this.rdUrgentSingle.SelectedValue == "3")
                {
                    this.txtDO_No.Text = "B" + strDO_No;
                }
            }
            IList<DispatchOrder_MDL> mylist = DispatchOrder_BLL.existsDispatchOrder(ddlMachineNo.SelectedValue.ToString(), "MachineNo", "2");
            for (int i = 0; i < mylist.Count; i++)
            {
                if (this.rdUrgentSingle.SelectedValue.Trim() == "2")
                {
                    if (i == mylist.Count - 1)
                    {
                        this.txtStartDate.Value = DateTime.Parse(mylist[i].StartDate).AddMinutes(1).ToString("yyyy-MM-dd HH:mm");
                        if (this.txtDispatchNum.Text.Trim() != "" || this.txtStandCycle.Text.Trim() != "")
                        {
                            string strSQL = @"select isnull(GoodSocketNum,0) GoodSocketNum from MouldDetail where Mould_Code='" + this.ddlMouldNo.SelectedValue.ToString() + "'";
                            DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                            if (dtTmp != null)
                            {
                                if (dtTmp.Rows.Count > 0)
                                {
                                    double sumSeconds = Convert.ToDouble(this.txtDispatchNum.Text.Trim()) * (Convert.ToDouble(this.txtStandCycle.Text.Trim()) / Convert.ToDouble(dtTmp.Rows[0]["GoodSocketNum"].ToString().Trim()));
                                    this.txtStopDate.Value = DateTime.Parse(this.txtStartDate.Value).AddSeconds(sumSeconds).ToString("yyyy-MM-dd HH:mm");
                                }
                                else
                                {
                                    if (dtTmp.Rows.Count > 0)
                                    {
                                        double sumSeconds = Convert.ToDouble(this.txtDispatchNum.Text.Trim()) * Convert.ToDouble(this.txtStandCycle.Text.Trim());
                                        this.txtStopDate.Value = DateTime.Parse(this.txtStartDate.Value).AddSeconds(sumSeconds).ToString("yyyy-MM-dd HH:mm");
                                    }
                                }
                            }
                            else
                            {
                                double sumSeconds = Convert.ToDouble(this.txtDispatchNum.Text.Trim()) * Convert.ToDouble(this.txtStandCycle.Text.Trim());
                                this.txtStopDate.Value = DateTime.Parse(this.txtStartDate.Value).AddSeconds(sumSeconds).ToString("yyyy-MM-dd HH:mm");
                            }
                            return;
                        }
                        else
                        {
                            dboSetCtrls.SetExecMsg(this, "请输入派工数和周期,以便计算结束时间!");
                            return;
                        }
                    }
                }
                if (this.rdUrgentSingle.SelectedValue.Trim() == "3")
                {
                    if (i == mylist.Count - 2)
                    {
                        this.txtStartDate.Value = DateTime.Parse(mylist[i].StartDate).AddMinutes(1).ToString("yyyy-MM-dd HH:mm");
                        if (this.txtDispatchNum.Text.Trim() != "" || this.txtStandCycle.Text.Trim() != "")
                        {
                            string strSQL = @"select isnull(GoodSocketNum,0) GoodSocketNum from MouldDetail where Mould_Code='" + this.ddlMouldNo.SelectedValue.ToString() + "'";
                            DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
                            if (dtTmp != null)
                            {
                                if (dtTmp.Rows.Count > 0)
                                {
                                    double sumSeconds = Convert.ToDouble(this.txtDispatchNum.Text.Trim()) * (Convert.ToDouble(this.txtStandCycle.Text.Trim()) / Convert.ToDouble(dtTmp.Rows[0]["GoodSocketNum"].ToString().Trim()));
                                    this.txtStopDate.Value = DateTime.Parse(this.txtStartDate.Value).AddSeconds(sumSeconds).ToString("yyyy-MM-dd HH:mm");
                                }
                                else
                                {
                                    if (dtTmp.Rows.Count > 0)
                                    {
                                        double sumSeconds = Convert.ToDouble(this.txtDispatchNum.Text.Trim()) * Convert.ToDouble(this.txtStandCycle.Text.Trim());
                                        this.txtStopDate.Value = DateTime.Parse(this.txtStartDate.Value).AddSeconds(sumSeconds).ToString("yyyy-MM-dd HH:mm");
                                    }
                                }
                            }
                            else
                            {
                                double sumSeconds = Convert.ToDouble(this.txtDispatchNum.Text.Trim()) * Convert.ToDouble(this.txtStandCycle.Text.Trim());
                                this.txtStopDate.Value = DateTime.Parse(this.txtStartDate.Value).AddSeconds(sumSeconds).ToString("yyyy-MM-dd HH:mm");
                            }
                            return;
                        }
                        else
                        {
                            dboSetCtrls.SetExecMsg(this, "请输入派工数和周期,以便计算结束时间!");
                            return;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
    }
}