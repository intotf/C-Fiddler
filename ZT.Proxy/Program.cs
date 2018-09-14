using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ZT.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.DefaultConnectionLimit = 1024;

            HostFactory.Run(x =>
            {
                x.Service<FiddlerApp>();
                x.RunAsLocalSystem();

                x.SetDescription("ZT.ProxyService");
                x.SetDisplayName("智通代理服务器");
                x.SetServiceName("ZT.ProxyService");
            });
        }
    }
}
