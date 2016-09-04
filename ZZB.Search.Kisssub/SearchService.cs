using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ZZB.Search.OutInterface;

namespace ZZB.Search.Kisssub
{
    /// <summary>
    /// Author:zaibinzhang
    /// CreateTime:2016-08-26
    /// </summary>
    public class SearchService : ISearchService
    {

        public string Url { get; } = @"http://www.kisssub.org/";
        public string Name { get; } = "爱恋动漫";

        /// <summary>
        /// 搜索url
        /// </summary>
        private readonly string _searchUrl = @"http://www.kisssub.org/search.php?keyword={0}&page={1}";

        /// <summary>
        /// 未完成的多线程数，用于监视多线程完成成矿
        /// </summary>
        //private int _unfinishedCount;

        public void Search(string keyWord, int index, Action<OutInterface.Search> callBack)
        {
            //List<OutInterface.Search> list = new List<OutInterface.Search>();
            //获取html并用HtmlAgilityPack获取节点信息
            string html = Common.GetPage(string.Format(_searchUrl, keyWord, index));
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            //获取资源列表
            GetSearchModel(htmlDoc, "alt1", callBack, keyWord);
            GetSearchModel(htmlDoc, "alt2", callBack, keyWord);

        }

        private void GetSearchModel(HtmlDocument htmlDoc, string className, Action<OutInterface.Search> callBack,string keyword)
        {
            HtmlNodeCollection htmlNodeCollection = htmlDoc.DocumentNode.SelectNodes($"//tr[@class='{className}']");
            foreach (HtmlNode htmlNode in htmlNodeCollection)
            {
                //开辟线程获取资源
                new Task(() =>
                {
                    OutInterface.Search search = new OutInterface.Search(keyword);

                    var titleNode = htmlNode.ChildNodes[5].ChildNodes;
                    search.Title = titleNode[1].InnerText.Trim();

                    string size = htmlNode.ChildNodes[7].InnerText.Trim();

                    double d;
                    double.TryParse(size.TrimEnd('M', 'B'), out d);
                    search.Size = d;

                    search.CreateTime = GetDateTime(htmlNode.ChildNodes[1].InnerText.Trim());

                    search.DownloadUrl = GetDownloadUrl(Url + titleNode[1].GetAttributeValue("href", ""));

                    // list.Add(search);

                    callBack(search);
                }).Start();
            }
        }

        /// <summary>
        /// 获取下载链接
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetDownloadUrl(string url)
        {
            string html = Common.GetPage(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc.DocumentNode.SelectNodes("//a[@id='magnet']")[0].GetAttributeValue("href", "");
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        private DateTime GetDateTime(string strTime)
        {
            DateTime dt;
            if (strTime.Contains("今天"))
            {
                dt = DateTime.Today;
            }
            else if (strTime.Contains("昨天"))
            {
                dt = DateTime.Today.AddDays(-1);
            }
            else if (strTime.Contains("前天"))
            {
                dt = DateTime.Today.AddDays(-2);
            }
            else
            {
                DateTime.TryParse(strTime, out dt);
            }
            return dt;
        }
    }
}