using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using NetworkSocket;
using NetworkSocket.Http;

namespace ZT.Proxy
{

    /// <summary>
    /// 初始者抽象类
    /// </summary>
    public abstract class ProcessorAbstract : IProcessor
    {
        /// <summary>
        /// http和ws监听器
        /// </summary>
        private static readonly TcpListener listener = new TcpListener();

        /// <summary>
        /// Tcp 监听
        /// </summary>
        public ProcessorAbstract()
        {
            var http = listener.Use<HttpMiddleware>();
            http.MIMECollection.Add(".cer", "application/x-x509-ca-cert");
            listener.Use<WebsocketMiddleware>();
            listener.Start(AppConfig.WsPort);
        }


        /// <summary>
        /// 关闭监听器
        /// </summary>
        public void CloseListener()
        {
            listener.Dispose();
        }


        /// <summary>
        /// 由基类实现消息处理
        /// </summary>
        public abstract void ProcessSession(Session session);
    }
}
