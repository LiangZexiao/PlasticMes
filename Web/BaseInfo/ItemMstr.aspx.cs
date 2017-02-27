using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Product_MDL;
using Admin.Model.BaseInfo_MDL;
using Admin.Model.Machine_MDL;
using Admin.BLL.Product_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL;
using Admin.SQLServerDAL.GetErp;
using System.IO;
using Admin.SQLServerDAL.BaseInfo_DAL;

public partial class BaseInfo_ItemMstr : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(BaseInfo_ItemMstr));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "ItemMstr");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
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
                getbtn(sts);
                //this.search.Disabled = true;
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
                BindData();
                //igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
                //igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
                //igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
                //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
                //dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "Mould_Code", "Mould_Code");
                //dboSetCtrls.SetDropDownList(ddlCustomerNo, CustomerInfo_BLL.selectCustomerInfo(0, "", "") as IList, false, "CustomerNo", "CustomerName");
            }
            BindData();
            BindRawNo();
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            igbUpdate.Attributes.Add("onclick", "updateClick()");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            // dboSetCtrls.SetDropDownList(ddlMouldCode, MouldDetail_BLL.selectMouldDetail() as IList, false, "MouldCode", "MouldCode");
            dboSetCtrls.SetDropDownList(ddlCustomerName, CustomerInfo_BLL.selectCustomerInfo(0, "", "") as IList, false, "CustomerName", "CustomerName");
            dboSetCtrls.SetDropDownList(ddlItem_Color, new ColorManage_DAL().selectColorManage(0, "", "") as IList, false, "Depth", "ColorName");

        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<ItemMstr_MDL> tempList = ItemMstr_BLL.selectItemMstr(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ArrayList list = GetRaw();

        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vItem_Code = search.Value.Trim();// txtItem_Code.Text.Trim().ToString();
        string vProductRemark = txtProductRemark.Text.Trim();
        string vMouldCode = txtMouldCode.Text.Trim(); //ddlMouldCode.SelectedValue.ToString();
        string vModeDesc = txtModeDesc.Text.Trim().ToString();
        string vMould_SpecialFittingsNo = txtMould_SpecialFittingsNo.Text.Trim().ToString();
        string vInsertsDesc = txtInsertsDesc.Text.Trim().ToString();
        string vPackageNum = txtPackageNum.Text.Trim().ToString();
        string vItem_Weight = (txtItem_Weight.Text.Trim().ToString() == "") ? "0" : txtItem_Weight.Text.Trim().ToString();
        string vItem_ActualGrossWgt = (txtItem_ActualGrossWgt.Text.Trim().ToString()) == "" ? "0" : txtItem_ActualGrossWgt.Text.Trim().ToString();
        string vItem_WaterGapScale = (txtItem_WaterGapScale.Text.Trim().ToString() == "") ? "0" : txtItem_WaterGapScale.Text.Trim().ToString();
        string vItem_Color = ddlItem_Color.SelectedValue.Trim().ToString();
        string vCustomerName = ddlCustomerName.SelectedValue.ToString();
        string vMaterialCode = txtMaterialCode.Text.Trim().ToString();
        string vMaterialDesc = txtMaterialDesc.Text.Trim().ToString();
        string vPowderCode = txtPowderCode.Text.Trim().ToString();
        string vAuxiliaryMaterialName = txtAuxiliaryMaterialName.Text.Trim().ToString();
        string vAuxiliaryMaterialNum = (txtAuxiliaryMaterialNum.Text.Trim().ToString() == "") ? "0" : txtAuxiliaryMaterialNum.Text.Trim().ToString();
        string vOutsideAssociation = rblOutsideAssociation.SelectedValue.ToString();
        string vMachineAssembly = rblMachineAssembly.SelectedValue.ToString();
        string vStandEmployee = txtStandEmployee.Text.Trim();
        string vProcesses = txtProcesses.Text.Trim();
        string vVerNo = txtVerNo.Text.Trim().ToString();
        string vCreater = this.Page.User.Identity.Name.Trim();
        string vCreateDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        string vModiHistoryContent = txtModiHistoryContent.Text.Trim();
        string vRemark = txtRemark.Text.Trim().ToString();
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        //***********************
        //产品图片
        HttpPostedFile hpf = FileUpload1.PostedFile;
        object vImgType = hpf.ContentType;//图片类型
        int ImgLength = hpf.ContentLength;
        byte[] ProdPhoto = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            ProdPhoto = new GifOrJpg().MakeSmallImg(tempStream, 255, 230);//257, 234);// new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            ProdPhoto = new byte[0];
        }
        //*************************

        if (IU == "UPDATE")
        {

            ArrayList myArrListNew = new ArrayList();
            ArrayList MyItemMstrName = new ArrayList();
            ArrayList myArrListOld = Session["ItemMstrmyArrListOld"] as ArrayList;

            MyItemMstrName.Add("辅料名称:");
            MyItemMstrName.Add("辅料用量:");
            MyItemMstrName.Add("模镶件描述:");
            MyItemMstrName.Add("实际啤重:");
            MyItemMstrName.Add("产品编号:");
            MyItemMstrName.Add("产品颜色:");
            MyItemMstrName.Add("水口比例:");
            MyItemMstrName.Add("产品重量:");
            MyItemMstrName.Add("原料编号:");
            MyItemMstrName.Add("原料描述:");
            MyItemMstrName.Add("模具描述:");
            MyItemMstrName.Add("模镶件编号:");
            MyItemMstrName.Add("装箱数量:");
            MyItemMstrName.Add("色粉编号:");
            MyItemMstrName.Add("产品描述:");
            MyItemMstrName.Add("备注:");
            MyItemMstrName.Add("版本:");
            MyItemMstrName.Add("用人标准:");
            MyItemMstrName.Add("下一工序:");

            myArrListNew.Add(vAuxiliaryMaterialName);
            myArrListNew.Add(vAuxiliaryMaterialNum);
            myArrListNew.Add(vInsertsDesc);
            myArrListNew.Add(vItem_ActualGrossWgt);
            myArrListNew.Add(vItem_Code);
            myArrListNew.Add(vItem_Color);
            myArrListNew.Add(vItem_WaterGapScale);
            myArrListNew.Add(vItem_Weight);
            myArrListNew.Add(vMaterialCode);
            myArrListNew.Add(vMaterialDesc);
            myArrListNew.Add(vModeDesc);
            myArrListNew.Add(vMould_SpecialFittingsNo);
            myArrListNew.Add(vPackageNum);
            myArrListNew.Add(vPowderCode);
            myArrListNew.Add(vProductRemark);
            myArrListNew.Add(vRemark);
            myArrListNew.Add(vVerNo);
            myArrListNew.Add(vStandEmployee);
            myArrListNew.Add(vProcesses);

            string vModiHistoryContentx = "";
            for (int i = 0; i < myArrListOld.Count; i++)
            {
                if (myArrListOld[i].ToString() != myArrListNew[i].ToString())
                {
                    //if (vModiHistoryContent != "")
                    //{
                    vModiHistoryContentx += MyItemMstrName[i].ToString() + myArrListOld[i].ToString() + "-->" + myArrListNew[i].ToString() + ((i == myArrListNew.Count - 1) ? "；" : ",");
                    //}
                }
            }
            if (vModiHistoryContentx != "")
            {
                vModiHistoryContentx = System.DateTime.Now.ToString("yyyy-MM-dd") + " " + this.Page.User.Identity.Name.Trim() + " " + vModiHistoryContentx;
                string strstr = vModiHistoryContentx + vModiHistoryContent;
                vModiHistoryContent = strstr;
            }
            //vModiHistoryContent = vModiHistoryContent.Substring(0, vModiHistoryContent.Length - 1);

            if (vModiHistoryContent.Length > 8000)
            {
                vModiHistoryContent = vModiHistoryContent.Substring(0, 7990).ToString();
            }
            if (myArrListOld[4].ToString() != myArrListNew[4].ToString())//产品编号修改了时
            {
                IU = "INSERT";
                vModiHistoryContent = "";
            }
        }

        try
        {
            if (IU == "INSERT")
            {
                if (ItemMstr_BLL.existsItemMstr(vItem_Code).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的产品编号!!");
                    return;
                }
            }
            else
            {
                ItemMstr_BLL.cancelItemMstrDetail(vItem_Code);
            }
            if (vImgType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            {
                dboSetCtrls.SetExecMsg(this, "产品图只能是图片!");
                return;
            }
            else
            {
                if (((ImgLength + 10 * 1024) / 1024) > 209)
                {
                    dboSetCtrls.SetExecMsg(this, "产品图大小不能大于200KB!");
                    return;
                }
            }

            int flages = ItemMstr_BLL.ChangeItemMstr(vID, vItem_Code, vProductRemark, vMouldCode, vModeDesc, vMould_SpecialFittingsNo,
                            vInsertsDesc, vPackageNum, vItem_Weight, vItem_ActualGrossWgt, vItem_WaterGapScale,
                            vItem_Color, vCustomerName, vMaterialCode, vMaterialDesc, vPowderCode, vAuxiliaryMaterialName,
                            vAuxiliaryMaterialNum, vOutsideAssociation, vMachineAssembly, ProdPhoto, vStandEmployee, vProcesses, vVerNo, vCreater, vCreateDate,
                            vModiHistoryContent, vRemark, IU);

            string[] strMouldCode = vMouldCode.Split(',');
            string[] strMouldDesc = vModeDesc.Split(',');
            string[] strMaterialCode = vMaterialCode.Split(',');
            string[] strMaterialDesc = vMaterialDesc.Split(',');
            //for (int i = 0; i < strMouldCode.Length; i++)
            //{
            //    Response.Write(strMouldCode[i].ToString());
            //}

            if (strMouldCode.Length > 0)
            {
                for (int i = 0; i < strMouldCode.Length; i++)
                {
                    if (i >= strMouldDesc.Length)
                    {
                        ItemMstr_BLL.ChangeItemMstrDetail(vID, vItem_Code, strMouldCode[i].ToString(), "", "", "", vCreateDate, "INSERT", 0);
                    }
                    else
                    {
                        ItemMstr_BLL.ChangeItemMstrDetail(vID, vItem_Code, strMouldCode[i].ToString(), strMouldDesc[i].ToString(), "", "", vCreateDate, "INSERT", 0);
                    }
                }
            }
            if (strMaterialCode.Length > 0)
            {
                for (int i = 0; i < strMaterialCode.Length; i++)
                {
                    if (i >= strMaterialDesc.Length)
                    {
                        ItemMstr_BLL.ChangeItemMstrDetail(vID, vItem_Code, "", "", strMaterialCode[i].ToString(), "", vCreateDate, "INSERT", int.Parse(list[i].ToString().Split('@')[1].ToString()));
                    }
                    else
                    {
                        ItemMstr_BLL.ChangeItemMstrDetail(vID, vItem_Code, "", "", strMaterialCode[i].ToString(), strMaterialDesc[i].ToString(), vCreateDate, "INSERT", int.Parse(list[i].ToString().Split('@')[1].ToString()));
                    }
                }
            }
            if (flages > 0)
                dboSetCtrls.SetExecMsg(this, IU, true);
            else
                dboSetCtrls.SetExecMsg(this, IU, false);
            this.Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=ItemMstr&ImgType=Machine_PhotoType&Img=ProdPhoto", vID);
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
                ItemMstr_BLL.cancelItemMstr(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                ItemMstr_BLL.cancelItemMstr(pIDList);
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
            try
            {
                //  o[1].ToString(); o[2].ToString();
                dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "TEXTBOX", txtID);
                object[] textboxid = { txtID,txtAuxiliaryMaterialName,txtMouldCode,txtAuxiliaryMaterialNum,txtInsertsDesc,txtItem_ActualGrossWgt,
                    txtItem_WaterGapScale,txtItem_Weight,txtMaterialCode,txtMaterialDesc,txtModeDesc,txtMould_SpecialFittingsNo,txtPackageNum,
                    txtPowderCode,txtProductRemark,txtStandEmployee,txtProcesses,txtRemark};
                dboSetCtrls.InitCtrls(this, "textbox", textboxid);
                object[] ddlid = { ddlItem_Color };
                dboSetCtrls.InitCtrls(this, "DROPDOWNLIST", ddlid);
                ddlCustomerName.SelectedIndex = rblOutsideAssociation.SelectedIndex = 0; //rblCopyNo.SelectedIndex = rblPlatepart.SelectedIndex = 0;
                rblMachineAssembly.SelectedIndex = 2;
                rblOutsideAssociation.SelectedIndex = 0;
                search.Value = "";
                Image1.ImageUrl = null;
                this.search.Disabled = false;
                txtModiHistoryContent.Text = "";
                txtVerNo.Text = "1";
            }
            catch (Exception er)
            {
            }
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
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        this.search.Disabled = false;
        string vID = txtID.Text = hdnID.Value =
           ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        getbtn(vID);
    }
    void getbtn(string vID)
    {
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtAuxiliaryMaterialName);



        IList<ItemMstr_MDL> tempIList = ItemMstr_BLL.selectItemMstr(Int32.Parse(vID), "", "");
        ArrayList myArrListOld = new ArrayList();
        myArrListOld.Add(tempIList[0].AuxiliaryMaterialName);
        myArrListOld.Add(tempIList[0].AuxiliaryMaterialNum);
        myArrListOld.Add(tempIList[0].InsertsDesc);
        myArrListOld.Add(tempIList[0].Item_ActualGrossWgt);
        myArrListOld.Add(tempIList[0].Item_Code);
        myArrListOld.Add(tempIList[0].Item_Color);
        myArrListOld.Add(tempIList[0].Item_WaterGapScale);
        myArrListOld.Add(tempIList[0].Item_Weight);
        myArrListOld.Add(tempIList[0].MaterialCode);
        myArrListOld.Add(tempIList[0].MaterialDesc);
        myArrListOld.Add(tempIList[0].ModeDesc);
        myArrListOld.Add(tempIList[0].Mould_SpecialFittingsNo);
        myArrListOld.Add(tempIList[0].PackageNum);
        myArrListOld.Add(tempIList[0].PowderCode);
        myArrListOld.Add(tempIList[0].ProductRemark);
        myArrListOld.Add(tempIList[0].Remark);
        myArrListOld.Add(tempIList[0].VerNo);
        myArrListOld.Add(tempIList[0].StandEmployee);
        myArrListOld.Add(tempIList[0].Processes);
        Session["ItemMstrmyArrListOld"] = myArrListOld;

        txtID.Text = hdnID.Value = vID;
        txtAuxiliaryMaterialName.Text = tempIList[0].AuxiliaryMaterialName;
        txtAuxiliaryMaterialNum.Text = tempIList[0].AuxiliaryMaterialNum;
        txtInsertsDesc.Text = tempIList[0].InsertsDesc;
        txtItem_ActualGrossWgt.Text = tempIList[0].Item_ActualGrossWgt;
        search.Value = tempIList[0].Item_Code;
        txtProductRemark.Text = tempIList[0].ProductRemark;
        ddlItem_Color.Text = tempIList[0].Item_Color;
        txtItem_WaterGapScale.Text = tempIList[0].Item_WaterGapScale;
        txtItem_Weight.Text = tempIList[0].Item_Weight;
        txtMaterialCode.Text = tempIList[0].MaterialCode;
        txtMaterialDesc.Text = tempIList[0].MaterialDesc;
        txtModeDesc.Text = tempIList[0].ModeDesc;
        txtMould_SpecialFittingsNo.Text = tempIList[0].Mould_SpecialFittingsNo;
        txtPackageNum.Text = tempIList[0].PackageNum;
        txtPowderCode.Text = tempIList[0].PowderCode;
        txtProductRemark.Text = tempIList[0].ProductRemark;
        txtRemark.Text = tempIList[0].Remark;
        txtVerNo.Text = tempIList[0].VerNo;
        txtStandEmployee.Text = tempIList[0].StandEmployee;
        txtProcesses.Text = tempIList[0].Processes;
        ddlCustomerName = dboSetCtrls.SetSelectedIndex(ddlCustomerName, tempIList[0].CustomerName);
        //ddlMouldCode = dboSetCtrls.SetSelectedIndex(ddlMouldCode, tempIList[0].MouldCode);
        txtMouldCode.Text = tempIList[0].MouldCode;
        rblMachineAssembly.SelectedValue = tempIList[0].MachineAssembly;
        rblOutsideAssociation.SelectedValue = tempIList[0].OutsideAssociation;
        this.Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=ItemMstr&ImgType=Machine_PhotoType&Img=ProdPhoto", vID);
        txtModiHistoryContent.Text = tempIList[0].ModiHistoryContent;
        hdnProdCode.Value = tempIList[0].Item_Code;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }


    protected void productremark_TextChanged(object sender, EventArgs e)
    {

    }
    protected void igbwork_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn = sender as ImageButton;
        string item_code = search.Value.Trim();// txtItem_Code.Text.Trim().ToString();
        string item_id = hdnID.Value.Trim().ToString();
        if (btn.ID != "igbbox")
        {
            Response.Redirect("~/Product/WorkPaper.aspx?types=1&Item_Code=" + item_code + "&id=" + item_id, true);
        }
        else
        {
            Response.Redirect("~/Product/PackageList.aspx?types=1&Item_Code=" + item_code + "&id=" + item_id, true);
        }
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
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }

    [Ajax.AjaxMethod()]
    public ArrayList GetSearhValues(string str)
    {
        ArrayList itmes = new ArrayList();

        DataSet ds = new GetErpItm().QueryErpDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);

        string itemStr1 = ds.Tables[0].Rows[0][1].ToString();
        string itemStr2 = ds.Tables[0].Rows[0][2].ToString();
        //if ((itemStr1 + itemStr2) != "")
        //{
        //    itmes.Add(itemStr1 + "," + itemStr2);
        //}
        //else
        //{
        //    itmes.Add("");
        //}

        if (itemStr1 != "" && itemStr2 != "")
        {
            itmes.Add(itemStr1 + "," + itemStr2);
        }
        else if (itemStr1 == "" && itemStr2 != "")
        {
            itmes.Add(itemStr2);
        }
        else if (itemStr1 != "" && itemStr2 == "")
        {
            itmes.Add(itemStr1);
        }
        else if (itemStr1 == "" && itemStr2 == "")
        {
            itmes.Add(" ");
        }

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }
    /// <summary>
    /// 原料编号
    /// </summary>
    /// <param name="str"></param>
    /// <param name="flage"></param>
    /// <returns></returns>
    [Ajax.AjaxMethod()]
    public ArrayList GetSearhSetValues(string str, string flage)
    {
        ArrayList itmes = new ArrayList();
        DataSet ds = new GetErpItm().QueryErpBomDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);

        string itemStr1 = "";// ds.Tables[0].Rows[i]["CPNITMREF"].ToString();


        if (flage.ToString() == "1")
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["CPNITMREF"].ToString().Substring(0, 1) == "1")
                {
                    if (i != ds.Tables[0].Rows.Count - 1)
                    {
                        itemStr1 += ds.Tables[0].Rows[i]["CPNITMREF"].ToString() + ",";
                    }
                    else
                    {
                        itemStr1 += ds.Tables[0].Rows[i]["CPNITMREF"].ToString();
                    }
                }
                // itmes.Add(itemStr1);
            }
        }
        else
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["CPNITMREF"].ToString().Substring(0, 1) == "1")
                {
                    if (i != ds.Tables[0].Rows.Count - 1)
                    {
                        itemStr1 += ds.Tables[0].Rows[i]["ITMDES_1"].ToString() + " ";
                    }
                    else
                    {
                        itemStr1 += ds.Tables[0].Rows[i]["ITMDES_1"].ToString();
                    }
                }
            }
        }
        itmes.Add(itemStr1);
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    items[i][0] = dr[0];
        //    items[i][1] = dr[1];
        //}
        return itmes;
    }
    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMstr(string str)
    {
        ArrayList items = new ArrayList();


        IList<MouldDetail_MDL> myList = MouldDetail_BLL.selectMouldDetail(0, "", "");
        try
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (str == "1")
                {
                    items.Add(myList[i].MouldCode + "   " + myList[i].GoodsNo);
                }
                else if (str == "2")
                {
                    items.Add(myList[i].MouldDesc);
                }
                else
                {
                    items.Add(myList[i].MouldCode);
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
    public ArrayList QueryGetMouldMstr(string str, string coltext)
    {
        ArrayList items = new ArrayList();


        IList<MouldDetail_MDL> myList = MouldDetail_BLL.selectMouldDetail(0, "GoodsNo", coltext);
        try
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (str == "1")
                {
                    items.Add(myList[i].MouldCode + "   " + myList[i].GoodsNo);
                }
                else if (str == "2")
                {
                    items.Add(myList[i].MouldDesc);
                }
                else
                {
                    items.Add(myList[i].MouldCode);
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

    protected void BindRawNo()
    {
        string colname = "RawNo";
        string coltext = tbRawNo.Text.ToString().Trim();
        IList<RawMaterial_MDL> tempList = new RawMaterial_DAL().selectRawMaterial(0, colname, coltext);
        gvMaterial.DataSource = tempList;
        gvMaterial.DataBind();
    }

    public ArrayList GetRaw()
    {
        ArrayList list = new ArrayList();

        CheckBox cb = new CheckBox();
        TextBox txtPercentage = new TextBox();

        int i = gvMaterial.Rows.Count;

        foreach (GridViewRow gvr in gvMaterial.Rows)
        {
            cb = (CheckBox)gvr.FindControl("chkItem");
            if (cb.Checked == true)
            {
                txtPercentage = (TextBox)gvr.FindControl("txtPercentage");
                if (txtPercentage.Text != "0" && txtPercentage.Text != "" && txtPercentage.Text != null)
                {
                    list.Add(gvr.Cells[1].Text.ToString() + "@" + txtPercentage.Text.ToString());
                }
            }
        }
        return list;
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        BindRawNo();
        fade.Attributes.Add("style", "display:block");
        light.Attributes.Add("style", "display:block");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        ArrayList list = GetRaw();

        int percentage = 0;

        string rawNo = "";

        string per = "";
        for (int i = 0; i < list.Count; i++)
        {
            percentage += int.Parse(list[i].ToString().Split('@')[1].ToString());
            per += list[i].ToString().Split('@')[1].ToString() + ",";
            rawNo += list[i].ToString().Split('@')[0].ToString() + ",";

        }
        if (percentage > 100 || percentage < 100)
        {
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('百分比错误！');", true);
            fade.Attributes.Add("style", "display:block");
            light.Attributes.Add("style", "display:block");
        }
        else
        {
            txtMaterialCode.Text = rawNo.TrimEnd(',');
            fade.Attributes.Add("style", "display:none");
            light.Attributes.Add("style", "display:none");
        }
    }

}
