<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QualityTrack_Press.aspx.cs" Inherits="Quality_QualityTrack_Press" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>质量跟踪压力(QualityTrack_Press)</title>
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
                url: "QualityTrack_Press.aspx?value1=1&LabelPage=" + LabelPage + "&whoButton=" + whoButton,
                success: function (backData, textStatus, XMLResponse) {
                   // alert(backData);
                    var data = JSON.parse(backData);
                    document.getElementById("Label1").innerHTML = data.PageNum;
                    document.getElementById("Label2").innerHTML = "共" + (data.TotalPageNum).toString() + "页";
                   // alert(data.PageNum);
                    if (data.OnoffButton != null && data.OnoffButton == "offxia") {
                        document.getElementById("lkbXiaPage").setAttribute("disabled", "disabled");
                    }
                    if (data.OnoffButton != null && data.OnoffButton == "offshang") {
                        document.getElementById("lkbShangPage").setAttribute("disabled", "disabled");
                    }
                    //var minNum = data.YData1[4] - 1;
                    //var maxNum = data.YData1[0];
                    var myChart1 = echarts.init(document.getElementById('main1'), 'dark');
                    myChart1.setOption(option = {
                        title: {
                            top: '0%',
                            left: '50%',
                            text: '压力图',
                            textAlign:'center',
                            subtext: data.YData1[0] + '啤' + '                                     ' + data.YData1[1] + '啤' + '                                     ' + data.YData1[2] + '啤' + '                                     ' + data.YData1[3] + '啤' + '                                 ' + data.YData1[4] + '啤',
                        },
                        tooltip: {
                            //formatter: '碑数:{b} {a}:{c}',
                            trigger: 'axis'
                        },
                        xAxis: [{
                            type:'category',
                            name: '取样点',
                            data: data.XData
                        }, {
                            type:'value',
                            position:'top',
                            min: data.YData1[4] - 1,
                            max: data.YData1[0],
                            interval:1,
                            //splitNumber:5,
                           /* axisLabel :{  
                                interval:0   
                            },
                            //data: data.XData
                            //data: [data.YData1[0], data.YData1[1], data.YData1[2], data.YData1[3], data.YData1[4], data.YData1[4]-1]
                            /*data: [1187, 1187, 1187, 1187, 1187, 1187, 1187, 1187, 1187, 1187, 1186, 1186, 1186, 1186, 1186, 1186, 1186, 1186, 1186, 1186
                            , 1185, 1185, 1185, 1185, 1185, 1185, 1185, 1185, 1185, 1185, 1184, 1184, 1184, 1184, 1184, 1184, 1184, 1184, 1184, 1184, 1183
                            , 1183, 1183, 1183, 1183, 1183, 1183, 1183, 1183, 1183]*/
                            axisLabel: {
                                formatter: function (v) {
                                    return "";
                                }
                            }
                            //name: '碑数',
                            /*data: function(v){
                                v = -data.YData1;
                                return v;
                            }*/
                        }],
                        yAxis: {
                            nameLocation:'middle',
                            name: '压力',
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
                                name: '压力',
                                type: 'line',
                                data: data.YData,     
                            }, /*{
                                name: '压力',
                                type: 'bar',
                                data: {},
                            }*/
                        ]
                    });
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center">
                <%-- <asp:Image ID="Image1" runat="server" />--%>
                <div id="main1" style="width: 1000px;height:500px;"></div>
            </td>
        </tr>
        <tr>
            <td>
            <table style="width: 100%">
                    <tr>
                        <%-- <td align="right" style="width: 50%">
                            &nbsp;<asp:RadioButtonList ID="rblPictureType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rblPictureType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="5">5啤1图</asp:ListItem>
                                <asp:ListItem Value="1">1啤1图</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td align="left" valign="top">
                            <asp:LinkButton ID="lkbShangPage" runat="server" OnClick="LinkButton_Click">上一页</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lkbXiaPage" runat="server" OnClick="LinkButton_Click" CommandName="Next">下一页</asp:LinkButton>&nbsp;
                            第&nbsp;
                            <asp:DropDownList ID="ddlImageIndex" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlImageIndex_SelectedIndexChanged" />&nbsp;
                            啤
                        </td>--%>
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
