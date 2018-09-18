using System;
using Topshelf;

namespace ZHService
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                Console.SetOut(Debugger.Out);
                x.Service<AppService>();
                x.SetDisplayName("ZTService");
                x.SetServiceName("ZTService");
                x.SetDescription("掌通家园服务");
            });
        }
    }
}
