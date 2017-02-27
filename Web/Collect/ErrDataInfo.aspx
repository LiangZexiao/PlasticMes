<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrDataInfo.aspx.cs" Inherits="Collect_ErrDataInfo" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>异常处理(ErrDataInfo)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script language="javascript" type="text/javascript">
        function GetDispatchNo(sender, args) {
            var txtNo = document.getElementById("txtDispatchNo").value;
            var arryList = Collect_ErrDataInfo.getSearchDispatchNo(txtNo);

            if (arryList.value == "") {
                document.getElementById("txtDispatchNo").value = "";
                document.getElementById("txtDispatchNo").focus();
                document.getElementById("txtDispatchNo").select();
                window.alert("无此工单信息!");
                args.isvalid = false;
            }
            else {
                document.getElementById("txtMouldNo").innerText = arryList.value[0];
                document.getElementById("txtMachineNo").innerText = arryList.value[1];
                
                form1.txtHiddenMouldNo.value = arryList.value[0];
                form1.txtHiddenMachineNo.value = arryList.value[1];
                args.isvalid = true;
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
                            当前位置:数据采集 -> 异常记录
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <asp:ListItem Value="MouldNo">模具编号</asp:ListItem>
                                        <asp:ListItem Value="DispatchNo">派工单号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox" Height="22px"></asp:TextBox>
                                    <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="imgBtExcel" runat="server" ImageAlign="Top" ImageUrl="~/images/button_export.gif"
                                        OnClick="imgBtExcel_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 浏览
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1"  runat="server"  CellPadding="2" Width="100%" AutoGenerateColumns="False"
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
                                            <asp:ButtonField DataTextField="MachineNo" CommandName="select" HeaderText="机器编号">
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="MouldNo" HeaderText="模具编号" />
                                            <asp:BoundField DataField="DispatchNo" HeaderText="派工单号" />
                                            <asp:BoundField DataField="WorkOrderNo" HeaderText="生产单号" Visible="false" />
                                            <asp:BoundField DataField="OriginalData" HeaderText="原始数据" />
                                            <asp:BoundField DataField="ModifyData" HeaderText="修正数据" />
                                            <asp:BoundField DataField="UploadDate" HeaderText="上传时间" Visible="false" />
                                            <asp:BoundField DataField="ModifyFlag" HeaderText="修正标志" />
                                            <asp:BoundField DataField="InputFlag" HeaderText="导入标志" />
                                            <asp:BoundField DataField="Operator" HeaderText="操作人" Visible="false" />
                                            <asp:BoundField DataField="OperatorDate" HeaderText="操作时间" Visible="false" />
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
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" CausesValidation="false" />
                                    <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" />
                                    &nbsp;
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                                    <input id="hdnID" runat="server" class="textbox" style="width: 20px" type="hidden" />
                                     <asp:HiddenField ID="txtHiddenMouldNo" runat="server" />
                                     <asp:HiddenField ID="txtHiddenMachineNo" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 编辑
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblDispatchNo" runat="server" Text="派工单号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtDispatchNo" runat="server" class="textboxodl"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDispatchNo"
                                            ErrorMessage="必填"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CvtxtDispatchNo" runat="server" ControlToValidate="txtDispatchNo"
                                     ErrorMessage="无此工单信息" 
                                     ClientValidationFunction="GetDispatchNo"  Display="Dynamic">
                                 </asp:CustomValidator>
                                    <%--  <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlDispatchNo_SelectedIndexChanged">
                                    </asp:DropDownList>--%>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblMouldNo" runat="server" Text="模具编号:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMouldNo" runat="server" CssClass="textbox" Enabled="false" ></asp:TextBox>
                                 <%--   <asp:DropDownList ID="ddlMouldNo" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="10px"></asp:TextBox>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblMachineNo" runat="server" Text="机器编号:"></asp:Label>
                                </th>
                                <td>
                                     <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textbox" Enabled="false" ></asp:TextBox>
                               <%--     <asp:DropDownList ID="ddlDispatchNo" runat="server" CssClass="dropdownlist">
                                    </asp:DropDownList>--%>
                                    <input id="Hidden2" type="hidden" runat="server" style="width: 13px" class="textbox" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblOriginalData" runat="server" Text="原始数据:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtOriginalData" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblModifyData" runat="server" Text="修正数据:"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtModifyData" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                                <th align="right">
                                    <asp:Label ID="lblUploadDate" runat="server" Text="上传时间:"></asp:Label>
                                </th>
                                <td>
                                    <input id="txtUploadDate" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                        onselectstart="return false;" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="lblModifyFlag" runat="server" Text="修正标志:"></asp:Label>
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblModifyFlag" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">未修正</asp:ListItem>
                                        <asp:ListItem Value="1">已修正</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right">
                                    &nbsp;<asp:Label ID="lblInputFlag" runat="server" Text="导入标志:"></asp:Label>
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rblInputFlag" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">未导入</asp:ListItem>
                                        <asp:ListItem Value="1">已导入</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlWorkOrderNo" runat="server" CssClass="dropdownlist" Visible="False">
                                    </asp:DropDownList>
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
