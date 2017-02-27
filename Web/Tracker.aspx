<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tracker.aspx.cs" Inherits="Tracker" %>
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
<link href="images/css.css" type="text/css" rel="stylesheet" />
    <title>报警消息</title>
</head>
<body>
    <form id="form1" runat="server">
             
             
          <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top" align="center">
          
          <table class="itemtable" cellspacing="1" cellpadding="2" border="0" style="width: 95%">
              <tr>
                <td height="22" style="background-image: url(images/bg_title.gif)">&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 浏览</td>
              </tr>
          </table> 
          
          
        <table border="0" style="border-collapse: collapse; width: 95%;" cellpadding="1" cellspacing="1" class="texttable" id="tbl_False" runat="server" >
            <tr>
                <th>
                    报警原因</th>
                <th>
                    报警消息数目</th>
            </tr>
            <tr>
                <th>
                    机器</th>
                <td align="center">
                    <asp:Label ID="lblMachine" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th style="height: 16px">
                    次品率</th>
                <td align="center" style="height: 16px">
                    <asp:Label ID="lblBadRate" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th>
                    周期</th>
                <td align="center">
                    <asp:Label ID="lblCycle" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th>
                    温度</th>
                <td align="center">
                    <asp:Label ID="lblTemp" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th>
                    射胶压力</th>
                <td align="center">
                    <asp:Label ID="lblPress" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th>
                    射胶时间</th>
                <td align="center">
                    <asp:Label ID="lblTime" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th>
                    射胶量</th>
                <td align="center">
                    <asp:Label ID="lblMtlNum" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
            <tr>
                <th>
                    预塑时间</th>
                <td align="center">
                    <asp:Label ID="lblPreTime" runat="server" ForeColor="Red" Text="0"></asp:Label>
                    条</td>
            </tr>
        </table>
              <asp:DataList ID="DataList1" runat="server" Width="95.5%" >
            <HeaderTemplate>
                <table style="border-collapse: collapse; width: 100%;" border="0" cellpadding="1" cellspacing="1" class="texttable">
                    <tr>
                        <th style="width:50%">
                            报警原因</th>
                        <th>
                            最新消息数目</th>
                    </tr>
                </table>
            </HeaderTemplate>
            
            <ItemTemplate> 
                <!--
                <tr> 
                 <td><%# DataBinder.Eval(Container.DataItem, "AlarmSource")%></td> 
                 <td><%# DataBinder.Eval(Container.DataItem, "NewsCnt")%></td>
                </tr> 
                -->
                <table border="0" style="border-collapse: collapse; width: 100%;" cellpadding="1" cellspacing="1" class="texttable" >
                <tr>
                <th style="width:50%">
                    <%# DataBinder.Eval(Container.DataItem, "AlarmSource")%></th>
                <td align="center">
                    <%# DataBinder.Eval(Container.DataItem, "NewsCnt")%>
                    条</td>
                </tr>
                </table> 
            </ItemTemplate> 


              </asp:DataList>
              <img onclick="window.close()" src="images/btn_cancel.gif" style="CURSOR: hand"/></td>
            </tr>
        </table>
        
    </form>
</body>
</html>
