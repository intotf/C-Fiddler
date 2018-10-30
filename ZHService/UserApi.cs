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
    public class User
    {
        /// <summary>
        /// ID 和昵称分割符号
        /// </summary>
        public static char pixText = '|';

        /// <summary>
        /// 用户id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 输出分割字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}{1}{2}", this.Id, pixText, this.NickName);
        }

        /// <summary>
        /// 字符串转 User 实体
        /// </summary>
        /// <param name="userStr"></param>
        public static User StrToUser(string userStr)
        {
            var arr = userStr.Split(pixText);
            if (arr.Length == 2)
            {
                return new User { Id = arr[0], NickName = arr[1] };
            }
            return default(User);
        }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    static class UserApi
    {
        /// <summary>
        /// 用户文件名
        /// </summary>
        private static string userFile = "userids.txt";

        /// <summary>
        /// 所有用户
        /// </summary>
        public static IEnumerable<User> Users;

        /// <summary>
        /// 加锁
        /// </summary>
        private static object lockKey = new object();

        /// <summary>
        /// 初始化
        /// </summary>
        static UserApi()
        {
            if (!File.Exists(userFile))
            {
                File.Create(userFile);
            }
            Users = GetUserIds();
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<User> GetUserIds()
        {
            var userLines = File.ReadAllLines(userFile);
            foreach (var item in userLines.Where(t => string.IsNullOrEmpty(t) == false))
            {
                var model = User.StrToUser(item);
                if (model != null)
                {
                    yield return model;
                }
            }
        }

        /// <summary>
        /// 刷新用户列表
        /// </summary>
        private static void RefreshUsers()
        {
            Users = GetUserIds();
            WsNoticeApi.LoadUsers();
        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="name">昵称</param>
        public static void AddOUpdateUser(User user)
        {
            lock (lockKey)
            {
                if (user == null)
                {
                    return;
                }
                var oldModel = Users.Where(item => item.Id == user.Id).FirstOrDefault();
                if (oldModel == null)
                {
                    File.AppendAllText(userFile, user.ToString() + Environment.NewLine);
                    Console.WriteLine("新增用户:{0}", user.ToString());
                }
                else
                {
                    var allText = File.ReadAllText(userFile);
                    var newText = allText.Replace(oldModel.ToString(), user.ToString());
                    File.WriteAllText(userFile, newText);
                    Console.WriteLine("登录用户:{0}", user.ToString());
                }
                RefreshUsers();
            }
        }
    }



}
