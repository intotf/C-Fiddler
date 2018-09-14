﻿using System;
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
        public string classId { get; set; } = RequstBase.classId;
        /// <summary>
        /// 学校id
        /// </summary>
        public string schoolId { get; set; } = RequstBase.user_Info.schoolid;
        /// <summary>
        /// 学生id
        /// </summary>
        public string studentId { get; set; } = RequstBase.studentId;
        /// <summary>
        /// 任务编码
        /// </summary>
        public string taskNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; } = RequstBase.user_Info.uid;

        /// <summary>
        /// 构造消息发送
        /// </summary>
        /// <param name="taskType"></param>
        public RequestTask(TaskType taskType)
        {
            this.actionType = taskType.GetHashCode();
            this.taskNumber = taskType.GetFieldDescription();
        }
    }
}
