﻿using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Admin.Model.Monitor_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.BLL.Monitor_BLL;
using Admin.BLL.Product_BLL;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.App_Code;
using Admin.SQLServerDAL.RightCtrl;

public partial class Monitor_PlantBristlesMachineInfo : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    string[,] tabMachineNo = null;
    string[,] tabLiveCycle = null;
    string[,] tabBeginCycle = null;
    string[,] tabColor = null;
    string[,] tabProductedQty = null;
    const int Width = 135;

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MonitorMachineMstr");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!Page.IsPostBack)
        {
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().getDataListOfWorkPaper() as IList, true, "MachineType", "MachineCode");
            //SetSession();
            BindData();
           // this.Label2.Text = System.DateTime.Now.ToString("yyyy-mm-dd") ;
            Session["onitor_PlantBristlesMachineInfoTime"] = System.DateTime.Now;
            string timerTxt = ConfigurationManager.AppSettings["PlantBristlesMachineInfo_Refresh"].ToString();
            this.Timer1.Interval = int.Parse(timerTxt);
        }
    }

    private void BindData()
    {

        IList<MonitorMachine_MDL> tempList = null;
        if (Session["PlantBristlesMachineInfo"] != null && Session["PlantBristlesMachineInfoSate"] != null)
        {
            tempList = MonitorMachine_BLL.selectMonitorPlantBristlesToolInfo(Session["PlantBristlesMachineInfo"].ToString().Trim(), Session["PlantBristlesMachineInfoSate"].ToString().Trim());
            ddlMachine_SeatCode.SelectedValue = Session["PlantBristlesMachineInfo"].ToString().Trim();
            ddlMachineSate.SelectedValue = Session["PlantBristlesMachineInfoSate"].ToString().Trim();
        }
        else
            tempList = MonitorMachine_BLL.selectMonitorPlantBristlesToolInfo(ddlMachine_SeatCode.SelectedValue.Trim(), ddlMachineSate.SelectedValue.Trim());

        int k = tempList.Count;//总个数（机器总数）
        int n = 12;//每行显示个数
        int m = (k + n - 1) / n;//行数
        Session["PlantBristlesMachineInfoCount"] = tempList.Count;
        int rowsIndex = 0;
        tabMachineNo = new string[n, m];
        tabLiveCycle = new string[n, m];
        tabBeginCycle = new string[n, m];
        tabColor = new string[n, m];
        tabProductedQty = new string[n, m];
        int intGreen = 0, intRed = 0, intYellow = 0, intBlack = 0, intFuchsia=0;

        string MachineNo;
        string DeviceStatus;
        string DispatchNo;
        string LiveCycle;
        string GoodQty;
        string ClinetIP;
        string BeginCycle;
        string ShowText = "";

        HtmlInputHidden hdnID;
        //Table TB = new Table();
        //form1.Controls.Add(TB);

        Table1.Controls.Clear();
        for (int i = 0; i < m; i++)
        {
            TableRow TRows = new TableRow();
            TRows.ID = "dr" + i.ToString();
           // TB.Controls.Add(TRows);
            Table1.Controls.Add(TRows);
            for (int j = 0; j < n ; j++)
            {
                if ((i * n + j < k))
                {
                    TableCell Tcell = new TableCell();
                    Tcell.ID = "TD" + i.ToString() + j.ToString();
                    hdnID = new HtmlInputHidden();
                    Tcell.Width = Width;
                    rowsIndex = i * n + j;

                    MachineNo = tempList[rowsIndex].MachineNo;//机器编号
                    DeviceStatus = tempList[rowsIndex].DeviceStatus;//机器状态

                    DispatchNo = tempList[rowsIndex].DispatchNo;

                    LiveCycle = tempList[rowsIndex].LiveCycle;//生产周期
                    GoodQty = tempList[rowsIndex].GoodQty;//良品
                    ClinetIP = tempList[rowsIndex].ClientIP;
                    BeginCycle = tempList[rowsIndex].BeginCycle;

                    //ShowText = string.Format("{0} <br> {2} <br> {3} <br> {4} <br> {5} <br> {6}", MachineNo, DeviceStatus, StandardCycle, LiveCycle, ProductedQty, GoodQty, BadQty);
                    ShowText = string.Format("{0}<br>{1}<br>{2}", MachineNo, LiveCycle, GoodQty);
                    Tcell.Text = ShowText;

                    string Color = string.Empty;
                    if (DeviceStatus == "Green")// 为正常生产
                    {

                        Tcell.BackColor = System.Drawing.Color.Green;
                        Tcell.ForeColor = System.Drawing.Color.White;
                        Color = "Green";
                        intGreen += 1;
                    }

                    if (DeviceStatus == "Black")//未排产 
                    {
                        Tcell.BackColor = System.Drawing.Color.Black;
                        Tcell.ForeColor = System.Drawing.Color.White;
                        Color = "Black";
                        intBlack += 1;
                    }
                    if (DeviceStatus == "Red") //停机状态
                    {
                        Tcell.BackColor = System.Drawing.Color.Red;
                        Color = "Red";
                        intRed += 1;
                    }
                    if (DeviceStatus == "Fuchsia") //未派单在生产的机器
                    {
                        Tcell.BackColor = System.Drawing.Color.Fuchsia;
                        Color = "Fuchsia";
                        intFuchsia += 1;
                    }
                    Tcell.Attributes.Add("ondblclick", @"window.open('MonitorMachineDtil.aspx?flages=2&DispatchNo=" + DispatchNo + "&ClientIP=" + ClinetIP + " &MachineNo=" + MachineNo + "','_newwindow', 'status=no,scrollbars=yes,resizable=no,width=380,height=385,left=270,top=100')");
                    TRows.Controls.Add(Tcell);
                    tabMachineNo[j, i] = tempList[rowsIndex].MachineNo;
                    tabLiveCycle[j, i] = tempList[rowsIndex].LiveCycle;
                    tabBeginCycle[j, i] = tempList[rowsIndex].BeginCycle;// System.DateTime.Now.ToString();
                    tabColor[j, i] = Color;
                    tabProductedQty[j, i] = GoodQty;
                }
                else
                {
                    TableCell TcellWhite = new TableCell();
                    TcellWhite.ID = "TD" + i.ToString() + j.ToString();

                    TcellWhite.Width = Width;
                    TcellWhite.BackColor = System.Drawing.Color.White;
                    TcellWhite.ForeColor = System.Drawing.Color.White;
                    TRows.Controls.Add(TcellWhite);
                }
            }
        }
        TableRow TRowss = new TableRow();
        TableCell Tcells = new TableCell();

        Session["tabPlantBristlesMachineNo"] = tabMachineNo;
        Session["tabPlantBristlesMachineInfoLiveCycle"] = tabLiveCycle;
        Session["tabPlantBristlesMachineInfoBeginCycle"] = tabBeginCycle;
        Session["tabPlantBristlesMachineInfoColor"] = tabColor;
        Session["tabPlantBristlesMachineInfoProductedQty"] = tabProductedQty;

       // pnlShow.Controls.Add(TB);
        double perGreen = (k == 0) ? 0 : ((intGreen * 1000) / k) * 0.1;
        double perRed = (k == 0) ? 0 : ((intRed * 1000) / k) * 0.1;
        double perYellow = (k == 0) ? 0 : ((intYellow * 1000) / k) * 0.1;
        double perFuchsia = (k == 0) ? 0 : ((intFuchsia * 1000) / k) * 0.1;
        double perBlack = (k == 0) ? 0 : (100 - (perGreen + perRed + perYellow + intFuchsia));

        lblShow.Text = "总共机器 <font color='red'> " + k.ToString().Trim() + "</font> 台;&nbsp;&nbsp;";
        lblGreen.Text = "正常生产 <font color='red'>" + intGreen + "</font> 台[占:" + perGreen + "%];&nbsp;&nbsp;";
        //lblYellow.Text = "异常生产 <font color='red'>" + intYellow + "</font> 台[占:" + perYellow + "%];&nbsp;&nbsp;";
        lblFuchsia.Text = "未派工在生产 <font color='red'>" + intFuchsia + "</font> 台[占:" + perFuchsia + "%];&nbsp;&nbsp;";
        lblRed.Text = "停机 <font color='red'>" + intRed + "</font> 台[占:" + perRed + "%];&nbsp;&nbsp;";
        lblBlack.Text = "未开机 <font color='red'>" + intBlack + "</font> 台[占:" + perBlack + "%];&nbsp;&nbsp;";
    }

    protected void DorpDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetSession();
    }

    protected void igbSured_Click(object sender, ImageClickEventArgs e)
    {
        SetSession();
    }

    private void SetSession()
    {
        Session["PlantBristlesMachineInfo"] = ddlMachine_SeatCode.SelectedValue.Trim();
        Session["PlantBristlesMachineInfoSate"] = ddlMachineSate.SelectedValue.Trim();
        BindData();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {

        Session["PlantBristlesMachineInfo"] = ddlMachine_SeatCode.SelectedValue.Trim();
        Session["PlantBristlesMachineInfoSate"] = ddlMachineSate.SelectedValue.Trim();
        int RefreshTxt = int.Parse(ConfigurationManager.AppSettings["PlantBristlesMachineInfo_config"].ToString());

        IList<MonitorMachine_MDL> tempList = null;
        tempList = MonitorMachine_BLL.selectMonitorPlantBristlesToolInfo(ddlMachine_SeatCode.SelectedValue.Trim(), ddlMachineSate.SelectedValue.Trim());

        int k = tempList.Count;//总个数（机器总数）
        int n = 12;//每行显示个数
        int m = (k + n - 1) / n;//行数
        Session["PlantBristlesMachineInfoCount"] = tempList.Count;
        int rowsIndex = 0;
        int intGreen = 0, intRed = 0, intYellow = 0, intBlack = 0, intFuchsia = 0;
        string[,] tabMachineNox = Session["tabPlantBristlesMachineNo"] as string[,];
        string[,] tabLiveCyclex = Session["tabPlantBristlesMachineInfoLiveCycle"] as string[,];
        string[,] tabBeginCyclex = Session["tabPlantBristlesMachineInfoBeginCycle"] as string[,];
        string[,] tabColorx = Session["tabPlantBristlesMachineInfoColor"] as string[,];
        string[,] ProductedQtyx = Session["tabPlantBristlesMachineInfoProductedQty"] as string[,];

        string MachineNo;
        string DeviceStatus;
        string DispatchNo;
        string LiveCycle;
        string GoodQty;
        string ClinetIP;
        string BeginCycle;
        string ShowText = "";

        HtmlInputHidden hdnID;
        // Table TB = new Table();
        //form1.Controls.Add(TB);
        Table1.Controls.Clear();
        for (int i = 0; i < m; i++)
        {
            //TableRow TRows = new TableRow();
            TableRow TRows = new TableRow();
            TRows.ID = "dr" + i.ToString();
            Table1.Controls.Add(TRows);
            for (int j = 0; j < n ; j++)
            {
                if ((i * n + j < k))
                {
                    string odlTime = tabBeginCyclex[j, i].ToString();
                    string LiveCyclex = tabLiveCyclex[j, i].ToString();
                    string MachineNox = tabMachineNox[j, i].ToString();
                    string newTime = DateTime.Parse(odlTime).AddSeconds(double.Parse(LiveCyclex)).ToString(); //保存的时间加上周期
                    string newBeginCycle = DateTime.Parse(odlTime).AddSeconds(double.Parse(LiveCyclex) * RefreshTxt).ToString();  //保存的时间+（周期*几模）
                    string datetimes = System.DateTime.Now.ToString();


                    TableCell Tcell = new TableCell();
                    Tcell.ID = "TD" + i.ToString() + j.ToString();
                    hdnID = new HtmlInputHidden();
                    Tcell.Width = Width;
                    rowsIndex = i * n + j;
                    //ID = tempList[rowsIndex].ID.ToString().Trim();
                    //hdnID.Value = (string.IsNullOrEmpty(ID)) ? "0" : ID;

                    MachineNo = tempList[rowsIndex].MachineNo;//机器编号
                    DeviceStatus = tempList[rowsIndex].DeviceStatus;//机器状态

                    DispatchNo = tempList[rowsIndex].DispatchNo;

                    LiveCycle = tempList[rowsIndex].LiveCycle;//生产周期
                    GoodQty = tempList[rowsIndex].GoodQty;//良品
                    ClinetIP = tempList[rowsIndex].ClientIP;
                    BeginCycle = tempList[rowsIndex].BeginCycle;
                    //WorkerName = tempList[rowsIndex].WorkerName;

                    //ShowText = string.Format("{0} <br> {2} <br> {3} <br> {4} <br> {5} <br> {6}", MachineNo, DeviceStatus, StandardCycle, LiveCycle, ProductedQty, GoodQty, BadQty);


                    string Color = string.Empty;

                    //if (DateTime.Parse(newTime) <= DateTime.Parse(datetimes))
                    //{
                    if (DateTime.Parse(BeginCycle) != DateTime.Parse("1900-01-01 00:00:00.000"))//这里判断时间是否为空(停机,未派单时为空)  不等于空的情况
                    {
                        if (DateTime.Parse(newBeginCycle) <= DateTime.Parse(datetimes))  //当前系统时间大于等于 上一次保存的时间+（周期*几模） 则按照实际查询的结果显示
                        {
                            if (DeviceStatus == "Green")//在正常生产状态
                            {
                                Tcell.BackColor = System.Drawing.Color.Green;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Green";
                                intGreen += 1;
                            }
                            if (DeviceStatus == "Black")//未排产 
                            {
                                Tcell.BackColor = System.Drawing.Color.Black;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Black";
                                intBlack += 1;
                            }
                            if (DeviceStatus == "Red") //停机状态
                            {
                                Tcell.BackColor = System.Drawing.Color.Red;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Red";
                                intRed += 1;
                            }
                            if (DeviceStatus == "Fuchsia") //未派单在生产的机器
                            {
                                Tcell.BackColor = System.Drawing.Color.Fuchsia;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Fuchsia";
                                intFuchsia += 1;
                            }
                            ShowText = string.Format("{0}<br>{1}<br>{2}", MachineNo, LiveCycle, GoodQty);
                        }
                        if (DateTime.Parse(newBeginCycle) > DateTime.Parse(datetimes))//当前系统时间大于等于 上一次保存的时间+（周期*几模） 则按照上一次的状态显示
                        {
                            string oldColor = tabColorx[j, i].ToString();
                            if (oldColor == "Green")//未排产 
                            {
                                Tcell.BackColor = System.Drawing.Color.Green;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Green";
                                intGreen += 1;
                            }
                            if (oldColor == "Black")//未排产 
                            {
                                Tcell.BackColor = System.Drawing.Color.Black;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Black";
                                intBlack += 1;
                            }
                            if (oldColor == "Red") //停机状态
                            {
                                Tcell.BackColor = System.Drawing.Color.Red;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Red";
                                intRed += 1;
                            }
                            if (oldColor == "Fuchsia") //未派单在生产的机器
                            {
                                Tcell.BackColor = System.Drawing.Color.Fuchsia;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Fuchsia";
                                intFuchsia += 1;
                            }
                            ShowText = string.Format("{0}<br>{1}<br>{2}", MachineNox, LiveCyclex, ProductedQtyx[j, i].ToString());
                        }

                    }
                    else //这里判断实际开始时间是否为空(停机,未派单时为空)  等于空的情况
                    {

                        if (DateTime.Parse(newBeginCycle) >= DateTime.Parse(datetimes))//当前系统时间大于 上一次保存的时间+（周期*几模） 则按照上一次的状态显示
                        {
                            string oldColor = tabColorx[j, i].ToString();
                            if (oldColor == "Green")//未排产 
                            {
                                Tcell.BackColor = System.Drawing.Color.Green;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Green";
                                intGreen += 1;
                            }
                            if (oldColor == "Black")//未排产 
                            {
                                Tcell.BackColor = System.Drawing.Color.Black;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Black";
                                intBlack += 1;
                            }
                            if (oldColor == "Red") //停机状态
                            {
                                Tcell.BackColor = System.Drawing.Color.Red;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Red";
                                intRed += 1;
                            }
                            if (oldColor == "Fuchsia") //未派单在生产的机器
                            {
                                Tcell.BackColor = System.Drawing.Color.Fuchsia;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Fuchsia";
                                intFuchsia += 1;
                            }
                            ShowText = string.Format("{0}<br>{1}<br>{2}", MachineNox, LiveCyclex, ProductedQtyx[j, i].ToString());
                        }
                        else
                        {
                            string oldColor = tabColorx[j, i].ToString();
                            if (oldColor == "Green")// 
                            {
                                Tcell.BackColor = System.Drawing.Color.Red;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Red";
                                intRed += 1;
                            }
                            if (oldColor == "Black")//未排产 
                            {
                                Tcell.BackColor = System.Drawing.Color.Black;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Black";
                                intBlack += 1;
                            }
                            if (oldColor == "Red") //停机状态
                            {
                                Tcell.BackColor = System.Drawing.Color.Red;
                                Tcell.ForeColor = System.Drawing.Color.Black;
                                Color = "Red";
                                intRed += 1;
                            }
                            if (oldColor == "Fuchsia") //未派单在生产的机器
                            {
                                Tcell.BackColor = System.Drawing.Color.Black;
                                Tcell.ForeColor = System.Drawing.Color.White;
                                Color = "Black";
                                intBlack += 1;
                            }
                            ShowText = string.Format("{0}<br>{1}<br>{2}", MachineNox, "0.00", "0");
                        }
                    }
                    if (DateTime.Parse(newBeginCycle) >= DateTime.Parse(datetimes))//当前系统时间小于 上一次保存的时间+（周期*几模） 则重新保存一下记录
                    {
                        tabMachineNox[j, i] = MachineNo;
                        tabLiveCyclex[j, i] = LiveCycle;
                        tabBeginCyclex[j, i] = BeginCycle;
                        tabColorx[j, i] = Color;
                        ProductedQtyx[j, i] = GoodQty;
                    }
                    Tcell.Attributes.Add("ondblclick",
                   @"window.open('MonitorMachineDtil.aspx?flages=2&DispatchNo=" + DispatchNo + "&ClientIP=" + ClinetIP + " &MachineNo=" + MachineNo +
                   "','_newwindow', 'status=no,scrollbars=yes,resizable=no,width=380,height=385,left=270,top=100')");
                    Tcell.Text = ShowText;

                    TRows.Controls.Add(Tcell);
                }
                else
                {
                    TableCell TcellWhite = new TableCell();
                    TcellWhite.ID = "TD" + i.ToString() + j.ToString();

                    TcellWhite.Width = Width;
                    TcellWhite.BackColor = System.Drawing.Color.White;
                    TcellWhite.ForeColor = System.Drawing.Color.White;
                    TRows.Controls.Add(TcellWhite);
                }
            }
        }
        TableRow TRowss = new TableRow();
        TableCell Tcells = new TableCell();
        //pnlShow.Controls.Clear();
        //pnlShow.Controls.Add(TB);

        Session["tabPlantBristlesMachineNo"] = tabMachineNox;
        Session["tabPlantBristlesMachineInfoLiveCycle"] = tabLiveCyclex;
        Session["tabPlantBristlesMachineInfoBeginCycle"] = tabBeginCyclex;
        Session["tabPlantBristlesMachineInfoColor"] = tabColorx;
        Session["tabPlantBristlesMachineInfoProductedQty"] = ProductedQtyx;


        double perGreen = (k == 0) ? 0 : ((intGreen * 1000) / k) * 0.1;
        double perRed = (k == 0) ? 0 : ((intRed * 1000) / k) * 0.1;
        double perYellow = (k == 0) ? 0 : ((intYellow * 1000) / k) * 0.1;
        double perFuchsia = (k == 0) ? 0 : ((intFuchsia * 1000) / k) * 0.1;
        double perBlack = (k == 0) ? 0 : (100 - (perGreen + perRed + perYellow + intFuchsia));

        lblShow.Text = "总共机器 <font color='red'> " + k.ToString().Trim() + "</font> 台;&nbsp;&nbsp;";
        lblGreen.Text = "正常生产 <font color='red'>" + intGreen + "</font> 台[占:" + perGreen + "%];&nbsp;&nbsp;";
        //lblYellow.Text = "异常生产 <font color='red'>" + intYellow + "</font> 台[占:" + perYellow + "%];&nbsp;&nbsp;";
        lblFuchsia.Text = "未派工在生产 <font color='red'>" + intFuchsia + "</font> 台[占:" + perFuchsia + "%];&nbsp;&nbsp;";
        lblRed.Text = "停机 <font color='red'>" + intRed + "</font> 台[占:" + perRed + "%];&nbsp;&nbsp;";
        lblBlack.Text = "未开机 <font color='red'>" + intBlack + "</font> 台[占:" + perBlack + "%];&nbsp;&nbsp;";


    }
    
}
