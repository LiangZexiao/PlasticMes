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
using Admin.Model.Monitor_MDL;
using Admin.BLL.Monitor_BLL;
using Admin.SQLServerDAL.RightCtrl;

public partial class Tracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbl_False.Visible = false;
            BindData();
        }
    }

    private void BindData()
    {
        IList<AlarmInfo_MDL> tempList = AlarmInfo_BLL.selectAlarmInfo();
        DataList1.DataSource = tempList;
        DataList1.DataBind();
    }
}
