﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QualityTrack_Temp.aspx.cs" Inherits="Quality_QualityTrack_Temp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>质量跟踪之温度(QualityTrack_Temp)</title>
     <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>
    <script type="text/javascript" src="../zhEcharts/js/jquery-1.8.2.min.js"></script>
     <script type="text/javascript" src="../zhEcharts/js/echarts.js"></script>
     <script type="text/javascript" src="../zhEcharts/theme/dark.js"></script>

    <script type="text/javascript">
        var flag = 0;
        var maxTotal = 0;
        function shangPage() {
            var Label = document.getElementById("Label1");
            var whoButton = "shangPage";
            document.getElementById("lkbXiaPage").removeAttribute("disabled");
            getPicture(Label.innerHTML, whoButton);
            flag = 1;
        }

        function xiaPage() {
            var Label = document.getElementById("Label1");
            var whoButton = "xiaPage";
            document.getElementById("lkbShangPage").removeAttribute("disabled");
            getPicture(Label.innerHTML, whoButton);
            flag = 1;
        }

        function getPicture(LabelPage, whoButton) {
            $.ajax({
                type: 'POST',
                url: "QualityTrack_Temp.aspx?value1=1&LabelPage=" + LabelPage + "&whoButton=" + whoButton,
                success: function (backData, textStatus, XMLResponse) {
                    //alert(backData);
                    var data = JSON.parse(backData);
                    document.getElementById("Label1").innerHTML = data.PageNum;
                    document.getElementById("Label2").innerHTML = "共" + (data.TotalPageNum).toString() + "页";

                    if (data.OnoffButton != null && data.OnoffButton == "offxia") {
                        document.getElementById("lkbXiaPage").setAttribute("disabled", "disabled");
                    }
                    if (data.OnoffButton != null && data.OnoffButton == "offshang") {
                        document.getElementById("lkbShangPage").setAttribute("disabled", "disabled");
                    }

                    var myChart1 = echarts.init(document.getElementById('main1'), 'dark');
                    myChart1.setOption(option = {
                        title: {
                            top: '1%',
                            left: '50%',
                            text: '温度图',
                            subtext: '每100啤一图',
                        },
                        legend: {
                            left: 'left',
                            data: ['温度一', '温度二']
                        },
                        tooltip: {
                            //formatter: '碑数:{b} {a}:{c}',
                            trigger: 'axis'
                        },
                        xAxis: {
                            name: '啤数',
                            data: data.XData
                        },
                        yAxis: {
                            name: '温度',
                            splitLine: {
                                show: false
                            }
                        },
                        toolbox: {
                            top: '0%',
                            left: '90%',
                            feature: {
                                restore: {},
                                saveAsImage: {}
                            }
                        },
                        series: [
                            {
                                name: '温度一',
                                type: 'line',
                                data: data.YData,
                                markLine: {
                                    //label: { show: true, position: 'left' },
                                    label: {
                                        normal: {
                                            show: true,
                                            formatter: '{b}: {c}'
                                        }
                                    },
                                    silent: true,
                                    data: [
                                        {
                                            name: '温度1标准',
                                            yAxis: 200,//data.StandCycleTime,
                                        }
                                    ]
                                }
                            },
                            {
                                name: '温度二',
                                type: 'line',
                                data: data.YData1,
                               
                            }
                        ]
                    });
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
					<%-- <!--<asp:Image ID="Image1" runat="server" />-->--%>
                        <div id="main1" style="width: 1000px;height:500px;"></div>
                </td>
            </tr>
            <tr>
                <td>
                <table style="width: 100%" runat="server" id="tblChgPage">
                    <tr>
                        <%--<td align="right" style="width: 50%;">
                            <asp:CheckBox ID="chkPictureType" runat="server" Text="100啤1图" AutoPostBack="True" Visible="False" /></td>
                        <td align="left" id="tdPictureType" runat="server" style="width: 50%; height: 23px;">
                            &nbsp;<asp:LinkButton ID="lkbShangPage" runat="server" OnClick="LinkButton_Click">上一页</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lkbXiaPage" runat="server" OnClick="LinkButton_Click" CommandName="Next">下一页</asp:LinkButton>
                            <asp:DropDownList ID="ddlImageIndex" runat="server" Enabled="false" /></td> --%>
                        <td align="center">
                            <input id="lkbShangPage" type="button" onclick="shangPage()" value="上一页"/>
                            <label id="Label1"></label>
                            <input id="lkbXiaPage" type="button" onclick="xiaPage()" value="下一页"/>
                            <label id="Label2"></label>
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
            </table>
    </form>
    <script type="text/javascript">
        if (flag == 0) {
            getPicture("0");
        }

    </script>
</body>
</html>
