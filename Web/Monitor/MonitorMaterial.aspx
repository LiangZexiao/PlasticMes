﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorMaterial.aspx.cs"
    Inherits="Monitor_MonitorMaterial" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物料监视(MonitorMaterial)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
        <tr>
            <td valign="top">
                <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            当前位置:生产监视 -> 物料监视
                        </td>
                    </tr>
                </table>
                <table width="100%" id="Tinf" runat="server" border="0" align="center" cellpadding="0"
                    cellspacing="0" bordercolor="#00ff00">
                    <tr>
                        <td height="23" class="tabPageFont" background="../images/tab_on.gif" style="cursor: hand;
                            width: 78px" align="center">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click">用料查看</asp:LinkButton>
                        </td>
                        <td class="tabPageFont" background="../images/tab_off.gif" style="cursor: hand; width: 78px"
                            align="center">
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click">详细原料查看</asp:LinkButton>
                        </td>
                        <td width="460" background="../images/topline_bg.gif">
                            <input id="Hidden1" type="hidden" value="0ccccccccccccccccccc" runat="server" style="" />
                        </td>
                        <td width="460" background="../images/topline_bg.gif">
                            <input id="Hidden2" type="hidden" value="0cccccccccccccccccccccc" runat="server"
                                style="" />
                        </td>
                        <td background="../images/topline_bg.gif">
                            <input id="hdnTargetss" type="hidden" value="QualityTrack_Cycle" runat="server" style="width: 1px" />
                            <input id="hdnCellIndexss" type="hidden" value="0" runat="server" style="width: 12px" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <asp:ListItem Value="DispatchNo">派工单号</asp:ListItem>
                                        <asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
                                        <asp:ListItem Value="MouldNo">模具编号</asp:ListItem>
                                        <asp:ListItem Value="ProductNo">产品编号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;派工状态:&nbsp;<asp:DropDownList
                                        ID="ddlCheckStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCheckStatus_SelectedIndexChanged"
                                        Width="82px">
                                        <asp:ListItem Value="" Selected="True">选择</asp:ListItem>
                                        <asp:ListItem Value="0">未派工</asp:ListItem>
                                        <asp:ListItem Value="1">已派工</asp:ListItem>
                                        <asp:ListItem Value="2">已完成</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" Visible="False" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        Visible="False" ImageAlign="Top" />&nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable"
                                        BorderWidth="0px" CellSpacing="1" ToolTip="1" PageSize="13">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="DispatchOrderNo" HeaderText="派工单号" />
                                            <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                            <asp:BoundField DataField="MouldNo" HeaderText="模具编号" />
                                            <asp:BoundField DataField="ProductNo" HeaderText="产品编号" />
                                            <asp:BoundField DataField="ProductDesc" HeaderText="产品描述">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MaterialCode" HeaderText="原料编号">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProductNum" HeaderText="生产数">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalWeight" HeaderText="用料(g)">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalGrassWeight" HeaderText="水口(g)">
                                                <ItemStyle HorizontalAlign="Right" />
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
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                            <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                            <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex"
                                                                ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
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
                </asp:MultiView>
                <asp:MultiView ID="MultiView2" runat="server">
                    <asp:View ID="View2" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery2" runat="server">
                                        <asp:ListItem Value="RawNo">原料编号</asp:ListItem>
                                        <asp:ListItem Value="RawName">原料名称</asp:ListItem>
                                        <asp:ListItem Value="RawBrand">供应商</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="tbQuery" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;日期:<input
                                        runat="server" type="text" id="inStartDate" name="txtBeginDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"
                                        class="Wdate" style="width: 130px" />
                                    至
                                    <input runat="server" type="text" id="inEndDate" name="inEndDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"
                                        class="Wdate" style="width: 130px" />
                                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btn_search.gif"
                                        ImageAlign="Top" OnClick="ImageButton1_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable"
                                        BorderWidth="0px" CellSpacing="1" ToolTip="1" PageSize="12">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="RawNo" HeaderText="原料编号" />
                                            <asp:BoundField DataField="RawName" HeaderText="原料名称" />
                                            <asp:BoundField DataField="RawModel" HeaderText="原料型号" />
                                            <asp:BoundField DataField="RawBrand" HeaderText="供应商">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RawColor" HeaderText="原料颜色" />
                                            <asp:BoundField DataField="ProductNum" HeaderText="生产数">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalWeight" HeaderText="用料(g)">
                                                <ItemStyle HorizontalAlign="Right" />
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
                                                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif"
                                                                OnClick="ClickPageInfo_Click" ImageAlign="Top" />
                                                            <asp:ImageButton ID="ibPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                                                OnClick="ClickPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                                                OnClick="ClickPageInfo_Click" ImageAlign="Top" />
                                                            <asp:ImageButton ID="ibLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                                                OnClick="ClickPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif"
                                                                OnClick="ClickPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbPageIndex"
                                                                ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
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
                </asp:MultiView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
