<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MdyPassword.aspx.cs" Inherits="Administrator_MdyPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <title>用户密码修改(MdyPassword)</title>
</head>
<body>
    <form id="form1" runat="server">

          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:系统管理 -> 用户密码修改</td>
          </tr>
          </table>
          
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="width: 100%" cellpadding="0" cellspacing="0" id="tbl_00">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">

                        <table border="0" style="border-collapse: collapse; width: 40%;" id="tbl_01" cellpadding="1" cellspacing="1" class="texttable">
                        <tr>
                            <td align="right" colspan="2">
                 <table class="itemtable" cellspacing="0" cellpadding="0" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)" align="left"></td>
                      </tr>
                    </table>
                    </td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 35%;">你的帐号：</th>
                            <td align="left" >
                                <asp:TextBox ID="txtUserID" runat="server" ReadOnly="True" CssClass="textbox" ForeColor="Red"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 35%">
                                旧密码：</th>
                            <td align="left">
                                <input id="pwdOld" type="password" class="textbox" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvOld" runat="server" ErrorMessage="不能为空!!" ControlToValidate="pwdOld" Display="Dynamic"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 35%;">
                                新密码：</th>
                            <td align="left">
                                <input id="pwdNew1" type="password" class="textbox" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvNew1" runat="server" ErrorMessage="不能为空!!" ControlToValidate="pwdNew1" Display="Dynamic"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 35%">
                                确认新密码：</th>
                            <td align="left">
                                <input id="pwdNew2" type="password" class="textbox" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvNew2" runat="server" ErrorMessage="不能为空!!" ControlToValidate="pwdNew2" Display="Dynamic"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 35%;">
                            </td>
                            <td align="left" >
                                <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" /></td>
                        </tr>
                    </table>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table> 
    </form>
</body>
</html>
