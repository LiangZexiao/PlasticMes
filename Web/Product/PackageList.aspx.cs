﻿using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Model.Product_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Product_DAL;
using Admin.SQLServerDAL.GetErp;

public partial class Product_PackageList : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    PackageList_BLL bllPackageList = new PackageList_BLL();
    //PackageList_MDL mdlPackageList = null;

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "PackageList");
            ViewState["authority"] = o;

           
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
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
            bindGr(hdcode.Value);

        }
    }

    void bindGr(string str)
    {
        DataSet ds = new GetErpItm().QueryErpBomDetail(str);  //ERPSQLExecutant().ExecQueryCmd(sql);
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        string types = hdnTypes.Value;
        if (types.Trim() == "1")
            Response.Redirect("~/BaseInfo/ItemMstr.aspx?ItemMstrID=" + hdids.Value, true);//回到项目页面!!
        else
            Response.Redirect("SuitManage.aspx?ItemMstrID=" + hdids.Value, true);//回到项目页面!!
    }
}