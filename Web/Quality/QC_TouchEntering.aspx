<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QC_TouchEntering.aspx.cs" Inherits="Quality_QC_TouchEntering" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>平板上录入次品数量</title>
    <style type="text/css">
        .style1
        {
            width: 289px;
        }
        .style2
        {
            width: 252px;
        }
        .style3
        {
            width: 206px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">


    <table style="width: 80%;">
        <tr bgcolor="#CCFFFF">
            <td class="style1" align="center">
                &nbsp;
                次品原因</td>
            <td class="style2" align="center">
                &nbsp;
                增加</td>
            <td align="center" class="style3">
                次品数量</td>
            <td align="center">
                &nbsp;
                减少</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
                <asp:Button ID="btUP" runat="server" Text="Button" onclick="btUP_Click" />
            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btDown" runat="server" Text="Button" onclick="btDown_Click" />
            </td>
            
        </tr>

    </table>

    </form>
</body>
</html>
