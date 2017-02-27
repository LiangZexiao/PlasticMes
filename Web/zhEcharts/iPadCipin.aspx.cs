using Admin.DBUtility;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class easyUI_iPad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["name"] != null && Request["value"] != null)
        {
            CiPinEntity entity = new CiPinEntity();
            DataSet dataSet = new DataSet();
            string entityJson = "fail";
            try
            {         
            if (Request["name"].Equals("DispatchNo"))
            {
                dataSet = SqlHelper.ReturnDataSet("select MachineNo from DispatchOrder where DO_No='" + Request["value"]+"'");//查询对应的机器编号
                if (dataSet != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.MachineNo = (row.ItemArray[i]).ToString();//得到机器编号
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("Select name from syscolumns where id=object_id('QCAdjust')");//查询次品记录的列名
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.ColumnsName.Add((row.ItemArray[i]).ToString());//得到字段名
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("select IMReasonName from BadReason");//查询次品记录的中文名
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.ColumnsNameCH.Add((row.ItemArray[i]).ToString());//得到中文名
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("Select DispatchNum,Do_Num,ProductDesc from DispatchOrder where MachineNo='" + entity.MachineNo + "'");//根据机器编号查询派单数量、完成数量、产品名称
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.DispachNum = row.ItemArray[0].ToString();
                            entity.Do_Num = row.ItemArray[1].ToString();
                            entity.ProductDesc = row.ItemArray[2].ToString();
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("select * from QCAdjust where " + Request["name"] + "='" + Request["value"] + "'");//查询对应次品记录数据
                    if (dataSet != null)
                    {
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            for (int i = 0; i < row.ItemArray.Length; i++)
                            {
                                entity.ColumnsValue.Add((row.ItemArray[i]).ToString());//得到数据
                            }
                        }
                        
                        entity.AddOrUpdate = "update";
                        entityJson = JsonConvert.SerializeObject(entity);//把实例转为json字符串
                    }
                    else
                    {
                        entity.AddOrUpdate = "add";
                        entityJson = JsonConvert.SerializeObject(entity);//把实例转为json字符串
                    }
                }
                else
                {
                    entityJson = "fail";//输入错误！
                }
                
            }
            else if (Request["name"].Equals("MachineNo"))
            {

                dataSet = SqlHelper.ReturnDataSet("select DO_No from DispatchOrder where " + Request["name"] + "='" + Request["value"]+"'");//查询对应机器号的派工单号
                String dispatchNo = "";
                entity.MachineNo = Request["value"];
                if (dataSet != null)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            dispatchNo = (row.ItemArray[i]).ToString();//得到派工单号
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("Select name from syscolumns where id=object_id('QCAdjust')");//查询次品记录的列名
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.ColumnsName.Add((row.ItemArray[i]).ToString());//得到字段名
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("select IMReasonName from BadReason");//查询次品记录的中文名
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.ColumnsNameCH.Add((row.ItemArray[i]).ToString());//得到中文名
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("Select DispatchNum,Do_Num,ProductDesc from DispatchOrder where MachineNo='" + entity.MachineNo + "'");//根据机器编号查询派单数量、完成数量、产品名称
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.DispachNum = row.ItemArray[0].ToString();
                            entity.Do_Num = row.ItemArray[1].ToString();
                            entity.ProductDesc = row.ItemArray[2].ToString();
                        }
                    }
                    dataSet = SqlHelper.ReturnDataSet("select * from QCAdjust where DispatchNo='" + dispatchNo + "'");//查询对应次品记录数据
                    if (dataSet != null)
                    {
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            for (int i = 0; i < row.ItemArray.Length; i++)
                            {
                                entity.ColumnsValue.Add((row.ItemArray[i]).ToString());//得到数据
                            }
                        }
                        
                        entity.AddOrUpdate = "update";
                        entityJson = JsonConvert.SerializeObject(entity);//把实例转为json字符串
                    }
                    else
                    {
                        entity.AddOrUpdate = "add";
                        entityJson = JsonConvert.SerializeObject(entity);//把实例转为json字符串
                    }
                }
                else
                {
                    entityJson = "fail";//输入错误！
                }         
            }
            
            }
            catch (Exception ex)
            {
                entityJson = "fail";//输入错误！
            }
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(entityJson);
            Response.End();
                                               
        }
        //提交任务
        if (Request["searchValue"] != "" && Request["searchValue"] != null)
        {

            CiPinEntity entity = new CiPinEntity();
            DataSet dataSet = new DataSet();
            string result = "";
            string sql = "";
                try
                {
                    dataSet = SqlHelper.ReturnDataSet("Select name from syscolumns where id=object_id('QCAdjust')");//查询次品记录的列名
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            entity.ColumnsName.Add((row.ItemArray[i]).ToString());//得到字段名
                        }
                    }
                    //string conn = "Data Source=172.16.1.201;Initial Catalog=Plastic;User ID=sa;Password=admin@2016";

                    if (Request["searchName"].Equals("DispatchNo"))
                    {
                        if (Request["addOrUpdate"].Equals("add"))
                        {
                            sql = "insert into QCAdjust(DispatchNo,CardId,";
                            for (int i = 3; i < entity.ColumnsName.Count - 2; i++)
                            {
                                sql += entity.ColumnsName[i];
                                if (i < entity.ColumnsName.Count - 3)
                                {
                                    sql += ",";
                                }
                            }
                            sql += ") values('" + Request["searchValue"] + "','abc',";
                            for (int i = 3; i < entity.ColumnsName.Count - 2; i++)
                            {
                                if (i == entity.ColumnsName.Count - 3)
                                {
                                    sql += "'"+DateTime.Parse(Request["time"].ToString())+"'";
                                }
                                else
                                {
                                    sql += int.Parse(Request[entity.ColumnsName[i]]) + "";
                                }
                                
                                if (i < entity.ColumnsName.Count - 3)
                                {
                                    sql += ",";
                                }
                            }
                            sql += ")";
                        }
                        else if (Request["addOrUpdate"].Equals("update"))
                        {
                            sql = "update QCAdjust set ";
                            for (int i = 3; i < entity.ColumnsName.Count - 3; i++)
                            {
                                sql += entity.ColumnsName[i] + "=" + int.Parse(Request[entity.ColumnsName[i]]);
                                if (i < entity.ColumnsName.Count - 4)
                                {
                                    sql += ",";
                                }
                            }
                            sql += " where " + Request["searchName"] + "='" + Request["searchValue"] + "'";
                        }
                        
                        int flag = SqlHelper.ExecuteNonQuery(sql);
                        if (flag > 0)
                        {
                            if (Request["addOrUpdate"].Equals("add"))
                            {
                                result = "add success";
                            }
                            else if (Request["addOrUpdate"].Equals("update"))
                            {
                                result = "update success";
                            }
                            
                        }
                        else
                        {
                            result = "fail";
                        }
                        
                    }
                    else if (Request["searchName"].Equals("MachineNo"))
                    {

                        dataSet = SqlHelper.ReturnDataSet("select DO_NO from DispatchOrder where " + Request["searchName"] + "='" + Request["searchValue"] + "'");//查询对应机器号的派工单号
                        String dispatchNo = "";
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            for (int i = 0; i < row.ItemArray.Length; i++)
                            {
                                dispatchNo = (row.ItemArray[i]).ToString();//得到派工单号
                            }
                        }
                        sql = "update QCAdjust set ";
                        for (int i = 3; i < entity.ColumnsName.Count-3; i++)
                        {
                            sql += entity.ColumnsName[i] + "=" + int.Parse(Request[entity.ColumnsName[i]]);
                            if (i < entity.ColumnsName.Count - 4)
                            {
                                sql += ",";
                            }
                        }
                        sql += " where DispatchNo='" + dispatchNo + "'";
                        int flag = SqlHelper.ExecuteNonQuery(sql);

                        if (flag != 0)
                        {
                            result = "success";
                        }
                        else
                        {
                            result = "fail";
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = "fail";
                    string ErrMsg = ex.Message.ToString();
                }
                Response.Clear();
                Response.ContentType = "text/plain";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Write(result);
                Response.End();
            }
        
    }
}