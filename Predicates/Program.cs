using System;
using System.Collections.Generic;

namespace Predicate2
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> predicateEven = new Predicate<int>(GetPairs);
            Predicate<int> predicateOdd = new Predicate<int>(GetOdd);

            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            List<int> resultEven = list.FindAll(predicateEven);
            List<int> resultOdd = list.FindAll(predicateOdd);

            Console.WriteLine("Números pares:");
            foreach (var item in resultEven)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Números Impares:");
            foreach (var item in resultOdd)
            {
                Console.WriteLine(item);
            }

        }

        static bool GetPairs(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }

        static bool GetOdd(int num)
        {
            if (num % 2 != 0) return true;
            else return false;
        }

        static bool GetPrimeNumbers(int num)
        {
            int counter = 0;

            for (int i = num; i > 0; i--)
            {
                if (num % i == 0)
                {
                    counter++;
                }
            }

            if (counter == 2)
                return true;
            else
                return false;
        }

    }
}
