<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PackageList.aspx.cs" Inherits="Product_PackageList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1"  runat="server">
<title>包装单(PackageList)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
</head>
<body>
      <form id="form2" runat="server"> 
        <table border="0" cellpadding="0" cellspacing="0" class="section-content" style="width: 98%">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">
               当前位置:基础资料 -&gt; 注塑产品管理 -&gt; 产品包装单</td>
          </tr>
          </table>
<br />
     <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　操作</td>
                  </tr>
            <tr>
            <td style="height: 20px" >
                &nbsp;<asp:ImageButton id="btnBack" onclick="ImageButton1_Click1" runat="server" ImageUrl="~/images/btn_back.gif" CausesValidation="false"></asp:ImageButton>
                <input id="hdids" runat="server" style="width: 1px" type="hidden" /><input id="hdcode"
                    runat="server" style="width: 2px" type="hidden" /><input id="hdnTypes" runat="server"
                        name="hdnTypes" style="width: 2px" type="hidden" /><asp:TextBox ID="txtID" runat="server"
                            Visible="False" Width="6px"></asp:TextBox></td>
              </tr>
              </table>
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 22px;">　　浏览</td>
                      
                </tr>
                
               <tr>
               <td style="width:100%">
                <table style="width:100%; height:100%; border-collapse:collapse; padding:0px; background-color:White; border: 1px;">
                <tr><td style="width:100%; ">
                 <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="12" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="True" ForeColor="#055BAE" />
                        <AlternatingRowStyle BackColor="White" />
                       <Columns>
                           <asp:BoundField DataField="ITMREF" HeaderText="产品编号" />
                           <asp:BoundField DataField="ITMDES" HeaderText="产品描述" />
                            
                         <asp:ButtonField DataTextField="CPNITMREF" CommandName="select" HeaderText="组件编码" />
                         <asp:BoundField DataField="ITMDES_1" HeaderText="组件描述" />
                           <asp:BoundField DataField="XLK" HeaderText="组件数量" />
                     </Columns>
                        <PagerSettings Visible="False" /> 
                    </asp:GridView>
            </td></tr>
            </table>
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