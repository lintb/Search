using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using ZZB.Search.OutInterface;

namespace ZZB.Search.Btmeet
{
    public class SearchService : ISearchService
    {
        public string Url { get; } = @"http://www.btmeet.com/";

        public string Name { get; } = "Btmeet";

        private readonly string _searchUrl = @"http://www.btmeet.com/search/{0}/{1}-1.html";

        public void Search(string keyWord, int index, Action<OutInterface.Search> callBack)
        {
            string html = Common.GetPage(string.Format(_searchUrl, keyWord, index));
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            HtmlNodeCollection htmlNodeCollection = htmlDoc.DocumentNode.SelectNodes("//div[@class='item-title']/h3/a");
            foreach (HtmlNode htmlNode in htmlNodeCollection)
            {
                new Task(() =>
                {
                    OutInterface.Search search = new OutInterface.Search();
                    string url = htmlNode.GetAttributeValue("href", "");
                    string oneHtml = Common.GetPage(Url + url);
                    HtmlDocument oneHtmlDoc = new HtmlDocument();
                    oneHtmlDoc.LoadHtml(oneHtml);

                    //获取TITLE
                    HtmlNodeCollection titleNodeCollection = oneHtmlDoc.DocumentNode.SelectNodes("//div[@id='wall']/h2");
                    Match match = Regex.Match(titleNodeCollection[0].InnerText, "document\\.write\\(decodeURIComponent\\(\"(.+?)\"\\)\\);");
                    string[] paths = match.Groups[1].Value.Split(new[] { "\"+\"" }, StringSplitOptions.RemoveEmptyEntries);
                    search.Title = HttpUtility.UrlDecode(string.Join("", paths));

                    //获取创建时间
                    HtmlNodeCollection createTimeNodeCollection = oneHtmlDoc.DocumentNode.SelectNodes("//div[@class='fileDetail']/table/tr/td");
                    DateTime dt;
                    DateTime.TryParse(createTimeNodeCollection[1].InnerText, out dt);
                    search.CreateTime = dt;

                    //大小
                    double size;
                    double.TryParse(createTimeNodeCollection[4].InnerText.TrimEnd(' ', 'M', 'B', '\n'), out size);
                    search.Size = size;

                    //下载地址
                    HtmlNodeCollection urlNodeCollection = oneHtmlDoc.DocumentNode.SelectNodes("//div[@class='fileDetail']/div[1]/div[2]/a");
                    search.DownloadUrl = urlNodeCollection[0].InnerText;

                    callBack(search);
                }).Start();
            }
        }
    }
}
