using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Machine_MDL;
using Admin.Model.Product_MDL;
//using Admin.BLL.Machine_BLL;
using Admin.BLL.Product_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class BaseInfo_MouldDetail : System.Web.UI.Page
{
    bool[] o = new bool[5] { false, false, false, false, false  };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"Machine/MouldDetail.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MouldMstr");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible =igbNewadd.Visible= false;
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
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            //dboSetCtrls.SetDropDownList(ddlProductNo, ItemMstr_BLL.selectItemMstr(0, "", "") as IList, false, "Item_Code", "Item_Code");

            IList<MachineMstr_MDL> tempIList = MachineMstr_BLL.selectMachineMstr(0, "", "");
           
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        if (Request.QueryString["MouldNo"]!=null && Request.QueryString["MouldNo"].ToString().Trim() != "")
        {
            colname = "Mould_Code";
            coltext = Request.QueryString["MouldNo"].ToString().Trim();
            igbNewadd.Visible = false;
            igbCancel.Visible = false;
            igbInsert.Visible = false;
            igbUpdate.Visible = false;
            igbDelete.Visible = false;
        }

        IList<MouldDetail_MDL> tempList = MouldDetail_BLL.selectMouldDetail(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string Mould_Code = txtMould_Code.Text.Trim().ToString();
        string Mould_Desc = txtMould_Desc.Text.Trim().ToString();
        string Clip_Code = txtClip_Code.Text.Trim().ToString();
        string Clip_Desc = txtClip_Desc.Text.Trim().ToString();
        string Clip_UsedNum = txtClip_UsedNum.Text.Trim().ToString() == "" ? "0" : txtClip_UsedNum.Text.Trim().ToString();
        string GoodsNo = txtGoodsNo.Text.Trim();
        string Mould_SpecialFittingsNo = rblMould_SpecialFittingsNo.SelectedValue.ToString();
        string Mould_Manufacturer = txtMould_Manufacturer.Text.Trim().ToString();
        string Mould_MadeDate = txtMould_MadeDate.Value.ToString();
        string Mould_CopyRight = rblMould_CopyRight.SelectedValue.ToString();
        string SocketNum = txtSocketNum.Text.Trim().ToString() == "" ? "0" : txtSocketNum.Text.Trim().ToString();
        string GoodSocketNum = txtGoodSocketNum.Text.Trim().ToString()==""?"0":txtGoodSocketNum.Text.Trim().ToString();
        string FitMachineG = txtFitMachineG1.Text.Trim().ToString();
        string PositioningHoleDiameter = txtPositioningHoleDiameter.Text.Trim().ToString() == "" ? "0" : txtPositioningHoleDiameter.Text.Trim().ToString();
        string RefBadRate = txtRefBadRate.Text.Trim().ToString() == "" ? "0" : txtRefBadRate.Text.Trim().ToString();
        string LostMaterialRate = txtLostMaterialRate.Text.Trim().ToString() == "" ? "0" : txtLostMaterialRate.Text.Trim().ToString();
        string InjectionCycle = txtInjectionCycle.Text.Trim().ToString() == "" ? "0" : txtInjectionCycle.Text.Trim().ToString();
        string MinInjectionCycle = txtMinInjectionCycle.Text.Trim().ToString() == "" ? "0" : txtMinInjectionCycle.Text.Trim().ToString();
        string MaxInjectionCycle = txtMaxInjectionCycle.Text.Trim().ToString() == "" ? "0" : txtMaxInjectionCycle.Text.Trim().ToString();
        string MachineCycle = txtMachineCycle.Text.Trim().ToString() == "" ? "0" : txtMachineCycle.Text.Trim().ToString();
        string Mould_InjectPress = txtMould_InjectPress.Text.Trim().ToString() == "" ? "0" : txtMould_InjectPress.Text.Trim().ToString();
        string Mould_ShotTemp = txtMould_ShotTemp.Text.Trim() == "" ? "0" : txtMould_ShotTemp.Text.Trim();
        string Mould_Lenght = txtMould_Lenght.Text.Trim().ToString() == "" ? "0" : txtMould_Lenght.Text.Trim().ToString();
        string Mould_Width = txtMould_Width.Text.Trim().ToString() == "" ? "0" : txtMould_Width.Text.Trim().ToString();
        string Mould_Thickth = txtMould_Thickth.Text.Trim().ToString() == "" ? "0" : txtMould_Thickth.Text.Trim().ToString();
        string Mould_Weight = txtMould_Weight.Text.Trim().ToString() == "" ? "0" : txtMould_Weight.Text.Trim().ToString();
        string Mould_PushDistance = txtMould_PushDistance.Text.Trim().ToString() == "" ? "0" : txtMould_PushDistance.Text.Trim().ToString();
        string TemplateDistance = txtTemplateDistance.Text.Trim().ToString() == "" ? "0" : txtTemplateDistance.Text.Trim().ToString();
        string TackOutFunction = rblTackOutFunction.SelectedValue.ToString();
        string Robort = rblRobort.SelectedValue.ToString();
        string RobortProgram = txtRobortProgram.Text.Trim().ToString();
        string ShotLenghten = rblShotLenghten.Text.Trim().ToString();
        string ProtectCycle = txtProtectCycle.Text.Trim().ToString() == "" ? "0" : txtProtectCycle.Text.Trim().ToString();
        string MouldStatus = ddlMouldStatus.Text.Trim().ToString();
        string WarehouseLocation = txtWarehouseLocation.Text.Trim().ToString();
        string ModiRecord = txtModiRecord.Text.Trim(); ;
        string LastModifier = this.Page.User.Identity.Name.Trim();
        string LastModiDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        string Ver = txtVer.Text.Trim().ToString();
        string Lu_law_Table = txtLu_law_Table.Text.Trim(); ;
        string Remark = txtRemark.Text.Trim().ToString();
        string Mould_Fixture = txtMould_Fixture.Text.Trim().ToString() == "" ? "0" : txtMould_Fixture.Text.Trim().ToString();
        string Mould_Soaked = txtMould_Soaked.Text.Trim().ToString() == "" ? "0" : txtMould_Soaked.Text.Trim().ToString();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";

        if (IU == "UPDATE")
        {
            ArrayList myArrListNew = new ArrayList();
            ArrayList myItemMstrName = new ArrayList();
            myItemMstrName.Add("模具编号");
            myItemMstrName.Add("模具描述");
            myItemMstrName.Add("夹具编号");
            myItemMstrName.Add("夹具描述");
            myItemMstrName.Add("夹具用量");
            myItemMstrName.Add("模具货号");
            myItemMstrName.Add("镶件");
            myItemMstrName.Add("生产厂商");
            myItemMstrName.Add("制造日期");
            myItemMstrName.Add("模具所有权");
            myItemMstrName.Add("模穴个数");
            myItemMstrName.Add("可用模穴个数");
            myItemMstrName.Add("适用机型(g)");
            myItemMstrName.Add("定位圈直径");
            myItemMstrName.Add("参考不良率");
            myItemMstrName.Add("原料损耗率");
            myItemMstrName.Add("标准周期");
            myItemMstrName.Add("最小周期");
            myItemMstrName.Add("最大周期");
            myItemMstrName.Add("机器周期");
            myItemMstrName.Add("注塑压力");
            myItemMstrName.Add("注塑温度");
            myItemMstrName.Add("模具尺寸");
            myItemMstrName.Add("模具重量");
            myItemMstrName.Add("顶出行程");
            myItemMstrName.Add("开模间距");
            myItemMstrName.Add("抽芯功能");
            myItemMstrName.Add("机械手");
            myItemMstrName.Add("机械手程序");
            myItemMstrName.Add("加长射嘴");
            myItemMstrName.Add("保养周期");
            myItemMstrName.Add("模具状态");
            myItemMstrName.Add("模具库位");
            myItemMstrName.Add("版本");

            ArrayList myArrListOld = Session["MouldDetailArrListOld"] as ArrayList;

            myArrListNew.Add(Mould_Code);
            myArrListNew.Add(Mould_Desc);
            myArrListNew.Add(Clip_Code);
            myArrListNew.Add(Clip_Desc);
            myArrListNew.Add(Clip_UsedNum);
            myArrListNew.Add(GoodsNo);
            myArrListNew.Add(Mould_SpecialFittingsNo);
            myArrListNew.Add(Mould_Manufacturer);
            myArrListNew.Add(Mould_MadeDate);
            myArrListNew.Add(Mould_CopyRight);
            myArrListNew.Add(SocketNum);
            myArrListNew.Add(GoodSocketNum);
            myArrListNew.Add(FitMachineG);
            myArrListNew.Add(PositioningHoleDiameter);
            myArrListNew.Add(RefBadRate);
            myArrListNew.Add(LostMaterialRate);
            myArrListNew.Add(InjectionCycle);
            myArrListNew.Add(MinInjectionCycle);
            myArrListNew.Add(MaxInjectionCycle);
            myArrListNew.Add(MachineCycle);
            myArrListNew.Add(Mould_InjectPress);
            myArrListNew.Add(Mould_ShotTemp);
            myArrListNew.Add(Mould_Lenght + Mould_Width + Mould_Thickth);
            //myArrListNew.Add(Mould_Width);
            //myArrListNew.Add(Mould_Thickth);
            myArrListNew.Add(Mould_Weight);
            myArrListNew.Add(Mould_PushDistance);
            myArrListNew.Add(TemplateDistance);
            myArrListNew.Add(TackOutFunction);
            myArrListNew.Add(Robort);
            myArrListNew.Add(RobortProgram);
            myArrListNew.Add(ShotLenghten);
            myArrListNew.Add(ProtectCycle);
            myArrListNew.Add(MouldStatus);
            myArrListNew.Add(WarehouseLocation);
            myArrListNew.Add(Ver);

            string vModiHistoryContentx = "";
            for (int i = 0; i < myArrListNew.Count; i++)
            {
               
                if (myArrListOld[i].ToString().Trim() != myArrListNew[i].ToString().Trim())
                {
                    vModiHistoryContentx += myItemMstrName[i].ToString() +":"+ myArrListOld[i].ToString() + "-->" + myArrListNew[i].ToString() + ((i==myArrListNew.Count-1)?"；":",");
                }
            }

            if (vModiHistoryContentx != "")
            {
                vModiHistoryContentx = System.DateTime.Now.ToString("yyyy-MM-dd") + " " +  this.Page.User.Identity.Name.Trim()  + " " + vModiHistoryContentx;

                ModiRecord = vModiHistoryContentx + ModiRecord;
            }
        }

        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (MouldDetail_BLL.existsMouldDetail(Mould_Code).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的模具编号!!");
                    return;
                }
            }
            MouldDetail_BLL.ChangeMouldDetail(vID,
                Mould_Code, Mould_Desc, Clip_Code, Clip_Desc, Clip_UsedNum,GoodsNo, Mould_SpecialFittingsNo, Mould_Manufacturer, Mould_MadeDate, Mould_CopyRight, SocketNum, GoodSocketNum, FitMachineG,
                PositioningHoleDiameter, RefBadRate, LostMaterialRate, InjectionCycle, MinInjectionCycle, MaxInjectionCycle,MachineCycle, Mould_InjectPress,Mould_ShotTemp, Mould_Lenght, Mould_Width, Mould_Thickth, Mould_Weight, Mould_PushDistance,
                TemplateDistance, TackOutFunction, Robort, RobortProgram, ShotLenghten, ProtectCycle, MouldStatus, WarehouseLocation, ModiRecord, LastModifier, LastModiDate, Ver, Lu_law_Table, Remark
                ,Mould_Soaked,Mould_Fixture,IU);
           dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
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
                MouldDetail_BLL.cancelMouldDetail(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                MouldDetail_BLL.cancelMouldDetail(pIDList);
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
            //o[1].ToString(); o[2].ToString();
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "TEXTBOX", txtMould_Code);


            object[] textboxid = {txtClip_Code,txtClip_Desc,txtClip_UsedNum,txtFitMachineG1,txtGoodSocketNum,txtInjectionCycle,txtLostMaterialRate,
                txtMaxInjectionCycle,txtMinInjectionCycle,txtMould_Code,txtMould_Desc,txtMachineCycle,txtMould_InjectPress,txtMould_Lenght,txtMould_Manufacturer,txtMould_PushDistance,
                txtMould_ShotHoleDiameter,txtMould_Thickth,txtMould_Weight,txtMould_Width,txtPositioningHoleDiameter,txtProtectCycle,txtRefBadRate,txtRemark,txtRobortProgram,txtSocketNum,txtTemplateDistance,
                txtWarehouseLocation,txtMould_Soaked,txtMould_Fixture};
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            txtMould_MadeDate.Value = txtGoodsNo.Text = "";
            //ddlProductNo.SelectedIndex = 0;
            rblMould_SpecialFittingsNo.SelectedIndex = rblMould_SpecialFittingsNo.SelectedIndex = rblRobort.SelectedIndex = rblShotLenghten.SelectedIndex = rblTackOutFunction.SelectedIndex = 0;
            rblMould_CopyRight.SelectedIndex = 1;
            ddlMouldStatus.SelectedIndex = 0;
            txtLu_law_Table.Text =txtModiRecord.Text=  txtMould_ShotTemp.Text="";
            txtVer.Text = "1";
        }
        else if (tempButton.ID == "btnPrint")
        {
            this.ClientScript.RegisterClientScriptBlock(GetType(), "open",
            @"<script> window.open('../repPrinter.aspx?ReportName=ProductMstr&ReportType=1') </script>");
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
        }
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        MultiView1.ActiveViewIndex = 1;

        //o[1].ToString(); o[2].ToString();
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "TEXTBOX", txtMould_Code);
        IList<MouldDetail_MDL> tempIList = MouldDetail_BLL.selectMouldDetail(Int32.Parse(vID), "", "");

        txtMould_Code.Enabled = true;
        ArrayList myArrListOld = new ArrayList();
         myArrListOld.Add( tempIList[0].MouldCode);
         myArrListOld.Add( tempIList[0].MouldDesc);
         myArrListOld.Add( tempIList[0].ClipCode);
         myArrListOld.Add( tempIList[0].ClipDesc);
         myArrListOld.Add( tempIList[0].ClipUsedNum);
         myArrListOld.Add( tempIList[0].GoodsNo);
         myArrListOld.Add( tempIList[0].MouldSpecialFittingsNo);
         myArrListOld.Add( tempIList[0].MouldManufacturer);
         myArrListOld.Add( tempIList[0].MouldMadeDate);
         myArrListOld.Add( tempIList[0].MouldCopyRight);

         myArrListOld.Add( tempIList[0].SocketNum);
         myArrListOld.Add( tempIList[0].GoodSocketNum);
         myArrListOld.Add( tempIList[0].FitMachineG);
         myArrListOld.Add( tempIList[0].PositioningHoleDiameter);
         myArrListOld.Add( tempIList[0].RefBadRate);
         myArrListOld.Add( tempIList[0].LostMaterialRate);
         myArrListOld.Add( tempIList[0].InjectionCycle);
         myArrListOld.Add( tempIList[0].MinInjectionCycle);
         myArrListOld.Add( tempIList[0].MaxInjectionCycle);
         myArrListOld.Add( tempIList[0].MachineCycle);
         myArrListOld.Add(tempIList[0].MouldInjectPress);
         myArrListOld.Add(tempIList[0].Mould_ShotTemp);
         myArrListOld.Add(tempIList[0].MouldLenght + tempIList[0].MouldWidth + tempIList[0].MouldThickth);
         //myArrListOld.Add( tempIList[0].MouldWidth);
         //myArrListOld.Add( tempIList[0].MouldThickth);
         myArrListOld.Add( tempIList[0].MouldWeight);
         myArrListOld.Add( tempIList[0].MouldPushDistance);
         myArrListOld.Add( tempIList[0].TemplateDistance);
         myArrListOld.Add( tempIList[0].TackOutFunction);
         myArrListOld.Add( tempIList[0].Robort);
         myArrListOld.Add( tempIList[0].RobortProgram);
         myArrListOld.Add( tempIList[0].ShotLenghten);
         myArrListOld.Add( tempIList[0].ProtectCycle);
         myArrListOld.Add( tempIList[0].MouldStatus);
         myArrListOld.Add( tempIList[0].WarehouseLocation);
         myArrListOld.Add( tempIList[0].Ver);
        Session["MouldDetailArrListOld"] = myArrListOld;



        txtID.Text = hdnID.Value = vID;
        txtMould_Code.Text = tempIList[0].MouldCode;
        txtMould_Desc.Text = tempIList[0].MouldDesc;
        txtClip_Code.Text = tempIList[0].ClipCode;
        txtClip_Desc.Text = tempIList[0].ClipDesc;
        txtClip_UsedNum.Text = tempIList[0].ClipUsedNum;
        txtGoodsNo.Text = tempIList[0].GoodsNo;
        rblMould_SpecialFittingsNo.SelectedValue = tempIList[0].MouldSpecialFittingsNo;
        txtMould_Manufacturer.Text = tempIList[0].MouldManufacturer;
        txtMould_MadeDate.Value = tempIList[0].MouldMadeDate;
        rblMould_CopyRight.SelectedValue = tempIList[0].MouldCopyRight;

        txtSocketNum.Text = tempIList[0].SocketNum;
        txtGoodSocketNum.Text = tempIList[0].GoodSocketNum;
        txtFitMachineG1.Text = tempIList[0].FitMachineG;
        txtPositioningHoleDiameter.Text = tempIList[0].PositioningHoleDiameter;
        txtRefBadRate.Text = tempIList[0].RefBadRate;
        txtLostMaterialRate.Text = tempIList[0].LostMaterialRate;
        txtInjectionCycle.Text = tempIList[0].InjectionCycle;
        txtMinInjectionCycle.Text = tempIList[0].MinInjectionCycle;
        txtMaxInjectionCycle.Text = tempIList[0].MaxInjectionCycle;
        txtMachineCycle.Text = tempIList[0].MachineCycle;
        txtMould_InjectPress.Text = tempIList[0].MouldInjectPress;
        txtMould_ShotTemp.Text = tempIList[0].Mould_ShotTemp;
        txtMould_Lenght.Text = tempIList[0].MouldLenght;
        txtMould_Width.Text = tempIList[0].MouldWidth;
        txtMould_Thickth.Text = tempIList[0].MouldThickth;
        txtMould_Weight.Text = tempIList[0].MouldWeight;
        txtMould_PushDistance.Text = tempIList[0].MouldPushDistance;
        txtTemplateDistance.Text = tempIList[0].TemplateDistance;
        rblTackOutFunction.SelectedValue = tempIList[0].TackOutFunction;
        rblRobort.SelectedValue = tempIList[0].Robort;
        txtRobortProgram.Text = tempIList[0].RobortProgram;
        rblShotLenghten.Text = tempIList[0].ShotLenghten;
        txtProtectCycle.Text = tempIList[0].ProtectCycle;
        ddlMouldStatus.Text = tempIList[0].MouldStatus;
        txtWarehouseLocation.Text = tempIList[0].WarehouseLocation;
        txtVer.Text = tempIList[0].Ver;
        txtRemark.Text = tempIList[0].Remark;
        txtMould_Fixture.Text = tempIList[0].Mould_Fixture;
        txtMould_Soaked.Text = tempIList[0].Mould_Soaked;
        txtModiRecord.Text = tempIList[0].ModiRecord;
        txtLu_law_Table.Text = tempIList[0].Lu_lawTable;
    }

   
}

