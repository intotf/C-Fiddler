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
                return AppService.listener.SessionManager.FilterWrappers<JsonWebSocketSession>().ToArray();
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
            try
            {
                UserList.AddUser(userId);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
