using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using ZT.Model;

namespace ZTHome.Work
{
    /// <summary>
    /// 校园新鲜事点赞
    /// </summary>
    [HttpHost("http://api.szy.cn")]
    [RequestFilter]
    public interface ISchoolLike : IHttpApi
    {
        /// <summary>
        /// 刷新新鲜事
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("/schoolfeed/downrefresh/v2.0")]
        ITask<ResultRest<ResultSchool>> GetSchoolListByAsync([JsonContent]RequestSchool data);

        /// <summary>
        /// 给每个新鲜事点赞
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("/commentserver/content/like/v1")]
        ITask<ResultRest<ResultLike>> DoSchoolsLikeByAsync([JsonContent]RequestLike data);

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("/infofeed/userrecommend/v1.1")]
        ITask<ResultRest<ResultInfo>> GetInfoListByAsync([JsonContent]RequestInfo data);


        /// <summary>
        /// 完成亲友聊天及阅读文章
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("/score/task/sendTask/v1.0")]
        ITask<ResultRest<ResultTask>> DoTaskByAsync([JsonContent]RequestTask data);
    }
}
