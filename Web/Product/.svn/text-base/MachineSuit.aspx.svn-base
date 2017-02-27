<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MachineSuit.aspx.cs" Inherits="Product_MachineSuit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>植毛机管理(MachineSuit)</title>
<link href="../images/css.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/checkbox.js"></script>
     <script type="text/javascript" language="javascript" src="../JS/Common.js"></script>
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

<script  type="text/javascript">
function doref(id)
{
    xid=id;
    
   
}

function ko(id){
if ( M('login').style.display != 'none') {  
	var ds=M(id);
	var e="";
	 for(var i=0;i<ds.options.length;i++){
							if(ds.options[i].selected){
								 e+= ds.options[i].value+","; 
							}
					}	
    e=e.substring(0,e.length-1);
	//M("txt1").innerText=e;
	M("txtSuitBrush").innerText=e;
	closes();
	}
}
</script>
</head>
<body>
    <form id="form1" runat="server" action="">
    <table  border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:基础资料 -> 植毛机管理</td>
          </tr>
          </table>
          <br />
            <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td style="background-image: url(../images/bg_title.gif); height: 20px;">　　操作</td>
                  </tr>
            <tr>
            <td >
                <asp:DropDownList ID="ddlQuery" runat="server" Width="99px">
                <asp:ListItem Value="MachineCode">机器编号</asp:ListItem>
                <asp:ListItem Value="MachineType">机器型号</asp:ListItem>
             </asp:DropDownList>                                    
                     <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="btnQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="btnNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" />
                <asp:TextBox ID="txtID" runat="server" CssClass="textbox" Visible="False" Width="5px"></asp:TextBox>
                <input id="hdnID" runat="server" style="width: 2px" type="hidden" /></td>
              </tr>
              </table>
              <br />
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
        <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 20px;">　　浏览</td>
                      </tr>
                    </table> 
        <asp:GridView ID="GridView1" runat="server" CellPadding="2"  Width="100%" AutoGenerateColumns="False"   AllowPaging="True" PageSize="12" CssClass="itemtable" 
        OnRowDataBound="GridView1_RowDataBound" BorderWidth="0px" CellSpacing="1" 
        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
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
                 <input id="chkAll" type="checkbox" onclick="selectAll(this);"/>
             </HeaderTemplate>
             <ItemStyle HorizontalAlign="Center"  Width="26px"/>
             <HeaderStyle HorizontalAlign="Center" />
         </asp:TemplateField>
                        <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号">
                        <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                            <HeaderStyle CssClass="hidden" />
                            <FooterStyle CssClass="hidden" />
                        </asp:ButtonField>
                         <asp:ButtonField DataTextField="MachineCode" CommandName="select" HeaderText="机器编号" />
                          <asp:BoundField DataField="MachineType" HeaderText="机器型号" />
                         <asp:BoundField DataField="MachineAxisNum" HeaderText="机器轴数" />
                         <asp:BoundField DataField="Power" HeaderText="功率" />
                         <asp:BoundField DataField="Manufacturers" HeaderText="制造厂商"/>
                          <asp:BoundField DataField="Remark" HeaderText="备注" />
                     
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
                        <asp:ImageButton ID="igbFirst" runat="server" CommandArgument="First" ImageUrl="~/images/page_first.gif" OnClick="CtrlPageInfo_Click" />
                        <asp:ImageButton ID="igbPrior" runat="server" CommandArgument="Prior" ImageUrl="~/images/page_prior.gif" OnClick="CtrlPageInfo_Click" />
                        </td>
                        <td>
                        <asp:Label ID="lblPageIndex" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        <asp:ImageButton ID="igbNext" runat="server" CommandArgument="Next" ImageUrl="~/images/page_next.gif" OnClick="CtrlPageInfo_Click" />
                        <asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif" OnClick="CtrlPageInfo_Click" />
                        </td>
                        <td>
                        <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                        </td>                                   
                        <td>
                        <asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif" OnClick="CtrlPageInfo_Click" />
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
                                    <td style="background-image: url(../images/bg_title.gif); height: 21px;">
                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                        操作</td>
                                </tr>
                  <tr><td style="height: 28px">
                    
                    <asp:ImageButton ID="btnInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" CausesValidation="False" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  /></td></tr>
                </table>
                <br />
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td style="background-image: url(../images/bg_title.gif); height: 17px;">　　编辑</td>
                      </tr>
                    </table> 
         <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
        <tr>
             <th align="right" class="label" style="width: 10%">
                <asp:Label ID="Label1" runat="server" Text="机器编号:" CssClass="txtlab"></asp:Label></th>
            <td style="width: 25%">
                <asp:TextBox ID="txtMachineCode" runat="server" CssClass="textboxodl" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvItem_Code" runat="server" ControlToValidate="txtMachineCode"
                    ErrorMessage="必填" Width="25px"></asp:RequiredFieldValidator></td>
            <th align="right" style="width: 10%">
                机器型号:</th>
            <td style="width: 20%">
                <asp:TextBox ID="txtMachineType" runat="server" CssClass="textbox"></asp:TextBox></td>
            <td align="center" colspan="2" rowspan="7">
                <asp:Image ID="Image1" runat="server" /></td>
        </tr>
        <tr>
            <th align="right" style="width: 10%">
                <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="设备编号:"></asp:Label></th>
            <td style="width: 25%">
                <asp:TextBox ID="txtMachineNumber" runat="server" CssClass="textbox" ></asp:TextBox><asp:TextBox ID="txtMaintainDate" runat="server" Height="1px" Visible="False" Width="1px" ></asp:TextBox></td>
            <th align="right" style="width: 10%">
                资产编号:</th>
            <td style="width: 25%">
                <asp:TextBox ID="txtMachineUpNo" runat="server" CssClass="textbox"></asp:TextBox><span
                    style="background-color: #ebeff0"></span></td>
        </tr>
                         <tr>
                             <th align="right" style="width: 10%">
                                 <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="功率:"></asp:Label></th>
                             <td style="width: 25%">
                <asp:TextBox ID="txtPower" runat="server" CssClass="textbox" ></asp:TextBox>
                                 Kw/h<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                     ControlToValidate="txtPower" Display="Static" ErrorMessage="有误"
                                     ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                             <th align="right" style="width: 10%">
                <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="机器轴数:"></asp:Label></th>
                             <td style="width: 20%">
                <asp:DropDownList ID="ddlMachineAxisNum" runat="server" CssClass="dropdownlist" Width="127px">
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                </asp:DropDownList></td>
                         </tr>
             <tr>
                 <th align="right" style="width: 10%">
                                 植毛行程:</th>
                 <td style="width: 25%">
                <asp:TextBox ID="txtMachineSpace" runat="server" CssClass="textbox"></asp:TextBox>
                     mm<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                     ControlToValidate="txtMachineSpace" Display="Static" ErrorMessage="有误"
                                     ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                 <th align="right" style="width: 10%">
                制造厂商:</th>
                 <td style="width: 20%">
                <asp:DropDownList ID="ddltxtManufacturers" runat="server" CssClass="textbox" Width="127px">
                    <asp:ListItem Value="德国">德国</asp:ListItem>
                    <asp:ListItem Value="意大利">意大利</asp:ListItem>
                </asp:DropDownList></td>
             </tr>
        <tr>
            <th align="right" style="width: 10%">
                制造日期:</th>
            <td style="width: 25%">
            <input id="txtMakeDate" runat="server" class="textbox" name="txtPublishDate" onfocus="setday(this)"
                    onkeypress="return false" onselectstart="return false;" readonly="readonly" type="text" /></td>
            <th align="right" style="width: 10%">
                     机器图片:</th>
            <td style="width: 20%">
               <asp:FileUpload ID="fudProcessPhoto" runat="server" CssClass="textbox" Width="188px" /></td>
        </tr>
             <tr>
                 <th align="right" style="width: 10%">
                <asp:Label ID="Label8" runat="server" ForeColor="Black" Text="适应刷类:"></asp:Label></th>
                 <td colspan="3" style="width: 25%">
                <asp:TextBox ID="txtSuitBrush" runat="server" CssClass="textbox" TextMode="MultiLine" Width="93%" Enabled="true"></asp:TextBox><a href="#" onclick="opens('txtSuitBrush')" style="color: #ff3333">选择</a></td>
             </tr>
             <tr>
                 <th align="right" style="width: 10%">
                <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="备注:"></asp:Label></th>
                 <td colspan="3" style="width: 25%">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
                    Width="93%"></asp:TextBox></td>
             </tr>
       </table>
         </asp:View>
         </asp:MultiView>
              </td>
          </tr>
        </table>
        <div id="login" class="login" >
       <table border="0.1px" width="100%" style="background-color: #f9f9f9">
           <tr  style="width: 100%; height: 24px;">  
           <td  colspan="2" align="center" >
               <span style="font-weight: bold; font-size: 20px; ">选择使用刷类</span></td>
               <td align="right" colspan="1" style="width: 5%;" valign="top">
                   <a href="#" onclick="closes();">×</a>
                   </td>                
               </tr>
           <tr>
               <td colspan="2" style="width: 45%; height: 224px;" align="center">
               <select id="Select1" name="Select1" multiple runat="server"  onclick="" size="20" style="width: 121px;height: 222px; border:1px;">
               <option value="马桶刷">马桶刷</option>
               <option value="碟刷">碟刷</option>
               <option value="扫把">扫把</option>
               <option value="扫连铲">扫连铲</option>
               <option value="地板刷">地板刷</option>
               <option value="平板刷">平板刷</option>
               <option value="指甲刷">指甲刷</option>
               <option value="绞丝刷">绞丝刷</option>
               <option value="工业扫把">工业扫把</option>
               <option value="长毛刷">长毛刷</option>
               <option value="双面碟刷">双面碟刷</option>
               <option value="其他">其他</option>
               </select></td>
               <td align="center" colspan="1" style="width: 5%; height: 224px;">
               </td>
           </tr>
           <tr>
               <td style="width: 50%" align="right">
                   <img src="../images/btn_yes.gif" onclick="ko('Select1')"/></td>
               <td style="width: 50%" align="left">
                   &nbsp;<img src="../images/btn_cancel.gif"onclick="closes();"  /></td>
               <td align="left" style="width: 5%">
               </td>
               </tr>
       </table>       
       
   <div id="panel">
   </div>
</div>
        </form>
</body>
</html>
