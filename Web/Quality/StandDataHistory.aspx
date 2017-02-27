<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StandDataHistory.aspx.cs" Inherits="Quality_StandDataHistory" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>试模参数</title>
<link href="../images/css.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>
    </head>
<body>
    <form id="form1" runat="server">

          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:品质管理 -> 参考工艺图</td>
          </tr>
          </table>
          <br />
          <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作<input id="hdnURLID" runat="server" style="width: 25px" type="hidden" />
        <input id="hdnID" runat="server" style="width: 25px" type="hidden" /></td>
                      </tr>
                      <tr>

                <th>
                    日期:<input id="txtDate1" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                    onselectstart="return false;" style="width: 70px" />
                    <input id="txtTime1" runat="server" class="textbox" maxlength="5" name="txtTime1" oncut="checkPaste()"
                        ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')" onkeypress="keypress(this,'time')"
                        onmousemove="checkPaste()" onpaste="checkPaste()" size="5" style="width: 40px"
                        type="text" value="07:20" />至<input id="txtDate2" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                    onselectstart="return false;" style="width: 70px" />
                    <input id="txtTime2" runat="server" class="textbox" maxlength="5" name="txtTime2" oncut="checkPaste()"
                        ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')" onkeypress="keypress(this,'time')"
                        onmousemove="checkPaste()" onpaste="checkPaste()" style="width: 40px" type="text"
                        value="07:20" />
                    <asp:Label ID="lblMachineNo" runat="server" Text="机器:"></asp:Label><asp:DropDownList ID="ddlMachineNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMachineNo_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Label ID="lblMouldNo" runat="server" Text="模具:"></asp:Label><asp:DropDownList ID="ddlMouldNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMouldNo_SelectedIndexChanged"></asp:DropDownList>
                    产品:<asp:DropDownList ID="ddlProductNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductNo_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;
                    <asp:Label ID="Label1" runat="server" Text="第"></asp:Label><asp:DropDownList ID="ddlAction" runat="server" Width="50px" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>1</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Text="啤" ></asp:Label>
                    <asp:ImageButton ID="igbSured" runat="server" ImageAlign="Top" ImageUrl="~/images/btn_search.gif"
                        OnClick="igbSured_Click" />
                    <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" ImageAlign="Top" />&nbsp;<asp:DropDownList ID="ddlXAxisFlag" runat="server" Visible="false">
                    <asp:ListItem Value="minute">时间</asp:ListItem>
                    <asp:ListItem Selected="True" Value="beernum">啤数</asp:ListItem>
                    </asp:DropDownList></th>
            </tr>
     </table>
        &nbsp;
        
    <table  width="100%"  id="Tinf" runat="server" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#00FF00">
      <tr>
        <td width="78" height="23" class="tabPageFont" background="../images/tab_on.gif" style="CURSOR: hand" align="center">            
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click">周期图</asp:LinkButton>
        </td>
        <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">            
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click">温度图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">	        
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton_Click">压力图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">            
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton_Click">最大压力图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton_Click">预塑时间图</asp:LinkButton></td>
        <td width="78"  class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton_Click">填充时间图</asp:LinkButton></td>
        <td width="78" class="tabPageFont" background="../images/tab_off.gif" style="CURSOR: hand" align="center">
        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton_Click">射胶量图</asp:LinkButton></td>
        <td background="../images/topline_bg.gif" >
        <input id="hdnTarget" type="hidden" value="QualityTrack_Cycle" runat="server" style="width: 64px" />
        &nbsp;</td>
      </tr>
      <tr>
        <td colspan="8"  bgcolor="#FFFFFF">
            <iframe width="100%" id="subnet" runat="server" marginheight="0" height="600" frameborder="0" scrolling="no" overflow="hidden" allowtransparency="false"></iframe>        
        </td>
      </tr>
</table>


    </form>
</body>
</html>