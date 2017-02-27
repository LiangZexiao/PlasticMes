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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Services;
using log4net;
using System.Reflection;

public partial class ExtjsMian : System.Web.UI.Page
{

    protected string JosnMsg;
    public string tmpUserName = string.Empty;
    SetCtrls dboSetCtrls = new SetCtrls();
    protected void Page_Load(object sender, EventArgs e)
    {
        dboSetCtrls.GetIdentiryInfo(this);
        try
        {
            //加载自定义报表的路径。Choose_CrystalReport为自定义报表节点a标签id
            //Choose_CrystalReport.HRef = ConfigurationManager.AppSettings["CrystalReportHref"];
            tmpUserName = (Session["UserID"] == null) ? "" : Session["UserID"].ToString().Trim();
        }
        catch (Exception ex)
        {
            string sTemp = ex.ToString().Trim();
        }

        ILog log = LogManager.GetLogger(this.GetType());

        String cmd = this.Request.Params["cmd"];
        String isAjax = this.Request.Params["isAjax"];

        if (String.IsNullOrEmpty(cmd))
        {

        }
        else
        {
            if (!string.IsNullOrEmpty(isAjax) && isAjax.Equals("1"))
            {
                try
                {
                    MethodInfo method = this.GetType().GetMethod(cmd);
                    method.Invoke(this, null);
                    Response.Write(JosnMsg);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        log.Error("执行出错。cmd=" + cmd + "。" + ex.InnerException.Message);
                        JosnMsg = ex.InnerException.Message;
                    }
                    else
                    {
                        log.Error("执行出错。cmd=" + cmd + "。" + ex.Message);
                        JosnMsg = ex.Message;
                    }
                    JosnMsg.Replace("\n", "");
                    JosnMsg.Replace("\r", "");
                    Response.Write("{success:false,msg:'" + JosnMsg + "'}");
                }
                finally
                {
                    Response.End();
                }
            }
            else
            {
                try
                {
                    MethodInfo method = this.GetType().GetMethod(cmd);
                    method.Invoke(this, null);
                }
                catch (Exception ex)
                {
                    log.Error("执行出错。cmd=" + cmd + "。" + ex.Message);
                    Response.Redirect("Result.aspx?msg=" + ex.InnerException.Message, false);
                }
            }
        }

    }
    //public void InitTreeLeft()
    //{
    //    string mlevel = Request.Params["mlevel"].ToString();
    //    string userid = (this.Page.User.Identity.IsAuthenticated) ? this.Page.User.Identity.Name.Trim() : string.Empty;
    //    DataSet Ds = new DataSet();
    //    Ds.ReadXml(Server.MapPath("xml/XMLInfoFile.xml"));
    //    string strJson = "[";
    //    if (mlevel == "0")
    //    {
    //        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
    //        {
    //            foreach (SysClassInfo_MDL sysclassinfo in SysClassInfo_BLL.selectSysClassInfo(userid))//查询登录者权限所有根目录节点
    //            {
    //                if (sysclassinfo.ClassID == Ds.Tables[0].Rows[i]["mlocation"].ToString() && Ds.Tables[0].Rows[i]["mlevel"].ToString() == "0")
    //                {
    //                    strJson += "{\"checked2\":false,\"children\":null,\"cls\":\"menu-node\",\"expanded\":false,\"iconCls\":null,\"id\":\"" + Ds.Tables[0].Rows[i]["mlocation"].ToString() + "\",\"leaf\":false,\"text\":\"" + Ds.Tables[0].Rows[i]["names"].ToString() + "\",\"url\":null},";
    //                }
    //            }
    //        }
    //        strJson = strJson.TrimEnd(',');
    //        strJson += "]";
    //    }
    //    else
    //    {
    //        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
    //        {
    //            foreach (ProgramInfo_MDL programinfo in SysProgramInfo_BLL.selectProgramInfo(userid, mlevel))//查询根目录下所有子节点
    //            {
    //                if (programinfo.RequestURL == Ds.Tables[0].Rows[i]["mulr"].ToString() && Ds.Tables[0].Rows[i]["mlevel"].ToString() != "0")
    //                {
    //                    strJson += "{\"checked2\":false,\"children\":null,\"cls\":\"menu-node2\",\"expanded\":false,\"iconCls\":\"node-leaf\",\"id\":\"" + Ds.Tables[0].Rows[i]["mlocation"].ToString() + "\",\"leaf\":true,\"text\":\"" + Ds.Tables[0].Rows[i]["names"].ToString() + "\",\"url\":\"" + Ds.Tables[0].Rows[i]["mulr"].ToString() + "\"},";
    //                }
    //            }
    //        }
    //        strJson = strJson.TrimEnd(',');
    //        strJson += "]";
    //    }
    //    JosnMsg = strJson;
    //}
    public void InitTreeLeft()
    {
        string mlevel = Request.Params["mlevel"].ToString();
        string userid = (this.Page.User.Identity.IsAuthenticated) ? this.Page.User.Identity.Name.Trim() : string.Empty;
        string strJson = "[";
        if (mlevel == "0")
        {
            foreach (SysClassInfo_MDL sysclassinfo in SysClassInfo_BLL.selectSysClassInfo(userid))//查询登录者权限所有根目录节点
            {
                strJson += "{\"checked2\":false,\"children\":null,\"cls\":\"menu-node\",\"expanded\":false,\"iconCls\":null,\"id\":\"" + sysclassinfo.ClassID + "\",\"leaf\":false,\"text\":\"" + sysclassinfo.ClassName + "\",\"url\":null},";
            }
            strJson = strJson.TrimEnd(',');
            strJson += "]";
        }
        else
        {
            foreach (ProgramInfo_MDL programinfo in SysProgramInfo_BLL.selectProgramInfo(userid, mlevel))//查询根目录下所有子节点
            {
                strJson += "{\"checked2\":false,\"children\":null,\"cls\":\"menu-node2\",\"expanded\":false,\"iconCls\":\"node-leaf\",\"id\":\"" + programinfo.ProgramID + "\",\"leaf\":true,\"text\":\"" + programinfo.ProgramName + "\",\"url\":\"" + programinfo.RequestURL + "\"},";
            }
            strJson = strJson.TrimEnd(',');
            strJson += "]";
        }
        JosnMsg = strJson;
    }
}


