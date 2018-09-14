using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 获取文章
    /// 请求实体,每请求一次会自动刷新一次
    /// </summary>
    public class RequestInfo : IRequest
    {
        /// <summary>
        /// 提交地址
        /// </summary>
        private static string PostUrl = "http://api.szy.cn/infofeed/userrecommend/v1.1";

        /// <summary>
        /// 默认请求内容
        /// </summary>
        private static AdParams adparams = new AdParams();

        /// <summary>
        /// 请求Body
        /// </summary>
        public AdParams adParams { get; set; } = adparams;
        /// <summary>
        /// 通道标识
        /// </summary>
        public int channelId { get; set; } = 1;
        /// <summary>
        /// 数量
        /// </summary>
        public int count { get; set; } = 15;
        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; } = 1;
        /// <summary>
        /// 设备imei
        /// </summary>
        public string udid { get; set; } = adparams.device_info.imei;
        /// <summary>
        /// 用户Id
        /// </summary>
        public string userId { get; set; } = adparams.user_info.uid;

        /// <summary>
        /// 获取提交Url
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return PostUrl;
        }
    }
}
