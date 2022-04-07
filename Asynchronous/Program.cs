using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Asynchronous
            //Console.WriteLine("Loading...");
            //Asynchronous.WaitForIt();
            //await Asynchronous.WaitForIt2();

            var timeElapsed = await Parallelism.Main();
            Console.WriteLine($"Both processes finished after {timeElapsed / 1000m} seconds");
        }
    }

    public class Asynchronous
    {
        public static async Task WaitForIt()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Five seconds complete");
        }

        public static async Task WaitForIt2()
        {
            await Task.Delay(10000);
            Console.WriteLine("Ten seconds complete");
        }
    }

    public class Parallelism
    {
        public static async Task<long> Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = Process1(); // await Process1();
            var task2 = Process2(); // await Process2();

            await Task.WhenAll(task1, task2); // Espera cuando TODAS las tareas se completan
            //await Task.WhenAny(task1, task2); // Espera a que cualquiera de las tareas se complete

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;

        }

        public static async Task Process1()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
            });
        }

        public static async Task Process2()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }
    }
}
