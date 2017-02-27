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
    public class TempDraw
    {
        private float m_YSliceValue = 1;
        private float m_XSliceValue = 1;
        private string[] m_Keys = null;
        private string[] m_ParaNameCH = null;

        ArrayList m_DataBlockList = new ArrayList();
        ArrayList m_vArrayList = new ArrayList();
        private Boolean m_Press100 = false;
        private Boolean m_SingleParaFlag = true;
        private string[] m_ExDataFieldName = null;
        private ArrayList m_ExData = new ArrayList();
        private ArrayList m_ExDataIndex = new ArrayList();
        private Boolean m_isWriteExData = false;

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
        
        public string[] Keys
        {
            set { m_Keys = value; }
            get { return m_Keys; }
        }
        
        public ArrayList DataBlockList
        {
            set { m_DataBlockList = value; }
            get { return m_DataBlockList; }
        }

        public ArrayList vArrayList
        {
            set { m_vArrayList = value; }
            get { return m_vArrayList; }
        }

        public Boolean Press100
        {
            set { m_Press100 = value; }
            get { return m_Press100; }
        }

        public Boolean isWriteExData
        {
            set { m_isWriteExData = value; }
            get { return m_isWriteExData; }
        }
        public Boolean SingleParaFlag
        {
            set { m_SingleParaFlag = value; }
            get { return m_SingleParaFlag; }
        }

        public string[] ParaNameCH
        {
            set { m_ParaNameCH = value; }
            get { return m_ParaNameCH; }
        }
        public string[] ExDataFieldName
        {
            set { m_ExDataFieldName = value; }
            get { return m_ExDataFieldName; }
        }

        public ArrayList ExData
        {
            set { m_ExData = value; }
            get { return m_ExData; }
        }

        public ArrayList ExDataIndex
        {
            set { m_ExDataIndex = value; }
            get { return m_ExDataIndex; }
        }

        public void DrawPicture(int X_MAX_LENGHT, int Y_MAX_LENGHT, string bDateTime, string eDateTime, 
            string[] Stand_FieldName, string[] Lived_FieldName, DataTable stand_dt, DataTable lived_dt)
        {
            ArrayList StandValuesList = new ArrayList();
            ArrayList LivedValuesList = new ArrayList();

            int stand_rowscount = (stand_dt == null) ? 0 : stand_dt.Rows.Count;
            int lived_rowscount = (lived_dt == null) ? 0 : lived_dt.Rows.Count;

            int Mold_Seriate = 1, Mold_Discrete = 1;
            int s1 = 0, s2 = 0, s3 = 0, total = 0;

            System.TimeSpan TimeSpan1 = DateTime.Parse(eDateTime).Subtract(DateTime.Parse(bDateTime));
            s1 = (TimeSpan1.Days == 0) ? 0 : TimeSpan1.Days * 24 * 60;
            s2 = (TimeSpan1.Hours == 0) ? 0 : TimeSpan1.Hours * 60;
            s3 = (TimeSpan1.Minutes == 0) ? 0 : TimeSpan1.Minutes;
            total = s1 + s2 + s3;

            //求出以时间为横坐标的模值(连续型的数据)
            if (total > X_MAX_LENGHT && X_MAX_LENGHT == 61)
            {
                for (int a = 1; a != -1; a++)
                {
                    if ((a * (X_MAX_LENGHT - 1)) >= total)
                    {
                        Mold_Seriate = a;
                        break;
                    }
                }
            }
            //求出以啤数为横坐标的模值(离散型的数据)
            if (lived_rowscount > X_MAX_LENGHT && X_MAX_LENGHT >= 101)
            {
                for (int a = 1; a != -1; a++)
                {
                    if (a * (X_MAX_LENGHT - 1) >= lived_rowscount)
                    {
                        Mold_Discrete = a;
                        break;
                    }
                }
            }

            string[] UpLoadTimes = new string[lived_rowscount];

            float[] SingleStandValues = new float[Stand_FieldName.Length];
            float[] SingleLivedValues = new float[Lived_FieldName.Length];
            ArrayList tempStandValuesList = new ArrayList();
            ArrayList tempLivedValuesList = new ArrayList();

            //得到标准值(如周期,温度,压力,位移,速度...........)
            foreach (DataRow dr in stand_dt.Rows)
            {
                int Length = Stand_FieldName.Length;
                SingleStandValues = new float[Length];

                for (int b = 0; b < Length; b++)
                    SingleStandValues[b] = (stand_rowscount == 0) ? 0f : float.Parse(dr[Stand_FieldName[b]].ToString().Trim());

                StandValuesList.Add(SingleStandValues);
            }
            //得到现场值(如周期,温度,压力,位移,速度...........)
            if (lived_rowscount != 0)
            {
                int a = 0;
                foreach (DataRow dr in lived_dt.Rows)
                {
                    //存入所有的记录             判断是否为空为空就换成0曾豪改
                    SingleLivedValues = new float[Lived_FieldName.Length];
                    string t = "";
                    for (int b = 0; b < Lived_FieldName.Length; b++){
                        if (Convert.IsDBNull(dr[Lived_FieldName[b]]))
                        {
                            t = "0";
                        }
                        else
                        {
                            if (dr[Lived_FieldName[b]].ToString().Trim() == "")
                            {
                                t = "0";
                            }
                            else
                            {
                                t = dr[Lived_FieldName[b]].ToString().Trim();
                            }
                        }
                        // = (Convert.IsDBNull(dr[Lived_FieldName[b]]) ? 110 : dr[Lived_FieldName[b]]).ToString().Trim();
                        SingleLivedValues[b] = (lived_rowscount == 0) ? 0f : float.Parse(t);
                     
                    }
                    tempLivedValuesList.Add(SingleLivedValues);
                    //tempLivedValuesList.Add(SingleLivedValues);
                    //处理异常的记录
                    if (isWriteExData)
                    {
                        if (ExDataFieldName != null)
                            for (int b = 0; b < ExDataFieldName.Length; b++)
                            {
                                if ((lived_dt.Rows.IndexOf(dr)) % 10 == 0)
                                {
                                    if (float.Parse(dr[ExDataFieldName[b]].ToString()) != 0)
                                    {
                                        ExData.Add(dr[ExDataFieldName[b]].ToString() + " " + dr["BeginCycle"].ToString().Substring(11,5));
                                        ExDataIndex.Add(a);
                                    }
                                }
                            }

                    }

                    if (X_MAX_LENGHT == 61)
                        UpLoadTimes[a] = dr["UpLoadTime"].ToString().Trim();
                    a = a + 1;
                }

                Keys = new string[X_MAX_LENGHT];
                string[] midKeys = new string[X_MAX_LENGHT];
                string[] tKeys = new string[lived_rowscount];
                //*************************************************************
                if (Keys.Length == 61)
                {
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        midKeys[i] = (i * Mold_Seriate).ToString().Trim();

                        if (((i) % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i * Mold_Seriate).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                }
                if (X_MAX_LENGHT >= 101)
                {
                    for (int i = 0; i < X_MAX_LENGHT; i++)
                    {
                        midKeys[i] = (i * Mold_Discrete).ToString().Trim();
                        if (Press100)
                        {
                            if ((i % 10) == 0 || i == Keys.Length - 1)
                                Keys[i] = (i * Mold_Discrete).ToString().Trim();
                            else
                                Keys[i] = "NULL";
                        }
                        else
                        {
                            if ((i % 5) == 0 || i == Keys.Length - 1)
                                Keys[i] = (i * Mold_Discrete).ToString().Trim();
                            else
                                Keys[i] = "NULL";
                        }
                    }
                }
                //*************************************************************
                DataTable dt = new DataTable();
                DataTable LivedDataTable = new DataTable();
                //添加列
                foreach (string FieldName in Lived_FieldName)
                {
                    dt.Columns.Add(new DataColumn(FieldName));
                    LivedDataTable.Columns.Add(new DataColumn(FieldName));
                }
                //添加虚假的资料行
                for (int i = 0; i < X_MAX_LENGHT; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (string FieldName in Lived_FieldName)
                        dr[FieldName] = -1f;
                    dt.Rows.Add(dr);
                    dr = null;
                }
                //添加实际的资料行
                foreach (DataRow dr in dt.Rows)
                {
                    float[] NullArray = new float[Lived_FieldName.Length];
                    for (int j = 0; j < Lived_FieldName.Length; j++)
                        NullArray[j] = float.Parse(dr[Lived_FieldName[j]].ToString());
                    LivedValuesList.Add(NullArray);
                }
                //******************************************************************
                if (X_MAX_LENGHT == 61)
                {
                    for (int i = 0; i < lived_rowscount; i++)
                    {
                        s1 = 0; s2 = 0; s3 = 0;

                        TimeSpan1 = DateTime.Parse(UpLoadTimes[i]).Subtract(DateTime.Parse(UpLoadTimes[0]));
                        s1 = (TimeSpan1.Days == 0) ? 0 : TimeSpan1.Days * 24 * 60;
                        s2 = (TimeSpan1.Hours == 0) ? 0 : TimeSpan1.Hours * 60;
                        s3 = (TimeSpan1.Minutes == 0) ? 0 : TimeSpan1.Minutes;

                        tKeys[i] = (s1 + s2 + s3).ToString();
                    }
                }

                if (X_MAX_LENGHT >= 101)
                {
                    int CollectCount = 0;

                    if ((lived_rowscount % Mold_Discrete) != 0)
                        CollectCount = lived_rowscount / Mold_Discrete + 1;
                    else
                        CollectCount = lived_rowscount / Mold_Discrete;

                    for (int j = 0, j0 = 0; j < lived_rowscount; j0++)
                    {
                        j = j + Mold_Discrete;
                        DataRow dr = LivedDataTable.NewRow();
                        for (int k = 0; k < Lived_FieldName.Length; k++)
                        {
                            float sum = 0, avg = 0;
                            int flag = 0;
                            for (int l = j - Mold_Discrete; l < j; l++)
                            {
                                if (l < lived_rowscount)
                                {
                                    sum += (float.Parse(lived_dt.Rows[l][Lived_FieldName[k]].ToString().Trim()));
                                    flag +=1;
                                }
                            }
                            avg = sum / Mold_Discrete;
                            if (flag < Mold_Discrete)
                            {
                               avg = sum / flag;
                            }
                            dr[Lived_FieldName[k]] = float.Parse(System.Math.Round(avg, 2).ToString().Trim()); ;
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
                                        float vf0 = f0 - Mold_Seriate;
                                        float vf1 = f1 - Mold_Seriate;
                                        if (vf0 > 0 && vf1 <= 0)
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
                for (int i = 0; i < Keys.Length; i++)
                {
                    if (Press100)
                    {
                        if ((i % 10) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i * Mold_Discrete).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                    else
                    {
                        if ((i % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                        {
                            if (X_MAX_LENGHT == 61)
                                Keys[i] = (i * Mold_Seriate).ToString().Trim();
                            else
                                Keys[i] = (i * Mold_Discrete).ToString().Trim();
                        }
                        else
                            Keys[i] = "NULL";
                    }
                }
            }//无现场生产值


            if (X_MAX_LENGHT == 61)
                XSliceValue = Mold_Seriate;
            else
                XSliceValue = Mold_Discrete;
            //***************************************************
            //获取标准生产值和现场生产值中最大的值
            //MaxNum最大的值
            //***************************************************
            float[] stand = returnCollect(StandValuesList, Stand_FieldName);
            float[] lived = returnCollect(LivedValuesList, Lived_FieldName);

            float YLastMaxNum = 1f;
            if (stand_rowscount != 0 && lived_rowscount != 0)
                YLastMaxNum = Math.Max(stand[stand.Length - 1], lived[lived.Length - 1]);
            else if (stand_rowscount != 0 && lived_rowscount == 0)
                YLastMaxNum = stand[stand.Length - 1];//MaxNum最大的值
            else if (stand_rowscount == 0 && lived_rowscount != 0)
                YLastMaxNum = lived[lived.Length - 1];//MaxNum最大的值
            else
                YLastMaxNum = Y_MAX_LENGHT;

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

            //**********************************************
            //
            //标准生产值,如温度,压力,周期,位移,速度
            //
            //**********************************************
            for (int b = 0; b < Stand_FieldName.Length; b++)//先取一个字段
            {
                float[] tempOneFieldValues = new float[X_MAX_LENGHT];
                if (StandValuesList.Count == 1)
                {
                    for (int c = 0; c < X_MAX_LENGHT; c++)
                        tempOneFieldValues[c] = (StandValuesList[0] as float[])[b];//把此字段值放入同一数组
                }
                else
                {
                    tempOneFieldValues = new float[StandValuesList.Count];
                    for (int a = 0; a < StandValuesList.Count; a++)
                        tempOneFieldValues[a] = (StandValuesList[a] as float[])[b];
                }
                vArrayList.Add(tempOneFieldValues);//把此字段生成的数组放入一个ArrayList
            }
            //**********************************************
            //
            // 实际生产值,如温度,压力,周期,位移,速度
            //
            //**********************************************
            for (int a = 0; a < Lived_FieldName.Length; a++)//先取一个字段
            {
                float[] tempOneFieldValues = new float[LivedValuesList.Count];
                for (int b = 0; b < LivedValuesList.Count; b++)
                {
                    tempOneFieldValues[b] = (LivedValuesList[b] as float[])[a];//把此字段值放入同一数组
                }
                vArrayList.Add(tempOneFieldValues);//把此字段生成的数组放入一个ArrayList
            }
            if (SingleParaFlag)
            {
                if (!Press100)
                    getMiddleValue(Stand_FieldName, Lived_FieldName, stand_dt, lived_dt);
            }
            else
                getMinMidMaxValue(Stand_FieldName, Lived_FieldName, stand_dt, lived_dt);
            
        }

        private void getMiddleValue(string[] Stand_FieldName, string[] Lived_FieldName, DataTable stand_dt, DataTable lived_dt)
        {
            int lived_rowscount = lived_dt.Rows.Count;
            float StandValue = 0;
            ArrayList MidArrayList = new ArrayList();
            
            for (int j = 0; j < Lived_FieldName.Length; j++)
            {
                StandValue = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[j]].ToString().Trim());
                string[] DataBlock = new string[3];
                string LessStandValue = "", RealStandValue = "", MoreStandValue = "";
                int iLessStandValue = 0, iStandValue = 0, iMoreStandValue = 0;
                for (int i = 0; i < lived_rowscount; i++)
                {
                    float tempV = float.Parse(lived_dt.Rows[i][Lived_FieldName[j]].ToString().Trim());
                    if (tempV < StandValue)
                        iLessStandValue += 1;
                    else if (tempV == StandValue)
                        iStandValue += 1;
                    else
                        iMoreStandValue += 1;
                }
                LessStandValue = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iLessStandValue / lived_rowscount, 2).ToString() + "%";
                RealStandValue = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iStandValue / lived_rowscount, 2).ToString() + "%";
                MoreStandValue = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iMoreStandValue / lived_rowscount, 2).ToString() + "%";

                if (ParaNameCH != null && ParaNameCH.Length != 0)
                {
                    DataBlock[0] = " " + ParaNameCH[j] + " <标准值:" + LessStandValue;
                    DataBlock[1] = "       =标准值:" + RealStandValue;
                    DataBlock[2] = "       >标准值:" + MoreStandValue;
                }
                else
                {
                    DataBlock[0] = "  <标准值:" + LessStandValue;
                    DataBlock[1] = "  =标准值:" + RealStandValue;
                    DataBlock[2] = "  >标准值:" + MoreStandValue;
                }
                MidArrayList.Add(DataBlock);
            }

            DataBlockList = MidArrayList;
        }

        private void getMinMidMaxValue(string[] Stand_FieldName, string[] Lived_FieldName, DataTable stand_dt, DataTable lived_dt)
        {
            int lived_rowscount = lived_dt.Rows.Count;
            float MinV = 0, MidV = 0, MaxV = 0;
            int Length = Stand_FieldName.Length;
            if (Length <= 1)
            {
                MinV = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[0]].ToString().Trim());
            }
            else if (Length > 1 && Length <= 2)
            {
                MinV = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[0]].ToString().Trim());
                MidV = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[1]].ToString().Trim());
            }
            else
            {
                MinV = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[0]].ToString().Trim());
                MidV = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[1]].ToString().Trim());
                MaxV = (stand_dt.Rows.Count == 0) ? 0 : float.Parse(stand_dt.Rows[0][Stand_FieldName[2]].ToString().Trim());
            }
            ArrayList MidArrayList = new ArrayList();
            for (int j = 0; j < Lived_FieldName.Length; j++)
            {
                string[] DataBlock = new string[5];
                string LessMinV = "", LessMidV = "", SameMidV = "", MoreMidV = "", MoreMaxV = "";
                int iLessMinV = 0 ,iLessMidV = 0, iSameMidV = 0, iMoreMidV = 0, iMoreMaxV = 0;
                for (int i = 0; i < lived_rowscount; i++)
                {
                    float tempV = float.Parse(lived_dt.Rows[i][Lived_FieldName[j]].ToString().Trim());
                    if (tempV < MinV)
                        iLessMinV += 1;
                    else if (tempV >= MinV && tempV < MidV)
                        iLessMidV += 1;
                    else if (tempV == MidV)
                        iSameMidV += 1;
                    else if (tempV > MidV && tempV <= MaxV)
                        iMoreMidV += 1;
                    else if (tempV > MaxV)
                        iMoreMaxV += 1;
                }
                LessMinV = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iLessMinV / lived_rowscount, 2).ToString() + "%";
                LessMidV = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iLessMidV / lived_rowscount, 2).ToString() + "%";
                SameMidV = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iSameMidV / lived_rowscount, 2).ToString() + "%";
                MoreMidV = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iMoreMidV / lived_rowscount, 2).ToString() + "%";
                MoreMaxV = (lived_rowscount == 0) ? "0.0%" : System.Math.Round(100f * iMoreMaxV / lived_rowscount, 2).ToString() + "%";

                DataBlock[0] = "  <最小值:" + LessMinV;
                DataBlock[1] = "  ≥最小值且<标准值:" + LessMidV;
                DataBlock[2] = "  =标准值:" + SameMidV;
                DataBlock[3] = "  >标准值且≤最大值:" + MoreMidV;
                DataBlock[4] = "  >最大值:" + MoreMaxV;

                MidArrayList.Add(DataBlock);
            }
            DataBlockList = MidArrayList;
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
    }
}


