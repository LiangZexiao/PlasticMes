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
using System.IO;
using Admin.App_Code;
using Admin.SQLServerDAL.Call_DAL;
using Admin.Model.Product_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.SQLServerDAL;
using Admin.SQLServerDAL.GetErp;

public partial class Product_SuitManage : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    private SuitManage_DAL SuitManage = new SuitManage_DAL();
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Product_SuitManage));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "SuitManage");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnNewadd.Visible = btnInsert.Visible = false;
            if (o[2])  btnUpdate.Visible = false;
            if (o[3]) btnCancel.Visible = btnDelete.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            string sts = "";
            try
            {
                sts = Request.QueryString["ItemMstrID"].ToString();
            }
            catch
            {
                sts = "";
            }
            finally
            {
            }
            if (sts != "")
            {
                MultiView1.ActiveViewIndex = 1;
                bindBtn(sts);
                //this.search.Disabled = true;
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
                dataBind();
                //igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
                //igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
                //igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
                //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
                //dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "Mould_Code", "Mould_Code");
                //dboSetCtrls.SetDropDownList(ddlCustomerNo, CustomerInfo_BLL.selectCustomerInfo(0, "", "") as IList, false, "CustomerNo", "CustomerName");
            }
            //this.MultiView1.ActiveViewIndex = 0;
           // dataBind();
            // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlSuitMachine, new MachineSuit_DAL().selectMachineSuit(0, "", "") as IList, false, "MachineCode", "MachineCode");
            btnCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            btnUpdate.Attributes.Add("onclick", "updateClick()");

        }
    }

    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.Trim().ToString();
        string coltext = txtQuery.Text.Trim().ToString();
        
        IList<SuitManage_MDL> tempList = SuitManage.selectSuitManage(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }
    protected void btnVisible_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "btnNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtID);
           // this.ddlMachineNo.SelectedValue = "";
           /// this.ddlUnit.SelectedValue = "";
           // this.txtCycle.Text = "";
            // this.txtNum.Text = "";
            ddlSuitMachine.SelectedIndex = 0; //tempList[0].SuitType;   //适用类型
           
            txtBrushWireTypeCode.Text = txtStandEmployee.Text = txtCutLength.Text = txtGetKnifeFoot.Text = txtHoleDiameter.Text =
            txtHoleNum.Text = txtModiHeight.Text =   txtPlantBristlesDesc.Text = txtRally.Text =txtTrayNum.Text=txtColumnCount.Text=txtColumnNum.Text=
            txtWireBrushMould.Text=txtWireBrushMouldDesc.Text= txtRemark.Text = txtSystemNo.Text =  txtWireBrushWeight.Text = txtWireDesc.Text = txtWireTypeCode.Text = txtWireWeight.Text = "";
            ddlOutNum.SelectedIndex = 1;
            search.Value = "";
            Image1.ImageUrl = null;
            this.search.Disabled = false;
        }
        else
        {
            if (tempButton.ID != "btnQuery")
                MultiView1.ActiveViewIndex = 0;
            dataBind();
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
        dataBind();
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            int t = 0;
            if (tempButton.ID == "btnDelete")
            {
                pIDList.Add(txtID.Text.Trim());
                // ItemMstr_BLL.cancelItemMstr(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                // t = new WorkPaper_DAL().cancelItemMstr(pIDList);
                // ItemMstr_BLL.cancelItemMstr(pIDList);                
            }
            t = SuitManage.DeleteMachineSuit(pIDList);
            dataBind();
            if (t > 0)
            {
                dboSetCtrls.SetExecMsg(this, "delete", true);
            }
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton   = sender as ImageButton;

      

        string vID = txtID.Text.Trim() == "" ? "0" : txtID.Text.Trim();
        string PlantBristlesCode = search.Value.Trim();// txtPlantBristlesCode.Text.Trim();
        string PlantBristlesDesc = txtPlantBristlesDesc.Text.Trim();
        string WireBrushMould = txtWireBrushMould.Text.Trim();// txtWireBrushMould.Value.Trim();
        string WireBrushMouldDesc = txtWireBrushMouldDesc.Text.Trim();
        string SuitMachine       = ddlSuitMachine.SelectedValue;
        string HoleNum = (txtHoleNum.Text.Trim() == "") ? "0" : txtHoleNum.Text.Trim();
        string HoleDiameter      = (txtHoleDiameter.Text.Trim()=="" )? "0" :txtHoleDiameter.Text.Trim();
        string WireBrushWeight = (txtWireBrushWeight.Text.Trim() == "") ? "0" : txtWireBrushWeight.Text.Trim();
        string WireWeight = (txtWireWeight.Text.Trim() == "") ? "0" : txtWireWeight.Text.Trim();
        string SystemNo          = txtSystemNo.Text.Trim();
        string CutLength = (txtCutLength.Text.Trim() == "") ? "0" : txtCutLength.Text.Trim();
        string OutNum = ddlOutNum.SelectedValue.ToString();// (txtOutNum.Text.Trim() == "") ? "0" : txtOutNum.Text.Trim();
        string GetKnifeFoot      = txtGetKnifeFoot.Text.Trim();
        string StandEmployee = txtStandEmployee.Text.Trim();
        string WireTypeCode      = txtWireTypeCode.Text.Trim();
        string WireDesc          = txtWireDesc.Text.Trim();
        string ModiHeight        = txtModiHeight.Text.Trim();
        string BrushWireTypeCode = txtBrushWireTypeCode.Text.Trim();
        string Rally             = txtRally.Text.Trim();
        string TrayNum = txtTrayNum.Text.Trim() == "" ? "0" : txtTrayNum.Text.Trim();
        string ColumnNum = txtColumnNum.Text.Trim() == "" ? "0" : txtColumnNum.Text.Trim();
        string ColumnCount = txtColumnCount.Text.Trim() == "" ? "0" : txtColumnCount.Text.Trim();
        string VerModiReason = txtVerModiReason.Text;//版本更新原因
        string VerModiContent = txtVerModiContent.Text;//修改记录
         //***********************
        //产品图片
        HttpPostedFile hpf = fudProcessPhoto.PostedFile;
        object vImgType = hpf.ContentType;//图片类型
        int ImgLength = hpf.ContentLength;
        byte[] ProductImg = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            ProductImg = new GifOrJpg().MakeSmallImg(tempStream, 245, 160);//new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            ProductImg = new byte[0];
        }

        //*************************
        string Ver               = txtVer.Text.Trim();        
       
        string Remark            = txtRemark.Text.Trim();
        string LastUpdator = this.Page.User.Identity.Name.Trim();
        string LastUpdateDate= System.DateTime.Now.ToString("yyyy-MM-dd");
        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";
        if (UI == "UPDATE")
        {
            ArrayList myArrListNew = new ArrayList();
            ArrayList myItemMstrName = new ArrayList();
            myItemMstrName.Add("产品编号:");
            myItemMstrName.Add("产品描述:");
            myItemMstrName.Add("植毛模具:");
            myItemMstrName.Add("模具描述:");
            myItemMstrName.Add("适应机型:");
            myItemMstrName.Add("孔数:");
            myItemMstrName.Add("孔径:");
            myItemMstrName.Add("植毛刷丝重:");
            myItemMstrName.Add("铁丝重:");
            myItemMstrName.Add("系统编号:");
            myItemMstrName.Add("切毛长度:");
            myItemMstrName.Add("出模数:");
            myItemMstrName.Add("取毛刀:");
            myItemMstrName.Add("人员需求:");
            myItemMstrName.Add("铁丝编码:");
            myItemMstrName.Add("铁丝编码描述:");
            myItemMstrName.Add("修毛高度:");
            myItemMstrName.Add("刷丝编码:");
            myItemMstrName.Add("拉力:");
            myItemMstrName.Add("托盘数:");
            myItemMstrName.Add("每层数量:");
            myItemMstrName.Add("版本:" );
            myItemMstrName.Add("层数:");

            ArrayList myArrListOld = Session["SuitManagemyArrListOld"] as ArrayList;

            myArrListNew.Add( PlantBristlesCode);
            myArrListNew.Add( PlantBristlesDesc);
            myArrListNew.Add( WireBrushMould);
            myArrListNew.Add( WireBrushMouldDesc);
            myArrListNew.Add( SuitMachine);
            myArrListNew.Add( HoleNum);
            myArrListNew.Add( HoleDiameter);
            myArrListNew.Add( WireBrushWeight);
            myArrListNew.Add( WireWeight);
            myArrListNew.Add( SystemNo);
            myArrListNew.Add( CutLength);
            myArrListNew.Add( OutNum);
            myArrListNew.Add( GetKnifeFoot);
            myArrListNew.Add( StandEmployee);
            myArrListNew.Add( WireTypeCode);
            myArrListNew.Add( WireDesc);
            myArrListNew.Add( ModiHeight);
            myArrListNew.Add( BrushWireTypeCode);
            myArrListNew.Add( Rally);
            myArrListNew.Add( TrayNum);
            myArrListNew.Add( ColumnNum);
            myArrListNew.Add( Ver);
            myArrListNew.Add( ColumnCount);

            string vModiHistoryContentx = "";
            for (int i = 0; i < myArrListNew.Count ; i++)
            {
                string asa = myArrListOld[i].ToString().Trim();
                string asa2 = myArrListNew[i].ToString().Trim();
                if (myArrListOld[i].ToString().Trim() != myArrListNew[i].ToString().Trim())
                {
                    vModiHistoryContentx += myItemMstrName[i].ToString() + myArrListOld[i].ToString() + "-->" + myArrListNew[i].ToString() + ((i == myArrListNew.Count - 1) ? "；" : ",");
                }
            }

            if (vModiHistoryContentx != "")
            {
                vModiHistoryContentx = System.DateTime.Now.ToString("yyyy-MM-dd") + " " + this.Page.User.Identity.Name.Trim()  + " " + vModiHistoryContentx;

                VerModiContent = vModiHistoryContentx + VerModiContent;
            }
            if (myArrListOld[0].ToString().Trim() != myArrListNew[0].ToString().Trim())
            {
                UI = "INSERT";
                VerModiContent = "";
            }
        }
        try
        {
            SuitManage_MDL call = new SuitManage_MDL(int.Parse(vID), PlantBristlesCode, PlantBristlesDesc,WireBrushMould,WireBrushMouldDesc, SuitMachine, HoleNum, HoleDiameter,
                              WireBrushWeight, WireWeight, SystemNo, CutLength, OutNum, GetKnifeFoot,
                              StandEmployee, WireTypeCode, WireDesc, ModiHeight, BrushWireTypeCode, Rally,TrayNum,ColumnNum,ColumnCount,
                              ProductImg, Ver, VerModiContent, VerModiReason, LastUpdator, LastUpdateDate, Remark);
            if (UI == "INSERT")
            {
                if (SuitManage.existsPlantBristlesCode(PlantBristlesCode, "PlantBristlesCode").Count > 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同产品编号!");
                    return;
                }
            }
            else
            {
                new SuitManage_DAL().DeleteMachineSuitDetail(PlantBristlesCode);
            }
            if (vImgType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            {
                dboSetCtrls.SetExecMsg(this, "产品图片只能是图片!");
                return;
            }
            else
            {
                if (((ImgLength + 10 * 1024) / 1024) > 209)
                {
                    dboSetCtrls.SetExecMsg(this, "产品图片大小不能大于200KB!");
                    return;
                }
            }
            if (SuitManage.InsertSuitManage(call, UI) == 1)
            {
                dboSetCtrls.SetExecMsg(this, UI, true);
                //BindData();
                if (UI == "INSERT")
                {
                    this.search.Disabled = false;
                    vID=new SuitManage_DAL().existsPlantBristlesCode(PlantBristlesCode, "plantBristlesCode")[0].ID.ToString();
                }
                Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=PlantBristlesProdInfo&ImgType=PhotoType&Img=ProductImg", vID);
                string[] strMouldCode = WireBrushMould.Split(',');
                string[] strMouldDesc = WireBrushMouldDesc.Split(',');
                //for (int i = 0; i < strMouldCode.Length; i++)
                //{
                //    Response.Write(strMouldCode[i].ToString());
                //}

                if (strMouldCode.Length > 0)
                {
                    SuitManage_MDL SuitManageDetail;
                    for (int i = 0; i < strMouldCode.Length; i++)
                    {
                        if (i >= strMouldDesc.Length)
                        {
                            SuitManageDetail = new SuitManage_MDL(int.Parse(vID), PlantBristlesCode, strMouldCode[i].ToString(), "", LastUpdateDate);
                        }
                        else
                        {
                            SuitManageDetail = new SuitManage_MDL(int.Parse(vID), PlantBristlesCode, strMouldCode[i].ToString(), strMouldDesc[i].ToString(), LastUpdateDate);
                        }
                        SuitManage.InsertSuitManageDetail(SuitManageDetail, "INSERT");
                    }
                }
                
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, UI, false);
            }

        }
        catch
        {
            // string temp = ex.ToString().Trim();
            // Response.Write(ex.Message);
            dboSetCtrls.SetExecMsg(this, UI, false);
        }
    }
    protected void igbwork_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn = sender as ImageButton;
        string item_code = search.Value.Trim();// txtItem_Code.Text.Trim().ToString();
        string item_id = txtID.Text.Trim().ToString();
        if (btn.ID != "igbbox")
        {
            Response.Redirect("~/Product/WorkPaper.aspx?types=2&Item_Code=" + item_code + "&id=" + item_id, true);
        }
        else
        {
            Response.Redirect("~/Product/PackageList.aspx?types=2&Item_Code=" + item_code + "&id=" + item_id, true);
        }
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
       // Page.RegisterStartupScript("IndexChecks", "<script>var updiv=document.getElementById(\"querydiv\");updiv.style.visibility = \"visible\";</script>");
        MultiView1.ActiveViewIndex = 1;

        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtID);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();
        bindBtn(vID);

    }
    void bindBtn(string vID)
    {

        IList<SuitManage_MDL> tempList = SuitManage.selectSuitManage(int.Parse(vID), "", "");

        ArrayList myArrListOld = new ArrayList();
        myArrListOld.Add(tempList[0].PlantBristlesCode);
        myArrListOld.Add(tempList[0].PlantBristlesDesc);
        myArrListOld.Add(tempList[0].WireBrushMould);
        myArrListOld.Add(tempList[0].WireBrushMouldDesc);
        myArrListOld.Add(tempList[0].SuitMachine);
        myArrListOld.Add(tempList[0].HoleNum);
        myArrListOld.Add(tempList[0].HoleDiameter);
        myArrListOld.Add(tempList[0].WireBrushWeight);
        myArrListOld.Add(tempList[0].WireWeight);
        myArrListOld.Add(tempList[0].SystemNo);
        myArrListOld.Add(tempList[0].CutLength);
        myArrListOld.Add(tempList[0].OutNum);
        myArrListOld.Add(tempList[0].GetKnifeFoot);
        myArrListOld.Add(tempList[0].StandEmployee);
        myArrListOld.Add(tempList[0].WireTypeCode);
        myArrListOld.Add(tempList[0].WireDesc);
        myArrListOld.Add(tempList[0].ModiHeight);
        myArrListOld.Add(tempList[0].BrushWireTypeCode);
        myArrListOld.Add(tempList[0].Rally);
        myArrListOld.Add(tempList[0].TrayNum);
        myArrListOld.Add(tempList[0].ColumnNum);
        myArrListOld.Add(tempList[0].Ver);
        myArrListOld.Add(tempList[0].ColumnCount);
        Session["SuitManagemyArrListOld"] = myArrListOld;

        search.Disabled = false;
        txtUpInput.Disabled = true;
        //txtPlantBristlesCode.Text
        search.Value = tempList[0].PlantBristlesCode;
        txtPlantBristlesDesc.Text = tempList[0].PlantBristlesDesc;
        txtWireBrushMould.Text = tempList[0].WireBrushMould;
        txtWireBrushMouldDesc.Text = tempList[0].WireBrushMouldDesc;
        ddlSuitMachine = dboSetCtrls.SetSelectedIndex(ddlSuitMachine, tempList[0].SuitMachine); ;
        txtHoleNum.Text = tempList[0].HoleNum;
        txtHoleDiameter.Text = tempList[0].HoleDiameter;
        txtWireBrushWeight.Text = tempList[0].WireBrushWeight;
        txtWireWeight.Text = tempList[0].WireWeight;
        txtSystemNo.Text = tempList[0].SystemNo;
        txtCutLength.Text = tempList[0].CutLength;
        //txtOutNum.Text=tempList[0].OutNum;
        ddlOutNum.SelectedValue = tempList[0].OutNum;
        txtGetKnifeFoot.Text = tempList[0].GetKnifeFoot;
        txtStandEmployee.Text = tempList[0].StandEmployee;
        txtWireTypeCode.Text = tempList[0].WireTypeCode;
        txtWireDesc.Text = tempList[0].WireDesc;
        txtModiHeight.Text = tempList[0].ModiHeight;
        txtBrushWireTypeCode.Text = tempList[0].BrushWireTypeCode;
        txtRally.Text = tempList[0].Rally;
        txtVer.Text = tempList[0].Ver;
        txtTrayNum.Text = tempList[0].TrayNum;
        txtColumnNum.Text = tempList[0].ColumnNum;
        txtColumnCount.Text = tempList[0].ColumnCount;
        //txtVerModiContent.Text = tempList[0].VerModiContent;
        //txtVerModiReason.Text = tempList[0].VerModiReason;
        txtRemark.Text = tempList[0].Remark;
        txtVerModiContent.Text = tempList[0].VerModiContent;
        hdnProdCode.Value = tempList[0].PlantBristlesCode;




        Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=PlantBristlesProdInfo&ImgType=PhotoType&Img=ProductImg", vID);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhItmes(string str)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds = new GetErpItm().QueryErp(str);  //ERPSQLExecutant().ExecQueryCmd(sql);


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            itmes.Add(dr[0]);
        }
       
        return itmes;
    }

    [Ajax.AjaxMethod()]
    public ArrayList GetSearhValues(string str)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds = new GetErpItm().QueryErpBomDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);

        string itemStr1 = ds.Tables[0].Rows[0][2].ToString();
        string itemStr2 = ds.Tables[0].Rows[0][2].ToString();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i][2].ToString().Substring(0, 1) == "3")
            {
                if (i != ds.Tables[0].Rows.Count - 1 && i!=0)
                    itmes.Add(ds.Tables[0].Rows[i][2].ToString() +" "+ ds.Tables[0].Rows[i][4].ToString() +" ,");
                else
                    itmes.Add(ds.Tables[0].Rows[i][2].ToString() + " " + ds.Tables[0].Rows[i][4].ToString());
            }
        }
        return itmes;
    }

    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMstr(string str)
    {
        ArrayList items = new ArrayList();


        IList<ClampManage_MDL> myList = new ClampManage_DAL().selectClampManage(0, "", "");//MouldDetail_BLL.selectMouldDetail(0, "", "");
        try
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (str == "1")
                {
                    items.Add(myList[i].FixtureCode + "    " + myList[i].FixtureDesc);
                }
                else
                {
                    items.Add(myList[i].FixtureDesc);
                }
            }
            return items;
        }
        catch (Exception ex)
        {
            string temp = ex.Message.ToString();
            return new ArrayList();
        }
    }
    [Ajax.AjaxMethod()]
    public ArrayList GetMould(string str,string types)
    {
        ArrayList items = new ArrayList();


        IList<ClampManage_MDL> myList = new ClampManage_DAL().selectClampManage(0, "FixtureDesc", str);//MouldDetail_BLL.selectMouldDetail(0, "", "");
        try
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (types == "1")
                {
                    items.Add(myList[i].FixtureCode + "    " + myList[i].FixtureDesc);
                }
                else
                {
                    items.Add(myList[i].FixtureDesc);
                }
            }
            return items;
        }
        catch (Exception ex)
        {
            string temp = ex.Message.ToString();
            return new ArrayList();
        }
    }
    [Ajax.AjaxMethod()]
    public ArrayList GetWireDetail(string str)
    {
        ArrayList items = new ArrayList();


        DataSet ds = new GetErpItm().QueryErpWireDetail();//MouldDetail_BLL.selectMouldDetail(0, "", "");
        try
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str == "1")
                {
                    items.Add(ds.Tables[0].Rows[i][0].ToString() + "    " + ds.Tables[0].Rows[i][1].ToString());
                }
                else
                {
                    items.Add(ds.Tables[0].Rows[i][1].ToString());
                }
            }
            return items;
        }
        catch (Exception ex)
        {
            string temp = ex.Message.ToString();
            return new ArrayList();
        }
    }

   
}
