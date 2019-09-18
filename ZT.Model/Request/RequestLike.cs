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
    public class RequestLike
    {
        /// <summary>
        /// 初始化用户信息
        /// </summary>
        /// <param name="uid"></param>
        public RequestLike(string uid, string childId)
        {
            this.userId = uid;
            this.childId = childId;
        }

        /// <summary>
        /// 孩子Id
        /// </summary>
        public string childId { get; set; }
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
        public string userId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string userName { get; set; } = "涛涛";
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string userPic { get; set; } = "http://zthome.ztjystore.cn/FlcBMnJMq_trKqWe3THVdgyYGR-W";
        /// <summary>
        /// 微信名称
        /// </summary>
        public string wxName { get; set; } = "";
    }
}
