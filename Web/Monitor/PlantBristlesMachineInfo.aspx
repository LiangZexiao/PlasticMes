﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlantBristlesMachineInfo.aspx.cs"
    Inherits="Monitor_PlantBristlesMachineInfo" ValidateRequest="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
<meta http-equiv="Refresh" content="300" runat="server" id="RefreshPlantBristlesMachineInfo" />
    <title>植毛机器监视</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                <tr>
                    <td style="background-image: url(../images/bg_title.gif); height: 22px;">
                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作</td>
                </tr>
            </table>
            <table style="width: 100%" class="itemtable" cellspacing="1" cellpadding="2" border="0">
                <tr>
                    <th valign="middle">
                        &nbsp;机器车间:<asp:DropDownList ID="ddlMachine_SeatCode" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="DorpDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                        机器状态:<asp:DropDownList ID="ddlMachineSate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DorpDownList_SelectedIndexChanged">
                            <asp:ListItem Value="All">全部</asp:ListItem>
                            <asp:ListItem Value="Green">正常生产</asp:ListItem>
                            <asp:ListItem Value="Red">停机</asp:ListItem>
                            <asp:ListItem Value="Fuchsia">未派工在生产</asp:ListItem>
                            <asp:ListItem Value="Black">未派工</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                        <asp:ImageButton ID="igbSured" runat="server" ImageUrl="~/images/btn_yes.gif" OnClick="igbSured_Click"
                            Visible="false" ImageAlign="Top" />
                        <asp:DropDownList ID="ddlMachineCode" runat="server" Visible="False">
                        </asp:DropDownList>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" class="section-content" style="padding-right: 0px;
                        margin-top: 0px; margin-left: 0px; width: 100%; padding-top: 0px">
                        <tr>
                            <td valign="top" style="padding-right: 0px; margin-top: 0px; margin-left: 0px; padding-top: 0px;
                                width: 100%; padding-left: 0px;">
                                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlShow" runat="server" Width="100%">
                                                <asp:Table ID="Table1" runat="server" Width="100%">
                                                </asp:Table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="tablefoot" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblShow" runat="server"></asp:Label>
                                                            <asp:Label ID="Green" runat="server" BackColor="Green" Width="15px"></asp:Label>
                                                            <asp:Label ID="lblGreen" runat="server"></asp:Label>
                                                            <asp:Label ID="Red" runat="server" BackColor="Red" Width="15px"></asp:Label>
                                                            <asp:Label ID="lblRed" runat="server"></asp:Label>
                                                            <asp:Label ID="Fuchsia" runat="server" BackColor="Fuchsia" Width="15px"></asp:Label>
                                                            <asp:Label ID="lblFuchsia" runat="server"></asp:Label>
                                                            <asp:Label ID="Black" runat="server" BackColor="Black" Width="15px"></asp:Label>
                                                            <asp:Label ID="lblBlack" runat="server"></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
                                            </asp:Timer>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script type="text/javascript">
        Sys.Application.add_load(function() 
        { 
        var form = Sys.WebForms.PageRequestManager.getInstance()._form; 
        form._initialAction = form.action = window.location.href; 
        }); 
    </script>
</body>
</html>
