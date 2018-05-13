using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1 part1 = new Part1();
            part1.DoTasksPart1();

            Part2 part2 = new Part2();
            part2.DoTasksPart2();

            Part3 part3 = new Part3();
            part3.DoTasksPart3();
        }
    }
}
