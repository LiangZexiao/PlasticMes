<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choice.aspx.cs" Inherits="CrystalReports_choice" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>自定义报表</title>
 <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script type="text/javascript" language="javascript" >
    function ongoto() {
   window.history.go(-1);
}
    </script>
</head>
<body>
<form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
           <td style="height: 17px" >
                    当前位置:报表管理-> 自定义报表</td>
            </tr>
          </table>
 <br />
            <asp:MultiView ID="MultiView1" runat="server">
               <asp:View ID="View1" runat="server">
            
           
    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                <td colspan="3" style="background-image: url(../images/bg_title.gif); height: 17px;">　　操作</td>
             </tr>
     <tr><td style="WIDTH: 100%" colspan="3">&nbsp;<asp:ImageButton id="igbQuery" onclick="igbQuery_Click" runat="server" ImageAlign="Top" ImageUrl="~/images/button_check.gif"></asp:ImageButton>&nbsp;<asp:ImageButton id="igbsubmit" onclick="igbsubmit_Click" runat="server" ImageAlign="Top" ImageUrl="~/images/btn_print.gif"></asp:ImageButton> 
         <input id="Button3" onclick=" return history.go(-1)" style="background-attachment: fixed;
             background-image: url(../images/btn_back.gif); width: 76px; background-repeat: no-repeat;
             height: 25px; background-color: transparent; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" type="button" />
         <input style="WIDTH: 5px" id="num" type=hidden runat="server" /></td></tr>
     <tr><td style="FONT-SIZE: 15pt; WIDTH: 47px" align="center"><asp:Label id="key1" runat="server" Text="KEY1"></asp:Label> </td><td style="WIDTH: 385px"><asp:DropDownList id="keydrop1" runat="server" Width="150px" OnSelectedIndexChanged="keyDropSelected" AutoPostBack="True">
                        </asp:DropDownList><asp:DropDownList id="keydata1" runat="server" Width="180px">
                        </asp:DropDownList><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="keydata1" ErrorMessage="不能为空" Display="Dynamic"></asp:RequiredFieldValidator></td><td><asp:DropDownList id="keydrop2" runat="server" Width="150px" OnSelectedIndexChanged="keyDropSelected" AutoPostBack="True">
                        </asp:DropDownList><asp:DropDownList id="keydata2" runat="server" Width="180px">
                        </asp:DropDownList> <asp:Label id="labtab1" runat="server" ForeColor="Red"></asp:Label> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="keydata2" ErrorMessage="不能为空" Display="Dynamic"></asp:RequiredFieldValidator></td></tr><tr><td style="FONT-SIZE: 15pt; WIDTH: 47px" align="center"><asp:Label id="key2" runat="server" Text="KEY2"></asp:Label></td><td style="WIDTH: 385px"><asp:DropDownList id="keydrop3" runat="server" Width="150px" OnSelectedIndexChanged="keyDropSelected" AutoPostBack="True">
                        </asp:DropDownList><asp:DropDownList id="keydata3" runat="server" Width="180px">
                        </asp:DropDownList><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="keydata3" ErrorMessage="不能为空" Display="Dynamic"></asp:RequiredFieldValidator></td><td><asp:DropDownList id="keydrop4" runat="server" Width="150px" OnSelectedIndexChanged="keyDropSelected" AutoPostBack="True">
                        </asp:DropDownList><asp:DropDownList id="keydata4" runat="server" Width="180px">
                        </asp:DropDownList> <asp:Label id="labtab2" runat="server" ForeColor="Red"></asp:Label> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="keydata4" ErrorMessage="不能为空" Display="Dynamic"></asp:RequiredFieldValidator></td></tr><tr><td style="FONT-SIZE: 15pt; WIDTH: 47px" align="center"><asp:Label id="labwhere" runat="server" Text="WHERE"></asp:Label> </td><td colSpan=2><asp:TextBox id="txtwhere" runat="server" Width="714px" Height="42px" TextMode="MultiLine"></asp:TextBox>
         </td></tr>
         </table>
     <table cellspacing="0" cellpadding="0" width="100%" border="0"><tr><td><table class="itemtable" cellspacing="1" cellpadding="2" border="0">  </table>
   <br />
             <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="17" style="background-image: url(../images/bg_title.gif)">　　浏览</td>
                      </tr>
                    </table>   
                     
                      <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="17" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                        <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="c1" HeaderText="ss" />
                            </Columns>
                            <PagerSettings Visible="False" />
                    </asp:GridView>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <asp:Panel ID="Panel1" runat="server" Height="1px" Width="486px">
                                    <table style="width: 386px; height: 1px">
                                        <tr>
                                            <td style="height: 33px; width: 136px;">
                                                <asp:Label ID="lblDataCount" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="height: 33px; width: 98px;">
<asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif" OnClick="CtrlPageInfo_Click" />
                                            </td>
                                            <td style="height: 33px; width: 49px;">
                                                <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="height: 33px; width: 68px;">
<asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif" OnClick="CtrlPageInfo_Click" />
                                            </td>
                                            <td style="height: 33px; width: 99px;">
                                                <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                            </td>
                                            <td style="height: 33px">
<asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif" OnClick="CtrlPageInfo_Click" />
                                            </td>
                                            <td style="height: 33px; width: 104px;">
                                                <asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex"
                                                    ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$" Width="68px"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
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
              
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                       <td style="BACKGROUND-IMAGE: url(../images/bg_title.gif); HEIGHT: 10px">　　浏览</td>
                      </tr>
             <tr><td style="HEIGHT: 22px">
             <input style="BACKGROUND-ATTACHMENT: fixed; BACKGROUND-IMAGE: url(../images/btn_print_list.gif); WIDTH: 85px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 25px; BACKGROUND-COLOR: transparent" id="Button1" onclick="return window.print();" type="button" />&nbsp; 
             <input style="BACKGROUND-ATTACHMENT: fixed; BACKGROUND-IMAGE: url(../images/btn_back.gif); WIDTH: 76px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 25px; BACKGROUND-COLOR: transparent; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" id="Button2" onclick=" return history.go(-1)" type="button" /> </td></tr>
             </table>
             <asp:GridView id="GridView2" runat="server" Width="660px" CellSpacing="1" BorderWidth="0px" CssClass="itemtable" PageSize="1" AutoGenerateColumns="False" CellPadding="2">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <PagerSettings Visible="False" />
                            <Columns>
                                <asp:BoundField DataField="c1" HeaderText="ss" />
                            </Columns>
                    </asp:GridView> 
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
