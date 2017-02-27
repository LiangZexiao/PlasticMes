<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProdPlan.aspx.cs" Inherits="WebReport_ProdPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>生产计划报表</title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div><asp:Label id="lblLocal" runat="server" Text="当前位置:报表管理-->生产计划报表" ForeColor="Blue"></asp:Label>
    </div>
               <table style="width: 100%; border-collapse: collapse;" border="1" class="table row">
                        <tr>
                            <td align="right" style="width: 40%">
                                生产日期：</td>
                            <td align="left"><INPUT onselectstart="return false;" runat="server" onkeypress="return false" id="txtStartDate" onfocus="setday(this)" class="textbox" readonly="true" /></td>
                        </tr>
                   <tr visible="false">
                       <td align="right">
                                报表类型：
                       </td>
                       <td align="left"><asp:DropDownList runat="server" id="ddlReportType" >
                           <asp:ListItem Value="D">日报表</asp:ListItem>
                           <asp:ListItem Value="W">周报表</asp:ListItem>
                           <asp:ListItem Value="M">月报表</asp:ListItem>
                       </asp:DropDownList></td>
                   </tr>
                   <tr>
                       <td align="right">
                       </td>
                       <td align="left">
                                <asp:Button ID="btnPrint" runat="server" Text="打印报表" OnClick="btnPrint_Click" CssClass="button" /></td>
                   </tr>
                    </table>
    </form>
</body>
</html>
