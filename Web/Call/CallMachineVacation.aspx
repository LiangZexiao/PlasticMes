<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallMachineVacation.aspx.cs"
    Inherits="Call_CallMachineVacation" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机台假期配置(CallMachineVacation)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>

    <script language="JavaScript" type="text/javascript">
        function moveOption(e1, e2) {
            try {
                if (e2.id == "Select2") {
                    for (var i = 0; i < e1.options.length; i++) {
                        if (e1.options[i].selected) {
                            var e = e1.options[i];
                            for (var j = 0; j < e2.options.length; j++) {
                                var sel2 = e2.options[j];
                                if (sel2.value == e.value) {
                                    e2.remove(j);
                                }
                            }
                            e2.options.add(new Option(e.text, e.value));
                            //  e1.remove(i); 
                            //i=i-1 ;    
                        }
                    }
                }
                else {
                    for (var i = 0; i < e1.options.length; i++) {
                        if (e1.options[i].selected) {

                            // e2.options.add(new Option(e.text, e.value)); 
                            e1.remove(i);
                            i = i - 1;
                        }
                    }
                }
                if (e2.id == "Select2") {
                    document.form1.hdnemp.value = getvalue(e2);
                    // alert( getvalue(e2));
                } else {
                    document.form1.hdnemp.value = getvalue(e1);
                    //alert( getvalue(e1));
                }
            }
            catch (e) { }
        }
        function moveOption2(e1, e2) {
            try {
                for (var i = 0; i < e1.options.length; i++) {

                    var e = e1.options[i];
                    for (var j = 0; j < e2.options.length; j++) {
                        var sel2 = e2.options[j];
                        if (sel2.value == e.value) {
                            e2.remove(j);
                        }
                    }

                    e2.options.add(new Option(e.text, e.value));
                    if (e1.id == "Select2") {
                        e1.remove(i);
                        i = i - 1;
                    }
                }
                if (e2.id == "Select2") {
                    document.form1.hdnemp.value = getvalue(e2);
                    //alert( getvalue(e2));
                } else {
                    document.form1.hdnemp.value = getvalue(e1);
                    //alert( getvalue(e1));
                }
                // document.form1.hdnemp.value=getvalue(document.form1.Select2);

            }
            catch (e) { }
        }
        function getvalue(geto) {
            var allvalue = "";
            for (var i = 0; i < geto.options.length; i++) {
                if (i != (geto.options.length - 1))
                    allvalue += geto.options[i].value + ",";
                else
                    allvalue += geto.options[i].value;
            }
            return allvalue;
        }
    </script>

    <style type="text/css">
        .style1
        {
            width: 122px;
        }
        .style2
        {
            width: 245px;
        }
        .style3
        {
            width: 215px;
        }
        .style4
        {
            height: 26px;
            width: 215px;
        }
        .style5
        {
            height: 92px;
            width: 215px;
        }
        .style6
        {
            width: 169px;
        }
    </style>
</head>
<body style="padding-right: 0px; margin-top: 0px; margin-left: 0px; padding-top: 0px">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" class="section-content" style="width: 100%;
            padding-right: 0px; margin-top: 0px; margin-left: 0px; padding-top: 0px;">
            <tr>
                <td valign="top" style="margin-top: 0px; margin-left: 0px; padding-top: 0px; padding-left: 0px;
                    margin-bottom: 0px;">
                    <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            当前位置:配置管理 -> 机台假期配置
                        </td>
                    </tr>
                </table>
                <br />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td style="background-image: url(../images/bg_title.gif); height: 19px;">
                                        &nbsp; &nbsp; &nbsp; &nbsp; 操作
                                    </td>
                                </tr>
                            </table>
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlQuery" runat="server" Width="92px">
                                            <asp:ListItem Value="">选择</asp:ListItem>
                                            <asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                        <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox" ></asp:TextBox>
                                        <asp:DropDownList ID="ddlWorkShopSearch" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                                            Width="127px" >
                                        </asp:DropDownList>
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
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                            <tr>
                                                <td style="background-image: url(../images/bg_title.gif); height: 19px;">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; 浏览
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
                                                <asp:ButtonField CommandName="select"  DataTextField="WorkShop" HeaderText="车间名称" />
                                                <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                                <asp:BoundField DataField="StartDate" HeaderText="开始时间" />
                                                <asp:BoundField DataField="EndDate" HeaderText="结束时间"/>
                                                <asp:BoundField DataField="Creator" HeaderText="创建人"/>
                                                <asp:BoundField DataField="CreateDate" HeaderText="创建时间"/>
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
                                    <td style="background-image: url(../images/bg_title.gif); height: 19px;">
                                        &nbsp; &nbsp; &nbsp; &nbsp; 操作
                                    </td>
                                </tr>
                            </table>
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td style="height: 28px">
                                        <asp:ImageButton ID="btnInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                        <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                            OnClick="btnDelete_Click" ImageAlign="Top" CausesValidation="False" />
                                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                            CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td style="background-image: url(../images/bg_title.gif); height: 17px;">
                                        &nbsp; &nbsp; &nbsp; &nbsp; 编辑
                                    </td>
                                </tr>
                            </table>
                            <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                                cellspacing="1" class="texttable">
                                <tr>
                                    <td align="right" class="style1">
                                        <asp:Label ID="Label3" runat="server" Text="车间编号:"></asp:Label>
                                    </td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlWorkShop" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                                            Width="127px" OnSelectedIndexChanged="ddlWorkShop_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <input id="hhdn" style="width: 1px" type="hidden" runat="server" />
                                    </td>
                                    <td align="right" class="style1">
                                        <asp:Label ID="Label4" runat="server" Text="机器编号:"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                                            Width="127px" >
                                        </asp:DropDownList>
                                        <input id="Hidden1" runat="server" style="width: 7px" type="hidden" />
                                    </td>
                                    <td class="style6">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 122px; height: 26px;">
                                        <asp:Label ID="lblBcCode" runat="server" Text="开始时间:"></asp:Label>
                                    </td>
                                    <td style="width: 245px; height: 26px;">
                                       <input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                        onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                      style="width: 130px" />
                                    </td>
                                    <td align="right" style="height: 26px; width: 122px;">
                                        <asp:Label ID="Label2" runat="server" Text="结束时间:"></asp:Label>
                                    </td>
                                    <td class="style4">
                                        <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                      onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                     /> 
                                        <input id="hdnID" runat="server" style="width: 5px" type="hidden" />

                                    </td>
                                    <td class="style6">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
