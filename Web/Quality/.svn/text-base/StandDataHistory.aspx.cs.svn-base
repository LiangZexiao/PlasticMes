using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Chart;

using Admin.BLL.Collect_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Quality_StandDataHistory : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    const string IMG_HEIGHT = "560";
    const string IMG_WIDTH = "1000";

    public string bDateTime
    {
        get { return (ViewState["bDateTime"] == null) ? System.DateTime.Now.ToString("yyyy-MM-dd") + " " + "07:20" : ViewState["bDateTime"].ToString().Trim(); }
        set { ViewState["bDateTime"] = value; }
    }

    private string eDateTime
    {
        get { return (ViewState["eDateTime"] == null) ? System.DateTime.Now.ToString("yyyy-MM-dd") + " " + "07:20" : ViewState["eDateTime"].ToString().Trim(); }
        set { ViewState["eDateTime"] = value; }
    }
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "StandDataHistory");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            //subnet.Attributes.Add("src", "QualityTrack_Cycle.aspx");
            BinaDataToCtrl();
            string today = System.DateTime.Now.ToString("yyyy-MM-dd");
            txtDate1.Value = txtDate2.Value = today;

            txtTime1.Value = "07:20";
            txtTime2.Value = "07:20";
            bDateTime = today + " " + txtTime1.Value.Trim();
            eDateTime = today + " " + txtTime2.Value.Trim();

            string Target = "QualityTrack_Cycle";
            string bdate = bDateTime + ":00";
            string edate = eDateTime + ":00";
            string machineno = ddlMachineNo.SelectedValue.Trim();
            string mouldno = ddlMouldNo.SelectedValue.Trim();
            string productno = ddlProductNo.SelectedValue.Trim();
            string ActionNum = (ddlAction.SelectedValue.Trim() == "") ? "-9" : ddlAction.SelectedValue.Trim();
            subnet.Attributes.Add("src", Target + ".aspx?URLID=StandDataHistory&IMG_HEIGHT=" + IMG_HEIGHT + "&IMG_WIDTH=" + IMG_WIDTH + "&StartDate=" + bdate + "&EndDate=" + edate + "&MachineNo=" + machineno + "&MouldNo=" + mouldno + "&ProductNo=" + productno + "&ActionNum=" + ActionNum + "&AdjustData=1");
        }
    }

    private void BinaDataToCtrl()
    {
        StandDataHistory_BLL bllDataHistory = new StandDataHistory_BLL();

        dboSetCtrls.SetDropDownList(ddlMachineNo, bllDataHistory.selectMachineNoFromStandDataHistory(), false, "MachineNo", "MachineNo");
        dboSetCtrls.SetDropDownList(ddlMouldNo, bllDataHistory.selectMouldNoFromStandDataHistory(ddlMachineNo.SelectedValue.Trim()), false, "MouldNo", "MouldNo");
        dboSetCtrls.SetDropDownList(ddlProductNo, bllDataHistory.selectProductNoFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim()), false, "ProductNo", "ProductNo");
        dboSetCtrls.SetDropDownList(ddlAction, bllDataHistory.selectActionNumFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim(), ddlProductNo.SelectedValue.Trim()), true, "TotalNum", "TotalNum");
    }

    protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        StandDataHistory_BLL bllDataHistory = new StandDataHistory_BLL();
        dboSetCtrls.SetDropDownList(ddlMouldNo, bllDataHistory.selectMouldNoFromStandDataHistory(ddlMachineNo.SelectedValue.Trim()), false, "MouldNo", "MouldNo");
        dboSetCtrls.SetDropDownList(ddlProductNo, bllDataHistory.selectProductNoFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim()), false, "ProductNo", "ProductNo");
        dboSetCtrls.SetDropDownList(ddlAction, bllDataHistory.selectActionNumFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim(), ddlProductNo.SelectedValue.Trim()), true, "TotalNum", "TotalNum");
        LoadPage();
    }

    protected void ddlMouldNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        StandDataHistory_BLL bllDataHistory = new StandDataHistory_BLL();
        dboSetCtrls.SetDropDownList(ddlProductNo, bllDataHistory.selectProductNoFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim()), false, "ProductNo", "ProductNo");
        dboSetCtrls.SetDropDownList(ddlAction, bllDataHistory.selectActionNumFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim(), ddlProductNo.SelectedValue.Trim()), true, "TotalNum", "TotalNum");
        LoadPage();
    }

    protected void ddlProductNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        StandDataHistory_BLL bllDataHistory = new StandDataHistory_BLL();
        dboSetCtrls.SetDropDownList(ddlAction, bllDataHistory.selectActionNumFromStandDataHistory(ddlMachineNo.SelectedValue.Trim(), ddlMouldNo.SelectedValue.Trim(), ddlProductNo.SelectedValue.Trim()), true, "TotalNum", "TotalNum");
        LoadPage();
    }

    protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPage();
    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton tempLinkButton = sender as LinkButton;

        for (int i = 0; i < Tinf.Rows[0].Cells.Count - 1; i++)
            Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");

        string Target = "QualityTrack_Cycle";
        int CellsIndex = 0;
        switch (tempLinkButton.ID.Trim())
        {
            case "LinkButton1":
                Target = "QualityTrack_Cycle";
                CellsIndex = 0;
                break;
            case "LinkButton2":
                Target = "QualityTrack_Temp";
                CellsIndex = 1;
                break;
            case "LinkButton3":
                Target = "QualityTrack_Press";
                CellsIndex = 2;
                break;
            case "LinkButton4":
                Target = "QualityTrack_MaxPress";
                CellsIndex = 3;
                break;
            case "LinkButton5":
                Target = "QualityTrack_PreInjectTime";
                CellsIndex = 4;
                break;
            case "LinkButton6":
                Target = "QualityTrack_InjectTime";
                CellsIndex = 5;
                break;
            case "LinkButton7":
                Target = "QualityTrack_InjectNum";
                CellsIndex = 6;
                break;
            default:
                Target = "QualityTrack_Cycle";
                CellsIndex = 7;
                break;
        }
        hdnTarget.Value = Target;
        Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");
        LoadPage();
    }


    private void LoadPage()
    {
        string Target = hdnTarget.Value.Trim();

        string bdate = txtDate1.Value.Trim();
        string edate = txtDate2.Value.Trim();

        if (bdate == "" || bdate == null)
        {
            dboSetCtrls.SetExecMsg(this, "请输入起始日期!!");
            return;
        }

        bdate = bdate + " " + txtTime1.Value + ":00";
        edate = edate + " " + txtTime2.Value + ":00";

        string machineno = ddlMachineNo.SelectedValue.Trim();
        string mouldno = ddlMouldNo.SelectedValue.Trim();
        string productno = ddlProductNo.SelectedValue.Trim();
        string ActionNum = ddlAction.SelectedValue.Trim();
        if (ActionNum == "") ActionNum = "-9";
        if (Target == "QualityTrack_Press")
        {
            ActionNum = ddlAction.SelectedValue.Trim();
            if (ActionNum == "")
            {
                ActionNum = "1";
                //ddlAction.Items.Clear();
                //ddlAction.Items.Insert(0, new ListItem("0", "1"));
                ddlAction.SelectedIndex = 0;
            }
        }
        subnet.Attributes.Add("src", Target + ".aspx?URLID=StandDataHistory&IMG_HEIGHT=" + IMG_HEIGHT + "&IMG_WIDTH=" + IMG_WIDTH + "&StartDate=" + bdate + "&EndDate=" + edate + "&MachineNo=" + machineno + "&MouldNo=" + mouldno + "&ProductNo=" + productno + "&ActionNum=" + ActionNum + "&AdjustData=1");
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        string MachineNo = ddlMachineNo.SelectedValue.Trim();
        string MouldNo = ddlMouldNo.SelectedValue.Trim();
        string ProductNo = ddlProductNo.SelectedValue.Trim();
        string TotalNum = ddlAction.SelectedValue.Trim();
        StandDataHistory_BLL bllDataHistory = new StandDataHistory_BLL();
        int i = bllDataHistory.updateStandDataHistory(MachineNo, MouldNo, ProductNo, TotalNum);
    }
    protected void igbSured_Click(object sender, ImageClickEventArgs e)
    {
        LoadPage();
    }
}