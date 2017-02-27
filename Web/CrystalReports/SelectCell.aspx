<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCell.aspx.cs" Inherits="CrystalReports_SelectCell" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>选择列</title>
      <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellpadding="0" cellspacing="0" class="tablefoot" style="height: 24px">
       
            <tr>
                <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
            </tr>
            
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="itemtable" style="height: 24px">
            <tr>
            <td style="height: 326px" align="center">
                    <select id="Select1" size="20" style="height:<%=numbers %>; width: 221px;"  runat="server">
                        
                    </select>
                <br />
                    <asp:ImageButton ID="btnok" runat="server" ImageUrl="~/images/btn_yes.gif" OnClick="btnok_Click"  />
                        <asp:ImageButton ID="btnclose" runat="server" ImageUrl="~/images/btn_cancel.gif" OnClick="btnclose_Click" /></tr>
     </table>
    </div>
    </form>
</body>
</html>
