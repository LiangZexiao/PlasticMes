<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdjustMachine.aspx.cs" Inherits="Product_AdjustMachine" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>调机管理(AdjustMachine)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script language="javascript" src="../JS/itemJS.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function GetDispatchNo(sender, args) {
            var txtNo = document.getElementById("txtDispatchNo").value;
            var arryList = Product_AdjustMachine.getSearchDispatchNo(txtNo);

            if (arryList.value=="") {
                document.getElementById("txtDispatchNo").value = "";
                document.getElementById("txtDispatchNo").focus();
                document.getElementById("txtDispatchNo").select();
                window.alert("无此工单信息!");
                args.isvalid = false;
            }
            else {
                document.getElementById("txtProductNo").innerText = arryList.value[1];
                document.getElementById("txtProdDesc").innerText = arryList.value[2];
                document.getElementById("txtMouldNo").innerText = arryList.value[3];
                document.getElementById("txtMachineNo").innerText = arryList.value[4];
                form1.txtDispatchNum.value = arryList.value[5];
                form1.txtHiddenProductNo.value = arryList.value[1];
                form1.txtHiddenProdDesc.value = arryList.value[2];
                form1.txtHiddenMouldNo.value = arryList.value[3];
                form1.txtHiddenMachineNo.value = arryList.value[4];
                args.isvalid = true;
            }
        }
        function IsExceedDispatchNum(sender, args) {
            var txtDispatchNum = document.getElementById("txtDispatchNum").value;
            if (txtDispatchNum == "") {
                document.getElementById("txtTotalQty").value = "";
                document.getElementById("txtDispatchNo").focus();
                document.getElementById("txtDispatchNo").select();
                alert("派工单号不能为空，请先输入派工单号!");
            }
            else {
                var txtTotalQty = document.getElementById("txtTotalQty").value;
                if (parseInt(txtTotalQty) > parseInt(txtDispatchNum)) {
                    document.getElementById("txtTotalQty").value = "";
                    document.getElementById("txtTotalQty").focus();
                    document.getElementById("txtTotalQty").select();
                    alert("调机良品数:"+txtTotalQty+"不能超过派工数量:"+txtDispatchNum+"!");
                }
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 9%;
        }
        .style2
        {
            width: 20%;
        }
        .style3
        {
            color: Blue;
            width: 9%;
        }
        .style4
        {
            width: 15%;
        }
        .style5
        {
            width: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:生产排程 ->调机管理</td>
          </tr>
          </table>
            <br />
            <asp:MultiView ID="MultiView1" runat="server">
               <asp:View ID="View1" runat="server">
            
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td height="22" style="background-image: url(../images/bg_title.gif)">　　&nbsp;&nbsp; 操作</td>
                  </tr>
                  <tr>
                    <td>
<asp:DropDownList ID="ddlQuery" runat="server">
<asp:ListItem Value="DispatchNo">派工单号</asp:ListItem>
<asp:ListItem Value="MachineNo">机器编号</asp:ListItem>
<asp:ListItem Value="MouldNo">模具编号</asp:ListItem>
<asp:ListItem Value="ProductNo">产品编号</asp:ListItem>
</asp:DropDownList>                                    
<asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                        &nbsp;日期:<input runat="server" type="text" id="inStartDate" name="txtBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 至
                                 <input runat="server" type="text" id="inEndDate" name="inEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 
<asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top"  Visible="false"/></td>
                  </tr>
              </table>
              <br />
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　&nbsp;&nbsp; 浏览</td>
                      </tr>
                    </table>              
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" 
                          AllowPaging="True" PageSize="12" 
                         OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" CellSpacing="1"
                         OnRowCommand="GridView1_RowCommand"  >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                        <AlternatingRowStyle BackColor="White" />
                    <Columns>
                     <asp:TemplateField><ItemTemplate><asp:CheckBox ID="chkItemInner" runat="server" /></ItemTemplate><HeaderTemplate><input id="chkAll" type="checkbox" onclick="selectAll(this);"/></HeaderTemplate><ItemStyle HorizontalAlign="Center"  Width="26px"/><HeaderStyle HorizontalAlign="Center" /></asp:TemplateField>

                    <asp:ButtonField DataTextField="ID" HeaderText="序号"><ItemStyle HorizontalAlign="Center" CssClass="hidden" /><HeaderStyle CssClass="hidden" /><FooterStyle CssClass="hidden" /></asp:ButtonField>
                    <asp:ButtonField DataTextField="DispatchNo" CommandName="select" HeaderText="派工单号" SortExpression="DispatchNo" />
                    <asp:BoundField DataField="ProductNo" HeaderText="产品编号" SortExpression="ProductNo" />
                    <asp:BoundField DataField="ProductDesc" HeaderText="产品描述" SortExpression="ProductDesc" />
                    <asp:BoundField DataField="MachineNo" HeaderText="机器编号" SortExpression="MachineNo" />
                    <asp:BoundField DataField="MouldNo" HeaderText="模具编号" SortExpression="MouldNo" />
                    <asp:BoundField DataField="TotalQty" HeaderText="调机总数" SortExpression="TotalQty" />
                    <asp:BoundField DataField="ReasonName" HeaderText="调机原因" SortExpression="ReasonName" />
                    <asp:BoundField DataField="StartDate" HeaderText="调机开始时间"  SortExpression="StartDate"/>
                    <asp:BoundField DataField="EndDate" HeaderText="调机结束时间" SortExpression="EndDate" />
                    <asp:BoundField DataField="EmpName" HeaderText="调机人" SortExpression="EmpName"/>
                    <asp:BoundField DataField="Remark" HeaderText="备注" />
                     </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" valign="top">
                        <table>
                            <tr>
                                <td style="height: 28px">
                                    <asp:Label ID="lblDataCount" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="height: 28px">
<asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td style="height: 28px">
                                    <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="height: 28px">
<asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                </td>
                                <td style="height: 28px">
<asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td style="height: 28px">
<asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
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
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　&nbsp; 操作</td>
                      </tr>
                      <tr>
                      <td>
                        <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                        <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                        <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="false" Visible="false"/>
                        <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  />
                        <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                        <asp:HiddenField ID="txtDispatchNum" runat="server" />  
                        <asp:HiddenField ID="txtHiddenProductNo" runat="server" /> 
                        <asp:HiddenField ID="txtHiddenProdDesc" runat="server" /> 
                        <asp:HiddenField ID="txtHiddenMouldNo" runat="server" />
                        <asp:HiddenField ID="txtHiddenMachineNo" runat="server" />
                      </td>
                      </tr>
                    </table>
                <br />
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 22px;" valign="middle">
                            　　&nbsp; 编辑
                        </td>
                      </tr>
                    </table>
                    <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
                        <tr>
                            <th align="right" class="style1">
                <asp:Label ID="lblDispatchNo" runat="server" Text="派工单号:" CssClass="txtlab"></asp:Label></th>
                        <td class="style2">
                        <input id="txtDispatchNo" runat="server" autocomplete="off" name="txtDispatchNo"
                                        type="text" class="textboxodl"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDispatchNo"
                                    ErrorMessage="必填"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CvtxtDispatchNo" runat="server" ControlToValidate="txtDispatchNo"
                             ErrorMessage="无此工单信息" 
                             ClientValidationFunction="GetDispatchNo"  Display="Dynamic">
                         </asp:CustomValidator>
                                         
                        </td>
                            <th align="right" class="style3">
               <asp:Label ID="Label1" runat="server" CssClass="txtlab" Text="产品编号:"></asp:Label></th>
                            <td class="style4">
                <asp:TextBox ID="txtProductNo" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                                 <%--     <asp:TextBox ID="txtDispatchNum" runat="server" CssClass="textbox" Visible="false" Width="12px"></asp:TextBox>--%>
                           
                                    </td>
                            <th align="right" class="style1">
                                <asp:Label ID="Label4" runat="server" Text="产品描述:"></asp:Label></th>
                            <td class="style5">
                                <asp:TextBox ID="txtProdDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                    Width="99%" Enabled="False"></asp:TextBox>
                                    </td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 9%">
               <asp:Label ID="Label2" runat="server" CssClass="txtlab" Text="模具编号:"></asp:Label></th>
                            <td style="width: 20%">
           <asp:TextBox ID="txtMouldNo" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                                   </td>
                            <th align="right" style="width: 9%">
                                <asp:Label ID="Label3" runat="server" CssClass="txtlab" Text="机器编号:"></asp:Label></th>
                            <td style="width: 15%">
               <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                                    </td>
                            <th align="right" style="width: 9%">
               <asp:Label ID="lblProductDate" runat="server" Text="开始时间:" CssClass="txtlab"></asp:Label></th>
                            <td style="width: 30%">
                              <input runat="server" type="text" id="txtStartDate" name="txtStartDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"
                                 style="width: 140px" />
 <%--          <input id="txtStartDate" runat="server" class="textboxodl" name="txtProductDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" visible="true"  />
                                  <input id="txtStartTime" runat="server" class="textboxodl" maxlength="5" name="txtStartTime"
                                        oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                                        onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                                        type="text" value="00:00" />--%>
                                  <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStartDate"
                                    ErrorMessage="必填"></asp:RequiredFieldValidator>--%>
                                    </td>
                        </tr>
       <tr>
           <th align="right" style="width: 9%">
                <asp:Label ID="lblWorker" runat="server" Text="调机人:" CssClass="txtlab"></asp:Label></th>
           <td style="width: 20%">
            <asp:DropDownList ID="ddlWorker" runat="server" CssClass="textboxodl" ></asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlWorker"
                   ErrorMessage="必填"></asp:RequiredFieldValidator></td>
           <th align="right" style="width: 9%">调机总数:
                </th>
           <td style="width: 20%">
                    <asp:TextBox ID="txtTotalQty" runat="server" CssClass="textbox" ></asp:TextBox>
                PCS<asp:RegularExpressionValidator ID="revTotalQty" runat="server" ControlToValidate="txtTotalQty" Display="Static" ErrorMessage="有误" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CvtxtTotalQty" runat="server" ControlToValidate="txtTotalQty"
                             ErrorMessage="不能超过派工数" 
                             ClientValidationFunction="IsExceedDispatchNum"  Display="Dynamic">
                         </asp:CustomValidator>         
            </td>
           <th align="right" style="width: 9%">
                <asp:Label ID="Label5" runat="server" Text="结束时间:" CssClass="txtlab"></asp:Label>
               </th>
           <td style="width: 30%">
            <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"
                                 style="width: 140px"  /> 
        <%--   <input id="txtEndDate" runat="server" class="textboxodl" name="txtEndDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" visible="true"  />
                         <input id="txtEndTime" runat="server" class="textboxodl" maxlength="5" name="txtEndTime"
                                        oncut="checkPaste()" ondrag="checkPaste()" onfocus="" onkeydown="keydown(this,'time')"
                                        onkeypress="keypress(this,'time')" onmousemove="checkPaste()" onpaste="checkPaste()"
                                        type="text" value="00:00" />--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEndDate"
                                    ErrorMessage="必填"></asp:RequiredFieldValidator>--%>
           <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="false" Width="12px"></asp:TextBox></td>
       </tr>
       <tr>
           <th align="right" style="width: 9%">
             <asp:Label ID="lblMemo" runat="server" Text="备注:"></asp:Label></th>
           <td colspan="3">
             <asp:TextBox ID="txtMemo" runat="server" CssClass="textbox" Width="100%" TextMode="MultiLine" ></asp:TextBox>
               </td>
           <th align="right" style="width: 9%">
                <asp:Label ID="Label6" runat="server" Text="调机原因:" CssClass="txtlab"></asp:Label></th>
           <td style="width: 20%">
            <asp:DropDownList ID="ddlStopMachine" runat="server" CssClass="textbox" ></asp:DropDownList>
           </td>
       </tr>
         <tr>
                                    <th align="right" style="width: 9%">
                                        修改记录:</th>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtModiHistoryContent" runat="server" CssClass="textbox" Height="60px"
                                            TextMode="MultiLine" Width="99%" ReadOnly="True"></asp:TextBox></td>
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