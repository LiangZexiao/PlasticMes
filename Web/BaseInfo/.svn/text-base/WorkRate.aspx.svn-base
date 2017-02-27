<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkRate.aspx.cs" Inherits="BaseInfo_WorkRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>员工作业速度设置</title><link href="../images/css.css" type="text/css" rel="stylesheet" />
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
            <td style="height: 24px">当前位置:基础资料 -> 员工作业速度设置</td>
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
                    <td>
                        &nbsp;产品编号:
                        <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"   OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"  OnClick="btnDelete_Click" ImageAlign="Top" />&nbsp;
                      
                        </td>
                  </tr>
              </table>
              <br>
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td style="width: 100%">
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0" >
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　浏览</td>
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
                         <asp:ButtonField DataTextField="Item_Code" CommandName="select" HeaderText="产品编号" />
                            <asp:BoundField DataField="Item_NameCH" HeaderText="产品名称" />
                         <asp:BoundField DataField="workrate" HeaderText="作业速度(s/pcs)" />
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
                                        OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                        OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                </td>
                                <td>
                                    <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                        OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                        OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
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
                        <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　操作</td>
                      </tr>
                      <tr>
                      <td>
<asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="false" ImageAlign="Top" />
<asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false" ImageAlign="Top"  />
                        <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                      </td>
                      </tr>
                    </table>
                <br>
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　编辑</td>
                      </tr>
                    </table>
<table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
        <tr>
            <th align="right" class="label">
                <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="产品编号:"></asp:Label></th>
            <td style="width: 341px">
                <asp:DropDownList ID="ddlitem_code" runat="server" Width="117px">
                </asp:DropDownList><asp:TextBox ID="txtMachine_Code" runat="server" CssClass="textbox" ></asp:TextBox></td>
            <th align="right">
                作业速度:</th>
            <td>
            <asp:TextBox ID="txtMachine_NameCH" runat="server" CssClass="textbox"></asp:TextBox><asp:Label
                ID="Label2" runat="server" Text="s/pcs"></asp:Label>
            </td>
           </tr>
           <tr>
            <th align="right" class="label">
                <asp:Label ID="Label3" runat="server"  Text="超时次数:" ForeColor="Black"></asp:Label></th>
            <td style="width: 341px">
                <asp:TextBox ID="txtovertime" runat="server" CssClass="textbox" ></asp:TextBox><asp:Label ID="Label4" runat="server" Text="次/小时"></asp:Label>
                <asp:RegularExpressionValidator ID="exprots1" runat="server" ControlToValidate="txtovertime"
                                        ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                        </td>
            <th align="right">
               </th>
            <td>
            
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
