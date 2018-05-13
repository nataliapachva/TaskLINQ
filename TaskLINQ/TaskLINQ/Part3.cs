using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLINQ
{
    public class Part3
    {
        public List<Client> LoadData()
        {
            string readPath = @"clients.txt";
            List<Client> clients = new List<Client>();
            using (StreamReader sr = new StreamReader(readPath, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    Client client = new Client(data[0], Convert.ToInt32(data[1]), Convert.ToInt32(data[2]), Convert.ToDouble(data[3]));
                    clients.Add(client);
                }
            }
            return clients;
        }
        public void PrintToFile<T>(IEnumerable<T> list, string writePath, string title)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.WriteLine(title);
                foreach (T elem in list)
                {
                    sw.WriteLine(elem);
                }
            }
        }
        public void PrintToFile(Client client, string writePath, string title)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine(title);
                sw.WriteLine(client);
            }
        }
        public void PrintToFile(int a, string writePath, string title)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine(title);
                sw.WriteLine(a);
            }
        }

        public Client FindMinDurationOfClasses(List<Client> clients)
        {
            double min = clients.Min(elem => elem.DurationOfClasses);
            Client client = clients.Find(elem => elem.DurationOfClasses == min);

            return client;
        }

        public Client FindMaxDurationOfClasses(List<Client> clients)
        {
            double max = clients.Max(elem => elem.DurationOfClasses);
            Client client = clients.Find(elem => elem.DurationOfClasses == max);

            return client;
        }

        public void FindYearOfMaxDurationOfClasses(List<Client> clients)
        {
            var groupClientsByYear = clients.GroupBy(client => client.Year, client => client.DurationOfClasses)
                .Select(c=>new { Year = c.Key, Duration = c.Sum() })
                .OrderByDescending(o=> o.Duration ).ThenBy(o=>o.Year);
            var item= groupClientsByYear.First();
            string writePath = @"yearOfMaxDurationOfClasses.txt";
            string title = "Year of max duration of classes: ";
            PrintToFile(item.Year, writePath, title);
        }


        public void TotalDurationOfClasses(List<Client> clients)
        {
            var groupClientsById = clients.GroupBy(client => client.Id, client => client.DurationOfClasses);
            var clientsWithTotalDuration = groupClientsById.Select(c => new { Id = c.Key, Duration = c.Sum() });
            var sortedCliets= clientsWithTotalDuration.OrderByDescending(o => o.Duration).ThenBy(o => o.Id);
            string writePath = @"totalDurationOfClasses.txt";
            string title = "Clients with TotalDurationOfClasses: ";
            PrintToFile(sortedCliets, writePath, title);
        }

        public void CountOfMonths(List<Client> clients)
        {
            var groupClientsById = clients.GroupBy(client => client.Id, client => client.Month);
            var clientsWithCountOfMonths = groupClientsById.Select(c => new { Id = c.Key, Monts = c.Count() });
            string writePath = @"countOfMonths.txt";
            string title = "Clients with CountOfMonths: ";
            PrintToFile(clientsWithCountOfMonths, writePath, title);
        }

        public void DoTasksPart3()
        {
            List<Client> clients = LoadData();
            Client clientMaxDurationOfClasses = FindMaxDurationOfClasses(clients);
            string title1 = "client with max duration of classes: ";
            string path1 = @"clientMaxDurationOfClasses.txt";
            PrintToFile(clientMaxDurationOfClasses, path1, title1);
            Client clientMinDurationOfClasses = FindMinDurationOfClasses(clients);
            string title2 = "client with min duration of classes: ";
            string path2 = @"clientMinDurationOfClasses.txt";
            PrintToFile(clientMinDurationOfClasses, path2, title2);
            FindYearOfMaxDurationOfClasses(clients);
            TotalDurationOfClasses(clients);
            CountOfMonths(clients);
        }
    }
}
