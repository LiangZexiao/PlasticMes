﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchOrder.aspx.cs" Inherits="Product_DispatchOrder"
    EnableEventValidation="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>派工管理(DispatchOrder)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

    <script language="javascript" src="../JS/itemJS.js" type="text/javascript"></script>

    

    <script language="javascript" type="text/javascript">

        // 选择一个条目
        function _selectResult(item) {
            var spans = item.getElementsByTagName("span");
            if (spans) {
                for (var i = 0; i < spans.length; i++) {
                    if (spans[i].className == "result1") {
                        queryField.value = spans[i].innerHTML;
                        lastVal = val = escape(queryField.value);
                        mainLoop();
                        queryField.focus();
                        //showDiv(true);

                        //document.getElementById("TextBox1").innerText = spans[i].innerHTML; 

                        if (newSetById != null)//派工单号
                        {
                            var response = newById.GetSearhItmes(spans[i].innerHTML, "-1");
                            _innerTexts(response.value, newSetById);
                        }

                        if (otherById != null)//产品编号
                        {
                            var response = newById.GetSearhSetValues(spans[i].innerHTML, '1');
                            _innerTexts(response.value, otherById);
                        }
                        if (otherById2 != null)//产品描述
                        {
                            var response = newById.GetSearhSetValues(spans[i].innerHTML, '2');
                            _innerTexts(response.value, otherById2);
                        }
                        if (otherById3 != null)//派工数量
                        {
                            var response = newById.GetSearhValues(spans[i].innerHTML);
                            _innerTexts(response.value, otherById3);
                        }
                        if (otherById4 != null)//模具
                        {
                            var response = newById.GetMouldMstr(spans[i].innerHTML);
                            _innerDDl(response.value, otherById4);
                        }
                        //                 if(otherById6 !=null)//周期
                        //                 {
                        //                     var response = newById.GetMouldMstr(spans[i].innerHTML);                
                        //                     _innerDDl(response.value,otherById6);
                        //                 }
                        showDiv(false);
                        return;
                    }
                }
            }
        }

        function _innerDDl(arrlist, byids) {
            var updatebyid = document.getElementById(byids);
            //清空Select1的options
            for (var j = 0; j < updatebyid.options.length; j++) {
                updatebyid.options.remove(j);
                j = 0;
                //j--;
            }
            //新增Select1的options

            updatebyid.options[0] = new Option("选择", "");
            if (arrlist.length > 0) {
                for (var i = 0; i < arrlist.length; i++) {
                    var option = new Option(arrlist[i], arrlist[i]);
                    updatebyid.options[i + 1] = option;
                }
            }
        }

        function selectIndex(checkesId) {
            var selectById = document.getElementById(checkesId);
          var mouldNo = selectById.options[selectById.selectedIndex].value;
          //  var mouldNo = selectById.value;
            if (otherById5 != null && otherById4 == checkesId)//模具
            {
                var prodNo = document.getElementById(otherById).value;
                document.getElementById("Hidden1").innerText = mouldNo;
                var response = newById.GetMachineMstr(mouldNo, prodNo);
                _innerDDl(response.value, otherById5);
                var texts = newById.GetMachineMstrCycle(mouldNo, prodNo);
                _innerTexts(texts.value, otherById6);
            }
            if (otherById5 != null && otherById5 == checkesId)//机器
            {
                document.getElementById("Hidden2").innerText = mouldNo;
            }
        }
        function GetStopDate() { //由计划开始时间和派工数量和模具周期计算结束时间
             var vMouldNo=document.getElementById("ddlMouldNo").value;
             if(document.getElementById("txtDispatchNum").value!=""||document.getElementById("txtStandCycle").value!="")
             {
                 var GoodSocketNum = Product_DispatchOrder.GetGoodSocketNumByNew(vMouldNo);
                 var sumSeconds=0;
                 if(GoodSocketNum!="")
                 {
                     sumSeconds=(Number(document.getElementById("txtDispatchNum").value)*(Number(document.getElementById("txtStandCycle").value)/Number(GoodSocketNum.value)));
                 }
                 else
                 {
                     sumSeconds=(Number(document.getElementById("txtDispatchNum").value)*Number(document.getElementById("txtStandCycle").value));
                 }
                 var time = new Date(document.getElementById("txtStartDate").value.replace("-", "/"));
                 time.setSeconds(time.getSeconds() + Number(sumSeconds), time.getSeconds(), 0);
                 document.getElementById("txtStopDate").value= time.format("yyyy-MM-dd hh:mm");
             }
             else
             {
                 alert("请输入派工数和周期,以便计算结束时间！！");
             }
        }
        Date.prototype.format = function(format) {
            var o = {
                "M+": this.getMonth() + 1, //month  
                "d+": this.getDate(),    //day  
                "h+": this.getHours(),   //hour  
                "m+": this.getMinutes(), //minute  
                "s+": this.getSeconds(), //second  
                "q+": Math.floor((this.getMonth() + 3) / 3), //quarter  
                "S": this.getMilliseconds() //millisecond  
            }
            if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
      (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o) if (new RegExp("(" + k + ")").test(format))
                format = format.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
          ("00" + o[k]).substr(("" + o[k]).length));
            return format;
        }
    </script>

    <script language="jscript" type="text/javascript">
        mainLoop = function() {
            val = escape(queryField.value);
            if (lastVal != val) {
                if (document.getElementById("search").disabled)//修改时候
                {
                    val = "lkdsfjlsjdsfjklssdasdasdas";
                }
                var response = Product_DispatchOrder.GetSearhItmes(val, "0");
                showQueryDiv(response.value);

                lastVal = val;
            }
            newById = Product_DispatchOrder;
            newSetById = "txtDO_No"; //派工单号
            otherById = "txtProductNo";  //产品编号
            otherById2 = "txtProductDesc"; //产品描述
            otherById3 = "txtDispatchNum"; //派工数量
            otherById4 = "ddlMouldNo"; //模具编号
            otherById5 = "ddlMachineNo"; //机器编号
            otherById6 = "txtStandCycleMould"; //模具参考周期
            setTimeout('mainLoop()', 100);
            return true;
        }

        function SetMouldNo(sender, args) {
            var txtNo = args.Value;
            form1.txtHiddenMouldNo.value = txtNo;
            form1.Hidden1.value = txtNo;
            args.isvalid = true;
        }
        function SetMachineNo(sender, args) {
            var txtNo = args.Value;
            form1.txtHiddenMachineNo.value = txtNo;
            form1.Hidden2.value = txtNo;
            args.isvalid = true;
        }
    </script>

    <style type="text/css">
        #btMachine
        {
            width: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
        <tr>
            <td valign="top">
                <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            当前位置:生产排程 -> 派工单
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" id="Tinf" runat="server" border="0" align="center" cellpadding="0"
                    cellspacing="0" bordercolor="#00FF00">
                    <tr>
                        <td width="78" height="23" class="tabPageFont" background="../images/tab_on.gif"
                            style="cursor: hand" align="center">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click" CausesValidation="False">注塑派工</asp:LinkButton>
                        </td>
                        <%--<td width="78" class="tabPageFont" background="../images/tab_off.gif" style="cursor: hand"
                            align="center">
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click" CausesValidation="False">植毛派工</asp:LinkButton>
                        </td>--%>
                        <td width="198" background="../images/topline_bg.gif">
                            <input id="Hidden4" type="hidden" value="0ccccccccccccccccccc" runat="server" style="width: 198px" />
                        </td>
                        <td width="198" background="../images/topline_bg.gif">
                            <input id="Hidden5" type="hidden" value="0cccccccccccccccccccccc" runat="server"
                                style="width: 198px" />
                        </td>
                        <td background="../images/topline_bg.gif">
                            <input id="hdnTargetss" type="hidden" value="MachineMstr" runat="server" style="width: 1px" />
                            <input id="hdnCellIndexss" type="hidden" value="0" runat="server" style="width: 12px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" bgcolor="#FFFFFF">
                            <iframe width="100%" id="subnet" runat="server" visible="false" marginheight="0"
                                height="1" frameborder="0" scrolling="no" overflow="hidden" style="padding-right: 0px;
                                margin-top: 0px; padding-left: 0px; margin-left: 0px; padding-top: 0px" src="DispatchOrder.aspx">
                            </iframe>
                        </td>
                    </tr>
                </table>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table width="100%" runat="server" border="0" cellpadding="0" cellspacing="0" bordercolor="#00ff00"
                            align="center">
                            <tr>
                                <td colspan="5" bgcolor="#ffffff">
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                &nbsp; &nbsp; &nbsp; &nbsp; 操作
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlQuery" runat="server">
                                                    <asp:ListItem Value="DO_No">派工单号</asp:ListItem>
                                                    <asp:ListItem Value="WorkOrderNo">工单号</asp:ListItem>
                                                    <asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
                                                    <asp:ListItem Value="ProductNo">产品编号</asp:ListItem>
                                                    <asp:ListItem Value="MouldNo">模具编号</asp:ListItem>
                                                    <asp:ListItem Value="Creater">创建人</asp:ListItem>
                                                    <asp:ListItem Value="convert(char(19),DispatchDate,121)">派工日期</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;
                                                <asp:DropDownList ID="ddlMachine_SeatCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMachine_SeatCode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                                    OnClick="btnVisible_Click" ImageAlign="Top" />
                                                <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                                    OnClick="btnVisible_Click" ImageAlign="Top" />
                                                <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                                    OnClick="btnDelete_Click" ImageAlign="Top" />
                                                <asp:ImageButton ID="igbCheckYdouble" runat="server" CausesValidation="false" ImageUrl="~/images/btn_check_yes.gif"
                                                    OnClick="btnCheck_Click" ImageAlign="Top" Style="height: 22px" />
                                                <asp:ImageButton ID="igbCheckNdouble" runat="server" CausesValidation="false" ImageUrl="~/images/btn_check_no.gif"
                                                    OnClick="btnCheck_Click" ImageAlign="Top" />
                                                <asp:DropDownList ID="ddlDispatchStateFlag" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDispatchState_SelectedIndexChanged"
                                                    Width="88px">
                                                    <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                                                    <asp:ListItem Value="0">未审核</asp:ListItem>
                                                    <asp:ListItem Value="1">已审核</asp:ListItem>
                                                </asp:DropDownList>
                                                <input id="hdnID" type="hidden" runat="server" style="width: 5px" class="textbox" />
                                                <asp:DropDownList ID="ddlCheckStatus" runat="server" Visible="False" Width="67px">
                                                    <asp:ListItem Value="0">未派工</asp:ListItem>
                                                    <asp:ListItem Value="1">在生产</asp:ListItem>
                                                    <asp:ListItem Value="2">已完成</asp:ListItem>
                                                    <asp:ListItem Value="3">急单</asp:ListItem>
                                                    <asp:ListItem Value="4">次急单</asp:ListItem>
                                                    <asp:ListItem Value="5">挂起单</asp:ListItem>
                                                    <asp:ListItem Value="6">已派工</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                                    <tr>
                                                        <td style="background-image: url(../images/bg_title.gif); height: 22px;">
                                                            &nbsp; &nbsp; &nbsp; &nbsp;浏览
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="12" CssClass="itemtable" OnRowDataBound="GridView1_RowDataBound"
                                                    BorderWidth="0px" CellSpacing="1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                    AllowSorting="True" OnSorting="GridView1_Sorting">
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkItemInner" runat="server" /></ItemTemplate>
                                                            <HeaderTemplate>
                                                                <input id="chkAll" type="checkbox" onclick="selectAll(this);" /></HeaderTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:ButtonField DataTextField="ID" HeaderText="序号">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                                                            <HeaderStyle CssClass="hidden" />
                                                            <FooterStyle CssClass="hidden" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField CommandName="Detail" Text="派工" Visible="False">
                                                            <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField DataTextField="DO_No" SortExpression="DO_No" CommandName="select"
                                                            HeaderText="派工单号">
                                                            <ItemStyle Width="8%" />
                                                        </asp:ButtonField>
                                                        <asp:BoundField DataField="MachineNo" SortExpression="MachineNo" HeaderText="机器编号">
                                                            <ItemStyle Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MouldNo" SortExpression="MouldNo" HeaderText="模具编号">
                                                            <ItemStyle Width="7%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ProductNo" SortExpression="ProductNo" HeaderText="产品编号">
                                                            <ItemStyle Width="7%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ProductDesc" SortExpression="ProductDesc" HeaderText="产品描述">
                                                            <ItemStyle Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="StartDate" SortExpression="StartDate" HeaderText="预计开始时间"
                                                            Visible="False" />
                                                        <asp:BoundField DataField="StopDate" SortExpression="StopDate" HeaderText="预计结束时间"
                                                            Visible="False" />
                                                        <asp:BoundField DataField="DispatchDate" SortExpression="DispatchDate" HeaderText="派工日期">
                                                            <ItemStyle Width="9%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DispatchNum" SortExpression="DispatchNum" HeaderText="数量"
                                                            DataFormatString="{0:N}">
                                                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="StartDate" SortExpression="StartDate" HeaderText="计划开始时间">
                                                            <ItemStyle Width="9%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="StopDate" SortExpression="StopDate" HeaderText="计划结束时间">
                                                            <ItemStyle Width="9%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CheckStatus" SortExpression="CheckStatus" HeaderText="审核状态">
                                                            <ItemStyle Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DispatchStatus" SortExpression="DispatchStatus" HeaderText="派工状态">
                                                            <ItemStyle Width="6%" />
                                                        </asp:BoundField>
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
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                        ImageAlign="Top" />
                                    <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                        ImageAlign="Top" />
                                    <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" CausesValidation="false" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCheckYsingle" runat="server" CausesValidation="false" ImageUrl="~/images/btn_check_yes.gif"
                                        OnClick="btnCheck_Click" />
                                    <asp:ImageButton ID="igbCheckNsingle" runat="server" CausesValidation="false" ImageUrl="~/images/btn_check_no.gif"
                                        OnClick="btnCheck_Click" Height="22px" />
                                    <input id="txtstate" runat="server" style="width: 9px" type="hidden" />
                                    <asp:TextBox ID="txtID" runat="server" Visible="False" Width="1px" Height="8px"></asp:TextBox>
                                    <input id="Hidden1" type="hidden" runat="server" style="width: 5px" class="textbox" />
                                    <input id="Hidden2" type="hidden" runat="server" style="width: 5px" class="textbox" />
                                    <input id="Hidden3" runat="server" style="width: 21px" type="hidden" />
                                    <input id="txtCheckStatus" runat="server" style="width: 30px" type="hidden" />
                                    <asp:HiddenField ID="txtHiddenMouldNo" runat="server" />
                                    <asp:HiddenField ID="txtHiddenMachineNo" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp; &nbsp;编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblWorkOrderNo" runat="server" Text="工单号:"></asp:Label>
                                </th>
                                <td>
                                    <input id="search" runat="server" autocomplete="off" name="search" style="width: 132px"
                                        type="text" class="textboxodl" disabled="disabled"  onblur="EnterPress()" >

                                    <script language="javascript" type="text/javascript">
                                        function EnterPress() { //传入 event
                                            //alert("进入方法");
                                            //                                            var e = e || window.event;
                                            //                                            if (e.keyCode == 13) {
                                            var DO_No = document.getElementById("search").value;
                                           // var DO_No = document.getElementById("search").value.toString();
                                           // alert(DO_No);
                                            var response = Product_DispatchOrder.GetDO_No(DO_No);
                                            //var response = DO_No + "001";
                                            //var response = Product_DispatchOrder.ZH_Test(DO_No).value;

                                           // alert(response);

                                            document.getElementById("txtDO_No").value = response.value;
                                            //document.getElementById("txtDO_No").value = response;
                                            //                                            }
                                        }

                                     </script>
                                    

                                    <!-- 
                                    <script language="javascript" type="text/javascript">
                                          window.oninit = InitQueryCode("search", "querydiv"); function search_onclick(){}
                                        </script>  -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="search"
                                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblDO_No" runat="server" Text="派工单号:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtDO_No" runat="server" CssClass="textboxodl" Width="132px"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="rfvDO_No" runat="server" ControlToValidate="txtDO_No"
                                        ErrorMessage="必填" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="Label1" runat="server" Text="产品编号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtProductNo" runat="server" CssClass="textboxodl" Width="132px"
                                        onblur="EnterPress1()"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProductNo"
                                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblProductNo" runat="server" Text="产品描述:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtProductDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                        Width="99%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblMouldNo" runat="server" Text="模具编号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlMouldNo" runat="server" CssClass="textboxodl" Width="132px"
                                        OnSelectedIndexChanged="ddlMouldNo_SelectedIndexChanged">
                                        <asp:ListItem Text="选择" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMouldNo"
                                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CvddlMouldNo" runat="server" ControlToValidate="ddlMouldNo"
                                        ErrorMessage="" ClientValidationFunction="SetMouldNo" Display="Dynamic">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </asp:CustomValidator>
                                    <asp:Button ID="btMould" runat="server" name="" OnClick="btMould_Click" Width="16px" />
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblMachineNo" runat="server" Text="机器编号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="textboxodl" Width="132px"
                                        OnSelectedIndexChanged="ddlMachineNo_SelectedIndexChanged">
                                        <asp:ListItem Text="选择" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMachineNo"
                                        Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CvddlMachineNo" runat="server" ControlToValidate="ddlMachineNo"
                                        ErrorMessage="" ClientValidationFunction="SetMachineNo" Display="Dynamic">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </asp:CustomValidator>
                                    <asp:Button ID="btMachine" runat="server" name="btMachine" OnClick="btMachine_Click"
                                        Width="16px" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblDo_Num" runat="server" Text="派工数量:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtDispatchNum" runat="server" CssClass="textbox" Width="132px" onblur="GetStopDate()"></asp:TextBox>
                                    PCS<asp:RegularExpressionValidator ID="revDo_Num" runat="server" ControlToValidate="txtDispatchNum"
                                        Display="Dynamic" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    <asp:Label ID="Label2" runat="server" Text="模具参考周期:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtStandCycleMould" runat="server" CssClass="textbox" Width="132px"
                                        Enabled="False"></asp:TextBox>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblDispatchDate" runat="server" Text="派工日期:"></asp:Label>
                                </th>
                                <td>
                                    <input id="txtDispatchDate" runat="server" class="textbox" onfocus="setday(this)"
                                        onkeypress="return false" onselectstart="return false;" style="width: 132px"
                                        disabled="true" />
                                    <%-- <asp:RegularExpressionValidator ID="revDispatchDate" runat="server" ControlToValidate="txtDispatchDate"
                                            ErrorMessage="有误" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"
                                            Display="Dynamic"></asp:RegularExpressionValidator></td>--%>
                                    <th align="right">
                                        <asp:Label ID="Label3" runat="server" Text="标准周期:"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtStandCycle" runat="server" CssClass="textbox" Width="132px" onblur="GetStopDate()"></asp:TextBox>
                                        S<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ControlToValidate="txtStandCycle" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>

                                    </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblStartDate" runat="server" Text="计划开始时间:"></asp:Label>
                                </th>
                                <td>
                                    <input runat="server" type="text" id="txtStartDate" name="txtStartDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"
                                        class="Wdate" style="width: 132px" onblur="GetStopDate()" />
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblStopDate" runat="server" Text="计划结束时间:"></asp:Label>
                                </th>
                                <td>
                                    <input runat="server" type="text" id="txtStopDate" name="txtStopDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"
                                        class="Wdate" style="width: 132px" />
                                    <%--    <input id="txtStopDate" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                            onselectstart="return false;" style="width: 132px" />
                                        <input id="Text2" runat="server" class="textbox" maxlength="5" name="txtTime2" oncut="checkPaste()"
                                            ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')" onkeypress="keypress(this,'time')"
                                            onmousemove="checkPaste()" onpaste="checkPaste()" type="text" value="07:20" style="width: 40px" />--%>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    派工单状态</th>
                                <td>
                                    <asp:RadioButtonList ID="rdUrgentSingle" runat="server"
                                        RepeatDirection="Horizontal"
                                        onselectedindexchanged="rdUrgentSingle_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="1">正常单</asp:ListItem>
                                        <asp:ListItem Value="2">急单</asp:ListItem>
                                        <asp:ListItem Value="3">次急单</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right">
                                    &nbsp;</th>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblRemark" runat="server" Text="备注:"></asp:Label>
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" 
                                        TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" 
                                    style="height: 22px; background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;派工明细 
                                </td>
                            </tr>
                        </table>
                        
                        <script language="javascript" type="text/javascript">
                            function EnterPress1() { //传入 event

//                                var e = e || window.event;
//                                if (e.keyCode == 13) {
                                    var ProductNo = document.getElementById("txtProductNo").value;
                                    var ProductRemark = Product_DispatchOrder.GetSearhSetValuesByNew(ProductNo);
                                    _innerTexts(ProductRemark.value, "txtProductDesc");//产品描述
                                    var response = Product_DispatchOrder.GetMouldMstrByNew(ProductNo);
                                    _innerDDl(response.value, "ddlMouldNo");  //模具

                                    document.getElementById("ddlMouldNo").value = response.value;
                                    document.getElementById("Hidden1").value = response.value;
                                    var Machine = Product_DispatchOrder.GetMachineMstr(response.value, ProductNo);
                                    _innerDDl(Machine.value, "ddlMachineNo"); //机器
                                  
                                    var texts = Product_DispatchOrder.GetMachineMstrCycle(response.value, ProductNo);
                                    _innerTexts(texts.value, "txtStandCycleMould");//标准周期
                        
//                                }
                            } 
                        </script>

                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <td align="left">
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        BorderWidth="0px" CellPadding="2" CellSpacing="1" CssClass="itemtable" PageSize="40"
                                        Width="100%">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItemInner" runat="server" /></ItemTemplate>
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="selectAll(this);" type="checkbox" /></HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="26px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号">
                                                <ItemStyle CssClass="hidden" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="select" DataTextField="ActualStartDate" HeaderText="实际开始时间" />
                                            <asp:BoundField DataField="ActualStopDate" HeaderText="实际结束时间" />
                                            <asp:BoundField DataField="WorkOrderNo" HeaderText="工单号" />
                                            <asp:BoundField DataField="DO_No" HeaderText="派工单号" />
                                            <asp:BoundField DataField="ProductNo" HeaderText="产品编号" />
                                            <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                            <asp:BoundField DataField="ProductDesc" HeaderText="产品描述" />
                                            <asp:BoundField DataField="DispatchNum" HeaderText="派工数量" />
                                        </Columns>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
