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
        /// 创建请求客户端
        /// </summary>
        private static ISchoolsTask client = HttpApiClient.Create<ISchoolsTask>();


        /// <summary>
        /// 根据Id 自动完成任务
        /// </summary>
        /// <param name="uid"></param>
        public static async void Run(string uid)
        {
            await GetSchoolListByAsycn(uid);
            await DoTaskAsync(uid);
        }


        /// <summary>
        /// 点赞任务,刷新前5条进行点赞
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        async static Task GetSchoolListByAsycn(string uid)
        {
            var requestSchool = new RequestSchool(uid);
            var schoolList = await client.GetSchoolListByAsync(requestSchool).HandleAsDefaultWhenException(r =>
            {
                Console.WriteLine(r.Message);
            });

            foreach (var item in schoolList.body.feeds.Take(5))
            {
                var likeData = new RequestLike(uid);
                likeData.contentId = item.contentId;
                likeData.contentUserId = item.userId;
                likeData.studentId = item.studentId;
                likeData.like = 1;
                var likeResult = await client.DoSchoolsLikeByAsync(likeData);
                Console.WriteLine("{2} 点赞：{0},当前赞数：{1}", likeResult.message, likeResult.body.count, uid);
                await Task.Delay(2000);
                likeData.like = 0;
                var noLikeResult = await client.DoSchoolsLikeByAsync(likeData);
                Console.WriteLine("{2} 取消点赞：{0},当前赞数：{1}", likeResult.message, likeResult.body.count, uid);
                await Task.Delay(2000);
            }
        }


        /// <summary>
        /// 完成阅读文章及亲友聊天任务
        /// </summary>
        /// <returns></returns>
        async static Task DoTaskAsync(string uid)
        {
            var tasks = default(TaskType).GetFieldValues<TaskType>();
            var result = new ResultRest<ResultTask>();
            foreach (var t in tasks)
            {
                //完成文章阅读
                var data = new RequestTask(t, uid);
                if (t == TaskType.Info)
                {
                    await DoTaskByTypeAsync(t, uid, 5);
                }
                else
                {
                    await DoTaskByTypeAsync(t, uid);
                }
            }
        }

        /// <summary>
        /// 指定类型循环次数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        async static Task DoTaskByTypeAsync(TaskType type, string uid, int count = 1)
        {
            //完成指定类型任务
            var data = new RequestTask(type, uid);
            for (var i = 0; i < count; i++)
            {
                var result = await client.DoTaskByAsync(data);
                if (result.code != 10000)
                {
                    Console.WriteLine("{2} {0} {1}", DateTime.Now, result, uid);
                }
                else
                {
                    Console.WriteLine("{2} {0} {1}", DateTime.Now, result.body.task.description, uid);
                }
                await Task.Delay(2000);
            }
        }
    }
}
