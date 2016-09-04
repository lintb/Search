using System;

namespace ZZB.Search.OutInterface
{
    public class Search
    {
        public string Keyword { get; }

        public Search(string keyword)
        {
            Keyword = keyword;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 大小（单位为M）
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownloadUrl { get; set; }
    }
}