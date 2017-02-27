<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StopReas.aspx.cs" Inherits="Quality_StopReas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>停机原因统计柏拉图</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <table id="tblBiggest" border="0" cellpadding="0" cellspacing="0" class="section-content">
            <tr>
                <td valign="top">
                
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:报表管理 -> 停机原因统计柏拉图</td>
          </tr>
          </table>
          <br />
          

          <table class="itemtable" cellspacing="1" cellpadding="2" border="0" style="width: 100%">
              <tr>
                <td style="background-image: url(../images/bg_title.gif); height: 18px;">　　条件</td>
              </tr>
          </table> 


<table border="0" cellpadding="1" cellspacing="1" class="texttable" style="border-collapse: collapse; width: 100%;">
  <tr>
        <th align="right" style="width: 283px">
            机器编号:</th>
        <td align="left">
            <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="dropdownlist">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <th align="right" style="width: 283px">
                    <asp:Label ID="lblProductDate" runat="server" Text="生产时间:"></asp:Label></th>
        <td align="left">
                    <input id="txtbDate" runat="server" class="textbox" name="txtbDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" style="width: 121px" type="text" />
                    <input id="txtbTime" runat="server" class="textbox" maxlength="5" name="txtTime1"
                        oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                        onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                        size="5" style="width: 40px" type="text" value="07:20" />至<input id="txteDate" runat="server"
                            class="textbox" name="txteDate" onfocus="setday(this)" onkeypress="return false"
                            onselectstart="return false;" style="width: 121px" type="text" />
                    <input id="txteTime" runat="server" class="textbox" maxlength="5" name="txtTime2"
                        oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                        onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                        style="width: 40px" type="text" value="07:20" />
                    <asp:CompareValidator ID="cpvActualStart_EndDate" runat="server" ControlToCompare="txteDate"
                        ControlToValidate="txtbDate" Display="Dynamic" ErrorMessage="结束要大于开始" Operator="LessThanEqual"
                        Type="Date"></asp:CompareValidator></td>
    </tr>
            <tr>
                <td align="right" style="width: 283px">
                </td>
                <td align="left">
<asp:ImageButton ID="igbPrint" runat="server" ImageUrl="~/images/btn_print.gif" OnClick="igbPrint_Click" /></td>
            </tr>
        </table>

        </td>
            </tr>
        </table>
    </form>
</body>
</html>