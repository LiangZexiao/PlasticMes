﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorMachineMstr.aspx.cs" Inherits="Monitor_MonitorMachineMstr" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>机器监视(MonitorMstr)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
 
</head>
<body style="width: 100%; height: 100%">
    <form id="form1" runat="server">
   
        <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
            <td valign="top">
            
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:生产监视 -> 机器监视</td>
          </tr>
          </table>
            <br />
              <table  width="100%"  id="Tinf" runat="server" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#00FF00">
      <tr>
        <td width="78" height="23" class="tabPageFont" background="../images/tab_on.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click">注塑机器</asp:LinkButton></td>
        <td width="78" class="tabPageFont" background="../images/topline_bg.gif" style="CURSOR: hand" align="center">
            <!--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click" 
                Visible="False">植毛机器</asp:LinkButton>--></td>
       <td width="78"   background="../images/topline_bg.gif" >
            <input id="Hidden1" type="hidden" value="0ccccccccccccccccccc" runat="server" style="" /></td>
        <td width="78"   background="../images/topline_bg.gif" >
           <input id="Hidden2" type="hidden" value="0cccccccccccccccccccccc" runat="server" 
                style="" visible="False" /></td>
        <td   background="../images/topline_bg.gif"   >         
        <input id="hdnTargetss" type="hidden" value="QualityTrack_Cycle" runat="server" style="width: 1px" />
        <input id="hdnCellIndexss" type="hidden" value="0" runat="server" style="width: 12px" /></td>
        </tr>
      <tr>
        <td colspan="8"  bgcolor="#FFFFFF">
         <iframe width="100%" id="subnet" runat="server" marginheight="0" height="600" frameborder="0" scrolling="no" overflow="hidden" style="padding-right: 0px; margin-top: 0px; padding-left: 0px; margin-left: 0px; padding-top: 0px" src="MachineMstr.aspx"></iframe>
           </td>
      </tr>
    </table>
        </td>
        </tr>
       </table>
           
    </form>
</body>
</html>
