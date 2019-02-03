using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCaminhoCerto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#######");

            int[,] ar = { { 1, -3 }, { 1, 2 }, { 3, 4 } };

            ClosestXdestinations(3, ar, 1);

            Console.Read(); //Pause
        }


        public static List<List<int>> ClosestXdestinations(int numDestinations,
                                            int[,] allLocations,
                                            int numDeliveries)
        {
            List<Calculate> list = new List<Calculate>();
            List<List<int>> listResult = new List<List<int>>();

            for (int x = 0; x < numDestinations; x++)
            {

                int xValue = allLocations[x, 0];
                int yValue = allLocations[x, 1];

                var calc = CalculeDistance(xValue, yValue);

                list.Add(new Calculate() { distance = calc, index = x, x = xValue, y = yValue });
            }

            var listOrdered = list.OrderBy(x => x.distance);
            var listCroped = listOrdered.Take(1);

            foreach (var item in listCroped)
            {
                List<int> l = new List<int>();
                l.Add(item.x);
                l.Add(item.y);
                listResult.Add(l);
            }

            return listResult;
        }

        public static double CalculeDistance(int x, int y)
        {
            int result = 0;
            double resultFinal = 0;

            result = (x * x) + (y * y);

            resultFinal = Convert.ToSingle(Math.Sqrt(result));

            return resultFinal;
        }

        public class Calculate
        {
            public int index { get; set; }
            public double distance { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}
