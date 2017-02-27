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
//using Admin.BLL.Machine_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;


public partial class BaseInfo_MachineMstr : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MachineMstr");
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
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();

        if (Request.QueryString["MachineNo"] != null && Request.QueryString["MachineNo"].ToString().Trim() != "")
        {
            colname = "Machine_Code";
            coltext = Request.QueryString["MachineNo"].ToString().Trim();
            igbNewadd.Visible = false;
            igbCancel.Visible = false;
            igbInsert.Visible = false;
            igbUpdate.Visible = false;
            igbDelete.Visible = false;
        }
     
        IList<MachineMstr_MDL> tempList = MachineMstr_BLL.selectMachineMstr(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string vMachine_Code = txtMachine_Code.Text.Trim();
        string vMachine_Type = txtMachine_Type.Text.Trim();
        string vMachine_Manufacturer = txtMachine_Manufacturer.Text.Trim();

        string vMachine_AssetNo = txtMachine_AssetNo.Text.Trim();
        string vMachine_EquipmentNo = txtMachine_EquipmentNo.Text.Trim();
        string vMachine_MadeDate = txtMachine_MadeDate.Value.Trim();

        string vMachine_LockPower = (txtMachine_LockPower.Text.Trim() == "") ? "0" : txtMachine_LockPower.Text.Trim();
        string vMachine_ShotQty = (txtMachine_ShotQty.Text.Trim() == "") ? "0" : txtMachine_ShotQty.Text.Trim();

        string vMachine_PushDistance = (txtMachine_PushDistance.Text.Trim() == "") ? "0" : txtMachine_PushDistance.Text.Trim();
        string vMachine_LoadMouldLgt = (txtMachine_LoadMouldLgt.Text.Trim() == "") ? "0" : txtMachine_LoadMouldLgt.Text.Trim();
        string vMachine_LoadMouldWdt = (txtMachine_LoadMouldWdt.Text.Trim() == "") ? "0" : txtMachine_LoadMouldWdt.Text.Trim();
        string vMinMouldThick = (txtMinMouldThick.Text.Trim() == "") ? "0" : txtMinMouldThick.Text.Trim();
        string vMaxMouldThick = (txtMaxMouldThick.Text.Trim() == "") ? "0" : txtMaxMouldThick.Text.Trim();

        string vShotDiameter = (txtShotDiameter.Text.Trim() == "") ? "0" : txtShotDiameter.Text.Trim();

        string vHydPressTackOut = rblHydPressTackOut.SelectedValue.Trim();
        string vDrawPoleDistance = (txtDrawPoleDistance.Text.Trim() == "") ? "0" : txtDrawPoleDistance.Text.Trim();
        string vRobort = rblRobort.SelectedValue.Trim();
        string vMachine_Power = (txtMachine_Power.Text.Trim() == "") ? "0" : txtMachine_Power.Text.Trim();

        string vMachine_MaterialChgAmt = (txtMachine_MaterialChgAmt.Text.Trim() == "") ? "0" : txtMachine_MaterialChgAmt.Text.Trim();

        string vRemark = txtRemark.Text.Trim();
        //*********************************************
        HttpPostedFile hpf = fudPhoto.PostedFile;
        object vImgType = hpf.ContentType;//图片类型
        int ImgLength = hpf.ContentLength;
        byte[] vMachine_Photo = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            vMachine_Photo = new GifOrJpg().MakeSmallImg(tempStream, 249, 176);// new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            vMachine_Photo = new byte[0];
        }
        //*********************************************
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (MachineMstr_BLL.existsMachineMstr(vMachine_Code).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的机器编号!!");
                    return;
                }
            }
            if (vImgType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            {
                dboSetCtrls.SetExecMsg(this, "机器图片只能是图片!");
                return;
            }
            else
            {
                if (((ImgLength + 10 * 1024) / 1024) > 209)
                {
                    dboSetCtrls.SetExecMsg(this, "机器图片大小不能大于200KB!");
                    return;
                }
            }
            MachineMstr_BLL.updateMachineMstr(vID,
                vMachine_Code, vMachine_Type, vMachine_Manufacturer, 
                vMachine_AssetNo, vMachine_EquipmentNo, vMachine_MadeDate, 
                vMachine_LockPower, vMachine_ShotQty, 
                vMachine_PushDistance, vMachine_LoadMouldLgt, vMachine_LoadMouldWdt, vMinMouldThick, vMaxMouldThick,
                 vShotDiameter,
                vHydPressTackOut, vDrawPoleDistance, vRobort, vMachine_Power,
                vMachine_MaterialChgAmt,vMachine_Photo, vRemark,  IU);                
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
                MachineMstr_BLL.cancelMachineMstr(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                MachineMstr_BLL.cancelMachineMstr(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtMachine_Code);
            object[] textboxid = {
                txtID, txtMachine_Code, txtMachine_Type, txtMachine_Manufacturer, 
                txtMachine_AssetNo, txtMachine_EquipmentNo,txtMachine_LockPower, txtMachine_ShotQty,
                txtMachine_PushDistance, txtMachine_LoadMouldLgt, txtMachine_LoadMouldWdt, txtMinMouldThick, txtMaxMouldThick,
                txtShotDiameter, txtDrawPoleDistance,  txtMachine_Power,txtMachine_MaterialChgAmt,txtRemark
            };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            rblHydPressTackOut.SelectedIndex = rblRobort.SelectedIndex = 0;
            txtMachine_MadeDate.Value = null;
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
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim();

        MultiView1.ActiveViewIndex = 1;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtMachine_Code);
        IList<MachineMstr_MDL> tempIList = MachineMstr_BLL.selectMachineMstr(Int32.Parse(vID), "", "");

        txtID.Text = hdnID.Value = vID;
        txtMachine_Code.Text = tempIList[0].Machine_Code;

        txtMachine_Type.Text = tempIList[0].Machine_Type;
        txtMachine_Manufacturer.Text = tempIList[0].Machine_Manufacturer;
        txtMachine_AssetNo.Text = tempIList[0].Machine_AssetNo;
        txtMachine_EquipmentNo.Text = tempIList[0].Machine_EquipmentNo;
        txtMachine_MadeDate.Value = tempIList[0].Machine_MadeDate;
        txtMachine_LockPower.Text = tempIList[0].Machine_LockPower;
        txtMachine_ShotQty.Text = tempIList[0].Machine_ShotQty;

        txtMachine_PushDistance.Text = tempIList[0].Machine_PushDistance;
        txtMachine_LoadMouldLgt.Text = tempIList[0].Machine_LoadMouldLgt;
        txtMachine_LoadMouldWdt.Text = tempIList[0].Machine_LoadMouldWdt;
        txtMinMouldThick.Text = tempIList[0].MinMouldThick;
        txtMaxMouldThick.Text = tempIList[0].MaxMouldThick;
        txtShotDiameter.Text = tempIList[0].ShotDiameter;

        //dboSetCtrls.SetExecMsg(this, tempIList[0].LengthenShot);
        //dboSetCtrls.SetExecMsg(this, tempIList[0].MixenShot);
        //dboSetCtrls.SetExecMsg(this, tempIList[0].HydPressTackOut);
        rblHydPressTackOut.SelectedValue = tempIList[0].HydPressTackOut.Trim(); ;

        txtDrawPoleDistance.Text = tempIList[0].DrawPoleDistance;

        string Robort = tempIList[0].Robort.Trim();
        if (Robort != "0" && Robort != "1") rblRobort.SelectedIndex = 0;
        else rblRobort.SelectedValue = Robort;

        txtMachine_Power.Text = tempIList[0].Machine_Power;
        txtMachine_MaterialChgAmt.Text = tempIList[0].Machine_MaterialChgAmt;
        Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=MachineMstr&ImgType=Machine_PhotoType&Img=Machine_Photo", vID);
        txtRemark.Text = tempIList[0].Remark;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

}
