<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCycle.aspx.cs" Inherits="Product_UpdateCycle" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>派工周期修改(UpdateCycle)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>

    <script language="javascript" src="../JS/itemJS.js" type="text/javascript"></script>

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
               if(newSetById !=null)//工单号
               {
                    var response = newById.GetSearhItmes(spans[i].innerHTML,"-1");                
                     _innerTexts(response.value,newSetById);
                 }
                 
                 if(otherById!=null)//产品编号
                 {
                     var response = newById.GetSearhSetValues(spans[i].innerHTML,'1');                
                     _innerTexts(response.value,otherById);
                 }
                 if(otherById2 !=null)//产品描述
                 {
                     var response = newById.GetSearhSetValues(spans[i].innerHTML,'2');                
                     _innerTexts(response.value,otherById2);
                 }
//                 if(otherById3 !=null)//派工数量
//                 {
//                     var response = newById.GetSearhValues(spans[i].innerHTML);                
//                     _innerTexts(response.value,otherById3);
//                 }
                 if(otherById4 !=null)//模具
                 {
                     var response = newById.GetMouldMstr(spans[i].innerHTML);                
                     _innerTexts(response.value,otherById4);
                 }
                 if(otherById5 !=null)//机器
                 {
                     var response = newById.GetMachineMstr(spans[i].innerHTML);                
                     _innerTexts(response.value,otherById5);
                 }
                 if(otherById6 !=null)//模具周期
                 {
                     var response = newById.GetMouldStandCycle(spans[i].innerHTML);                
                     _innerTexts(response.value,otherById6);
                 }
//                 if(otherById7 !=null && otherById8 !=null)//模具最大最小周期
//                 {
//                     var response = newById.GetMouldMaxORMinStandCyclee(spans[i].innerHTML);                
//                    // _innerTexts(response.value,otherById6);
//                     var innText="";
//                    document.getElementById(otherById7).innerText="";
//                    innText =response.value[0];
//                    document.getElementById(otherById7).innerText=innText;
//                    document.getElementById(otherById8).innerText="";
//                    innText =response.value[1];
//                    document.getElementById(otherById8).innerText=innText;
//                 }
                showDiv(false);
                return;
            }
        }
    }
}
function _innerDDl(arrlist, byids)
{
    var updatebyid=document.getElementById(byids);
     //清空Select1的options
          for(var j=0;j< updatebyid.options.length;j++)
          {
            updatebyid.options.remove(j);
            j=0;
            //j--;
          }
          //新增Select1的options
          
          updatebyid.options[0]=new Option("选择","");
    if(arrlist.length>0)
    {
          for(var i=0;i< arrlist.length;i++)
          {
            var option=new Option(arrlist[i],arrlist[i]);
            updatebyid.options[i+1]=option;
          }
    }    

}


function selectIndex(checkesId)
{
//    var selectById=document.getElementById(checkesId);
//    var mouldNo=selectById.options[selectById.selectedIndex].value;
//    if(otherById5 !=null &&otherById4==checkesId )//模具
//    {
//        var prodNo=document.getElementById(otherById).value;
//        document.getElementById("Hidden1").innerText=mouldNo;
//        var response = newById.GetMachineMstr(mouldNo,prodNo);                
//        _innerDDl(response.value,otherById5);
//    }
//    if(otherById5 !=null &&otherById5==checkesId )//机器
//    {
//        document.getElementById("Hidden2").innerText=mouldNo;
//    }
    
}
    </script>

    <script language="jscript" type="text/javascript">
        mainLoop = function()
        {
            val = escape(queryField.value);
            if (lastVal != val)
            {
                if(document.getElementById("search").disabled)//修改时候
                {
                   val="lkdsfjlsjdsfjklssdasdasdas";
                }
                var response = Product_UpdateCycle.GetSearhItmes(val,"0");
                showQueryDiv(response.value);
                
                lastVal = val;
            }
            newById=Product_UpdateCycle;
            newSetById="txtWorkOrderNo"; //工单号
            otherById="txtProductNo";  //产品编号
            otherById2="txtProductDesc";//产品描述
            otherById4="txtMouldNo";//模具编号`
            otherById5="txtMachineNo";//机器编号`
            otherById6="txtStandCycle";//模具周期
            setTimeout('mainLoop()', 100);
            return true;
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
                            <td style="height: 24px">
                                当前位置:生产排程 -> 派工周期修改</td>
                        </tr>
                    </table>
                    <br />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table id="Table1" width="100%" runat="server" border="0" cellpadding="0" cellspacing="0"
                                bordercolor="#00ff00" align="center">
                                <tr>
                                    <td colspan="5" bgcolor="#ffffff">
                                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                            <tr>
                                                <td height="22" style="background-image: url(../images/bg_title.gif)">
                                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 操作</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                                        <asp:ListItem Value="do.DO_No">派工单号</asp:ListItem>
                                                        <asp:ListItem Value="do.WorkOrderNo">工单号</asp:ListItem>
                                                        <asp:ListItem Value="do.MachineNo">机器编号</asp:ListItem>
                                                        <asp:ListItem Value="do.ProductNo">产品编号</asp:ListItem>
                                                        <asp:ListItem Value="do.MouldNo">模具编号</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                                    <asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                                    <asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                                        OnClick="btnVisible_Click" ImageAlign="Top" />
                                                    <asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                                        OnClick="btnDelete_Click" ImageAlign="Top" />
                                                    &nbsp;&nbsp;
                                                    <input id="hdnID" type="hidden" runat="server" style="width: 5px" class="textbox" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                                        <tr>
                                                            <td style="background-image: url(../images/bg_title.gif); height: 22px;">
                                                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 浏览</td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                                        AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable"
                                                        BorderWidth="0px" CellSpacing="1" OnRowCommand="GridView1_RowCommand" PageSize="8">
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
                                                                    <input id="chkAll" type="checkbox" onclick="selectAll(this);" />
                                                                </HeaderTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                                                            </asp:TemplateField>
                                                            <asp:ButtonField DataTextField="DO_NO" CommandName="select" HeaderText="序号">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                                                                <HeaderStyle CssClass="hidden" />
                                                                <FooterStyle CssClass="hidden" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField DataTextField="DO_No" CommandName="Detail" HeaderText="派工单号" />
                                                            <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                                                            <asp:BoundField DataField="MouldNo" HeaderText="模具编号" />
                                                            <asp:BoundField DataField="ProductNo" HeaderText="产品编号" />
                                                            <asp:BoundField DataField="ProductDesc" HeaderText="产品描述">
                                                                <ItemStyle Width="300px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Standcycle" HeaderText="模具标准周期" />
                                                            <asp:BoundField DataField="UpdateStandCycle" HeaderText="修改标准周期"/>
                                                            <asp:BoundField DataField="updateemployee" HeaderText="修改人"/>
                                                            <asp:BoundField DataField="UpdateTime" HeaderText="修改时间">
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <PagerSettings Visible="False" />
                                                    </asp:GridView>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="center" valign="top">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblDataCount" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif"
                                                                                OnClick="CtrlPageInfo_Click" />
                                                                            <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif"
                                                                                OnClick="CtrlPageInfo_Click" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif"
                                                                                OnClick="CtrlPageInfo_Click" />
                                                                            <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif"
                                                                                OnClick="CtrlPageInfo_Click" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif"
                                                                                OnClick="CtrlPageInfo_Click" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex"
                                                                                ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                    <td height="22" style="background-image: url(../images/bg_title.gif)">
                                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 操作</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                            ImageAlign="Top" />
                                        <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click"
                                            ImageAlign="Top" />
                                        <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                            OnClick="btnDelete_Click" CausesValidation="false" ImageAlign="Top" />
                                        <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                            CausesValidation="false" ImageAlign="Top" />
                                        <input id="txtMaxInjectionCycle" type="hidden" runat="server" style="width: 5px"
                                            class="textbox" name="txtMaxInjectionCycle" />
                                        <input id="txtMinInjectionCycle" type="hidden" runat="server" style="width: 5px"
                                            class="textbox" name="txtMinInjectionCycle" />&nbsp;
                                        <asp:TextBox ID="txtID" runat="server" Height="8px" Visible="False" Width="1px"></asp:TextBox></td>
                                </tr>
                            </table>
                            <br />
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td height="22" style="background-image: url(../images/bg_title.gif)">
                                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 编辑</td>
                                </tr>
                            </table>
                            <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                                cellspacing="1" class="texttable">
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="lblDO_No" runat="server" Text="派工单号:" CssClass="txtlab"></asp:Label>
                                    </th>
                                    <td>
                                        <input id="search" runat="server" autocomplete="off" name="search" style="width: 132px"
                                            type="text" class="textboxodl" disabled="disabled" />
                                        <script language="javascript" type="text/javascript">window.oninit=InitQueryCode("search","querydiv");</script>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="search"
                                            Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                                    <th align="right">
                                        <asp:Label ID="lblWorkOrderNo" runat="server" Text="工单号:"></asp:Label></th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtWorkOrderNo" runat="server" CssClass="textbox" Width="132px"
                                            Enabled="False"></asp:TextBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="Label1" runat="server" Text="产品编号:"></asp:Label></th>
                                    <td>
                                        <asp:TextBox ID="txtProductNo" runat="server" CssClass="textbox" Width="132px" Enabled="False"></asp:TextBox></td>
                                    <th align="right">
                                        <asp:Label ID="lblProductNo" runat="server" Text="产品描述:"></asp:Label></th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtProductDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="99%" Enabled="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="lblMouldNo" runat="server" Text="模具编号:"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMouldNo" runat="server" CssClass="textbox" Width="132px" Enabled="False"></asp:TextBox></td>
                                    <th align="right">
                                        <asp:Label ID="lblMachineNo" runat="server" Text="机器编号:"></asp:Label></th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textbox" Width="132px" Enabled="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="lblDo_Num" runat="server" Text="模具周期:"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtStandCycle" runat="server" CssClass="textbox" Width="132px" Enabled="False"></asp:TextBox>
                                        S</td>
                                    <th align="right">
                                        派工周期:</th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtUpdateStandCycle" runat="server" CssClass="textboxodl" Width="132px"></asp:TextBox>
                                        S<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                            ControlToValidate="txtUpdateStandCycle" Display="Static" ErrorMessage="有误" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUpdateStandCycle"
                                            Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
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
