using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Entity 的摘要说明
/// </summary>
public class Entity
{
    private List<string> _Name = new List<string>();

    public List<string> Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private List<string> _Value = new List<string>();

    public List<string> Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

    public Entity()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}