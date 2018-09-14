using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace ZTHome
{
    public class RequestFilterAttribute : ApiActionFilterAttribute
    {
        public override async Task OnBeginRequestAsync(ApiActionContext context)
        {
            var req = await context.RequestMessage.ToStringAsync();
            //Console.WriteLine(req);
            await base.OnBeginRequestAsync(context);
        }

        public override async Task OnEndRequestAsync(ApiActionContext context)
        {
            //var rs = await context.ResponseMessage.Content.ReadAsStringAsync();
            await base.OnEndRequestAsync(context);
        }

    }
}
