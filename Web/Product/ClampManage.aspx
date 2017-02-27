<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClampManage.aspx.cs" Inherits="Product_ClampManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>夹具管理(ClampManage)</title>
<link href="../images/css.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:基础资料 -> 植毛夹具管理</td>
          </tr>
          </table>
          <br />
            <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
            <tr>
                    <td style="background-image: url(../images/bg_title.gif); height: 18px;">　　&nbsp; 操作</td>
                  </tr>
            <tr>
            <td >
                <asp:DropDownList ID="ddlQuery" runat="server" Width="99px">
                <asp:ListItem Value="FixtureCode">夹具编号</asp:ListItem>
                <asp:ListItem Value="PlantBristlesMachine">植毛机型</asp:ListItem>
                <asp:ListItem Value="WarehouseLocation">库位</asp:ListItem>
             </asp:DropDownList>                                    
                     <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="btnNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" />
                <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="5px"></asp:TextBox></td>
              </tr>
              </table>
              <br />
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 20px;">　　&nbsp; 浏览</td>
                      </tr>
                    </table> 
        <asp:GridView ID="GridView1" runat="server" CellPadding="2"  Width="100%" AutoGenerateColumns="False"   AllowPaging="True" PageSize="12" CssClass="itemtable" 
        OnRowDataBound="GridView1_RowDataBound" BorderWidth="0px" CellSpacing="1" 
        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
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
                        <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                        <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                            <HeaderStyle CssClass="hidden" />
                            <FooterStyle CssClass="hidden" />
                        </asp:ButtonField>
                         <asp:ButtonField DataTextField="FixtureCode" CommandName="select" HeaderText="夹具编号" />
                          <asp:BoundField DataField="FixtureDesc" HeaderText="夹具描述" />
                          <asp:BoundField DataField="PlantBristlesMachine" HeaderText="植毛机型" />
                          <asp:BoundField DataField="MachineCycle" HeaderText="机器周期" />
                         <asp:BoundField DataField="WarehouseLocation" HeaderText="库位" />
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
                                    <td style="background-image: url(../images/bg_title.gif); height: 20px;">
                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作</td>
                                </tr>
                  <tr><td style="height: 28px">
                    
                    <asp:ImageButton ID="btnInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" CausesValidation="False" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  />
                    </td></tr>
                </table>
                <br />
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 20px;">　　&nbsp;&nbsp;&nbsp; 编辑</td>
                      </tr>
                    </table> 
         <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
        <tr>
             <th align="right" class="label" style="height: 26px">
                <asp:Label ID="Label1" runat="server" Text="夹具编号:" CssClass="txtlab"></asp:Label></th>
            <td style="height: 26px">
                <asp:TextBox ID="txtFixtureCode" runat="server" CssClass="textboxodl" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvItem_Code" runat="server" ControlToValidate="txtFixtureCode"
                    ErrorMessage="必填" Width="31px"></asp:RequiredFieldValidator></td>
            <th align="right" style="height: 26px">
                夹具描述:</th>
            <td style="height: 26px" colspan="3">
                <asp:TextBox ID="txtFixtureDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                    Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <th align="right">
                <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="植毛机型:"></asp:Label></th>
            <td>
                <asp:DropDownList ID="ddlPlantBristlesMachine" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                                 <input id="Hidden1" runat="server" style="width: 5px" type="hidden" />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Visible="False" Width="10px"></asp:TextBox></td>
            <th align="right">
                程序:</th>
            <td>
                <asp:TextBox ID="txtProgram" runat="server" CssClass="textbox"></asp:TextBox><span
                    style="background-color: #ebeff0"></span></td>
            <th align="right" style="width: 10%">
                库位:</th>
            <td>
                <asp:TextBox ID="txtWarehouseLocation" runat="server" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
                <th align="right">
                机器周期:</th>
                    <td>
                <asp:TextBox ID="txtMachineCycle" runat="server" CssClass="textboxodl"></asp:TextBox><span
                    style="background-color: #ebeff0"></span>
                     s<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMachineCycle" ErrorMessage="必填"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMachineCycle"
                        Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                    </td>
               </td>
               <th align="right">
                版本:</th>
            <td>
                <asp:TextBox ID="txtVer" runat="server" CssClass="textbox"></asp:TextBox>
                <input id="Hidden2" runat="server" style="width: 3px" type="hidden" />
            </td>
               <td>
               </td>
               <td></td>
        </tr>
        <tr>
            
            <th align="right">
                备注:</th>
            <td colspan="5">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                <input id="hdnID" runat="server" style="width: 3px" type="hidden" />
            </td>
            <%--<th align="right">
                <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="备注:"></asp:Label>
            </th>
            <td colspan="3">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Width="98%"></asp:TextBox>
            </td>--%>
            
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
