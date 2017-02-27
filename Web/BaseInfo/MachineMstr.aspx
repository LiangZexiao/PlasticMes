<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MachineMstr.aspx.cs" Inherits="BaseInfo_MachineMstr" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机器信息</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

    <script type="text/javascript">
        function ValidateMachine_Code(Mould) {
            var s = Mould.value.substr(0, 2);
            if (s != '' && s != null) {
                if (s == 'IM') {
                } else {
                    alert('机器编号必须以 IM 开头！');
                    Mould.focus();
                    Mould.select();
                }
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
                            当前位置:基础资料 -> 注塑机器管理
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                   &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <asp:ListItem Value="Machine_Code">机器编号</asp:ListItem>
                                        <asp:ListItem Value="Machine_Type">型号</asp:ListItem>
                                        <asp:ListItem Value="Machine_EquipmentNo">设备编号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                        PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px"
                                        CellSpacing="1">
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
                                            <asp:ButtonField DataTextField="ID" HeaderText="序号">
                                                <ItemStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField DataTextField="Machine_Code" CommandName="select" HeaderText="机器编号" />
                                            <asp:BoundField DataField="Machine_Type" HeaderText="型号" />
                                            <asp:BoundField DataField="Machine_Manufacturer" HeaderText="制造厂商" />
                                            <asp:BoundField DataField="Machine_AssetNo" HeaderText="资产编号" Visible="False" />
                                            <asp:BoundField DataField="Machine_EquipmentNo" HeaderText="设备编号" />
                                            <asp:BoundField DataField="Machine_MadeDate" HeaderText="制造日期" Visible="False" />
                                            <asp:BoundField DataField="Machine_PurchaseDate" HeaderText="入厂日期" Visible="False" />
                                            <asp:BoundField DataField="Machine_Status" HeaderText="机器状态" Visible="False" />
                                            <asp:BoundField DataField="Machine_LockPower" HeaderText="锁模吨位" />
                                            <asp:BoundField DataField="ScrewDiameter" HeaderText="螺杆直径" Visible="False" />
                                            <asp:BoundField DataField="Machine_ShotQty" HeaderText="射胶量" />
                                            <asp:BoundField DataField="Machine_InjectionPress" HeaderText="注塑压力" Visible="False" />
                                            <asp:BoundField DataField="Machine_PushDistance" HeaderText="顶出行程" Visible="False" />
                                            <asp:BoundField DataField="Machine_LoadMouldLgt" HeaderText="容模长度" />
                                            <asp:BoundField DataField="Machine_LoadMouldWdt" HeaderText="容模宽度" Visible="False" />
                                            <asp:BoundField DataField="MinMouldThick" HeaderText="最小容模厚度" Visible="False" />
                                            <asp:BoundField DataField="MaxMouldThick" HeaderText="最大容模厚度" Visible="False" />
                                            <asp:BoundField DataField="ShotDiameter" HeaderText="射嘴直径" Visible="False" />
                                            <asp:BoundField DataField="HydPressTackOut" HeaderText="液压抽芯" Visible="False" />
                                            <asp:BoundField DataField="DrawPoleDistance" HeaderText="拉杆间距" Visible="False" />
                                            <asp:BoundField DataField="Robort" HeaderText="机械手" Visible="False" />
                                            <asp:BoundField DataField="Machine_Power" HeaderText="功率" Visible="False" />
                                            <asp:BoundField DataField="Machine_MaterialChgAmt" HeaderText="换料容量" Visible="False" />
                                            <asp:BoundField DataField="Remark" HeaderText="最小注塑周期" Visible="False" />
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
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                            <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
                                                            <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                                                OnClick="CtrlPageInfo_Click" ImageAlign="Top" />
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
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                        ImageAlign="Top" />
                                    <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                        ImageAlign="Top" />
                                    <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" CausesValidation="false" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" ImageAlign="Top" />
                                    <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right" class="label">
                                    <asp:Label ID="Label1" runat="server" Text="机器编号:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_Code" runat="server" CssClass="textboxodl" onblur=" ValidateMachine_Code(this)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMachine_Code" runat="server" ErrorMessage="必填"
                                        ControlToValidate="txtMachine_Code"></asp:RequiredFieldValidator>
                                </td>
                                <th align="right">
                                    设备编号:&nbsp;
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_EquipmentNo" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                                <th align="right">
                                    资产编号:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_AssetNo" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    机器型号:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_Type" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="10px"></asp:TextBox>
                                </td>
                                <th align="right">
                                    制造厂商:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_Manufacturer" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                                <th align="right">
                                    制造日期:
                                </th>
                                <td>
                                    <input id="txtMachine_MadeDate" runat="server" class="textbox" onfocus="setday(this)"
                                        onkeypress="return false" onselectstart="return false;" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    锁模吨位:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_LockPower" runat="server" CssClass="textbox">0</asp:TextBox>
                                    T<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                        ControlToValidate="txtMachine_LockPower" Display="Static" ErrorMessage="有误" ValidationExpression="^[0-9]*[0-9][0-9]*$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    顶出行程:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_PushDistance" runat="server" CssClass="textbox"></asp:TextBox>
                                    mm<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                        ControlToValidate="txtMachine_PushDistance" Display="Static" ErrorMessage="有误"
                                        ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    最大射胶量:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_ShotQty" runat="server" CssClass="textboxodl"></asp:TextBox>
                                    <span style="font-size: 10pt">g<span></span></span><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtMachine_ShotQty"
                                        Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMachine_ShotQty"
                                            ErrorMessage="必填"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    容模长度:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_LoadMouldLgt" runat="server" CssClass="textbox"></asp:TextBox>
                                    mm<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                        ControlToValidate="txtMachine_LoadMouldLgt" Display="Static" ErrorMessage="有误"
                                        ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    容模宽度:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_LoadMouldWdt" runat="server" CssClass="textbox"></asp:TextBox>
                                    mm<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="txtMachine_LoadMouldWdt" Display="Static" ErrorMessage="有误"
                                        ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    容模厚度:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMinMouldThick" runat="server" CssClass="textbox" Width="54px"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtMinMouldThick"
                                        Display="Dynamic" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>至<asp:TextBox
                                            ID="txtMaxMouldThick" runat="server" CssClass="textbox" Width="54px"></asp:TextBox>
                                    mm<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                        ControlToValidate="txtMaxMouldThick" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator><asp:CompareValidator
                                            ID="CompareValidator1" runat="server" ControlToCompare="txtMaxMouldThick" ControlToValidate="txtMinMouldThick"
                                            Display="Dynamic" ErrorMessage="最大不能小于最小" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    射嘴直径:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtShotDiameter" runat="server" CssClass="textbox"></asp:TextBox>
                                    mm<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                        ControlToValidate="txtShotDiameter" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    液压抽芯:
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblHydPressTackOut" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" colspan="2" rowspan="5">
                                    <asp:Image ID="Image1" runat="server" Height="16px" Width="16px" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    拉杆间距:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtDrawPoleDistance" runat="server" CssClass="textbox"></asp:TextBox>
                                    mm
                                </td>
                                <th align="right">
                                    机械手:
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblRobort" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    换料容量:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_MaterialChgAmt" runat="server" CssClass="textbox"></asp:TextBox>
                                    <span>mm<span lang="EN-US" style="font-size: 7pt; vertical-align: super; font-family: 'Times New Roman';
                                        mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 宋体; mso-font-kerning: 1.0pt;
                                        mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">3</span></span><asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtMachine_MaterialChgAmt"
                                            Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right">
                                    功率:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMachine_Power" runat="server" CssClass="textbox"></asp:TextBox>
                                    Kw/h<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                        ControlToValidate="txtMachine_Power" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    机器图片:
                                </th>
                                <td>
                                    <asp:FileUpload ID="fudPhoto" runat="server" CssClass="textbox" Width="192px" />
                                </td>
                                <th align="right">
                                </th>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    备注:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
                                        Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
