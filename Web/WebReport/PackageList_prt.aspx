<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PackageList_prt.aspx.cs" Inherits="WebReport_PackageList_prt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtProdNO" runat="server"></asp:TextBox>
        <asp:Button ID="btnPrint" runat="server" Text="打印报表" OnClick="btnPrint_Click" CssClass="button" /></div>
    </form>
</body>
</html>
