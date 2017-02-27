<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerInfo.aspx.cs" Inherits="BaseInfo_CustomerInfo" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>客户管理(DepartmentInfo)</title>
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
            <td style="height: 24px">当前位置:基础资料 -> 客户管理</td>
          </tr>

      </table>
        <br>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
                  </tr>
                  <tr>
                    <td>
                <asp:DropDownList ID="ddlQuery" runat="server">
                <asp:ListItem Value="CustomerNo">客户编号</asp:ListItem>
                <asp:ListItem Value="CustomerName">客户名称</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
                <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
                <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" /></td>
                  </tr>
              </table>
              <br>
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　浏览</td>
                      </tr>
                    </table>              
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True" PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
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
                                <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号"  >
                                <ItemStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <FooterStyle CssClass="hidden" />
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="select" DataTextField="CustomerNo" HeaderText="客户编号" />
                                <asp:BoundField DataField="CustomerName" HeaderText="客户名称" />
                                <asp:BoundField DataField="LinkMan" HeaderText="联系人" />
                                <asp:BoundField DataField="Tel" HeaderText="联系电话" />
                                <asp:BoundField DataField="Fax" HeaderText="传真"  Visible="False" />
                                <asp:BoundField DataField="WebSite" HeaderText="主页" />
                                <asp:BoundField DataField="EMail" HeaderText="电子邮件" />
                                <asp:BoundField DataField="OfficeAddr" HeaderText="办公地址"  Visible="False" />
                                <asp:BoundField DataField="WareHouse" HeaderText="送货地址"  Visible="False" />
                                <asp:BoundField DataField="Bank" HeaderText="开户银行" Visible="False" />
                                <asp:BoundField DataField="Account" HeaderText="银行帐号" Visible="False" />
                                <asp:BoundField DataField="BalanceKind" HeaderText="结算方式" Visible="False"  />
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
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
                      </tr>
                      <tr>
                      <td>
                        <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                        <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                        <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="false" />
                        <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  />
                        <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="txtID" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                      </td>
                      </tr>
                    </table>
                <br>
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　编辑</td>
                      </tr>
                    </table>
                    <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
                        <tbody>
                        <tr>
                            <th align="right" class="label">
                                <asp:Label ID="Label1" runat="server" Text="客户编号:" CssClass="txtlab"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtCustomerNo" runat="server" CssClass="textboxodl"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCustomerNo" runat="server" ErrorMessage="必填" ControlToValidate="txtCustomerNo"></asp:RequiredFieldValidator></td>
                            <th align="right">
                                <asp:Label ID="Label2" runat="server" Text="客户名称:" CssClass="txtlab"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtCustomerName" runat="server" CssClass="textboxodl"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerName"
                                    ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                            <th align="right">联系人:</th>
                            <td>
                            <asp:TextBox ID="txtLinkMan" runat="server" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th align="right" style="height: 26px">联系电话:</th>
                            <td style="height: 26px">
                                <asp:TextBox ID="txtTel" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revTel" runat="server" ControlToValidate="txtTel"
                                    ErrorMessage="输入有误" ValidationExpression="^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$"></asp:RegularExpressionValidator></td>
                            <th align="right" style="height: 26px">
                                传真:</th>
                            <td style="height: 26px">
                                <asp:TextBox ID="txtFax" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revFax" runat="server" ControlToValidate="txtFax"
                                    ErrorMessage="输入有误" ValidationExpression="^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$"></asp:RegularExpressionValidator></td>
                            <th align="right" style="height: 26px">主页:</th>
                            <td style="height: 26px">
                                <asp:TextBox ID="txtWebSite" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revWebSite" runat="server" ControlToValidate="txtWebSite"
                                    ErrorMessage="输入有误" ValidationExpression="^http(s)?://(?!([\w-]+\.[\w-]+$))([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <th align="right">电子邮件:</th>
                            <td>
                            <asp:TextBox ID="txtEMail" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEMail" runat="server" ErrorMessage="输入有误" ControlToValidate="txtEMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                            <th align="right">
                                办公地址:</th>
                            <td>
                                <asp:TextBox ID="txtOfficeAddr" runat="server" CssClass="textbox"></asp:TextBox></td>
                            <th align="right">送货地址:</th>
                            <td>
                                <asp:TextBox ID="txtWareHouse" runat="server" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <th align="right">开户银行:</th>
                            <td>
                                <asp:TextBox ID="txtBank" runat="server" CssClass="textbox"></asp:TextBox></td>
                             <th align="right">
                                 银行帐号:</th>
                             <td>
                            <asp:TextBox ID="txtAccount" runat="server" CssClass="textbox"></asp:TextBox></td>
                            <th align="right">结算方式:</th>
                            <td>
                                <asp:DropDownList ID="ddlBalanceKind" runat="server" CssClass="dropdownlist">
                                    <asp:ListItem Value="1">银行汇票</asp:ListItem>
                                    <asp:ListItem Value="2">银行本票</asp:ListItem>
                                    <asp:ListItem Value="3">商业汇票</asp:ListItem>
                                    <asp:ListItem Value="4">支票</asp:ListItem>
                                    <asp:ListItem Value="5">信用卡</asp:ListItem>
                                    <asp:ListItem Value="6">汇兑</asp:ListItem>
                                    <asp:ListItem Value="7">委托收款</asp:ListItem>
                                    <asp:ListItem Value="8">托收承付</asp:ListItem>
                                    <asp:ListItem Value="9">信用证</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <th align="right" >备注:</th>
                            <td colspan="5" ><asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="550px" TextMode="MultiLine"></asp:TextBox></td>                                                
                        </tr>
                        </tbody>
                    </table>
            </asp:View>
        </asp:MultiView>
        </td>
          </tr>
        </table>
    </form>
</body>
</html>