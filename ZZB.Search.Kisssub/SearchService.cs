using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ZZB.Search.OutInterface;

namespace ZZB.Search.Kisssub
{
    public class SearchService : ISearchService
    {
        public string Url { get; } = @"http://www.kisssub.org/";
        public string Name { get; } = "爱恋动漫";

        private readonly string _searchUrl =
            @"http://www.kisssub.org/search.php?keyword={0}&page={1}";

        public List<OutInterface.Search> Search(string keyWord, int index)
        {
            List<OutInterface.Search> list = new List<OutInterface.Search>();
            string html = Common.GetPage(string.Format(_searchUrl, keyWord, index));
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            list.AddRange(GetSearchModel(htmlDoc, "alt1"));
            list.AddRange(GetSearchModel(htmlDoc, "alt2"));

            return list;
        }

        private List<OutInterface.Search> GetSearchModel(HtmlDocument htmlDoc, string className)
        {
            List<OutInterface.Search> list = new List<OutInterface.Search>();
            HtmlNodeCollection htmlNodeCollection = htmlDoc.DocumentNode.SelectNodes($"//tr[@class='{className}']");
            foreach (HtmlNode htmlNode in htmlNodeCollection)
            {
                OutInterface.Search search = new OutInterface.Search();

                var titleNode = htmlNode.ChildNodes[5].ChildNodes;
                search.Title = titleNode[1].InnerText.Trim();

                string size = htmlNode.ChildNodes[7].InnerText.Trim();

                double d;
                double.TryParse(size.TrimEnd('M', 'B'), out d);
                search.Size = d;

                search.CreateTime = GetDateTime(htmlNode.ChildNodes[1].InnerText.Trim());

                search.DownloadUrl = GetDownloadUrl(Url + titleNode[1].GetAttributeValue("href", ""));

                list.Add(search);
            }
            return list;
        }

        private string GetDownloadUrl(string url)
        {
            string html = Common.GetPage(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc.DocumentNode.SelectNodes("//a[@id='magnet']")[0].GetAttributeValue("href", "");
        }

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