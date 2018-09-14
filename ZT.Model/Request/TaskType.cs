using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZT.Model
{
    /// <summary>
    /// 发送消息类型
    /// </summary>
    public enum TaskType
    {
        /// <summary>
        /// 给孩子送爱心
        /// 可以任意发送
        /// </summary>
        [Display(Name = "给孩子送爱心 TaskNumber", Description = "jzrw000024")]
        Love = 9,

        /// <summary>
        /// 亲友聊天
        /// </summary>
        [Display(Name = "新友聊天 TaskNumber", Description = "jzrw000025")]
        Send = 10,

        /// <summary>
        /// 文章读完
        /// </summary>
        [Display(Name = "文章读完 TaskNumber", Description = "jzrw000026")]
        Info = 11,

        /// <summary>
        /// 分享文章或课程
        /// </summary>
        [Display(Name = "听视频 TaskNumber", Description = "jzrw000027")]
        Share = 12,

        /// <summary>
        /// 收听课程
        /// </summary>
        [Display(Name = "听视频 TaskNumber", Description = "jzrw000028")]
        Listen = 13,
    }
}
