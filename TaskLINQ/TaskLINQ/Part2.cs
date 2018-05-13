using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLINQ
{
    public class Part2
    {
        public List<string> ReadFromFile(string readPath)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(readPath, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }

        public void PrintToFile<T>(IEnumerable<T> list, string writePath, string title)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.WriteLine(title);
                foreach (T i in list)
                {
                    sw.WriteLine(i);
                }
            }
        }
        public void Task1()
        {
            string readPath = @"dataPart2Task1.txt";
            string writePath = @"outputPart2Task1.txt";
            int k1, k2;
            List<string> data = ReadFromFile(readPath);
            string str1 = data[0];
            string[] lenghts = str1.Split(' ');
            k1 = Convert.ToInt32(lenghts[0]);
            k2 = Convert.ToInt32(lenghts[1]);
            string str2 = data[1];
            string str3 = data[2];
            int[] arrayA = str2.Split(' ').Select(s=> Convert.ToInt32(s)).ToArray();
            int[] arrayB = str3.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
            var a = arrayA.Where(elem => elem > k1);
            var b = arrayB.Where(elem => elem < k2);
            var c = a.Concat(b);
            c = c.OrderBy(s => s);
            string title = "Sorted sequence: ";
            PrintToFile(c, writePath, title);
        }

        public void Task2()
        {
            string readPath = @"dataPart2Task2.txt";
            string writePath = @"outputPart2Task2.txt";
            int l1, l2;
            List<string> data = ReadFromFile(readPath);
            string str1 = data[0];
            string[] lenghts = str1.Split(' ');
            l1 = Convert.ToInt32(lenghts[0]);
            l2 = Convert.ToInt32(lenghts[1]);
            string str2 = data[1];
            string str3 = data[2];
            string[] arrayA = str2.Split(' ');
            string[] arrayB = str3.Split(' ');
            var a = arrayA.Where(elem => elem.Length == l1);
            var b = arrayB.Where(elem => elem.Length == l2);
            var c = a.Concat(b);
            c = c.OrderByDescending(s => s);
            string title = "Sorted sequence: ";
            PrintToFile(c, writePath, title);
        }

        public void DoTasksPart2()
        {
            Task1();
            Task2();
        }
    }
}
