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
using Fiddler;
using System.Globalization;
using ZHService.Proxy;

namespace ZHService
{
    public class AppService : ServiceControl
    {
        /// <summary>
        /// 服务端口
        /// </summary>
        private readonly int Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

        /// <summary>
        /// 代理服务端口
        /// </summary>
        private readonly int ProxyPort = int.Parse(ConfigurationManager.AppSettings["ProxyPort"]);

        /// <summary>
        /// 所有会话的集合
        /// </summary>
        public static readonly SessionCollection AllSessions = new SessionCollection();

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(HostControl hostControl)
        {
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            var httpMiddleware = Listener.WsListener.Use<HttpMiddleware>();
            Listener.WsListener.Use<JsonWebSocketMiddleware>();
            httpMiddleware.MIMECollection.Add(".woff", ".woff");
            httpMiddleware.MIMECollection.Add(".woff2", ".woff2");
            httpMiddleware.MIMECollection.Add(".ttf", ".ttf");

            var ower = TcpSnapshot.Snapshot().FirstOrDefault(item => item.Port == this.Port);
            if (ower != null)
            {
                ower.Kill();
            }

            Listener.WsListener.Start(this.Port);


            #region 代理服务
            // 请求前
            FiddlerApplication.BeforeRequest += (session) =>
            {
                //Console.WriteLine($"{session.clientIP}-> {session.fullUrl}");
                session.bBufferResponse = true;

                // 首页重定向
                var uri = new Uri(session.fullUrl);
                if (uri.Port == ProxyPort || uri.Port == Port)
                {
                    session.host = $"{uri.Host}:{ Port }";
                    AllSessions.Add(session);
                }
                //Console.WriteLine(session.url);
            };

            // 收到服务端的回复
            FiddlerApplication.BeforeResponse += (session) =>
            {
                try
                {
                    FiddlerProcessor.OnResponse(session);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };

            // 配置代理服务器
            Cert.SetRootCertificate();
            CONFIG.IgnoreServerCertErrors = true;

            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            FiddlerApplication.Startup(ProxyPort, FiddlerCoreStartupFlags.AllowRemoteClients | FiddlerCoreStartupFlags.DecryptSSL);
            #endregion
            return true;
        }

        /// <summary>
        /// 停目服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(HostControl hostControl)
        {
            Listener.WsListener.Dispose();
            FiddlerApplication.Shutdown();
            return true;
        }
    }
}
