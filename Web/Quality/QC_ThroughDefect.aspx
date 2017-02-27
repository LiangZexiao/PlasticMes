<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QC_ThroughDefect.aspx.cs" Inherits="Quality_QC_ThroughDefect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script language="javascript" src="../JS/itemJS.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function GetDispatchNo(sender, args) {
            var txtNo = document.getElementById("txtDispatchNo").value;
            var arryList = Quality_QC_ThroughDefect.getSearchDispatchNo(txtNo);

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
                document.getElementById("txtTotalQty").innerText = arryList.value[5];
                document.getElementById("txtProductDate").innerText = arryList.value[6];
                document.getElementById("txtTime").innerText = arryList.value[7];
                document.getElementById("txtBadQtySum").innerText=arryList.value[8];
                document.getElementById("txtGoodQty").innerText=Number(arryList.value[5])-Number(arryList.value[8]);
                
                form1.txtHiddenProductNo.value = arryList.value[1];
                form1.txtHiddenProdDesc.value = arryList.value[2];
                form1.txtHiddenMouldNo.value = arryList.value[3];
                form1.txtHiddenMachineNo.value = arryList.value[4];
                form1.txtHiddenTotalQty.value = arryList.value[5];
                form1.txtHiddenProductDate.value = arryList.value[6];
                form1.txtHiddenTime.value = arryList.value[7];
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
          <table cl当前位置:品质管理 -> 补录次品</td>
          </tr>
          </table>
            <br />
            <asp:MultiView ID="MultiView1" runat="server">
               <asp:View ID="View1" runat="server">
            
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td height="22" style="background-image: url(../images/bg_title.gif)">　　&nbsp;&nbsp;&nbsp; 操作</td>
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
<asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top"/>
<asp:ImageButton ID="igbCheckYdouble" runat="server" CausesValidation="false" ImageUrl="~/images/btn_check_yes.gif" OnClick="btnCheck_Click" ImageAlign="Top" Style="height: 22px" />
                        <asp:ImageButton ID="igbCheckNdouble" runat="server" CausesValidation="false" ImageUrl="~/images/btn_check_no.gif" OnClick="btnCheck_Click" ImageAlign="Top" /></td>
                  </tr>
              </table>
              <br />
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　&nbsp;&nbsp;&nbsp; 浏览</td>
                      </tr>
                    </table>              
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" 
                            AutoGenerateColumns="False" AllowPaging="True" PageSize="12" 
                            OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" 
                            CellSpacing="1" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnDataBound="GridView1_DataBound" >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                        <AlternatingRowStyle BackColor="White" />
                    <Columns>
                     <asp:TemplateField><ItemTemplate><asp:CheckBox ID="chkItemInner" runat="server" /></ItemTemplate><HeaderTemplate><input id="chkAll" type="checkbox" onclick="selectAll(this);"/></HeaderTemplate><ItemStyle HorizontalAlign="Center"  Width="26px"/><HeaderStyle HorizontalAlign="Center" /></asp:TemplateField>

                    <asp:ButtonField DataTextField="ID" HeaderText="序号"><ItemStyle HorizontalAlign="Center" CssClass="hidden" /><HeaderStyle CssClass="hidden" /><FooterStyle CssClass="hidden" /></asp:ButtonField>
                    <asp:ButtonField CommandName="detail" Text="次品" Visible="False"><ItemStyle HorizontalAlign="Center" Width="30px" /></asp:ButtonField>
                    <asp:ButtonField DataTextField="DispatchNo" CommandName="select" HeaderText="派工单号" SortExpression="DispatchNo" />
                    <asp:BoundField DataField="EmpID" HeaderText="员工工号" SortExpression="EmpID"/>
                    <asp:BoundField DataField="QueLiaoNum" HeaderText="缺料" SortExpression="QueLiaoNum" />
                    <asp:BoundField DataField="HuaHenNum" HeaderText="划痕" SortExpression="HuaHenNum" />
                    <asp:BoundField DataField="SeChaNum" HeaderText="色差" SortExpression="SeChaNum" />
                    <asp:BoundField DataField="XiaCiNum" HeaderText="瑕疵" SortExpression="XiaCiNum" />
                    <asp:BoundField DataField="QueJiaoNum" HeaderText="缺胶" SortExpression="QueJiaoNum" />
                    <asp:BoundField DataField="SuoShuiNum" HeaderText="缩水"  SortExpression="SuoShuiNum"/>
                    <asp:BoundField DataField="BianXingNum" HeaderText="变型" SortExpression="BianXingNum"/>
                    <asp:BoundField DataField="LiaoHuaNum" HeaderText="料花" SortExpression="LiaoHuaNum"/>
                    <asp:BoundField DataField="PiFengNum" HeaderText="批锋" SortExpression="PiFengNum"/>
                    <asp:BoundField DataField="ChicunNum" HeaderText="尺寸" SortExpression="ChicunNum"/>
                    <asp:BoundField DataField="ShaoJiaoNum" HeaderText="少胶" SortExpression="ShaoJiaoNum"/>
                    <asp:BoundField DataField="JiaWenNum" HeaderText="夹纹" SortExpression="JiaWenNum"/>
                    <asp:BoundField DataField="KaiLieNum" HeaderText="开裂" SortExpression="KaiLieNum"/>
                    <asp:BoundField DataField="QiTaNum" HeaderText="其他" SortExpression="QiTaNum"/>
                    <asp:BoundField DataField="Confirm" HeaderText="确认人" SortExpression="Confirm"/>
                    <asp:BoundField DataField="ConfirmDate" HeaderText="确认日期" SortExpression="ConfirmDate" Visible="false"/>
                    
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
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
                      </tr>
                      <tr>
                      <td>
                        <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" 
                              OnClick="btnUpdate_Click" style="height: 24px; width: 70px" />
                        <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                          <asp:ImageButton ID="igbDelete" runat="server" ImageAlign="Top" 
                              ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" Visible="false" />
                        <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  />
                        <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                        <asp:HiddenField ID="txtHiddenProductNo" runat="server" /> 
                        <asp:HiddenField ID="txtHiddenProdDesc" runat="server" /> 
                        <asp:HiddenField ID="txtHiddenMouldNo" runat="server" />
                        <asp:HiddenField ID="txtHiddenMachineNo" runat="server" />
                        <asp:HiddenField ID="txtHiddenTotalQty" runat="server" />
                        <asp:HiddenField ID="txtHiddenProductDate" runat="server" />
                        <asp:HiddenField ID="txtHiddenTime" runat="server" />    
                      </td>
                      </tr>
                    </table>
                <br />
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 22px;" valign="middle">　　&nbsp;编辑
                        </td>
                      </tr>
                    </table>
                    <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
                        <tr>
                            <th align="right" style="width: 9%">
                <asp:Label ID="lblDispatchNo" runat="server" Text="派工单号:" CssClass="txtlab"></asp:Label></th>
                            <td style="width: 20%">
                <input id="txtDispatchNo" runat="server" autocomplete="off" name="txtDispatchNo"
                                        type="text" class="textboxodl"/>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDispatchNo"
                                    ErrorMessage="必填"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CvtxtDispatchNo" runat="server" ControlToValidate="txtDispatchNo"
                             ErrorMessage="无此工单信息" 
                             ClientValidationFunction="GetDispatchNo"  Display="Dynamic">
                         </asp:CustomValidator>                       
                </td>
                            <th align="right" class="label" style="width: 9%">
               <asp:Label ID="Label1" runat="server" CssClass="txtlab" Text="产品编号:"></asp:Label></th>
                            <td style="width: 15%">
                <asp:TextBox ID="txtProductNo" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                                </td>
                            <th align="right" style="width: 9%">
                                <asp:Label ID="Label4" runat="server" Text="产品描述:"></asp:Label></th>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtProdDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                    Width="99%" Enabled="False"></asp:TextBox></td>
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
               <asp:Label ID="lblProductDate" runat="server" Text="生产开始时间:" CssClass="txtlab"></asp:Label></th>
                            <td style="width: 30%">
                            <asp:TextBox ID="txtProductDate" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>
                            <asp:TextBox ID="txtTime" runat="server" CssClass="textboxodl" Enabled="False" 
                                    Width="54px"></asp:TextBox>
   <%--                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProductDate"
                                    ErrorMessage="必填"></asp:RequiredFieldValidator>--%>
                                    
             </td>
                        </tr>
       <tr>
           <th align="right" style="width: 9%">
                <asp:Label ID="lblWorker" runat="server" Text="QC:" CssClass="txtlab"></asp:Label></th>
           <td style="width: 20%">
            <asp:DropDownList ID="ddlWorker" runat="server" CssClass="textboxodl" ></asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlWorker"
                   ErrorMessage="必填"></asp:RequiredFieldValidator></td>
           <th align="right" style="width: 9%">
                </th>
           <td style="width: 20%">
            </td>
           <th align="right" style="width: 9%">
               </th>
           <td style="width: 30%">
           <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="false" Width="12px"></asp:TextBox></td>
       </tr>
        <tr>
            <th align="right" style="width: 9%">
                生产总数:</th>
            <td style="width: 22%">
                <asp:TextBox ID="txtTotalQty" runat="server" CssClass="textbox" Enabled="False" ReadOnly="True" ></asp:TextBox>
                PCS<asp:RegularExpressionValidator ID="revTotalQty" runat="server" ControlToValidate="txtTotalQty" Display="Static" ErrorMessage="有误" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator></td>
            <th align="right" style="width: 9%">良品数:</th>
            <td style="width: 15%">
                <asp:TextBox ID="txtGoodQty" runat="server" CssClass="textbox" Enabled="False" ReadOnly="True"></asp:TextBox>
                PCS</td>
            <th align="right" style="width: 9%">次品数:</th>
            <td style="width: 30%">
                <asp:TextBox ID="txtBadQtySum" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                PCS</td>
        </tr>
       
       <tr>
           <th align="right" style="width: 9%">
             <asp:Label ID="lblMemo" runat="server" Text="备注:"></asp:Label></th>
           <td colspan="5">
             <asp:TextBox ID="txtMemo" runat="server" CssClass="textbox" Width="99%" TextMode="MultiLine" ></asp:TextBox>
               </td>
       </tr>
                        <tr id="Tr1" runat="server">
                            <td   colspan="6" style="height: 22px; background-image: url(../images/bg_title.gif);">　　QC明细内容</td>
                        </tr>
            </table>
                <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
                  <tr id="tr2" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy1" runat="server" Text="缺料" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber1" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextNumber1" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr3" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy2" runat="server" Text="划痕" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber2" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextNumber2" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr4" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy3" runat="server" Text="色差" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber3" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextNumber3" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr5" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy4" runat="server" Text="瑕疵" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber4" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextNumber4" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr6" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy5" runat="server" Text="缺胶" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber5" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextNumber5" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr7" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy6" runat="server" Text="缩水" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber6" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextNumber6" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr8" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy7" runat="server" Text="变型" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber7" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextNumber7" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr9" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy8" runat="server" Text="料花" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber8" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextNumber8" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr10" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy9" runat="server" Text="批锋" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber9" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextNumber9" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr11" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy10" runat="server" Text="尺寸" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber10" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TextNumber10" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr12" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy11" runat="server" Text="少胶" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber11" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextNumber11" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr13" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy12" runat="server" Text="夹纹" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber12" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="TextNumber12" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr14" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy13" runat="server" Text="开裂" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber13" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="TextNumber13" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
                  </tr>
                  <tr id="tr15" runat="server">
                      <th align="right" style="width: 9%; height: 26px;">次品原因:</th>
                      <td style="width: 20%; height: 26px;"><asp:TextBox ID="Textwhy14" runat="server" Text="其他" CssClass="textboxodl" Enabled="False"></asp:TextBox></td>
                      <th align="right" style="width: 9%; height: 26px;">次品数量:</th>
                      <td align="left" style="height: 26px"><asp:TextBox ID="TextNumber14" runat="server" CssClass="textbox"></asp:TextBox>
                           PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="TextNumber14" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>&nbsp;</td>
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
