using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //OutInterface.Search search = new OutInterface.Search() { Title = htmlNode.InnerText };
                ////string title = htmlNode.InnerHtml;
                //callBack(search);

                string url = htmlNode.GetAttributeValue("href", "");
                string ohtml = Common.GetPage(Url + url);
                HtmlDocument ohtmlDoc = new HtmlDocument();
                ohtmlDoc.LoadHtml(ohtml);
                HtmlNodeCollection oHtmlNodeCollection = ohtmlDoc.DocumentNode.SelectNodes("//div[@id='wall']/h2");
                Console.WriteLine(oHtmlNodeCollection.Count);
                foreach (HtmlNode node in oHtmlNodeCollection)
                {
                    Console.WriteLine(node.InnerText);
                }

            }
        }
    }
}
