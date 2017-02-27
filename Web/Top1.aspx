<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top1.aspx.cs" Inherits="Top1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="images/css.css" type="text/css" rel="stylesheet" />
    <title>无标题页</title>
    <script type="text/javascript" language="javascript">
     function ExitSys()
     {
        if(!window.confirm("你要退出系统吗?"))
        {
            return event.returnValue = false;
        }
        else
              window.top.location="login.aspx";
     }
     function OpenWin()
     {     
        window.open('Tracker.aspx','_newwindow','status=no,scrollbars=yes,resizable=no,width=380,height=265,left=270,top=100');
     }
     function btnOpen()
     {
        window.open('http://www.koimy.com','_newchieftec','status=no,scrollbars=yes,resizable=no,width=380,height=265,left=270,top=100');
     }
    </script>
</head>
<body class="Top_BODY">
<form id="form1" runat="server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/top_bg.jpg">
      <tr>
        <td style="height: 55px"><a href="http://www.koimy.com" target="_blank"><asp:Image ID="imgLeft" runat="server" ImageUrl="images/top_left.jpg" width="337" height="58"  /></a></td>
        <td style="height: 55px"><div align="right">
            <asp:Image ID="imgRight" runat="server" ImageUrl="images/top_right.jpg" width="337" height="58" />
            </div>
        </td>
      </tr>
    </table>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="font_white">
            <td background="images/bg_welcome.gif" style="padding-left: 10px; height: 26px;" valign="top">
                欢迎您：<asp:Label ID="lblUser" runat="server" Text=""></asp:Label></td>
            <td background="images/bg_welcome.gif" style="padding-left: 10px; height: 26px;" align="center">
                <asp:Label ID="lblNotice1" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblNotice2" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblNotice3" runat="server" Text=""></asp:Label>
                
                </td>
            <td background="images/bg_welcome.gif" style="height: 26px" valign="top">


      <table align="right" cellpadding="0" cellspacing="0" style="height: 17px">
      <tr>
<!--
        <td visible="false" width="80" valign="bottom"><a class="toolbaricon" title="生产监视" href="#"><span class="font_boldblue"><img src="images/icon_systemMant.gif" width="14" height="13" border="0"></span> <span class="font_white" visible="false">生产监视</span></a></td>
        <td visible="false" width="80" valign="bottom"><a class="toolbaricon" title="库存管理" href="#"><span class="font_boldblue"><img src="images/icon_document.gif" width="15" height="15" border="0"></span> <span class="font_white" visible="false">库存管理</span></a></td>
        <td visible="false" width="80" valign="bottom"><a class="toolbaricon" title="基础资料" href="#"><span class="font_boldblue"><img src="images/ico_basedata.gif" width="16" height="16" border="0"></span> <span class="font_white" visible="false">基础资料</span></a></td>
        <td visible="false" width="80" valign="bottom"><a class="toolbaricon" title="系统管理" href="#"><span class="font_boldblue"><img src="images/icon_sys.gif" width="16" height="16" border="0"></span> <span class="font_white" visible="false">系统管理</span></a></td>
-->
        <td valign="bottom" visible="false">
        <%--<a class="toolbaricon" onclick="OpenWin()"> <span class="font_boldblue"><img src="images/icon_systemMant.gif" width="16" height="16" border="0" style="cursor:hand"></span>  <span class="font_white" style="cursor:hand">报警消息</span></a>&nbsp;--%>
        </td>
        <td width="80" valign="bottom">
        <a class="toolbaricon" title="退出系统" onclick="ExitSys()"><span class="font_boldblue" style="vertical-align: middle"><img src="images/icon_exitsystem.gif" width="16" height="16" border="0" style="cursor:hand"></span> <span class="font_white" style="cursor:hand">退出系统</span></a>
        </td>
      </tr>
      </table>
            </td>
        </tr>
    </table>
    
    
 </form>
</body>
</html>

