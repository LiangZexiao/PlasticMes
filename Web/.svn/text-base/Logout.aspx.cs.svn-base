using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["ClickMould"] = null;
        //Response.Redirect("~/login.aspx");
        FormsAuthentication.SignOut(); 
        Response.Write("<script language=javascript>window.top.location='login.aspx';</script>");
    }
}
