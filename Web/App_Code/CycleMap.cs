using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// CycleMap 的摘要说明
/// </summary>
public class CycleMap
{
    private int _IMG_WIDTH;

    public int IMG_WIDTH
    {
        get { return _IMG_WIDTH; }
        set { _IMG_WIDTH = value; }
    }
    private int _IMG_HEIGHT;//560

    public int IMG_HEIGHT
    {
        get { return _IMG_HEIGHT; }
        set { _IMG_HEIGHT = value; }
    }
    private string _bDate;//2016-10-14 08:22

    public string bDate
    {
        get { return _bDate; }
        set { _bDate = value; }
    }
    private string _eDate;//2016-10-14 08:22

    public string eDate
    {
        get { return _eDate; }
        set { _eDate = value; }
    }
    private string _MachineNo;//""机器编号

    public string MachineNo
    {
        get { return _MachineNo; }
        set { _MachineNo = value; }
    }
    private string _MouldNo;//""模具编号

    public string MouldNo
    {
        get { return _MouldNo; }
        set { _MouldNo = value; }
    }
    private string _ProductNo;//""产品编号

    public string ProductNo
    {
        get { return _ProductNo; }
        set { _ProductNo = value; }
    }
    private string _ActionNum;//1

    public string ActionNum
    {
        get { return _ActionNum; }
        set { _ActionNum = value; }
    }
    private string _DispatchOrder;//""派工单号

    public string DispatchOrder
    {
        get { return _DispatchOrder; }
        set { _DispatchOrder = value; }
    }
    private string _CycleTime;//真实周期时间

    public string CycleTime
    {
        get { return _CycleTime; }
        set { _CycleTime = value; }
    }

    private int _MaxCycleTime;

    public int MaxCycleTime//最大周期时间
    {
        get { return _MaxCycleTime; }
        set { _MaxCycleTime = value; }
    }
    private int _MinCycleTime;

    public int MinCycleTime//最小周期时间
    {
        get { return _MinCycleTime; }
        set { _MinCycleTime = value; }
    }

    private int _StandCycleTime;

    public int StandCycleTime//标准周期时间
    {
        get { return _StandCycleTime; }
        set { _StandCycleTime = value; }
    }
    private List<int> _XData = new List<int>();//x轴值

    public List<int> XData
    {
        get { return _XData; }
        set { _XData = value; }
    }
    private List<int> _YData = new List<int>();//Y轴值

    public List<int> YData
    {
        get { return _YData; }
        set { _YData = value; }
    }

    private List<int> _YData1 = new List<int>();

    public List<int> YData1
    {
        get { return _YData1; }
        set { _YData1 = value; }
    }
    private string _PageNum;//当前页数

    public string PageNum
    {
        get { return _PageNum; }
        set { _PageNum = value; }
    }
    private string onoffButton;//上下页开关

    public string OnoffButton
    {
        get { return onoffButton; }
        set { onoffButton = value; }
    }
    private int _TotalPageNum;

    public int TotalPageNum//总页数
    {
        get { return _TotalPageNum; }
        set { _TotalPageNum = value; }
    }

    private List<int> _StandShotTemp = new List<int>();//温度标准

    public List<int> StandShotTemp
    {
        get { return _StandShotTemp; }
        set { _StandShotTemp = value; }
    }
    private int _TotalNum;//总共啤数

    public int TotalNum
    {
        get { return _TotalNum; }
        set { _TotalNum = value; }
    }
    

	public CycleMap()
	{
        
	}
}