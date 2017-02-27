 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="ICcard.aspx.cs" Inherits="ICcard" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>停机记录</title>
    <link href="images/css.css" type="text/css" rel="stylesheet" />
    <link href="WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="JS/checkbox.js"></script>
    <script type="text/javascript" language="javascript" src="JS/Common.js"></script>
    
    <script src="zhEcharts/js/jquery-1.8.2.min.js"></script>
    <script src="zhEcharts/js/echarts.js"></script>
    <script src="zhEcharts/theme/dark.js"></script>

    <!--********************-->
    <script type="text/javascript">
        function chongfu(arr1,reason) {
            for (var i = 0; i < arr1.length; i++) {
                if (arr1[i] == reason) {
                    return true;
                }
            }
            return false;
        } 
    </script>
    <!--********************-->
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
        <tr>
            <td valign="top">
                <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            当前位置:数据浏览 -> <a id="ICcard" href="ICcard.aspx" target="main">停机记录</a>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(images/bg_title.gif); height: 17px;">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <%--<asp:ListItem Value="deptname">部门</aspListItem>
                 <asp:ListItem Value="rank">职位</asp:ListItem>--%>
                                        <asp:ListItem Value="DispatchNo">派工单号</asp:ListItem>
                                        <asp:ListItem Value="Machineno">机器编号</asp:ListItem>
                                    <%--<asp:ListItem Value="employeename_cn">员工姓名</asp:ListItem>--%>
                                        <%--     <asp:ListItem Value="employeeid">员工编号</asp:ListItem>
                 <asp:ListItem Value="iccardno">IC卡号</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:DropDownList ID="ddlMachine_SeatCode" runat="server" Height="16px">
                                    </asp:DropDownList>
                                    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;停机时间:<input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 至
                                 <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 
                                    <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="images/btn_search.gif" OnClick="btnVisible_Click"
                                        ImageAlign="Top" />&nbsp;
                                    <asp:ImageButton ID="imgBtExcel" runat="server" ImageAlign="Top" ImageUrl="~/images/button_export.gif"
                                        OnClick="imgBtExcel_Click" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td style="background-image: url(images/bg_title.gif); height: 17px;">
                                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 浏览
                                            </td>
                                        </tr>
                                    </table>
                                   <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="18" CssClass="itemtable" BorderWidth="0px" CellSpacing="1"
                                        OnRowDataBound="GridView1_RowDataBound">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <%--      <asp:BoundField DataField="DispatchNo" HeaderText="派工单号" />--%>
                                            <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                            <%-- <asp:BoundField DataField="employeeid" HeaderText="员工编号" />--%>
                                            <%--           <asp:BoundField DataField="employeename_cn" HeaderText="员工姓名" />--%>
                                            <%-- <asp:BoundField DataField="iccardno" HeaderText="IC卡号" />--%>
                                            <asp:BoundField DataField="reasonname" HeaderText="停机原因" />
                                            <asp:BoundField DataField="start_date" HeaderText="开始时间" />
                                            <asp:BoundField DataField="startempname" HeaderText="开始停机人" />
                                            <asp:BoundField DataField="end_date" HeaderText="结束时间" />
                                            <asp:BoundField DataField="endempname" HeaderText="结束停机人" />
                                            <asp:BoundField DataField="StopTime" HeaderText="停机时间(时：分：秒)" />
                                        </Columns>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDataCount" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                            <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                            <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex"
                                                                ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                                            <input id="hdnFlag" type="hidden" runat="server" style="width: 13px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                     <div id="main1" style="width: 48%;height:300px;float:left;margin-right:2%"></div><div id="main2" style="width: 48%;height:300px;float:left;margin-left:2%"></div>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    </form>
    <!--************************************************-->
    <script type="text/javascript">
        $.ajax({
            type: 'POST',
            url: "ICcard.aspx?stop=1",
            success: function (backData, textStatus, XMLResponse) {
                var data = JSON.parse(backData);
                if (data != "" && data  != undefined) {
                    //alert(data[0]);
                    //alert(data[0]["start_date"]);
                    var map = new Map();
                    var reasonName = [];
                    var timeNumber = [];
                    var arr = [];
                    var n = 0;
                    var total = 0;
                    for (var i = 0; i < data.length; i++) {
                        //alert("进入");
                        var tString = [];
                        var reason = data[i]["reasonname"]==undefined? "" : data[i]["reasonname"].toString().trim();
                        var time = data[i]["StopTime"]==undefined?"":data[i]["StopTime"].toString().trim();
                        //alert(reason + "和" + time);
                        //alert(data.length);
                        if (!chongfu(reasonName, reason)) {

                            if (reason.trim() == "") {
                                reason = "未知原因";
                            }
                            reasonName[n] = reason;
                            n++;
                        }
                        if (isNaN(time)) {
                            tString = time.split(":");
                        } else {
                            tString = ["0", "0", "0"];
                        }
                        var seconds = 0;
                        seconds = seconds + parseInt(tString[2]);
                        seconds = seconds + parseInt(tString[1]) * 60;
                        seconds = seconds + parseInt(tString[0]) * 3600;
                        //alert(reason+"和"+seconds);
                        if (map.has(reason)) {
                            map.set(reason, map.get(reason) + seconds);

                        } else {
                            map.set(reason, seconds);
                        }
                    }
                }
                for (var i = 0; i < reasonName.length; i++) {
                    timeNumber[i] = parseFloat((map.get(reasonName[i]) / 3600).toFixed(2));
                    //              alert(reasonName[i] + "和" + timeNumber[i]);
                }

                var colors = ['#5793f3', '#d14a61', '#675bba'];
                for (var i = 0; i < timeNumber.length; i++) {
                    total = total + timeNumber[i];
                }

                for (var i = 0; i < timeNumber.length; i++) {
                    arr[i] = parseFloat((timeNumber[i] * 100 / total).toFixed(2));
                }
                var myChart1 = echarts.init(document.getElementById('main1'), 'dark');
                var myChart2 = echarts.init(document.getElementById('main2'), 'dark');
                myChart1.setOption({
                    title: {
                        text: '停机时间',
                        x: 'left'
                    },
                    grid:{
                        right: '5%'
                    },
                    color: colors,
                    tooltip: {
                        trigger: 'axis',
                        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                        }
                    },
                    dataZoom: [
                        {
                            show: true,
                            yAxisIndex: 0,
                            filterMode: 'empty',
                            width: 20,
                            height: '60%',
                            showDataShadow: false,
                            left: '95%'
                        }
                    ],
                    toolbox: {
                        feature: {
                            magicType: {
                                type: ['line', 'bar']           ///切换
                            },
                            dataView: { show: true, readOnly: false },
                            restore: { show: true },
                            saveAsImage: { show: true }

                        }
                    },
                    xAxis: [
                        {
                            type: 'category',
                            axisTick: {
                                alignWithLabel: true
                            },
                            data: reasonName
                        }
                    ],
                    yAxis: [
                        {
                            name: '单位:(小时)',
                            type: 'value',
                            axisLabel: {
                                formatter: '{value} '
                            },
                        }
                    ],
                    series: [
                        {
                            name: '停机时间',
                            type: 'bar',
                            label: {
                                normal: {
                                    show: true,
                                    position: 'inside',  //inside
                                    formatter: '{c}'
                                }
                            },
                            data: timeNumber
                        } 
                    ]
                });
                myChart2.setOption({
                    title: {
                        text: '停机原因占比',
                        x: 'left'
                    },
                    grid: {
                        right: '5%'
                    },
                    color: colors,
                    tooltip: {
                        trigger: 'axis',
                        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                        }
                    },
                    toolbox: {
                        feature: {
                            magicType: {
                                type: ['line', 'bar']           ///切换
                            },
                            dataView: { show: true, readOnly: false },
                            restore: { show: true },
                            saveAsImage: { show: true }

                        }
                    },
                    dataZoom: [
                        {
                            show: true,
                            yAxisIndex: 0,
                            filterMode: 'empty',
                            width: 20,
                            height: '60%',
                            showDataShadow: false,
                            left: '95%'
                        }
                    ],
                    xAxis: [
                        {
                            type: 'category',
                            axisTick: {
                                alignWithLabel: true
                            },
                            data: reasonName
                        }
                    ],
                    yAxis: [
                        {
                            type: 'value',
                            name: '单位:(%)',
                            axisLabel: {
                                formatter: '{value} '
                            }
                        }
                    ],
                    series: [
                        {
                            name: '停机原因占比',
                            type: 'bar',
                            label: {
                                normal: {
                                    show: true,
                                    position: 'inside',  //inside
                                    formatter: '{c}'
                                }
                            },
                            itemStyle: {
                                normal:{
                                    color: '#675bba'
                                }  
                            },
                            data: arr
                        }
                    ]
                });
            }
        });
    /*        var table = document.getElementById("GridView1");
            var map = new Map();
            var reasonName = [];
            var timeNumber = [];
            var arr = [];
            var n = 0;
            var total = 0;
            if (table != null) {
                var tr = table.getElementsByTagName("tr");
                for (var i = 1 ; i < tr.length ; i++) {
                    if (tr[i] != null) {
                        var tString = [];
                        var reason = tr[i].getElementsByTagName("td")[1].innerText.toString().trim();
                        var time = tr[i].getElementsByTagName("td")[6].innerText.toString().trim();
                        if (!chongfu(reasonName, reason)) {
                            
                            if (reason.trim() == "") {
                                reason = "未知原因";
                            }
                            reasonName[n] = reason;
                            n++;
                        }


                        if (isNaN(time)) {
                            tString = time.split(":");
                        } else {
                            tString = ["0", "0", "0"];
                        }
                        var seconds = 0;
                        seconds = seconds + parseInt(tString[2]);
                        seconds = seconds + parseInt(tString[1]) * 60;
                        seconds = seconds + parseInt(tString[0]) * 3600;
                        //              alert(reason+"和"+seconds);
                        if (map.has(reason)) {
                            map.set(reason, map.get(reason) + seconds);

                        } else {
                            map.set(reason, seconds);
                        }
                    }
                }

            }
            for (var i = 0; i < reasonName.length; i++) {
                timeNumber[i] = parseFloat((map.get(reasonName[i]) / 3600).toFixed(2));
                //              alert(reasonName[i] + "和" + timeNumber[i]);
            }

            var colors = ['#5793f3', '#d14a61', '#675bba'];
            for (var i = 0; i < timeNumber.length; i++) {
                total = total + timeNumber[i];
            }

            for (var i = 0; i < timeNumber.length; i++) {
                arr[i] = parseFloat((timeNumber[i] * 100 / total).toFixed(2));
            }
            var myChart1 = echarts.init(document.getElementById('main1'), 'dark');
            var myChart2 = echarts.init(document.getElementById('main2'), 'dark');
            myChart1.setOption({
                title: {
                    text: '停机时间',
                    x: 'left'
                },
                grid:{
                    right: '5%'
                },
                color: colors,
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                dataZoom: [
                    {
                        show: true,
                        yAxisIndex: 0,
                        filterMode: 'empty',
                        width: 20,
                        height: '60%',
                        showDataShadow: false,
                        left: '95%'
                    }
                ],
                toolbox: {
                    feature: {
                        magicType: {
                            type: ['line', 'bar']           ///切换
                        },
                        dataView: { show: true, readOnly: false },
                        restore: { show: true },
                        saveAsImage: { show: true }

                    }
                },
                xAxis: [
                    {
                        type: 'category',
                        axisTick: {
                            alignWithLabel: true
                        },
                        data: reasonName
                    }
                ],
                yAxis: [
                    {
                        name: '单位:(小时)',
                        type: 'value',
                        axisLabel: {
                            formatter: '{value} '
                        },
                    }
                ],
                series: [
                    {
                        name: '停机时间',
                        type: 'bar',
                        label: {
                            normal: {
                                show: true,
                                position: 'inside',  //inside
                                formatter: '{c}'
                            }
                        },
                        data: timeNumber
                    } 
                ]
            });
            myChart2.setOption({
                title: {
                    text: '停机原因占比',
                    x: 'left'
                },
                grid: {
                    right: '5%'
                },
                color: colors,
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                toolbox: {
                    feature: {
                        magicType: {
                            type: ['line', 'bar']           ///切换
                        },
                        dataView: { show: true, readOnly: false },
                        restore: { show: true },
                        saveAsImage: { show: true }

                    }
                },
                dataZoom: [
                    {
                        show: true,
                        yAxisIndex: 0,
                        filterMode: 'empty',
                        width: 20,
                        height: '60%',
                        showDataShadow: false,
                        left: '95%'
                    }
                ],
                xAxis: [
                    {
                        type: 'category',
                        axisTick: {
                            alignWithLabel: true
                        },
                        data: reasonName
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        name: '单位:(%)',
                        axisLabel: {
                            formatter: '{value} '
                        }
                    }
                ],
                series: [
                    {
                        name: '停机原因占比',
                        type: 'bar',
                        label: {
                            normal: {
                                show: true,
                                position: 'inside',  //inside
                                formatter: '{c}'
                            }
                        },
                        itemStyle: {
                                 normal:{
                                 color: '#675bba'
                            }  
                        },
                        data: arr
                    }
                ]
            });*/
    </script>
</body>
</html>
