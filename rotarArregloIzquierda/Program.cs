using System;

namespace rotarArregloIzquierda
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arreglo = new int[5] { 1, 2, 3, 4, 5 };

            rotLeft(arreglo, 4);

            foreach (int i in arreglo)
            {
                Console.Write("[" + i + "]");
            }
        }

        public static void rotLeft(int[] arr, int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                int temp = arr[0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = temp;
            }
        }
    }
}
