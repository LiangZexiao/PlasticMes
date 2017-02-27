using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.SQLServerDAL.Call_DAL;
using Admin.Model.Call_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL;
using Admin.SQLServerDAL.Collect_DAL;
using Admin.App_Code;
using Admin.Model.Collect_MDL;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
public partial class Collect_CardDetail : System.Web.UI.Page
{
    static SQLExecutant sc = new SQLExecutant();
    DataTable dt;

    SetCtrls dboSetCtrls = new SetCtrls();
    bool[] o = new bool[7] { false, false, false, false, false, false, false };

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Collect_CardDetail));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "CardDetail");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) igbNewadd.Visible = false; igbInsert.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbCancel.Visible = false; igbDelete.Visible = false;
            
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
            this.txtInBeginDate.Value = this.txtInEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            dboSetCtrls.SetDropDownList(DropDownList1, new MachineSuit_DAL().SelectReasonAll(false) as IList, true, "ReasonID", "ReasonName");
            dboSetCtrls.SetDropDownList(ddlMachine_SeatCode, new MachineSuit_DAL().selectMachineMstr() as IList, true, "Machine_MaterialChgAmt", "Remark");
            dataBind();
        }
    }

    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.ToString().Trim();
        string coltext = this.txtQuery.Text.ToString().Trim();
        string begindate = txtInBeginDate.Value.Trim() == "" ? "" : txtInBeginDate.Value.Trim();
        string enddate = txtInEndDate.Value.Trim() == "" ? "" : txtInEndDate.Value.Trim();
        dt = new CardDetail_DAL().selectICCard(ddlMachine_SeatCode.SelectedValue, DropDownList1.SelectedValue,colname, coltext, begindate, enddate);
        this.GridView1.DataSource = dt;
        GridView1.DataBind();
        dboSetCtrls.SetGridView(ddlCardType, GridView1, "cardtype");
        
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, dt.Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
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
        voidBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete);
            object[] textboxid = { txtICCard, txtRemark };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            search.Value = "";
            this.search.Disabled = false;
        }
        else
        {
            if (tempButton.ID != "btnQuery")
            {
                MultiView1.ActiveViewIndex = 0;
                voidBind();
            }
            else
            {
                string begindate = txtInBeginDate.Value.Trim() == "" ? "" : txtInBeginDate.Value.Trim();
                string enddate = txtInEndDate.Value.Trim() == "" ? "" : txtInEndDate.Value.Trim();
                if (begindate != "" && enddate != "")
                {
                    if (Convert.ToDateTime(begindate) > Convert.ToDateTime(enddate))
                    {
                        dboSetCtrls.SetExecMsg(this, "开始时间不能大于结束时间！");
                        return;
                    }
                }
                voidBind();
            }
        }
    }

    void voidBind()
    {
        string colname = this.ddlQuery.SelectedValue.ToString().Trim();
        string coltext = this.txtQuery.Text.ToString().Trim();
        string begindate = txtInBeginDate.Value.Trim() == "" ? "" : txtInBeginDate.Value.Trim();
        string enddate = txtInEndDate.Value.Trim() == "" ? "" : txtInEndDate.Value.Trim();
        DataTable dtCard = new CardDetail_DAL().selectICCard(ddlMachine_SeatCode.SelectedValue, DropDownList1.SelectedValue, colname, coltext, begindate, enddate);
        this.GridView1.DataSource = dtCard;
        this.GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, dtCard.Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
        dboSetCtrls.SetGridView(ddlCardType, GridView1, "CardType");
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {

                pIDList.Add(txtID.Text.Trim());
                int y = new CardDetail_DAL().cancelCardDetail(pIDList);
                if (y > 0)
                {

                    dboSetCtrls.SetExecMsg(this, "delete", true);
                }
                else
                {

                    dboSetCtrls.SetExecMsg(this, "delete", false);
                }
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                int y = new CardDetail_DAL().cancelCardDetail(pIDList);
                if (y > 0)
                {

                    dboSetCtrls.SetExecMsg(this, "delete", true);
                }
                else
                {

                    dboSetCtrls.SetExecMsg(this, "delete", false);
                }
                voidBind();
            }
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        string vID = txtID.Text.ToString() == "" ? "0" : txtID.Text.ToString();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        string vDONO = this.search.Value.Trim();
        string vCardID = this.txtICCard.Text.Trim();
        string vCardType = this.ddlType.SelectedValue.Trim();
        string vBeginDate = this.txtBeginDate.Value.Trim();
        string vEndDate = this.txtEndDate.Value.Trim();
        string vRemark = this.txtRemark.Text.Trim();
        string vCreateDate = System.DateTime.Now.ToString();
        string vClientIP = new CardDetail_DAL().selectIPAddr(vDONO,"","").Rows[0]["IPAddr"].ToString();
        string odlBeginDate = hdnBeginDate.Value.Trim();
        string odlEndDate = hdnEndDate.Value.Trim();
        string odlCardType = hdnCardType.Value.Trim();

        try
        {
            CardDetail_MDL card = new CardDetail_MDL(int.Parse(vID), vDONO, vClientIP, vCardID, vCardType, vBeginDate, vEndDate, vCreateDate, vRemark, odlBeginDate, odlEndDate, odlCardType);
            int t = new CardDetail_DAL().ChangeCardDetail(card, IU);
            if (t > 0)
            {
                dboSetCtrls.SetExecMsg(this, IU, true);
                return;
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
                return;
            }
        }
        catch(Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, IU, false);
            return;
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string vID = txtID.Text =
           ((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]) as LinkButton).Text.Trim();
        string vCmd = e.CommandName.Trim();

        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtICCard);

        DataTable dt = new CardDetail_DAL().selectICCardDetail(int.Parse(vID), "", "", "", "");
        this.search.Value = dt.Rows[0]["DONO"].ToString();
        this.txtICCard.Text = dt.Rows[0]["CardID"].ToString();
        dboSetCtrls.SetSelectedIndex(ddlType, dt.Rows[0]["CardType"].ToString());
        if (dt.Rows[0]["BeginDate"].ToString().Length > 16)
        {
            this.txtBeginDate.Value = dt.Rows[0]["BeginDate"].ToString();
        }
        else
        {
            this.txtBeginDate.Value = "";
        }
        if (dt.Rows[0]["EndDate"].ToString().Length > 16)
        {
            this.txtEndDate.Value = dt.Rows[0]["EndDate"].ToString();
        }
        else
        {
            this.txtEndDate.Value = "";
        }

        this.txtRemark.Text = dt.Rows[0]["Remark"].ToString();
        this.hdnBeginDate.Value = dt.Rows[0]["BeginDate"].ToString();
        this.hdnEndDate.Value = dt.Rows[0]["EndDate"].ToString();
        this.hdnCardType.Value = dt.Rows[0]["CardType"].ToString();
        

    }

    #region //给派工单号赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "", "DO_NO", str);
        for (int t = 0; t < tempList.Count; t++)
        {
            string do_no = tempList[t].DO_No;
            if (do_no.Substring(do_no.Length - 3, 1) == "0")
            {
                itmes.Add(do_no);
            }
        }
        return itmes;
    }
    #endregion

    [AjaxPro.AjaxMethod]
    public string GetName(string UserId) 
    {
        string[] aa ={ "2", "1", "3", "4", "5", "6", "7", "8" };
        //Random rd = new Random();
        return "asdf";
    }

    protected void imgBtExcel_Click(object sender, ImageClickEventArgs e)
    {
        if ((GridView1.Rows.Count) > 0)
        {
            string colname = this.ddlQuery.SelectedValue.ToString().Trim();
            string coltext = this.txtQuery.Text.ToString().Trim();
            string begindate = txtInBeginDate.Value.Trim() == "" ? "" : txtInBeginDate.Value.Trim();
            string enddate = txtInEndDate.Value.Trim() == "" ? "" : txtInEndDate.Value.Trim();
            DataTable dtCard = new CardDetail_DAL().selectICCard(ddlMachine_SeatCode.SelectedValue, DropDownList1.SelectedValue, colname, coltext, begindate, enddate);
            GridView gridTmp = new GridView();
            gridTmp.DataSource = dtCard;
            gridTmp.DataBind();
            gridTmp.AllowPaging = false;

            Response.Clear();
            Response.Buffer = false;
            Response.Charset = "GB2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=CardDetail.xls");
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            gridTmp.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
        }
    }
}
