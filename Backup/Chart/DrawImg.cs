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
    public class DrawImg
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

        private string[] Stand_FieldName
        {
            set { m_Stand_FieldName = value; }
            get { return m_Stand_FieldName; }
        }

        private string[] Lived_FieldName
        {
            set { m_Lived_FieldName = value; }
            get { return m_Lived_FieldName; }
        }

        public byte[] ExecDrawImage(string PictID, string bDateTime, string eDateTime, DataTable stand_dt, DataTable lived_dt)
        {
            System.TimeSpan TimeSpan = DateTime.Parse(eDateTime).Subtract(DateTime.Parse(bDateTime));
            int Range = TimeSpan.Days + 1;
            int stand_rowscount = stand_dt.Rows.Count;
            int lived_rowscount = lived_dt.Rows.Count;

            string TempTime = string.Empty;
            string[] Keys = null;

            string[] tEndTimes = new string[lived_rowscount];
            float[] StandValues = new float[X_MAX_LENGHT];
            float[] StandValues1 = new float[X_MAX_LENGHT];
            float[] StandValues2 = new float[X_MAX_LENGHT];
            float[] StandValues3 = new float[X_MAX_LENGHT];
            float[] StandValues4 = new float[X_MAX_LENGHT];
            float[] StandValues5 = new float[X_MAX_LENGHT];
            float[] StandValues6 = new float[X_MAX_LENGHT];
            float[] StandValues7 = new float[X_MAX_LENGHT];
            float[] StandValues8 = new float[X_MAX_LENGHT];
            float[] StandValues9 = new float[X_MAX_LENGHT];

            float[] tempLivedValues = new float[lived_rowscount];
            float[] tempLivedValues1 = new float[lived_rowscount];
            float[] tempLivedValues2 = new float[lived_rowscount];
            float[] tempLivedValues3 = new float[lived_rowscount];
            float[] tempLivedValues4 = new float[lived_rowscount];
            float[] tempLivedValues5 = new float[lived_rowscount];
            float[] tempLivedValues6 = new float[lived_rowscount];
            float[] tempLivedValues7 = new float[lived_rowscount];
            float[] tempLivedValues8 = new float[lived_rowscount];
            float[] tempLivedValues9 = new float[lived_rowscount];

            float[] baseLivedValues = new float[lived_rowscount];
            float[] baseLivedValues1 = new float[lived_rowscount];
            float[] baseLivedValues2 = new float[lived_rowscount];
            float[] baseLivedValues3 = new float[lived_rowscount];
            float[] baseLivedValues4 = new float[lived_rowscount];
            float[] baseLivedValues5 = new float[lived_rowscount];
            float[] baseLivedValues6 = new float[lived_rowscount];
            float[] baseLivedValues7 = new float[lived_rowscount];
            float[] baseLivedValues8 = new float[lived_rowscount];
            float[] baseLivedValues9 = new float[lived_rowscount];

            float[] lastLivedValues = new float[lived_rowscount];
            float[] lastLivedValues1 = new float[lived_rowscount];
            float[] lastLivedValues2 = new float[lived_rowscount];
            float[] lastLivedValues3 = new float[lived_rowscount];
            float[] lastLivedValues4 = new float[lived_rowscount];
            float[] lastLivedValues5 = new float[lived_rowscount];
            float[] lastLivedValues6 = new float[lived_rowscount];
            float[] lastLivedValues7 = new float[lived_rowscount];
            float[] lastLivedValues8 = new float[lived_rowscount];
            float[] lastLivedValues9 = new float[lived_rowscount];

            float StandCycle = 0f;
            float StandShotMouthTemp1 = 0f, StandShotMouthTemp2 = 0f, StandShotMouthTemp3 = 0f;

            float StandShotPress1 = 0f, StandShotPress2 = 0f, StandShotPress3 = 0f, StandShotPress4 = 0f;
            float StandKeepPress1 = 0f, StandKeepPress2 = 0f, StandKeepPress3 = 0f;
            float StandFastLockMouldPress = 0f, StandLowPressLockMouldPress = 0f, StandHighPressLockMouldPress = 0f;

            if (PictID == "Cycle")
            {
                StandCycle = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["StandCycle"].ToString().Trim());
                for (int i = 0; i < StandValues.Length; i++)
                    StandValues[i] = StandCycle;

                for (int i = 0; (i < lived_rowscount); i++)
                {
                    tEndTimes[i] = lived_dt.Rows[i]["EndTime"].ToString().Trim();
                    tempLivedValues[i] = float.Parse(lived_dt.Rows[i]["avgLivedCycle"].ToString().Trim());
                    baseLivedValues[i] = float.Parse(lived_dt.Rows[i]["avgLivedCycle"].ToString().Trim());
                }
                //执行冒泡排序,以便得到最大的周期值
                tempLivedValues = getSortedArray(tempLivedValues);               
            }            

            if (PictID == "Temp")
            {
                StandShotMouthTemp1 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotMouthTemp1"].ToString().Trim());
                StandShotMouthTemp2 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotMouthTemp2"].ToString().Trim());
                StandShotMouthTemp3 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotMouthTemp3"].ToString().Trim());
                for (int i = 0; i < StandValues.Length; i++)
                {
                    StandValues[i] = StandShotMouthTemp1;
                    StandValues1[i] = StandShotMouthTemp2;
                    StandValues2[i] = StandShotMouthTemp3;
                }
                for (int i = 0; (i < lived_rowscount); i++)
                {
                    tEndTimes[i] = lived_dt.Rows[i]["EndTime"].ToString().Trim();
                    tempLivedValues[i] = float.Parse(lived_dt.Rows[i]["AvgTemp1"].ToString().Trim());
                    tempLivedValues1[i] = float.Parse(lived_dt.Rows[i]["AvgTemp2"].ToString().Trim());
                    tempLivedValues2[i] = float.Parse(lived_dt.Rows[i]["AvgTemp3"].ToString().Trim());

                    baseLivedValues[i] = float.Parse(lived_dt.Rows[i]["AvgTemp1"].ToString().Trim());
                    baseLivedValues1[i] = float.Parse(lived_dt.Rows[i]["AvgTemp2"].ToString().Trim());
                    baseLivedValues2[i] = float.Parse(lived_dt.Rows[i]["AvgTemp3"].ToString().Trim());
                }
                //执行冒泡排序,以便得到最大的周期值
                tempLivedValues = getSortedArray(tempLivedValues);
                tempLivedValues1 = getSortedArray(tempLivedValues1);
                tempLivedValues2 = getSortedArray(tempLivedValues2);
            }
            if (PictID == "Press")
            {
                StandShotPress1 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotPress1"].ToString().Trim());
                StandShotPress2 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotPress2"].ToString().Trim());
                StandShotPress3 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotPress3"].ToString().Trim());
                StandShotPress4 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["ShotPress4"].ToString().Trim());

                StandKeepPress1 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["KeepPress1"].ToString().Trim());
                StandKeepPress2 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["KeepPress2"].ToString().Trim());
                StandKeepPress3 = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["KeepPress3"].ToString().Trim());

                StandFastLockMouldPress = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["FastLockMouldPress"].ToString().Trim());
                StandLowPressLockMouldPress = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["LowPressLockMouldPress"].ToString().Trim());
                StandHighPressLockMouldPress = (stand_rowscount == 0) ? 0 : float.Parse(stand_dt.Rows[0]["HighPressLockMouldPress"].ToString().Trim());

                for (int i = 0; i < StandValues.Length; i++)
                {
                    StandValues[i] = StandShotPress1;
                    StandValues1[i] = StandShotPress2;
                    StandValues2[i] = StandShotPress3;
                    StandValues3[i] = StandShotPress4;
                    StandValues4[i] = StandKeepPress1;
                    StandValues5[i] = StandKeepPress2;
                    StandValues6[i] = StandKeepPress3;

                    StandValues7[i] = StandFastLockMouldPress;
                    StandValues8[i] = StandLowPressLockMouldPress;
                    StandValues9[i] = StandHighPressLockMouldPress;
                }
                for (int i = 0; (i < lived_rowscount); i++)
                {
                    tEndTimes[i] = lived_dt.Rows[i]["EndTime"].ToString().Trim();
                    tempLivedValues[i] = float.Parse(lived_dt.Rows[i]["avgShotPress1"].ToString().Trim());
                    tempLivedValues1[i] = float.Parse(lived_dt.Rows[i]["avgShotPress2"].ToString().Trim());
                    tempLivedValues2[i] = float.Parse(lived_dt.Rows[i]["avgShotPress3"].ToString().Trim());
                    tempLivedValues3[i] = float.Parse(lived_dt.Rows[i]["avgShotPress4"].ToString().Trim());

                    tempLivedValues4[i] = float.Parse(lived_dt.Rows[i]["avgKeepPress1"].ToString().Trim());
                    tempLivedValues5[i] = float.Parse(lived_dt.Rows[i]["avgKeepPress2"].ToString().Trim());
                    tempLivedValues6[i] = float.Parse(lived_dt.Rows[i]["avgKeepPress3"].ToString().Trim());
                    tempLivedValues7[i] = float.Parse(lived_dt.Rows[i]["avgFastLockMouldPress"].ToString().Trim());
                    tempLivedValues8[i] = float.Parse(lived_dt.Rows[i]["avgLowPressLockMouldPress"].ToString().Trim());
                    tempLivedValues9[i] = float.Parse(lived_dt.Rows[i]["avgHighPressLockMouldPress"].ToString().Trim());

                    baseLivedValues[i] = float.Parse(lived_dt.Rows[i]["avgShotPress1"].ToString().Trim());
                    baseLivedValues1[i] = float.Parse(lived_dt.Rows[i]["avgShotPress2"].ToString().Trim());
                    baseLivedValues2[i] = float.Parse(lived_dt.Rows[i]["avgShotPress3"].ToString().Trim());
                    baseLivedValues3[i] = float.Parse(lived_dt.Rows[i]["avgShotPress4"].ToString().Trim());

                    baseLivedValues4[i] = float.Parse(lived_dt.Rows[i]["avgKeepPress1"].ToString().Trim());
                    baseLivedValues5[i] = float.Parse(lived_dt.Rows[i]["avgKeepPress2"].ToString().Trim());
                    baseLivedValues6[i] = float.Parse(lived_dt.Rows[i]["avgKeepPress3"].ToString().Trim());
                    baseLivedValues7[i] = float.Parse(lived_dt.Rows[i]["avgFastLockMouldPress"].ToString().Trim());
                    baseLivedValues8[i] = float.Parse(lived_dt.Rows[i]["avgLowPressLockMouldPress"].ToString().Trim());
                    baseLivedValues9[i] = float.Parse(lived_dt.Rows[i]["avgHighPressLockMouldPress"].ToString().Trim());
                }
                //执行冒泡排序,以便得到最大的周期值
                tempLivedValues = getSortedArray(tempLivedValues);
                tempLivedValues1 = getSortedArray(tempLivedValues1);
                tempLivedValues2 = getSortedArray(tempLivedValues2);
                tempLivedValues3 = getSortedArray(tempLivedValues3);
                tempLivedValues4 = getSortedArray(tempLivedValues4);
                tempLivedValues5 = getSortedArray(tempLivedValues5);
                tempLivedValues6 = getSortedArray(tempLivedValues6);
                tempLivedValues7 = getSortedArray(tempLivedValues7);
                tempLivedValues8 = getSortedArray(tempLivedValues8);
                tempLivedValues9 = getSortedArray(tempLivedValues9);                
            }
            if (lived_rowscount != 0)
            {                
                    TimeSpan = DateTime.Parse(tEndTimes[tEndTimes.Length - 1]).Subtract(DateTime.Parse(tEndTimes[0]));

                    Keys = new string[X_MAX_LENGHT];
                    string[] midKeys = new string[X_MAX_LENGHT];
                    string[] tKeys = new string[lived_rowscount];
                    
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        midKeys[i] = (i * Range * 24).ToString().Trim();
                        if (((i * Range) % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                            Keys[i] = (i * Range * 24).ToString().Trim();
                        else
                            Keys[i] = "";
                    }

                    for (int i = 0; i < lived_rowscount; i++)
                    {
                        if (i != 0)
                        {
                            TimeSpan = DateTime.Parse(tEndTimes[i]).Subtract(DateTime.Parse(tEndTimes[0]));

                            int s1 = (TimeSpan.Days == 0) ? 0 : TimeSpan.Days * 24 * 60;
                            int s2 = (TimeSpan.Hours == 0) ? 0 : TimeSpan.Hours * 60;
                            int s3 = (TimeSpan.Minutes == 0) ? 0 : TimeSpan.Minutes;
                            tKeys[i] = (s1 + s2 + s3).ToString();
                        }
                        else
                            tKeys[i] = "0";
                    }

                    lastLivedValues = new float[midKeys.Length];
                    lastLivedValues1 = new float[midKeys.Length];
                    lastLivedValues2 = new float[midKeys.Length];
                    lastLivedValues3 = new float[midKeys.Length];
                    lastLivedValues4 = new float[midKeys.Length];
                    lastLivedValues5 = new float[midKeys.Length];
                    lastLivedValues6 = new float[midKeys.Length];
                    lastLivedValues7 = new float[midKeys.Length];
                    lastLivedValues8 = new float[midKeys.Length];
                    lastLivedValues9 = new float[midKeys.Length];

                    for (int i = 0; i < midKeys.Length; i++)
                    {
                        for (int j = 0; j < tKeys.Length; j++)
                        {
                            if (tKeys[j] == midKeys[i])
                            {
                                if (PictID == "Cycle")
                                    lastLivedValues[i] = baseLivedValues[j];
                                else if (PictID == "Temp")
                                {
                                    lastLivedValues[i] = baseLivedValues[j];
                                    lastLivedValues1[i] = baseLivedValues1[j];
                                    lastLivedValues2[i] = baseLivedValues2[j];
                                }
                                else if (PictID == "Press")
                                {
                                    lastLivedValues[i] = baseLivedValues[j];
                                    lastLivedValues1[i] = baseLivedValues1[j];
                                    lastLivedValues2[i] = baseLivedValues2[j];
                                    lastLivedValues3[i] = baseLivedValues3[j];
                                    lastLivedValues4[i] = baseLivedValues4[j];
                                    lastLivedValues5[i] = baseLivedValues5[j];
                                    lastLivedValues6[i] = baseLivedValues6[j];
                                    lastLivedValues7[i] = baseLivedValues7[j];
                                    lastLivedValues8[i] = baseLivedValues8[j];
                                    lastLivedValues9[i] = baseLivedValues9[j];
                                }
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    if (tKeys[j] == midKeys[i])
                                    {
                                        if (PictID == "Cycle")
                                            lastLivedValues[i] = baseLivedValues[j];
                                        else if (PictID == "Temp")
                                        {
                                            lastLivedValues[i] = baseLivedValues[j];
                                            lastLivedValues1[i] = baseLivedValues1[j];
                                            lastLivedValues2[i] = baseLivedValues2[j];
                                        }
                                        else if (PictID == "Press")
                                        {
                                            lastLivedValues[i] = baseLivedValues[j];
                                            lastLivedValues1[i] = baseLivedValues1[j];
                                            lastLivedValues2[i] = baseLivedValues2[j];
                                            lastLivedValues3[i] = baseLivedValues3[j];
                                            lastLivedValues4[i] = baseLivedValues4[j];
                                            lastLivedValues5[i] = baseLivedValues5[j];
                                            lastLivedValues6[i] = baseLivedValues6[j];
                                            lastLivedValues7[i] = baseLivedValues7[j];
                                            lastLivedValues8[i] = baseLivedValues8[j];
                                            lastLivedValues9[i] = baseLivedValues9[j];
                                        }
                                    }
                                }
                                else
                                {
                                    float f0 = Math.Abs(float.Parse(tKeys[j]) - float.Parse(midKeys[i - 1]));
                                    float f1 = Math.Abs(float.Parse(tKeys[j]) - float.Parse(midKeys[i]));
                                    if (f0 >= f1)
                                    {
                                        if (PictID == "Cycle")
                                            lastLivedValues[i] = baseLivedValues[j];
                                        else if (PictID == "Temp")
                                        {
                                            lastLivedValues[i] = baseLivedValues[j];
                                            lastLivedValues1[i] = baseLivedValues1[j];
                                            lastLivedValues2[i] = baseLivedValues2[j];
                                        }
                                        else if (PictID == "Press")
                                        {
                                            lastLivedValues[i] = baseLivedValues[j];
                                            lastLivedValues1[i] = baseLivedValues1[j];
                                            lastLivedValues2[i] = baseLivedValues2[j];
                                            lastLivedValues3[i] = baseLivedValues3[j];
                                            lastLivedValues4[i] = baseLivedValues4[j];
                                            lastLivedValues5[i] = baseLivedValues5[j];
                                            lastLivedValues6[i] = baseLivedValues6[j];
                                            lastLivedValues7[i] = baseLivedValues7[j];
                                            lastLivedValues8[i] = baseLivedValues8[j];
                                            lastLivedValues9[i] = baseLivedValues9[j];
                                        }
                                    }
                                    else
                                    {
                                        if (PictID == "Cycle")
                                            lastLivedValues[i - 1] = baseLivedValues[j];
                                        else if (PictID == "Temp")
                                        {
                                            lastLivedValues[i - 1] = baseLivedValues[j];
                                            lastLivedValues1[i - 1] = baseLivedValues1[j];
                                            lastLivedValues2[i - 1] = baseLivedValues2[j];
                                        }
                                        else if (PictID == "Press")
                                        {
                                            lastLivedValues[i - 1] = baseLivedValues[j];
                                            lastLivedValues1[i - 1] = baseLivedValues1[j];
                                            lastLivedValues2[i - 1] = baseLivedValues2[j];
                                            lastLivedValues3[i - 1] = baseLivedValues3[j];
                                            lastLivedValues4[i - 1] = baseLivedValues4[j];
                                            lastLivedValues5[i - 1] = baseLivedValues5[j];
                                            lastLivedValues6[i - 1] = baseLivedValues6[j];
                                            lastLivedValues7[i - 1] = baseLivedValues7[j];
                                            lastLivedValues8[i - 1] = baseLivedValues8[j];
                                            lastLivedValues9[i - 1] = baseLivedValues9[j];
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
                    if (((i * Range) % 5) == 0 || i == Keys.Length - 1)// && i != 0)
                        Keys[i] = (i * Range * 24).ToString().Trim();
                    else
                        Keys[i] = "";
                }
                if (PictID == "Cycle")
                    lastLivedValues = new float[Keys.Length];
                else if (PictID == "Temp")
                {
                    lastLivedValues = new float[Keys.Length];
                    lastLivedValues1 = new float[Keys.Length];
                    lastLivedValues2 = new float[Keys.Length];
                }
                else if (PictID == "Press")
                {
                    lastLivedValues = new float[Keys.Length];
                    lastLivedValues1 = new float[Keys.Length];
                    lastLivedValues2 = new float[Keys.Length];
                    lastLivedValues3 = new float[Keys.Length];
                    lastLivedValues4 = new float[Keys.Length];
                    lastLivedValues5 = new float[Keys.Length];
                    lastLivedValues6 = new float[Keys.Length];
                    lastLivedValues7 = new float[Keys.Length];
                    lastLivedValues8 = new float[Keys.Length];
                    lastLivedValues9 = new float[Keys.Length];
                }
            }

            float LastMaxNum = 0f;
            if (PictID == "Cycle")
                LastMaxNum = (lived_rowscount == 0) ? StandCycle : float.Parse(System.Math.Max(StandCycle, tempLivedValues[tempLivedValues.Length - 1]).ToString());
            if (PictID == "Temp")
            {
                float LivedShotMouthTemp1 = 0f, LivedShotMouthTemp2 = 0f, LivedShotMouthTemp3 = 0f;
                if (lived_rowscount != 0)
                {
                    LivedShotMouthTemp1 = tempLivedValues[tempLivedValues.Length - 1];
                    LivedShotMouthTemp2 = tempLivedValues1[tempLivedValues1.Length - 1];
                    LivedShotMouthTemp3 = tempLivedValues2[tempLivedValues2.Length - 1];
                }

                float[] tempLastMaxNum = getSortedArray(new float[6]{
                    StandShotMouthTemp1, StandShotMouthTemp2, StandShotMouthTemp3,
                    LivedShotMouthTemp1, LivedShotMouthTemp2, LivedShotMouthTemp3});
                LastMaxNum = tempLastMaxNum[tempLastMaxNum.Length - 1];
            }

            if (PictID == "Press")
            {
                float LivedShotPress1 = 0f, LivedShotPress2 = 0f, LivedShotPress3 = 0f, LivedShotPress4 = 0f;
                float LivedKeepPress1 = 0f, LivedKeepPress2 = 0f, LivedKeepPress3 = 0f;
                float LiveddFastLockMouldPress = 0f, LivedLowPressLockMouldPress = 0f, LivedHighPressLockMouldPress = 0f;

                if (lived_rowscount != 0)
                {
                    LivedShotPress1 = tempLivedValues[tempLivedValues.Length - 1];
                    LivedShotPress2 = tempLivedValues1[tempLivedValues1.Length - 1];
                    LivedShotPress3 = tempLivedValues2[tempLivedValues2.Length - 1];
                    LivedShotPress4 = tempLivedValues3[tempLivedValues2.Length - 1];

                    LivedKeepPress1 = tempLivedValues4[tempLivedValues2.Length - 1];
                    LivedKeepPress2 = tempLivedValues5[tempLivedValues2.Length - 1];
                    LivedKeepPress3 = tempLivedValues6[tempLivedValues2.Length - 1];

                    LiveddFastLockMouldPress = tempLivedValues7[tempLivedValues2.Length - 1];
                    LivedLowPressLockMouldPress = tempLivedValues8[tempLivedValues2.Length - 1];
                    LivedHighPressLockMouldPress = tempLivedValues9[tempLivedValues2.Length - 1];
                }
                float[] tempLastMaxNum = getSortedArray(new float[20]{
                    StandShotPress1, StandShotPress2, StandShotPress3,StandShotPress4,
                    StandKeepPress1, StandKeepPress2, StandKeepPress3,
                    StandFastLockMouldPress, StandLowPressLockMouldPress, StandHighPressLockMouldPress,

                    LivedShotPress1, LivedShotPress2, LivedShotPress3, LivedShotPress4,
                    LivedKeepPress1, LivedKeepPress2, LivedKeepPress3,
                    LiveddFastLockMouldPress, LivedLowPressLockMouldPress, LivedHighPressLockMouldPress
                });
                LastMaxNum = tempLastMaxNum[tempLastMaxNum.Length - 1];
            }

            float realYSliceValue = (LastMaxNum <= Y_MAX_LENGHT) ? 1 : float.Parse(System.Math.Round((LastMaxNum / Y_MAX_LENGHT), 0).ToString());

            New_Curve curve2d = new New_Curve();
            curve2d.MainTitle = MainTitle;
            curve2d.Unit = "秒";
            curve2d.XAxisText = XAxisText;

            curve2d.YAxisText = YAxisText;
            curve2d.Across = Y_MAX_LENGHT;

            curve2d.Height = Height;//图片的高度
            curve2d.Width = Width;//图片的宽度

            curve2d.YSliceBegin = 0;
            curve2d.YSliceValue = (realYSliceValue == 0) ? 1 : realYSliceValue;
            //curve2d.YMaxValue = (LastMaxNum == 0) ? 6 : LastMaxNum;
            curve2d.Keys = Keys;

            ArrayList vArrayList = new ArrayList();

            if (PictID == "Cycle")
            {
                vArrayList.Add(StandValues);//标准生产周期
                vArrayList.Add(lastLivedValues);//实际生产周期
            }
            if (PictID == "Temp")
            {
                vArrayList.Add(StandValues);//标准生产温度
                vArrayList.Add(StandValues1);
                vArrayList.Add(StandValues2);
                vArrayList.Add(lastLivedValues);//实际生产温度
                vArrayList.Add(lastLivedValues1);
                vArrayList.Add(lastLivedValues2);
            }

            if (PictID == "Press")
            {
                vArrayList.Add(StandValues);//标准生产温度
                vArrayList.Add(StandValues1);
                vArrayList.Add(StandValues2);
                vArrayList.Add(StandValues3);
                vArrayList.Add(StandValues4);
                vArrayList.Add(StandValues5);
                vArrayList.Add(StandValues6);
                vArrayList.Add(StandValues7);
                vArrayList.Add(StandValues8);
                vArrayList.Add(StandValues9);
                vArrayList.Add(lastLivedValues);//实际生产温度
                vArrayList.Add(lastLivedValues1);
                vArrayList.Add(lastLivedValues2);
                vArrayList.Add(lastLivedValues3);
                vArrayList.Add(lastLivedValues4);
                vArrayList.Add(lastLivedValues5);
                vArrayList.Add(lastLivedValues6);
                vArrayList.Add(lastLivedValues7);
                vArrayList.Add(lastLivedValues8);
                vArrayList.Add(lastLivedValues9);
            }

            curve2d.pArrayList = vArrayList;
            curve2d.CurveColors = CurveColors;
            //curve2d.RedText = ContentTexts[0];
            //curve2d.GreenText = ContentTexts[1];

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

        private ArrayList Stand_PrepareParm()
        {
            return null;
        }

        private ArrayList Lived_PrepareParm()
        {
            return null;
        }
    }
}

