<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chief_bom.aspx.cs" Inherits="chief_bom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BOM</title>
<link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
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
              
                var response = chief_bom.GetSearhItmes(val);
                showQueryDiv(response.value);
                
                lastVal = val;
            }
           newById=chief_bom;
           
            setTimeout('mainLoop()', 100);
            return true;
        }
</script>    
</head>
<body >
  
       <form id="form2" runat="server"> 
        <table border="0" cellpadding="0" cellspacing="0" class="section-content" style="width: 98%">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">
                当前位置:工艺管理 -> 物料清单</td>
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
                &nbsp;产品编号:
                      <input id="search" runat="server" autocomplete="off" name="search" style="width: 160px" type="text" />                
                <script language="javascript" type="text/javascript">window.oninit=InitQueryCode("search","querydiv");</script>
                
<asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
                </td>
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

