<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Admin.BLL.Monitor_BLL" %>
<%@ Import Namespace="System.Net" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        //在应用程序启动时运行的代码
        System.Timers.Timer myTimer = new System.Timers.Timer(30000); // 
        myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent); //执行需要操作的代码，OnTimedEvent是要执行的方法名称
        myTimer.Interval = 30000;
        myTimer.Enabled = true;

    }

    void Application_End(object sender, EventArgs e)
    {
        //在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e)
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

    private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
   {

        //需要的操作写在这个方法中
        //报警监视
        MonitorMachine_BLL.execStoredProcedure("CallInfo");
        //DataTable dtSMS = MonitorMachine_BLL.execSMSDetail();
        //if (dtSMS.Columns.Count!=0)
        //{
        //    foreach (DataRow dr in dtSMS.Rows)
        //    {
        //        string status = send(dr["CellNumber"].ToString(), dr["SMSContent"].ToString());
        //        string[] ss = status.Split('&');
        //        int floa = Convert.ToInt32(ss[1].ToString().Split('=')[1].ToString());
        //        if (floa == 100)
        //        {
        //           int i= MonitorMachine_BLL.UpdateSMSDetailStatus(Convert.ToInt32(dr["ID"].ToString()));
        //        }
        //    }
        //}

    }

    protected string send(string mobile, string strContent)
    {
        string sendurl = "http://api.sms.cn/mt/";
        StringBuilder sbTemp = new StringBuilder();
        string uid = ConfigurationManager.AppSettings["SMSUser"].ToString();
        string pwd = ConfigurationManager.AppSettings["SMSPwd"].ToString();
        string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd + uid, "MD5"); //密码进行MD5加密
        //POST 传值
        sbTemp.Append("uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobile + "&content=" + strContent);
        byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());
        String postReturn = doPostRequest(sendurl, bTemp);
        //Response.Write("Post response is: " + postReturn);  //测试返回结果
        return postReturn;

    }
    //POST方式发送得结果
    private static String doPostRequest(string url, byte[] bData)
    {
        System.Net.HttpWebRequest hwRequest;
        System.Net.HttpWebResponse hwResponse;

        string strResult = string.Empty;
        try
        {
            hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            hwRequest.Timeout = 5000;
            hwRequest.Method = "POST";
            hwRequest.ContentType = "application/x-www-form-urlencoded";
            hwRequest.ContentLength = bData.Length;

            System.IO.Stream smWrite = hwRequest.GetRequestStream();
            smWrite.Write(bData, 0, bData.Length);
            smWrite.Close();
        }
        catch (System.Exception err)
        {
            //WriteErrLog(err.ToString());
            return strResult;
        }

        //get response
        try
        {
            hwResponse = (HttpWebResponse)hwRequest.GetResponse();
            StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
            strResult = srReader.ReadToEnd();
            srReader.Close();
            hwResponse.Close();
        }
        catch (System.Exception err)
        {
            //WriteErrLog(err.ToString());
        }
        return strResult;
    }


       
</script>

