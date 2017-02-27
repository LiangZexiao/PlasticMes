<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataHistory.aspx.cs" Inherits="Collect_DataHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>数据返回(DataHistory)</title>
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
            <td style="height: 24px">当前位置:数据采集 -> 浏览数据</td>
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
                        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="删除" CausesValidation="false" Visible="False" OnClick="btnCancel_Click" /></fieldset>&nbsp; 
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
                         <asp:BoundField DataField="TotalNum" HeaderText="总啤数" />
                         <asp:BoundField DataField="GoodNum" HeaderText="良品数" />                         
                         <asp:BoundField DataField="BadNum" HeaderText="次品数" />
                         <asp:BoundField DataField="Cycletime" HeaderText="周期" />                         
                         <asp:BoundField DataField="LockMPA1" HeaderText="开关量5" Visible="False" />
                         <asp:BoundField DataField="LockMPA2" HeaderText="开关量6" Visible="False" />
                         <asp:BoundField DataField="Part1_ShotDisplacement" HeaderText="开关量7" Visible="False" />
                         <asp:BoundField DataField="Part1_ShotP1" HeaderText="开关量8" Visible="False" />                         
                         <asp:BoundField DataField="Part1_ShotP2" HeaderText="温度1" />
                         <asp:BoundField DataField="Part1_ShotTemp1" HeaderText="温度2" />
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
                                                    &nbsp;</td>
                                                <td>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblTotalNum" runat="server" Text="总啤数:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalNum" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>次</td>
                                                <td align="right">
                                                    <asp:Label ID="lblGoodNum" runat="server" Text="良品数:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtGoodNum" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                                <td align="right">
                                                    <asp:Label ID="lblBadNum" runat="server" Text="次品数:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtBadNum" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>个</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblCycletime" runat="server" Text="周期:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtCycletime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    &nbsp;<asp:Label ID="lblBeginTime" runat="server" Text="开始时间:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtBeginTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    <asp:Label ID="lblEndTime" runat="server" Text="结束时间:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    锁模压力1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLockMPA1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    锁模压力2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtLockMPA2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶1段位移:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotDisplacement" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶1段压力1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotP1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    射胶1段压力2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotP2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶1段温度1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotTemp1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶1段温度2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotTemp2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶1段温度3:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotTemp3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶1段时间:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart1_ShotTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    </td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶2段位移:</td>
                                                <td>
                                                   <asp:TextBox ID="txtPart2_ShotDisplacement" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶2段压力1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart2_ShotP1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    射胶2段压力2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart2_ShotP2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶2段温度1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart2_ShotTemp1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶2段温度2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart2_ShotTemp2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶2段温度3:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart2_ShotTemp3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶2段时间:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart2_ShotTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    </td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶3段位移:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotDisplacement" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶3段压力1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotP1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    射胶3段压力2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotP2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶3段温度1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotTemp1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶3段温度2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotTemp2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    射胶3段温度3:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotTemp3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    射胶3段时间:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPart3_ShotTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    </td>
                                                <td align="right">
                                                    </td>
                                                <td>
                                                    </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="right">
                                                    保压位移:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepDisplacement" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    保压压力1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepP1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                                <td align="right">
                                                    保压压力2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepP2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>bar</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    保压温度1:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepTemp1" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    保压温度2:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepTemp2" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                    保压温度3:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepTemp3" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    保压时间:</td>
                                                <td>
                                                    <asp:TextBox ID="txtKeepTime" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox></td>
                                                <td align="right">
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                </td>
                                                <td>
                                                </td>
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