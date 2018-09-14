using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 刷新消息新鲜事
    /// </summary>
    public class RequestSchool : IRequest
    {
        /// <summary>
        /// 提交Url
        /// </summary>
        private static string PostUrl = "http://api.szy.cn/schoolfeed/downrefresh/v2.0";

        /// <summary>
        /// 请求附属参数
        /// </summary>
        public AdParams adParams { get; set; } = new AdParams();
        /// <summary>
        /// 班级id
        /// </summary>
        public string classId { get; set; } = RequstBase.classId;
        /// <summary>
        /// 提要Id
        /// </summary>
        public int feedId { get; set; } = 0;
        /// <summary>
        /// 行业类型
        /// </summary>
        public string industryType { get; set; } = "A";
        /// <summary>
        /// 模块类型
        /// </summary>
        public int moduleType { get; set; } = 2;
        /// <summary>
        /// 学校id
        /// </summary>
        public string schoolId { get; set; } = RequstBase.user_Info.schoolid;
        /// <summary>
        /// 学校类型
        /// </summary>
        public int schoolType { get; set; } = 2;
        /// <summary>
        /// 学生id
        /// </summary>
        public string studentId { get; set; } = RequstBase.studentId;
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; } = RequstBase.user_Info.uid;
        /// <summary>
        /// 行政编码
        /// </summary>
        public string zipCode { get; set; } = RequstBase.geo.city.ToString();

        /// <summary>
        /// 获取提交 Url
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return PostUrl;
        }
    }
}
