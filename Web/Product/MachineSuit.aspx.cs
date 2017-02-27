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


public partial class Product_MachineSuit : System.Web.UI.Page
{
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    private MachineSuit_DAL MachineSuit = new MachineSuit_DAL();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MachineSuit");
            ViewState["authority"] = o;

            if (o[0]) btnQuery.Visible = false;
            if (o[1]) btnNewadd.Visible = btnInsert.Visible = false;
            if (o[2])  btnUpdate.Visible = false;
            if (o[3]) btnCancel.Visible =btnDelete.Visible= false;
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
        if (Request.QueryString["MachineNo"] != null && Request.QueryString["MachineNo"].ToString().Trim() != "")
        {
            colname = "MachineCode";
            coltext = Request.QueryString["MachineNo"].ToString().Trim();
            btnNewadd.Visible = false;
            btnCancel.Visible = false;
            btnInsert.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        IList<MachineSuit_MDL> tempList = MachineSuit.selectMachineSuit(0, colname, coltext);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtMachineCode);
            txtMachineCode.Text =txtMachineCode.Text =  txtMakeDate.Value = txtMachineNumber.Text =  
            txtMachineSpace.Text = txtMachineUpNo.Text =  txtPower.Text = txtMaintainDate.Text =txtSuitBrush.Text =txtMachineType.Text= "";
            ddltxtManufacturers.SelectedIndex = ddlMachineAxisNum.SelectedIndex = 0;
            Image1.ImageUrl = null;
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
            t = MachineSuit.DeleteMachineSuit(pIDList);
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
        string MachineCode = txtMachineCode.Text.Trim().ToString();   //机器编号
        string Manufacturers = ddltxtManufacturers.SelectedValue.ToString();//制造厂商
        string MachineType = txtMachineType.Text.Trim().ToString();  //机器型号

        string MakeDate = txtMakeDate.Value.Trim().ToString(); //制造日期
        string MachineNumber = txtMachineNumber.Text.Trim().ToString();   //设备编号
        string MachineSpace = txtMachineSpace.Text.Trim().ToString() == "" ? "0" : txtMachineSpace.Text.Trim().ToString();   //植毛行程

        string MachineUpNo = txtMachineUpNo.Text.Trim().ToString(); //资产编号
        string MachineAxisNum = ddlMachineAxisNum.SelectedValue.ToString();// 机器轴数
        string Power =  txtPower.Text.Trim()==""?"0":txtPower.Text.Trim().ToString();  //功率
        string MaintainDate = txtMaintainDate.Text.Trim();//保养周期
        string SuitBrush = txtSuitBrush.Text.Trim();  //适应刷类1
        string Remark = txtRemark.Text.Trim();// 备注
      
        //***********************
        //产品图片
        HttpPostedFile hpf = fudProcessPhoto.PostedFile;
        object vImgType = hpf.ContentType;//图片类型
        int ImgLength = hpf.ContentLength;
        byte[] MachinePhoto = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            MachinePhoto = new GifOrJpg().MakeSmallImg(tempStream, 252, 174);//new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            MachinePhoto = new byte[0];
        }
        //*************************

        string UI = tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";
        try
        {
            MachineSuit_MDL call = new MachineSuit_MDL(txtID.Text.Trim().ToString(), MachineCode,MachineType,MachineAxisNum,
                Manufacturers,MakeDate,MachineSpace,SuitBrush,MachineNumber,MachineUpNo,Power,MaintainDate,MachinePhoto,Remark   );
            if (UI == "INSERT")
            {
                IList<MachineSuit_MDL> llist = MachineSuit.ExistsMachineSuit(0, "MachineCode", MachineCode);
                if(llist!=null)
                {
                    if (llist.Count > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, "存在相同机器编号!");
                        return;
                    }
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
            if (MachineSuit.InsertMachineSuit(call, UI) == 1)
            {
                dboSetCtrls.SetExecMsg(this, UI, true);
                Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=PlantBristlesMachineInfo&ImgType=MachinePhotoType&Img=MachinePhoto", txtID.Text.Trim().ToString());
                //BindData();
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

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;

        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], btnInsert, btnUpdate, btnDelete, "TEXTBOX", txtMachineCode);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.Trim().ToString().Trim();


        IList<MachineSuit_MDL> tempList = MachineSuit.selectMachineSuit(int.Parse(vID), "", "");

        txtMachineCode.Text = tempList[0].MachineCode;   //机器编号
        txtMachineType.Text = tempList[0].MachineType;  //机器型号
        ddlMachineAxisNum.SelectedValue = tempList[0].MachineAxisNum;// 机器轴数

       ddltxtManufacturers.SelectedValue=tempList[0].Manufacturers;//制造厂商
        txtMakeDate.Value=tempList[0].MakeDate; //制造日期
         txtMachineSpace.Text=tempList[0].MachineSpace;   //植毛行程
         txtSuitBrush.Text=tempList[0].SuitBrush;   //适应刷类
         txtMachineNumber.Text=tempList[0].MachineNumber;   //设备编号
        txtMachineUpNo.Text=tempList[0].MachineUpNo; //资产编号
       txtPower.Text=tempList[0].Power;  //功率
        txtMaintainDate.Text=tempList[0].MaintainDate;//保养周期
         txtRemark.Text = tempList[0].Remark;  //备注



         Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=PlantBristlesMachineInfo&ImgType=MachinePhotoType&Img=MachinePhoto", vID);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
