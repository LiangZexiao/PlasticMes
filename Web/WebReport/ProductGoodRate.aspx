<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductGoodRate.aspx.cs" Inherits="WebReport_ProductGoodRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>产品合格率报表(ProductGoodRate)</title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label id="lblLocal" runat="server" ForeColor="Blue" Text="当前位置:报表管理-->产品合格率报表"></asp:Label>
        <table style="width: 100%; border-collapse: collapse;" border="1" cellpadding="0" cellspacing="0" class="table row">
            <tr>
                <td align="right" style="width: 40%">
                    <asp:Label ID="lblDate" runat="server" Text="生产日期:"></asp:Label>
                </td>
                <td>
                    <input id="txtBeginDate" runat="server" class="textbox" name="txtBeginDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" readonly="readOnly" /><asp:RequiredFieldValidator
                            ID="rfvBeginDate" runat="server" ControlToValidate="txtBeginDate" ErrorMessage="*"></asp:RequiredFieldValidator>至
                    <input id="txtEndDate" runat="server" class="textbox" name="txtEndDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                        ErrorMessage="有误" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblOrderID" runat="server" Text="生产单号:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlOrderID" runat="server" CssClass="dropdownlist">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    </td>
                <td>
                    <asp:Button ID="btnPrint" runat="server" Text="打印报表" CssClass="button" OnClick="btnPrint_Click" /></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblProductNo" runat="server" Text="产品编号:" Visible="False"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlProductNo" runat="server" Visible="False" Width="124px">
                </asp:DropDownList></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
