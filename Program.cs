using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DirectoryCrawler
{
    class Program
    {
        public static StringBuilder jsonDir = new StringBuilder();

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("./");
            StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"/{dir.Name}.json", true);
            CrawlUtils.SearchDirectory(dir);
            JToken token = JToken.Parse(jsonDir.ToString());
            file.WriteLine(token.ToString(Formatting.Indented));
            file.Close();
        }
    }
}