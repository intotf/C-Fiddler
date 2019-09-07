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
    public class RequestSchool
    {

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        /// <param name="uid"></param>
        public RequestSchool(string uid, string classId, string studentId)
        {
            var userInfo = new User_info(uid);
            this.schoolId = userInfo.schoolid;
            this.userId = userInfo.uid;
            this.adParams = new AdParams(uid);
            this.classId = classId;
            this.studentId = studentId;
        }

        /// <summary>
        /// 请求附属参数
        /// </summary>
        public AdParams adParams { get; set; }

        /// <summary>
        /// 班级id
        /// </summary>
        public string classId { get; set; }
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
        public string schoolId { get; set; }
        /// <summary>
        /// 学校类型
        /// </summary>
        public int schoolType { get; set; } = 2;
        /// <summary>
        /// 学生id
        /// </summary>
        public string studentId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 行政编码
        /// </summary>
        public string zipCode { get; set; } = RequstBase.geo.city.ToString();

    }
}
