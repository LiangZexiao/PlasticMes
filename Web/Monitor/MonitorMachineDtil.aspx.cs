using System;
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
using Admin.App_Code;
using Admin.SQLServerDAL.RightCtrl;

public partial class Monitor_MonitorMachineDtil : System.Web.UI.Page
{
    string[] MachineSatusName = new string[] { "", "换模",
"换料","换单","辅设故障","机器故障","模具故障","待料","无订单","其它"};

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string flages = Request.QueryString["flages"].ToString();
            if (flages == "1")
            {
                bindMachineMstr();
                bindNxtInjectionDO();
                this.MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                this.MultiView1.ActiveViewIndex = 1;
                bindPlantBristlesMachineInfo();
            }
        }
    }
    void bindMachineMstr()
    {
        string DispatchOrder = Request.QueryString["DispatchNo"].ToString();
        string ClientIP = Request.QueryString["ClientIP"].ToString();
        string MachineNo = Request.QueryString["MachineNo"].ToString();
        this.lblIp.Text = ClientIP;
       // IList<MonitorMachine_MDL> tempList = MonitorMachine_BLL.selectMonitorMachine(DispatchOrder, ClientIP);
       // lblDeviceStatus.Text =tempList.Count>0 ? tempList[0].DeviceStatusName : "";
        DataSet ds = MonitorMachine_BLL.selectMonitorMachine(DispatchOrder);
        lblMachineNo.Text = MachineNo;
        if (DispatchOrder != "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMouldNo.Text = ds.Tables[0].Rows[0]["MouldNo"].ToString();
                lblGoodSocketNum.Text = ds.Tables[0].Rows[0]["GoodSocketNum"].ToString();
                lblWO_No.Text = ds.Tables[0].Rows[0]["WorkOrderNo"].ToString();
                lblDO_No.Text = ds.Tables[0].Rows[0]["do_no"].ToString();
                lblMaterialName.Text = ds.Tables[0].Rows[0]["MaterialCode"].ToString();
                lblProductNo.Text = ds.Tables[0].Rows[0]["productNo"].ToString();
                lblProductName.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                lblItem_WaterGapScale.Text = ds.Tables[0].Rows[0]["Item_WaterGapScale"].ToString();
                lblStandCycle.Text = ds.Tables[0].Rows[0]["StandardCycle"].ToString();
                lblBeginTime.Text = ds.Tables[0].Rows[0]["LiveCycle"].ToString();
                lblDispatchNum.Text = ds.Tables[0].Rows[0]["DispatchNum"].ToString();
                lblProducted.Text = ds.Tables[0].Rows[0]["productNum"].ToString();
                lblBadQty.Text = ds.Tables[0].Rows[0]["badnum"].ToString();
            }
        }
    }

    void bindPlantBristlesMachineInfo()
    {
        string DispatchOrder = Request.QueryString["DispatchNo"].ToString();
        string ClientIP = Request.QueryString["ClientIP"].ToString();
        string MachineNo = Request.QueryString["MachineNo"].ToString();
        this.Label4.Text = ClientIP;
        // IList<MonitorMachine_MDL> tempList = MonitorMachine_BLL.selectMonitorMachine(DispatchOrder, ClientIP);
        // lblDeviceStatus.Text =tempList.Count>0 ? tempList[0].DeviceStatusName : "";
        DataSet ds =  MonitorMachine_BLL.selectMonitorPlantBristlesToolInfo(DispatchOrder);
        Label1.Text = MachineNo;
        if (DispatchOrder != "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label3.Text = ds.Tables[0].Rows[0]["MouldNo"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["WorkOrderNo"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["do_no"].ToString();
                Label8.Text = ds.Tables[0].Rows[0]["productNo"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                Label14.Text = ds.Tables[0].Rows[0]["DispatchNum"].ToString();
                Label15.Text = ds.Tables[0].Rows[0]["productNum"].ToString();
                Label17.Text = ds.Tables[0].Rows[0]["badnum"].ToString();
            }
        }
    }
    void bindNxtInjectionDO()
    {
        string DispatchOrder = Request.QueryString["DispatchNo"].ToString();
        string ClientIP = Request.QueryString["ClientIP"].ToString();
        string MachineNo = Request.QueryString["MachineNo"].ToString();
        // IList<MonitorMachine_MDL> tempList = MonitorMachine_BLL.selectMonitorMachine(DispatchOrder, ClientIP);
        // lblDeviceStatus.Text =tempList.Count>0 ? tempList[0].DeviceStatusName : "";
        DataSet ds = MonitorMachine_BLL.selectNxtInjectionDO(MachineNo);
        if (DispatchOrder != "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMouldNo1.Text = ds.Tables[0].Rows[0]["MouldNo"].ToString();
                lblGoodSocketNum1.Text = ds.Tables[0].Rows[0]["GoodSocketNum"].ToString();
                lblWO_No1.Text = ds.Tables[0].Rows[0]["WorkOrderNo"].ToString();
                lblDO_No1.Text = ds.Tables[0].Rows[0]["do_no"].ToString();
                lblMaterialName1.Text = ds.Tables[0].Rows[0]["MaterialCode"].ToString();
                lblProductNo1.Text = ds.Tables[0].Rows[0]["productNo"].ToString();
                lblProductName1.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                lblItem_WaterGapScale1.Text = ds.Tables[0].Rows[0]["Item_WaterGapScale"].ToString();
                lblStandCycle1.Text = ds.Tables[0].Rows[0]["StandardCycle"].ToString();
                lblBeginTime1.Text = ds.Tables[0].Rows[0]["LiveCycle"].ToString();
                lblDispatchNum1.Text = ds.Tables[0].Rows[0]["DispatchNum"].ToString();
                lblProducted1.Text = ds.Tables[0].Rows[0]["productNum"].ToString();
                lblBadQty1.Text = ds.Tables[0].Rows[0]["badnum"].ToString();
            }
        }
    }
}
