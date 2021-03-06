﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaintainReport.aspx.cs" Inherits="Maintain_MaintainReport" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <title>维修报告(MaintainReport)</title>
</head>
<body>
    <form id="form1" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
                   <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:设备管理 -> 维修报告</td>
          </tr>
          </table>
<br />
          
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0" style="width: 100%">
              <tr>
                <td height="22" style="background-image: url(../images/bg_title.gif)">　　条件</td>
              </tr>
          </table> 
          
          
<table border="0" cellpadding="1" cellspacing="1" class="texttable" style="border-collapse: collapse; width: 100%;">
            <tr>
                <th align="right" style="width: 40%">
                    维修时间:</th>
                <td>
                    <input id="txtStartDate" runat="server" class="textbox" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" />&nbsp;至&nbsp;<input id="txtEndDate" runat="server" class="textbox" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" /></td>
            </tr>
            <tr>
                <th align="right" style="width: 40%">
                    设备类型:</th>
                <td>
                    <asp:DropDownList ID="ddlDeviceType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDeviceType_SelectedIndexChanged"
                         CssClass="dropdownlist">
                        <asp:ListItem Text="全部" Value=""></asp:ListItem>
                        <asp:ListItem Text="机器" Value="1"></asp:ListItem>
                        <asp:ListItem Text="模具" Value="2"></asp:ListItem>
                        <asp:ListItem Text="其它" Value="3"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <th align="right" style="width: 40%">
                    设备编号:</th>
                <td>
                    <asp:DropDownList ID="ddlDeviceNo" runat="server" CssClass="dropdownlist">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtDeviceNo" runat="server" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                <asp:ImageButton ID="igbPrint" runat="server" ImageUrl="~/images/btn_print.gif"
                        OnClick="igbPrint_Click" /></td>
            </tr>
        </table>
        
        </td>
            </tr>
        </table>
    </form>
</body>
</html>
