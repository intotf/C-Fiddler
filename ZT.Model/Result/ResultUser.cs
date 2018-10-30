using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    public class ResultUser
    {
        /// <summary>
        /// 状态码 10000
        /// </summary>
        public string returncode { get; set; }

        /// <summary>
        /// 提示信息 ok
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        public Body body { get; set; }
    }

    /// <summary>
    /// 消息体
    /// </summary>
    public class Body
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public Userinfo userInfo { get; set; }

        public Childinfo childInfo { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class Userinfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string uid { get; set; }

        public string avatar { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nickname { get; set; }
        public string imaccount { get; set; }
        public Levelinfo levelinfo { get; set; }
        public string signature { get; set; }
        public string sex { get; set; }
        public string birthday { get; set; }
        public string source { get; set; }
        public string appkey { get; set; }
        public string impassword { get; set; }
        public string pushcername { get; set; }
        public Levelinfo1 levelInfo { get; set; }
        public string isVip { get; set; }
        public Authinfo authInfo { get; set; }
        public string numTotal { get; set; }
        public string feedNum { get; set; }
        public string commentNum { get; set; }
        public string followNum { get; set; }
        public string fansNum { get; set; }
        public string isFollow { get; set; }
        public string eduQaNum { get; set; }
        public string authEduQa { get; set; }
        public string isOnceQa { get; set; }
        public string expertQuestionPrice { get; set; }
        public string expertPaymentType { get; set; }
        public string userBgImg { get; set; }
        public string couponNum { get; set; }
        public string ztBean { get; set; }
    }

    public class Levelinfo
    {
        public string level { get; set; }
        public string nextscore { get; set; }
        public string score { get; set; }
        public string nextScore { get; set; }
    }

    public class Levelinfo1
    {
        public string level { get; set; }
        public string nextscore { get; set; }
        public string score { get; set; }
        public string nextScore { get; set; }
    }

    public class Authinfo
    {
        public string type { get; set; }
        public string desc { get; set; }
        public string icon { get; set; }
        public string honor { get; set; }
    }

    public class Childinfo
    {
        public string levelname { get; set; }
    }
}
