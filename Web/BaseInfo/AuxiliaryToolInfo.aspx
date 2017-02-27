﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuxiliaryToolInfo.aspx.cs"
    Inherits="BaseInfo_AuxiliaryToolInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>辅助设备管理(AuxiliaryToolInfo)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/OpenFun.js"></script>
    
 <style type="text/css">
    .login{
	    position: relative;
	    display: none;
	    top: 20px;
	    left: 30px;
	    padding: 10px;
	    background-color: #ffffff;
	    text-align: center;
	    border: solid 2px;
	    border-color:#ffffff;	
	    z-index: 1;	
}
</style>
    <script type="text/javascript" language="javascript">
        function doref(id) {
            xid = id;
            var responsexx;
            var responseTxt;
            M("TextBox2").value = "";
            if (xid == "txtMouldCode") {
                M("Label9").innerText = "选择模具";
                M("lblTD").innerText = "模具编号:";
                responsexx = BaseInfo_AuxiliaryToolInfo.GetMouldMstr("1");
                responseTxt = BaseInfo_AuxiliaryToolInfo.GetMouldMstr("2");
                M("TD1").style.visibility = "visible";
            }
            else {
                M("Label9").innerText = "选择机器";
                M("lblTD").innerText = "机器编号:";
                responsexx = BaseInfo_AuxiliaryToolInfo.GetMachineNo("1");
                responseTxt = BaseInfo_AuxiliaryToolInfo.GetMachineNo("2");
                M("TD1").style.visibility = "visible";
            }

            //清空Select1的options
            for (var j = 0; j < M('Select1').options.length; j++) {
                M('Select1').options.remove(j);
                j = 0;
                //j--;
            }
            //新增Select1的options
            for (var i = 0; i < responsexx.value.length; i++) {
                var option = new Option(responsexx.value[i], responseTxt.value[i]);
                M('Select1').options[i] = option;
            }
        }

        function Sel(cid) {
            var responsexx;
            var responseTxt;
            if (xid == "txtMouldCode") {
                responsexx = BaseInfo_AuxiliaryToolInfo.GetMould(M("TextBox2").value, "1");
                responseTxt = BaseInfo_AuxiliaryToolInfo.GetMould(M("TextBox2").value, "2");
            }
            else {
                responsexx = BaseInfo_AuxiliaryToolInfo.GetMachine(M("TextBox2").value, "1");
                responseTxt = BaseInfo_AuxiliaryToolInfo.GetMachine(M("TextBox2").value, "2");
            }
            
            //清空Select1的options
            for (var j = 0; j < M('Select1').options.length; j++) {
                M('Select1').options.remove(j);
                j = 0;
            }
            //新增Select1的options
            for (var i = 0; i < responsexx.value.length; i++) {
                var option = new Option(responsexx.value[i], responseTxt.value[i]);
                M('Select1').options[i] = option;
            }
        }
        
        function ko(id) {
            if (M('login').style.display != 'none') {
                var ds = M(id);
                var e = "";
                var txt = "";
                for (var i = 0; i < ds.options.length; i++) {
                    if (ds.options[i].selected) {
                        e += ds.options[i].value + ",";
                        txt += ds.options[i].text.substring(0, ds.options[i].text.indexOf("    ")) + ",";
                    }
                }
                e = e.substring(0, e.length - 1);
                txt = txt.substring(0, txt.length - 1);
                if (xid == "txtMouldCode") {
                    M("txtMouldNo").value = "";
                    M("txtMouldNo").innerText = txt;
                }
                else {
                    M("txtMachineNo").value = "";
                    M("txtMachineNo").innerText = txt;
                }
                closes();
            }
        }
    </script>
 </head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
        <tr>
            <td valign="top">
                <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            当前位置:基础资料 -> 辅助设备管理
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server" Width="99px">
                                        <asp:ListItem Value="FixtureCode">设备编号</asp:ListItem>
                                        <asp:ListItem Value="AssetCode">资产编号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="btnNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                    <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="5px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td style="background-image: url(../images/bg_title.gif); height: 17px;">
                                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="12" CssClass="itemtable" OnRowDataBound="GridView1_RowDataBound"
                                        BorderWidth="0px" CellSpacing="1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItemInner" runat="server" />
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    <input id="chkAll" type="checkbox" onclick="selectAll(this);" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="26px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                                                <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField DataTextField="DeviceCode" CommandName="select" HeaderText="设备编号" />
                                            <asp:BoundField DataField="DeviceDesc" HeaderText="设备描述" />
                                            <asp:BoundField DataField="MouldNo" HeaderText="模具编号" />
                                            <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                            <asp:BoundField DataField="Manufacturers" HeaderText="制造厂商" />
                                            <asp:BoundField DataField="Remark" HeaderText="备注" />
                                        </Columns>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDataCount" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                            <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                            <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif"
                                                                OnClick="CtrlPageInfo_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex"
                                                                ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                                            <input id="hdnFlag" type="hidden" runat="server" style="width: 13px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="height: 28px">
                                    <asp:ImageButton ID="btnInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" />
                                    <input id="Hidden1" runat="server" style="width: 3px" type="hidden" />
                                    <input id="hdnID" runat="server" style="width: 1px" type="hidden" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(../images/bg_title.gif); height: 17px;">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right" class="label" style="height: 26px; width: 83px;">
                                    <asp:Label ID="Label1" runat="server" Text="设备编号:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td style="height: 26px; width: 232px;">
                                    <asp:TextBox ID="txtDeviceCode" runat="server" CssClass="textboxodl" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvItem_Code" runat="server" ControlToValidate="txtDeviceCode"
                                        ErrorMessage="必填" Width="31px"></asp:RequiredFieldValidator>
                                </td>
                                <th align="right" style="height: 26px; width: 83px;">
                                    设备描述:
                                </th>
                                <td style="height: 26px" colspan="3">
                                    <asp:TextBox ID="txtDeviceDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                        Width="98%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="height: 18px; width: 83px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="资产编号:"></asp:Label>
                                </th>
                                <td style="width: 232px; height: 18px">
                                    <asp:TextBox ID="txtAssetCode" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                                </td>
                                <th align="right" style="height: 18px; width: 83px;">
                                    说明:
                                </th>
                                <td style="height: 18px" colspan="3">
                                    <span style="background-color: #ebeff0">
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="98%"></asp:TextBox></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 83px">
                                    功率:
                                </th>
                                <td style="width: 232px">
                                    <asp:TextBox ID="txtPower" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                                    &nbsp;KW/H<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txtPageIndex" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right" style="width: 83px">
                                    制造厂商:
                                </th>
                                <td style="width: 177px">
                                    <asp:TextBox ID="txtManufacturers" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                                </td>
                                <th align="right" style="width: 99px">
                                    制造日期:
                                </th>
                                <td>
                                    <input id="txtMadeDate" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                        onselectstart="return false;" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 83px">
                                    机器编号:
                                </th>
                                <td style="height: 18px" colspan="5">
                                    <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textbox"  TextMode="MultiLine" Width="86%">
                                    </asp:TextBox>
                                    <a href="#" onclick="opens('txtMachineNo')" style="color: #ff3333">选择</a>
                                </td>
                            </tr>
                            <tr>
                                 <th align="right" style="width: 83px">
                                    模具编号:
                                </th>
                                <td style="height: 18px" colspan="5">
                                    <asp:TextBox ID="txtMouldNo" runat="server" CssClass="textbox" TextMode="MultiLine" Width="86%"></asp:TextBox>
                                    <a href="#" onclick="opens('txtMouldCode')" style="color: #ff3333">选择</a>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 83px">
                                    图片:
                                </th>
                                <td style="width: 232px">
                                    <asp:FileUpload ID="fudProcessPhoto" runat="server" CssClass="textbox" Width="192px" />
                                </td>
                                <th align="right" style="width: 83px">
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="备注:"></asp:Label>
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
                                        Width="98%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6">
                                    <asp:Image ID="Image1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <div id="login" class="login" style="background-color: #f9f9f9">
            <table border="0.1px" width="100%">
                <tr style="width: 100%; height: 24px;">
                    <td colspan="2" align="center" style="width: 98%">
                        <span style="font-weight: bold; font-size: 20px;">
                            <asp:Label ID="Label9" runat="server" Text="选择模具"></asp:Label>
                        </span>
                    </td>
                    <td align="right" colspan="1" style="width: 5%;" valign="top">
                        <a href="#" onclick="closes();">×</a>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" valign="middle" id="TD1" runat="server">
                        <asp:Label ID="lblTD" runat="server" Text="模具编号:"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="100px" valign="middle"></asp:TextBox>
                        <input
                            id="Button1" type="button" onclick="Sel('Select1')" style="border-right: #ffffff 0px solid;
                            border-top: #ffffff 0px solid; background-image: url(../images/btn_search.gif);
                            border-left: #ffffff 0px solid; width: 67px; border-bottom: #ffffff 0px solid;
                            height: 24px" tabindex="-1" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" style="height: 224px">
                        <select id="Select1" name="Select1" multiple runat="server" size="20" style="width: 266px;
                            height: 300px; border: 1px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <img src="../images/btn_yes.gif" onclick="ko('Select1')" id="IMG1" />
                        &nbsp;<img src="../images/btn_cancel.gif" onclick="closes();" /></td>
                </tr>
            </table>
            <div id="panel">
            </div>
        </div>
    </form>
</body>
</html>
