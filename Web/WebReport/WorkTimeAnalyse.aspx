<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkTimeAnalyse.aspx.cs" Inherits="WebReport_WorkTimeAnalyse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工时分析表(WorkTimeAnalyse)</title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">

                    <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:报表管理 -> 工时分析表</td>
          </tr>
          </table>
<br />
    <table border="1" cellpadding="0" cellspacing="0" class="table row" style="width: 100%;
            border-collapse: collapse">
            <tr>
                <td align="right" style="width: 40%">
                    <asp:Label ID="lblPlanDate" runat="server" Text="生产日期:"></asp:Label>
                </td>
                <td>
                    <input id="txtBeginDate" runat="server" class="textbox" name="txtBeginDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" readonly="readOnly" />
                    <asp:RequiredFieldValidator ID="rfvBeginDate" runat="server" ControlToValidate="txtBeginDate"
                        ErrorMessage="*"></asp:RequiredFieldValidator>至
                    <input id="txtEndDate" runat="server" class="textbox" name="txtEndDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" type="text" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                        ErrorMessage="有误" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPosition" runat="server" Text="车间:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlPosition" runat="server" Width="124px" AutoPostBack="True" OnSelectedIndexChanged="ddlPosition_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblMachineNo" runat="server" Text="机器编号:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlMachineNo" runat="server" Width="124px">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:Button ID="btnPrint" runat="server" CssClass="button" OnClick="btnPrint_Click"
                        Text="打印报表" /></td>
            </tr>
        </table>
    
    </form>
</body>
</html>
