<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemMstr.aspx.cs" Inherits="BaseInfo_ItemMstr" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ����(ItemMstr)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/OpenFun.js"></script>

    <script language="javascript" src="../JS/itemJS.js" type="text/javascript"></script>

    <style type="text/css">
        .login
        {
            position: relative;
            display: none;
            top: 20px;
            left: 30px;
            padding: 10px;
            background-color: ffffff;
            text-align: center;
            border: solid 2px;
            border-color: ffffff;
            z-index: 1;
        }
    </style>
    <style>
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: #D7D7D7;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }
        .white_content
        {
            display: none;
            position: absolute;
            top: 25%;
            left: 30%;
            width: 25%;
            height: 50%;
            padding: 10px;
            background-color: ffffff;
            text-align: center;
            border: solid 2px;
            border-color: ffffff;
            z-index: 1002;
        }
    </style>

    <script type="text/javascript">
        function IsNum(obj, alertStr) {
            alertStr = alertStr + "���������֣�";
            var tr = obj.parentNode.parentNode;
            var re = /^\d+(\.\d+)?$/;
            if (obj.value != "") {
                if (parseFloat(obj.value) > 100) {
                    alert("�ٷֱ����벻�ܳ���һ�٣�");
                    obj.value = "";
                    return false;
                }
                if (!re.test(obj.value)) {
                    alert(alertStr);
                    obj.value = "";
                    return false;
                }

            }
        }

        function isValidated() {
            var search = document.getElementById('search');
            var txtMouldCode = document.getElementById('txtMouldCode');
            var txtItem_Weight = document.getElementById('txtItem_Weight')
            var txtItem_ActualGrossWgt = document.getElementById('txtItem_ActualGrossWgt')
            var txtItem_WaterGapScale = document.getElementById('txtItem_WaterGapScale');
            if (search.value == "") {
                alert("��Ʒ��Ų���Ϊ�գ�");
                search.focus();
                return false;
            }
            if (txtMouldCode.value == "") {
                alert("ģ�߱�Ų���Ϊ�գ�");
                txtMouldCode.focus();
                return false;
            }
            if (txtItem_Weight.value == "") {
                alert("��Ʒ��������Ϊ�գ�");
                txtItem_Weight.focus();
                return false;
            }
            if (txtItem_ActualGrossWgt.value == "") {
                alert("ʵ��ơ�ز���Ϊ�գ�");
                txtItem_ActualGrossWgt.focus();
                return false;
            }
            if (txtItem_WaterGapScale.value == "") {
                alert("ˮ�ڱ�������Ϊ�գ�");
                txtItem_WaterGapScale.focus();
                return false;
            }
        }

        function updateClick() {
            var oldProdCode = M("hdnProdCode").value;
            var newProdCode = M("search").value;
            if (oldProdCode != newProdCode) {
                if (!window.confirm('ȷ��Ҫ����¼��'))
                    return event.returnValue = false
            }
        }
        function doref(id) {//<%--#ededec;--%>#e0edf7;
            xid = id;
            M("TextBox2").value = "";
            var responsexx = BaseInfo_ItemMstr.GetMouldMstr("1");

            var responseTxt = BaseInfo_ItemMstr.GetMouldMstr("3");
            //���Select1��options
            for (var j = 0; j < M('Select1').options.length; j++) {
                M('Select1').options.remove(j);
                j = 0;
                //j--;
            }
            //����Select1��options
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
                var responsexx;
                for (var i = 0; i < ds.options.length; i++) {
                    if (ds.options[i].selected) {
                        e += (ds.options[i].value == "") ? "" : ds.options[i].value + ",";
                        responsexx = BaseInfo_ItemMstr.QueryGetMouldMstr("2", ds.options[i].value);
                        if (responsexx.value.length > 0) {
                            txt += responsexx.value[0] + ","; //(ds.options[i].text=="")?"":ds.options[i].text+",";
                        }
                        else {
                            txt = "";
                        }
                    }
                }

                e = (e == "") ? "" : e.substring(0, e.length - 1);
                txt = (txt == "") ? "" : txt.substring(0, txt.length - 1);
                M("txtModeDesc").innerText = txt; //e;
                M("txtMouldCode").innerText = e; //txt;
                closes();
            }
        }
        function Sel(cid) {
            var responsexx;
            var responseTxt;

            responsexx = BaseInfo_ItemMstr.QueryGetMouldMstr("1", M("TextBox2").value);

            responseTxt = BaseInfo_ItemMstr.QueryGetMouldMstr("3", M("TextBox2").value);
            //���Select1��options
            for (var j = 0; j < M('Select1').options.length + 1; j++) {
                j = 0;
                M('Select1').options.remove(j);

                //j--;
            }
            //����Select1��options
            for (var i = 0; i < responsexx.value.length; i++) {
                var option = new Option(responsexx.value[i], responseTxt.value[i]);
                M('Select1').options[i] = option;
            }
        }
        

    </script>

    <script language="javascript" type="text/javascript">
        /**
        �ı�������onkeydown��Ӧ����
        */
        function keypressHandler(evt) {
            // ��ȡ��������������        
            var div = getDiv(divName);

            // �������������ʾ����ʲôҲ����       
            if (div.style.visibility == "hidden") {
                //return true;
            }


            // ȷ��evt��һ����Ч���¼�   
            if (!evt && window.event) {
                evt = window.event;
            }
            var key = evt.keyCode;

            var KEYUP = 38;
            var KEYDOWN = 40;
            var KEYENTER = 13;
            var KEYTAB = 9;
            var KEYESC = 27;

            // ֻ�������¼����س�����Tab������Ӧ       
            if ((key != KEYUP) && (key != KEYDOWN) && (key != KEYENTER) && (key != KEYTAB) && (key != KEYESC)) {
                document.getElementById("txtUpInput").disabled = false;
                return true;
            }
            else {
                document.getElementById("txtUpInput").disabled = true;
                return false;
            }

            var selNum = getSelectedSpanNum(div);
            var selSpan = setSelectedSpan(div, selNum);

            if ((key == KEYESC)) {
                //         if (selSpan)
                //            {
                //                _selectResult(selSpan);
                //           }
                evt.cancelBubble = true;

                // ����������
                showDiv(false);
                return false;
            }
            else {
                // �������س���Tab����ѡ��ǰѡ����Ŀ   
                if ((key == KEYENTER) || (key == KEYTAB)) {
                    if (selSpan) {
                        _selectResult(selSpan);
                    }
                    evt.cancelBubble = true;

                    // ��ʾ������
                    showDiv(false);
                    return false;
                }
                else //����������¼����������ƶ�ѡ����Ŀ
                {
                    if (key == KEYUP) {
                        selSpan = setSelectedSpan(div, selNum - 1);
                    }
                    if (key == KEYDOWN) {
                        selSpan = setSelectedSpan(div, selNum + 1);
                    }
                    if (selSpan) {
                        _highlightResult(selSpan);
                    }

                }
            }

            // ��ʾ������
            showDiv(true);
            return true;
        }

        // ѡ��һ����Ŀ
        function _selectResult(item) {
            var spans = item.getElementsByTagName("span");
            if (spans) {
                for (var i = 0; i < spans.length; i++) {
                    if (spans[i].className == "result1") {
                        queryField.value = spans[i].innerHTML;
                        lastVal = val = escape(queryField.value);
                        mainLoop();
                        queryField.focus();
                        //showDiv(true);

                        //document.getElementById("TextBox1").innerText = spans[i].innerHTML; 
                        if (newSetById != null) {
                            var response = newById.GetSearhValues(spans[i].innerHTML);
                            _innerTexts(response.value, newSetById);
                        }

                        if (otherById != null) {
                            var response = newById.GetSearhSetValues(spans[i].innerHTML, '1');
                            _innerTexts(response.value, otherById);
                        }
                        if (otherById2 != null) {
                            var response = newById.GetSearhSetValues(spans[i].innerHTML, '2');
                            _innerTexts(response.value, otherById2);
                        }
                        showDiv(false);
                        return;
                    }
                }
            }
        }
    </script>

    <script language="jscript" type="text/javascript">
        mainLoop = function() {
            val = escape(queryField.value);
            if (lastVal != val) {
                if (document.getElementById("txtUpInput").disabled)//�޸�ʱ��
                {
                    val = "lkdsfjlsjdsfjklssdasdasdassdfsdfsdfsdfzxcvvsdvfsdSDv";
                }
                var response = BaseInfo_ItemMstr.GetSearhItmes(val);
                showQueryDiv(response.value);

                lastVal = val;
            }
            newById = BaseInfo_ItemMstr;
            newSetById = "txtProductRemark";
            otherById = "txtMaterialCode";
            otherById2 = "txtMaterialDesc";
            setTimeout('mainLoop()', 100);
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="section-content" style="width: 99%">
        <tr>
            <td valign="top" style="width: 97%">
                <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                    <tr>
                        <td style="height: 24px">
                            ��ǰλ��:�������� -> ע�ܲ�Ʒ����
                        </td>
                    </tr>
                </table>
                <br />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; ����
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                        <asp:ListItem Value="Item_Code">��Ʒ���</asp:ListItem>
                                        <asp:ListItem Value="ProductRemark">��Ʒ����</asp:ListItem>
                                        <asp:ListItem Value="Item_Weight">��Ʒ����</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" ImageAlign="Top" />&nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                        <tr>
                                            <td style="background-image: url(../images/bg_title.gif); height: 19px;" valign="middle">
                                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; ���
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                        OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px"
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
                                            <asp:ButtonField DataTextField="ID" HeaderText="���">
                                                <ItemStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <FooterStyle CssClass="hidden" />
                                            </asp:ButtonField>
                                            <asp:ButtonField DataTextField="Item_Code" CommandName="select" HeaderText="��Ʒ���">
                                                <ItemStyle Width="75px" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="MouldCode" HeaderText="ģ�߱��">
                                                <ItemStyle Width="215px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProductRemark" HeaderText="��Ʒ����">
                                                <ItemStyle Width="215px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CustomerName" HeaderText="�ͻ�����" Visible="False" />
                                            <asp:BoundField DataField="Item_Weight" HeaderText="��Ʒ����" />
                                            <asp:BoundField DataField="Item_WaterGapScale" HeaderText="ˮ�ڱ���" />
                                            <asp:BoundField DataField="VerNo" HeaderText="�汾��" Visible="False" />
                                            <asp:BoundField DataField="Item_ActualGrossWgt" HeaderText="ʵ��ơ��" Visible="False" />
                                            <asp:BoundField DataField="Remark" HeaderText="��ע">
                                                <ItemStyle Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Creater" HeaderText="��������" Visible="False" />
                                            <asp:BoundField DataField="CreateDate" HeaderText="����޸�ʱ��" Visible="False" />
                                            <asp:BoundField DataField="ModiHistoryContent" HeaderText="�޸ļ�¼��ʷ" Visible="False" />
                                            <asp:BoundField DataField="OutsideAssociation" HeaderText="��Э" Visible="False" />
                                            <asp:BoundField DataField="MachineAssembly" HeaderText="������װ" Visible="False" />
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
                                                                ErrorMessage="����������" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
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
                                <td style="background-image: url(../images/bg_title.gif); height: 18px;">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 21px">
                                    <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                        OnClientClick="return isValidated()" />
                                    <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                    <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                        OnClick="btnDelete_Click" CausesValidation="false" />
                                    <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                        CausesValidation="false" />&nbsp;
                                    <input id="hdnID" type="hidden" runat="server" style="width: 20px; height: 13px;"
                                        class="textbox" />&nbsp;
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"
                                        Height="7px"></asp:TextBox>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="igbwork" runat="server" ImageUrl="~/images/btn_work.gif" OnClick="igbwork_Click"
                                        ImageAlign="Top" CausesValidation="False" />&nbsp;
                                    <asp:ImageButton ID="igbbox" runat="server" ImageUrl="~/images/btn_box.gif" OnClick="igbwork_Click"
                                        ImageAlign="Top" CausesValidation="False" />
                                    <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="8px"></asp:TextBox>
                                    <input id="hdnProdCode" runat="server" style="width: 5px" type="hidden" />
                                    <input id="txtUpInput" runat="server" autocomplete="off" class="textbox" disabled="disabled"
                                        name="txtUpInput" style="border-right: #ffffff thin solid; border-top: #ffffff thin solid;
                                        border-left: #ffffff thin solid; width: 1px; border-bottom: #ffffff thin solid"
                                        type="text" visible="true" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                <td style="background-image: url(../images/bg_title.gif); height: 23px;">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �༭
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="border-collapse: collapse;" width="98%" cellpadding="1"
                            cellspacing="1" class="texttable">
                            <tr>
                                <th align="right" class="label" style="width: 9%">
                                    <asp:Label ID="Label1" runat="server" Text="��Ʒ���:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td style="width: 22%">
                                    <input id="search" runat="server" autocomplete="off" name="search" style="width: 139px"
                                        type="text" class="textboxodl" />
                                </td>
                                <th align="right" style="width: 9%">
                                    ��Ʒ����:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtProductRemark" runat="server" CssClass="textbox" OnTextChanged="productremark_TextChanged"
                                        TextMode="MultiLine" Width="418px" Height="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ģ�߱��:
                                </th>
                                <td style="width: 22%">
                                    <asp:TextBox ID="txtMouldCode" runat="server" CssClass="textboxodl" Width="139px"></asp:TextBox>
                                    <a href="#" onclick="opens('txtMouldCode')" style="color: #ff3333">ѡ��</a>
                                </td>
                                <th align="right" style="width: 9%">
                                    ģ������:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtModeDesc" runat="server" CssClass="textbox" OnTextChanged="productremark_TextChanged"
                                        TextMode="MultiLine" Width="418px" Height="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ģ������:
                                </th>
                                <td style="width: 22%">
                                    <asp:TextBox ID="txtMould_SpecialFittingsNo" runat="server" CssClass="textbox" Width="139px"></asp:TextBox>
                                </td>
                                <th align="right" style="width: 9%">
                                    ģ�������:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtInsertsDesc" runat="server" CssClass="textbox" OnTextChanged="productremark_TextChanged"
                                        TextMode="MultiLine" Width="418px" Height="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ԭ�ϱ��:
                                </th>
                                <td style="width: 22%">
                                    <asp:TextBox ID="txtMaterialCode" runat="server" CssClass="textbox" Width="139px"></asp:TextBox>
                                    <a href="#" onclick="document.getElementById('light').style.display='block';document.getElementById('fade').style.display='block'"
                                        style="color: #ff3333">ѡ��</a>
                                </td>
                                <th align="right" style="width: 9%">
                                    ԭ������:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtMaterialDesc" runat="server" CssClass="textbox" OnTextChanged="productremark_TextChanged"
                                        TextMode="MultiLine" Width="418px" Height="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    <asp:Label ID="Label6" runat="server" Text="��Ʒ����:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td style="width: 22%">
                                    <asp:TextBox ID="txtItem_Weight" runat="server" CssClass="textboxodl" Width="139px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtItem_Weight"
                                        Display="Static" ErrorMessage="����" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right" style="width: 9%">
                                    <asp:Label ID="Label4" runat="server" Text="ʵ��ơ��:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtItem_ActualGrossWgt" runat="server" CssClass="textboxodl"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtItem_ActualGrossWgt"
                                        Display="Static" ErrorMessage="����" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right" style="width: 8%">
                                    <asp:Label ID="Label3" runat="server" Text="ˮ�ڱ���:" CssClass="txtlab"></asp:Label>
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtItem_WaterGapScale" runat="server" CssClass="textboxodl"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revItem_ActualGrossWgt" runat="server" ControlToValidate="txtItem_WaterGapScale"
                                        Display="Static" ErrorMessage="����" ValidationExpression="^0\.\d*[0-9]\d*$" Width="24px"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ��һ����:
                                </th>
                                <td style="width: 22%">
                                    <asp:TextBox ID="txtProcesses" runat="server" CssClass="textbox" Width="139px"></asp:TextBox>&nbsp;
                                </td>
                                <th align="right" style="width: 9%">
                                    ��Ա����:
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtStandEmployee" runat="server" CssClass="textbox" Width="121px"></asp:TextBox>
                                    ��
                                </td>
                                <th align="right" style="width: 8%">
                                </th>
                                <td style="width: 20%">
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ��Ʒ��ɫ:
                                </th>
                                <td style="width: 22%">
                                    <asp:DropDownList ID="ddlItem_Color" runat="server" CssClass="textbox" Width="139px">
                                    </asp:DropDownList>
                                </td>
                                <th align="right" style="width: 9%">
                                    װ������:
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtPackageNum" runat="server" CssClass="textbox"></asp:TextBox>
                                    PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                        ControlToValidate="txtPackageNum" ErrorMessage="����" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right" style="width: 8%">
                                </th>
                                <td style="width: 20%">
                                    <asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="dropdownlist" Width="120px"
                                        Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ��������:
                                </th>
                                <td style="width: 22%">
                                    <asp:TextBox ID="txtAuxiliaryMaterialName" runat="server" CssClass="textbox" Width="139px"></asp:TextBox>
                                </td>
                                <th align="right" style="width: 9%">
                                    ��������:
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtAuxiliaryMaterialNum" runat="server" CssClass="textbox"></asp:TextBox>
                                    PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                        ControlToValidate="txtAuxiliaryMaterialNum" Display="Static" ErrorMessage="����"
                                        ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                                <th align="right" style="width: 8%">
                                    ɫ�۱��:
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtPowderCode" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ��Э:
                                </th>
                                <td style="width: 22%">
                                    <asp:RadioButtonList ID="rblOutsideAssociation" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">��</asp:ListItem>
                                        <asp:ListItem Value="1">��</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right" style="width: 9%">
                                    ������װ:
                                </th>
                                <td style="width: 20%">
                                    <asp:RadioButtonList ID="rblMachineAssembly" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">��Ʒ</asp:ListItem>
                                        <asp:ListItem Value="1">���Ʒ</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="2">��</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <th align="right" style="width: 8%">
                                    �汾��:
                                </th>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txtVerNo" runat="server" CssClass="textbox">1</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    ͼƬ:
                                </th>
                                <td style="width: 22%">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" Width="192px" />
                                </td>
                                <th align="right" style="width: 9%">
                                    ��ע:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="418px" TextMode="MultiLine"
                                        Height="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="width: 9%">
                                    �޸ļ�¼:
                                </th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtModiHistoryContent" runat="server" CssClass="textbox" Height="60px"
                                        TextMode="MultiLine" Width="93%" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="width: 10%">
                                    <asp:Image ID="Image1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <div id="login" class="login">
        <table border="0.1px" width="100%" style="background-color: #f9f9f9">
            <tr style="width: 100%; height: 24px;">
                <td colspan="2" align="center">
                    <tr style="width: 100%; height: 24px;">
                        <td colspan="2" align="center">
                            <span style="font-weight: bold; font-size: 20px;">ѡ��ģ��</span>
                        </td>
                        <td align="right" colspan="1" style="width: 5%;" valign="top">
                            <a href="#" onclick="closes();">��</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" valign="middle" id="TD1" runat="server">
                            ����:<asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="86px" valign="middle"></asp:TextBox><input
                                id="Button1" type="button" onclick="Sel('Select1')" style="border-right: #ffffff 0px solid;
                                border-top: #ffffff 0px solid; background-image: url(../images/btn_search.gif);
                                border-left: #ffffff 0px solid; width: 67px; border-bottom: #ffffff 0px solid;
                                height: 24px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" style="height: 224px;">
                            &nbsp;<select id="Select1" name="Select1" multiple runat="server" style="width: 277px;
                                height: 258px; border: 1px;">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <img src="../images/btn_yes.gif" onclick="ko('Select1')" />
                            &nbsp;<img src="../images/btn_cancel.gif" onclick="closes();" />
                        </td>
                    </tr>
        </table>
        <div id="panel">
        </div>
    </div>
    <div id="light" class="white_content" runat="server">
        <table border="0.1px" width="100%" style="background-color: #f9f9f9">
            <tr style="width: 100%; height: 24px;">
                <td colspan="2" align="center">
                    <span style="font-weight: bold; font-size: 20px;">ѡ��ԭ��</span>
                </td>
                <td align="right" colspan="1" style="width: 5%;" valign="top">
                    <a href="#" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                        ��</a>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" valign="middle" id="TD2" runat="server">
                    ���:<asp:TextBox ID="tbRawNo" runat="server" CssClass="textbox" Width="86px" valign="middle"></asp:TextBox><asp:Button
                        ID="btnSelect" runat="server" OnClick="btnSelect_Click" Style="border-right: #ffffff 0px solid;
                        border-top: #ffffff 0px solid; background-image: url(../images/btn_search.gif);
                        border-left: #ffffff 0px solid; width: 67px; border-bottom: #ffffff 0px solid;
                        height: 24px" />
                </td>
            </tr>
            <tr valign="top">
                <td colspan="3" style="height: 224px;">
                    <div style="overflow-y: scroll; height: 224px; width: 100%">
                        <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" Style="border: 1px;
                            width: 100%; text-align: center;">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItem" runat="server" ToolTip="�� ѡ" name="chkItem" Checked="false">
                                        </asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="���" DataField="RawNo" />
                                <asp:TemplateField HeaderText="�ٷֱ�">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPercentage" runat="server" Style="width: 35px; text-align: center"
                                            onblur="return IsNum(this,' ')"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Style="border-right: #ffffff 0px solid;
                        background-image: url(../images/btn_yes.gif); border-left: #ffffff 0px solid;
                        width: 67px; border-bottom: #ffffff 0px solid; height: 26px" />
                    &nbsp;
                    <img src="../images/btn_cancel.gif" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'" />
                </td>
            </tr>
        </table>
    </div>
    <div id="fade" runat="server" class="black_overlay">
    </div>
    </form>
</body>
</html>
