using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{

    public class ThirdInteract
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> view { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> click { get; set; }
    }

    public class Interact
    {
        /// <summary>
        /// 
        /// </summary>
        public int openMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ThirdInteract thirdInteract { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string landPage { get; set; }
    }

    public class Content
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> images { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int nativeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 亲友团满3人，即可赢豪华大奖！ 还有大波红包等你来领，最高可达920元
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
    }


    public class AdsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int orderId { get; set; }
        /// <summary>
        /// 掌通家园
        /// </summary>
        public string sourceMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int materialType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Interact interact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isShowAdvert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int playtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sourceLogo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int advertId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int platform { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int insertPos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Content content { get; set; }
    }

    public class Space
    {
        /// <summary>
        /// 
        /// </summary>
        public int spaceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
    }

    /// <summary>
    /// 广告信息
    /// </summary>
    public class Ad
    {
        /// <summary>
        /// 
        /// </summary>
        public List<AdsItem> ads { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Space space { get; set; }
    }
}
