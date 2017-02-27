using System;
using System.Collections;
using System.Drawing;

namespace Chart
{
    public class Curve
    {
        #region 变量定义
        private Graphics objGraphics; //Graphics 类提供将对象绘制到显示设备的方法
        private Bitmap objBitmap; //位图对象

        /// <summary>
        /// 数字区
        /// </summary>
        private int m_Width = 900; //图像宽度
        private int m_Height = 500; //图像高度
        private float m_XSlice = 50; //X轴刻度宽度
        private float m_YSlice = 50; //Y轴刻度宽度
        private float m_YSliceValue = 20; //Y轴刻度的数值宽度
        private float m_YSliceBegin = 0; //Y轴刻度开始值        

        private int m_YLineNum = 6;//最多画多少条平行X轴方向的直线(背景横线)
        private int m_XLineNum = 15;//最多画多少条平行Y轴方向的直线(背景竖线)  

        private string[] m_Keys = null;//键
        private float[] m_RedValues = null;//值
        private float[] m_BlueValues = null;//值
        private float[] m_GreenValues = null;//值
        private float[] m_BlackValues = null;//值
        private float m_YMaxValue = 0;//Y轴的最大的数值
              
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

        private string m_RedText = null;//描述4种曲线所代表的意思
        private string m_BlueText = null;
        private string m_GreenText = null;
        private string m_BlackText = null;

        private string m_XAxisMold = "hour";
        /// <summary>
        /// 颜色区
        /// </summary>
        private Color m_BgColor = Color.Snow; //背景
        private Color m_BorderColor = Color.White; //整体边框颜色
        //private Color m_BorderColor = Color.Black; //整体边框颜色
        
        private Color m_TitleColor = Color.Black; //文字颜色
        private Color m_SubTitleColor = Color.Blue; //副标题文字颜色
        private Color m_WarningColor = Color.Red;//

        private Color m_AxisColor = Color.Black; //轴线颜色        
        private Color m_AxisTextColor = Color.Black; //轴说明文字颜色
        private Color m_SliceColor = Color.Black; //刻度颜色
        private Color m_SliceTextColor = Color.Black; //刻度文字颜色
        
        private Color m_CurveColor = Color.Red; //曲线颜色
        private Color[] m_CurveColors = null;
        private Color m_GridColor = Color.YellowGreen;//背景网格线的颜色

        private float m_Tension = 0.5f;
        private float ZoomSize = 1f;
        /// <summary>
        /// 设置条件区
        /// </summary>
        private Boolean m_DrawDetail = false;//是否画细刻度


        /// <summary>
        /// 输入值
        /// </summary>
        private ArrayList m_ArrayList = null;

        #region 数字区
        public int Width
        {
            set { m_Width = (value < 300) ? 300 : value;}
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

        public float YSliceValue
        {
            set { m_YSliceValue = value; }
            get { return m_YSliceValue; }
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

        public int YLineNum
        {
            set { m_YLineNum = value; }
            get { return m_YLineNum; }
        }

        public int XLineNum
        {
            set { m_XLineNum = value; }
            get { return m_XLineNum; }
        }

        public float[] RedValues
        {
            set { m_RedValues = value; }
            get { return m_RedValues; }
        }

        public float[] BlueValues
        {
            set { m_BlueValues = value; }
            get { return m_BlueValues; }
        }
        public float[] GreenValues
        {
            set { m_GreenValues = value; }
            get { return m_GreenValues; }
        }
        public float[] BlackValues
        {
            set { m_BlackValues = value; }
            get { return m_BlackValues; }
        }

        public float YMaxValue
        {
            set { m_YMaxValue = value; }
            get { return m_YMaxValue; }
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

        public string RedText
        {
            set { m_RedText = value; }
            get { return m_RedText; }
        }

        public string BlueText
        {
            set { m_BlueText = value; }
            get { return m_BlueText; }
        }

        public string GreenText
        {
            set { m_GreenText = value; }
            get { return m_GreenText; }
        }

        public string BlackText
        {
            set { m_BlackText = value; }
            get { return m_BlackText; }
        }

        public string XAxisMold
        {
            set { m_XAxisMold = value; }
            get { return m_XAxisMold; }
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

        public Color CurveColor
        {
            set { m_CurveColor = value; }
            get { return m_CurveColor; }
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
        public Boolean DrawDetail
        {
            set { m_DrawDetail = value; }
            get { return m_DrawDetail; }
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

        public ArrayList pArrayList
        {
            set { m_ArrayList = value; }
            get { return (m_ArrayList == null) ? null : m_ArrayList; }
        }

        #endregion
        #region 生成图像并返回bmp图像对象
        public Bitmap CreateImage()
        {
            Bitmap tempBitmap = new Bitmap(Width, Height);//根据给定的高度和宽度创建一个位图图像
            InitializeGraph(tempBitmap);

            DrawContent(ref objGraphics);

            return objBitmap;
        }
        #endregion

        #region 生成直方图像并返回bmp图像对象
        public Bitmap MakeImage()
        {
            Bitmap tempBitmap = new Bitmap(Width, Height);//根据给定的高度和宽度创建一个位图图像
            InitializeGraph(tempBitmap);

            DrawImage(ref objGraphics);

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
            int XStartPoint = 75;
            int YStartPoint = 75;
            int XUnitLenght = 25;
            int YUnitLenght = 50;
            if (XLineNum == 24)
                YUnitLenght = 25;

            int YDiffLenght = 40;
            int YEndPonit = 60;

            Pen objPenOfGrid = new Pen(new SolidBrush(GridColor), 1);
            objPenOfGrid.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;//画虚线

            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), XStartPoint, Height - YDiffLenght, Width - 25, Height - YDiffLenght);//画X轴,pen,x1,y1,x2,y2
            for (int a = 1; a <= ((Height - 100) / XUnitLenght); a++)
            {
                if (a != ((Height - 100) / XUnitLenght))
                    objGraphics.DrawLine(objPenOfGrid, XStartPoint, Height - (YDiffLenght + a * XUnitLenght), Width - 25, Height - (YDiffLenght + a * XUnitLenght));//20071012添加的,画平行于X轴的线条
                else
                    objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), XStartPoint, Height - (YDiffLenght + a * XUnitLenght), Width - 25, Height - (YDiffLenght + a * XUnitLenght));//20071012添加的,画平行于X轴的线条
            }

            objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), YStartPoint, Height - YDiffLenght, YStartPoint, YEndPonit);//画Y轴,pen,x1,y1,x2,y2
            for (int b = 1; b <= ((Width - 75) / YUnitLenght); b++)
            {
                if (b != ((Width - 75) / YUnitLenght))
                {
                    objGraphics.DrawLine(objPenOfGrid, YStartPoint + b * YUnitLenght, Height - YDiffLenght, YStartPoint + b * YUnitLenght, YEndPonit);//画平行于Y轴的线条,pen,x1,y1,x2,y2
                }
                else
                    objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), YStartPoint + b * YUnitLenght, Height - YDiffLenght, YStartPoint + b * YUnitLenght, YEndPonit);//画平行于Y轴的线条,pen,x1,y1,x2,y2
            }

            SetAxisText(ref objGraphics);//初始化轴线说明文字

            SetXAxis(ref objGraphics);//初始化X轴上的刻度和文字

            SetYAxis(ref objGraphics);//初始化Y轴上的刻度和文字

            CreateTitle(ref objGraphics);//初始化标题
        }
        #endregion

        #region 设置X轴,Y轴方向文本(轴线标题:代表的意思)
        private void SetAxisText(ref Graphics objGraphics)
        {
            objGraphics.DrawString(XAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), Width / 2, Height - 20);

            int X = 15;
            int Y = (Height / 2) - 45;
            for (int i = 0; i < YAxisText.Length; i++)
            {
                objGraphics.DrawString(YAxisText[i].ToString(), new Font("宋体", 10), new SolidBrush(AxisTextColor), X, Y);
                Y += 15;
            }
        }
        #endregion

        #region 画X坐标
        private void SetXAxis(ref Graphics objGraphics)
        {
            int XStart = 60;
            int XUnitLenght = 50;

            int x1 = 75;
            int y1 = Height - 110;
            int x2 = 100;
            int y2 = Height - 35;
            int iCount = 0;
            int iXSliceCount = 1;
            float Scale = 0;
            int iWidth = (int)((Width) * (XUnitLenght / XSlice));

            objGraphics.DrawString(Keys[0].ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), XStart, y2);

            for (int i = 0; i <= iWidth; i += 10)
            {
                Scale = i * (XSlice / XUnitLenght);

                if (iCount == 5)
                {
                    //objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor)), x1 + Scale, y1, x2 + Scale, y2);
                    //The Point!这里显示X轴刻度
                    if (iXSliceCount <= Keys.Length - 1)
                    {
                       objGraphics.DrawString(Keys[iXSliceCount].ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), x1 + Scale - 15, y2);
                    }
                    else
                    {
                        //超过范围，不画任何刻度文字
                    }
                    iCount = 0;
                    iXSliceCount++;
                    if (x1 + Scale > Width - 75)
                    {
                        break;
                    }
                }
                else
                {
                    if (DrawDetail)
                    {
                        objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), x1 + Scale, y1 + 5, x2 + Scale, y2 - 5);
                    }
                }
                iCount++;
            }
        }
        #endregion

        #region 画Y坐标
        private void SetYAxis(ref Graphics objGraphics)
        {
            int x1 = 95;
            int y1 = (int)(Height - 45 - 10 * (YSlice / 50));
            int x2 = 105;
            int y2 = (int)(Height - 45 - 10 * (YSlice / 50));
            int iCount = 1;
            float Scale = 0;
            int iSliceCount = 1;

            int iHeight = (int)((Height ) * (50 / YSlice));

            objGraphics.DrawString(YSliceBegin.ToString(), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), 35, Height - 50);

            for (int i = 0; i < iHeight; i += 10)
            {
                Scale = i * (YSlice / 50);
                if (iCount == 5)
                {
                    //objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor)), x1 - 5, y1 - Scale, x2 + 5, y2 - Scale);
                    //The Point!!这里显示Y轴刻度

                    if (YSliceValue * iSliceCount + YSliceBegin >= YMaxValue)
                    {
                        objGraphics.DrawString(Convert.ToString(YMaxValue), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), 35, y1 - Scale);
                        break;
                    }
                    else
                        objGraphics.DrawString(Convert.ToString(YSliceValue * iSliceCount + YSliceBegin), new Font("宋体", SliceFontSize), new SolidBrush(SliceTextColor), 35, y1 - Scale);
                    if (iSliceCount == YLineNum)
                        break;
                    iCount = 0;
                    iSliceCount++;
                }
                else
                {
                    if (DrawDetail)
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
            int XStartPoint = 75;
            int XMiddle = (Width / 2) - 50;
            int YSecond = 30;
            int YThird = 45;

            objGraphics.DrawString(MainTitle, new Font("宋体", 15), new SolidBrush(TitleColor), new Point(XMiddle, 5));//20070920modify
            objGraphics.DrawString(SubTitle, new Font("宋体", SliceFontSize), new SolidBrush(SubTitleColor), new Point(Width / 2 + Width / 4, YSecond));//20070920modify
            objGraphics.DrawString(Warning, new Font("宋体", SliceFontSize), new SolidBrush(WarningColor), new Point(Width / 2 + Width / 4, YThird));//20070920modify

            if (RedText != null)
            {
                m_CurveColor = Color.Red;
                objGraphics.DrawString(RedText, new Font("宋体", SliceFontSize), new SolidBrush(CurveColor), XStartPoint, YThird);
            }
            if (BlueText != null)
            {
                m_CurveColor = Color.Blue;
                objGraphics.DrawString(BlueText, new Font("宋体", SliceFontSize), new SolidBrush(CurveColor), XMiddle, YSecond);
            }
            if (GreenText != null)
            {
                m_CurveColor = Color.Green;
                objGraphics.DrawString(GreenText, new Font("宋体", SliceFontSize), new SolidBrush(CurveColor), XStartPoint, YSecond);
            }
            if (BlackText != null)
            {
                m_CurveColor = Color.Black;
                objGraphics.DrawString(BlackText, new Font("宋体", SliceFontSize), new SolidBrush(CurveColor), XMiddle, YThird);
            }

        }
        #endregion

        #region 画内容曲线
        private void DrawContent(ref Graphics objGraphics)
        {
            int StartPoint = 75;
            Pen CurvePen = new Pen(CurveColor, 1);
            PointF[] CurvePointF = new PointF[Keys.Length];
            float keys = 0;
            float values = 0;

            float Offset1 = (Height - 40) + YSliceBegin;
            float Offset2 = (YSlice / 50) * (50 / YSliceValue);
            float PenWidth = 2;
            bool isFlag = false;

            if (pArrayList != null)
            {
                for (int i = 0; (i < pArrayList.Count && pArrayList.Count == CurveColors.Length); i++)
                {
                    isFlag = false;
                    float[] Values = new float[(pArrayList[i] as float[]).Length];
                    Values = pArrayList[i] as float[];

                    for (int j = 0; (j < Values.Length && Keys.Length == Values.Length); j++)
                    {
                        keys = XSlice * j + StartPoint;
                        values = Offset1 - Values[j] * Offset2;
                        CurvePointF[j] = new PointF(keys, values);
                        if (Values[j] != 0)
                            isFlag = true;
                    }

                    CurvePen = new Pen(CurveColors[i], PenWidth);
                    if (isFlag)
                        objGraphics.DrawLines(CurvePen, CurvePointF);
                }
            }
            else
            {
                objGraphics.DrawString("键值不匹配，画曲线失败!", new Font("宋体", 16), new SolidBrush(TitleColor), new Point(150, Height / 2));
            }
        }
        #endregion

        private void DrawImage(ref Graphics objGraphics)
        {
             
        }
    }
}
