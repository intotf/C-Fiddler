using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 亲友聊天请求
    /// </summary>
    public class RequestTask
    {
        /// <summary>
        /// 构造消息发送
        /// </summary>
        /// <param name="taskType"></param>
        public RequestTask(TaskType taskType, string uid, Students student)
        {
            var userInfo = new User_info(uid);
            this.schoolId = userInfo.schoolid;
            this.userId = userInfo.uid;
            this.actionType = taskType.GetHashCode();
            this.taskNumber = taskType.GetFieldDescription();
            this.classId = student.ClassId;
            this.studentId = student.StudentId;
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int actionType { get; set; }
        /// <summary>
        /// App类型
        /// </summary>
        public string appType { get; set; } = "parent";
        /// <summary>
        /// 子类Id
        /// </summary>
        public string childId { get; set; } = "7e2ed4c0da316059c7c9";
        /// <summary>
        /// 分类id
        /// </summary>
        public string classId { get; set; }
        /// <summary>
        /// 学校id
        /// </summary>
        public string schoolId { get; set; }
        /// <summary>
        /// 学生id
        /// </summary>
        public string studentId { get; set; }
        /// <summary>
        /// 任务编码
        /// </summary>
        public string taskNumber { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; }
    }
}
