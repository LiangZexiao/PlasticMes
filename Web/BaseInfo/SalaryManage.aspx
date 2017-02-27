﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryManage.aspx.cs" Inherits="BaseInfo_SalaryManage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工资管理(SalaryManage)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script language="javascript" type="text/javascript">
        function GetEmpNameByNo(sender, args) {
            var txtNo = args.Value;
            var arryList = BaseInfo_SalaryManage.getSearchEmpName(txtNo);

            if (arryList.value=="") {
                document.getElementById("txtEmpNo").value = "";
                document.getElementById("txtEmpNo").focus();
                document.getElementById("txtEmpNo").select();
                window.alert("无此员工信息!");
                args.isvalid = false;
            }
            else {
                document.getElementById("txtEmpName").innerText = arryList.value[0];
                form1.txtHiddenEmpName.value = arryList.value[0];
                args.isvalid = true;
            }
        }
   </script>

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
                                    当前位置:工资管理 -> 计件计时工资</td>
                            </tr>
                        </table>
                        <br>
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

                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                            &nbsp;日期:<input runat="server" type="text" id="txtInBeginDate" name="txtInBeginDate"  
                                                onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                                        style="width: 130px" /> 至
                                                <input runat="server" type="text" id="txtInEndDate" name="txtInEndDate"  
                                                    onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                                    style="width: 130px" /> 

                                            <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                                OnClick="btnVisible_Click" ImageAlign="Top" style="height: 24px" />
                                            <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                                OnClick="btnVisible_Click" ImageAlign="Top" Height="24px" />
                                            <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                                OnClick="btnDelete_Click" ImageAlign="Top" Visible = "false"　 
                                                Height="24px"/>
                                            <asp:Button ID="btnInsert" runat="server" OnClick="Button1_Click" Text="生成工资" />
                                            <asp:ImageButton ID="ibgOutPut" runat="server" ImageUrl="~/images/button_export.gif"
                                                OnClick="ImageButton1_Click" ImageAlign="Top" /></td>
                                    </tr>
                                </table>
                                <br>
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
                                                    <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号">
                                                        <ItemStyle CssClass="hidden" />
                                                        <HeaderStyle CssClass="hidden" />
                                                        <FooterStyle CssClass="hidden" />
                                                    </asp:ButtonField>
                                                    <asp:BoundField DataField="EmpID" HeaderText="工号" />   
                                                    <asp:BoundField DataField="EmployeeName" HeaderText="姓名" />                                                    
                                                    <asp:BoundField DataField="Do_No" HeaderText="派工单号" />
                                                    <asp:BoundField DataField="BeginDate" HeaderText="刷卡开始时间" />
                                                    <asp:BoundField DataField="EndDate" HeaderText="刷卡结束时间" />

                                                    <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                                    <asp:BoundField DataField="MouldNo" HeaderText="模具编号" Visible="False" />
                                                    <asp:BoundField DataField="ProductNo" HeaderText="产品编号" />
                                                    <asp:BoundField DataField="ProductDesc" HeaderText="产品描述"/>
                                                    <asp:BoundField DataField="Num" HeaderText="数量"/>
                                                   
                                                    
                                                    <asp:BoundField DataField="MachineWage" HeaderText="计件工资"/>
                                                    <asp:BoundField DataField="TimeWage" HeaderText="计时工资"/>
                                                    <asp:BoundField ItemStyle-Width = "10%" DataField="Remark" HeaderText="备注" />
                                                   
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
                                                OnClick="btnDelete_Click" CausesValidation="false" Visible = "false" />
                                            <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                                CausesValidation="false" />
                                            <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                                            <asp:TextBox ID="txtID" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                                             <asp:HiddenField ID="txtHiddenEmpName" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <br>
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
                                            <th align="right" class="label">
                                                <asp:Label ID="Label1" runat="server" Text="工号:" CssClass="txtlab"></asp:Label></th>
                                            <td style="width: 290px">
                                            <input id="txtEmpID" runat="server" autocomplete="off" name="txtEmpID"
                                                        type="text" class="textboxodl"/>
                                                <asp:TextBox ID="txtEmpName" runat="server" CssClass="textboxodl" ReadOnly="true" ></asp:TextBox>
<%--                                                <asp:RequiredFieldValidator ID="rfvCustomerNo" runat="server" ErrorMessage="必填" ControlToValidate="txtEmpID"></asp:RequiredFieldValidator>
--%>                                                 <asp:CustomValidator ID="CvtxtEmpID" runat="server" ControlToValidate="txtEmpID"
                                                         ErrorMessage="无此员工信息" 
                                                         ClientValidationFunction="GetEmpNameByNo"  Display="Dynamic">
                                                 </asp:CustomValidator>
                                                </td>
                                            <th align="right">
                                                车间:</th>
                                            <td style="width: 209px">
                                                <asp:DropDownList ID="ddlWorkShop" runat="server" Width="160px">
                                                <asp:ListItem Value="注一车间">注一车间</asp:ListItem>
                                                <asp:ListItem Value="注二车间">注二车间</asp:ListItem>
                                                <asp:ListItem Value="注三车间">注三车间</asp:ListItem>
                                                <asp:ListItem Value="植毛-注塑">植毛-注塑</asp:ListItem>
                                                <asp:ListItem Value="植毛-植毛">植毛-植毛</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <th align="right">
                                                </th>
                                            <td>
                                                </td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="height: 26px">
                                                开始时间:</th>
                                            <td style="width: 290px; height: 26px">
                                               <input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                                    onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                                    style="width: 130px" /> 
                                               </td>
                                            <th align="right" style="height: 26px">
                                                结束时间:</th>
                                            <td style="width: 209px; height: 26px">
                                             <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                                onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                                style="width: 160px" />
                                              </td>
                                            <th align="right" style="height: 26px">
                                                计时工资:</th>
                                            <td style="height: 26px">
                                                <asp:TextBox ID="txtTimeWage" runat="server" Width="119px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th align="right" style="height: 26px">
                                                </th>
                                            <td style="height: 26px; width: 290px;">
                                                &nbsp;</td>
                                            <th align="right" style="height: 26px">
                                                </th>
                                            <td style="height: 26px; width: 209px;">
                                                &nbsp;</td>
                                            <th align="right" style="height: 26px">
                                                </th>
                                            <td style="height: 26px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th align="right">
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
