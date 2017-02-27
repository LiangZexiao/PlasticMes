<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Choose_CrystalReport.aspx.cs" Inherits="CrystalReports_Choose_CrystalReport" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>自定义报表</title>
     <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script type="text/javascript" language="javascript" >
   
    </script>
</head>

<body> 
    <form id="form1" runat="server">   
     <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
                <td style="height: 17px" >
                    当前位置:报表管理-> 自定义报表</td>
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
                    <td>
                        绑定数据表个数 &nbsp;<asp:DropDownList ID="dropnum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropnum_SelectedIndexChanged">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                        </asp:DropDownList><asp:Label ID="tabname" runat="server" Visible="False"  /></td>
                  </tr>
                
             <tr>
             <td>
                
                 <asp:Table ID="tables1" runat="server" Width="100%">
                 </asp:Table>
                 <asp:Table ID="tabx2" runat="server" Width="100%">
                 </asp:Table>
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
