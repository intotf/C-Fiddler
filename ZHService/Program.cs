using System;
using Topshelf;
using WebApiClient;

namespace ZHService
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            HttpApi.Register<ISchoolsTask>();
            HostFactory.Run(x =>
            {
                //Console.SetOut(Debugger.Out);
                x.Service<AppService>();
                x.SetDisplayName("ZTService");
                x.SetServiceName("ZTService");
                x.SetDescription("掌通家园服务");
            });
        }
    }
}
