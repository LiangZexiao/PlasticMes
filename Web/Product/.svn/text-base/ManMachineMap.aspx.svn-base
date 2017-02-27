<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManMachineMap.aspx.cs" Inherits="Product_ManMachineMap" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>员工安排(ManMachineMap)</title>
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
            <td style="height: 24px">当前位置:生产排程 -> 员工安排</td>
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
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="igbQuery"  runat="server" ImageUrl="~/images/btn_search.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
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
                                 <input id="chkAll" type="checkbox" onclick="selectAll(this);"/>
                             </HeaderTemplate>
                             <ItemStyle HorizontalAlign="Center"  Width="26px"/>
                             <HeaderStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                            <asp:ButtonField DataTextField="ID" HeaderText="序号" >
                                <ItemStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <FooterStyle CssClass="hidden" />
                            </asp:ButtonField>
                         <asp:ButtonField DataTextField="EmployeeID" CommandName="select" HeaderText="员工编号" />
                         <asp:ButtonField DataTextField="EmployeeName_CN" CommandName="select" HeaderText="员工姓名" />                         
                         <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                         <asp:BoundField DataField="WorkGrade" HeaderText="班别" />
                         <asp:BoundField DataField="WorkDate" HeaderText="工作日" />
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
                <br />
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　编辑</td>
                      </tr>
                    </table>                    
<table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
        <tr>
            <th align="right" class="label">
                员工:</th>
            <td>
                <asp:TextBox ID="txtEmployeeID" runat="server" CssClass="textbox" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmployeeID" runat="server" ErrorMessage="*" ControlToValidate="txtEmployeeID"></asp:RequiredFieldValidator>
                </td>
            <th align="right">
                机器编号:</th>
            <td>
            <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                </td>
            <th align="right">
                班别:</th>
            <td><asp:DropDownList ID="ddlWorkGrade" runat="server" CssClass="dropdownlist">
                <asp:ListItem Value="1">早班</asp:ListItem>
                <asp:ListItem Value="2">中班</asp:ListItem>
                <asp:ListItem Value="3">晚班</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblWorkGrade" runat="server" Font-Bold="True" ForeColor="Brown"></asp:Label>
            </td>
        </tr>
    <tr>
        <th align="right" class="label">
            工作日:</th>
        <td>
            <input id="txtWorkDate" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                onselectstart="return false;" /></td>
        <th align="right">
        </th>
        <td>
        </td>
        <th align="right">
        </th>
        <td>
        </td>
    </tr>
        <tr>
         <th align="right" colspan="1">
             备注:</th>
         <td colspan="5">
        <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="550px" TextMode="MultiLine" ></asp:TextBox></td>
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
