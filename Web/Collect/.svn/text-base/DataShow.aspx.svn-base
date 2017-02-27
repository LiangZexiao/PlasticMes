<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataShow.aspx.cs" Inherits="Collect_DataShow" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>数据浏览(DataShow)</title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>  
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
               <td>
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:数据采集 -> 数据浏览</td>
          </tr>
          </table>
<br />
                <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                <fieldset><legend>操作</legend>
                <asp:DropDownList ID="ddlQuery" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuery_SelectedIndexChanged">
                            </asp:DropDownList>
                        <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
                        <input id="txtQUpLoadTime" runat="server" class="textbox" onfocus="setday(this)" onkeypress="return false"
                                onselectstart="return false;" />
                        <asp:Button ID="btnQuery" runat="server" CssClass="button"  Text="查询" OnClick="btnVisible_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="删除" CausesValidation="false" Visible="False" /></fieldset>&nbsp; 
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
               <tr>
               <td>
       <fieldset><legend>浏览</legend>
       <asp:GridView ID="GridView1" runat="server" CellPadding="0" ForeColor="#333333" Width="100%" AutoGenerateColumns="False"
        AllowPaging="True" PageSize="12" CssClass="gridview" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="GridView1_RowDataBound" >
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" Height="18px" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="False" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
         <Columns>
                          <asp:TemplateField Visible="False">
                             <ItemTemplate>
                             <asp:CheckBox ID="chkItemInner" runat="server" />
                             </ItemTemplate>
                             <HeaderTemplate>
                                 <input id="chkAll" type="checkbox" onclick="selectAll(this);"/>
                             </HeaderTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="26px" />
                             <HeaderStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                        <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号" >
                            <ItemStyle HorizontalAlign="Center" CssClass="hidden" />
                            <HeaderStyle CssClass="hidden" />
                            <FooterStyle CssClass="hidden" />
                        </asp:ButtonField>
                         <asp:ButtonField DataTextField="CollectorID" CommandName="select" HeaderText="采器编号" />
                         <asp:BoundField DataField="OrderID" HeaderText="订单号" Visible="False" />
                         <asp:BoundField DataField="ItemNo" HeaderText="产品编号" Visible="False" />
                         <asp:BoundField DataField="MachineNo" HeaderText="机器编号" />
                         <asp:BoundField DataField="MouldNo" HeaderText="模具编号" Visible="False" />                         
                         <asp:BoundField DataField="BeginTime"  DataFormatString="{0:d}"  HtmlEncode="False" HeaderText="开始时间" Visible="False" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                         <asp:BoundField DataField="EndTime"  DataFormatString="{0:d}"  HtmlEncode="False" HeaderText="结束时间" Visible="False" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                         <asp:BoundField DataField="Switch1" HeaderText="总啤数" />
                         <asp:BoundField DataField="Switch2" HeaderText="良品数" />                         
                         <asp:BoundField DataField="Switch3" HeaderText="次品数" />
                         <asp:BoundField DataField="Switch4" HeaderText="开关量4" />                         
                         <asp:BoundField DataField="Switch5" HeaderText="开关量5" Visible="False" />
                         <asp:BoundField DataField="Switch6" HeaderText="开关量6" Visible="False" />
                         <asp:BoundField DataField="Switch7" HeaderText="开关量7" Visible="False" />
                         <asp:BoundField DataField="Switch8" HeaderText="开关量8" Visible="False" />                         
                         <asp:BoundField DataField="Temp1" HeaderText="温度1" />
                         <asp:BoundField DataField="Temp2" HeaderText="温度2" />
                         <asp:BoundField DataField="Temp3" HeaderText="温度3" />
                         <asp:BoundField DataField="Temp4" HeaderText="温度4" Visible="False" />                             
                         <asp:BoundField DataField="Temp5" HeaderText="温度5" Visible="False" />
                         <asp:BoundField DataField="Temp6" HeaderText="温度6" Visible="False" />
                         <asp:BoundField DataField="Temp7" HeaderText="温度7" Visible="False" />
                         <asp:BoundField DataField="Temp8" HeaderText="温度8" Visible="False" />                         
                         
                         <asp:BoundField DataField="P1" HeaderText="压力1" Visible="False" />
                         <asp:BoundField DataField="P2" HeaderText="压力2" Visible="False" />
                         <asp:BoundField DataField="Displacement1" HeaderText="位移1" Visible="False" />
                         <asp:BoundField DataField="Displacement2" HeaderText="位移2" Visible="False" />
                         <asp:BoundField DataField="UpLoadTime" DataFormatString="{0:d}"  HtmlEncode="False" HeaderText="上传时间" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                     </Columns>
                     <PagerSettings Visible="False" /> 
    </asp:GridView>
    </fieldset>
                   <table border="0" cellpadding="0" cellspacing="0" class="table row" style="border-collapse: collapse"
                       width="100%">
                       <tr>
                           <td align="center">
                               &nbsp;<asp:Label ID="lblGridViewInfo" runat="server" Text=""></asp:Label>
                               <asp:LinkButton ID="lkbFirstPage" runat="server" CommandArgument="First" OnClick="CtrlPageInfo_Click">首页</asp:LinkButton>
                               <asp:LinkButton ID="lkbPriorPage" runat="server" CommandArgument="Prev" OnClick="CtrlPageInfo_Click">上一页</asp:LinkButton>
                               <asp:LinkButton ID="lkbNextPage" runat="server" CommandArgument="Next" OnClick="CtrlPageInfo_Click">下一页</asp:LinkButton>
                               <asp:LinkButton ID="lkbLastPage" runat="server" CommandArgument="Last" OnClick="CtrlPageInfo_Click">尾页</asp:LinkButton>
                               <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>&nbsp;
                               <asp:Button ID="btnSearch" runat="server" CssClass="button" OnClick="CtrlPageInfo_Click"
                                   Text="跳转" Width="40px" />
                               <asp:RegularExpressionValidator ID="revPageIndex" runat="server" ControlToValidate="txtPageIndex"
                                   ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator></td>
                       </tr>
                   </table>
               </td>
               </tr>
               </table></asp:View>
                            <asp:View ID="View2" runat="server">
                                <div id="Div_Master" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                    margin: 0px; overflow: auto; width: 100%; padding-top: 0px; height: 430px">
                                    <fieldset>
                                            <legend>操作</legend>
                                            <asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnVisible_Click"
                                                Text="返回" ValidationGroup="0" />
                                        <asp:TextBox ID="txtID" runat="server" Width="26px" Visible="False"></asp:TextBox>
                                        <input id="hdnID" runat="server" style="width: 26px" type="hidden" class="textbox" />
                                            <asp:Button ID="btnInsert" runat="server" CssClass="button" Enabled="False" 
                                                Text="提交" Visible="False" />
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="button" Enabled="False" 
                                                Text="保存" Visible="False" />
                                            <asp:Button ID="btnDelete" runat="server" CssClass="button" Enabled="False" 
                                                Text="删除" ValidationGroup="0" Visible="False" /></fieldset>
                                    <fieldset>                                        
                                        <br />
                                        <legend>浏览</legend>
                                        <table border="1" bordercolor="#e6e6e6" cellpadding="0" cellspacing="0" class="toptable row"
                                            style="border-collapse: collapse" width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblCollectorID" runat="server" Text="采器编号:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtCollectorID" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    <asp:Label ID="lblOrderID" runat="server" Text="生产单号:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOrderID" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    <asp:Label ID="lblItemNo" runat="server" Text="产品编号:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemNo" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                            </tr>

                                          <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblMachineNo" runat="server" Text="机器编号:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    <asp:Label ID="lblMouldNo" runat="server" Text="模具编号:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMouldNo" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                <td align="right">
                                                    <asp:Label ID="lblBeginTime" runat="server" Text="开始时间:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBeginTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblEndTime" runat="server" Text="结束时间:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch1" runat="server" Text="总啤数:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>次</td>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch2" runat="server" Text="良品数:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch3" runat="server" Text="次品数:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch4" runat="server" Text="开关量4:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch4" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch5" runat="server" Text="开关量5:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch5" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch6" runat="server" Text="开关量6:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch6" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch7" runat="server" Text="开关量7:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch7" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                                <td align="right">
                                                    <asp:Label ID="lblSwitch8" runat="server" Text="开关量8:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtSwitch8" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp1" runat="server" Text="温度1:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp2" runat="server" Text="温度2:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp3" runat="server" Text="温度3:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp4" runat="server" Text="温度4:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp4" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp5" runat="server" Text="温度5:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp5" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp6" runat="server" Text="温度6:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp6" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp7" runat="server" Text="温度7:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp7" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTemp8" runat="server" Text="温度8:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTemp8" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><span
                                                        style="font-size: 10.5pt; color: #000000; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">℃</span></td>
                                                <td align="right">
                                                    射胶一段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtShotPress1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶二段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtShotPress2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    射胶三段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtShotPress3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    射胶四段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtShotPress4" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    保压一段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepPress1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    保压二段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepPress2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    保压三段压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepPress3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    快速锁模压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtFastLockMouldPress" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    低压力锁模压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLowPressLockMouldPress" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    高压锁模压力:</td>
                                                <td>
                                                    <asp:TextBox ID="txtHighPressLockMouldPress" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                <asp:Label ID="lblP1" runat="server" Text="压力1:"></asp:Label></td>
                                                <td>
                                                <asp:TextBox ID="txtP1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    <asp:Label ID="lblP2" runat="server" Text="压力2:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtP2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDisplacement1" runat="server" Text="位移1:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtDisplacement1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>毫米</td>
                                                <td align="right">
                                                    <asp:Label ID="lblDisplacement2" runat="server" Text="位移2:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtDisplacement2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>毫米</td>
                                                <td align="right">
                                                    <asp:Label ID="lblUpLoadTime" runat="server" Text="上传时间:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtUpLoadTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>                                            
                                        </table>
                                        </fieldset>
                                </div>
                            </asp:View>                  
                 </asp:MultiView>                
           </td>       
        </tr> 
        </table>
    </form>
</body>
</html>