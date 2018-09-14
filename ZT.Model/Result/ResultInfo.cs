using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 文章消息回复
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// 文章内容列表
        /// </summary>
        public List<ContentItem> content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Ad ad { get; set; }
    }

    /// <summary>
    /// 图片信息
    /// </summary>
    public class ImagesItem
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string image { get; set; }
    }

    /// <summary>
    /// 标签
    /// </summary>
    public class TagsItem
    {
        /// <summary>
        /// 标签样式
        /// </summary>
        public string display { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string name { get; set; }
    }

    /// <summary>
    /// 作者信息
    /// </summary>
    public class Author
    {
        /// <summary>
        /// 作者id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 作者类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 作者头像
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 作者等级荣誉
        /// </summary>
        public string honor { get; set; }
        /// <summary>
        /// * 遵循
        /// </summary>
        public int follow { get; set; }
        /// <summary>
        /// * 源
        /// </summary>
        public int source { get; set; }
    }

    /// <summary>
    /// 文章详情
    /// </summary>
    public class Data
    {
    }

    /// <summary>
    /// 文章内容
    /// </summary>
    public class ContentItem
    {
        /// <summary>
        /// 提要id
        /// </summary>
        public int feedId { get; set; }
        /// <summary>
        /// 内容id
        /// </summary>
        public string contentId { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public int contentType { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int weight { get; set; }
        /// <summary>
        /// 图片集合
        /// </summary>
        public List<ImagesItem> images { get; set; }
        /// <summary>
        /// 大图
        /// </summary>
        public string largeImage { get; set; }
        /// <summary>
        /// 发布者，来源
        /// </summary>
        public string origin { get; set; }
        /// <summary>
        /// 持续时间0永久
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 文章标签
        /// </summary>
        public List<TagsItem> tags { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int comments { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int likes { get; set; }
        /// <summary>
        /// 是否点赞
        /// </summary>
        public int likeState { get; set; }
        /// <summary>
        /// 转发数
        /// </summary>
        public int forwards { get; set; }
        /// <summary>
        /// 阅读数
        /// </summary>
        public int pv { get; set; }
        /// <summary>
        /// 推送朋友友圈数量
        /// </summary>
        public int publishTm { get; set; }
        /// <summary>
        /// 作者信息
        /// </summary>
        public Author author { get; set; }
        /// <summary>
        /// 数据内容,暂无
        /// </summary>
        public Data data { get; set; }
    }

}
