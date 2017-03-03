using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace HtmlScraper
{
    class Program
    {
        static public List<Post> posts;


        static void Main(string[] args)
        {
            //BrowseCommand cmd = new BrowseCommand();

            Display(Console.ReadLine());

            /*start:

            string msg = Console.ReadLine();

            
            if (cmd.Accept(msg))
            {
                cmd.Execute();
            }
            else
            {
                Console.WriteLine("wrong input");
            }
            goto start;*/

        }

        static public void Display(string subredditName)
        {
            
            posts = RedditScraper.GetPosts(String.Format("https://www.reddit.com/r/{0}/", subredditName));
            
            foreach (Post p in posts)
            {
                Console.WriteLine(p.Rank + ".");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(p.Title + "\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(p.Upvotes + " upvotes\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }

}
