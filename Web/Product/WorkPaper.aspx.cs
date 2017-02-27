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
using Admin.Model.Product_MDL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.BLL.BaseInfo_BLL;
using Admin.App_Code;
using Admin.SQLServerDAL.Product_DAL;

public partial class Product_WorkPaper : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    WorkPaper_BLL bllWorkPaper = new WorkPaper_BLL();
    WorkPaper_MDL mdlWorkPaper = null;

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "WorkPaper");
            ViewState["authority"] = o;

           
            //if (o[1]) btnInsert.Visible = false;
            btnUpdate.Visible = !o[2];//if (o[2]) false
            btnDelete.Visible = !o[3];//if (o[3])false
             btnPrint.Visible = !o[4];//if (o[4])false
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            try
            {
                hdcode.Value = Request.QueryString["Item_Code"].ToString().Trim() == "" ? "" : Request.QueryString["Item_Code"].ToString().Trim();//产品编号
                hdids.Value = Request.QueryString["id"].ToString().Trim();//产品ＩＤ
                hdnTypes.Value = Request.QueryString["types"].ToString().Trim(); //类型
            }
            catch (Exception ex)
            {
                hdcode.Value = "";
            }
           
            this.txtProdCode.Text = hdcode.Value;
            if (new WorkPaper_DAL().existsWorkPaper("ProdCode", hdcode.Value).Count > 0)
            {
                txtID.Text = new WorkPaper_DAL().existsWorkPaper("ProdCode", hdcode.Value)[0].ID;
                Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=WorkPaper&ImgType=Machine_PhotoType&Img=WorkGuidanceImg", txtID.Text.Trim());
            }
            else
            {
                txtID.Text = "";
                Image1.ImageUrl = null;
            }
          
            MultiView1.ActiveViewIndex =0;
            btnDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
        }
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
            }
           
            if (txtID.Text.Trim() != "")
            {
                t = new WorkPaper_DAL().deleteWorkPaper(pIDList);
            }
            else
            {
                t = -1;
            }

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
        string vID = txtID.Text.Trim() == "" ? "" : txtID.Text.Trim();
        string ProdCode = txtProdCode.Text.Trim();
        //*********************************************
        
        //产品图片
        HttpPostedFile hpf = fudProcessPhoto.PostedFile;
        object vImgType = hpf.ContentType;//图片类型
        int ImgLength = hpf.ContentLength;
        byte[] vImgs = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            vImgs = new GifOrJpg().MakeSmallImg(tempStream, 0, 0);//257, 234);// new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            vImgs = new byte[0];
        }
        //*********************************************

        string UI = "";// tempButton.ID == "btnInsert" ? "INSERT" : "UPDATE";

        try
        {
            mdlWorkPaper = new WorkPaper_MDL(vID, ProdCode, vImgs);
            if (vImgType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            {
                dboSetCtrls.SetExecMsg(this, "指导图只能是图片!");
                return;
            }
            {
                if (((ImgLength + 10 * 1024) / 1024) > 209)
                {
                    dboSetCtrls.SetExecMsg(this, "产品图大小不能大于200KB!");
                    return;
                }
            }
            if (new WorkPaper_DAL().existsWorkPaper("ProdCode", ProdCode).Count > 0 && tempButton.ID != "btnInsert")
            {
                UI = "UPDATE";
            }
            else
            {
                UI = "INSERT";
            }
            if (new WorkPaper_DAL().insertWorkPaper(mdlWorkPaper, UI) == 1)
            {
                dboSetCtrls.SetExecMsg(this, UI, true);
                if (UI == "INSERT")
                {
                    txtID.Text = new WorkPaper_DAL().existsWorkPaper("ProdCode", ProdCode)[0].ID.ToString();
                }
                Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=WorkPaper&ImgType=Machine_PhotoType&Img=WorkGuidanceImg", new WorkPaper_DAL().existsWorkPaper("ProdCode", ProdCode)[0].ID);
                //BindData();
            }
        }
        catch (Exception ex)
        {
            string temp = ex.ToString().Trim();
            dboSetCtrls.SetExecMsg(this, UI, false);
        }


    }
   
    
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        string types = hdnTypes.Value;
        if (types.Trim() == "1")
            Response.Redirect("~/BaseInfo/ItemMstr.aspx?ItemMstrID=" + hdids.Value, true);//回到项目页面!!
        else
            Response.Redirect("SuitManage.aspx?ItemMstrID=" + hdids.Value, true);//回到项目页面!!
    }
  

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        string ID = txtID.Text.Trim();
        if (ID == "")
        {
            dboSetCtrls.SetExecMsg(this, "没有记录不可以打印!!");
            return;
        }
        Session["WorkPaper_ID"] = ID;
        this.ClientScript.RegisterClientScriptBlock(GetType(), "open", @"<script> window.open('../repPrinter.aspx?ReportName=WorkPaper&ReportType=2') </script>");
    }
}