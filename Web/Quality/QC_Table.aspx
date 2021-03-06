﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QC_Table.aspx.cs" Inherits="Quality_QC_Table" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>QA检查(QC_Table)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script language="javascript" type="text/javascript">
        function GetDispatchNo(sender, args) {
            var txtNo = document.getElementById("txtDispatchNo").value;
            var arryList = Quality_QC_Table.getSearchDispatchNo(txtNo);

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
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:品质管理 -> QC检查</td>
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
<asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" Visible="false"/></td>
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
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" OnRowCommand="GridView1_RowCommand"  >
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
                     <input id="chkAll" type="checkbox" onclick="selectAll(this);"/>
                     </HeaderTemplate>
                     <ItemStyle HorizontalAlign="Center"  Width="26px"/>
                     <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                    <asp:ButtonField DataTextField="ID" HeaderText="序号">
                    <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                        <FooterStyle CssClass="hidden" />
                    </asp:ButtonField>
                    <asp:ButtonField CommandName="detail" Text="报废" Visible="False">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:ButtonField>
                    <asp:ButtonField DataTextField="DispatchNo" CommandName="select" HeaderText="派工单号" SortExpression="DispatchNo" />
                    <asp:BoundField DataField="ProductNo" HeaderText="产品编号" SortExpression="ProductNo" />
                    <asp:BoundField DataField="MachineNo" HeaderText="机器编号" SortExpression="MachineNo" />
                    <asp:BoundField DataField="MouldNo" HeaderText="模具编号" SortExpression="MouldNo" />
                    <asp:BoundField DataField="TotalQty" HeaderText="生产总数" SortExpression="TotalQty" />
                    <asp:BoundField DataField="GoodQty" HeaderText="良品数" SortExpression="GoodQty" />
                    <asp:BoundField DataField="BadQty" HeaderText="报废品数" SortExpression="BadReasonNum" />
                    <asp:BoundField DataField="Worker" HeaderText="操作工"  SortExpression="Worker" Visible="False"/>
                    <asp:BoundField DataField="Checker" HeaderText="质检员" SortExpression="Checker" Visible="False"/>
                    <asp:BoundField DataField="CheckDate" HeaderText="记录日期" SortExpression="CheckDate" Visible="False"/>
                    <asp:BoundField DataField="Memo" HeaderText="备注" />
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
                        <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="false" Visible="false"/>
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
            <th align="right" style="width: 9%">报废品数:</th>
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
                        <tr runat="server">
                            <td   colspan="6" style="height: 22px; background-image: url(../images/bg_title.gif);">　　QC明细内容</td>
                        </tr>
        <tr id="trDetail" runat="server">
            <th align="right" style="width: 9%; height: 26px;">
                报废原因:</th>
            <td style="width: 20%; height: 26px;">
               <asp:DropDownList ID="ddlBadReason" runat="server" CssClass="dropdownlist">
               </asp:DropDownList></td>
            <th align="right" style="width: 9%; height: 26px;">
                报废品数量:</th>
            <td align="left" colspan="2" style="height: 26px">
                <asp:TextBox ID="txtBadQty" runat="server" CssClass="textbox"></asp:TextBox>
                PCS<asp:RegularExpressionValidator ID="Regular" runat="server" ControlToValidate="txtBadQty" Display="Static" ErrorMessage="输入数字" ValidationExpression="^[\d]+$"></asp:RegularExpressionValidator>
                &nbsp;</td>
            <td style="width: 30%; height: 26px;">
                <asp:TextBox ID="txtDetailID" runat="server" CssClass="textbox" Visible="false" Width="12px"></asp:TextBox></td>
        </tr>
            </table>
                <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
                  <tr>
                    <td align="center" >
                    
                    <asp:GridView ID="GridView2" runat="server" CellPadding="2" Width="26%" AutoGenerateColumns="False" AllowPaging="True" PageSize="40" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" OnRowCommand="GridView2_RowCommand" >
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
                            <input id="chkAll" type="checkbox" onclick="selectAll(this);"/>
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center"  Width="26px"/>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                        <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                        <FooterStyle CssClass="hidden" />
                    </asp:ButtonField>
                    <asp:ButtonField DataTextField="ReasonName" HeaderText="报废原因" CommandName="select" />
                    <asp:BoundField DataField="BadQty" HeaderText="报废数量" />
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
                    
                            
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