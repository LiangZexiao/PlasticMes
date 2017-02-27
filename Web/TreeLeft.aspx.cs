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
using Admin.Model.Adminis_MDL;
using Admin.BLL.Adminis_BLL;
using Admin.App_Code;

public partial class TreeLeft : System.Web.UI.Page
{
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitTreeLeft();
        dboSetCtrls.GetIdentiryInfo(this);
    }

    private void InitTreeLeft()
    {
        TreeView1.Nodes.Clear();
        string userid = (Session["UserID"] != null) ? this.Page.User.Identity.Name.Trim() : string.Empty;
        foreach (SysClassInfo_MDL sysclassinfo in SysClassInfo_BLL.selectSysClassInfo(userid))
        {
            TreeNode bole = new TreeNode();
            bole.Value = sysclassinfo.ClassID;
            bole.Text  = sysclassinfo.ClassName;
            foreach (ProgramInfo_MDL programinfo in SysProgramInfo_BLL.selectProgramInfo(userid, sysclassinfo.ClassID))
            {
                if (sysclassinfo.ClassID != "99")
                {
                    TreeNode leaf = new TreeNode();
                    leaf.Value = programinfo.ProgramID;
                    leaf.Text = programinfo.ProgramName;
                    leaf.NavigateUrl = programinfo.RequestURL;
                    leaf.Target = "main";
                    bole.ChildNodes.Add(leaf);
                }
                else
                {
                    bole.Value = programinfo.ProgramID;
                    bole.Text = programinfo.ProgramName;
                    bole.NavigateUrl = "Logout.aspx";//programinfo.RequestURL;
                    bole.Target = "main";
                }
            }
            TreeView1.Nodes.Add(bole);
        }
    }
}
