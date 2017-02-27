using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Admin.Model.Monitor_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.BLL.Monitor_BLL;
using Admin.BLL.Product_BLL;
using Admin.App_Code;
using Admin.SQLServerDAL.RightCtrl;

public partial class Monitor_MonitorMachineMstr : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    const int Width = 135;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];

                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MonitorMachineMstr");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!Page.IsPostBack)
        {
            //dboSetCtrls.SetDropDownList(ddlMachineCode, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");
            //dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, MachineMstr_BLL.selectMachineMstr() as IList, true, "Machine_MaterialChgAmt", "Remark");
          // MachineMstr.aspx
        }
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        /* LinkButton tempLinkButton = sender as LinkButton;

         for (int i = 0; i < Tinf.Rows[0].Cells.Count - 3; i++)
             Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");

         string Target = "QualityTrack_Cycle";
         int CellsIndex = 0;
         switch (tempLinkButton.ID.Trim())
         {
             case "LinkButton1"://注塑机器　
                 Target = "MachineMstr";
                 CellsIndex = 0;
                 break;
             default:
                 Target = "PlantBristlesMachineInfo";//植毛机器
                 CellsIndex = 1;
                 break;
         }
         Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");
         subnet.Attributes.Add("src", Target + ".aspx");*/
    }
}
