using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = int.Parse(args[0]);
            Random rnd = new Random(seed);

            int n = rnd.Next((int)1E6 + 1);
            Console.WriteLine(n);
            Console.Write(rnd.Next((int)1E9));
            for (int i = 1; i < n; i++)
                Console.Write(" {0}", rnd.Next((int)1E9));
            Console.WriteLine();
            for (int i = 0; i < 2*n; i++)
                Console.WriteLine("{0} {1}", rnd.Next(2) == 0 ? 'C' : 'E', rnd.Next((int)1E9));
        }
    }
}
