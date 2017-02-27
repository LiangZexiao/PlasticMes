<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffPrice.aspx.cs" Inherits="Administrator_StaffPrice" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1"  runat="server">
 <title>员工记件工资查询</title>
       <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">

          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">
                    当前位置:系统管理->记件工资查询</td>
           </tr>
          </table>
          <br />
    <asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
     <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                <td style="background-image: url(../images/bg_title.gif); height: 18px;" colspan="3">　　操作</td>
           </tr>
                  <tr>
                      <td colspan="3" style="height: 21px">
                    <asp:DropDownList ID="ddlquery" runat="server" Width="78px">
                    <asp:ListItem Value="">选择</asp:ListItem>
                        <asp:ListItem Value="员工">姓名</asp:ListItem>
                        <asp:ListItem Value="产品编号">产品编号</asp:ListItem>
                        <asp:ListItem Value="派工单号">派工单号</asp:ListItem>
                    </asp:DropDownList><asp:TextBox ID="txtname" runat="server" Width="77px"></asp:TextBox>
                          入库时间
            <input id="txtProductDatePlanStart" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                    onselectstart="return false;" style="width: 77px" />
                        <input id="txtTime_1" runat="server" class="textbox" maxlength="5" name="txtTime2"
                    oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                    onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                    style="width: 40px" type="text" value="07:20" />
                至
            <input id="txtProductDatePlanEnd" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                    onselectstart="return false;" style="width: 77px" />
                        <input id="txtTime_2" runat="server" class="textbox" maxlength="5" name="txtTime2" oncut="checkPaste()"
                    ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')" onkeypress="keypress(this,'time')"
                    onmousemove="checkPaste()" onpaste="checkPaste()" type="text" value="07:20" style="width: 40px" /><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtProductDatePlanEnd"
                    ControlToValidate="txtProductDatePlanStart" Display="Dynamic" ErrorMessage="结束要大于开始"
                    Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                          <asp:ImageButton ID="btn_query" runat="server" ImageAlign="Top" ImageUrl="~/images/btn_query.gif"  OnClick="igbQuery_Click" />
                    <asp:ImageButton ID="btn_print" runat="server" ImageAlign="Top" ImageUrl="~/images/btn_print.gif"  OnClick="digbQuery_Click" />
                      </td>
                  </tr>
              </table>
              <br />
               <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　浏览</td>
                      </tr>
                    </table> 
                        <asp:GridView ID="gridStaff" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="12"  CssClass="itemtable" BorderWidth="0px" CellSpacing="1">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" />
                            <PagerSettings Visible="False" />
                            <Columns>
                                <asp:BoundField DataField="员工" HeaderText="姓名" >
                                </asp:BoundField>
                                <asp:BoundField DataField="产品编号" HeaderText="产品编号" >
                                </asp:BoundField>
                                <asp:BoundField DataField="派工单号" HeaderText="派工单号">
                                </asp:BoundField>
                                <asp:BoundField DataField="良品数" HeaderText="良品数" >
                                </asp:BoundField>
                                <asp:BoundField DataField="单价" HeaderText="记件单价" >
                                </asp:BoundField>
                                <asp:BoundField DataField="记件工资" HeaderText="记件工资">
                                </asp:BoundField>
                                <asp:BoundField DataField="入库时间" HeaderText="入库时间">
                                </asp:BoundField>
                            </Columns>
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
<asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td>
                                    <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
<asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                </td>
                                <td>
<asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td>
<asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
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
