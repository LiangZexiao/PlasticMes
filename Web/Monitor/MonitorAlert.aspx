﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorAlert.aspx.cs" Inherits="Monitor_Alarm" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
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
                当前位置:生产监视-->报警监视</td>
          </tr>
          </table>
    <br />
            <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　操作</td>
                  </tr>
            <tr>
            <td style="height: 20px" >
             <asp:DropDownList ID="ddlQuery" runat="server">
             <asp:ListItem Value="AlarmMachine">报警机器</asp:ListItem>
             </asp:DropDownList>                                    
                     <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
                &nbsp;<asp:ImageButton ID="ibgOutPut" runat="server" ImageUrl="~/images/button_export.gif"
                                                OnClick="ImageButton1_Click" ImageAlign="Top" />
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

                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                    <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        <asp:ButtonField CommandName="select" DataTextField="ID" HeaderText="序号">
                            <ItemStyle CssClass="hidden" />
                            <HeaderStyle CssClass="hidden" />
                            <FooterStyle CssClass="hidden" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="select" DataTextField="AlarmSource" HeaderText="报警来源" Visible="False" />
                        <asp:ButtonField DataTextField="AlarmMachine" HeaderText="报警机器" Visible="False" />
                            <asp:BoundField DataField="AlarmMachine" HeaderText="报警机器" />
                        <asp:BoundField DataField="AlarmMemo" HeaderText="报警内容" />
                        <asp:BoundField DataField="AlarmStatus" HeaderText="报警状态"  />
                        <asp:BoundField DataField="SendType" HeaderText="发送标志" />
                        <asp:BoundField DataField="CreateDate" HeaderText="报警时间" />
                        <asp:BoundField DataField="AlarmTotalTime" HeaderText="持续时间" Visible="False" />
                        <asp:BoundField DataField="Remark" HeaderText="备注" Visible="False" />
                        <asp:BoundField DataField="DutyOn" HeaderText="责任人" Visible="false"  />
                        <asp:BoundField DataField="IsReadFlag" HeaderText="查看否" Visible="False" />
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
                          <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" Visible="False" /><asp:ImageButton
                              ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" Enabled="False" Visible="False" /><asp:ImageButton
                                  ID="igbDelete" runat="server" CausesValidation="false" ImageUrl="~/images/btn_delete.gif" Visible="False" /><asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  />
                        <input id="Hidden1" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
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
                            <th align="right">
                                <asp:Label ID="lblAlarmSource" runat="server" Text="报警来源:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtAlarmSource" runat="server" CssClass="textbox"></asp:TextBox>
                            </td>
                            <th align="right">
                                <input id="hdnID" runat="server" style="width: 27px" type="hidden" />
                                <asp:Label ID="lblAlarmMachine" runat="server" Text="报警机器:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtAlarmMachine" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox></td>
                            <th align="right">
                                <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="37px"></asp:TextBox>
                                <asp:Label ID="lblDutyOn" runat="server" Text="责任人:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtDutyOn" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblAlarmMemo" runat="server" Text="报警说明:"></asp:Label>
                            </th>
                            <td colspan="5">
                                <asp:TextBox ID="txtAlarmMemo" runat="server" CssClass="textbox" Height="80px" ReadOnly="True"
                                    TextMode="MultiLine" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblAlarmStatus" runat="server" Text="报警状态:"></asp:Label></th>
                            <td>
                                <asp:RadioButtonList ID="rblAlarmStatus" runat="server" Enabled="False" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" Width="124px">
                                    <asp:ListItem Value="0">未解除</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1">已解除</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <th align="right">
                                <asp:Label ID="lblSendType" runat="server" Text="发送标志:"></asp:Label></th>
                            <td>
                                <asp:RadioButtonList ID="rblSendType" runat="server" Enabled="False" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" Width="124px">
                                    <asp:ListItem Value="0">未发送</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1">已发送</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td align="right">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblAlarmTotalTime" runat="server" Text="持续时间:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtAlarmTotalTime" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <th align="right">
                                <asp:Label ID="lblCreateDate" runat="server" Text="报警时间:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtCreateDate" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <th align="right">
                                <asp:Label ID="lblRemark" runat="server" Text="备注:"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>
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
