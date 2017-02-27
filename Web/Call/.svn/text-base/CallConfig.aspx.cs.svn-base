using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.App_Code;
using Admin.SQLServerDAL.RightCtrl;

public partial class Call_CallConfig : System.Web.UI.Page
{

    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "CallConfig");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            subnet.Attributes.Add("src", "Call_Cycle.aspx");
            this.MultiView1.ActiveViewIndex = 0;
        }

    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton tempLinkButton = sender as LinkButton;

        for (int i = 0; i < Tinf.Rows[0].Cells.Count - 3; i++)
            Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");

        string Target = "QualityTrack_Cycle";
        int CellsIndex = 0;
        switch (tempLinkButton.ID.Trim())
        {
            case "LinkButton1"://周期提醒设置
                Target = "Call_Cycle";
                CellsIndex = 0;
                break;
            default:
                Target = "Call_press";//生产数量提醒设置
                CellsIndex = 1;
                break;
        }
        Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");
        subnet.Attributes.Add("src", Target + ".aspx");


    }
}
