using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Chart;
using Admin.BLL.Quality_BLL;
using Admin.BLL.Collect_BLL;
using Admin.SQLServerDAL.RightCtrl;
using Admin.App_Code;
using Newtonsoft.Json;


public partial class Quality_QualityTrack_Cycle : System.Web.UI.Page
{
    
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
        if (!IsPostBack)
        {   
            if (Request.QueryString["URLID"]!=null && Request.QueryString["URLID"].ToString().Trim().Equals("QualityTrack"))
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
        }
    }

    private void BindData(int Flag)
    {
        CycleMap cycleMap = new CycleMap();
        DataTable dt = new DataHistory_BLL().selectActionNumFromDataHistory(DispatchOrder, MachineNo, MouldNo, ProductNo, bDate, eDate);//查询到selectid rowid id totalnum
        DataTable stand_dt = new DataTable();
        DataTable lived_dt = new DataTable();
        int LabelPage = 0;
        if (dt.Rows.Count>0&&dt!=null || firstFlag == 0)
        {
            maxTotal = dt.Rows.Count;
            cycleMap.TotalPageNum = maxTotal / 100 + (maxTotal % 100 == 0 ? 0 : 1);
            
            string startTotalNum = "";
            string endTotalNum = "";
            if (Request["LabelPage"] != null && Convert.ToInt32(Request["LabelPage"])!= 0)
            {
                LabelPage = Convert.ToInt32(Request["LabelPage"]);
                if (Request["whoButton"].Equals("xiaPage"))
                {
                    if ((LabelPage+1)*100>dt.Rows.Count)
                    {
                        cycleMap.OnoffButton = "offxia";
                        LabelPage++;
                        startTotalNum = dt.Rows[(LabelPage-1) * 100][3].ToString();
                        endTotalNum = dt.Rows[dt.Rows.Count - 1][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }
                    else
                    {
                        LabelPage++;
                        startTotalNum = dt.Rows[(LabelPage-1) * 100][3].ToString();
                        endTotalNum = dt.Rows[(LabelPage) * 100 - 1][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }

                    
                }
                else if (Request["whoButton"].Equals("shangPage"))
                {
                    if (LabelPage==2)
                    {
                        cycleMap.OnoffButton = "offshang";
                        LabelPage--;
                        startTotalNum = dt.Rows[0][3].ToString();
                        endTotalNum = dt.Rows[99][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }else{
                        LabelPage--;
                        startTotalNum = dt.Rows[(LabelPage-1)*100][3].ToString();
                        endTotalNum = dt.Rows[(LabelPage)*100-1][3].ToString();
                        cycleMap.PageNum = (LabelPage).ToString();
                    }
                }
                else
                {

                }
            }
            else
            {
                if (dt.Rows.Count<100)
                {
                    startTotalNum = dt.Rows[0][3].ToString();
                    endTotalNum = dt.Rows[(dt.Rows.Count - 1)][3].ToString();
                }
                else
                {
                    startTotalNum = dt.Rows[0][3].ToString();

                    endTotalNum = dt.Rows[99][3].ToString();
                }
                cycleMap.OnoffButton = "offshang";
                cycleMap.PageNum = "1";
             //   cycleMap.PageNum = startTotalNum;              
            }
            
            string[] TotalNum = { startTotalNum, endTotalNum };
            stand_dt = new QualityTrack_BLL().selectStandCycle(DispatchOrder);//ProductNo);
            lived_dt = new QualityTrack_BLL().selectUnifyField(DispatchOrder, MachineNo, MouldNo, ProductNo, bDate, eDate, TotalNum);
         
            for (int i = 0; i < lived_dt.Rows.Count; i++)
		    {
                cycleMap.XData.Add(Convert.ToInt32(Convert.ToDouble(lived_dt.Rows[i][1])));
                cycleMap.YData.Add(Convert.ToInt32(Convert.ToDouble(lived_dt.Rows[i][8])));
		    }

            foreach (DataRow row in stand_dt.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {

                    cycleMap.MinCycleTime = Convert.ToInt32(Convert.ToDouble(row.ItemArray[1]));
                    cycleMap.StandCycleTime = Convert.ToInt32(Convert.ToDouble(row.ItemArray[2]));
                    cycleMap.MinCycleTime = Convert.ToInt32(Convert.ToDouble(row.ItemArray[3]));

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
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
       /* LinkButton tempLinkButton = sender as LinkButton;
        int Mold = 100;
        if (tempLinkButton.CommandName == "Next")
        {
                if (Int32.Parse(Label1.Text.Trim()) > Mold)
                {
                    Label1.Text = (Int32.Parse(Label1.Text.Trim()) - Mold).ToString().Trim();
                    lkbShangPage.Enabled = true;
                    lkbXiaPage.Enabled = true;
                }
                else
                {
                    lkbShangPage.Enabled = true;
                    lkbXiaPage.Enabled = false;
                }
        }
        else
        {
            if (Int32.Parse(Label1.Text.Trim()) < maxTotal- Mold)
            {
                Label1.Text = (Int32.Parse(Label1.Text.Trim()) + Mold).ToString().Trim();
                lkbShangPage.Enabled = true;
                lkbXiaPage.Enabled = true;
            }
            else
            {
                Label1.Text = maxTotal.ToString();
                lkbShangPage.Enabled = false;
                lkbXiaPage.Enabled = true;
            }
        }
        linkButFlag = 1;
        labtext = Label1.Text;*/
    }

   /* protected void chkPictureType_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPictureType.Checked)
            tdPictureType.Visible = true;
        else
            tdPictureType.Visible = false;
    }*/
}