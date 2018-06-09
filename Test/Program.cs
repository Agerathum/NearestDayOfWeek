using System;
using System.Linq;

namespace Test
{
    class Program
    {
        private static Random rand = new Random();

        private static DateTime[] randomDays = new DateTime[rand.Next(10, 29)];


        static void Main(string[] args)
        {

            GenerateRandomDays();
            Console_ShowGeneratedDays();

            Console.WriteLine($"Ближайший день недели исключая сегоднешний день - {NearestDayOfWeek().DayOfWeek}, {NearestDayOfWeek().Day} число");

            Console.ReadKey();
        }


        private static void GenerateRandomDays()
        {
            randomDays = new DateTime[rand.Next(10, 29)];

            for (int i = 0; i < randomDays.Length; i++)
            {
                DateTime generDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, rand.Next(1, 29),DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                randomDays[i] = generDate;
            }


        }

        private static void Console_ShowGeneratedDays()
        {
            Console.WriteLine($"Сгенерированные дни недели ({randomDays.Length} дней) созданные в случайном порядке в отсортированном виде");
            Console.Write(new string('-', 119));
            Console.WriteLine();

            DateTime[] sortedDated = randomDays.OrderBy(o => o.Date).ToArray();

            for (int i = 0; i < sortedDated.Length; i++)
            {
                Console.WriteLine($"День недели - {sortedDated[i].DayOfWeek}, {sortedDated[i].Day} число");
            }

            Console.Write(new string('-', 40));
            Console.WriteLine();
        }


        private static DateTime NearestDayOfWeek()
        {
            DateTime nearestDay = DateTime.MinValue;

            long min = long.MaxValue;
            long diff = 0;

            for (int i = 0; i < randomDays.Length; i++)
            {
                if(DateTime.Now.Day < randomDays[i].Day)
                {
                    diff = Math.Abs(randomDays[i].Ticks - DateTime.Now.Ticks);

                    if (diff < min)
                    {
                        min = diff;
                        nearestDay = randomDays[i];
                    }
                }
            }
            return nearestDay;
        }
    }
}
