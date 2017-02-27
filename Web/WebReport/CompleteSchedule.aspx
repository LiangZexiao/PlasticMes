<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompleteSchedule.aspx.cs" Inherits="WebReport_CompleteSchedule" %>

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
    <asp:Label id="lblLocal" runat="server" Text="当前位置:报表管理-->生产完成进度表" ForeColor="Blue"></asp:Label>
    </div>
 <table style="width: 100%; border-collapse: collapse;" border="1" cellpadding="0" cellspacing="0" class="table row">
            <tr>
                <td align="right" style="width: 30%">
                    生产单号:</td>
                <td align="left">
                    <asp:TextBox ID="txtStartProduceNO" runat="server" CssClass="textbox"></asp:TextBox>
                    至
                    <asp:TextBox ID="txtEndProduceNO" runat="server" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    产品编号:</td>
                <td align="left">
                    <asp:TextBox ID="txtStartProductNO" runat="server" CssClass="textbox"></asp:TextBox>
                    至
                    <asp:TextBox ID="txtEndProductNO" runat="server" CssClass="textbox"></asp:TextBox></td>
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
