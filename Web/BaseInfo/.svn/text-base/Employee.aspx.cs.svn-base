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
using Admin.Model.Adminis_MDL;
using Admin.BLL.Adminis_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class BaseInfo_Employee : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"BaseInfo/Employee.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "Employee");
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
        if (!Page.IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
          //  dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlDepartment, Department_BLL.selectDepartment(0, "", "") as IList,false, "DeptID", "DeptName");
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<Employee_MDL> tempList = Employee_BLL.selectEmployee(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();

        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        ////*********************************************
        //HttpPostedFile hpf = fudPhoto.PostedFile;
        //int ImgLength = hpf.ContentLength;
        //byte[] Photo = new byte[ImgLength];
        //Stream tempStream = hpf.InputStream;
        //tempStream.Read(Photo, 0, ImgLength);
        //object PhotoType = hpf.ContentType;
        ////*********************************************
        //*********************************************
        HttpPostedFile hpf = fudPhoto.PostedFile;
        object PhotoType = hpf.ContentType;        
        int ImgLength = hpf.ContentLength;
        byte[] Photo = new byte[ImgLength];

        if (ImgLength > 0)
        {
            Stream tempStream = hpf.InputStream;
            Photo = new GifOrJpg().ReadeImage(tempStream);
        }
        else
        {
            Photo = new byte[0];
        }
        //*********************************************
        int ID = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string EmployeeID = txtEmployeeID.Text.Trim();
        string Name_CN = txtName_CN.Text.Trim();
        string Name_EN = txtName_EN.Text.Trim();
        string IDCardNo = txtIDCardNo.Text.Trim();
        string Sex = rblSex.SelectedValue.Trim();
        DateTime Birthday = (txtBirthday.Value.Trim() == "") ? DateTime.Now : DateTime.Parse(txtBirthday.Value.Trim());
        string Department = ddlDepartment.SelectedValue.Trim();

        string Province = ddlProvince.SelectedValue.Trim();
        string RankLevel = ddlRankLevel.SelectedValue.Trim();
        string Rank = ddlRank.SelectedValue.Trim(); //txtRank.Text.Trim();
        string RankDesc = ddlRank.SelectedItem.Text.Trim(); //txtRankDesc.Text.Trim();
        DateTime HireDate = (txtHireDate.Value.Trim() == "") ? DateTime.Now : DateTime.Parse(txtHireDate.Value.Trim());
        string Memo = txtMemo.Text.Trim();
        string Tel = this.txtTel.Text.Trim().ToString();
        string email = txtEmail.Text.Trim().ToString();
        string valid = ddlCard.SelectedValue.Trim();
        DateTime Date = System.DateTime.Now;
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            //if (tempButton.ID == "igbInsert")
            //{
            //    if (Employee_BLL.existsEmployee(EmployeeID).Count != 0)
            //    {
            //        dboSetCtrls.SetExecMsg(this, "存在相同的员工编号!!");
            //        return;
            //    }
            //}
            if (PhotoType.ToString().ToLower().IndexOf("image") < 0 && ImgLength > 0)
            {
                dboSetCtrls.SetExecMsg(this, "员工相片只能是图片!");
                return;
            }
            else
            {
                if (((ImgLength + 10 * 1024) / 1024) > 209)
                {
                    dboSetCtrls.SetExecMsg(this, "员工相片大小不能大于200KB!");
                    return;
                }
            }
            int t = Employee_BLL.ChangeEmployee(ID, EmployeeID, Name_CN, Name_EN, Photo, PhotoType, 
                          IDCardNo, Sex, Birthday, Department, Province, RankLevel, Rank, RankDesc,
                          HireDate, Memo, Tel, email,valid, IU);
            if (t > 0)
            {
                dboSetCtrls.SetExecMsg(this, IU, true);
            }
            else
            {
                dboSetCtrls.SetExecMsg(this, IU, false);
            }
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
                Employee_BLL.cancelEmployee(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                Employee_BLL.cancelEmployee(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmployeeID as object);
            object[] textboxid = { txtEmployeeID, txtName_CN, txtName_EN, txtIDCardNo,   txtMemo };
            txtBirthday.Value = txtHireDate.Value = null;
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            rblSex.SelectedIndex = ddlProvince.SelectedIndex = ddlDepartment.SelectedIndex =ddlRankLevel.SelectedIndex=ddlRank.SelectedIndex= 0;
            Image1.ImageUrl = null;
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
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtEmployeeID as object);
        string vID = txtID.Text = hdnID.Value =
            ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();

        IList<Employee_MDL> tempIList = Employee_BLL.selectEmployee(Int32.Parse(vID), "", "");
        txtEmployeeID.Text = tempIList[0].EmployeeID;
        txtName_CN.Text = tempIList[0].EmployeeName_CN;
        txtIDCardNo.Text = tempIList[0].IDCardNo;
        rblSex.SelectedValue = tempIList[0].Sex;
        txtBirthday.Value = tempIList[0].Birthday;
        ddlDepartment = dboSetCtrls.SetSelectedIndex(ddlDepartment, tempIList[0].Department); //tempIList[0].Department;

        ddlProvince = dboSetCtrls.SetSelectedIndex(ddlProvince, tempIList[0].Province);
        ddlRankLevel = dboSetCtrls.SetSelectedIndex(ddlRankLevel, tempIList[0].RankLevel);
        
        //txtRank.Text = tempIList[0].Rank;
        ddlRank = dboSetCtrls.SetSelectedIndex(ddlRank, tempIList[0].Rank);
        ddlCard = dboSetCtrls.SetSelectedIndex(ddlCard, tempIList[0].InvalidCode);

        txtHireDate.Value = tempIList[0].HireDate;
        txtMemo.Text = tempIList[0].Remark;
        txtTel.Text = tempIList[0].Tel;
        txticcard.Text = tempIList[0].IcCarId;
        txtEmail.Text = tempIList[0].EMail;
        Image1.ImageUrl = string.Format("~/ShowImage.aspx?ID={0}&TableName=Employee&ImgType=PhotoType&Img=Photo", vID);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
}
