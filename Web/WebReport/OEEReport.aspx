﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OEEReport.aspx.cs" Inherits="WebReport_OEEReport" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>设备可动率报表</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <link href="../WebControls/DatePicker/skin/WdatePicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../WebControls/DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

    <script src="../JS/BOMItem.js" language="javascript" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

// 选择一个条目
function _selectResult(item)
{
    var spans = item.getElementsByTagName("span");
    if (spans)
    {
        for (var i = 0; i < spans.length; i++)
        {
            if (spans[i].className == "result1")
            {
                queryField.value = spans[i].innerHTML;
                lastVal = val = escape(queryField.value);
                mainLoop();
                queryField.focus();
                //showDiv(true);
               
               //document.getElementById("TextBox1").innerText = spans[i].innerHTML; 
                if(newSetById!="" )
                 {
                    var response = newById.GetSearhValues(spans[i].innerHTML);                
                     _innerTexts(response.value,newSetById);
                 }
                showDiv(false);
                return;
            }
        }
    }
}
    </script>

    <script language="jscript" type="text/javascript">
        mainLoop = function()
        {
            val = escape(queryField.value);
            if (lastVal != val)
            {
              
                var response = WebReport_OEEReport.GetSearhItmes(val);
                showQueryDiv(response.value);
                
                lastVal = val;
            }
           newById=WebReport_OEEReport;
           
            setTimeout('mainLoop()', 100);
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table id="tblBiggest" border="0" cellpadding="0" cellspacing="0" class="section-content">
            <tr>
                <td valign="top">
                    <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                        <tr>
                            <td style="height: 24px">
                                当前位置:报表管理 -> 设备可动率报表</td>
                        </tr>
                    </table>
                    <br />
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0" style="width: 100%">
                        <tr>
                            <td style="background-image: url(../images/bg_title.gif); height: 19px;">
                                &nbsp; &nbsp; &nbsp;&nbsp;
                                条件</td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="1" cellspacing="1" class="texttable" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <th align="right" style="width: 35%">
                                <asp:Label ID="lblMonth" runat="server" Text="生产日期:"></asp:Label>
                            </th>
                          <td>
                                <input runat="server" type="text" id="txtBeginDate" name="txtBeginDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 至
                                 <input runat="server" type="text" id="txtEndDate" name="txtEndDate"  
                                   onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" class="Wdate"
                                 style="width: 130px" /> 
                            </td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 35%">
                                机器编号:</th>
                            <td align="left">
                                <input id="search" runat="server" autocomplete="off" name="search" style="width: 160px"
                                    type="text" />

                                <%--<script language="javascript" type="text/javascript">window.oninit=InitQueryCode("search","querydiv");</script>--%>

                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:ImageButton ID="igbPrint" runat="server" ImageUrl="~/images/btn_print.gif" OnClick="igbPrint_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
