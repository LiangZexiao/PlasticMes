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
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;

using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.BLL.Product_BLL;
using Admin.BLL.Quality_BLL;
using Admin.App_Code;
using Admin.Model.Machine_MDL;
using System.Collections.Generic;

public partial class Quality_OEE : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "OEE");
            ViewState["authority"] = o;
            if (o[0]) igbQuery.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            BindData();
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, true, "Machine_Code", "Machine_Code");
            //dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, true, "Item_Code", "Item_Code");
            //dboSetCtrls.SetDropDownList(ddlMachineNo, new SuitManage_DAL().selectSuitManage(0) as IList, true, "PlantBristlesCode", "PlantBristlesCode");
            txtBeginDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //txtTime1.Value = "07:20";
            //txtTime2.Value = "07:20";

            ddlMachineNo.Items.Clear();
            ddlMachineNo.Items.Add(new ListItem("全部", "全部"));
            IList<MachineMstr_MDL> mytempList = MachineMstr_BLL.selectMachineMstr(0, "", "");//注塑机器
            IList<MachineSuit_MDL> tempList2 = new MachineSuit_DAL().selectMachineSuit(0, "", "");//植毛机器
            for (int i = 0; i < mytempList.Count; i++)
            {
                ddlMachineNo.Items.Add(new ListItem(mytempList[i].Machine_Code, mytempList[i].Machine_Code));
            }
            for (int i = 0; i < tempList2.Count; i++)
            {
                ddlMachineNo.Items.Add(new ListItem(tempList2[i].MachineCode, tempList2[i].MachineCode));
            }

            ddlWorkShop.Items.Clear();
            ddlWorkShop.Items.Add(new ListItem("全部", "全部"));
            DataTable dtWorkShop = MachineMstr_BLL.selectWorkShop();
            foreach (DataRow dr in dtWorkShop.Rows)
            {
                ddlWorkShop.Items.Add(new ListItem(dr["WorkShop"].ToString().Trim(), dr["MachineNo"].ToString().Trim()));
            }
        }
    }

    private void BindData()
    {
        string WorkShopNo = ddlWorkShop.SelectedValue.Trim();
        string MachineNo = ddlMachineNo.SelectedValue.Trim();
        string ProductNo = ddlProductNo.SelectedValue.Trim();
        string BeginDate = txtBeginDate.Value.Trim();
        string EndDate = txtEndDate.Value.Trim();
        DataTable tempTable = new OEE_BLL().selectOEETable(WorkShopNo,MachineNo, ProductNo, BeginDate, EndDate);
        GridView1.DataSource = tempTable;
        GridView1.DataBind();
        // dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        // dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempTable.Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);

    }

    //protected void CtrlPageInfo_Click(object sender, EventArgs e)
    //{
    //    ImageButton tempImageButton = sender as ImageButton;
    //    if (tempImageButton.ID == "igbSearch")
    //    {
    //        string strPageIndex = txtPageIndex.Text.Trim();
    //        if (strPageIndex == "" || strPageIndex == null) return;
    //        GridView1.PageIndex = int.Parse(strPageIndex) - 1;
    //    }
    //    else
    //        GridView1.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
    //    BindData();
    //}

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }


    protected void CtrlPageInfo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton tempImageButton = sender as ImageButton;
        if (tempImageButton.ID == "igbSearch")
        {
            string strPageIndex = txtPageIndex.Text.Trim();
            if (strPageIndex == "" || strPageIndex == null) return;
            GridView1.PageIndex = int.Parse(strPageIndex) - 1;
        }
        else
            GridView1.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
        BindData();
    }
    protected void btnQuery_Click(object sender, ImageClickEventArgs e)
    {
        BindData();
    }
    protected void ddlWorkShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        string MachineNo = ddlWorkShop.SelectedValue.Trim();
        if (MachineNo == "") return;
        ddlMachineNo.Items.Clear();
        if (MachineNo != "全部")
        {
            DataTable dtMachine = MachineMstr_BLL.selectMachinePlant(MachineNo);
            DataRow dr = dtMachine.NewRow();
            dr["MachineCode"] = "全部";
            dtMachine.Rows.InsertAt(dr, 0);
            dboSetCtrls.SetDropDownList(ddlMachineNo, dtMachine, "MachineCode", "MachineCode");
        }
        else
        {
            ddlMachineNo.Items.Add(new ListItem("全部", "全部"));
            IList<MachineMstr_MDL> mytempList = MachineMstr_BLL.selectMachineMstr(0, "", "");//注塑机器
            IList<MachineSuit_MDL> tempList2 = new MachineSuit_DAL().selectMachineSuit(0, "", "");//植毛机器
            for (int i = 0; i < mytempList.Count; i++)
            {
                ddlMachineNo.Items.Add(new ListItem(mytempList[i].Machine_Code, mytempList[i].Machine_Code));
            }
            for (int i = 0; i < tempList2.Count; i++)
            {
                ddlMachineNo.Items.Add(new ListItem(tempList2[i].MachineCode, tempList2[i].MachineCode));
            }
        }
    }
}
