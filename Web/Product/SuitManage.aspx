<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuitManage.aspx.cs" Inherits="Product_SuitManage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>植毛产品管理(SuitManage)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/SuitManageMstr.js"></script>

    <script type="text/javascript" language="javascript" src="../JS/OpenFun.js"></script>

    <style type="text/css">
.login{
	position: relative;
	display: none;
	top: 20px;
	left: 30px;
	padding: 10px;
	background-color: #ffffff;
	text-align: center;
	border: solid 2px;
	border-color:#ffffff;	
	z-index: 1;	
}
</style>

    <script type="text/javascript">
function updateClick()
{
    var oldProdCode=M("hdnProdCode").value;
    var newProdCode=M("search").value;
    if(oldProdCode != newProdCode)
    {
        if(!window.confirm('确定要另存记录吗？'))
                return event.returnValue = false
    }
}
function doref(id)
{
    xid=id;
    var responsexx;
    var responseTxt;
    if(xid=="txtWireTypeCode")
    {
       M("Label9").innerText="选择铁丝";
       responsexx = Product_SuitManage.GetWireDetail("1");
        
       responseTxt = Product_SuitManage.GetWireDetail("2");
     // M("TD1").visible=true;//visible="true" ;disabled
     M("TD1").style.visibility="hidden";
    }
    else
    {
     M("Label9").innerText="选择模具";
       responsexx = Product_SuitManage.GetMouldMstr("1");
        
       responseTxt = Product_SuitManage.GetMouldMstr("2");
       M("TD1").style.visibility="visible";
    }
      //清空Select1的options
      for(var j=0;j< M('Select1').options.length;j++){
        M('Select1').options.remove(j);
        j=0;
        //j--;
      }
      //新增Select1的options
      for(var i=0;i<responsexx.value.length;i++)
      {
        var option=new Option(responsexx.value[i],responseTxt.value[i]);
        M('Select1').options[i]=option;
      }
    
   
}

function Sel(cid)
{
 var responsexx;
    var responseTxt;
    
        responsexx = Product_SuitManage.GetMould(M("TextBox2").value,"1");
        
       responseTxt = Product_SuitManage.GetMould(M("TextBox2").value,"2");
     //清空Select1的options
      for(var j=0;j< M('Select1').options.length;j++){
        M('Select1').options.remove(j);
        j=0;
        //j--;
      }
      //新增Select1的options
      for(var i=0;i<responsexx.value.length;i++)
      {
        var option=new Option(responsexx.value[i],responseTxt.value[i]);
        M('Select1').options[i]=option;
      }
}

function ko(id){
if ( M('login').style.display != 'none') {  
	var ds=M(id);
	var e="";
	var txt="";
    for(var i=0;i<ds.options.length;i++)
    {
        if(ds.options[i].selected){
	        
	          if(xid=="txtWireTypeCode")
             {
              e+= ds.options[i].text.substring(0,ds.options[i].text.indexOf("    "))+": "+ds.options[i].value+","; 
              txt+=ds.options[i].text.substring(0,ds.options[i].text.indexOf("    "))+","; 
             }
             else
             {             
              e+= ds.options[i].value+","; 
	         txt+=ds.options[i].text.substring(0,ds.options[i].text.indexOf("    "))+","; 
	         }
        }
    }	
    e=e.substring(0,e.length-1);
    txt=txt.substring(0,txt.length-1);
    if(xid=="txtWireTypeCode")
    {
        M("txtWireTypeCode").value="";
        M("txtWireDesc").value="";
	    M("txtWireDesc").innerText=e;
	    M("txtWireTypeCode").innerText=txt;
    }else
    {
        M("txtWireBrushMouldDesc").value="";
        M("txtWireBrushMould").value="";
	    M("txtWireBrushMouldDesc").innerText=e;
	    M("txtWireBrushMould").innerText=txt;
	  
	}
	closes();
	}
}

    </script>

    <script language="javascript" type="text/javascript">
/**
文本输入框的onkeydown响应函数
*/
function keypressHandler (evt)
{
    // 获取对下拉区的引用        
    var div = getDiv(divName);

   // 如果下拉区不显示，则什么也不做       
    if (div.style.visibility == "hidden")
    {
        //return true;
    }
  

    // 确保evt是一个有效的事件   
    if (!evt && window.event)
    {
        evt = window.event;
    }
    var key = evt.keyCode;

    var KEYUP = 38;
    var KEYDOWN = 40;
    var KEYENTER = 13;
    var KEYTAB = 9;
    var KEYESC =27;
   
    // 只处理上下键、回车键和Tab键的响应       
    if ((key != KEYUP) && (key != KEYDOWN) && (key != KEYENTER) && (key != KEYTAB) && (key != KEYESC))
    {
        document.getElementById("txtUpInput").disabled=false;        
        return true;
    }
    else
    {
        document.getElementById("txtUpInput").disabled=true;
        return false;
    }
    
    var selNum = getSelectedSpanNum(div);
    var selSpan = setSelectedSpan(div, selNum);
   
    if((key == KEYESC))
    {
//         if (selSpan)
//            {
//                _selectResult(selSpan);
//           }
            evt.cancelBubble = true;
            
            // 隐藏下拉区
            showDiv(false);
            return false;
    }
    else
    {
        // 如果键入回车和Tab，则选择当前选择条目   
        if ((key == KEYENTER) || (key == KEYTAB))
        {
            if (selSpan)
            {
                _selectResult(selSpan);
           }
            evt.cancelBubble = true;
            
            // 显示下拉区
            showDiv(false);
            return false;
        }
        else //如果键入上下键，则上下移动选中条目
        {
            if (key == KEYUP)
            {
                selSpan = setSelectedSpan(div, selNum - 1);
            }
            if (key == KEYDOWN)
            {
                selSpan = setSelectedSpan(div, selNum + 1);
            }
            if (selSpan)
            {
                _highlightResult(selSpan);
            }
            
        }
    }

    // 显示下拉区
    showDiv(true);
    return true;
}
    </script>

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
                if(newSetById != "" )
                 {
                    var response = newById.GetSearhValues(spans[i].innerHTML); 
                   // 
                    if(response!=null)
                    {               
                     _innerTexts(response.value,newSetById);
                     //alert(arrLsit.value[0]);
                     }
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
                if(document.getElementById("txtUpInput").disabled)//修改时候
                {
                   val="lkdsfjlsjdsfjklssdasdasdahjjjvjvvnvgfhs";
                }
                var response = Product_SuitManage.GetSearhItmes(val);
                showQueryDiv(response.value);
                
                lastVal = val;
            }
            newById=Product_SuitManage;
            newSetById="txtPlantBristlesDesc";
            
            setTimeout('mainLoop()', 100);
            
            return true;
        }
    </script>

</head>
<body text="#0">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="section-content">
            <tr>
                <td valign="top">
                    <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
                        <tr>
                            <td style="height: 24px">
                                当前位置:基础资料 ->植毛产品管理</td>
                        </tr>
                    </table>
                    <br />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                            <tr>
                                    <td style="background-image: url(../images/bg_title.gif); height: 24px;">
                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlQuery" runat="server" Width="99px">
                                            <asp:ListItem Value="PlantBristlesCode">产品编号</asp:ListItem>
                                            <asp:ListItem Value="WireBrushMould">植毛模具</asp:ListItem>
                                            <asp:ListItem Value="SystemNo">系统编号</asp:ListItem>
                                            <asp:ListItem Value="OutNum">出模数</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"
                                            OnClick="btnVisible_Click" ImageAlign="Top" />
                                        <asp:ImageButton ID="btnNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif"
                                            OnClick="btnVisible_Click" ImageAlign="Top" />
                                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/btn_delete.gif"
                                            OnClick="btnDelete_Click" ImageAlign="Top" />
                                        <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="5px"></asp:TextBox></td>
                                </tr>
                            </table>
                            <br />
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                            <tr>
                                                <td style="background-image: url(../images/bg_title.gif); height: 24px;">
                                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 浏览</td>
                                            </tr>
                                        </table>
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False"
                                            AllowPaging="True" CssClass="itemtable" OnRowDataBound="GridView1_RowDataBound"
                                            BorderWidth="0px" CellSpacing="1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
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
                                                    <ItemStyle HorizontalAlign="Center" Width="26px" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                                                    <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                                                    <HeaderStyle CssClass="hidden" />
                                                    <FooterStyle CssClass="hidden" />
                                                </asp:ButtonField>
                                                <asp:ButtonField DataTextField="PlantBristlesCode" CommandName="select" HeaderText="产品编号" />
                                                <asp:BoundField DataField="PlantBristlesDesc" HeaderText="产品描述">
                                               
                                                    <ItemStyle Width="300px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="WireBrushMould" HeaderText="植毛模具">
                                                    <ItemStyle Width="250px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OutNum" HeaderText="出模数" />
                                                <asp:BoundField DataField="StandEmployee" HeaderText="人员需求" />
                                                <asp:BoundField DataField="Remark" HeaderText="备注"></asp:BoundField>
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
                                                                <input id="hdnFlag" type="hidden" runat="server" style="width: 13px" />
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
                                    <td style="background-image: url(../images/bg_title.gif); height: 23px;">
                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 操作</td>
                                </tr>
                                <tr>
                                    <td style="height: 28px" valign="middle">
                                        <asp:ImageButton ID="btnInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                        <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif"
                                            OnClick="btnDelete_Click" ImageAlign="Top" />
                                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click"
                                            CausesValidation="false" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <input id="txtUpInput" autocomplete="off" name="txtUpInput" style="width: 1px; border-right: #ffffff thin solid;
                                            border-top: #ffffff thin solid; border-left: #ffffff thin solid; border-bottom: #ffffff thin solid;"
                                            type="text" class="textbox" disabled="disabled" visible="true" runat="server" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:ImageButton ID="igbwork" runat="server" CausesValidation="False" ImageAlign="Top"
                                            ImageUrl="~/images/btn_work.gif" OnClick="igbwork_Click" />&nbsp;<asp:ImageButton
                                                ID="igbbox" runat="server" CausesValidation="False" ImageAlign="Top" ImageUrl="~/images/btn_box.gif"
                                                OnClick="igbwork_Click" /></td>
                                </tr>
                            </table>
                            <br />
                            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                                <tr>
                                    <td style="background-image: url(../images/bg_title.gif); height: 23px;">
                                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 编辑</td>
                                </tr>
                            </table>
                            <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1"
                                cellspacing="1" class="texttable">
                                <tr>
                                    <th align="right" class="label" style="width: 9%">
                                        <asp:Label ID="Label1" runat="server" Text="产品编号:" CssClass="txtlab"></asp:Label></th>
                                    <td style="width: 22%">
                                        <%--<asp:TextBox ID="txtPlantBristlesCode" runat="server" CssClass="textboxodl" ></asp:TextBox>--%>
                                        <input id="search" runat="server" autocomplete="off" name="search" style="width: 117px"
                                            type="text" class="textboxodl" disabled="disabled" onkeydown="keypressHandler()" />

                                        <script language="javascript" type="text/javascript">window.oninit=InitQueryCode("search","querydiv");</script>

                                        <asp:RequiredFieldValidator ID="rfvItem_Code" runat="server" ControlToValidate="search"
                                            ErrorMessage="必填" Width="24px"></asp:RequiredFieldValidator></td>
                                    <th align="right" style="width: 10%">
                                        产品描述:</th>
                                    <td colspan="3" style="width: 68%;">
                                        <asp:TextBox ID="txtPlantBristlesDesc" runat="server" CssClass="textbox" Width="410px"
                                            TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        适应机型:</th>
                                    <td style="width: 22%">
                                        <asp:DropDownList ID="ddlSuitMachine" runat="server" CssClass="textbox" Width="117px">
                                        </asp:DropDownList>
                                        <input id="hdnProdCode" runat="server" style="width: 19px; height: 13px" type="hidden"
                                            name="hdnProdCode" /></td>
                                    <th align="right" style="width: 10%">
                                        植毛模具:</th>
                                    <td colspan="3" style="width: 68%;">
                                        <asp:TextBox ID="txtWireBrushMould" runat="server" CssClass="textboxodl" TextMode="MultiLine"
                                            Width="410px"></asp:TextBox>
                                        <a href="#" onclick="opens('txtMouldCode')" style="color: #ff3333">选择</a>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWireBrushMould"
                                            ErrorMessage="必填" Width="24px"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        孔数:</th>
                                    <td style="width: 22%">
                                        <asp:TextBox ID="txtHoleNum" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtHoleNum"
                                            ErrorMessage="有误" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator></td>
                                    <th align="right" style="width: 10%">
                                        模具描述:</th>
                                    <td colspan="3" style="width: 68%;">
                                        <asp:TextBox ID="txtWireBrushMouldDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="410px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%; height: 26px;">
                                        <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="系统编码:"></asp:Label></th>
                                    <td style="width: 22%; height: 26px;">
                                        <asp:TextBox ID="txtSystemNo" runat="server" CssClass="textbox"></asp:TextBox></td>
                                    <th align="right" style="width: 10%; height: 26px;">
                                        植毛刷丝重:</th>
                                    <td style="width: 67%; height: 26px;">
                                        <asp:TextBox ID="txtWireBrushWeight" runat="server" CssClass="textbox"></asp:TextBox>
                                        g<span><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ControlToValidate="txtWireBrushWeight" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></span></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        拉力:</th>
                                    <td style="width: 22%">
                                        <asp:TextBox ID="txtRally" runat="server" CssClass="textbox"></asp:TextBox>
                                        N</td>
                                    <th align="right" style="width: 10%">
                                        刷丝编码:</th>
                                    <td style="width: 67%;">
                                        <asp:TextBox ID="txtBrushWireTypeCode" runat="server" CssClass="textbox"></asp:TextBox>
                                        <input id="hdnID" runat="server" style="width: 5px" type="hidden" /></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        <asp:Label ID="Label7" runat="server" ForeColor="Black" Text="修毛高度:"></asp:Label></th>
                                    <td style="width: 22%">
                                        <asp:TextBox ID="txtModiHeight" runat="server" CssClass="textbox"></asp:TextBox>
                                        mm</td>
                                    <th align="right" style="width: 10%">
                                        取毛刀:</th>
                                    <td style="width: 67%;">
                                        <asp:TextBox ID="txtGetKnifeFoot" runat="server" CssClass="textbox"></asp:TextBox>
                                        mm<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                            ControlToValidate="txtGetKnifeFoot" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        出模数:</th>
                                    <td style="width: 22%">
                                        <asp:DropDownList ID="ddlOutNum" runat="server" CssClass="textbox" Width="120px">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem Selected="True">2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                        </asp:DropDownList>
                                        PCS</td>
                                    <th align="right" style="width: 10%">
                                        切毛长度:</th>
                                    <td style="width: 67%;">
                                        <asp:TextBox ID="txtCutLength" runat="server" CssClass="textbox"></asp:TextBox>
                                        mm</td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        产品图片:</th>
                                    <td style="width: 22%">
                                        &nbsp;<asp:FileUpload ID="fudProcessPhoto" runat="server" CssClass="textbox" Width="188px" /></td>
                                    <th align="right" style="width: 10%">
                                        <asp:Label ID="Label8" runat="server" ForeColor="Black" Text="人员需求:" ></asp:Label></th>
                                    <td style="width: 67%;">
                                        <asp:TextBox ID="txtStandEmployee" runat="server" CssClass="textbox" BackColor="Yellow"></asp:TextBox>个<asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtStandEmployee"
                                            Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="铁丝重:"></asp:Label></th>
                                    <td style="width: 22%">
                                        <asp:TextBox ID="txtWireWeight" runat="server" CssClass="textbox"></asp:TextBox>
                                        g<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                            ControlToValidate="txtWireWeight" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                                    <th align="right" style="width: 10%">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="孔径:"></asp:Label></th>
                                    <td style="width: 67%;">
                                        <asp:TextBox ID="txtHoleDiameter" runat="server" CssClass="textbox"></asp:TextBox>
                                        mm<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                            ControlToValidate="txtHoleDiameter" Display="Static" ErrorMessage="有误" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        托盘数:</th>
                                    <td style="width: 22%">
                                        <asp:TextBox ID="txtTrayNum" runat="server" CssClass="textbox"></asp:TextBox></td>
                                    <th align="right" style="width: 10%">
                                        每层数量:</th>
                                    <td style="width: 67%">
                                        <asp:TextBox ID="txtColumnNum" runat="server" CssClass="textbox"></asp:TextBox>
                                        PCS<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                            ControlToValidate="txtColumnNum" Display="Static" ErrorMessage="有误" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 9%">
                                        层数:</th>
                                    <td style="width: 22%">
                                        <asp:TextBox ID="txtColumnCount" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtColumnCount"
                                            Display="Static" ErrorMessage="有误" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator></td>
                                    <th align="right" style="width: 10%">
                                        版本号:</th>
                                    <td style="width: 67%">
                                        <asp:TextBox ID="txtVer" runat="server" CssClass="textbox">1</asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Visible="False" Width="10px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" rowspan="5">
                                        <asp:Image ID="Image1" runat="server" /></td>
                                    <th align="right" style="width: 10%">
                                        <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="铁丝编码:"></asp:Label></th>
                                    <td align="left" colspan="3" rowspan="1" style="width: 68%;">
                                        <asp:TextBox ID="txtWireTypeCode" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="410px"></asp:TextBox>
                                        <a href="#" onclick="opens('txtWireTypeCode')" style="color: #ff3333">选择</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 10%">
                                        <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="铁丝编码描述:"></asp:Label></th>
                                    <td align="left" colspan="3" rowspan="1" style="width: 68%;">
                                        <asp:TextBox ID="txtWireDesc" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="410px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 10%">
                                        备注:</th>
                                    <td align="left" colspan="3" rowspan="1" style="width: 68%;">
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="410px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 10%">
                                        版本更新原因:</th>
                                    <td align="left" colspan="3" rowspan="1" style="width: 68%;">
                                        <asp:TextBox ID="txtVerModiReason" runat="server" CssClass="textbox" TextMode="MultiLine"
                                            Width="410px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th align="right" style="width: 10%">
                                        修改记录:</th>
                                    <td align="left" colspan="3" rowspan="1" style="width: 68%">
                                        <asp:TextBox ID="txtVerModiContent" runat="server" CssClass="textbox" Height="60px"
                                            TextMode="MultiLine" Width="410px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
        <div id="login" class="login" style="background-color: #f9f9f9">
            <table border="0.1px" width="100%">
                <tr style="width: 100%; height: 24px;">
                    <td colspan="2" align="center" style="width: 98%">
                        <span style="font-weight: bold; font-size: 20px;">
                            <asp:Label ID="Label9" runat="server" Text="选择模具"></asp:Label>
                        </span>
                    </td>
                    <td align="right" colspan="1" style="width: 5%;" valign="top">
                        <a href="#" onclick="closes();">×</a>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" valign="middle" id="TD1" runat="server">
                        模具货号:<asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="100px" valign="middle"></asp:TextBox>
                        <input
                            id="Button1" type="button" onclick="Sel('Select1')" style="border-right: #ffffff 0px solid;
                            border-top: #ffffff 0px solid; background-image: url(../images/btn_search.gif);
                            border-left: #ffffff 0px solid; width: 67px; border-bottom: #ffffff 0px solid;
                            height: 24px" tabindex="-1" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" style="height: 224px">
                        <select id="Select1" name="Select1" multiple runat="server" size="20" style="width: 266px;
                            height: 300px; border: 1px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <img src="../images/btn_yes.gif" onclick="ko('Select1')" id="IMG1" />
                        &nbsp;<img src="../images/btn_cancel.gif" onclick="closes();" /></td>
                </tr>
            </table>
            <div id="panel">
            </div>
        </div>
    </form>
</body>
</html>
