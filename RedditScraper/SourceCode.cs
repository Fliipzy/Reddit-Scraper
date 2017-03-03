using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace HtmlScraper
{
    public static class SourceCode
    {
        public static string GetSourceCode(string url)
        {
            WebRequest req = WebRequest.Create(url);
            HttpWebRequest httpRequest = (HttpWebRequest)req;

            httpRequest.CookieContainer = new CookieContainer();

            httpRequest.CookieContainer.Add(new Cookie("over18", "1", "/", ".reddit.com"));

            WebResponse resp = httpRequest.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string sourceCode = sr.ReadToEnd();
            sr.Close();
            return sourceCode;
        }
    }
}
