using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace ZHService
{
    /// <summary>
    /// 任务请求过滤器
    /// </summary>
    public class RequestFilterAttribute : ApiActionFilterAttribute
    {
        /// <summary>
        /// 请求执行前
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task OnBeginRequestAsync(ApiActionContext context)
        {
            var req = await context.RequestMessage.ToStringAsync();
            //Console.WriteLine(req);
            await base.OnBeginRequestAsync(context);
        }

        /// <summary>
        /// 请求执行后
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task OnEndRequestAsync(ApiActionContext context)
        {
            //var rs = await context.ResponseMessage.Content.ReadAsStringAsync();
            await base.OnEndRequestAsync(context);
        }

    }
}
