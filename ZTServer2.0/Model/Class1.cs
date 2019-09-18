using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTServer2._0.Model
{
    /// <summary>
    /// 刷新消息新鲜事
    /// </summary>
    public class Class1
    {

        public class Rootobject
        {
            public Adparams adParams { get; set; }
            public string classId { get; set; }
            public int feedId { get; set; }
            public string industryType { get; set; }
            public int moduleType { get; set; }
            public string schoolId { get; set; }
            public int schoolType { get; set; }
            public string studentId { get; set; }
            public string userId { get; set; }
            public string zipCode { get; set; }
        }

        public class Adparams
        {
            public Device_Info device_info { get; set; }
            public int feed_max { get; set; }
            public int feed_page { get; set; }
            public User_Info user_info { get; set; }
        }

        public class Device_Info
        {
        }

        public class User_Info
        {
            public string schoolid { get; set; }
            public string uid { get; set; }
        }

    }
}
