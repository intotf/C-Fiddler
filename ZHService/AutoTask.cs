using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using ZT.Model;

namespace ZHService
{
    /// <summary>
    /// 自动任务
    /// </summary>
    public static class AutoTask
    {
        /// <summary>
        /// 根据Id 自动完成任务
        /// </summary>
        /// <param name="uid"></param>
        public static async Task Run(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                return;
            }
            var user = UserApi.Users.Where(item => item.Id == uid).FirstOrDefault();

            var students = Students.GetAllStudents();
            foreach (var student in students)
            {
                await GetSchoolListByAsycn(user, student);
                await DoTaskAsync(user, student);
            }
            Console.WriteLine("执行完成,请选择下一个要执行的用户.");
        }


        /// <summary>
        /// 一次自动全刷
        /// </summary>
        /// <returns></returns>
        public static async Task RunAll()
        {
            await Task.Delay(0);
            //var users = UserApi.Users.ToArray();
            //var students = Students.GetAllStudents();
            //foreach (var item in users)
            //{
            //    foreach (var student in students)
            //    {
            //        await GetSchoolListByAsycn(item, student);
            //        await DoTaskAsync(item, student);
            //    }
            //}
        }


        /// <summary>
        /// 点赞任务,刷新前5条进行点赞
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        async static Task GetSchoolListByAsycn(User user, Students student)
        {
            var client = HttpApi.Resolve<ISchoolsTask>();
            var requestSchool = new RequestSchool(user.Id, student.ClassId, student.StudentId);
            var schoolList = await client.GetSchoolListByAsync(requestSchool);

            var news = schoolList.body.feeds.Where(item => item.userId != "").Take(5).ToArray();
            foreach (var item in news)
            {
                var likeData = new RequestLike(user.Id, student.childId);
                likeData.contentId = item.contentId;
                likeData.contentUserId = item.userId;
                likeData.studentId = item.studentId;
                likeData.like = 1;
                var likeResult = await client.DoSchoolsLikeByAsync(likeData);
                Console.WriteLine("{3} 的 {2} 点赞：{0},当前赞数：{1}", likeResult.message, likeResult.body.count, user.NickName, student.StudentName);
                await Task.Delay(2000);
                //likeData.like = 0;
                //var noLikeResult = await client.DoSchoolsLikeByAsync(likeData);
                //Console.WriteLine("{3} 的 {2} 取消点赞：{0},当前赞数：{1}", likeResult.message, likeResult.body.count, user.NickName, student.StudentName);
                //await Task.Delay(2000);
            }
        }


        /// <summary>
        /// 完成阅读文章及亲友聊天任务
        /// </summary>
        /// <returns></returns>
        async static Task DoTaskAsync(User user, Students student)
        {
            var tasks = default(TaskType).GetFieldValues<TaskType>();
            var result = new ResultRest<ResultTask>();
            foreach (var t in tasks)
            {
                if (t == TaskType.Info)
                {
                    await DoTaskByTypeAsync(t, user, student, 5);
                }
                else
                {
                    await DoTaskByTypeAsync(t, user, student);
                }
            }
        }

        /// <summary>
        /// 指定类型循环次数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        async static Task DoTaskByTypeAsync(TaskType type, User user, Students student, int count = 1)
        {
            var client = HttpApi.Resolve<ISchoolsTask>();
            //完成指定类型任务
            var data = new RequestTask(type, user.Id, student);
            for (var i = 0; i < count; i++)
            {
                var result = await client.DoTaskByAsync(data);
                if (result.code != 10000)
                {
                    Console.WriteLine("{2} 的 {0} {1}", user.NickName, result, student.StudentName);
                }
                else
                {
                    Console.WriteLine("{2} 的 {0} {1}", user.NickName, result.body.task.description, student.StudentName);
                }
                await Task.Delay(2000);
            }
        }
    }
}
