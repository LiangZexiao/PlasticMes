using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
/// <summary>
///SendMessage 的摘要说明
/// </summary>
/// 
namespace Admin.DBUtility
{
    public class SendMessage
    {
        public SendMessage()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="mobiles">发送给谁的手机号码字符串，号码间用,隔开</param>
        
        public void Send(string message, string mobiles)
        {
            string[] t_content = MsgFormat(message);
            string[] numbers = MobiFormat(mobiles);
            MessageSend(t_content, numbers);

        }
        public void MessageSend(string[] t_content, string[] numbers)
        {
            string msg = "";
            string unsucNumber = ""; // 发送不成功的手机号码
            int sucCount = 0;     // 成功发送的短信数量
            int unsucCount = 0;   // 不成功发送的短信数量

            // 调用 COM 组件发送手机短信
            EMPPCOMLib.EmppObjClass sms = new EMPPCOMLib.EmppObjClass();

            GetMsgService(sms);

            // 发送手机短信

            foreach (string number in numbers)
            {
                // 将短信内容按每70个字符截成一条短信来发送
                if (sms.Status == 2)
                {
                    for (int i = 0; i < t_content.Length; i++)
                    {
                  // sms.SendSmsA("15889304990", "123456", out msg);
                    sms.SendSmsA(number, t_content[i], out msg);
                    }

                    if (msg == "-1")
                    {
                        unsucNumber = unsucNumber + number + ",";
                        unsucCount += 1;
                    }
                    else
                    {
                        sucCount += 1;
                        //保存到数据库

                    }
                }
            }

            CloseMsgService(sms);
        }

        /// <summary>
        /// 讯息发送服务初始化
        /// </summary>
        public void GetMsgService(EMPPCOMLib.EmppObjClass sms)
        {
            // 获取短信网关的连接字符串，然后将字符串中各参数的值提取出来
            string conStr = ConfigurationManager.AppSettings["SmsConn"];
            // 提取网关 IP
            int idx1 = conStr.IndexOf("=");
            int idx2 = conStr.IndexOf(";");
            string server = conStr.Substring(idx1 + 1, idx2 - idx1 - 1);
            conStr = conStr.Substring(idx2 + 1, conStr.Length - idx2 - 1);
            // 提取网关端口
            idx1 = conStr.IndexOf("=");
            idx2 = conStr.IndexOf(";");
            short port = short.Parse(conStr.Substring(idx1 + 1, idx2 - idx1 - 1));
            conStr = conStr.Substring(idx2 + 1, conStr.Length - idx2 - 1);
            // 提取用户 Id
            idx1 = conStr.IndexOf("=");
            idx2 = conStr.IndexOf(";");
            string userId = conStr.Substring(idx1 + 1, idx2 - idx1 - 1);
            conStr = conStr.Substring(idx2 + 1, conStr.Length - idx2 - 1);
            // 提取密码
            idx1 = conStr.IndexOf("=");
            string password = conStr.Substring(idx1 + 1, conStr.Length - idx1 - 1);
            // 调用 COM 组件发送手机短信
            if (sms.Status == 0)  sms.Connect(server, port);
            if (sms.Status == 1) sms.Login(userId, password);

        }
        /// <summary>
        /// 讯息发送服务关闭
        /// </summary>
        public void CloseMsgService(EMPPCOMLib.EmppObjClass sms)
        {
            if (sms.Status != 0) sms.Quit();
        }
        /// <summary>
        /// 将接收讯息的手机号码，格式为字符串数组
        /// </summary>
        public string[] MobiFormat(string mobi)
        {
            string[] numbers = null;
            numbers = mobi.Trim().Split(",".ToCharArray());
            return numbers;
        }
        /// <summary>
        /// 按每段70个字符，分割字符串分字符串数组
        /// </summary>
        public string[] MsgFormat(string msg)
        {
            string content = msg.Trim();
            // 将短信内容按每一定字符数分段发送，先将内容放到字符串数组
            int sn = 70; // 短信内容分段发送每段的字符数
            int len = content.Length;
            int n = len / sn;
            if (n == 0)
            {
                n = 1;
            }
            else
            {
                if ((len % sn) != 0)
                    n++;
            }

            string[] t_content = new string[n]; // 存放短信内容的字符串数组

            for (int i = 0; i < n; i++)
            {
                if (len > sn)
                {
                    t_content[i] = content.Substring(0, sn);
                    content = content.Substring(70, len - sn);
                    len = content.Length;
                }
                else
                {
                    t_content[i] = content;
                }
            }
            return t_content;
        }
    }
}