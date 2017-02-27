using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using Admin.Model.BaseInfo_MDL;
using Admin.Model.Adminis_MDL;
using Admin.BLL.BaseInfo_BLL;
using Admin.BLL.Adminis_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.Call_DAL;

public partial class Administrator_UserInfo : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "UserInfo");
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

        if (!IsPostBack)
        {
            BindData();
            MultiView1.ActiveViewIndex = 0;
            trvies.Visible = false;
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlDeptID, Department_BLL.selectDepartment(0,"","") as IList, "DeptID", "DeptName");
            dboSetCtrls.SetDropDownList(ddlGroupID, GroupInfo_BLL.selectGroupInfo(0, "", "") as IList, "GroupID", "GroupName");
            //dboSetCtrls.SetDropDownList(ddlUserName, Employee_BLL.selectEmployee(0, "", "") as IList,false, "EmployeeID", "EmployeeName_CN");
            //dboSetCtrls.SetDropDownList(ddlUserName, new CallConfig_DAL().selectEmployee(0, "", "").Tables[0] , "EmployeeID", "EmployeeName_CN");
            ddlGroupID.Items.Insert(0,new ListItem("",""));
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<UserInfo_MDL> tempList = UserInfo_BLL.selectUserInfo(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }
    public string GetIP()
    {
        string uip = "";
        if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
        {
            uip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else
        {
            uip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
        return uip;
    } 

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;

        string userid = txtUserID.Text.Trim();
        string username = txtUserName.Text.Trim();
        //string username = tempButton.ID == "igbInsert" ? ddlUserName.SelectedValue.Trim() : TextBox1.Text.Trim();

        string password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Value.Trim(), "MD5");
        string pwd2=this.txtpwd2.Value.Trim();
        string sex = (rblSex.Text == "男") ? "男" : "女";
        string email = txtEmail.Text.Trim();
        string deptid = dempno.Value;// ddlDeptID.SelectedValue.Trim();
        string groupid = ddlGroupID.SelectedValue.Trim();
        string islock = (ckbIslock.Checked) ? "1" : "0";
        string lastip = GetIP();// (Dns.GetHostEntry(Dns.GetHostName()).AddressList)[0].ToString();
        DateTime sysdate = DateTime.Now;
        try
        {
            if (tempButton.ID == "igbInsert")
            {
                if (UserInfo_BLL.existsUserInfo(userid).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "存在相同的用户帐号!!");
                    return;
                }
                if (pwd2 == txtPassword.Value.Trim())
                {
                    UserInfo_BLL.insertUserInfo(userid, username, password, sex, email, deptid, groupid, islock, lastip, sysdate, sysdate);
                }
                else
                {
                    dboSetCtrls.SetExecMsg(this, "两次密码不相同,请再次输入!!");
                    this.txtpwd2.Value = "";
                    return;
                }
                dboSetCtrls.SetExecMsg(this, "insert", true);
            }
            else
            {
                int id = Int32.Parse(txtID.Text.Trim());
                if (UserInfo_BLL.existsUserInfo(this.Page.User.Identity.Name.Trim())[0].GroupID == "1")//为管理员时
                {
                    UserInfo_BLL.updateUserInfo(userid, FormsAuthentication.HashPasswordForStoringInConfigFile(pwd2, "MD5"));
                }
                int yt=UserInfo_BLL.updateUserInfo(id, userid, username, password, sex, email, deptid, groupid, islock, lastip, sysdate);
                if(yt>0)                
                    dboSetCtrls.SetExecMsg(this, "update", true);
                else
                    dboSetCtrls.SetExecMsg(this, "update", false);
            }
        }
        catch
        {
            if (tempButton.ID == "igbInsert") dboSetCtrls.SetExecMsg(this, "insert", false);
            else dboSetCtrls.SetExecMsg(this, "update", false);
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
                UserInfo_BLL.cancelUserInfo(pIDList);
            }
            else
            {

                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                UserInfo_BLL.cancelUserInfo(pIDList);
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
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtUserID);

            object[] textboxid = { txtID, txtUserID, txtEmail, txtLastIP };
            dboSetCtrls.InitCtrls(this, "textbox", textboxid);
            txtPassword.Disabled = false;
            txtPassword.Value = null;
            rblSex.SelectedIndex = 0;//= ddlDeptID.SelectedIndex
            ckbIslock.Checked = false;
            txtEmail.Enabled = false;
            TxtDept.Enabled = false;
            rblSex.Enabled = false;
            txtpwd2.Value = null;
            txtpwd2.Disabled = false;
            //ddlUserName.Enabled = true;
            //ddlUserName.Visible = true;
            txtUserName.Text="";
            TxtDept.Text = "";
            //RequiredFieldValidator1.ControlToValidate = "ddlUserName";
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
        txtPassword.Disabled = true;
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, "textbox", txtUserID);

        //ddlUserName.Visible = false;
        //txtUserName.Visible = true;
        //RequiredFieldValidator1.ControlToValidate = "TextBox1";
       
        string vID = txtID.Text = hdnID.Value =
                ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        IList<UserInfo_MDL> tempIList = UserInfo_BLL.selectUserInfo(Int32.Parse(vID), "", "");

        txtUserID.Text   = tempIList[0].UserID;
        //ddlUserName = dboSetCtrls.SetSelectedIndex(ddlUserName, tempIList[0].UserName);
        txtUserName.Text = tempIList.Count > 0 ? tempIList[0].UserName : "";
        TextBox1.Text = tempIList[0].UserName == "" ? "" : tempIList[0].UserName;
        txtPassword.Value= tempIList[0].Password;
        rblSex.Text      = tempIList[0].Sex;
        txtEmail.Text    = tempIList[0].Email;
       // ddlDeptID = dboSetCtrls.SetSelectedIndex(ddlDeptID, tempIList[0].DeptID);
        dempno.Value = tempIList[0].DeptID;
        this.TxtDept.Text = "";
       // TxtDept.Text = tempIList[0].DeptName==""? "" : tempIList[0].DeptName;
        IList<Employee_MDL> templistx = Employee_BLL.selectEmployee(0, "employeeid", tempIList[0].UserName);
        this.TxtDept.Text = tempIList[0].DeptName == "" ? "" : tempIList[0].DeptName; ;// ddlDeptID.Items[ddlDeptID.SelectedIndex].Text; //templistx[0].DeptName;
        ddlGroupID = dboSetCtrls.SetSelectedIndex(ddlGroupID, tempIList[0].GroupID);
        ckbIslock.Checked= (tempIList[0].Islock == "是") ? true : false;
        txtLastIP.Text   = tempIList[0].LastIP;
        IList<UserInfo_MDL> mylistx = UserInfo_BLL.existsUserInfo(this.Page.User.Identity.Name.Trim());
        if (mylistx[0].GroupID == "1")
        {
            txtpwd2.Disabled = false;
            txtpwd2.Value = null;
        }
        else
        {
            txtpwd2.Disabled = true;
            txtpwd2.Value = null;
        }
        txtEmail.Enabled = false;
        TxtDept.Enabled = false;
        rblSex.Enabled = false;
        
        //ddlUserName.Enabled = false;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string strs = ddlUserName.SelectedValue;
        //IList<Employee_MDL> templist = Employee_BLL.selectEmployee(0, "employeeid", strs);
        //this.TxtDept.Text = templist[0].DeptName;
        //dempno.Value = templist[0].DeptID;
        //txtEmail.Text = templist[0].EMail;
        //rblSex.Text = templist[0].Sex;
        //this.txtUserID.Text = templist[0].EmployeeID;
        //txtUserID.Enabled = false;
    }
}