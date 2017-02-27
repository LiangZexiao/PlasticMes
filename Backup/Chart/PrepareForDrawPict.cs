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
    public class PrepareForDrawPict
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

        public void DrawPicture(int xMaxlgt, int yMaxlgt, string bDateTime, string eDateTime,
            string[] stdFieldName, string[] livFieldName, DataTable stdDataTbl, DataTable livDataTbl)
        {
            ArrayList StandValuesList = new ArrayList();
            ArrayList LivedValuesList = new ArrayList();

            int stand_rowscount = (stdDataTbl == null) ? 0 : stdDataTbl.Rows.Count;
            int lived_rowscount = (livDataTbl == null) ? 0 : livDataTbl.Rows.Count;
            int Mold_Discrete = 1;

            //求出以啤数为横坐标的模值(离散型的数据)
            if (lived_rowscount > xMaxlgt && xMaxlgt >= 101)
            {
                for (int a = 1; a != -1; a++)
                {
                    if (a * (xMaxlgt - 1) >= lived_rowscount)
                    {
                        Mold_Discrete = a;
                        break;
                    }
                }
            }

            float[] SingleStandValues = new float[stdFieldName.Length];
            float[] SingleLivedValues = new float[livFieldName.Length];
            ArrayList tempStandValuesList = new ArrayList();
            ArrayList tempLivedValuesList = new ArrayList();

            //得到标准值(如周期,温度,压力,位移,速度...........)
            foreach (DataRow dr in stdDataTbl.Rows)
            {
                int Length = stdFieldName.Length;
                SingleStandValues = new float[Length];

                for (int b = 0; b < Length; b++)
                    SingleStandValues[b] = (stand_rowscount == 0) ? 0f : float.Parse(dr[stdFieldName[b]].ToString().Trim());

                StandValuesList.Add(SingleStandValues);
            }
            //有现场生产值的时候(如周期,温度,压力,位移,速度...........)
            if (lived_rowscount != 0)
            {
                Keys = new string[xMaxlgt];
                string[] midKeys = new string[xMaxlgt];
                string[] tKeys = new string[lived_rowscount];

                if (xMaxlgt >= 101)
                {
                    for (int i = 0; i < xMaxlgt; i++)
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
                foreach (string FieldName in livFieldName)
                {
                    dt.Columns.Add(new DataColumn(FieldName));
                    LivedDataTable.Columns.Add(new DataColumn(FieldName));
                }
                //添加虚假的资料行
                for (int i = 0; i < xMaxlgt; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (string FieldName in livFieldName)
                        dr[FieldName] = -1f;
                    dt.Rows.Add(dr);
                    dr = null;
                }
                //添加实际的资料行
                foreach (DataRow dr in dt.Rows)
                {
                    float[] NullArray = new float[livFieldName.Length];
                    for (int j = 0; j < livFieldName.Length; j++)
                        NullArray[j] = float.Parse(dr[livFieldName[j]].ToString());
                    LivedValuesList.Add(NullArray);
                }
                //******************************************************************
                if (xMaxlgt >= 101)
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
                        for (int k = 0; k < livFieldName.Length; k++)
                        {
                            float sum = 0, avg = 0;
                            int flag = 0;
                            for (int l = j - Mold_Discrete; l < j; l++)
                            {
                                if (l < lived_rowscount)
                                {
                                    sum += (float.Parse(livDataTbl.Rows[l][livFieldName[k]].ToString().Trim()));
                                    flag += 1;
                                }
                            }
                            avg = sum / Mold_Discrete;
                            if (flag < Mold_Discrete)
                            {
                                avg = sum / flag;
                            }
                            dr[livFieldName[k]] = float.Parse(System.Math.Round(avg, 2).ToString().Trim()); ;
                        }
                        LivedDataTable.Rows.Add(dr);
                    }

                    ArrayList tempK = new ArrayList();
                    for (int i = 0; i < LivedDataTable.Rows.Count; i++)
                    {
                        float[] NullArray = new float[livFieldName.Length];
                        for (int j = 0; j < livFieldName.Length; j++)
                            NullArray[j] = float.Parse(LivedDataTable.Rows[i][livFieldName[j]].ToString());
                        tempK.Add(NullArray);
                    }

                    for (int i = 0; i < tempK.Count; i++)
                    {
                        LivedValuesList[i] = tempK[i];
                    }
                }
            }
            else
            {
                Keys = new string[xMaxlgt];
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
                            Keys[i] = (i * Mold_Discrete).ToString().Trim();
                        else
                            Keys[i] = "NULL";
                    }
                }
            }//无现场生产值

            XSliceValue = Mold_Discrete;
            //***************************************************
            //获取标准生产值和现场生产值中最大的值
            //MaxNum最大的值
            //***************************************************
            float[] stand = returnCollect(StandValuesList, stdFieldName);
            float[] lived = returnCollect(LivedValuesList, livFieldName);

            float YLastMaxNum = 1f;
            if (stand_rowscount != 0 && lived_rowscount != 0)
                YLastMaxNum = Math.Max(stand[stand.Length - 1], lived[lived.Length - 1]);
            else if (stand_rowscount != 0 && lived_rowscount == 0)
                YLastMaxNum = stand[stand.Length - 1];//MaxNum最大的值
            else if (stand_rowscount == 0 && lived_rowscount != 0)
                YLastMaxNum = lived[lived.Length - 1];//MaxNum最大的值
            else
                YLastMaxNum = yMaxlgt;

            if (YLastMaxNum > yMaxlgt)
            {
                for (int a = 1; a != -1; a++)
                {
                    if ((a * yMaxlgt) >= YLastMaxNum)
                    {
                        YSliceValue = a;
                        break;
                    }
                }
            }
            else
                YSliceValue = 1f;

            Hashtable[] hts = new Hashtable[stdFieldName.Length + livFieldName.Length];

            if (stand_rowscount != 0)
            {
                int i = 0;
                foreach (string stdValue in stdFieldName)
                {

                    hts[i] = new Hashtable();
                    foreach (string Key in Keys)
                    {
                        hts[i].Add(Key, stdDataTbl.Rows[0][stdValue].ToString());
                    }
                    i = i + 1;
                }
            }
            if (lived_rowscount != 0)
                for (int i = 0; (i < livFieldName.Length); i++)
                {
                    int j = 0;
                    foreach (string Key in Keys)
                    {
                        hts[i + stdFieldName.Length].Add(Key, livDataTbl.Rows[j][livFieldName[i]].ToString());
                        j = j + 1;
                    }
                }

            //**********************************************
            //
            //标准生产值,如温度,压力,周期,位移,速度
            //
            //**********************************************
            for (int b = 0; b < stdFieldName.Length; b++)//先取一个字段
            {
                float[] tempOneFieldValues = new float[xMaxlgt];
                if (StandValuesList.Count == 1)
                {
                    for (int c = 0; c < xMaxlgt; c++)
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
            for (int a = 0; a < livFieldName.Length; a++)//先取一个字段
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
                    getMiddleValue(stdFieldName, livFieldName, stdDataTbl, livDataTbl);
            }
            else
                getMinMidMaxValue(stdFieldName, livFieldName, stdDataTbl, livDataTbl);

        }

        private void getMiddleValue(string[] stdFieldName, string[] livFieldName, DataTable stdDataTbl, DataTable livDataTbl)
        {
            int lived_rowscount = livDataTbl.Rows.Count;
            float StandValue = 0;
            ArrayList MidArrayList = new ArrayList();

            for (int j = 0; j < livFieldName.Length; j++)
            {
                StandValue = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[j]].ToString().Trim());
                string[] DataBlock = new string[3];
                string LessStandValue = "", RealStandValue = "", MoreStandValue = "";
                int iLessStandValue = 0, iStandValue = 0, iMoreStandValue = 0;
                for (int i = 0; i < lived_rowscount; i++)
                {
                    float tempV = float.Parse(livDataTbl.Rows[i][livFieldName[j]].ToString().Trim());
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

        private void getMinMidMaxValue(string[] stdFieldName, string[] livFieldName, DataTable stdDataTbl, DataTable livDataTbl)
        {
            int lived_rowscount = livDataTbl.Rows.Count;
            float MinV = 0, MidV = 0, MaxV = 0;
            int Length = stdFieldName.Length;
            if (Length <= 1)
            {
                MinV = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[0]].ToString().Trim());
            }
            else if (Length > 1 && Length <= 2)
            {
                MinV = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[0]].ToString().Trim());
                MidV = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[1]].ToString().Trim());
            }
            else
            {
                MinV = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[0]].ToString().Trim());
                MidV = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[1]].ToString().Trim());
                MaxV = (stdDataTbl.Rows.Count == 0) ? 0 : float.Parse(stdDataTbl.Rows[0][stdFieldName[2]].ToString().Trim());
            }
            ArrayList MidArrayList = new ArrayList();
            for (int j = 0; j < livFieldName.Length; j++)
            {
                string[] DataBlock = new string[5];
                string LessMinV = "", LessMidV = "", SameMidV = "", MoreMidV = "", MoreMaxV = "";
                int iLessMinV = 0, iLessMidV = 0, iSameMidV = 0, iMoreMidV = 0, iMoreMaxV = 0;
                for (int i = 0; i < lived_rowscount; i++)
                {
                    float tempV = float.Parse(livDataTbl.Rows[i][livFieldName[j]].ToString().Trim());
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
