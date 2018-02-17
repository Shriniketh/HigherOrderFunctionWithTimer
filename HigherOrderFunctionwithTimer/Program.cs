using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigherOrderFunctionwithTimer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var data = GetStringDataFromAWebsite();

            CheckIfPrimeNumber();

            Console.ReadLine();
        }

        public static string GetStringDataFromAWebsite()
        {
            var client = new WebClient();

            Func<string> download = () => client.DownloadString("https://www.facebook.com");

            var data = download.WithRetry();

            Console.WriteLine(data);

            return data;
        }

        public static void CheckIfPrimeNumber()
        {
            var timeMeasurement = new TimeMeasurement();

            var timeElapsed = timeMeasurement.Measure(() =>
            {
                var primeNumbers = RandomNumber().Find(IsPrimeNumber).Take(3).ToList();

                foreach (var item in primeNumbers)
                {
                    Console.WriteLine(item);
                }
            }
                );

            Console.WriteLine(timeElapsed);
        }

        public static IEnumerable<int> RandomNumber()
        {
            Random rand = new Random();
            while (true)
            {
                yield return rand.Next(1000);
            }

        }

        public static IEnumerable<int> Find(this IEnumerable<int> value, Func<int, bool> test)
        {
            foreach (var number in value)
            {
                if (test(number))
                {
                    yield return number;
                }
            }
        }

        public static bool IsPrimeNumber(int number)
        {
            int count = 0;

            Console.WriteLine($"Testing the number {number}");

            if (number != 1 && number != 0)
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        count++;
                    }
                    if (count > 0)
                        break;
                }
            }
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
