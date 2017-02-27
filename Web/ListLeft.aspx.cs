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
using Admin.Model.Adminis_MDL;
using Admin.BLL.Adminis_BLL;
using Admin.App_Code;

public partial class ListLeft : System.Web.UI.Page
{
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        dboSetCtrls.GetIdentiryInfo(this);
        try
        {
            //加载自定义报表的路径。
            Choose_CrystalReport.HRef = ConfigurationManager.AppSettings["CrystalReportHref"];
            InitTreeLeft();
        }
        catch (Exception ex)
        {
            string sTemp = ex.ToString().Trim();
        }

        //lblUser.Text = "登入者:" + Session["Name"].ToString().Trim();

    }

    private void InitTreeLeft()
    {
        HtmlTableRow[] tr = { trMonitor, trTechnics, trQuality, trProduct, trReport, trStorage, trCollect, trMaintain, trOrder, trBaseinfo, trSysmould, trManHour };
        HtmlTableRow[] mu = { muMonitor, muTechnics, muQuality, muProduct, muReport, muStorage, muCollect, muMaintain, muOrdermstr, muBaseinfo, muSysmould, muManHour };

        HtmlAnchor[] hf_monitor = { MonitorMachineMstr, MonitorMaterial,   MonitorAlert, MonitorDispatchMstr };//0
        HtmlTableRow[] tr_monitor = { trMonitorMachineMstr, trMonitorMaterial,   trMonitorAlert, trMonitorDispatchMstr };

        HtmlAnchor[] hf_collect = { ErrDataInfo, ShowData, ICcard, CardDetail};//1
        HtmlTableRow[] tr_collect = { trErrDataInfo, trShowData, trICcard, trCardDetail};

        HtmlAnchor[] hf_maintain = { MaintainPlan, MaintainInfo, MaintainReport };//2
        HtmlTableRow[] tr_maintain = { trMaintainPlan, trMaintainInfo, trMaintainReport };

        HtmlAnchor[] hf_ordermstr = { CommunicationInfo, CallConfig, SalaryConfig, MachineVacation };//3
        HtmlTableRow[] tr_ordermstr = { trCommunicationInfo, trCallConfig, trSalaryConfig, trMachineVacation };

        HtmlAnchor[] hf_product = { DispatchOrder, UpdateCycle, AdjustMachine};//4WorkOrder, MPSResult,trWorkOrder, trMPSResult,
        HtmlTableRow[] tr_product = { trDispatchOrder, trUpdateCycle, trAdjustMachine };

        HtmlAnchor[] hf_technics = {  QualityTrack, chief_bom };//5StandTechnicsParams,trStandTechnicsParams,
        HtmlTableRow[] tr_technics = {  trQualityTrack, trchief_bom };

        HtmlAnchor[] hf_quality = { QC_Table,  OEE };//5QualityReport,trQualityReport,
        HtmlTableRow[] tr_quality = { trQC_Table,  trOEE };

        HtmlAnchor[] hf_storage = {  };//6INStorage, ReceiveMaterial, ExtendMaterial trINStorage, trReceiveMaterial, trExtendMaterial 
        HtmlTableRow[] tr_storage = { };

        HtmlAnchor[] hf_report = { MoldCycleDetail, OEEReport, SMSDetail, QueryQCCard, StopMachineReason, WorkShopMaterial, ProductForDay, Performance, WorkOrderComplete, QualityForDay, MouldProdNumTime, InjectCondition, RptCardDisHistory, RptDispatchHistory };//7Choose_CrystalReport
        HtmlTableRow[] tr_report = { trMoldCycleDetail, trOEEReport, trSMSDetail, trQueryQCCard, trStopMachineReason, trWorkShopMaterial, trProductForDay, trPerformance, trWorkOrderComplete, trQualityForDay, trMouldProdNumTime, trInjectCondition, trRptCardDisHistory, trRptDispatchHistory };//trChoose_CrystalReport

        HtmlAnchor[] hf_baseinfo = { ItemMstr, MouldMstr, SuitManage, ClampManage, MachineMstr, MachineSuit, AuxiliaryToolInfo, Employee };//8trCustomerInfo,CustomerInfo,Department
        HtmlTableRow[] tr_baseinfo = { trItemMstr, trMouldMstr, trSuitManage, trClampManage, trMachineMstr, trMachineSuit,  trAuxiliaryToolInfo,  trEmployee  };//trDepartment

        HtmlAnchor[] hf_sysmould = { UserInfo, GroupInfo,  UserProgramMap, MdyPassword, GroupProgramMap};//9
        HtmlTableRow[] tr_sysmould = { trUserInfo, trGroupInfo,  trUserProgramMap, trMdyPassword, trGroupProgramMap };

        HtmlAnchor[] hf_ManHour = {  SalaryManage };//9trStaffPrice,StaffPrice,
        HtmlTableRow[] tr_ManHour = {  trSalaryManage };

        object[] main = { hf_monitor, hf_technics, hf_quality, hf_product, hf_report, hf_storage, hf_collect, hf_maintain, hf_ordermstr, hf_baseinfo, hf_sysmould, hf_ManHour };
        object[] subs = { tr_monitor, tr_technics, tr_quality, tr_product, tr_report, tr_storage, tr_collect, tr_maintain, tr_ordermstr, tr_baseinfo, tr_sysmould, tr_ManHour };

        string userid = (this.Page.User.Identity.IsAuthenticated) ? this.Page.User.Identity.Name.Trim() : string.Empty;
        for (int a = 0; a < main.Length; a++)
        {
            tr[a].Visible = false;
            mu[a].Visible = false;
            //if (a == 8)
            //{
            //    Response.Write("hello");
            //}
            string yysa = tr[a].ToString();
            string ffddrs = mu[a].ToString();
            for (int b = 0; b < (main[a] as HtmlAnchor[]).Length; b++)
            {
                string ttf = subs[a].ToString();
                string fffs = (subs[a] as HtmlTableRow[])[b].ToString();
                //if (b == 3)
                //{
                //    Response.Write("hello");
                //}
                (subs[a] as HtmlTableRow[])[b].Visible = false;
                foreach (SysClassInfo_MDL sysclassinfo in SysClassInfo_BLL.selectSysClassInfo(userid))
                {
                    foreach (ProgramInfo_MDL programinfo in SysProgramInfo_BLL.selectProgramInfo(userid, sysclassinfo.ClassID))
                    {
                        if (a == 6)
                        {
                            string s = (main[a] as HtmlAnchor[])[b].HRef.Trim();
                           // Response.Write(s);
                        }
                        string hrefs1 = (main[a] as HtmlAnchor[])[b].HRef.Trim();
                        string hrefs2 = programinfo.RequestURL.Trim();
                        if (hrefs1 == hrefs2)
                        {
                            string srs = subs[a].ToString();
                            string srs2 = (subs[a] as HtmlTableRow[])[b].ToString();
                            (subs[a] as HtmlTableRow[])[b].Visible = true;
                            tr[a].Visible = true;
                            mu[a].Visible = true;
                            //continue;//break;
                        }
                    }
                }
               // Response.Write("<br/>b"+b.ToString());
            }
           // Response.Write("第二个出来后直接出来了!!!");
        }
    }
}
