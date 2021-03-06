﻿using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Chart;
using Admin.BLL.Product_BLL;
using Admin.SQLServerDAL.Product_DAL;
using Admin.Model.Product_MDL;
using Admin.BLL.Collect_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.Model.Collect_MDL;
using Admin.App_Code;

public partial class Quality_QualityTrack : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    const string IMG_HEIGHT = "560";
    const string IMG_WIDTH = "1000";
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "QualityTrack");
            ViewState["authority"] = o;
            if (o[0]) igbSured.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            string Today = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            txtBeginDate.Value = txtEndDate.Value = Today;
            //txtTime1.Value = "07:20";
            //txtTime2.Value = "07:20";
            BinaDataToCtrl();
            LoadPage(0);
        }
    }

    /// <summary>
    /// update by fsq 
    /// update date:2010-06-18
    /// 去掉下拉框。
    /// </summary>
    
    public void BinaDataToCtrl()
    {
        DataHistory_BLL bllDataHistory = new DataHistory_BLL();
        string bDate = string.Empty;
        string eDate = string.Empty;
        string ProductNo = string.Empty;
        string MouldNo = string.Empty;
        string MachineNo = string.Empty;

        if (Session["bDate"] != null && Session["eDate"] != null)
        {
            bDate = Session["bDate"].ToString().Trim();
            eDate = Session["eDate"].ToString().Trim();
        }
        else
        {
            bDate = txtBeginDate.Value.Trim();
            eDate = txtEndDate.Value.Trim();
        }

        //start 
        //DataTable dts = bllDataHistory.SelectProductNoFrDh(bDate, eDate);

        //dboSetCtrls.SetDropDownList(ddlDispatchOrder, dts, "DispatchOrder", "DispatchOrder");
        //dboSetCtrls.SetDropDownList(ddlMachineNo, bllDataHistory.selectMachineNoFromDataHistory(bDate, eDate), "clientip", "MachineNo");
        //ddlDispatchOrder.SelectedIndex = ddlMachineNo.SelectedIndex=0;
        //for (int i = 0; i < ddlDispatchOrder.Items.Count; i++)
        //{
        //    if (Session["DispatchNo"] != null && ddlDispatchOrder.Items[i].ToString() == Session["DispatchNo"].ToString())
        //    {
        //        ddlDispatchOrder.SelectedIndex = i;
        //    }
        //}
        //for (int i = 0; i < ddlMachineNo.Items.Count; i++)
        //{
        //    if (Session["MachineNo"] != null && ddlMachineNo.Items[i].ToString() == Session["MachineNo"].ToString())
        //    {
        //        ddlMachineNo.SelectedIndex = i;
        //    }
        //}
        //end


        //dboSetCtrls.SetDropDownList(ddlProductNo, bllDataHistory.SelectProductNoFrDh(bDate, eDate), "ProductNo", "ProductNo");
        ////if (Session["ProductNo"] != null)
        ////    ProductNo = Session["ProductNo"].ToString().Trim();
        ////else
        //    ProductNo = ddlProductNo.SelectedValue.Trim();
        //dboSetCtrls.SetDropDownList(ddlMouldNo, bllDataHistory.SelectMouldNoFrDh(bDate, eDate, ProductNo), "MouldNo", "MouldNo");
        ////if (Session["MouldNo"] != null)
        ////    MouldNo = Session["MouldNo"].ToString().Trim();
        ////else
        //    MouldNo = ddlMouldNo.SelectedValue.Trim();
        //dboSetCtrls.SetDropDownList(ddlMachineNo, bllDataHistory.SelectMachineNoFrDh(bDate, eDate, ProductNo, MouldNo), "MachineNo", "MachineNo");
    }

    protected void ddlProductNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClickCtrl(ddlProductNo);
        SetSessionValue();
        //LoadPage();
    }

    protected void ddlMouldNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClickCtrl(ddlMouldNo);
        SetSessionValue();
        //LoadPage();
    }

    protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drop = sender as DropDownList;
        //Session["DispatchNo"] = ddlDispatchOrder.SelectedValue.Trim();
        //Session["MachineNo"] = ddlMachineNo.SelectedValue.Trim();
        SetSessionValue();
        if (drop.ID == "ddlMachineNo")
        {
            SetSessionValue2(1);
        }
        //LoadPage();
    }

    private void BindClickCtrl(DropDownList ddl)
    {
        DataHistory_BLL bllDataHistory = new DataHistory_BLL();

        string bDate = string.Empty;
        string eDate = string.Empty;
        if (Session["bDate"] != null && Session["eDate"] != null)
        {
            bDate = Session["bDate"].ToString().Trim();
            eDate = Session["eDate"].ToString().Trim();
        }
        else
        {
            bDate = txtBeginDate.Value.Trim() ;
            eDate = txtEndDate.Value.Trim() ;
        }
        
        //IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(ddlDispatchOrder.SelectedValue.Trim());
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(txtDispatchOrder.Value.Trim());
        
        string DispatchOrder = "";
        string productno = "";
        string mouldno = "";
        string machineno = "";
        if (tempList.Count > 0)
        {
            DispatchOrder = tempList[0].DO_No;
            productno = tempList[0].ProductNo;//DispatchOrder_BLL.existsDispatchOrder(ddlDispatchOrder.SelectedValue.Trim()); // ddlProductNo.SelectedValue.Trim();
            mouldno = tempList[0].MouldNo;// ddlMouldNo.SelectedValue.Trim();
            machineno = tempList[0].MachineNo;// ddlMachineNo.SelectedValue.Trim();
        }
        
        //string ProductNo = ddlProductNo.SelectedValue.Trim();
        //start 
       // if (ddl == ddlDispatchOrder)
       // {
       //     //绑定机器编号控件
       //     dboSetCtrls.SetDropDownList(ddlMachineNo, bllDataHistory.SelectMouldNoFrDh(bDate, eDate, DispatchOrder), "MachineNo", "MachineNo");
       // }
       // if (ddl == ddlDispatchOrder)
       // {
       //     //绑定模具编号控件
       //     dboSetCtrls.SetDropDownList(ddlMouldNo, bllDataHistory.SelectMouldNoFrDh(bDate, eDate, DispatchOrder), "MouldNo", "MouldNo");
       // }
       //// string MouldNo = ddlMouldNo.SelectedValue.Trim();
       // //绑定机器编号控件
       // dboSetCtrls.SetDropDownList(ddlMachineNo, bllDataHistory.SelectMachineNoFrDh(bDate, eDate, productno, mouldno), "MachineNo", "MachineNo");
       // //绑定派工单号控件
       // dboSetCtrls.SetDropDownList(ddlMachineNo, bllDataHistory.SelectMachineNoFrDh(bDate, eDate, productno, mouldno), "DispatchNo", "DispatchNo");
        //end 
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton tempLinkButton = sender as LinkButton;

        for (int i = 0; i < Tinf.Rows[0].Cells.Count - 1; i++)
            Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");

        string Target = "QualityTrack_Cycle";
        int CellsIndex = 0;
        switch (tempLinkButton.ID.Trim())
        {
            case "LinkButton1":
                Target = "QualityTrack_Cycle";
                CellsIndex = 0;
                break;

            case "LinkButton6":
                Target = "QualityTrack_IntervalInfo";
                CellsIndex = 1;
                break;
            case "LinkButton5":
                Target = "QualityTrack_InjectTime"; //"QualityTrack_PreInjectTime";
                CellsIndex = 2;
                break;
            case "LinkButton2":
                Target = "QualityTrack_Temp";
                CellsIndex = 3;
                break;
            case "LinkButton3":
                Target = "QualityTrack_Press";
                CellsIndex = 4;
                break;
            case "LinkButton4":
                Target = "QualityTrack_MaxPress";
                CellsIndex = 5;
                break;
            default:
                Target = "QualityTrack_Cycle";
                CellsIndex = 0;
                break;
        }
        hdnTarget.Value = Target;
        hdnCellIndex.Value = CellsIndex.ToString();
        Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");
        SetSessionValue();
        LoadPage(1);
    }

    private void LoadPage(int flag)
    {
        if (Session["HttpEquiv"] != null)
            chkRefresh.Checked = (Session["HttpEquiv"].ToString().Trim() == "Refresh") ? true : false;
        else
            chkRefresh.Checked = false;

        SetHttpEquiv();

        string bDate = txtBeginDate.Value.Trim();
        string eDate = txtEndDate.Value.Trim();
        string dispatchorder = txtDispatchOrder.Value.Trim();
        if (string.IsNullOrEmpty(bDate))
        {
            dboSetCtrls.SetExecMsg(this, "请输入起始日期!!");
            return;
        }
        if ((string.IsNullOrEmpty(dispatchorder) || dispatchorder == "") && flag==1)
        {
            dboSetCtrls.SetExecMsg(this, "请输入派工单号!!");
            return;
        }

        if (Session["Target"] != null &&
            Session["CellsIndex"] != null &&
            Session["bDate"] != null && Session["eDate"] != null &&
            Session["MachineNo"] != null &&
            Session["DispatchNo"] !=null)
        {
            hdnTarget.Value = Session["Target"].ToString().Trim();
            hdnCellIndex.Value = Session["CellsIndex"].ToString().Trim();
            
            bDate = Session["bDate"].ToString().Trim();
            eDate = Session["eDate"].ToString().Trim();
            txtBeginDate.Value = bDate;
            //txtTime1.Value = bDate.Substring(11, 5).Trim();
            txtEndDate.Value = eDate;
            //txtTime2.Value = eDate.Substring(11, 5).Trim();
        }

        string Target = hdnTarget.Value.Trim();
        int CellsIndex = int.Parse(hdnCellIndex.Value.Trim());
        //string dispatchorder=ddlDispatchOrder.SelectedValue.Trim();
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(dispatchorder);
        string productno="";
        string mouldno="";
       //string machineno = ddlMachineNo.SelectedItem.Text.Trim();
        string machineno = txtMachineNo.Value.Trim(); 
        if (tempList.Count > 0)
        {
            productno = tempList[0].ProductNo.Trim();
            mouldno = tempList[0].MouldNo.Trim();
            machineno = tempList[0].MachineNo.Trim();
        }
        string ActionNum =  ddlAction.SelectedValue.Trim();

        bDate = txtBeginDate.Value.Trim();
        eDate = txtEndDate.Value.Trim();

        if (Target == "QualityTrack_Press")
        {
            ActionNum = "-100";
        }

        for (int i = 0; i < Tinf.Rows[0].Cells.Count - 1; i++)
            Tinf.Rows[0].Cells[i].Attributes.Add("background", "../images/tab_off.gif");
        Tinf.Rows[0].Cells[CellsIndex].Attributes.Add("background", "../images/tab_on.gif");
        subnet.Attributes.Add("src", Target + ".aspx?URLID=QualityTrack&IMG_HEIGHT=" + IMG_HEIGHT + "&IMG_WIDTH=" + IMG_WIDTH + "&StartDate=" + bDate + "&EndDate=" + eDate + "&Dispatchorder=" + dispatchorder + "&MachineNo=" + machineno + "&MouldNo=" + mouldno + "&ProductNo=" + productno + "&ActionNum=" + ActionNum + "&AdjustData=1");
    }

    protected void igbSured_Click(object sender, ImageClickEventArgs e)
    {
        Session["bDate"] = txtBeginDate.Value.Trim();
        Session["eDate"] = txtEndDate.Value.Trim();

        //Session["DispatchNo"] = ddlDispatchOrder.SelectedValue.Trim();
        Session["DispatchNo"] = txtDispatchOrder.Value.Trim();
        BinaDataToCtrl();
        SetSessionValue();
        LoadPage(1);
    }

    private void SetSessionValue()
    {
        Session["Target"] = hdnTarget.Value.Trim();
        Session["CellsIndex"] = hdnCellIndex.Value.Trim();

        Session["bDate"] = txtBeginDate.Value.Trim() ;
        Session["eDate"] = txtEndDate.Value.Trim();
        //IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(ddlDispatchOrder.SelectedValue.Trim());
        IList<DispatchOrder_MDL> tempList = DispatchOrder_BLL.existsDispatchOrder(txtDispatchOrder.Value.Trim());
        string productno = "";
        string mouldno = "";
        string machineno = "";
        if (tempList.Count > 0)
        {
            productno = tempList[0].ProductNo;//DispatchOrder_BLL.existsDispatchOrder(ddlDispatchOrder.SelectedValue.Trim()); // ddlProductNo.SelectedValue.Trim();
            mouldno = tempList[0].MouldNo;// ddlMouldNo.SelectedValue.Trim();
            machineno = tempList[0].MachineNo;// ddlMachineNo.SelectedValue.Trim();
        }
        Session["ProductNo"] = productno;// ddlProductNo.SelectedValue.Trim();
        Session["MouldNo"] = mouldno;// ddlMouldNo.SelectedValue.Trim();
      //  Session["MachineNo"] = machineno;// ddlMachineNo.SelectedValue.Trim();
        //Session["DispatchNo"] = ddlDispatchOrder.s//DispatchNo;
    }

    private void SetSessionValue2(int t)
    {
        Session["Target"] = hdnTarget.Value.Trim();
        Session["CellsIndex"] = hdnCellIndex.Value.Trim();

        string bDate= txtBeginDate.Value.Trim();
        string eDate= txtEndDate.Value.Trim();
        Session["bDate"] = bDate;
        Session["eDate"] = eDate;
        if (t == 1)//如果为机器选择时
        {
            //dboSetCtrls.SetDropDownList(ddlDispatchOrder, new DataHistory_BLL().SelectMachineNoFrDh(bDate, eDate, ddlMachineNo.SelectedValue,""),  "DispatchNo", "DispatchNo");
        }
       // Session["MachineNo"] =  ddlMachineNo.SelectedValue.Trim();
        //Session["DispatchNo"] = ddlDispatchOrder.s//DispatchNo;
    }

    protected void chkRefresh_CheckedChanged(object sender, EventArgs e)
    {
        Session["bDate"] = txtBeginDate.Value.Trim();
        Session["eDate"] = txtEndDate.Value.Trim();
        //Session["DispatchNo"] = ddlDispatchOrder.SelectedValue.Trim();
        Session["DispatchNo"] = txtDispatchOrder.Value.Trim();
        BinaDataToCtrl();
        SetSessionValue();
        SetHttpEquiv();
        LoadPage(1);
    }

    private void SetHttpEquiv()
    {
        if (chkRefresh.Checked)
        {
            Session["HttpEquiv"] = Refresh.HttpEquiv = "Refresh";
            Refresh.Content = hdnTime.Value.Trim();
        }
        else
        {
            Session["HttpEquiv"] = Refresh.HttpEquiv = "Content-Type";
            Refresh.Content = "text/xml";
        }
    }
}