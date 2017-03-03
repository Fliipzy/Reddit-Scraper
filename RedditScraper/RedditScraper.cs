using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace HtmlScraper
{
    static class RedditScraper
    {


        public static List<Post> GetPosts(string url)
        {
            List<Post> posts = new List<Post>();
            string sourceCode = SourceCode.GetSourceCode(url);

            Regex postRegex = new Regex(@"<div class="" thing id-t3(.*?)<div class=""clearleft""></div>");

            Regex dataURLRegex = new Regex(@"data-url=""(.*?)""");
            Regex rankRegex = new Regex(@"<span class=""rank"">(.*?)</span>");
            Regex titleRegex = new Regex(@"<p class=""title"">(.*?)rel="""" >(.*?)</a>");
            Regex votesRegex = new Regex(@"<div class=""score unvoted"">(.*?)</div>");

            //Match m = titleRegex.Match(sourceCode);
            MatchCollection mc = postRegex.Matches(sourceCode);

            //Console.WriteLine(m.Groups[0]);

            foreach (Match m in mc)
            {
                string post = m.Groups[0].Value;

                Match dataUrlMatch = dataURLRegex.Match(post);
                Match titleMatch = titleRegex.Match(post);
                Match rankMatch = rankRegex.Match(post);
                Match votesMatch = votesRegex.Match(post);

               

                posts.Add(new Post(rankMatch.Groups[1].Value, votesMatch.Groups[1].Value, dataUrlMatch.Groups[1].Value, titleMatch.Groups[2].Value));
            }
            
            return posts;
        }
    }
}
