<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MyLogin" %>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
<title>注塑-MES</title>
<link href="images/login.css" type="text/css" rel="stylesheet" />
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<form id="form1" runat="server">
<table height="100%" width="100%" align="center" id="tbl_10" style="width: 100%; height: 100%">
  <tr>
    <td style=""><!-- login form -->
     <table borderColor="#e4e4e4" cellspacing="0" cellpadding="10" align="center" border="1" id="tbl_9" style="width: 60%; height: 325px">
        <tr>
          <td align="center" style="border:none;">

            <table border="0" cellpadding="0" cellspacing="0" id="tbl_8" style="height: 100%; width: 568px;">
              <tr>
                <td align="center" background="images/welcome_bg.jpg" >
                
                  <table border="0" cellpadding="0" cellspacing="0" id="tbl_7" style="height: 100%; width: 100%;">
                    <tr>
                      <td style="height: 43%; width: 293px">&nbsp;</td>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td style="width: 266px">&nbsp;</td>
                      <td style="width: 8.5%; height: 10%;" class="font_login">帐号：</td>
                      <td><input id="txtUserName" runat="server" maxlength="16" size="16" name="username" class="INPUT" accesskey="0" /></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td class="font_login">密码：</td>
                      <td><input id="txtPassword" runat="server" type="password" maxlength="16" size="16" name="password" class="INPUT" accesskey="1" /></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                      <td noWrap style="height: 12%">
                      <asp:ImageButton ID="ibnLogin" runat="server" ImageUrl="~/images/btn_login.gif" OnClick="ImageButton_Click" AccessKey="2" />
                      <img src="images/btn_cancel.gif" onclick="window.close()" />
                      </td>
                    </tr>
                    <tr>
                      <td style="width: 266px">&nbsp;</td>
                      <td>&nbsp;</td>
                      <td noWrap>&nbsp;</td>
                    </tr>
                    <tr>
                      <td style="width: 266px">&nbsp;</td>
                      <td colspan="2">&nbsp;</td>
                      </tr>
                    <tr align="center">
                      <td colspan="3" class="font_gray">系统版本：注塑生产 MES V2.0 系统开发：<a href="http://http://www.borch-machinery.com/" target="_blank">博创智能装备股份有限公司</a></td>
                    </tr>
                    </table>
                    
                  </td>
              </tr>
        </table>

        </td>
        </tr>
      </table><!-- end of login form -->

      </td>
      </tr>
    </table>
</form>
</body>
</html>