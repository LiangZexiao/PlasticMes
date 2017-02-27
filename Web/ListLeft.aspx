<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListLeft.aspx.cs" Inherits="ListLeft" %>

<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>注塑MES系统管理平台</title>
    <link href="images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="JS/menu.js"></script>

    <script type="text/javascript" language="javascript">
        function on(o) {
            o.runtimeStyle.color = "#000000";
            o.runtimeStyle.backgroundColor = "#72C2FF";
        }
        function off(o) {
            o.runtimeStyle.color = "";
            o.runtimeStyle.backgroundColor = "";
        }
        function ExitSys() {
            if (!window.confirm("你要退出系统吗?")) {
                return event.returnValue = false;
            }
            else
                window.top.location = "login.aspx";
        } 
    </script>

</head>
<body class="doc" style="overflow-x: hidden; overflow-y: auto; scrollbar-base-color: white">
    <%--lavender;">--%>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" border="0" style="border-right-color: White"
        id="tblOuter" width="100%">
        <tr>
            <td align="center">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr id="trMonitor" runat="server" class="toplinebg">
                        <td width="30%" class="font_boldblue" align="right" style="height: 10px; width: 30%;
                            cursor: hand;" onclick='menu("monitor",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgMonitor" runat="server" ImageUrl="images/icon_systemMant.gif" />
                        </td>
                        <td class="font_boldblue" style="cursor: hand; height: 10px;" onclick='menu("monitor",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            生产监视
                        </td>
                    </tr>
                    <tr id="muMonitor" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblMonitorList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse;"
                                class="table_aa">
                                <a runat="server" id="MonitorMachineMstr" href="Monitor/MonitorMachineMstr.aspx"
                                    target="main">
                                    <tr id="trMonitorMachineMstr" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td width="30%" align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            机器监视
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MonitorMaterial" href="Monitor/MonitorMaterial.aspx" target="main">
                                    <tr id="trMonitorMaterial" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            物料监视
                                        </td>
                                    </tr>
                                </a>
                                <%--<a runat="server" id="MonitorOrderMstr" href="Monitor/MonitorOrderMstr.aspx" target="main">
																<tr id="trMonitorOrderMstr" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">生产单监视</td>
																</tr>
																</a>--%>
                                <a runat="server" id="MonitorDispatchMstr" href="Monitor/MonitorDispatchMstr.aspx"
                                    target="main">
                                    <tr id="trMonitorDispatchMstr" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image56" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            派工单监视
                                        </td>
                                    </tr>
                                </a>
                                <%--	<a runat="server" id="MonitorAlarm" href="Monitor/MonitorAlarm.aspx" target="main">
																<tr id="trMonitorAlarm" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image4" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left"> 报警监视</td>
																</tr>
																</a>--%>
                                <a runat="server" id="MonitorAlert" href="Monitor/MonitorAlert.aspx" target="main">
                                    <tr id="trMonitorAlert" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image18" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            报警监视
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trTechnics" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("technics", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="Image17" runat="server" ImageUrl="images/ico_pz.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("technics", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            工艺管理
                        </td>
                    </tr>
                    <tr id="muTechnics" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblTechnics" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse;"
                                class="table_aa">
                                <%-- <a runat="server" id="StandTechnicsParams" href="Quality/StandTechnicsParams.aspx" target="main">
																<tr id="trStandTechnicsParams" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td width="30%" align="right" style="width: 30%">&nbsp;<asp:Image ID="Image57" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>																	
																	<td align="left">工艺参数</td>                                                                        
																</tr>
																</a>--%>
                                <%--<a runat="server" id="StandDataHistory" href="Quality/StandDataHistory.aspx" target="main">
																<tr id="trStandDataHistory" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image58" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">参考工艺图</td>
																</tr>
																</a>--%>
                                <a runat="server" id="QualityTrack" href="Quality/QualityTrack.aspx" target="main">
                                    <tr id="trQualityTrack" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image59" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            实际工艺图
                                        </td>
                                    </tr>
                                </a><a runat="server" id="chief_bom" href="Quality/chief_bom.aspx" target="main">
                                    <tr id="trchief_bom" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image62" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            BOM清单
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trQuality" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("quality",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgQuality" runat="server" ImageUrl="images/ico_qc.GIF" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("quality",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            品质管理
                        </td>
                    </tr>
                    <tr id="muQuality" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblQualityList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <a runat="server" id="QC_Table" href="Quality/QC_Table.aspx" target="main">
                                    <tr id="trQC_Table" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td width="30%" align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image19" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            QC检查
                                        </td>
                                    </tr>
                                </a>
                                <%--<a runat="server" id="QualityReport" href="Quality/QualityReport.aspx" target="main">
																<tr id="trQualityReport" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image21" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">质量报表</td>
																</tr>
																</a>--%>
                                <a runat="server" id="OEE" href="Quality/OEE.aspx" target="main">
                                    <tr id="trOEE" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image22" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            设备可动率
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trProduct" runat="server" class="toplinebg">
                        <td class="font_boldblue" align="right" style="height: 10px; cursor: hand; width: 30%;"
                            onclick='menu("product", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgProduct" runat="server" ImageUrl="images/ico_work.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("product", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            生产排程
                        </td>
                    </tr>
                    <tr id="muProduct" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblProductList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <%--<a runat="server" id="WorkOrder" href="Product/WorkOrder.aspx" target="main">
																<tr id="trWorkOrder" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td width="30%" align="right" style="width: 30%">&nbsp;<asp:Image ID="Image14" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">生产单</td>
																</tr>
																</a>
																<a runat="server" id="MPSResult" href="Product/MPSResult.aspx" target="main" >
																<tr id="trMPSResult" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image15" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">排产管理</td>
																</tr>
																</a>--%>
                                <a runat="server" id="DispatchOrder" href="Product/DispatchOrder.aspx" target="main">
                                    <tr id="trDispatchOrder" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image16" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            派工管理
                                        </td>
                                    </tr>
                                </a><a runat="server" id="UpdateCycle" href="Product/UpdateCycle.aspx" target="main">
                                    <tr id="trUpdateCycle" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image20" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="11" />
                                        </td>
                                        <td align="left">
                                            派工周期修改
                                        </td>
                                    </tr>
                                </a><a runat="server" id="UpdateMacCycle" href="Product/UpdateMacCycle.aspx" target="main">
                                    <tr id="tr3" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image23" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="11" />
                                        </td>
                                        <td align="left">
                                            机器周期修改
                                        </td>
                                    </tr>
                                </a><a runat="server" id="AdjustMachine" href="Product/AdjustMachine.aspx" target="main">
                                    <tr id="trAdjustMachine" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image21" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="11" />
                                        </td>
                                        <td align="left">
                                            调机管理
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trReport" runat="server" class="toplinebg">
                        <td class="font_boldblue" align="right" style="height: 10px; cursor: hand; width: 30%;"
                            onclick='menu("report", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgReport" runat="server" ImageUrl="images/ico_report.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("report", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            <%--<td class="font_boldblue" align="right" style="height: 10px; cursor: hand;">
                                        <asp:Image ID="imgReport" runat="server" ImageUrl="images/ico_report.gif" /></td>
										<td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("report", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould");' align="left">--%>
                            报表管理
                        </td>
                    </tr>
                    <tr id="muReport" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblReportList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <%-- <a runat="server" id="ProductSchedule" href="WebReport/ProductSchedule.aspx" target="main">
																<tr id="trProductSchedule" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image26" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">生产进度报表</td>
																</tr>
																</a>--%>
                                <a runat="server" id="ProductForDay" href="WebReport/ProductForDay.aspx" target="main">
                                    <tr id="trProductForDay" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td style="width: 30%;" align="right">
                                            &nbsp;<asp:Image ID="Image39" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left" style="height: 13px">
                                            生产日报
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MoldCycleDetail" href="WebReport/MoldCycleDetail.aspx"
                                    target="main">
                                    <tr id="trMoldCycleDetail" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image27" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            注塑周期明细
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MouldProdNumTime" href="WebReport/MouldProdNumTime.aspx"
                                    target="main">
                                    <tr id="trMouldProdNumTime" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image35" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            模具模次统计
                                        </td>
                                    </tr>
                                </a><a runat="server" id="WorkOrderComplete" href="WebReport/WorkOrderComplete.aspx"
                                    target="main">
                                    <tr id="trWorkOrderComplete" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image38" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            派工单达成率
                                        </td>
                                    </tr>
                                </a><a runat="server" id="InjectCondition" href="WebReport/InjectCondition.aspx"
                                    target="main">
                                    <tr id="trInjectCondition" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image37" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            成型参数
                                        </td>
                                    </tr>
                                </a><a runat="server" id="StopMachineReason" href="WebReport/StopMachineReason.aspx"
                                    target="main">
                                    <tr id="trStopMachineReason" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image33" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            停机原因统计
                                        </td>
                                    </tr>
                                </a><a runat="server" id="WorkShopMaterial" href="WebReport/WorkShopMaterial.aspx"
                                    target="main">
                                    <tr id="trWorkShopMaterial" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image34" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            车间用料统计
                                        </td>
                                    </tr>
                                </a><a runat="server" id="QueryQCCard" href="WebReport/QueryQCCard.aspx" target="main">
                                    <tr id="trQueryQCCard" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image32" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            QC巡检签到
                                        </td>
                                    </tr>
                                </a><a runat="server" id="OEEReport" href="WebReport/OEEReport.aspx" target="main">
                                    <tr id="trOEEReport" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image28" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            设备可动率报表
                                        </td>
                                    </tr>
                                </a>
                                <%--<a runat="server" id="MouldProductRate" href="WebReport/MouldProductRate.aspx" target="main">
																<tr id="trMouldProductRate" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image29" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">模具生产率</td>
																</tr>
																</a>
																<a runat="server" id="ProductGoodRate" href="WebReport/ProductGoodRate.aspx" target="main">
																<tr id="trProductGoodRate" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image30" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">产品合格率</td>
																</tr>
																</a>--%>
                                <a runat="server" id="SMSDetail" href="WebReport/SMSDetail.aspx" target="main">
                                    <tr id="trSMSDetail" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image31" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            短消息报警汇总
                                        </td>
                                    </tr>
                                </a><a runat="server" id="QualityForDay" href="WebReport/QualityForDay.aspx" target="main">
                                    <tr id="trQualityForDay" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image36" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            次品原因统计
                                        </td>
                                    </tr>
                                </a><a runat="server" id="Performance" href="WebReport/Performance.aspx" target="main">
                                    <tr id="trPerformance" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image61" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="11" />
                                        </td>
                                        <td align="left">
                                            机器效能报表
                                        </td>
                                    </tr>
                                </a><a runat="server" id="RptDispatchHistory" href="WebReport/RptDispatchHistory.aspx"
                                    target="main">
                                    <tr id="trRptDispatchHistory" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image14" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            完工派工单查询
                                        </td>
                                    </tr>
                                </a><a runat="server" id="RptCardDisHistory" href="WebReport/RptCardDisHistory.aspx"
                                    target="main">
                                    <tr id="trRptCardDisHistory" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image15" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            工艺单跟踪报表
                                        </td>
                                    </tr>
                                </a><a runat="server" id="Choose_CrystalReport" href="CrystalReports/Choose_CrystalReport.aspx"
                                    target="main">
                                    <tr id="trChoose_CrystalReport" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="imgMySelf" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="11" />
                                        </td>
                                        <td align="left">
                                            自定义报表
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trManHour" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("orManHour",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgManHour" runat="server" ImageUrl="images/ico_data.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("orManHour",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            工资管理
                        </td>
                    </tr>
                    <tr id="muManHour" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblManHour" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <%--<a runat="server" id="StaffPrice" href="Administrator/StaffPrice.aspx" target="main">
													<tr id="trStaffPrice" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
														<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image42" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
														<td align="left">记件工资</td>
													</tr></a>--%>
                                <a runat="server" id="SalaryManage" href="BaseInfo/SalaryManage.aspx" target="main">
                                    <tr id="trSalaryManage" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image4" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            计件计时工资
                                        </td>
                                    </tr>
                                </a><a runat="server" id="A1" href="BaseInfo/SalaryManageAdjust.aspx" target="main">
                                    <tr id="tr1" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image8" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            调整工资
                                        </td>
                                    </tr>
                                </a><a runat="server" id="A2" href="BaseInfo/SalaryManageTotal.aspx" target="main">
                                    <tr id="tr2" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image13" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            工资统计
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trStorage" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("storage", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgStorage" runat="server" ImageUrl="images/icon_document.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("storage", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            库存管理
                        </td>
                    </tr>
                    <tr id="muStorage" runat="server" style="display: none">
                        <td colspan="2">
                            <%--<table id="tblStorageList" cellspacing="0" cellpadding="6"  style=" width:100%; border-collapse:collapse" class="table_aa">
															    <a runat="server" id="INStorage" href="Storage/INStorage.aspx" target="main">
																<tr id="trINStorage" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td width="30%" align="right" style="width: 30%">&nbsp;<asp:Image ID="Image23" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">入库管理</td>
																</tr>
																</a>
																<a runat="server" id="ReceiveMaterial" href="Storage/ReceiveMaterial.aspx" target="main">
																<tr id="trReceiveMaterial" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image24" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">领料管理</td>
																</tr>
																</a>
																<a runat="server" id="ExtendMaterial" href="Storage/ExtendMaterial.aspx" target="main">
																<tr id="trExtendMaterial" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image25" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">退料管理</td>
																</tr>
																</a>
															</table>--%>
                        </td>
                    </tr>
                    <tr id="trCollect" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("collect",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgCollect" runat="server" ImageUrl="images/icon_sys_.gif" Height="10px"
                                Width="12px" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("collect",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            数据采集
                        </td>
                    </tr>
                    <tr id="muCollect" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblCollectList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <%--	<a runat="server" id="Interface" href="Collect/Interface.aspx" target="main">
																<tr id="trInterface" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image6" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">接口管理</td>
																</tr>
																</a>--%>
                                <a runat="server" id="ShowData" href="Collect/ShowData.aspx" target="main">
                                    <tr id="trShowData" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image7" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            历史数据
                                        </td>
                                    </tr>
                                </a>
                                <%--<a runat="server" id="DataShow" href="Collect/DataShow.aspx" target="main">
																<tr id="trDataShow" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image8" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">数据浏览</td>
																</tr>
																</a>--%>
                                <a runat="server" id="ErrDataInfo" href="Collect/ErrDataInfo.aspx" target="main">
                                    <tr id="trErrDataInfo" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image9" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            异常记录
                                        </td>
                                    </tr>
                                </a><a runat="server" id="ICcard" href="ICcard.aspx" target="main">
                                    <tr id="trICcard" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image66" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            停机记录
                                        </td>
                                    </tr>
                                </a><a runat="server" id="CardDetail" href="Collect/CardDetail.aspx" target="main">
                                    <tr id="trCardDetail" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image6" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            刷卡记录
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trMaintain" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("maintain", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgMaintain" runat="server" ImageUrl="images/ico_wh.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("maintain", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            维护管理
                        </td>
                    </tr>
                    <tr id="muMaintain" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblMaintainList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <a runat="server" id="MaintainPlan" href="Maintain/MaintainPlan.aspx" target="main">
                                    <tr id="trMaintainPlan" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td width="30%" align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image10" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            维护计划
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MaintainInfo" href="Maintain/MaintainInfo.aspx" target="main">
                                    <tr id="trMaintainInfo" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image11" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            设备维修
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MaintainReport" href="Maintain/MaintainReport.aspx" target="main">
                                    <tr id="trMaintainReport" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image12" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            维修报告
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trBaseinfo" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("baseinfo",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgBaseinfo" runat="server" ImageUrl="images/ico_basedata.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("baseinfo",  "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            基础资料
                        </td>
                    </tr>
                    <tr id="muBaseinfo" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblBaseinfoList" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <a runat="server" id="ItemMstr" href="BaseInfo/ItemMstr.aspx" target="main">
                                    <tr id="trItemMstr" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image45" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            注塑产品管理
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MouldMstr" href="BaseInfo/MouldMstr.aspx" target="main">
                                    <tr id="trMouldMstr" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image43" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            注塑模具管理
                                        </td>
                                    </tr>
                                </a>
                                <!--<a runat="server" id="SuitManage" href="Product/SuitManage.aspx" target="main">
																<tr id="trSuitManage" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image68" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
																	<td align="left">植毛产品管理</td>
																</tr>
																</a>
																
																<a runat="server" id="ClampManage" href="Product/ClampManage.aspx" target="main">
																<tr id="trClampManage" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image69" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
																	<td align="left">植毛夹具管理</td>
																</tr>
																</a>-->
                                <a runat="server" id="MachineMstr" href="BaseInfo/MachineMstr.aspx" target="main">
                                    <tr id="trMachineMstr" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td width="30%" align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image41" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            注塑机器管理
                                        </td>
                                    </tr>
                                </a>
                                <!--
																<a runat="server" id="MachineSuit" href="Product/MachineSuit.aspx" target="main">
																<tr id="trMachineSuit" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image67" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
																	<td align="left">植毛机管理</td>
																</tr>
																</a>
																-->
                                <%--<a runat="server" id="ItemMstr0" href="Product/ItemMstr0.aspx" target="main">
																<tr id="trItemMstr0" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image44" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
																	<td align="left">产品管理</td>
																</tr>
																</a>--%>
                                <a runat="server" id="AuxiliaryToolInfo" href="BaseInfo/AuxiliaryToolInfo.aspx" target="main">
                                    <tr id="trAuxiliaryToolInfo" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image40" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            辅助设备管理
                                        </td>
                                    </tr>
                                </a>
                                <%--<a runat="server" id="CustomerInfo" href="BaseInfo/CustomerInfo.aspx" target="main">
																<tr id="trCustomerInfo" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image48" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
																	<td align="left">客户管理</td>
																</tr>
																</a>--%>
                                <a runat="server" id="Employee" href="BaseInfo/Employee.aspx" target="main">
                                    <tr id="trEmployee" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image46" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            员工管理
                                        </td>
                                    </tr>
                                </a><a runat="server" id="A3" href="BaseInfo/RawMaterial.aspx" target="main">
                                    <tr id="tr4" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image24" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            原料管理
                                        </td>
                                    </tr>
                                </a><a runat="server" id="A4" href="BaseInfo/ColorManage.aspx" target="main">
                                    <tr id="tr5" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image25" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            产品颜色管理
                                        </td>
                                    </tr>
                                </a>
                                <%--	<a runat="server" id="Department" href="Administrator/Department.aspx" target="main">
																<tr id="trDepartment" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image47" runat="server" ImageUrl="images/point_01.gif" width="11" height="10" /></td>
																	<td align="left">部门管理</td>
																</tr>
																</a>--%>
                                <%--<tr id="trPackageList" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right">&nbsp;<asp:Image ID="Image64" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left"><a runat="server" id="PackageList" href="Product/PackageList.aspx" target="main">产品包装单</a></td>
																</tr>
																<tr id="trWorkPaper" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right">&nbsp;<asp:Image ID="Image60" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left"><a runat="server" id="WorkPaper" href="Product/WorkPaper.aspx" target="main">作业指导书</a></td>
																</tr>
																
																<tr id="trWorkRate" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right">&nbsp;<asp:Image ID="Image63" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left"><a runat="server" id="WorkRate" href="BaseInfo/WorkRate.aspx" target="main">作业速度配置</a></td>
																</tr>--%>
                            </table>
                        </td>
                    </tr>
                    <tr id="trOrder" runat="server" class="toplinebg">
                        <td height="10px" class="font_boldblue" align="right" style="height: 10px; cursor: hand;
                            width: 30%;" onclick='menu("ordermstr", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgOrdermstr" runat="server" ImageUrl="images/icon_edit.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("ordermstr", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            配置管理
                        </td>
                    </tr>
                    <tr id="muOrdermstr" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblOrdermstrList" cellspacing="0" cellpadding="6" style="width: 100%;
                                border-collapse: collapse" class="table_aa">
                                <%--<a runat="server" id="OrderMstr" href="Product/OrderMstr.aspx" target="main">
																<tr id="trOrderMstr" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this) visible="false">
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image13" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">订单维护</td>
																</tr>
																</a>--%>
                                <a runat="server" id="CommunicationInfo" href="Collect/CommunicationInfo.aspx" target="main">
                                    <tr id="trCommunicationInfo" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td width="30%" align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image5" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            通讯配置
                                        </td>
                                    </tr>
                                </a><a runat="server" id="CallConfig" href="Call/CallConfig.aspx" target="main">
                                    <tr id="trCallConfig" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image65" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            报警配置
                                        </td>
                                    </tr>
                                </a><a runat="server" id="SalaryConfig" href="BaseInfo/SalaryConfig.aspx" target="main">
                                    <tr id="trSalaryConfig" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            工资结构配置
                                        </td>
                                    </tr>
                                </a><a runat="server" id="MachineVacation" href="Call/CallMachineVacation.aspx" target="main">
                                    <tr id="trMachineVacation" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="ImagMacVa" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            机台假期配置
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                    <tr id="trSysmould" runat="server" class="toplinebg">
                        <td height="10" class="font_boldblue" align="right" style="height: 10px; width: 30%;"
                            onclick='menu("sysmould", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'>
                            <asp:Image ID="imgSysmould" runat="server" ImageUrl="images/icon_sys.gif" />
                        </td>
                        <td class="font_boldblue" style="height: 10px; cursor: hand;" onclick='menu("sysmould", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould","muManHour");'
                            align="left">
                            系统管理
                        </td>
                    </tr>
                    <tr id="muSysmould" runat="server" style="display: none">
                        <td colspan="2">
                            <table id="tblSysmould" cellspacing="0" cellpadding="6" style="width: 100%; border-collapse: collapse"
                                class="table_aa">
                                <a runat="server" id="UserInfo" href="Administrator/UserInfo.aspx" target="main">
                                    <tr id="trUserInfo" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td width="30%" align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image49" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            帐号管理
                                        </td>
                                    </tr>
                                </a><a runat="server" id="GroupInfo" href="Administrator/GroupInfo.aspx" target="main">
                                    <tr id="trGroupInfo" runat="server" style="cursor: hand" onmouseover="on(this)" onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image50" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            群组管理
                                        </td>
                                    </tr>
                                </a><a runat="server" id="UserProgramMap" href="Administrator/UserProgramMap.aspx"
                                    target="main">
                                    <tr id="trUserProgramMap" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image53" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            个人权限控制
                                        </td>
                                    </tr>
                                </a><a runat="server" id="GroupProgramMap" href="Administrator/GroupProgramMap.aspx"
                                    target="main">
                                    <tr id="trGroupProgramMap" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image54" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            组别权限控制
                                        </td>
                                    </tr>
                                </a>
                                <%--<a runat="server" id="ProgramInfo" href="Administrator/ProgramInfo.aspx" target="main"   >
																<tr id="trProgramInfo" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image51" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">程式管理</td>
																</tr>
																</a>
																<a runat="server" id="SysClassInfo" href="Administrator/SysClassInfo.aspx" target="main">
																<tr id="trSysClassInfo" runat="server" style="CURSOR: hand" onmouseover=on(this) onmouseout=off(this)>
																	<td align="right" style="width: 30%">&nbsp;<asp:Image ID="Image52" runat="server" ImageUrl="images/point_01.gif" width="11" height="11" /></td>
																	<td align="left">系统类别</td>
																</tr>
																</a>--%>
                                <a runat="server" id="MdyPassword" href="Administrator/MdyPassword.aspx" target="main">
                                    <tr id="trMdyPassword" runat="server" style="cursor: hand" onmouseover="on(this)"
                                        onmouseout="off(this)">
                                        <td align="right" style="width: 30%">
                                            &nbsp;<asp:Image ID="Image55" runat="server" ImageUrl="images/point_01.gif" Width="11"
                                                Height="10" />
                                        </td>
                                        <td align="left">
                                            用户密码修改
                                        </td>
                                    </tr>
                                </a>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
