using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlScraper
{
    public class Command
    {
        public string Cmd_Name;

        public virtual bool Accept(string input)
        {
            return input.StartsWith(Cmd_Name);
        }

        public virtual void Execute()
        {

        }
    }

    public class ClearCommand : Command
    {
        public override void Execute()
        {
            Console.Clear();
            Program.posts.Clear();
        }
    }

    public class BrowseCommand : Command
    {
        public const string CMD_NAME = "browse";
        private string data;

        public override bool Accept(string input)
        {
            if (!input.StartsWith(CMD_NAME))
            {
                return false;
            }
            else
            {
                string tempData = input.Substring(7, input.Length - 7).Trim();
                if (data.Length > 0)
                {
                    data = tempData;
                }
                return true;
            }
        }

        public override void Execute()
        {
            Console.Clear();
            Program.posts.Clear();

            try
            {
                Program.Display(data);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
                throw;
            }
        }
    }
}
