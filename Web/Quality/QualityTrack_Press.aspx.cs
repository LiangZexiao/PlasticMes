using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Chart;
using Admin.BLL.Collect_BLL;
using Admin.BLL.Quality_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Newtonsoft.Json;

public partial class Quality_QualityTrack_Press : System.Web.UI.Page
{
   // bool[] o = new bool[7] { false, false, false, false, false, false, false };
    //SetCtrls dboSetCtrls = new SetCtrls();

    static string URLID;
    //static int IMG_WIDTH;//1000
    //static int IMG_HEIGHT;//560
    static string bDate;//2016-10-14 08:22
    static string eDate;//2016-10-14 08:22
    static string MachineNo;//""
    static string MouldNo;//""
    static string ProductNo;//""
    //    static string ActionNum;//1
    static string DispatchOrder;//""
    int maxTotal = 0;
    static int firstFlag = 0;
    string json = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["URLID"] != null && Request.QueryString["URLID"].ToString().Trim().Equals("QualityTrack"))
        {
            URLID = Request.QueryString["URLID"].ToString().Trim();//QualityTrack
            //IMG_WIDTH = int.Parse(Request.QueryString["IMG_WIDTH"].ToString().Trim());//1000
            //IMG_HEIGHT = int.Parse(Request.QueryString["IMG_HEIGHT"].ToString().Trim());//560
            bDate = Request.QueryString["StartDate"].ToString().Trim();//2016-10-14 08:22
            eDate = Request.QueryString["EndDate"].ToString().Trim();//2016-10-14 08:22
            MachineNo = Request.QueryString["MachineNo"].ToString().Trim();//""
            MouldNo = Request.QueryString["MouldNo"].ToString().Trim();//""
            ProductNo = Request.QueryString["ProductNo"].ToString().Trim();//""
            //   ActionNum = Request.QueryString["ActionNum"].ToString().Trim();//1
            DispatchOrder = Request.QueryString["Dispatchorder"].ToString().Trim();//""
            firstFlag = 1;
        }
        else
        {
            BindData(0);
        }
        /*try
        {
            dboSetCtrls.GetIdentiryInfo(this);
            if (IsPostBack)
            {
                o = (bool[])ViewState["authority"];
                return;
            }
            o = RightCtrl.PageRightCtrl(this.Page.User.Identity.Name.Trim(), "QualityTrack");
            ViewState["authority"] = o;
        }
        catch (Exception ex)
        {
            dboSetCtrls.SetExecMsg(this, ex.ToString());
        }
        if (!IsPostBack)
        {
            BindData(0);
        }*/
    }

    private void BindData(int Flag)
    {
        CycleMap cycleMap = new CycleMap();
        DataTable dt = new DataHistory_BLL().selectActionNumFromDataHistory(DispatchOrder, MachineNo, MouldNo, ProductNo, bDate, eDate);//查询到selectid rowid id totalnum
        DataTable stand_dt = new DataTable();
        DataTable lived_dt = new DataTable();
        int LabelPage = 0;
        if (dt.Rows.Count > 0 && dt != null || firstFlag == 0)
        {
            maxTotal = dt.Rows.Count;
            cycleMap.TotalPageNum = maxTotal / 5 + (maxTotal % 5 == 0 ? 0 : 1);
            //cycleMap.TotalNum = Convert.ToInt32(dt.Rows[0]["TotalNum"]);
            string startTotalNum = "";
            string endTotalNum = "";
            if (Request["LabelPage"] != null && Convert.ToInt32(Request["LabelPage"]) != 0)
            {
                LabelPage = Convert.ToInt32(Request["LabelPage"]);
                if (Request["whoButton"].Equals("xiaPage"))
                {
                    if ((LabelPage + 1) * 5 > dt.Rows.Count)
                    {
                        cycleMap.OnoffButton = "offxia";
                        LabelPage++;
                        startTotalNum = dt.Rows[(LabelPage - 1) * 5][3].ToString();
                        endTotalNum = dt.Rows[dt.Rows.Count - 1][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }
                    else
                    {
                        LabelPage++;
                        startTotalNum = dt.Rows[(LabelPage - 1) * 5][3].ToString();
                        endTotalNum = dt.Rows[(LabelPage) * 5 - 1][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }


                }
                else if (Request["whoButton"].Equals("shangPage"))
                {
                    if (LabelPage == 2)
                    {
                        cycleMap.OnoffButton = "offshang";
                        LabelPage--;
                        startTotalNum = dt.Rows[0][3].ToString();
                        endTotalNum = dt.Rows[99][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }
                    else
                    {
                        LabelPage--;
                        startTotalNum = dt.Rows[(LabelPage - 1) * 5][3].ToString();
                        endTotalNum = dt.Rows[(LabelPage) * 5 - 1][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }
                }
                else
                {

                }
            }
            else
            {
                if (dt.Rows.Count < 5)
                {
                    startTotalNum = dt.Rows[0][3].ToString();
                    endTotalNum = dt.Rows[(dt.Rows.Count - 1)][3].ToString();
                }
                else
                {
                    startTotalNum = dt.Rows[0][3].ToString();

                    endTotalNum = dt.Rows[4][3].ToString();
                }
                cycleMap.OnoffButton = "offshang";
                cycleMap.PageNum = "1";
                //   cycleMap.PageNum = startTotalNum;              
            }

            string[] TotalNum = { startTotalNum, endTotalNum };
            stand_dt = new QualityTrack_BLL().selectStandShotTemp(MachineNo, MouldNo, ProductNo);
            lived_dt = new QualityTrack_BLL().selectPress(DispatchOrder, MachineNo, MouldNo, ProductNo, bDate, eDate, TotalNum);
            int[] time = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < lived_dt.Rows.Count; i++)
            {
                cycleMap.YData1.Add(Convert.ToInt32(Convert.ToDouble(lived_dt.Rows[i]["TotalNum"])));
                for (int j = 0; j < time.Length; j++)
                {
                    cycleMap.XData.Add(time[j]);
                    cycleMap.YData.Add(Convert.ToInt32(Convert.ToDouble(Convert.IsDBNull(lived_dt.Rows[i]["KeepPress" + (j + 1)]) ? 0 : lived_dt.Rows[i]["KeepPress" + (j + 1)])));
                }
            }

            cycleMap.MachineNo = MachineNo;
            cycleMap.DispatchOrder = DispatchOrder;
            //cycleMap.IMG_HEIGHT = IMG_HEIGHT;
            //cycleMap.IMG_WIDTH = IMG_WIDTH;
            cycleMap.MachineNo = MachineNo;
            cycleMap.MouldNo = MouldNo;
            cycleMap.bDate = bDate;
            cycleMap.eDate = eDate;
        }
        else
        {
            firstFlag = 0;
            cycleMap.PageNum = "0";
        }
        json = JsonConvert.SerializeObject(cycleMap);
        Response.Clear();
        Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Write(json);
        Response.End();  
        /*
        string URLID = Request.QueryString["URLID"].ToString().Trim();
        int IMG_WIDTH = int.Parse(Request.QueryString["IMG_WIDTH"].ToString().Trim());
        int IMG_HEIGHT = int.Parse(Request.QueryString["IMG_HEIGHT"].ToString().Trim());

        string bDate = Request.QueryString["StartDate"].ToString().Trim();
        string eDate = Request.QueryString["EndDate"].ToString().Trim();
        string MachineNo = Request.QueryString["MachineNo"].ToString().Trim();
        string MouldNo = Request.QueryString["MouldNo"].ToString().Trim();
        string ProductNo = Request.QueryString["ProductNo"].ToString().Trim();
        string DispatchOrder = Request.QueryString["Dispatchorder"].ToString().Trim();

        if (Flag == 0)
        {
            DataTable dt = new DataHistory_BLL().selectActionNumFromDataHistory(DispatchOrder,MachineNo, MouldNo, ProductNo, bDate, eDate);
            dboSetCtrls.SetDropDownList(ddlImageIndex, dt, false, "RowID", "TotalNum");

            if (ddlImageIndex.SelectedValue.Trim() == "") { ddlImageIndex.Items.RemoveAt(0); }
            if (ddlImageIndex.Items.Count == 0) { ddlImageIndex.Items.Insert(0, new ListItem("0", "0")); }
        }
        if (Session["PictureType"] != null)
        {
            rblPictureType.SelectedValue = Session["PictureType"].ToString().Trim();
        }

        int Mold = (rblPictureType.SelectedValue.Trim() == "5") ? 5 : 1;
        dboSetCtrls.SetLinkButtonOfPageIndex(lkbXiaPage, lkbShangPage, ddlImageIndex, Mold);//设置跳页的按钮事件

        int StartNum = int.Parse(ddlImageIndex.SelectedValue.Trim());
        int[] ActionNum = null;
        if (Mold == 1)
            ActionNum = new int[1] { StartNum };
        else
            ActionNum = new int[5] { StartNum - 0, StartNum - 1, StartNum - 2, StartNum - 3, StartNum - 4 };
        //取得啤数序号
        string[] ActionText = new string[ActionNum.Length];
        for (int i = 0; i < ActionNum.Length; i++)
        {
            if (ActionNum[i] <= 0) ActionText[i] = "0";
            else
                for (int j = 0; j < ddlImageIndex.Items.Count; j++)
                {
                    if (ActionNum[i].ToString().Trim() == ddlImageIndex.Items[j].Value.Trim())
                    {
                        ActionText[i] = ddlImageIndex.Items[j].Text.Trim();
                        break;
                    }
                }
        }
        */
        /*DataTable stand_dt = new DataTable();
        DataTable lived_dt = new DataTable();
        if (URLID == "QualityTrack")
        {
            //stand_dt = new StandDataHistory_BLL().selectPress(MachineNo, MouldNo, ProductNo, bDate, eDate, "-100");
            lived_dt = new QualityTrack_BLL().selectPress(DispatchOrder,MachineNo, MouldNo, ProductNo, bDate, eDate, ActionText);
        }
        else
        {
            //lived_dt = new StandDataHistory_BLL().selectPress(MachineNo, MouldNo, ProductNo, bDate, eDate, ActionNum);
        }
        bDate = (lived_dt.Rows.Count == 0) ? eDate : lived_dt.Rows[0]["BeginCycle"].ToString().Trim();
        eDate = (lived_dt.Rows.Count == 0) ? bDate : lived_dt.Rows[lived_dt.Rows.Count - 1]["BeginCycle"].ToString().Trim();
/*
        int X_MAX_LENGHT = 0;
        int Y_MAX_LENGHT = 9;
        float XSlice = 0;
        string XAxisText = "";
        string XAxisFlag = "beernum";
        if (XAxisFlag == "minute")
        {
            X_MAX_LENGHT = 61;
            XSlice = 12.5f;
            XAxisText = "生产分钟";
        }

        if (XAxisFlag == "beernum")
        {
            if (ActionNum.Length > 1)
            {
                X_MAX_LENGHT = 501;//5啤1图
                XSlice = 1.8f;
            }
            else
            {
                X_MAX_LENGHT = 101;//1啤1图
                XSlice = 8.5f;
            }
            XAxisText = "压力点";
        }

        New_Curve objCurve = new New_Curve();

        objCurve.MainTitle = "注塑压力曲线图";
        objCurve.ProductTime = "生产时间:" + eDate + "至" + bDate;
        objCurve.ObjectNo = "机器编号:" + MachineNo + " 模具编号:" + MouldNo + " 产品编号:" + ProductNo;

        objCurve.Width = IMG_WIDTH;
        objCurve.Height = IMG_HEIGHT;

        objCurve.XAxisTextAlign = "right";
        objCurve.YAxisTextAlign = "top";
        objCurve.XAxisText = XAxisText;
        objCurve.YAxisText = "%压力";

        objCurve.XSlice = XSlice;
        objCurve.YSlice = 40f;
        objCurve.YSliceHalf = 0.5f * 40;
        objCurve.Across = Y_MAX_LENGHT;

        objCurve.BMargin = 50f;
        objCurve.TMargin = 110f;
        objCurve.RMargin = (IMG_WIDTH - (X_MAX_LENGHT - 1) * XSlice) / 2;
        objCurve.LMargin = (IMG_WIDTH - (X_MAX_LENGHT - 1) * XSlice) / 2;
        objCurve.YSliceBegin = 0;

        TempDraw objDraw = new TempDraw();
        string[] FieldName = new string[] {
                                        "KeepPress1", "KeepPress2", "KeepPress3", "KeepPress4", "KeepPress5", 
                                        "KeepPress6", "KeepPress7", "KeepPress8", "KeepPress9", "KeepPress10", 
                                        "KeepPress11", "KeepPress12", "KeepPress13", "KeepPress14", "KeepPress15", 
                                        "KeepPress16", "KeepPress17", "KeepPress18", "KeepPress19", "KeepPress20", 
                                        "KeepPress21", "KeepPress22", "KeepPress23", "KeepPress24", "KeepPress25", 
                                        "KeepPress26", "KeepPress27", "KeepPress28", "KeepPress29", "KeepPress30", 
                                        "KeepPress31", "KeepPress32", "KeepPress33", "KeepPress34", "KeepPress35", 
                                        "KeepPress36", "KeepPress37", "KeepPress38", "KeepPress39", "KeepPress40", 
                                        "KeepPress41", "KeepPress42", "KeepPress43", "KeepPress44", "KeepPress45", 
                                        "KeepPress46", "KeepPress47", "KeepPress48", "KeepPress49", "KeepPress50", 
                                        "KeepPress51", "KeepPress52", "KeepPress53", "KeepPress54", "KeepPress55", 
                                        "KeepPress56", "KeepPress57", "KeepPress58", "KeepPress59", "KeepPress60", 
                                        "KeepPress61", "KeepPress62", "KeepPress63", "KeepPress64", "KeepPress65", 
                                        "KeepPress66", "KeepPress67", "KeepPress68", "KeepPress69", "KeepPress70", 
                                        "KeepPress71", "KeepPress72", "KeepPress73", "KeepPress74", "KeepPress75", 
                                        "KeepPress76", "KeepPress77", "KeepPress78", "KeepPress79", "KeepPress80", 
                                        "KeepPress81", "KeepPress82", "KeepPress83", "KeepPress84", "KeepPress85", 
                                        "KeepPress86", "KeepPress87", "KeepPress88", "KeepPress89", "KeepPress90", 
                                        "KeepPress91", "KeepPress92", "KeepPress93", "KeepPress94", "KeepPress95", 
                                        "KeepPress96", "KeepPress97", "KeepPress98", "KeepPress99", "KeepPress100" };

        string[] Stand_FieldName = new string[] { "KeepPress" };
        string[] Lived_FieldName = null;
        string[] tmpLived_FieldName = new string[] { "Press1", "Press2", "Press3", "Press4", "Press5" };
        

        DataTable dt_stand = new DataTable();
        DataTable dt_lived = new DataTable();

        foreach (string temp in Stand_FieldName)
            dt_stand.Columns.Add(new DataColumn(temp));
        if (tmpLived_FieldName.Length <= lived_dt.Rows.Count)
        {
            Lived_FieldName = new string[tmpLived_FieldName.Length];
            for (int i = 0; i < tmpLived_FieldName.Length; i++)
            {
                dt_lived.Columns.Add(new DataColumn(tmpLived_FieldName[i].Trim()));
                Lived_FieldName[i] = tmpLived_FieldName[i];
            }
        }//5啤1图的记录表的情况
        else
        {
            Lived_FieldName = new string[lived_dt.Rows.Count];
            for (int i = 0; i < lived_dt.Rows.Count; i++)
            {
                dt_lived.Columns.Add(new DataColumn(tmpLived_FieldName[i].Trim()));
                Lived_FieldName[i] = tmpLived_FieldName[i];
            }
        }//1啤1图的记录表的情况

        foreach (string tempFieldName in FieldName)
        {
            if (stand_dt.Rows.Count != 0)
            {
                DataRow dr = dt_stand.NewRow();
                foreach (string temp in Stand_FieldName)
                    dr[temp] = stand_dt.Rows[0][tempFieldName].ToString().Trim();
                dt_stand.Rows.Add(dr);
            }

            if (lived_dt.Rows.Count != 0)
            {
                DataRow dr = dt_lived.NewRow();
                if (tmpLived_FieldName.Length <= lived_dt.Rows.Count)
                {
                    for (int i = 0; i < tmpLived_FieldName.Length; i++)
                        dr[tmpLived_FieldName[i]] = lived_dt.Rows[i][tempFieldName].ToString().Trim();
                }
                else
                {
                    for (int i = 0; i < lived_dt.Rows.Count; i++)
                        dr[tmpLived_FieldName[i]] = lived_dt.Rows[i][tempFieldName].ToString().Trim();
                }
                dt_lived.Rows.Add(dr);
            }
        }

        objDraw.Press100 = true;
        objDraw.DrawPicture((X_MAX_LENGHT - 1) / ActionNum.Length + 1, Y_MAX_LENGHT, bDate, eDate, Stand_FieldName, Lived_FieldName, dt_stand, dt_lived);

        objCurve.XSliceValue = objDraw.XSliceValue;
        objCurve.YSliceValue = objDraw.YSliceValue;

        objCurve.Keys = objDraw.Keys;
        objCurve.pArrayList = objDraw.vArrayList;

        objCurve.StandParaCount = Stand_FieldName.Length;
        objCurve.blnDrawData = false;

        objCurve.CurveColors = new Color[] { Color.Gray, Color.Orange, Color.Blue, Color.Orange, Color.Green, Color.Maroon };
        objCurve.blnPress100 = true;

        objCurve.CurveDesc = ActionText;
        string lastip = (Dns.GetHostEntry(Dns.GetHostName()).AddressList)[0].ToString().Trim().Replace(".", "");

        Bitmap bmp = objCurve.CreateImage();
        MemoryStream imgStream = new MemoryStream();
        bmp.Save(imgStream, ImageFormat.Jpeg);
        byte[] bytes = imgStream.ToArray();

        Session[URLID] = null;
        Session[URLID] = bytes;
        Image1.ImageUrl = string.Format("~/ShowImage.aspx?Flag=" + URLID);

        bmp.Clone();
        bmp.Dispose();*/
    }

  /*  protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton tempLinkButton = sender as LinkButton;
        int Mold = (rblPictureType.SelectedValue.Trim() == "5") ? 5 : 1;
        dboSetCtrls.ShowWhichPicture(tempLinkButton, lkbXiaPage, lkbShangPage, ddlImageIndex, Mold);
        BindData(1);
    }

    protected void rblPictureType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["PictureType"] = rblPictureType.SelectedValue.Trim();
        BindData(1);
    }

    protected void ddlImageIndex_SelectedIndexChanged(object sender, EventArgs e)
    {
        rblPictureType.SelectedValue = "1";
        BindData(1);
    }*/
}