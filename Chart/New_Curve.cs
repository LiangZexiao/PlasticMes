using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Chart
{
    public class New_Curve
    {
        #region 变量定义
        private Graphics objGraphics; //Graphics 类提供将对象绘制到显示设备的方法
        private Bitmap objBitmap; //位图对象
        private StringFormat DrawFormat = new StringFormat();

        /// <summary>
        /// 数字区
        /// </summary>
        private int m_Width = 900; //图像宽度
        private int m_Height = 500; //图像高度
        private float m_XSlice = 50; //X轴刻度宽度(物理宽度)
        private float m_YSlice = 50; //Y轴刻度宽度(物理宽度)
        private float m_YSliceHalf = 0.5f * 50;//一半Y轴刻度宽度(物理宽度)
        private float m_XSliceValue = 24; //X轴刻度代表的数值
        private float m_YSliceValue = 20; //Y轴刻度代表的数值
        private float m_YSliceBegin = 0; //Y轴刻度开始值

        private int m_Across = 6;//最多画多少条平行X轴方向的直线(背景横线)
        private int m_Erect = 15;//最多画多少条平行Y轴方向的直线(背景竖线)

        private float m_LMargin = 75;//左边边缘的宽度
        private float m_RMargin = 25;//右边边缘的宽度
        private float m_TMargin = 60;//顶部边缘的宽度
        private float m_BMargin = 100f;//底部边缘的宽度

        private string[] m_Keys = null;//键
        private float[] m_WithinKeys = null;//键

        private int m_SliceFontSize = 9;//X,Y轴的文本字体大小
        /// <summary>
        /// 文本文字区
        /// </summary>
        private string m_MainTitle;// 图片的主标题
        private string m_SubTitle;//图片的副标题
        private string m_Warning;//提醒信息

        private string m_Unit;// = "万元"; //单位
        private string m_XAxisText;// = "月份"; //X轴说明文字
        private string m_YAxisText;// = "万元"; //Y轴说明文字

        private string m_XAxisTextAlign = "center";
        private string m_YAxisTextAlign = "middle";
        private string[] m_Stand_FieldDesc = null;
        private string[] m_CurveDesc = null;
        private string m_PictType = "Curve";
        private string m_Temp3Desc = string.Empty;

        private string m_ProductTime = string.Empty;
        private string m_ObjectNo = string.Empty;
        private ArrayList m_StatData = new ArrayList();
        private string m_StatData1 = string.Empty;
        private string m_StatData2 = string.Empty;
        private string m_StatData3 = string.Empty;
        
        /// <summary>
        /// 颜色区
        /// </summary>
        private Color m_BgColor = Color.Snow; //背景
        private Color m_BorderColor = Color.White; //整体边框颜色

        private Color m_TitleColor = Color.Black; //文字颜色
        private Color m_SubTitleColor = Color.Blue; //副标题文字颜色
        private Color m_WarningColor = Color.Red;//

        private Color m_AxisColor = Color.Black; //轴线颜色
        private Color m_AxisTextColor = Color.Black; //轴说明文字颜色
        private Color m_SliceColor = Color.Black; //刻度颜色
        private Color m_SliceTextColor = Color.Black; //刻度文字颜色

        private Color[] m_CurveColors = null;
        private Color m_GridColor = Color.Gainsboro;//背景网格线的颜色

        private float m_Tension = 0.5f;
        private float ZoomSize = 1f;
        /// <summary>
        /// 设置条件区
        /// </summary>
        private Boolean m_DrawDetail = false;//是否画细刻度
        private Boolean m_DrawGrid = true;//是否画背景网格
        private Boolean m_DrawData = false;
        private Boolean m_DrawConst = true;//是否写出最大值与最小值,标准值
        private Boolean m_isExData = false;//是否写出异常数据的啤数序号
        private Boolean m_Press100 = false;
        private Boolean m_isTemp = false;
        /// <summary>
        /// 输入值
        /// </summary>
        private ArrayList m_pArrayList = null;//标准

        private ArrayList m_ExData = null;
        private ArrayList m_ExDataIndex = null;

        private float m_PenWidth = 2;
        private int m_StandParaCount = 0;
        private int m_LivedParaCount = 1;

        #region 数字区
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

        public float YSliceHalf
        {
            set { m_YSliceHalf = value; }
            get { return m_YSliceHalf; }
        }

        public float YSliceValue
        {
            set { m_YSliceValue = value; }
            get { return m_YSliceValue; }
        }

        public float XSliceValue
        {
            set { m_XSliceValue = value; }
            get { return m_XSliceValue; }
        }

        public float YSliceBegin
        {
            set { m_YSliceBegin = value; }
            get { return m_YSliceBegin; }
        }

        public string[] Keys
        {
            set { m_Keys = value; }
            get { return m_Keys; }
        }

        public float[] WithinKeys
        {
            set { m_WithinKeys = value; }
            get { return m_WithinKeys; }
        }

        public int Across
        {
            set { m_Across = value; }
            get { return m_Across; }
        }

        public int Erect
        {
            set { m_Erect = value; }
            get { return m_Erect; }
        }
        /// <summary>
        /// 左边边缘的宽度
        /// </summary>
        public float LMargin
        {
            set { m_LMargin = value; }
            get { return m_LMargin; }
        }
        /// <summary>
        /// 右边边缘的宽度
        /// </summary>
        public float RMargin
        {
            set { m_RMargin = value; }
            get { return m_RMargin; }
        }
        /// <summary>
        /// 顶部边缘的宽度
        /// </summary>
        public float TMargin
        {
            set { m_TMargin = value; }
            get { return m_TMargin; }
        }
        /// <summary>
        /// 底部边缘的宽度
        /// </summary>
        public float BMargin
        {
            set { m_BMargin = value; }
            get { return m_BMargin; }
        }

        #endregion

        #region 文本文字区
        public string MainTitle
        {
            set { m_MainTitle = value; }
            get { return m_MainTitle; }
        }

        public string SubTitle
        {
            set { m_SubTitle = value; }
            get { return m_SubTitle; }
        }

        public string Warning
        {
            set { m_Warning = value; }
            get { return m_Warning; }
        }

        public string Unit
        {
            set { m_Unit = value; }
            get { return m_Unit; }
        }

        public string XAxisText
        {
            set { m_XAxisText = value; }
            get { return m_XAxisText; }
        }

        public string YAxisText
        {
            set { m_YAxisText = value; }
            get { return m_YAxisText; }
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

        public string[] Stand_FieldDesc
        {
            set { m_Stand_FieldDesc = value; }
            get { return m_Stand_FieldDesc; }
        }

        public string[] CurveDesc
        {
            set { m_CurveDesc = value; }
            get { return m_CurveDesc; }
        }

        public string PictType
        {
            set { m_PictType = value; }
            get { return m_PictType; }
        }

        public string Temp3Desc
        {
            set { m_Temp3Desc = value; }
            get { return m_Temp3Desc; }
        }

        public string ProductTime
        {
            set { m_ProductTime = value; }
            get { return m_ProductTime; }
        }

        public string ObjectNo
        {
            set { m_ObjectNo = value; }
            get { return m_ObjectNo; }
        }

        public ArrayList StatData
        {
            set { m_StatData = value; }
            get { return m_StatData; }
        }

        public string StatData1
        {
            set { m_StatData1 = value; }
            get { return m_StatData1; }
        }

        public string StatData2
        {
            set { m_StatData2 = value; }
            get { return m_StatData2; }
        }

        public string StatData3
        {
            set { m_StatData3 = value; }
            get { return m_StatData3; }
        }
        #endregion

        #region 颜色区
        public Color BgColor
        {
            set { m_BgColor = value; }
            get { return m_BgColor; }
        }

        public Color BorderColor
        {
            set { m_BorderColor = value; }
            get { return m_BorderColor; }
        }

        public Color TitleColor
        {
            set { m_TitleColor = value; }
            get { return m_TitleColor; }
        }

        public Color SubTitleColor
        {
            set { m_SubTitleColor = value; }
            get { return m_SubTitleColor; }
        }

        public Color WarningColor
        {
            set { m_WarningColor = value; }
            get { return m_WarningColor; }
        }

        public Color AxisColor
        {
            set { m_AxisColor = value; }
            get { return m_AxisColor; }
        }

        public Color AxisTextColor
        {
            set { m_AxisTextColor = value; }
            get { return m_AxisTextColor; }
        }

        public Color SliceColor
        {
            set { m_SliceColor = value; }
            get { return m_SliceColor; }
        }

        public Color SliceTextColor
        {
            set { m_SliceTextColor = value; }
            get { return m_SliceTextColor; }
        }

        public int SliceFontSize
        {
            set { m_SliceFontSize = value; }
            get { return m_SliceFontSize; }
        }

        public Color[] CurveColors
        {
            set { m_CurveColors = value; }
            get { return m_CurveColors; }
        }

        public Color GridColor//(平行于X,Y轴的网格线条的颜色)
        {
            set { m_GridColor = value; }
            get { return m_GridColor; }
        }
        #endregion

        #region 条件区
        /// <summary>
        /// 是否画细刻度
        /// </summary>
        public Boolean blnDrawDetail
        {
            set { m_DrawDetail = value; }
            get { return m_DrawDetail; }
        }
        /// <summary>
        /// 是否画网格
        /// </summary>
        public Boolean blnDrawGrid
        {
            set { m_DrawGrid = value; }
            get { return m_DrawGrid; }
        }
        /// <summary>
        /// 表示是否要描画出点所对应的数据,默认值是不描画出来的
        /// </summary>
        public Boolean blnDrawData
        {
            set { m_DrawData = value; }
            get { return m_DrawData; }
        }
        /// <summary>
        /// 是否写出最大值与最小值,标准值 等字样,默认值是描画出来的
        /// </summary>
        public Boolean blnDrawConst
        {
            set { m_DrawConst = value; }
            get { return m_DrawConst; }
        }
        /// <summary>
        /// 是否写出异常数据所对应的啤数序号
        /// </summary>
        public Boolean blnExData
        {
            set { m_isExData = value; }
            get { return m_isExData; }
        }

        public Boolean blnPress100
        {
            set { m_Press100 = value; }
            get { return m_Press100; }
        }

        public Boolean blnTemperature
        {
            set { m_isTemp = value; }
            get { return m_isTemp; }
        }
        #endregion

        public float Tension
        {
            set
            {
                if (value < 0.0f && value > 1.0f)
                {
                    //m_Tension = 0.5f;
                    m_Tension = value;
                }
                else { m_Tension = value; }
            }
            get { return m_Tension; }
        }
        /// <summary>
        /// 标准和现场的值,通常前面的是固定值,后面的是现场值
        /// </summary>
        public ArrayList pArrayList
        {
            set { m_pArrayList = value; }
            get { return (m_pArrayList == null) ? null : m_pArrayList; }
        }

        public ArrayList ExData
        {
            set { m_ExData = value; }
            get { return (m_ExData == null) ? null : m_ExData; }
        }

        public ArrayList ExDataIndex
        {
            set { m_ExDataIndex = value; }
            get { return (m_ExDataIndex == null) ? null : m_ExDataIndex; }
        }

        public int StandParaCount
        {
            set { m_StandParaCount = value; }
            get { return (m_StandParaCount == 0) ? 0 : m_StandParaCount; }
        }

        public int LivedParaCount
        {
            set { m_LivedParaCount = value; }
            get { return (m_LivedParaCount == 0) ? 0 : m_LivedParaCount; }
        }

        public float PenWidth
        {
            set { m_PenWidth = value; }
            get { return (m_PenWidth == 0) ? 1 : m_PenWidth; }
        }

        #endregion
        #region 生成图像并返回bmp图像对象
        public Bitmap CreateImage()
        {
            Bitmap tempBitmap = new Bitmap(Width, Height);//根据给定的高度和宽度创建一个位图图像


            if (PictType == "Curve")
            {
                InitializeGraph(tempBitmap);
                if (blnPress100)
                    DrawCurve2(ref objGraphics);
                else
                    DrawCurve(ref objGraphics);
            }
            else
            {
                InitializeGraphPie(tempBitmap);
                SetAxisTextPie(ref objGraphics);
                DrawCake(ref objGraphics);
            }

            return objBitmap;
        }
        #endregion

        #region 生成直方图像并返回bmp图像对象
        public Bitmap MakeImage()
        {
            Bitmap tempBitmap = new Bitmap(Width, Height);//根据给定的高度和宽度创建一个位图图像
            InitializeGraph(tempBitmap);

            return objBitmap;
        }
        #endregion

        #region 初始化和填充图像区域，画出边框，初始标题
        private void InitializeGraph(Bitmap pobjBitmap)
        {
            //objBitmap = new Bitmap(Width, Height);//根据给定的高度和宽度创建一个位图图像
            objBitmap = pobjBitmap;
            ZoomSize = m_Width / 1000;//计算自动缩放比例

            //从指定的 objBitmap 对象创建 objGraphics 对象 (即在objBitmap对象中画图)

            objGraphics = Graphics.FromImage(objBitmap);


            //根据给定颜色(LightGray)填充图像的矩形区域 (背景)
            objGraphics.DrawRectangle(new Pen(BorderColor, 1), 0, 0, Width, Height);

            //objGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width - 2, Height - 2);

            objGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width, Height);//上面一条为原始的版本,20070920修改为了不显示边框

            //画X轴,pen,x1,y1,x2,y2 注意图像的原始X轴和Y轴计算是以左上角为原点，向右和向下计算的


            Pen objPenOfGrid = new Pen(new SolidBrush(GridColor), 1);
            objPenOfGrid.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;//画虚线

            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), PenWidth), LMargin, Height - BMargin, (Width - RMargin), Height - BMargin);//画X轴,pen,x1,y1,x2,y2
            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), PenWidth), LMargin, Height - BMargin, LMargin, Height - BMargin - (Across + 1) * YSlice);//画Y轴,pen,x1,y1,x2,y2

            if (blnDrawGrid)
            {
                //画平行于X轴的线条,即横线
                int tempa = 1;
                for (int a = 1; a <= ((Height - (BMargin + TMargin)) / YSliceHalf); a++)
                {
                    if (a != ((Height - (BMargin + TMargin)) / YSliceHalf))
                        objGraphics.DrawLine(objPenOfGrid, LMargin + 1, Height - (BMargin + a * YSliceHalf), Width - RMargin, Height - (BMargin + a * YSliceHalf));//20071012添加的,画平行于X轴的线条
                    else
                        objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), LMargin, Height - (BMargin + a * YSliceHalf), Width - RMargin, Height - (BMargin + a * YSliceHalf));//20071012添加的,画平行于X轴的线条
                    tempa = a;
                }

                //画平行于Y轴的线条,即竖线
                float s = float.Parse(((Width - LMargin) / XSlice).ToString().Split('.')[0]);
                for (int b = 1; b <= s; b++)
                {
                    if (LMargin + b * XSlice >= Width - RMargin)
                    {
                        objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), LMargin + b * XSlice, Height - BMargin, LMargin + b * XSlice, TMargin);//画平行于Y轴的线条,pen,x1,y1,x2,y2
                        if (LMargin + b * XSlice != Width - RMargin)
                        {
                            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), PenWidth), LMargin, Height - BMargin, LMargin + b * XSlice, Height - BMargin);//重新画X轴(因为结束时的X轴坐标有变动)
                            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), LMargin, Height - (BMargin + tempa * YSliceHalf), LMargin + b * XSlice, Height - (BMargin + tempa * YSliceHalf));//重新画平行于X轴最后一根线(因为结束时的X轴坐标有变动)
                        }
                        break;
                    }
                    if (b != s)
                    {
                        if (b % 5 == 0)
                        {
                            PointF Ponit = new PointF(LMargin + b * XSlice, Height - BMargin);
                            objGraphics.DrawRectangle(new Pen(new SolidBrush(AxisColor), 1), Ponit.X - 1, Ponit.Y - 1, 2, 2);
                        }
                        //else
                        objGraphics.DrawLine(objPenOfGrid, LMargin + b * XSlice, Height - BMargin - PenWidth, LMargin + b * XSlice, TMargin);//画平行于Y轴的线条,pen,x1,y1,x2,y2
                    }
                }
            }

            SetAxisText(ref objGraphics);//初始化轴线说明文字

            SetXAxis(ref objGraphics);//初始化X轴上的刻度和文字

            SetYAxis(ref objGraphics);//初始化Y轴上的刻度和文字

            CreateTitle(ref objGraphics);//初始化标题
        }
        #endregion 


        #region 初始化和填充图像区域，画出边框，初始标题
        private void InitializeGraphPie(Bitmap pobjBitmap)
        {
            //objBitmap = new Bitmap(Width, Height);//根据给定的高度和宽度创建一个位图图像
            objBitmap = pobjBitmap;
            ZoomSize = m_Width / 1000;//计算自动缩放比例

            //从指定的 objBitmap 对象创建 objGraphics 对象 (即在objBitmap对象中画图)

            objGraphics = Graphics.FromImage(objBitmap);


            //根据给定颜色(LightGray)填充图像的矩形区域 (背景)
            objGraphics.DrawRectangle(new Pen(BorderColor, 1), 0, 0, Width, Height);

            //objGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width - 2, Height - 2);

            objGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width, Height);//上面一条为原始的版本,20070920修改为了不显示边框

            //画X轴,pen,x1,y1,x2,y2 注意图像的原始X轴和Y轴计算是以左上角为原点，向右和向下计算的


            Pen objPenOfGrid = new Pen(new SolidBrush(GridColor), 1);
            objPenOfGrid.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;//画虚线

            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), PenWidth), LMargin, Height - BMargin, (Width - RMargin), Height - BMargin);//画X轴,pen,x1,y1,x2,y2
            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), PenWidth), LMargin, Height - BMargin, LMargin, Height - BMargin - (Across + 1) * YSlice);//画Y轴,pen,x1,y1,x2,y2

            if (blnDrawGrid)
            {
                //画平行于X轴的线条,即横线
                int tempa = 1;
                for (int a = 1; a <= ((Height - (BMargin + TMargin)) / YSliceHalf); a++)
                {
                    if (a != ((Height - (BMargin + TMargin)) / YSliceHalf))
                        objGraphics.DrawLine(objPenOfGrid, LMargin + 1, Height - (BMargin + a * YSliceHalf), Width - RMargin, Height - (BMargin + a * YSliceHalf));//20071012添加的,画平行于X轴的线条
                    else
                        objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), LMargin, Height - (BMargin + a * YSliceHalf), Width - RMargin, Height - (BMargin + a * YSliceHalf));//20071012添加的,画平行于X轴的线条
                    tempa = a;
                }

                //画平行于Y轴的线条,即竖线
                float s = float.Parse(((Width - LMargin) / XSlice).ToString().Split('.')[0]);
                for (int b = 1; b <= s; b++)
                {
                    if (LMargin + b * XSlice >= Width - RMargin)
                    {
                        objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), LMargin + b * XSlice, Height - BMargin, LMargin + b * XSlice, TMargin);//画平行于Y轴的线条,pen,x1,y1,x2,y2
                        if (LMargin + b * XSlice != Width - RMargin)
                        {
                            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), PenWidth), LMargin, Height - BMargin, LMargin + b * XSlice, Height - BMargin);//重新画X轴(因为结束时的X轴坐标有变动)
                            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), LMargin, Height - (BMargin + tempa * YSliceHalf), LMargin + b * XSlice, Height - (BMargin + tempa * YSliceHalf));//重新画平行于X轴最后一根线(因为结束时的X轴坐标有变动)
                        }
                        break;
                    }
                    if (b != s)
                    {
                        if (b % 5 == 0)
                        {
                            PointF Ponit = new PointF(LMargin + b * XSlice, Height - BMargin);
                            objGraphics.DrawRectangle(new Pen(new SolidBrush(AxisColor), 1), Ponit.X - 1, Ponit.Y - 1, 2, 2);
                        }
                        //else
                        objGraphics.DrawLine(objPenOfGrid, LMargin + b * XSlice, Height - BMargin - PenWidth, LMargin + b * XSlice, TMargin);//画平行于Y轴的线条,pen,x1,y1,x2,y2
                    }
                }
            }

           // SetAxisText(ref objGraphics);//初始化轴线说明文字

            SetXAxis(ref objGraphics);//初始化X轴上的刻度和文字

            SetYAxis(ref objGraphics);//初始化Y轴上的刻度和文字

            CreateTitle(ref objGraphics);//初始化标题
        }
        #endregion

        #region 设置X轴,Y轴方向文本(轴线标题:代表的意思)
        private void SetAxisText(ref Graphics objGraphics)
        {
            float XAxisTextPointX = Width / 2;
            float Ydiff = BMargin / 2;
            if (XAxisTextAlign == "right")
            {
                XAxisTextPointX = Width - RMargin + 5;
                Ydiff = 45;
            }
            DrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            if (blnPress100)
                objGraphics.DrawString(XAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), XAxisTextPointX, Height - BMargin - 40, DrawFormat);//默认放在图片正中间
            else
                objGraphics.DrawString(XAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), XAxisTextPointX, Height - BMargin - 10);//默认放在图片正中间

            DrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            float X = 15;
            float Y = (Height / 2) - 45;
            float YAxisTextPointY = TMargin - 20;
            if (YAxisTextAlign == "top")
            {
                byte[] bytStr = System.Text.Encoding.Default.GetBytes(YAxisText);

                objGraphics.DrawString(YAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), LMargin + float.Parse(bytStr.Length.ToString()) * 3, YAxisTextPointY, DrawFormat);
                bytStr = null;
            }
            else
            {
                for (int i = 0; i < YAxisText.Length; i++)
                {
                    objGraphics.DrawString(YAxisText[i].ToString(), new Font("宋体", 10), new SolidBrush(AxisTextColor), X, Y);
                    Y += 15;
                }
            }
        }
        #endregion

        #region 设置X轴,Y轴方向文本(轴线标题:代表的意思) pie
        private void SetAxisTextPie(ref Graphics objGraphics)
        {
            float XAxisTextPointX = 580;
            float Ydiff = BMargin / 2;
            if (XAxisTextAlign == "right")
            {
                XAxisTextPointX = Width - RMargin + 5;
                Ydiff = 45;
            }
            DrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            if (blnPress100)
                objGraphics.DrawString(XAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), XAxisTextPointX, Height - BMargin - 48, DrawFormat);//默认放在图片正中间
            else
                objGraphics.DrawString(XAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), XAxisTextPointX, Height - BMargin - 18);//默认放在图片正中间

            DrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            float X = 75;
            float Y = 50;//(Height / 2) - 45;
            float YAxisTextPointY = 50;// TMargin - 20;
            float XAxisTextPointY =75;// TMargin - 20;
            if (YAxisTextAlign == "top")
            {
                byte[] bytStr = System.Text.Encoding.Default.GetBytes(YAxisText);

                objGraphics.DrawString(YAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), XAxisTextPointY, YAxisTextPointY, DrawFormat);
                bytStr = null;
            }
            else
            {
                DrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                //for (int i = 0; i < YAxisText.Length; i++)
               // {
                    objGraphics.DrawString(YAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), X, Y);
                    //Y += 15;
               // }
            }
        }
        #endregion

        #region 画X坐标
        private void SetXAxis(ref Graphics objGraphics)
        {
            int y1 = Height - 110;
            int x2 = 100;
            int y2 = (int)(Height - BMargin + 5);
            int iCount = 0;
            int iXSliceCount = 1;
            int iMold = 1;
            float Scale = 0;
            int iWidth = (int)((Width) * (50 / XSlice));

            DrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            if (PictType == "Curve")
                objGraphics.DrawString(Keys[0].ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), LMargin - 5, y2, DrawFormat);

            for (int i = 0; i <= iWidth; i += 10)
            {
                Scale = i * (XSlice / 50) + 10;

                if (iCount == 5)
                {
                    if (blnPress100)
                    {
                        if (iMold > 500)
                            break;
                        if (iXSliceCount > 100)
                        {
                            iXSliceCount = iXSliceCount % 100;
                        }
                        if (iXSliceCount <= Keys.Length - 1 && Keys[iXSliceCount] != "NULL")
                        {
                            if (PictType == "Curve")
                            {
                                objGraphics.DrawString(Keys[iXSliceCount].ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), LMargin + Scale - 15, y2, DrawFormat);

                                if (iXSliceCount == Keys.Length - 1)
                                {
                                    if (float.Parse(CurveDesc[(iMold / 100) - 1]) > 0f)
                                    {
                                        StringFormat sf = new StringFormat();
                                        sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                                        objGraphics.DrawString("第" + CurveDesc[(iMold / 100) - 1] + "啤", new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), (LMargin + 20 + ((iMold / 100) - 0.5f) * XSlice * 100), TMargin - 15, sf);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (iXSliceCount <= Keys.Length - 1 && Keys[iXSliceCount] != "NULL")
                        {
                            if (PictType == "Curve")
                            {
                                objGraphics.DrawString(Keys[iXSliceCount].ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), LMargin + Scale - 15, y2, DrawFormat);
                            }
                        }
                    }
                    iCount = 0;
                    iXSliceCount++;
                    iMold++;
                }
                else
                {
                    if (blnDrawDetail)
                    {
                        objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), LMargin + Scale, y1 + 5, x2 + Scale, y2 - 5);
                    }
                }
                iCount++;
            }
        }
        #endregion

        #region 画Y坐标
        private void SetYAxis(ref Graphics objGraphics)
        {
            int x1 = 95, y1 = (int)(Height - 45 - 10 * (YSlice / 50));
            int x2 = 105, y2 = (int)(Height - 45 - 10 * (YSlice / 50));

            int iCount = 1;
            float Scale = 0;
            int iSliceCount = 1;

            int iHeight = (int)((Height) * (50 / YSlice));

            DrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            objGraphics.DrawString(YSliceBegin.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), LMargin - 1, Height - BMargin - 10, DrawFormat);

            for (int i = 0; i < iHeight; i += 10)
            {
                Scale = i * (YSlice / 50);
                if (iCount == 5)
                {
                    if (iSliceCount <= Across + 1)
                        objGraphics.DrawString(Convert.ToString(YSliceValue * iSliceCount + YSliceBegin), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), LMargin - 1, Height - BMargin - Scale - 15, DrawFormat);
                    else
                        break;
                    iCount = 0;
                    iSliceCount++;
                }
                else
                {
                    if (blnDrawDetail)
                    {
                        objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), x1, y1 - Scale, x2, y2 - Scale);
                    }
                }
                iCount++;
            }
        }

        #endregion

        #region 初始化标题
        private void CreateTitle(ref Graphics objGraphics)
        {
            int XMiddle = (Width / 2) - 80;
            int YSecond = 30;
            int YThird = 45;

            objGraphics.DrawString(MainTitle, new Font("宋体", 15), new SolidBrush(TitleColor), new Point(XMiddle, 5));//20070920modify
            objGraphics.DrawString(SubTitle, new Font("宋体", SliceFontSize), new SolidBrush(SubTitleColor), new Point(Width / 2 + Width / 4, YSecond));//20070920modify
            objGraphics.DrawString(Warning, new Font("宋体", SliceFontSize), new SolidBrush(WarningColor), new Point(Width / 2 + Width / 4, YThird));//20070920modify
            objGraphics.DrawString(ProductTime, new Font("宋体", SliceFontSize), new SolidBrush(Color.Black), new Point((int)LMargin, (int)(TMargin / 3)));//20070920modify
            objGraphics.DrawString(ObjectNo, new Font("宋体", SliceFontSize), new SolidBrush(Color.Black), new Point((int)(LMargin - 1), (int)(TMargin / 3 + 15)));//20070920modify
            if (blnTemperature)//代表温度
            {
                DrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                for (int i = 0; i < Stand_FieldDesc.Length; i++)
                {
                    objGraphics.DrawString(Stand_FieldDesc[i], new Font("宋体", SliceFontSize), new SolidBrush(CurveColors[CurveColors.Length - StandParaCount + i]), Width - RMargin - i * 60, TMargin - 15, DrawFormat);
                }
            }
            if (LivedParaCount == 1)
            {
                objGraphics.DrawString(StatData1, new Font("宋体", SliceFontSize), new SolidBrush(Color.Black), new Point((int)(2 * (Width - LMargin) / 3), (int)(TMargin / 3)));//20070920modify
                objGraphics.DrawString(StatData2, new Font("宋体", SliceFontSize), new SolidBrush(Color.Black), new Point((int)(2 * (Width - LMargin) / 3), (int)(TMargin / 3 + 15)));//20070920modify
                objGraphics.DrawString(StatData3, new Font("宋体", SliceFontSize), new SolidBrush(Color.Black), new Point((int)(2 * (Width - LMargin) / 3), (int)(TMargin / 3 + 30)));//20070920modify
            }
            else
            {
                for (int i = 0; i < StatData.Count; i++)
                {
                    string[] strStatData = (StatData[i] as string[]);
                    for (int j = 0; j < strStatData.Length; j++)
                    {
                        objGraphics.DrawString(strStatData[j], new Font("宋体", SliceFontSize), new SolidBrush(Color.Black), new Point((int)(Width * 0.45f + (i + 1) * (0.55f * Width - LMargin) / 4), (int)(TMargin / 3 + j * 15)));//20070920modify
                    }
                }
            }
        }
        #endregion

        #region 画内容曲线
        private void DrawCurve(ref Graphics objGraphics)
        {
            DrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            Pen CurvePen = null;

            PointF[] CurvePointF = new PointF[Keys.Length];
            float keys = 0;
            float values = 0;

            float XOffset1 = LMargin + YSliceBegin;
            float XOffset2 = (XSlice / 50) * (50 / XSliceValue);

            float YOffset1 = (Height - BMargin) + YSliceBegin;
            float YOffset2 = (YSlice / 50) * (50 / YSliceValue);

            bool isFlag = false;
            if (pArrayList != null)
            {
                for (int i = 0; (i < pArrayList.Count); i++)
                {
                    isFlag = false;
                    float[] Values = pArrayList[i] as float[];

                    ArrayList tempList = new ArrayList();
                    for (int j = 0; j < Values.Length; j++)
                    {
                        if (Values[j] >= 0f)
                            tempList.Add(Values[j]);
                    }

                    CurvePointF = new PointF[tempList.Count];
                    for (int j = 0; (j < tempList.Count); j++)
                    {
                        float tempValue = float.Parse(tempList[j].ToString());

                        keys = XSlice * j + LMargin;
                        values = YOffset1 - (tempValue) * YOffset2;

                        if (tempValue <= 0f)
                            values = Height - BMargin;//X轴的Y坐标

                        isFlag = true;
                        CurvePointF[j] = new PointF(keys, values);

                        //以下是画实际的曲线的点位
                        if (i > StandParaCount - 1 && StandParaCount != 0)
                        {
                            if (tempValue > 0)//只有大于0的值才画出点,等于0或小于0的都画在X轴上面,所以没必要画
                            {
                                objGraphics.DrawEllipse(new Pen(Color.Blue, 3), CurvePointF[j].X - 1, CurvePointF[j].Y - 1, 2, 2);//描出对应的点

                                if (blnDrawData)
                                {
                                    objGraphics.DrawString(tempValue.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X - 1, CurvePointF[j].Y - 1, DrawFormat);//描出相应点所对应的数值
                                }
                            }
                            if (blnExData)//异常记录的时候,写出对应的啤数序号
                            {
                                for (int k = 0; k < ExDataIndex.Count; k++)
                                {
                                    int TempIndex = int.Parse(ExDataIndex[k].ToString());
                                    if (TempIndex == j)
                                        objGraphics.DrawString(ExData[k].ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X - 1, CurvePointF[j].Y - 1.5f, DrawFormat);//描出相应点的数据
                                }
                            }
                        }
                        else//以下是画最大值,最小值,标准值的点位(通常是连接起来的点都是直线)
                        {
                            if (tempValue != 0 && j == tempList.Count - 1 && blnDrawConst)
                            {
                                if (Stand_FieldDesc != null && Stand_FieldDesc.Length == StandParaCount)
                                    objGraphics.DrawString(Stand_FieldDesc[i] + " " + tempValue.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X + 1, CurvePointF[j].Y - 5);//描出说明文字与对应的值
                                else
                                    objGraphics.DrawString(tempValue.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X + 1, CurvePointF[j].Y - 5);//不描出说明文字,只描出值
                            }
                        }
                    }

                    if (isFlag)
                    {
                        CurvePen = new Pen(CurveColors[i], PenWidth);
                        objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        for (int k = 0; k < CurvePointF.Length - 1; k++)
                        {
                            if (CurvePointF[k].Y == Height - BMargin && CurvePointF[k + 1].Y == Height - BMargin)
                            {
                                objGraphics.DrawLine(new Pen(AxisColor, PenWidth), CurvePointF[k], CurvePointF[k + 1]);//利用画线段,和X轴线的重合的就轴线颜色
                                //objGraphics.DrawCurve(new Pen(AxisColor, PenWidth), CurvePointF[k]);//利用画线段,和X轴线的重合的就轴线颜色
                            }
                            else
                            {
                                objGraphics.DrawLine(CurvePen, CurvePointF[k], CurvePointF[k + 1]);//本身的颜色画线段
                                //objGraphics.DrawCurve(CurvePen, CurvePointF[k]);//本身的颜色画线段
                            }
                        }
                        //objGraphics.DrawCurve(new Pen(AxisColor, PenWidth), CurvePointF);
                    }
                    CurvePointF = new PointF[Keys.Length];
                }
            }
            else
            {
                objGraphics.DrawString("键值不匹配，画曲线失败!", new Font("宋体", 16), new SolidBrush(TitleColor), new Point(150, Height / 2));
            }
        }
        #endregion

        private void DrawCurve2(ref Graphics objGraphics)
        {
            DrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            Pen CurvePen = null;

            PointF[] CurvePointF = new PointF[Keys.Length];
            float keys = 0;
            float values = 0;

            float YOffset1 = (Height - BMargin) + YSliceBegin;
            float YOffset2 = (YSlice / 50) * (50 / YSliceValue);
            float XOffset1 = LMargin + YSliceBegin;
            float XOffset2 = (XSlice / 50) * (50 / XSliceValue);

            bool isFlag = false;
            if (pArrayList != null)
            {
                for (int i = 0; (i < pArrayList.Count); i++)
                {
                    isFlag = false;
                    float[] Values = pArrayList[i] as float[];

                    CurvePointF = new PointF[Keys.Length - 1];//后来添加的2007/11/21
                    for (int j = 0; (j < Values.Length); j++)
                    {
                        if (j != Keys.Length - 1)
                        {
                            float tempValue = Values[j];
                            if (i < 1)
                                keys = XSlice * j + LMargin;
                            else
                                keys = (i - 1) * 100 * XSlice + XSlice * j + LMargin;

                            values = YOffset1 - tempValue * YOffset2;
                            if (tempValue <= 0)
                                values = Height - BMargin;//X轴的Y坐标

                            isFlag = true;
                            CurvePointF[j] = new PointF(keys, values);

                            if (i > StandParaCount - 1 && StandParaCount != 0)
                            {
                                if (tempValue > 0)
                                {
                                    objGraphics.DrawEllipse(new Pen(Color.Blue, 3), CurvePointF[j].X - 1, CurvePointF[j].Y - 1, 2, 2);//描出对应的点
                                    if (blnDrawData)
                                        objGraphics.DrawString(tempValue.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X - 1, CurvePointF[j].Y - 1, DrawFormat);//描出相应点的数据
                                }
                            }//画实际生产时候产生的曲线
                            else
                            {
                                if (blnDrawConst && j == Values.Length - 1 && tempValue != 0)
                                {
                                    if (Stand_FieldDesc != null && Stand_FieldDesc.Length == StandParaCount)
                                    {
                                        objGraphics.DrawString(Stand_FieldDesc[i] + " " + tempValue.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X + 1, CurvePointF[j].Y - 5);//描出说明文字与对应的值
                                    }
                                    else
                                        objGraphics.DrawString(tempValue.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(Color.Blue), CurvePointF[j].X + 1, CurvePointF[j].Y - 5);//不描出说明文字,只描出值
                                }
                            }//画最大值,最小值,标准值(通常是一根直线)
                        }
                    }
                    if (isFlag)
                    {
                        CurvePen = new Pen(CurveColors[i], PenWidth);
                        objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        for (int k = 0; k < CurvePointF.Length - 1; k++)
                        {
                            CurvePen = new Pen(CurveColors[i], PenWidth);
                            if (CurvePointF[k].Y == Height - BMargin && CurvePointF[k + 1].Y == Height - BMargin)
                            {
                                objGraphics.DrawLine(new Pen(AxisColor, 1), CurvePointF[k], CurvePointF[k + 1]);//利用画线段,和X轴线的重合的就轴线颜色
                                //objGraphics.DrawCurve(new Pen(AxisColor, 1), CurvePointF[k]);//利用画线段,和X轴线的重合的就轴线颜色

                            }
                            else
                            {
                                objGraphics.DrawLine(CurvePen, CurvePointF[k], CurvePointF[k + 1]);//本身的颜色画线段
                                //objGraphics.DrawCurve(CurvePen, CurvePointF[k]);//本身的颜色画线段
                            }
                        }
                        //objGraphics.DrawLines(CurvePen, CurvePointF);
                        //objGraphics.DrawCurve(CurvePen, CurvePointF);
                    }
                    CurvePointF = new PointF[Keys.Length - 1];
                }
            }
            else
            {
                objGraphics.DrawString("键值不匹配，画曲线失败!", new Font("宋体", 16), new SolidBrush(TitleColor), new Point(150, Height / 2));
            }
        }
        /// <summary>
        /// 画圆饼图
        /// </summary>
        /// <param name="objGraphics"></param>
        private void DrawCake(ref Graphics objGraphics)
        {
            float smallRectWidth = 30f;
            float smallRectHeight = 20f;

            PointF symbolLeg = new PointF(Width / 2 + 205, 150);
            //PointF descLeg = new PointF(symbolLeg.X + smallRectWidth, symbolLeg.Y + 5);
            PointF descLeg = new PointF(Width - 90, 155);

            float PieWidth = 120;
            float PieHeight = 120;

            float YOffset1 = Height - BMargin + YSliceBegin;
            float YOffset2 = (YSlice / 50) * (50 / YSliceValue);

            if (pArrayList != null)
            {
                for (int a = 0; (a < pArrayList.Count); a++)
                {
                    float[] Values = new float[(pArrayList[a] as float[]).Length];
                    Values = pArrayList[a] as float[];

                    for (int i = 0; i < Values.Length-1; i++)//圆的解释文字
                    {
                        objGraphics.FillRectangle(new SolidBrush(CurveColors[i]), Width - 120, symbolLeg.Y, smallRectWidth, smallRectHeight-3);
                        objGraphics.DrawRectangle(Pens.Black, Width - 120, symbolLeg.Y, smallRectWidth, smallRectHeight-3);
                        objGraphics.DrawString(Keys[i].ToString(), new Font("宋体", 10), Brushes.Black, descLeg);
                        symbolLeg.Y += 25;
                        descLeg.Y += 25;
                    }
                    for (int i = 0; i < Values.Length; i++)//画矩形
                    {
                        float width = 20;
                        float x = LMargin + i * XSlice + (XSlice - width) / 2+10;
                       // x = x + i * 5;

                        float height = YOffset1 - (Values[i]) * YOffset2;

                        objGraphics.FillRectangle(new SolidBrush(CurveColors[i]), x, height, width, Height - BMargin - height);
                        objGraphics.DrawRectangle(Pens.Black, x, height, width, Height - BMargin - height);
                        objGraphics.DrawString(Values[i].ToString(), new Font("宋体", 10), Brushes.Black, x, height - 15);
                        //objGraphics.DrawString(Keys[i], new Font("宋体", 10), Brushes.Black, x, Height - BMargin + 5);
                        DrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                        objGraphics.DrawString(Keys[i], new Font("宋体", 10), Brushes.Black, x, Height - BMargin + 5, DrawFormat);
                        //objGraphics.DrawString(Keys[i], new Font("宋体", 10), Brushes.Black, x,( Height - BMargin + 5)*-1);
                    }

                    float sglCurrentAngle = 0f;
                    float sglTotalAngle = 0f;
                    float sglTotalValues = 0f;

                    for (int i = 0; i < Values.Length - 1; i++)
                    {
                        sglTotalValues += Values[i];
                    }

                    for (int i = 0; i < Values.Length-1; i++)//画圆
                    {
                        sglCurrentAngle = Values[i] / sglTotalValues * 360;
                        //objGraphics.FillPie(new SolidBrush(CurveColors[i]), Width / 2, Height / 4, PieWidth, PieHeight, sglTotalAngle, sglCurrentAngle);
                        objGraphics.FillPie(new SolidBrush(CurveColors[i]), Width - 250, Height / 4, PieWidth, PieHeight, sglTotalAngle, sglCurrentAngle);
                        objGraphics.DrawPie(Pens.Black, Width - 250, Height / 4, PieWidth, PieHeight, sglTotalAngle, sglCurrentAngle);
                        sglTotalAngle += sglCurrentAngle;
                    }
                }
            }
            else
            {
                objGraphics.DrawString("键值不匹配，画曲线失败!", new Font("宋体", 16), new SolidBrush(TitleColor), new Point(150, Height / 2));
            }
        }
    }
}