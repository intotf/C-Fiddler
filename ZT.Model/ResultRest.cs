using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 点赞消息回复
    /// </summary>
    public class ResultRest<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息提示
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        public T body { get; set; }
    }
}
