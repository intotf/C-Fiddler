using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHService
{
    /// <summary>
    /// 用户信息
    /// </summary>
    static class UserList
    {
        /// <summary>
        /// 用户文件名
        /// </summary>
        private static string userFile = "userids.txt";

        /// <summary>
        /// 所有用户Id
        /// </summary>
        public static IEnumerable<string> UserIds;

        /// <summary>
        /// 初始化
        /// </summary>
        static UserList()
        {
            if (!File.Exists(userFile))
            {
                File.Create(userFile);
            }
            UserIds = GetUserIds();
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetUserIds()
        {
            return File.ReadAllLines(userFile);
        }

        /// <summary>
        /// 刷新用户列表
        /// </summary>
        private static void RefreshUsers()
        {
            UserIds = GetUserIds();
        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="userId"></param>
        public static void AddUser(string userId)
        {
            File.AppendAllText(userFile, Environment.NewLine + userId);
            RefreshUsers();
        }
    }
}
