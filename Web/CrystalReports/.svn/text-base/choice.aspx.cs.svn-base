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
using Admin.BLL.Machine_BLL;
using Admin.Model.BaseInfo_MDL;
using Admin.BLL.Product_BLL;
using Admin.Model.Product_MDL;
using Admin.BLL.Quality_BLL;
using Admin.Model.Quality_MDL;
using Admin.BLL.Collect_BLL;

using Admin.BLL.BaseInfo_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Admin.SQLServerDAL.CrystalReports_DAL;

using Admin.SQLServerDAL;

public partial class CrystalReports_choice : System.Web.UI.Page
{
    CrystalReports crd = new CrystalReports();
    SetCtrls dboSetCtrls = new SetCtrls();
    DataTable daitab;
    List<string> arry = new List<string>();


    // Response.Write(Request.QueryString["tabname"]+"<br>"+Request.QueryString["cels"]);
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //o[4]--打印,列印
    //o[5]--审核
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };

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
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "choice");
            ViewState["authority"] = o;

            // if (o[0]) btn_query.Visible = false;
            if (o[4]) igbsubmit.Visible = false;

        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            binddrop();
            this.Panel1.Visible = false;
        }
        else
        {
            //txtwhere.Attributes.Add("onKeyUp", @"this.value=this.value.replace(/[^\d{2}^\'^\>^\=^\<^\.^\ ^\:^\&H8 ^\-^a-zA-Z^\u3447-\uFA29]/gi,'')");
        }
    }
    void binddrop()
    {
        int t = 0;
        try
        {
            t = int.Parse(Session["celsnum"].ToString());//int.Parse(this.num.Value.ToString()); //int.Parse(Session["celsnum"].ToString()); 
        }
        catch
        {
            t = int.Parse(Request.QueryString["num"].ToString());
        }
        //t= int.Parse(Session["celsnum"].ToString()); //int.Parse(Request.QueryString["num"].ToString());
        this.num.Value = t.ToString();
        if (t <= 2)
        {
            if (t == 1)
            {
                this.key1.Visible = false;
                this.keydrop1.Visible = false;
                this.keydrop2.Visible = false;
                this.keydata1.Visible = false;
                this.keydata2.Visible = false;
                this.key2.Visible = false;
                this.keydrop3.Visible = false;
                this.keydrop4.Visible = false;
                this.keydata3.Visible = false;
                this.keydata4.Visible = false;
                RequiredFieldValidator3.Visible = false;
                RequiredFieldValidator4.Visible = false;
                RequiredFieldValidator2.Visible = false;
                RequiredFieldValidator1.Visible = false;


            }
            else
            {
                this.key2.Visible = false;
                this.keydrop3.Visible = false;
                this.keydrop4.Visible = false;
                this.keydata3.Visible = false;
                this.keydata4.Visible = false;
                RequiredFieldValidator3.Visible = false;
                RequiredFieldValidator4.Visible = false;
            }
        }
        else
        {
        }

        for (int j = 1; j <= 4; j++)
        {
            (this.Page.FindControl("keydrop" + j.ToString()) as DropDownList).Items.Add(new ListItem("--请选择--", "0"));
        }
        try
        {
            for (int i = 1; i <= t; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    string a = Session["tabname" + i.ToString()].ToString();
                    //string b=Session["tabname" + i.ToString()].ToString();
                    (this.Page.FindControl("keydrop" + j.ToString()) as DropDownList).Items.Add(new ListItem(a, a));
                }

            }
        }
        catch
        {
        }
    }


    protected void CtrlPageInfo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton tempImageButton = sender as ImageButton;
        GridView1.PageIndex = System.Convert.ToInt32(((ImageButton)sender).CommandName) - 1;
        bindgr();

    }
    protected void igbQuery_Click(object sender, ImageClickEventArgs e)
    {

        if (labtab1.Text == "" || (labtab1.Text == "" && labtab2.Text == ""))
        {
            bindgr();
            // Response.Write((GridView1.DataSource as DataTable).Rows.Count.ToString());
            if ((GridView1.DataSource as DataTable).Rows.Count > 1)
            {
                this.Panel1.Visible = true;
            }
            else
            {
                this.Panel1.Visible = false;
            }

        }
        //MultiView1.ActiveViewIndex = 1;

    }

    void bindgr()
    {
        int t = 0;
        try
        {
            t = int.Parse(this.num.Value.ToString()); //int.Parse(Session["celsnum"].ToString()); 
        }
        catch
        {

        }
        string keytabname1 = this.keydrop1.SelectedValue.ToString();
        string strsql = "select ";
        int x = 1;
        GridView1.Columns.Clear();
        GridView2.Columns.Clear();
        for (int i = 1; i <= t; i++)
        {
            foreach (string s in Session["cels" + i.ToString()].ToString().Split(','))
            {
                strsql += Session["tabname" + i.ToString()].ToString() + "." + s.ToString() + " as c" + x.ToString() + ",";

                BoundField sa = new BoundField();
                sa.HeaderText = s.ToString();
                sa.DataField = "c" + x.ToString();
                //sa.ItemStyle.Width = System.Web.UI.WebControls.Unit.Parse("5");
                sa.ItemStyle.Wrap = true;
                sa.HeaderStyle.Width =System.Web.UI.WebControls.Unit.Parse("5");
                sa.HeaderStyle.Wrap = true;
                
                GridView1.Columns.Add(sa);
                GridView2.Columns.Add(sa);
                ++x;
            }
          //  x--;
            //x++;
        }
        strsql = strsql.Substring(0, strsql.Length - 1) + " from ";
        if (!(this.key1.Visible) && !(this.key2.Visible))
        {
            strsql += Session["tabname1"].ToString();
        }
        if (this.key1.Visible)
        {
            if (this.keydrop1.SelectedValue.ToString() != "0" && this.keydrop2.SelectedValue.ToString() != "0")
                strsql += this.keydrop1.SelectedValue.ToString() + " inner join " + this.keydrop2.SelectedValue.ToString() + " on " + this.keydrop1.SelectedValue.ToString() + "." + this.keydata1.SelectedValue.ToString() + "=" + this.keydrop2.SelectedValue.ToString() + "." + this.keydata2.SelectedValue.ToString();
        }
        if (this.key2.Visible)
        {
            if (this.keydrop3.SelectedValue.ToString() != "0" && this.keydrop4.SelectedValue.ToString() != "0")
                strsql += " inner join " + this.keydrop3.SelectedValue.ToString() + " on " + this.keydrop3.SelectedValue.ToString() + "." + this.keydata4.SelectedValue.ToString() + "=" + this.keydrop4.SelectedValue.ToString() + "." + this.keydata4.SelectedValue.ToString();
        }
        if (this.txtwhere.Text.ToString() != "")
        {
            strsql += " where 1=1 and " + this.txtwhere.Text.ToString();
        }

        // Response.Write(strsql);
        try
        {
            if (crd.setsql(strsql).Rows.Count > 0)
            {
                daitab = crd.setsql(strsql);
            }
            else
            {
                daitab = new DataTable();
                ClientScript.RegisterStartupScript(this.GetType(), "s", "<script>alert('无数据!')</script>");
            }
        }
        catch (Exception ex)
        {
            daitab = new DataTable();
            ClientScript.RegisterStartupScript(this.GetType(), "s", "<script>alert('无数据!')</script>");
        }
        finally
        {

        }
        GridView1.DataSource = daitab;
        GridView1.DataBind();
        GridView2.DataSource = daitab;
        GridView2.DataBind();
        dboSetCtrls.SetInfoOfPage(lblDataCount, lblPageIndex, GridView1, crd.setsql(strsql).Rows.Count);
        dboSetCtrls.SetInfoOfImageButtonPage(igbFirst, igbPrior, igbNext, igbLast, GridView1);

    }
    protected void keyDropSelected(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        int t = int.Parse(this.num.Value.ToString());
        for (int i = 1; i <= t; i++)
        {
            arry.Add(Session["tabname" + i.ToString()].ToString());
        }
        if (drop.ID == "keydrop1")
        {
            keydata1.DataSource = crd.SelCell(drop.SelectedValue.ToString());
            keydata1.DataTextField = "colname";
            keydata1.DataValueField = "colname";
            keydata1.DataBind();
        }
        if (drop.ID == "keydrop2")
        {
            keydata2.DataSource = crd.SelCell(drop.SelectedValue.ToString());
            keydata2.DataTextField = "colname";
            keydata2.DataValueField = "colname";
            keydata2.DataBind();
            if ((this.Page.FindControl("keydrop1") as DropDownList).SelectedValue == drop.SelectedValue.ToString() && (this.Page.FindControl("keydrop1") as DropDownList).SelectedValue != "0")
            {
                labtab1.Text = "KEY1中不能选择相同表名!";
            }
            else
            {
                labtab1.Text = "";
            }
            string str = "";
            foreach (string i in arry)
            {
                if ((this.Page.FindControl("keydrop1") as DropDownList).SelectedValue.ToString() != i.ToString() && (this.Page.FindControl("keydrop2") as DropDownList).SelectedValue.ToString() != i.ToString())
                {
                    str = i.ToString();
                    if (key2.Visible)
                    {
                        (this.Page.FindControl("keydrop3") as DropDownList).Items.Clear();
                        (this.Page.FindControl("keydrop3") as DropDownList).Items.Add(new ListItem("--请选择--", "0"));
                        (this.Page.FindControl("keydrop3") as DropDownList).Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }

                }
            }
        }
        if (drop.ID == "keydrop3")
        {
            keydata3.DataSource = crd.SelCell(drop.SelectedValue.ToString());
            keydata3.DataTextField = "colname";
            keydata3.DataValueField = "colname";
            keydata3.DataBind();
        }
        if (drop.ID == "keydrop4")
        {
            keydata4.DataSource = crd.SelCell(drop.SelectedValue.ToString());
            keydata4.DataTextField = "colname";
            keydata4.DataValueField = "colname";
            keydata4.DataBind();

            if ((this.Page.FindControl("keydrop3") as DropDownList).SelectedValue == drop.SelectedValue.ToString() && (this.Page.FindControl("keydrop3") as DropDownList).SelectedValue != "0")
            {
                labtab2.Text = "KEY2中不能选择相同表名!";
            }
            else
            {

                labtab2.Text = "";

            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    { }


    protected void igbsubmit_Click(object sender, ImageClickEventArgs e)
    {
        bindgr();
        Response.Clear();
        GridView ddd = new GridView();
        ddd.DataSource = (GridView1.DataSource as DataTable).DefaultView;
        ddd.DataBind();
        if ((GridView1.DataSource as DataTable).Rows.Count > 0)
        {
            for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            {
                (ddd.HeaderRow.Cells[i] as DataControlFieldHeaderCell).Text = GridView1.HeaderRow.Cells[i].Text.ToString();
            }
            ddd.AllowPaging = false;
            ddd.EnableViewState = false;
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=saa.xls");// + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = true;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ddd.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            //ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>document.write(" + tw.ToString() + ")</script>");
            HttpContext.Current.Response.End();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ass", "<script>alert('无数据!')</script>");
        }


        //prints(); 
    }
    void prints()
    {
        bindgr();
        DataGrid dg = new DataGrid();
        dg.DataSource = daitab;
        dg.DataBind();

        System.Web.UI.WebControls.DataGrid dgExport = null;

        System.Web.HttpContext curContext = System.Web.HttpContext.Current; //   当前对话    

        System.IO.StringWriter strWriter = null;  //   IO用于导出并返回excel文件 
        System.Web.UI.HtmlTextWriter htmlWriter = null;
        GridView1.EnableViewState = false;
        if (daitab != null)
        {

            //   设置编码和附件格式     
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            curContext.Response.Charset = "";

            //   导出excel文件     
            strWriter = new System.IO.StringWriter();
            htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

            //   为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid     
            dgExport = new System.Web.UI.WebControls.DataGrid();
            dgExport.DataSource = (GridView2.DataSource as DataTable).DefaultView;//daitab.DefaultView;//dtData.DefaultView;
            dgExport.AllowPaging = false;
            dgExport.DataBind();

            //   返回客户端     
            dgExport.RenderControl(htmlWriter);
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.End();
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "d", "window.print();");
    }

}

