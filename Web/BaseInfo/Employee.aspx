﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="BaseInfo_Employee" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工管理(Employee)</title>
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
                            当前位置:基础资料 -> 员工管理
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
                                        <asp:ListItem Value="EmployeeID">员工编号</asp:ListItem>
                                        <asp:ListItem Value="DeptName">部门</asp:ListItem>
                                        <asp:ListItem Value="RankDesc">职位</asp:ListItem>
                                        <asp:ListItem Value="IcCardNo">IC卡号</asp:ListItem>
                                        <asp:ListItem Value="EmployeeName_CN">姓名</asp:ListItem>
                                        <asp:ListItem Value="Invalid">卡状态</asp:ListItem>
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
                                            <asp:ButtonField DataTextField="EmployeeID" CommandName="select" HeaderText="员工编号" />
                                            <asp:BoundField DataField="IcCarid" HeaderText="IC卡号" />
                                            <asp:BoundField DataField="EmployeeName_CN" HeaderText="姓名" />
                                            <asp:BoundField DataField="DeptName" HeaderText="部门" />
                                            <asp:BoundField DataField="RankDesc" HeaderText="职位" />
                                            <asp:BoundField DataField="IDCardNo" Visible="False" HeaderText="身份证号" />
                                            <asp:BoundField DataField="Sex" HeaderText="性别" />
                                            <%--  <asp:BoundField DataField="Birthday" DataFormatString="{0:d}"  HtmlEncode="False" HeaderText="出生日期" />--%>
                                            <asp:BoundField DataField="RankLevel" Visible="False" HeaderText="职位等级" />
                                            <asp:BoundField DataField="Province" Visible="False" HeaderText="籍贯" />
                                            <asp:BoundField DataField="RankDesc" Visible="False" HeaderText="职位描述" />
                                            <asp:BoundField DataField="HireDate" DataFormatString="{0:d}" HtmlEncode="False"
                                                HeaderText="发卡日期" />
                                            <asp:BoundField DataField="IcCardRight" HeaderText="权限" />
                                            <asp:BoundField DataField="Invalid" HeaderText="卡状态" />
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
                        <br>
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
                                    <asp:Label ID="lblEmployeeID" runat="server" Text="员工编号:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtEmployeeID" runat="server" CssClass="textboxodl"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmployeeID" runat="server" ControlToValidate="txtEmployeeID"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>&nbsp;
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblName_CN" runat="server" Text="姓名:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:TextBox ID="txtName_CN" runat="server" CssClass="textboxodl"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName_CN"
                                        ErrorMessage="必填"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Width="5px" Visible="False"></asp:TextBox>
                                    <input id="hdnID" type="hidden" runat="server" style="width: 16px" class="textbox" />
                                </td>
                                <td align="center" rowspan="7">
                                    <asp:Image ID="Image1" runat="server" Height="118px" Width="107px" />&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lab1" runat="server" Text="IC卡号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txticcard" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblName_EN" runat="server" Text="英文名:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:TextBox ID="txtName_EN" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblIDCardNo" runat="server" Text="身份证号:" CssClass="txtlable"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIDCardNo" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularE1" runat="server" ErrorMessage="错误" ControlToValidate="txtIDCardNo"
                                        ValidationExpression="\d{17}[\d|X]|\d{15}" Width="25px"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblDepartment" runat="server" Text="部门:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblSex" runat="server" Text="性别:"></asp:Label>
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" CssClass="dropdownlist"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                                        <asp:ListItem Value="女">女</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblBirthday" runat="server" Text="出生日期:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <input id="txtBirthday" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                        onselectstart="return false;" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblRank" runat="server" Text="职位:"></asp:Label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlRank" runat="server" CssClass="dropdownlist" Enabled="false">
                                        <asp:ListItem Value="">选择</asp:ListItem>
                                        <asp:ListItem Value="1">操作工</asp:ListItem>
                                        <asp:ListItem Value="2">加料</asp:ListItem>
                                        <asp:ListItem Value="3">机修</asp:ListItem>
                                        <asp:ListItem Value="4">领班</asp:ListItem>
                                        <asp:ListItem Value="5">质检</asp:ListItem>
                                        <asp:ListItem Value="6">管理员</asp:ListItem>
                                        <asp:ListItem Value="7">其它</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblGroup" runat="server" Text="员工等级:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:DropDownList ID="ddlRankLevel" runat="server" CssClass="dropdownlist" Width="122px">
                                        <asp:ListItem value="0">选择</asp:ListItem>
                                        <asp:ListItem Value="1">A级</asp:ListItem>
                                        <asp:ListItem Value="2">B级</asp:ListItem>
                                        <asp:ListItem Value="3">C级</asp:ListItem>
                                        <asp:ListItem Value="4">D级</asp:ListItem>
                                        <asp:ListItem Value="5">E级</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblProvince" runat="server" Text="籍贯:"></asp:Label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="dropdownlist">
                                        <asp:ListItem Value="01">广东</asp:ListItem>
                                        <asp:ListItem Value="02">上海</asp:ListItem>
                                        <asp:ListItem Value="03">北京</asp:ListItem>
                                        <asp:ListItem Value="04">天津</asp:ListItem>
                                        <asp:ListItem Value="05">河北</asp:ListItem>
                                        <asp:ListItem Value="06">山西</asp:ListItem>
                                        <asp:ListItem Value="07">内蒙古</asp:ListItem>
                                        <asp:ListItem Value="08">辽宁</asp:ListItem>
                                        <asp:ListItem Value="09">吉林</asp:ListItem>
                                        <asp:ListItem Value="10">黑龙江</asp:ListItem>
                                        <asp:ListItem Value="11">江苏</asp:ListItem>
                                        <asp:ListItem Value="12">浙江</asp:ListItem>
                                        <asp:ListItem Value="13">安徽</asp:ListItem>
                                        <asp:ListItem Value="14">福建</asp:ListItem>
                                        <asp:ListItem Value="15">江西</asp:ListItem>
                                        <asp:ListItem Value="16">山东</asp:ListItem>
                                        <asp:ListItem Value="17">河南</asp:ListItem>
                                        <asp:ListItem Value="18">湖北</asp:ListItem>
                                        <asp:ListItem Value="19">湖南</asp:ListItem>
                                        <asp:ListItem Value="20">广西</asp:ListItem>
                                        <asp:ListItem Value="21">四川</asp:ListItem>
                                        <asp:ListItem Value="22">贵州</asp:ListItem>
                                        <asp:ListItem Value="23">云南</asp:ListItem>
                                        <asp:ListItem Value="24">西藏</asp:ListItem>
                                        <asp:ListItem Value="25">陕西</asp:ListItem>
                                        <asp:ListItem Value="26">甘肃</asp:ListItem>
                                        <asp:ListItem Value="27">青海</asp:ListItem>
                                        <asp:ListItem Value="28">宁夏</asp:ListItem>
                                        <asp:ListItem Value="29">新疆</asp:ListItem>
                                        <asp:ListItem Value="30">香港</asp:ListItem>
                                        <asp:ListItem Value="31">台湾</asp:ListItem>
                                        <asp:ListItem Value="32">澳门</asp:ListItem>
                                        <asp:ListItem Value="33">重庆</asp:ListItem>
                                        <asp:ListItem Value="34">海南</asp:ListItem>
                                        <asp:ListItem Value="35">国外</asp:ListItem>
                                        <asp:ListItem Value="36">其他</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblCard" runat="server" Text="卡状态:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:DropDownList ID="ddlCard" runat="server" CssClass="dropdownlist" Width="122px">
                                        <asp:ListItem Value="">选择</asp:ListItem>
                                        <asp:ListItem Value="0">已注销</asp:ListItem>
                                        <asp:ListItem Value="1">正常</asp:ListItem>
                                        <asp:ListItem Value="2">已挂失</asp:ListItem>
                                        <asp:ListItem Value="3">解除挂失</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblHireDate" runat="server" Text="雇佣日期:"></asp:Label>
                                </th>
                                <td>
                                    <input id="txtHireDate" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                        onselectstart="return false;" /><asp:CompareValidator ID="CompareValidator1" runat="server"
                                            ControlToCompare="txtBirthday" ControlToValidate="txtHireDate" Display="Dynamic"
                                            ErrorMessage="出生要大于雇佣日期" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblPhoto" runat="server" Text="相片:"></asp:Label>
                                </th>
                                <td style="width: 283px">
                                    <asp:FileUpload ID="fudPhoto" runat="server" CssClass="textbox" Width="192px" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="labTel" runat="server" Text="手机号码:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtTel" runat="server" CssClass="textbox"></asp:TextBox>
                                    <%--<asp:RegularExpressionValidator
                                        ID="revTel" runat="server" ControlToValidate="" ErrorMessage="错误" ValidationExpression="(\d{3}-\d{8}|\d{4}-\d{7})|(^((\(\d{3}\))|(\d{3}\-))?13[0-9]\d{8}|15[0-9]\d{8})"></asp:RegularExpressionValidator>
                              --%>  </td>
                                <th align="right">
                                    Email:
                                </th>
                                <td style="width: 283px">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="有误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
