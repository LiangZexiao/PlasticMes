<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InspectionRecord.aspx.cs"  Inherits="Maintain_InspectionRecord" %>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>设备点检(InspectionRecord)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .style1
        {
            width: 147px;
        }
        .style2
        {
            width: 135px;
        }
        .style3
        {
            color: Blue;
            width: 117px;
        }
        .style4
        {
            width: 121px;
        }
        .style5
        {
            width: 91px;
        }
    </style>
 </head>


<body>
    <form id="form1" runat="server">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:设备管理->设备点检</td>
          </tr>
          </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td height="22" style="background-image: url(../images/bg_title.gif)">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      查询条件</td>
                  </tr>
                  <tr><td>
                    <asp:DropDownList ID="ddlQuery" runat="server">
                    <asp:ListItem Value="CurrentOperator">操作员</asp:ListItem>
                    <asp:ListItem Value="DeviceNo">设备编号</asp:ListItem>
                     </asp:DropDownList>
                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    点检日期: <input runat="server" type="text" id="txtInBeginDate" name="txtInBeginDate"  onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate" style="width:130px" /> 
                    至 <input runat="server" type="text" id="txtInEndDate" name="txtInEndDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate" style="width:130px" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    重要等级：&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlImport" runat="server" >
                    <asp:ListItem Value="all">全部</asp:ListItem>
                    <asp:ListItem Value="0">中等</asp:ListItem>
                    <asp:ListItem Value="1">重要</asp:ListItem>
                    </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      只显示未合格项：&nbsp;&nbsp;&nbsp;<asp:CheckBox  ID="chkIsOK" runat="server" />
                    </td></tr>
                    <tr><td  valign="middle" > &nbsp;  操作：
                        <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
                        <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
                        <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" />
                    </td>
                  </tr>
              </table>
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　浏览</td>
                      </tr>
                    </table>
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" 
                        AllowPaging="True" PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
                        
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE"  HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号" >
                                    <ItemStyle CssClass="hidden" />  <HeaderStyle CssClass="hidden"/> <FooterStyle CssClass="hidden" />
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="select" DataTextField="MachineNo" HeaderText="设备编号"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:ButtonField CommandName="select" DataTextField="ItemName" HeaderText="点检项目" />                                
                                <asp:BoundField DataField="ItemLevel" HeaderText="重要等级"   ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="CheckResult" HeaderText="是否合格" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="CheckMan" HeaderText="点检操作员" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />                       
                                <asp:BoundField DataField="CheckDate" HeaderText="检查日期" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
<asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$">
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
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　&nbsp;&nbsp;&nbsp;操作</td>
                      </tr>
                      <tr>
                      <td>
                        <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" ImageAlign="Top" />
                        <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" ImageAlign="Top" />
                        <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="false" ImageAlign="Top" />
                        <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false" ImageAlign="Top"  />
                        <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="txtID" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                      </td>
                      </tr>
                    </table>
                <br />
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  编辑</td>
                      </tr>
                    </table>

            <table border="0" style="border-collapse: collapse;" width="90%" cellpadding="1" cellspacing="1" class="texttable">
                                        <tr>
                                            <th align="right" class="style3"><asp:Label ID="Label1" runat="server" CssClass="txtlab"  Text="设备编号:"></asp:Label></th>
                                            <td class="style1">
                                                <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textboxodl" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMachineNo" runat="server" ErrorMessage="必填" ControlToValidate="txtMachineNo"></asp:RequiredFieldValidator>
                                            </td>
                                            <th align="right" class="style4">录入人员：:</th>
                                            <td class="style2">
                                                <asp:TextBox ID="txtOperator" runat="server" CssClass="textbox" ></asp:TextBox>
                                            </td>
                                            <th align="right" class="style5"> 巡检时间:</th>
                                           <td>
                                                <input runat="server" type="text" id="wpInspectionDate" name="wpInspectionDate"  onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate" style="width:130px" />
                                                <asp:TextBox ID="txtInspectionDate" runat="server" CssClass="textbox"></asp:TextBox>
                                           </td>
                                        </tr>
                                        <tr>
                                            <th align="right" class="style1">是否合格：:</th>
                                            <td class="style2">
                                                <asp:CheckBox  ID="chkHG1" runat="server" />
                                            </td>
                                            <td></td>
                                            
                                            <th align="right" class="style1">备注：:</th>
                                            <td class="style2">
                                                <asp:TextBox  ID="txtRemark1" runat="server" width="100%"  CssClass="textbox"/>
                                            </td>
                                        </tr>
                                    </table>
                <table width="80%" cellpadding="0"  cellspacing="0" border="0" align="center">
                    <tr>
                        <td>                    
                        <asp:GridView ID="GridView2" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" 
                        AllowPaging="True" PageSize="12" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE"  HorizontalAlign="Center" VerticalAlign="Middle" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                                <asp:BoundField  DataField="ItemID" HeaderText="项目编号"  HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField  DataField="ItemName" HeaderText="项目名称"  HeaderStyle-Width="32%"/>  
                                <asp:BoundField DataField="ItemLevel" HeaderText="重要等级" HeaderStyle-Width="10%"  ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="ItemType" HeaderText="点验周期" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="是否合格"  HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItemHG" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" HeaderStyle-Width="30%" >
                                    <ItemTemplate>
                                        <asp:TextBox  ID="txtRemark" runat="server" width="100%"  CssClass="textbox"/>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        <PagerSettings Visible="False" /> 
                    </asp:GridView>
                    </td>
                   </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>