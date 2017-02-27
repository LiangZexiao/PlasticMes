<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorMachineDtil.aspx.cs" Inherits="Monitor_MonitorMachineDtil" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Refresh" content="6" />
<link href="../images/css.css" type="text/css" rel="stylesheet" />
    <title>机器监视明细(MonitorMachineDtil)</title>
    <style type="text/css">
        .style1
        {
            width: 40%;
        }
        .style2
        {
            height: 14px;
            width: 178px;
        }
        .style3
        {
            width: 15%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <table border="0" cellpadding="0" cellspacing="0" class="section-content">
          <tr>
          <td valign="top" align="center">
          
          <table class="itemtable" cellspacing="1" cellpadding="2" border="0" style="width: 100%">
              <tr>
                <td style="background-image: url(../images/bg_title.gif); width: 100%; height: 22px;">　　浏览</td>
              </tr>
          </table> 
              <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">                  
              
                    
            <table border="0" style="border-collapse: collapse; width: 100%;" cellpadding="1" cellspacing="1" class="texttable">
                <tr>
                    <th align="left" colspan="2" 
                        style="font-size: 12px; color: #FF0000; font-weight: bold;" >
                        注塑主单
                    </th>
            </tr>
             <tr>
                    <th align="right"  style="width: 20%;" >
                    机器编号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblMachineNo" runat="server" Text=""></asp:Label></td>
            </tr>
                <tr>
                    <th align="right" style="width: 20%;">
                        IP地址:&nbsp;
                    </th>
                    <td style="height: 14px">
                        &nbsp;<asp:Label ID="lblIp" runat="server"></asp:Label></td>
                </tr>
            <tr>
                <th align="right" style="width: 20%;" >
                    模具编号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblMouldNo" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >
                    型腔数:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblGoodSocketNum" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr id="trWorkOrderNo" runat="server">
                <th align="right" style="width: 20%;">
                    工单号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblWO_No" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >派工单号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblDO_No" runat="server" Text=""></asp:Label>
                    <a runat="server" id="DispatchNo" target="main" onclick="window.close()"></a>
                </td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >
                    原料名称:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >产品编号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblProductNo" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
                <tr runat="server" id="trProductName">
                    <th align="right" class="style1">
                        产品描述:&nbsp;
                    </th>
                    <td>
                        &nbsp;<asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></td>
                </tr>
            <tr>
                <th align="right" class="style1" >
                    水口比例:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblItem_WaterGapScale" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th align="right" class="style1" >
                    标准周期:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblStandCycle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th align="right" class="style1" >注塑周期:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblBeginTime" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
            <tr>
                <th align="right" class="style1" >派工数量:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblDispatchNum" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" class="style1" >已生产数:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblProducted" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" class="style1" >
                   次品数:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblBadQty" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                    <th align="left" colspan="2" 
                        style="font-size: 12px; color: #FF0000; font-weight: bold;" >
                        注塑次单
                    </th>
            </tr>
            
               
            <tr>
                <th align="right" style="width: 20%;" >
                    模具编号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblMouldNo1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >
                    型腔数:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblGoodSocketNum1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr id="tr2" runat="server">
                <th align="right" style="width: 20%;">
                    工单号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblWO_No1" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >派工单号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblDO_No1" runat="server" Text=""></asp:Label>
                    <a runat="server" id="A2" target="main" onclick="window.close()"></a>
                </td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >
                    原料名称:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblMaterialName1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" style="width: 20%;" >产品编号:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblProductNo1" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
                <tr runat="server" id="tr3">
                    <th align="right" class="style1">
                        产品描述:&nbsp;
                    </th>
                    <td>
                        &nbsp;<asp:Label ID="lblProductName1" runat="server" Text=""></asp:Label></td>
                </tr>
            <tr>
                <th align="right" class="style1" >
                    水口比例:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblItem_WaterGapScale1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th align="right" class="style1" >
                    标准周期:&nbsp;</th>
                <td>
                    &nbsp;<asp:Label ID="lblStandCycle1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th align="right" class="style1" >注塑周期:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblBeginTime1" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
            <tr>
                <th align="right" class="style1" >派工数量:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblDispatchNum1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" class="style1" >已生产数:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblProducted1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th align="right" class="style1" >
                   次品数:&nbsp;
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblBadQty1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                  <td align="center" colspan="2">
                    <input id="hdnDispatchID" type="hidden" runat="server" style="width: 10px" />
                    <input id="hdnMachineID" type="hidden" runat="server" style="width: 10px" />
                    &nbsp;<img src="../images/btn_cancel.gif" onclick="window.close()" style="CURSOR: hand" id="IMG1" /></td>
            </tr>
            </table>
                  </asp:View>
                  <asp:View ID="View2" runat="server"><table border="0" style="border-collapse: collapse; width: 100%;" cellpadding="1" cellspacing="1" class="texttable">
                      <tr>
                          <th align="right" class="style1" >
                              机器编号:&nbsp;</th>
                          <td>
                              &nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <th align="right" class="style3">
                              IP地址:&nbsp;
                          </th>
                          <td>
                              &nbsp;<asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <th align="right" class="style3" >
                              模具编号:&nbsp;</th>
                          <td>
                              &nbsp;<asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr id="Tr1" runat="server">
                          <th align="right" class="style3" >
                              生产单号:&nbsp;</th>
                          <td>
                              &nbsp;<asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <th align="right" class="style3" >
                              派工单号:&nbsp;</th>
                          <td>
                              &nbsp;<asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                              <a runat="server" id="A1" target="main" onclick="window.close()"></a>
                          </td>
                      </tr>
                      <tr>
                          <th align="right" class="style3" >
                              产品编号:&nbsp;</th>
                          <td>
                              &nbsp;<asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <th align="right" class="style3">
                              产品描述:&nbsp;
                          </th>
                          <td>
                              &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <th align="right" class="style3" >
                              派工数量:&nbsp;
                          </th>
                          <td>
                              &nbsp;<asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <th align="right" class="style3" >
                              已生产数:&nbsp;
                          </th>
                          <td>
                              &nbsp;<asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <th align="right" class="style3" >
                              次品数:&nbsp;
                          </th>
                          <td>
                              &nbsp;<asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <td align="center" colspan="2" >
                              <input id="Hidden1" type="hidden" runat="server" style="width: 10px" />
                              <input id="Hidden2" type="hidden" runat="server" style="width: 10px" />
                              &nbsp;<img src="../images/btn_cancel.gif" onclick="window.close()" style="CURSOR: hand" /></td>
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
