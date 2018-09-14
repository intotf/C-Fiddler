using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 点赞提交对象
    /// </summary>
    public class RequestLike : IRequest
    {
        /// <summary>
        /// 提交url
        /// </summary>
        private static string PostUrl = "http://api.szy.cn/commentserver/content/like/v1";

        /// <summary>
        /// 子类Id
        /// </summary>
        public string childId { get; set; } = "7e2ed4c0da316059c7c9";
        /// <summary>
        /// 内容id
        /// </summary>
        public string contentId { get; set; }
        /// <summary>
        /// 内容内型
        /// </summary>
        public string contentType { get; set; } = "8";
        /// <summary>
        /// 内容发布者Id
        /// </summary>
        public string contentUserId { get; set; }
        /// <summary>
        /// 点赞
        /// </summary>
        public int like { get; set; } = 1;
        /// <summary>
        /// 发布者学生Id
        /// </summary>
        public string studentId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; } = RequstBase.user_Info.uid;
        /// <summary>
        /// 昵称
        /// </summary>
        public string userName { get; set; } = "涛涛爸爸";
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string userPic { get; set; } = "http://zthome.ztjystore.cn/FlcBMnJMq_trKqWe3THVdgyYGR-W";
        /// <summary>
        /// 微信名称
        /// </summary>
        public string wxName { get; set; }

        /// <summary>
        /// 获取提交地址
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return PostUrl;
        }
    }
}
