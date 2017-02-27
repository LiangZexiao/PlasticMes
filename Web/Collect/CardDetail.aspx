<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardDetail.aspx.cs" Inherits="Collect_CardDetail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>刷卡记录(CardDetail)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
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
                var response = Collect_CardDetail.GetSearhItmes(val);
                showQueryDiv(response.value);
                lastVal = val;
            }
            newById = Collect_CardDetail;
            setTimeout('mainLoop()', 100);
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
        <tr>
            <td valign="top">
                <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            当前位置:数据浏览 -> <a id="ICcard" href="CardDetail.aspx" target="main">刷卡记录</a>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(../images/bg_title.gif); height: 17px;">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;操作
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <%--<asp:ListItem Value="rank">职位</asp:ListItem>--%>
                                        <asp:ListItem Value="dispatchNo">派工单号</asp:ListItem>
                                        <asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
                                        <asp:ListItem Value="employeename_cn">员工姓名</asp:ListItem>
                                        <asp:ListItem Value="employeeid">员工编号</asp:ListItem>
                                        <asp:ListItem Value="iccardno">IC卡号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                    <asp:DropDownList ID="ddlMachine_SeatCode" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;刷卡时间:<input runat="server" type="text" id="txtInBeginDate" name="txtInBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 至
                                 <input runat="server" type="text" id="txtInEndDate" name="txtInEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" />     
                                     
                                   <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="../images/btn_search.gif"
                                                        OnClick="btnVisible_Click" ImageAlign="Top" /><asp:ImageButton ID="igbNewadd" runat="server"
                                                            ImageAlign="Top" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" /><asp:ImageButton
                                                                ID="igbCancel" runat="server" ImageAlign="Top" ImageUrl="~/images/btn_delete.gif"
                                                                OnClick="btnDelete_Click" />
                                    <asp:ImageButton ID="imgBtExcel" runat="server" ImageAlign="Top" ImageUrl="~/images/button_export.gif"
                                        OnClick="imgBtExcel_Click" />
                                    <asp:DropDownList ID="ddlCardType" runat="server" Visible="False">
                                        <asp:ListItem Value="0">QC巡检</asp:ListItem>
                                        <asp:ListItem Value="11">待人刷卡</asp:ListItem>
                                        <asp:ListItem Value="12">自定义刷卡</asp:ListItem>
                                        <asp:ListItem Value="1">换摸</asp:ListItem>
                                        <asp:ListItem Value="2">换料</asp:ListItem>
                                        <asp:ListItem Value="3">换单</asp:ListItem>
                                        <asp:ListItem Value="5">机器故障</asp:ListItem>
                                        <asp:ListItem Value="6">模具故障</asp:ListItem>
                                        <asp:ListItem Value="4">辅助故障</asp:ListItem>
                                        <asp:ListItem Value="7">待料</asp:ListItem>
                                        <asp:ListItem Value="8">无定单</asp:ListItem>
                                        <asp:ListItem Value="9">其他</asp:ListItem>
                                        <asp:ListItem Value="10">交班</asp:ListItem>
                                        <asp:ListItem Value="14">上下班</asp:ListItem>
                                        <asp:ListItem Value="15">设置</asp:ListItem>
                                        <asp:ListItem Value="16">修改周期</asp:ListItem>
                                        <asp:ListItem Value="8">F3状态</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td style="background-image: url(../images/bg_title.gif); height: 17px;">
                                                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="0" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable"
                                        BorderWidth="0px" CellSpacing="1" PageSize="15" OnRowCommand="GridView1_RowCommand">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItemInner" runat="server" />
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    <input id="chkAll" type="checkbox" onclick="selectAll(this);" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                                                <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="Detail" DataTextField="dispatchNo" HeaderText="派工单号" />
                                            <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                            <asp:BoundField DataField="employeeid" HeaderText="员工编号" />
                                            <asp:BoundField DataField="employeename_cn" HeaderText="员工姓名" />
                                            <asp:BoundField DataField="iccardno" HeaderText="IC卡号" />
                                            <asp:BoundField DataField="cardtype" HeaderText="刷卡类型" />
                                            <asp:BoundField DataField="begindate" HeaderText="开始时间" />
                                            <asp:BoundField DataField="enddate" HeaderText="结束时间" />
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
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;操作
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
                                    <input id="txtMaxInjectionCycle" type="hidden" runat="server" style="width: 5px"
                                        class="textbox" name="txtMaxInjectionCycle" />
                                    <input id="txtMinInjectionCycle" type="hidden" runat="server" style="width: 5px"
                                        class="textbox" name="txtMinInjectionCycle" />&nbsp;
                                    <asp:TextBox ID="txtID" runat="server" Height="8px" Visible="False" Width="10px"></asp:TextBox>
                                    <input id="hdnBeginDate" type="hidden" runat="server" style="width: 5px" class="textbox"
                                        name="hdnBeginDate" />
                                    <input id="hdnEndDate" type="hidden" runat="server" style="width: 5px" class="textbox"
                                        name="hdnEndDate" />
                                    <input id="hdnCardType" type="hidden" runat="server" style="width: 5px" class="textbox"
                                        name="hdnCardType" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp; 编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right" style="font-weight: bold">
                                    &nbsp;派工单号:
                                </th>
                                <td style="color: #ff0000">
                                    <input id="search" runat="server" autocomplete="off" name="search" style="width: 132px"
                                        type="text" class="textboxodl" disabled="disabled" />

                                    <script language="javascript" type="text/javascript">                                        window.oninit = InitQueryCode("search", "querydiv");</script>

                                    必填
                                </td>
                                <th align="right">
                                    员工编号:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtICCard" runat="server" CssClass="textboxodl" Width="132px" onfocusOut="javascript:SendRequest(this);"></asp:TextBox>&nbsp;<span
                                        id="GetName"></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    刷卡类型:
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" Width="132px">
                                        <asp:ListItem Value="0">次品刷卡</asp:ListItem>
                                        <asp:ListItem Value="11">待人刷卡</asp:ListItem>
                                        <asp:ListItem Value="12">自定义刷卡</asp:ListItem>
                                        <asp:ListItem Value="1">换摸</asp:ListItem>
                                        <asp:ListItem Value="2">换料</asp:ListItem>
                                        <asp:ListItem Value="3">换单</asp:ListItem>
                                        <asp:ListItem Value="5">机器故障</asp:ListItem>
                                        <asp:ListItem Value="6">模具故障</asp:ListItem>
                                        <asp:ListItem Value="4">辅助故障</asp:ListItem>
                                        <asp:ListItem Value="7">待料</asp:ListItem>
                                        <asp:ListItem Value="8">无定单</asp:ListItem>
                                        <asp:ListItem Value="9">其他</asp:ListItem>
                                        <asp:ListItem Value="10">交班</asp:ListItem>
                                        <asp:ListItem Value="13">上班</asp:ListItem>
                                        <asp:ListItem Value="14">下班</asp:ListItem>
                                        <asp:ListItem Value="15">设置</asp:ListItem>
                                        <asp:ListItem Value="16">修改周期</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th align="right">
                                </th>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="height: 26px">
                                    开始时间:
                                </th>
                                <td style="height: 26px">
                                   <input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                     onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                    style="width: 130px" />
                                </td>
                                <th align="right" style="height: 26px">
                                    结束时间:
                                </th>
                                <td colspan="3" style="height: 26px">
                                    <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" />     
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    备注:
                                </th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
                                        Width="99%"></asp:TextBox>
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
