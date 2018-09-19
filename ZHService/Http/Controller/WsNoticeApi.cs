using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSocket;
using NetworkSocket.Core;
using NetworkSocket.WebSocket;

namespace ZHService
{
    public sealed class WsNoticeApi : JsonWebSocketApiService
    {

        /// <summary>
        /// 获取其它成员
        /// </summary>
        private static IEnumerable<JsonWebSocketSession> OtherSessions
        {
            get
            {
                return Listener.WsListener.SessionManager.FilterWrappers<JsonWebSocketSession>().ToArray();
            }
        }

        /// <summary>
        /// 发送通知
        /// </summary>
        /// <returns></returns>
        public static void OnLog(string log)
        {
            foreach (var ws in OtherSessions)
            {
                try
                {
                    ws.InvokeApi("OnLog", log);
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Api]
        public bool AddUser(string userId)
        {
            var user = User.StrToUser(userId);
            if (user == null)
            {
                return false;
            }
            try
            {
                UserApi.AddOUpdateUser(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 刷新用户
        /// </summary>
        public static void LoadUsers()
        {
            foreach (var ws in OtherSessions)
            {
                try
                {
                    ws.InvokeApi("LoadUsers", true);
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="userIds"></param>
        [Api]
        public async void Run(string userIds)
        {
            var userArr = userIds.Split(',');
            foreach (var u in userArr)
            {
                await AutoTask.Run(u);
            }
        }

    }
}
