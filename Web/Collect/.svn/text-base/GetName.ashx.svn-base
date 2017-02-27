<%@ WebHandler Language="C#" Class="GetName" %>

using System;
using System.Web;

public class GetName : IHttpHandler {
    private string UserId;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        UserId = context.Request.QueryString["UserId"];
        string tempSql = "Select EmployeeName_CN From Employee Where EmployeeID='" + UserId + "'";
        object tempValue = Admin.DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, tempSql, null);
        if (tempValue == null)
        {
            context.Response.Write("查无此人");
            context.Response.End();
        }
        //ResponseWrite(context, "查无此人");
        else 
        {
            context.Response.Write(tempValue.ToString());
            context.Response.End();
        }
       //   ResponseWrite(context,tempValue.ToString());
    }
    private void ResponseWrite(HttpContext context, string Message) 
    {
        context.Response.Write(Message);
        context.Response.End();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}