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
using Admin.BLL.Adminis_BLL;
using Admin.Model.Adminis_MDL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL;
using Admin.Model;

public partial class Administrator_GroupProgramMap : System.Web.UI.Page
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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "GroupProgramMap");
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
          //  dboSetCtrls.SetInfoDropDownList(ddlQuery, GridView1);
            dboSetCtrls.SetDropDownList(ddlGroupID, GroupInfo_BLL.selectGroupInfo(0, "", "") as IList, "GroupID","GroupName");
            //dboSetCtrls.SetDropDownList(ddlProgramID, SysProgramInfo_BLL.selectProgramInfo(0, "", "") as IList, false, "ProgramID", "ProgramName");
            DataTable dt = sc.ExecQueryCmd("select   ClassID,ClassName from sysclassinfo order by classid");
            DataSet ds = sc.ExecQueryCmd2("SELECT DISTINCT   a.ID, a.ProgramID, a.ProgramName, a.RequestURL, a.ClassID, b.ClassName, a.OrderID, CASE Locked WHEN '1' THEN '是' ELSE '否' END AS Locked,CONVERT(char(10), a.aDate, 121) AS aDate, CONVERT(char(10), a.mDate, 121) AS mDate FROM  SysProgramInfo AS a LEFT OUTER JOIN SysClassInfo AS b ON a.ClassID = b.ClassID WHERE 1=1  ORDER BY a.ClassID ,a.OrderID ") as DataSet;
            IList<Manage_MDL> mylst = new List<Manage_MDL>();
            Manage_MDL mans;
            DataView dvs;
            DataTable dt3;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mans = new Manage_MDL(dt.Rows[i][0].ToString(), "--" + dt.Rows[i][1].ToString() + "--");
                mylst.Add(mans);
                dvs = ds.Tables[0].DefaultView;
                dvs.RowFilter = "  ClassID=" + dt.Rows[i][0].ToString();
                dt3 = dvs.ToTable();
                int y = dt3.Rows.Count;
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    mans = new Manage_MDL(dt3.Rows[j]["ProgramID"].ToString(), dt3.Rows[j]["ProgramName"].ToString());
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
        IList<GroupProgramMap_MDL> tempList = GroupProgramMap_BLL.selectGroupProgramMap(0, colname, coltext);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, tempList.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int id = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string GroupID = ddlGroupID.SelectedValue.Trim();
        string ProgramID = ddlProgramID.SelectedValue.Trim();
        string AddFlag = ddlAddFlag.SelectedValue.Trim();
        string CnlFlag = ddlCnlFlag.SelectedValue.Trim();
        string MdyFlag = ddlMdyFlag.SelectedValue.Trim();
        string QuyFlag = ddlQuyFlag.SelectedValue.Trim();
        string PrtFlag = ddlPrtFlag.SelectedValue.Trim();
        string ChkFlag = ddlChkFlag.SelectedValue.Trim();

        DateTime Date = System.DateTime.Now;
        string IU = (tempButton.ID == "igbInsert") ? "INSERT" : "UPDATE";
        try
        {
            if (GroupID == "" || ProgramID == "")
            {
                dboSetCtrls.SetExecMsg(this, "请选择群组和程序代号!!");
                return;
            }
            if (tempButton.ID == "igbInsert")
            {
                if (GroupProgramMap_BLL.existsGroupProgramMap(GroupID, ProgramID).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "exists", true);
                    return;
                }
            }
            GroupProgramMap_BLL.ChangeGroupProgramMap(id, GroupID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag, Date, Date, IU);
            dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        try
        {
            ArrayList pIDList = new ArrayList();
            if (tempButton.ID == "igbDelete")
            {
                pIDList.Add(txtID.Text.Trim());
                GroupProgramMap_BLL.cancelGroupProgramMap(pIDList);
            }
            else
            {
                pIDList = dboSetCtrls.GetCancelRecordID(GridView1);
                GroupProgramMap_BLL.cancelGroupProgramMap(pIDList);
                BindData();
            }
            dboSetCtrls.SetExecMsg(this, "delete", true);            
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, "delete", false);
        }
    }

    protected void btnVisible_Click(object sender, EventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        if (tempButton.ID == "igbNewadd")
        {
            MultiView1.ActiveViewIndex = 1;
            ArrayList tempList = new ArrayList();
            tempList.Add(new DropDownList[2] { ddlGroupID, ddlProgramID });
            dboSetCtrls.SetCtrlEnabled(true, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, new string[1] { "dropdownlist" }, tempList);
            object[] ddlistid = { ddlGroupID, ddlProgramID, ddlAddFlag, ddlCnlFlag, ddlMdyFlag, ddlQuyFlag, ddlPrtFlag, ddlChkFlag };
            dboSetCtrls.InitCtrls(this, "dropdownlist", ddlistid);
            txtID.Text = null;
        }
        else
        {
            if (tempButton.ID != "igbQuery")
                MultiView1.ActiveViewIndex = 0;
            BindData();
        }
    }

    protected void CtrlPageInfo_Click(object sender, EventArgs e)
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

        tempList.Add(new DropDownList[2] { ddlGroupID, ddlProgramID });
        dboSetCtrls.SetCtrlEnabled(false, !o[1], !o[2], igbInsert, igbUpdate, igbDelete, new string[1] { "dropdownlist" }, tempList);

        string vID = txtID.Text = hdnID.Value =
                ((GridView1.Rows[e.NewSelectedIndex].Cells[1].Controls[0]) as LinkButton).Text.ToString().Trim();
        IList<GroupProgramMap_MDL> tempIList = GroupProgramMap_BLL.selectGroupProgramMap(Int32.Parse(vID), "", "");

        ddlGroupID = dboSetCtrls.SetSelectedIndex(ddlGroupID, tempIList[0].GroupID);
        ddlProgramID = dboSetCtrls.SetSelectedIndex(ddlProgramID, tempIList[0].ProgramID);
        ddlAddFlag.SelectedValue = (tempIList[0].AddFlag == "是") ? "1" : "0";
        ddlCnlFlag.SelectedValue = (tempIList[0].CnlFlag == "是") ? "1" : "0";
        ddlMdyFlag.SelectedValue = (tempIList[0].MdyFlag == "是") ? "1" : "0";
        ddlQuyFlag.SelectedValue = (tempIList[0].QuyFlag == "是") ? "1" : "0";
        ddlPrtFlag.SelectedValue = (tempIList[0].PrtFlag == "是") ? "1" : "0";
        ddlChkFlag.SelectedValue = (tempIList[0].ChkFlag == "是") ? "1" : "0";
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dboSetCtrls.SetGridViewColorOfMouseEvent(GridView1);
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempButton = sender as ImageButton;
        int id = (txtID.Text.Trim() == "") ? 0 : Int32.Parse(txtID.Text.Trim());
        string GroupID = ddlGroupID.SelectedValue.Trim();
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
            if (GroupID == "" || ProgramID == "")
            {
                dboSetCtrls.SetExecMsg(this, "请选择群组和程序代号!!");
                return;
            }
            if (tempButton.ID == "igbInsert")
            {
                if (GroupProgramMap_BLL.existsGroupProgramMap(GroupID, ProgramID).Count != 0)
                {
                    dboSetCtrls.SetExecMsg(this, "exists", true);
                    return;
                }
            }
            if (tempButton.ID == "igbInsert")
            {
                if (ddlProgramID.SelectedItem.Text.ToString().Substring(0, 2) == "--")
                {
                    DataTable dt2 = sc.ExecQueryCmd("SELECT ID, GroupID  FROM View_GroupProgramMap WHERE 1=1 and GroupID= '" + GroupID + "' and classid='" + ProgramID + "'"); //UserProgramMap_BLL.selectUserProgramMap(0, "UserID", UserID);
                    ArrayList pIDList = new ArrayList();
                    for (int t = 0; t < dt2.Rows.Count; t++)
                    {
                        pIDList.Add(dt2.Rows[t]["ID"].ToString());
                    }
                    GroupProgramMap_BLL.cancelGroupProgramMap(pIDList);
                    //string sql = "select programid from SysProgramInfo where classId=" + ProgramID;
                    IList<ProgramInfo_MDL> lst = SysProgramInfo_BLL.selectProgramInfo(0, "ClassID", ProgramID);
                    int y = 0;
                    for (int j = 0; j < lst.Count; j++)
                    {
                        y = y + GroupProgramMap_BLL.ChangeGroupProgramMap(id, GroupID, lst[j].ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag,ChkFlagNO, Date, Date, IU);
                    }
                    if (y == lst.Count)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                    }
                }
                else
                {
                    if (GroupProgramMap_BLL.ChangeGroupProgramMap(id, GroupID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag, ChkFlagNO, Date, Date, IU) > 0)
                    {
                        dboSetCtrls.SetExecMsg(this, IU, true);
                    }
                }
            }
            else
            {
                if (GroupProgramMap_BLL.ChangeGroupProgramMap(id, GroupID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag, ChkFlagNO, Date, Date, IU) > 0)
                    dboSetCtrls.SetExecMsg(this, IU, true);
            }
           // GroupProgramMap_BLL.ChangeGroupProgramMap(id, GroupID, ProgramID, AddFlag, CnlFlag, MdyFlag, QuyFlag, PrtFlag, ChkFlag, Date, Date, IU);
           // dboSetCtrls.SetExecMsg(this, IU, true);
        }
        catch
        {
            dboSetCtrls.SetExecMsg(this, IU, false);
        }
    }
}
