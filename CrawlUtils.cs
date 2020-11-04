using System;
using System.IO;

namespace DirectoryCrawler
{
    internal static class CrawlUtils
    {
        public static void SearchDirectory(DirectoryInfo dir)
        {
            FileInfo[] files = null;

            try
            {
                files = dir.GetFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (files != null)
            {
                Program.jsonDir.AppendLine($"{'{'}\"{dir.Name}\": [");

                for (int i = 0; i < files.Length; i++)
                {
                    Program.jsonDir.AppendLine($"\"{files[i].Name}\"{((i == files.Length - 1 && dir.GetDirectories().Length == 0) ? ' ' : ',')}");
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    SearchDirectory(dirs[i]);
                    if (dirs.Length > 1 && i != dirs.Length-1)
                    {
                        Program.jsonDir.AppendLine(",");
                    }
                }

                Program.jsonDir.AppendLine("]}");
            }
        }
    }
}