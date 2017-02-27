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

public partial class CrystalReports_Choose_CrystalReport : System.Web.UI.Page
{
    private CrystalReports crd = new CrystalReports();
    //*****************************************************
    //o[0]--浏览,查询
    //o[1]--新增,添加
    //o[2]--修改
    //o[3]--删除
    //o[4]--打印,列印
    //o[5]--审核
    //*****************************************************
    bool[] o = new bool[7] { false, false, false, false, false, false, false };

    SetCtrls dboSetCtrls = new SetCtrls();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.bindTb();
        bindbtn();
        try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "Choose_CrystalReport");
            ViewState["authority"] = o;

            //if (o[0]) btn_query.Visible = false;
            //if (o[4]) btn_print.Visible = false;

        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }
        this.DataBind();


    }
    //动态生成Table
    void bindTb()
    {
        DataTable myTab = crd.SelTab();
        this.tables1.Rows.Clear();
        int counts = 0;

        counts = int.Parse(this.dropnum.SelectedValue.ToString());
        for (int i = 1; i <= counts; i++)
        {
            TableRow tbr1 = new TableRow();
            TableCell tbc1 = new TableCell();
            TableCell tbc2 = new TableCell();
            TableCell tbc3 = new TableCell();
            TableCell tbc4 = new TableCell();


            tbc1.Width = Unit.Parse("10%");
            Label lb1 = new Label();
            lb1.ID = "lb" + i.ToString(); ;
            lb1.Text = "绑定数据表:";
            tbc1.HorizontalAlign = HorizontalAlign.Center;
            tbc1.Controls.Add(lb1);
            tbr1.Cells.Add(tbc1);


            DropDownList drop = new DropDownList();
            tbc2.Width = Unit.Parse("25%");
            drop.ID = "drop" + i.ToString();
            //drop.SelectedIndexChanged += new EventHandler(selectindex);
            drop.Width = Unit.Parse("196px");
            drop.DataSource = myTab;
            drop.DataTextField = "table_name";
            drop.DataValueField = "table_name";
            drop.DataBind();
            //drop.AutoPostBack = true;

            tbc2.Controls.Add(drop);
            tbr1.Cells.Add(tbc2);


            tbc3.Width = Unit.Parse("10%");
            Label lb2 = new Label();
            lb2.ID = "lb2" + i.ToString(); ;
            lb2.Text = "数据表列:";
            tbc3.HorizontalAlign = HorizontalAlign.Center;
            tbc3.Controls.Add(lb2);
            tbr1.Cells.Add(tbc3);


            tbc4.Width = Unit.Parse("55%");
            Button btn = new Button();
            btn.Text = "选择";
            btn.ID = i.ToString();
            btn.Click += new EventHandler(btn_Click2);
            // HtmlInputButton btn = new HtmlInputButton();
            // btn.Type = "button";

            TextBox tx = new TextBox();
            tx.ID = "txt" + i.ToString();
            tx.Width = Unit.Parse("350px");
            //onkeyup="value=value.replace(/[^\u4e00-\u9fa5]/g,)" 
            //tx.Attributes.Add("onkeyup",
            Label lbx = new Label();
            lbx.ID = "lbx" + i.ToString(); ;
            lbx.Text = "";
            lbx.ForeColor = System.Drawing.Color.Red;
            // tx.ReadOnly = true;
            tbc4.Controls.Add(tx);

            tbc4.Controls.Add(btn);
            tbc4.Controls.Add(lbx);

            tbr1.Cells.Add(tbc4);

            this.tables1.Rows.Add(tbr1);
        }

    }

    /// <summary>
    /// 自定义方法，用于页面跳转与传值
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void btn_Click2(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        string tname = (this.tables1.FindControl("drop" + bt.ID.ToString()) as DropDownList).SelectedValue.ToString();
        //"<script> window.open('SelectCell.aspx?d=" + bt.ID + "&tabname=" + tname + "','hfh','top=200,left=300,height=400,width=350
        ClientScript.RegisterStartupScript(GetType(), "a", "<script> window.open('SelectCell.aspx?d=" + bt.ID + "&tabname=" + tname + "','hfh','top=200,left=300,width=350,height=400,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')</script>");
    }
    public void btn_Click(object sender, EventArgs e)
    {
        int t = int.Parse(this.dropnum.SelectedValue.ToString());
        string tabname1 = "";
        string tabname2 = "";
        string tabname3 = "";
        string strce1 = "";
        string strce2 = "";
        string strce3 = "";
        Session["celsnum"] = t;
        if (t == 1)
        {
            tabname1 = (this.tables1.FindControl("drop1") as DropDownList).SelectedValue.ToString();
            strce1 = (this.tables1.FindControl("txt1") as TextBox).Text.Trim().ToString();
            if (strce1 != "")
            {
                Session["tabname1"] = tabname1.ToString();
                Session["cels1"] = strce1.ToString();
                //Response.Redirect("choice.aspx?tabname=" + tabname1 + "&cels=" + strce1+"&num=1", true);
                Response.Redirect("choice.aspx?num=1");
            }
            else
            {
                (this.tables1.FindControl("lbx1") as Label).Text = "数据表列不能为空!";
            }
        }
        if (t == 2)
        {
            tabname1 = (this.tables1.FindControl("drop1") as DropDownList).SelectedValue.ToString();
            strce1 = (this.tables1.FindControl("txt1") as TextBox).Text.Trim().ToString();
            tabname2 = (this.tables1.FindControl("drop2") as DropDownList).SelectedValue.ToString();
            strce2 = (this.tables1.FindControl("txt2") as TextBox).Text.Trim().ToString();
            if (strce1 != "" && strce2 != "")
            {
                Session["tabname1"] = tabname1.ToString();
                Session["cels1"] = strce1.ToString();
                Session["tabname2"] = tabname2.ToString();
                Session["cels2"] = strce2.ToString();
                // Response.Redirect("choice.aspx?tabname=" + tabname1 + ";" + tabname2 + "&cels=" + strce1 + ";" + strce2 + "&num=1", true);
                Response.Redirect("choice.aspx?num=2");
            }
            else
            {
                if (strce1 == "")
                {
                    (this.tables1.FindControl("lbx1") as Label).Text = "数据列表不能为空!";
                }
                if (strce2 == "")
                {
                    (this.tables1.FindControl("lbx2") as Label).Text = "数据列表不能为空!";
                }
            }
            //Response.Redirect("choice.aspx");
        }
        if (t == 3)
        {
            tabname1 = (this.tables1.FindControl("drop1") as DropDownList).SelectedValue.ToString();
            strce1 = (this.tables1.FindControl("txt1") as TextBox).Text.Trim().ToString();
            tabname2 = (this.tables1.FindControl("drop2") as DropDownList).SelectedValue.ToString();
            strce2 = (this.tables1.FindControl("txt2") as TextBox).Text.Trim().ToString();
            tabname3 = (this.tables1.FindControl("drop3") as DropDownList).SelectedValue.ToString();
            strce3 = (this.tables1.FindControl("txt3") as TextBox).Text.Trim().ToString();
            if (strce1 != "" && strce2 != "")
            {
                Session["tabname1"] = tabname1.ToString();
                Session["cels1"] = strce1.ToString();
                Session["tabname2"] = tabname2.ToString();
                Session["cels2"] = strce2.ToString();
                Session["tabname3"] = tabname3.ToString();
                Session["cels3"] = strce3.ToString();
                // Response.Redirect("choice.aspx?tabname=" + tabname1 + ";" + tabname2 + ";" + tabname3 + "&cels=" + strce1 + ";" + strce2 + ";" + strce3 + "&num=1", true);
                Response.Redirect("choice.aspx?num=3");
            }
            else
            {
                if (strce1 == "")
                {
                    (this.tables1.FindControl("lbx1") as Label).Text = "数据表列不能为空!";
                }
                if (strce2 == "")
                {
                    (this.tables1.FindControl("lbx2") as Label).Text = "数据表列不能为空!";
                }
                if (strce3 == "")
                {
                    (this.tables1.FindControl("lbx3") as Label).Text = "数据表列不能为空!";
                }
            }
        }

    }
    protected void selectindex(object sender, EventArgs e)
    {

        DropDownList dr = (DropDownList)sender;
        this.tabname.Text = dr.SelectedValue.ToString();
        string s = dr.ID.ToString().Substring(4).ToString();
        (this.tables1.FindControl(dr.ID.ToString()) as DropDownList).ID.ToString();
        ClientScript.RegisterStartupScript(this.GetType(), "cxcx", "<script>alert('" + dr.ID.ToString() + "')</script>");
        string tname = dr.SelectedValue.ToString();


    }

    protected void dropnum_SelectedIndexChanged(object sender, EventArgs e)
    {

        this.bindTb();

        this.DataBind();
    }
    void bindbtn()
    {
        TableRow tbrx = new TableRow();
        TableCell tbcx = new TableCell();
        tbrx.Width = Unit.Parse("100%");
        tbrx.HorizontalAlign = HorizontalAlign.Center;
        Button btn = new Button();
        btn.Text = "下一步";
        btn.ID = "btnnext";
        btn.Click += new EventHandler(btn_Click);
        tbcx.Controls.Add(btn);
        tbrx.Cells.Add(tbcx);
        this.tabx2.Rows.Add(tbrx);
    }
}
