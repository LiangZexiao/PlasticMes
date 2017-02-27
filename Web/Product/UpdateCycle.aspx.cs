using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.Model.BaseInfo_MDL;
using Admin.Model.Machine_MDL;
using Admin.BLL.Product_BLL;
using Admin.BLL.Machine_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.DBUtility;
using Admin.SQLServerDAL.GetErp;


public partial class Product_UpdateCycle : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Product_UpdateCycle));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "UpdateCycle");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible =  false;
            if (o[1]) igbInsert.Visible = igbNewadd.Visible = false;
            if (o[2]) igbUpdate.Visible = false;
            if (o[3]) igbDelete.Visible = igbCancel.Visible = false;
           
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            this.search.Disabled = true;
        }
    }
    
    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<UpdateCycle_MDL> tempList = new UpdateCycle_DAL().selectDispatchOrder(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    private void bindTxt(string DO_NO)
    {
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(DO_NO);
        this.txtWorkOrderNo.Text = tempList[0].WorkOrderNo;
        this.txtProductNo.Text = tempList[0].ProductNo;
        this.txtProductDesc.Text = tempList[0].ProductDesc;
        this.txtMouldNo.Text = tempList[0].MouldNo;
        this.txtMachineNo.Text = tempList[0].MachineNo;
        this.txtStandCycle.Text = tempList[0].StandCycle;
        this.txtMaxInjectionCycle.Value = tempList[0].MaxInjectionCycle;
        this.txtMinInjectionCycle.Value = tempList[0].MinInjectionCycle;

    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        string DO_NO = search.Value.Trim();
        bindTxt(DO_NO);
        string StandCycle=txtStandCycle.Text.Trim()==""?"0":txtStandCycle.Text.Trim();
        ArrayList myarr = GetMachineMstrMaxCycle(DO_NO);
        string MaxInjectionCycle = myarr[0].ToString() == "" ? "0" : myarr[0].ToString();
        string MinInjectionCycle = myarr[1].ToString() == "" ? "0" : myarr[1].ToString();
        string UpdateStandCycle = txtUpdateStandCycle.Text.Trim()==""?"0":txtUpdateStandCycle.Text.Trim();
        double cutnum = double.Parse(StandCycle) - double.Parse(UpdateStandCycle);
        string snum = DO_NO.Substring(DO_NO.Length - 3, 1);
        string UpdateMaxInjectionCycle = (snum == "0") ? Convert.ToString(double.Parse(MaxInjectionCycle) - cutnum) : "0";
        string UpdateMinInjectionCycle = (snum == "0") ? Convert.ToString(double.Parse(MinInjectionCycle) - cutnum) : "0";
        string UpdateTime = System.DateTime.Now.ToString("yyyy-MM-dd");
        string CreateTime = System.DateTime.Now.ToString("yyyy-MM-dd");
        string UpdateEmployee = this.Page.User.Identity.Name.Trim();
        string ProductNo = txtProductNo.Text.Trim();
        string ProductDesc = txtProductDesc.Text.Trim();
        string MachineNo = txtMachineNo.Text.Trim();
        string MouldNo = txtMouldNo.Text.Trim();


        if (IU == "INSERT")
        {
            if (new UpdateCycle_DAL().existsDispatchOrder(DO_NO).Count > 0)
            {
                dboSetCtrls.SetExecMsg(this, "此派工单数据已存在，不能新增!");
                return;
            }
            try
            {
                UpdateCycle_MDL up = new UpdateCycle_MDL(0, DO_NO, ProductNo, ProductDesc, MachineNo, MouldNo, StandCycle, MaxInjectionCycle, MinInjectionCycle, UpdateStandCycle, UpdateMaxInjectionCycle, UpdateMinInjectionCycle, UpdateTime, CreateTime, UpdateEmployee);
                UpdateCycle_MDL up2 = new UpdateCycle_MDL(DO_NO,ProductNo, ProductDesc, MachineNo, MouldNo,  UpdateStandCycle, UpdateMaxInjectionCycle, UpdateMinInjectionCycle);

                int t = new UpdateCycle_DAL().ChangeUpdateCycle(up, IU);
                bindTxt(DO_NO);
                if (t > 0)
                {
                    int t2 = new UpdateCycle_DAL().ChangeDispatchOrder(up2, IU);
                    if (t2 > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                        return;
                    }
                    else
                    {
                        new UpdateCycle_DAL().deleteUpdateCycle(DO_NO);
                        dboSetCtrls.SetExecMsg(this, IU, false);
                        return;
                    }
                }
                else
                {
                    dboSetCtrls.SetExecMsg(this, IU, false);
                    return;
                }
            }
            catch
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }
        }
        else if (IU == "UPDATE")
        {
            try
            {
               // UpdateCycle_MDL up = new UpdateCycle_MDL(0, DO_NO, StandCycle, MaxInjectionCycle, MinInjectionCycle, UpdateStandCycle, UpdateMaxInjectionCycle, UpdateMinInjectionCycle, UpdateTime, CreateTime, UpdateEmployee);
                //UpdateCycle_MDL up2 = new UpdateCycle_MDL(DO_NO, UpdateStandCycle, UpdateMaxInjectionCycle, UpdateMinInjectionCycle);
                int y = new UpdateCycle_DAL().UpdateDispatchOrder(ProductNo, UpdateStandCycle, UpdateMaxInjectionCycle, UpdateMinInjectionCycle, UpdateTime,UpdateEmployee);
                //int t = new UpdateCycle_DAL().ChangeUpdateCycle(up, IU);
                //int t2 = new UpdateCycle_DAL().ChangeDispatchOrder(up2, IU);
                bindTxt(DO_NO);
                if (y > 0)
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
            catch
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }
        }
        BindData();
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
    
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {

                pIDList.Add(txtID.Text.Trim());
                new UpdateCycle_DAL().cancelDispatchOrder(pIDList);

            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                new UpdateCycle_DAL().cancelDispatchOrder(pIDList);
                BindData();
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }
    
    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete);
            object[] textboxid = { txtWorkOrderNo, txtProductNo, txtStandCycle, txtProductDesc, txtMachineNo, txtMouldNo };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            search.Value = "";
            this.search.Disabled = false;
            this.txtUpdateStandCycle.Text = "";
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
        }
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Controls[0]) as LinkButton).Text.Trim();
       
        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete);

        this.search.Disabled = true;
        IList<UpdateCycle_MDL> tempIList = new UpdateCycle_DAL().selectDispatchOrder("do.DO_NO", vID);
        this.search.Value = tempIList[0].DO_NO;
        this.txtWorkOrderNo.Text = tempIList[0].WorkOrderNo;
        this.txtProductNo.Text = tempIList[0].ProductNo;
        this.txtProductDesc.Text = tempIList[0].ProductDesc;
        this.txtMouldNo.Text = tempIList[0].MouldNo;
        this.txtMachineNo.Text = tempIList[0].MachineNo;
        this.txtStandCycle.Text = tempIList[0].StandCycle;
        this.txtUpdateStandCycle.Text = tempIList[0].UpdateStandCycle;
        this.txtMaxInjectionCycle.Value = tempIList[0].MaxInjectionCycle;
        this.txtMinInjectionCycle.Value = tempIList[0].MinInjectionCycle;
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
   
    #region //给工单号和派工单号赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str, string cloIndex)
    {
        str = str.Trim();
        ArrayList itmes = new ArrayList();
        if (cloIndex == "-1")//工单号赋值
        {

            string workorderno = DispatchOrder_BLL.existsDispatchOrder(str, "DO_NO").Count == 0 ? "" : DispatchOrder_BLL.existsDispatchOrder(str, "DO_NO")[0].WorkOrderNo;

            itmes.Add(workorderno);
        }
        else  //查询派工单
        {
            IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.selectDispatchOrder(0, "-11", "DO_NO", str);
            for (int t = 0; t < tempList.Count;t++ )
            {
                string do_no = tempList[t].DO_No;
                //if (do_no.Substring(do_no.Length - 3, 1) == "0")
                //{
                    itmes.Add(do_no);
                //}
            }
        }

        return itmes;
    }
    #endregion

    #region //派工数量
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhValues(string str)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds = new GetErpItm().QueryErpDispatchDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);
        double number = double.Parse(ds.Tables[0].Rows[0][2].ToString());
        int t = (Int32)number;
        itmes.Add(t.ToString());

        return itmes;
    }
    #endregion

    #region 给产品编号 产品描述赋值
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhSetValues(string str, string flage)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(str);
        string itemStr1="";
        if (flage.ToString() == "1")
        {
            itemStr1 = tempList[0].ProductNo;
        }
        else
        {
            itemStr1 = tempList[0].ProductDesc;
        }
        itmes.Add(itemStr1);
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }
    #endregion

    #region  查询模具
    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMstr(string str)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(str);
        string itemStr1 = "";
        itemStr1 = tempList[0].MouldNo;
        itmes.Add(itemStr1);
        return itmes;
    }
    #endregion

    #region 查询机器
    [Ajax.AjaxMethod()]
    public ArrayList GetMachineMstr(string DO_NO)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(DO_NO);
        string itemStr1 = "";
        itemStr1 = tempList[0].MachineNo;
        itmes.Add(itemStr1);
        return itmes;
    }
    #endregion

    #region 查询模具标准周期
    [Ajax.AjaxMethod()]
    public ArrayList GetMouldStandCycle(string DO_NO)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(DO_NO);
        string itemStr1 = "";
        itemStr1 = tempList[0].StandCycle;
        itmes.Add(itemStr1);
        return itmes;
    }
    #endregion
    
    #region 查询模具标准周期
    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMaxORMinStandCycle(string DO_NO)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(DO_NO);
        string itemStr1 = "";
        itemStr1 = tempList[0].MaxInjectionCycle;
        itmes.Add(itemStr1); 
        itemStr1 = tempList[0].MinInjectionCycle;
        itmes.Add(itemStr1);
        return itmes;
    }
    #endregion

    #region 查询模具最大最小周期
    public ArrayList GetMachineMstrMaxCycle(string DO_NO)
    {
        ArrayList itmes = new ArrayList();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(DO_NO);
        itmes.Add(tempList[0].MaxInjectionCycle);
        itmes.Add(tempList[0].MinInjectionCycle);
        return itmes;
    }
    #endregion
}
