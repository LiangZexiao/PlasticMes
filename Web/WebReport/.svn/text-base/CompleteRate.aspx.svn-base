<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompleteRate.aspx.cs" Inherits="WebReport_CompleteRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label id="lblLocal" runat="server" ForeColor="Blue" Text="当前位置:报表管理-->生产达成率报表"></asp:Label>
    </div>
                    <table style="width: 100%; border-collapse: collapse;" border="1" cellpadding="0" cellspacing="0" class="table row">
            <tr>
                <td align="right" style="width: 30%">
                    生产日期:</td>
                <td align="left">
                    <input id="txtStartDate" runat="server" class="textbox" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" />&nbsp;
                    至&nbsp;<input id="txtEndDate" runat="server" class="textbox" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" /></td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click"
                        Text="打印报表" CssClass="button" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
