using NetworkSocket.Http;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZT.Proxy
{


    public class HomeController : HttpController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Route("/")]
        public ActionResult Index()
        {
            var clientsIp = from session in FiddlerApp.AllSessions
                            let ip = Regex.Match(session.clientIP, @"\d+\.\d+\.\d+\.\d+").Value
                            where string.IsNullOrEmpty(ip) == false
                            select ip;

            var proxyHost = this.GetProxyHost();
            var model = new IndexModel
            {
                ProxyIpEndpoint = $"{proxyHost}:{AppConfig.ProxyPort}",
                WsIpEndpoint = $"{proxyHost}:{AppConfig.WsPort}",
                ClientsIp = clientsIp.Distinct().ToArray()
            };

            return this.View("Index", model);
        }

        /// <summary>
        /// 动态生成pac
        /// 直接填入该代理地址就可以访问 Https 站点
        /// </summary>
        /// <returns></returns>
        [Route("/Proxy.PAC")]
        public ActionResult Proxy_PAC()
        {
            var buidler = new StringBuilder();
            buidler.AppendLine("function FindProxyForURL(url, host){");
            buidler.AppendLine($"    var proxy = 'PROXY {this.Request.Url.Host}:{AppConfig.ProxyPort}';");
            foreach (var host in AppConfig.ProxyHosts)
            {
                buidler.AppendLine($"    if (dnsDomainIs(host, '{host}')) return proxy;");
            }
            buidler.AppendLine("    return 'DIRECT';");
            buidler.AppendLine("}");

            var pacString = buidler.ToString();
            this.Response.ContentType = "application/x-ns-proxy-autoconfig";
            return Content(pacString);
        }



        /// <summary>
        /// 返回视图
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private ActionResult View<T>(string name, T model)
        {
            var controller = this.CurrentContext.Action.ControllerName;
            var cshtml = System.IO.File.ReadAllText($"Http\\View\\{controller}\\{name}.cshtml", System.Text.Encoding.UTF8);
            var html = Engine.Razor.RunCompile(cshtml, name, null, model);
            //var html = Razor.Parse(cshtml, model);
            return Content(html);
        }

        /// <summary>
        /// 返回代理服务器绝对域名
        /// </summary>
        /// <returns></returns>
        private string GetProxyHost()
        {
            var ipArray = from i in NetworkInterface.GetAllNetworkInterfaces()
                          where i.OperationalStatus == OperationalStatus.Up
                          let address = i.GetIPProperties().UnicastAddresses
                          select address.ToArray();

            var networkIps = from ip in ipArray.SelectMany(item => item)
                             where ip.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred
                             where ip.PrefixOrigin == PrefixOrigin.Dhcp || ip.PrefixOrigin == PrefixOrigin.Manual
                             where ip.SuffixOrigin == SuffixOrigin.OriginDhcp || ip.SuffixOrigin == SuffixOrigin.Manual
                             select ip;

            var networkIp = networkIps.FirstOrDefault();
            return networkIp == null ? this.Request.Url.Host : networkIp.Address.ToString();
        }


        /// <summary>
        /// ws客户端页面
        /// </summary>
        /// <returns></returns>
        [Route("/client")]
        public ActionResult Client(string ip)
        {
            var model = new ClientModel
            {
                IpAddress = ip,
                WsServer = $"ws://{this.Request.Url.Host}:{AppConfig.WsPort}"
            };

            return this.View("Client", model);
        }
    }
}
