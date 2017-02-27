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
using Admin.BLL.Adminis_BLL;
using Admin.Model.Adminis_MDL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL;
using Admin.Model;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.BaseInfo_BLL;

public partial class Administrator_UserProgramMap : System.Web.UI.Page
{
    bool[] o = new bool[7] { false, false, false, false, false, false, false };
    SetCtrls dboSetCtrls = new SetCtrls();
    SQLExecutant sc = new SQLExecutant();
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "UserProgramMap");
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
            igbCancel.Attributes.Add("onclick", "BatchIsDeleted('GridView1')");
            igbDelete.Attributes.Add("onclick", "SingleIsDeleted('hdnID')");
            igbSearch.Attributes.Add("onclick", "ChgPageIndex('txtPageIndex')");
            //dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlUserID, UserInfo_BLL.selectUserInfo(0, "", "") as IList, false, "UserID", "UserID");
          //  dboSetCtrls.SetDropDownList(ddlProgramID, SysProgramInfo_BLL.selectProgramInfo(0, "", "") as IList, false, "ProgramID", "ProgramName");
            DataTable dt= sc.ExecQueryCmd("select   ClassID,ClassName from sysclassinfo order by classid");
            DataSet ds = sc.ExecQueryCmd2("SELECT DISTINCT   a.ID, a.ProgramID, a.ProgramName, a.RequestURL, a.ClassID, b.ClassName, a.OrderID, CASE Locked WHEN '1' THEN '是' ELSE '否' END AS Locked,CONVERT(char(10), a.aDate, 121) AS aDate, CONVERT(char(10), a.mDate, 121) AS mDate FROM  SysProgramInfo AS a LEFT OUTER JOIN SysClassInfo AS b ON a.ClassID = b.ClassID WHERE 1=1  ORDER BY a.ClassID ,a.OrderID ") as DataSet;
            IList<Manage_MDL> mylst = new List<Manage_MDL>();
            Manage_MDL mans;
            DataView dvs;
            DataTable dt3;
            for (int i = 0; i <dt.Rows.Count; i++)
            {
                mans = new Manage_MDL(dt.Rows[i][0].ToString(), "--" + dt.Rows[i][1].ToString() + "--");
                mylst.Add(mans);
                dvs = ds.Tables[0].DefaultView;
                dvs.RowFilter = "  ClassID=" + dt.Rows[i][0].ToString();
                dt3=dvs.ToTable();
                int y = dt3.Rows.Count;
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    mans = new Manage_MDL(dt3.Rows[j]["ProgramID"].ToString(),  dt3.Rows[j]["ProgramName"].ToString());
                    mylst.Add(mans);
                }
            }
            dboSetCtrls.SetDropDownList(ddlProgramID, mylst as IList, false, "ClassId", "ClassName");            
        }
    }

    private void BindData()
    {
        string colname = ddlQuery.SelectedValue.ToString().Trim();
        string coltext = txtQuery.Text.ToString().Trim();
        IList<UserProgramMap_MDL> tempList = UserProgramMap_BLL.selectUserProgramMap(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int vID = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string UserID = ddlUserID.SelectedValue.Trim();
        string ProgramID = ddlProgramID.SelectedValue.Trim();
        string AddFlag = ddlAddFlag.SelectedValue.Trim();
        string CnlFlag = ddlCnlFlag.SelectedValue.Trim();
        string MdyFlag = ddlMdyFlag.SelectedValue.Trim();
        string QuyFlag = ddlQuyFlag.SelectedValue.Trim();
        string PrtFlag = ddlPrtFlag.SelectedValue.Trim();
        string ChkFlag = ddlChkFlag.SelectedValue.Trim();

        string ChkFlagNO = ddlChkFlagNO.SelectedValue.Trim();

        DateTime Date = System.DateTime.Now;
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (UserID == "" || ProgramID == "")
            {
                dboSetCtrls.SetExecMsg(this, "请选择个人和程序代号!!");
                return;
            }
            if (tempButton.ID == "igbInsert")
            {
                if (UserProgramMap_BLL.existsUserProgramMap(UserID, ProgramID).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "exists",true);
                    return;
                }
            }
            if (tempButton.ID == "igbInsert")
            {
                if (ddlProgramID.SelectedItem.Text.ToString().Substring(0, 2) == "--")
                {
                    DataTable dt2 = sc.ExecQueryCmd("SELECT ID, UserID  FROM View_UserProgramMap WHERE 1=1 and UserID= '" + UserID + "' and classid='" + ProgramID + "'"); //UserProgramMap_BLL.selectUserProgramMap(0, "UserID", UserID);
                    ArrayList pIDList = new ArrayList();
                    for (int t = 0; t < dt2.Rows.Count; t++)
                    {
                        pIDList.Add(dt2.Rows[t]["ID"].ToString());
                    }
                    UserProgramMap_BLL.cancelUserProgramMap(pIDList);
                    //string sql = "select programid from SysProgramInfo where classId=" + ProgramID;
                    IList<ProgramInfo_MDL> lst = SysProgramInfo_BLL.selectProgramInfo(0, "ClassID", ProgramID);
                    int y = 0;
                    for (int j = 0; j < lst.Count; j++)
                    {
                        y = y + UserProgramMap_BLL.ChangeUserProgramMap(vID, UserID, lst[j].ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, Date, Date, IU);
                    }
                    if (y == lst.Count)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                    }
                }
                else
                {
                   if( UserProgramMap_BLL.ChangeUserProgramMap(vID, UserID,ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, Date, Date, IU)>0)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                    }
                }
            }
            else
            {
                if(UserProgramMap_BLL.ChangeUserProgramMap(vID, UserID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, Date, Date, IU)>0)
                dboSetCtrls.SetExecMsg(this, IU, true);
            }
            //UserProgramMap_BLL.ChangeUserProgramMap(vID, UserID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag, Date, Date, IU);
            
        }
        catch
        {
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
                UserProgramMap_BLL.cancelUserProgramMap(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                UserProgramMap_BLL.cancelUserProgramMap(pIDList);
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
            ArrayList tempList = new ArrayList();
            tempList.Add(new DropDownList[2] { ddlUserID, ddlProgramID });
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, new string[1] { "dropdownlist" }, tempList);

            object[] ddlistid = { ddlUserID, ddlProgramID, ddlAddFlag, ddlCnlFlag, ddlMdyFlag, ddlQuyFlag, ddlPrtFlag, ddlChkFlag };
            dboSetCtrls.InitCtrls(this, "dropdownlist", ddlistid);
            txtID.Text = null;
            Label1.Text = "";
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
        ArrayList tempList = new ArrayList();
        tempList.Add(new DropDownList[2] { ddlUserID, ddlProgramID });

        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, new string[1] { "dropdownlist"}, tempList);
        string vID = txtID.Text = hdnID.Value =
                ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        IList<UserProgramMap_MDL> tempIList = UserProgramMap_BLL.selectUserProgramMap(Int32.Parse(vID), "", "");

        ddlUserID = dboSetCtrls.SetSelectedIndex(ddlUserID, tempIList[0].UserID);
        ddlProgramID = dboSetCtrls.SetSelectedIndex(ddlProgramID, tempIList[0].ProgramID);
        ddlAddFlag.SelectedValue = (tempIList[0].AddFlag == "是") ? "1" : "0";
        ddlCnlFlag.SelectedValue = (tempIList[0].CnlFlag == "是") ? "1" : "0";
        ddlMdyFlag.SelectedValue = (tempIList[0].MdyFlag == "是") ? "1" : "0";
        ddlQuyFlag.SelectedValue = (tempIList[0].QuyFlag == "是") ? "1" : "0";
        ddlPrtFlag.SelectedValue = (tempIList[0].PrtFlag == "是") ? "1" : "0";
        ddlChkFlag.SelectedValue = (tempIList[0].ChkFlag == "是") ? "1" : "0";

        IList<UserInfo_MDL> lst = UserInfo_BLL.selectUserInfo(0, "UserID", tempIList[0].UserID)  ;
        Label1.Text = Employee_BLL.selectEmployee(0, "EmployeeID", lst[0].UserName).Count>0? Employee_BLL.selectEmployee(0, "EmployeeID", lst[0].UserName)[0].EmployeeName_CN.ToString():"";
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void ddlUserID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlss = sender as DropDownList;
        string str = ddlss.SelectedValue.ToString();
        IList<UserInfo_MDL> lst= UserInfo_BLL.selectUserInfo(0, "UserID", str)  ;
        Label1.Text = Employee_BLL.selectEmployee(0, "EmployeeID", lst[0].UserName).Count > 0 ? Employee_BLL.selectEmployee(0, "EmployeeID", lst[0].UserName)[0].EmployeeName_CN.ToString() : "";
    }
}
