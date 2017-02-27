<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkPaper.aspx.cs" Inherits="Product_WorkPaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>作业指导书(WorkPaper)</title>
     <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
     <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">
                当前位置:基础资料 -&gt; 产品管理 -&gt; 产品作业指导书</td>
          </tr>
          </table>
    <br />
            <asp:MultiView ID="MultiView1" runat="server">
         
 <asp:View ID="View2" runat="server">
  <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　操作</td>
                  </tr>
                  <tr><td style="height: 28px" id="TD1" runat="server">
                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" CausesValidation="False" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/images/btn_print.gif" OnClick="btnPrint_Click" CausesValidation="false" Visible="False" /> 
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="ImageButton1_Click1" CausesValidation="false"  />
                      <input id="hdids" runat="server" style="width: 1px" type="hidden" />
                      <input id="hdcode" runat="server" style="width: 2px" type="hidden" />
                      <input id="hdnTypes" runat="server" style="width: 2px" type="hidden" name="hdnTypes" />
                <asp:TextBox ID="txtID" runat="server" Visible="False" Width="6px"></asp:TextBox></td></tr>
                </table>
                <br />
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 20px;">　　编辑</td>
                      </tr>
                    </table> 
           <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
        <tr>
            <td align="right">
                <asp:Label ID="lblProdNO" runat="server" Text="成品编号:" CssClass="txtlab"></asp:Label></td>
            <td>
            <asp:TextBox ID="txtProdCode" runat="server" CssClass="textboxodl" Enabled="False"></asp:TextBox>&nbsp;
                </td>
            <td align="right">
                <asp:Label ID="lblProcessPhoto" runat="server" Text="作业指导图:"></asp:Label></td>
            <td>
                <asp:FileUpload ID="fudProcessPhoto" runat="server" CssClass="textbox" Width="188px" /></td>
            
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:Image ID="Image1" runat="server" /></td>
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
