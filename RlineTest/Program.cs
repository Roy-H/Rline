using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rline;

namespace RlineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Rline.Rline rline = new Rline.Rline();
            rline.RunFile("./examples/cake.rl");
            Console.ReadKey();
        }
    }
}
