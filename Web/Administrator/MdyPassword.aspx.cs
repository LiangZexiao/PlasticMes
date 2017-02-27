using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.BLL.Adminis_BLL;
using Admin.Model.Adminis_MDL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;

public partial class Administrator_MdyPassword : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["ClickMould"] = @"Administrator/MdyPassword.aspx";
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "MdyPassword");
            ViewState["authority"] = o;

            if (o[2]) igbUpdate.Visible = false;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            txtUserID.Text = this.Page.User.Identity.Name.Trim();
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        string userid = txtUserID.Text.Trim();
        string old_Input = pwdOld.Value.Trim();
        string new1 = pwdNew1.Value.Trim();
        string new2 = pwdNew2.Value.Trim();
        //if (userid.ToUpper() == "ADMIN")
        //{
        //    dboSetCtrls.SetExecMsg(this, "系统管理员的密码不可以修改!!");
        //    return;
        //}
        string EnPswdStr_old = FormsAuthentication.HashPasswordForStoringInConfigFile(old_Input, "MD5");

        IList<UserInfo_MDL> tempList = UserInfo_BLL.existsUserInfo(userid);
        string old_Select = tempList[0].Password.Trim();
        if (EnPswdStr_old != old_Select)
        {
            dboSetCtrls.SetExecMsg(this, "你输入的旧密码错误!!");
            return;
        }
        if (new1 != new2)
        {
            dboSetCtrls.SetExecMsg(this, "新密码不一致!!");
            return;
        }
        string EnPswdStr_new = FormsAuthentication.HashPasswordForStoringInConfigFile(new1, "MD5");
        UserInfo_BLL.updateUserInfo(userid, EnPswdStr_new);
        dboSetCtrls.SetExecMsg(this, "修改密码成功!!");
    }
}
