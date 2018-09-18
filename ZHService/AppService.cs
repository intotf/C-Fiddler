using NetworkSocket;
using NetworkSocket.Http;
using NetworkSocket.Util;
using NetworkSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using System.Configuration;

namespace ZHService
{
    public class AppService : ServiceControl
    {
        /// <summary>
        /// 监听服务
        /// </summary>
        public static TcpListener listener = new TcpListener();

        /// <summary>
        /// 服务端口
        /// </summary>
        private readonly int Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(HostControl hostControl)
        {
            var httpMiddleware = listener.Use<HttpMiddleware>();
            listener.Use<JsonWebSocketMiddleware>();
            httpMiddleware.MIMECollection.Add(".woff", ".woff");
            httpMiddleware.MIMECollection.Add(".woff2", ".woff2");
            httpMiddleware.MIMECollection.Add(".ttf", ".ttf");

            var ower = TcpSnapshot.Snapshot().FirstOrDefault(item => item.Port == this.Port);
            if (ower != null)
            {
                ower.Kill();
            }
            listener.Start(this.Port);
            return true;
        }

        /// <summary>
        /// 停目服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(HostControl hostControl)
        {
            listener.Dispose();
            return true;
        }
    }
}
