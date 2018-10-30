using Fiddler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Model;

namespace ZHService.Proxy
{
    /// <summary>
    /// 王者数据处理器
    /// </summary>
    static class FiddlerProcessor
    {
        /// <summary>
        /// 处理会话
        /// </summary>
        /// <param name="session">会话</param>
        /// <returns></returns>

        public static void OnResponse(Session session)
        {
            session.utilDecodeResponse();
            var url = session.fullUrl;
            if (url.Equals("http://core-ztjy.szy.cn/user/myself", StringComparison.OrdinalIgnoreCase))
            {
                SetResponseByUser(session);
            }
        }

        /// <summary>
        /// 对用户数据进行处理
        /// </summary>
        /// <param name="session"></param>
        public static void SetResponseByUser(Session session)
        {
            var body = session.GetResponseBodyAsString();
            var model = JsonConvert.DeserializeObject<ResultUser>(body);
            UserApi.AddOUpdateUser(new User { Id = model.body.userInfo.uid, NickName = model.body.userInfo.nickname });
        }
    }
}
