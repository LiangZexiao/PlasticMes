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
using System.Web.UI.HtmlControls;
using Admin.BLL;
using Admin.Model;
using Admin.App_Code;
using Admin.Model.Adminis_MDL;
using Admin.BLL.Adminis_BLL;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Response.Write("<script> window.open('Tracker.aspx','_newwindow','status=no,scrollbars=yes,width=380,height=220,left=270,top=100'); </script>");
            string userid = (this.Page.User.Identity.IsAuthenticated) ? this.Page.User.Identity.Name.Trim() : string.Empty;
            // foreach (SysClassInfo_MDL sysclassinfo in 
            IList<SysClassInfo_MDL> mst = SysClassInfo_BLL.selectSysClassInfo(userid);
            // {
            // foreach (ProgramInfo_MDL programinfo in  SysProgramInfo_BLL.selectProgramInfo(userid, sysclassinfo.ClassID))
            // {
            IList<ProgramInfo_MDL> mst2 = SysProgramInfo_BLL.selectProgramInfo(userid, mst[0].ClassID.ToString());

            HttpContext.Current.Response.Redirect(mst2[0].RequestURL.ToString());
            //}
            //}
            //HttpContext.Current.Response.Redirect("Monitor/MonitorMachineMstr.aspx");            
        }//
    }
}