<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QualityReport.aspx.cs" Inherits="Quality_QualityReport" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>质量跟踪报表(QualityReport)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px" valign="middle">当前位置:品质管理 -> 质量跟踪报表</td>
          </tr>
          </table>
<br />
    
              <table class="itemtable" cellspacing="1" cellpadding="2" border="0" style="width: 100%">
              <tr>
                <td height="22" style="background-image: url(../images/bg_title.gif)">　　条件</td>
              </tr>
          </table> 
          
        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
       <tr>
           <th align="right" style="width: 40%">
                    <asp:Label ID="lblDate" runat="server" Text="生产时间:"></asp:Label>
                </th>
                <td>
                    <input id="txtbDate" runat="server" class="textbox" name="txtbDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" style="width: 77px" />
                    <input id="txtbTime" runat="server" class="textbox" maxlength="5" name="txtTime1"
                        oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                        onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                        size="5" style="width: 40px" type="text" value="07:20" />至<input id="txteDate" runat="server" class="textbox" name="txteDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" style="width: 77px" />
                    <input id="txteTime" runat="server" class="textbox" maxlength="5" name="txtTime2"
                        oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                        onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                        style="width: 40px" type="text" value="07:20" />
                    <asp:CompareValidator ID="cpvActualStart_EndDate" runat="server" ControlToCompare="txteDate"
                        ControlToValidate="txtbDate" Display="Dynamic" ErrorMessage="结束要大于开始" Operator="LessThanEqual"
                        Type="Date"></asp:CompareValidator></td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="lblMachineNo" runat="server" Text="机器编号:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="dropdownlist" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="lblMouldNo" runat="server" Text="模具编号:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlMouldNo" runat="server" CssClass="dropdownlist" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="lblProductNo" runat="server" Text="产品编号:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlProductNo" runat="server" CssClass="dropdownlist" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <th align="right">
                </th>
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
