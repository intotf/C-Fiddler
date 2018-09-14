using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 提交请求接口
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// 获取提交 Url
        /// </summary>
        /// <returns></returns>
        string GetUrl();
    }
}
