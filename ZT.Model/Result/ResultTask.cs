using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 亲友聊天响应Body
    /// </summary>
    public class ResultTask
    {
        /// <summary>
        /// 消息体
        /// </summary>
        public Tasks task { get; set; }
    }

    /// <summary>
    /// 任务提示信息
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// 消息id
        /// </summary>
        ///public int id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string iconUrl { get; set; }
        /// <summary>
        /// 描叙
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        ///public int taskType { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        public string taskNumber { get; set; }
        ///// <summary>
        ///// 任务数量
        ///// </summary>
        //public int taskCount { get; set; }
        ///// <summary>
        ///// 是否Tip
        ///// </summary>
        //public int showTip { get; set; }
        ///// <summary>
        ///// 完成任务数
        ///// </summary>
        //public int completeTaskCount { get; set; }
        ///// <summary>
        ///// 状态
        ///// </summary>
        //public int status { get; set; }
        ///// <summary>
        ///// 连接任务数
        ///// </summary>
        //public int continuityTaskCount { get; set; }
        /// <summary>
        /// 积分奖励
        /// </summary>
        public Reward reward { get; set; }
    }

    /// <summary>
    /// 积分奖励
    /// </summary>
    public class Reward
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 奖励提示
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 奖励描叙
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string image { get; set; }
        ///// <summary>
        ///// 类型
        ///// </summary>
        //public int type { get; set; }
        ///// <summary>
        ///// 奖励类型
        ///// </summary>
        //public int rewardType { get; set; }
        /// <summary>
        /// 奖励积分
        /// </summary>
        public string rewardData { get; set; }
        /// <summary>
        /// 是否生效
        /// </summary>
        //public int isTaken { get; set; }
    }
}
