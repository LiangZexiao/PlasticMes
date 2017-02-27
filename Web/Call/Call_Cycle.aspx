﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Call_Cycle.aspx.cs" Inherits="Call_Call_Cycle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>异常消息设置(Call_Cycle)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>

    <script language="JavaScript" type="text/javascript">
        function moveOption(e1, e2) {
            try {
                if (e2.id == "Select2") {
                    for (var i = 0; i < e1.options.length; i++) {
                        if (e1.options[i].selected) {
                            var e = e1.options[i];
                            for (var j = 0; j < e2.options.length; j++) {
                                var sel2 = e2.options[j];
                                if (sel2.value == e.value) {
                                    e2.remove(j);
                                }
                            }
                            e2.options.add(new Option(e.text, e.value));
                            //  e1.remove(i); 
                            //i=i-1 ;    
                        }
                    }
                }
                else {
                    for (var i = 0; i < e1.options.length; i++) {
                        if (e1.options[i].selected) {

                            // e2.options.add(new Option(e.text, e.value)); 
                            e1.remove(i);
                            i = i - 1;
                        }
                    }
                }
                if (e2.id == "Select2") {
                    document.form1.hdnemp.value = getvalue(e2);
                    // alert( getvalue(e2));
                } else {
                    document.form1.hdnemp.value = getvalue(e1);
                    //alert( getvalue(e1));
                }
            }
            catch (e) { }
        }
        function moveOption2(e1, e2) {
            try {
                for (var i = 0; i < e1.options.length; i++) {

                    var e = e1.options[i];
                    for (var j = 0; j < e2.options.length; j++) {
                        var sel2 = e2.options[j];
                        if (sel2.value == e.value) {
                            e2.remove(j);
                        }
                    }

                    e2.options.add(new Option(e.text, e.value));
                    if (e1.id == "Select2") {
                        e1.remove(i);
                        i = i - 1;
                    }
                }
                if (e2.id == "Select2") {
                    document.form1.hdnemp.value = getvalue(e2);
                    //alert( getvalue(e2));
                } else {
                    document.form1.hdnemp.value = getvalue(e1);
                    //alert( getvalue(e1));
                }
                // document.form1.hdnemp.value=getvalue(document.form1.Select2);

            }
            catch (e) { }
        }
        function getvalue(geto) {
            var allvalue = "";
            for (var i = 0; i < geto.options.length; i++) {
                if (i != (geto.options.length - 1))
                    allvalue += geto.options[i].value + ",";
                else
                    allvalue += geto.options[i].value;
            }
            return allvalue;
        }
    </script>

    <style type="text/css">
        .style2
        {
            width: 284px;
        }
        .style3
        {
            width: 245px;
            height: 26px;
        }
        .style4
        {
            width: 217px;
        }
        .style5
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content" style="padding-right: 0px;
        margin-top: 0px; margin-left: 0px; width: 100%; padding-top: 0px">
        <tr>
            <td valign="top" style="padding-right: 0px; margin-top: 0px; margin-left: 0px; padding-top: 0px;
                width: 100%; padding-left: 0px;">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(../images/bg_title.gif); height: 19px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                        </table>
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" Width="112px">
                                        <asp:ListItem Value="">选择</asp:ListItem>
                                        <asp:ListItem Value="1">人工周期异常</asp:ListItem>
                                        <asp:ListItem Value="8">机器周期异常</asp:ListItem>
                                        <asp:ListItem Value="2">压力异常</asp:ListItem>
                                        <asp:ListItem Value="3">温度异常</asp:ListItem>
                                        <asp:ListItem Value="4">停机异常</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlQuery" runat="server" Width="96px">
                                        <asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="btnNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                    <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="5px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td style="background-image: url(../images/bg_title.gif); height: 18px;">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="12" CssClass="itemtable" OnRowDataBound="GridView1_RowDataBound"
                                        BorderWidth="0px" CellSpacing="1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
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
                                                <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField DataTextField="MachineNo" CommandName="select" HeaderText="机器编号" />
                                            <asp:BoundField DataField="CallStr" HeaderText="异常消息类型" />
                                            <asp:BoundField DataField="UnitType" HeaderText="检索单位" />
                                            <asp:BoundField DataField="UnitValue" HeaderText="检索周期" />
                                            <asp:BoundField DataField="CallValue" HeaderText="异常次数" />
                                            <asp:BoundField DataField="CreateTime" HeaderText="创建时间"></asp:BoundField>
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
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(../images/bg_title.gif); height: 19px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作
                                </td>
                            </tr>
                        </table>
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="height: 28px">
                                    <asp:ImageButton ID="btnInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" CausesValidation="False" />
                                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(../images/bg_title.gif); height: 17px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMachineNo" runat="server" Text="报警类型:" CssClass="txtlab"></asp:Label>
                                </td>
                                <td style="width: 284px" colspan="2">
                                    <asp:DropDownList ID="ddlExecute" runat="server" CssClass="textboxodl" Width="127px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlExecute_SelectedIndexChanged">
                                        <asp:ListItem>选择</asp:ListItem>
                                        <asp:ListItem Value="1">人工周期异常</asp:ListItem>
                                        <asp:ListItem Value="8">机器周期异常</asp:ListItem>
                                        <asp:ListItem Value="2">压力异常</asp:ListItem>
                                        <asp:ListItem Value="3">温度异常</asp:ListItem>
                                        <asp:ListItem Value="4">停机异常</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlExecute"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                    <input id="hdnemp" runat="server" style="width: 1px" type="hidden" />
                                    <input id="hdnID" runat="server" style="width: 5px" type="hidden" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="车间编号:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlWorkShop" runat="server" CssClass="textboxodl" AutoPostBack="true"
                                        Width="127px" onselectedindexchanged="ddlWorkShop_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvWorkShop" runat="server" ControlToValidate="ddlWorkShop"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFileNO" runat="server" Text="异常时间:"></asp:Label>
                                </td>
                                <td colspan="2" class="style2">
                                    <asp:TextBox ID="txtCycle" runat="server" CssClass="textboxodl" EnableViewState="False"></asp:TextBox>
                                    分钟<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCycle"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="Regularr1"
                                            runat="server" ControlToValidate="txtCycle" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblMachine" runat="server" Text="机器编号:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="textbox" Width="127px">
                                    </asp:DropDownList>
                                    &nbsp;
                                    <input id="Hidden1" runat="server" style="width: 1px" type="hidden" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style5">
                                    <asp:Label ID="lblFileName" runat="server" Text="异常次数:"></asp:Label>
                                </td>
                                <td colspan="2" class="style5">
                                    <asp:TextBox ID="txtNum" runat="server" CssClass="textbox" EnableViewState="False"
                                        Enabled="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="Regular2" runat="server" ControlToValidate="txtNum"
                                        ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                </td>
                                <td align="right" class="style5">
                                    <asp:Label ID="lblBc" runat="server" Text="班次类型:"></asp:Label>
                                </td>
                                <td class="style3" colspan="2">
                                    <asp:DropDownList ID="ddlBc" runat="server" CssClass="textboxodl" Width="127px">
                                        <asp:ListItem>选择</asp:ListItem>
                                        <asp:ListItem Value="AC">白班</asp:ListItem>
                                        <asp:ListItem Value="BC">夜班</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvBc" runat="server" ControlToValidate="ddlBc" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="labnum" runat="server" Text="发送次数:"></asp:Label>
                                </td>
                                <td class="style2" colspan="2">
                                    <asp:TextBox ID="txtsend" runat="server" CssClass="textbox" EnableViewState="False">1</asp:TextBox>
                                    条<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txtsend" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="报警上限:"></asp:Label>
                                </td>
                                <td colspan="2" style="width: 284px">
                                    <asp:TextBox ID="txtmax" runat="server" CssClass="textbox" EnableViewState="False"
                                        Enabled="true"></asp:TextBox>
                                    %<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="txtmax" ErrorMessage="请输入数字" ValidationExpression="\d+(\.\d+)?$"
                                        Display="Static"></asp:RegularExpressionValidator>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="报警下限:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmin" runat="server" CssClass="textbox" Enabled="true" EnableViewState="False"></asp:TextBox>
                                    %<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                        ControlToValidate="txtmin" Display="Static" ErrorMessage="请输入数字" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 92px">
                                    <asp:Label ID="Label3" runat="server" Text="短信接收人员:"></asp:Label>
                                </td>
                                <td align="left" valign="middle" class="style4">
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="182px" Width="92px">
                                    </asp:CheckBoxList>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Height="182px"
                                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Visible="False"
                                        Width="92px">
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right" style="width: 28px" valign="top">
                                    <select id="Select1" runat="server" multiple style="height: 280px; width: 125px;">
                                    </select>
                                </td>
                                <td align="center" style="height: 92px">
                                    <a onclick="moveOption2(document.form1.Select1, document.form1.Select2)" style="cursor: hand"
                                        title="全部导入">
                                        <asp:Label ID="Label1" runat="server" Text="&gt;&gt;&gt;&gt;"></asp:Label>
                                        <asp:Button ID="Button1" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
                                            CausesValidation="False" CssClass="dropdownlist" OnClick="Button1_Click" Text="&gt;&gt;&gt;&gt;"
                                            Width="42px" />
                                    </a>
                                    <br />
                                    <br />
                                    <a onclick="moveOption(document.form1.Select1, document.form1.Select2)" style="cursor: hand"
                                        title="单个导入">
                                        <asp:Label ID="Label6" runat="server" Text="&gt;&gt;"></asp:Label>
                                        <asp:Button ID="Button2" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
                                            CausesValidation="False" CssClass="dropdownlist" OnClick="Button1_Click" Text="&gt;&gt;"
                                            Width="42px" />
                                    </a>
                                    <br />
                                    <br />
                                    <a onclick="moveOption(document.form1.Select2, document.form1.Select1)" style="cursor: hand"
                                        title="单个导出">
                                        <asp:Label ID="Label7" runat="server" Text="&lt;&lt;"></asp:Label>
                                        <asp:Button ID="Button3" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
                                            CausesValidation="False" CssClass="dropdownlist" OnClick="Button1_Click" Text="&lt;&lt;"
                                            Width="42px" />
                                    </a>
                                    <br />
                                    <br />
                                    <a onclick="moveOption2(document.form1.Select2, document.form1.Select1)" style="cursor: hand"
                                        title="全部导出">
                                        <asp:Label ID="Label8" runat="server" Text="&lt;&lt;&lt;&lt;"></asp:Label>
                                        <asp:Button ID="Button4" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
                                            CausesValidation="False" CssClass="dropdownlist" OnClick="Button1_Click" Text="&lt;&lt;&lt;&lt;"
                                            Width="42px" />
                                    </a>
                                </td>
                                <td style="height: 92px" valign="top">
                                    <select id="Select2" runat="server" multiple style="height: 279px; width: 125px;">
                                    </select>
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
