using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// CiPinEntity 的摘要说明
/// </summary>
public class CiPinEntity
{
    private List<String> columnsName = new List<string>();

    public List<String> ColumnsName
    {
        get { return columnsName; }
        set { columnsName = value; }
    }
    private List<String> columnsNameCH = new List<string>();

    public List<String> ColumnsNameCH
    {
        get { return columnsNameCH; }
        set { columnsNameCH = value; }
    }
    private List<String> columnsValue = new List<string>();

    public List<String> ColumnsValue
    {
        get { return columnsValue; }
        set { columnsValue = value; }
    }

    private String machineNo;

    public String MachineNo
    {
        get { return machineNo; }
        set { machineNo = value; }
    }
    private String dispachNum;

    public String DispachNum
    {
        get { return dispachNum; }
        set { dispachNum = value; }
    }

    private String do_Num;

    public String Do_Num
    {
        get { return do_Num; }
        set { do_Num = value; }
    }

    private String productDesc;

    public String ProductDesc
    {
        get { return productDesc; }
        set { productDesc = value; }
    }

    private String addOrUpdate;

    public String AddOrUpdate
    {
        get { return addOrUpdate; }
        set { addOrUpdate = value; }
    }
    

	public CiPinEntity()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
}