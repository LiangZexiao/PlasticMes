using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace Chart
{
    public class New_Draw
    {
        private int m_Width = 900;
        private int m_Height = 500;
        private int m_X_MAX_LENGHT = 61;
        private int m_Y_MAX_LENGHT = 6;
        private string m_XAxisText = "";
        private string m_XAxisFlag = "";
        private string m_YAxisText = "";
        private string[] m_ContentTexts = null;
        private Color[] m_CurveColors = null;
        private string m_MainTitle = "";
        private string[] m_Stand_FieldName = null;
        private string[] m_Lived_FieldName = null;
        private float m_XSlice = 50;
        private float m_YSlice = 50;
        private float m_LMargin = 75;
        private float m_RMargin = 25;
        private string m_XAxisTextAlign = "";
        private string m_YAxisTextAlign = "";
        public int Width
        {
            set { m_Width = (value < 300) ? 300 : value; }
            get { return m_Width; }
        }

        public int Height
        {
            set { m_Height = (value < 300) ? 300 : value; }
            get { return m_Height; }
        }

        public int X_MAX_LENGHT
        {
            set { m_X_MAX_LENGHT = value; }
            get { return m_X_MAX_LENGHT; }
        }

        public int Y_MAX_LENGHT
        {
            set { m_Y_MAX_LENGHT = value; }
            get { return m_Y_MAX_LENGHT; }
        }
        public string XAxisText
        {
            set { m_XAxisText = value; }
            get { return m_XAxisText; }
        }

        public string XAxisFlag
        {
            set { m_XAxisFlag = value; }
            get { return m_XAxisFlag; }
        }

        public string YAxisText
        {
            set { m_YAxisText = value; }
            get { return m_YAxisText; }
        }

        public string[] ContentTexts
        {
            set { m_ContentTexts = value; }
            get { return m_ContentTexts; }
        }

        public Color[] CurveColors
        {
            set { m_CurveColors = value; }
            get { return m_CurveColors; }
        }
        public string MainTitle
        {
            set { m_MainTitle = value; }
            get { return m_MainTitle; }
        }

        public string[] Stand_FieldName
        {
            set { m_Stand_FieldName = value; }
            get { return m_Stand_FieldName; }
        }

        public string[] Lived_FieldName
        {
            set { m_Lived_FieldName = value; }
            get { return m_Lived_FieldName; }
        }
        public float XSlice
        {
            set { m_XSlice = value; }
            get { return m_XSlice; }
        }

        public float YSlice
        {
            set { m_YSlice = value; }
            get { return m_YSlice; }
        }
        public float LMargin
        {
            set { m_LMargin = value; }
            get { return m_LMargin; }
        }

        public float RMargin
        {
            set { m_RMargin = value; }
            get { return m_RMargin; }
        }

        public string XAxisTextAlign
        {
            set { m_XAxisTextAlign = value; }
            get { return m_XAxisTextAlign; }
        }

        public string YAxisTextAlign
        {
            set { m_YAxisTextAlign = value; }
            get { return m_YAxisTextAlign; }
        }

        private float m_YSliceValue = 1;
        public float YSliceValue
        {
            set { m_YSliceValue = value; }
            get { return m_YSliceValue; }
        }
        private float m_XSliceValue = 1;
        public float XSliceValue
        {
            set { m_XSliceValue = value; }
            get { return m_XSliceValue; }
        }
        
        private string[] m_Keys = null;
        public string[] Keys
        {
            set { m_Keys = value; }
            get { return m_Keys; }
        }
        private float m_YLastMaxNum = 6;
        public float YLastMaxNum
        {
            set { m_YLastMaxNum = value; }
            get { return m_YLastMaxNum; }
        }
        private ArrayList m_StandValuesList = new ArrayList();
        private ArrayList StandValuesList
        {
            set { m_StandValuesList = value; }
            get { return m_StandValuesList; }
        }

        private ArrayList m_LivedValuesList = new ArrayList();
        private ArrayList LivedValuesList
        {
            set { m_LivedValuesList = value; }
            get { return m_LivedValuesList; }
        }

        private StringFormat m_DrawFormat = new StringFormat();
        public StringFormat DrawFormat
        {
            set { m_DrawFormat = value; }
            get { return m_DrawFormat; }
        }

        private float[] m_PointX = null;
        public float[] PointX
        {
            set { m_PointX = value; }
            get { return m_PointX; }
        }

        private float[] m_PointY = null;
        public float[] PointY
        {
            set { m_PointY = value; }
            get { return m_PointY; }
        }
        private Boolean m_DrawData = false;
        public Boolean DrawData
        {
            set { m_DrawData = value; }
            get { return m_DrawData; }
        }

        public byte[] DrawPicture(string bDateTime, string eDateTime, DataTable stand_dt, DataTable lived_dt)
        {
            Return(bDateTime, eDateTime, stand_dt, lived_dt);
            New_Curve curve2d = new New_Curve();
            curve2d.MainTitle = MainTitle;
            curve2d.Unit = "秒";
            curve2d.XAxisText = XAxisText;

            curve2d.XSlice = XSlice;
            curve2d.YSlice = YSlice;
            curve2d.YAxisText = YAxisText;
            curve2d.Across = Y_MAX_LENGHT;
            curve2d.LMargin = LMargin;
            curve2d.RMargin = RMargin;
            curve2d.XAxisTextAlign = XAxisTextAlign;
            curve2d.YAxisTextAlign = YAxisTextAlign;
            curve2d.Height = Height;//图片的高度
            curve2d.Width = Width;//图片的宽度

            //curve2d.DrawFormat = DrawFormat;
            curve2d.YSliceBegin = 0;
            curve2d.YSliceValue = (YSliceValue == 0) ? 1 : YSliceValue;
            curve2d.XSliceValue = XSliceValue;

            //curve2d.YMaxValue = (YLastMaxNum == 0) ? Y_MAX_LENGHT : YLastMaxNum;
            curve2d.Keys = Keys;

            //curve2d.PointX = PointX;
            //curve2d.PointY = PointY;
            ArrayList vArrayList = new ArrayList();
            //**********************************************
            //
            //标准生产值,如温度,压力,周期,位移,速度
            //
            //**********************************************
            for (int b = 0; b < Stand_FieldName.Length; b++)//先取一个字段
            {
                float[] tempOneFieldValues = new float[StandValuesList.Count];
                float[] tempStandValues = new float[X_MAX_LENGHT];
                for (int a = 0; a < StandValuesList.Count; a++)
                {
                    tempOneFieldValues[a] = (StandValuesList[a] as float[])[b];
                    for (int c = 0; c < X_MAX_LENGHT; c++)
                    {
                        tempStandValues[c] = tempOneFieldValues[a];//把此字段值放入同一数组
                    }
                }
                vArrayList.Add(tempStandValues);//把此字段生成的数组放入一个ArrayList
            }
            //**********************************************
            //
            // 实际生产值,如温度,压力,周期,位移,速度
            //
            //**********************************************
            for(int a = 0; a < Lived_FieldName.Length; a++)//先取一个字段
            {
                float[] tempOneFieldValues = new float[LivedValuesList.Count];
                for (int b = 0; b < LivedValuesList.Count; b++)
                {
                    tempOneFieldValues[b] = (LivedValuesList[b] as float[])[a];//把此字段值放入同一数组
                }
                vArrayList.Add(tempOneFieldValues);//把此字段生成的数组放入一个ArrayList
            }
            
            curve2d.pArrayList = vArrayList;
            curve2d.StandParaCount = Stand_FieldName.Length;
            curve2d.CurveColors = CurveColors;
            curve2d.blnDrawData = DrawData;
            //显示出图片
            string lastip = (Dns.GetHostEntry(Dns.GetHostName()).AddressList)[0].ToString().Trim().Replace(".", "");

            Bitmap bmp = curve2d.CreateImage();
            MemoryStream imgStream = new MemoryStream();
            bmp.Save(imgStream, ImageFormat.Jpeg);
            byte[] bytes = imgStream.ToArray();
            bmp.Clone();
            bmp.Dispose();
            return bytes;
        }


        public void Return(string bDateTime, string eDateTime, DataTable stand_dt, DataTable lived_dt)
        {
            int s1 = 0, s2 = 0, s3 = 0, total = 0, MoldTime = 1;

            System.TimeSpan TimeSpan1 = DateTime.Parse(eDateTime).Subtract(DateTime.Parse(bDateTime));

            s1 = (TimeSpan1.Days == 0) ? 0 : TimeSpan1.Days * 24 * 60;
            s2 = (TimeSpan1.Hours == 0) ? 0 : TimeSpan1.Hours * 60;
            s3 = (TimeSpan1.Minutes == 0) ? 0 : TimeSpan1.Minutes;
            
            total = s1 + s2 + s3;


            MoldTime = 1;
            if (total > (60))
            {
                for (int a = 1; a != -1; a++)
                {
                    if ((a * (X_MAX_LENGHT - 1)) >= total)
                    {
                        MoldTime = a;
                        break;
                    }
                }
            }

            int stand_rowscount = stand_dt.Rows.Count;
            int lived_rowscount = lived_dt.Rows.Count;

            string TempTime = string.Empty;

            string[] UpLoadTimes = new string[lived_rowscount];

            float[] SingleStandValues = new float[Stand_FieldName.Length];
            float[] SingleLivedValues = new float[Lived_FieldName.Length];
            ArrayList tempStandValuesList = new ArrayList();
            ArrayList tempLivedValuesList = new ArrayList();

            //得到标准值(如周期,温度,压力,位移,速度...........)
            for (int a = 0; a < stand_rowscount; a++)
            {
                for (int b = 0; b < Stand_FieldName.Length; b++)
                {
                    SingleStandValues[b] = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[a][Stand_FieldName[b]].ToString().Trim());
                }
                StandValuesList.Add(SingleStandValues);
            }
            //得到现场值(如周期,温度,压力,位移,速度...........)
            if (lived_rowscount != 0)
            {
                for (int a = 0; a < lived_rowscount; a++)
                {
                    SingleLivedValues = new float[Lived_FieldName.Length];
                    for (int b = 0; b < Lived_FieldName.Length; b++)
                    {
                        SingleLivedValues[b] = (lived_rowscount == 0) ? 0 : float.Parse(lived_dt.Rows[a][Lived_FieldName[b]].ToString().Trim());
                    }
                    tempLivedValuesList.Add(SingleLivedValues);//存入所有的记录
                    UpLoadTimes[a] = lived_dt.Rows[a]["UpLoadTime"].ToString().Trim();
                }

                //TimeSpan1 = DateTime.Parse(UpLoadTimes[UpLoadTimes.Length - 1]).Subtract(DateTime.Parse(UpLoadTimes[0]));

                Keys = new string[X_MAX_LENGHT];
                //PointX = new float[X_MAX_LENGHT];
                //PointX = new float[lived_rowscount];

                string[] midKeys = new string[X_MAX_LENGHT];
                string[] tKeys = new string[lived_rowscount];

                int MoldAction = 1;
                //*************************************************************
                if (Keys.Length == 61)
                {
                    XSliceValue = MoldTime;
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        midKeys[i] = (i * MoldTime).ToString().Trim();

                        if (((i) % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i * MoldTime).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                }
                if (X_MAX_LENGHT == 101)
                {                    
                    if (lived_rowscount > 101)
                    {
                        for (int a = 1; a != -1; a++)
                        {
                            if (a * (X_MAX_LENGHT - 1) >= lived_rowscount)
                            {
                                MoldAction = a;
                                break;
                            }
                        }
                    }
                    XSliceValue = float.Parse(MoldAction.ToString());

                    for (int i = 0; i < X_MAX_LENGHT; i++)
                    {
                        midKeys[i] = (i * MoldAction).ToString().Trim();

                        if ((i % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i * MoldAction).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                }
                //*************************************************************



                //*************************************************************
                DataTable dt = new DataTable();
                DataTable LivedDataTable = new DataTable();
                for (int j = 0; j < Lived_FieldName.Length; j++)
                {
                    dt.Columns.Add(new DataColumn(Lived_FieldName[j]));
                    LivedDataTable.Columns.Add(new DataColumn(Lived_FieldName[j]));
                }

                for (int i = 0; i < X_MAX_LENGHT; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < Lived_FieldName.Length; j++)
                        dr[Lived_FieldName[j]] = -1f;
                    dt.Rows.Add(dr);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float[] NullArray = new float[Lived_FieldName.Length];
                    for (int j = 0; j < Lived_FieldName.Length; j++)
                        NullArray[j] = float.Parse(dt.Rows[i][Lived_FieldName[j]].ToString());
                    LivedValuesList.Add(NullArray);
                }
                //******************************************************************

                if (X_MAX_LENGHT == 61)
                {
                    for (int i = 0; i < lived_rowscount; i++)
                    {
                        s1 = 0;
                        s2 = 0;
                        s3 = 0;

                        TimeSpan1 = DateTime.Parse(UpLoadTimes[i]).Subtract(DateTime.Parse(UpLoadTimes[0]));
                        s1 = (TimeSpan1.Days == 0) ? 0 : TimeSpan1.Days * 24 * 60;
                        s2 = (TimeSpan1.Hours == 0) ? 0 : TimeSpan1.Hours * 60;
                        s3 = (TimeSpan1.Minutes == 0) ? 0 : TimeSpan1.Minutes;

                        tKeys[i] = (s1 + s2 + s3).ToString();
                    }
                }

                if (X_MAX_LENGHT == 101)
                {
                    int CollectCount = 0;

                    if ((lived_rowscount % MoldAction) != 0)
                        CollectCount = lived_rowscount / MoldAction + 1;
                    else
                        CollectCount = lived_rowscount / MoldAction;

                    for (int j = 0, j0 = 0; j < lived_rowscount; j = j + MoldAction, j0++)
                    {
                        DataRow dr = LivedDataTable.NewRow();
                        for (int k = 0; k < Lived_FieldName.Length; k++)
                        {
                            float sum = 0, avg = 0;
                            for (int l = j; l < j + MoldAction; l++)
                            {
                                sum += (float.Parse(lived_dt.Rows[j][Lived_FieldName[k]].ToString().Trim()));
                                if (j == lived_rowscount - 1) break;
                            }
                            avg = float.Parse(System.Math.Round(sum / MoldAction,2).ToString().Trim());
                            dr[Lived_FieldName[k]] = avg;
                        }
                        LivedDataTable.Rows.Add(dr);
                    }

                    ArrayList tempK = new ArrayList();
                    for (int i = 0; i < LivedDataTable.Rows.Count; i++)
                    {
                        float[] NullArray = new float[Lived_FieldName.Length];
                        for (int j = 0; j < Lived_FieldName.Length; j++)
                            NullArray[j] = float.Parse(LivedDataTable.Rows[i][Lived_FieldName[j]].ToString());
                        tempK.Add(NullArray);
                    }

                    for (int i = 0; i < tempK.Count; i++)
                    {
                        LivedValuesList[i] = tempK[i];
                    }
                }

                if (Keys.Length == 61)
                {
                    for (int i = 0; i < midKeys.Length; i++)
                    {
                        for (int j = 0; j < tKeys.Length; j++)
                        {
                            if (float.Parse(midKeys[i]) <= float.Parse(tKeys[tKeys.Length - 1]))
                            {
                                if (midKeys[i] == tKeys[j])
                                    LivedValuesList[i] = tempLivedValuesList[j];
                                else
                                {
                                    if (i == 0)
                                    {
                                        if (midKeys[i] == tKeys[j])
                                            LivedValuesList[i] = tempLivedValuesList[j];
                                        //else
                                        //    LivedValuesList[i] = 0f;
                                    }
                                    else
                                    {
                                        float f0 = Math.Abs(float.Parse(tKeys[j]) - float.Parse(midKeys[i - 1]));
                                        float f1 = Math.Abs(float.Parse(tKeys[j]) - float.Parse(midKeys[i]));
                                        float vf0 = f0 - MoldTime;
                                        float vf1 = f1 - MoldTime;
                                        if (vf0 > 0 && vf1 <=0)
                                        {
                                            LivedValuesList[i] = tempLivedValuesList[j];
                                        }
                                        else if (vf0 <= 0 && vf1 > 0)
                                        {
                                            LivedValuesList[i - 1] = tempLivedValuesList[j];
                                        }
                                        else if (vf0 < 0 && vf1 < 0)
                                        {
                                            float f = f0 - f1;
                                            if (f <= 0)
                                            {
                                                LivedValuesList[i - 1] = tempLivedValuesList[j];
                                            }
                                            else
                                                LivedValuesList[i] = tempLivedValuesList[j];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Keys = new string[X_MAX_LENGHT];
                PointX = new float[X_MAX_LENGHT];
                if (X_MAX_LENGHT == 61)
                {
                    XSliceValue = 24;
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        PointX[i] = float.Parse((i * MoldTime).ToString().Trim());
                        if (((i) % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i * MoldTime).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                }
                else
                {
                    XSliceValue = 1f;
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        PointX[i] = float.Parse((i).ToString().Trim());
                        if ((i % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                }

                //for (int i = 0; i < Lived_FieldName.Length; i++)
                //    LivedValuesList.Add(new float[Keys.Length]);
            }//无现场生产值

            //***************************************************
            //
            //获取标准生产值和现场生产值中最大的值
            //
            //***************************************************
            float[] stand = returnCollect(StandValuesList, Stand_FieldName);
            float[] lived = returnCollect(LivedValuesList, Lived_FieldName);
            //***************************************************
            //
            //MaxNum最大的值
            //
            //***************************************************
            if (stand_rowscount != 0 && lived_rowscount != 0)
                YLastMaxNum = Math.Max(stand[stand.Length - 1], lived[lived.Length - 1]);
            else if (stand_rowscount != 0 && lived_rowscount == 0)
                YLastMaxNum = stand[stand.Length - 1];//MaxNum最大的值
            else if (stand_rowscount == 0 && lived_rowscount != 0)
                YLastMaxNum = lived[lived.Length - 1];//MaxNum最大的值
            else
                YLastMaxNum = 6;

            if (YLastMaxNum > Y_MAX_LENGHT)
            {
                for (int a = 1; a != -1; a++)
                {
                    if ((a * Y_MAX_LENGHT) >= YLastMaxNum)
                    {
                        YSliceValue = a;
                        break;
                    }
                }
            }
            else
                YSliceValue = 1f;
        }

        //执行冒泡排序,以便得到Y轴方向的最大值
        private float[] getSortedArray(float[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = Array.Length - 2; j >= i; j--)
                {
                    float temp = 0f;
                    if (Array[j] > Array[j + 1])
                    {
                        temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
            return Array;
        }

        private float[] returnCollect(ArrayList pArrayList, string[] pFieldName)
        {
            float[] list = new float[pArrayList.Count];
            float[] list0 = new float[pArrayList.Count];
            float[] list1 = new float[pFieldName.Length];
            for (int a = 0; a < pArrayList.Count; a++)
            {
                list1 = new float[pFieldName.Length];
                for (int b = 0; b < pFieldName.Length; b++)
                {
                    list1[b] = ((pArrayList[a]) as float[])[b];
                }
                float[] temp = getSortedArray(list1);
                list0[a] = temp[temp.Length - 1];
            }
            list = getSortedArray(list0);
            return list;
        }
    }
}


