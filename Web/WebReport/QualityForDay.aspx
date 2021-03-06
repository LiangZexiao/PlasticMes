﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QualityForDay.aspx.cs" Inherits="WebReport_QualityForDay" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>次品原因统计报表</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script src="../JS/BOMItem.js" language="javascript" type="text/javascript"></script>
   
</head>
<body>
    <form id="form1" runat="server">
            <table id="tblBiggest" border="0" cellpadding="0" cellspacing="0" class="section-content">
            <tr>
                <td valign="top">
                
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:报表管理 -> 次品原因统计报表</td>
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
        <th align="right" style="width: 35%">
            工单号:</th>
        <td align="left">
            <input id="txtWorkOrderNo" runat="server" autocomplete="off" name="txtMouldNo"
                           type="text" class="textbox" />
            </td>
    </tr>
    <tr>
        <th align="right">
            派工单号:</th>
        <td align="left">
            <input id="txtDispatchOrder" runat="server" autocomplete="off" name="txtMouldNo"
                           type="text" class="textbox" />
            </td>
    </tr>
    <tr>
        <th align="right">
            车间: </th>
        <td align="left">
            <asp:DropDownList ID="ddlMachine_SeatCode" runat="server" Width="120px">
            </asp:DropDownList></td>
    </tr>
            <tr>
                <th align="right" style="width: 35%">
                    <asp:Label ID="lblMonth" runat="server" Text="生产日期:"></asp:Label>
                </th>
                <td>
                                <input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 至
                                 <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
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