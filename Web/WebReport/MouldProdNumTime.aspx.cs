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
using Admin.BLL.Collect_BLL;
using Admin.BLL.Machine_BLL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.Model.Machine_MDL;
using Admin.BLL.BaseInfo_BLL;

public partial class WebReport_MouldProdNumTime : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    private Dictionary<string, string> dicSearch = new Dictionary<string, string>();
    private string strGoodsNo, strMouldNo, strUserID, strBeginDate, strEndDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(WebReport_MouldProdNumTime));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MouldProdNumTime");
            ViewState["authority"] = o;
            if (o[4]) igbPrint.Visible = false;
            DicInit();
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            DataHistory_BLL sdh_bll = new DataHistory_BLL();
           // dboSetCtrls.SetDropDownList(ddlMouldNo, sdh_bll.selectMouldNoFromDataHistory(""), true, "MouldNo", "MouldNo");           
            txtBeginDate.Value = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            txtEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
    }

    private void DicInit()
    {
        this.dicSearch.Add("strGoodsNo", "");
        this.dicSearch.Add("strMouldNo", "");
        this.dicSearch.Add("strUserID", "");
        this.dicSearch.Add("strBeginDate", "");
        this.dicSearch.Add("strEndDate", "");
    }

    protected void igbPrint_Click(object sender, ImageClickEventArgs e)
    {
        int flag;
        string BeginDate = txtBeginDate.Value.Trim();
        if (string.IsNullOrEmpty(BeginDate))
        {
            dboSetCtrls.SetExecMsg(this, "startdate", true);
            return;
        }
        string EndDate = (txtEndDate.Value.Trim() == string.Empty) ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") : txtEndDate.Value.Trim();
        if (dboSetCtrls.CheckDateTime("string", BeginDate, EndDate))
        {
            dboSetCtrls.SetExecMsg(this, "起始日期不能大于终止日期!!");
            return;
        }
        string ReportName = "MouldProdNumTime";
        Session[ReportName + "_BeginDate"] = BeginDate ;
        this.strBeginDate = Session[ReportName + "_BeginDate"].ToString().Trim();
        Session[ReportName + "_EndDate"] = EndDate ;
        this.strEndDate = Session[ReportName + "_EndDate"].ToString().Trim();
        Session[ReportName + "_GoodsNo"] = txtMouldNo.Value.Trim();
        this.strGoodsNo = Session[ReportName + "_GoodsNo"].ToString().Trim();
        Session[ReportName + "_MouldNo"] = search.Value.Trim();//ddlMouldNo.SelectedValue.Trim();
        this.strMouldNo = Session[ReportName + "_MouldNo"].ToString().Trim(); 
        Session[ReportName + "_UserID"] = this.Page.User.Identity.Name.Trim();
        this.strUserID = Session[ReportName + "_UserID"].ToString().Trim();
        flag = getSearchFlag();
        Session[ReportName + "_Flag"] = flag.ToString().Trim();

        this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportType=3&ReportName=" + ReportName + "') </script>");
    }

    private int getSearchFlag()
    {
        int flag = 1;
        string retValue;

        this.dicSearch.TryGetValue("strGoodsNo", out retValue);
        if (this.strGoodsNo != retValue)
        {
            this.dicSearch.Remove("strGoodsNo");
            this.dicSearch.Add("strGoodsNo", strGoodsNo);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strMouldNo", out retValue);
        if (this.strMouldNo != retValue)
        {
            this.dicSearch.Remove("strMouldNo");
            this.dicSearch.Add("strMouldNo", strMouldNo);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strUserID", out retValue);
        if (this.strUserID != retValue)
        {
            this.dicSearch.Remove("strUserID");
            this.dicSearch.Add("strUserID", strUserID);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strBeginDate", out retValue);
        if (this.strBeginDate != retValue)
        {
            this.dicSearch.Remove("strBeginDate");
            this.dicSearch.Add("strBeginDate", strBeginDate);
            flag = 0;
        }
        this.dicSearch.TryGetValue("strEndDate", out retValue);
        if (this.strEndDate != retValue)
        {
            this.dicSearch.Remove("strEndDate");
            this.dicSearch.Add("strEndDate", strEndDate);
            flag = 0;
        }
        return flag;
    }

    #region //给工单号和派工单号赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str)
    {
        ArrayList itmes = new ArrayList();

        IList<MouldDetail_MDL> tempList = MouldDetail_BLL.selectMouldDetail(0, "Mould_Code", str);//DispatchOrder_BLL.selectDispatchOrder(0, "", "DO_NO", str);
        for (int t = 0; t < (tempList.Count > 50 ? 50 : tempList.Count); t++)
        {
            itmes.Add(tempList[t].MouldCode);
        }


        return itmes;
    }
    #endregion
    
    #region //查询货号
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhGoodsNo(string str)
    {
        ArrayList itmes = new ArrayList();

        IList<MouldDetail_MDL> tempList = MouldDetail_BLL.selectMouldDetail(0, "GoodsNo", str);//DispatchOrder_BLL.selectDispatchOrder(0, "", "DO_NO", str);
        for (int t = 0; t < (tempList.Count > 50 ? 50 : tempList.Count); t++)
        {
            itmes.Add(tempList[t].GoodsNo);
        }


        return itmes;
    }
    #endregion
    
}
