using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace linq
{
    class LinqToFile
    {
        public static void ShowNumberOfLines(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            var files = from file in directory.EnumerateFiles()
                        where file.Extension.Equals(".cs")
                        select new { X = file, Lines = countLines(file) };
            foreach (var p in files)
            {
                Console.WriteLine("file = {0}; lines ={1}", p.X.FullName, p.Lines);
            }
        }

        public static int countLines(FileInfo f)
        {
            int count = 0;
            StreamReader sr = new StreamReader(f.OpenRead());
            while (sr.Peek() != -1)
            {
                sr.ReadLine();
                count++;
            }
            return count;
        }

    }
}
