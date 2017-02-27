<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorDispatchMstr.aspx.cs"
    Inherits="Monitor_MonitorDispatchMstr" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>派工单监视(MonitorDispatchMstr)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

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
                                当前位置:生产监视 -> 派工单监视</td>
                        </tr>
                    </table>
                    <br />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td height="22" style="background-image: url(../images/bg_title.gif)">
                                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 操作</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlQuery" runat="server">
                                            <asp:ListItem Value="DispatchNo">派工单号</asp:ListItem>
                                            <asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
                                            <asp:ListItem Value="MouldNo">模具编号</asp:ListItem>
                                            <asp:ListItem Value="ProductNo">产品编号</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                        派工状态:&nbsp;<asp:DropDownList ID="ddlCheckStatus" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlCheckStatus_SelectedIndexChanged" Width="82px">
                                            <asp:ListItem Value="" Selected="True">选择</asp:ListItem>
                                            <asp:ListItem Value="0">未派工</asp:ListItem>
                                            <asp:ListItem Value="1">已派工</asp:ListItem>
                                            <asp:ListItem Value="2">已完成</asp:ListItem>
                                            <asp:ListItem Value="3">超量生产</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                            OnClick="btnVisible_Click" ImageAlign="Top" />
                                        <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                            OnClick="btnVisible_Click" Visible="False" ImageAlign="Top" Height="24px" 
                                            Width="70px" />
                                        <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                            Visible="False" ImageAlign="Top" />
                                        <asp:TextBox ID="txtID" runat="server" Visible="False" Width="16px"></asp:TextBox>
                                        <input id="hdnID" runat="server" style="width: 10px" type="hidden" /></td>
                                </tr>
                            </table>
                            <br />
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                            <tr>
                                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 浏览</td>
                                            </tr>
                                        </table>
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                            AllowPaging="True" PageSize="15" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable"
                                            BorderWidth="0px" CellSpacing="1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                            ToolTip="1">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号">
                                                    <ItemStyle CssClass="hidden" />
                                                    <HeaderStyle CssClass="hidden" />
                                                    <FooterStyle CssClass="hidden" />
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="DispatchNo" HeaderText="派工单号" />
                                                <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                                <asp:BoundField DataField="MouldNo" HeaderText="模具编号" />
                                                <asp:BoundField DataField="ProductNo" HeaderText="产品编号" />
                                                <asp:BoundField DataField="ProductRemark" HeaderText="产品描述">
                                                    <ItemStyle Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DispatchNum" HeaderText="派工数">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ProductNum" HeaderText="生产数">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GoodQty" HeaderText="良品数">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BadQty" HeaderText="次品数">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StartDate" HeaderText="计划开始时间" Visible="False" />
                                                <asp:BoundField DataField="StopDate" HeaderText="计划结束时间" />
                                                <asp:BoundField DataField="BeginTime" HeaderText="实际开始时间" Visible="False" />
                                                <asp:BoundField DataField="NeedTime" HeaderText="预计完成时间" Visible="False" />
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
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
