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
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.BaseInfo_DAL;
using Admin.Model.Machine_MDL;
using Admin.DBUtility;


public partial class BaseInfo_AuxiliaryToolInfo : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    private AuxiliaryToolInfo_DAL AuxiliaryToolInfo = new AuxiliaryToolInfo_DAL();
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(BaseInfo_AuxiliaryToolInfo));
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "AuxiliaryToolInfo");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnNewadd.Visible = btnInsert.Visible = false;
            if (o[2]) btnUpdate.Visible = false;
            if (o[3]) btnCancel.Visible = btnDelete.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
            dataBind();
            //  dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            btnCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");

        }
    }
    void dataBind()
    {
        string colname = this.ddlQuery.SelectedValue.Trim().ToString();
        string coltext = txtQuery.Text.Trim().ToString();

        IList<AuxiliaryToolInfo_MDL> tempList = AuxiliaryToolInfo.selectAuxiliaryToolInfo(0, colname, coltext);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtDeviceCode);

            txtAssetCode.Text = txtDescription.Text = txtDeviceCode.Text = txtDeviceDesc.Text = txtMadeDate.Value
                = txtManufacturers.Text = txtPower.Text = txtRemark.Text =txtMachineNo.Text=txtMouldNo.Text="";
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
            t = AuxiliaryToolInfo.DeleteAuxiliaryToolInfo(pIDList);
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
        ImageButton tempButton = sender as ImageButton;
        string vDeviceCode = txtDeviceCode.Text.Trim();
        string vDeviceDesc = txtDeviceDesc.Text.Trim();
        string vAssetCode = txtAssetCode.Text.Trim();
        string vMadeDate = txtMadeDate.Value.Trim();
        string vManufacturers = txtManufacturers.Text.Trim();
        string vPower = txtPower.Text.Trim() == "" ? "0" : txtPower.Text.Trim();
        string vMouldNo = txtMouldNo.Text.Trim();
        string vMachineNo = txtMachineNo.Text.Trim();
        //***********************
        //产品图片
        HttpPostedFile hpf = fudProcessPhoto.PostedFile;
        
        object vImgType = hpf.ContentType;//图片类型
        int ImgLength = hpf.ContentLength;
        byte[] vDeviceImg = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            vDeviceImg = new GifOrJpg().MakeSmallImg(tempStream, 253, 170);
        }
        else
        {
            vDeviceImg = new byte[0];
        }

        //*************************
        string vDescription = txtDescription.Text.Trim();
        string vRemark = txtRemark.Text.Trim();

        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";
        try
        {
            AuxiliaryToolInfo_MDL call = new AuxiliaryToolInfo_MDL(txtID.Text.Trim().ToString(), vDeviceCode, vDeviceDesc,
                 vAssetCode, vMadeDate, vManufacturers, vPower, vDeviceImg, vDescription, vRemark, vMouldNo,vMachineNo);
            if (UI == "INSERT")
            {
                if (new AuxiliaryToolInfo_DAL().ExistsAuxiliaryToolInfo("DeviceCode", vDeviceCode).Count > 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同产品编号!");
                    return;
                }
            }
            if (vImgType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            {
                dboSetCtrls.SetExecMsg(this, "辅助设备图片只能是图片!");
                return;
            }
            else
            {
                if (((ImgLength + 10 * 1024) / 1024) > 209)
                {
                    dboSetCtrls.SetExecMsg(this, "辅助设备图片大小不能大于200KB!");
                    return;
                }
            }
            if (new AuxiliaryToolInfo_DAL().InsertAuxiliaryToolInfo(call,UI) == 1)
            {
                dboSetCtrls.SetExecMsg(this, UI, true);
                Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=AuxiliaryToolInfo&ImgType=PhotoType&Img=DeviceImg", new AuxiliaryToolInfo_DAL().ExistsAuxiliaryToolInfo("DeviceCode", vDeviceCode)[0].ID);
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, UI, false);
            }
        }
        catch (Exception ex)
        {
            // string temp = ex.ToString().Trim();
            // Response.Write(ex.Message);
            dboSetCtrls.SetExecMsg(this, UI, false);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;

        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtDeviceCode);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();

        IList<AuxiliaryToolInfo_MDL> tempList = new AuxiliaryToolInfo_DAL().selectAuxiliaryToolInfo(int.Parse(vID), "", "");
        txtDeviceCode.Text = tempList[0].DeviceCode;
        txtDeviceDesc.Text = tempList[0].DeviceDesc;
        txtAssetCode.Text = tempList[0].AssetCode;
        txtMadeDate.Value = tempList[0].MadeDate;
        txtManufacturers.Text = tempList[0].Manufacturers;
        txtPower.Text = tempList[0].Power;
        txtMachineNo.Text = tempList[0].MachineNo;
        txtMouldNo.Text = tempList[0].MouldNo;
        txtDescription.Text = tempList[0].Description;
        txtRemark.Text = tempList[0].Remark;
        Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=AuxiliaryToolInfo&ImgType=PhotoType&Img=DeviceImg", vID);
    }

    [Ajax.AjaxMethod()]
    public ArrayList GetMouldMstr(string str)
    {
        ArrayList items = new ArrayList();
        IList<MouldDetail_MDL> myList = new MouldDetail_DAL().selectMouldDetail(0, "", "");
        try
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (str == "1")
                {
                    items.Add(myList[i].MouldCode + "    " + myList[i].GoodsNo);
                }
                else
                {
                    items.Add(myList[i].GoodsNo);
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
    public ArrayList GetMould(string str, string types)
    {
        ArrayList items = new ArrayList();
        IList<MouldDetail_MDL> myList = new MouldDetail_DAL().selectMouldDetail(0, "Mould_Code", str);
        try
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (types == "1")
                {
                    items.Add(myList[i].MouldCode + "    " + myList[i].GoodsNo);
                }
                else
                {
                    items.Add(myList[i].GoodsNo);
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
    public ArrayList GetMachineNo(string str)
    {
        ArrayList items = new ArrayList();
        string strSQL = "select distinct machinecode,workshop  from v_machine ";
        DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
        try
        {
            foreach (DataRow dr in dtTmp.Rows)
            {
                if (str == "1")
                {
                    items.Add(dr["machinecode"].ToString().Trim() + "    " + dr["workshop"].ToString().Trim());
                }
                else
                {
                    items.Add(dr["workshop"].ToString().Trim());
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
    public ArrayList GetMachine(string str, string types)
    {
        ArrayList items = new ArrayList();
        string strSQL = "select distinct machinecode,workshop  from v_machine where machinecode like '%"+str.Trim()+"%'";
        DataTable dtTmp = SqlHelper.ReturnTableValue(CommandType.Text, strSQL);
        try
        {
            foreach (DataRow dr in dtTmp.Rows)
            {
                if (types == "1")
                {
                    items.Add(dr["machinecode"].ToString().Trim() + "    " + dr["workshop"].ToString().Trim());
                }
                else
                {
                    items.Add(dr["workshop"].ToString().Trim());
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
