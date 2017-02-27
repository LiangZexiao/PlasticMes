<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RawMaterial.aspx.cs" Inherits="BaseInfo_RawMaterial" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>原料管理(RawMaterial)</title>
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
                            当前位置:基础资料 -> 原料管理
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <asp:ListItem Value="RawNo">原料编号</asp:ListItem>
                                        <asp:ListItem Value="RawName">原料名称</asp:ListItem>
                                        <asp:ListItem Value="RawBrand">供应商</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                    <input id="hdnID" runat="server" type="hidden" style="width: 15px" />
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                        PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px"
                                        CellSpacing="1">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItemInner" runat="server" />
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    <input id="chkAll" type="checkbox" onclick="selectAll(this);" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="26px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                                                <ItemStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField DataTextField="RawNo" CommandName="select" HeaderText="原料编号" />
                                            <asp:BoundField DataField="RawName" HeaderText="原料名称" />
                                            <asp:BoundField DataField="RawModel" HeaderText="原料型号" />
                                            <asp:BoundField DataField="RawBrand" HeaderText="供应商">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="spec" HeaderText="规格(KG/包)" />
                                            <asp:BoundField DataField="RawColor" HeaderText="原料颜色" />
                                            <asp:BoundField DataField="Memo" HeaderText="备注">
                                                <ItemStyle Width="200px" />
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
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" CausesValidation="false" />
                                    <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" />
                                    <input id="Hidden1" type="hidden" runat="server" style="width: 20px" class="textbox" /><asp:TextBox
                                        ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lab1" runat="server" Text="原料编号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="tbRawNo" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRawNo" runat="server" ControlToValidate="tbRawNo"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtID" Visible="false" runat="server" Width="10px"></asp:TextBox>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblName_EN" runat="server" Text="原料名称:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:TextBox ID="tbRawName" runat="server" CssClass="textboxodl"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRawName" runat="server" ControlToValidate="tbRawName"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblRawModel" runat="server" Text="原料型号:" CssClass="txtlable"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="tbRawModel" runat="server" CssClass="textboxodl"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="rfvRawModel" runat="server" ControlToValidate="tbRawModel"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblRawBrand" runat="server" Text="原料品牌:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:TextBox ID="tbRawBrand" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="labTel" runat="server" Text="规格:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="tbSpec" runat="server" CssClass="textboxodl"></asp:TextBox>KG/包
                                    <asp:RequiredFieldValidator ID="rfvSpec" runat="server" ControlToValidate="tbSpec"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="tbSpec"
                                        Display="Static" ErrorMessage="有误" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    颜色:
                                </th>
                                <td style="width: 283px">
                                    <asp:TextBox ID="tbRawColor" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblMemo" runat="server" Text="备注:"></asp:Label>
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtMemo" runat="server" CssClass="textbox" TextMode="MultiLine"
                                        Width="550px"></asp:TextBox>
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
