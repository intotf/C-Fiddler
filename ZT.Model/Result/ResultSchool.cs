using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 消息新鲜事响应实体
    /// </summary>
    public class ResultSchool
    {
        /// <summary>
        /// 新鲜事集合
        /// </summary>
        public List<FeedsItem> feeds { get; set; }

        /// <summary>
        /// 广告信息
        /// </summary>
        public Ad ad { get; set; }

        /// <summary>
        /// 点赞集合
        /// </summary>
        public List<FeedCommentsItem> feedComments { get; set; }
    }

    public class UserPic
    {
        /// <summary>
        /// 
        /// </summary>
        public string imageUrl { get; set; }
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
    /// 图片集合
    /// </summary>
    public class Images
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 图宽
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 图高
        /// </summary>
        public int height { get; set; }
    }

    /// <summary>
    /// 标签集合
    /// </summary>
    public class Tags
    {
        /// <summary>
        /// 标签名
        /// </summary>
        public string tag { get; set; }
    }

    /// <summary>
    /// 图片内容
    /// </summary>
    public class FeedContent
    {
        /// <summary>
        /// 图片集合
        /// </summary>
        public List<Images> images { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 背景音乐
        /// </summary>
        public string musicMark { get; set; }
        /// <summary>
        /// 标签集合
        /// </summary>
        public List<Tags> tags { get; set; }
    }

    /// <summary>
    /// 新鲜事集合
    /// </summary>
    public class FeedsItem
    {
        /// <summary>
        /// 新鲜事id
        /// </summary>
        public long feedId { get; set; }
        /// <summary>
        /// 内容id
        /// </summary>
        public string contentId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int contentType { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public int visible { get; set; }
        /// <summary>
        /// 学校id
        /// </summary>
        public string schoolId { get; set; }
        /// <summary>
        /// 学生id
        /// </summary>
        public string studentId { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public string classId { get; set; }
        /// <summary>
        /// 发布者用户Id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string userType { get; set; }
        /// <summary>
        /// 发布者真实名称
        /// </summary>
        public string trueName { get; set; }
        /// <summary>
        /// 发布者昵称
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 发布者头像
        /// </summary>
        public UserPic userPic { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public long publishTime { get; set; }
        /// <summary>
        /// 标题/内容信息
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 是否粘性的帖子
        /// </summary>
        public string stickyPost { get; set; }
        /// <summary>
        /// 分享网址
        /// </summary>
        public string shareUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FeedContent feedContent { get; set; }
    }

    /// <summary>
    /// 点赞人信息
    /// </summary>
    public class LikeListItem
    {
        /// <summary>
        /// 点赞人id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 子类id
        /// </summary>
        public string childId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 微信名
        /// </summary>
        public string wxName { get; set; }
        /// <summary>
        /// 点赞人头像
        /// </summary>
        public string userPic { get; set; }
    }

    /// <summary>
    /// 点赞信息
    /// </summary>
    public class CommentInfo
    {
        /// <summary>
        /// 点赞总数
        /// </summary>
        public int likeCount { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int commentCount { get; set; }
        /// <summary>
        /// 浏览总次数
        /// </summary>
        public int viewCount { get; set; }
        /// <summary>
        /// 分享总次数
        /// </summary>
        public int shareCount { get; set; }
        /// <summary>
        /// 是否点赞
        /// </summary>
        public int likeState { get; set; }
        /// <summary>
        /// 点击赞合
        /// </summary>
        public List<LikeListItem> likeList { get; set; }
        /// <summary>
        /// 评论文本集合
        /// </summary>
        public List<string> comments { get; set; }
    }

    /// <summary>
    /// 点赞集合
    /// </summary>
    public class FeedCommentsItem
    {
        /// <summary>
        /// 内容id
        /// </summary>
        public string contentId { get; set; }
        /// <summary>
        /// 内容类别
        /// </summary>
        public int contentType { get; set; }
        /// <summary>
        /// 点赞信息
        /// </summary>
        public CommentInfo commentInfo { get; set; }
    }
}
