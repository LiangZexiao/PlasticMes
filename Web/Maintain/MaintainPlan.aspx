﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaintainPlan.aspx.cs" Inherits="Maintain_MaintainPlan" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>维护计划(MaintainPlan)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

    <style type="text/css">
        .style1
        {
            color: Blue;
            height: 19px;
        }
        .style2
        {
            height: 19px;
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
                            当前位置:设备管理 -> 维护计划
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <asp:ListItem Value="RepairBillID">维修单号</asp:ListItem>
                                        <asp:ListItem Value="DeviceNo">设备编号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;浏览
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
                                                    <input id="chkAll" onclick="selectAll(this);" type="checkbox" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="26px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号">
                                                <ItemStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="select" DataTextField="RepairBillID" HeaderText="维修单号" />
                                            <asp:BoundField DataField="DeviceType" HeaderText="设备类型" />
                                            <asp:BoundField DataField="DeviceNo" HeaderText="设备编号" />
                                            <asp:BoundField DataField="RepareDate" HeaderText="计划维修日期" />
                                            <asp:BoundField DataField="BeginDate" HeaderText="计划开始时间" />
                                            <asp:BoundField DataField="RepairHour" HeaderText="计划维修时数" />
                                            <asp:BoundField DataField="EndDate" HeaderText="计划结束时间" Visible="False" />
                                            <asp:BoundField DataField="RepairContent" HeaderText="计划维修内容" />
                                            <asp:BoundField DataField="CompleteFlag" HeaderText="完成标志" Visible="False" />
                                            <asp:BoundField DataField="Applier" HeaderText="申请人" Visible="False" />
                                            <asp:BoundField DataField="DutyMan" HeaderText="维修责任人" Visible="False" />
                                            <asp:BoundField DataField="Checker" HeaderText="审核人" Visible="False" />
                                            <asp:BoundField DataField="Remark" HeaderText="备注" />
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
                                                                ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$">
                                                            </asp:RegularExpressionValidator>
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
                                <td style="background-image: url(../images/bg_title.gif); height: 22px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作
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
                                    <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                                    <asp:TextBox ID="txtID" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right" class="style1">
                                    <asp:Label ID="Label1" runat="server" CssClass="txtlab" Text="维修单号:"></asp:Label>
                                </th>
                                <td class="style2">
                                    <asp:TextBox ID="txtRepairBillID" runat="server" CssClass="textboxodl" ReadOnly="true" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRepairBillID" runat="server" ErrorMessage="必填"
                                        ControlToValidate="txtRepairBillID"></asp:RequiredFieldValidator>
                                </td>
                                <th align="right" class="style2">
                                    设备类型:
                                </th>
                                <td class="style2">
                                    <asp:DropDownList ID="ddlDeviceType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDeviceType_SelectedIndexChanged"
                                        CssClass="dropdownlist">
                                        <asp:ListItem Text="机器" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="模具" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="其它" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th align="right" class="style2">
                                    设备编号:
                                </th>
                                <td class="style2">
                                    <asp:DropDownList ID="ddlDeviceNo" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtDeviceNo" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    计划维修日期:
                                </th>
                                <td>
                                    <input id="txtRepareDate" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                        onselectstart="return false;" />
                                    <asp:RegularExpressionValidator ID="revRepareDate" runat="server" ControlToValidate="txtRepareDate"
                                        ErrorMessage="有误" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                  计划开始时间:
                                </th>
                                <td>
                                   <input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})" class="Wdate"
                                   />
                                </td>
                                <th align="right">
                                    计划结束时间:
                                </th>
                                <td>
                                    <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                      onfocus="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})" class="Wdate"
                                    />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    计划维修内容:
                                </th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtRepairContent" runat="server" CssClass="textbox" Width="475px"
                                        Height="45px" TextMode="MultiLine"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    完成标志:
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblCompleteFlag" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem  Value="TRUE">已完成</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="FALSE">未完成</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right">
                                    发送短消息:
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblMessageFlag" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="TRUE">是</asp:ListItem>
                                        <asp:ListItem Value="FALSE">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right" class="style2">
                                    计划维修时数:
                                </th>
                                <td colspan="2"  class="style2">
                                       <asp:TextBox ID="txtRepairHour" runat="server" CssClass="textbox" ></asp:TextBox>H
                                       <asp:RegularExpressionValidator ID="refHour" runat="server"
                                        ControlToValidate="txtRepairHour" ErrorMessage="请输入数字" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    最大模具次数:
                                </th>
                                <td colspan="2">
                                       <asp:TextBox ID="txtMaxMouldNum" runat="server" CssClass="textbox" ></asp:TextBox>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txtMaxMouldNum" ErrorMessage="请输入数字" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                               <td>
                               </td>
                               <td>
                               </td>
                               <td>
                               </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    申请人:
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlApplier" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>
                                </td>
                                <th align="right">
                                    维修责任人:
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlDutyMan" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>
                                </td>
                                <th align="right">
                                    审核人:
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlChecker" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    备注:
                                </th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="475px" Height="45px"
                                        TextMode="MultiLine"></asp:TextBox>
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
