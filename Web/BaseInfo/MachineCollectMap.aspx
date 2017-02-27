<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MachineCollectMap.aspx.cs" Inherits="Machine_MachineCollectMap" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../JS/checkbox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
       <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
           <tr>
               <td>
                   <asp:MultiView ID="MultiView1" runat="server">
                       <asp:View ID="View1" runat="server">
                       <fieldset><legend>操作</legend>
                               <asp:DropDownList ID="ddlQuery" runat="server">
                               </asp:DropDownList>
                               <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                           <asp:Button ID="btnQuery" runat="server" CssClass="button"  OnClick="btnQuery_Click" Text="查询" />
                           <asp:Button ID="btnNewadd" runat="server" CssClass="button"  OnClick="btnVisible_Click" Text="新增" />
                           <asp:Button ID="btnCancel" runat="server" CssClass="button"  OnClick="btnDelete_Click" Text="删除" /></fieldset>&nbsp;
                           
                           <table border=0 cellpadding=0 cellspacing=0 width="100%">
                           
                           <tr><td>
                           <fieldset><legend>浏览</legend>
                           <asp:GridView ID="GridView1" runat="server" CellPadding="0" ForeColor="#333333" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" CssClass="gridview" OnRowDataBound="GridView1_RowDataBound" >
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
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
                         <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号" >
                             <ItemStyle CssClass="hidden" />
                             <HeaderStyle CssClass="hidden" />
                             <FooterStyle CssClass="hidden" />
                         </asp:ButtonField>
                         <asp:ButtonField DataTextField="MachineNO" CommandName="select" HeaderText="机器编号" />
                         <asp:BoundField DataField="CollectNO" HeaderText="采集器编号" />
                         <asp:BoundField DataField="Remark" HeaderText="备注" />
                     </Columns>
                     <PagerSettings Visible="False" /> 
    </asp:GridView>  </fieldset>
    </td></tr>
                           <tr><td align="center"><asp:Label ID="lblGridViewInfo" runat="server" Text=""></asp:Label> 
 <asp:LinkButton ID="lkbFirstPage" runat="server" CommandArgument="First" OnClick="lkbChangPage_Click">首页</asp:LinkButton>
 <asp:LinkButton ID="lkbPriorPage" runat="server" CommandArgument="Prev" OnClick="lkbChangPage_Click">上一页</asp:LinkButton> 
 <asp:LinkButton ID="lkbNextPage" runat="server" CommandArgument="Next" OnClick="lkbChangPage_Click">下一页</asp:LinkButton> 
 <asp:LinkButton ID="lkbLastPage" runat="server" CommandArgument="Last" OnClick="lkbChangPage_Click">尾页</asp:LinkButton></td></tr>
  </table>

  </asp:View>
<asp:View ID="View2" runat="server">
<fieldset><legend>操作</legend>
                               <asp:Button ID="btnInsert" runat="server"  CssClass="button"  Text="提交" OnClick="btnINS_UDP_DEL_Click" />
                               <asp:Button ID="btnUpdate" runat="server"  CssClass="button" Text="保存" OnClick="btnINS_UDP_DEL_Click" />
                               <asp:Button ID="btnDelete" runat="server" CssClass="button"  Text="删除" OnClick="btnDelete_Click" ValidationGroup="0" />
                           <asp:Button ID="btnBack" runat="server" CssClass="button"  OnClick="btnVisible_Click" Text="返回" ValidationGroup="0" />
                               <asp:Label ID="lblExecMsg" runat="server" ForeColor="Red"></asp:Label>
                                                          </fieldset>&nbsp;
                           <fieldset><legend>编辑</legend>
                   <table width="100%" border=0 cellpadding=0 cellspacing=0 class="toptable row">
                       <tr>
                           <td width=50%>
                               <asp:Label ID="lblMachineNO" runat="server" Text="机器编号:"></asp:Label>
                               <asp:TextBox ID="txtMachineNO" runat="server" CssClass=textbox></asp:TextBox>
                               <asp:RequiredFieldValidator ID="rfvMachineNO" runat="server" ControlToValidate="txtMachineNO"
                                   ErrorMessage="*"></asp:RequiredFieldValidator></td>
                               <td>
                               <asp:Label ID="lblCollectNO" runat="server" Text="采集器编号:"></asp:Label>
                               <asp:TextBox ID="txtCollectNO" runat="server" CssClass=textbox></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="rfvCollectNO" runat="server" ControlToValidate="txtCollectNO"
                                       ErrorMessage="*"></asp:RequiredFieldValidator></td>
                       </tr>
                       <tr>
                           <td>
                               <asp:Label ID="lblRemark" runat="server" Text="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注:"></asp:Label>
                               <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox"></asp:TextBox>
                               <input id="hdnID" runat="server" type="hidden" />
                               
                               <asp:Label ID="lblID" runat="server" Text="流水号:" Visible="False"></asp:Label></td>
                               <td>
                               <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False"></asp:TextBox></td>
                       </tr>
                   </table>
                   </fieldset>
                       </asp:View>
                   </asp:MultiView>
               </td>
           </tr>
       </table>
   </div>
    </form>
</body>
</html>
