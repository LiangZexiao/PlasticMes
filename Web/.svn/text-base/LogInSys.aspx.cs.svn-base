using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Chart;
using Admin.SQLServerDAL.Quality_DAL;

public partial class LogInSys : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        //Bitmap objBitMap = new Bitmap(400, 200);
        //Graphics objGraphics;
        //objGraphics = Graphics.FromImage(objBitMap);
        //objGraphics.Clear(Color.White);

        New_Curve objCurve = new New_Curve();

        string ReportName=Request.QueryString["ReportName"].ToString();
        string MachineNo=Session[ReportName +"_MachineNo"].ToString();
        string bDate = Session[ReportName + "_bDate"].ToString();
        string eDate = Session[ReportName + "_eDate"].ToString();
        string Prints = Session[ReportName + "_UserID"].ToString();

        DataTable dt = new StopReas_DAL().selectOEETable(MachineNo, bDate, eDate, Prints);
        if (MachineNo != "")
        {
            objCurve.ProductTime = "机器编号:" + MachineNo + "  生产时间:" + bDate + " 至 " + eDate;
        }
        else
        {
            objCurve.ProductTime =  "生产时间:" + bDate + " 至 " + eDate;
        }
      //  objCurve.LMargin = 97.5f;
       //objCurve.TMargin=110f;
        float[] arrValues = {float.Parse( dt.Rows[0][0].ToString()), float.Parse(dt.Rows[0][1].ToString()), float.Parse(dt.Rows[0][2].ToString()),
            float.Parse(dt.Rows[0][3].ToString()), float.Parse(dt.Rows[0][4].ToString()), float.Parse(dt.Rows[0][5].ToString()), float.Parse(dt.Rows[0][6].ToString()), float.Parse(dt.Rows[0][7].ToString()), float.Parse(dt.Rows[0][8].ToString()), float.Parse(dt.Rows[0][9].ToString()) };
        string[] arrValueNames = new string[] { "换模", "换料", "换单", "辅设故障", "机器故障", "模具故障", "待料", "无订单", "其它", "总计" };
        ArrayList tempList = new ArrayList();
        tempList.Add(arrValues);
        objCurve.pArrayList = tempList;
        objCurve.Keys = arrValueNames;

        int YLastMaxNum =(int)float.Parse( dt.Rows[0][9].ToString());
        int Y_MAX_LENGHT = 6;
        float YSliceValue = 1f;
        if (YLastMaxNum > Y_MAX_LENGHT)
        {
            int tsd = (YLastMaxNum / Y_MAX_LENGHT);
            YSliceValue = float.Parse(tsd.ToString());
        }
        else
            YSliceValue = 1f;
        objCurve.YSliceValue = YSliceValue;

        objCurve.CurveColors = new Color[] { Color.Blue, Color.Red, Color.Yellow, Color.Purple, Color.Orange, Color.Maroon, Color.Gray, Color.FloralWhite, Color.DarkGoldenrod, Color.PapayaWhip };
        objCurve.PictType = "Cake";
        objCurve.XAxisText = "停机原因";
        objCurve.YAxisText = "停机时间(小时)";
        objCurve.MainTitle = "停机原因统计柏拉图";
        //objCurve.Width = 1000;
        Bitmap bmp = objCurve.CreateImage();
        MemoryStream imgStream = new MemoryStream();
        bmp.Save(imgStream, ImageFormat.Jpeg);
        byte[] bytes = imgStream.ToArray();

        Session["Cycle_chartID"] = null;
        Session["Cycle_chartID"] = bytes;
        Image1.ImageUrl = string.Format("~/ShowImage.aspx?Flag=Cycle_chartID");

        bmp.Clone();
        bmp.Dispose();

        float temp = 0;
        
        float[] num = {float.Parse( dt.Rows[0][0].ToString()), float.Parse(dt.Rows[0][1].ToString()), float.Parse(dt.Rows[0][2].ToString()),
            float.Parse(dt.Rows[0][3].ToString()), float.Parse(dt.Rows[0][4].ToString()), float.Parse(dt.Rows[0][5].ToString()), float.Parse(dt.Rows[0][6].ToString()), float.Parse(dt.Rows[0][7].ToString()), float.Parse(dt.Rows[0][8].ToString()), float.Parse(dt.Rows[0][9].ToString()) };

        for (int k = 0; k < num.Length; k++)
        {

            for (int i = k + 1; i < num.Length; i++)
            {
                if (num[k] < num[i])
                {
                    temp = num[k];
                    num[k] = num[i];
                    num[i] = temp;
                }
            }

        }
        Response.Write(temp.ToString());
        for (int i = 0; i < num.Length; i++)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (num[i] > num[j])
                {
                    temp = num[i];
                    num[i] = num[j];
                    num[j] = temp;
                }
            }
        }
        Response.Write(temp.ToString());
        for (int i = 0; i< num.Length;i++)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (num[i] > num[j])
                {
                    temp = num[i];
                    num[i] = num[j];
                    num[j] = temp;
                }
            }
        }
        Response.Write(temp.ToString());
    }
}