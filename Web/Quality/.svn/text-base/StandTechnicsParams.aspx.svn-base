<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StandTechnicsParams.aspx.cs" Inherits="Quality_StandTechnicsParams" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>工艺参数(StandTechnicsParams)</title>
    <link href="../images/css.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../JS/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JS/CheckBox.js"></script>
    <script type="text/javascript" language="javascript" >
    function dowork()
    {
      document.getElementById("txtflags").innerText="true";
    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top">
          
          <table class="tablefoot" cellspacing="0" cellpadding="0" border="0" style="height: 24px">
          <tr>
            <td style="height: 24px">当前位置:品质管理 -> 工艺参数</td>
          </tr>
          </table>
          <br />
                <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            
                <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                  <tr>
                    <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
                  </tr>
                  <tr>
                    <td>
                                    <asp:DropDownList ID="ddlQuery" runat="server">
                                    <asp:ListItem Value="FileNo">文件编号</asp:ListItem>
                                    <asp:ListItem Value="MachineNo">注塑机编号</asp:ListItem>
                                    <asp:ListItem Value="MouldNo">模具编号</asp:ListItem>
                                    <asp:ListItem Value="ProductNo">产品编号</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtQuery" runat="server" CssClass="textbox"></asp:TextBox>
<asp:ImageButton ID="igbQuery" runat="server" ImageUrl="~/images/btn_search.gif"  OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbNewadd" runat="server" ImageUrl="~/images/btn_newadd.gif" OnClick="btnVisible_Click" ImageAlign="Top" />
<asp:ImageButton ID="igbCancel" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" ImageAlign="Top" /></td>
                  </tr>
              </table>
              <br>
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                    <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　浏览</td>
                      </tr>
                    </table>              
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True" PageSize="12" OnRowDataBound="GridView1_RowDataBound" CssClass="itemtable" BorderWidth="0px" CellSpacing="1" >
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
                        <ItemStyle HorizontalAlign="Center"  Width="2%"/>
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:ButtonField DataTextField="ID" CommandName="select" HeaderText="序号" >
                        <ItemStyle HorizontalAlign="Center" CssClass="hidden" />    
                        <HeaderStyle CssClass="hidden" />
                        <FooterStyle CssClass="hidden" />
                        </asp:ButtonField>
                         <asp:ButtonField DataTextField="FileNo" CommandName="select" HeaderText="文件编号" />
                         <asp:BoundField DataField="ProductNo" HeaderText="产品编号" />
                         <asp:BoundField DataField="MachineNo" HeaderText="注塑机编号" />
                         <asp:BoundField DataField="MouldNo" HeaderText="模具编号" />
                         <asp:BoundField DataField="Version" HeaderText="版本" />
                         <asp:BoundField DataField="Engineer" HeaderText="调模人" />
                         <asp:BoundField DataField="AdjustDate" HeaderText="调模日期" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                         <asp:BoundField DataField="RegrindRate" HeaderText="水口比例" Visible="False" />
                         <asp:BoundField DataField="Season" HeaderText="季节" Visible="False" />
                         <asp:BoundField DataField="SetShotMouthTemp" HeaderText="射咀温度" Visible="False" />
                         <asp:BoundField DataField="ShotMouthTemp1" HeaderText="温度一"  Visible="False"/>
                         <asp:BoundField DataField="ShotMouthTemp2" HeaderText="温度二"  Visible="False"/>
                         <asp:BoundField DataField="ShotMouthTemp3" HeaderText="温度三"  Visible="False"/>
                         <asp:BoundField DataField="MaterialPipeTemp" HeaderText="料温"  Visible="False"/>
                         <asp:BoundField DataField="GlueMeltTime" HeaderText="熔胶时间"  Visible="False"/>
                         <asp:BoundField DataField="ScrewTurnSpeed" HeaderText="螺杆转速"  Visible="False"/>
                         <asp:BoundField DataField="FillingTime" HeaderText="充填时间"  Visible="False"/>
                         <asp:BoundField DataField="PeriodTime" HeaderText="周期时间"  Visible="False"/>
                         <asp:BoundField DataField="ShotGlueDelay" HeaderText="射胶延时"  Visible="False"/>
                         <asp:BoundField DataField="ShotGluePoint" HeaderText="射胶终点"  Visible="False"/>
                         
                         <asp:BoundField DataField="ThimbleNum" HeaderText="顶针次数"  Visible="False"/>
                         <asp:BoundField DataField="MouldCloseNum" HeaderText="合模时间"  Visible="False"/>
                         <asp:BoundField DataField="CoolingTime" HeaderText="冷却时间"  Visible="False"/>
                         <asp:BoundField DataField="FillingLimit" HeaderText="填充时限"  Visible="False"/>
                         <asp:BoundField DataField="GlueMeltTimeLimit" HeaderText="熔胶时限"  Visible="False"/>
                         <asp:BoundField DataField="GlueMeltDelay" HeaderText="熔胶延时"  Visible="False"/>
                         <asp:BoundField DataField="BeforeMeltSpeed" HeaderText="熔前抽胶_速度"  Visible="False"/>
                         <asp:BoundField DataField="BeforeMeltPress" HeaderText="熔前抽胶_压力"  Visible="False" />
                         <asp:BoundField DataField="MeltSpeed1" HeaderText="熔胶一段_速度"  Visible="False" />
                         <asp:BoundField DataField="MeltPress1" HeaderText="熔胶一段_压力"  Visible="False" />

                         <asp:BoundField DataField="MeltPosition1" HeaderText="熔胶一段_位置"  Visible="False" />
                         <asp:BoundField DataField="MeltSpeed2" HeaderText="熔胶二段_速度"  Visible="False" />
                         <asp:BoundField DataField="MeltPress2" HeaderText="熔胶二段_压力"  Visible="False" />
                         <asp:BoundField DataField="MeltPosition2" HeaderText="熔胶二段_位置"  Visible="False" />
                         <asp:BoundField DataField="AtferMeltSpeed" HeaderText="熔后抽胶_速度"  Visible="False" />
                         <asp:BoundField DataField="AfterMeltPress" HeaderText="熔后抽胶_压力"  Visible="False" />
                         <asp:BoundField DataField="AfterMeltPosition" HeaderText="熔后抽胶_位置"  Visible="False" />
                         <asp:BoundField DataField="MeltBackPress" HeaderText="熔胶背压"  Visible="False" />
                         <asp:BoundField DataField="ShotBaseFastSpeed1" HeaderText="射胶一段_速度"  Visible="False" />
                         <asp:BoundField DataField="ShotPosition1" HeaderText="射胶一段_位置"  Visible="False" />
                         
                         <asp:BoundField DataField="ShotPress1" HeaderText="射胶一段_压力"  Visible="False" />
                         <asp:BoundField DataField="ShotBaseFastSpeed2" HeaderText="射胶二段_速度"  Visible="False" />
                         <asp:BoundField DataField="ShotPress2" HeaderText="射胶二段_压力"  Visible="False" />
                         <asp:BoundField DataField="ShotPosition2" HeaderText="射胶二段_位置"  Visible="False" />
                         <asp:BoundField DataField="ShotBaseFastSpeed3" HeaderText="射胶三段_速度"  Visible="False" />
                         <asp:BoundField DataField="ShotPress3" HeaderText="射胶三段_压力"  Visible="False" />
                         <asp:BoundField DataField="ShotPosition3" HeaderText="射胶三段_位置"  Visible="False" />
                         <asp:BoundField DataField="ShotBaseFastSpeed4" HeaderText="射胶四段_速度"  Visible="False" />
                         <asp:BoundField DataField="ShotPress4" HeaderText="射胶四段_压力"  Visible="False" />
                         <asp:BoundField DataField="ShotPosition4" HeaderText="射胶四段_位置"  Visible="False" />
                         
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
<asp:ImageButton ID="igbNext" runat="server"  CommandArgument="Next" ImageUrl="~/images/page_next.gif" OnClick="CtrlPageInfo_Click" />
<asp:ImageButton ID="igbLast" runat="server" CommandArgument="Last" ImageUrl="~/images/page_last.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPageIndex" runat="server" CssClass="textbox_search" Width="45px"></asp:TextBox>
                                </td>
                                <td>
<asp:ImageButton ID="igbSearch" runat="server" CommandArgument="Last" ImageUrl="~/images/mirror.gif" OnClick="CtrlPageInfo_Click" />
                                </td>
                                <td>
<asp:RegularExpressionValidator ID="revPageIndex"  runat="server" ControlToValidate="txtPageIndex" ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
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
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　操作</td>
                      </tr>
                      <tr>
                      <td>
                        <asp:ImageButton ID="igbInsert" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" />
                      <asp:ImageButton ID="igbUpdate" runat="server" ImageUrl="~/images/btn_save.gif" OnClick="btnUpdate_Click" BorderWidth="0px" />
                        <asp:ImageButton ID="igbDelete" runat="server" ImageUrl="~/images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="false" />
                        <asp:ImageButton ID="igbBacked" runat="server" ImageUrl="~/images/btn_back.gif" OnClick="btnVisible_Click" CausesValidation="false"  />
                        <input id="hdnID" type="hidden" runat="server" style="width: 20px" class="textbox" />&nbsp;
                        <asp:TextBox ID="txtID" runat="server" Visible="False" CssClass="textbox" Width="20px"></asp:TextBox>
                          <br />
                      </td>
                      </tr>
                    </table>
                <br>
                 <table class="itemtable" cellspacing="1" cellpadding="2" border="0">
                      <tr>
                        <td height="22" style="background-image: url(../images/bg_title.gif)">　　编辑</td>
                      </tr>
                    </table>
                    <table border="0" style="border-collapse: collapse;" width="100%" cellpadding="1" cellspacing="1" class="texttable">
              <tr>
                  <th align="right">
                <asp:Label ID="lblFileNo" runat="server" Text="文件编号:" CssClass="txtlab"></asp:Label></th>
                  <td>
            <asp:TextBox ID="txtFileNo" runat="server" CssClass="textboxodl"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvFileNo" runat="server" ErrorMessage="必填" ControlToValidate="txtFileNo"></asp:RequiredFieldValidator></td>
                  <th align="right">
                      <asp:Label ID="lblMachineNo" runat="server" Text="注塑机编号:" CssClass="lable"></asp:Label></th>
                  <td>
                      <asp:DropDownList ID="ddlMachineNo" runat="server" CssClass="dropdownlist">
                      </asp:DropDownList></td>
                  <th align="right">
                <asp:Label ID="lblMouldNo" runat="server" Text="模具编号:"></asp:Label></th>
                  <td>
                      <asp:DropDownList ID="ddlMouldNo" runat="server" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
                      </asp:DropDownList></td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblProductNo" runat="server" Text="产品编号:"></asp:Label></th>
            <td>
                <asp:DropDownList ID="ddlProductNo" runat="server" CssClass="dropdownlist">
                </asp:DropDownList></td>
            <th align="right">
                <asp:Label ID="lblRegrindRate" runat="server" Text="水口比例:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtRegrindRate" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revItem_WaterGapScale" runat="server" ControlToValidate="txtRegrindRate"
                    Display="Static" ErrorMessage="小数" ValidationExpression="^0\.\d*[1-9]\d*$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblGoodSocketNum" runat="server" Text="可用模穴数:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtGoodSocketNum" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>PCS</td>
        </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblSeason" runat="server" Text="季节:"></asp:Label></th>
                  <td>
                <asp:DropDownList ID="ddlSeason" runat="server" CssClass="dropdownlist">
                <asp:ListItem Value="春">春</asp:ListItem>
                <asp:ListItem Value="夏季">夏季</asp:ListItem>
                <asp:ListItem Value="秋">秋</asp:ListItem>
                <asp:ListItem Value="冬季">冬季</asp:ListItem>
                </asp:DropDownList></td>
                  <th align="right">
                      <asp:Label ID="lblGrossWeight" runat="server" Text="啤重:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="textbox"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="revGrossWeight" runat="server" ControlToValidate="txtGrossWeight"
                          Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                  <th align="right">
                      <asp:Label ID="lblMaterialNo" runat="server" Text="使用原料:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtMaterialNo" runat="server" CssClass="textbox"></asp:TextBox></td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblVersion" runat="server" Text="版本:"></asp:Label>
                    </th>
            <td>
                    <asp:TextBox ID="txtVersion" runat="server" CssClass="textbox"></asp:TextBox></td>
            <th align="right">
                <asp:Label ID="lblEngineer" runat="server" Text="调模人:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtEngineer" runat="server" CssClass="textbox" ></asp:TextBox></td>
            <th align="right">
                <asp:Label ID="lblAdjustDate" runat="server" Text="调模日期:"></asp:Label>
                </th>
            <td>
                <input id="txtAdjustDate" runat="server" class="textbox" name="txtAdjustDate" onfocus="setday(this)"
                        onkeypress="return false" onselectstart="return false;" readonly="readonly" type="text" />
                </td>
        </tr>
              <tr>
                  <td align="right">
                  </td>
                  <td>
                      &nbsp;
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
            <th align="right">
                <asp:Label ID="lblSetShotMouthTemp" runat="server" Text="射咀温度:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtSetShotMouthTemp" runat="server" CssClass="textbox" ></asp:TextBox>'C
                <asp:RegularExpressionValidator ID="revSetShotMouthTemp" runat="server" ControlToValidate="txtSetShotMouthTemp"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            <th align="right">
                <asp:Label ID="lblMaterialPipeTemp" runat="server" Text="料温:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtMaterialPipeTemp" runat="server" CssClass="textbox" ></asp:TextBox>'C
                <asp:RegularExpressionValidator ID="revMaterialPipeTemp" runat="server" ControlToValidate="txtMaterialPipeTemp"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblShotMouthTemp1" runat="server" Text="温度一:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotMouthTemp1" runat="server" CssClass="textbox"></asp:TextBox>'C
                <asp:RegularExpressionValidator ID="revShotMouthTemp1" runat="server" ControlToValidate="txtShotMouthTemp1"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
                  <th align="right">
                <asp:Label ID="lblShotMouthTemp2" runat="server" Text="温度二:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotMouthTemp2" runat="server" CssClass="textbox" ></asp:TextBox>'C
                <asp:RegularExpressionValidator ID="revShotMouthTemp2" runat="server" ControlToValidate="txtShotMouthTemp2"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblShotMouthTemp3" runat="server" Text="温度三:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotMouthTemp3" runat="server" CssClass="textbox"></asp:TextBox>'C
                <asp:RegularExpressionValidator ID="revShotMouthTemp3" runat="server" ControlToValidate="txtShotMouthTemp3"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
              </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td>
                </td>
            <td align="right">
                </td>
            <td>
                </td>
        </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblGlueMeltTime" runat="server" Text="熔胶时间:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtGlueMeltTime" runat="server" CssClass="textbox"></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revGlueMeltTime" runat="server" ControlToValidate="txtGlueMeltTime"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
                  <th align="right">
                <asp:Label ID="lblShotGluePoint" runat="server" Text="射胶终点:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotGluePoint" runat="server" CssClass="textbox" ></asp:TextBox>mm
                <asp:RegularExpressionValidator ID="revShotGluePoint" runat="server" ControlToValidate="txtShotGluePoint"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblGlueMeltTimeLimit" runat="server" Text="熔胶时限:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtGlueMeltTimeLimit" runat="server" CssClass="textbox" ></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revGlueMeltTimeLimit" runat="server" ControlToValidate="txtGlueMeltTimeLimit"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
              </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblScrewTurnSpeed" runat="server" Text="螺杆转速:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtScrewTurnSpeed" runat="server" CssClass="textbox" ></asp:TextBox>RPM
                <asp:RegularExpressionValidator ID="revScrewTurnSpeed" runat="server" ControlToValidate="txtScrewTurnSpeed"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblThimbleNum" runat="server" Text="顶针次数:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtThimbleNum" runat="server" CssClass="textbox"></asp:TextBox>次
                <asp:RegularExpressionValidator ID="revThimbleNum" runat="server" ControlToValidate="txtThimbleNum"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
                  <th align="right">
                <asp:Label ID="lblGlueMeltDelay" runat="server" Text="熔胶延时:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtGlueMeltDelay" runat="server" CssClass="textbox" ></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revGlueMeltDelay" runat="server"
                    ControlToValidate="txtGlueMeltDelay" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblFillingTime" runat="server" Text="充填时间:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtFillingTime" runat="server" CssClass="textbox"></asp:TextBox>s
                 <asp:RegularExpressionValidator ID="revFillingTime" runat="server" ControlToValidate="txtFillingTime"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            <th align="right">
                <asp:Label ID="lblMouldCloseNum" runat="server" Text="合模时间:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtMouldCloseNum" runat="server" CssClass="textbox" ></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revMouldCloseNum" runat="server" ControlToValidate="txtMouldCloseNum"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <td align="right">
                </td>
            <td>
                </td>
        </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblPeriodTime" runat="server" Text="周期时间:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtPeriodTime" runat="server" CssClass="textbox" ></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revPeriodTime" runat="server" ControlToValidate="txtPeriodTime"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblCoolingTime" runat="server" Text="冷却时间:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtCoolingTime" runat="server" CssClass="textbox"></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revCoolingTime" runat="server" ControlToValidate="txtCoolingTime"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
                  <td align="right">
                  </td>
                  <td>
                  </td>
              </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblShotGlueDelay" runat="server" Text="射胶延时:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotGlueDelay" runat="server" CssClass="textbox"></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revShotGlueDelay" runat="server" ControlToValidate="txtShotGlueDelay"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
                  <th align="right">
            <asp:Label ID="lblFillingLimit" runat="server" Text="填充时限:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtFillingLimit" runat="server" CssClass="textbox" ></asp:TextBox>s
                      <asp:RegularExpressionValidator ID="revFillingLimit" runat="server" ControlToValidate="txtFillingLimit"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                      </td>
                  <td align="right">
                  </td>
                  <td>
                  </td>
              </tr>
              <tr>
                  <td align="right">
                </td>
                  <td align="center">
                      速度</td>
                  <td align="right">
                </td>
                  <td align="center">
                      压力</td>
                  <td align="right">
            </td>
                  <td align="center">
                      位置</td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblBeforeMeltSpeed" runat="server" Text="熔前抽胶_速度:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtBeforeMeltSpeed" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revBeforeMeltSpeed" runat="server" ControlToValidate="txtBeforeMeltSpeed"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                    <asp:Label ID="lblBeforeMeltPress" runat="server" Text="熔前抽胶_压力:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtBeforeMeltPress" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revBeforeMeltPress" runat="server"
                    ControlToValidate="txtBeforeMeltPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
           
            <th align="right">
                    <asp:Label ID="lblBeforeMeltTime" runat="server" Text="熔前抽胶_时间:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtBeforeMeltTime" runat="server" CssClass="textbox" ></asp:TextBox>s
                    <asp:RegularExpressionValidator ID="revBeforeMeltTime" runat="server"
                    ControlToValidate="txtBeforeMeltTime" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
             </tr>                                                                                
              <tr>
                  <th align="right">
                <asp:Label ID="lblMeltSpeed1" runat="server" Text="熔胶一段_速度:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtMeltSpeed1" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revMeltSpeed1" runat="server" ControlToValidate="txtMeltSpeed1"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                    <asp:Label ID="lblMeltPress1" runat="server" Text="熔胶一段_压力:"></asp:Label></th>
                  <td>
                    <asp:TextBox ID="txtMeltPress1" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revMeltPress1" runat="server" ControlToValidate="txtMeltPress1"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                    <asp:Label ID="lblMeltPosition1" runat="server" Text="熔胶一段_位置:"></asp:Label></th>
                  <td>
                    <asp:TextBox ID="txtMeltPosition1" runat="server" CssClass="textbox"></asp:TextBox>mm
                    <asp:RegularExpressionValidator ID="revMeltPosition1" runat="server"
                    ControlToValidate="txtMeltPosition1" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
              </tr>
        <tr>
                <th align="right">
                    <asp:Label ID="lblMeltSpeed2" runat="server" Text="熔胶二段_速度:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtMeltSpeed2" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revMeltSpeed2" runat="server"
                    ControlToValidate="txtMeltSpeed2" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                   <asp:Label ID="lblMeltPress2" runat="server" Text="熔胶二段_压力:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtMeltPress2" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revMeltPress2" runat="server"
                    ControlToValidate="txtMeltPress2" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblMeltPosition2" runat="server" Text="熔胶二段_位置:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtMeltPosition2" runat="server" CssClass="textbox" ></asp:TextBox>mm
                    <asp:RegularExpressionValidator ID="revMeltPosition2" runat="server"
                        ControlToValidate="txtMeltPosition2" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <th align="right">
                <asp:Label ID="lblMeltSpeed3" runat="server" Text="熔后抽胶_速度:"></asp:Label></th>
                <td>
                  <asp:TextBox ID="txtMeltSpeed3" runat="server" CssClass="textbox"></asp:TextBox>%
                  <asp:RegularExpressionValidator ID="revMeltSpeed3" runat="server"
                        ControlToValidate="txtMeltSpeed3" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                  </td>
                <th align="right">
                <asp:Label ID="lblAfterMeltPress" runat="server" Text="熔后抽胶_压力:"></asp:Label></th>
                <td>
                <asp:TextBox ID="txtAfterMeltPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revAfterMeltPress" runat="server"
                        ControlToValidate="txtAfterMeltPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                <th align="right">
                <asp:Label ID="lblAfterMeltPosition" runat="server" Text="熔后抽胶_位置:"></asp:Label></th>
                <td>
                <asp:TextBox ID="txtAfterMeltPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                <asp:RegularExpressionValidator ID="revAfterMeltPosition" runat="server"
                        ControlToValidate="txtAfterMeltPosition" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            </tr>
            
            <tr>
            <td align="right">
                &nbsp;</td>
                <td>
                    &nbsp;</td>
            <th align="right">
                <asp:Label ID="lblMeltBackPress" runat="server" Text="熔胶背压:"></asp:Label>
                </th>
                <td>
                <asp:TextBox ID="txtMeltBackPress" runat="server" CssClass="textbox"></asp:TextBox>%
                 <asp:RegularExpressionValidator ID="revMeltBackPress" runat="server"
                        ControlToValidate="txtMeltBackPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            <td align="right">
                &nbsp;</td>
                <td>
                    &nbsp;</td>
        </tr>
              <tr>
                  <th align="right">
            <asp:Label ID="lblShotBaseFastSpeed1" runat="server" Text="射胶一段_速度:"></asp:Label></th>
                  <td>
            <asp:TextBox ID="txtShotBaseFastSpeed1" runat="server" CssClass="textbox" ></asp:TextBox>%
            <asp:RegularExpressionValidator ID="revShotBaseFastSpeed1" runat="server"
                        ControlToValidate="txtShotBaseFastSpeed1" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblShotPress1" runat="server" Text="射胶一段_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotPress1" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revShotPress1" runat="server"
                    ControlToValidate="txtShotPress1" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblShotPosition1" runat="server" Text="射胶一段_位置:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotPosition1" runat="server" CssClass="textbox"></asp:TextBox>mm
                <asp:RegularExpressionValidator ID="revShotPosition1" runat="server"
                    ControlToValidate="txtShotPosition1" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblShotBaseFastSpeed2" runat="server" Text="射胶二段_速度:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtShotBaseFastSpeed2" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revShotBaseFastSpeed2" runat="server"
                    ControlToValidate="txtShotBaseFastSpeed2" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                    <asp:Label ID="lblShotPress2" runat="server" Text="射胶二段_压力:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtShotPress2" runat="server" CssClass="textbox" ></asp:TextBox>%
                 <asp:RegularExpressionValidator
                        ID="revShotPress2" runat="server" ControlToValidate="txtShotPress2"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblShotPosition2" runat="server" Text="射胶二段_位置:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtShotPosition2" runat="server" CssClass="textbox"></asp:TextBox>mm
                <asp:RegularExpressionValidator
                        ID="revShotPosition2" runat="server" ControlToValidate="txtShotPosition2"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                </td>
        </tr>                                                                                
        <tr>
            <th align="right" >
                    <asp:Label ID="lblShotBaseFastSpeed3" runat="server" Text="射胶三段_速度:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtShotBaseFastSpeed3" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator
                        ID="revShotBaseFastSpeed3" runat="server" ControlToValidate="txtShotBaseFastSpeed3"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                    <asp:Label ID="lblShotPress3" runat="server" Text="射胶三段_压力:"></asp:Label></th>
            <td >
                    <asp:TextBox ID="txtShotPress3" runat="server" CssClass="textbox"></asp:TextBox>%
                    <asp:RegularExpressionValidator
                        ID="revShotPress3" runat="server" ControlToValidate="txtShotPress3"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th  align="right">
                    <asp:Label ID="lblShotPosition3" runat="server" Text="射胶三段_位置:"></asp:Label></th>
            <td >
                    <asp:TextBox ID="txtShotPosition3" runat="server" CssClass="textbox"></asp:TextBox>mm
                    
                    <asp:RegularExpressionValidator
                        ID="revShotPosition3" runat="server" ControlToValidate="txtShotPosition3"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                    </td>
        </tr>
        <tr>
                <th align="right">
                <asp:Label ID="lblShotBaseFastSpeed4" runat="server" Text="射胶四段_速度:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtShotBaseFastSpeed4" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator
                        ID="revShotBaseFastSpeed4" runat="server" ControlToValidate="txtShotBaseFastSpeed4"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblShotPress4" runat="server" Text="射胶四段_压力:"></asp:Label></th>
            <td>                 
                    <asp:TextBox ID="txtShotPress4" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator
                        ID="revShotPress4" runat="server" ControlToValidate="txtShotPress4"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                    <asp:Label ID="lblShotPosition4" runat="server" Text="射胶四段_位置:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtShotPosition4" runat="server" CssClass="textbox" ></asp:TextBox>mm
                    <asp:RegularExpressionValidator
                        ID="revShotPosition4" runat="server" ControlToValidate="txtShotPosition4"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                    </td>
            </tr>
            <tr>
                <th align="right">
                <asp:Label ID="lblKeepPressSpeed1" runat="server" Text="保压一段_速度:"></asp:Label></th>
                <td>
            <asp:TextBox ID="txtKeepPressSpeed1" runat="server" CssClass="textbox"></asp:TextBox>%
            <asp:RegularExpressionValidator
                ID="revKeepPressSpeed1" runat="server" ControlToValidate="txtKeepPressSpeed1"
                Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                <th align="right">
                      <asp:Label ID="lblKeepPress1" runat="server" Text="保压一段_压力:"></asp:Label></th>
                <td>
                      <asp:TextBox ID="txtKeepPress1" runat="server" CssClass="textbox"></asp:TextBox>%
                      <asp:RegularExpressionValidator
                          ID="revKeepPress1" runat="server" ControlToValidate="txtKeepPress1"
                          Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                <th align="right">
                <asp:Label ID="lblKeepPressPosition1" runat="server" Text="保压一段_时间:"></asp:Label></th>
                <td>
                      <asp:TextBox ID="txtKeepPressPosition1" runat="server" CssClass="textbox" ></asp:TextBox>s
                      <asp:RegularExpressionValidator
                          ID="revKeepPressPosition1" runat="server" ControlToValidate="txtKeepPressPosition1"
                          Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                      </td>
            </tr>            
              <tr>
                  <td align="right">
                      </td>
                  <td>
                      </td>
                  <th align="right">
                <asp:Label ID="lblKeepPress2" runat="server" Text="保压二段_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtKeepPress2" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revKeepPress2" runat="server" ControlToValidate="txtKeepPress2"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblKeepPressPosition2" runat="server" Text="保压二段_时间:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtKeepPressPosition2" runat="server" CssClass="textbox" ></asp:TextBox>s
                <asp:RegularExpressionValidator
                    ID="trevKeepPressPosition2" runat="server" ControlToValidate="txtKeepPressPosition2"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                </td>
              </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                </td>
            <th align="right">
                <asp:Label ID="lblKeepPress3" runat="server" Text="保压三段_压力:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtKeepPress3" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revKeepPress3" runat="server" ControlToValidate="txtKeepPress3"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblKeepPressPosition3" runat="server" Text="保压三段_时间:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtKeepPressPosition3" runat="server" CssClass="textbox" ></asp:TextBox>s
                <asp:RegularExpressionValidator ID="revKeepPressPosition3" runat="server" ControlToValidate="txtKeepPressPosition3"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
        </tr>
              <tr>
                  <td align="right">
                  </td>
                  <td>
                      &nbsp;</td>
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
            <th align="right">
                <asp:Label ID="lblShotBaseFastSpeed" runat="server" Text="射台快进_速度:"></asp:Label>
                    </th>
            <td>
                    <asp:TextBox ID="txtShotBaseFastSpeed" runat="server" CssClass="textbox"></asp:TextBox>%
                    
                    <asp:RegularExpressionValidator
                        ID="revShotBaseFastSpeed" runat="server" ControlToValidate="txtShotBaseFastSpeed"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblShotBaseFastPress" runat="server" Text="射台快进_压力:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtShotBaseFastPress" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revShotBaseFastPress" runat="server" ControlToValidate="txtShotBaseFastPress"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblShotBaseFastTime" runat="server" Text="射台快进_时间:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtShotBaseFastTime" runat="server" CssClass="textbox"></asp:TextBox>s
                <asp:RegularExpressionValidator
                    ID="revShotBaseFastTime" runat="server" ControlToValidate="txtShotBaseFastTime"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblShotBaseSlowSpeed" runat="server" Text="射台慢进_速度:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtShotBaseSlowSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revShotBaseSlowSpeed" runat="server" ControlToValidate="txtShotBaseSlowSpeed"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblShotBaseSlowPress" runat="server" Text="射台慢进_压力:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtShotBaseSlowPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revShotBaseSlowPress" runat="server" ControlToValidate="txtShotBaseSlowPress"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtflags" runat="server" Width="59px" style="DISPLAY:none;"></asp:TextBox></td>
        </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblShotBackSpeed" runat="server" Text="射台后退_速度:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotBackSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revShotBackSpeed" runat="server" ControlToValidate="txtShotBackSpeed"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblShotBackPress" runat="server" Text="射台后退_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtShotBackPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revShotBackPress" runat="server" ControlToValidate="txtShotBackPress"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                  <td align="right">
                  </td>
                  <td>
                  </td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblShotBackTemp" runat="server" Text="调模设定_温度:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtShotBackTemp" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revShotBackTemp" runat="server" ControlToValidate="txtShotBackTemp"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblAdjustMouldPress" runat="server" Text="调模设定_压力:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtAdjustMouldPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revAdjustMouldPress" runat="server" ControlToValidate="txtAdjustMouldPress"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <td align="right">
                </td>
            <td>
                </td>
        </tr>
              <tr>
                  <td align="right">
                  </td>
                  <td>
                      &nbsp;</td>
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
                  <th align="right">
                <asp:Label ID="lblFastLockMouldSpeed" runat="server" Text="快速锁模_速度:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtFastLockMouldSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revFastLockMouldSpeed" runat="server" ControlToValidate="txtFastLockMouldSpeed"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblFastLockMouldPress" runat="server" Text="快速锁模_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtFastLockMouldPress" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revFastLockMouldPress" runat="server" ControlToValidate="txtFastLockMouldPress"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblFastLockMouldPosition" runat="server" Text="快速锁模_位置:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtFastLockMouldPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                <asp:RegularExpressionValidator ID="revFastLockMouldPosition" runat="server" ControlToValidate="txtFastLockMouldPosition"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblLowPressLockMouldSpeed" runat="server" Text="低压锁模_速度:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtLowPressLockMouldSpeed" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revLowPressLockMouldSpeed" runat="server" ControlToValidate="txtLowPressLockMouldSpeed"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblLowPressLockMouldPress" runat="server" Text="低压锁模_压力:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtLowPressLockMouldPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revLowPressLockMouldPress" runat="server" ControlToValidate="txtLowPressLockMouldPress"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblLowPressLockMouldPosition" runat="server" Text="低压锁模_位置:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtLowPressLockMouldPosition" runat="server" CssClass="textbox"></asp:TextBox>mm
                <asp:RegularExpressionValidator
                    ID="revLowPressLockMouldPosition" runat="server" ControlToValidate="txtLowPressLockMouldPosition"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
        </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblHighPressLockMouldSpeed" runat="server" Text="高压锁模_速度:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtHighPressLockMouldSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revHighPressLockMouldSpeed" runat="server" ControlToValidate="txtHighPressLockMouldSpeed"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblHighPressLockMouldPress" runat="server" Text="高压锁模_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtHighPressLockMouldPress" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revHighPressLockMouldPress" runat="server" ControlToValidate="txtHighPressLockMouldPress"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
            <asp:Label ID="lblHighPressLockMouldPosition" runat="server" Text="高压锁模_位置:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtHighPressLockMouldPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                 <asp:RegularExpressionValidator ID="revHighPressLockMouldPosition" runat="server" ControlToValidate="txtHighPressLockMouldPosition"
                          Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                          
              </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblLowSpeedOpenMouldSpeed" runat="server" Text="慢速开模_速度:"></asp:Label>
                </th>
            <td>
                <asp:TextBox ID="txtLowSpeedOpenMouldSpeed" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator
                    ID="revLowSpeedOpenMouldSpeed" runat="server" ControlToValidate="txtLowSpeedOpenMouldSpeed"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblLowSpeedOpenMouldPress" runat="server" Text="慢速开模_压力:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtLowSpeedOpenMouldPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revLowSpeedOpenMouldPress" runat="server" ControlToValidate="txtLowSpeedOpenMouldPress"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblLowSpeedOpenMouldPosition" runat="server" Text="慢速开模_位置:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtLowSpeedOpenMouldPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                <asp:RegularExpressionValidator ID="revLowSpeedOpenMouldPosition" runat="server"
                    ControlToValidate="txtLowSpeedOpenMouldPosition" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
        </tr>                                                                                
              <tr>
                  <th align="right">
                    <asp:Label ID="lblHighSpeedOpenMouldSpeed" runat="server" Text="快速开模_速度:"></asp:Label></th>
                  <td>
                    <asp:TextBox ID="txtHighSpeedOpenMouldSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revHighSpeedOpenMouldSpeed" runat="server"
                    ControlToValidate="txtHighSpeedOpenMouldSpeed" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblHighSpeedOpenMouldPress" runat="server" Text="快速开模_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtHighSpeedOpenMouldPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revHighSpeedOpenMouldPress" runat="server" ControlToValidate="txtHighSpeedOpenMouldPress"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                    <asp:Label ID="lblHighSpeedOpenMouldPosition" runat="server" Text="快速开模_位置:"></asp:Label></th>
                  <td>
                    <asp:TextBox ID="txtHighSpeedOpenMouldPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                    <asp:RegularExpressionValidator ID="revHighSpeedOpenMouldPosition" runat="server" ControlToValidate="txtHighSpeedOpenMouldPosition"
                    ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
              </tr>
        <tr>
                <th align="right">
                    <asp:Label ID="lblReduceSpeedOpenMouldSpeed" runat="server" Text="减速开模_速度:"></asp:Label>
                    </th>
            <td>
                    <asp:TextBox ID="txtReduceSpeedOpenMouldSpeed" runat="server" CssClass="textbox"></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revReduceSpeedOpenMouldSpeed" runat="server"
                    ControlToValidate="txtReduceSpeedOpenMouldSpeed" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                    <asp:Label ID="lblReduceSpeedOpenMouldPress" runat="server" Text="减速开模_压力:"></asp:Label>
                    </th>
            <td>
                    <asp:TextBox ID="txtReduceSpeedOpenMouldPress" runat="server" CssClass="textbox" ></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="revReduceSpeedOpenMouldPress" runat="server"
                    ControlToValidate="txtReduceSpeedOpenMouldPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                   <asp:Label ID="lblReduceSpeedOpenMouldPosition" runat="server" Text="减速开模_位置:"></asp:Label>
                    </th>
            <td>
                    <asp:TextBox ID="txtReduceSpeedOpenMouldPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                    <asp:RegularExpressionValidator ID="revReduceSpeedOpenMouldPosition" runat="server"
                    ControlToValidate="txtReduceSpeedOpenMouldPosition" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            </tr>
              <tr>
                  <td align="right">
                  </td>
                  <td>
                      &nbsp;</td>
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
                <th align="right">
                <asp:Label ID="lblThimbleBeginMouldPosition" runat="server" Text="顶针模板位置:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtThimbleBeginMouldPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                    <asp:RegularExpressionValidator ID="revThimbleBeginMouldPosition" runat="server"
                        ControlToValidate="txtThimbleBeginMouldPosition" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                <th align="right">
                <asp:Label ID="lblThimbleActKind" runat="server" Text="顶针动作方式:"></asp:Label>
                    </th>
                <td align="left">
                    <asp:RadioButtonList ID="rblThimbleActKind" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" Width="124px">
                        <asp:ListItem Selected="True" Value="0">震动</asp:ListItem>
                        <asp:ListItem Value="1">定次</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
              <tr>
                  <th align="right">
                <asp:Label ID="lblThimbleGoSpeed" runat="server" Text="顶针前进_速度:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtThimbleGoSpeed" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revThimbleGoSpeed" runat="server"
                        ControlToValidate="txtThimbleGoSpeed" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblThimbleGoPress" runat="server" Text="顶针前进_压力:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtThimbleGoPress" runat="server" CssClass="textbox" ></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revThimbleGoPress" runat="server"
                        ControlToValidate="txtThimbleGoPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                  <th align="right">
                <asp:Label ID="lblThimbleGoPosition" runat="server" Text="顶针前进_位置:"></asp:Label></th>
                  <td>
                <asp:TextBox ID="txtThimbleGoPosition" runat="server" CssClass="textbox"></asp:TextBox>mm
                <asp:RegularExpressionValidator
                    ID="revThimbleGoPosition" runat="server" ControlToValidate="txtThimbleGoPosition"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
              </tr>
            
            <tr>
            <th align="right">
            <asp:Label ID="lblThimbleBackSpeed" runat="server" Text="顶针后退_速度:"></asp:Label></th>
                <td>
            <asp:TextBox ID="txtThimbleBackSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
            <asp:RegularExpressionValidator ID="revThimbleBackSpeed" runat="server"
                        ControlToValidate="txtThimbleBackSpeed" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblThimbleBackPress" runat="server" Text="顶针后退_压力:"></asp:Label></th>
                <td>
                <asp:TextBox ID="txtThimbleBackPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revThimbleBackPress" runat="server"
                    ControlToValidate="txtThimbleBackPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblThimbleBackPosition" runat="server" Text="顶针后退_位置:"></asp:Label></th>
                <td>
                <asp:TextBox ID="txtThimbleBackPosition" runat="server" CssClass="textbox" ></asp:TextBox>mm
                <asp:RegularExpressionValidator ID="revThimbleBackPosition" runat="server"
                    ControlToValidate="txtThimbleBackPosition" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <th align="right">
            <asp:Label ID="lblPushSpeed" runat="server" Text="吹气顶出_速度:"></asp:Label></th>
                <td>
            <asp:TextBox ID="txtPushSpeed" runat="server" CssClass="textbox" ></asp:TextBox>%
            <asp:RegularExpressionValidator ID="revPushSpeed" runat="server"
                        ControlToValidate="txtPushSpeed" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblPushPress" runat="server" Text="吹气顶出_压力:"></asp:Label></th>
                <td>
                <asp:TextBox ID="txtPushPress" runat="server" CssClass="textbox"></asp:TextBox>%
                <asp:RegularExpressionValidator ID="revPushPress" runat="server"
                    ControlToValidate="txtPushPress" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <td align="right">
                </td>
                <td>
                </td>
        </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblThimbleNum1" runat="server" Text="顶针次数1:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtThimbleNum1" runat="server" CssClass="textbox"></asp:TextBox>次
                <asp:RegularExpressionValidator ID="revThimbleNum1" runat="server"
                    ControlToValidate="txtThimbleNum1" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator></td>
            <th align="right">
                    <asp:Label ID="lblThimbleShakeTime" runat="server" Text="震动时间:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtThimbleShakeTime" runat="server" CssClass="textbox" ></asp:TextBox>s
                    <asp:RegularExpressionValidator
                        ID="revThimbleShakeTime" runat="server" ControlToValidate="txtThimbleShakeTime"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblThimbleStayTime" runat="server" Text="停留时间:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtThimbleStayTime" runat="server" CssClass="textbox"></asp:TextBox>s
                <asp:RegularExpressionValidator
                    ID="revThimbleStayTime" runat="server" ControlToValidate="txtThimbleStayTime"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <th align="right">
                <asp:Label ID="lblBeforeGetWater" runat="server" Text="前模接水方式:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtBeforeGetWater" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            <th align="right">
                    <asp:Label ID="lblBeforeGetWaterTemp" runat="server" Text="前模接水_温度:"></asp:Label></th>
            <td>
                    <asp:TextBox ID="txtBeforeGetWaterTemp" runat="server" CssClass="textbox" ></asp:TextBox>'C<asp:RegularExpressionValidator
                        ID="revBeforeGetWaterTemp" runat="server" ControlToValidate="txtBeforeGetWaterTemp"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
            <th align="right">
                <asp:Label ID="lblBeforeGetWaterMouldTemp" runat="server" Text="前模接水_模温:"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtBeforeGetWaterMouldTemp" runat="server" CssClass="textbox"></asp:TextBox>'C<asp:RegularExpressionValidator
                    ID="revBeforeGetWaterMouldTemp" runat="server" ControlToValidate="txtBeforeGetWaterMouldTemp"
                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
        </tr>
              <tr>
                  <th align="right">
                      <asp:Label ID="lblAfterGetWater" runat="server" Text="后模接水方式:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtAfterGetWater" runat="server" CssClass="textbox"></asp:TextBox>
                      </td>
                  <th align="right">
                      <asp:Label ID="lblAfterGetWaterTemp" runat="server" Text="后模接水_温度:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtAfterGetWaterTemp" runat="server" CssClass="textbox"></asp:TextBox>'C<asp:RegularExpressionValidator ID="revAfterGetWaterTemp" runat="server" ControlToValidate="txtAfterGetWaterTemp"
                          Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
                  <th align="right">
                      <asp:Label ID="lblAfterGetWaterMouldTemp" runat="server" Text="后模接水_模温:"></asp:Label></th>
                  <td>
                      <asp:TextBox ID="txtAfterGetWaterMouldTemp" runat="server" CssClass="textbox"></asp:TextBox>'C<asp:RegularExpressionValidator ID="revAfterGetWaterMouldTemp" runat="server" ControlToValidate="txtAfterGetWaterMouldTemp"
                          Display="Dynamic" ErrorMessage="*" ValidationExpression="\d+(\.\d+)?$"></asp:RegularExpressionValidator></td>
              </tr>
              <tr>
                  <th align="right">
                      <asp:Label ID="Label2" runat="server" Text="物料选项:"></asp:Label></th>
                  <td colspan="5">
                      <asp:TextBox ID="qualiteremark" runat="server" CssClass="textbox" TextMode="MultiLine" Width="550px"></asp:TextBox></td>
              </tr>
              <tr>
                  <th align="right">
                      <asp:Label ID="lblRemark" runat="server" Text="备注:"></asp:Label></th>
                  <td colspan="5">
                      <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" TextMode="MultiLine" Width="550px"></asp:TextBox></td>
              </tr>
              <tr>
                  <th align="right" valign="top">
                      <asp:Label ID="Label1" runat="server" Text="接水图:"></asp:Label></th>
                  <td valign="top">
                      <asp:FileUpload ID="fudPhoto" runat="server" CssClass="textbox" Width="192px" /></td>
                  <td align="left" colspan="3">
                      <asp:Image ID="Image1" runat="server" Height="106px" Width="206px" /></td>
                  <td>
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