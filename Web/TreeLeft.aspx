﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeLeft.aspx.cs" Inherits="TreeLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>Plastics MES系统管理平台</title>
     <link href="Css/Style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <table id="tbltree" style="height : 80%">
        
        <tr>
        <td valign="top">
                <asp:TreeView ID="TreeView1" runat="server" ShowLines="True">
            <RootNodeStyle />
        </asp:TreeView>
        
        </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
