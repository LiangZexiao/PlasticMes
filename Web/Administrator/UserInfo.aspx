<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="Administrator_UserInfo" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>用户管理(UserInfo)</title>
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
            <td style="height: 24px">当前位置:系统管理 -> 帐号管理</td>
          </tr>
          </table>
        <br />
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
                  </tr>
                  <tr>
                    <td>
<asp:DropDownList ID="ddlQuery" runat="server">
<asp:ListItem Value="UserID">帐号</asp:ListItem>
<asp:ListItem Value="Employeename_cn">姓名</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" />
                    </td>
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
                                <asp:ButtonField CommandName="select" DataTextField="UserID" HeaderText="帐号" />
                                <asp:BoundField DataField="Employeename_cn" HeaderText="姓名" />
                                <asp:BoundField  DataField="Password" HeaderText="密码" Visible="False" />
                                <asp:BoundField DataField="Sex" HeaderText="性别" Visible="False"  />
                                <asp:BoundField DataField="Email" HeaderText="Email" Visible="False" />
                                <asp:BoundField DataField="DeptName" HeaderText="部门" Visible="False" />
                                <asp:BoundField DataField="GroupName" HeaderText="群组" />
                                <asp:BoundField DataField="LastIP" HeaderText="最后IP" Visible="False" />
                                <asp:BoundField DataField="IsLock" HeaderText="禁用" />
                                <asp:BoundField DataField="cDate" HeaderText="创建时间" />
                                <asp:BoundField DataField="mDate" HeaderText="修改时间" Visible="False" />
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
                        <tr>
                            <th align="right" style="width: 10%" class="label">
                                <asp:Label ID="Label2" runat="server" CssClass="txtlab" Text="用户名:"></asp:Label>
                            </th>
                            <td style="width: 40%">
                                <asp:TextBox ID="txtUserID" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvItem_Code" runat="server" ControlToValidate="txtUserID"
                                    ErrorMessage="必填" Width="31px"></asp:RequiredFieldValidator>
                                <input id="dempno" type="hidden" runat="server" style="width: 20px" class="textbox" />
                               <%--<asp:DropDownList ID="ddlUserName" runat="server" CssClass="textboxodl" AutoPostBack="True" 
                                 OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged" Enabled="false"></asp:DropDownList>--%>
                              </td>
                            <th align="right" style="width: 10%">
                                <asp:Label ID="Label1" runat="server" CssClass="txtlab" Text="姓名:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="118px" >
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">密码:</th>
                            <td>
                                <input id="txtPassword" type="password" runat="server" class="textbox" /></td>
                            <th align="right">
                                确认密码:</th>
                            <td><input id="txtpwd2" type="password" runat="server" class="textbox" />
                                <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                        </tr>
     <tr>
         <th align="right">
             部门:</th>
         <td>
                                <asp:TextBox ID="TxtDept" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox></td>
         <th align="right">
                                所属群组:</th>
         <td>
                            <asp:DropDownList ID="ddlGroupID" runat="server" Width="124px"></asp:DropDownList></td>
     </tr>
     <tr runat="server" id="trvies">
         <th align="right">
             部门性别</th>
         <td>
                                <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True">男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:RadioButtonList>
             <asp:DropDownList ID="ddlDeptID" runat="server" Width="124px" Visible="False"></asp:DropDownList>
                                最后登入IP:</td>
         <th align="right">
             Email:</th>
         <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox><asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="有误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtLastIP" runat="server" CssClass="textbox" Width="10px" Enabled="False"></asp:TextBox></td>
     </tr>
                        <tr>
                            <th align="right" style="height: 22px" >
                                状态:</th>
                            <td style="height: 22px">
                                <asp:CheckBox ID="ckbIslock" runat="server" Text="禁用" /></td>
                            <th align="right" style="height: 22px">
                                </th>
                            <td style="height: 22px">
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