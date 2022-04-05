using System;

namespace Hiker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Paseo = new string[8] { "U", "D", "D", "D", "U", "D", "U", "U" };
            //string[] Paseo = new string[8] { "D", "U", "D", "U", "D", "U", "D", "U" };

            int conteoValles = countingValleys(Paseo);
            Console.WriteLine(conteoValles);
        }

        public static int countingValleys(string[] paseo)
        {
            int nivelMar = 0;
            int contar = 0;

            for (int i = 0; i < paseo.Length; i++)
            {
                if (paseo[i].Equals("U"))
                {
                    nivelMar++;

                    if (nivelMar == 0)
                        contar++;
                }
                else if (paseo[i].Equals("D"))
                {
                    nivelMar--;
                }

            }

            return contar;
        }
    }
}
