using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Admin.SQLServerDAL;
using Newtonsoft.Json;

public partial class zhEcharts_CiPin : System.Web.UI.Page
{
    private static string[] temp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Request["temp"]!=null)
            {
                temp = Request["temp"].Split(',');
            }
            
            if(Request["value1"] != null)
            {
                string[] nameStr = {};
                string sql = "select IMReasonName from BadReason";
                DataSet dataSet = SqlHelper.ReturnDataSet(sql);
                Entity entity = new Entity();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        entity.Name.Add(row.ItemArray[i].ToString());
                    }
                }
                for (int i = 3; i < 16; i++)
                {
                    entity.Value.Add(temp[i]);
                }
                string json = JsonConvert.SerializeObject(entity);
                Response.Clear();
                Response.ContentType = "text/plain";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Write(json);
                Response.End();
            }
        }
    }
}