﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QualityTrack.aspx.cs" Inherits="Quality_QualityTrack" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

<meta http-equiv="Refresh" content="15" runat="server" id="Refresh" />
     <title> 实际工艺图(QualityTrack)</title>
     <link href="../images/css.css" type="text/css" rel="stylesheet" />
     <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>
     <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <!--*************************************-->
    <script src="../zhEcharts/js/jquery-1.8.2.min.js"></script>

     
</head>
<body>
    <script type="text/javascript">
        /*var frames = document.getElementById("subnet");
        alert("调用函数");
        frames.contentWindow.click();*/


    </script>
    <form id="form1" runat="server">

          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:品质管理 -> 实际工艺图<asp:Label ID="Label1" runat="server" Text="第" style="visibility:hidden"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="啤" style="visibility:hidden" ></asp:Label>
                <asp:DropDownList ID="ddlXAxisFlag" runat="server" Visible="False">
                <asp:ListItem Value="minute">时间</asp:ListItem>
                <asp:ListItem Selected="True" Value="beernum">啤数</asp:ListItem>
                </asp:DropDownList></td>
          </tr>
          </table>
          <br />
          
          <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　&nbsp;&nbsp; 操作</td>
                      </tr>
                      <tr>
            <th>
                日期:<input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                 style="width: 120px" /> 至
                 <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                 style="width: 120px" /> 

                <%--<input id="txtDate1" runat="server" class="textbox" onfocus="setday(this)" 
                    onkeypress="return false" onselectstart="return false;" 
                    style="width: 90px; height: 23px;"  />
                <input name="txtTime1" id="txtTime1"  runat="server" value="07:20" onkeydown="keydown(this,'time')" size="5" maxlength="5" type="text" onFocus="" onkeypress="keypress(this,'time')" onpaste="checkPaste()" onDrag="checkPaste()" oncut="checkPaste()" onmousemove="checkPaste()" style="width: 40px" class="textbox" /> 
                至
                <input id="txtDate2" runat="server" class="textbox" onfocus="setday(this)" 
                    onkeypress="return false" onselectstart="return false;" style="width: 90px" />
                <input name="txtTime2" id="txtTime2" runat="server" value="07:20" onkeydown="keydown(this,'time')" maxlength="5" type="text" onFocus="" onkeypress="keypress(this,'time')" onpaste="checkPaste()" onDrag="checkPaste()" oncut="checkPaste()" onmousemove="checkPaste()" style="width: 40px" class="textbox" />--%>
                <asp:Label ID="lblMachineNo" runat="server" Text="机器:"></asp:Label>
               <%-- <asp:DropDownList ID="ddlMachineNo" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlMachineNo_SelectedIndexChanged" Height="16px" 
                    Width="130px">
                </asp:DropDownList>--%><input id="txtMachineNo" runat="server" autocomplete="off" name="txtMachineNo"  style="width: 100px" type="text" />
                <asp:Label ID="Label3" runat="server" Text="派工单:"></asp:Label>
          <%--  <asp:DropDownList ID="ddlDispatchOrder" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlMachineNo_SelectedIndexChanged" Height="18px" 
                    Width="130px">
                </asp:DropDownList>--%><input id="txtDispatchOrder" runat="server" autocomplete="off" name="txtDispatchOrder" style="width: 110px" type="text" />
                <asp:ImageButton ID="igbSured" runat="server" ImageAlign="Top" ImageUrl="~/images/btn_search.gif" OnClick="igbSured_Click" />
                <asp:CheckBox ID="chkRefresh" runat="server" Text="自动刷新" AutoPostBack="True" OnCheckedChanged="chkRefresh_CheckedChanged" />
                <input id="hdnTime" type="hidden" value="10" runat="server" style="width: 30px" />
                <asp:DropDownList ID="ddlMouldNo" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlMouldNo_SelectedIndexChanged" Visible="False" 
                    Height="23px" Width="106px"></asp:DropDownList><asp:Label ID="lblMouldNo" runat="server" Text="模具:" Visible="False"></asp:Label><asp:DropDownList ID="ddlProductNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductNo_SelectedIndexChanged" Visible="False"></asp:DropDownList><asp:Label ID="lblProductNo" runat="server" Text="产品:" Visible="False"></asp:Label><asp:DropDownList ID="ddlAction" runat="server" disabled="true" style="visibility:hidden"  Width="60px">
                    <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>&nbsp;
            </th>
        </tr>
     </table>
    <br />
    <table  width="100%"  id="Tinf" runat="server" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#00FF00">
      <tr>
       <%--<td width="78" height="23" class="tabPageFont" background="../images/tab_on.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click">人工周期图</asp:LinkButton></td>
             <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton_Click">机器周期图</asp:LinkButton></td>
             <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton_Click">填充时间图</asp:LinkButton></td>
        <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click">温度图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton_Click">压力图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton_Click">最大压力图</asp:LinkButton></td>
        <td  background="../images/topline_bg.gif"  >         --%>
          <td width="78" height="23" class="tabPageFont" background="../images/tab_on.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click">人工周期图</asp:LinkButton></td>
             <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton_Click">机器周期图</asp:LinkButton></td>
             <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton_Click">填充时间图</asp:LinkButton></td>
        <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click">温度图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton_Click">压力图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton_Click">最大压力图</asp:LinkButton></td>
        <td  background="../images/topline_bg.gif"  > 
        <input id="hdnTarget" type="hidden" value="QualityTrack_Cycle" runat="server" style="width: 64px" />
            <input id="hdnCellIndex" type="hidden" value="0" runat="server" style="width: 64px" /></td>
        </tr>
      <tr>
        <td colspan="8"  bgcolor="#FFFFFF">
           <iframe width="100%" id="subnet" runat="server" marginheight="0" height="600" frameborder="0" scrolling="no" overflow="hidden" allowtransparency="false" ></iframe>
           </td>
      </tr>
    </table>

    </form>
</body>
</html>
