using System.IO;
using System.Net;
using System.Text;

namespace ZZB.Search.OutInterface
{
    public static class Common
    {
        public static string GetPage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.KeepAlive = true;
            //request.Headers.Add("Cookie:" + CookiesString);
            //request.CookieContainer = CookieContainer;
            request.AllowAutoRedirect = false;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            var response = (HttpWebResponse)request.GetResponse();
            //设置cookie  
            // CookiesString = request.CookieContainer.GetCookieHeader(request.RequestUri);
            //取再次跳转链接  
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string ss = sr.ReadToEnd();
            sr.Close();
            request.Abort();
            response.Close();
            //依据登陆成功后返回的Page信息，求出下次请求的url
            //每个网站登陆后加载的Url和顺序不尽相同，以下两步需根据实际情况做特殊处理，从而得到下次请求的URL
            //string[] substr = ss.Split(new char[] { '"' });

            return ss;
        }
    }
}