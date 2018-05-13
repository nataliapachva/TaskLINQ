using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLINQ
{
    public class Part1
    {
        public string ReadFromFile(string readPath)
        {
            string text;
            using (StreamReader sr = new StreamReader(readPath, Encoding.Default))
            {
                text = sr.ReadToEnd();
            }

            return text;
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
            string readPath = @"dataPart1Task1.txt";
            string writePath = @"outputPart1Task1.txt";
            string text = ReadFromFile(readPath);
            string[] elements = text.Split(' ');
            var positiveIntegers = elements.Where(elem => Convert.ToInt32(elem) > 0);
            string title = "Positive integers:";
            PrintToFile(positiveIntegers, writePath, title);
        }

        public void Task2()
        {
            string readPath = @"dataPart1Task2.txt";
            string writePath = @"outputPart1Task2.txt";
            string text = ReadFromFile(readPath);
            string[] elements = text.Split(' ');
            var oddIntegers = elements.Where(elem => (Convert.ToInt32(elem) % 2) != 0);
            oddIntegers = oddIntegers.Distinct();
            string title = "Odd integers:";
            PrintToFile(oddIntegers, writePath, title);
        }
        
        public void Task3()
        {
            string readPath = @"dataPart1Task3.txt";
            string writePath = @"outputPart1Task3.txt";
            string text = ReadFromFile(readPath);
            string[] elements = text.Split(' ');
            var result = elements.Where(elem => Convert.ToInt32(elem) > 0 && elem.Length == 2);
            result = result.OrderBy(elem => elem).ToList();
            string title = "Sorted two-digit integers:";
            PrintToFile(result, writePath, title);
        }

        public void Task4()
        {
            string readPath = @"dataPart1Task4.txt";
            string writePath = @"outputPart1Task4.txt";
            string text = ReadFromFile(readPath);
            string[] words = text.Split(' ');
            var sorderWords = words.OrderBy(elem => elem.Length).ThenByDescending(i => i);
            string title = "Sorted two - digit integers:";
            PrintToFile(sorderWords, writePath, title);
        }
        
        public void Task5()
        {
            string readPath = @"dataPart1Task5.txt";
            string writePath = @"outputPart1Task5.txt";
            string text = ReadFromFile(readPath);
            string[] parts = text.Split(new[] { ' ' }, 2);
            int d = Convert.ToInt32(parts[0]);
            string[] elements = parts[1].Split(' ');
            var a = elements.SkipWhile(element => Convert.ToInt32(element) < d);
            var b = elements.Where(elem => Convert.ToInt32(elem) % 2 != 0 && Convert.ToInt32(elem) > 0);
            var result = b.Reverse();
            string title = "New sequence: ";
            PrintToFile(result, writePath, title);
        }

        public void DoTasksPart1()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
    }
}
