using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 请求公共类
    /// </summary>
    public class RequstBase
    {
        /// <summary>
        /// 初始化定位信息
        /// </summary>
        public static Geo geo = new Geo();

        /// <summary>
        /// 初始化设备信息
        /// </summary>
        public static Device_info device_Info = new Device_info();

        /// <summary>
        /// 初始化当前用户信息
        /// </summary>
        public static User_info user_Info(string uid)
        {
            return new User_info(uid);
        }

        /// <summary>
        /// 初始化请求附属参数
        /// </summary>
        public static AdParams adParams(string uid)
        {
            return new AdParams(uid);
        }
        /// <summary>
        /// 学生Id
        /// </summary>
        public static string studentId = "bb7889c25394fea9142e";

        /// <summary>
        /// 分类Id
        /// </summary>
        public static string classId = "kLAy4HlS7BY0q0wOs4K";
    }

    /// <summary>
    /// 定位信息
    /// </summary>
    public class Geo
    {
        /// <summary>
        /// 所在城市行政编码
        /// 中山 坦洲 440402
        /// </summary>
        public int city { get; set; } = 440402;
        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { get; set; } = 22.303976;
        /// <summary>
        /// 经度
        /// </summary>
        public double lon { get; set; } = 113.48017;
    }


    /// <summary>
    /// 设备信息
    /// </summary>
    public class Device_info
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string adid { get; set; } = "8cb1793dd4afeef0";
        /// <summary>
        /// App 版本
        /// </summary>
        public string app_version { get; set; } = "6.1.6";
        /// <summary>
        /// 品牌
        /// </summary>
        public string brand { get; set; } = "Xiaomi";
        /// <summary>
        /// 航空公司
        /// </summary>
        public int carrier { get; set; } = 2;
        /// <summary>
        /// 连接类型
        /// 1 Wifi
        /// </summary>
        public int connectiontype { get; set; } = 1;
        /// <summary>
        /// 密度
        /// 2.0
        /// </summary>
        public string density { get; set; } = "2.0";
        /// <summary>
        /// 设置类型
        /// 1 手机
        /// </summary>
        public int devicetype { get; set; } = 1;

        /// <summary>
        /// 定位信息
        /// </summary>
        public Geo geo { get; set; }
        /// <summary>
        /// 屏幕高度
        /// </summary>
        public int h { get; set; } = 2248;
        /// <summary>
        /// 手机IMEI
        /// </summary>
        public string imei { get; set; } = "80001165643365";
        /// <summary>
        /// IP 地址
        /// </summary>
        public string ip { get; set; } = "14.21.24.82";
        /// <summary>
        /// 手机MAC
        /// </summary>
        public string mac { get; set; } = "8C:2D:C2:08:A1:2E";
        /// <summary>
        /// 使用者信息
        /// </summary>
        public string make { get; set; }
        /// <summary>
        /// 手机品牌型号
        /// </summary>
        public string model { get; set; } = "XiaoMi 8";
        /// <summary>
        /// 操作系统
        /// 2 安桌
        /// </summary>
        public int os { get; set; } = 2;
        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string osv { get; set; } = "7.1.2";
        /// <summary>
        /// 内置浏览器信息
        /// </summary>
        public string ua { get; set; } = "Mozilla/5.0 (Linux; Android 7.1.2; Redmi 5A Build/N2G47H; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/64.0.3282.137 Mobile Safari/537.36";
        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public int w { get; set; } = 1080;
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class User_info
    {
        public User_info(string id)
        {
            this.uid = id;
        }

        public static string _schoolid = "AvbRjTcLwKbe1DjLkxv";

        /// <summary>
        /// 行政代码
        /// </summary>
        public int babycity { get; set; } = 442000;
        /// <summary>
        /// 性别
        /// 1 男
        /// </summary>
        public int gender { get; set; } = 1;
        /// <summary>
        /// 相对
        /// </summary>
        public int relative { get; set; } = 0;
        /// <summary>
        /// 学校ID
        /// </summary>
        public string schoolid { get; set; } = _schoolid;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string uid { get; set; }

        /// <summary>
        /// 未知
        /// 默认：2012
        /// </summary>
        public int yob { get; set; } = 2012;
    }

    /// <summary>
    /// 请求附属参数
    /// </summary>
    public class AdParams
    {
        public AdParams(string uid)
        {
            this.user_info = new User_info(uid);

        }
        /// <summary>
        /// 设备信息
        /// </summary>
        public Device_info device_info { get; set; } = new Device_info();
        /// <summary>
        /// 每页最大数量
        /// 最大只能 20
        /// </summary>
        public int feed_max { get; set; } = 20;
        /// <summary>
        /// 页码
        /// </summary>
        public int feed_page { get; set; } = 1;
        /// <summary>
        /// 空间Id
        /// </summary>
        public int space_id { get; set; } = 1024;
        /// <summary>
        /// 用户信息
        /// </summary>
        public User_info user_info { get; set; }
    }
}
