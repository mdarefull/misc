using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhterOptionsExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert File URL: ");
            string fileSrc = Console.ReadLine();
            StreamReader sr = new StreamReader(fileSrc);
            string content = sr.ReadToEnd();
            content = content.Substring(content.IndexOf("jdbc.connectionPool.initialSize=1"));

            Debugger.Break();
        }
    }
}
