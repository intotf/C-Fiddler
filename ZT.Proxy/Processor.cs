using Fiddler;
using NetworkSocket;
using NetworkSocket.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Proxy
{
    /// <summary>
    /// 王者数据处理器
    /// </summary>
    static class Processor
    {
        /// <summary>
        /// http和ws监听器
        /// </summary>
        private static readonly TcpListener listener = new TcpListener();

        /// <summary>
        /// 王者数据处理器
        /// </summary>
        static Processor()
        {
            var http = listener.Use<HttpMiddleware>();
            http.MIMECollection.Add(".cer", "application/x-x509-ca-cert");

            listener.Use<WebsocketMiddleware>();
            listener.Start(AppConfig.WsPort);
        }

        /// <summary>
        /// 显式初始化
        /// </summary>
        public static void Init()
        {

        }

        /// <summary>
        /// 关闭监听器
        /// </summary>
        public static void CloseListener()
        {
            //listener.Dispose();
        }

        /// <summary>
        /// 处理会话
        /// </summary>
        /// <param name="session">会话</param>
        /// <returns></returns>

        public static void ProcessSession(Session session)
        {
            session.utilDecodeResponse();
            var url = session.fullUrl;
            if (url.Equals("http://core-ztjy.szy.cn/user/myself", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(session.GetResponseBodyAsString());
            }
            Console.WriteLine(url);


            //if (url.Contains("question/bat/findQuiz") == true)
            //{
            //    SetResponseWithAnswer(session);
            //}
            //else if (url.Contains("question/bat/choose") == true)
            //{
            //    UpdateCorrectOptions(session);
            //}
            //else if (url.Contains("question/bat/fightResult") == true)
            //{
            //    var notifyData = new WsNotifyData<object> { Cmd = WsCmd.GameOver };
            //    WsNotifyByClientIP(notifyData, session.clientIP);
            //}
        }
    }
}
