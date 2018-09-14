using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using ZT.Model;
using ZTHome.Work;

namespace ZTHome
{
    class Program
    {
        static ISchoolLike client = HttpApiClient.Create<ISchoolLike>();

        static void Main(string[] args)
        {

            //DoTaskByTypeAsync(TaskType.Love, 84).Wait();

            DoTaskAsync().Wait();
            //GetSchoolListByAsycn().Wait();
            Console.ReadKey();
        }

        async static Task GetSchoolListByAsycn()
        {
            var requestSchool = new RequestSchool();
            var schoolList = await client.GetSchoolListByAsync(requestSchool).HandleAsDefaultWhenException(r =>
            {
                Console.WriteLine(r.Message);
            });

            foreach (var item in schoolList.body.feeds.Take(5))
            {
                var likeData = new RequestLike();
                likeData.contentId = item.contentId;
                likeData.contentUserId = item.userId;
                likeData.studentId = item.studentId;
                likeData.like = 1;
                var likeResult = await client.DoSchoolsLikeByAsync(likeData);
                Console.WriteLine("点赞：{0},当前赞数：{1}", likeResult.message, likeResult.body.count);
                await Task.Delay(2000);
                likeData.like = 0;
                var noLikeResult = await client.DoSchoolsLikeByAsync(likeData);
                Console.WriteLine("取消点赞：{0},当前赞数：{1}", likeResult.message, likeResult.body.count);
                await Task.Delay(2000);
            }
        }

        /// <summary>
        /// 指定类型循环次数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        async static Task DoTaskByTypeAsync(TaskType type, int count = 1)
        {
            //完成指定类型任务
            var data = new RequestTask(type);
            for (var i = 0; i < count; i++)
            {
                var result = await client.DoTaskByAsync(data);
                if (result.code != 10000)
                {
                    Console.WriteLine("{0} {1}", DateTime.Now, result);
                }
                else
                {
                    Console.WriteLine("{0} {1}", DateTime.Now, result.body.task.description);
                }
                await Task.Delay(2000);
            }
        }

        /// <summary>
        /// 完成阅读文章及亲友聊天任务
        /// </summary>
        /// <returns></returns>
        async static Task DoTaskAsync()
        {
            var tasks = default(TaskType).GetFieldValues<TaskType>();
            var result = new ResultRest<ResultTask>();
            foreach (var t in tasks)
            {
                //完成文章阅读
                var data = new RequestTask(t);
                if (t == TaskType.Info)
                {
                    await DoTaskByTypeAsync(t, 5);
                }
                else
                {
                    await DoTaskByTypeAsync(t);
                }
            }
        }
    }
}
