<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>注塑MES制造执行系统</title>
    <link href="Css/Style.css" type="text/css" rel="stylesheet" />
    <script language="JavaScript" type="text/javascript">
//      if (window.opener==null)
//      {
//          window.open(window.location.href, "", "channelMode");   //打开类似F11的窗口
//          window.opener = "tucb";     //加了这句在IE5.5+浏览器里就不会有关闭窗口的提示
//          window.close();
//      }
    </script>
</head>

    <FRAMESET border="0" framespacing="0" rows="80,16%" frameborder="0">
    <FRAME name="banner" src="Top1.aspx" noresize scrolling="no">
    <FRAMESET name="framework" border="0" framespacing="0" cols="16.1%,10,*">
    <FRAME name="contents" src="ListLeft.aspx" noresize>
    <FRAME name="switch" marginwidth="0" marginheight="0" src="Switch.htm" scrolling="no">
    <FRAME name="main" src="Main.aspx" noresize>    
    </FRAMESET>    
    <NOFRAMES></NOFRAMES>
	</FRAMESET>
<%--	<FRAMESET border="0" framespacing="0" rows="10,16%" frameborder="0">
	<FRAME name="banner" src="Top.aspx" noresize scrolling="no">
	</FRAMESET>--%>
</html>
