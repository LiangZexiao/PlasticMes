<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryManageTotal.aspx.cs" Inherits="BaseInfo_SalaryManage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工资管理(SalaryManage)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" class="section-content">
                <tr>
                    <td valign="top">
                        <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                            <tr>
                                <td style="height: 24px">
                                    当前位置:工资管理 -> 工资统计</td>
                            </tr>
                        </table>
                        
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                    <tr>
                                        <td height="22" style="background-image: url(../images/bg_title.gif)">
                                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 操作</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlQuery" runat="server">
                                                <asp:ListItem Value="EmployeeName">员工姓名</asp:ListItem>
                                                <asp:ListItem Value="CardID">卡号</asp:ListItem>
                                                <asp:ListItem Value="Do_No">派工单号</asp:ListItem>
                                                <asp:ListItem Value="注塑车间">注塑车间</asp:ListItem>
                                                <asp:ListItem Value="植毛车间">植毛车间</asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                            &nbsp;日期:<input runat="server" type="text" id="txtInBeginDate" name="txtInBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 至
                                 <input runat="server" type="text" id="txtInEndDate" name="txtInEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 
                                           
                                            <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                                OnClick="btnVisible_Click" ImageAlign="Top" />
                                            <asp:ImageButton ID="ibgOutPut" runat="server" ImageUrl="~/images/button_export.gif"
                                                OnClick="ImageButton1_Click" ImageAlign="Top" /></td>
                                    </tr>
                                </table>
                                
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                                <tr>
                                                    <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 浏览</td>
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
                                                    <asp:BoundField DataField="EmpID" HeaderText="工号" /> 
                                                    <asp:BoundField DataField="EmployeeName" HeaderText="姓名" /> 
                                                    <asp:BoundField DataField="MachineWage" HeaderText="计件工资"/>
                                                    <asp:BoundField DataField="TimeWage" HeaderText="计时工资"/>
                                                    <asp:BoundField DataField="AdjustWage" HeaderText="调整工资"/>
                                                    <asp:BoundField DataField="TotalWage" HeaderText="小计工资"/>
                                                    <asp:BoundField DataField="CheckWage" HeaderText="考核工资"/>
                                                    <asp:BoundField DataField="JobWage" HeaderText="岗位工资"/>
                                                    <asp:BoundField DataField="ServiceWage" HeaderText="工龄工资"/>
                                                    <asp:BoundField DataField="OtherWage" HeaderText="其它工资"/>
                                                   
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
                                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                            操作</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                            <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                            <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                                OnClick="btnDelete_Click" CausesValidation="false" Visible ="false" />
                                            <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                                CausesValidation="false" />
                                            <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                                            <asp:TextBox ID="txtID" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                
                                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                    <tr>
                                        <td height="22" style="background-image: url(../images/bg_title.gif)">
                                            &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;编辑</td>
                                    </tr>
                                </table>
                                <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                                    cellspacing="1" class="texttable">
                                    <tbody>
                                        <tr>
                                            <th align="right" class="label" style="width: 166px">
                                                <asp:Label ID="Label1" runat="server" Text="姓名:" CssClass="txtlab"></asp:Label></th>
                                            <td style="width: 188px">
                                                <asp:TextBox ID="txtEmployeeName_CN" runat="server" CssClass="textboxodl"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCustomerNo" runat="server" ErrorMessage="必填" ControlToValidate="txtEmployeeName_CN"></asp:RequiredFieldValidator></td>
                                            <th align="right" style="width: 154px">
                                                派工单号:</th>
                                            <td style="width: 209px">
                                                &nbsp;<asp:TextBox ID="txtDo_No" runat="server" CssClass="textbox" Width="113px"></asp:TextBox></td>
                                            <th align="right" style="width: 200px">
                                                </th>
                                            <td>
                                                </td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="height: 26px; width: 166px;">
                                                机器编号:</th>
                                            <td style="height: 26px; width: 188px;">
                                                <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <th align="right" style="height: 26px; width: 154px;">
                                                模具编号:</th>
                                            <td style="height: 26px; width: 209px;">
                                                <asp:TextBox ID="txtMouldNo" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <th align="right" style="height: 26px; width: 200px;">
                                                </th>
                                            <td style="height: 26px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="width: 166px">
                                                产品编号:</th>
                                            <td style="width: 188px">
                                                <asp:TextBox ID="txtProductNo" runat="server" CssClass="textbox"></asp:TextBox></td>
                                            <th align="right" style="width: 154px">
                                                产品描述:</th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtProductDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                                    Width="100%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="width: 166px">
                                                调整机台工资:</th>
                                            <td style="width: 188px">
                                                <asp:TextBox ID="txAdjustWage" runat="server" CssClass="textbox"></asp:TextBox></td>
                                            <th align="right" style="width: 154px">
                                            </th>
                                            <td style="width: 209px">
                                            </td>
                                            <th align="right" style="width: 200px">
                                            </th>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="width: 166px">
                                                </th>
                                            <td style="width: 188px">
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox></td>
                                            <th align="right" style="width: 154px">
                                                </th>
                                            <td style="width: 209px">
                                                <input id="txtBeginDate" runat="server" class="textbox" name="txtBeginDate" onfocus="setday(this)"
                                                    onkeypress="return false" onselectstart="return false;" readonly="readonly" type="text" /><input
                                                        id="Text3" runat="server" class="textbox" maxlength="5" name="txtTime2" oncut="checkPaste()"
                                                        ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')" onkeypress="keypress(this,'time')"
                                                        onmousemove="checkPaste()" onpaste="checkPaste()" style="width: 40px" type="text"
                                                        value="07:20" /></td>
                                            <th align="right" style="width: 200px">
                                                </th>
                                            <td>
                                                &nbsp;<input id="txtEndDate" runat="server" class="textbox" name="txtEndDate" onfocus="setday(this)"
                                                    onkeypress="return false" onselectstart="return false;" readonly="readonly" type="text" />
                                                <input id="Text4" runat="server" class="textbox" maxlength="5" name="txtTime2" oncut="checkPaste()"
                                                    ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')" onkeypress="keypress(this,'time')"
                                                    onmousemove="checkPaste()" onpaste="checkPaste()" style="width: 40px" type="text"
                                                    value="07:20" /></td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="width: 166px; height: 14px">
                                            </th>
                                            <td colspan="5" style="height: 14px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="width: 166px">
                                            </th>
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="width: 166px">
                                                备注:</th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="100%" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
