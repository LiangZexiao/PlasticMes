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
using Admin.Model.Quality_MDL;
using Admin.Model.BaseInfo_MDL;
using Admin.Model.Product_MDL;
using Admin.BLL.Quality_BLL;
using Admin.BLL.BaseInfo_BLL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Quality_StandTechnicsParams : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "StandTechnicsParams");
            ViewState["authority"] = o;

            if (o[0]) igbQuery.Visible = false;
            if (o[1]) igbInsert.Visible = false;
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
            //igbUpdate.Attributes.Add("onclick", "if(window.confirm('是否覆盖?')) dowork(); ");
            //igbUpdate.Attributes.Add("onclick", "if(confirm('是否覆盖原记录?')){ window.document.getElementById('hashas').value='true' }else {window.document.getElementById('hashas').value='false'} ");
            igbUpdate.Attributes.Add("onclick", "IsFalgOverent()");
           // dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlMachineNo, MachineMstr_BLL.selectMachineMstr(0, "", "") as IList, false, "Machine_Code", "Machine_Code");
            dboSetCtrls.SetDropDownList(ddlMouldNo, MouldDetail_BLL.selectMouldDetail() as IList, false, "MouldCode", "MouldCode");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<StandTechnicsParams_MDL> tempList = StandTechnicsParams_BLL.selectStandTechnicsParams(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        
        bool blong =false ;
        if (tempButton.ID == "igbUpdate")
        {
            string flages = txtflags.Text.Trim().ToString(); // hashas.Value.ToString().Trim();
            if (flages == "true" && flages != "")
            {
                blong = true;
            }
            else
            {
                blong = false;
            }
        }
        int vID = (txtID.Text.Trim() == "") ? 0 : int.Parse(txtID.Text.Trim());
        string FileNo           = txtFileNo.Text.Trim();
        string MachineNo        = ddlMachineNo.SelectedValue.Trim();
        string MouldNo          = ddlMouldNo.SelectedValue.Trim();
        string ProductNo        = ddlProductNo.SelectedValue.Trim();
        string RegrindRate      = (txtRegrindRate.Text.Trim() == "") ? "0" : txtRegrindRate.Text.Trim();
        string Season           = ddlSeason.SelectedValue.Trim();
        string Version          = (blong == true) ? txtVersion.Text.Trim() + "+1" : txtVersion.Text.Trim();
        string Engineer         = txtEngineer.Text.Trim();
        string AdjustDate       = (txtAdjustDate.Value.Trim() == "") ? System.DateTime.Now.ToString("yyyy-MM-dd") : txtAdjustDate.Value.Trim();
        string SetShotMouthTemp = (txtSetShotMouthTemp.Text.Trim() == "") ? "0" : txtSetShotMouthTemp.Text.Trim();

        string ShotMouthTemp1 = (txtShotMouthTemp1.Text.Trim() == "") ? "0" : txtShotMouthTemp1.Text.Trim();
        string ShotMouthTemp2 = (txtShotMouthTemp2.Text.Trim() == "") ? "0" : txtShotMouthTemp2.Text.Trim();
        string ShotMouthTemp3 = (txtShotMouthTemp3.Text.Trim() == "") ? "0" : txtShotMouthTemp3.Text.Trim();
        string MaterialPipeTemp = (txtMaterialPipeTemp.Text.Trim() == "") ? "0" : txtMaterialPipeTemp.Text.Trim();
        string GlueMeltTime = (txtGlueMeltTime.Text.Trim() == "") ? "0" : txtGlueMeltTime.Text.Trim();
        string ScrewTurnSpeed = (txtScrewTurnSpeed.Text.Trim() == "") ? "0" : txtScrewTurnSpeed.Text.Trim();
        string FillingTime = (txtFillingTime.Text.Trim() == "") ? "0" : txtFillingTime.Text.Trim();
        string PeriodTime = (txtPeriodTime.Text.Trim() == "") ? "0" : txtPeriodTime.Text.Trim();
        string ShotGlueDelay = (txtShotGlueDelay.Text.Trim() == "") ? "0" : txtShotGlueDelay.Text.Trim();
        string ShotGluePoint = (txtShotGluePoint.Text.Trim() == "") ? "0" : txtShotGluePoint.Text.Trim();

        string ThimbleNum = (txtThimbleNum.Text.Trim() == "") ? "0" : txtThimbleNum.Text.Trim();
        string MouldCloseNum = (txtMouldCloseNum.Text.Trim() == "") ? "0" : txtMouldCloseNum.Text.Trim();
        string CoolingTime = (txtCoolingTime.Text.Trim() == "") ? "0" : txtCoolingTime.Text.Trim();
        string FillingLimit = (txtFillingLimit.Text.Trim() == "") ? "0" : txtFillingLimit.Text.Trim();
        string GlueMeltTimeLimit = (txtGlueMeltTimeLimit.Text.Trim() == "") ? "0" : txtGlueMeltTimeLimit.Text.Trim();
        string GlueMeltDelay = (txtGlueMeltDelay.Text.Trim() == "") ? "0" : txtGlueMeltDelay.Text.Trim();
        string BeforeMeltSpeed = (txtBeforeMeltSpeed.Text.Trim() == "") ? "0" : txtBeforeMeltSpeed.Text.Trim();
        string BeforeMeltPress = (txtBeforeMeltPress.Text.Trim() == "") ? "0" : txtBeforeMeltPress.Text.Trim();

        string BeforeMeltTime = (txtBeforeMeltTime.Text.Trim() == "") ? "0" : txtBeforeMeltTime.Text.Trim();

        string MeltSpeed1 = (txtMeltSpeed1.Text.Trim() == "") ? "0" : txtMeltSpeed1.Text.Trim();
        string MeltPress1 = (txtMeltPress1.Text.Trim() == "") ? "0" : txtMeltPress1.Text.Trim();

        string MeltPosition1 = (txtMeltPosition1.Text.Trim() == "") ? "0" : txtMeltPosition1.Text.Trim();
        string MeltSpeed2 = (txtMeltSpeed2.Text.Trim() == "") ? "0" : txtMeltSpeed2.Text.Trim();
        string MeltPress2 = (txtMeltPress2.Text.Trim() == "") ? "0" : txtMeltPress2.Text.Trim();
        string MeltPosition2 = (txtMeltPosition2.Text.Trim() == "") ? "0" : txtMeltPosition2.Text.Trim();
        string MeltSpeed3 = (txtMeltSpeed3.Text.Trim() == "") ? "0" : txtMeltSpeed3.Text.Trim();
        string AfterMeltPress = (txtAfterMeltPress.Text.Trim() == "") ? "0" : txtAfterMeltPress.Text.Trim();
        string AfterMeltPosition = (txtAfterMeltPosition.Text.Trim() == "") ? "0" : txtAfterMeltPosition.Text.Trim();
        string MeltBackPress = (txtMeltBackPress.Text.Trim() == "") ? "0" : txtMeltBackPress.Text.Trim();
        string ShotBaseFastSpeed1 = (txtShotBaseFastSpeed1.Text.Trim() == "") ? "0" : txtShotBaseFastSpeed1.Text.Trim();
        string ShotPosition1 = (txtShotPosition1.Text.Trim() == "") ? "0" : txtShotPosition1.Text.Trim();

        string ShotPress1 = (txtShotPress1.Text.Trim() == "") ? "0" : txtShotPress1.Text.Trim();
        string ShotBaseFastSpeed2 = (txtShotBaseFastSpeed2.Text.Trim() == "") ? "0" : txtShotBaseFastSpeed2.Text.Trim();
        string ShotPress2 = (txtShotPress2.Text.Trim() == "") ? "0" : txtShotPress2.Text.Trim();
        string ShotPosition2 = (txtShotPosition2.Text.Trim() == "") ? "0" : txtShotPosition2.Text.Trim();
        string ShotBaseFastSpeed3 = (txtShotBaseFastSpeed3.Text.Trim() == "") ? "0" : txtShotBaseFastSpeed3.Text.Trim();
        string ShotPress3 = (txtShotPress3.Text.Trim() == "") ? "0" : txtShotPress3.Text.Trim();
        string ShotPosition3 = (txtShotPosition3.Text.Trim() == "") ? "0" : txtShotPosition3.Text.Trim();
        string ShotBaseFastSpeed4 = (txtShotBaseFastSpeed4.Text.Trim() == "") ? "0" : txtShotBaseFastSpeed4.Text.Trim();
        string ShotPress4 = (txtShotPress4.Text.Trim() == "") ? "0" : txtShotPress4.Text.Trim();
        string ShotPosition4 = (txtShotPosition4.Text.Trim() == "") ? "0" : txtShotPosition4.Text.Trim();

        string KeepPressSpeed1 = (txtKeepPressSpeed1.Text.Trim() == "") ? "0" : txtKeepPressSpeed1.Text.Trim();
        string KeepPress1 = (txtKeepPress1.Text.Trim() == "") ? "0" : txtKeepPress1.Text.Trim();
        string KeepPressPosition1 = (txtKeepPressPosition1.Text.Trim() == "") ? "0" : txtKeepPressPosition1.Text.Trim();
        string KeepPress2 = (txtKeepPress2.Text.Trim() == "") ? "0" : txtKeepPress2.Text.Trim();
        string KeepPressPosition2 = (txtKeepPressPosition2.Text.Trim() == "") ? "0" : txtKeepPressPosition2.Text.Trim();
        string KeepPress3 = (txtKeepPress3.Text.Trim() == "") ? "0" : txtKeepPress3.Text.Trim();
        string KeepPressPosition3 = (txtKeepPressPosition3.Text.Trim() == "") ? "0" : txtKeepPressPosition3.Text.Trim();
        string ShotBaseFastSpeed = (txtShotBaseFastSpeed.Text.Trim() == "") ? "0" : txtShotBaseFastSpeed.Text.Trim();
        string ShotBaseFastPress = (txtShotBaseFastPress.Text.Trim() == "") ? "0" : txtShotBaseFastPress.Text.Trim();
        string ShotBaseFastTime = (txtShotBaseFastTime.Text.Trim() == "") ? "0" : txtShotBaseFastTime.Text.Trim();

        string ShotBaseSlowSpeed = (txtShotBaseSlowSpeed.Text.Trim() == "") ? "0" : txtShotBaseSlowSpeed.Text.Trim();
        string ShotBaseSlowPress = (txtShotBaseSlowPress.Text.Trim() == "") ? "0" : txtShotBaseSlowPress.Text.Trim();
        string ShotBackSpeed = (txtShotBackSpeed.Text.Trim() == "") ? "0" : txtShotBackSpeed.Text.Trim();
        string ShotBackPress = (txtShotBackPress.Text.Trim() == "") ? "0" : txtShotBackPress.Text.Trim();
        string ShotBackTemp = (txtShotBackTemp.Text.Trim() == "") ? "0" : txtShotBackTemp.Text.Trim();
        string AdjustMouldPress = (txtAdjustMouldPress.Text.Trim() == "") ? "0" : txtAdjustMouldPress.Text.Trim();
        string FastLockMouldSpeed = (txtFastLockMouldSpeed.Text.Trim() == "") ? "0" : txtFastLockMouldSpeed.Text.Trim();
        string FastLockMouldPress = (txtFastLockMouldPress.Text.Trim() == "") ? "0" : txtFastLockMouldPress.Text.Trim();
        string FastLockMouldPosition = (txtFastLockMouldPosition.Text.Trim() == "") ? "0" : txtFastLockMouldPosition.Text.Trim();
        string LowPressLockMouldSpeed = (txtLowPressLockMouldSpeed.Text.Trim() == "") ? "0" : txtLowPressLockMouldSpeed.Text.Trim();

        string LowPressLockMouldPress = (txtLowPressLockMouldPress.Text.Trim() == "") ? "0" : txtLowPressLockMouldPress.Text.Trim();
        string LowPressLockMouldPosition = (txtLowPressLockMouldPosition.Text.Trim() == "") ? "0" : txtLowPressLockMouldPosition.Text.Trim();
        string HighPressLockMouldSpeed = (txtHighPressLockMouldSpeed.Text.Trim() == "") ? "0" : txtHighPressLockMouldSpeed.Text.Trim();
        string HighPressLockMouldPress = (txtHighPressLockMouldPress.Text.Trim() == "") ? "0" : txtHighPressLockMouldPress.Text.Trim();
        string HighPressLockMouldPosition = (txtHighPressLockMouldPosition.Text.Trim() == "") ? "0" : txtHighPressLockMouldPosition.Text.Trim();
        string LowSpeedOpenMouldSpeed = (txtLowSpeedOpenMouldSpeed.Text.Trim() == "") ? "0" : txtLowSpeedOpenMouldSpeed.Text.Trim();
        string LowSpeedOpenMouldPress = (txtLowSpeedOpenMouldPress.Text.Trim() == "") ? "0" : txtLowSpeedOpenMouldPress.Text.Trim();
        string LowSpeedOpenMouldPosition = (txtLowSpeedOpenMouldPosition.Text.Trim() == "") ? "0" : txtLowSpeedOpenMouldPosition.Text.Trim();
        string HighSpeedOpenMouldSpeed = (txtHighSpeedOpenMouldSpeed.Text.Trim() == "") ? "0" : txtHighSpeedOpenMouldSpeed.Text.Trim();
        string HighSpeedOpenMouldPress = (txtHighSpeedOpenMouldPress.Text.Trim() == "") ? "0" : txtHighSpeedOpenMouldPress.Text.Trim();

        string HighSpeedOpenMouldPosition = (txtHighSpeedOpenMouldPosition.Text.Trim() == "") ? "0" : txtHighSpeedOpenMouldPosition.Text.Trim();
        string ReduceSpeedOpenMouldSpeed = (txtReduceSpeedOpenMouldSpeed.Text.Trim() == "") ? "0" : txtReduceSpeedOpenMouldSpeed.Text.Trim();
        string ReduceSpeedOpenMouldPress = (txtReduceSpeedOpenMouldPress.Text.Trim() == "") ? "0" : txtReduceSpeedOpenMouldPress.Text.Trim();
        string ReduceSpeedOpenMouldPosition = (txtReduceSpeedOpenMouldPosition.Text.Trim() == "") ? "0" : txtReduceSpeedOpenMouldPosition.Text.Trim();
        string ThimbleBeginMouldPosition = (txtThimbleBeginMouldPosition.Text.Trim() == "") ? "0" : txtThimbleBeginMouldPosition.Text.Trim();
        string ThimbleActKind = rblThimbleActKind.SelectedValue.Trim();
        string ThimbleGoSpeed = (txtThimbleGoSpeed.Text.Trim() == "") ? "0" : txtThimbleGoSpeed.Text.Trim();
        string ThimbleGoPress = (txtThimbleGoPress.Text.Trim() == "") ? "0" : txtThimbleGoPress.Text.Trim();
        string ThimbleGoPosition = (txtThimbleGoPosition.Text.Trim() == "") ? "0" : txtThimbleGoPosition.Text.Trim();
        string ThimbleBackSpeed = (txtThimbleBackSpeed.Text.Trim() == "") ? "0" : txtThimbleBackSpeed.Text.Trim();

        string ThimbleBackPress = (txtThimbleBackPress.Text.Trim() == "") ? "0" : txtThimbleBackPress.Text.Trim();
        string ThimbleBackPosition = (txtThimbleBackPosition.Text.Trim() == "") ? "0" : txtThimbleBackPosition.Text.Trim();
        string ThimbleNum1 = (txtThimbleNum1.Text.Trim() == "") ? "0" : txtThimbleNum1.Text.Trim();
        string ThimbleShakeTime = (txtThimbleShakeTime.Text.Trim() == "") ? "0" : txtThimbleShakeTime.Text.Trim();
        string ThimbleStayTime = (txtThimbleStayTime.Text.Trim() == "") ? "0" : txtThimbleStayTime.Text.Trim();

        string PushSpeed = (txtPushSpeed.Text.Trim() == "") ? "0" : txtPushSpeed.Text.Trim();
        string PushPress = (txtPushPress.Text.Trim() == "") ? "0" : txtPushPress.Text.Trim();
        string BeforeGetWater = (txtBeforeGetWater.Text.Trim() == "") ? "0" : txtBeforeGetWater.Text.Trim();
        string BeforeGetWaterTemp = (txtBeforeGetWaterTemp.Text.Trim() == "") ? "0" : txtBeforeGetWaterTemp.Text.Trim();
        string BeforeGetWaterMouldTemp = (txtBeforeGetWaterMouldTemp.Text.Trim() == "") ? "0" : txtBeforeGetWaterMouldTemp.Text.Trim();
        string AfterGetWater = (txtAfterGetWater.Text.Trim() == "") ? "0" : txtAfterGetWater.Text.Trim();
        string AfterGetWaterTemp = (txtAfterGetWaterTemp.Text.Trim() == "") ? "0" : txtAfterGetWaterTemp.Text.Trim();
        string AfterGetWaterMouldTemp = (txtAfterGetWaterMouldTemp.Text.Trim() == "") ? "0" : txtAfterGetWaterMouldTemp.Text.Trim();
        string GrossWeight = (txtGrossWeight.Text.Trim() == "") ? "0" : txtGrossWeight.Text.Trim();
        string MaterialNo = txtMaterialNo.Text.Trim();
        string Remark = txtRemark.Text.Trim();
        string QualiteRemark = qualiteremark.Text.Trim().ToString();

        //*********************************************
        //HttpPostedFile hpf = fudPhoto.PostedFile;
        //int ImgLength = hpf.ContentLength;
        //byte[] Photo = new byte[ImgLength];
        //Stream tempStream = hpf.InputStream;
        //tempStream.Read(Photo, 0, ImgLength);
        //object PhotoType = hpf.ContentType;
        //*********************************************

        //*********************************************
        HttpPostedFile hpf = fudPhoto.PostedFile;
        object PhotoType = hpf.ContentType;
        int ImgLength = hpf.ContentLength;
        byte[] Photo = new byte[ImgLength];
        Stream tempStream = hpf.InputStream;
        if (ImgLength > 0)
        {
            Photo = new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            Photo = new byte[0];
        }
        //*********************************************

        string IU;// = (tempButton.ID == "igbInsert" || blong==true) ? "INSERT" : "UPDATE";

        if (tempButton.ID == "igbInsert")
        {
            IU = "INSERT";
        }
        else
        {
            if (!blong)
            {
                IU = "UPDATE";
            }
            else
            {
                IU = "INSERT";
            }
        }
        try
        {
            StandTechnicsParams_BLL.updateStandTechnicsParams(vID,
                    FileNo, MachineNo, MouldNo, ProductNo, RegrindRate,
                    Season, Version, Engineer, AdjustDate, SetShotMouthTemp,

                    ShotMouthTemp1, ShotMouthTemp2, ShotMouthTemp3, MaterialPipeTemp, GlueMeltTime,
                    ScrewTurnSpeed, FillingTime, PeriodTime, ShotGlueDelay, ShotGluePoint,

                    ThimbleNum, MouldCloseNum, CoolingTime, FillingLimit, GlueMeltTimeLimit,
                    GlueMeltDelay, BeforeMeltSpeed, BeforeMeltPress, BeforeMeltTime, MeltSpeed1,

                    MeltPress1,

                    MeltPosition1, MeltSpeed2, MeltPress2, MeltPosition2, MeltSpeed3,
                    AfterMeltPress, AfterMeltPosition, MeltBackPress, ShotBaseFastSpeed1, ShotPosition1,

                    ShotPress1, ShotBaseFastSpeed2, ShotPress2, ShotPosition2, ShotBaseFastSpeed3,
                    ShotPress3, ShotPosition3, ShotBaseFastSpeed4, ShotPress4, ShotPosition4,

                    KeepPressSpeed1, KeepPress1, KeepPressPosition1, KeepPress2, KeepPressPosition2,
                    KeepPress3, KeepPressPosition3, ShotBaseFastSpeed, ShotBaseFastPress, ShotBaseFastTime,

                    ShotBaseSlowSpeed, ShotBaseSlowPress, ShotBackSpeed, ShotBackPress, ShotBackTemp,
                    AdjustMouldPress, FastLockMouldSpeed, FastLockMouldPress, FastLockMouldPosition, LowPressLockMouldSpeed,

                    LowPressLockMouldPress, LowPressLockMouldPosition, HighPressLockMouldSpeed, HighPressLockMouldPress, HighPressLockMouldPosition,
                    LowSpeedOpenMouldSpeed, LowSpeedOpenMouldPress, LowSpeedOpenMouldPosition, HighSpeedOpenMouldSpeed, HighSpeedOpenMouldPress,

                    HighSpeedOpenMouldPosition, ReduceSpeedOpenMouldSpeed, ReduceSpeedOpenMouldPress, ReduceSpeedOpenMouldPosition, ThimbleBeginMouldPosition,
                    ThimbleActKind, ThimbleGoSpeed, ThimbleGoPress, ThimbleGoPosition, ThimbleBackSpeed,

                    ThimbleBackPress, ThimbleBackPosition, ThimbleNum1, ThimbleShakeTime, ThimbleStayTime,//需要修改
                    PushSpeed, PushPress, BeforeGetWater, BeforeGetWaterTemp, BeforeGetWaterMouldTemp,
                    AfterGetWater, AfterGetWaterTemp, AfterGetWaterMouldTemp, GrossWeight, MaterialNo,
                    Photo, PhotoType, Remark,QualiteRemark, IU
                    );
          
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
        { ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                pIDList.Add(txtID.Text.Trim());
                StandTechnicsParams_BLL.cancelStandTechnicsParams(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                StandTechnicsParams_BLL.cancelStandTechnicsParams(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtFileNo);
            object[] textboxid = { txtGoodSocketNum,
                txtFileNo,txtRegrindRate,txtVersion,txtEngineer,txtSetShotMouthTemp,

                txtShotMouthTemp1,txtShotMouthTemp2,txtShotMouthTemp3,txtMaterialPipeTemp,txtGlueMeltTime,
                txtScrewTurnSpeed,txtFillingTime,txtPeriodTime,txtShotGlueDelay,txtShotGluePoint,

                txtThimbleNum,txtMouldCloseNum,txtCoolingTime,txtFillingLimit,txtGlueMeltTimeLimit,
                txtGlueMeltDelay,txtBeforeMeltSpeed,txtBeforeMeltPress,txtBeforeMeltTime,txtMeltSpeed1,
                
                txtMeltPress1,

                txtMeltPosition1,txtMeltSpeed2,txtMeltPress2,txtMeltPosition2,txtMeltSpeed3,
                txtAfterMeltPress,txtAfterMeltPosition,txtMeltBackPress,txtShotBaseFastSpeed1,txtShotPosition1,

                txtShotPress1,txtShotBaseFastSpeed2,txtShotPress2,txtShotPosition2,txtShotBaseFastSpeed3,
                txtShotPress3,txtShotPosition3,txtShotBaseFastSpeed4,txtShotPress4,txtShotPosition4,

                txtKeepPressSpeed1,txtKeepPress1,txtKeepPressPosition1,txtKeepPress2,txtKeepPressPosition2,
                txtKeepPress3,txtKeepPressPosition3,txtShotBaseFastSpeed,txtShotBaseFastPress,txtShotBaseFastTime,

                txtShotBaseSlowSpeed,txtShotBaseSlowPress,txtShotBackSpeed,txtShotBackPress, txtShotBackTemp,
                txtAdjustMouldPress,txtFastLockMouldSpeed,txtFastLockMouldPress,txtFastLockMouldPosition,txtLowPressLockMouldSpeed,

                txtLowPressLockMouldPress,txtLowPressLockMouldPosition,txtHighPressLockMouldSpeed,txtHighPressLockMouldPress,txtHighPressLockMouldPosition,
                txtLowSpeedOpenMouldSpeed,txtLowSpeedOpenMouldPress,txtLowSpeedOpenMouldPosition,txtHighSpeedOpenMouldSpeed,txtHighSpeedOpenMouldPress,

                txtHighSpeedOpenMouldPosition,txtReduceSpeedOpenMouldSpeed,txtReduceSpeedOpenMouldPress,txtReduceSpeedOpenMouldPosition,txtThimbleBeginMouldPosition,
                txtThimbleGoSpeed,txtThimbleGoPress,txtThimbleGoPosition,txtThimbleBackSpeed,

                txtThimbleBackPress,txtThimbleBackPosition,txtThimbleNum1,txtThimbleShakeTime,txtThimbleStayTime,qualiteremark
            };
            txtAdjustDate.Value = null;
            SetDropDownList("ddlMouldNo");

            ddlMachineNo.SelectedIndex = ddlMouldNo.SelectedIndex = ddlProductNo.SelectedIndex = ddlSeason.SelectedIndex = 0;
            rblThimbleActKind.SelectedIndex = 0;
            
            SetTextBox();

            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
        }
        else
        {
            if(tempButton.ID != "igbQuery")
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
        txtflags.Text = "false";
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtFileNo);

        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();

        IList<StandTechnicsParams_MDL> tempIList = StandTechnicsParams_BLL.selectStandTechnicsParams(Int32.Parse(vID), "", "");

        txtFileNo.Text = tempIList[0].FileNo;
        ddlMachineNo = dboSetCtrls.SetSelectedIndex(ddlMachineNo, tempIList[0].MachineNo);
        ddlMouldNo = dboSetCtrls.SetSelectedIndex(ddlMouldNo, tempIList[0].MouldNo);
        SetDropDownList(ddlMouldNo.ID);

        ddlProductNo = dboSetCtrls.SetSelectedIndex(ddlProductNo, tempIList[0].ProductNo);

        SetTextBox();

        txtRegrindRate.Text = tempIList[0].RegrindRate;
        ddlSeason.SelectedValue = tempIList[0].Season;
        txtVersion.Text = tempIList[0].Version;
        txtEngineer.Text = tempIList[0].Engineer;
        txtAdjustDate.Value = tempIList[0].AdjustDate;
        txtSetShotMouthTemp.Text = tempIList[0].SetShotMouthTemp;

        txtShotMouthTemp1.Text = tempIList[0].ShotMouthTemp1;
        txtShotMouthTemp2.Text = tempIList[0].ShotMouthTemp2;
        txtShotMouthTemp3.Text = tempIList[0].ShotMouthTemp3;
        txtMaterialPipeTemp.Text = tempIList[0].MaterialPipeTemp;
        txtGlueMeltTime.Text = tempIList[0].GlueMeltTime;
        txtScrewTurnSpeed.Text = tempIList[0].ScrewTurnSpeed;
        txtFillingTime.Text = tempIList[0].FillingTime;
        txtPeriodTime.Text = tempIList[0].PeriodTime;
        txtShotGlueDelay.Text = tempIList[0].ShotGlueDelay;
        txtShotGluePoint.Text = tempIList[0].ShotGluePoint;

        txtThimbleNum.Text = tempIList[0].ThimbleNum;
        txtMouldCloseNum.Text = tempIList[0].MouldCloseNum;
        txtCoolingTime.Text = tempIList[0].CoolingTime;
        txtFillingLimit.Text = tempIList[0].FillingLimit;
        txtGlueMeltTimeLimit.Text = tempIList[0].GlueMeltTimeLimit;
        txtGlueMeltDelay.Text = tempIList[0].GlueMeltDelay;
        txtBeforeMeltSpeed.Text = tempIList[0].BeforeMeltSpeed;
        txtBeforeMeltPress.Text = tempIList[0].BeforeMeltPress;
        txtBeforeMeltTime.Text = tempIList[0].BeforeMeltTime;


        txtMeltSpeed1.Text = tempIList[0].MeltSpeed1;
        txtMeltPress1.Text = tempIList[0].MeltPress1;

        txtMeltPosition1.Text = tempIList[0].MeltPosition1;
        txtMeltSpeed2.Text = tempIList[0].MeltSpeed2;
        txtMeltPress2.Text = tempIList[0].MeltPress2;
        txtMeltPosition2.Text = tempIList[0].MeltPosition2;
        txtMeltSpeed3.Text = tempIList[0].AfterMeltSpeed;
        txtAfterMeltPress.Text = tempIList[0].AfterMeltPress;
        txtAfterMeltPosition.Text = tempIList[0].AfterMeltPosition;
        txtMeltBackPress.Text = tempIList[0].MeltBackPress;
        txtShotBaseFastSpeed1.Text = tempIList[0].ShotBaseFastSpeed1;
        txtShotPosition1.Text = tempIList[0].ShotPosition1;

        txtShotPress1.Text = tempIList[0].ShotPress1;
        txtShotBaseFastSpeed2.Text = tempIList[0].ShotBaseFastSpeed2;
        txtShotPress2.Text = tempIList[0].ShotPress2;
        txtShotPosition2.Text = tempIList[0].ShotPosition2;
        txtShotBaseFastSpeed3.Text = tempIList[0].ShotBaseFastSpeed3;
        txtShotPress3.Text = tempIList[0].ShotPress3;
        txtShotPosition3.Text = tempIList[0].ShotPosition3;
        txtShotBaseFastSpeed4.Text = tempIList[0].ShotBaseFastSpeed4;
        txtShotPress4.Text = tempIList[0].ShotPress4;
        txtShotPosition4.Text = tempIList[0].ShotPosition4;

        txtKeepPressSpeed1.Text = tempIList[0].KeepPressSpeed1;
        txtKeepPress1.Text = tempIList[0].KeepPress1;
        txtKeepPressPosition1.Text = tempIList[0].KeepPressPosition1;
        txtKeepPress2.Text = tempIList[0].KeepPress2;
        txtKeepPressPosition2.Text = tempIList[0].KeepPressPosition2;
        txtKeepPress3.Text = tempIList[0].KeepPress3;
        txtKeepPressPosition3.Text = tempIList[0].KeepPressPosition3;
        txtShotBaseFastSpeed.Text = tempIList[0].ShotBaseFastSpeed;
        txtShotBaseFastPress.Text = tempIList[0].ShotBaseFastPress;
        txtShotBaseFastTime.Text = tempIList[0].ShotBaseFastTime;

        txtShotBaseSlowSpeed.Text = tempIList[0].ShotBaseSlowSpeed;
        txtShotBaseSlowPress.Text = tempIList[0].ShotBaseSlowPress;
        txtShotBackSpeed.Text = tempIList[0].ShotBackSpeed;
        txtShotBackPress.Text = tempIList[0].ShotBackPress;
        txtShotBackTemp.Text = tempIList[0].ShotBackTemp;
        txtAdjustMouldPress.Text = tempIList[0].AdjustMouldPress;
        txtFastLockMouldSpeed.Text = tempIList[0].FastLockMouldSpeed;
        txtFastLockMouldPress.Text = tempIList[0].FastLockMouldPress;
        txtFastLockMouldPosition.Text = tempIList[0].FastLockMouldPosition;
        txtLowPressLockMouldSpeed.Text = tempIList[0].LowPressLockMouldSpeed;

        txtLowPressLockMouldPress.Text = tempIList[0].LowPressLockMouldPress;
        txtLowPressLockMouldPosition.Text = tempIList[0].LowPressLockMouldPosition;
        txtHighPressLockMouldSpeed.Text = tempIList[0].HighPressLockMouldSpeed;
        txtHighPressLockMouldPress.Text = tempIList[0].HighPressLockMouldPress;
        txtHighPressLockMouldPosition.Text = tempIList[0].HighPressLockMouldPosition;
        txtLowSpeedOpenMouldSpeed.Text = tempIList[0].LowSpeedOpenMouldSpeed;
        txtLowSpeedOpenMouldPress.Text = tempIList[0].LowSpeedOpenMouldPress;
        txtLowSpeedOpenMouldPosition.Text = tempIList[0].LowSpeedOpenMouldPosition;
        txtHighSpeedOpenMouldSpeed.Text = tempIList[0].HighSpeedOpenMouldSpeed;
        txtHighSpeedOpenMouldPress.Text = tempIList[0].HighSpeedOpenMouldPress;

        txtHighSpeedOpenMouldPosition.Text = tempIList[0].HighSpeedOpenMouldPosition;
        txtReduceSpeedOpenMouldSpeed.Text = tempIList[0].ReduceSpeedOpenMouldSpeed;
        txtReduceSpeedOpenMouldPress.Text = tempIList[0].ReduceSpeedOpenMouldPress;
        txtReduceSpeedOpenMouldPosition.Text = tempIList[0].ReduceSpeedOpenMouldPosition;
        txtThimbleBeginMouldPosition.Text = tempIList[0].ThimbleBeginMouldPosition;
        rblThimbleActKind.SelectedValue = (tempIList[0].ThimbleActKind.ToUpper() == "TRUE") ? "1" : "0";
        txtThimbleGoSpeed.Text = tempIList[0].ThimbleGoSpeed;
        txtThimbleGoPress.Text = tempIList[0].ThimbleGoPress;
        txtThimbleGoPosition.Text = tempIList[0].ThimbleGoPosition;
        txtThimbleBackSpeed.Text = tempIList[0].ThimbleBackSpeed;

        txtThimbleBackPress.Text = tempIList[0].ThimbleBackPress;
        txtThimbleBackPosition.Text = tempIList[0].ThimbleBackPosition;
        txtThimbleNum1.Text = tempIList[0].ThimbleNum1;
        txtThimbleShakeTime.Text = tempIList[0].ThimbleShakeTime;
        txtThimbleStayTime.Text = tempIList[0].ThimbleStayTime;

        txtPushSpeed.Text = tempIList[0].PushSpeed;
        txtPushPress.Text = tempIList[0].PushPress;
        txtBeforeGetWater.Text = tempIList[0].BeforeGetWaterSpeed;
        txtBeforeGetWaterTemp.Text = tempIList[0].BeforeGetWaterTemp;
        txtBeforeGetWaterMouldTemp.Text = tempIList[0].BeforeGetWaterMouldTemp;
        txtAfterGetWater.Text = tempIList[0].AfterGetWaterSpeed;
        txtAfterGetWaterTemp.Text = tempIList[0].AfterGetWaterTemp;
        txtAfterGetWaterMouldTemp.Text = tempIList[0].AfterGetWaterMouldTemp;
        txtGrossWeight.Text = tempIList[0].GrossWeight;
        txtMaterialNo.Text = tempIList[0].MaterialNo;
        txtRemark.Text = tempIList[0].Remark;
        qualiteremark.Text = tempIList[0].QualiteRemark;
        Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=StandTechnicsParams&ImgType=PhotoType&Img=Photo", vID);

        //igbUpdate.Attributes.Remove("onclick");
        //igbUpdate.Attributes.Add("onclick", "if(confirm('是否覆盖原记录?')){ window.document.getElementById('hashas').value='true' }else {window.document.getElementById('hashas').value='false'} ");
        
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }

    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList tempDropDownList = sender as DropDownList;
        SetDropDownList(tempDropDownList.ID);
        SetTextBox();
    }

    private void SetDropDownList(string pDropDownList)
    {
        string MouldNo = "";
        string ProductNo = "";
        IList<MouldMstr_MDL> tempList = null;

        if(pDropDownList == "ddlMouldNo")
        {
            MouldNo = ddlMouldNo.SelectedValue.Trim();
            tempList = MouldMstr_BLL.existsMouldMstr(MouldNo, ProductNo);
            dboSetCtrls.SetDropDownList(ddlProductNo, tempList as IList, false, "ProductNo", "ProductNo");
        }
        if(pDropDownList == "ddlProductNo")
        {
            ProductNo = ddlProductNo.SelectedValue.Trim();
            tempList = MouldMstr_BLL.existsMouldMstr(MouldNo, ProductNo);
            dboSetCtrls.SetDropDownList(ddlMouldNo, tempList as IList, false, "Mould_Code", "Mould_Code");
        }
    }

    private void SetTextBox()
    {
        string MouldNo = ddlMouldNo.SelectedValue.Trim();
        string ProductNo = ddlProductNo.SelectedValue.Trim();

        IList<MouldMstr_MDL> tempList = MouldMstr_BLL.existsMouldMstr(MouldNo, ProductNo);
        txtGoodSocketNum.Text = (tempList.Count == 0) ? "0" : tempList[0].GoodSocketNum.ToString();
    }


    protected void Hidden1_ServerChange(object sender, EventArgs e)
    {

    }
}
