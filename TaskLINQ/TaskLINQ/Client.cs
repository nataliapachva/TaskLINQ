using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLINQ
{
    public class Client
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public double DurationOfClasses { get; set; }

        public Client(string id, int year, int month, double durationOfClasses)
        {
            Id = id;
            Year = year;
            Month = month;
            DurationOfClasses = durationOfClasses;
        }

        public override string ToString()
        {
            return $"{Id} {Year} {Month} {DurationOfClasses}";
        }
    }
}
