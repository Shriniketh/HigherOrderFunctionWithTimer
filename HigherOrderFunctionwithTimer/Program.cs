using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherOrderFunctionwithTimer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            CheckIfPrimeNumber();

            Console.ReadLine();
        }

        public static void CheckIfPrimeNumber()
        {
            var timeMeasurement = new TimeMeasurement();

            var timeElapsed = timeMeasurement.Measure(() =>
            {
                var primeNumbers = RandomNumber().IsPrimeNumber().Take(3).ToList();

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

        public static IEnumerable<int> IsPrimeNumber(this IEnumerable<int> value)
        {
            foreach (var item in value)
            {
                int count = 0;

                Console.WriteLine($"Testing the number {item}");

                if (item != 1 && item != 0)
                {
                    for (int i = 2; i < item; i++)
                    {
                        if (item % i == 0)
                        {
                            count++;
                        }
                        if (count > 0)
                            break;
                    }
                    if (count == 0)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
