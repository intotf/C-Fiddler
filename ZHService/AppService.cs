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
        private TcpListener listener = new TcpListener();

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
            this.listener.Use<HttpMiddleware>();
            this.listener.Use<JsonWebSocketMiddleware>();

            var ower = TcpSnapshot.Snapshot().FirstOrDefault(item => item.Port == this.Port);
            if (ower != null)
            {
                ower.Kill();
            }
            this.listener.Start(this.Port);
            return true;
        }

        /// <summary>
        /// 停目服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(HostControl hostControl)
        {
            this.listener.Dispose();
            return true;
        }
    }
}
